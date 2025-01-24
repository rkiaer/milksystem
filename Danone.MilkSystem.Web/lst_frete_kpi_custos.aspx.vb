Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_frete_kpi_custos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("ano") = txt_nr_ano.Text.Trim()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_frete_kpi_custos.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_kpi_custos.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 267
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.SelectedValue = 1
            ViewState.Item("id_estabelecimento") = 1

            txt_nr_ano.Text = DateTime.Parse(Now).ToString("yyyy")
            ViewState.Item("ano") = txt_nr_ano.Text

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim frete As New CalculoFrete

            frete.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            frete.nr_ano = ViewState.Item("ano")

            Dim dsfrete As DataSet = frete.getFreteKpiCustos

            If (dsfrete.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
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
        loadData()
    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("ano") = txt_nr_ano.Text

        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 267
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_frete_kpi_custos_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&ano=" + ViewState.Item("ano").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        Else
            messageControl.Alert("Não há linhas para serem exportadas para o Excel!")

        End If
    End Sub

    Protected Sub cv_ano_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_ano.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If txt_nr_ano.Text < 2024 Then
                args.IsValid = False
                lmsg = "Não existem dados para ano de referência anterior ao ano de 2024."
            End If
            If Len(txt_nr_ano.Text) <> 4 Then
                args.IsValid = False
                lmsg = "O Ano de referência deve ter 4 posições, com formato 'aaaa'."
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class

