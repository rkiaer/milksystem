Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Data.SqlClient
Imports RK.GlobalTools

Partial Class frm_download_documentos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Cada id_processo significa rotina diferente para extrair documento
        ' 1 - lst_ciq_documentos
        ' 2 - lst_romaneio_ciq_anexos
        '3 - lst_central_notas_importacao
        '4 - frm_central_pedido_anexos desconto produtor
        '5 - frm_central_pedido_anexos pagto fornecedor
        '6 - frm_central_pedido_anexos pedido
        '7 - frm_central_pedido_anexos notas
        '8 - frm_central_pedido_anexos notas
        '9 - frm_romaneio_analise_anexo
        '10 - frm_romaneio_anexos
        '11 - frm_romaneio_saida_nota_anexo
        '12 - frm_calculo_frete_transportador_anexo
        Try
            Dim lid_processo As String = String.Empty
            Dim lid As String = String.Empty
            Dim ltxt As String = String.Empty

            If Not (Request("id_processo") Is Nothing) Then
                lid_processo = (Request("id_processo"))
            End If
            If Not (Request("id") Is Nothing) Then
                lid = (Request("id"))
            End If

            If Not (Request("txt") Is Nothing) Then
                ltxt = (Request("txt"))
            End If

            'se tem os parametros
            If Convert.ToInt64(lid) > 0 AndAlso CInt(lid_processo) > 0 Then

                Dim lnm_documento
                Dim llen As String

                Dim con As New SqlConnection
                con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                con.Open()

                'prepara o comando
                Dim sqlcmd As New SqlCommand
                sqlcmd.CommandType = CommandType.StoredProcedure

                Select Case CInt(lid_processo)

                    Case 1 'lst_ciq_documentos
                        sqlcmd.CommandText = "ms_getCIQDocumentosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_ciq_documentos", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)

                    Case 2 'lst_romaneio_ciq_documentos
                        sqlcmd.CommandText = "ms_getRomaneioCIQDocumentosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_romaneio_ciq_documentos", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)

                    Case 3 'lst_central_notas_importar
                        Dim centralnotaanexo As New CentralNotasAnexo
                        centralnotaanexo.id_central_notas_importacao = Convert.ToInt32(lid)
                        Dim dsanexo As DataSet = centralnotaanexo.getCentroNotasImportacaoAnexo
                        Dim lidcentralnotasanexo As Integer = 0
                        If dsanexo.Tables(0).Rows.Count > 0 Then
                            lidcentralnotasanexo = Helper.getDataView(dsanexo.Tables(0), "nm_extensao").Item(0).Item("id_central_notas_importacao_anexos").ToString
                        End If

                        sqlcmd.CommandText = "ms_getCentralNotasAnexoDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_central_notas_importacao_anexos", SqlDbType.Int)
                        sqlparam.Value = lidcentralnotasanexo

                        sqlcmd.Parameters.Add(sqlparam)

                    Case 4 'frm_central_pedido_anexos
                        sqlcmd.CommandText = "ms_getCentralPedidoAnexosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_central_pedido_desconto_produtor", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)

                    Case 5 'frm_central_pedido_anexos
                        sqlcmd.CommandText = "ms_getCentralPedidoAnexosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_central_pedido_pagto_fornecedor", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 6 'frm_central_pedido_anexos
                        sqlcmd.CommandText = "ms_getCentralPedidoAnexosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_central_pedido_anexos", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 7 'frm_central_pedido_anexos
                        sqlcmd.CommandText = "ms_getCentralPedidoAnexosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_central_pedido_notas", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 8
                        sqlcmd.CommandText = "ms_getRomaneioNotasAnexosDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_romaneio_notas", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)
                        sqlcmd.Parameters.Add(sqlparam)

                        If Not ltxt.Equals(String.Empty) Then
                            Dim sqlparam1 As New SqlParameter("@nm_extensao", SqlDbType.Char)
                            sqlparam1.Value = ltxt
                            sqlcmd.Parameters.Add(sqlparam1)
                        End If
                    Case 9 'frm_romaneio_analise_comp_anexos
                        sqlcmd.CommandText = "ms_getRomaneioAnaliseAnexoDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_romaneio_analise_anexo", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 10 'frm_romaneio_anexos
                        sqlcmd.CommandText = "ms_getRomaneioAnexoDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_romaneio_anexo", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 11 'frm_romaneio_saida_nota_anexo
                        sqlcmd.CommandText = "ms_getRomaneioSaidaNotaAnexoDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_romaneio_saida_nota_anexo", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)
                    Case 12 'frm_calculo_frete_transportador_anexo
                        sqlcmd.CommandText = "ms_getCalculoFreteTransportadorAnexoDownload"
                        sqlcmd.Connection = con

                        Dim sqlparam As New SqlParameter("@id_calculo_frete_transportador_anexo", SqlDbType.Int)
                        sqlparam.Value = Convert.ToInt32(lid)

                        sqlcmd.Parameters.Add(sqlparam)

                End Select

                Dim sqldr As SqlDataReader = sqlcmd.ExecuteReader()

                If (sqldr.Read()) Then
                    Select Case CInt(lid_processo)
                        Case 3, 8
                            lnm_documento = sqldr("nm_documento")
                        Case Else
                            lnm_documento = sqldr("nm_documento") & sqldr("nm_extensao")

                    End Select
                    'If CInt(lid_processo) = 3 Then
                    '    lnm_documento = sqldr("nm_documento")
                    'Else
                    '    lnm_documento = sqldr("nm_documento") & sqldr("nm_extensao")
                    'End If
                    llen = sqldr("nr_tamanho").ToString

                    Select Case sqldr("nm_extensao")
                        Case ".xls"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-excel"
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.End()
                        Case ".xlsx"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-excel"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".doc"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-word"
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.End()
                        Case ".docx"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-word"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".zip"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/zip"
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.End()
                        Case ".msg"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/vnd.ms-outlook"
                            Me.Response.AddHeader("Content-Length", llen)
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".pdf"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.ContentType = "application/pdf"
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.Flush()
                            Me.Response.End()
                        Case ".xml"
                            'Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            'Me.Response.ContentType = "application/xml"
                            'Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            'Me.Response.Flush()
                            'Me.Response.End()

                            'Response.ContentType = "text/xml"
                            'Response.AddHeader("Content-disposition", "inline; filename=" & lnm_documento)
                            'Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            'Response.End()

                            Response.Buffer = False
                            Response.Clear()
                            Response.ClearHeaders()
                            Response.ClearContent()
                            Response.AppendHeader("content-length", llen)
                            Response.ContentType = "application/octet-stream" '//string.Format("application/{0}", extensao)
                            Response.AppendHeader("content-disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Response.Flush()
                            Response.Close()
                            Response.End()


                        Case Else
                            Me.Response.Clear()
                            Me.Response.Buffer = True
                            Me.Response.Charset = ""
                            Me.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                            'Me.Response.ContentType = ContentType
                            'Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
                            Me.Response.ContentType = "image/jpeg"
                            Me.Response.AddHeader("Content-Disposition", "attachment; filename=" & lnm_documento)
                            Me.Response.BinaryWrite(DirectCast(sqldr("varbin_documento"), Byte()))
                            Me.Response.Flush()
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
