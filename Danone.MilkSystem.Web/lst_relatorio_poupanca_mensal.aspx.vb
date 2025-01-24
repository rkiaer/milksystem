Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_relatorio_poupanca_mensal

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_poupanca_mensal.aspx")
        If Not Page.IsPostBack Then
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

        If Not (customPage.getFilterValue("extratopoupancames", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("extratopoupancames", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratopoupancames", cbo_referencia_poupanca.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_poupanca_parametro") = customPage.getFilterValue("extratopoupancames", cbo_referencia_poupanca.ID)
            cbo_referencia_poupanca.SelectedValue = ViewState.Item("id_poupanca_parametro").ToString()
        Else
            ViewState.Item("id_poupanca_parametro") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratopoupancames", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("extratopoupancames", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("extratopoupancames", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("extratopoupancames", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratopoupancames", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("extratopoupancames", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If



        If (hasFilters) Then
            customPage.clearFilters("extratoqualidade")
        End If


    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("extratopoupancames", cbo_referencia_poupanca.ID, ViewState.Item("id_poupanca_parametro").ToString)
            customPage.setFilter("extratopoupancames", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("extratopoupancames", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("extratopoupancames", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("extratopoupancames", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

            customPage.setFilter("extratopoupancames", "PageIndex", gridResults.PageIndex.ToString())

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
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.id_situacao = 1
            '19/10/2016 traz todos os periodo
            poupancaparametro.dt_referencia_fim = DateAdd(DateInterval.Year, -1, Convert.ToDateTime(String.Concat("01/01/", Format(DateTime.Parse(Now), "yyyy").ToString)))

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametro()
            cbo_referencia_poupanca.DataTextField = "ds_periodo_poupanca"
            cbo_referencia_poupanca.DataValueField = "id_poupanca_parametro"
            cbo_referencia_poupanca.DataBind()
            cbo_referencia_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_referencia_poupanca.SelectedValue = 0
        Else
            cbo_referencia_poupanca.Items.Clear()
            cbo_referencia_poupanca.Enabled = False
        End If

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
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

                ViewState.Item("dt_referencia_ini") = String.Concat("01/", Left(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString
                ViewState.Item("dt_referencia_fim") = String.Concat("01/", Right(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
                ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue


                If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                    ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
                Else
                    ViewState.Item("id_pessoa") = 0
                End If

                customPage.clearFilters("extratopoupancames")

                saveFilters()

                loadData()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_relatorio_poupanca_mensal.aspx")

    End Sub
    Private Sub loadData()

        Try
            Dim poupancamensal As New Poupanca

            poupancamensal.dt_referencia_ini = ViewState.Item("dt_referencia_ini").ToString
            poupancamensal.dt_referencia_fim = ViewState.Item("dt_referencia_fim").ToString
            poupancamensal.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            poupancamensal.id_pessoa = ViewState.Item("id_pessoa").ToString

            Dim dsextratopoupancames As DataSet = poupancamensal.getPoupancaPropriedades()  ' Traz as propriedades que tenhamm realizado calculo poupancamensal

            If (dsextratopoupancames.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsextratopoupancames.Tables(0), "id_propriedade")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Não há cálculo de poupança realizado para o produtor informado. Por favor tente novamente.")
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
            'Dim lbl_id_unid_producao As Label = CType(e.Row.FindControl("lbl_id_unid_producao"), Label)

            ' hl_imprimir.NavigateUrl = String.Format("frm_relatorio_poupanca_mensal.aspx?dt_referencia_ini={0}", ViewState.Item("dt_referencia_ini").ToString) & String.Format("&dt_referencia_fim={0}", ViewState.Item("dt_referencia_fim").ToString) & String.Format("&id_propriedade={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value & String.Format("&id_unid_producao={0}", lbl_id_unid_producao.Text) & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&dspropriedade={0}", e.Row.Cells(0).Text.Trim))
            hl_imprimir.NavigateUrl = String.Format("frm_relatorio_poupanca_mensal.aspx?dt_referencia_ini={0}", ViewState.Item("dt_referencia_ini").ToString) & String.Format("&dt_referencia_fim={0}", ViewState.Item("dt_referencia_fim").ToString) & String.Format("&id_propriedade={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&dspropriedade={0}", e.Row.Cells(0).Text.Trim))

        End If

    End Sub
End Class
