Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_tipo_equipamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo.aspx")
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

            If Not (Request("id_tipo_equipamento") Is Nothing) Then

                ViewState.Item("id_tipo_equipamento") = Request("id_tipo_equipamento")
                loadData()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try


            Dim id_tipo_equipamento As Int32 = Convert.ToInt32(ViewState.Item("id_tipo_equipamento"))
            Dim tipoequipamento As New TipoEquipamento(id_tipo_equipamento)

            txt_cd_tipo_equipamento.Text = tipoequipamento.cd_tipo_equipamento
            txt_nm_tipo_equipamento.Text = tipoequipamento.nm_tipo_equipamento

            'fran 07/2017 i 
            txt_nr_eixo.Text = tipoequipamento.nr_eixo.ToString
            txt_nr_custo_fixo_km_minima.Text = tipoequipamento.nr_custo_fixo_km_min_t2.ToString
            'fran 07/2017 f 

            If (tipoequipamento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = tipoequipamento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = tipoequipamento.id_modificador.ToString()
            lbl_dt_modificacao.Text = tipoequipamento.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim tipoequipamento As New TipoEquipamento

            tipoequipamento.nm_tipo_equipamento = txt_nm_tipo_equipamento.Text
            tipoequipamento.cd_tipo_equipamento = txt_cd_tipo_equipamento.Text

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                tipoequipamento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            tipoequipamento.id_modificador = Session("id_login")
            'fran 07/2017 i 
            tipoequipamento.nr_eixo = txt_nr_eixo.Text
            tipoequipamento.nr_custo_fixo_km_min_t2 = txt_nr_custo_fixo_km_minima.Text
            'fran 07/2017 f

            If Page.IsValid Then
                If Not (ViewState.Item("id_tipo_equipamento") Is Nothing) Then

                    tipoequipamento.id_tipo_equipamento = Convert.ToInt32(ViewState.Item("id_tipo_equipamento"))
                    tipoequipamento.updateTipoEquipamento()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alterar
                    usuariolog.id_menu_item = 86
                    usuariolog.id_nr_processo = ViewState.Item("id_tipo_equipamento").ToString
                    usuariolog.nm_nr_processo = tipoequipamento.cd_tipo_equipamento

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_tipo_equipamento") = tipoequipamento.insertTipoEquipamento()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 86
                    usuariolog.id_nr_processo = ViewState.Item("id_tipo_equipamento").ToString
                    usuariolog.nm_nr_processo = tipoequipamento.cd_tipo_equipamento

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
        Response.Redirect("lst_tipo_equipamento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_tipo_equipamento.aspx")
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
        Response.Redirect("frm_tipo_equipamento.aspx")
    End Sub


End Class
