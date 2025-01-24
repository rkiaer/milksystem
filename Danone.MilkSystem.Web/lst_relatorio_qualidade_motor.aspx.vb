Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_relatorio_qualidade_motor

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_qualidade_motor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

        ' 02/12/2009 - Maracanau - i
        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
        End With
        ' 02/12/2009 - Maracanau - f

    End Sub


    Private Sub loadDetails()

        Try

            ' 02/12/2009 - Maracanau - i
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            ' 02/12/2009 - Maracanau - f

            Dim relatorio As New RelatorioMotor
            relatorio.relatorio = "extrato_qualidade"

            ' Desativa os relatórios criados há mais de dois dias
            relatorio.deleteRelatorioMotor()

            Dim dsRelatorios As DataSet = relatorio.getRelatoriosMotorByFilters()

            If (dsRelatorios.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRelatorios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                'messageControl.Alert("Nenhum relatório foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            ViewState.Item("dt_referencia") = "01/" + dt_referencia.Text

            Dim relatorio As New RelatorioMotor

            relatorio.relatorio = "extrato_qualidade"
            relatorio.descricao = "Extrato Mensal do Produtor"
            'relatorio.origem = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString() & "\extrato_qualidade.rpt"
            'relatorio.origem = System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString() & "\extrato_qualidade.rpt"
            relatorio.origem = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString() & "extrato_qualidade.rpt"  ' 04/01/2010 - Caminho correto aonde estão todas as páginas do site
            relatorio.conteudo = "01/" + dt_referencia.Text
            relatorio.id_modificador = Session("id_login")

            ' 02/12/2009 - Maracanau - i
            relatorio.par_id_estabelecimento = cbo_estabelecimento.SelectedValue
            relatorio.par_cd_pessoa = txt_cd_pessoa.Text
            ' 02/12/2009 - Maracanau - f


            relatorio.insertRelatorioQualidadeMotor()   ' coloca relatorio na fila

 
            Dim dsRelatorios As DataSet = relatorio.getRelatoriosMotorByFilters()

            If (dsRelatorios.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRelatorios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum relatório foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging

        ' Chamado 703 - 03/03/2010 - Erro na paginação do grid - i
        gridResults.PageIndex = e.NewPageIndex
        loadData()
        ' Chamado 703 - 03/03/2010 - Erro na paginação do grid - f

    End Sub
    Private Sub loadData()

        ' Chamado 703 - 03/03/2010 - Erro na paginação do grid - i
        Try
            Dim relatorio As New RelatorioMotor
            relatorio.relatorio = "extrato_qualidade"

            Dim dsRelatorios As DataSet = relatorio.getRelatoriosMotorByFilters()

            If (dsRelatorios.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRelatorios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Chamado 703 - 03/03/2010 - Erro na paginação do grid - f

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_download As Anthem.HyperLink = CType(e.Row.FindControl("hl_download"), Anthem.HyperLink)

            'hl_download.NavigateUrl = String.Format("frm_download.aspx?arquivo={0}", Convert.ToString(e.Row.Cells(5).Text))
            hl_download.NavigateUrl = String.Format("frm_download.aspx?arquivo={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value())


            If e.Row.Cells(3).Text = 2 Then  ' Se finalizado com sucesso
                hl_download.Enabled = True
            Else
                hl_download.Enabled = False
            End If
        End If



    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        ' 02/12/2009 - Maracanau - i
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If
        ' 02/12/2009 - Maracanau - f

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        ' 02/12/2009 - Maracanau - i
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
        ' 02/12/2009 - Maracanau - f

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        ' 02/12/2009 - Maracanau - i
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty
        ' 02/12/2009 - Maracanau - f

    End Sub
    ' 02/12/2009 - Maracanau - i
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    ' 02/12/2009 - Maracanau - f

End Class
