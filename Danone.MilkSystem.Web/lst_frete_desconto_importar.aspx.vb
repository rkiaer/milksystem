Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_frete_desconto_importar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try

            'ViewState.Item("caminho_arquivo") = "c:\home\milksystem\dados\"
            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_nm_arquivo.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)

            If fup_nm_arquivo.FileName <> "" Then
                fup_nm_arquivo.SaveAs(ViewState.Item("nm_arquivo").ToString)
            End If
            lbl_totallidas.Visible = True
            lbl_totalimportadas.Visible = True
            lbl_totallinhaslidas.Visible = True
            lbl_totallinhasimportadas.Visible = True

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 115
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            importData()

            deleteArquivos()   ' 12/05/2010 - chamado 835 - i

            ViewState.Item("IMPORTAR") = "S" 'fran 03/2017 já importou
            loadData()




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_importar.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 115
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

        End If
        If ViewState.Item("IMPORTAR") Is Nothing Then
            ViewState.Item("IMPORTAR") = "N"
        End If
    End Sub


    Private Sub loadData()
        Try


            Dim importacaofrete As New ImportacaoFrete
            importacaofrete.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = importacaofrete.getImportacaoFreteByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                'fran 03/2017 i
                If ViewState.Item("IMPORTAR") = "S" Then
                    btn_exportar.Enabled = True
                    btn_exportar.ImageUrl = "~/img/btn_exportar.gif"
                Else
                    btn_exportar.Enabled = False
                    btn_exportar.ImageUrl = "~/img/btn_exportar_desabilitado.gif"
                End If
            Else
                btn_exportar.Enabled = False
                btn_exportar.ImageUrl = "~/img/btn_exportar_desabilitado.gif"
                ViewState.Item("IMPORTAR") = "N"
                'fran 03/2017 f

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim importacaofrete As New ImportacaoFrete
            importacaofrete.id_criacao = Convert.ToInt32(Session("id_login"))
            importacaofrete.nm_arquivo = ViewState.Item("nm_arquivo")

            ViewState.Item("id_importacao") = importacaofrete.importFrete


            lbl_totallinhaslidas.Text = importacaofrete.nr_linhaslidas
            lbl_totallinhasimportadas.Text = importacaofrete.nr_linhasimportadas


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "nr_linha"
                If (ViewState.Item("sortExpression")) = "nr_linha asc" Then
                    ViewState.Item("sortExpression") = "nr_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nr_linha asc"
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

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        Try

            Dim importacaofrete As New ImportacaoFrete
            importacaofrete.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = importacaofrete.getImportacaoFreteByFilters()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 115
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Response.Redirect("frm_frete_desconto_importar_excel.aspx?id_importacao_frete=" + ViewState.Item("id_importacao").ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
