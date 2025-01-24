Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_central_pedidos_abertos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedidos_abertos.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                ViewState.Item("sortExpression") = "id_central_pedido"
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))
            lbl_propriedade.Text = String.Concat(propriedade.id_propriedade, " - ", propriedade.nm_propriedade)
            lbl_produtor.Text = String.Concat(propriedade.cd_pessoa, " - ", propriedade.nm_pessoa)
            lbl_nm_tecnico_danone.Text = String.Concat(propriedade.id_tecnico.ToString, " - ", propriedade.nm_tecnico)
            lbl_nm_tecnico_educampo.Text = String.Concat(propriedade.id_tecnico_educampo.ToString, " - ", propriedade.nm_tecnico_educampo)
            lbl_propriedade_matriz.Text = propriedade.id_propriedade_matriz

            'Cálcula saldo
            'Dim saldoDisponivel As New SaldoDisponivel()
            'saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
            'If Not lbl_propriedade_matriz.Text.Equals(String.Empty) Then
            '    saldoDisponivel.id_propriedade = lbl_propriedade_matriz.Text
            'Else
            '    saldoDisponivel.id_propriedade = lbl_propriedade.Text
            'End If

            'lbl_nr_valor_disponivel.Text = FormatNumber(saldoDisponivel.getSaldoDisponivelCentral, 2).ToString

            Dim saldoDisponivel As New SaldoDisponivel()
            saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
            If Not lbl_propriedade_matriz.Text.Equals(String.Empty) Then
                saldoDisponivel.id_propriedade = lbl_propriedade_matriz.Text
            Else
                saldoDisponivel.id_propriedade = lbl_propriedade.Text
            End If

            Dim dslimite As DataSet = saldoDisponivel.getSaldoDisponivelPropriedadeEMatriz
            If dslimite.Tables(0).Rows.Count > 0 Then
                With dslimite.Tables(0).Rows(0)
                    lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                End With

            Else
                'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                If dslimitecusto.Tables(0).Rows.Count > 0 Then
                    With dslimitecusto.Tables(0).Rows(0)
                        lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                    End With
                    lbl_nr_valor_disponivel.ForeColor = Drawing.Color.Blue
                    lbl_informacao.Visible = True
                Else
                    'se nao encontrou valor projetado e nem faturamento mes anterior
                    lbl_nr_valor_disponivel.Text = String.Empty

                End If
            End If

            'Pedidos em aberto
            Dim pedido As New Pedido
            pedido.id_propriedade = propriedade.id_propriedade
            pedido.id_situacao_pedido = 1

            'Dim dsPedidos As DataSet = pedido.getPedidoByFilters()
            Dim dsPedidos As DataSet = pedido.getPedidosAbertos

            If (dsPedidos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPedidos.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()


    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Response.Redirect("lst_caderneta.aspx")

    End Sub

  


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then



        End If

    End Sub

    Protected Sub lk_voltarFooter_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        'Response.Redirect("lst_caderneta.aspx")
    End Sub


End Class
