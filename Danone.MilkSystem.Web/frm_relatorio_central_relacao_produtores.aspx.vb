Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_relatorio_central_relacao_produtores
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_central_relacao_produtores.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 104
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_inicio") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                ViewState.Item("id_pessoa") = Request("id_pessoa")
                ViewState.Item("dt_inicio") = Request("dt_inicio")
                ViewState.Item("dt_fim") = Request("dt_fim")
                ViewState.Item("cbo_tipo") = Request("cbo_tipo")

                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If
        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido
            Dim dspedido As DataSet

            If Not (ViewState.Item("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState.Item("id_pessoa").ToString().Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState.Item("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If

            If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se tipo do relatorio é ANALITICO
                dspedido = pedido.getSpendProdutoresAnalitico
            Else
                dspedido = pedido.getSpendProdutores
            End If

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se é tipo analitico
                    gridResults.Columns.Item(3).Visible = True 'propriedade
                Else
                    gridResults.Columns.Item(3).Visible = False 'propriedade
                End If

                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messagecontrol.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_estabelecimento As Label = CType(e.Row.FindControl("lbl_id_estabelecimento"), Label)

            'Campo estabelecimento
            Select Case CInt(lbl_id_estabelecimento.Text)
                Case 1
                    e.Row.Cells(0).Text = "Poços de Caldas"
                Case 2
                    e.Row.Cells(0).Text = "Guaratinguetá"
                Case 6
                    e.Row.Cells(0).Text = "Águas da Prata"
                Case 9
                    e.Row.Cells(0).Text = "Maracanaú"
                Case Else
                    e.Row.Cells(0).Text = lbl_id_estabelecimento.Text
            End Select

            'Valor Total da Nota
            e.Row.Cells(5).Text = Round(CDec(e.Row.Cells(5).Text), 2).ToString

            'Total Volume
            e.Row.Cells(6).Text = FormatNumber(e.Row.Cells(6).Text, 0)

            'Valor Total Compra Central
            e.Row.Cells(7).Text = Round(CDec(e.Row.Cells(7).Text), 2).ToString

            'Valor Spend
            e.Row.Cells(8).Text = Round(CDec(e.Row.Cells(8).Text), 4).ToString


        End If

    End Sub
End Class
