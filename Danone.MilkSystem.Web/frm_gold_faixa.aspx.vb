Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_gold_faixa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo_faixa.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        Else
            If ViewState.Item("cd_gold_faixa") Is Nothing Then
                If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then

                    grdFaixas.Rows(0).Cells.Clear()
                    grdFaixas.Rows(0).Cells.Add(New TableCell())
                    grdFaixas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    grdFaixas.Rows(0).Cells(0).Text = "Não existe nenhuma Faixa cadastrada!"
                    grdFaixas.Rows(0).Cells(0).ColumnSpan = 5
                End If
            End If
        End If
    End Sub

    Private Sub loadDetails()

        Try
            Dim situacoes As New Situacao

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True

            If Not (Request("cd_gold_faixa") Is Nothing) Then
                ViewState.Item("tipo_gold_faixa") = Request("tipo_gold_faixa")
                ViewState.Item("cd_gold_faixa") = Request("cd_gold_faixa")
                loadData()
            Else

                Dim dsgrid As New DataTable
                dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

                grdFaixas.Visible = True
                grdFaixas.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
                grdFaixas.DataBind()
                grdFaixas.Rows(0).Cells.Clear()
                grdFaixas.Rows(0).Cells.Add(New TableCell())
                grdFaixas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdFaixas.Rows(0).Cells(0).Text = "Não existe nenhuma Faixa cadastrada!"
                grdFaixas.Rows(0).Cells(0).ColumnSpan = 5
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim cd_gold_faixa As Int32 = Convert.ToInt32(ViewState.Item("cd_gold_faixa").ToString)
            Dim id_tipo_faixa As Int32 = Convert.ToInt32(ViewState.Item("tipo_gold_faixa").ToString)
            Select Case id_tipo_faixa
                Case 1   ' Custo
                    loadCusto(cd_gold_faixa)
                Case 2   ' Volume
                    loadVolume(cd_gold_faixa)
                Case 3   ' Crescimento
                    loadCrescimento(cd_gold_faixa)
                Case 4   ' Eficiencia
                    loadEficiencia(cd_gold_faixa)
            End Select

            
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadVolume(ByVal cd_gold_faixa)

        Try

            Dim faixaVolume As New GoldFaixaVolume()

            cbo_tipo_faixa.SelectedValue = 2
            cbo_tipo_faixa.Enabled = False

            faixaVolume.cd_gold_faixa_volume = cd_gold_faixa

            Dim ds_faixa As DataSet = faixaVolume.getGoldFaixaVolumeByCodigo()

            If (ds_faixa.Tables(0).Rows.Count > 0) Then
                txt_nm_faixa.Text = ds_faixa.Tables(0).Rows(0).Item("nm_gold_faixa_volume").ToString

                cbo_estabelecimento.SelectedValue = ds_faixa.Tables(0).Rows(0).Item("id_estabelecimento").ToString
                cbo_estabelecimento.Enabled = False
                txt_dt_referencia_inicial.Text = (DateTime.Parse(ds_faixa.Tables(0).Rows(0).Item("dt_referencia_inicial").ToString).ToString("MM/yyyy"))
                txt_dt_referencia_inicial.Enabled = False
                txt_dt_referencia_inicial.Enabled = False
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""


                grdFaixas.Visible = False
                cv_grid.Visible = False
                cv_validar_faixas_grid.Visible = False
                btn_nova_faixa.Visible = False

                grdfaixaconsulta.Visible = True
                grdfaixaconsulta.DataSource = Helper.getDataView(ds_faixa.Tables(0), "nr_faixa_inicio asc")
                grdfaixaconsulta.DataBind()
            Else
                grdfaixaconsulta.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadEficiencia(ByVal cd_gold_faixa)

        Try

            Dim faixaeficiencia As New GoldFaixaEficiencia()

            cbo_tipo_faixa.SelectedValue = 4
            cbo_tipo_faixa.Enabled = False

            faixaeficiencia.cd_gold_faixa_eficiencia = cd_gold_faixa

            Dim ds_faixa As DataSet = faixaeficiencia.getGoldFaixaEficienciaByCodigo()

            If (ds_faixa.Tables(0).Rows.Count > 0) Then
                txt_nm_faixa.Text = ds_faixa.Tables(0).Rows(0).Item("nm_gold_faixa_eficiencia").ToString
                cbo_estabelecimento.SelectedValue = ds_faixa.Tables(0).Rows(0).Item("id_estabelecimento").ToString
                cbo_estabelecimento.Enabled = False
                txt_dt_referencia_inicial.Text = (DateTime.Parse(ds_faixa.Tables(0).Rows(0).Item("dt_referencia_inicial").ToString).ToString("MM/yyyy"))
                txt_dt_referencia_inicial.Enabled = False
                txt_dt_referencia_inicial.Enabled = False
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""



                grdFaixas.Visible = False
                cv_grid.Visible = False
                cv_validar_faixas_grid.Visible = False
                btn_nova_faixa.Visible = False

                grdfaixaconsulta.Visible = True
                grdfaixaconsulta.DataSource = Helper.getDataView(ds_faixa.Tables(0), "nr_faixa_inicio asc")
                grdfaixaconsulta.DataBind()
            Else
                grdfaixaconsulta.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCrescimento(ByVal cd_gold_faixa)

        Try

            Dim faixacrescimento As New GoldFaixaCrescimento()

            cbo_tipo_faixa.SelectedValue = 3
            cbo_tipo_faixa.Enabled = False

            faixacrescimento.cd_gold_faixa_crescimento = cd_gold_faixa

            Dim ds_faixa As DataSet = faixacrescimento.getGoldFaixaCrescimentoByCodigo()

            If (ds_faixa.Tables(0).Rows.Count > 0) Then
                txt_nm_faixa.Text = ds_faixa.Tables(0).Rows(0).Item("nm_gold_faixa_crescimento").ToString
                cbo_estabelecimento.SelectedValue = ds_faixa.Tables(0).Rows(0).Item("id_estabelecimento").ToString
                cbo_estabelecimento.Enabled = False
                txt_dt_referencia_inicial.Text = (DateTime.Parse(ds_faixa.Tables(0).Rows(0).Item("dt_referencia_inicial").ToString).ToString("MM/yyyy"))
                txt_dt_referencia_inicial.Enabled = False
                txt_dt_referencia_inicial.Enabled = False
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""


                grdFaixas.Visible = False
                cv_grid.Visible = False
                cv_validar_faixas_grid.Visible = False
                btn_nova_faixa.Visible = False

                grdfaixaconsulta.Visible = True
                grdfaixaconsulta.DataSource = Helper.getDataView(ds_faixa.Tables(0), "nr_faixa_inicio asc")
                grdfaixaconsulta.DataBind()
            Else
                grdfaixaconsulta.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCusto(ByVal cd_gold_faixa)

        Try

            Dim faixacusto As New GoldFaixaCusto()

            cbo_tipo_faixa.SelectedValue = 1
            cbo_tipo_faixa.Enabled = False

            faixacusto.cd_gold_faixa_custo = cd_gold_faixa

            Dim ds_faixa As DataSet = faixacusto.getGoldFaixaCustoByCodigo()

            If (ds_faixa.Tables(0).Rows.Count > 0) Then
                txt_nm_faixa.Text = ds_faixa.Tables(0).Rows(0).Item("nm_gold_faixa_custo").ToString
                cbo_estabelecimento.SelectedValue = ds_faixa.Tables(0).Rows(0).Item("id_estabelecimento").ToString
                cbo_estabelecimento.Enabled = False
                txt_dt_referencia_inicial.Text = (DateTime.Parse(ds_faixa.Tables(0).Rows(0).Item("dt_referencia_inicial").ToString).ToString("MM/yyyy"))
                txt_dt_referencia_inicial.Enabled = False
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""



                grdFaixas.Visible = False
                cv_grid.Visible = False
                cv_validar_faixas_grid.Visible = False
                btn_nova_faixa.Visible = False

                grdfaixaconsulta.Visible = True
                grdfaixaconsulta.DataSource = Helper.getDataView(ds_faixa.Tables(0), "nr_faixa_inicio asc")
                grdfaixaconsulta.DataBind()
            Else
                grdfaixaconsulta.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()
        Try

            Select Case cbo_tipo_faixa.SelectedValue
                Case 1   ' Custo
                    updateCusto()
                Case 2   ' Volume
                    updateVolume()
                Case 3   ' Crescimento
                    updateCrescimento()
                Case 4   ' Eficiencia
                    updateEficiencia()
            End Select


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub updateCusto()
        Try

            If Not ViewState.Item("cd_gold_faixa") Is Nothing Then

                Dim faixaCusto As New GoldFaixaCusto()



                faixaCusto.cd_gold_faixa_custo = Convert.ToInt32(ViewState.Item("cd_gold_faixa"))
                faixaCusto.nm_gold_faixa_custo = txt_nm_faixa.Text
                faixaCusto.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                faixaCusto.id_modificador = Session("id_login")

                faixaCusto.updateGoldFaixaCusto()
                messageControl.Alert("Registro atualizado com sucesso!")
                loadCusto(ViewState.Item("cd_gold_faixa"))

            Else
                If Page.IsValid Then

                    Dim faixa As New GoldFaixaCusto()
                    Dim row As GridViewRow

                    faixa.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixa.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    faixa.nm_gold_faixa_custo = txt_nm_faixa.Text.ToString
                    faixa.id_modificador = Session("id_login")
                    faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    faixa.fxs_ds_faixa = New ArrayList
                    faixa.fxs_nr_inicio = New ArrayList
                    faixa.fxs_nr_fim = New ArrayList

                    For Each row In grdFaixas.Rows
                        If row.Visible = True Then
                            Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                            Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                            faixa.fxs_ds_faixa.Add(txt_nm_faixa.Text.ToString)
                            If Not (txt_nr_faixa_inicio.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_inicio.Add(CDec(txt_nr_faixa_inicio.Text))
                            Else
                                faixa.fxs_nr_inicio.Add(CDec(0))
                            End If
                            If Not (txt_nr_faixa_fim.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_fim.Add(CDec(txt_nr_faixa_fim.Text))
                            Else
                                faixa.fxs_nr_fim.Add(CDec(0))
                            End If

                        End If
                    Next

                    ViewState.Item("cd_gold_faixa") = faixa.insertGrupoGoldFaixasCusto()
                    messageControl.Alert("O Grupo de Faixas foi criado com sucesso!")
                    loadCusto(ViewState.Item("cd_gold_faixa"))

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub updateVolume()
        Try

            If Not ViewState.Item("cd_gold_faixa") Is Nothing Then

                Dim faixaVolume As New GoldFaixaVolume()

                faixaVolume.cd_gold_faixa_volume = Convert.ToInt32(ViewState.Item("cd_gold_faixa"))
                faixaVolume.nm_gold_faixa_volume = txt_nm_faixa.Text
                faixaVolume.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                faixaVolume.id_modificador = Session("id_login")

                faixaVolume.updateGoldFaixaVolume()
                messageControl.Alert("Registro atualizado com sucesso!")
                loadVolume(ViewState.Item("cd_gold_faixa"))

            Else
                If Page.IsValid Then

                    Dim faixa As New GoldFaixaVolume()
                    Dim row As GridViewRow

                    faixa.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixa.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    faixa.nm_gold_faixa_volume = txt_nm_faixa.Text.ToString
                    faixa.id_modificador = Session("id_login")
                    faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    faixa.fxs_ds_faixa = New ArrayList
                    faixa.fxs_nr_inicio = New ArrayList
                    faixa.fxs_nr_fim = New ArrayList

                    For Each row In grdFaixas.Rows
                        If row.Visible = True Then
                            Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                            Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                            faixa.fxs_ds_faixa.Add(txt_nm_faixa.Text.ToString)
                            If Not (txt_nr_faixa_inicio.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_inicio.Add(CDec(txt_nr_faixa_inicio.Text))
                            Else
                                faixa.fxs_nr_inicio.Add(CDec(0))
                            End If
                            If Not (txt_nr_faixa_fim.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_fim.Add(CDec(txt_nr_faixa_fim.Text))
                            Else
                                faixa.fxs_nr_fim.Add(CDec(0))
                            End If

                        End If
                    Next

                    ViewState.Item("cd_gold_faixa") = faixa.insertGrupoGoldFaixasVolume()
                    messageControl.Alert("O Grupo de Faixas foi criado com sucesso!")
                    loadVolume(ViewState.Item("cd_gold_faixa"))

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub updateCrescimento()
        Try

            If Not ViewState.Item("cd_gold_faixa") Is Nothing Then

                Dim faixacrescimento As New GoldFaixaCrescimento()

                faixacrescimento.cd_gold_faixa_crescimento = Convert.ToInt32(ViewState.Item("cd_gold_faixa"))
                faixacrescimento.nm_gold_faixa_crescimento = txt_nm_faixa.Text
                faixacrescimento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                faixacrescimento.id_modificador = Session("id_login")

                faixacrescimento.updateGoldFaixaCrescimento()
                messageControl.Alert("Registro atualizado com sucesso!")
                loadCrescimento(ViewState.Item("cd_gold_faixa"))

            Else
                If Page.IsValid Then

                    Dim faixa As New GoldFaixaCrescimento()
                    Dim row As GridViewRow

                    faixa.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixa.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    faixa.nm_gold_faixa_crescimento = txt_nm_faixa.Text.ToString
                    faixa.id_modificador = Session("id_login")
                    faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    faixa.fxs_ds_faixa = New ArrayList
                    faixa.fxs_nr_inicio = New ArrayList
                    faixa.fxs_nr_fim = New ArrayList

                    For Each row In grdFaixas.Rows
                        If row.Visible = True Then
                            Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                            Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                            faixa.fxs_ds_faixa.Add(txt_nm_faixa.Text.ToString)
                            If Not (txt_nr_faixa_inicio.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_inicio.Add(CDec(txt_nr_faixa_inicio.Text))
                            Else
                                faixa.fxs_nr_inicio.Add(CDec(0))
                            End If
                            If Not (txt_nr_faixa_fim.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_fim.Add(CDec(txt_nr_faixa_fim.Text))
                            Else
                                faixa.fxs_nr_fim.Add(CDec(0))
                            End If

                        End If
                    Next

                    ViewState.Item("cd_gold_faixa") = faixa.insertGrupoGoldFaixasCrescimento()
                    messageControl.Alert("O Grupo de Faixas foi criado com sucesso!")
                    loadCrescimento(ViewState.Item("cd_gold_faixa"))

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub updateEficiencia()
        Try

            If Not ViewState.Item("cd_gold_faixa") Is Nothing Then

                Dim faixaeficiencia As New GoldFaixaEficiencia()

                faixaeficiencia.cd_gold_faixa_eficiencia = Convert.ToInt32(ViewState.Item("cd_gold_faixa"))
                faixaeficiencia.nm_gold_faixa_eficiencia = txt_nm_faixa.Text
                faixaeficiencia.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                faixaeficiencia.id_modificador = Session("id_login")

                faixaeficiencia.updateGoldFaixaEficiencia()
                messageControl.Alert("Registro atualizado com sucesso!")
                loadEficiencia(ViewState.Item("cd_gold_faixa"))

            Else
                If Page.IsValid Then

                    Dim faixa As New GoldFaixaEficiencia()
                    Dim row As GridViewRow

                    faixa.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixa.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    faixa.nm_gold_faixa_eficiencia = txt_nm_faixa.Text.ToString
                    faixa.id_modificador = Session("id_login")
                    faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    faixa.fxs_ds_faixa = New ArrayList
                    faixa.fxs_nr_inicio = New ArrayList
                    faixa.fxs_nr_fim = New ArrayList

                    For Each row In grdFaixas.Rows
                        If row.Visible = True Then
                            Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                            Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                            faixa.fxs_ds_faixa.Add(txt_nm_faixa.Text.ToString)
                            If Not (txt_nr_faixa_inicio.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_inicio.Add(CDec(txt_nr_faixa_inicio.Text))
                            Else
                                faixa.fxs_nr_inicio.Add(CDec(0))
                            End If
                            If Not (txt_nr_faixa_fim.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_fim.Add(CDec(txt_nr_faixa_fim.Text))
                            Else
                                faixa.fxs_nr_fim.Add(CDec(0))
                            End If

                        End If
                    Next

                    ViewState.Item("cd_gold_faixa") = faixa.insertGrupoGoldFaixasEficiencia()
                    messageControl.Alert("O Grupo de Faixas foi criado com sucesso!")
                    loadEficiencia(ViewState.Item("cd_gold_faixa"))

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_gold_faixa.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_gold_faixa.aspx")

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub



    Protected Sub btn_nova_faixa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nova_faixa.Click

        Dim dstable As New DataTable
        Dim ilinha As Integer
        If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
            Dim faixa As New FaixaVolume
            Dim ds As New DataSet
            faixa.id_faixa_volume = 0
            ds = faixa.getFaixaVolumeByFilters
            ViewState.Item("gridLinhasAdicionadas") = "S"
            ilinha = 0
        Else
            ViewState.Item("incluirlinha") = "S"
            'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
            dstable.Columns.Add("nm_faixa_volume")
            dstable.Columns.Add("nr_faixa_inicio")
            dstable.Columns.Add("nr_faixa_fim")
            dstable.Columns.Add("id_faixa_volume")

            Dim row As GridViewRow
            ilinha = 0
            For Each row In grdFaixas.Rows
                If row.Visible = True Then
                    Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                    Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    With dstable.Rows.Item(ilinha)
                        .Item(0) = txt_nm_faixa.Text
                        .Item(1) = txt_nr_faixa_inicio.Text
                        .Item(2) = txt_nr_faixa_fim.Text
                    End With
                    ilinha = ilinha + 1
                End If
            Next

            ViewState.Item("gridtable") = dstable

        End If

        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
        grdFaixas.Visible = True
        grdFaixas.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))

        grdFaixas.DataBind()

        ViewState.Item("incluirlinha") = "N"

    End Sub

    Protected Sub grdFaixas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdFaixas.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteFaixas(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteFaixas(ByVal id_index_row As Integer)

        Try

            grdFaixas.Rows(id_index_row).Visible = False
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridFaixas_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFaixas.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                If ViewState.Item("incluirlinha") = "S" Then
                    Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub


    Protected Sub grdFaixas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFaixas.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_nm_faixa As Anthem.TextBox = CType(e.Row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                txt_nm_faixa.Text = dr.Item(0).ToString
                txt_nr_faixa_inicio.Text = dr.Item(1).ToString
                txt_nr_faixa_fim.Text = dr.Item(2).ToString

            End If
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdFaixas.RowDeleting
        e.Cancel = True

    End Sub


    Protected Sub cv_validar_faixas_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_faixas_grid.ServerValidate
        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim iprincipal As Integer = 0
            Dim fx_ini As New ArrayList
            Dim lmsg As String
            args.IsValid = True

            For Each row In grdFaixas.Rows
                If row.Visible = True Then
                    Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                    If Not txt_nr_faixa_inicio.Text.Equals(String.Empty) Then
                        If Not txt_nr_faixa_fim.Text.Equals(String.Empty) Then
                            If CDec(txt_nr_faixa_inicio.Text.Trim) > CDec(txt_nr_faixa_fim.Text.Trim) Then
                                args.IsValid = False
                                lmsg = "A faixa inicial '" & txt_nr_faixa_inicio.Text & "' não pode ser maior que a faixa final '" & txt_nr_faixa_fim.Text & "'."
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
            If args.IsValid = False Then

                messageControl.Alert(lmsg)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_grid.ServerValidate
        Try
            args.IsValid = True
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                args.IsValid = False
                messageControl.Alert("Uma faixa deve ser informada para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_gold_faixa.aspx")
    End Sub

   
    Protected Sub cv_data_validade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_data_validade.ServerValidate
        Try
            args.IsValid = True

            Select Case cbo_tipo_faixa.SelectedValue
                Case 1   ' Custo
                    Dim faixacusto As New GoldFaixaCusto
                    If Not ViewState.Item("cd_gold_faixa") Is Nothing Then
                        faixacusto.cd_gold_faixa_custo = ViewState.Item("cd_gold_faixa")
                    End If

                    faixacusto.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixacusto.id_situacao = 1
                    faixacusto.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    Dim dscusto As DataSet = faixacusto.getGoldFaixaCustoGrupos
                    If dscusto.Tables(0).Rows.Count > 0 Then
                        args.IsValid = False
                        messageControl.Alert("Período de validade inválido. Já existe uma Faixa de Custo Efetivo cadastrada para esse estabelecimento com o prazo de validade informado.")
                    End If

                Case 2   ' Volume
                    Dim faixavolume As New GoldFaixaVolume
                    If Not ViewState.Item("cd_gold_faixa") Is Nothing Then
                        faixavolume.cd_gold_faixa_volume = ViewState.Item("cd_gold_faixa")
                    End If
                    faixavolume.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixavolume.id_situacao = 1
                    faixavolume.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    Dim dsVolume As DataSet = faixavolume.getGoldFaixaVolumeGrupos
                    If dsVolume.Tables(0).Rows.Count > 0 Then
                        args.IsValid = False
                        messageControl.Alert("Período de validade inválido. Já existe uma Faixa de Volume cadastrada para esse estabelecimento com o prazo de validade informado.")
                    End If


                Case 3   ' Crescimento

                    Dim faixacrescimento As New GoldFaixaCrescimento
                    If Not ViewState.Item("cd_gold_faixa") Is Nothing Then
                        faixacrescimento.cd_gold_faixa_crescimento = ViewState.Item("cd_gold_faixa")
                    End If
                    faixacrescimento.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixacrescimento.id_situacao = 1
                    faixacrescimento.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    Dim dscrescimento As DataSet = faixacrescimento.getGoldFaixaCrescimentoGrupos
                    If dscrescimento.Tables(0).Rows.Count > 0 Then
                        args.IsValid = False
                        messageControl.Alert("Período de validade inválido. Já existe uma Faixa de Crescimento cadastrada para esse estabelecimento com o prazo de validade informado.")
                    End If

                Case 4   ' Eficiencia

                    Dim faixaeficiencia As New GoldFaixaEficiencia
                    If Not ViewState.Item("cd_gold_faixa") Is Nothing Then
                        faixaeficiencia.cd_gold_faixa_eficiencia = ViewState.Item("cd_gold_faixa")
                    End If
                    faixaeficiencia.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixaeficiencia.id_situacao = 1
                    faixaeficiencia.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                    Dim dseficiencia As DataSet = faixaeficiencia.getGoldFaixaEficienciaGrupos
                    If dseficiencia.Tables(0).Rows.Count > 0 Then
                        args.IsValid = False
                        messageControl.Alert("Período de validade inválido. Já existe uma Faixa de Eficiencia da Dieta cadastrada para esse estabelecimento com o prazo de validade informado.")
                    End If

            End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
