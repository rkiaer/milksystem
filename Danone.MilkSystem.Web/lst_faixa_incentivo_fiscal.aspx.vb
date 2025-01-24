Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_faixa_incentivo_fiscal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("ds_validade") = txt_ds_validade.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        'Fran 26/11/2009 i chamado 520 Maracanau
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Fran 26/11/2009 f chamado 520 Maracanau

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_faixa_incentivo_fiscal.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_incentivo_fiscal.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 30
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            'Fran 26/11/2009 i chamado 520 Maracanau
            'cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_situacao.SelectedValue = 1

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 26/11/2009 f chamado 520 Maracanau

            ViewState.Item("sortExpression") = "ds_validade asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("faixa", txt_ds_validade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_validade") = customPage.getFilterValue("faixa", txt_ds_validade.ID)
            txt_ds_validade.Text = ViewState.Item("ds_validade").ToString()
        Else
            ViewState.Item("ds_validade") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("faixa", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        'Fran 26/11/2009 i chamado 520 Maracanau
        If Not (customPage.getFilterValue("faixa", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("faixa", cbo_estabelecimento.ID)
            cbo_situacao.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        'Fran 26/11/2009 f chamado 520 Maracanau


        If Not (customPage.getFilterValue("faixa", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("faixa", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("faixa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim faixaincentivofiscal As New FaixaIncentivoFiscal


            faixaincentivofiscal.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaincentivofiscal.ds_validade = ViewState.Item("ds_validade").ToString()
            If (faixaincentivofiscal.ds_validade.ToString.Trim <> "") Then
                faixaincentivofiscal.dt_validade = String.Concat("01/", faixaincentivofiscal.ds_validade)
            End If
            'Fran 26/11/2009 i chamado 520 Maracanau
            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaincentivofiscal.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            'Fran 26/11/2009 f chamado 520 Maracanau

            Dim dsFaixaIncentivoFiscal As DataSet = faixaincentivofiscal.getFaixaIncentivoFiscalByFilters()

            If (dsFaixaIncentivoFiscal.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsFaixaIncentivoFiscal.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            'Fran 26/11/2009 i chamado 520 Maracanau
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If
                'Fran 26/11/2009 f chamado 520 Maracanau
            Case "ds_validade"
                If (ViewState.Item("sortExpression")) = "ds_validade asc" Then
                    ViewState.Item("sortExpression") = "ds_validade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_validade asc"
                End If


            Case "nr_faixa_inicio"
                If (ViewState.Item("sortExpression")) = "nr_faixa_inicio asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_inicio asc"
                End If


            Case "nr_faixa_fim"
                If (ViewState.Item("sortExpression")) = "nr_faixa_fim asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_fim desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_fim asc"
                End If

            Case "nr_incentivo_fiscal"
                If (ViewState.Item("sortExpression")) = "nr_incentivo_fiscal asc" Then
                    ViewState.Item("sortExpression") = "nr_incentivo_fiscal desc"
                Else
                    ViewState.Item("sortExpression") = "nr_incentivo_fiscal asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("faixa", txt_ds_validade.ID, ViewState.Item("ds_validade").ToString)
            customPage.setFilter("faixa", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("faixa", "PageIndex", gridResults.PageIndex.ToString())
            'Fran 26/11/2009 i chamado 520 Maracanau
            customPage.setFilter("faixa", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            'Fran 26/11/2009 f chamado 520 Maracanau

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_faixa_incentivo_fiscal.aspx?id_faixa_incentivo_fiscal=" + e.CommandArgument.ToString())

            Case "delete"
                deleteFaixaIncentivoFiscal(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteFaixaIncentivoFiscal(ByVal id_faixa_incentivo_fiscal As Integer)

        Try

            Dim faixaincentivofiscal As New FaixaIncentivoFiscal()
            faixaincentivofiscal.id_faixa_incentivo_fiscal = id_faixa_incentivo_fiscal
            faixaincentivofiscal.id_modificador = Convert.ToInt32(Session("id_login"))
            faixaincentivofiscal.deleteFaixaIncentivoFiscal()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 30
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_faixa_incentivo_fiscal.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
