Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_cep
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_cep.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try


            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False


            If Not (Request("id_cep") Is Nothing) Then
                ViewState.Item("id_cep") = Request("id_cep")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim cep As New CEP(Convert.ToInt32(ViewState.Item("id_cep")))


            txt_cd_cep.Text = cep.cd_cep
            txt_cd_cep.Enabled = False

            If (cep.id_situacao > 0) Then
                cbo_situacao.SelectedValue = cep.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If (cep.id_cidade > 0) Then
                loadCidadesByEstado(cep.id_estado)
                cbo_estado.SelectedValue = cep.id_estado.ToString()
                cbo_cidade.SelectedValue = cep.id_cidade.ToString()
            End If
            cbo_estado.Enabled = False
            cbo_cidade.Enabled = False
            lk_concluir.Enabled = False
            lk_concluirFooter.Enabled = False

            Dim usuario As New Usuario(cep.id_modificador)

            lbl_modificador.Text = usuario.ds_login
            lbl_dt_modificacao.Text = DateTime.Parse(cep.dt_modificacao).ToString("dd/MM/yyyy HH:mm:ss")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim cep As New CEP()

                cep.id_estado = Convert.ToInt32(cbo_estado.SelectedValue)
                cep.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                cep.cd_cep = txt_cd_cep.Text

                cep.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                cep.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_cep") Is Nothing) Then
                    cep.id_cep = Convert.ToInt32(ViewState.Item("id_cep"))
                    cep.updateCEP()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 218
                    usuariolog.ds_nm_processo = "CEP"
                    usuariolog.id_nr_processo = ViewState.Item("id_cep").ToString
                    usuariolog.nm_nr_processo = cep.cd_cep.ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_cep") = cep.insertCEP()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 218
                    usuariolog.ds_nm_processo = "CEP"
                    usuariolog.id_nr_processo = ViewState.Item("id_cep").ToString
                    usuariolog.nm_nr_processo = cep.cd_cep.ToString

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
        Response.Redirect("lst_cep.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_cep.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_cep.aspx")

    End Sub

    Protected Sub cbo_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado.SelectedIndexChanged
        If Not (cbo_estado.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
        Else
            cbo_cidade.Items.Clear()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Enabled = False
        End If

    End Sub
    Private Sub loadCidadesByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade.DataSource = cidade.getCidadeByFilters()
            cbo_cidade.DataTextField = "nm_cidade"
            cbo_cidade.DataValueField = "id_cidade"
            cbo_cidade.DataBind()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_cep_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cep.ServerValidate
        Try
            Dim cep As New CEP()
            Dim lmsg As String = String.Empty
            Dim dscep As DataSet

            args.IsValid = True

            cep.cd_cep = Me.txt_cd_cep.Text.Trim
            cep.id_situacao = 1
            dscep = cep.getCEPByFilters
            If dscep.Tables(0).Rows.Count > 0 Then
                lmsg = "Código CEP já está cadastrado"
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
