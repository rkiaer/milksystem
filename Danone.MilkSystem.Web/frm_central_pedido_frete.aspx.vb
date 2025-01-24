Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_central_pedido_frete
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedido_frete.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_central_pedido") Is Nothing) Then

                ViewState.Item("id_central_pedido") = Request("id_central_pedido")
                ViewState.Item("id_central_pedido_transportador") = 0

                'combo transportador
                'transportador central
                Dim pessoa As New Pessoa
                pessoa.id_situacao = 1
                pessoa.st_transportador_central = "S"
                pessoa.st_acordo_aquisicao_insumos = "S"
                cbo_transportador.DataSource = pessoa.getTransportadorCentralByFilters()
                cbo_transportador.DataTextField = "nm_pessoa"
                cbo_transportador.DataValueField = "id_pessoa"
                cbo_transportador.DataBind()
                cbo_transportador.Items.Insert(0, New ListItem("[Selecione]", 0))

                tr_transportador.Visible = False

                'carrega cotações
                loadData()
            Else
                ViewState.Item("id_central_pedido") = "0"
                messageControl.Alert("Problemas na passagem de parâmetros. Contacte o administrador do sistema.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()


        Try

            Dim pedido As New Pedido()
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            Dim dspedido As DataSet = pedido.getPedidoByFilters
            With dspedido.Tables(0).Rows(0)

                'DADOS PEDIDO &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                lbl_id_central_pedido.Text = .Item("id_central_pedido")
                lbl_dt_pedido.Text = DateTime.Parse(.Item("dt_pedido")).ToString("dd/MM/yyyy")
                lbl_situacao_pedido.Text = .Item("nm_situacao_pedido").ToString
                lbl_total_pedido.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)

                lbl_nr_parcelas.Text = String.Concat(.Item("st_tipo_parcelamento").ToString, " - ", .Item("nr_qtde_parcelas").ToString)

                cbo_tipo_frete.SelectedValue = .Item("ds_tipofrete").ToString

                'DADOS PRODUTOR PROPRIEDADE &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                lbl_nm_produtor.Text = String.Concat(.Item("cd_produtor"), " - ", .Item("nm_produtor"))
                lbl_propriedade.Text = .Item("id_propriedade").ToString
                lbl_propriedade_matriz.Text = .Item("id_propriedade_matriz").ToString
                lbl_uf_cidade.Text = String.Concat(.Item("cd_uf").ToString, " - ", .Item("nm_cidade").ToString)


                'PARCEIRO DE INSUMOS ou TRANSPORTADOR &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                If .Item("id_grupo").ToString = "2" Then 'se o pedido é de fornecedor insumos
                    If .Item("nm_abreviado_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_parceiro.Text = .Item("ds_fornecedor")
                    Else
                        lbl_parceiro.Text = .Item("ds_abreviado_fornecedor")
                    End If
                    If .Item("cd_cnpj_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cpf_fornecedor").ToString
                    Else
                        lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cnpj_fornecedor").ToString
                    End If
                    If .Item("st_fornecedor_cif").ToString.Equals("S") Then
                        lbl_cif_parceiro.Text = "SIM"
                    Else
                        lbl_cif_parceiro.Text = "NÃO"
                    End If

                End If

                'ATAUALIZA VARIAVEIS PARA PROCESSO
                ViewState.Item("id_central_pedido_matriz") = .Item("id_central_pedido_matriz")
                ViewState.Item("id_situacao_pedido") = .Item("id_situacao_pedido") 'fran 01/05/2005 chamado 812
                ViewState.Item("id_fornecedor") = .Item("id_fornecedor")
                ViewState.Item("id_produtor") = .Item("id_pessoa")
                ViewState.Item("id_propriedade") = .Item("id_propriedade")
                ViewState.Item("id_cidade_destino") = .Item("id_cidade")
                ViewState.Item("id_estado_destino") = .Item("id_estado")
                ViewState.Item("id_propriedade_matriz") = .Item("id_propriedade_matriz")
                ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento") 'fran 14/05/2010 chamado 816
                ViewState.Item("nm_estabelecimento") = .Item("nm_estabelecimento") 'fran 14/05/2010 chamado 816
                ViewState.Item("dstipofrete") = .Item("ds_tipofrete")

            End With

            'DADOS DO ITEM &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            Dim itens As New PedidoItem
            itens.id_central_pedido = ViewState.Item("id_central_pedido").ToString
            Dim dsItens As DataSet = itens.getPedidoItensByFilters()
            With dsItens.Tables(0).Rows(0)

                lbl_cd_item.Text = .Item("cd_item").ToString
                lbl_item_nm.Text = .Item("nm_item").ToString
                lbl_item_un.Text = .Item("nm_unidade_medida").ToString
                lbl_item_categoria.Text = .Item("nm_categoria_item").ToString
                Select Case .Item("ds_tipo_medida").ToString
                    Case "G"
                        lbl_tipo_embalagem.Text = "Granel"
                    Case "S"
                        lbl_tipo_embalagem.Text = "Sacaria"
                    Case "O"
                        lbl_tipo_embalagem.Text = "Outros"
                End Select
                lbl_nr_qtde.Text = FormatNumber(.Item("nr_quantidade").ToString, 4)
                lbl_vl_unitario.Text = FormatNumber(.Item("nr_valor_unitario").ToString, 2)
                lbl_sacaria.Text = FormatNumber(.Item("nr_sacaria").ToString, 2)
                lbl_frete.Text = FormatNumber(.Item("nr_frete").ToString, 2)

                'atualiza variaveis item
                ViewState.Item("id_central_pedido_item") = .Item("id_central_pedido_item").ToString
                ViewState.Item("id_item") = .Item("id_item").ToString
                ViewState.Item("nr_quantidade_item") = CDec(.Item("nr_quantidade").ToString)
                ViewState.Item("st_parcelamento") = .Item("st_parcelamento")

            End With

            loadGridPedido()

            'CONTROLE VISUAL
            'Tudo da tela entra como enable false, com se fosse so consulta mesmo
            Select Case CInt(ViewState.Item("id_situacao_pedido").ToString)

                Case 1, 6 'em aberto ou aprovado

                    If cbo_tipo_frete.SelectedValue <> "D" Then
                        tr_transportador.Visible = False
                        cbo_tipo_frete.Enabled = True
                        btn_salvar_tipo_frete.ToolTip = String.Empty
                    Else

                        If ViewState.Item("TemPedidoFrete") = True Then
                            If ViewState.Item("PedidoFreteAtivo") = True Then
                                tr_transportador.Visible = False
                                cbo_tipo_frete.Enabled = False
                                btn_salvar_tipo_frete.ToolTip = "Para trocar o tipo de frete os pedidos de Transportador devem ser cancelados."
                            Else
                                tr_transportador.Visible = True
                                cbo_tipo_frete.Enabled = True
                                btn_salvar_tipo_frete.ToolTip = String.Empty
                            End If
                        Else
                            tr_transportador.Visible = True
                            cbo_tipo_frete.Enabled = True
                        End If

                    End If

                    'deixa tudo aberto
                Case Else
                    tr_transportador.Visible = False
                    cbo_tipo_frete.Enabled = False
                    btn_salvar_tipo_frete.Enabled = False
                    btn_salvar_tipo_frete.Visible = False
            End Select




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString())


    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub loadGridPedido()
        Try

            Dim pedido As New Pedido

            pedido.id_central_pedido_matriz = CInt(ViewState.Item("id_central_pedido"))
            pedido.st_tipo_fornecedor = "T"

            Dim dspedido As DataSet = pedido.getCentralPedidoseSeusItensbyFilter

            'Carrega os dados do Grid
            Dim entrega As New PedidoEntrega
            If dspedido.Tables(0).Rows.Count > 0 Then
                ViewState.Item("PedidoFreteAtivo") = False
                ViewState.Item("TemPedidoFrete") = True

                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dspedido.Tables(0), "id_central_pedido desc")
                gridpedidos.DataBind()
            Else
                ViewState.Item("TemPedidoFrete") = False
                ViewState.Item("PedidoFreteAtivo") = False
                Dim dr As DataRow = dspedido.Tables(0).NewRow()
                dspedido.Tables(0).Rows.InsertAt(dr, 0)
                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dspedido.Tables(0), "")
                gridpedidos.DataBind()
                gridpedidos.Rows(0).Cells.Clear()
                gridpedidos.Rows(0).Cells.Add(New TableCell())
                gridpedidos.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridpedidos.Rows(0).Cells(0).Text = "Não há nenhum pedido de Frete incluido."
                gridpedidos.Rows(0).Cells(0).ColumnSpan = 15
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub EnviarEmailTecnicoAprovacao()
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    'Dim lAssunto As String = String.Concat("Aprovação de Cotações Central de Compras para Propriedade ", , " - ", lbl_nm_propriedade.Text.Trim & ".")
                    Dim lCorpo As String

                    lCorpo = "Existem cotações realizadas pela Central de Compras do Produtor "
                    lCorpo = lCorpo & "'" & lbl_nm_produtor.Text.Trim & "' para a Propriedade "
                    'lCorpo = lCorpo & "'" & String.Concat(txt_id_propriedade.Text.Trim, " - ", lbl_nm_propriedade.Text.Trim) & "', "
                    lCorpo = lCorpo & " pendentes para serem aprovadas por você, técnico responsável."

                    ' Parametro 7 - Central Cotacao 1.o Nível Gestor (enviar aos Tecnicos) 
                    'If notificacao.enviaMensagemEmail(7, lAssunto, lCorpo, MailPriority.High) = True Then

                    'messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade foi enviada aos destinatários com sucesso!")
                    'Else

                    'messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")
                    'img_notificacao.Visible = True
                    'lk_email_produtor.Visible = True

                    'End If


                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Protected Sub cv_pedido_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido.ServerValidate

    '    Try
    '        Dim lmsg As String
    '        Dim lvalid As Boolean
    '        Dim pedido As New Pedido
    '        Dim dspedido As DataSet
    '        Dim row As DataRow
    '        args.IsValid = True
    '        pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))


    '        If CInt(ViewState.Item("id_grupo")) <> 3 Then 'fran 30/07/2010 i chamado 682
    '            'Busca a somatoria das qtde previstas de ntrega de cada item do pedido
    '            dspedido = pedido.getCentralPedidoConsSomaQtdePrevista
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                For Each row In dspedido.Tables(0).Rows
    '                    'se a qtde do pedido subtraindo a soma da qtde prevista para o item for diferente de zero
    '                    If Convert.ToDecimal(row.Item("qtde")) <> 0 Then
    '                        args.IsValid = False
    '                        lmsg = "O somatório da 'Qtde Prevista' está diferente da quantidade informada para o item " & row.Item("nm_item").ToString & "."
    '                        Exit For
    '                    End If
    '                Next
    '            Else
    '                args.IsValid = False
    '                lmsg = "A quantidade prevista para Entregas deve ser informada!"
    '            End If
    '        End If
    '        'fran chamado 945 i 25/08/2010 - não deve consistir o somatorio das prcelas com o valor total do item nem para fornecedor nem para produtor
    '        'If args.IsValid = True Then

    '        '    'Busca a somatoria do valor das parcelas  e subtrai peo valor total do item
    '        '    dspedido = pedido.getCentralPedidoConsSomaValorFornecedor
    '        '    If dspedido.Tables(0).Rows.Count > 0 Then
    '        '        For Each row In dspedido.Tables(0).Rows
    '        '            'se o valor total do item do pedido subtraindo a soma do valor da parcelas para o item for diferente de zero
    '        '            If Convert.ToDecimal(row.Item("valor")) <> 0 Then
    '        '                args.IsValid = False
    '        '                lmsg = "Para o item " & row.Item("nm_item").ToString & ", o somatório do valor das parcelas do 'Pagamento ao Fonecedor' está diferente do valor total informado no pedido."
    '        '                Exit For
    '        '            End If
    '        '        Next
    '        '    Else
    '        '        args.IsValid = False
    '        '        lmsg = "O valor das parcelas do Pagamento ao Fornecedor deve ser informado!"
    '        '    End If
    '        'End If
    '        'If CInt(ViewState.Item("id_grupo")) <> 3 Then 'se diferente de transportador 'fran 30/07/2010 i chamado 682

    '        '    If args.IsValid = True Then
    '        '        'Busca a somatoria do valor das parcelas  e subtrai peo valor total do item
    '        '        dspedido = pedido.getCentralPedidoConsSomaValorProdutor
    '        '        If dspedido.Tables(0).Rows.Count > 0 Then
    '        '            For Each row In dspedido.Tables(0).Rows
    '        '                'se o valor total do item do pedido subtraindo a soma do valor da parcelas para o item for diferente de zero
    '        '                If Convert.ToDecimal(row.Item("valor")) <> 0 Then
    '        '                    args.IsValid = False
    '        '                    lmsg = "Para o item " & row.Item("nm_item").ToString & ", o somatório do valor das parcelas do 'Desconto ao Produtor' está diferente do valor total informado no pedido."
    '        '                    Exit For
    '        '                End If
    '        '            Next
    '        '        Else
    '        '            args.IsValid = False
    '        '            lmsg = "O valor das parcelas do Desconto ao Produtor deve ser informado!"
    '        '        End If
    '        '    End If
    '        'End If
    '        'fran chamado 945 f
    '        If args.IsValid = True Then
    '            'Busca se existe data de pagamento repetidas 
    '            dspedido = pedido.getCentralPedidoConsDataFornecedor
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                'se tem linhas, tem datas repetias
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    'lmsg = "As datas de pagamento para o 'Pagamento ao Fornecedor' do item " & row.Item("nm_item").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
    '                    lmsg = "As datas de pagamento para o 'Pagamento ao Fornecedor' do item " & row.Item("nm_item").ToString & ", nr de nota " & row.Item("nr_nota_fiscal").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
    '                    Exit For
    '                Next
    '            End If
    '        End If
    '        'fran 25/08/2010 i chamado 946 - o pedido de transportador tb terá desconto ao produtor
    '        'If CInt(ViewState.Item("id_grupo")) <> 3 Then 'fran 30/07/2010 i chamado 682
    '        'fran 25/08/2010 f chamado 946 - o pedido de transportador tb terá desconto ao produtor

    '        'fran 10/03/2010 i chamado 686
    '        'fran fase 3 i 
    '        'If args.IsValid = True  Then
    '        If args.IsValid = True Then
    '            If ViewState.Item("ReabrirPedido") = "N" Then
    '                If ViewState.Item("pedidoindireto") = "N" Then

    '                    'fran fase 3 f
    '                    'Busca a quantidade de  parcelas informadas em cotação e o count das parcelas informadas para pedido
    '                    dspedido = pedido.getCentralPedidoConsParcelas
    '                    If dspedido.Tables(0).Rows.Count > 0 Then
    '                        Dim lqtde_parcelas As Integer
    '                        Dim lnr_parcelas As Integer
    '                        Dim lnr_nota_fiscal As Int64
    '                        For Each row In dspedido.Tables(0).Rows
    '                            lqtde_parcelas = row.Item("qtde_parcelas")
    '                            lnr_parcelas = row.Item("nr_parcelas")
    '                            lnr_nota_fiscal = row.Item("nr_nota_fiscal")
    '                            'se parcela informada em cotacao é 0 (a vista) ou 1 parcela (á vista) e a qtde parcelas incluidas no grid for maior que 1
    '                            If (lnr_parcelas = 0 Or lnr_parcelas = 1) And lqtde_parcelas > 1 Then
    '                                args.IsValid = False
    '                                lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser feito em apenas 1 vez, conforme informado na Cotação."
    '                                Exit For
    '                            End If
    '                            'assume que se veio parcelas = 0 significa que aomenos tem 1 parcela
    '                            If lnr_parcelas = 0 Then
    '                                lnr_parcelas = 1
    '                            End If
    '                            'se a atde parcelas incluidas for maior que as parcelas informadas na cotação
    '                            If lqtde_parcelas > lnr_parcelas Then
    '                                args.IsValid = False
    '                                lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser no máximo de " & lnr_parcelas & " parcelas, conforme informado na Cotação."
    '                                Exit For
    '                            End If
    '                        Next
    '                    Else

    '                        args.IsValid = False
    '                        lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
    '                    End If
    '                End If
    '            Else

    '                'fran 08/2015 i
    '                'Busca a quantidade de  parcelas informadas em cotação e o count das parcelas informadas para pedido
    '                dspedido = pedido.getCentralPedidoConsParcelasbyItem
    '                If dspedido.Tables(0).Rows.Count > 0 Then
    '                    Dim lqtde_parcelas As Integer
    '                    Dim lnr_parcelas As Integer
    '                    For Each row In dspedido.Tables(0).Rows
    '                        lqtde_parcelas = row.Item("qtde_parcelas")
    '                        lnr_parcelas = row.Item("nr_parcelas")
    '                        'se parcela informada em parcelamento é 0 (a vista) ou 1 parcela (á vista) e a qtde parcelas incluidas no grid for maior que 1
    '                        If (row.Item("st_parcelamento").Equals("N")) And lqtde_parcelas > 1 Then
    '                            args.IsValid = False
    '                            lmsg = "Para o item " & row.Item("nm_item").ToString & ", o parcelamento do Desconto ao Produtor deve ser feito em apenas 1 vez, conforme informado no campo Parcelamento. Caso necessário, altere o campo parcelamento e clique em 'Atualizar Parcelamento'."
    '                            Exit For
    '                        End If
    '                    Next
    '                Else

    '                    args.IsValid = False
    '                    lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
    '                End If


    '                'fase 3 09/2014 i 
    '                'Se esta reabrindo pedido.... Deixa aumentar ou retirar parcelas.... contanto que o valor da nota bata com total
    '                'Porém se parcelamento for DANONE, deve respoeitar total de parcelas informada no parametro 
    '                dspedido = pedido.getCentralPedidoTotalParcelasByPedido 'Busca da VIEWTOTALPARCELAS o total de parcelas por ITEM
    '                If dspedido.Tables(0).Rows.Count > 0 Then
    '                    'rever fran 2023
    '                    ' ''For Each row In dspedido.Tables(0).Rows
    '                    ' ''    'se o parcelamento do item é DANONE, deve respeitar o limite de parcelas do parametro
    '                    ' ''    If row.Item("st_parcelamento").ToString.Equals("D") Then
    '                    ' ''        If CInt(row.Item("nr_total_parcela").ToString) > CInt(ViewState.Item("nr_politica_parcelas").ToString) Then
    '                    ' ''            args.IsValid = False
    '                    ' ''            lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser no máximo de " & ViewState.Item("nr_politica_parcelas").ToString & " parcelas, de acordo com a Política de Parcelas para Danone."
    '                    ' ''            Exit For
    '                    ' ''        End If
    '                    ' ''    End If
    '                    ' ''Next
    '                Else
    '                    args.IsValid = False
    '                    lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
    '                End If
    '                'fase 3 09/2014 f 
    '            End If
    '        End If
    '        'fran 10/03/2010 f
    '        If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
    '            'Busca se existe data de pagamento repetidas 
    '            dspedido = pedido.getCentralPedidoConsDataProdutor
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                'se tem linhas, tem datas repetias
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    'lmsg = "As datas de pagamento para o 'Desconto ao Produtor' do item " & row.Item("nm_item").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
    '                    lmsg = "As datas de pagamento para o 'Desconto ao Produtor' do item " & row.Item("nm_item").ToString & ", nr de nota " & row.Item("nr_nota_fiscal").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
    '                    Exit For
    '                Next
    '            End If
    '        End If
    '        'End If 'fran 25/08/2010 i chamado 946 - o pedido de transportador tb terá desconto ao produtor
    '        'fran 10/05/2010 i chamado 817
    '        If args.IsValid = True Then
    '            'Verifica se há o mesmo nr nota com valores diferentes
    '            dspedido = pedido.getCentralPedidoConsNotaVlDiferenteFornec
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                'se tem linhas, tem notas com valores diferentes
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    'lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
    '                    lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
    '                    Exit For
    '                Next
    '            End If
    '        End If
    '        If args.IsValid = True Then
    '            'Verifica se há o mesmo nr nota com valores diferentes
    '            dspedido = pedido.getCentralPedidoConsNotaSerieEmissaoFornec
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                'se tem linhas, tem notas com valores diferentes
    '                For Each row In dspedido.Tables(0).Rows
    '                    If CInt(row.Item("count_serie")) > 1 Then
    '                        args.IsValid = False
    '                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Série' com valores diferentes.")
    '                        Exit For
    '                    End If
    '                    If CInt(row.Item("count_data")) > 1 Then
    '                        args.IsValid = False
    '                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Emissão' com valores diferentes.")
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        End If
    '        If args.IsValid = True Then
    '            'Verifica se a soma das parcelas para um nr nota é igual ao vl da nota
    '            dspedido = pedido.getCentralPedidoConsSomaParcComVlNotaFornec
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                For Each row In dspedido.Tables(0).Rows
    '                    If row.Item("valor_nota_fiscal") > 0 Then
    '                        If row.Item("valor") <> 0 Then 'se tem diferença
    '                            args.IsValid = False
    '                            'lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
    '                            lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
    '                            Exit For

    '                        End If
    '                    End If
    '                Next
    '            Else
    '                'fran -8/2015i
    '                'se não tem linhas de fornecedor
    '                args.IsValid = False
    '                lmsg = String.Concat("Para finalizar o pedido, Pagamento ao Fornecedor deve ser informado!")

    '                'fran -8/2015f

    '            End If
    '        End If
    '        'fran 10/05/2010 f chamado 817

    '        'fran 25/08/2010 i chamado 945
    '        If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then
    '            'Verifica se há o mesmo nr nota com valores diferentes
    '            dspedido = pedido.getCentralPedidoConsNotaVlDiferenteProdutor
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                'se tem linhas, tem notas com valores diferentes
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Desconto ao Produtor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
    '                    Exit For
    '                Next
    '            End If
    '        End If
    '        If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then
    '            'Verifica se a soma das parcelas para um nr nota é igual ao vl da nota
    '            dspedido = pedido.getCentralPedidoConsSomaParcComVlNotaProdutor
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                For Each row In dspedido.Tables(0).Rows
    '                    If row.Item("valor_nota_fiscal") > 0 Then
    '                        If row.Item("valor") <> 0 Then 'se tem diferença
    '                            args.IsValid = False
    '                            lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Desconto ao Produtor, o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
    '                            Exit For

    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If
    '        'fran 25/08/2010 f chamado 945

    '        'fran 08/2015 i
    '        If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
    '            'Verifica se o nr nota existe nos dois grids fornecedor e produtor 
    '            dspedido = pedido.getCentralPedidoConsNrNotaFornecProd
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " os mesmos números de Nota Fiscal devem ser informados para Desconto ao Produtor e Pagamento ao Fornecedor.")
    '                    Exit For
    '                Next
    '            End If
    '        End If

    '        If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
    '            'Verifica se o valor nota é o mesmo para dois grids fornecedor e produtor 
    '            dspedido = pedido.getCentralPedidoConsValorNotaFornecProd
    '            If dspedido.Tables(0).Rows.Count > 0 Then
    '                For Each row In dspedido.Tables(0).Rows
    '                    args.IsValid = False
    '                    lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " o valor da Nota Fiscal " & row.Item("nr_nota_fiscal").ToString, " está divergente entre Desconto ao Produtor e Pagamento ao Fornecedor.")
    '                    Exit For
    '                Next
    '            End If
    '        End If

    '        'fran 08/2015 f


    '        If Not args.IsValid Then
    '            messageControl.Alert(lmsg)
    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub
 

 

    Protected Sub cv_pedido_itens_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido_itens.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String

            'If cbo_vai_parcelar.SelectedValue = "D" AndAlso CInt(ViewState.Item("nr_politica_parcelas")) < txt_nr_parcelas.Text Then
            '    lmsg = String.Concat("O número de parcelas informado para o pedido execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
            '    args.IsValid = False
            'End If
            If cbo_tipo_frete.SelectedValue <> "D" Then 'se for diferente de Frete FOB_D
                args.IsValid = False
                lmsg = "Para geração de pedido de frete o  Tipo do Frete deve ser FOB-D."
            End If
            If cbo_transportador.SelectedValue = 0 Then
                lmsg = "O Transportador deve ser informado para o tipo de frete FOB-D."
                args.IsValid = False
            End If

            If txt_nr_frete.Text.Equals(String.Empty) OrElse CDec(txt_nr_frete.Text) = 0 Then
                lmsg = "O Valor do Frete deve ser informado para o tipo de frete FOB-D."
                args.IsValid = False
            End If

            If ViewState.Item("TemPedidoFrete") = True AndAlso ViewState.Item("PedidoFreteAtivo") = True Then
                lmsg = "Não pode gerar um novo pedido de frete porque já existe Pedido ativo."
                args.IsValid = False

            End If


            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)
            End If



        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub txt_nr_frete_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_frete.TextChanged
        lbl_inf_frete.Text = String.Empty
        ViewState.Item("id_central_tabela_frete_veiculos") = 0
        ViewState.Item("id_veiculo_central_compras") = 0

        'se tem quantidade e valor frete
        If Not txt_nr_frete.Text.Equals(String.Empty) Then
            lbl_total_frete.Text = FormatCurrency((CDec(txt_nr_frete.Text) * CDec(ViewState.Item("nr_quantidade_item"))).ToString, 2).ToString()
        Else
            lbl_total_frete.Text = FormatCurrency(0, 2).ToString
        End If

    End Sub

    Protected Sub gridpedidos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridpedidos.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "cancelarpedido"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim nm_estabelecimento As Label = CType(row.FindControl("nm_estabelecimento"), Label)
                Dim nr_unid_producao As Label = CType(row.FindControl("nr_unid_producao"), Label)
                Dim id_propriedade As Label = CType(row.FindControl("id_propriedade"), Label)
                Dim id_produtor As Label = CType(row.FindControl("id_produtor"), Label)
                Dim id_fornecedor As Label = CType(row.FindControl("id_fornecedor"), Label)
                Dim nm_pedido_cancelar_motivo As Label = CType(row.FindControl("lbl_nm_pedido_cancelar_motivo"), Label)

                'EnvioEmailCancelamentoFornecedor(Convert.ToInt32(e.CommandArgument.ToString), Convert.ToInt32(id_propriedade.Text), Convert.ToInt32(id_produtor.Text), Convert.ToInt32(id_fornecedor.Text), nm_estabelecimento.Text.ToString, nr_unid_producao.Text.ToString, nm_pedido_cancelar_motivo.Text.ToString)

                If Page.IsValid = True Then
                    Try

                        If (Not (row) Is Nothing) Then

                            Dim pedido As New Pedido
                            Dim cbo_pedido_cancelar_motivo As Anthem.DropDownList = CType(row.FindControl("cbo_pedido_cancelar_motivo"), Anthem.DropDownList)
                            pedido.id_central_pedido = Convert.ToInt32(gridpedidos.DataKeys.Item(row.RowIndex).Value)
                            pedido.id_pedido_cancelar_motivo = Convert.ToInt32(cbo_pedido_cancelar_motivo.SelectedValue)
                            pedido.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                            pedido.id_modificador = Session("id_login")

                            'FRAN 08/12/2020 i incluir log 
                            Dim usuariolog As New UsuarioLog
                            usuariolog.id_usuario = Session("id_login")
                            usuariolog.ds_id_session = Session.SessionID.ToString()
                            usuariolog.id_tipo_log = 6 'processo
                            usuariolog.id_menu_item = 97
                            usuariolog.ds_nm_processo = "Pedido - Atualização Frete Cancelar"
                            usuariolog.id_nr_processo = pedido.id_central_pedido
                            usuariolog.insertUsuarioLog()
                            'FRAN 08/12/2020  incluir log 

                            If pedido.cancelarPedido() = True Then
                                ViewState.Item("id_central_pedido_transportador") = 0
                                messageControl.Alert(String.Concat("Pedido ", pedido.id_central_pedido.ToString, " cancelado com sucesso!"))
                            Else
                                messageControl.Alert("Ocorreram problemas no cancelamento do Pedido. Contate o administrador do sistema.")
                            End If

                            'grdresults.EditIndex = -1
                            loadData()
                        End If

                    Catch ex As Exception
                        messageControl.Alert(ex.Message)
                    End Try
                End If

            Case "EnviarEmail"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim nm_estabelecimento As Label = CType(row.FindControl("nm_estabelecimento"), Label)
                Dim nr_unid_producao As Label = CType(row.FindControl("nr_unid_producao"), Label)
                Dim id_propriedade As Label = CType(row.FindControl("id_propriedade"), Label)
                Dim id_produtor As Label = CType(row.FindControl("id_produtor"), Label)
                Dim id_fornecedor As Label = CType(row.FindControl("id_fornecedor"), Label)
                Dim nm_pedido_cancelar_motivo As Label = CType(row.FindControl("lbl_nm_pedido_cancelar_motivo"), Label)

                EnvioEmailCancelamentoFornecedor(Convert.ToInt32(e.CommandArgument.ToString), Convert.ToInt32(ViewState.Item("id_propriedade")), Convert.ToInt32(ViewState.Item("id_produtor")), Convert.ToInt32(id_fornecedor.Text), ViewState.Item("nm_estabelecimento").ToString, "1", nm_pedido_cancelar_motivo.Text.ToString)


        End Select


    End Sub

    Protected Sub gridpedidos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpedidos.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso ViewState.Item("TemPedidoFrete") = True Then
            'AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim cbo_pedido_cancelar_motivo As DropDownList = CType(e.Row.FindControl("cbo_pedido_cancelar_motivo"), DropDownList)
                Dim motivo As New PedidoCancelarMotivo

                cbo_pedido_cancelar_motivo.DataSource = motivo.getPedidoCancelarMotivoByFilters()
                cbo_pedido_cancelar_motivo.DataTextField = "nm_pedido_cancelar_motivo"
                cbo_pedido_cancelar_motivo.DataValueField = "id_pedido_cancelar_motivo"
                cbo_pedido_cancelar_motivo.DataBind()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub gridpedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpedidos.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) AndAlso ViewState.Item("TemPedidoFrete") = True Then
                Dim hl_id_pedido As Anthem.HyperLink = CType(e.Row.FindControl("hl_id_pedido"), Anthem.HyperLink)
                Dim lbl_id_situacao_pedido As Label = CType(e.Row.FindControl("lbl_id_situacao_pedido"), Label)
                Dim lbl_id_pedido_cancelar_motivo As Label = CType(e.Row.FindControl("lbl_id_pedido_cancelar_motivo"), Label)
                Dim btn_salvar As ImageButton = CType(e.Row.FindControl("btn_salvar"), ImageButton)
                Dim cbo_pedido_cancelar_motivo As DropDownList = CType(e.Row.FindControl("cbo_pedido_cancelar_motivo"), DropDownList)
                Dim btn_envio_email As ImageButton = CType(e.Row.FindControl("btn_envio_email"), ImageButton)

                'lbl_nr_valor_mensal_estimado.Text = saldoDisponivel.nr_valor_faturamento.ToString
                If Not hl_id_pedido.Text = String.Empty Then
                    hl_id_pedido.Visible = True
                    hl_id_pedido.NavigateUrl = String.Format("frm_central_pedido.aspx?id_central_pedido={0}", hl_id_pedido.Text)
                Else
                    hl_id_pedido.Visible = False
                End If

                If cbo_pedido_cancelar_motivo.Items(0).Text <> "[Selecione]" Then
                    cbo_pedido_cancelar_motivo.Items.Insert(0, New ListItem("[Selecione]", 0))
                End If
                If lbl_id_pedido_cancelar_motivo.Text.Equals(String.Empty) OrElse lbl_id_pedido_cancelar_motivo.Text.Equals("0") Then
                    cbo_pedido_cancelar_motivo.SelectedValue = 0
                Else
                    cbo_pedido_cancelar_motivo.SelectedValue = lbl_id_pedido_cancelar_motivo.Text
                End If

                'se o pedido principla é aberto ou aprovado
                If ViewState.Item("id_situacao_pedido") = "1" OrElse ViewState.Item("id_situacao_pedido") = "6" Then

                    'Tudo da tela entra como enable false, com se fosse so consulta mesmo
                    Select Case CInt(lbl_id_situacao_pedido.Text)
                        Case 1, 6 'em aberto ou aprovado
                            btn_salvar.Enabled = True
                            btn_salvar.Visible = True
                            btn_envio_email.Enabled = False
                            btn_envio_email.Visible = False
                            btn_envio_email.ImageUrl = "~/img/ico_email_desabilitado.gif"
                            cbo_pedido_cancelar_motivo.Enabled = True

                            ViewState.Item("PedidoFreteAtivo") = True

                            'deixa tudo aberto
                        Case 2 'cancelado
                            btn_salvar.Visible = False
                            btn_envio_email.Visible = True
                            btn_envio_email.ImageUrl = "~/img/ico_email.gif"
                            btn_envio_email.Enabled = True
                            cbo_pedido_cancelar_motivo.Enabled = False

                        Case Else '3,8,  'finalizado ou finalizado parcial ou qualquer outra situação nao pode fazer nenhuma alteracao
                            btn_salvar.Enabled = False
                            btn_salvar.Visible = False
                            btn_envio_email.Enabled = False
                            btn_envio_email.Visible = False
                            btn_envio_email.ImageUrl = "~/img/ico_email_desabilitado.gif"
                            cbo_pedido_cancelar_motivo.Enabled = False
                            ViewState.Item("PedidoFreteAtivo") = True


                    End Select
                Else
                    If lbl_id_situacao_pedido.Text.Equals("2") Then 'se pedido já cancelado
                        btn_salvar.Enabled = False
                        btn_salvar.Visible = False
                        btn_envio_email.Visible = True
                        btn_envio_email.ImageUrl = "~/img/ico_email.gif"
                        btn_envio_email.Enabled = True
                        cbo_pedido_cancelar_motivo.Enabled = False
                    Else
                        btn_salvar.Enabled = False
                        btn_salvar.Visible = False
                        btn_envio_email.Enabled = False
                        btn_envio_email.Visible = False
                        btn_envio_email.ImageUrl = "~/img/ico_email_desabilitado.gif"

                        ViewState.Item("PedidoFreteAtivo") = True

                    End If

                End If

            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub EnvioEmailCancelamentoFornecedor(ByVal id_central_pedido As Int32, ByVal id_propriedade As Int32, ByVal id_produtor As Int32, ByVal id_fornecedor As Int32, ByVal nm_estabelecimento As String, ByVal nr_unid_producao As String, ByVal nm_pedido_cancelar_motivo As String)

        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
        Dim propriedade As New Propriedade(Convert.ToInt32(id_propriedade))
        Dim produtor As New Pessoa(Convert.ToInt32(id_produtor))
        Dim fornecedor As New Pessoa(Convert.ToInt32(id_fornecedor))
        Dim lemail_parceiro As String
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")

        lemail_parceiro = fornecedor.ds_email
        If lemail_parceiro.Equals(String.Empty) Then
            If Not fornecedor.ds_email2 Is Nothing Then
                lemail_parceiro = fornecedor.ds_email2
            Else
                lemail_parceiro = String.Empty

            End If
        End If
        'lemail_parceiro = "franoliveira@hotmail.com"
        If Not lemail_parceiro.Equals(String.Empty) Then
            'lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", id_central_pedido.ToString) fran 19/12/2013
            lassunto = String.Concat("DANONE - Cancelamento Pedido de Compra ", "Nr ", id_central_pedido.ToString)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_fornecedor_cancelamento.HTML", Encoding.UTF7)
            lcorpo = ""
            Do While Not arqTemp.EndOfStream
                lcorpo = lcorpo & arqTemp.ReadLine
            Loop

            lcorpo = Replace(lcorpo, "$nm_estabelecimento", nm_estabelecimento.ToString)
            lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            lcorpo = Replace(lcorpo, "$id_pedido", id_central_pedido.ToString)
            lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
            lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
            lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)
            ' Adriana 10/12/2010 - Erro reportado em reunião do dia 08/12/2010 - i
            lcorpo = Replace(lcorpo, "$nm_pedido_cancelar_motivo", nm_pedido_cancelar_motivo.ToString)
            ' Adriana 10/12/2010 - Erro reportado em reunião do dia 08/12/2010 - f

            lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
            lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
            lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
            lcorpo = Replace(lcorpo, "$nr_unid_producao", nr_unid_producao.ToString)
            lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
            lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
            lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
            If produtor.st_categoria = "F" Then
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
            Else
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
            End If
            lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
            lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
            lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)


            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(id_central_pedido)
            Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
            Dim row As DataRow
            Dim ltable As String = String.Empty
            Dim i As Integer = 1
            For Each row In dsgrid.Tables(0).Rows
                If i > 1 Then
                    ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
                End If
                ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
                ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                If fornecedor.id_grupo <> 3 Then 'se o fornecedor for transportador de frete não exibe valor unitario e sacaria
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Unitário:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_unitario"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Sacaria:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_sacaria"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                End If

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"

                'lcorpo = Replace(lcorpo, "$itens", i.ToString)
                i = i + 1
            Next


            lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'envio e-mail
                usuariolog.id_menu_item = 97
                usuariolog.ds_nm_processo = "Pedido De Frete - Cancelar"
                usuariolog.id_nr_processo = id_central_pedido.ToString
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            Dim notificacao As New Notificacao
            arqTemp.Close()
            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
                messageControl.Alert("Email enviado ao parceiro com sucesso!")
            Else

                messageControl.Alert("Email ao parceiro não foi enviado com sucesso!")

            End If
        Else
            messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastrado do Parceiro!")
        End If

    End Sub

    Protected Sub btn_gerar_pedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_gerar_pedido.Click
        If Page.IsValid Then
            Try
                If ViewState.Item("id_central_pedido_transportador") = 0 Then
                    Dim pedido As New Pedido
                    Dim lmsg As String = String.Empty

                    'preparar dados do grid de itens
                    Dim dstable As New DataTable
                    Dim ilinha As Integer

                    dstable.Columns.Add("nr_frete")
                    dstable.Columns.Add("id_central_tabela_frete_veiculos")

                    ilinha = 0

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

                    With dstable.Rows.Item(ilinha)
                        .Item(0) = txt_nr_frete.Text
                        'se informação sobre tabela de frete for vazia, significa que nao uilizou tabela de frete do cadastro
                        If lbl_inf_frete.Text.Equals(String.Empty) Then
                            .Item(1) = "0"
                        Else
                            .Item(1) = ViewState.Item("id_central_tabela_frete_veiculos")
                        End If
                    End With

                    'ilinha = ilinha + 1

                    Pedido.id_central_pedido_matriz = ViewState.Item("id_central_pedido")
                    Pedido.id_transportador = cbo_transportador.SelectedValue
                    Pedido.nr_total_pedido_frete = CDec(ViewState.Item("nr_quantidade_item").ToString) * CDec(txt_nr_frete.Text)
                    Pedido.pedidoitens = dstable
                    Pedido.id_modificador = Session("id_login")

                    ViewState.Item("id_central_pedido_transportador") = Pedido.gerarPedidoTransportador()

                    If ViewState.Item("id_central_pedido_transportador") = 0 Then
                        Me.messageControl.Alert("Ocorreram problemas na inclusão do Pedido de Transportador. Contate o administrador do sistema.")
                    Else
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 6 'processo
                        usuariolog.id_menu_item = 97
                        usuariolog.ds_nm_processo = "Pedido - Gerar Pedido Frete"
                        usuariolog.id_nr_processo = ViewState.Item("id_central_pedido_transportador")

                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        btn_gerar_pedido.Enabled = False
                        btn_gerar_pedido.ToolTip = "Pedido gerado."
                        tr_transportador.Visible = False
                        lmsg = String.Concat("O Pedido do frete ", ViewState.Item("id_central_pedido_transportador").ToString, " foi gerado com sucesso!")
                        Me.messageControl.Alert(lmsg)
                        Response.Redirect("frm_central_pedido_frete.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString())
                    End If
                End If


                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub btn_salvar_tipo_frete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_tipo_frete.Click
        If Page.IsValid Then
            Try
                cbo_tipo_frete.ForeColor = System.Drawing.Color.FromName("#000000")

                If ViewState.Item("dstipofrete").ToString <> cbo_tipo_frete.SelectedValue.ToString Then

                    Dim pedido As New Pedido
                    pedido.id_central_pedido = ViewState.Item("id_central_pedido")
                    pedido.ds_tipofrete = cbo_tipo_frete.SelectedValue
                    pedido.id_modificador = Session("id_login")

                    pedido.updateCentralPedidoTipoFrete()

                    ViewState.Item("dstipofrete") = cbo_tipo_frete.SelectedValue

                    If cbo_tipo_frete.SelectedValue = "D" Then
                        tr_transportador.Visible = True
                        txt_nr_frete.Text = ""
                        lbl_total_frete.Text = ""
                        cbo_transportador.SelectedValue = 0
                    Else

                        tr_transportador.Visible = False
                        btn_salvar_tipo_frete.ToolTip = String.Empty

                    End If

                    messageControl.Alert("Tipo de Frete atualizado com sucesso!")
                    loadData()


                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub cv_salvar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_salvar.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String = ""


            Select Case ViewState.Item("id_situacao_pedido")
                Case 1, 6
                    'se for aberto ou aprovado poderia trocar frete

                    'e  tem pedido de frete e o pedido esta ativo
                    If ViewState.Item("TemPedidoFrete") = True And ViewState.Item("PedidoFreteAtivo") = True Then
                        lmsg = "O tipo de frete não pode ser atualizado pois existe pedido de frete ativo."
                    End If

                Case Else
                    lmsg = "O tipo de frete não pode ser atualizado porque a situação Pedido de Insumos é diferente de aprovado ou aberto. "
                    args.IsValid = False

            End Select

            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)
            End If



        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_lupa_frete_valor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_frete_valor.Click

        pnl_frete.Visible = False

        If cbo_transportador.SelectedValue = "0" Then
            Me.messageControl.Alert("Transportador deve ser selecionado para a busca da tabela de fretes.")
        Else

            Dim tabfrete As New TabelaFrete
            tabfrete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            tabfrete.id_fornecedor = cbo_transportador.SelectedValue
            tabfrete.id_item = ViewState.Item("id_item")
            tabfrete.id_estado_propriedade = ViewState.Item("id_estado_destino")
            tabfrete.id_cidade_propriedade = ViewState.Item("id_cidade_destino")

            Dim dsfrete As DataSet = tabfrete.getCentralTabelaFreteMax()
            If (dsfrete.Tables(0).Rows.Count <= 0) Then
                Me.messageControl.Alert("Não foram encontrados valores de frete ativos para o Transportador, item e cidade destino da propriedade!")
                'ViewState.Item("id_index_item_frete") = Nothing
                gridfrete.Visible = False
                'Dim dr As DataRow = dsfrete.Tables(0).NewRow()
                'dsfrete.Tables(0).Rows.InsertAt(dr, 0)
                'gridfrete.Visible = True
                'gridfrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                'gridfrete.DataBind()
                'gridfrete.Rows(0).Cells.Clear()
                'gridfrete.Rows(0).Cells.Add(New TableCell())
                'gridfrete.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                'gridfrete.Rows(0).Cells(0).ColumnSpan = 10
                'gridfrete.Rows(0).Cells(0).Text = "Não foram encontrados valores de frete ativos para o Transportador, item e cidade destino da propriedade!"
            Else
                'ViewState.Item("id_index_item_frete") = row.RowIndex
                pnl_frete.Visible = True
                lbl_detalhe_item_frete.Text = String.Concat("Frete para o ITEM ")

                gridfrete.Visible = True
                gridfrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                gridfrete.DataBind()
            End If

        End If

    End Sub

    Protected Sub img_selecionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)


        Dim tabelafrete As New TabelaFreteVeiculos
        tabelafrete.id_central_tabela_frete_veiculos = gridfrete.DataKeys(row.RowIndex).Value.ToString()

        Dim dsfrete As DataSet = tabelafrete.getCentralTabelaFreteVeiculos
        With dsfrete.Tables(0).Rows(0)
            txt_nr_frete.Text = .Item("nr_valor_frete").ToString
            'lbl_inf_frete.Text = String.Concat("(Data cotação: ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ")")
            lbl_inf_frete.Text = String.Concat("Cotação em ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ".")
            ViewState.Item("id_central_tabela_frete_veiculos") = .Item("id_central_tabela_frete_veiculos").ToString
            ViewState.Item("id_veiculo_central_compras") = .Item("id_veiculocentralcompras").ToString
        End With

        gridfrete.Visible = False
        pnl_frete.Visible = False
    End Sub

    Protected Sub cbo_tipo_frete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_frete.SelectedIndexChanged

        cbo_tipo_frete.ForeColor = Drawing.Color.Red
        btn_salvar_tipo_frete.Enabled = True
    End Sub

    Protected Sub btn_salvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        'Dim wc As WebControl = CType(sender, WebControl)
        'Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim nm_estabelecimento As Label = CType(row.FindControl("nm_estabelecimento"), Label)
        Dim nr_unid_producao As Label = CType(row.FindControl("nr_unid_producao"), Label)
        Dim id_propriedade As Label = CType(row.FindControl("id_propriedade"), Label)
        Dim id_produtor As Label = CType(row.FindControl("id_produtor"), Label)
        Dim id_fornecedor As Label = CType(row.FindControl("id_fornecedor"), Label)
        Dim nm_pedido_cancelar_motivo As Label = CType(row.FindControl("lbl_nm_pedido_cancelar_motivo"), Label)

        'EnvioEmailCancelamentoFornecedor(Convert.ToInt32(e.CommandArgument.ToString), Convert.ToInt32(id_propriedade.Text), Convert.ToInt32(id_produtor.Text), Convert.ToInt32(id_fornecedor.Text), nm_estabelecimento.Text.ToString, nr_unid_producao.Text.ToString, nm_pedido_cancelar_motivo.Text.ToString)

        If Page.IsValid = True Then
            Try

                If (Not (row) Is Nothing) Then
                    If ViewState.Item("PedidoFreteAtivo") = True Then
                        Dim pedido As New Pedido
                        Dim cbo_pedido_cancelar_motivo As Anthem.DropDownList = CType(row.FindControl("cbo_pedido_cancelar_motivo"), Anthem.DropDownList)
                        pedido.id_central_pedido = Convert.ToInt32(gridpedidos.DataKeys.Item(row.RowIndex).Value)
                        pedido.id_pedido_cancelar_motivo = Convert.ToInt32(cbo_pedido_cancelar_motivo.SelectedValue)
                        pedido.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                        pedido.id_modificador = Session("id_login")

                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 6 'processo
                        usuariolog.id_menu_item = 97
                        usuariolog.ds_nm_processo = "Pedido - Atualização Frete Cancelar"
                        usuariolog.id_nr_processo = pedido.id_central_pedido
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        If pedido.cancelarPedido() = True Then
                            ViewState.Item("id_central_pedido_transportador") = 0
                            ViewState.Item("PedidoFreteAtivo") = False
                            messageControl.Alert(String.Concat("Pedido ", pedido.id_central_pedido.ToString, " cancelado com sucesso!"))
                        Else
                            messageControl.Alert("Ocorreram problemas no cancelamento do Pedido. Contate o administrador do sistema.")
                        End If

                        'tr_transportador.Visible = True
                        'grdresults.EditIndex = -1
                        loadData()
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class