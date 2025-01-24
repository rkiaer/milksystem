Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_resfriamento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_resfriamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_resfriamento") Is Nothing) Then
                ViewState.Item("id_resfriamento") = Request("id_resfriamento")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim resfriamento As New Resfriamento(Convert.ToInt32(ViewState.Item("id_resfriamento")))


            txt_dt_referencia.Enabled = False
            txt_dt_referencia.Text = DateTime.Parse(resfriamento.dt_referencia).ToString("MM/yyyy")

            txt_valor.Text = resfriamento.nr_valor

            If (resfriamento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = resfriamento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If (resfriamento.id_estabelecimento > 0) Then
                Me.cbo_estabelecimento.SelectedValue = resfriamento.id_estabelecimento.ToString
                Me.cbo_estabelecimento.Enabled = False
                loadCombosbyEstabelecimento(CInt(resfriamento.id_estabelecimento.ToString))
                cbo_transit_point_unidade.SelectedValue = resfriamento.id_transit_point_unidade.ToString
                cbo_transit_point_unidade.Enabled = False
            End If

            Dim usuario As New Usuario(resfriamento.id_modificador)

            lbl_modificador.Text = usuario.nm_usuario
            lbl_dt_modificacao.Text = DateTime.Parse(resfriamento.dt_modificacao).ToString("dd/MM/yyyy HH:mm:ss")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim resfriamento As New Resfriamento

                resfriamento.id_estabelecimento = cbo_estabelecimento.SelectedValue
                resfriamento.id_transit_point_unidade = Convert.ToInt32(cbo_transit_point_unidade.SelectedValue)
                resfriamento.id_modificador = Session("id_login")
                resfriamento.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)
                resfriamento.nr_valor = CDec(txt_valor.Text)
                resfriamento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)

                If Not (ViewState.Item("id_resfriamento") Is Nothing) Then
                    resfriamento.id_resfriamento = Convert.ToInt32(ViewState.Item("id_resfriamento"))
                    resfriamento.updateResfriamento()

                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 265
                    usuariolog.id_nr_processo = ViewState.Item("id_resfriamento").ToString

                    usuariolog.insertUsuarioLog()

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_resfriamento") = resfriamento.insertResfriamento()

                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 265
                    usuariolog.id_nr_processo = ViewState.Item("id_resfriamento").ToString

                    usuariolog.insertUsuarioLog()

                    messageControl.Alert("Registro inserido com sucesso.")
                End If
                loadData()



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_resfriamento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_resfriamento.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            loadCombosbyEstabelecimento(cbo_estabelecimento.SelectedValue)
        Else
            cbo_transit_point_unidade.Items.Clear()
            cbo_transit_point_unidade.Enabled = False
        End If
    End Sub
    Private Sub loadCombosbyEstabelecimento(ByVal id_estabelecimento As Int32)

        Try

            cbo_transit_point_unidade.Enabled = True

            Dim transit As New TransitPointUnidade
            transit.id_estabelecimento = id_estabelecimento
            transit.id_situacao = 1 'ativo

            cbo_transit_point_unidade.DataSource = transit.getTransitPointUnidadeByFilters()
            cbo_transit_point_unidade.DataTextField = "ds_transit_point_unidade"
            cbo_transit_point_unidade.DataValueField = "id_transit_point_unidade"
            cbo_transit_point_unidade.DataBind()
            cbo_transit_point_unidade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_transit_point_unidade.SelectedValue = 0

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_resfriamento.aspx")

    End Sub
End Class

