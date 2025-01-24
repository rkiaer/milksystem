Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_Grupo_pool_compras
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_pool_compras.aspx")
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

            If Not (Request("id_grupo_pool_compras") Is Nothing) Then
                ViewState.Item("id_grupo_pool_compras") = Request("id_grupo_pool_compras")
                lk_propriedade.Enabled = True  ' Adri 04/11/2009
                loadData()
            Else
                lk_propriedade.Enabled = False  ' Adri 04/11/2009
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_grupo_pool_compras As Int32 = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))
            Dim grupo_pool_compras As New GrupoPoolCompras(id_grupo_pool_compras)

            ' 19/01/2010 - Chamado 600 - i
            If Not (ViewState.Item("id_grupo_pool_compras") Is Nothing) Then     ' Não permite alteração do Código do Grupo
                txt_cd_grupo_pool_compras.Enabled = False
            Else
                txt_cd_grupo_pool_compras.Enabled = True
            End If
            ' 19/01/2010 - Chamado 600 - f


            txt_cd_grupo_pool_compras.Text = grupo_pool_compras.cd_grupo_pool_compras
            txt_nm_grupo_pool_compras.Text = grupo_pool_compras.nm_grupo_pool_compras

            If (grupo_pool_compras.id_situacao > 0) Then
                cbo_situacao.SelectedValue = grupo_pool_compras.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = grupo_pool_compras.nm_modificador.ToString()  ' 04/11/2009 - Adri
            lbl_dt_modificacao.Text = grupo_pool_compras.dt_modificacao.ToString()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim grupo_pool_compras As New GrupoPoolCompras()

            grupo_pool_compras.cd_grupo_pool_compras = txt_cd_grupo_pool_compras.Text
            grupo_pool_compras.nm_grupo_pool_compras = txt_nm_grupo_pool_compras.Text

            ' 04/11/2009 - Adri (padrão de update) - i
            'If Not (lbl_modificador.Text.Trim().Equals(String.Empty)) Then
            '    grupo_pool_compras.id_modificador = Convert.ToInt32(lbl_modificador.Text)
            'End If

            'grupo_pool_compras.dt_modificacao = lbl_dt_modificacao.Text
            grupo_pool_compras.id_modificador = Session("id_login")
            ' 04/11/2009 - Adri - f

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                grupo_pool_compras.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            If Not (ViewState.Item("id_grupo_pool_compras") Is Nothing) Then
                grupo_pool_compras.id_grupo_pool_compras = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))
                grupo_pool_compras.updategrupo_pool_compras()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 99
                usuariolog.id_nr_processo = ViewState.Item("id_grupo_pool_compras")

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")
            Else
                ViewState.Item("id_grupo_pool_compras") = grupo_pool_compras.insertgrupo_pool_compras
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 99
                usuariolog.id_nr_processo = ViewState.Item("id_grupo_pool_compras")

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro inserido com sucesso.")
                lk_propriedade.Enabled = True  ' Adri 04/11/2009

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_grupo_pool_compras.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_grupo_pool_compras.aspx")
    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo_pool_compras.aspx")  ' Adri
    End Sub

    Protected Sub lk_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_propriedade.Click
        Response.Redirect("frm_grupo_pool_compras_propriedade.aspx?id_grupo_pool_compras=" & ViewState.Item("id_grupo_pool_compras").ToString)  ' 04/11/2009 Adri
    End Sub
End Class
