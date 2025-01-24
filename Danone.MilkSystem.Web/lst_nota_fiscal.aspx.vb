Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_nota_fiscal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        End If

        If Not (Me.txt_nr_nota_fiscal.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nr_nota_fiscal") = Me.txt_nr_nota_fiscal.Text.Trim()
        Else
            ViewState.Item("nr_nota_fiscal") = String.Empty
        End If
        ViewState.Item("id_natureza_operacao") = Me.cbo_natureza_operacao.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        'fran 5/1/2011 gko i
        If Not (Me.txt_id_romaneio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_romaneio") = Me.txt_id_romaneio.Text.Trim()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        'fran 5/1/2011 gko f

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_nota_fiscal.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_nota_fiscal.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 25
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim naturezaoperecao As New NaturezaOperacao
            naturezaoperecao.id_situacao = 1 'ativo

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_natureza_operacao.DataSource = naturezaoperecao.getNaturezaOperacoesByFilters()
            cbo_natureza_operacao.DataTextField = "cd_natureza_operacao"
            cbo_natureza_operacao.DataValueField = "id_natureza_operacao"
            cbo_natureza_operacao.DataBind()
            cbo_natureza_operacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "nr_nota_fiscal asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("notafiscal", cbo_estabelecimento.ID).Equals("0")) And Not (customPage.getFilterValue("notafiscal", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("notafiscal", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("notafiscal", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("notafiscal", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", txt_nr_nota_fiscal.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_nota_fiscal") = customPage.getFilterValue("notafiscal", txt_nr_nota_fiscal.ID)
            txt_nr_nota_fiscal.Text = ViewState.Item("nr_nota_fiscal").ToString()
        Else
            ViewState.Item("nr_nota_fiscal") = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("notafiscal", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", cbo_natureza_operacao.ID).Equals("0")) And Not (customPage.getFilterValue("notafiscal", cbo_natureza_operacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_natureza_operacao") = customPage.getFilterValue("notafiscal", cbo_natureza_operacao.ID)
            cbo_natureza_operacao.Text = ViewState.Item("id_natureza_operacao").ToString()
        Else
            ViewState.Item("id_natureza_operacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("notafiscal", cbo_situacao.ID).Equals("0")) And Not (customPage.getFilterValue("notafiscal", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("notafiscal", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = 0
        End If
        'fran 05/01/2011 gko i
        If Not (customPage.getFilterValue("notafiscal", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("notafiscal", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        'fran 05/01/2011 gko f

        If Not (customPage.getFilterValue("notafiscal", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("notafiscal", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("notafiscal")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim notafiscal As New NotaFiscal

            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
            Else
                notafiscal.id_estabelecimento = 0
            End If
            If Not (ViewState.Item("nr_nota_fiscal").Equals(String.Empty)) Then
                notafiscal.nr_nota_fiscal = ViewState.Item("nr_nota_fiscal").ToString
            Else
                notafiscal.nr_nota_fiscal = String.Empty
            End If
            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                notafiscal.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                notafiscal.id_pessoa = 0
            End If
            notafiscal.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            If Not (ViewState.Item("id_natureza_operacao").Equals(String.Empty)) Then
                notafiscal.id_natureza_operacao = Convert.ToInt32(ViewState.Item("id_natureza_operacao").ToString())
            Else
                notafiscal.id_natureza_operacao = 0
            End If
            'fran 05/01/2011 gko i
            If Not (ViewState.Item("id_romaneio").Equals(String.Empty)) Then
                notafiscal.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Else
                notafiscal.id_romaneio = 0
            End If
            'fran 05/01/2011 gko i

            Dim dsnf As DataSet = notafiscal.getNotasFiscaisByFilters()

            If (dsnf.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsnf.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nr_nota_fiscal"
                If (ViewState.Item("sortExpression")) = "nr_nota_fiscal asc" Then
                    ViewState.Item("sortExpression") = "nr_nota_fiscal desc"
                Else
                    ViewState.Item("sortExpression") = "nr_nota_fiscal asc"
                End If

            Case "nr_serie"
                If (ViewState.Item("sortExpression")) = "nr_serie asc" Then
                    ViewState.Item("sortExpression") = "nr_serie desc"
                Else
                    ViewState.Item("sortExpression") = "nr_serie asc"
                End If

            Case "ds_pessoa"
                If (ViewState.Item("sortExpression")) = "ds_pessoa asc" Then
                    ViewState.Item("sortExpression") = "ds_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_pessoa asc"
                End If

            Case "ds_estabelecimento"
                If (ViewState.Item("sortExpression")) = "ds_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "ds_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "ds_estabelecimento asc"
                End If
            Case "cd_natureza_operacao"
                If (ViewState.Item("sortExpression")) = "cd_natureza_operacao asc" Then
                    ViewState.Item("sortExpression") = "cd_natureza_operacao desc"
                Else
                    ViewState.Item("sortExpression") = "cd_natureza_operacao asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub carregarCamposCooperativa()

        Try



            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


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

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_pessoa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pessoa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)

            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
            lidpessoa = pessoa.validarCooperativa

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Emitente não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("notafiscal", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("notafiscal", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("notafiscal", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("notafiscal", txt_nr_nota_fiscal.ID, ViewState.Item("nr_nota_fiscal").ToString)
            customPage.setFilter("notafiscal", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("notafiscal", cbo_natureza_operacao.ID, ViewState.Item("id_natureza_operacao").ToString)
            customPage.setFilter("notafiscal", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString) 'fran 05/01/2011 gko
            customPage.setFilter("notafiscal", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("notafiscal", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_nota_fiscal.aspx?id_nota_fiscal=" + e.CommandArgument.ToString())

            Case "delete"
                deleteNotaFiscal(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_nota_fiscal.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim data_ini As String
            Dim data_fim As String

            data_ini = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(data_ini)))
            If Convert.ToDateTime(e.Row.Cells(6).Text) < Convert.ToDateTime(data_ini) Or Convert.ToDateTime(e.Row.Cells(6).Text) > Convert.ToDateTime(data_fim) Then  ' Se Data de Transferência estiver fora do mes corrente
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                If Not (btnexcluir Is Nothing) Then
                    btnexcluir.Enabled = False
                    btnexcluir.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                End If
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    'Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
    '    Me.lbl_nm_pessoa.Text = ""
    '    Me.txt_cd_pessoa.Text = ""
    '    Me.hf_id_pessoa.Value = ""
    '    Me.lbl_nm_pessoa.Visible = False
    'End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
        End If
        'End If

    End Sub
    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty
    End Sub

    Private Sub deleteNotaFiscal(ByVal id_nota_fiscal As Integer)

        Try

            Dim notafiscal As New NotaFiscal
            notafiscal.id_nota_fiscal = id_nota_fiscal
            notafiscal.id_modificador = Convert.ToInt32(Session("id_nota_fiscal"))
            notafiscal.deleteNotaFiscal()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 25
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, qualquer manutenção neste documento não será enviada ao EMS.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
End Class
