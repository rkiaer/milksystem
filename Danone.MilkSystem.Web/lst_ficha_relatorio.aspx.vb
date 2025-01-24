Imports Danone.MilkSystem.Business
Imports System.Data
'Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_ficha_relatorio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
            Else
                ViewState.Item("id_tecnico") = String.Empty
            End If

            If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("dt_referencia_ini") = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")
                ViewState.Item("dt_referencia_fim") = DateTime.Parse("01/" & txt_dt_fim.Text).ToString("dd/MM/yyyy")
            Else
                ViewState.Item("dt_referencia_ini") = String.Empty
                ViewState.Item("dt_referencia_fim") = String.Empty
            End If

            If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = String.Empty
            End If

            If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue


            If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
            Else
                ViewState.Item("cd_codigo_sap") = String.Empty
            End If

            loadData(True)
        Else
            gridResults.Visible = False
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_ficha_relatorio.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_ficha_relatorio.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 192
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



            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData(ByVal pAtualizarFicha As Boolean) 'se parametro for true, insere na ficha senao apenas monta grid

        Try
            Dim ficha As New FichaFinanceira

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                ficha.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                ficha.id_pessoa = Convert.ToString(ViewState.Item("id_pessoa"))
            End If
            If Not (ViewState("dt_referencia_ini").ToString().Equals(String.Empty)) Then
                ficha.dt_referencia_ficha_start = Convert.ToString(ViewState.Item("dt_referencia_ini"))
                ficha.dt_referencia_ficha_end = Convert.ToString(ViewState.Item("dt_referencia_fim"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                ficha.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                ficha.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                ficha.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If

            ficha.id_modificador = Session("id_login")

            If pAtualizarFicha = True Then
                'inclui dados da referencia selecionada
                ficha.atualizarFichaRelatorio()
            End If

            Dim dsficha As DataSet

            dsficha = ficha.getFichaRelatorio()

            If (dsficha.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsficha.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                'fran 06/2015 i
                'If ViewState("preromaneiotp").ToString.Equals("S") Then
                '    lbl_total_litros.Text = FormatNumber(dsficha.getExportaVolumeRomaneioTotalLitrosTP, 0)
                '    lbl_total_notas.Text = FormatNumber(dsficha.getExportaVolumeRomaneioTotalLitrosRejeitadosTP, 0)

                'Else
                '    lbl_total_litros.Text = FormatNumber(ExportaVolume.getExportaVolumeRomaneioTotalLitros, 0)
                '    lbl_total_notas.Text = FormatNumber(ExportaVolume.getExportaVolumeRomaneioTotalLitrosRejeitados, 0)

                'End If


                btn_exportar.Enabled = True

            Else
                gridResults.Visible = False
                btn_exportar.Enabled = False

                lbl_total_litros.Text = String.Empty
                lbl_total_notas.Text = String.Empty
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If

            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If

            Case "cd_produtor"
                If (ViewState.Item("sortExpression")) = "cd_produtor asc" Then
                    ViewState.Item("sortExpression") = "cd_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "cd_produtor asc"
                End If
            Case "nm_produtor"
                If (ViewState.Item("sortExpression")) = "nm_produtor asc" Then
                    ViewState.Item("sortExpression") = "nm_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "nm_produtor asc"
                End If

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

        End Select

        loadData(False)

    End Sub



    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData(False)
    End Sub



    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then

            If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
            Else
                ViewState.Item("id_tecnico") = String.Empty
            End If

            If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("dt_referencia_ini") = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")
                ViewState.Item("dt_referencia_fim") = DateTime.Parse("01/" & txt_dt_fim.Text).ToString("dd/MM/yyyy")
            Else
                ViewState.Item("dt_referencia_ini") = String.Empty
                ViewState.Item("dt_referencia_fim") = String.Empty
            End If

            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text

            If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = String.Empty
            End If

            If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue


            If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
            Else
                ViewState.Item("cd_codigo_sap") = String.Empty
            End If

            loadData(True)

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 192
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                Response.Redirect("frm_ficha_relatorio_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString)

            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
            End If
        Else
            gridResults.Visible = False

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
                    'lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
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
                'Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_data_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_data.ServerValidate


        Try
            Dim lmsg As String

            args.IsValid = True

            If CDate(DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")) > CDate(DateTime.Parse("01/" & txt_dt_fim.Text).ToString("dd/MM/yyyy")) Then
                lmsg = "A Referência Início não poder ser maior que a Referência Fim."
                args.IsValid = False

            End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class

