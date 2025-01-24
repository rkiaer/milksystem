Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_pre_romaneio_controle_leite
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True


        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = Me.txt_dt_inicio.Text.Trim
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        'ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("nm_linha") = txt_nm_linha.Text



        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_pre_romaneio_controle_leite.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pre_romaneio_controle_leite.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 226
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = ""


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio
            Dim dsromaneio As DataSet

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If

            If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_romaneio")
            End If
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString

            dsromaneio = romaneio.getRomaneioControleLeitePreRomaneio
            
            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Try


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = Me.txt_dt_inicio.Text.Trim
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        'ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("nm_linha") = txt_nm_linha.Text

        loadData()

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 226
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Response.Redirect("frm_pre_romaneio_controle_leite_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&nm_linha=" + ViewState.Item("nm_linha").ToString)
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
        End If
    End Sub


End Class

