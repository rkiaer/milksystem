Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_contrato_faixa_qualidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_contrato_faixa_qualidade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_categoria.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria.DataTextField = "nm_categoria"
            cbo_categoria.DataValueField = "id_categoria"
            cbo_categoria.DataBind()
            cbo_categoria.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_un_medida.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_un_medida.Items.Add(New ListItem("Kilograma", "K"))
            cbo_un_medida.Items.Add(New ListItem("Litro", "L"))

            If Not (Request("id_contrato_validade") Is Nothing) Then
                ViewState.Item("id_contrato_validade") = Request("id_contrato_validade")
                ViewState.Item("id_contrato") = Request("id_contrato")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim contratovalidade As New Contrato
            Dim dscontratovalidade As DataSet

            contratovalidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
            dscontratovalidade = contratovalidade.getContratoSuasValidades()

            'CABEÇALHO
            If dscontratovalidade.Tables(0).Rows.Count > 0 Then
                With dscontratovalidade.Tables(0).Rows(0)
                    lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                    lbl_contrato.Text = String.Concat(.Item("cd_contrato").ToString, " - ", .Item("nm_contrato").ToString)
                    lbl_contrato_padrao.Text = IIf(.Item("st_contrato_comercial").ToString.Equals("S"), "SIM", "NÃO")
                    lbl_contrato_mercado.Text = IIf(.Item("st_contrato_mercado").ToString.Equals("S"), "SIM", "NÃO")
                    lbl_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                    lbl_situacao.Text = .Item("nm_situacao").ToString
                    lbl_situacao_contrato.Text = String.Concat(.Item("nm_situacao_contrato_validade").ToString, " - ", .Item("nm_situacao_contrato").ToString)
                    ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento").ToString
                    ViewState.Item("dt_referencia") = .Item("dt_referencia").ToString
                    ViewState.Item("id_situacao_contrato") = .Item("id_situacao_contrato").ToString
                    ViewState.Item("st_contrato_mercado") = .Item("st_contrato_mercado").ToString

                    'se o contrato estiver inativo ou contrato validade estiver inativo
                    If .Item("id_situacao").ToString = 2 OrElse .Item("id_situacao_contrato_validade").ToString = 2 Then
                        grdQualidade.Columns.Item(6).Visible = True 'não deixa exluir
                        tr_painelincluir.Visible = False
                    End If
                    'se a situacao contrato estiver aprovado, reprovado em 1 ou 2 nivel, nao pode exluir
                    If Not (.Item("id_situacao_contrato").ToString = 1) AndAlso Not (.Item("id_situacao_contrato").ToString = 2) Then
                        grdQualidade.Columns.Item(6).Visible = True 'não deixa exluir
                        tr_painelincluir.Visible = False
                    End If
                    lbl_modificador.Text = .Item("id_modificador_validade").ToString()
                    lbl_dt_modificacao.Text = .Item("dt_modificacao_validade").ToString()

                End With
            End If

            loadGridFaixaQualidade()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadGridFaixaQualidade(Optional ByVal bpesquisar As Boolean = False)

        Try

            Dim faixaqualidade As New FaixaQualidade

            faixaqualidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
            faixaqualidade.id_situacao = 1
            If bpesquisar = True Then
                faixaqualidade.id_categoria = Convert.ToInt32(ViewState.Item("id_categoria_filtro"))
            End If

            Dim dsfaixaqualidade As DataSet = faixaqualidade.getFaixaQualidadeByFilters()

            If (dsfaixaqualidade.Tables(0).Rows.Count > 0) Then
                grdQualidade.Visible = True
                grdQualidade.DataSource = Helper.getDataView(dsfaixaqualidade.Tables(0), "nm_categoria,nr_faixa_inicio")
                grdQualidade.DataBind()
            Else
                grdQualidade.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub btn_incluirqualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirqualidade.Click
        Try

            If Page.IsValid Then

                Dim faixaqualidade As New FaixaQualidade()
                Dim batualizousituacao As Boolean = True
                'BUSCAR DADOS DOS CAMPOS INFORMADOS PARA INCLUSAO
                If Not (cbo_categoria_qualidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    faixaqualidade.id_categoria = Convert.ToInt32(cbo_categoria_qualidade.SelectedValue)
                End If

                If Not (txt_nr_faixa_inicio.Text.Trim().Equals(String.Empty)) Then
                    faixaqualidade.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_inicio.Text)
                End If

                If Not (txt_nr_faixa_fim.Text.Trim().Equals(String.Empty)) Then
                    faixaqualidade.nr_faixa_fim = Convert.ToDouble(txt_nr_faixa_fim.Text)
                End If

                If Not (txt_nr_bonus_desconto.Text.Trim().Equals(String.Empty)) Then
                    faixaqualidade.nr_bonus_desconto = Convert.ToDouble(txt_nr_bonus_desconto.Text)
                End If

                If Not (cbo_un_medida.SelectedValue.Trim().Equals(String.Empty)) Then
                    faixaqualidade.un_medida = cbo_un_medida.SelectedValue
                End If

                'BUSCAR DADOS CABECALHO QUE VEM DE CONTRATO 
                faixaqualidade.id_situacao = 1
                faixaqualidade.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                faixaqualidade.dt_validade = DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("dd/MM/yyyy")
                faixaqualidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
                faixaqualidade.id_modificador = Session("id_login")

                'incluir faixa qualidade
                faixaqualidade.insertFaixaQualidade()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.ds_nm_processo = "Contrato - Faixa Qualidade"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                If ViewState.Item("id_situacao_contrato").ToString.Equals("1") Then 'se situacao contrato aberta
                    If ViewState.Item("st_contrato_mercado").ToString.Equals("S") Then
                        'se nao tem cadastro de adicional de volume, atualiza contrato para completo
                        Dim contrato As New ContratoValidade
                        contrato.id_contrato_validade = faixaqualidade.id_contrato_validade
                        contrato.id_modificador = faixaqualidade.id_modificador
                        contrato.id_situacao_contrato = 2 'Completo
                        contrato.updateContratoValidadeSituacao() 'atualiza situcao contrato para completo
                    Else
                        'verifica se ja incluiu volume
                        Dim contratoadicional As New ContratoAdicionalVolume
                        contratoadicional.id_contrato_validade = faixaqualidade.id_contrato_validade
                        contratoadicional.id_situacao = 1
                        'se encontrou linhas salvas em adicional de volume
                        If contratoadicional.getContratoAdicionalVolumeByFilters.Tables(0).Rows.Count > 0 Then
                            Dim contrato As New ContratoValidade
                            contrato.id_contrato_validade = faixaqualidade.id_contrato_validade
                            contrato.id_modificador = faixaqualidade.id_modificador
                            contrato.id_situacao_contrato = 2 'Completo
                            contrato.updateContratoValidadeSituacao() 'atualiza situcao contrato para completo
                        End If

                    End If
                End If

                messageControl.Alert("Registro inserido com sucesso.")

                'atualiza tela
                cbo_categoria.SelectedValue = String.Empty
                cbo_categoria_qualidade.SelectedValue = String.Empty
                txt_nr_faixa_inicio.Text = String.Empty
                txt_nr_faixa_fim.Text = String.Empty
                txt_nr_bonus_desconto.Text = String.Empty
                cbo_un_medida.SelectedValue = String.Empty

                If batualizousituacao = True Then
                    loadData()
                Else
                    loadGridFaixaQualidade()

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Try

            If cbo_categoria.SelectedValue = String.Empty Then
                ViewState.Item("id_categoria_filtro") = 0
            Else
                ViewState.Item("id_categoria_filtro") = cbo_categoria.SelectedValue
            End If

            loadGridFaixaQualidade(True)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdQualidade_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdQualidade.PageIndexChanging
        grdQualidade.PageIndex = e.NewPageIndex
        loadGridFaixaQualidade()
    End Sub

    Protected Sub grdQualidade_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdQualidade.RowCommand
        Select Case e.CommandName.ToString().ToLower()


            Case "delete"
                deletefaixaqualidade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteFaixaQualidade(ByVal id_faixa_qualidade As Integer)

        Try

            Dim faixaqualidade As New FaixaQualidade()
            faixaqualidade.id_faixa_qualidade = id_faixa_qualidade
            faixaqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            faixaqualidade.deleteConta()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.ds_nm_processo = "Contrato - Faixa Qualidade"
            usuariolog.id_nr_processo = id_faixa_qualidade
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadGridFaixaQualidade()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdQualidade_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdQualidade.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdQualidade_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdQualidade.Sorting
        Select Case e.SortExpression.ToLower()

            Case "nm_categoria"
                If (ViewState.Item("sortExpression")) = "nm_categoria asc" Then
                    ViewState.Item("sortExpression") = "nm_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "nm_categoria asc"
                End If
            Case "nr_faixa_inicio"
                If (ViewState.Item("sortExpression")) = "nr_faixa_inicio asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_inicio asc"
                End If


            Case "nr_faixa_fim"
                If (ViewState.Item("sortExpression")) = "nr_faixa_fim asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_fim desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_fim asc"
                End If

        End Select

        loadGridFaixaQualidade()

    End Sub


    Protected Sub cv_qualidade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_qualidade.ServerValidate
        Try
            Dim lmsg As String
            Dim faixaqualidade As New FaixaQualidade

            args.IsValid = True

            faixaqualidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade").ToString)
            faixaqualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
            faixaqualidade.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_inicio.Text)
            If faixaqualidade.getContratoFaixasQualidadeConsFaixas.Tables(0).Rows.Count > 0 Then
                lmsg = "O valor da faixa de início informada já existe entre as faixas desta categoria."
                args.IsValid = False
            End If

            If args.IsValid = True Then
                faixaqualidade.nr_faixa_inicio = Convert.ToDouble(txt_nr_faixa_fim.Text)
                If faixaqualidade.getContratoFaixasQualidadeConsFaixas.Tables(0).Rows.Count > 0 Then
                    lmsg = "O valor da faixa fim informada já existe entre as faixas desta categoria."
                    args.IsValid = False
                End If
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
