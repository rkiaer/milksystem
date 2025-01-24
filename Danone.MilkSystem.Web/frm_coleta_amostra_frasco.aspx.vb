Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_coleta_amostra_frasco
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_coleta_amostra_frasco.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False


            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")

                loadData()
            Else
                'se é nova tela, verifica rota carregada e guarda a data ult coleta
                Dim coletaamostra As New ColetaAmostra
                Dim dsultimacoleta As DataSet = coletaamostra.getColetaUltimaRotaCarregada
                If dsultimacoleta.Tables(0).Rows.Count > 0 Then
                    With dsultimacoleta.Tables(0).Rows(0)

                        lbl_ultima_coleta.Text = String.Concat("Rota: ", .Item("nm_linha").ToString, " - ", "Data: ", DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy HH:mm"))
                        ViewState.Item("dataultimacoleta") = DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy")

                    End With
                Else
                    lbl_ultima_coleta.Text = String.Empty
                    ViewState.Item("dataultimacoleta") = String.Empty
                End If
                'sugere uma referencia
                txt_referencia.Text = DateTime.Now.ToString("MM/yyyy")

                'monta grid
                Dim coletafrasco As New ColetaAmostraFrasco
                Dim dscoletafrasco As DataSet = coletafrasco.getColetaAmostraFrascoCadastro
                If (dscoletafrasco.Tables(0).Rows.Count > 0) Then
                    gridFrascos.Visible = True
                    gridFrascos.DataSource = Helper.getDataView(dscoletafrasco.Tables(0), "")
                    gridFrascos.DataBind()
                End If

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim coletafrasco As New ColetaAmostraFrasco()


            'Dados
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento")
            cbo_estabelecimento.Enabled = False

            txt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
            txt_referencia.Enabled = False

            Dim coletaamostra As New ColetaAmostra
            Dim dsultimacoleta As DataSet = coletaamostra.getColetaUltimaRotaCarregada
            If dsultimacoleta.Tables(0).Rows.Count > 0 Then
                With dsultimacoleta.Tables(0).Rows(0)

                    lbl_ultima_coleta.Text = String.Concat("Rota: ", .Item("nm_linha").ToString, " - ", "Data: ", DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy HH:mm"))
                    ViewState.Item("dataultimacoleta") = DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy")

                End With
            Else
                lbl_ultima_coleta.Text = String.Empty
                ViewState.Item("dataultimacoleta") = String.Empty
            End If

            coletafrasco.id_estabelecimento = ViewState.Item("id_estabelecimento")
            coletafrasco.dt_validade = ViewState.Item("dt_referencia")

            Dim dscoletafrasco As DataSet = coletafrasco.getColetaAmostraFrascoCadastro

            If (dscoletafrasco.Tables(0).Rows.Count > 0) Then

                'controle sistema
                With dscoletafrasco.Tables(0).Rows(0)
                    lbl_modificador.Text = .Item("ds_login")
                    lbl_dt_modificacao.Text = .Item("dt_modificacao").ToString()
                    cbo_situacao.SelectedValue = .Item("id_situacao").ToString()
                End With


                gridFrascos.Visible = True
                gridFrascos.DataSource = Helper.getDataView(dscoletafrasco.Tables(0), "")
                gridFrascos.DataBind()
            Else
                gridFrascos.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


            'CONTROELE VISUAL

            'se data ultima coleta maior ou igual referencia nao atualiza, nao pode salvar
            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateAdd(DateInterval.Month, 1, ViewState.Item("dt_referencia"))) Then
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            End If

            If cbo_situacao.SelectedValue = 2 Then
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim coletafrasco As New ColetaAmostraFrasco
                Dim lmsg As String = String.Empty

                coletafrasco.dt_validade = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")
                coletafrasco.id_estabelecimento = cbo_estabelecimento.SelectedValue
                coletafrasco.id_modificador = Session("id_login")
                If cbo_situacao.SelectedValue = 1 Then
                    Dim row As GridViewRow
                    For Each row In gridFrascos.Rows
                        If row.Visible = True Then
                            Dim txt_descricao_coletor As Anthem.TextBox = CType(row.FindControl("txt_descricao_coletor"), Anthem.TextBox)
                            Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_frasco"), Anthem.CheckBox)
                            Dim lbl_id_coleta_amostra_frasco As Label = CType(row.FindControl("lbl_id_coleta_amostra_frasco"), Label)
                            Dim lbl_id_tipo_frasco As Label = CType(row.FindControl("lbl_id_tipo_frasco"), Label)

                            'se foi selecionado
                            If check.Checked = True Then
                                coletafrasco.id_tipo_frasco = Convert.ToInt32(lbl_id_tipo_frasco.Text)
                                coletafrasco.ds_descricao_frasco = txt_descricao_coletor.Text
                                coletafrasco.id_situacao = 1
                                'se nao tem id é novo item
                                If lbl_id_coleta_amostra_frasco.Text.Equals(String.Empty) Then
                                    coletafrasco.insertColetaAmostraFrasco()
                                Else
                                    coletafrasco.id_coleta_amostra_frasco = Convert.ToInt32(lbl_id_coleta_amostra_frasco.Text)
                                    coletafrasco.updateColetaAmostraFrasco()
                                End If
                            Else
                                'se nao esta slecionado mas tem id, inativa registro
                                If Not lbl_id_coleta_amostra_frasco.Text.Equals(String.Empty) Then
                                    coletafrasco.id_coleta_amostra_frasco = Convert.ToInt32(lbl_id_coleta_amostra_frasco.Text)
                                    'inativa no banco
                                    coletafrasco.deleteColetaAmostraFrasco()
                                End If
                            End If

                        End If
                    Next

                    If ViewState.Item("dt_referencia") Is Nothing Then
                        lmsg = "Registro inserido com sucesso!"

                        ViewState.Item("dt_referencia") = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")
                        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                    Else
                        lmsg = "Registro atualizado com sucesso!"
                    End If
                Else
                    coletafrasco.deleteColetaAmostraFrascoTodos()
                    lmsg = "Registro inativado com sucesso!"

                End If
                messageControl.Alert(lmsg)

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_coleta_amostra_frasco.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_coleta_amostra_frasco.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_coleta_amostra_frasco.aspx")

    End Sub


    Protected Sub cv_salvar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_salvar.ServerValidate
        Try
            Dim lmsg As String
            Dim lreferencianow As String = DateTime.Parse(String.Concat("01/", DateTime.Now.ToString("MM/yyyy")))

            Dim coletamanual As New ColetaAmostraManual
            coletamanual.id_estabelecimento = cbo_estabelecimento.SelectedValue
            coletamanual.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")

            Dim coletaperiodo As New ColetaAmostraPeriodo
            coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue
            coletaperiodo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")

            args.IsValid = True

            Dim row As GridViewRow

            Dim ilinha As Int32 = 0

            For Each row In gridFrascos.Rows
                Dim txt_descricao_coletor As Anthem.TextBox = CType(row.FindControl("txt_descricao_coletor"), Anthem.TextBox)
                Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_frasco"), Anthem.CheckBox)
                Dim img_tipo_frasco As Anthem.Image = CType(row.FindControl("img_tipo_frasco"), Anthem.Image)
                Dim lbl_id_coleta_amostra_frasco As Label = CType(row.FindControl("lbl_id_coleta_amostra_frasco"), Label)
                Dim lbl_nm_imagem_frasco As Label = CType(row.FindControl("lbl_nm_imagem_frasco"), Label)
                Dim lbl_nm_tipo_frasco As Label = CType(row.FindControl("lbl_nm_tipo_frasco"), Label)
                Dim lbl_id_tipo_frasco As Label = CType(row.FindControl("lbl_id_tipo_frasco"), Label)

                If check.Checked = True Then
                    ilinha = ilinha + 1

                    If txt_descricao_coletor.Text.Equals(String.Empty) Then
                        lmsg = "A descrição do frasco " & lbl_nm_tipo_frasco.Text & ", que deve ser visualizada no Coletor deve ser informada."
                        args.IsValid = False
                        Exit For
                    End If
                End If
            Next

            If args.IsValid = True AndAlso ilinha = 0 Then
                lmsg = "Algum frasco deve ser selecionado para a referência."
                args.IsValid = False

            End If

            'se é novo
            If args.IsValid = True AndAlso ViewState.Item("dt_referencia") Is Nothing Then
                If CDate(DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")) < CDate(lreferencianow) Then
                    lmsg = "A referência de validade não pode ser menor que a referência atual."
                    args.IsValid = False
                End If

                If args.IsValid = True Then
                    Dim coletafrasco As New ColetaAmostraFrasco
                    coletafrasco.dt_validade = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")
                    coletafrasco.id_estabelecimento = cbo_estabelecimento.SelectedValue

                    If coletafrasco.getColetaAmostraFrasco.Tables(0).Rows.Count > 0 Then
                        lmsg = "Já existe a referência informada no cadastro de Frascos para Análises das Amostras."
                        args.IsValid = False
                    End If
                End If
            End If



            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub gridFrascos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridFrascos.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try

                Dim txt_descricao_coletor As Anthem.TextBox = CType(e.Row.FindControl("txt_descricao_coletor"), Anthem.TextBox)
                Dim check As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_frasco"), Anthem.CheckBox)
                Dim img_tipo_frasco As Anthem.Image = CType(e.Row.FindControl("img_tipo_frasco"), Anthem.Image)
                Dim lbl_id_coleta_amostra_frasco As Label = CType(e.Row.FindControl("lbl_id_coleta_amostra_frasco"), Label)
                Dim lbl_nm_imagem_frasco As Label = CType(e.Row.FindControl("lbl_nm_imagem_frasco"), Label)
                Dim lbl_nm_tipo_frasco As Label = CType(e.Row.FindControl("lbl_nm_tipo_frasco"), Label)
                Dim lbl_id_tipo_frasco As Label = CType(e.Row.FindControl("lbl_id_tipo_frasco"), Label)

                'se nao esta no banco
                If lbl_id_coleta_amostra_frasco.Text.Equals(String.Empty) Then
                    check.Checked = False
                    If txt_descricao_coletor.Text.Equals(String.Empty) Then 'se nao tem valor no campo assume o nome do frasco n milk
                        txt_descricao_coletor.Text = lbl_nm_tipo_frasco.Text
                    End If
                Else
                    check.Checked = True

                End If

                img_tipo_frasco.ImageUrl = String.Concat("~/img/", lbl_nm_imagem_frasco.Text)


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub
End Class
