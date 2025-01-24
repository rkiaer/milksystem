Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_calculo_juros
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(txt_dt_referencia.Text).ToString("MM/yyyy"))
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        ' ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_calculo_juros.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_calculo_juros.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 216
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try



            ViewState.Item("sortExpression") = "dt_referencia desc"

            Dim calcjuros As New CalculoJuros
            ViewState.Item("maior_referencia") = calcjuros.getCalculoJurosMaiorReferencia
            If CDate(ViewState.Item("maior_referencia")) = CDate("01/01/1900") Then
                ViewState.Item("maior_referencia") = String.Empty
            End If
            If Not ViewState.Item("maior_referencia").ToString.Equals(String.Empty) Then
                ViewState.Item("maior_referencia") = DateTime.Parse(ViewState.Item("maior_referencia")).ToString("dd/MM/yyyy")
                txt_novo_referencia.Text = DateTime.Parse(DateAdd(DateInterval.Month, 1, CDate(ViewState.Item("maior_referencia")))).ToString("MM/yyyy")
            Else
                ViewState.Item("maior_referencia") = String.Empty
                txt_novo_referencia.Text = DateTime.Now.ToString("MM/yyyy")
            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean

    '    If Not (customPage.getFilterValue("indicadorpreco", cbo_indicador_tipo.ID).Equals(String.Empty)) AndAlso Not (customPage.getFilterValue("contrato", cbo_indicador_tipo.ID).Equals("0")) Then
    '        hasFilters = True
    '        ViewState.Item("id_indicador_tipo") = customPage.getFilterValue("indicadorpreco", cbo_indicador_tipo.ID)
    '        cbo_indicador_tipo.SelectedValue = ViewState.Item("id_indicador_tipo").ToString()
    '    Else
    '        ViewState.Item("id_indicador_tipo") = 0
    '    End If

    '    If Not (customPage.getFilterValue("indicadorpreco", txt_dt_referencia.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_referencia") = customPage.getFilterValue("indicadorpreco", txt_dt_referencia.ID)
    '        txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
    '    Else
    '        ViewState.Item("dt_referencia") = String.Empty
    '    End If


    '    'If Not (customPage.getFilterValue("indicadorpreco", cbo_situacao.ID).Equals("0")) Or Not (customPage.getFilterValue("indicadorpreco", cbo_situacao.ID).Equals("")) Then
    '    '    ViewState.Item("id_situacao") = 0
    '    '    cbo_situacao.SelectedValue = 0
    '    '    hasFilters = True
    '    'Else
    '    '    ViewState.Item("id_situacao") = customPage.getFilterValue("indicadorpreco", cbo_situacao.ID)
    '    '    If ViewState.Item("id_situacao").ToString.Equals("2") Then
    '    '        hasFilters = True

    '    '    End If
    '    'End If

    '    If Not (customPage.getFilterValue("indicadorpreco", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("indicadorpreco", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("indicadorpreco")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim calculojuros As New CalculoJuros()

            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                calculojuros.dt_referencia = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
            End If
            calculojuros.id_situacao = 1
            Dim dscalculojuros As DataSet = calculojuros.getCalculoJurosByFilters()

            If (dscalculojuros.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscalculojuros.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_referencia"
                If ViewState.Item("sortExpression") = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

            Case "nr_valor"
                If ViewState.Item("sortExpression") = "nr_valor asc" Then
                    ViewState.Item("sortExpression") = "nr_valor desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor asc"
                End If


        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()


            Case "delete"

                deleteCalculoJuros(Convert.ToInt32(e.CommandArgument.ToString))

        End Select

    End Sub

    Private Sub deleteCalculoJuros(ByVal id_calculo_juros As Integer)

        Try
            Dim lmsg As String
            Dim calcjuros As New CalculoJuros()
            calcjuros.id_situacao = 2
            calcjuros.id_calculo_juros = id_calculo_juros
            calcjuros.id_modificador = Convert.ToInt32(Session("id_login"))
            calcjuros.deleteCalculoJuros()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 216
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            lmsg = "Registro de referência de Juros para Cálculo foi desativado com sucesso!"

            messageControl.Alert(lmsg)
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim lbl_id_situacao As Label = CType(e.Row.FindControl("lbl_id_situacao"), Label)
            Dim lbl_dt_referencia As Label = CType(e.Row.FindControl("lbl_dt_referencia"), Label)
            Dim lsaux As String

            If lbl_id_situacao.Text.Equals("1") Then 'se linha ativa deixa excluir
                Dim calculodefinitivo As New CalculoProdutor
                calculodefinitivo.dt_referencia_start = DateTime.Parse(lbl_dt_referencia.Text).ToString("dd/MM/yyyy")
                calculodefinitivo.dt_referencia_end = DateTime.Now.ToString("dd/MM/yyyy")
                lsaux = calculodefinitivo.getCalculoDefinitivoByPeriodo
                If Not lsaux Is Nothing AndAlso Not IsDBNull(lsaux) AndAlso Not (lsaux.Equals(String.Empty)) Then
                    'se encontrou calculo definitivo nao deixa excluir refencia anterior a calculo definitivo
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir o registro. Existem cálculo em definitivo para referências posteriores."
                End If
            Else
                'se encontrou calculo definitivo nao deixa excluir refencia anterior a calculo definitivo
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                btn_delete.ToolTip = "O registro já foi excluído anteriormente."

            End If


        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub cv_novo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_novo.ServerValidate
        Try
            Dim calcjuros As New CalculoJuros()
            Dim lmsg As String = ""

            args.IsValid = True

            calcjuros.dt_referencia = "01/" & txt_novo_referencia.Text
            calcjuros.id_situacao = 1

            If calcjuros.getCalculoJurosByFilters.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "A referência informada já está cadastrada."
            End If

            If args.IsValid = False Then
                args.IsValid = True
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_nova_taxa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nova_taxa.Click
        If Page.IsValid Then
            Try
                Dim calcjuros As New CalculoJuros

                calcjuros.dt_referencia = "01/" & txt_novo_referencia.Text
                calcjuros.nr_valor = CDec(txt_novo_valor.Text)
                calcjuros.id_modificador = Session("id_login")

                calcjuros.insertCalculoJuros()

                txt_novo_referencia.Text = String.Empty
                txt_novo_valor.Text = String.Empty
                loadDetails()
                txt_dt_referencia.Text = String.Empty
                ViewState.Item("dt_referencia") = String.Empty
                loadData()

                messageControl.Alert("Registro de Juros para cálculo incluido com sucesso.")


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
