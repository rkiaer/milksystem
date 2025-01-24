Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_relatorio_qualidade_web

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_qualidade_web.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 152
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("extratoqualidade", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("extratoqualidade", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoqualidade", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("extratoqualidade", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoqualidade", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("extratoqualidade", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("extratoqualidade", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("extratoqualidade", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If


        If Not (customPage.getFilterValue("extratoqualidade", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("extratoqualidade", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If



        If (hasFilters) Then
            customPage.clearFilters("extratoqualidade")
        End If


    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("extratoqualidade", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("extratoqualidade", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("extratoqualidade", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("extratoqualidade", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("extratoqualidade", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

            customPage.setFilter("lstVagaCarta", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub
    ' 02/12/2009 - Maracanau - i
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    ' 02/12/2009 - Maracanau - f
    'Private Sub gerarRelatorio()  ' Para gerar em formato HTML
    '    Try

    '        Dim extratoprodutorweb As New ExtratoProdutorWeb

    '        extratoprodutorweb.dt_referencia = ViewState.Item("dt_referencia").ToString
    '        extratoprodutorweb.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '        extratoprodutorweb.cd_pessoa = txt_cd_pessoa.Text

    '        Dim dsVolume As DataSet = extratoprodutorweb.getExtratoQualidadebyFilters()

    '        If (dsVolume.Tables(0).Rows.Count > 0) Then

    '            ' Monta o corpo 
    '            Dim lcorpo As String
    '            Dim arqTemp As StreamReader
    '            Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Não funcionou na locaweb com o caminhoServidor

    '            arqTemp = New StreamReader(lcaminhoservidor & "\extrato_qualidade_web.HTML", Encoding.UTF7)
    '            lcorpo = ""
    '            Do While Not arqTemp.EndOfStream
    '                lcorpo = lcorpo & arqTemp.ReadLine
    '            Loop

    '            '===========================
    '            ' Replace das variáveis
    '            '===========================

    '            ' Data
    '            Dim ldia As String
    '            Dim lmes As String
    '            Dim lano As String

    '            ldia = DateTime.Parse(Now.ToString).ToString("dd")
    '            lmes = DateTime.Parse(Now.ToString).ToString("MM")
    '            lano = DateTime.Parse(Now.ToString).ToString("yyyy")


    '            lcorpo = Replace(lcorpo, "$dia", ldia)
    '            lcorpo = Replace(lcorpo, "$mes", lmes)
    '            lcorpo = Replace(lcorpo, "$ano", lano)


    '            '===========================
    '            ' Monta $gridmovimento
    '            '===========================
    '            Dim row As DataRow
    '            Dim ltable As String = String.Empty

    '            ltable = "<table  width='95%' border='1' cellspacing='0' cellpadding='2'>"
    '            ltable = ltable & "<tr>"
    '            ltable = ltable & "<td bgcolor='#C0C0C0'><font size='1' face='Verdana'><strong>Dt Coleta</strong></font></td>"
    '            ltable = ltable & "<td bgcolor='#C0C0C0'><font size='1' face='Verdana'><strong>Litros</strong></font></td>"
    '            ltable = ltable & "</tr>"

    '            Dim i As Integer = 1
    '            For Each row In dsVolume.Tables(0).Rows

    '                ltable = ltable & "<tr>"
    '                ltable = ltable & "<td><font size='1' face='Verdana'>" & row.Item("dt_movimento").ToString & "</font></td>"
    '                If IsNumeric(row.Item("nr_volume")) Then
    '                    ltable = ltable & "<td><font size='1' face='Verdana'>" & row.Item("nr_volume").ToString & "</font></td>"
    '                Else
    '                    ltable = ltable & "<td><font size='1' face='Verdana'>&nbsp;</font></td>"
    '                End If

    '                ltable = ltable & "</tr>"

    '                i = i + 1
    '            Next
    '            ltable = ltable & "</table>"

    '            lcorpo = Replace(lcorpo, "$gridmovimento", ltable.ToString)

    '            HttpContext.Current.Response.Clear()
    '            HttpContext.Current.Response.Charset = ""
    '            HttpContext.Current.Response.Write(lcorpo)
    '            HttpContext.Current.Response.End()


    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Try
            If Page.IsValid Then

                ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text

                customPage.clearFilters("extratoqualidade")

                saveFilters()

                loadData()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_relatorio_qualidade_web.aspx?st_incluirlog=N")

    End Sub
    Private Sub loadData()

        Try
            Dim extratoqualidadeweb As New ExtratoQualidadeWeb

            extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
            extratoqualidadeweb.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            extratoqualidadeweb.cd_pessoa = ViewState.Item("cd_pessoa").ToString

            Dim dsPropriedadesMovimento As DataSet = extratoqualidadeweb.getExtratoQualidadePropriedadesWeb()  ' Traz as propriedades com movimento no mes

            If (dsPropriedadesMovimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPropriedadesMovimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Não há propriedades com movimento no mês para o produtor informado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_imprimir As HyperLink = CType(e.Row.FindControl("hl_imprimir"), HyperLink)
            Dim lbl_id_unid_producao As Label = CType(e.Row.FindControl("lbl_id_unid_producao"), Label)

            hl_imprimir.NavigateUrl = String.Format("frm_relatorio_qualidade_web.aspx?dt_referencia={0}", ViewState.Item("dt_referencia").ToString) & String.Format("&id_propriedade={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value & String.Format("&id_unid_producao={0}", lbl_id_unid_producao.Text))

        End If

    End Sub
End Class
