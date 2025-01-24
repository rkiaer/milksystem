Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools


Partial Class frm_central_pedido_anexos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedido_anexos.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO

                usuariolog.id_menu_item = 97
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("id") Is Nothing) Then
                ViewState.Item("tipo") = Request("tipo")
                ViewState.Item("tela") = Request("tela")
                ViewState.Item("id") = Request("id")
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
            Dim lower As String



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
                        If lower = ".pdf" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
                        Else
                            lmsg = "Somente são suportados arquivos no formato pdf, jpg, jpeg, png, xls, xlsx, doc, docx."
                            lberro = True
                        End If

                    End If

                Else
                    lmsg = "Selecione um documento para anexar."
                    lberro = True
                End If
            End If
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

            Dim anexo As New PedidoAnexos

            If Left(ViewState.Item("tipo").ToString, 3).ToString = "int" Then 'se veio da interrupcao
                tr_interrupcao.Visible = True
                tr_pedido.Visible = False
                rf_valor.Visible = True

                Dim intfornec As New InterrupcaoFornecimento

                Dim dspedido As DataSet

                If ViewState.Item("tipo").ToString = "intdp" Then
                    lbl_tipo_acerto.Text = "Desconto Produtor"
                    intfornec.id_central_pedido_desconto_produtor = ViewState.Item("id").ToString
                    anexo.id_central_pedido_desconto_produtor = ViewState.Item("id").ToString

                    dspedido = intfornec.getDescontoProdutorbyPropriedade
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        With dspedido.Tables(0).Rows(0)
                            lbl_pedido.Text = .Item("id_central_pedido").ToString
                            lbl_nr_nota.Text = .Item("nr_nota_fiscal").ToString
                            lbl_valor_nota.Text = FormatCurrency(.Item("nr_valor_nota_fiscal").ToString, 2)
                            lbl_dt_pagto.Text = DateTime.Parse(.Item("dt_pagto").ToString).ToString("dd/MM/yyyy")
                            lbl_valor_parcela.Text = .Item("nr_parcela").ToString
                            ViewState.Item("id_central_interrupcao_fornecimento") = .Item("id_central_interrupcao_fornecimento").ToString
                        End With
                    End If

                Else
                    lbl_tipo_acerto.Text = "Pagamento Fornecedor"
                    intfornec.id_central_pedido_pagto_fornecedor = ViewState.Item("id").ToString
                    anexo.id_central_pedido_pagto_fornecedor = ViewState.Item("id").ToString

                    dspedido = intfornec.getPagtoFornecedorbyPropriedade
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        With dspedido.Tables(0).Rows(0)
                            lbl_pedido.Text = .Item("id_central_pedido").ToString
                            lbl_nr_nota.Text = .Item("nr_nota_fiscal").ToString
                            lbl_valor_nota.Text = FormatCurrency(.Item("nr_valor_nota_fiscal").ToString, 2)
                            lbl_dt_pagto.Text = DateTime.Parse(.Item("dt_pagto").ToString).ToString("dd/MM/yyyy")
                            lbl_valor_parcela.Text = FormatCurrency(.Item("nr_valor_parcela").ToString, 2)
                            ViewState.Item("id_central_interrupcao_fornecimento") = .Item("id_central_interrupcao_fornecimento").ToString
                        End With
                    End If

                End If

                intfornec.id_central_interrupcao_fornecimento = Convert.ToInt32(ViewState.Item("id_central_interrupcao_fornecimento").ToString)

                Dim dsDetalhesTela As DataSet = intfornec.getInterrupcaoFornecimentoByFilters

                If dsDetalhesTela.Tables(0).Rows.Count > 0 Then
                    With dsDetalhesTela.Tables(0).Rows(0)
                        lbl_dt_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                        lbl_produtor.Text = .Item("nm_abreviado_produtor").ToString
                        lbl_propriedade_up.Text = .Item("ds_propriedade").ToString
                        lbl_id_execucao.Text = .Item("id_execucao").ToString
                        lbl_id_propriedade_matriz.Text = .Item("id_propriedade_matriz").ToString
                        If lbl_id_propriedade_matriz.Text = "0" Then
                            lbl_id_propriedade_matriz.Text = String.Empty
                        End If
                    End With
                End If

                anexo.st_origem = "I" 'interrupcao
            Else 'se veio da pedido
                tr_interrupcao.Visible = False
                tr_pedido.Visible = True
                rf_valor.Visible = True
                anexo.st_origem = "P" 'interrupcao

                Dim pedido As New Pedido

                If ViewState.Item("tipo").ToString = "pedido" OrElse ViewState.Item("tipo").ToString = "pednf" Then 'se veio de pedido
                    rf_valor.Visible = False
                End If

                If ViewState.Item("tipo").ToString = "pedido" OrElse ViewState.Item("tipo").ToString = "pednf" Then
                    If ViewState.Item("tipo").ToString = "pednf" Then
                        anexo.id_central_pedido_notas = ViewState.Item("id").ToString

                        Dim pednotas As New PedidoNotas
                        pednotas.id_central_pedido_notas = anexo.id_central_pedido_notas
                        pedido.id_central_pedido = pednotas.getPedidoNotasByFilters.Tables(0).Rows(0).Item("id_central_pedido").ToString
                    Else
                        anexo.id_central_pedido = ViewState.Item("id").ToString
                        pedido.id_central_pedido = anexo.id_central_pedido
                    End If

                    tr_pedido_tipo.Visible = False
                    Dim dspedido As DataSet = pedido.getPedidoByFilters
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        With dspedido.Tables(0).Rows(0)
                            lbl_central_pedido.Text = .Item("id_central_pedido").ToString
                            lbl_dt_pedido.Text = DateTime.Parse(.Item("dt_pedido").ToString).ToString("dd/MM/yyyy")
                            lbl_situacao.Text = .Item("nm_situacao_pedido").ToString
                            lbl_pedido_produtor.Text = .Item("nm_abreviado_produtor").ToString
                            lbl_pedido_propriedade.Text = .Item("id_propriedade").ToString
                            lbl_pedido_prop_matriz.Text = .Item("id_propriedade_matriz").ToString
                            lbl_fornecedor.Text = .Item("nm_abreviado_fornecedor").ToString
                            lbl_valor_pedido.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)
                        End With
                    End If
                Else
                    tr_pedido_tipo.Visible = True

                    If ViewState.Item("tipo").ToString = "peddp" Then
                        anexo.id_central_pedido_desconto_produtor = ViewState.Item("id").ToString

                        Dim desc As New PedidoDescontoProdutor
                        desc.id_central_pedido_desconto_produtor = anexo.id_central_pedido_desconto_produtor
                        Dim dsdesc As DataSet = desc.getPedidoDescontoProdutorByFilters
                        If dsdesc.Tables(0).Rows.Count > 0 Then
                            With dsdesc.Tables(0).Rows(0)
                                lbl_central_pedido.Text = .Item("id_central_pedido").ToString
                                lbl_pedido_nota.Text = .Item("nr_nota_fiscal").ToString
                                lbl_pedido_valor_parcela.Text = FormatCurrency(.Item("nr_valor_parcela").ToString, 2)
                                lbl_pedido_tipo.Text = "Desconto Produtor"
                            End With

                            pedido.id_central_pedido = lbl_central_pedido.Text

                        End If

                    Else
                        anexo.id_central_pedido_pagto_fornecedor = ViewState.Item("id").ToString

                        Dim pagto As New PedidoPagtoFornecedor
                        pagto.id_central_pedido_pagto_fornecedor = anexo.id_central_pedido_pagto_fornecedor
                        Dim dspagto As DataSet = pagto.getPedidoPagtoFornecedorByFilters
                        If dspagto.Tables(0).Rows.Count > 0 Then
                            With dspagto.Tables(0).Rows(0)
                                lbl_central_pedido.Text = .Item("id_central_pedido").ToString
                                lbl_pedido_nota.Text = .Item("nr_nota_fiscal").ToString
                                lbl_pedido_valor_parcela.Text = FormatCurrency(.Item("nr_valor_parcela").ToString, 2)
                                lbl_pedido_tipo.Text = "Pagto Fornecedor"
                            End With

                            pedido.id_central_pedido = lbl_central_pedido.Text

                        End If

                    End If

                    Dim dspedido As DataSet = pedido.getPedidoByFilters

                    If dspedido.Tables(0).Rows.Count > 0 Then
                        With dspedido.Tables(0).Rows(0)
                            lbl_dt_pedido.Text = DateTime.Parse(.Item("dt_pedido").ToString).ToString("dd/MM/yyyy")
                            lbl_situacao.Text = .Item("nm_situacao_pedido").ToString
                            lbl_pedido_produtor.Text = .Item("nm_abreviado_produtor").ToString
                            lbl_pedido_propriedade.Text = .Item("id_propriedade").ToString
                            lbl_pedido_prop_matriz.Text = .Item("id_propriedade_matriz").ToString
                            lbl_fornecedor.Text = .Item("nm_abreviado_fornecedor").ToString
                            lbl_valor_pedido.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)
                        End With
                    End If

                End If

            End If

            Dim dsdocumentos As DataSet = anexo.getPedidoAnexos()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                If Not ViewState.Item("tipo").ToString = "pedido" Then
                    btn_anexar.Enabled = False
                    btn_anexar.ToolTip = "Permitido apenas um documento anexado por parcela"
                End If
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

            Dim ltipo As Integer = 0
            Dim lid As String
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = ViewState.Item("id").ToString
                If ViewState.Item("tipo").ToString = "intdp" OrElse ViewState.Item("tipo").ToString = "peddp" Then
                    ltipo = 4
                End If
                If ViewState.Item("tipo").ToString = "intpf" OrElse ViewState.Item("tipo").ToString = "pedpf" Then
                    ltipo = 5
                End If
                If ViewState.Item("tipo").ToString = "pedido" Then
                    ltipo = 6
                    lid = Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString
                End If
                If ViewState.Item("tipo").ToString = "pednf" Then
                    ltipo = 7
                End If

                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", ltipo)
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

    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName

            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor
            If arquivos(index) = ViewState.Item("nm_arquivo").ToString Then
                Arquivo.Delete()
            End If
        Next index
    End Sub

    Protected Sub btn_anexar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anexar.Click

        Try
            If Page.IsValid Then

                If consistirAnexo() = False Then

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
                    usuariolog.id_tipo_log = 4 'includsao
                    If Left(ViewState.Item("tipo").ToString, 3) = "ped" Then
                        usuariolog.id_menu_item = 97
                    Else
                        usuariolog.id_menu_item = 113
                    End If
                    usuariolog.ds_nm_processo = "Anexar Documento"
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                    'lbl_msg.Text = "Documento anexado com sucesso!"
                    txt_nm_documento.Text = String.Empty
                    txt_dt_recebimento.Text = String.Empty
                    txt_valor.Text = String.Empty
                    ViewState.Item("id_ciq_filtro") = "0"

                    ful_documento.FileContent.Close()
                    ful_documento.FileContent.Dispose()
                    ful_documento.FileContent.Flush()
                    ful_documento.PostedFile.InputStream.Dispose()
                    ful_documento.Dispose()

                    If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
                        File.Delete(ViewState.Item("nm_arquivo").ToString)
                    End If

                    loadData()
                End If

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

        'If Page.IsValid = True Then
        '    Try

        '        If fup_documento.HasFile Then

        '            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + ful_documento.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)

        '            Dim fileName As String = Me.ful_documento.PostedFile.FileName
        '            Dim lower As String = fileName.Substring(fileName.LastIndexOf("."))
        '            lower = lower.ToLower()

        '            Dim contentType As Object = Me.ful_documento.PostedFile.ContentType
        '            Dim contentLength As Integer = Me.ful_documento.PostedFile.ContentLength

        '            Dim inputStream As Stream = Me.ful_documento.PostedFile.InputStream

        '            If ful_documento.FileName <> "" Then
        '                ful_documento.SaveAs(ViewState.Item("nm_arquivo").ToString)
        '            End If

        '            ful_documento.FileContent.Close()
        '            ful_documento.FileContent.Dispose()
        '            ful_documento.FileContent.Flush()
        '            Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

        '            cbo_estabelecimento.SelectedValue = 0
        '            cbo_tipo_incidente.SelectedValue = 0
        '            chk_obrigatorio.Checked = False
        '            txt_nm_documento.Text = String.Empty

        '            If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
        '                File.Delete(ViewState.Item("nm_arquivo").ToString)
        '            End If

        '            loadData()

        '            'If (Me.ful_documento.PostedFile.ContentLength > 2000000) Then
        '            '    Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=" & "tamanho")

        '            '    messageControl.Alert("O documento deve possuir tamanho máximo de 2000 KB.")

        '            'Else
        '            '    If lower = ".pdf" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
        '            '        Me.AnexarDocumento(lower)
        '            '        ful_documento.FileContent.Close()
        '            '        ful_documento.FileContent.Dispose()
        '            '        ful_documento.FileContent.Flush()
        '            '        ful_documento.UpdateAfterCallBack = True
        '            '        Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=" & "Anexado")

        '            '        'limpa inclusao de documentos
        '            '        cbo_estabelecimento.SelectedValue = 0
        '            '        cbo_tipo_incidente.SelectedValue = 0
        '            '        chk_obrigatorio.Checked = False
        '            '        txt_nm_documento.Text = String.Empty
        '            '        ful_documento.Dispose()

        '            '        loadData()
        '            '        messageControl.Alert("Registro inserido com sucesso.")


        '            '    Else
        '            '        Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=N")
        '            '        messageControl.Alert("Somente são suportados arquivos no formato pdf, jpg, jpeg, png, xls, xlsx, doc, docx.")
        '            '    End If
        '            'End If
        '        Else
        '            messageControl.Alert("Selecione um documento para anexar ao CIQ.")
        '        End If


        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    Finally
        '        ful_documento.Dispose()
        '        ful_documento.PostedFile.InputStream.Dispose()
        '        ful_documento.Controls.Clear()
        '        cbo_estabelecimento.SelectedValue = 0
        '        cbo_tipo_incidente.SelectedValue = 0
        '        chk_obrigatorio.Checked = False
        '        txt_nm_documento.Text = String.Empty

        '   End Try
        'End If
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
            sqlcmd.CommandText = "ms_insertCentralPedidoAnexos"
            sqlcmd.Connection = con

            Select Case ViewState.Item("tipo").ToString
                Case "pedido"
                    Dim sqlparam As New SqlParameter("@id_central_pedido", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(ViewState.Item("id").ToString)
                    sqlcmd.Parameters.Add(sqlparam)

                Case "pednf"
                    Dim sqlparam As New SqlParameter("@id_central_pedido_notas", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(ViewState.Item("id").ToString)
                    sqlcmd.Parameters.Add(sqlparam)
                Case "peddp", "intdp"
                    Dim sqlparam As New SqlParameter("@id_central_pedido_desconto_produtor", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(ViewState.Item("id").ToString)
                    sqlcmd.Parameters.Add(sqlparam)

                Case "pedpf", "intpf"
                    Dim sqlparam As New SqlParameter("@id_central_pedido_pagto_fornecedor", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(ViewState.Item("id").ToString)
                    sqlcmd.Parameters.Add(sqlparam)

            End Select


            Dim sqlparam1 As New SqlParameter("@dt_documento", SqlDbType.VarChar)
            sqlparam1.Value = txt_dt_recebimento.Text
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@nr_valor", SqlDbType.Decimal)
            If txt_valor.Text.Equals(String.Empty) Then
                sqlparam2.Value = CDec(0)
            Else
                sqlparam2.Value = CDec(txt_valor.Text)
            End If
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@st_origem", SqlDbType.VarChar)
            If Left(ViewState.Item("tipo").ToString, 3) = "ped" Then
                sqlparam3.Value = "P"
            Else
                sqlparam3.Value = "I"
            End If
            sqlcmd.Parameters.Add(sqlparam3)

            Dim sqlparam4 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam4.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam5.Value = pext
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam6.Value = filename
            sqlcmd.Parameters.Add(sqlparam6)

            Dim sqlparam7 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            sqlparam7.Value = contentlength
            sqlcmd.Parameters.Add(sqlparam7)

            Dim sqlparam8 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
            sqlparam8.Value = numArray
            sqlcmd.Parameters.Add(sqlparam8)

            Dim sqlparam9 As New SqlParameter("@id_modificador", SqlDbType.Int)
            sqlparam9.Value = Convert.ToInt32(Me.Session("id_login"))
            sqlcmd.Parameters.Add(sqlparam9)

            sqlcmd.ExecuteNonQuery()
            con.Close()

            inputStream.Close()
            inputStream.Flush()


            'If Not ViewState.Item("tipo").ToString = "pedido" OrElse Not ViewState.Item("tipo").ToString = "pednf" Then
            If Not ViewState.Item("tipo").ToString = "pedido" AndAlso Not ViewState.Item("tipo").ToString = "pednf" Then
                If ViewState.Item("tipo").ToString = "peddp" OrElse ViewState.Item("tipo").ToString = "intdp" Then
                    Dim desconto As New PedidoDescontoProdutor
                    desconto.id_central_pedido_desconto_produtor = Convert.ToInt32(ViewState.Item("id").ToString)
                    desconto.id_modificador = Convert.ToInt32(Me.Session("id_login"))
                    desconto.dt_acerto = txt_dt_recebimento.Text

                    desconto.updatePedidoDescontoProdutorAcerto()
                Else
                    Dim pagto As New PedidoPagtoFornecedor
                    pagto.id_central_pedido_pagto_fornecedor = Convert.ToInt32(ViewState.Item("id").ToString)
                    pagto.id_modificador = Convert.ToInt32(Me.Session("id_login"))
                    pagto.dt_acerto = txt_dt_recebimento.Text

                    pagto.updatePedidoPagtoFornecedorAcerto()
                End If
            End If

            ' End If
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub



    'Protected Sub btn_pesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisar.Click

    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_ciq_filtro") = cbo_tipo_incidente_filtro.SelectedValue
    '    lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text

    '    'limpa inclusao de documentos
    '    cbo_ds_tipo_incidente.SelectedValue = 0
    '    chk_obrigatorio.Checked = False
    '    txt_nm_documento.Text = String.Empty
    '    fup_documento.FileContent.Flush()
    '    fup_documento.Attributes.Clear()
    '    fup_documento.Dispose()

    '    lbl_msg.Text = String.Empty


    '    loadData()

    'End Sub

    'Protected Sub btn_limpar_selecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpar_selecao.Click

    '    fup_documento.FileContent.Flush()
    '    fup_documento.Dispose()
    '    fup_documento.Attributes.Clear()
    '    lbl_msg.Text = String.Empty

    'End Sub

    'Protected Sub btn_limpar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpar.Click

    '    cbo_estabelecimento.SelectedValue = 1
    '    cbo_tipo_incidente_filtro.SelectedValue = 0
    '    fup_documento.FileContent.Flush()
    '    fup_documento.Dispose()
    '    fup_documento.Attributes.Clear()

    '    txt_nm_documento.Text = String.Empty
    '    cbo_ds_tipo_incidente.SelectedValue = 0
    '    chk_obrigatorio.Checked = False
    '    lbl_msg.Text = String.Empty
    '    lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text
    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_tipo_incidente_filtro") = cbo_tipo_incidente_filtro.SelectedValue
    '    gridResults.Visible = False

    '    'Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=N")

    'End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deletePedidoAnexos(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deletePedidoAnexos(ByVal id_central_pedido_anexos As Integer)
        Try
            Dim pedidoanexo As New PedidoAnexos

            pedidoanexo.id_central_pedido_anexos = id_central_pedido_anexos
            pedidoanexo.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            pedidoanexo.deletePedidoAnexos()

            Select Case ViewState.Item("tipo").ToString
                Case "peddp", "intdp"

                    Dim pedido As New PedidoDescontoProdutor
                    pedido.id_central_pedido_desconto_produtor = Convert.ToInt32(ViewState.Item("id").ToString)
                    pedido.dt_acerto = ""
                    pedido.id_modificador = pedidoanexo.id_modificador
                    pedido.updatePedidoDescontoProdutorAcerto()

                Case "pedpf", "intpf"
                    Dim pedido As New PedidoPagtoFornecedor
                    pedido.id_central_pedido_pagto_fornecedor = Convert.ToInt32(ViewState.Item("id").ToString)
                    pedido.dt_acerto = ""
                    pedido.id_modificador = pedidoanexo.id_modificador
                    pedido.updatePedidoPagtoFornecedorAcerto()

            End Select

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            If Left(ViewState.Item("tipo").ToString, 3) = "ped" Then
                usuariolog.id_menu_item = 97
            Else
                usuariolog.id_menu_item = 113
            End If
            usuariolog.ds_nm_processo = "Anexar Documento"
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

    'Protected Sub cv_anexar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_anexar.ServerValidate
    '    If Page.IsValid Then
    '        Try

    '            Dim transitpoint As New TransitPoint
    '            Dim lmsg As String
    '            Dim lower As String

    '            args.IsValid = True

    '            If fup_documento.HasFile Then
    '                lower = Me.fup_documento.PostedFile.FileName
    '                lower = lower.Substring(lower.LastIndexOf("."))
    '                lower = lower.ToLower()

    '                If (Me.fup_documento.PostedFile.ContentLength > 2000000) Then
    '                    lmsg = "O documento deve possuir tamanho máximo de 2000 KB."
    '                    args.IsValid = False
    '                Else
    '                    If lower = ".pdf" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
    '                    Else
    '                        lmsg = "Somente são suportados arquivos no formato pdf, jpg, jpeg, png, xls, xlsx, doc, docx."
    '                        args.IsValid = False
    '                    End If

    '                End If

    '            Else
    '                lmsg = "Selecione um documento para anexar ao CIQ."
    '                args.IsValid = False

    '            End If

    '            If args.IsValid = True Then
    '                'verifica se ja tem o documento
    '                Dim ciq As New CIQDocumentos

    '                ciq.nm_documento = txt_nm_documento.Text
    '                ciq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '                ciq.id_ciq = cbo_ds_tipo_incidente.SelectedValue
    '                If ciq.getCIQDocumentos.Tables(0).Rows.Count > 0 Then
    '                    lmsg = "Já existe este documento anexado para o incidente de qualidade " & cbo_ds_tipo_incidente.SelectedItem.Text & "."
    '                    args.IsValid = False
    '                End If

    '            End If
    '            If args.IsValid = False Then
    '                messageControl.Alert(lmsg)
    '            End If

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect(ViewState.Item("tela").ToString)

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect(ViewState.Item("tela").ToString)
    End Sub
End Class
