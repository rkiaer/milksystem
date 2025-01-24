Imports Danone.MilkSystem.Business
Imports System.Data
'Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_util_ExportaVolumeRomaneio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        'Fran 20/02/2009 i deve habilitar exportar apenas qdo tiver resultado na pesquisa
        'btn_exportar.Visible = True
        'Fran 20/02/2009 f

        Dim data_fim As String

        'fran 5/08/2010 i chamado 899
        'If Not (txt_nm_tecnico.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        'Else
        '    ViewState.Item("nm_tecnico") = String.Empty
        'End If
        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        'fran 5/08/2010 f chamado 899
        'fran 06/2015 i release relatorio
        'If cbo_tipo_emissao.SelectedValue.Equals("A") Then 'se tipo emissão analítico pega datas dos campos período
        '    ViewState.Item("tipo_emissao") = "A"
        '    If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
        '        ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
        '        ViewState.Item("dt_fim") = txt_dt_fim.Text
        '    Else
        '        ViewState.Item("dt_inicio") = String.Empty
        '        ViewState.Item("dt_fim") = String.Empty
        '    End If
        'Else
        '    ViewState.Item("tipo_emissao") = "S"

        'fran 06/2015 f release relatorio
        'se tipo emissão sintetico pega datas da referencia
        'If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
        '    'ViewState.Item("dt_fim") = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))
        '    data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
        '    ViewState.Item("dt_fim") = data_fim
        'Else
        '    ViewState.Item("dt_inicio") = String.Empty
        '    ViewState.Item("dt_fim") = String.Empty
        'End If
        'End If


        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
            'data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Fran 08/2015
            ViewState.Item("dt_fim") = txt_dt_fim.Text
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (txt_cd_pessoa.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        'fran 5/08/2010 i chamado 899
        If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If
        'fran 5/08/2010 f chamado 899

        If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        'If Not cbo_estabelecimento.SelectedValue = 0 Then
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Else
        'ViewState.Item("id_estabelecimento") = String.Empty
        ' End If


        'chamado 1576 - 31/07/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 31/07/2012 - Mirella f
        'fran 08/2015 i melhorias relatorios
        If Not (txt_id_romaneio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        'fran 08/2015 f melhorias relatorios
        If chk_preromaneio.Checked = True Then
            ViewState.Item("preromaneiotp") = "S"
        Else
            ViewState.Item("preromaneiotp") = "N"
        End If
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_util_ExportaVolumeRomaneio.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_ExportaVolumeRomaneio.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 82
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        'fran 04/08/2010 i chamado 899
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With
        'fran 04/08/2010 f chamado 899

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_dt_inicio.Text = String.Concat("01/", Format(Date.Today, "MM/yyyy").ToString())
            txt_dt_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()

            ViewState.Item("sortExpression") = "nm_tecnico asc"

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean




    '    If Not (customPage.getFilterValue("exportarR", txt_nm_tecnico.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_tecnico") = customPage.getFilterValue("exportarR", txt_nm_tecnico.ID)
    '        txt_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
    '    Else
    '        ViewState.Item("nm_tecnico") = String.Empty
    '    End If

    '    'If Not (customPage.getFilterValue("exportarR", dt_referencia.ID).Equals(String.Empty)) Then
    '    '    hasFilters = True
    '    '    ViewState.Item("dt_inicio") = customPage.getFilterValue("exportarR", dt_referencia.ID)
    '    '    dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
    '    'Else
    '    '    ViewState.Item("dt_referencia") = String.Empty
    '    'End If
    '    If Not (customPage.getFilterValue("exportarR", txt_produtor.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_pessoa") = customPage.getFilterValue("exportarR", txt_produtor.ID)
    '        txt_produtor.Text = ViewState.Item("cd_pessoa").ToString()
    '    Else
    '        ViewState.Item("cd_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("exportarR", txt_propriedade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_propriedade") = customPage.getFilterValue("exportarR", txt_propriedade.ID)
    '        txt_propriedade.Text = ViewState.Item("id_propriedade").ToString()
    '    Else
    '        ViewState.Item("id_propriedade") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("exportarR", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("exportarR", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("exportar")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim exportavolume As New ExportaVolume

            'fran 04/08/2010 i chamado 899
            'If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
            '    exportavolume.nm_tecnico = Convert.ToString(ViewState.Item("nm_tecnico"))
            'End If
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                exportavolume.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                exportavolume.id_pessoa = Convert.ToString(ViewState.Item("id_pessoa"))
            End If
            'fran 04/08/2010 f chamado 899

            'If Not (ViewState("cd_pessoa").ToString().Equals(String.Empty)) Then
            '    exportavolume.cd_pessoa = Convert.ToInt32(ViewState.Item("cd_pessoa"))
            'End If
            exportavolume.cd_pessoa = ViewState.Item("cd_pessoa")
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                exportavolume.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                exportavolume.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                exportavolume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                exportavolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If

            'fran 08/2015 i
            If Not (ViewState("id_romaneio").ToString().Equals(String.Empty)) Then
                exportavolume.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            End If
            'fran 08/2015 f

            'chamado 1576 - 31/07/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                exportavolume.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 31/07/2012 - Mirella f

            'Dim dsExportaVolume As DataSet = exportavolume.getExportaVolumebyRomaneio()
            Dim dsExportaVolume As DataSet

            If ViewState("preromaneiotp").ToString.Equals("S") Then
                dsExportaVolume = exportavolume.getExportaVolumeRomaneioTP()
            Else
                dsExportaVolume = exportavolume.getExportaVolumebyRomaneio()
            End If

            If (dsExportaVolume.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsExportaVolume.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                'fran 06/2015 i
                If ViewState("preromaneiotp").ToString.Equals("S") Then
                    lbl_total_litros.Text = FormatNumber(exportavolume.getExportaVolumeRomaneioTotalLitrosTP, 0)
                    lbl_total_litros_rejeitados.Text = FormatNumber(exportavolume.getExportaVolumeRomaneioTotalLitrosRejeitadosTP, 0)

                Else
                    lbl_total_litros.Text = FormatNumber(exportavolume.getExportaVolumeRomaneioTotalLitros, 0)
                    lbl_total_litros_rejeitados.Text = FormatNumber(exportavolume.getExportaVolumeRomaneioTotalLitrosRejeitados, 0)

                End If


                'Fran 20/02/2009 i 
                btn_exportar.Enabled = True
                'Fran 20/02/2009 f

            Else
                gridResults.Visible = False
                'Fran 20/02/2009 i 
                btn_exportar.Enabled = False
                'Fran 20/02/2009 f

                'fran 06/2015 i
                lbl_total_litros.Text = String.Empty
                lbl_total_litros_rejeitados.Text = String.Empty
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            'Case "id_tecnico"
            '    If (ViewState.Item("sortExpression")) = "id_tecnico asc" Then
            '        ViewState.Item("sortExpression") = "id_tecnico desc"
            '    Else
            '        ViewState.Item("sortExpression") = "id_tecnico asc"
            '    End If


            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If


            Case "st_categoria"
                If (ViewState.Item("sortExpression")) = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If

                'chamado 1576 - 31/07/2012 - Mirella i
            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If
                'chamado 1576 - 31/07/2012 - Mirella i


        End Select

        loadData()

    End Sub



    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub



    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        'Fran 01/04/2009 i
        Dim data_fim As String

        'fran 5/08/2010 i chamado 899
        'If Not (txt_nm_tecnico.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        'Else
        '    ViewState.Item("nm_tecnico") = String.Empty
        'End If
        If Not (txt_cd_tecnico.Text.Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If
        If Not (hf_id_pessoa.Value.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If
        'fran 5/08/2010 f chamado 899

        'If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()

            'data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' fran 08/2015
            ViewState.Item("dt_fim") = txt_dt_fim.Text
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (txt_cd_pessoa.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue


        'chamado 1576 - 31/07/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 31/07/2012 - Mirella f
        'fran 08/2015 i melhorias relatorios
        If Not (txt_id_romaneio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        'fran 08/2015 f melhorias relatorios
        If chk_preromaneio.Checked = True Then
            ViewState.Item("preromaneiotp") = "S"
        Else
            ViewState.Item("preromaneiotp") = "N"
        End If


        loadData()

        'fran 01/04/2009 f

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 82
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            'fran chamado 899 05/08/2010 i
            'Response.Redirect("frm_romaneio_excel.aspx?nm_tecnico=" + ViewState.Item("nm_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())
            'Response.Redirect("frm_romaneio_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString) 'chamado 1576 - 31/07/2012 - Mirella
            Response.Redirect("frm_romaneio_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_romaneio=" + ViewState.Item("id_romaneio").ToString() + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString + "&preromaneiotp=" + ViewState.Item("preromaneiotp").ToString) '08/2015 - Fran
            'fran chamado 899 05/08/2010 i

        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
        End If
    End Sub

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If

    End Sub


    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        'lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
        Try
            If Not txt_cd_tecnico.Text.Equals(String.Empty) Then

                Dim tecnico As New Tecnico
                tecnico.id_tecnico = Convert.ToInt32(Me.txt_cd_tecnico.Text.Trim)
                tecnico.id_situacao = 1
                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                'se encontrou produtor
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico")
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
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

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True

        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then

                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'grupo de produtores 
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        Try
            If Not txt_id_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text.Trim)
                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
    End Sub
    Private Sub carregarCamposPropriedade()

        Try
            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.txt_id_propriedade.Text = Me.hf_id_propriedade.Value.ToString
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

   
End Class

