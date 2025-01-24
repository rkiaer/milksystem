Imports Danone.MilkSystem.Business
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Data


Partial Class lst_SAP_importar_selecao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            If Page.IsValid Then
                Dim li As Integer
                Dim limportacao() As Int64
                lbl_Aguarde.Visible = True

                ViewState.Item("lbl_totallinhaslidas.Text") = 0
                ViewState.Item("lbl_totallinhasimportadas.Text") = 0

                For li = 0 To gridFiles.Rows.Count - 1
                    If CType(gridFiles.Rows(li).FindControl("chk_item"), CheckBox).Checked = True Then 'se está selecionado
                        ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + gridFiles.DataKeys(li).Value.ToString
                        ViewState.Item("nm_arquivo_destino") = ViewState.Item("caminho_arquivo") + "\temp\" + gridFiles.DataKeys(li).Value.ToString
                        importData()
                        ReDim Preserve limportacao(li)
                        limportacao(li) = ViewState.Item("id_importacao").ToString

                        'deleteArquivos()
                    End If
                Next

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 117
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                lbl_totallidas.Visible = True
                lbl_totalimportadas.Visible = True
                lbl_totallinhaslidas.Visible = True
                lbl_totallinhasimportadas.Visible = True
                lbl_totallinhaslidas.Text = ViewState.Item("lbl_totallinhaslidas.Text").ToString
                lbl_totallinhasimportadas.Text = ViewState.Item("lbl_totallinhasimportadas.Text").ToString
                loadDataFiles()
                ViewState.Item("lidimportacao") = limportacao
                loadData(limportacao)
                lbl_Aguarde.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_SAP_importar_selecao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 117
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()
        'busca o caminho que estão os arquivos de fornecedor informados no webconfig
        ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationSettings.AppSettings("ArquivoFornec").ToString()
        ViewState.Item("sortExpressionfile") = "dt_criacao desc"
        If Convert.ToInt32(Session("id_login")) = 182 Then 'teste para verificar acesso de diretorio
            btn_importar.Visible = False
            btnteste.Visible = True
        End If
        loadDataFiles()
    End Sub

    Private Sub loadData(ByVal lidimportacao() As Int64)
        Try


            Dim importacaolog As New ImportacaoLog
            Dim datasettemp As New DataSet
            Dim li As Integer

            importacaolog.id_importacao = lidimportacao(0)

            Dim dsimportacaolog As DataSet = importacaolog.getImportacaoLogByFilters
            datasettemp = dsimportacaolog

            For li = 1 To UBound(lidimportacao)
                importacaolog.id_importacao = lidimportacao(li)
                datasettemp = importacaolog.getImportacaoLogByFilters

                If datasettemp.Tables(0).Rows.Count > 0 Then
                    dsimportacaolog.Merge(datasettemp)
                End If
            Next

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadDataFiles()
        Try



            Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

            Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
            Dim lAllFiles As IO.FileInfo() = lDirectory.GetFiles()
            Dim lfoundFile As IO.FileInfo
            Dim dstable As New DataTable
            Dim ilinha As Integer = 0
            Dim arqTemp As StreamReader
            Dim llinhaarquivo As String
            Dim larraycampos() As String
            dstable.Columns.Add("nm_arquivo")
            dstable.Columns.Add("dt_criacao")
            dstable.Columns.Add("nm_fornecedor")
            dstable.Columns.Add("cd_codigo_sap")

            For Each lfoundFile In lAllFiles
                dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                With dstable.Rows.Item(ilinha)
                    arqTemp = New StreamReader(lfoundFile.FullName.ToString, Encoding.UTF7)
                    llinhaarquivo = arqTemp.ReadLine
                    larraycampos = Split(llinhaarquivo.ToString, ";")

                    .Item(0) = lfoundFile.Name.ToString
                    .Item(1) = DateTime.Parse(lfoundFile.CreationTime).ToString("dd/MM/yyyy HH:mm:ss")
                    .Item(2) = larraycampos(1).ToString 'Segunda posição do arquivo Nome
                    .Item(3) = larraycampos(0).ToString 'Primeira posição COd SAP
                End With
                ilinha = ilinha + 1
            Next
            If ilinha = 0 Then
                dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

            End If
            gridFiles.Visible = True
            gridFiles.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpressionfile"))
            gridFiles.DataBind()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim importacao As New Importacao
            importacao.id_criacao = Convert.ToInt32(Session("id_login"))
            importacao.nm_arquivo = ViewState.Item("nm_arquivo")
            importacao.nm_arquivo_destino = ViewState.Item("nm_arquivo_destino")

            ViewState.Item("id_importacao") = importacao.importSAP()  ' 28/02/2012 - Projeto Themis - Importação de Fornecedores

            ViewState.Item("lbl_totallinhaslidas.Text") = CInt(ViewState.Item("lbl_totallinhaslidas.Text")) + importacao.nr_linhaslidas
            ViewState.Item("lbl_totallinhasimportadas.Text") = CInt(ViewState.Item("lbl_totallinhasimportadas.Text")) + importacao.nr_linhasimportadas


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData(ViewState.Item("lidimportacao"))

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "nr_linha"
                If (ViewState.Item("sortExpression")) = "nr_linha asc" Then
                    ViewState.Item("sortExpression") = "nr_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nr_linha asc"
                End If


            Case "st_importacao"
                If (ViewState.Item("sortExpression")) = "st_importacao asc" Then
                    ViewState.Item("sortExpression") = "st_importacao desc"
                Else
                    ViewState.Item("sortExpression") = "st_importacao asc"
                End If

            Case "cd_erro"
                If (ViewState.Item("sortExpression")) = "cd_erro asc" Then
                    ViewState.Item("sortExpression") = "cd_erro desc"
                Else
                    ViewState.Item("sortExpression") = "cd_erro asc"
                End If

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If

        End Select

        loadData(ViewState.Item("lidimportacao"))

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("1")) Then
                e.Row.Cells(2).Text = "O processo de importação do SAP foi realizado. Verificar a ocorrência de avisos e erros."
            Else
                If (e.Row.Cells(2).Text.Trim().Equals("2")) Then
                    e.Row.Cells(2).Text = "Linha com Erro"
                Else
                    e.Row.Cells(2).Text = "Linha com Aviso"
                End If
            End If
            If Not e.Row.Cells(0).Text.Equals(String.Empty) Then
                e.Row.Cells(0).Text = Path.GetFileName(e.Row.Cells(0).Text)
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

    Protected Sub gridFiles_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridFiles.PageIndexChanging
        gridFiles.PageIndex = e.NewPageIndex
        Me.loadDataFiles()

    End Sub

    Protected Sub chk_todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim li As Integer
        Dim ch As CheckBox
        Dim chk_todos As CheckBox

        chk_todos = CType(sender, CheckBox)

        For li = 0 To gridFiles.Rows.Count - 1
            ch = CType(gridFiles.Rows(li).FindControl("chk_item"), CheckBox)
            ch.Checked = chk_todos.Checked
        Next
    End Sub

    Protected Sub cv_importacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_importacao.ServerValidate
        Try
            Dim li As Integer = 0
            Dim lifileselecionados As Integer
            Dim lmsg As String

            args.IsValid = True

            For li = 0 To gridFiles.Rows.Count - 1
                If CType(gridFiles.Rows(li).FindControl("chk_item"), CheckBox).Checked = True Then 'se está selecionado
                    lifileselecionados = lifileselecionados + 1
                End If
            Next

            ' Se não há arquivos selecionados 
            If lifileselecionados = 0 Then
                lmsg = "Não há arquivos selecionados para Importação."
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridFiles_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridFiles.Sorting
        Select Case e.SortExpression.ToLower()


            Case "nm_arquivo"
                If (ViewState.Item("sortExpressionfile")) = "nm_arquivo asc" Then
                    ViewState.Item("sortExpressionfile") = "nm_arquivo desc"
                Else
                    ViewState.Item("sortExpressionfile") = "nm_arquivo asc"
                End If

            Case "dt_criacao"
                If (ViewState.Item("sortExpressionfile")) = "dt_criacao asc" Then
                    ViewState.Item("sortExpressionfile") = "dt_criacao desc"
                Else
                    ViewState.Item("sortExpressionfile") = "dt_criacao asc"
                End If

            Case "nm_fornecedor"
                If (ViewState.Item("sortExpressionfile")) = "nm_fornecedor asc" Then
                    ViewState.Item("sortExpressionfile") = "nm_fornecedor desc"
                Else
                    ViewState.Item("sortExpressionfile") = "nm_fornecedor asc"
                End If

            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpressionfile")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpressionfile") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpressionfile") = "cd_codigo_sap asc"
                End If

        End Select

        loadDataFiles()
    End Sub

    Protected Sub btnteste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnteste.Click
        If Page.IsValid Then
            Dim li As Integer
            Dim limportacao() As Int64
            lbl_Aguarde.Visible = True

            ViewState.Item("lbl_totallinhaslidas.Text") = 0
            ViewState.Item("lbl_totallinhasimportadas.Text") = 0

            For li = 0 To gridFiles.Rows.Count - 1
                If CType(gridFiles.Rows(li).FindControl("chk_item"), CheckBox).Checked = True Then 'se está selecionado
                    ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + gridFiles.DataKeys(li).Value.ToString
                    ViewState.Item("nm_arquivo_destino") = ViewState.Item("caminho_arquivo") + "\temp\" + gridFiles.DataKeys(li).Value.ToString

                    Dim importacao As New Importacao
                    importacao.nm_arquivo = ViewState.Item("nm_arquivo")
                    importacao.nm_arquivo_destino = ViewState.Item("nm_arquivo_destino")

                    Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(importacao.nm_arquivo)
                    If Arquivo.Exists Then
                        'fran 27/09/2013 i melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp
                        'Arquivo.Delete()
                        If System.IO.File.Exists(importacao.nm_arquivo_destino) Then 'verifica se existe no TEMP
                            File.Delete(importacao.nm_arquivo_destino) 'delete se existit
                        End If
                        File.Move(importacao.nm_arquivo, importacao.nm_arquivo_destino) 'move da pasta origem para TEMP
                        'fran 27/09/2013 f melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp

                    End If

                    ReDim Preserve limportacao(li)
                    'limportacao(li) = ViewState.Item("id_importacao").ToString


                End If
            Next

            lbl_totallidas.Visible = True
            lbl_totalimportadas.Visible = True
            lbl_totallinhaslidas.Visible = True
            lbl_totallinhasimportadas.Visible = True
            lbl_totallinhaslidas.Text = ViewState.Item("lbl_totallinhaslidas.Text").ToString
            lbl_totallinhasimportadas.Text = ViewState.Item("lbl_totallinhasimportadas.Text").ToString
            loadDataFiles()
            ViewState.Item("lidimportacao") = limportacao
            loadData(limportacao)
            lbl_Aguarde.Visible = False
        End If


    End Sub
End Class
