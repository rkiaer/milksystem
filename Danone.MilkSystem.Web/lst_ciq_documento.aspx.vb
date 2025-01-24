Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools


Partial Class lst_ciq_documento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_ciq_documento.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 222
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            estabelecimento.id_situacao = 1
            estabelecimento.st_recepcao_leite = "S"
            Dim dsestabel As DataSet = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataSource = Helper.getDataView(dsestabel.Tables(0), "nm_estabelecimento")
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.Items.Insert(2, New ListItem("Boa Esperança", "77"))
            cbo_estabelecimento.Items.RemoveAt(0)
            cbo_estabelecimento.SelectedValue = 1

            ViewState.Item("id_estabelecimento") = "1"
            ViewState.Item("id_ciq_filtro") = "0"

            ViewState.Item("sortExpression") = "id_estabelecimento, id_ciq, nm_documento"
            ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()

            lbl_msg.Text = String.Empty
            lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Function consistirAnexo() As Boolean

        Try

            Dim lberro As Boolean = False
            Dim lmsg As String
            Dim lower As String


            If cbo_ds_tipo_incidente.SelectedValue = 0 Then
                lmsg = "Escolha o tipo de incidente para continuar!"
                lberro = True
            Else
                If txt_nm_documento.Text.Equals(String.Empty) Then
                    lmsg = "Nome do Arquivo a ser exibido deve ser informado para continuar!"
                    lberro = True
                End If
            End If

            If lberro = False Then
                If fup_documento.HasFile Then
                    lower = Me.fup_documento.PostedFile.FileName
                    lower = lower.Substring(lower.LastIndexOf("."))
                    lower = lower.ToLower()

                    If (Me.fup_documento.PostedFile.ContentLength > 2000000) Then
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
                    lmsg = "Selecione um documento para anexar ao CIQ."
                    lberro = True
                End If
            End If
            If lberro = False Then
                'verifica se ja tem o documento
                Dim ciq As New CIQDocumentos

                ciq.nm_documento = txt_nm_documento.Text
                ciq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                ciq.id_ciq = cbo_ds_tipo_incidente.SelectedValue
                If ciq.getCIQDocumentos.Tables(0).Rows.Count > 0 Then
                    lmsg = "Já existe este documento anexado para o incidente de qualidade " & cbo_ds_tipo_incidente.SelectedItem.Text & "."
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


            Dim ciqdocumentos As New CIQDocumentos

            ciqdocumentos.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            ciqdocumentos.id_ciq = Convert.ToInt32(ViewState.Item("id_ciq_filtro").ToString)
            ciqdocumentos.id_situacao = 1

            Dim dsdocumentos As DataSet = ciqdocumentos.getCIQDocumentos()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
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
                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString) + String.Format("&id_processo={0}", "1")
            End If

        End If
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_estabelecimento"
                If (ViewState.Item("sortExpression")) = "ds_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "ds_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "ds_estabelecimento asc"
                End If

            Case "ds_tipo_incidente"
                If (ViewState.Item("sortExpression")) = "ds_tipo_incidente asc" Then
                    ViewState.Item("sortExpression") = "ds_tipo_incidente desc"
                Else
                    ViewState.Item("sortExpression") = "ds_tipo_incidente asc"
                End If


            Case "nm_arquivo"
                If (ViewState.Item("sortExpression")) = "nm_arquivo asc" Then
                    ViewState.Item("sortExpression") = "nm_arquivo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_arquivo asc"
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

                    fup_documento.FileContent.Close()
                    fup_documento.FileContent.Dispose()
                    fup_documento.FileContent.Flush()
                    fup_documento.PostedFile.InputStream.Dispose()
                    fup_documento.Dispose()

                    Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                    lbl_msg.Text = "Documento anexado com sucesso!"
                    txt_nm_documento.Text = String.Empty
                    cbo_ds_tipo_incidente.SelectedValue = 0
                    chk_obrigatorio.Checked = False
                    cbo_tipo_incidente_filtro.SelectedValue = 0
                    ViewState.Item("id_ciq_filtro") = "0"

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'includsao
                    usuariolog.id_menu_item = 222
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

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
            inputStream.Read(numArray, 0, contentLength)

            Dim con As New SqlConnection
            con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
            con.Open()

            Dim sqlcmd As New SqlCommand
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.CommandText = "ms_insertCIQDocumentos"
            sqlcmd.Connection = con

            Dim sqlparam As New SqlParameter("@id_ciq", SqlDbType.Int)
            sqlparam.Value = Convert.ToInt32(cbo_ds_tipo_incidente.SelectedValue)
            sqlcmd.Parameters.Add(sqlparam)

            Dim sqlparam1 As New SqlParameter("@id_estabelecimento", SqlDbType.Int)
            sqlparam1.Value = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@ds_tipo_incidente", SqlDbType.VarChar)
            sqlparam2.Value = cbo_ds_tipo_incidente.SelectedItem.Text
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam3.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam3)

            Dim sqlparam4 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam4.Value = pext
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam5.Value = filename
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@st_obrigatorio", SqlDbType.VarChar)
            If chk_obrigatorio.Checked = True Then
                sqlparam6.Value = "S"
            Else
                sqlparam6.Value = "N"
            End If
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
            ' End If
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub



    Protected Sub btn_pesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_ciq_filtro") = cbo_tipo_incidente_filtro.SelectedValue
        lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text

        'limpa inclusao de documentos
        cbo_ds_tipo_incidente.SelectedValue = 0
        chk_obrigatorio.Checked = False
        txt_nm_documento.Text = String.Empty
        fup_documento.FileContent.Flush()
        fup_documento.Attributes.Clear()
        fup_documento.Dispose()

        lbl_msg.Text = String.Empty


        loadData()

    End Sub

    Protected Sub btn_limpar_selecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpar_selecao.Click

        fup_documento.FileContent.Flush()
        fup_documento.Dispose()
        fup_documento.Attributes.Clear()
        lbl_msg.Text = String.Empty

    End Sub

    Protected Sub btn_limpar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpar.Click

        cbo_estabelecimento.SelectedValue = 1
        cbo_tipo_incidente_filtro.SelectedValue = 0
        fup_documento.FileContent.Flush()
        fup_documento.Dispose()
        fup_documento.Attributes.Clear()

        txt_nm_documento.Text = String.Empty
        cbo_ds_tipo_incidente.SelectedValue = 0
        chk_obrigatorio.Checked = False
        lbl_msg.Text = String.Empty
        lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_tipo_incidente_filtro") = cbo_tipo_incidente_filtro.SelectedValue
        gridResults.Visible = False

        'Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=N")

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteCiqDocumentos(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteCiqDocumentos(ByVal id_ciq_documentos As Integer)
        Try
            Dim ciqdocumentos As New CIQDocumentos

            ciqdocumentos.id_ciq_documentos = id_ciq_documentos
            ciqdocumentos.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            ciqdocumentos.deleteCIQDocumentos()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 222
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
End Class
