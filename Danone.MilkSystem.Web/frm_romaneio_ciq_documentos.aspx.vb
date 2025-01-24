Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools


Partial Class frm_romaneio_ciq_documentos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_ciq_documentos.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 220
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("id_ciq") Is Nothing) Then
                ViewState.Item("id_ciq") = Request("id_ciq")
                ViewState.Item("id_romaneio_compartimento") = Request("id_romaneio_compartimento")
                ViewState.Item("id_romaneio_uproducao") = Request("id_romaneio_uproducao")

                Dim ciqdocto As New CIQDocumentos

                ciqdocto.id_situacao = 1
                ciqdocto.id_ciq = ViewState.Item("id_ciq")
                Dim dsdocto As DataSet = ciqdocto.getCIQDocumentos
                cbo_tipo_documento.DataSource = Helper.getDataView(dsdocto.Tables(0), "nm_documento")
                cbo_tipo_documento.DataTextField = "ds_nm_documento"
                cbo_tipo_documento.DataValueField = "id_ciq_documentos"
                cbo_tipo_documento.DataBind()
                cbo_tipo_documento.Items.Insert(0, New ListItem("[Selecione]", "0"))
                cbo_tipo_documento.Items.Insert(1, New ListItem("Documento Avulso", "A"))
                cbo_tipo_documento.SelectedValue = 0

                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()

                lbl_msg.Text = String.Empty
                loadData()
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Private Sub loadData()
        Try


            Dim romcomp As New Romaneio_Compartimento(ViewState.Item("id_romaneio_compartimento"))
            Dim romaneio As New Romaneio(romcomp.id_romaneio)

            lbl_id_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_dt_entrada.Text = DateTime.Parse(romaneio.dt_hora_entrada).ToString("dd/MM/yyyy HH:mm")
            lbl_situacao.Text = romaneio.nm_st_romaneio.ToString
            lbl_transportador.Text = romaneio.nm_transportador.ToString
            If romaneio.id_cooperativa > 0 Then
                lbl_label.Text = "Cooperativa:"
                lbl_nome.Text = romaneio.nm_cooperativa.ToString
                lbl_rota.Text = String.Empty
            Else
                lbl_rota.Text = String.Concat("Rota: ", romaneio.nm_linha.ToString)
            End If

            lbl_ds_placa.Text = romcomp.ds_placa.ToString
            lbl_compartimento.Text = romcomp.nm_compartimento.ToString

            Select Case romcomp.st_responsavel_ciq.ToString
                Case "P"
                    lbl_responsavel.Text = "Produtor"
                Case "C"
                    lbl_responsavel.Text = "Cooperativa"
                Case "T"
                    lbl_responsavel.Text = "Transportador"
                Case "R"
                    lbl_responsavel.Text = "Recepção"
            End Select

            Select Case ViewState.Item("id_ciq").ToString
                Case "1"
                    lbl_tipo_incidente.Text = "CIQ"
                Case "2"
                    lbl_tipo_incidente.Text = "CIQP"

                    Dim romup As New Romaneio_Comp_UProducao(ViewState.Item("id_romaneio_uproducao"))
                    lbl_label.Text = "Produtor:"
                    lbl_nome.Text = String.Concat(romup.nm_pessoa, "   -   Propriedade: ", romup.id_propriedade.ToString)

                Case "3"
                    lbl_tipo_incidente.Text = "CIQT"
                Case "4"
                    lbl_tipo_incidente.Text = "CIQR"
            End Select



            romaneio.id_ciq = Convert.ToInt32(ViewState.Item("id_ciq").ToString)
            romaneio.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento").ToString)
            If romaneio.id_ciq = 2 Then
                romaneio.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao").ToString)
            End If

            Dim dsdocumentos As DataSet = romaneio.getRomaneioCiqDocumentos()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), "st_obrigatorio desc, nm_documento")
                gridResults.DataBind()
            Else
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


            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString) + String.Format("&id_processo={0}", "2")
            End If

        End If
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
                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_documento.FileName

                Dim fileName As String = Me.fup_documento.PostedFile.FileName
                Dim lower As String = fileName.Substring(fileName.LastIndexOf("."))
                lower = lower.ToLower()
                Dim contentType As Object = Me.fup_documento.PostedFile.ContentType
                Dim contentLength As Integer = Me.fup_documento.PostedFile.ContentLength
                Dim inputStream As Stream = Me.fup_documento.PostedFile.InputStream

                If fup_documento.FileName <> "" Then
                    fup_documento.SaveAs(ViewState.Item("nm_arquivo").ToString)
                End If

                Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                fup_documento.FileContent.Close()
                fup_documento.FileContent.Dispose()
                fup_documento.FileContent.Flush()
                fup_documento.PostedFile.InputStream.Dispose()
                fup_documento.Dispose()


                lbl_msg.Text = "Documento anexado com suecesso!"
                txt_nm_documento.Text = String.Empty
                img_obrigatorio.ImageUrl = "~/img/ico_chk_false.gif"
                hl_documento.Text = String.Empty
                hl_documento.NavigateUrl = String.Empty
                cbo_tipo_documento.SelectedValue = 0

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'includsao
                usuariolog.id_menu_item = 220
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
                    File.Delete(ViewState.Item("nm_arquivo").ToString)
                End If

                loadData()

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
            sqlcmd.CommandText = "ms_insertRomaneioCIQDocumentos"
            sqlcmd.Connection = con

            Dim sqlparam As New SqlParameter("@id_romaneio_compartimento", SqlDbType.Int)
            sqlparam.Value = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            sqlcmd.Parameters.Add(sqlparam)

            Dim sqlparam1 As New SqlParameter("@id_romaneio_uproducao", SqlDbType.Int)
            sqlparam1.Value = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@id_ciq_documentos", SqlDbType.Int)
            If cbo_tipo_documento.SelectedValue = "A" Then
                sqlparam2.Value = 0
            Else
                sqlparam2.Value = Convert.ToInt32(cbo_tipo_documento.SelectedValue)
            End If
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@id_ciq", SqlDbType.Int)
            sqlparam3.Value = Convert.ToInt32(ViewState.Item("id_ciq"))
            sqlcmd.Parameters.Add(sqlparam3)


            Dim sqlparam4 As New SqlParameter("@ds_tipo_incidente", SqlDbType.VarChar)
            Select Case ViewState.Item("id_ciq").ToString
                Case "1"
                    sqlparam4.Value = "CIQ"
                Case "2"
                    sqlparam4.Value = "CIQP"
                Case "3"
                    sqlparam4.Value = "CIQT"
                Case "4"
                    sqlparam4.Value = "CIQR"
            End Select
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam5.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam6.Value = pext
            sqlcmd.Parameters.Add(sqlparam6)

            Dim sqlparam7 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam7.Value = filename
            sqlcmd.Parameters.Add(sqlparam7)

            Dim sqlparam8 As New SqlParameter("@st_obrigatorio", SqlDbType.VarChar)
            If img_obrigatorio.ImageUrl = "~/img/ico_chk_true.gif" Then
                sqlparam8.Value = "S"
            Else
                sqlparam8.Value = "N"
            End If
            sqlcmd.Parameters.Add(sqlparam8)

            Dim sqlparam9 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            sqlparam9.Value = contentlength
            sqlcmd.Parameters.Add(sqlparam9)

            Dim sqlparam10 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
            sqlparam10.Value = numArray
            sqlcmd.Parameters.Add(sqlparam10)

            Dim sqlparam11 As New SqlParameter("@id_modificador", SqlDbType.Int)
            sqlparam11.Value = Convert.ToInt32(Me.Session("id_login"))
            sqlcmd.Parameters.Add(sqlparam11)

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
                deleteCiqDocumentos(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteCiqDocumentos(ByVal id_ciq_documentos As Integer)
        Try
            Dim ciqdocumentos As New Romaneio

            ciqdocumentos.id_romaneio_ciq_documentos = id_ciq_documentos
            ciqdocumentos.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            ciqdocumentos.deleteRomaneioCIQDocumentos()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 220
            usuariolog.ds_nm_processo = String.Concat("id_romaneio_ciq_documentos ", id_ciq_documentos.ToString)
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

    Protected Sub cv_anexar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_anexar.ServerValidate
        If Page.IsValid Then
            Try

                Dim lmsg As String
                Dim lower As String
                Dim lcboarquivo As String = String.Empty

                args.IsValid = True

                If fup_documento.HasFile Then
                    lower = Me.fup_documento.PostedFile.FileName
                    lower = lower.Substring(lower.LastIndexOf("."))
                    lower = lower.ToLower()

                    If (Me.fup_documento.PostedFile.ContentLength > 2000000) Then
                        lmsg = "O documento deve possuir tamanho máximo de 2000 KB."
                        args.IsValid = False
                    Else
                        If lower = ".pdf" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
                        Else
                            lmsg = "Somente são suportados arquivos no formato pdf, jpg, jpeg, png, xls, xlsx, doc, docx."
                            args.IsValid = False
                        End If

                    End If
                    If args.IsValid = True AndAlso cbo_tipo_documento.SelectedValue <> "A" Then
                        If Left(cbo_tipo_documento.SelectedItem.Text, 1) = "*" Then
                            lcboarquivo = Mid(cbo_tipo_documento.SelectedItem.Text, 2)
                        Else
                            lcboarquivo = cbo_tipo_documento.SelectedItem.Text
                        End If

                        If fup_documento.FileName.Equals(String.Empty) Then
                            lmsg = "O nome do arquivo selecionado não pode ser vazio."
                            args.IsValid = False
                        Else
                            If UCase(lcboarquivo) <> UCase(fup_documento.FileName) Then
                                lmsg = "O nome e extensão do anexo devem ser os mesmos do documento selecionado no campo Tipo Documento."
                                args.IsValid = False
                            End If

                        End If
                    End If
                Else
                    lmsg = "Selecione um documento para anexar ao CIQ."
                    args.IsValid = False

                End If

                If args.IsValid = True Then
                    'verifica se ja tem o documento
                    Dim ciq As New Romaneio
                    If cbo_tipo_documento.SelectedValue = "A" Then
                        ciq.id_ciq = ViewState.Item("id_ciq").ToString
                        ciq.nm_documento = txt_nm_documento.Text
                    Else
                        ciq.id_ciq_documentos = cbo_tipo_documento.SelectedValue

                    End If
                    ciq.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento")
                    If ViewState.Item("id_ciq").ToString = "2" Then
                        ciq.id_romaneio_uproducao = ViewState.Item("id_romaneio_uproducao")
                    End If
                    If ciq.getRomaneioCiqDocumentos.Tables(0).Rows.Count > 0 Then
                        lmsg = "Já existe este documento anexado para o incidente de qualidade."
                        args.IsValid = False
                    End If

                End If
                If args.IsValid = False Then
                    messageControl.Alert(lmsg)
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cbo_tipo_documento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_documento.SelectedIndexChanged

        fup_documento.FileContent.Flush()
        fup_documento.Dispose()
        fup_documento.Attributes.Clear()
        lbl_msg.Text = String.Empty
        txt_nm_documento.Text = String.Empty
        txt_nm_documento.Enabled = False

        img_obrigatorio.ImageUrl = "~/img/ico_chk_false.gif"
        If Not cbo_tipo_documento.SelectedValue = "0" Then 'se selecione

            If cbo_tipo_documento.SelectedValue = "A" Then
                'se documento avulso
                txt_nm_documento.Enabled = True
                hl_documento.Text = String.Empty
                hl_documento.NavigateUrl = String.Empty
            Else
                If Left(cbo_tipo_documento.SelectedItem.Text, 1) = "*" Then
                    img_obrigatorio.ImageUrl = "~/img/ico_chk_true.gif"
                    txt_nm_documento.Text = Mid(Left(cbo_tipo_documento.SelectedItem.Text, InStr(1, cbo_tipo_documento.SelectedItem.Text, ".") - 1), 2)
                    txt_nm_documento.Enabled = False
                Else
                    img_obrigatorio.ImageUrl = "~/img/ico_chk_false.gif"
                    txt_nm_documento.Text = Left(cbo_tipo_documento.SelectedItem.Text, InStr(1, cbo_tipo_documento.SelectedItem.Text, ".") - 1)
                    txt_nm_documento.Enabled = False

                End If
                Me.hl_documento.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", cbo_tipo_documento.SelectedValue.ToString) + String.Format("&id_processo={0}", "1")
                Me.hl_documento.Enabled = True
                hl_documento.Text = cbo_tipo_documento.SelectedItem.Text
            End If

        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_ciq_documentos.aspx")

    End Sub
End Class
