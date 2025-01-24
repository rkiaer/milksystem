Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_pessoa_propriedade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade.aspx")
        If Not Page.IsPostBack Then
            loadData()
        End If


    End Sub




    Private Sub loadData()

        Try

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
            End If

            Dim estabelecimento As New Estabelecimento(Convert.ToInt32(ViewState.Item("id_estabelecimento")))
            lbl_estabelecimento.Text = estabelecimento.cd_estabelecimento & " - " & estabelecimento.nm_estabelecimento

            Dim pessoa As New Pessoa(Convert.ToInt32(ViewState.Item("id_pessoa")))
            lbl_produtor.Text = pessoa.cd_pessoa & " - " & pessoa.nm_pessoa

            Dim propriedade As New Propriedade

            propriedade.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            propriedade.id_situacao = 1  ' Somente ativas

            ViewState.Item("saldodisponivel_produtor") = 0   ' Inicializa totalizador

            Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

            If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nm_propriedade"
                If (ViewState.Item("sortExpression")) = "nm_propriedade asc" Then
                    ViewState.Item("sortExpression") = "nm_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_propriedade asc"
                End If


        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                'saveFilters()
                Response.Redirect("frm_propriedade.aspx?id_propriedade=" + e.CommandArgument.ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)

            Case "delete"
                deletePropriedade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePropriedade(ByVal id_propriedade As Integer)

        Try
            Dim propriedade As New Propriedade()
            propriedade.id_propriedade = id_propriedade
            propriedade.id_modificador = Convert.ToInt32(Session("id_login"))
            propriedade.deletePropriedade()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
    '    'saveFilters()
    '    Response.Redirect("frm_propriedade.aspx?id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)
    'End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim saldodisponivel As New SaldoDisponivel

            saldodisponivel.id_propriedade = Convert.ToInt32(e.Row.Cells(0).Text)
            saldodisponivel.dt_referencia = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            'saldodisponivel.dt_referencia = "01/05/2008"

            e.Row.Cells(2).Text = saldodisponivel.getSaldoDisponivel()

            ViewState.Item("saldodisponivel_produtor") = Convert.ToDecimal(ViewState.Item("saldodisponivel_produtor")) + Convert.ToDecimal(e.Row.Cells(2).Text)


        End If
        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(2).Text = Convert.ToString(ViewState.Item("saldodisponivel_produtor"))
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_pessoa.aspx?id_pessoa=" & ViewState.Item("id_pessoa"))
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i
        Response.Redirect("frm_propriedade.aspx?id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)

    End Sub
End Class
