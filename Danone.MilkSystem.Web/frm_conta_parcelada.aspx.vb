Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_conta_parcelada
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_conta_parcelada.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With

    End Sub

    Private Sub loadDetails()

        Try


            Dim conta As New Conta
            If (Request("id_conta_parcelada") Is Nothing) Then
                conta.id_situacao = 1
            End If

            'cbo_conta.DataSource = conta.getContaByFilters()
            cbo_conta.DataSource = conta.getContaLancamentoByFilters()      ' 13/11/2008
            cbo_conta.DataTextField = "ds_conta"
            cbo_conta.DataValueField = "id_conta"
            cbo_conta.DataBind()
            cbo_conta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_conta_parcelada") Is Nothing) Then
                ViewState.Item("id_conta_parcelada") = Request("id_conta_parcelada")
                'txt_cd_propriedade.Enabled = False
                'cbo_conta.Enabled = False
                'lbl_produtor.Visible = True
                'lbl_estabelecimento.Visible = True
                loadData()
            Else
                txt_cd_propriedade.Enabled = True
                cbo_conta.Enabled = True
                lbl_estabelecimento.Visible = False
                lbl_nm_estabelecimento.Visible = False
                lbl_produtor.Visible = False
                lbl_nm_produtor.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_conta_parcelada As Int32 = Convert.ToInt32(ViewState.Item("id_conta_parcelada"))
            Dim contaparcelada As New ContaParcelada(id_conta_parcelada)

            lbl_produtor.Visible = True
            lbl_nm_produtor.Visible = True
            lbl_nm_produtor.Text = contaparcelada.ds_produtor
            lbl_estabelecimento.Visible = True
            lbl_nm_estabelecimento.Visible = True
            lbl_nm_estabelecimento.Text = contaparcelada.ds_estabelecimento

            txt_cd_propriedade.Text = contaparcelada.id_propriedade
            txt_cd_propriedade.Enabled = False
            lbl_nm_propriedade.Visible = True
            lbl_nm_propriedade.Text = contaparcelada.nm_propriedade
            btn_lupa_propriedade.Visible = False
            If (contaparcelada.id_conta > 0) Then
                cbo_conta.SelectedValue = contaparcelada.id_conta.ToString()
                cbo_conta.Enabled = False
            End If

            txt_valor_total.Text = contaparcelada.nr_valor_total
            'fran 06/2016 i
            'Se for conta gerada pelo romaneio , volume rejeitado
            If contaparcelada.id_conta = 263 Then
                txt_valor_total.Enabled = False
                tr_romaneio.Visible = True
                lbl_romaneio.Text = contaparcelada.id_romaneio
            Else
                tr_romaneio.Visible = False
            End If
            'fran 06/2016 f

            txt_nr_taxa.Text = contaparcelada.nr_taxa

            If Not (contaparcelada.dt_inicio_desconto Is Nothing) Then
                txt_dt_incio_desconto.Text = DateTime.Parse(contaparcelada.dt_inicio_desconto).ToString("dd/MM/yyyy")
            End If

            txt_qtd_parcela.Text = contaparcelada.nr_qtd_parcela.ToString

            txt_valor_parcela.Text = contaparcelada.nr_valor_parcela

            If (contaparcelada.id_situacao > 0) Then
                cbo_situacao.SelectedValue = contaparcelada.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = contaparcelada.id_modificador.ToString()
            lbl_dt_modificacao.Text = contaparcelada.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim contaparcelada As New ContaParcelada()


                contaparcelada.id_propriedade = txt_cd_propriedade.Text

                If Not (cbo_conta.SelectedValue.Trim().Equals(String.Empty)) Then
                    contaparcelada.id_conta = Convert.ToInt32(cbo_conta.SelectedValue)
                End If

                If Not (txt_valor_total.Text.Trim().Equals(String.Empty)) Then
                    contaparcelada.nr_valor_total = txt_valor_total.Text
                End If

                If Not (txt_nr_taxa.Text.Trim().Equals(String.Empty)) Then
                    contaparcelada.nr_taxa = txt_nr_taxa.Text
                End If

                contaparcelada.dt_inicio_desconto = txt_dt_incio_desconto.Text

                If Not (txt_qtd_parcela.Text.Trim.Equals(String.Empty)) Then
                    contaparcelada.nr_qtd_parcela = txt_qtd_parcela.Text
                End If

                If Not (txt_valor_parcela.Text.Trim().Equals(String.Empty)) Then
                    contaparcelada.nr_valor_parcela = txt_valor_parcela.Text
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    contaparcelada.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                contaparcelada.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_conta_parcelada") Is Nothing) Then

                        contaparcelada.id_conta_parcelada = Convert.ToInt32(ViewState.Item("id_conta_parcelada"))
                        contaparcelada.updateContaParcelada()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 33
                        usuariolog.nm_nr_processo = contaparcelada.id_propriedade.ToString
                        usuariolog.id_nr_processo = ViewState.Item("id_conta_parcelada").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_conta_parcelada") = contaparcelada.insertContaParcelada()

                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 33
                        usuariolog.nm_nr_processo = contaparcelada.id_propriedade.ToString
                        usuariolog.id_nr_processo = ViewState.Item("id_conta_parcelada").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")

                    End If

                    loadData()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_conta_parcelada.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_conta_parcelada.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub


    Protected Sub cmv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_propriedade.ServerValidate, cmv_propriedade.ServerValidate
        Try
            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = Trim(txt_cd_propriedade.Text)
            Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

            args.IsValid = dsPropriedade.Tables(0).Rows.Count > 0
            If Not args.IsValid Then
                messageControl.Alert("Propriedade não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString
                Me.lbl_nm_propriedade.Visible = True
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If


            If Not (customPage.getFilterValue("lupa_propriedade", "pessoa").Equals(String.Empty)) Then
                Me.lbl_produtor.Visible = True
                Me.lbl_nm_produtor.Visible = True
                Me.lbl_nm_produtor.Text = customPage.getFilterValue("lupa_propriedade", "pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "estabelecimento").Equals(String.Empty)) Then
                Me.lbl_estabelecimento.Visible = True
                Me.lbl_nm_estabelecimento.Visible = True
                Me.lbl_nm_estabelecimento.Text = customPage.getFilterValue("lupa_propriedade", "estabelecimento").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click

        carregarCamposPropriedade()
        
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_estabelecimento.Text = String.Empty
        lbl_nm_estabelecimento.Visible = False
        lbl_estabelecimento.Visible = False

        lbl_nm_produtor.Text = String.Empty
        lbl_nm_produtor.Visible = False
        lbl_produtor.Visible = False

        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
        hf_id_propriedade.Value = String.Empty

    End Sub

    Protected Sub CalculaParcela()
        Try
            Dim lvalor_total As Decimal
            Dim lvalor_parcela As Decimal
            Dim lqtd_parcela As Int32
            Dim ltaxa As Decimal
            Dim lerro As Boolean

            lerro = False
            If Trim(Me.txt_valor_total.Text) <> "" Then
                If Convert.ToDecimal(Me.txt_valor_total.Text) = 0 Then
                    lerro = True
                End If
            Else
                lerro = True
            End If

            If Trim(Me.txt_nr_taxa.Text) <> "" Then
                If Convert.ToDecimal(Me.txt_nr_taxa.Text) = 0 Then
                    lerro = True
                End If
            Else
                lerro = True
            End If

            If Trim(Me.txt_qtd_parcela.Text) <> "" Then
                If Convert.ToInt32(Me.txt_qtd_parcela.Text) = 0 Then
                    lerro = True
                End If
            Else
                lerro = True
            End If

            If lerro = False Then
                lvalor_total = Convert.ToDecimal(Me.txt_valor_total.Text)
                lqtd_parcela = Convert.ToInt32(Me.txt_qtd_parcela.Text)
                ltaxa = Convert.ToDecimal(Me.txt_nr_taxa.Text)
                ltaxa = ltaxa / 100
                lvalor_total = lvalor_total + (lvalor_total * ltaxa)
                lvalor_parcela = lvalor_total / lqtd_parcela
                Me.txt_valor_parcela.Text = Round(lvalor_parcela, 2)
            Else
                Me.txt_valor_parcela.Text = ""
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_qtd_parcela_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qtd_parcela.TextChanged
        CalculaParcela()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_conta_parcelada.aspx")

    End Sub
End Class
