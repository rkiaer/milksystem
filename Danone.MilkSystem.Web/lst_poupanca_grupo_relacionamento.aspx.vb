Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class lst_poupanca_grupo_relacionamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_grupo_relacionamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            ViewState.Item("id_propriedade_titular") = 0
            ViewState.Item("id_propriedade_titular_filtro") = 0
            With btn_lupa_produtor
                .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
                .ToolTip = "Filtrar Produtores"
                '.Style("cursor") = "hand"
            End With

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim poupanca As New PoupancaAdesao
            Dim dspoupancagrupo As DataSet

            poupanca.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            poupanca.id_propriedade_titular = ViewState.Item("id_propriedade_titular_filtro")
            poupanca.id_propriedade = ViewState.Item("id_propriedade")
            poupanca.id_pessoa = ViewState.Item("id_produtor")
            poupanca.st_participa_poupanca = ViewState.Item("st_participa_poupanca")

            lbl_referencia_poupanca.Text = ViewState.Item("ds_periodo_poupanca").ToString
            lbl_estabelecimento.Text = ViewState.Item("nm_estabelecimento").ToString
            Dim poupancaparametro As New PoupancaParametro(Convert.ToInt32(ViewState.Item("id_poupanca_parametro")))

            lbl_situacao_poupanca.Text = poupancaparametro.nm_situacao_poupanca
            'assume busca relacionamento titular
            dspoupancagrupo = poupanca.getPoupancaGrupoRelacionamentoTitular

            'se informou propriedade ou propriedadetitular
            If poupanca.id_propriedade_titular > 0 Then
                dspoupancagrupo = poupanca.getPoupancaGrupoRelacionamentoTitular
            Else
                If poupanca.id_propriedade > 0 Then 'se informou propriedade
                    Dim gruporelacionamento As New GrupoRelacionamento
                    gruporelacionamento.id_situacao = 1
                    gruporelacionamento.id_propriedade = poupanca.id_propriedade
                    Dim dsgruporelacionamento As DataSet = gruporelacionamento.getGrupoRelacionamento
                    If dsgruporelacionamento.Tables(0).Rows.Count > 0 Then
                        poupanca.id_propriedade_titular = dsgruporelacionamento.Tables(0).Rows(0).Item("id_propriedade_titular")
                    End If
                    dspoupancagrupo = poupanca.getPoupancaGrupoRelacionamentoTitular
                Else
                    If poupanca.id_pessoa > 0 Then 'se informou pessoa e naõ informou propriedade
                        dspoupancagrupo = poupanca.getPoupancaGrupoRelacionamentoTitularbyPessoa
                    End If
                End If
            End If


            If (dspoupancagrupo.Tables(0).Rows.Count > 0) Then
                gridGrupoTitular.Visible = True
                gridGrupoTitular.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
                gridGrupoTitular.DataBind()
            Else
                gridGrupoTitular.Visible = False
            End If


            loadGridGrupo()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub gridGrupoTitular_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridGrupoTitular.PageIndexChanging
        gridGrupoTitular.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridGrupoTitular_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridGrupoTitular.RowCancelingEdit
        Try

            gridGrupoTitular.EditIndex = -1
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridGrupoTitular_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridGrupoTitular.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "gruporelacionamento"
                If gridGrupoTitular.EditIndex = -1 Then

                    Dim lbl_id_propriedade_titular As Label = CType(gridGrupoTitular.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_propriedade_titular"), Label)
                    Dim lbl_id_grupo_relacionamento As Label = CType(gridGrupoTitular.Rows.Item(e.CommandArgument.ToString).FindControl("id_grupo_relacionamento"), Label)
                    ViewState.Item("id_propriedade_titular") = lbl_id_propriedade_titular.Text
                    ViewState.Item("lbl_detalhe_item") = lbl_id_propriedade_titular.Text

                    loadData()
                End If
        End Select



    End Sub
    Protected Sub gridGrupoTitular_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGrupoTitular.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_detalhe_item As ImageButton = CType(e.Row.FindControl("btn_detalhe_item"), ImageButton)
                btn_detalhe_item.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState.Item("label_participa_poupanca") Is Nothing) Then
                    Dim cbo_st_participa_poupanca As DropDownList = CType(e.Row.FindControl("cbo_st_participa_poupanca"), DropDownList)

                    If Not (ViewState.Item("label_participa_poupanca").ToString.Equals(String.Empty)) Then
                        cbo_st_participa_poupanca.SelectedValue = cbo_st_participa_poupanca.Items.FindByText(ViewState.Item("label_participa_poupanca").Trim.ToString).Value
                        ViewState.Item("label_participa_poupanca") = Nothing
                    End If
                End If
                If Not (ViewState.Item("label_propriedade_responsavel_bonus") Is Nothing) Then
                    Dim poupancapropriedadebonus As New PoupancaAdesao
                    Dim lbl_id_propriedade_titular As Label = CType(e.Row.FindControl("lbl_id_propriedade_titular"), Label)
                    Dim cbo_id_propriedade_responsavel_bonus As DropDownList = CType(e.Row.FindControl("cbo_id_propriedade_responsavel_bonus"), DropDownList)

                    poupancapropriedadebonus.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)
                    poupancapropriedadebonus.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular").ToString)
                    cbo_id_propriedade_responsavel_bonus.DataSource = poupancapropriedadebonus.getPoupancaPropriedadeBonus()
                    cbo_id_propriedade_responsavel_bonus.DataTextField = "id_propriedade"
                    cbo_id_propriedade_responsavel_bonus.DataValueField = "id_propriedade"
                    cbo_id_propriedade_responsavel_bonus.DataBind()

                    If (ViewState.Item("label_propriedade_responsavel_bonus").ToString.Equals(String.Empty)) Then
                        cbo_id_propriedade_responsavel_bonus.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_propriedade_responsavel_bonus") = "SEM_VALOR"
                    Else
                        cbo_id_propriedade_responsavel_bonus.SelectedValue = cbo_id_propriedade_responsavel_bonus.Items.FindByText(ViewState.Item("label_propriedade_responsavel_bonus").Trim.ToString).Value
                        ViewState.Item("label_propriedade_responsavel_bonus") = Nothing
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
    Protected Sub gridGrupoTitular_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGrupoTitular.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                    Dim cbo_id_propriedade_responsavel_bonus As DropDownList = CType(e.Row.FindControl("cbo_id_propriedade_responsavel_bonus"), DropDownList)
                    Dim cbo_st_participa_poupanca As DropDownList = CType(e.Row.FindControl("cbo_st_participa_poupanca"), DropDownList)
                    Dim lbl_id_propriedade_titular As Label = CType(e.Row.FindControl("lbl_id_propriedade_titular"), Label)

                    If ViewState.Item("label_propriedade_responsavel_bonus") = "SEM_VALOR" Then
                        'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                        If Not (cbo_id_propriedade_responsavel_bonus Is Nothing) Then
                            cbo_id_propriedade_responsavel_bonus.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        End If
                        ViewState.Item("label_propriedade_responsavel_bonus") = Nothing

                    End If
                    If ViewState.Item("label_participa_poupanca") = "SEM_VALOR" Then
                        'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                        If Not (cbo_st_participa_poupanca Is Nothing) Then
                            'cbo_st_participa_poupanca.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        End If
                        ViewState.Item("label_participa_poupanca") = Nothing

                    End If

                    If (Not lbl_id_propriedade_titular.Text.Equals(String.Empty)) AndAlso CLng(lbl_id_propriedade_titular.Text) = CLng(ViewState.Item("id_propriedade_titular")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                        lbl_id_propriedade_titular.ForeColor = Drawing.Color.Red 'fran 25/08/2015
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_id_propriedade_titular.ForeColor = System.Drawing.Color.FromName("#333333") 'fran 25/08/2015
                    End If


                Else
                    Dim lbl_st_participa_poupanca As Label = CType(e.Row.FindControl("lbl_st_participa_poupanca"), Label)
                    Dim lbl_id_propriedade_responsavel_bonus As Label = CType(e.Row.FindControl("lbl_id_propriedade_responsavel_bonus"), Label)
                    Dim st_participa_poupanca As Label = CType(e.Row.FindControl("st_participa_poupanca"), Label)
                    Dim lbl_id_propriedade_titular As Label = CType(e.Row.FindControl("lbl_id_propriedade_titular"), Label)

                    If (Not lbl_id_propriedade_titular.Text.Equals(String.Empty)) AndAlso CLng(lbl_id_propriedade_titular.Text) = CLng(ViewState.Item("id_propriedade_titular")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                        lbl_st_participa_poupanca.ForeColor = Drawing.Color.Red
                        lbl_id_propriedade_responsavel_bonus.ForeColor = Drawing.Color.Red
                        lbl_id_propriedade_titular.ForeColor = Drawing.Color.Red 'fran 25/08/2015
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_st_participa_poupanca.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_id_propriedade_responsavel_bonus.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_id_propriedade_titular.ForeColor = System.Drawing.Color.FromName("#333333") 'fran 25/08/2015
                    End If

                    If lbl_id_propriedade_responsavel_bonus.Text.Equals("0") Then
                        lbl_id_propriedade_responsavel_bonus.Text = String.Empty
                    End If
                    'se tempo de adesao é vazio
                    If e.Row.Cells(3).Text.Trim.Equals(String.Empty) Or e.Row.Cells(3).Text.Trim.Equals("&nbsp;") Then
                        Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                        btn_editar.Enabled = False
                        btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
                        btn_editar.ToolTip = "Não existe adesão à poupança."
                    Else
                        Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                        btn_editar.Enabled = True
                        btn_editar.ImageUrl = "~/img/icone_editar_grid.gif"
                        btn_editar.ToolTip = String.Empty
                    End If
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadGridGrupo()
        Try

            If ViewState.Item("id_propriedade_titular") Is Nothing Then
                ViewState.Item("id_propriedade_titular") = 0
            End If
            'Carrega os dados do Grid
            Dim poupancagrupo As New PoupancaAdesao
            poupancagrupo.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
            If CLng(ViewState.Item("id_propriedade_titular")) > 0 Then
                poupancagrupo.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular"))
                lbl_detalhe_titular.Text = ViewState.Item("lbl_detalhe_item").ToString

                Dim dspoupancagrupo As DataSet = poupancagrupo.getPoupancaGrupoRelacionamentoAdesaobyTitular()

                If (dspoupancagrupo.Tables(0).Rows.Count > 0) Then
                    gridGrupo.Visible = True
                    gridGrupo.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
                    gridGrupo.DataBind()
                Else
                    Dim dr As DataRow = dspoupancagrupo.Tables(0).NewRow()
                    dspoupancagrupo.Tables(0).Rows.InsertAt(dr, 0)
                    gridGrupo.Visible = True
                    gridGrupo.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
                    gridGrupo.DataBind()
                    gridGrupo.Rows(0).Cells.Clear()
                    gridGrupo.Rows(0).Cells.Add(New TableCell())
                    gridGrupo.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridGrupo.Rows(0).Cells(0).Text = "Não existe ainda nenhum grupo de relacionamento informado para a propriedade titular selecionada!"
                    gridGrupo.Rows(0).Cells(0).ColumnSpan = 11
                End If
            Else
                poupancagrupo.id_propriedade_titular = -1
                Dim dspoupancagrupo As DataSet = poupancagrupo.getPoupancaGrupoRelacionamentoAdesaobyTitular()
                Dim dr As DataRow = dspoupancagrupo.Tables(0).NewRow()
                dspoupancagrupo.Tables(0).Rows.InsertAt(dr, 0)
                gridGrupo.Visible = True
                gridGrupo.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
                gridGrupo.DataBind()
                gridGrupo.Rows(0).Cells.Clear()
                gridGrupo.Rows(0).Cells.Add(New TableCell())
                gridGrupo.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridGrupo.Rows(0).Cells(0).Text = "Selecione o detalhe da Propriedade Titular para visualizar seu grupo de relacionamento."
                gridGrupo.Rows(0).Cells(0).ColumnSpan = 11
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_pesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisar.Click
        If Page.IsValid Then
            Try
                limparGrids()

                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("nm_estabelecimento") = cbo_estabelecimento.SelectedItem.Text
                ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue
                ViewState.Item("ds_periodo_poupanca") = cbo_referencia_poupanca.SelectedItem.Text
                ViewState.Item("st_participa_poupanca") = cbo_st_participa_poupanca.SelectedValue

                If Not txt_id_propriedade_titular.Text.Equals(String.Empty) Then
                    ViewState.Item("id_propriedade_titular_filtro") = txt_id_propriedade_titular.Text
                Else
                    ViewState.Item("id_propriedade_titular_filtro") = 0
                End If
                If Not txt_id_propriedade.Text.Equals(String.Empty) Then
                    ViewState.Item("id_propriedade") = txt_id_propriedade.Text
                Else
                    ViewState.Item("id_propriedade") = 0
                End If
                If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                    ViewState.Item("cd_produtor") = txt_cd_pessoa.Text
                    ViewState.Item("id_produtor") = hf_id_pessoa.Value
                Else
                    ViewState.Item("cd_produtor") = String.Empty
                    ViewState.Item("id_produtor") = 0
                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_limpar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpar.Click
        Response.Redirect("lst_poupanca_grupo_relacionamento.aspx")

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.situacao = "1|3" 'aberto e liberado

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametrobySituacao()
            cbo_referencia_poupanca.DataTextField = "ds_periodo_poupanca"
            cbo_referencia_poupanca.DataValueField = "id_poupanca_parametro"
            cbo_referencia_poupanca.DataBind()
            cbo_referencia_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_referencia_poupanca.SelectedValue = 0
        Else
            cbo_referencia_poupanca.Items.Clear()
            cbo_referencia_poupanca.Enabled = False

        End If

    End Sub

    Protected Sub cbo_st_participa_poupanca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            Dim cbo_st_participa_poupanca As DropDownList = CType(row.FindControl("cbo_st_participa_poupanca"), DropDownList)
            Dim rf_propriedadebonus As RequiredFieldValidator = CType(row.FindControl("rf_propriedadebonus"), RequiredFieldValidator)
            Dim cbo_id_propriedade_responsavel_bonus As DropDownList = CType(row.FindControl("cbo_id_propriedade_responsavel_bonus"), DropDownList)
            Dim lbl_produtor_responsavel As Label = CType(row.FindControl("lbl_produtor_responsavel"), Label)

            If cbo_st_participa_poupanca.SelectedValue.Equals("I") Then
                'se for grupo individual não precisa de propriedade responsavel
                rf_propriedadebonus.Visible = False
                cbo_id_propriedade_responsavel_bonus.Enabled = False
                lbl_produtor_responsavel.Enabled = False
            Else
                rf_propriedadebonus.Visible = True
                cbo_id_propriedade_responsavel_bonus.Enabled = True
                lbl_produtor_responsavel.Enabled = True

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridGrupoTitular_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridGrupoTitular.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridGrupoTitular_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridGrupoTitular.RowEditing
        Try

            Dim lbl_st_participa_poupanca As Label = CType(gridGrupoTitular.Rows(e.NewEditIndex).FindControl("lbl_st_participa_poupanca"), Label)
            Dim lbl_id_propriedade_responsavel_bonus As Label = CType(gridGrupoTitular.Rows(e.NewEditIndex).FindControl("lbl_id_propriedade_responsavel_bonus"), Label)
            Dim lbl_id_propriedade_titular As Label = CType(gridGrupoTitular.Rows.Item(e.NewEditIndex).FindControl("lbl_id_propriedade_titular"), Label)
            ViewState.Item("label_participa_poupanca") = Trim(lbl_st_participa_poupanca.Text)
            ViewState.Item("label_propriedade_responsavel_bonus") = Trim(lbl_id_propriedade_responsavel_bonus.Text)
            ViewState.Item("id_propriedade_titular") = lbl_id_propriedade_titular.Text
            ViewState.Item("lbl_detalhe_item") = lbl_id_propriedade_titular.Text

            gridGrupoTitular.EditIndex = e.NewEditIndex
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridGrupoTitular_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridGrupoTitular.RowUpdating
        Dim row As GridViewRow = gridGrupoTitular.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim grupo As New GrupoRelacionamento

                    Dim cbo_st_participa_poupanca As DropDownList = CType(row.FindControl("cbo_st_participa_poupanca"), DropDownList)
                    Dim lbl_id_propriedade_titular As Label = CType(row.FindControl("lbl_id_propriedade_titular"), Label)
                    Dim cbo_id_propriedade_responsavel_bonus As DropDownList = CType(row.FindControl("cbo_id_propriedade_responsavel_bonus"), DropDownList)

                    grupo.st_participa_poupanca = cbo_st_participa_poupanca.SelectedValue
                    If grupo.st_participa_poupanca.Equals("G") Then
                        grupo.id_propriedade_responsavel_bonus = cbo_id_propriedade_responsavel_bonus.SelectedValue
                    End If
                    grupo.id_propriedade_titular = lbl_id_propriedade_titular.Text

                    grupo.id_modificador = Session("id_login")
                    grupo.updateGrupoRelacionamentoParametroPoupanca()

                    gridGrupoTitular.EditIndex = -1

                    loadData()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridGrupo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGrupo.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim img_adesao_poupanca As Anthem.Image = CType(e.Row.FindControl("img_adesao_poupanca"), Anthem.Image)
                Dim lbl_id_poupanca_adesao As Label = CType(e.Row.FindControl("lbl_id_poupanca_adesao"), Label)

                If lbl_id_poupanca_adesao.Text.Equals("0") Then
                    img_adesao_poupanca.ImageUrl = "~/img/ico_chk_false.gif"
                Else
                    img_adesao_poupanca.ImageUrl = "~/img/ico_chk_true.gif"
                End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub limparGrids()
        Try

            ViewState.Item("id_propriedade_titular") = 0
            'Carrega os dados do Grid
            Dim poupancagrupo As New PoupancaAdesao
            poupancagrupo.id_poupanca_parametro = 0
            poupancagrupo.id_propriedade_titular = -1

            Dim dspoupancagrupo As DataSet = poupancagrupo.getPoupancaGrupoRelacionamentoAdesaobyTitular()
            Dim dr As DataRow = dspoupancagrupo.Tables(0).NewRow()
            dspoupancagrupo.Tables(0).Rows.InsertAt(dr, 0)
            gridGrupo.Visible = True
            gridGrupo.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
            gridGrupo.DataBind()
            gridGrupo.Rows(0).Cells.Clear()
            gridGrupo.Rows(0).Cells.Add(New TableCell())
            gridGrupo.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridGrupo.Rows(0).Cells(0).Text = "Selecione o detalhe da Propriedade Titular para visualizar seu grupo de relacionamento."
            gridGrupo.Rows(0).Cells(0).ColumnSpan = 11

            dspoupancagrupo = poupancagrupo.getPoupancaGrupoRelacionamentoTitular
            dr = dspoupancagrupo.Tables(0).NewRow()
            dspoupancagrupo.Tables(0).Rows.InsertAt(dr, 0)
            gridGrupoTitular.Visible = True
            gridGrupoTitular.DataSource = Helper.getDataView(dspoupancagrupo.Tables(0), "")
            gridGrupoTitular.DataBind()
            gridGrupoTitular.Rows(0).Cells.Clear()
            gridGrupoTitular.Rows(0).Cells.Add(New TableCell())
            gridGrupoTitular.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridGrupoTitular.Rows(0).Cells(0).Text = "Uma pesquisa deve ser realizada para a visualização das propriedades titulares do grupo de relacionamento."
            gridGrupoTitular.Rows(0).Cells(0).ColumnSpan = 11



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
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

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


End Class