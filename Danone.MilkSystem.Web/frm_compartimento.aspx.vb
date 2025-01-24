Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_compartimento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_compartimento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        'Fran 16/02/2009 i rls16
        'With bt_lupa_veiculo
        '    .Attributes.Add("onclick", "javascript:ShowDialog()")
        '    .ToolTip = "Filtrar Veículos"
        '    '.Style("cursor") = "hand"
        'End With
        'Fran 16/12/2009 f
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

            If Not (customPage.getFilterValue("compartimento", "ds_placa").Equals(String.Empty)) Then
                ViewState.Item("ds_placa") = customPage.getFilterValue("compartimento", "ds_placa")
                txt_placa.Text = ViewState.Item("ds_placa").ToString()
            Else
                ViewState.Item("ds_placa") = String.Empty
            End If


            If Not (Request("id_compartimento") Is Nothing) Then
                ViewState.Item("id_compartimento") = Request("id_compartimento")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_compartimento As Int32 = Convert.ToInt32(ViewState.Item("id_compartimento"))
            Dim compartimento As New Compartimento(id_compartimento)

            tr_CodigoCompartimento.Visible = True
            txt_nr_compartimento.Text = compartimento.nr_compartimento.ToString
            txt_nr_compartimento.Enabled = False

            txt_placa.Text = compartimento.ds_placa
            txt_nm_compartimento.Text = compartimento.nm_compartimento
            txt_volume.Text = compartimento.nr_volume


            If (compartimento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = compartimento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = compartimento.id_modificador.ToString()
            lbl_dt_modificacao.Text = compartimento.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid = True Then
            Try

                Dim compartimento As New Compartimento()


                compartimento.ds_placa = txt_placa.Text
                compartimento.nm_compartimento = txt_nm_compartimento.Text

                If Not (txt_nr_compartimento.Text.Trim.Equals(String.Empty)) Then
                    compartimento.nr_compartimento = Convert.ToInt32(txt_nr_compartimento.Text)
                Else
                    compartimento.nr_compartimento = 0
                End If

                If Not (txt_volume.Text.Trim().Equals(String.Empty)) Then
                    compartimento.nr_volume = Convert.ToDecimal(txt_volume.Text)
                End If

                Dim veiculo As New Veiculo
                veiculo.ds_placa = compartimento.ds_placa

                veiculo.getVeiculoByPlaca()

                compartimento.id_veiculo = veiculo.id_veiculo


                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    compartimento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                compartimento.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_compartimento") Is Nothing) Then

                        compartimento.id_compartimento = Convert.ToInt32(ViewState.Item("id_compartimento"))
                        compartimento.updateCompartimento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteração]
                        usuariolog.id_menu_item = 8
                        usuariolog.ds_nm_processo = "Veículo - Compartimento"
                        usuariolog.nm_nr_processo = String.Concat(compartimento.ds_placa, " - ", compartimento.nm_compartimento)
                        usuariolog.id_nr_processo = ViewState.Item("id_compartimento").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango
                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_compartimento") = compartimento.insertCompartimento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_menu_item = 8
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.ds_nm_processo = "Veículo - Compartimento"
                        usuariolog.nm_nr_processo = String.Concat(compartimento.ds_placa, " - ", compartimento.nm_compartimento)
                        usuariolog.id_nr_processo = ViewState.Item("id_compartimento").ToString

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
        Response.Redirect("lst_compartimento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_compartimento.aspx")
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

    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_placa.TextChanged

    End Sub


    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa.ServerValidate, cmv_placa.ServerValidate
        
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_volume_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_volume.TextChanged

    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click
        Me.txt_placa.Text = ""
        carregarCamposVeiculo()
    End Sub
    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_compartimento.aspx")
    End Sub
End Class
