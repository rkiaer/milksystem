Imports Danone.MilkSystem.Business

Partial Class frm_faixa_incentivo_fiscal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_faixa_incentivo_fiscal.aspx")
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

            'Fran 24/11/2009 i chamado 520 - Maracanau
            Dim estabel As New Estabelecimento
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 24/11/2009 f

            If Not (Request("id_faixa_incentivo_fiscal") Is Nothing) Then
                ViewState.Item("id_faixa_incentivo_fiscal") = Request("id_faixa_incentivo_fiscal")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_faixa_incentivo_fiscal As Int32 = Convert.ToInt32(ViewState.Item("id_faixa_incentivo_fiscal"))
            Dim faixaincentivofiscal As New FaixaIncentivoFiscal(id_faixa_incentivo_fiscal)

            txt_ds_validade.Enabled = False
            txt_ds_validade.Text = faixaincentivofiscal.ds_validade.ToString()

            txt_nr_faixa_inicio.Text = faixaincentivofiscal.nr_faixa_inicio
            If Not (faixaincentivofiscal.nr_faixa_fim.Equals(0)) Then
                txt_nr_faixa_fim.Text = faixaincentivofiscal.nr_faixa_fim
            End If
            txt_nr_incentivo_fiscal.Text = faixaincentivofiscal.nr_incentivo_fiscal

            If (faixaincentivofiscal.id_situacao > 0) Then
                cbo_situacao.SelectedValue = faixaincentivofiscal.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If
            'Fran 27/11/2009 i chamado 520 - Maracanau
            If faixaincentivofiscal.id_estabelecimento > 0 Then
                cbo_estabelecimento.SelectedValue = faixaincentivofiscal.id_estabelecimento
                cbo_estabelecimento.Enabled = False
            End If
            'Fran 27/11/2009 f

            lbl_modificador.Text = faixaincentivofiscal.id_modificador.ToString()
            lbl_dt_modificacao.Text = faixaincentivofiscal.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim faixaincentivofiscal As New FaixaIncentivoFiscal()


            faixaincentivofiscal.ds_validade = txt_ds_validade.Text.Trim
            faixaincentivofiscal.dt_validade = String.Concat("01/", faixaincentivofiscal.ds_validade)

            If Not (txt_nr_faixa_inicio.Text.Trim().Equals(String.Empty)) Then
                faixaincentivofiscal.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_inicio.Text)
            End If

            If Not (txt_nr_faixa_fim.Text.Trim().Equals(String.Empty)) Then
                faixaincentivofiscal.nr_faixa_fim = Convert.ToDouble(txt_nr_faixa_fim.Text)
            End If

            If Not (txt_nr_incentivo_fiscal.Text.Trim().Equals(String.Empty)) Then
                faixaincentivofiscal.nr_incentivo_fiscal = Convert.ToDouble(txt_nr_incentivo_fiscal.Text)
            End If

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                faixaincentivofiscal.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            'Fran 27/11/2009 i Maracanau chamado 520
            If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
                faixaincentivofiscal.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            End If
            'Fran 27/11/2009 f

            faixaincentivofiscal.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_faixa_incentivo_fiscal") Is Nothing) Then

                    faixaincentivofiscal.id_faixa_incentivo_fiscal = Convert.ToInt32(ViewState.Item("id_faixa_incentivo_fiscal"))
                    faixaincentivofiscal.updateFaixaIncentivoFiscal()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 30
                    usuariolog.id_nr_processo = ViewState.Item("id_faixa_incentivo_fiscal")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_faixa_incentivo_fiscal") = faixaincentivofiscal.insertFaixaIncentivoFiscal()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'insert
                    usuariolog.id_menu_item = 30
                    usuariolog.id_nr_processo = ViewState.Item("id_faixa_incentivo_fiscal")

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
        Response.Redirect("lst_faixa_incentivo_fiscal.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_faixa_incentivo_fiscal.aspx")
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
        Response.Redirect("frm_faixa_incentivo_fiscal.aspx")

    End Sub
End Class
