Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_poupanca_finalizar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_finalizar.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_finalizar.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

 
            ViewState.Item("sortExpression") = "dt_referencia_ini desc"



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            poupancaparametro.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
            poupancaparametro.id_situacao = 1
            poupancaparametro.id_situacao_poupanca = 1 'traz apenas parametros abertos

            Dim dsPoupancaParam As DataSet = poupancaparametro.getPoupancaParametro()

            If (dsPoupancaParam.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPoupancaParam.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "dt_referencia_ini"
                If ViewState.Item("sortExpression") = "dt_referencia_ini asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_ini desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_ini asc"
                End If

            Case "dt_referencia_fim"
                If ViewState.Item("sortExpression") = "dt_referencia_fim asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_fim desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_fim asc"
                End If

            Case "nm_situacao_poupanca"
                If ViewState.Item("sortExpression") = "nm_situacao_poupanca asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_poupanca desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_poupanca asc"
                End If

        End Select

        loadData()

    End Sub




    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                Response.Redirect("frm_poupanca_parametro.aspx?id_poupanca_parametro=" + e.CommandArgument.ToString())

            Case "delete"
                deletePoupancaParametro(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePoupancaParametro(ByVal id_poupanca_parametro As Integer)

        Try

            Dim poupancaparametro As New PoupancaParametro()
            poupancaparametro.id_poupanca_parametro = id_poupanca_parametro
            poupancaparametro.id_modificador = Convert.ToInt32(Session("id_login"))
            poupancaparametro.deletePoupancaParametro()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim lbl_id_situacao_poupanca As Label = CType(e.Row.FindControl("lbl_id_situacao_poupanca"), Label)

            e.Row.Cells(1).Text = DateTime.Parse(e.Row.Cells(1).Text).ToString("MM/yyyy")
            e.Row.Cells(2).Text = DateTime.Parse(e.Row.Cells(2).Text).ToString("MM/yyyy")

            If lbl_id_situacao_poupanca.Text.Equals(1) Then
                btn_delete.Visible = True

                Dim poupancaparam As New PoupancaParametro
                poupancaparam.id_poupanca_parametro = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
                If poupancaparam.getPoupancaCalculoMensalbyParametro > 0 Then
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir o registro. Já foi efetuado cálculo de poupança mensal para este parâmetro."
                Else
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    btn_delete.ToolTip = String.Empty
                End If
            Else 'se finalizado a poupanca
                btn_delete.Visible = False
            End If

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.id_situacao_poupanca = 1 'aberto (traz apenas as referencias abertas

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
End Class
