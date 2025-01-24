Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.data.SqlClient
Imports RK.GlobalTools

Partial Class frm_download_maissolidos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Convert.ToInt64(Me.Request.QueryString("id")) > 0 Then
                Dim lnm_documento
                Dim llen As String

                Dim con As New SqlConnection
                con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                con.Open()

                Dim sqlcmd As New SqlCommand
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandText = "ms_getPoupancaParametroAnexo"
                sqlcmd.Connection = con

                Dim sqlparam As New SqlParameter("@id_poupanca_parametro", SqlDbType.Int)
                sqlparam.Value = Convert.ToInt32(Me.ViewState("id_poupanca_parametro"))

                sqlcmd.Parameters.Add(sqlparam)

                Dim sqldr As SqlDataReader = sqlcmd.ExecuteReader()

                If (sqldr.Read()) Then

                    lnm_documento = sqldr("nm_documento") & sqldr("nm_extensao")
                    llen = sqldr("nr_tamanho").ToString

                    Select Case sqldr("nm_extensao")
                        Case ".xls"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-excel"
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.End()
                        Case ".xlsx"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-excel"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".doc"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-word"
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.End()
                        Case ".docx"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-word"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".zip"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/zip"
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.End()
                        Case ".msg"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-outlook"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("img_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case Else
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "image/jpeg"
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.End()

                    End Select
                End If
                con.Close()

            Else
                Me.Response.Redirect("AcessoNegado.htm")

            End If


        Catch ex As System.Exception
            Me.Response.Write(ex.Message)
        End Try


    End Sub
End Class
