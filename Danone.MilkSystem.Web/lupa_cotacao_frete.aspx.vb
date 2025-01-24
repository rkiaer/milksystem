Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math



Partial Class lupa_cotacao_frete
    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim js As New System.Text.StringBuilder

        js.Append("<script>")
        js.Append(vbCrLf)
        js.Append("function FechaPagina()")
        js.Append(vbCrLf)
        js.Append("{")
        js.Append(vbCrLf)
        js.Append("window.returnValue=document.getElementById(""txtDataHidden"").value;")
        js.Append(vbCrLf)
        js.Append("window.close();")
        js.Append(vbCrLf)
        js.Append("}")
        js.Append(vbCrLf)
        js.Append("</script>")
        js.Append(vbCrLf)

        If (Not ClientScript.IsClientScriptBlockRegistered("fechar")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "fechar", js.ToString)
        End If
        customPage = MenuTools.getInitialContext(HttpContext.Current, "")
        If Not Page.IsPostBack Then
            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If
            If Not (Request("id_item") Is Nothing) Then
                ViewState.Item("id_item") = Request("id_item")
            End If
            If Not (Request("id_fornecedor") Is Nothing) Then
                ViewState.Item("id_fornecedor") = Request("id_fornecedor")
            End If
            'fran chamado 556 i
            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
            End If
            'fran chamado 556 f

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = ""

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim dstable As New DataTable
            Dim ilinha As Integer
            Dim frete As New TabelaFrete
            frete.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            frete.id_item = Convert.ToInt32(ViewState.Item("id_item"))
            frete.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            'fran chamado 556 i
            Dim prop As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))
            frete.id_estado_propriedade = prop.id_estado
            frete.id_cidade_propriedade = prop.id_cidade
            'fran chamado 556 f

            Dim dsfrete As DataSet = frete.getCentralTabelaFreteMax

            If dsfrete.Tables(0).Rows.Count > 0 Then

                dstable.Columns.Add("descricao")
                dstable.Columns.Add("nr_valor")
                dstable.Rows.InsertAt(dstable.NewRow(), 0)
                With dstable.Rows.Item(0)
                    .Item(0) = "BiTrem"
                    .Item(1) = CStr(Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_bitrem")), 2))
                End With

                dstable.Rows.InsertAt(dstable.NewRow(), 1)
                With dstable.Rows.Item(1)
                    .Item(0) = "Carreta Graneleiro"
                    .Item(1) = Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_carreta_graneleiro").ToString), 2).ToString
                End With
                dstable.Rows.InsertAt(dstable.NewRow(), 2)
                With dstable.Rows.Item(2)
                    .Item(0) = "Carreta Rosca"
                    .Item(1) = Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_carreta_rosca").ToString), 2).ToString
                End With
                dstable.Rows.InsertAt(dstable.NewRow(), 3)
                With dstable.Rows.Item(3)
                    .Item(0) = "Truck Graneleiro"
                    .Item(1) = Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_truck_graneleiro").ToString), 2).ToString
                End With
                dstable.Rows.InsertAt(dstable.NewRow(), 4)
                With dstable.Rows.Item(4)
                    .Item(0) = "Truck Rosca"
                    .Item(1) = Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_truck_rosca").ToString), 2).ToString
                End With
                dstable.Rows.InsertAt(dstable.NewRow(), 5)
                With dstable.Rows.Item(5)
                    .Item(0) = "Truck 4 Eixo"
                    .Item(1) = Round(Convert.ToDecimal(dsfrete.Tables(0).Rows(0).Item("nr_valor_truck_4eixo").ToString), 2).ToString
                End With

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
                gridResults.DataBind()

                lbl_estabelecimento.Text = dsfrete.Tables(0).Rows(0).Item("estabelecimento").ToString
                lbl_fornecedor.Text = dsfrete.Tables(0).Rows(0).Item("pessoa").ToString
                lbl_item.Text = String.Concat(dsfrete.Tables(0).Rows(0).Item("cd_item").ToString, " - ", dsfrete.Tables(0).Rows(0).Item("nm_item").ToString)
                lbl_dt_cotacao.Text = dsfrete.Tables(0).Rows(0).Item("dt_cotacao").ToString

            Else
                messageControl.Alert("Não há dados cadastrados na Tabela de Frete para o item x fornecedor informados!")
                Dim pessoa As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor")))
                Dim item As New Item(Convert.ToInt32(ViewState.Item("id_item")))
                Dim estabel As New Estabelecimento(Convert.ToInt32(ViewState.Item("id_estabelecimento")))
                lbl_estabelecimento.Text = String.Concat(estabel.cd_estabelecimento.ToString, " - ", estabel.nm_estabelecimento.ToString)
                lbl_fornecedor.Text = String.Concat(pessoa.cd_pessoa.ToString, " - ", pessoa.nm_pessoa.ToString)
                lbl_item.Text = String.Concat(item.cd_item.ToString, " - ", item.nm_item.ToString)

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub



    Private Sub salvarLinhaSelecionada(ByVal pvalor As String)

        Try

            customPage.setFilter("lupa_fretevl", "nr_frete", pvalor.ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lvalor As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lvalor)

                salvarLinhaSelecionada(lvalor)
        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim img_selecionar As ImageButton = CType(e.Row.FindControl("img_selecionar"), ImageButton)
            Dim valor As DataControlFieldCell = CType(e.Row.Cells(1), DataControlFieldCell)

            img_selecionar.CommandArgument = valor.Text
        End If

    End Sub
End Class
