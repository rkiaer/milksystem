Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_natureza_operacao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_natureza_operacao.aspx")
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

            Dim especie As New EspecieNotaFiscal
            especie.id_situacao = 1 'ativa
            cbo_id_especie_nf.DataSource = especie.getEspeciesNotasFiscaisByFilters()
            cbo_id_especie_nf.DataTextField = "nm_especie_nf"
            cbo_id_especie_nf.DataValueField = "id_especie_nf"
            cbo_id_especie_nf.DataBind()
            cbo_id_especie_nf.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim tributacao As New TributacaoNotaFiscal
            tributacao.id_situacao = 1 'ativa
            cbo_id_tributacao_icms.DataSource = tributacao.getTributacoesNotasByFilters()
            cbo_id_tributacao_icms.DataTextField = "nm_tributacao_nf"
            cbo_id_tributacao_icms.DataValueField = "id_tributacao_nf"
            cbo_id_tributacao_icms.DataBind()
            cbo_id_tributacao_icms.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_id_tributacao_ipi.DataSource = cbo_id_tributacao_icms.DataSource
            cbo_id_tributacao_ipi.DataTextField = "nm_tributacao_nf"
            cbo_id_tributacao_ipi.DataValueField = "id_tributacao_nf"
            cbo_id_tributacao_ipi.DataBind()
            cbo_id_tributacao_ipi.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_id_tributacao_pis.DataSource = cbo_id_tributacao_icms.DataSource
            cbo_id_tributacao_pis.DataTextField = "nm_tributacao_nf"
            cbo_id_tributacao_pis.DataValueField = "id_tributacao_nf"
            cbo_id_tributacao_pis.DataBind()
            cbo_id_tributacao_pis.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_id_tributacao_cofins.DataSource = cbo_id_tributacao_icms.DataSource
            cbo_id_tributacao_cofins.DataTextField = "nm_tributacao_nf"
            cbo_id_tributacao_cofins.DataValueField = "id_tributacao_nf"
            cbo_id_tributacao_cofins.DataBind()
            cbo_id_tributacao_cofins.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_natureza_operacao") Is Nothing) Then
                ViewState.Item("id_natureza_operacao") = Request("id_natureza_operacao")

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim id_natureza_operacao As Int32 = Convert.ToInt32(ViewState.Item("id_natureza_operacao"))
            Dim natoper As New NaturezaOperacao(id_natureza_operacao)

            txt_cd_natureza_operacao.Text = natoper.cd_natureza_operacao.ToString
            txt_cd_natureza_operacao.Enabled = False
            txt_nm_natureza_operacao.Text = natoper.nm_natureza_operacao

            txt_ds_tipo_especie.Text = natoper.ds_tipo_especie
            If (natoper.id_especie_nf > 0) Then
                cbo_id_especie_nf.SelectedValue = natoper.id_especie_nf
            End If

            If (natoper.id_tributacao_cofins > 0) Then
                cbo_id_tributacao_cofins.SelectedValue = natoper.id_tributacao_cofins
            End If
            If (natoper.id_tributacao_icms > 0) Then
                cbo_id_tributacao_icms.SelectedValue = natoper.id_tributacao_icms
            End If
            If (natoper.id_tributacao_ipi > 0) Then
                cbo_id_tributacao_ipi.SelectedValue = natoper.id_tributacao_ipi
            End If
            If (natoper.id_tributacao_pis > 0) Then
                cbo_id_tributacao_pis.SelectedValue = natoper.id_tributacao_pis
            End If

            If (natoper.nr_aliquota_cofins > 0) Then
                txt_nr_aliquota_cofins.Text = natoper.nr_aliquota_cofins
            End If
            'Adri 26/11/2008 - i
            'If (natoper.nr_conta_transitoria > 0) Then
            '    txt_nr_conta_transitoria.Text = Left(natoper.nr_conta_transitoria.ToString, 8) + "." + Right(natoper.nr_conta_transitoria.ToString, 8)
            'Else
            '    txt_nr_conta_transitoria.Text = ""
            'End If
            If Len(natoper.nr_conta_transitoria) > 0 Then
                txt_nr_conta_transitoria.Text = Left(natoper.nr_conta_transitoria.ToString, 8) + "." + Right(natoper.nr_conta_transitoria.ToString, 8)
            Else
                txt_nr_conta_transitoria.Text = ""
            End If
            'Adri 26/11/2008 - f
            If (natoper.nr_aliquota_icms > 0) Then
                txt_nr_aliquota_icms.Text = natoper.nr_aliquota_icms
            End If
            If (natoper.nr_aliquota_ipi > 0) Then
                txt_nr_aliquota_ipi.Text = natoper.nr_aliquota_ipi
            End If
            If (natoper.nr_aliquota_pis > 0) Then
                txt_nr_aliquota_pis.Text = natoper.nr_aliquota_pis
            End If

            If (natoper.id_situacao > 0) Then
                cbo_situacao.SelectedValue = natoper.id_situacao
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = natoper.id_modificador.ToString()
            lbl_dt_modificacao.Text = natoper.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid() Then
            Try

                Dim naturezaoper As New NaturezaOperacao()

                naturezaoper.cd_natureza_operacao = txt_cd_natureza_operacao.Text
                naturezaoper.nm_natureza_operacao = txt_nm_natureza_operacao.Text
                If Not (cbo_id_especie_nf.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_especie_nf = Convert.ToInt32(cbo_id_especie_nf.SelectedValue)
                End If
                naturezaoper.ds_tipo_especie = txt_ds_tipo_especie.Text
                If Not (txt_nr_aliquota_icms.Text.Trim.Equals(String.Empty)) Then
                    naturezaoper.nr_aliquota_icms = Convert.ToDecimal(txt_nr_aliquota_icms.Text)
                Else
                    naturezaoper.nr_aliquota_icms = 0
                End If

                If Not (txt_nr_aliquota_ipi.Text.Trim.Equals(String.Empty)) Then
                    naturezaoper.nr_aliquota_ipi = Convert.ToDecimal(txt_nr_aliquota_ipi.Text)
                Else
                    naturezaoper.nr_aliquota_ipi = 0
                End If

                If Not (txt_nr_aliquota_pis.Text.Trim.Equals(String.Empty)) Then
                    naturezaoper.nr_aliquota_pis = Convert.ToDecimal(txt_nr_aliquota_pis.Text)
                Else
                    naturezaoper.nr_aliquota_pis = 0
                End If
                If Not (txt_nr_aliquota_cofins.Text.Trim.Equals(String.Empty)) Then
                    naturezaoper.nr_aliquota_cofins = Convert.ToDecimal(txt_nr_aliquota_cofins.Text)
                Else
                    naturezaoper.nr_aliquota_cofins = 0
                End If
                If Not (cbo_id_tributacao_cofins.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_tributacao_cofins = Convert.ToInt32(cbo_id_tributacao_cofins.SelectedValue)
                Else
                    naturezaoper.id_tributacao_cofins = 0
                End If
                If Not (cbo_id_tributacao_icms.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_tributacao_icms = Convert.ToInt32(cbo_id_tributacao_icms.SelectedValue)
                Else
                    naturezaoper.id_tributacao_icms = 0
                End If
                If Not (cbo_id_tributacao_pis.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_tributacao_pis = Convert.ToInt32(cbo_id_tributacao_pis.SelectedValue)
                Else
                    naturezaoper.id_tributacao_pis = 0
                End If
                If Not (cbo_id_tributacao_ipi.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_tributacao_ipi = Convert.ToInt32(cbo_id_tributacao_ipi.SelectedValue)
                Else
                    naturezaoper.id_tributacao_ipi = 0
                End If
                'Fran 22/11/2008
                If Not (txt_nr_conta_transitoria.Text.Trim.Equals(String.Empty)) Then
                    'naturezaoper.nr_conta_transitoria = Convert.ToInt32(Replace(txt_nr_conta_transitoria.Text, ".", ""))
                    naturezaoper.nr_conta_transitoria = Replace(txt_nr_conta_transitoria.Text, ".", "")  'Adri 26/11/2008
                Else
                    'naturezaoper.nr_conta_transitoria = 0
                    naturezaoper.nr_conta_transitoria = ""   'Adri 26/11/2008
                End If


                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    naturezaoper.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                naturezaoper.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_natureza_operacao") Is Nothing) Then

                    naturezaoper.id_natureza_operacao = Convert.ToInt32(ViewState.Item("id_natureza_operacao"))
                    naturezaoper.updateNaturezaOperacao()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 10
                    usuariolog.id_nr_processo = ViewState.Item("id_natureza_operacao")
                    usuariolog.nm_nr_processo = naturezaoper.cd_natureza_operacao

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_natureza_operacao") = naturezaoper.insertNaturezaOperecao()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 10
                    usuariolog.id_nr_processo = ViewState.Item("id_natureza_operacao")
                    usuariolog.nm_nr_processo = naturezaoper.cd_natureza_operacao
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_natureza_operacao.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_natureza_operacao.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009
        Response.Redirect("frm_natureza_operacao.aspx")
    End Sub
End Class
