Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_silo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_silo.aspx")
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

            Dim itens As New Item

            cbo_id_item_leite.DataSource = itens.getItensByFilters()
            cbo_id_item_leite.DataTextField = "nm_item"
            cbo_id_item_leite.DataValueField = "id_item"
            cbo_id_item_leite.DataBind()
            cbo_id_item_leite.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_silo") Is Nothing) Then
                ViewState.Item("id_silo") = Request("id_silo")
                lbl_cd_silo.Visible = True
                txt_cd_silo.Visible = True

                loadData()
            Else
                lbl_cd_silo.Visible = False
                txt_cd_silo.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_silo As Int32 = Convert.ToInt32(ViewState.Item("id_silo"))
            Dim silo As New Silo(id_silo)

            txt_cd_silo.Text = silo.id_silo

             txt_nm_silo.Text = silo.nm_silo

            If (silo.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = silo.id_estabelecimento.ToString()
            End If

            If (silo.id_item_leite > 0) Then
                cbo_id_item_leite.SelectedValue = silo.id_item_leite.ToString()
            End If

            If (silo.nr_silo > 0) Then
                txt_nr_silo.Text = silo.nr_silo.ToString()
            End If
            If (silo.nr_volume > 0) Then
                txt_nr_volume.Text = silo.nr_volume.ToString()
            End If

            If (silo.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = silo.id_estabelecimento.ToString()
            End If

            If (silo.id_situacao > 0) Then
                cbo_situacao.SelectedValue = silo.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = silo.id_modificador.ToString()
            lbl_dt_modificacao.Text = silo.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim silo As New Silo()


            silo.nm_silo = txt_nm_silo.Text

            If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                silo.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            End If

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                silo.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            If Not (cbo_id_item_leite.SelectedValue.Trim().Equals(String.Empty)) Then
                silo.id_item_leite = Convert.ToInt32(cbo_id_item_leite.SelectedValue)
            End If
            If Not (txt_nr_volume.Text.Trim().Equals(String.Empty)) Then
                silo.nr_volume = Convert.ToDouble(txt_nr_volume.Text)
            End If
            If Not (txt_nr_silo.Text.Trim().Equals(String.Empty)) Then
                silo.nr_silo = Convert.ToInt32(txt_nr_silo.Text)
            End If

            silo.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_silo") Is Nothing) Then

                    silo.id_silo = Convert.ToInt32(ViewState.Item("id_silo"))
                    silo.updateSilo()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 2
                    usuariolog.id_nr_processo = ViewState.Item("id_silo").ToString
                    usuariolog.nm_nr_processo = silo.nm_silo

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_silo") = silo.insertSilo()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 2
                    usuariolog.id_nr_processo = ViewState.Item("id_silo").ToString
                    usuariolog.nm_nr_processo = silo.nm_silo

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
        Response.Redirect("lst_silo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_silo.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub

    Protected Sub RequiredFieldValidator1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles RequiredFieldValidator1.DataBinding

    End Sub

    Protected Sub RequiredFieldValidator1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles RequiredFieldValidator1.Load
    End Sub




    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i - Rls 17
        Response.Redirect("frm_silo.aspx")
    End Sub
End Class
