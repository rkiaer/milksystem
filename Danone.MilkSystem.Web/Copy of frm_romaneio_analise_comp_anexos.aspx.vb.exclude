Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools


Partial Class frm_romaneio_analise_comp_anexos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_analise_comp_anexos.aspx")

        If Not Page.IsPostBack Then
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_nr_processo = Request("id")
                usuariolog.nm_nr_processo = Request("id")
                usuariolog.ds_nm_processo = "Anexar Documento"
                usuariolog.id_menu_item = 22
                usuariolog.insertUsuarioLog()
            End If
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("id") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id")
                ViewState.Item("tela") = Request("tela")
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                Dim companalise As New Romaneio
                companalise.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                Dim dsanalise As DataSet = companalise.getRomaneioAnalisesCompartimentosDistinct

                cbo_cd_analise.DataSource = Helper.getDataView(dsanalise.Tables(0), "nm_analise")
                cbo_cd_analise.DataTextField = "ds_cd_analise"
                cbo_cd_analise.DataValueField = "id_analise"
                cbo_cd_analise.DataBind()
                cbo_cd_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

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

            Dim anexo As New RomaneioAnaliseAnexo
            Dim romaneio As New Romaneio
            ViewState.Item("analise102coop") = 0

            anexo.id_romaneio = ViewState.Item("id_romaneio").ToString
            romaneio.id_romaneio = anexo.id_romaneio

            Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters
            If dsromaneio.Tables(0).Rows.Count > 0 Then
                With dsromaneio.Tables(0).Rows(0)
                    If Not IsDBNull(.Item("id_cooperativa")) AndAlso .Item("id_cooperativa") > 0 Then
                        lbl_romaneio.Text = "Cooperativa"

                        'fran 03/2024 i
                        'verificar se existe a analise 102 para amexar documento (obrigatorio apenas para cooperativa)
                        romaneio.cd_analise = 102
                        Dim ds_analise As DataSet = romaneio.getRomaneioAnalisesCompartimentosDistinct
                        If ds_analise.Tables(0).Rows.Count > 0 Then
                            ViewState.Item("analise102coop") = ds_analise.Tables(0).Rows(0).Item("id_analise")
                        End If
                        'limpa parametros
                        romaneio.cd_analise = 0

                        If ViewState.Item("analise102coop") > 0 Then
                            anexo.id_analise = ViewState.Item("analise102coop")
                            Dim dsanexo As DataSet = anexo.getRomaneioAnaliseAnexo
                            If dsanexo.Tables(0).Rows.Count = 0 Then 'se não tem aanexo da analise
                                'coloca como sugestao o anexo da analise 102
                                cbo_cd_analise.SelectedValue = ViewState.Item("analise102coop")
                            End If
                            'limpa parametros
                            anexo.id_analise = 0
                        End If
                        'fran 03/2024 f
                    End If
                    If Not IsDBNull(.Item("nr_caderneta")) AndAlso .Item("nr_caderneta") > 0 Then
                        lbl_romaneio.Text = "Coletas Produtores"
                    End If
                    If Not IsDBNull(.Item("st_romaneio_transbordo")) AndAlso .Item("st_romaneio_transbordo") = "S" Then
                        lbl_romaneio.Text = "Transbordo"
                    End If

                    lbl_id_romaneio.Text = .Item("id_romaneio").ToString
                    Me.lbl_nm_linha.Text = .Item("nm_linha").ToString
                    Me.lbl_nm_st_romaneio.Text = .Item("nm_st_romaneio").ToString
                    Me.lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                    Me.lbl_nm_item.Text = .Item("nm_item").ToString
                    ViewState.Item("id_st_romaneio") = .Item("id_st_romaneio")
                End With
            End If
            Dim romaneiocompartimento As New Romaneio_Compartimento
            romaneiocompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsromaneiocomp As DataSet = romaneiocompartimento.getRomaneio_CompartimentoByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then

                If Not IsDBNull(dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")) Then
                    lbl_analista.Text = dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")
                End If

                If Not IsDBNull(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")) Then
                    lbl_dt_inicio_analise.Text = Format(DateTime.Parse(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")), "dd/MM/yyyy HH:mm").ToString
                End If
            End If

            Dim dsdocumentos As DataSet = anexo.getRomaneioAnaliseAnexo()
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

            Select Case CInt(ViewState.Item("id_st_romaneio"))
                Case 2, 3, 7, 8
                    btn_anexar.Visible = True
                Case Else
                    btn_anexar.Visible = False
                    gridResults.Columns(4).Visible = False

            End Select

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
            Dim lbl_cd_analise As Label = CType(e.Row.FindControl("lbl_cd_analise"), Label)
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString

                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 9)
            End If
            If CLng(ViewState.Item("analise102coop")) > 0 Then 'se é cooperativa e tem analise 102 que obriga docto
                If lbl_cd_analise.Text = "102" AndAlso CInt(ViewState.Item("id_st_romaneio")) = 4 Then 'se o grid é analise 102
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                End If
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
                    usuariolog.id_nr_processo = Request("id")
                    usuariolog.nm_nr_processo = Request("id")
                    usuariolog.ds_nm_processo = "Anexar Documento"
                    usuariolog.id_menu_item = 22
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                    'lbl_msg.Text = "Documento anexado com sucesso!"
                    txt_nm_documento.Text = String.Empty
                    cbo_cd_analise.SelectedValue = String.Empty

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
            sqlcmd.CommandText = "ms_insertRomaneioAnaliseAnexo"
            sqlcmd.Connection = con

            Dim sqlparam As New SqlParameter("@id_romaneio", SqlDbType.Int)
            sqlparam.Value = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            sqlcmd.Parameters.Add(sqlparam)

            Dim sqlparam1 As New SqlParameter("@id_analise", SqlDbType.Int)
            If cbo_cd_analise.SelectedValue.Equals(String.Empty) Then
                sqlparam1.Value = 0
            Else
                sqlparam1.Value = Convert.ToInt32(cbo_cd_analise.SelectedValue)
            End If
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam2.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam3.Value = pext
            sqlcmd.Parameters.Add(sqlparam3)

            Dim sqlparam4 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam4.Value = filename
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            sqlparam5.Value = contentlength
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
            sqlparam6.Value = numArray
            sqlcmd.Parameters.Add(sqlparam6)

            Dim sqlparam7 As New SqlParameter("@id_modificador", SqlDbType.Int)
            sqlparam7.Value = Convert.ToInt32(Me.Session("id_login"))
            sqlcmd.Parameters.Add(sqlparam7)

            sqlcmd.ExecuteNonQuery()
            con.Close()

            inputStream.Close()
            inputStream.Flush()

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
                deleteRomaneioAnaliseAnexo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteRomaneioAnaliseAnexo(ByVal id_romaneio_analise_anexo As Integer)
        Try
            Dim romaneioanexo As New RomaneioAnaliseAnexo

            romaneioanexo.id_romaneio_analise_anexo = id_romaneio_analise_anexo
            romaneioanexo.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            romaneioanexo.deleteRomaneioAnaliseAnexo()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 22
            usuariolog.id_nr_processo = ViewState.Item("id_romaneio")
            usuariolog.nm_nr_processo = ViewState.Item("id_romaneio")
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
