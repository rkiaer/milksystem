Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_relatorio_anual_web

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_qualidade_web.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 155
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("extratoanual", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("extratoanual", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoanual", dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ano_referencia") = customPage.getFilterValue("extratoanual", dt_referencia.ID)
            dt_referencia.Text = ViewState.Item("ano_referencia").ToString()
        Else
            ViewState.Item("ano_referencia") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoanual", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("extratoanual", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("extratoanual", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("extratoanual", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoanual", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("extratoanual", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If



        If (hasFilters) Then
            customPage.clearFilters("extratoanual")
        End If


    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("extratoanual", dt_referencia.ID, ViewState.Item("ano_referencia").ToString)
            customPage.setFilter("extratoanual", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("extratoanual", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("extratoanual", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("extratoanual", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

            customPage.setFilter("extratoanual", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub
    ' 02/12/2009 - Maracanau - i
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Try
            If Page.IsValid Then

                ViewState.Item("ano_referencia") = dt_referencia.Text
                ViewState.Item("dt_referencia_ini") = "01/01/" & dt_referencia.Text
                ViewState.Item("dt_referencia_fim") = "31/12/" & dt_referencia.Text
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text

                customPage.clearFilters("extratoanual")

                saveFilters()

                loadData()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_relatorio_anual_web.aspx?st_incluirlog=N")

    End Sub
    Private Sub loadData()

        Try
            Dim extratoqualidadeweb As New ExtratoQualidadeWeb

            ' 11/12/2015 - Montar referencia inicial e final - i 
            extratoqualidadeweb.dt_referencia_start = ViewState.Item("dt_referencia_ini").ToString
            extratoqualidadeweb.dt_referencia_end = ViewState.Item("dt_referencia_fim").ToString
            ' 11/12/2015 - Montar referencia inicial e final - f 

            extratoqualidadeweb.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            extratoqualidadeweb.cd_pessoa = ViewState.Item("cd_pessoa").ToString

            Dim dsPropriedadesMovimento As DataSet = extratoqualidadeweb.getExtratoAnualPropriedadesWeb()  ' Traz as propriedades com movimento no mes

            If (dsPropriedadesMovimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPropriedadesMovimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Não há propriedades com movimento no mês para o produtor informado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_imprimir As HyperLink = CType(e.Row.FindControl("hl_imprimir"), HyperLink)
            Dim lbl_id_unid_producao As Label = CType(e.Row.FindControl("lbl_id_unid_producao"), Label)

            hl_imprimir.NavigateUrl = String.Format("frm_relatorio_extrato_anual_web.aspx?ano_referencia={0}", ViewState.Item("ano_referencia").ToString) & String.Format("&id_propriedade={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value & String.Format("&id_unid_producao={0}", lbl_id_unid_producao.Text))

        End If

    End Sub
End Class
