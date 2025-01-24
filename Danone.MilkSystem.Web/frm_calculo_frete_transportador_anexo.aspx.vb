Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools
Imports System.Xml

Partial Class frm_calculo_frete_transportador_anexo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_calculo_frete_transportador_anexo.aspx")

        If Not Page.IsPostBack Then
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_nr_processo = Request("id")
                usuariolog.nm_nr_processo = Request("id")
                usuariolog.ds_nm_processo = "Anexar Documento"
                usuariolog.id_menu_item = 258
                usuariolog.insertUsuarioLog()
            End If
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("id") Is Nothing) Then
                ViewState.Item("id_calculo_frete_transportador") = Request("id")
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()

                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Function consistirAnexo() As Boolean

        Try

            Dim lberro As Boolean = False
            Dim lmsg As String
            Dim lower As String = String.Empty

            ViewState.Item("id_tipo_anexo") = 0

            If txt_nm_documento.Text.Equals(String.Empty) Then
                lmsg = "Nome do Arquivo a ser exibido deve ser informado para continuar!"
                lberro = True
            End If

            If lberro = False Then
                If ful_documento.HasFile Then
                    lower = Me.ful_documento.PostedFile.FileName
                    lower = lower.Substring(lower.LastIndexOf("."))
                    lower = lower.ToLower()

                    If (Me.ful_documento.PostedFile.ContentLength > 2000000) Then
                        lmsg = "O documento deve possuir tamanho máximo de 2000 KB."
                        lberro = True
                    Else
                        If lower = ".pdf" OrElse lower = ".xml" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
                        Else
                            lmsg = "Somente são suportados arquivos no formato pdf, xml, jpg, jpeg, png, xls, xlsx, doc, docx."
                            lberro = True
                        End If

                    End If

                Else
                    lmsg = "Selecione um documento para anexar."
                    lberro = True
                End If
            End If
            If lberro = False Then
                Select Case cbo_tipo_documento.SelectedValue
                    Case "CTE"
                        If lower = ".pdf" Then
                            ViewState.Item("id_tipo_anexo") = 3
                        Else
                            If lower = ".xml" Then
                                ViewState.Item("id_tipo_anexo") = 4
                            Else
                                lmsg = "O arquivo do tipo CTE deve ser do tipo PDF ou XML."
                                lberro = True
                            End If
                        End If
                    Case "O"
                        ViewState.Item("id_tipo_anexo") = 5

                End Select
            End If
            'If lberro = False Then
            '    If cbo_tipo_documento.SelectedValue = "CTE" Then
            '        Dim anexo As New RomaneioSaidaNotaAnexo
            '        anexo.id_origem = ViewState.Item("id_origem").ToString
            '        anexo.id_tipo_anexo = ViewState.Item("id_tipo_anexo").ToString
            '        anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
            '        If anexo.getRomaneioSaidaNotaAnexo.Tables(0).Rows.Count > 0 Then
            '            lmsg = String.Concat("Já existe CTE no formato ", UCase(lower), " anexado ao Romaneio de Saída.")
            '            lberro = True
            '        End If
            '    End If

            'End If

            If lberro = True Then
                consistirAnexo = True
                messageControl.Alert(lmsg)
            Else
                consistirAnexo = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function


    Private Sub loadData()
        Try

            Dim anexo As New CalculoFreteTransportadorAnexo
            Dim calctransp As New CalculoFrete

            anexo.id_calculo_frete_transportador = ViewState.Item("id_calculo_frete_transportador").ToString
            calctransp.id_calculo_frete_transportador = anexo.id_calculo_frete_transportador

            Dim dstransp As DataSet = calctransp.getCalculoFreteTransportador
            If dstransp.Tables(0).Rows.Count > 0 Then
                With dstransp.Tables(0).Rows(0)

                    'DADOS transportaor
                    'Me.lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                    lbl_transportador.Text = .Item("nm_abreviado_transportador").ToString
                    lbl_cnpj.Text = .Item("cd_cnpj").ToString
                    lbl_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                    lbl_tipo_frete.Text = .Item("ds_tipo_frete").ToString
                    If .Item("st_tipo_calculo").ToString.Equals("D") Then
                        lbl_calculo_definitivo.Text = "SIM"
                    Else
                        lbl_calculo_definitivo.Text = "NÃO"
                    End If
                    lbl_qtde_viagens.Text = FormatNumber(.Item("nr_qtde_viagens"), 0)
                    lbl_km_frete.Text = FormatNumber(.Item("nr_km_frete"), 0)
                    lbl_total_bruto.Text = FormatNumber(.Item("nr_total_bruto"), 2)
                    If Not IsDBNull(.Item("nr_cte_multi")) Then
                        lbl_nr_cte_multi.Text = .Item("nr_cte_multi").ToString
                    End If
                    If Not IsDBNull(.Item("nr_viagem_multi")) Then
                        lbl_nr_viagem_multi.Text = .Item("nr_viagem_multi").ToString
                    End If
                    ViewState.Item("id_frete_periodo") = .Item("id_frete_periodo")
                    ViewState.Item("id_tipo_frete") = .Item("id_tipo_frete")
                    ViewState.Item("id_transportador") = .Item("id_transportador")

                End With
            End If

            Dim dsdocumentos As DataSet = anexo.getCalculoFreteTransportadorAnexo()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                btn_anexar.Enabled = True
                btn_anexar.ToolTip = String.Empty

                Dim dataRow As System.Data.DataRow = dsdocumentos.Tables(0).NewRow()
                dsdocumentos.Tables(0).Rows.InsertAt(dataRow, 0)
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), "")
                gridResults.DataBind()
                gridResults.Rows(0).Cells.Clear()
                gridResults.Rows(0).Cells.Add(New TableCell())
                gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridResults.Rows(0).Cells(0).Text = "Não existem documentos anexados!"
                gridResults.Rows(0).Cells(0).ColumnSpan = 7
            End If

            'Select Case CInt(ViewState.Item("id_st_romaneio"))
            '    Case 2, 3, 7, 8
            '        btn_anexar.Visible = True
            '    Case 1,
            '        btn_anexar.Visible = False
            '        gridResults.Columns(4).Visible = False

            'End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lid As String
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString

                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 12)
            End If


        End If
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nm_arquivo"
                If (ViewState.Item("sortExpression")) = "nm_documento asc" Then
                    ViewState.Item("sortExpression") = "nm_documento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_documento asc"
                End If

        End Select

        loadData()


    End Sub

    'Protected Sub deleteArquivos()
    '    Dim arquivos() As String
    '    Dim index As Integer

    '    'Obtem a lista de arquivos no diretório 
    '    arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

    '    For index = 0 To arquivos.Length - 1
    '        arquivos(index) = New FileInfo(arquivos(index)).FullName

    '        Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
    '        'Se o arquivo existir no servidor
    '        If arquivos(index) = ViewState.Item("nm_arquivo").ToString Then
    '            Arquivo.Delete()
    '        End If
    '    Next index
    'End Sub

    Protected Sub btn_anexar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anexar.Click

        Try
            If Page.IsValid AndAlso consistirAnexo() = False Then

                'If consistirAnexo() = False Then

                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + ful_documento.FileName

                Dim fileName As String = Me.ful_documento.PostedFile.FileName
                Dim lower As String = fileName.Substring(fileName.LastIndexOf("."))
                lower = lower.ToLower()
                Dim contentType As Object = Me.ful_documento.PostedFile.ContentType
                Dim contentLength As Integer = Me.ful_documento.PostedFile.ContentLength
                Dim inputStream As Stream = Me.ful_documento.PostedFile.InputStream

                If ful_documento.FileName <> "" Then
                    ful_documento.SaveAs(ViewState.Item("nm_arquivo").ToString)
                End If


                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_nr_processo = ViewState.Item("id_calculo_frete_transportador")
                usuariolog.nm_nr_processo = ViewState.Item("id_calculo_frete_transportador")
                usuariolog.ds_nm_processo = String.Concat("Anexar Docto", " - Tipo ", ViewState.Item("id_tipo_anexo").ToString)
                usuariolog.id_menu_item = 258
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                'lbl_msg.Text = "Documento anexado com sucesso!"
                txt_nm_documento.Text = String.Empty
                cbo_tipo_documento.SelectedValue = String.Empty
                txt_nr_nota.Text = String.Empty
                txt_ds_descricao.Text = String.Empty
                ViewState.Item("id_tipo_anexo") = 0

                ful_documento.FileContent.Close()
                ful_documento.FileContent.Dispose()
                ful_documento.FileContent.Flush()
                ful_documento.PostedFile.InputStream.Dispose()
                ful_documento.Dispose()

                If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
                    File.Delete(ViewState.Item("nm_arquivo").ToString)
                End If

                messageControl.Alert("Arquivo anexado com sucesso!")

                loadData()


            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub AnexarDocumento(ByVal pext As String, ByVal inputStream As Stream, ByVal contentlength As Integer, ByVal contentType As String, ByVal filename As String)
        Try

            Dim numArray(contentlength + 1 - 1) As Byte
            inputStream.Read(numArray, 0, contentlength)

            Dim con As New SqlConnection
            con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
            con.Open()

            Dim sqlcmd As New SqlCommand
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.CommandText = "ms_insertCalculoFreteTransportadorAnexo"
            sqlcmd.Connection = con

            Dim sqlparam As New SqlParameter("@id_calculo_frete_transportador", SqlDbType.Int)
            sqlparam.Value = Convert.ToInt32(ViewState.Item("id_calculo_frete_transportador").ToString)
            sqlcmd.Parameters.Add(sqlparam)

            Dim sqlparam1 As New SqlParameter("@id_frete_periodo", SqlDbType.Int)
            sqlparam1.Value = Convert.ToInt32(ViewState.Item("id_frete_periodo").ToString)
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@id_tipo_frete", SqlDbType.Int)
            sqlparam2.Value = ViewState.Item("id_tipo_frete")
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@id_transportador", SqlDbType.Int)
            sqlparam3.Value = ViewState.Item("id_transportador")
            sqlcmd.Parameters.Add(sqlparam3)

            Dim sqlparam4 As New SqlParameter("@id_tipo_anexo", SqlDbType.Int)
            sqlparam4.Value = ViewState.Item("id_tipo_anexo")
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nr_nota_fiscal", SqlDbType.VarChar)
            sqlparam5.Value = txt_nr_nota.Text
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam6.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam6)

            Dim sqlparam7 As New SqlParameter("@ds_descricao", SqlDbType.VarChar)
            sqlparam7.Value = txt_ds_descricao.Text
            sqlcmd.Parameters.Add(sqlparam7)

            Dim sqlparam8 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam8.Value = pext
            sqlcmd.Parameters.Add(sqlparam8)

            Dim sqlparam9 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam9.Value = filename
            sqlcmd.Parameters.Add(sqlparam9)

            Dim sqlparam10 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            sqlparam10.Value = contentlength
            sqlcmd.Parameters.Add(sqlparam10)

            Dim sqlparam11 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
            sqlparam11.Value = numArray
            sqlcmd.Parameters.Add(sqlparam11)

            Dim sqlparam12 As New SqlParameter("@id_modificador", SqlDbType.Int)
            sqlparam12.Value = Convert.ToInt32(Me.Session("id_login"))
            sqlcmd.Parameters.Add(sqlparam12)

            sqlcmd.ExecuteNonQuery()
            con.Close()

            inputStream.Close()
            inputStream.Flush()

            ' End If
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteCalculoFreteTransportadorAnexo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteCalculoFreteTransportadorAnexo(ByVal id_calculo_frete_transportador_anexo As Integer)
        Try
            Dim anexo As New CalculoFreteTransportadorAnexo

            anexo.id_calculo_frete_transportador_anexo = id_calculo_frete_transportador_anexo
            anexo.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            anexo.deleteCalculoFreteTransportadorAnexo()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 258
            usuariolog.id_nr_processo = ViewState.Item("id_calculo_frete_transportador")
            usuariolog.nm_nr_processo = String.Concat("Calculo Frete Transportador Anexo - ", id_calculo_frete_transportador_anexo.ToString)

            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()
        Catch ex As System.Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_calculo_frete_transportador.aspx")

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_calculo_frete_transportador.aspx")
    End Sub



End Class
