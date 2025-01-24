Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_frete_kpi_densidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click



        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_data_ini.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_data_ini.Text.Trim()
            'ViewState.Item("dt_fim") = txt_data_fim.Text
        Else
            ViewState.Item("dt_inicio") = String.Empty
            'ViewState.Item("dt_fim") = String.Empty
        End If



        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_frete_kpi_densidade.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_kpi_densidade.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 266
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim frete As New CalculoFrete

            frete.id_estabelecimento = cbo_estabelecimento.SelectedValue
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                frete.dt_referencia = String.Concat("01/", ViewState.Item("dt_inicio").ToString)
            End If
            Dim periodo As New FretePeriodo
            periodo.dt_referencia = frete.dt_referencia
            Dim dsperiodo As DataSet = periodo.getFretePeriodo()
            If dsperiodo.Tables(0).Rows.Count > 0 Then
                frete.id_frete_periodo = dsperiodo.Tables(0).Rows(0).Item("id_frete_periodo").ToString
                ViewState.Item("id_frete_periodo") = frete.id_frete_periodo.ToString
                Dim dsfrete As DataSet = frete.getFreteKpiDensidade

                If (dsfrete.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridResults.DataBind()


                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_data_ini.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_data_ini.Text
            'ViewState.Item("dt_fim") = txt_data_fim.Text
        Else
            ViewState.Item("dt_inicio") = String.Empty
            'ViewState.Item("dt_fim") = String.Empty
        End If

        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True AndAlso gridResults.Rows.Count > 0 Then
            ViewState.Item("dt_inicio") = String.Concat("01/", txt_data_ini.Text.Trim())

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 266
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_frete_kpi_densidade_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_inicio").ToString + "&id_frete_periodo=" + ViewState.Item("id_frete_periodo").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        Else
            messageControl.Alert("Não há linhas para serem exportadas para o Excel!")

        End If
    End Sub

End Class

