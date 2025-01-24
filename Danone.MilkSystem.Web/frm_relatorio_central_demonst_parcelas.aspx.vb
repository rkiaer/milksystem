Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_central_demonst_parcelas
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_central_demonst_parcelas.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 103
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
                ViewState.Item("id_produtor") = Request("id_produtor")
                ViewState.Item("id_fornecedor") = Request("id_fornecedor")
                ViewState.Item("id_tecnico") = Request("id_tecnico")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                'fran 10/05/2010 i chamado 830
                ViewState.Item("cd_produtor") = Request("cd_produtor")
                ViewState.Item("cd_fornecedor") = Request("cd_fornecedor")
                'fran 10/05/2010 f chamado 830

                Dim data_fim As String
                If Not (ViewState.Item("dt_referencia").Equals(String.Empty)) Then
                    ViewState.Item("dt_inicio") = "01/" + ViewState.Item("dt_referencia")
                    data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
                    ViewState.Item("dt_fim") = data_fim
                Else
                    ViewState.Item("dt_inicio") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                End If

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

            If Not (ViewState.Item("id_tecnico").ToString().Equals(String.Empty)) Then
                pedido.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState.Item("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState.Item("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If
            If Not (ViewState.Item("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState.Item("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If

            'fran 10/05/2010 i chamado 830
            pedido.cd_produtor = ViewState.Item("cd_produtor").ToString
            pedido.cd_fornecedor = ViewState.Item("cd_fornecedor").ToString
            'fran 10/05/2010 f chamado 830

            Dim dspedido As DataSet = pedido.getParcelamento_Parceiros

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i
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
        ' Adri 04/11/2009 - i
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            ' Coluna 6 - Nome do Técnico
            If (e.Row.Cells(6).Text.Trim().Equals("Total")) Then  ' Se é a linha de total, limpa o código do parceiro
                e.Row.Cells(0).Text = ""
                e.Row.Cells(13).Text = ViewState.Item("totalsaldo").ToString 'fran 09/12/2010 i
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i
            Else
                'fran 09/12/2010 i
                Dim pedido As New Pedido
                Dim dt_pagto As Label = CType(e.Row.FindControl("dt_pagto"), Label)
                Dim nrsaldo As Decimal
                pedido.id_central_pedido = Convert.ToInt32(e.Row.Cells(7).Text.Trim)
                pedido.dt_fim = dt_pagto.Text.ToString
                nrsaldo = pedido.getCentralParcelamentoSaldo
                e.Row.Cells(13).Text = nrsaldo.ToString
                nrsaldo = CDbl(ViewState.Item("totalsaldo").ToString) + nrsaldo
                ViewState.Item("totalsaldo") = nrsaldo.ToString
                'fran 09/12/2010 f
            End If

            ' Adri 04/11/2009 - f

        End If

    End Sub
End Class
