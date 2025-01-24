Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_densidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_densidade.aspx")
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


            If Not (Request("id_densidade") Is Nothing) Then
                ViewState.Item("id_densidade") = Request("id_densidade")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim densidade As New Densidade(Convert.ToInt32(ViewState.Item("id_densidade")))


            txt_dt_referencia.Enabled = False
            txt_dt_referencia.Text = DateTime.Parse(densidade.dt_referencia).ToString("MM/yyyy")

            txt_nr_valor_densidade.Text = densidade.nr_valor_densidade


            If (densidade.id_situacao > 0) Then
                cbo_situacao.SelectedValue = densidade.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            Dim usuario As New Usuario(densidade.id_modificador)

            lbl_modificador.Text = usuario.ds_login
            lbl_dt_modificacao.Text = DateTime.Parse(densidade.dt_modificacao).ToString("dd/MM/yyyy HH:mm:ss")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim densidade As New Densidade()

                densidade.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)
                densidade.nr_valor_densidade = Convert.ToDecimal(txt_nr_valor_densidade.Text)

                densidade.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                densidade.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_densidade") Is Nothing) Then
                    densidade.id_densidade = Convert.ToInt32(ViewState.Item("id_densidade"))
                    densidade.updateDensidade()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 130
                    usuariolog.id_nr_processo = ViewState.Item("id_densidade").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_densidade") = densidade.insertDensidade()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 130
                    usuariolog.id_nr_processo = ViewState.Item("id_densidade").ToString

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
        Response.Redirect("lst_densidade.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_densidade.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_densidade.aspx")

    End Sub
End Class
