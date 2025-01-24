Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_relatorio_termo_ocorrencia

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_ini") = Me.txt_dt_ini.Text.Trim
        If txt_dt_fim.Text.Equals(String.Empty) Then
            txt_dt_fim.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        End If
        ViewState.Item("dt_fim") = String.Concat(Me.txt_dt_fim.Text.Trim, " 23:59:59")
        ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
        ViewState.Item("rota") = txt_rota.Text
        ViewState.Item("id_romaneio") = txt_romaneio.Text 'fran themis 15/05/2012

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_termo_ocorrencia.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_termo_ocorrencia.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 116
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_dt_ini.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("rel_termo", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("rel_termo", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        If Not (customPage.getFilterValue("rel_termo", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            Me.txt_cd_transportador.Text = customPage.getFilterValue("rel_termo", txt_cd_transportador.ID)
            hf_id_transportador.Value = customPage.getFilterValue("rel_termo", hf_id_transportador.ID)
            ViewState.Item("id_transportador") = customPage.getFilterValue("rel_termo", hf_id_transportador.ID)
            Me.lbl_nm_transportador.Text = customPage.getFilterValue("rel_termo", lbl_nm_transportador.ID)
        Else
            ViewState.Item("id_transportador") = String.Empty
        End If

        If Not (customPage.getFilterValue("rel_termo", txt_dt_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_ini") = customPage.getFilterValue("rel_termo", txt_dt_ini.ID)
            txt_dt_ini.Text = ViewState.Item("dt_ini").ToString()
        Else
            ViewState.Item("dt_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("rel_termo", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim") = customPage.getFilterValue("rel_termo", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("dt_fim").ToString()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        If Not (customPage.getFilterValue("rel_termo", txt_rota.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("rota") = customPage.getFilterValue("rel_termo", txt_rota.ID)
            txt_rota.Text = ViewState.Item("rota").ToString()
        Else
            ViewState.Item("rota") = String.Empty
        End If
        'fran themis i 15/05/2012
        If Not (customPage.getFilterValue("rel_termo", txt_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("rel_termo", txt_romaneio.ID)
            txt_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        'fran themis f 15/05/2012

        If Not (customPage.getFilterValue("rel_termo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("rel_termo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("rel_termo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            romaneio.data_inicio = ViewState.Item("dt_ini").ToString
            romaneio.data_fim = ViewState.Item("dt_fim").ToString
            romaneio.nm_linha = ViewState.Item("rota").ToString
            If Not ViewState.Item("id_transportador").Equals(String.Empty) Then
                romaneio.id_transportador = ViewState.Item("id_transportador")
            End If
            'fran themis i 15/05/2012
            If Not ViewState.Item("id_romaneio").Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_romaneio")
            End If
            'fran themis f 15/05/2012


            Dim dstermo As DataSet = romaneio.getRelatorioTermoOcorrencia()

            If (dstermo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstermo.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_controleleite.aspx?data={0}", Me.txt_data.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue)
            'Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.Load

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If
            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If
            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If


        End Select

        loadData()

    End Sub
    'Private Sub saveFilters()

    '    Try


    '        customPage.setFilter("rel_termo", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("rel_termo", txt_cd_transportador.ID, txt_cd_transportador.Text)
    '        customPage.setFilter("rel_termo", lbl_nm_transportador.ID, lbl_nm_transportador.Text)
    '        customPage.setFilter("rel_termo", hf_id_transportador.ID, ViewState.Item("id_transportador").ToString)
    '        customPage.setFilter("rel_termo", txt_rota.ID, ViewState.Item("rota").ToString)
    '        customPage.setFilter("rel_termo", txt_dt_fim.ID, ViewState.Item("dt_fim").ToString)
    '        customPage.setFilter("rel_termo", txt_dt_ini.ID, ViewState.Item("dt_ini").ToString)
    '        customPage.setFilter("rel_termo", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

  

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'Formata valores para emissão do termo de ocorrencia
        'REGRAS:
        'Só emite termo de ocorrencia quando o volume da caderneta ou do romaneio for maior que a pesagem da balança e a diferença destes volumes ultrapassar a margem de 0,2% de tolerancia;
        'Não emite quando:
        '1) Se o volume da balança estiver zerado. (ocorre qdo o romaneio ainda nao foi finalizado)
        '2) Quando o volume da balança for maior que o volume da caderneta ou nota 
        '3) Quando a diferença em litros do volume da balança e volume da caderneta /nota for maior que o valor de toleran cia

        If (e.Row.RowType <> DataControlRowType.Header _
             And e.Row.RowType <> DataControlRowType.Footer _
             And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim txt_nr_preco As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_preco"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim hl_imprimir As Anthem.HyperLink = CType(e.Row.FindControl("hl_imprimir"), Anthem.HyperLink)

            'Data de entrada do romaneio - formatar
            e.Row.Cells(0).Text = Left(DateTime.Parse(e.Row.Cells(0).Text).ToString("dd/MM/yyyy"), 10)

            Dim romaneio As New Romaneio
            romaneio.id_romaneio = Convert.ToInt32(e.Row.Cells(1).Text)
            Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()

            'Converte os kg da balança em litros
            e.Row.Cells(5).Text = Decimal.Truncate(Decimal.Round(CDec(e.Row.Cells(5).Text) / mediadensidade, 0))

            'Format volume caderneta/nota
            e.Row.Cells(6).Text = Decimal.Truncate(Decimal.Round(CDec(e.Row.Cells(6).Text), 0))

            'Diferença
            'Litros da caderneta/nota fiscal subtraindo litros da balanca
            e.Row.Cells(7).Text = Decimal.Truncate(CDec(e.Row.Cells(6).Text) - CDec(e.Row.Cells(5).Text))

            'se o sinal é negativo, significa que o volume da balança é maior do que o volume da cadaerneta/nf,
            'neste caso não emite termo de ocorrência
            If Sign(CDec(e.Row.Cells(7).Text)) = -1 Or e.Row.Cells(5).Text.Equals("0") Then
                txt_nr_preco.Enabled = False
            Else
                If Sign(CDec(e.Row.Cells(5).Text)) = -1 Then 'se balança valor negativo
                    txt_nr_preco.Enabled = False
                Else
                    txt_nr_preco.Enabled = True
                End If
            End If

            'Retira o sinal da diferença
            e.Row.Cells(7).Text = +Abs(CDec(e.Row.Cells(7).Text))

            '0,2%
            'Valor total da balança em litros 
            e.Row.Cells(8).Text = Decimal.Truncate(Decimal.Round(CDec(CDec(e.Row.Cells(5).Text) * 0.002), 0))

            'se a diferença de volume for maior que o percentual de tolerancia deve emitir relatorio caso contrario não deve emitir relatorio
            If CDec(e.Row.Cells(7).Text) > CDec(e.Row.Cells(8).Text) Then
                txt_nr_preco.Enabled = True
            Else
                txt_nr_preco.Enabled = False
            End If
            'se não deve imprimir, não calcula valor a ser descontado  trasnportador
            If txt_nr_preco.Enabled = False Then
                e.Row.Cells(9).Text = String.Empty
                hl_imprimir.Enabled = False
                hl_imprimir.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                hl_imprimir.ToolTip = "Não há ocorrência para geração do Relatório Termo de Ocorrência."
                txt_nr_preco.Visible = False
                hl_imprimir.Visible = False
            Else
                'Valor a ser descontado do transportador (diferença - valor 0,2%
                e.Row.Cells(9).Text = Decimal.Truncate(CDec(e.Row.Cells(7).Text) - CDec(e.Row.Cells(8).Text))
                hl_imprimir.Enabled = False
                hl_imprimir.ImageUrl = "~/img/ic_impressao.gif"
                hl_imprimir.NavigateUrl = String.Format("frm_relatorio_termo_ocorrencia.aspx?id_romaneio={0}", romaneio.id_romaneio.ToString) & String.Format("&nr_volume_descontar={0}", e.Row.Cells(9).Text)
                hl_imprimir.ToolTip = "Para Imprimir Relatório Termo de Ocorrência Informe Preço do Litro do Leite."


            End If


        End If



    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If

    End Sub
    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transcoop")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

        ' Para gravar o transportador se o código for digitado - i
        Try
            If Not txt_cd_transportador.Text.ToString.Equals(String.Empty) Then
                Dim pessoa As New Pessoa
                pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
                Dim dsPessoa As DataSet = pessoa.getTransportadorCooperativaByFilters
                If dsPessoa.Tables(0).Rows.Count > 0 Then
                    lbl_nm_transportador.Visible = True
                    lbl_nm_transportador.Text = dsPessoa.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_transportador.Value = dsPessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
                Else
                    lbl_nm_transportador.Text = String.Empty
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' para gravar o transportador se o código for digitado - f

    End Sub

   
   

    Protected Sub txt_nr_preco_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim txt_nr_preco As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim hl_imprimir As Anthem.HyperLink = CType(row.FindControl("hl_imprimir"), Anthem.HyperLink)
        Dim id_romaneio As DataControlFieldCell = CType(row.Cells(1), DataControlFieldCell)
        Dim nr_valor_descontar As DataControlFieldCell = CType(row.Cells(9), DataControlFieldCell)


        If txt_nr_preco.Text.Equals(String.Empty) Then

            hl_imprimir.Enabled = False
            'hl_imprimir.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
            hl_imprimir.ToolTip = "Para Imprimir Relatório Termo de Ocorrência Informe Preço do Litro do Leite."

        Else
            If txt_nr_preco.Text.Equals("0") Then
                hl_imprimir.Enabled = False
                'hl_imprimir.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                hl_imprimir.ToolTip = "Para Imprimir Relatório Termo de Ocorrência Informe Preço do Litro do Leite."
            Else

                hl_imprimir.Enabled = True
                'hl_imprimir.ImageUrl = "~/img/ic_impressao.gif"
                hl_imprimir.NavigateUrl = String.Format("frm_relatorio_termo_ocorrencia.aspx?id_romaneio={0}", id_romaneio.Text) & String.Format("&nr_volume_descontar={0}", nr_valor_descontar.Text) & String.Format("&nr_preco={0}", txt_nr_preco.Text)
                hl_imprimir.ToolTip = "Relatório Termo de Ocorrência: Versão para Imprimir."

            End If
        End If
    End Sub
End Class
