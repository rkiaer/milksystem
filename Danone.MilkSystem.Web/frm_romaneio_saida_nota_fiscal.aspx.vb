Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class frm_romaneio_saida_nota_fiscal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_nota_fiscal.aspx")
            If Not Page.IsPostBack Then

                loadDetails()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Private Sub loadDetails()
        Try


            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")

                'BUSCA SE O USUARIO TEM ACESSO AO PROCESSO de REGISTRO NF
                Dim usuarioprocesso As New GrupoAcessoProcesso
                usuarioprocesso.id_menu_item_processo = 4 'Procurar o processo 4 - REGISTRO NF
                usuarioprocesso.id_usuario = Session("id_login") 'usuario de acesso
                Dim dsusuarioprocesso As DataSet = usuarioprocesso.getGrupoAcessoProcessoByFilters
                'SE TEM DIREIRO A ACESSAR PROCESSO de REGISTRO NF
                If dsusuarioprocesso.Tables(0).Rows.Count > 0 Then
                    ViewState.Item("acessoregistroNF") = True
                Else 'SE NAO TEM ACESSO
                    ViewState.Item("acessoregistroNF") = False
                End If

                loadData()
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New RomaneioSaida()
            romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaSolicitacaoNF

            lbl_romaneio_saida.Text = ViewState.Item("id_romaneio_saida").ToString

            With dsromaneio.Tables(0).Rows(0)

                'DADOS GERAIS
                lbl_romaneio_situacao.Text = .Item("nm_situacao_romaneio_saida").ToString
                lbl_dt_abertura.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                lbl_pesagem_inicial.Text = FormatNumber(.Item("nr_pesagem_inicial"), 0).ToString
                lbl_pesagem_final.Text = FormatNumber(.Item("nr_pesagem_final"), 0).ToString
                lbl_peso_liquido_romaneio.Text = FormatNumber(.Item("nr_peso_liquido"), 0).ToString
                If Not IsDBNull(.Item("id_romaneio_entrada")) Then
                    lbl_id_romaneio_entrada.Text = .Item("id_romaneio_entrada").ToString
                End If
                lbl_volume_estimado.Text = FormatNumber(.Item("nr_volume_estimado"), 0).ToString

                If Not IsDBNull(.Item("id_romaneio_saida_nota")) Then
                    tr_situacaonota.Visible = True
                    lbl_situacao_nf.Text = .Item("nm_situacao_romaneio_saida_nota").ToString
                    lbl_dt_modificacao_nf.Text = Format(DateTime.Parse(.Item("dt_modificacao").ToString), "dd/MM/yyyy hh:mm").ToString
                    lbl_usuario_nf.Text = Left(.Item("nm_usuario").ToString, 20)
                    ViewState.Item("id_romaneio_saida_nota") = .Item("id_romaneio_saida_nota")
                    ViewState.Item("id_situacao_romaneio_saida_nota") = .Item("id_situacao_romaneio_saida_nota")
                    ViewState.Item("id_situacao_romaneio_saida") = .Item("id_situacao_romaneio_saida")
                    ''se situacao romaneio saida for aberta
                    'If .Item("id_situacao_romaneio_saida_nota") <= "1" Then
                    '    lk_AnexarDocumento.Enabled = True
                    '    lk_acao.Enabled = True
                    'Else
                    '    lk_AnexarDocumento.Enabled = False
                    '    lk_acao.Enabled = False
                    '    lk_concluir.Enabled = False
                    '    lk_concluirFooter.Enabled = False
                    'End If
                Else
                    ViewState.Item("id_romaneio_saida_nota") = 0
                    ViewState.Item("id_situacao_romaneio_saida_nota") = 0
                End If

                'DESTINATARIO
                lbl_nm_destino.Text = .Item("nm_cooperativa").ToString
                lbl_cnpj_destino.Text = .Item("cd_cnpj_cooperativa").ToString
                lbl_ie_destino.Text = .Item("cd_incricao_estadual_destino").ToString
                lbl_endereco_destino.Text = .Item("ds_endereco").ToString
                lbl_endereco_numero.Text = .Item("nr_endereco").ToString
                If lbl_endereco_numero.Text.Equals("0") Then
                    lbl_endereco_numero.Text = "S/N"
                End If
                lbl_cidade_destino.Text = .Item("nm_cidade_destino").ToString
                lbl_cep_destino.Text = .Item("cd_cep_destino").ToString
                lbl_uf_destino.Text = .Item("cd_uf_destino").ToString

                'EMITENTE
                lbl_emitente.Text = .Item("ds_emitente").ToString
                lbl_cbu.Text = .Item("ds_cbu").ToString

                'Transportador
                lbl_nm_transportador.Text = .Item("nm_transportador").ToString
                lbl_cnpj_transportador.Text = .Item("cd_cnpj_transportador").ToString
                lbl_cidade_transportador.Text = .Item("nm_cidade_transp").ToString
                lbl_uf_transportador.Text = .Item("cd_uf_transp").ToString

                'Frete
                If Not IsDBNull(.Item("id_frete_nf")) Then
                    'se frete CIF quem paga é o emitente, nesta caso a Danone
                    If .Item("id_frete_nf").ToString.Equals("1") Then
                        img_frete_danone.ImageUrl = "~/img/ico_chk_true.gif"
                        img_frete_destinatario.ImageUrl = "~/img/ico_chk_false.gif"
                    End If
                    'se frete FOB quem paga é o destinatario, nesta caso a COOP
                    If .Item("id_frete_nf").ToString.Equals("2") Then
                        img_frete_danone.ImageUrl = "~/img/ico_chk_false.gif"
                        img_frete_destinatario.ImageUrl = "~/img/ico_chk_true.gif"
                    End If
                End If
                lbl_placa.Text = .Item("ds_placa").ToString
                If Not IsDBNull(.Item("nr_valor_frete_acordado")) Then
                    lbl_valor_frete.Text = FormatNumber(CDec(.Item("nr_valor_frete_acordado")), 2).ToString
                End If

                'natureza operacao
                If Not IsDBNull(.Item("id_natureza_operacao")) Then
                    ViewState.Item("id_natureza_operacao") = .Item("id_natureza_operacao").ToString
                    lbl_natureza_operacao.Text = .Item("nm_natureza_operacao").ToString
                    lbl_ds_outros.Text = .Item("ds_natureza_operacao_outros").ToString

                End If

                If Not IsDBNull(.Item("id_tipo_operacao")) Then
                    lbl_descricao_natureza.Text = String.Concat(.Item("nm_tipo_operacao").ToString, " de ", .Item("nm_item").ToString)
                End If

                'MATERIAL
                lbl_unidade.Text = .Item("id_tipo_operacao").ToString
                lbl_cd_item.Text = .Item("cd_item_sap").ToString
                lbl_nm_item.Text = .Item("nm_item").ToString

                If Not IsDBNull(.Item("id_romaneio_saida_nota")) Then
                    txt_qtde.Text = FormatNumber(.Item("nr_quantidade"), 0).ToString
                    txt_peso_liquido.Text = FormatNumber(.Item("nr_peso_liquido_nota"), 0).ToString
                    If Not IsDBNull(.Item("nr_peso_bruto")) Then
                        txt_peso_bruto.Text = FormatNumber(.Item("nr_peso_bruto"), 0).ToString
                    End If
                    txt_preco_unitario.Text = FormatNumber(.Item("nr_valor_unitario"), 2).ToString

                    If Not IsDBNull(.Item("ds_nota_fiscal_origem")) Then
                        txt_nota_origem.Text = .Item("ds_nota_fiscal_origem").ToString
                    End If
                    If Not IsDBNull(.Item("ds_contrato")) Then
                        txt_nr_contrato.Text = .Item("ds_contrato").ToString
                    End If
                    If Not IsDBNull(.Item("nr_especie_material")) Then
                        txt_nr_especie.Text = .Item("nr_especie_material").ToString
                    End If
                    If Not IsDBNull(.Item("nr_volume_material")) Then
                        txt_volume_material.Text = .Item("nr_volume_material").ToString
                    End If
                    lbl_valor_total.Text = FormatNumber(.Item("nr_valor_nota_fiscal"), 2).ToString
                    lbl_valor_total_nota.Text = FormatNumber(.Item("nr_valor_nota_fiscal"), 2).ToString

                    txt_ds_deposito.Text = .Item("ds_obs_deposito").ToString
                    txt_ds_batch.Text = .Item("ds_obs_batch").ToString
                    txt_lacres.Text = .Item("ds_obs_lacres").ToString
                    txt_observacao.Text = .Item("ds_observacao").ToString

                    lbl_data_solicitacao.Text = Format(DateTime.Parse(.Item("dt_solicitacao_nf").ToString), "dd/MM/yyyy hh:mm").ToString
                    lbl_nm_usuario.Text = .Item("nm_usuario_solicitante").ToString
                    lbl_depto.Text = .Item("ds_depto").ToString
                    lbl_centro_custo.Text = .Item("ds_centro_custo").ToString
                    'Else
                    '    lbl_depto.Text = "DAL"
                    '    lbl_centro_custo.Text = "321018"

                    '    Dim usuario As New Usuario(Convert.ToInt32(Session("id_login")))
                    '    lbl_nm_usuario.Text = usuario.nm_usuario.ToString
                End If

                txt_qtde.Enabled = False
                txt_peso_liquido.Enabled = False
                txt_peso_bruto.Enabled = False
                txt_preco_unitario.Enabled = False
                txt_nota_origem.Enabled = False
                txt_nr_contrato.Enabled = False
                txt_nr_especie.Enabled = False
                txt_volume_material.Enabled = False
                lbl_valor_total.Enabled = False
                lbl_valor_total_nota.Enabled = False
                txt_ds_deposito.Enabled = False
                txt_ds_batch.Enabled = False
                txt_lacres.Enabled = False
                txt_observacao.Enabled = False

            End With

            'se situacao do romaneio saida for nf anexada ou finalizado... 
            If CInt(ViewState.Item("id_situacao_romaneio_saida").ToString) >= 8 Then
                lk_acao.Visible = True
                lk_acao.Enabled = True
                lk_AnexarDocumento.Enabled = False
            Else
                'se usuario tem acesso ao registro NF
                If ViewState.Item("acessoregistroNF") = True Then
                    Select Case CInt(ViewState.Item("id_situacao_romaneio_saida_nota").ToString)
                        Case 2 'NF Solicitada
                            lk_acao.Text = "Registrar Início Processo Nota Fiscal"
                            lk_acao.ToolTip = "Registrar o início do processo de geração da nota fiscal do ramaneio saída."
                            lk_acao.Visible = True
                            lk_acao.Enabled = True
                            lk_AnexarDocumento.Enabled = False
                            lk_AnexarDocumento.ToolTip = "Anexar documentos apenas disponível após registro do início do processo da nota fiscal."

                            'gridAnexos.Columns(7).Visible = False

                        Case 3 'NF em andamento
                            lk_acao.Text = "Liberar Nota Fiscal Anexada"
                            lk_acao.ToolTip = "Liberar Nota Fiscal Anexada e enviar e-mail para departamento responsável dar continuidade ao processo."
                            lk_acao.Visible = True
                            lk_acao.Enabled = True

                            lk_AnexarDocumento.Enabled = True
                            lk_AnexarDocumento.ToolTip = "Anexar documentos."

                            'gridAnexos.Columns(7).Visible = True
                            'ViewState.Item("excluirdocto") = "N"
                        Case 4 'NF Anexada - Aguardando CTE
                            lk_acao.Text = "Liberar CTE Anexado"
                            lk_acao.ToolTip = "Liberar CTE Anexado para departamento responsável dar continuidade ao processo."
                            lk_acao.Visible = True
                            lk_acao.Enabled = True

                            lk_AnexarDocumento.Enabled = True
                            lk_AnexarDocumento.ToolTip = "Anexar documentos."

                            'gridAnexos.Columns(7).Visible = True
                            'ViewState.Item("excluirdocto") = "C"

                    End Select
                Else
                    'se nao tem acesso ao processo de gerenciamento de nota fiscal

                    Select Case CInt(ViewState.Item("id_situacao_romaneio_saida_nota").ToString)
                        Case 2, 3 'NF Solicitada ou NF em andamento
                            lk_acao.Visible = False
                            lk_acao.Enabled = False

                            lk_AnexarDocumento.Enabled = False
                            lk_AnexarDocumento.ToolTip = "Anexar documentos CTE. Disponível após liberação e anexo da nota fiscal pelo departamento responsável."

                            gridAnexos.Columns(7).Visible = False

                        Case 4 'NF Anexada - Aguardando CTE
                            lk_acao.Text = "Liberar CTE Anexado"
                            lk_acao.ToolTip = "Liberar CTE Anexado para departamento responsável dar continuidade ao processo."
                            lk_acao.Visible = True
                            lk_acao.Enabled = True

                            lk_AnexarDocumento.Enabled = True
                            lk_AnexarDocumento.ToolTip = "Anexar documentos."

                            'gridAnexos.Columns(7).Visible = True
                            'ViewState.Item("excluirdocto") = "C"

                    End Select

                End If

            End If

            'grid
            Dim anexo As New RomaneioSaidaNotaAnexo
            anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")

            Dim dsdocumentos As DataSet = anexo.getRomaneioSaidaNotaAnexo()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridAnexos.Visible = True
                gridAnexos.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
                gridAnexos.DataBind()
            Else

                Dim dataRow As System.Data.DataRow = dsdocumentos.Tables(0).NewRow()
                dsdocumentos.Tables(0).Rows.InsertAt(dataRow, 0)
                gridAnexos.Visible = True
                gridAnexos.DataSource = Helper.getDataView(dsdocumentos.Tables(0), "")
                gridAnexos.DataBind()
                gridAnexos.Rows(0).Cells.Clear()
                gridAnexos.Rows(0).Cells.Add(New TableCell())
                gridAnexos.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridAnexos.Rows(0).Cells(0).Text = "Não existem documentos anexados!"
                gridAnexos.Rows(0).Cells(0).ColumnSpan = 7
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub lk_voltar_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar_footer.Click

        Response.Redirect("lst_romaneio_saida_nota_fiscal.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida"))

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("lst_romaneio_saida_nota_fiscal.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida"))

    End Sub


    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click

        'se situacao nota em andamento
        If ViewState.Item("id_situacao_romaneio_saida_nota").ToString.Equals("3") Then
            'id_origem = 2 NF
            Response.Redirect("frm_romaneio_saida_nota_anexo.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&id_origem=2&tela=frm_romaneio_saida_nota_fiscal.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)
        End If
        'se situacao nota nf anexada
        If ViewState.Item("id_situacao_romaneio_saida_nota").ToString.Equals("4") Then
            'id_origem = 3 CTE
            Response.Redirect("frm_romaneio_saida_nota_anexo.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&id_origem=3&tela=frm_romaneio_saida_nota_fiscal.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)
        End If


    End Sub


    Protected Sub txt_preco_unitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_preco_unitario.TextChanged
        If Not txt_preco_unitario.Text.Equals(String.Empty) Then
            If Not txt_qtde.Text.Equals(String.Empty) Then
                lbl_valor_total.Text = FormatNumber(Round(CDec(txt_preco_unitario.Text) * CDec(txt_qtde.Text), 2), 2).ToString
                lbl_valor_total_nota.Text = lbl_valor_total.Text
            End If
        Else
            lbl_valor_total.Text = String.Empty
            lbl_valor_total_nota.Text = String.Empty
        End If

    End Sub


    Protected Sub lk_acao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_acao.Click
        If Page.IsValid Then
            Dim lbok As Boolean = False
            Try
                Dim romaneio As New RomaneioSaidaNota
                romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                romaneio.id_romaneio_saida_nota = ViewState.Item("id_romaneio_saida_nota")
                romaneio.id_modificador = Session("id_login")

                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_menu_item = 251
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida_nota")
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida_nota")

                Select Case lk_acao.Text
                    Case "Registrar Início Processo Nota Fiscal"

                        romaneio.registrarNotaFiscalEmAndamento()
                        usuariolog.ds_nm_processo = String.Concat("Romaneio Saida ", ViewState.Item("id_romaneio_saida").ToString, " - Registro NF em Andamento")
                        usuariolog.insertUsuarioLog()
                        messageControl.Alert("Registro de início de processo de Nota Fiscal realizado com sucesso!")

                    Case "Liberar Nota Fiscal Anexada"

                        romaneio.registrarNotaFiscalLiberadaNF()
                        usuariolog.ds_nm_processo = String.Concat("Romaneio Saida ", ViewState.Item("id_romaneio_saida").ToString, " - Registro NF Anexada - Aguardando CTE")
                        usuariolog.insertUsuarioLog()

                        lbok = True
                        'ENVIO DE EMAIL *******************************************************************
                        Dim notificacao As New Notificacao
                        Dim lAssunto As String = String.Concat("Nota Fiscal do Romaneio Saída ", ViewState.Item("id_romaneio_saida").ToString, " está liberada.")
                        Dim lCorpo As String = String.Concat("A Nota Fiscal referente ao romaneio de saída ", ViewState.Item("id_romaneio_saida").ToString, " foi anexada e liberada para uso. O romaneio de saída está pendente aguardando o anexo do CTE. Acesse o MILKSYSTEM para dar andamento ao processo.")

                        usuariolog.id_tipo_log = 9 'e-mail
                        usuariolog.ds_nm_processo = String.Concat("Romaneio Saida ", ViewState.Item("id_romaneio_saida").ToString, " - Registro NF Anexada - Aguardando CTE")
                        usuariolog.insertUsuarioLog()

                        ' Parametro 27 - Romaneio Saida Nota Fiscal
                        If notificacao.enviaMensagemEmail(28, lAssunto, lCorpo, MailPriority.High) = True Then
                            messageControl.Alert("Nota Fiscal Anexada liberada com sucesso! O E-MAIL de aviso de liberação foi enviado aos destinatários com sucesso!")
                        Else
                            messageControl.Alert("Nota Fiscal Anexada liberada com sucesso! O E-MAIL de aviso de liberação ao departamento NÃO PODE SER ENVIADO. Verifique há destinatários cadastrados para este tipo de notificação.")
                        End If

                    Case "Liberar CTE Anexado"

                        romaneio.registrarNotaFiscalLiberadaCTE()
                        usuariolog.ds_nm_processo = String.Concat("Romaneio Saida ", ViewState.Item("id_romaneio_saida").ToString, " - Registro NF e CTE Anexados")
                        usuariolog.insertUsuarioLog()

                        messageControl.Alert("CTE liberado para uso com sucesso!")

                End Select

                loadData()
            Catch ex As Exception
                If lbok = True Then
                    loadData()
                    messageControl.Alert("Liberação realizada com sucesso! O E-MAIL de aviso de liberação ao departamento NÃO PODE SER ENVIADO. Verifique há destinatários cadastrados para este tipo de notificação.")
                Else
                    messageControl.Alert(ex.Message)

                End If
            End Try
        End If
    End Sub

    Protected Sub cv_acao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_acao.ServerValidate
        Try
            Dim lmsg As String
            Dim li As Integer = 0
            Dim lbpdf As Boolean = False
            Dim lbxml As Boolean = False

            args.IsValid = True

            Select Case lk_acao.Text

                Case "Liberar Nota Fiscal Anexada"

                    Dim anexo As New RomaneioSaidaNotaAnexo
                    Dim dsanexo As DataSet
                    Dim row As DataRow

                    anexo.id_origem = 2 'apenas anexos de solicitacao de nota
                    anexo.id_romaneio_saida_nota = ViewState.Item("id_romaneio_saida_nota")
                    dsanexo = anexo.getRomaneioSaidaNotaAnexo

                    For Each row In dsanexo.Tables(0).Rows
                        If CInt(row.Item("id_tipo_anexo").ToString) = 1 Then 'pdf
                            lbpdf = True
                        End If
                        If CInt(row.Item("id_tipo_anexo").ToString) = 2 Then 'xml
                            lbxml = True
                        End If
                    Next

                    If lbpdf = False Then
                        args.IsValid = False
                        lmsg = "O PDF da Nota Fiscal do Romaneio de Saída deve ser anexado."
                    End If

                    If lbxml = False Then
                        args.IsValid = False
                        lmsg = "O XML da Nota Fiscal do Romaneio de Saída deve ser anexado."
                    End If

                Case "Liberar CTE Anexado"

                    Dim anexo As New RomaneioSaidaNotaAnexo
                    Dim dsanexo As DataSet
                    Dim row As DataRow

                    anexo.id_origem = 3 'apenas anexos CTE
                    anexo.id_romaneio_saida_nota = ViewState.Item("id_romaneio_saida_nota")
                    dsanexo = anexo.getRomaneioSaidaNotaAnexo

                    For Each row In dsanexo.Tables(0).Rows
                        If CInt(row.Item("id_tipo_anexo").ToString) = 3 Then 'pdf
                            lbpdf = True
                        End If
                        If CInt(row.Item("id_tipo_anexo").ToString) = 4 Then 'xml
                            lbxml = True
                        End If
                    Next

                    If lbpdf = False Then
                        args.IsValid = False
                        lmsg = "O PDF do CTE do Romaneio de Saída deve ser anexado."
                    End If

                    If lbxml = False Then
                        args.IsValid = False
                        lmsg = "O XML do CTE do Romaneio de Saída deve ser anexado."
                    End If
            End Select


            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridAnexos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAnexos.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lid As String
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim lbl_id_tipo_anexo As Label = CType(e.Row.FindControl("lbl_id_tipo_anexo"), Label)
            Dim lbl_id_origem As Label = CType(e.Row.FindControl("lbl_id_origem"), Label)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = Me.gridAnexos.DataKeys(e.Row.RowIndex).Value.ToString

                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 11)
            End If

        End If

    End Sub
End Class
