Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_faixa_qualidade_complience
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_faixa_qualidade_complience.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try
            Dim situacoes As New Situacao

            Dim estabelecimento As New Estabelecimento
            estabelecimento.id_situacao = 1 '  adri 08/02/2017 - chamado 2500 - Para trazer somente os ativos
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

            Dim operador As New TipoOperador
            cbo_operador.DataSource = operador.getTipoOperador
            cbo_operador.DataTextField = "nm_tipo_operador"
            cbo_operador.DataValueField = "id_operador"
            cbo_operador.DataBind()
            cbo_operador.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaComplience()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_faixa_qualidade_complience") Is Nothing) Then
                ViewState.Item("id_faixa_qualidade_complience") = Request("id_faixa_qualidade_complience")
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""
                loadData()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim faixaqualidade As New FaixaQualidadeComplience(Convert.ToInt32(ViewState("id_faixa_qualidade_complience")))


            If (faixaqualidade.id_categoria > 0) Then
                cbo_categoria_qualidade.SelectedValue = faixaqualidade.id_categoria.ToString()
                cbo_categoria_qualidade.Enabled = False
            End If

            txt_dt_validade.Text = faixaqualidade.ds_validade
            txt_dt_validade.Enabled = False

            If (faixaqualidade.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = faixaqualidade.id_estabelecimento.ToString()
                cbo_estabelecimento.Enabled = False
            End If

            '08/02/2017 - Mirella i
            If faixaqualidade.ds_faixa_qualidade_complience <> "" Then
                txt_ds_faixa_qualidade_complience.Text = faixaqualidade.ds_faixa_qualidade_complience
                txt_ds_faixa_qualidade_complience.Enabled = False
            End If
            '08/02/2017 - Mirella g

            txt_nr_valor.Text = faixaqualidade.nr_valor
            txt_nr_valor.Enabled = False

            '08/02/2017 - Mirella i
            If cbo_categoria_qualidade.SelectedValue = 1 Or cbo_categoria_qualidade.SelectedValue = 2 Then
                txt_nr_valor.Text = FormatNumber(CDec(txt_nr_valor.Text), 0)
            End If
            '08/02/2017 - Mirella f


            cbo_operador.SelectedValue = faixaqualidade.id_operador.ToString()
            cbo_operador.Enabled = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        Try
            Dim faixaqualidade As New FaixaQualidadeComplience()

            If Not (cbo_categoria_qualidade.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.id_categoria = Convert.ToInt32(cbo_categoria_qualidade.SelectedValue)
            End If

            faixaqualidade.dt_validade = txt_dt_validade.Text.Trim
            faixaqualidade.dt_validade = String.Concat("01/", faixaqualidade.dt_validade)

            If Not (txt_nr_valor.Text.Trim().Equals(String.Empty)) Then
                faixaqualidade.nr_valor = Convert.ToDouble(txt_nr_valor.Text)
            End If

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            If Not (cbo_operador.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.id_operador = Convert.ToInt32(cbo_operador.SelectedValue)
            End If

            faixaqualidade.ds_faixa_qualidade_complience = txt_ds_faixa_qualidade_complience.Text

            faixaqualidade.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)

            faixaqualidade.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_faixa_qualidade_complience") Is Nothing) Then

                    faixaqualidade.id_faixa_qualidade_complience = Convert.ToInt32(ViewState.Item("id_faixa_qualidade_complience"))
                    faixaqualidade.updateFaixaQualidadeComplience()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 172
                    usuariolog.id_nr_processo = ViewState.Item("id_faixa_qualidade_complience")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    faixaqualidade.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    faixaqualidade.id_situacao = 1
                    faixaqualidade.dt_validade = String.Concat("01/" & txt_dt_validade.Text)
                    faixaqualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
                    Dim dsfaixaqualidade As DataSet = faixaqualidade.getFaixaQualidadeComplienceByFilters

                    If dsfaixaqualidade.Tables(0).Rows.Count > 0 Then
                        messageControl.Alert("Período de validade inválido. Já existe uma Faixa de Qualidade cadastrada para esse estabelecimento com o prazo de validade informado.")
                    Else
                        ViewState.Item("id_faixa_qualidade_complience") = faixaqualidade.insertFaixaQualidadeComplience()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 172
                        usuariolog.id_nr_processo = ViewState.Item("id_faixa_qualidade_complience")

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")
                    End If

                End If

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_faixa_qualidade_complience.aspx")

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_faixa_qualidade_complience.aspx")

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_faixa_qualidade_complience.aspx")
    End Sub

End Class
