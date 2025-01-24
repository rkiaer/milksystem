Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_usuario_grupo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_usuario.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_usuario") Is Nothing) Then
                ViewState.Item("id_usuario") = Request("id_usuario")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_usuario As Int32 = Convert.ToInt32(ViewState.Item("id_usuario").ToString)
            Dim usuario As New Usuario(id_usuario)

            lbl_login.Text = usuario.ds_login
            lbl_usuario.Text = usuario.nm_usuario

            Dim grupo As New GrupoCadastro
            grupo.id_situacao = 1 'apenas grupos ativos
            Dim dsGrupo As DataSet = grupo.getGrupoByFilters()

            lst_grupo.Items.Clear()
            lst_grupo.DataSource = Helper.getDataView(dsGrupo.Tables(0), "nm_grupo")
            lst_grupo.DataTextField = "nm_grupo"
            lst_grupo.DataValueField = "id_grupo"
            lst_grupo.DataBind()
            lst_grupo.SelectedIndex = 0

            Dim usuariogrupo As New UsuarioGrupo
            usuariogrupo.id_usuario = id_usuario

            Dim dsusuariogrupo As DataSet = usuariogrupo.getUSuarioGrupoByFilters()

            lst_grupo_usuario.DataSource = Helper.getDataView(dsusuariogrupo.Tables(0), "nm_grupo")
            lst_grupo_usuario.DataTextField = "nm_grupo"
            lst_grupo_usuario.DataValueField = "id_usuario_grupo"
            lst_grupo_usuario.DataBind()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)


    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)

    End Sub


    Protected Sub lst_grupo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_grupo.SelectedIndexChanged
    End Sub

    Protected Sub btn_adicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar.Click
        'lst_grupo_usuario.SelectedValue = lst_grupo.SelectedValue
        'lst_grupo_usuario.SelectedItem.Value()  ' id
        'lst_grupo_usuario.Items.Insert(lst_grupo.SelectedItem.Value, New ListItem("[Selecione]", String.Empty))

        If lst_grupo.SelectedValue <> "" Then

            ' Verifica se o item já foi selecionado
            For Each item As ListItem In lst_grupo_usuario.Items

                If lst_grupo.SelectedItem.Text = item.Text Then
                    Exit Sub
                End If

            Next

            Dim usuariogrupo As New UsuarioGrupo
            usuariogrupo.id_usuario = ViewState.Item("id_usuario")
            usuariogrupo.id_grupo = lst_grupo.SelectedItem.Value
            usuariogrupo.id_modificador = Session("id_login")
            usuariogrupo.insertUsuarioGrupo()

            'fran 08/12/2020 i dango
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 4 'inserir
            usuariolog.id_menu_item = 60
            usuariolog.id_nr_processo = usuariogrupo.id_usuario
            usuariolog.ds_nm_processo = String.Concat("Usuário x Grupo - (", usuariogrupo.id_grupo.ToString, ")")
            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f dango

            loadUsuarioGrupo()
            messageControl.Alert("Grupo adicionado com sucesso.")

        End If

    End Sub
    Protected Sub loadUsuarioGrupo()
        Try
            Dim usuariogrupo As New UsuarioGrupo
            usuariogrupo.id_usuario = ViewState.Item("id_usuario")

            Dim dsusuariogrupo As DataSet = usuariogrupo.getUSuarioGrupoByFilters()

            lst_grupo_usuario.Items.Clear()
            lst_grupo_usuario.DataSource = Helper.getDataView(dsusuariogrupo.Tables(0), "nm_grupo")
            lst_grupo_usuario.DataTextField = "nm_grupo"
            lst_grupo_usuario.DataValueField = "id_usuario_grupo"
            lst_grupo_usuario.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_retirar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_retirar.Click

        If lst_grupo_usuario.SelectedValue <> "" Then
            Dim usuariogrupo As New UsuarioGrupo
            usuariogrupo.id_usuario_grupo = lst_grupo_usuario.SelectedItem.Value
            usuariogrupo.deleteUsuarioGrupo()

            'fran 08/12/2020 i dango
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'deleção
            usuariolog.id_menu_item = 60
            usuariolog.ds_nm_processo = "Usuário x Grupo"
            usuariolog.id_nr_processo = ViewState.Item("id_usuario").ToString
            usuariolog.ds_nm_processo = String.Concat("Usuário x Grupo - (", lst_grupo_usuario.SelectedItem.Text, ")")
            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f dango

            loadUsuarioGrupo()
            messageControl.Alert("Grupo retirado com sucesso.")

        End If


    End Sub

 End Class
