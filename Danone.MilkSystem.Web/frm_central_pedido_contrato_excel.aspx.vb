Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_pedido_contrato_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try


            If (Not Request("id_central_contrato") Is Nothing) Then
                ViewState.Item("id_central_contrato") = Request("id_central_contrato")
            Else
                ViewState.Item("id_central_contrato") = 0
            End If

            Dim contratopropriedade As New CentralContratoPropriedade
            contratopropriedade.id_central_contrato = CInt(ViewState.Item("id_central_contrato").ToString)

            Dim dscontratoprop As DataSet = contratopropriedade.getCentralContratoPropriedadePedidos
            If dscontratoprop.Tables(0).Rows.Count = 0 Then
                Dim dscontratopropaberto As DataSet = contratopropriedade.getCentralContratoAbertoPropriedadePedidos
                If dscontratopropaberto.Tables(0).Rows.Count = 0 Then
                    gridpedidos.Visible = False
                Else
                    gridpedidos.Visible = True
                    gridpedidos.DataSource = Helper.getDataView(dscontratopropaberto.Tables(0), "")
                    gridpedidos.DataBind()
                End If

            Else
                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dscontratoprop.Tables(0), "")
                gridpedidos.DataBind()
            End If

            If gridpedidos.Rows.Count.ToString + 1 < 65536 Then
                Dim tw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_CentralPedidosContrato_" & ViewState.Item("id_central_contrato").ToString & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                Response.Charset = ""
                EnableViewState = False
                Controls.Add(frm)
                frm.Controls.Add(gridpedidos)

                frm.RenderControl(hw)
                Response.Write(tw.ToString())

                Response.End()
                Response.Flush()
                gridpedidos.AllowPaging = "True"
                gridpedidos.DataBind()
            End If


        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try
    End Sub

   
End Class
