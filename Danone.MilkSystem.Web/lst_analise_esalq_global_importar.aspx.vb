Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_analise_esalq_global_importar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try

            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + fup_nm_arquivo.FileName
            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_nm_arquivo.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)
            'fran 29/11/2009 i maracanau chamado 523
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            'fran 29/11/2009 f maracanau chamado 523

            If fup_nm_arquivo.FileName <> "" Then
                fup_nm_arquivo.SaveAs(ViewState.Item("nm_arquivo").ToString)
            End If

            lbl_totallidas.Visible = True
            lbl_totalimportadas.Visible = True
            lbl_totallinhaslidas.Visible = True
            lbl_totallinhasimportadas.Visible = True

            importData()

            deleteArquivos()   ' 12/05/2010 - chamado 835 - i

            loadData()

            ' 16/11/2008
            'messageControl.Alert("O processo de importação foi realizado. Verifique há erros e modifique se necessário.")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_importar.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            'fran 29/11/2009 i maracanau chamado 523
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran 29/11/2009 f maracanau chamado 523

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()
        Try


            Dim analiseesalqerro As New AnaliseEsalqErro
            analiseesalqerro.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = analiseesalqerro.getAnalisesEsalqErroByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

            ' 14/11/2008
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_analise_esalq_global.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim analiseesalq As New AnaliseEsalq
            analiseesalq.id_criacao = Convert.ToInt32(Session("id_login"))
            analiseesalq.nm_arquivo = ViewState.Item("nm_arquivo")
            'fran 27/11/2009 i maracanau chamado 523
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            'fran 27/11/2009 f maracanau chamado 523

            ViewState.Item("id_importacao") = analiseesalq.importAnaliseEsalqGlobal


            lbl_totallinhaslidas.Text = analiseesalq.nr_linhaslidas
            lbl_totallinhasimportadas.Text = analiseesalq.nr_linhasimportadas


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

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound


    End Sub
    ' chamado 835 - i (limpar arquivos de importação)
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
    ' chamado 835 - f (limpar arquivos de importação)

End Class
