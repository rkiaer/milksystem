Imports Danone.MilkSystem.Business

Partial Class frm_faixa_qualidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_qualidade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'Fran 27/11/2009 i chamado 521 Maracanau
            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 27/11/2009 f chamado 521 Maracanau


            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            cbo_un_medida.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_un_medida.Items.Add(New ListItem("Kilograma", "K"))
            cbo_un_medida.Items.Add(New ListItem("Litro", "L"))

            If Not (Request("id_faixa_qualidade") Is Nothing) Then
                ViewState.Item("id_faixa_qualidade") = Request("id_faixa_qualidade")
                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_faixa_qualidade As Int32 = Convert.ToInt32(ViewState.Item("id_faixa_qualidade"))
            Dim faixaqualidade As New FaixaQualidade(id_faixa_qualidade)

            txt_ds_validade.Enabled = False
            cbo_categoria_qualidade.Enabled = False

            txt_ds_validade.Text = faixaqualidade.ds_validade.ToString()

            If (faixaqualidade.id_categoria > 0) Then
                cbo_categoria_qualidade.SelectedValue = faixaqualidade.id_categoria.ToString()
            End If

            txt_nr_faixa_inicio.Text = faixaqualidade.nr_faixa_inicio
            If Not (faixaqualidade.nr_faixa_fim.Equals(0)) Then
                txt_nr_faixa_fim.Text = faixaqualidade.nr_faixa_fim
            End If
            txt_nr_bonus_desconto.Text = faixaqualidade.nr_bonus_desconto

            If Not (faixaqualidade.un_medida.Trim().Equals(String.Empty)) Then
                cbo_un_medida.SelectedValue = faixaqualidade.un_medida
            End If

            If (faixaqualidade.id_situacao > 0) Then
                cbo_situacao.SelectedValue = faixaqualidade.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If
            'Fran 27/11/2009 i chamado 521 Maracanau
            cbo_estabelecimento.SelectedValue = faixaqualidade.id_estabelecimento.ToString()
            cbo_estabelecimento.Enabled = False
            'Fran 27/11/2009 f chamado 521 Maracanau

            lbl_modificador.Text = faixaqualidade.id_modificador.ToString()
            lbl_dt_modificacao.Text = faixaqualidade.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim faixaqualidade As New FaixaQualidade()

            If Not (cbo_categoria_qualidade.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.id_categoria = Convert.ToInt32(cbo_categoria_qualidade.SelectedValue)
            End If

            faixaqualidade.ds_validade = txt_ds_validade.Text.Trim
            faixaqualidade.dt_validade = String.Concat("01/", faixaqualidade.ds_validade)

            If Not (txt_nr_faixa_inicio.Text.Trim().Equals(String.Empty)) Then
                faixaqualidade.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_inicio.Text)
            End If

            If Not (txt_nr_faixa_fim.Text.Trim().Equals(String.Empty)) Then
                faixaqualidade.nr_faixa_fim = Convert.ToDouble(txt_nr_faixa_fim.Text)
            End If

            If Not (txt_nr_bonus_desconto.Text.Trim().Equals(String.Empty)) Then
                faixaqualidade.nr_bonus_desconto = Convert.ToDouble(txt_nr_bonus_desconto.Text)
            End If

            If Not (cbo_un_medida.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.un_medida = cbo_un_medida.SelectedValue
            End If

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaqualidade.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            'Fran 27/11/2009 i chamado 521 Maracanau
            faixaqualidade.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'Fran 27/11/2009 f chamado 521 Maracanau

            faixaqualidade.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_faixa_qualidade") Is Nothing) Then

                    faixaqualidade.id_faixa_qualidade = Convert.ToInt32(ViewState.Item("id_faixa_qualidade"))
                    faixaqualidade.updateFaixaQualidade()
                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_faixa_qualidade") = faixaqualidade.insertFaixaQualidade()
                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_faixa_qualidade.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_faixa_qualidade.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_faixa_qualidade.aspx")
    End Sub
End Class
