Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_analise_esalq_protocolo_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                Else
                    ViewState.Item("dt_referencia") = String.Empty
                End If

                If (Not Request("id_tipo_coleta") Is Nothing) Then
                    ViewState.Item("id_tipo_coleta") = Request("id_tipo_coleta")
                Else
                    ViewState.Item("id_tipo_coleta") = String.Empty
                End If

                If (Not Request("dt_ini") Is Nothing) Then
                    ViewState.Item("dt_ini") = Request("dt_ini")
                Else
                    ViewState.Item("dt_ini") = String.Empty
                End If

                If (Not Request("dt_fim") Is Nothing) Then
                    ViewState.Item("dt_fim") = Request("dt_fim")
                Else
                    ViewState.Item("dt_fim") = String.Empty
                End If

                If (Not Request("st_exportacao") Is Nothing) Then
                    ViewState.Item("st_exportacao") = Request("st_exportacao")
                Else
                    ViewState.Item("st_exportacao") = String.Empty
                End If

                Dim protocolo As New AnaliseEsalqProtocolo

                protocolo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                protocolo.dt_referencia = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
                protocolo.id_tipo_coleta_analise_esalq = ViewState.Item("id_tipo_coleta").ToString
                protocolo.dt_coleta_ini = ViewState("dt_ini").ToString
                protocolo.dt_coleta_fim = ViewState("dt_fim").ToString
                protocolo.st_exportacao = ViewState.Item("st_exportacao").ToString

                Dim dsprotocolo As DataSet = protocolo.getAnaliseEsalqProtocoloByFilters()


                gridResults.DataSource = Helper.getDataView(dsprotocolo.Tables(0), "")
                gridResults.AllowPaging = False
                gridResults.DataBind()
                Dim row As GridViewRow
                For Each row In gridResults.Rows
                    row.Attributes.Add("class", "textmode")
                Next

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()

                        Response.Clear()
                        Response.Charset = ""
                        Response.Buffer = True

                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_Esalq_Protocolos_Pesquisa.xls")
                        EnableViewState = False

                        Controls.Add(frm)
                        frm.Controls.Add(gridResults)
                        frm.RenderControl(hw)

                        'style to format numbers to string 
                        Dim StyleAsText As String = "<style> .StyleAsText { mso-number-format:\@; } </style> "
                        Response.Write(StyleAsText & tw.ToString().Replace("<td>", "<td class='StyleAsText'>"))
                        Response.Flush()
                        Response.End()

                        'Response.Write(tw.ToString())
                        'Response.End()
                        'gridResults.AllowPaging = "True"
                        'gridResults.DataBind()
                    Else

                        messageControl.Alert("Não há linhas a serem exportadas!")
                    End If


                Else

                    messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

End Class
