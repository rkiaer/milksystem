Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.IO

Partial Class lst_nota_fiscal_mensagem
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ' ViewState.Item("id_estado") = cbo_estado.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_nota_fiscal_mensagem.aspx?st_incluirlog=N")
        

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_nota_fiscal_mensagem.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 66
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estado As New Estado

            'cbo_estado.DataSource = estado.getEstadosByFilters()
            'cbo_estado.DataTextField = "nm_estado"
            'cbo_estado.DataValueField = "id_estado"
            'cbo_estado.DataBind()
            'cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))


            
            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

       
        If Not (customPage.getFilterValue("NFMsg", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("NFMsg", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        

        If Not (customPage.getFilterValue("NFMsg", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("NFMsg", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("NFMsg")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim notafiscal_mensagem As New NotaFiscalMensagem


            notafiscal_mensagem.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsnotafiscalmensagem As DataSet = notafiscal_mensagem.getNotaFiscalMensagemByFilters()

            If (dsnotafiscalmensagem.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsnotafiscalmensagem.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            


            Case "ds_mensagem"
                If (ViewState.Item("sortExpression")) = "ds_mensagem asc" Then
                    ViewState.Item("sortExpression") = "ds_mensagem desc"
                Else
                    ViewState.Item("sortExpression") = "ds_mensagem asc"
                End If

            Case "st_incentivo_fiscal_21"
                If (ViewState.Item("sortExpression")) = "st_incentivo_fiscal_21 asc" Then
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_21 desc"
                Else
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_21 asc"
                End If

                ' 03/06/2009 - Chamado 277 - i
            Case "st_incentivo_fiscal_24"
                If (ViewState.Item("sortExpression")) = "st_incentivo_fiscal_24 asc" Then
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_24 desc"
                Else
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_24 asc"
                End If
                ' 03/06/2009 - Chamado 277 - f

            Case "st_incentivo_fiscal_25"
                If (ViewState.Item("sortExpression")) = "st_incentivo_fiscal_25 asc" Then
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_25 desc"
                Else
                    ViewState.Item("sortExpression") = "st_incentivo_fiscal_25 asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            'customPage.setFilter("Nota", cbo_estado.ID, ViewState.Item("id_estado").ToString)
            customPage.setFilter("NFMsg", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("NFMsg", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_nota_fiscal_mensagem.aspx?id_nota_fiscal_mensagem=" + e.CommandArgument.ToString())

            Case "delete"
                deletenotafiscal_mensagem(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletenotafiscal_mensagem(ByVal id_nota_fiscal_mensagem As Integer)

        Try

            Dim notafiscal_mensagem As New NotaFiscalMensagem()
            notafiscal_mensagem.id_nota_fiscal_mensagem = id_nota_fiscal_mensagem
            notafiscal_mensagem.id_modificador = Convert.ToInt32(Session("id_login"))
            notafiscal_mensagem.deleteNotaFiscalMensagem()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 66
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
        Response.Redirect("frm_nota_fiscal_mensagem.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    

    Protected Sub cbo_situacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_situacao.SelectedIndexChanged

    End Sub
    
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub
    
    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub
End Class
