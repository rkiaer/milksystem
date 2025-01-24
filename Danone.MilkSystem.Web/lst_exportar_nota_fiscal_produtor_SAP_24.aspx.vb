Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_nota_fiscal_produtor_SAP_24

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_nota_fiscal_produtor_SAP_24.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 238
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        btn_exportar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function exportData() As Boolean

        Try

            Dim notafiscal As New NotaFiscal
            ViewState.Item("SemNaturezaOperacao") = "N"
            ViewState.Item("nm_erro") = String.Empty
            notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
            notafiscal.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)
            notafiscal.nm_arquivo = ViewState.Item("nm_arquivo")
            notafiscal.st_exportacao = ViewState.Item("st_exportacao")
            notafiscal.id_modificador = Session("id_login")   'Para exportar o usuário que está logado

            exportData = notafiscal.exportNotaFiscalCreditoICMS24SAP
            If exportData = False Then 'se tem erros

                If notafiscal.cd_erro <> "SEM LINHAS" Then 'se existem linhas, concatena com a mensagem dados do produtor com erro
                    notafiscal.nm_erro = notafiscal.nm_erro.ToString & " Produtor: " & notafiscal.cd_pessoa & ", propriedade: " & notafiscal.id_propriedade.ToString & ", nota fiscal: " & notafiscal.nr_nota_fiscal & " e série: " & notafiscal.nr_serie & "."
                End If
                ViewState.Item("nm_erro") = notafiscal.nm_erro.ToString
            End If


            lbl_totallidas.Text = notafiscal.nr_linhaslidas
            lbl_totallinhas.Text = notafiscal.nr_linhasexportadas

        Catch ex As Exception

            ViewState.Item("nm_erro") = ex.Message.ToString 'fran 07/06/2010
            messageControl.Alert(ex.Message)
            Return False

        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            If ck_notas_exportadas.Checked = True Then
                ViewState.Item("st_exportacao") = "S"
            Else
                ViewState.Item("st_exportacao") = "N"
            End If


            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            lnomearquivo = "\Milsystem_NotaFiscal_creditoICMS_24_" & Now() & ".txt"
            lnomearquivo = Replace(lnomearquivo, ":", "")
            lnomearquivo = Replace(lnomearquivo, " ", "")
            lnomearquivo = Replace(lnomearquivo, "/", "")


            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

            deleteArquivos()

            lbl_totallidas.Visible = True
            lbl_totallinhas.Visible = True

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 238
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            If exportData() = True Then

                lbl_aguarde.CssClass = "aguardenormal"

                Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
            Else
                lbl_aguarde.CssClass = "aguardenormal"

                messageControl.Alert(ViewState.Item("nm_erro").ToString)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer
        Dim ldata As Date
        Dim ldata_limite As Date

        ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName


            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor


            If InStr(arquivos(index), "Milsystem_NotaFiscal_creditoICMS_24") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
