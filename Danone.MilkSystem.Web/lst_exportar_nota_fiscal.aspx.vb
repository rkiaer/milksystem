Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_nota_fiscal

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_nota_fiscal.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 54
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
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

            notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
            notafiscal.dt_inicio = ViewState.Item("dt_inicio").ToString
            notafiscal.dt_fim = ViewState.Item("dt_fim").ToString
            notafiscal.nm_arquivo = ViewState.Item("nm_arquivo")
            notafiscal.st_exportacao = ViewState.Item("st_exportacao")   ' 06/10/2008
            notafiscal.id_situacao = 1      ' 08/10/2008 - Somente notas ativas
            notafiscal.id_modificador = Session("id_login")   ' 29/10/2008  Para exportar o usuário que está logado

            notafiscal.exportNotaFiscal()

            lbl_totallidas.Text = notafiscal.nr_linhaslidas
            lbl_totallinhas.Text = notafiscal.nr_linhasexportadas

            Return True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
            Return False

        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text
            ViewState.Item("dt_fim") = txt_dt_fim.Text
            If (Me.txt_dt_fim.Text.Trim) = "" Then
                ViewState.Item("dt_fim") = Me.txt_dt_inicio.Text.Trim
            End If
            If ck_notas_exportadas.Checked = True Then
                ViewState.Item("st_exportacao") = "S"
            Else
                ViewState.Item("st_exportacao") = "N"
            End If


            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationSettings.AppSettings("PathFiles").ToString()
            lnomearquivo = "\MilkSystem_NotaFiscal_" & Now() & Session.SessionID & ".txt"
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
            usuariolog.id_menu_item = 54
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            If exportData() = True Then

                Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
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


            If InStr(arquivos(index), "MilkSystem_NotaFiscal") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
