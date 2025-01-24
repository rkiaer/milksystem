Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_cooperativa_sl0013

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("data") = Me.txt_data_ini.Text.Trim
            ViewState.Item("data_fim") = Me.txt_data_fim.Text.Trim
            ViewState.Item("tipo") = opt_tipo_visao.SelectedValue
            ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
            ViewState.Item("cd_cooperativa") = Me.txt_cd_cooperativa.Text

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_cooperativa_sl0013.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_cooperativa_sl0013.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 240
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_data_ini.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.data_inicio = ViewState.Item("data").ToString
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            If ViewState.Item("data_fim").ToString = "" Then
                romaneio.data_fim = ViewState.Item("data").ToString
            Else
                romaneio.data_fim = ViewState.Item("data_fim").ToString
            End If
            If Not ViewState.Item("id_cooperativa").ToString.Equals(String.Empty) Then
                romaneio.id_cooperativa = ViewState.Item("id_cooperativa").ToString

            End If

            Dim dssl0013 As DataSet
            If ViewState.Item("tipo") = "A" Then   ' Se vai emitir o relatório analitico
                gridResultsSintetico.Visible = False
                dssl0013 = romaneio.getRomaneioSL0013()
                If (dssl0013.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dssl0013.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False

                dssl0013 = romaneio.getRomaneioSL0013Sintetico()
                If (dssl0013.Tables(0).Rows.Count > 0) Then
                    gridResultsSintetico.Visible = True
                    gridResultsSintetico.DataSource = Helper.getDataView(dssl0013.Tables(0), ViewState.Item("sortExpression"))
                    gridResultsSintetico.DataBind()
                Else
                    gridResultsSintetico.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    'Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

    '    Select Case e.SortExpression.ToLower()


    '        Case "ds_placa"
    '            If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
    '                ViewState.Item("sortExpression") = "ds_placa desc"
    '            Else
    '                ViewState.Item("sortExpression") = "ds_placa asc"
    '            End If


    '    End Select

    '    loadData()

    'End Sub

    Protected Sub cv_periodo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_periodo.ServerValidate
        Try
            args.IsValid = True
            If Not (Me.txt_data_fim.Text.Trim) = "" Then
                If CDate(Me.txt_data_fim.Text.Trim) < CDate(Me.txt_data_ini.Text) Then
                    args.IsValid = False
                    messageControl.Alert("A data final do período deve ser maior que a data inicial.")
                Else
                    Dim lqtd_meses As Integer
                    lqtd_meses = DateDiff(DateInterval.Month, CDate(Me.txt_data_ini.Text.Trim), CDate(Me.txt_data_fim.Text.Trim))
                    If lqtd_meses > 12 Then
                        args.IsValid = False
                        messageControl.Alert("O período de consulta não deve ultrapassar um ano.")
                    End If
                End If
            End If
            If args.IsValid = False Then
                gridResults.Visible = False
                gridResultsSintetico.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("data") = txt_data_ini.Text
            ViewState.Item("data_fim") = txt_data_fim.Text
            ViewState.Item("tipo") = opt_tipo_visao.SelectedValue
            ViewState.Item("id_cooperativa") = hf_id_cooperativa.Value
            If ViewState.Item("data_fim").ToString = "" Then
                ViewState.Item("data_fim") = ViewState.Item("data").ToString
            Else
                ViewState.Item("data_fim") = ViewState.Item("data_fim").ToString
            End If
            If ViewState.Item("id_cooperativa").ToString.Equals(String.Empty) Then
                ViewState.Item("id_cooperativa") = "0"

            End If
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 240
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            customPage.clearFilters("sl0013")

            Response.Redirect("frm_cooperativa_sl0013_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&data_ini=" + ViewState.Item("data").ToString() + "&data_fim=" + ViewState.Item("data_fim").ToString() + "&id_cooperativa=" + ViewState.Item("id_cooperativa").ToString() + "&tipo=" + ViewState.Item("tipo").ToString())

        End If
    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cooperativa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidcooperativa As Int32

            'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If
            If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_cooperativa.Text.Trim
            lidcooperativa = pessoa.validarCooperativa

            If lidcooperativa > 0 Then
                args.IsValid = True
                hf_id_cooperativa.Value = lidcooperativa
            Else
                hf_id_cooperativa.Value = String.Empty
                args.IsValid = False
                'messageControl.Alert("Cooperativa não cadastrada.")
                messageControl.Alert("Cooperativa não cadastrada para o código informado!")  ' 19/08/2010 Adriana Chamado 932
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
