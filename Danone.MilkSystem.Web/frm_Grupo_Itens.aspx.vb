Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_Grupo_Itens
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_itens.aspx")
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

            If Not (Request("id_grupo_itens") Is Nothing) Then
                ViewState.Item("id_grupo_itens") = Request("id_grupo_itens")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_grupo_itens As Int32 = Convert.ToInt32(ViewState.Item("id_grupo_itens"))
            Dim grupo_itens As New GrupoItens(id_grupo_itens)

            ' 19/01/2010 - Chamado 596 - i
            If Not (ViewState.Item("id_grupo_itens") Is Nothing) Then     ' Não permite alteração do Código do Grupo
                txt_cd_grupo_itens.Enabled = False
            Else
                txt_cd_grupo_itens.Enabled = True
            End If
            ' 19/01/2010 - Chamado 596 - f

            txt_cd_grupo_itens.Text = grupo_itens.cd_grupo_itens
            txt_nm_grupo_itens.Text = grupo_itens.nm_grupo_itens
           
            If (grupo_itens.id_situacao > 0) Then
                cbo_situacao.SelectedValue = grupo_itens.id_situacao.ToString()
                cbo_situacao.Enabled = True
                If grupo_itens.id_situacao = 2 Then 'se inativo
                    txt_cd_grupo_itens.Enabled = False
                    txt_nm_grupo_itens.Enabled = False
                End If
            End If


            lbl_modificador.Text = grupo_itens.nm_modificador.ToString()  ' 04/11/2009 - Adri
            lbl_dt_modificacao.Text = grupo_itens.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim grupo_itens As New GrupoItens()

                grupo_itens.cd_grupo_itens = txt_cd_grupo_itens.Text
                grupo_itens.nm_grupo_itens = txt_nm_grupo_itens.Text

                ' 04/11/2009 - Adri (padrão de update) - i
                'If Not (lbl_modificador.Text.Trim().Equals(String.Empty)) Then
                '    grupo_itens.id_modificador = Convert.ToInt32(lbl_modificador.Text)
                'End If

                'grupo_itens.dt_modificacao = lbl_dt_modificacao.Text
                grupo_itens.id_modificador = Session("id_login")
                ' 04/11/2009 - Adri - f

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    grupo_itens.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                If Not (ViewState.Item("id_grupo_itens") Is Nothing) Then
                    grupo_itens.id_grupo_itens = Convert.ToInt32(ViewState.Item("id_grupo_itens"))
                    grupo_itens.updategrupo_itens()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 91
                    usuariolog.id_nr_processo = ViewState.Item("id_grupo_itens")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_grupo_itens") = grupo_itens.insertgrupo_itens
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 91
                    usuariolog.id_nr_processo = ViewState.Item("id_grupo_itens")

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
        Response.Redirect("lst_grupo_itens.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_grupo_itens.aspx")
    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo_itens.aspx")  ' Adri
    End Sub

    Protected Sub cv_itens_desativados_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_itens_desativados.ServerValidate
        Try
            args.IsValid = True

            If Not ViewState.Item("id_grupo_itens") Is Nothing Then
                If Not ViewState.Item("id_grupo_itens").ToString.Equals(String.Empty) Then
                    'fran 16/03/2010 i chamado 688
                    If cbo_situacao.SelectedValue = "2" Then
                        'ao inativar um grupo de itens verificar se há itens ativos. Caso haja não deixar desativar.
                        Dim item As New Item
                        item.id_grupo_itens = Convert.ToInt32(ViewState.Item("id_grupo_itens").ToString)
                        item.id_situacao = 1
                        Dim dsitem As DataSet = item.getItensByGrupoItem
                        If dsitem.Tables(0).Rows.Count > 0 Then 'se tem itens ativos
                            args.IsValid = False
                            messageControl.Alert("Grupo de Itens não pode ser desativado pois possui itens ativos.")
                        Else
                            args.IsValid = True
                        End If
                        'fran 16/03/2010 f
                    End If
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
