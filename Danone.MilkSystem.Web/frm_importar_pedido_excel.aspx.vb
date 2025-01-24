Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_importar_pedido_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            ViewState.Item("id_importacao") = 0
            ViewState.Item("id_fornecedor") = 0
            ViewState.Item("id_produtor") = 0
            ViewState.Item("id_propriedade") = 0
            ViewState.Item("nr_nota") = 0

            If Not (Request("id_importacao") Is Nothing) Then
                ViewState.Item("id_importacao") = Request("id_importacao")
            Else
                ViewState.Item("id_importacao") = 0
            End If
            If Not (Request("id_fornecedor") Is Nothing) Then
                ViewState.Item("id_fornecedor") = Request("id_fornecedor")
            Else
                ViewState.Item("id_fornecedor") = 0
            End If
            If Not (Request("id_produtor") Is Nothing) Then
                ViewState.Item("id_produtor") = Request("id_produtor")
            Else
                ViewState.Item("id_produtor") = 0
            End If
            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
            Else
                ViewState.Item("id_propriedade") = 0
            End If
            If Not (Request("dt_pagto_ini") Is Nothing) Then
                ViewState.Item("dt_pagto_ini") = Request("dt_pagto_ini")
            End If
            If Not (Request("dt_pagto_fim") Is Nothing) Then
                ViewState.Item("dt_pagto_fim") = Request("dt_pagto_fim")
            End If
            If Not (Request("nr_nota") Is Nothing) Then
                ViewState.Item("nr_nota") = Request("nr_nota")
            End If

            Dim importacao As New ImportacaoPedido

            If ViewState.Item("id_propriedade").Equals(String.Empty) Then
                ViewState.Item("id_propriedade") = 0
            End If
            If ViewState.Item("id_produtor").Equals(String.Empty) Then
                ViewState.Item("id_produtor") = 0
            End If
            If ViewState.Item("id_fornecedor").Equals(String.Empty) Then
                ViewState.Item("id_fornecedor") = 0
            End If
            If ViewState.Item("id_importacao").Equals(String.Empty) Then
                ViewState.Item("id_importacao") = 0
            End If
            If ViewState.Item("nr_nota").Equals(String.Empty) Then
                ViewState.Item("nr_nota") = 0
            End If
            importacao.id_propriedade = ViewState.Item("id_propriedade")
            importacao.id_fornecedor = ViewState.Item("id_fornecedor")
            importacao.id_produtor = ViewState.Item("id_produtor")
            importacao.id_importacao = ViewState.Item("id_importacao")
            importacao.nr_nota = ViewState.Item("nr_nota")
            importacao.dt_pagto_ini = ViewState.Item("dt_pagto_ini")
            importacao.dt_pagto_fim = ViewState.Item("dt_pagto_fim")

            If Not (ViewState("dt_pagto_ini").ToString().Equals(String.Empty)) Then
                Dim dsimportacaolog As DataSet = importacao.getImportacaoPedidoIncluidosByFilters()
                Try

                    gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), "")
                    gridResults.AllowPaging = False
                    gridResults.DataBind()

                    If gridResults.Rows.Count.ToString + 1 < 65536 Then
                        If gridResults.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MILKSYSTEM_ImportacaoPedidoFomento" & ".xls")
                            Response.Charset = ""
                            EnableViewState = False
                            Controls.Add(frm)
                            frm.Controls.Add(gridResults)
                            frm.RenderControl(hw)
                            Response.Write(tw.ToString())
                            Response.End()
                            gridResults.AllowPaging = "True"
                            gridResults.DataBind()
                        Else

                            messageControl.Alert("Não há linhas a serem exportadas!")
                        End If


                    Else

                        messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                    End If


                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try
            Else
                messageControl.Alert("Problemas na passagem de parâmetros: o número de execução da importação não existe!")

            End If
        End If
    End Sub

End Class
