Imports Danone.MilkSystem.Business

Partial Class frm_faixa_pagamento_produtor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_pagamento_produtor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_faixa_pagamento_produtor") Is Nothing) Then
                ViewState.Item("id_faixa_pagamento_produtor") = Request("id_faixa_pagamento_produtor")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_faixa_pagamento_produtor As Int32 = Convert.ToInt32(ViewState.Item("id_faixa_pagamento_produtor"))
            Dim faixapagtoprodutor As New FaixaPagamentoProdutor(id_faixa_pagamento_produtor)

            txt_nr_faixa_inicio.Text = faixapagtoprodutor.nr_faixa_inicio
            If Not (faixapagtoprodutor.nr_faixa_fim.Equals(0)) Then
                txt_nr_faixa_fim.Text = faixapagtoprodutor.nr_faixa_fim
            End If
            txt_nr_dia_pagamento.Text = faixapagtoprodutor.nr_dia_pagamento

            If (faixapagtoprodutor.id_situacao > 0) Then
                cbo_situacao.SelectedValue = faixapagtoprodutor.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = faixapagtoprodutor.id_modificador.ToString()
            lbl_dt_modificacao.Text = faixapagtoprodutor.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim faixapagtoprodutor As New FaixaPagamentoProdutor()


            If Not (txt_nr_faixa_inicio.Text.Trim().Equals(String.Empty)) Then
                faixapagtoprodutor.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_inicio.Text)
            End If

            If Not (txt_nr_faixa_fim.Text.Trim().Equals(String.Empty)) Then
                faixapagtoprodutor.nr_faixa_fim = Convert.ToDouble(txt_nr_faixa_fim.Text)
            End If

            If Not (txt_nr_dia_pagamento.Text.Trim().Equals(String.Empty)) Then
                faixapagtoprodutor.nr_dia_pagamento = Convert.ToInt32(txt_nr_dia_pagamento.Text)
            End If

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                faixapagtoprodutor.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            faixapagtoprodutor.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_faixa_pagamento_produtor") Is Nothing) Then

                    faixapagtoprodutor.id_faixa_pagamento_produtor = Convert.ToInt32(ViewState.Item("id_faixa_pagamento_produtor"))
                    faixapagtoprodutor.updateFaixaPagamentoProdutor()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 67
                    usuariolog.id_nr_processo = ViewState.Item("id_faixa_pagamento_produtor")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_faixa_pagamento_produtor") = faixapagtoprodutor.insertFaixaPagamentoProdutor()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 67
                    usuariolog.id_nr_processo = ViewState.Item("id_faixa_pagamento_produtor")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_faixa_pagamento_produtor.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_faixa_pagamento_produtor.aspx")
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
        Response.Redirect("frm_faixa_pagamento_produtor.aspx")

    End Sub
End Class
