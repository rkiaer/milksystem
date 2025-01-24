Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_linha
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_linha.aspx")
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
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()

            If Not (Request("id_linha") Is Nothing) Then
                ViewState.Item("id_linha") = Request("id_linha")
                lbl_cd_linha.Visible = True
                txt_cd_linha.Visible = True

                loadData()
            Else
                lbl_cd_linha.Visible = False
                txt_cd_linha.Visible = False
                lk_linha_detalhe.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            lk_linha_pedagio.Enabled = True

            Dim id_linha As Int32 = Convert.ToInt32(ViewState.Item("id_linha"))
            Dim linha As New Linha(id_linha)

            txt_cd_linha.Text = linha.id_linha

            txt_nm_linha.Text = linha.nm_linha

            If (linha.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = linha.id_estabelecimento.ToString()
                cbo_estabelecimento.Enabled = False
            End If

            If (linha.id_situacao > 0) Then
                cbo_situacao.SelectedValue = linha.id_situacao.ToString()
            End If

            cbo_periodicidade_coleta.SelectedValue = linha.st_periodicidade_coleta

            cbo_rota_transbordo.SelectedValue = linha.st_rota_transbordo  ' 12/09/2016 - Transit Point

            cbo_transit_point.SelectedValue = linha.st_rota_transit_point  ' 12/2016 - Transit Point

            cbo_transvase.SelectedValue = linha.st_rota_transvase

            'fran 07/2017 i
            Dim linhapedagio As New LinhaPedagio
            Dim dspedagio As DataSet
            linhapedagio.id_linha = Convert.ToInt32(ViewState.Item("id_linha").ToString)
            linhapedagio.id_situacao = 1
            dspedagio = linhapedagio.getLinhaPedagioByFilters
            If dspedagio.Tables(0).Rows.Count > 0 Then
                lbl_valor_pedagio.Text = String.Concat(dspedagio.Tables(0).Rows(0).Item("nr_valor_pedagio_eixo").ToString, " ('Válido a partir de ", dspedagio.Tables(0).Rows(0).Item("dt_validade").ToString, "')")
            Else
                lbl_valor_pedagio.Text = String.Empty
            End If
            'fran 07/2017 f

            lbl_modificador.Text = linha.id_modificador.ToString()
            lbl_dt_modificacao.Text = linha.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim linha As New Linha()


            'linha.nm_linha = txt_nm_linha.Text

            'If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
            '    linha.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If

            'If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
            '    linha.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            'End If

            linha.st_periodicidade_coleta = cbo_periodicidade_coleta.SelectedValue
            linha.st_rota_transbordo = cbo_rota_transbordo.SelectedValue  ' 12/09/2016 - Transit Point
            linha.st_rota_transit_point = cbo_transit_point.SelectedValue  ' 12/2016 - Transit Point
            linha.st_rota_transvase = cbo_transvase.SelectedValue

            linha.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_linha") Is Nothing) Then

                    linha.id_linha = Convert.ToInt32(ViewState.Item("id_linha"))
                    linha.updateLinha()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 7
                    usuariolog.id_nr_processo = ViewState.Item("id_linha")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_linha") = linha.insertLinha()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 7
                    usuariolog.id_nr_processo = ViewState.Item("id_linha")

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
        Response.Redirect("lst_linha.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_linha.aspx")
    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub
    Protected Sub lnk_detalhe_linha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_linha_detalhe.Click
        Response.Redirect("lst_linha_detalhe.aspx?id_linha=" + ViewState.Item("id_linha"))
    End Sub
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i
        Response.Redirect("frm_linha.aspx")
    End Sub

    Protected Sub lk_linha_pedagio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_linha_pedagio.Click
        Response.Redirect("frm_linha_pedagio.aspx?id_linha=" + ViewState.Item("id_linha").ToString)

    End Sub
End Class
