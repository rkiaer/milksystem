Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_mapaleite_SAP

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_mapaleite.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 119
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

            Dim mapaleite As New MapaLeite

            mapaleite.id_estabelecimento = ViewState.Item("id_estabelecimento")
            mapaleite.dt_referencia = "01/" & ViewState.Item("dt_referencia").ToString()
            If ViewState.Item("cd_rota_ini") <> "" Then
                ' 07/04/2009 - Rls17.3 - i
                'mapaleite.id_linha_ini = Convert.ToInt32(ViewState.Item("cd_rota_ini"))
                mapaleite.nm_linha_ini = ViewState.Item("cd_rota_ini")
                ' 07/04/2009 - Rls17.3 - f
            End If
            If ViewState.Item("cd_rota_fim") <> "" Then
                ' 07/04/2009 - Rls17.3 - i
                'mapaleite.id_linha_fim = Convert.ToInt32(ViewState.Item("cd_rota_fim"))
                mapaleite.nm_linha_fim = ViewState.Item("cd_rota_fim")
                ' 07/04/2009 - Rls17.3 - f
            End If
            mapaleite.imprime_semmovto = ViewState.Item("chk_movto")
            mapaleite.nm_arquivo = ViewState.Item("nm_arquivo")

            ' 07/04/2009 - Rls17.3 - i 
            'exportData = mapaleite.exportMapaLeite()
            'lbl_totallidas.Text = mapaleite.nr_linhaslidas
            'lbl_totallinhas.Text = mapaleite.nr_linhasexportadas
            Dim dsMapaLeite As DataSet = mapaleite.getMapaLeiteByFilters()
            If dsMapaLeite.Tables(0).Rows.Count > 0 Then
                exportData = mapaleite.exportMapaLeiteSAP()

                lbl_totallidas.Text = mapaleite.nr_linhaslidas
                lbl_totallinhas.Text = mapaleite.nr_linhasexportadas
            Else
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If
            ' 07/04/2009 - Rls17.3 - f 


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia") = dt_referencia.Text
            ViewState.Item("cd_rota_ini") = txt_cd_rota_ini.Text
            ViewState.Item("cd_rota_fim") = txt_cd_rota_fim.Text
            If Trim(Me.txt_cd_rota_fim.Text) = "" Then
                ViewState.Item("cd_rota_fim") = Me.txt_cd_rota_ini.text
            End If
            ViewState.Item("chk_movto") = chk_movto.Checked

            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationSettings.AppSettings("PathFiles").ToString()
            'Fran 30/05/2012 chamado 1556 i alteraçao nome arquivo THEMIS - 502 é o final da rotina no SAP BR1MM05502
            'lnomearquivo = "\MilkSystem_MapaLeite_" & Now() & Session.SessionID & ".txt"
            lnomearquivo = "\MilkSystem_MapaLeite_" & Now() & "502" & ".txt"
            'Fran 30/05/2012 chamado 1556 i alteraçao nome arquivo THEMIS
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
            usuariolog.id_menu_item = 119
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


            If InStr(arquivos(index), "MilkSystem_MapaLeite") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
