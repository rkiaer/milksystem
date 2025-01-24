Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_romaneio_ajuste_valor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_reajuste_valor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                If Not (Request("nm_tela") Is Nothing) Then
                    ViewState.Item("voltar_para_tela") = Request("nm_tela")
                End If
                'Fran 19/02/2009 i
                grdPropriedade.Visible = True

                Dim dsPropriedade As New DataTable
                dsPropriedade.Rows.Clear()
                dsPropriedade.Columns.Add("propriedade")
                dsPropriedade.Columns.Add("unidadeproducao")
                dsPropriedade.Columns.Add("placacompartimento")
                dsPropriedade.Columns.Add("datacoleta")
                dsPropriedade.Columns.Add("temperatura")
                dsPropriedade.Columns.Add("alizarol")

                Dim dr As DataRow

                dr = dsPropriedade.NewRow()
                dr.Item(0) = String.Empty
                dr.Item(1) = String.Empty

                dsPropriedade.Rows.InsertAt(dr, 0)
                grdPropriedade.Visible = True
                grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, ViewState.Item("sortExpression"))
                grdPropriedade.DataBind()
                'Fran 19/02/2009 f

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_dt_entrada.Text = DateTime.Parse(romaneio.dt_hora_entrada.ToString).ToString

            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                'gridRomaneioCompartimento.Columns.Item(4).Visible = False
                'cv_gridcomp.Visible = False
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = romaneio.nr_peso_liquido_caderneta.ToString
                lbl_tipoleite.Text = romaneio.nm_item
                tr_grd_cooperativa.Visible = False
                loadgridresults()
            End If
            If romaneio.id_cooperativa > 0 Then
                ViewState.Item("cooperativa") = "S"
                'td_dados_cooperativa.Visible = True
                tr_caderneta.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False
                tr_panel_caderneta.Visible = False
                'Dados cooperativa
                lbl_cooperativa.Text = String.Concat(romaneio.cd_cooperativa.ToString, " - ", romaneio.nm_cooperativa.ToString)
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal.ToString
                lbl_dt_saida_nota.Text = DateTime.Parse(romaneio.dt_saida_nota.ToString).ToString
                lbl_nm_item.Text = romaneio.nm_item.ToString
                lbl_nr_valor_nota.Text = FormatCurrency(romaneio.nr_valor_nota_fiscal, 2)
                lbl_nr_peso_liquido_nota.Text = romaneio.nr_peso_liquido_nota.ToString
                loadgridcompartimento()
                'Fran 19/02/2009 i
                btn_adicionar_propriedade.Enabled = False
                btn_adicionar_propriedade.ToolTip = "Esta funcionalidade não está disponível para romaneios de Cooperativas!"
                'Fran 19/02/2009 f
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                tr_caderneta.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False
                tr_grd_cooperativa.Visible = False
                tr_transbordo.Visible = True
                lbl_nr_nota_transf.Text = romaneio.nr_nota_fiscal_transf
                lbl_serie_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                lbl_dt_emissao_transf.Text = romaneio.dt_emissao_nota_transf
                lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                lbl_id_item.Text = romaneio.nm_item
                lbl_soma_nr_peso_liquido_caderneta.Text = romaneio.nr_peso_liquido_caderneta
                grdresults.Columns(0).Visible = False
                loadgridresults()
                'Fran 06/04/2009 i - Desabilitado pois transbordo deve fazer insert propriedade
                'Fran 19/02/2009 i
                'btn_adicionar_propriedade.Enabled = False
                'btn_adicionar_propriedade.ToolTip = "Esta funcionalidade não está disponível para romaneios do tipo Transbordo!"
                'Fran 19/02/2009 f
                'Fran 06/04/2009 f 
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridcompartimento()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rc As New Romaneio_Compartimento

            rc.id_romaneio = id_romaneio

            Dim dsrcompartimento As DataSet = rc.getRomaneio_CompartimentoByFilters()

            If (dsrcompartimento.Tables(0).Rows.Count > 0) Then
                gridRomaneioCompartimento.Visible = True
                gridRomaneioCompartimento.DataSource = Helper.getDataView(dsrcompartimento.Tables(0), "ds_placa asc, nr_compartimento asc")
                gridRomaneioCompartimento.DataBind()
            Else
                gridRomaneioCompartimento.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadgridresults()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rp As New Romaneio_Comp_UProducao

            rp.id_romaneio = id_romaneio

            Dim dsprodutor As DataSet = rp.getRomaneioUProducaoReajuste()

            If (dsprodutor.Tables(0).Rows.Count > 0) Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(dsprodutor.Tables(0), "")
                grdresults.DataBind()
            Else
                grdresults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas com a passagem de parametros.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_reajuste_valor.aspx")



    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_reajuste_valor.aspx")


    End Sub


    Protected Sub gridRomaneioCompartimento_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridRomaneioCompartimento.RowCancelingEdit
        Try

            gridRomaneioCompartimento.EditIndex = -1
            loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim nr_total_litros As Label = CType(e.Row.FindControl("nr_total_litros"), Label)
                Dim nr_total_litros_sem_reajuste As Label = CType(e.Row.FindControl("nr_total_litros_sem_reajuste"), Label)
                Dim lbl_volume_ajustado As Label = CType(e.Row.FindControl("lbl_nr_total_litros_ajustado"), Label)
                Dim lbl_volume_real As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                Dim diferenca As DataControlFieldCell = CType(e.Row.Cells(4), DataControlFieldCell)
                If Not (nr_total_litros_sem_reajuste Is Nothing) Then
                    'Se não tem valor de reajuste o valor real esta em nr_total_litros
                    If nr_total_litros_sem_reajuste.Text.Equals(String.Empty) Then
                        lbl_volume_real.Text = FormatNumber(nr_total_litros.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = String.Empty
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_total_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            txt_volume_ajustado.Text = String.Empty
                        End If

                        diferenca.Text = String.Empty
                    Else
                        lbl_volume_real.Text = FormatNumber(nr_total_litros_sem_reajuste.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = FormatNumber(nr_total_litros.Text, 0)
                            diferenca.Text = CDec(lbl_volume_real.Text) - CDec(lbl_volume_ajustado.Text)
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_total_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                            txt_volume_ajustado.Text = FormatNumber(nr_total_litros.Text, 0)
                            diferenca.Text = CDec(lbl_volume_real.Text) - CDec(txt_volume_ajustado.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridRomaneioCompartimento.RowEditing
        Try

            gridRomaneioCompartimento.EditIndex = e.NewEditIndex
            loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridRomaneioCompartimento_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridRomaneioCompartimento.RowUpdating
        'Capturar valores


        Dim row As GridViewRow = gridRomaneioCompartimento.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim rc As New Romaneio_Compartimento

                rc.id_romaneio_compartimento = Convert.ToInt32(gridRomaneioCompartimento.DataKeys.Item(e.RowIndex).Value)
                rc.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                Dim nr_total_litros As Label = CType(row.FindControl("nr_total_litros"), Label)
                Dim nr_total_litros_sem_reajuste As Label = CType(row.FindControl("nr_total_litros_sem_reajuste"), Label)
                Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_total_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                If Not (nr_total_litros_sem_reajuste Is Nothing) Then
                    'Se não tem valor de reajuste o valor real esta em nr_total_litros
                    If nr_total_litros_sem_reajuste.Text.Equals(String.Empty) Then
                        rc.nr_total_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                        rc.nr_total_litros_sem_reajuste = nr_total_litros.Text
                    Else
                        rc.nr_total_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                        rc.nr_total_litros_sem_reajuste = nr_total_litros_sem_reajuste.Text
                    End If
                End If

                rc.id_modificador = Session("id_login")

                ' adri 24/01/2011 - verifica se ultrapassou o volume ( o cv não está funcionando )- i
                'rc.updateRomaneioCompartimentoReajuste()
                'gridRomaneioCompartimento.EditIndex = -1
                ''loadgridcompartimento()
                'loadData()

                Dim lerro As Boolean = False
                If txt_volume_ajustado.Text >= 0 Then
                    rc.nr_total_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                    If rc.getAjusteExcedeuVolume > 0 Then 'se o volume informado para ajuste excedeu o volume do compartimento
                        lerro = True
                        messageControl.Alert("O volume ajustado excede o volume máximo permitido ao compartimento. Alteração não pode ser efetuada!")
                    End If
                End If

                If lerro = False Then  ' Se está sem erro
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 23
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    rc.updateRomaneioCompartimentoReajuste()
                    gridRomaneioCompartimento.EditIndex = -1
                    'loadgridcompartimento()
                    loadData()
                End If
                ' adri 24/01/2011 - verifica se ultrapassou o volume - i


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub grdresults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdresults.RowCancelingEdit
        Try

            grdresults.EditIndex = -1
            loadgridresults()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdresults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)
                'deleteLimparReajuste(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(id_romaneio_compartimento.Text))


        End Select

    End Sub
    Private Sub deleteLimparReajuste(ByVal id_romaneio_uproducao As Int32, ByVal id_romaneio_compartimento As Int32)

        Try

            'gridRomaneioCompartimento.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim nr_litros As Label = CType(e.Row.FindControl("nr_litros"), Label)
                Dim nr_litros_sem_reajuste As Label = CType(e.Row.FindControl("nr_litros_sem_reajuste"), Label)
                Dim lbl_volume_ajustado As Label = CType(e.Row.FindControl("lbl_nr_litros_ajustado"), Label)
                Dim lbl_volume_real As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
                Dim lbl_diferenca As DataControlFieldCell = CType(e.Row.Cells(8), DataControlFieldCell)
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("btn_excluir"), ImageButton)
                If Not (nr_litros_sem_reajuste Is Nothing) Then
                    'Se não tem valor de reajuste o valor real esta em nr_total_litros
                    If nr_litros_sem_reajuste.Text.Equals(String.Empty) Then
                        If Not (btnexcluir Is Nothing) Then
                            btnexcluir.Enabled = False
                            btnexcluir.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        End If
                        lbl_volume_real.Text = FormatNumber(nr_litros.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = String.Empty
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            txt_volume_ajustado.Text = String.Empty
                        End If
                        lbl_diferenca.Text = String.Empty
                    Else
                        lbl_volume_real.Text = FormatNumber(nr_litros_sem_reajuste.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = FormatNumber(nr_litros.Text, 0)
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            txt_volume_ajustado.Text = FormatNumber(nr_litros.Text, 0)
                        End If
                        lbl_diferenca.Text = CStr(FormatNumber(CDec(nr_litros_sem_reajuste.Text) - CDec(nr_litros.Text), 0))
                    End If
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdresults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdresults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdresults.RowEditing
        Try

            grdresults.EditIndex = e.NewEditIndex
            loadgridresults()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdresults.RowUpdating
        'Capturar valores

        If Page.IsValid = True Then
            Dim row As GridViewRow = grdresults.Rows(e.RowIndex)
            Try

                If (Not (row) Is Nothing) Then

                    Dim rp As New Romaneio_Comp_UProducao
                    Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)

                    rp.id_romaneio_compartimento = Convert.ToInt32(id_romaneio_compartimento.Text)
                    rp.id_romaneio_uproducao = Convert.ToInt32(grdresults.DataKeys.Item(e.RowIndex).Value)
                    rp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                    Dim nr_total_litros As Label = CType(row.FindControl("nr_total_litros"), Label)
                    Dim nr_total_litros_sem_reajuste As Label = CType(row.FindControl("nr_total_litros_sem_reajuste"), Label)
                    Dim nr_litros As Label = CType(row.FindControl("nr_litros"), Label)
                    Dim nr_litros_sem_reajuste As Label = CType(row.FindControl("nr_litros_sem_reajuste"), Label)
                    Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                    If Not (nr_litros_sem_reajuste Is Nothing) Then
                        'Se não tem valor de reajuste o valor real esta em nr_total_litros
                        If nr_litros_sem_reajuste.Text.Equals(String.Empty) Then
                            rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_litros_sem_reajuste = Convert.ToDecimal(nr_litros.Text)
                        Else
                            rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_litros_sem_reajuste = nr_litros_sem_reajuste.Text
                        End If
                        If nr_total_litros_sem_reajuste.Text.Equals(String.Empty) Then
                            'O compartimento tb nao foi alterado
                            'Pega o valor total do compartimento - o valor do coletor e soma o novo valor
                            rp.nr_total_litros = Convert.ToDecimal(nr_total_litros.Text) - Convert.ToDecimal(nr_litros.Text)
                            rp.nr_total_litros = rp.nr_total_litros + Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_total_litros_sem_reajuste = Convert.ToDecimal(nr_total_litros.Text)
                        Else
                            rp.nr_total_litros = Convert.ToDecimal(nr_total_litros.Text) - Convert.ToDecimal(nr_litros.Text)
                            rp.nr_total_litros = rp.nr_total_litros + Convert.ToDecimal(txt_volume_ajustado.Text)
                            'rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_total_litros_sem_reajuste = nr_total_litros_sem_reajuste.Text
                        End If
                    End If

                    rp.id_modificador = Session("id_login")

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 23
                    usuariolog.id_nr_processo = rp.id_romaneio_uproducao.ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    rp.updateRomaneioUProducaoReajuste()
                    grdresults.EditIndex = -1
                    'loadgridresults()
                    loadData()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_volumeajustado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_nr_litros_ajustado As Anthem.TextBox = CType(row.FindControl("txt_nr_litros_ajustado"), Anthem.TextBox)
            Dim lmsg As String = String.Empty
            If txt_nr_litros_ajustado.Text >= 0 Then
                args.IsValid = True
                'fran 09/01/2011 i chamado 1101
                Dim rp As New Romaneio_Comp_UProducao
                Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)
                rp.id_romaneio_compartimento = Convert.ToInt32(id_romaneio_compartimento.Text)
                rp.id_romaneio_uproducao = Convert.ToInt32(grdresults.DataKeys.Item(row.RowIndex).Value())
                rp.nr_litros = Convert.ToDecimal(txt_nr_litros_ajustado.Text)
                If rp.getAjusteExcedeuVolume > 0 Then 'se o volume informado para ajuste excedeu o volume do compartimento
                    args.IsValid = False
                    lmsg = "O volume ajustado excede o volume máximo permitido ao compartimento. Alteração não pode ser efetuada!"
                End If
                'fran 09/01/2011 f chamado 1101
            Else
                args.IsValid = False
                lmsg = "O volume ajustado do produtor deve ser maior ou igual a zero."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Fran 19/02/2009 i
    Protected Sub btn_adicionar_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_propriedade.Click
        If Page.IsValid Then
            Try

                If consistirAdicionarPropriedadeRomaneio() = True Then

                    Dim row As GridViewRow = grdPropriedade.Rows(0)
                    Dim txt_propriedade As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_propriedade"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim txt_unidade_producao As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_unidade_producao"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim txt_dt_coleta As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_coleta"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                    Dim txt_nr_temperatura As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_temperatura"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim cbo_placa_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_placa_compartimento"), Anthem.DropDownList)
                    Dim cbo_alizarol As Anthem.DropDownList = CType(row.FindControl("cbo_alizarol"), Anthem.DropDownList)

                    Dim rcunidprod As New Romaneio_Comp_UProducao
                    rcunidprod.id_romaneio = ViewState.Item("id_romaneio")
                    rcunidprod.id_romaneio_compartimento = cbo_placa_compartimento.SelectedValue
                    rcunidprod.id_propriedade = txt_propriedade.Text
                    rcunidprod.nr_unid_producao = txt_unidade_producao.Text
                    rcunidprod.dt_coleta = txt_dt_coleta.Text
                    rcunidprod.nr_temperatura = txt_nr_temperatura.Text
                    rcunidprod.id_alizarol = cbo_alizarol.SelectedValue
                    rcunidprod.id_modificador = Session("id_login")

                    rcunidprod.insertRomaneioUProducaoPropriedade()
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusão
                    usuariolog.id_menu_item = 23
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    'Limpa grid de inclusão
                    Dim dsPropriedade As New DataTable
                    dsPropriedade.Rows.Clear()
                    dsPropriedade.Columns.Add("propriedade")
                    dsPropriedade.Columns.Add("unidadeproducao")
                    dsPropriedade.Columns.Add("placacompartimento")
                    dsPropriedade.Columns.Add("datacoleta")
                    dsPropriedade.Columns.Add("temperatura")
                    dsPropriedade.Columns.Add("alizarol")

                    Dim dr As DataRow

                    dr = dsPropriedade.NewRow()
                    dr.Item(0) = String.Empty
                    dr.Item(1) = String.Empty

                    dsPropriedade.Rows.InsertAt(dr, 0)
                    grdPropriedade.Visible = True
                    grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, ViewState.Item("sortExpression"))
                    grdPropriedade.DataBind()

                    messageControl.Alert("Nova Propriedade incluída ao Romaneio com sucesso!")

                    loadData()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
 

    Private Function consistirAdicionarPropriedadeRomaneio() As Boolean


        If Page.IsValid Then
            Try
                consistirAdicionarPropriedadeRomaneio = True

                Dim row As GridViewRow = grdPropriedade.Rows(0)


                Dim txt_propriedade As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_propriedade"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                Dim txt_unidade_producao As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_unidade_producao"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                Dim txt_dt_coleta As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_coleta"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim txt_nr_temperatura As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_temperatura"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim cbo_placa_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_placa_compartimento"), Anthem.DropDownList)
                Dim cbo_alizarol As Anthem.DropDownList = CType(row.FindControl("cbo_alizarol"), Anthem.DropDownList)

                Dim rcompartimento As New Romaneio_Compartimento(Convert.ToInt32(cbo_placa_compartimento.SelectedValue))
                'Dim erro As Exception
                'Se o romaneio compartimento já foi registrado
                If rcompartimento.id_st_analise > 0 Then
                    consistirAdicionarPropriedadeRomaneio = False
                    Throw New Exception("O compartimento selecionado não pode ser utilizado pois já está com suas análises registradas.")
                End If

                Dim uprod As New UnidadeProducao
                uprod.id_propriedade = Convert.ToInt32(txt_propriedade.Text.Trim)
                uprod.nr_unid_producao = Convert.ToInt32(txt_unidade_producao.Text.Trim)

                Dim dsuprod As DataSet = uprod.getUnidadeProducaoByFilters

                If dsuprod.Tables(0).Rows.Count = 0 Then
                    consistirAdicionarPropriedadeRomaneio = False
                    Throw New Exception("Propriedade ou Unidade de Produção não cadastrada.")
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Function

    Protected Sub grdPropriedade_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPropriedade.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim cbo_placa_compartimento As DropDownList = CType(e.Row.FindControl("cbo_placa_compartimento"), DropDownList)
                Dim rcompartimento As New Romaneio_Compartimento
                rcompartimento.id_romaneio = ViewState.Item("id_romaneio")


                cbo_placa_compartimento.DataSource = rcompartimento.getRomaneio_CompartimentoByFilters()
                cbo_placa_compartimento.DataTextField = "ds_placa_compartimento"
                cbo_placa_compartimento.DataValueField = "id_romaneio_compartimento"
                cbo_placa_compartimento.DataBind()
                cbo_placa_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


                Dim cbo_alizarol As DropDownList = CType(e.Row.FindControl("cbo_alizarol"), DropDownList)
                cbo_alizarol.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub grdPropriedade_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPropriedade.RowDataBound
        'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
        Dim cbo_placa_compartimento As DropDownList = CType(e.Row.FindControl("cbo_placa_compartimento"), DropDownList)
        If Not (cbo_placa_compartimento Is Nothing) Then
            cbo_placa_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        End If

    End Sub

    Protected Sub cv_volumetotalajustado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        ''fran 09/01/2011 i chamado 1101
        'Try
        '    Dim wc As WebControl = CType(source, WebControl)
        '    Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        '    Dim txt_nr_total_litros_ajustado As Anthem.TextBox = CType(row.FindControl("txt_nr_total_litros_ajustado"), Anthem.TextBox)
        '    Dim lmsg As String = String.Empty
        '    If txt_nr_total_litros_ajustado.Text >= 0 Then
        '        args.IsValid = True
        '        Dim rc As New Romaneio_Compartimento
        '        rc.id_romaneio_compartimento = Convert.ToInt32(grdresults.DataKeys.Item(row.RowIndex).Value())
        '        rc.nr_total_litros = Convert.ToDecimal(txt_nr_total_litros_ajustado.Text)
        '        If rc.getAjusteExcedeuVolume > 0 Then 'se o volume informado para ajuste excedeu o volume do compartimento
        '            args.IsValid = False
        '            lmsg = "O volume ajustado excede o volume máximo permitido ao compartimento. Alteração não pode ser efetuada!"
        '        End If
        '    Else
        '        args.IsValid = False
        '        lmsg = "O volume ajustado do compartimento deve ser maior ou igual a zero."
        '    End If

        '    If Not args.IsValid Then
        '        messageControl.Alert(lmsg)
        '    End If
        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try
        ''fran 09/01/2011 f chamado 1101

    End Sub
End Class
