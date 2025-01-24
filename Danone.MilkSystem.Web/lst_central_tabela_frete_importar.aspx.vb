Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_central_tabela_frete_importar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            If Page.IsValid Then
                ViewState.Item("lbl_totallinhaslidas.Text") = 0
                ViewState.Item("lbl_totallinhasimportadas.Text") = 0
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_nm_arquivo.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)
                If fup_nm_arquivo.FileName <> "" Then
                    fup_nm_arquivo.SaveAs(ViewState.Item("nm_arquivo").ToString)
                End If
                lbl_totallidas.Visible = True
                lbl_totalimportadas.Visible = True
                lbl_totallinhaslidas.Visible = True
                lbl_totallinhasimportadas.Visible = True

                importData()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 198
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                lbl_Aguarde.CssClass = "aguardenormal"

                deleteArquivos()
                lbl_totallinhaslidas.Text = ViewState("lbl_totallinhaslidas.Text").ToString()
                lbl_totallinhasimportadas.Text = ViewState("lbl_totallinhasimportadas.Text").ToString()
                'lbl_Aguarde.Text = String.Empty
                loadData()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_tabela_frete_importar.aspx")
        If (Not Me.Page.IsPostBack) Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 198
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Me.loadDetails()
        End If
        btn_importar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")

    End Sub

    Private Sub loadData()
        Try


            Dim importlog As New ImportacaoLog
            importlog.id_importacao = ViewState.Item("id_importacao")

            Dim dsimportacaolog As DataSet = importlog.getImportacaoLogByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim importacao As New Importacao
            importacao.id_criacao = Convert.ToInt32(Session("id_login"))
            importacao.nm_arquivo = ViewState.Item("nm_arquivo").ToString
            importacao.id_estabelecimento = cbo_estabelecimento.SelectedValue

            ViewState.Item("id_importacao") = importacao.importCentralTabelaFrete

            lbl_totallinhaslidas.Text = importacao.nr_linhaslidas
            lbl_totallinhasimportadas.Text = importacao.nr_linhasimportadas
            ViewState.Item("lbl_totallinhaslidas.Text") = importacao.nr_linhaslidas.ToString
            ViewState.Item("lbl_totallinhasimportadas.Text") = importacao.nr_linhasimportadas.ToString


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header And e.Row.RowType <> DataControlRowType.Footer And e.Row.RowType <> DataControlRowType.Pager) Then

            Select Case e.Row.Cells(2).Text.Trim()
                Case "1"
                    e.Row.Cells(2).Text = "O processo de importação da Tabela de Frete foi realizado. Verificar a ocorrência de avisos e erros."
                Case "2"
                    e.Row.Cells(2).Text = "Linha com Erro"
                Case Else
                    e.Row.Cells(2).Text = "Linha com Aviso"
            End Select
            If (Not e.Row.Cells(0).Text.Equals(String.Empty)) Then
                e.Row.Cells(0).Text = Path.GetFileName(e.Row.Cells(0).Text)
            End If
        End If

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
    Private Sub loadDetails()
        Try
            Dim estabelecimento As New Estabelecimento()
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_importar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_importar.ServerValidate
        If Page.IsValid Then
            lbl_Aguarde.Text = ("Importação em andamento... Aguarde...")
        End If
    End Sub
End Class
