Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_linha_pedagio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_linha_pedagio.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_linha") Is Nothing) Then
                ViewState.Item("id_linha") = Request("id_linha")

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim linha As New Linha(Convert.ToInt32(ViewState.Item("id_linha")))


            lbl_nm_rota.Text = linha.nm_linha
            If linha.id_situacao = 1 Then
                lbl_situacao_rota.Text = "ATIVA"
                btn_incluirpedagio.Enabled = True

            End If
            If linha.id_situacao = 2 Then
                lbl_situacao_rota.Text = "INATIVA"
                btn_incluirpedagio.Enabled = False
                grdPedagio.Columns(4).Visible = False 'coluna excluir
            End If
            txt_dt_inicio.Text = String.Empty
            txt_valor_pedagio.Text = String.Empty

            loadPedagio()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_linha.aspx?id_linha=" + ViewState.Item("id_linha").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_linha.aspx?id_linha=" + ViewState.Item("id_linha").ToString)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Protected Sub cv_pedagio_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedagio.ServerValidate

        Try
            Dim lmsg As String
            Dim linhapedagio As New LinhaPedagio

            args.IsValid = True

            linhapedagio.id_linha = Convert.ToInt32(ViewState.Item("id_linha"))
            linhapedagio.dt_inicio_validade = txt_dt_inicio.Text

            'Busca todos os pedagios cadastrados maiores que a data de valiodade a ser incluido
            If linhapedagio.getLinhaPedagioConsValidade.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "A data de validade informada deve ser MAIOR que a última validade de pedágio ativa."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub grdPedagio_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdPedagio.PageIndexChanging
        grdPedagio.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub grdPedagio_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdPedagio.RowCancelingEdit
        Try

            grdPedagio.EditIndex = -1
            loadData()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub grdPedagio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPedagio.RowCommand
        Select Case e.CommandName.Trim.ToString

            Case "delete"
                deleteLinhaPedagio(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Private Sub deleteLinhaPedagio(ByVal id_linhapedagio As Integer)

        Try

            Dim linhapedagio As New LinhaPedagio()
            linhapedagio.id_linha_pedagio = id_linhapedagio
            linhapedagio.id_modificador = Convert.ToInt32(Session("id_login"))
            linhapedagio.deleteLinhaPedagio()
            'fran 08/12/2020 i dango
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delete
            usuariolog.id_menu_item = 7
            usuariolog.ds_nm_processo = "Rota x Pedágio"
            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f dango

            messageControl.Alert("Registro desativado com sucesso!")
            loadPedagio()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdPedagio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPedagio.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

        Else
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim lbl_dt_validade As Label = CType(e.Row.FindControl("lbl_dt_validade"), Label)

                Dim linhapedagio As New LinhaPedagio

                linhapedagio.id_linha = Convert.ToInt32(ViewState.Item("id_linha"))
                linhapedagio.dt_validade = lbl_dt_validade.Text

                'buscar romaneios ja exportados cuja data de validade seja menor que a data de saida romaneio
                If linhapedagio.getLinhaPedagioConsRomaneioExportado.Tables(0).Rows.Count > 0 Then
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir o registro de pedágio. Romaneios já foram exportados utilizando esta data de validade."
                Else
                    'se data validade for maior, deixa excluir linha
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    btn_delete.ToolTip = String.Empty
                End If

            End If
        End If

    End Sub

    Protected Sub grdPedagio_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdPedagio.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdPedagio_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdPedagio.RowEditing
        Try

            grdPedagio.EditIndex = e.NewEditIndex
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdPedagio_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdPedagio.RowUpdating
        Dim row As GridViewRow = grdPedagio.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Sub loadPedagio()

        Try
            txt_dt_inicio.Text = String.Empty
            txt_valor_pedagio.Text = String.Empty

            'Verifica se já existe referencia comm calculo de poupanca para o perido de poupanca
            Dim linhapedagio As New LinhaPedagio
            linhapedagio.id_linha = Convert.ToInt32(ViewState.Item("id_linha").ToString)
            linhapedagio.id_situacao = 1

            Dim dslinhapedagio As DataSet = linhapedagio.getLinhaPedagioByFilters()

            If (dslinhapedagio.Tables(0).Rows.Count > 0) Then
                grdPedagio.Visible = True
                grdPedagio.DataSource = Helper.getDataView(dslinhapedagio.Tables(0), "")
                grdPedagio.DataBind()

            Else
                grdPedagio.Visible = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_incluirpedagio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirpedagio.Click
        If Page.IsValid Then

            Try

                Dim linhapedagio As New LinhaPedagio()

                'Parâmetros
                linhapedagio.id_linha = ViewState.Item("id_linha")
                linhapedagio.dt_validade = DateTime.Parse(txt_dt_inicio.Text).ToString("dd/MM/yyyy")
                linhapedagio.nr_valor_pedagio_eixo = txt_valor_pedagio.Text
                linhapedagio.id_modificador = Session("id_login")

                linhapedagio.insertLinhaPedagio()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 7
                usuariolog.ds_nm_processo = "Rota x Pedágio"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro inserido com sucesso.")


                loadPedagio()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

End Class
