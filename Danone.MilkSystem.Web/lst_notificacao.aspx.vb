Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_notificacao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_tipo_notificacao") = cbo_tipo_notificacao.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        'Fran 26/11/2009 i chamado 518 Maracanau
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Fran 26/11/2009 f chamado 518 Maracanau
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_notificacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_notificacao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 14
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            'Fran 26/11/2009 i chamado 518 Maracanau
            'cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_situacao.SelectedValue = 1 'Ativo
            'Fran 26/11/2009 f chamado 518 Maracanau

            Dim tiponotificacao As New TipoNotificacao

            cbo_tipo_notificacao.DataSource = tiponotificacao.getTiposNotificacaoByFilters()
            cbo_tipo_notificacao.DataTextField = "nm_tipo_notificacao"
            cbo_tipo_notificacao.DataValueField = "id_tipo_notificacao"
            cbo_tipo_notificacao.DataBind()
            cbo_tipo_notificacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'Fran 26/11/2009 i chamado 518 Maracanau
            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 26/11/2009 f chamado 520 Maracanau

            ViewState.Item("sortExpression") = "nm_tipo_notificacao asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("notificacao", cbo_tipo_notificacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tipo_notificacao") = customPage.getFilterValue("notificacao", cbo_tipo_notificacao.ID)
            cbo_tipo_notificacao.SelectedValue = ViewState.Item("id_tipo_notificacao")
        Else
            ViewState.Item("id_tipo_notificacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("notificacao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("notificacao", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        'Fran 26/11/2009 i chamado 518 Maracanau
        If Not (customPage.getFilterValue("notificacao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("notificacao", cbo_estabelecimento.ID)
            cbo_situacao.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        'Fran 26/11/2009 f chamado 518 Maracanau


        If Not (customPage.getFilterValue("notificacao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("notificacao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("notificacao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim notificacao As New Notificacao

            If Not ViewState.Item("id_tipo_notificacao").ToString.Equals(String.Empty) Then
                notificacao.id_tipo_notificacao = Convert.ToInt32(ViewState.Item("id_tipo_notificacao").ToString())
            End If
            If Not ViewState.Item("id_situacao").ToString.Equals(String.Empty) Then
                notificacao.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If
            'Fran 26/11/2009 i chamado 518 Maracanau
            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                notificacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            'Fran 26/11/2009 f chamado 518 Maracanau
            Dim dsnotificacao As DataSet = notificacao.getNotificacoesByFilters()


            If (dsnotificacao.Tables(0).Rows.Count > 0) Then
                Dim ds As DataSet = dsnotificacao
                Dim row As DataRow
                Dim linha As Integer
                Dim lcont As Integer
                Dim lst_email_para As String
                Dim lst_email_copia As String
                Dim idtiponotificacaoant As Int32
                Dim idestabelatual As Int32 'maracanau chamado 518
                Dim idestabelant As Int32 'maracanau chamado 518
                linha = 0
                lcont = 0
                lst_email_copia = String.Empty
                lst_email_para = String.Empty
                dsnotificacao.Tables(0).Columns.Add("ds_email_para")
                dsnotificacao.Tables(0).Columns.Add("ds_email_copia")
                For Each row In ds.Tables(0).Rows 'Varre o data set auxiliar agrupando por tipo de notificacao
                    'se o tipo de notificacao mudou nesta linha
                    'maracanau chamado 518 i
                    If IsDBNull(row.Item("id_estabelecimento").ToString) Then
                        idestabelatual = 0
                    Else
                        If row.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                            idestabelatual = 0
                        Else
                            idestabelatual = CInt(row.Item("id_estabelecimento"))
                        End If
                    End If
                    'If row.Item("id_tipo_notificacao") <> idtiponotificacaoant Then
                    If row.Item("id_tipo_notificacao") <> idtiponotificacaoant Or idestabelatual <> idestabelant Then
                        'maracanau chamado 518 f
                        If Right(lst_email_para, 2) = ", " Then 'se não é a primeira vez, atribui valores do para e da copia para uma unica linha do dataset
                            lst_email_para = Mid(lst_email_para, 1, Len(lst_email_para) - 2)
                            If Not lst_email_copia.Trim.Equals(String.Empty) Then
                                lst_email_copia = Mid(lst_email_copia, 1, Len(lst_email_copia) - 2)
                            End If

                            dsnotificacao.Tables(0).Rows.Item(linha).Item("ds_email_para") = lst_email_para
                            dsnotificacao.Tables(0).Rows.Item(linha).Item("ds_email_copia") = lst_email_copia
                            linha = lcont
                        End If
                        idtiponotificacaoant = row.Item("id_tipo_notificacao")
                        idestabelant = idestabelatual
                        If row.Item("st_para_copia") = "P" Then
                            lst_email_para = row.Item("ds_email").ToString & ", "
                            lst_email_copia = String.Empty
                        Else
                            lst_email_copia = row.Item("ds_email").ToString & ", "
                            lst_email_para = String.Empty
                        End If
                    Else
                        If row.Item("st_para_copia") = "P" Then
                            lst_email_para = lst_email_para & row.Item("ds_email").ToString & ", "
                        Else
                            lst_email_copia = lst_email_copia & row.Item("ds_email").ToString & ", "
                        End If

                        dsnotificacao.Tables(0).Rows.Item(lcont).Delete()
                    End If

                    lcont = lcont + 1
                Next
                If Right(lst_email_para, 2) = ", " Then 'se não é a primeira vez, atribui valores do para e da copia para uma unica linha do dataset
                    lst_email_para = Mid(lst_email_para, 1, Len(lst_email_para) - 2)
                    If Not lst_email_copia.Trim.Equals(String.Empty) Then
                        lst_email_copia = Mid(lst_email_copia, 1, Len(lst_email_copia) - 2)
                    End If

                    dsnotificacao.Tables(0).Rows.Item(linha).Item("ds_email_para") = lst_email_para
                    dsnotificacao.Tables(0).Rows.Item(linha).Item("ds_email_copia") = lst_email_copia
                    linha = lcont
                End If

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsnotificacao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        'fran maracanau chamdo 518
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                Dim btneditar As ImageButton = CType(e.Row.FindControl("img_editar"), ImageButton)
                btneditar.CommandArgument = e.Row.RowIndex.ToString

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
        'fran maracanau f chamdo 518
    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nm_tipo_notificacao"
                If (ViewState.Item("sortExpression")) = "nm_tipo_notificacao asc" Then
                    ViewState.Item("sortExpression") = "nm_tipo_notificacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tipo_notificacao asc"
                End If




        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("notificacao", cbo_tipo_notificacao.ID, ViewState.Item("id_tipo_notificacao").ToString)
            customPage.setFilter("notificacao", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            'Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("notificacao", "PageIndex", gridResults.PageIndex.ToString())
            'Fran 26/11/2009 i chamado 518 Maracanau
            customPage.setFilter("notificacao", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            'Fran 26/11/2009 f chamado 518 Maracanau
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Dim id_tipo_notificacao As Label = CType(gridResults.Rows.Item(CInt(e.CommandArgument.ToString)).FindControl("lbl_id_tipo_notificacao"), Label)
                Dim id_estabelecimento As Label = CType(gridResults.Rows.Item(CInt(e.CommandArgument.ToString)).FindControl("lbl_id_estabelecimento"), Label)

                'Response.Redirect("frm_notificacao.aspx?id_tipo_notificacao=" + e.CommandArgument.ToString())
                Response.Redirect("frm_notificacao.aspx?id_tipo_notificacao=" + id_tipo_notificacao.Text + "&id_estabelecimento=" + id_estabelecimento.Text)

            Case "delete"
                deleteNotificacao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteNotificacao(ByVal id_index_row As Integer)

        Try
            'fran maracanau chamado 318 i
            Dim id_tipo_notificacao As Label = CType(gridResults.Rows.Item(id_index_row).FindControl("lbl_id_tipo_notificacao"), Label)
            Dim id_estabelecimento As Label = CType(gridResults.Rows.Item(id_index_row).FindControl("lbl_id_estabelecimento"), Label)
            Dim notificacao As New Notificacao()
            notificacao.id_tipo_notificacao = Convert.ToInt32(id_tipo_notificacao.Text)
            If Not id_estabelecimento.Text.ToString.Equals(String.Empty) Then
                notificacao.id_estabelecimento = Convert.ToInt32(id_estabelecimento.Text)
            End If
            'fran maracanau f
            notificacao.id_modificador = Convert.ToInt32(Session("id_login"))
            notificacao.deleteNotificacoes()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 14
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_notificacao.aspx")
    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
End Class
