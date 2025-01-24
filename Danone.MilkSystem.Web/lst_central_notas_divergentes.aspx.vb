Imports Danone.MilkSystem.Business
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Data
Imports System.Xml
Imports system.Data.SqlClient
Imports RK.GlobalTools
Partial Class lst_central_notas_divergentes
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_notas_divergentes.aspx")
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With

        If Not Page.IsPostBack Then
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 235
                usuariolog.ds_nm_processo = "Notas Divergentes"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 
            End If
            loadDetails()
        End If
    End Sub
    Private Sub loadDetails()


        ViewState.Item("arrowdown") = True
        ViewState.Item("id_item_filtro") = 0
        ViewState.Item("id_fornecedor_filtro") = 0
        ViewState.Item("idpageindex_detalhe") = 0
        ViewState.Item("idrowindex_detalhe") = -1
        'busca o ultimo nr de importacao e força no filtro de pesquisa

        'cbo_situacao_nota.DataSource = status.getSituacoesCentralNotasByFilters()
        'cbo_situacao_nota.DataTextField = "nm_situacao_central_notas"
        'cbo_situacao_nota.DataValueField = "id_situacao_central_notas"
        'cbo_situacao_nota.DataBind()
        'cbo_situacao_nota.Items.Insert(0, New ListItem("[Selecione]", "0"))

        loadDataFiles()

    End Sub
    Private Sub loadDetalhePedido()

        Try

            pnl_pedido.Visible = True

            Dim pedido As New Pedido
            pedido.id_central_pedido = ViewState.Item("id_central_pedido_sugestao_detalhe")

            Dim dspedido As DataSet = pedido.getCentralPedidoseSeusItensbyFilter
            If dspedido.Tables(0).Rows.Count > 0 Then
                With dspedido.Tables(0).Rows(0)
                    lbl_pedido.Text = pedido.id_central_pedido.ToString
                    lbl_dt_pedido.Text = String.Concat("Data: ", DateTime.Parse(.Item("dt_pedido")).ToString("dd/MM/yyyy"))
                    lbl_item.Text = String.Concat("Item: ", .Item("cd_item").ToString, " - ", .Item("nm_item").ToString)
                    lbl_qtde.Text = String.Concat("Qtde: ", FormatNumber(.Item("nr_quantidade").ToString, 4).ToString)
                    lbl_produtor.Text = String.Concat("Produtor: ", .Item("ds_produtor").ToString, "     CPF: ", .Item("cd_cpf_produtor").ToString)
                    lbl_fornecedor.Text = String.Concat("Fornecedor: ", .Item("ds_produtor").ToString, "     CPF: ", .Item("cd_cpf_produtor").ToString)
                    lbl_total_pedido.Text = String.Concat("Total Pedido: ", FormatCurrency(.Item("nr_total_pedido").ToString, 2))
                    lbl_situacao.Text = String.Concat("Situação: ", .Item("nm_situacao_pedido").ToString)
                    If IsDBNull(.Item("id_propriedade_matriz")) Then
                        lbl_propriedade.Text = String.Concat("Prop.: ", .Item("id_propriedade").ToString, "     Prop.Matriz: Não")
                    Else
                        lbl_propriedade.Text = String.Concat("Prop.: ", .Item("id_propriedade").ToString, "     Prop.Matriz: ", .Item("id_propriedade_matriz").ToString)
                    End If
                End With

                lbl_total_notas.Text = FormatCurrency(pedido.getCentralPedidoValorTotalNotas, 2).ToString
            Else
                pnl_pedido.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadComboParceiro(ByVal pFiltroNome As String, ByVal pFiltroId As Integer, Optional ByVal pcnpj As String = "")
        Try


            Dim parceiroitem As New ItemParceiro
            Dim dsparceiro As DataSet
            Dim lcnpj As String = String.Empty
            Dim lbsimulaselectedcombo As Boolean = False
            parceiroitem.id_estabelecimento = 1 'poços
            parceiroitem.nm_pessoa = pFiltroNome

            If Not ViewState.Item("nm_remetente_detalhe").Equals(String.Empty) Then
                Dim pessoa As New Pessoa
                'transportador central
                pessoa.id_situacao = 1
                pessoa.st_transportador_central = "S"
                dsparceiro = pessoa.getTransportadorCentralByFilters

                cbo_fornecedor.DataSource = dsparceiro
                cbo_fornecedor.DataTextField = "nm_pessoa"
                cbo_fornecedor.DataValueField = "id_pessoa"
                cbo_fornecedor.DataBind()
                cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione]", 0))
            Else
                parceiroitem.cd_cnpj = pcnpj
                If Not pcnpj.Equals(String.Empty) Then
                    parceiroitem.nm_pessoa = String.Empty 'procura so pela raiz do cnpj
                End If
                dsparceiro = parceiroitem.getCentralParceiroComItens()
                cbo_fornecedor.DataSource = dsparceiro
                cbo_fornecedor.DataTextField = "ds_abreviado"
                cbo_fornecedor.DataValueField = "id_fornecedor"
                cbo_fornecedor.DataBind()
                cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione]", "0"))

            End If

            'If pFiltroId > 0 Then
            '    parceiroitem.id_fornecedor = pFiltroId
            '    dsparceiro = parceiroitem.getCentralParceiroComItens()
            '    'se nao trouxe o parceiro, o fornecedor nao tem itens associado
            '    If dsparceiro.Tables(0).Rows.Count = 0 Then
            '        pFiltroId = 0
            '        parceiroitem.nm_pessoa = pFiltroNome
            '        parceiroitem.id_fornecedor = pFiltroId
            '        dsparceiro = parceiroitem.getCentralParceiroComItens()
            '    Else
            '        lcnpj = dsparceiro.Tables(0).Rows(0).Item("cd_cnpj").ToString
            '        parceiroitem.nm_pessoa = pFiltroNome
            '        parceiroitem.id_fornecedor = 0
            '        dsparceiro = parceiroitem.getCentralParceiroComItens()

            '    End If
            'Else
            '    parceiroitem.nm_pessoa = pFiltroNome
            '    parceiroitem.id_fornecedor = pFiltroId
            '    dsparceiro = parceiroitem.getCentralParceiroComItens()
            'End If

            If cbo_fornecedor.Items.Count Then

            End If
            If pFiltroId > 0 Then

                If Not cbo_fornecedor.Items.FindByValue(pFiltroId.ToString) Is Nothing Then
                    cbo_fornecedor.SelectedValue = pFiltroId
                    lbsimulaselectedcombo = True
                    ''simula chamada do combo
                    'ViewState.Item("id_fornecedor_filtro") = pFiltroId
                    'Dim pessoa As New Pessoa(pFiltroId)

                    'lbl_cnpj_fornecedor.Text = String.Concat("CNPJ: ", pessoa.cd_cnpj.ToString)

                    ''txt_nm_item.Text = String.Empty

                    'loadComboItens(txt_nm_item.Text)
                Else
                    ViewState.Item("id_fornecedor_filtro") = 0
                    lbl_cnpj_fornecedor.Text = String.Empty
                    cbo_fornecedor.SelectedValue = 0
                End If

            Else
                'se veio com filtro de texto, verifica se tem filtro do fornecedor que estava selecionado se encontra no combo 
                If CInt(ViewState.Item("id_fornecedor_filtro").ToString) > 0 Then
                    If cbo_fornecedor.Items.FindByValue(ViewState.Item("id_fornecedor_filtro").ToString) Is Nothing Then
                        ViewState.Item("id_fornecedor_filtro") = 0
                        lbl_cnpj_fornecedor.Text = String.Empty
                        'se nao tem filtro
                        If pFiltroNome.Equals(String.Empty) Then
                            'nao tem filtro de fornecedor nome assume selecione
                            cbo_fornecedor.SelectedValue = "0"
                        Else
                            'tem filtro em nome fornecedor
                            If cbo_fornecedor.Items.Count = 1 Then
                                'se so tem selecione nao encontrou nada com filtro
                                cbo_fornecedor.Items(0).Text = "[Filtro Não Encontrado]"
                            Else
                                cbo_fornecedor.Items(1).Selected = True 'assume o priemiro item apos selecione
                                lbsimulaselectedcombo = True
                            End If
                        End If
                    Else
                        cbo_fornecedor.SelectedValue = ViewState.Item("id_fornecedor_filtro").ToString
                    End If
                Else
                    lbl_cnpj_fornecedor.Text = String.Empty
                    'se nao tem filtro
                    If pFiltroNome.Equals(String.Empty) Then
                        'nao tem filtro de fornecedor nome assume selecione
                        cbo_fornecedor.SelectedValue = "0"
                    Else
                        'tem filtro em nome fornecedor
                        If cbo_fornecedor.Items.Count = 1 Then
                            'se so tem selecione nao encontrou nada com filtro
                            cbo_fornecedor.Items(0).Text = "[Filtro Não Encontrado]"
                        Else
                            cbo_fornecedor.Items(1).Selected = True 'assume o priemiro item apos selecione
                            lbsimulaselectedcombo = True
                        End If

                    End If

                End If


            End If

            If lbsimulaselectedcombo = True Then
                'simula chamada do combo
                ViewState.Item("id_fornecedor_filtro") = cbo_fornecedor.SelectedValue
                Dim pessoa As New Pessoa(cbo_fornecedor.SelectedValue)
                lbl_cnpj_fornecedor.Text = String.Concat("CNPJ: ", pessoa.cd_cnpj.ToString)
                If ViewState.Item("nm_remetente_detalhe").Equals(String.Empty) Then
                    txt_nm_item.Visible = True
                    lbl_item_filtro.Visible = True
                    lbl_item_selecione.Visible = True
                    cbo_item_filtro.Visible = True
                    If txt_nm_item.Text = "[Filtre Nome]" Then
                        loadComboItens(String.Empty)
                    Else
                        loadComboItens(txt_nm_item.Text)
                    End If
                Else
                    txt_nm_item.Visible = False
                    lbl_item_filtro.Visible = False
                    lbl_item_selecione.Visible = False
                    cbo_item_filtro.Visible = False
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Private Sub loadDataFiles()

        Try

            Dim centralnota As New CentralNotas

            If Not txt_dt_referencia.Text.Trim = String.Empty Then
                ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
                ViewState.Item("dt_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
                ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate("01/" + Me.txt_dt_referencia.Text.Trim))).ToString

                If Not txt_dia_fim.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_ini") = DateTime.Parse(Right("00" & txt_dia_ini.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                    ViewState.Item("dt_fim") = DateTime.Parse(Right("00" & txt_dia_fim.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                End If
                centralnota.dt_ini = ViewState.Item("dt_ini")
                centralnota.dt_fim = ViewState.Item("dt_fim")
            Else
                ViewState.Item("dt_referencia") = String.Empty
                ViewState.Item("dt_ini") = String.Empty
                ViewState.Item("dt_fim") = String.Empty
            End If

            If Not Me.txt_dt_importacao.Text.Trim = String.Empty Then
                centralnota.dt_criacao = Me.txt_dt_importacao.Text.Trim
            End If
            If Not Me.txt_nr_importacao.Text.Trim = String.Empty Then
                centralnota.id_importacao = txt_nr_importacao.Text.Trim()
            End If
            If Not txt_nm_emitente.Text = String.Empty Then
                centralnota.nm_emitente = txt_nm_emitente.Text
            End If
            If Not txt_nm_produtor.Text = String.Empty Then
                centralnota.nm_destino = txt_nm_produtor.Text
            End If
            If Not txt_nr_nota.Text = String.Empty Then
                centralnota.nr_nota_fiscal = txt_nr_nota.Text
            End If
            If Not txt_nr_pedido_nota.Text = String.Empty Then
                centralnota.nr_pedido = txt_nr_pedido_nota.Text
            End If
            centralnota.id_cd_divergencia = cbo_consistencias.SelectedValue

            centralnota.id_tipo_divergencia = cbo_divergencia_nota.SelectedValue

            Dim dsnotas As DataSet = centralnota.getCentralNotasImportacaoByTipoDivergencia
            If (dsnotas.Tables(0).Rows.Count > 0) Then
                gridFiles.Visible = True
                gridFiles.DataSource = Helper.getDataView(dsnotas.Tables(0), "nm_emitente, nm_destino")
                gridFiles.DataBind()
            Else
                gridFiles.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadSelecaoPedido()

        Try

            pnl_selecao_pedidos.Visible = True

            'carregar fornecedor
            lbl_cnpj_fornecedor.Text = String.Empty
            Dim lcnpjdetalhe As String = String.Empty 'cnpj de fornecedor

            If ViewState.Item("id_fornecedor_detalhe") = "0" Then
                If ViewState.Item("nm_emitente_detalhe").ToString = String.Empty Then
                    txt_nm_fornecedor.Text = "[Filtre Nome]"
                    loadComboParceiro(String.Empty, ViewState.Item("id_fornecedor_detalhe").ToString)
                Else
                    txt_nm_fornecedor.Text = Left(ViewState.Item("nm_emitente_detalhe").ToString.Trim, 10)
                    txt_nm_fornecedor_pedido.Text = Left(ViewState.Item("nm_emitente_detalhe").ToString.Trim, 10)
                    loadComboParceiro(txt_nm_fornecedor.Text, ViewState.Item("id_fornecedor_detalhe").ToString)
                End If
                txt_nm_fornecedor.Enabled = True
                txt_nm_fornecedor_pedido.Enabled = True
                cbo_fornecedor.Enabled = True

            Else
                Dim pessoa As New Pessoa(ViewState.Item("id_fornecedor_detalhe"))

                lcnpjdetalhe = pessoa.cd_cnpj.ToString.Trim
                Dim lpos As Integer
                If Not lcnpjdetalhe.Equals(String.Empty) Then
                    lpos = InStr(lcnpjdetalhe, "/", CompareMethod.Text)
                    If lpos > 0 Then
                        lcnpjdetalhe = Left(lcnpjdetalhe, lpos - 1)
                    Else
                        lcnpjdetalhe = String.Empty
                    End If
                End If
                txt_nm_fornecedor.Text = "[Filtre Nome]"
                txt_nm_fornecedor_pedido.Text = String.Empty
                loadComboParceiro(String.Empty, ViewState.Item("id_fornecedor_detalhe").ToString, lcnpjdetalhe)
                txt_nm_fornecedor.Enabled = False
                txt_nm_fornecedor_pedido.Enabled = False

                If lcnpjdetalhe.Equals(String.Empty) Then
                    cbo_fornecedor.Enabled = False
                Else
                    cbo_fornecedor.Enabled = True
                End If

            End If

            'carrega produtor- se veio zero do detalhe tem erro no cadatro de produtor, usuario vai ter que procurar
            If ViewState.Item("id_produtor_detalhe") = 0 Then
                Me.lbl_nm_pessoa.Text = String.Empty
                Me.hf_id_produtor.Value = String.Empty
                lbl_cpf_produtor.Text = String.Empty
                If ViewState.Item("nm_destino_detalhe").ToString = String.Empty Then
                    txt_nm_produtor_pedido.Text = String.Empty
                Else
                    txt_nm_produtor_pedido.Text = Left(ViewState.Item("nm_destino_detalhe").ToString.Trim, 10)
                End If
            Else
                Me.lbl_nm_pessoa.Text = String.Empty
                Me.hf_id_produtor.Value = String.Empty
                lbl_cpf_produtor.Text = String.Empty
                txt_nm_produtor_pedido.Text = String.Empty
                loadDadosProdutor(ViewState.Item("id_produtor_detalhe").ToString)
            End If

            If CInt(ViewState.Item("id_fornecedor_filtro")) > 0 OrElse Not hf_id_produtor.Value.Equals(String.Empty) Then
                loadGridPedidos(lcnpjdetalhe)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadDetalheDivergencia()

        Try

            pnl_romaneio.Visible = True

            Dim centralnota As New CentralNotas
            centralnota.id_central_notas_importacao = ViewState.Item("id_central_notas_importacao_detalhe")
            Dim dsnotas As DataSet = centralnota.getCentralNotasImportacaoDivergencia

            If dsnotas.Tables(0).Rows.Count > 0 Then
                gridDoc.Visible = True
                gridDoc.DataSource = Helper.getDataView(dsnotas.Tables(0), "id_cd_divergencia")
                gridDoc.DataBind()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadDetalhePropriedade()

        Try

            pnl_propriedade.Visible = True

            Dim pessoa As New Pessoa
            pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_produtor.Value)

            Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
            If (dspropriedades.Tables(0).Rows.Count > 0) Then

                btn_ver.ImageUrl = "~/img/arrowup.png"
                gridPropriedades.Visible = True
                ViewState.Item("arrowdown") = False
                gridPropriedades.Visible = True
                gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                gridPropriedades.DataBind()
            Else
                gridPropriedades.Visible = False
                pnl_propriedade.Visible = False
                btn_ver.ImageUrl = "~/img/arrowdown.png"
                ViewState.Item("arrowdown") = True

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadGridPedidos(Optional ByVal pcd_cnpj As String = "")

        Try


            Dim pedido As New Pedido
            Dim ds_pedidos As DataSet

            pedido.id_fornecedor = cbo_fornecedor.SelectedValue
            pedido.nm_fornecedor = txt_nm_fornecedor_pedido.Text
            pedido.cd_cnpj = pcd_cnpj
            If Not cbo_item_filtro.SelectedValue.Equals(String.Empty) Then
                pedido.id_item = cbo_item_filtro.SelectedValue
            End If
            pedido.id_situacao_pedido = cbo_situacao_pedido.SelectedValue
            If Not txt_nr_valor_pedido.Text.Equals(String.Empty) Then
                If cbo_operador.SelectedValue = "<" Then
                    pedido.nr_valor_ini = 0
                    pedido.nr_valor_fim = CDec(txt_nr_valor_pedido.Text)
                End If
                If cbo_operador.SelectedValue = ">" Then
                    pedido.nr_valor_fim = 999999999
                    pedido.nr_valor_ini = CDec(txt_nr_valor_pedido.Text)
                End If
                pedido.nr_total_pedido = CDec(txt_nr_valor_pedido.Text)
            End If
            If Not txt_id_central_pedido.Text = String.Empty Then
                pedido.id_central_pedido = txt_id_central_pedido.Text

            End If

            pedido.dt_inicio = txt_dt_pedido_ini.Text
            pedido.dt_fim = txt_dt_pedido_fim.Text

            'se tem propriedade ou prop matriz
            If Not txt_propriedade.Text = String.Empty Or Not txt_propriedade_matriz.Text = String.Empty Then
                If Not txt_propriedade_matriz.Text = String.Empty Then 'se tem prop matriz
                    pedido.id_propriedade_matriz = txt_propriedade_matriz.Text
                Else
                    If Not txt_propriedade.Text = String.Empty Then 'se tem prop 
                        Dim prop As New Propriedade(txt_propriedade.Text)
                        pedido.id_propriedade_matriz = prop.id_propriedade_matriz
                        pedido.id_propriedade = txt_propriedade.Text
                    End If
                End If
                ds_pedidos = pedido.getCentralPedidoNotasbyPropriedade
            Else
                If Not hf_id_produtor.Value = String.Empty Then
                    pedido.id_produtor = hf_id_produtor.Value
                End If
                pedido.nm_produtor = txt_nm_produtor_pedido.Text
                ds_pedidos = pedido.getCentralPedidoNotasbyProdutor

            End If

            If (ds_pedidos.Tables(0).Rows.Count > 0) Then
                pnl_selecao_pedidos.Visible = True
                gridPedidos.Visible = True
                gridPedidos.Visible = True
                gridPedidos.DataSource = Helper.getDataView(ds_pedidos.Tables(0), "")
                gridPedidos.DataBind()
            Else
                gridPedidos.Visible = False
                messageControl.Alert("Não foram encontrados pedidos para os filtros informados.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName

            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor
            If arquivos(index) = ViewState.Item("nm_arquivo").ToString Then
                Arquivo.Delete()
            End If
        Next index
    End Sub

    Protected Sub gridFiles_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridFiles.PageIndexChanging
        gridFiles.PageIndex = e.NewPageIndex

        'se foi selecionado item 
        If ViewState.Item("idrowindex_detalhe") <> -1 Then
            If ViewState.Item("idpageindex_detalhe") = e.NewPageIndex Then 'e esta retornando para a pagina do item
                gridFiles.SelectedIndex = ViewState.Item("idrowindex_detalhe")
            Else
                gridFiles.SelectedIndex = -1
            End If
        End If

        Me.loadDataFiles()

    End Sub

    'Protected Sub txt_dt_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If txt_dt_referencia.Text.Equals(String.Empty) Then
    '        txt_dia_ini.Enabled = False
    '        txt_dia_ini.ToolTip = "Para informar período em dias da data de Emissão da Nota, a Referência de Emissão dever ser informada."
    '        txt_dia_fim.Enabled = False
    '        txt_dia_fim.ToolTip = "Para informar período em dias da data de Emissão da Nota, a Referência de Emissão dever ser informada."

    '        txt_dia_ini.Text = String.Empty
    '        txt_dia_fim.Text = String.Empty
    '    Else
    '        txt_dia_ini.Enabled = True
    '        txt_dia_fim.Enabled = True
    '        txt_dia_ini.ToolTip = String.Empty
    '        txt_dia_ini.ToolTip = String.Empty

    '    End If
    'End Sub

    Protected Sub gridFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridFiles.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "select"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

                Dim lbl_id_central_pedido_sugestao As Label = CType(row.FindControl("lbl_id_central_pedido_sugestao"), Label)
                Dim lbl_nm_emitente As Label = CType(row.FindControl("lbl_nm_emitente"), Label)
                Dim lbl_nm_destino As Label = CType(row.FindControl("lbl_nm_destino"), Label)
                Dim lbl_nm_remetente As Label = CType(row.FindControl("lbl_nm_remetente"), Label)
                Dim lbl_id_fornecedor_remetente As Label = CType(row.FindControl("lbl_id_fornecedor_remetente"), Label)
                Dim lbl_id_fornecedor As Label = CType(row.FindControl("lbl_id_fornecedor_nota"), Label)
                Dim lbl_id_produtor As Label = CType(row.FindControl("lbl_id_produtor_nota"), Label)
                Dim lbl_nr_nota_fiscal As Label = CType(row.FindControl("lbl_nr_nota_fiscal"), Label)

                ViewState.Item("id_central_pedido_selecionado") = 0
                gridPedidos.SelectedIndex = -1 'força sem seleção

                ViewState.Item("id_central_notas_importacao_detalhe") = Me.gridFiles.DataKeys(row.RowIndex).Value.ToString
                If lbl_id_central_pedido_sugestao.Text = String.Empty Then
                    ViewState.Item("id_central_pedido_sugestao_detalhe") = 0
                Else
                    ViewState.Item("id_central_pedido_sugestao_detalhe") = lbl_id_central_pedido_sugestao.Text
                End If
                If lbl_id_fornecedor.Text = String.Empty Then
                    ViewState.Item("id_fornecedor_detalhe") = 0
                Else
                    ViewState.Item("id_fornecedor_detalhe") = lbl_id_fornecedor.Text
                End If
                If lbl_id_produtor.Text = String.Empty Then
                    ViewState.Item("id_produtor_detalhe") = 0
                Else
                    ViewState.Item("id_produtor_detalhe") = lbl_id_produtor.Text
                End If
                If lbl_id_fornecedor_remetente.Text = String.Empty Then
                    ViewState.Item("id_fornecedor_remetente_detalhe") = 0
                Else
                    ViewState.Item("id_fornecedor_remetente_detalhe") = lbl_id_fornecedor.Text
                End If

                ViewState.Item("nm_emitente_detalhe") = lbl_nm_emitente.Text
                ViewState.Item("nm_destino_detalhe") = lbl_nm_destino.Text
                ViewState.Item("nm_remetente_detalhe") = lbl_nm_remetente.Text

                ViewState.Item("nr_nota_fiscal_detalhe") = lbl_nr_nota_fiscal.Text
                ViewState.Item("idpageindex_detalhe") = gridFiles.PageIndex
                ViewState.Item("idrowindex_detalhe") = row.RowIndex


                tr_detalhes.Visible = True
                pnl_romaneio.Visible = True
                loadDetalheDivergencia()

                'se pedido valido ou pedido existente
                If cbo_divergencia_nota.SelectedValue = 1 OrElse cbo_divergencia_nota.SelectedValue = 2 Then
                    pnl_pedido.Visible = True
                    loadDetalhePedido()
                Else
                    pnl_pedido.Visible = False

                End If

                loadSelecaoPedido()
                'Response.Redirect("frm_relacao_CIQ_CIQPEmitidos_excel.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))

        End Select
    End Sub

    Protected Sub gridFiles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridFiles.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim btndetalhe As Anthem.ImageButton = CType(e.Row.FindControl("btn_detalhe"), Anthem.ImageButton)
            Dim lbl_id_situacao_nota As Label = CType(e.Row.FindControl("lbl_id_situacao_nota"), Label)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", Me.gridFiles.DataKeys(e.Row.RowIndex).Value.ToString) + String.Format("&id_processo={0}", "3")
            End If

            If lbl_id_situacao_nota.Text = "1" OrElse lbl_id_situacao_nota.Text = "2" Then 'se for importada ou incluida milk nao tem diveregencia para mostra
                btndetalhe.ImageUrl = "~/img/icon_preview_desabilitado.gif"
                btndetalhe.Enabled = False
                btndetalhe.ToolTip = "A nota não possui divergências."
            Else
                btndetalhe.ImageUrl = "~/img/icon_preview.gif"
                btndetalhe.Enabled = True
                btndetalhe.ToolTip = "Visualizar divergências."


            End If
        End If

    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then
            Try
                'limpa todas as variaveis de detalhes
                ViewState.Item("id_central_pedido_selecionado") = 0
                gridPedidos.SelectedIndex = -1 'força sem seleção

                ViewState.Item("id_central_notas_importacao_detalhe") = 0
                ViewState.Item("id_central_pedido_sugestao_detalhe") = 0
                ViewState.Item("id_fornecedor_detalhe") = 0
                ViewState.Item("id_produtor_detalhe") = 0
                ViewState.Item("id_fornecedor_remetente_detalhe") = 0
                ViewState.Item("nm_emitente_detalhe") = String.Empty
                ViewState.Item("nm_destino_detalhe") = String.Empty
                ViewState.Item("nm_remetente_detalhe") = String.Empty
                ViewState.Item("nr_nota_fiscal_detalhe") = String.Empty
                ViewState.Item("idpageindex_detalhe") = 0
                ViewState.Item("idrowindex_detalhe") = -1
                gridFiles.SelectedIndex = -1 'força sem seleção

                pnl_pedido.Visible = False
                pnl_romaneio.Visible = False
                pnl_selecao_pedidos.Visible = False
                loadDataFiles()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_central_notas_importar.aspx?st_incluirlog=N")

    End Sub

  
    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        gridDoc.Visible = False
        tr_detalhes.Visible = False
        pnl_romaneio.Visible = False
    End Sub

    Protected Sub cbo_divergencia_nota_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_divergencia_nota.SelectedIndexChanged
        Select Case cbo_divergencia_nota.SelectedValue
            Case 1 'pedidos validos
                cbo_consistencias.Items(0).Enabled = False
                cbo_consistencias.Items(1).Enabled = False
                cbo_consistencias.Items(2).Enabled = False
                cbo_consistencias.Items(3).Enabled = False
                cbo_consistencias.Items(4).Enabled = False
                cbo_consistencias.Items(5).Enabled = False
                cbo_consistencias.Items(6).Enabled = True
                cbo_consistencias.Items(7).Enabled = False
                cbo_consistencias.Items(8).Enabled = True
            Case 2 'pedidos exixstentes
                cbo_consistencias.Items(0).Enabled = True
                cbo_consistencias.Items(1).Enabled = True
                cbo_consistencias.Items(2).Enabled = True
                cbo_consistencias.Items(3).Enabled = True
                cbo_consistencias.Items(4).Enabled = True
                cbo_consistencias.Items(5).Enabled = True
                cbo_consistencias.Items(6).Enabled = True
                cbo_consistencias.Items(7).Enabled = False
                cbo_consistencias.Items(8).Enabled = True
            Case 3 'pedidos inexistente
                cbo_consistencias.Items(0).Enabled = True
                cbo_consistencias.Items(1).Enabled = True
                cbo_consistencias.Items(2).Enabled = True
                cbo_consistencias.Items(3).Enabled = True
                cbo_consistencias.Items(4).Enabled = False
                cbo_consistencias.Items(5).Enabled = False
                cbo_consistencias.Items(6).Enabled = False
                cbo_consistencias.Items(7).Enabled = False
                cbo_consistencias.Items(8).Enabled = True
            Case 4 'sem pedido
                cbo_consistencias.Items(0).Enabled = True
                cbo_consistencias.Items(1).Enabled = True
                cbo_consistencias.Items(2).Enabled = True
                cbo_consistencias.Items(3).Enabled = True
                cbo_consistencias.Items(4).Enabled = False
                cbo_consistencias.Items(5).Enabled = False
                cbo_consistencias.Items(6).Enabled = False
                cbo_consistencias.Items(7).Enabled = False
                cbo_consistencias.Items(8).Enabled = True
            Case 5 'notas ja existente
                cbo_consistencias.Items(0).Enabled = True
                cbo_consistencias.Items(1).Enabled = True
                cbo_consistencias.Items(2).Enabled = True
                cbo_consistencias.Items(3).Enabled = True
                cbo_consistencias.Items(4).Enabled = True
                cbo_consistencias.Items(5).Enabled = True
                cbo_consistencias.Items(6).Enabled = True
                cbo_consistencias.Items(7).Enabled = True
                cbo_consistencias.Items(8).Enabled = True



        End Select
    End Sub

    Protected Sub txt_dt_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_referencia.TextChanged
        If txt_dt_referencia.Text.Equals(String.Empty) Then
            txt_dia_ini.Text = String.Empty
            txt_dia_fim.Text = String.Empty
            txt_dia_ini.Enabled = False
            txt_dia_fim.Enabled = False
        Else
            txt_dia_ini.Enabled = True
            txt_dia_fim.Enabled = True

        End If
    End Sub

    Protected Sub txt_nm_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nm_fornecedor.TextChanged
        Try
            If txt_nm_fornecedor.Text.Trim = String.Empty Then
                txt_nm_fornecedor.Text = "[Filtre Nome]"
                loadComboParceiro(String.Empty, 0)
            Else
                loadComboParceiro(txt_nm_fornecedor.Text, 0)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Private Sub loadComboItens(ByVal pFiltroNome As String)
        Try


            Dim lcboitem As String = ViewState.Item("id_item_filtro").ToString

            Dim itemparceiro As New ItemParceiro
            itemparceiro.id_fornecedor = ViewState.Item("id_fornecedor_filtro").ToString
            itemparceiro.nm_item = pFiltroNome

            cbo_item_filtro.DataSource = itemparceiro.getCentralItemParceiro
            cbo_item_filtro.DataTextField = "ds_item"
            cbo_item_filtro.DataValueField = "id_item"
            cbo_item_filtro.DataBind()
            cbo_item_filtro.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'se nao tem filtro
            If pFiltroNome.Equals(String.Empty) Then
                cbo_item_filtro.SelectedValue = lcboitem
            Else
                cbo_item_filtro.Focus()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub txt_nm_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nm_item.TextChanged
        Try
            'If ViewState.Item("id_fornecedor_filtro") > 0 Then

            '    loadComboItens(txt_nm_item.Text)
            'Else
            '    loadComboItens(txt_nm_item.Text)

            'End If
            loadComboItens(txt_nm_item.Text)
            If txt_nm_item.Text = String.Empty Then
                txt_nm_item.Text = "[Filtre Nome]"
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cbo_fornecedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_fornecedor.SelectedIndexChanged

        Try

            ViewState.Item("id_fornecedor_filtro") = "0"
            lbl_cnpj_fornecedor.Text = String.Empty

            If cbo_fornecedor.SelectedValue > 0 Then

                ViewState.Item("id_fornecedor_filtro") = cbo_fornecedor.SelectedValue

                Dim pessoa As New Pessoa
                pessoa.id_pessoa = cbo_fornecedor.SelectedValue

                Dim dsparceiro As DataSet = pessoa.getPessoaByFilters

                If (dsparceiro.Tables(0).Rows.Count > 0) Then
                    With dsparceiro.Tables(0).Rows(0)
                        lbl_cnpj_fornecedor.Text = .Item("cd_cnpj").ToString
                    End With
                End If

                txt_nm_item.Text = "[Filtre Nome]"

                loadComboItens(String.Empty)
            Else

                cbo_item_filtro.Items.Clear()
                cbo_item_filtro.Items.Insert(0, New ListItem("[Selecione um Parceiro]", "0"))
                cbo_item_filtro.SelectedValue = 0
                txt_nm_item.Text = "[Filtre Nome]"
                txt_nm_item.Enabled = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        Me.lbl_nm_pessoa.Text = String.Empty
        Me.lbl_cpf_produtor.Text = String.Empty
        Me.hf_id_produtor.Value = String.Empty
        Try
            If Not (Me.txt_cd_pessoa.Text.Equals(String.Empty)) Then
                Dim pessoa As New Pessoa
                pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim()
                pessoa.id_situacao = 1
                pessoa.id_grupo = 1

                Dim dspessoa As DataSet = pessoa.getPessoaByFilters()
                If (dspessoa.Tables(0).Rows.Count <= 0) Then
                    Me.lbl_nm_pessoa.Text = "Produtor não encontrado!"
                Else
                    Me.lbl_nm_pessoa.Text = dspessoa.Tables(0).Rows(0)("nm_pessoa").ToString
                    Me.hf_id_produtor.Value = dspessoa.Tables(0).Rows(0)("id_pessoa").ToString
                    Me.lbl_cpf_produtor.Text = String.Concat("CPF: ", dspessoa.Tables(0).Rows(0)("cd_cpf").ToString)
                    Me.loadDadosProdutor(Convert.ToInt32(Me.hf_id_produtor.Value))
                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadDadosProdutor(ByVal pid_produtor As Integer)
        Me.lbl_nm_pessoa.Text = String.Empty
        Try
            Dim produtor As New Pessoa
            produtor.id_pessoa = pid_produtor

            Dim dspessoa As DataSet = produtor.getPessoaByFilters

            If (dspessoa.Tables(0).Rows.Count > 0) Then
                With dspessoa.Tables(0).Rows(0)
                    Me.lbl_nm_pessoa.Enabled = True
                    Me.lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
                    Me.hf_id_produtor.Value = .Item("id_pessoa").ToString
                    txt_cd_pessoa.Text = .Item("cd_pessoa").ToString
                    If IsDBNull(.Item("cd_cpf")) Then
                        If IsDBNull(.Item("cd_cnpj")) Then
                            lbl_cpf_produtor.Text = String.Empty
                        Else
                            lbl_cpf_produtor.Text = String.Concat("CNPJ: ", .Item("cd_cnpj").ToString)
                        End If
                    Else
                        lbl_cpf_produtor.Text = String.Concat("CPF: ", .Item("cd_cpf").ToString)
                    End If
                End With
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_ver_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_ver.Click
        If ViewState.Item("arrowdown") = True Then
            If hf_id_produtor.Value.Equals(String.Empty) Then
                btn_ver.ToolTip = "Não há produtor selecionado para visualização de suas propriedades."
            Else
                btn_ver.ToolTip = String.Empty
                loadDetalhePropriedade()
            End If
        Else
            gridPropriedades.Visible = False
            pnl_propriedade.Visible = False
            ViewState.Item("arrowdown") = True
            btn_ver.ImageUrl = "~/img/arrowdown.png"

        End If

    End Sub

    Protected Sub gridPropriedades_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPropriedades.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow AndAlso Me.ViewState("gridpropriedadeslinhas") > 0) Then
                If (e.Row.RowState <> (DataControlRowState.Alternate Or DataControlRowState.Edit) AndAlso e.Row.RowState <> DataControlRowState.Edit) Then
                    Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("lbl_id_propriedade"), Label)
                    Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)
                    Dim row_num As Label = CType(e.Row.FindControl("lbl_row_num"), Label)
                    Dim imgselecionar As Anthem.ImageButton = CType(e.Row.FindControl("imgselecionar"), Anthem.ImageButton)


                    If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) AndAlso CInt(row_num.Text) > 1 Then
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = False
                        imgselecionar.Visible = False
                    Else
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = True
                        imgselecionar.Visible = True

                    End If

                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPropriedades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPropriedades.SelectedIndexChanged
        Dim rowselected As GridViewRow = Me.gridPropriedades.SelectedRow
        Dim lbl_id_propriedade As Label = CType(rowselected.FindControl("lbl_id_propriedade"), Label)
        Dim lbl_id_propriedade_matriz As Label = CType(rowselected.FindControl("lbl_id_propriedade_matriz"), Label)
        Dim lbl_id_produtor As Label = CType(rowselected.FindControl("lbl_id_produtor"), Label)
        Me.ViewState.Item("id_propriedade_grid") = lbl_id_propriedade.Text
        Me.ViewState.Item("id_propriedade_matriz_grid") = lbl_id_propriedade_matriz.Text
        Me.ViewState.Item("id_produtor_grid") = lbl_id_produtor.Text
        txt_propriedade.Text = lbl_id_propriedade.Text
        ViewState.Item("indexgridpropriedade") = rowselected.RowIndex
        pnl_propriedade.Visible = False
        btn_ver.ImageUrl = "~/img/arrowdown.png"
        ViewState.Item("arrowdown") = True



    End Sub

    Protected Sub txt_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_propriedade.TextChanged
        pnl_propriedade.Visible = False
        gridPropriedades.Visible = False
        btn_ver.ImageUrl = "~/img/arrowdown.png"
        ViewState.Item("arrowdown") = True
        'limpa as variaveis de seleção de grid
        Me.ViewState.Item("id_propriedade_grid") = String.Empty
        Me.ViewState.Item("id_propriedade_matriz_grid") = String.Empty
        Me.ViewState.Item("id_produtor_grid") = String.Empty
        ViewState.Item("indexgridpropriedade") = String.Empty

    End Sub

    Protected Sub cbo_item_filtro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_item_filtro.SelectedIndexChanged
        ViewState.Item("id_item_filtro") = cbo_item_filtro.SelectedValue

    End Sub

    Protected Sub btn_pesquisar_pedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pesquisar_pedidos.Click
        If Page.IsValid Then
            pnl_propriedade.Visible = False
            ViewState.Item("id_central_pedido_selecionado") = 0
            gridPedidos.SelectedIndex = -1

            btn_ver.ImageUrl = "~/img/arrowdown.png"
            ViewState.Item("arrowdown") = True

            loadGridPedidos()


        End If
    End Sub

    Protected Sub gridPedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPedidos.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                If (e.Row.RowState <> (DataControlRowState.Alternate Or DataControlRowState.Edit) AndAlso e.Row.RowState <> DataControlRowState.Edit) Then
                    Dim lbl_id_situacao_pedido As Label = CType(e.Row.FindControl("lbl_id_situacao_pedido"), Label)
                    Dim imgselecionar As Anthem.ImageButton = CType(e.Row.FindControl("imgselecionarpedido"), Anthem.ImageButton)


                    If lbl_id_situacao_pedido.Text.Equals("1") OrElse lbl_id_situacao_pedido.Text.Equals("6") OrElse lbl_id_situacao_pedido.Text.Equals("8") Then
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = False
                        imgselecionar.Visible = True
                        e.Row.Cells(0).ToolTip = String.Empty
                    Else
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = True
                        imgselecionar.Visible = False
                        e.Row.Cells(0).ToolTip = "A situação do pedido não permite nenhuma inclusão de nota."
                    End If

                    Dim nrnotapedido As New PedidoPagtoFornecedor
                    nrnotapedido.id_central_pedido = Convert.ToInt32(gridPedidos.DataKeys(e.Row.RowIndex).Value.ToString())
                    Dim dsnotas As DataSet = nrnotapedido.getCentralPedidoPagtoFornecedorNotas()
                    Dim rownotas As DataRow() = dsnotas.Tables(0).Select("nr_nota_fiscal=" & ViewState.Item("nr_nota_fiscal_detalhe").ToString)
                    If rownotas.Length > 0 Then 'se  tem o nr nota no pedido
                        If imgselecionar.Visible = True Then
                            imgselecionar.Visible = False
                            e.Row.Cells(0).ToolTip = "O número da nota da NFe já existe neste pedido."
                        Else
                            e.Row.Cells(0).ToolTip = "A situação do pedido não permite nenhuma inclusão de nota. Este número de NFe já existe no Pedido."
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridPedidos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPedidos.SelectedIndexChanged


        Dim rowselected As GridViewRow = Me.gridPedidos.SelectedRow

        ViewState.Item("id_central_pedido_selecionado") = gridPedidos.DataKeys(rowselected.RowIndex).Value.ToString

    End Sub

    Protected Sub cv_pedidos_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedidos.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            Dim lbfornecedor As Boolean = False
            Dim lbprodutor As Boolean = False

            If hf_id_produtor.Value.Equals(String.Empty) And Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                args.IsValid = False
                lmsg = "O produtor informado não foi encontrado."
            End If

            If args.IsValid = True Then
                'se pedido é vazio deve informar algum filtro relacionado ao fornecedor emitente da nota e algum filtro relacionado ao produtor destinatario
                If txt_id_central_pedido.Text.Equals(String.Empty) Then

                    If cbo_fornecedor.SelectedValue > 0 Then
                        lbfornecedor = True
                    End If
                    If Not txt_nm_fornecedor_pedido.Text.Equals(String.Empty) Then
                        lbfornecedor = True
                    End If
                    If Not hf_id_produtor.Value.Equals(String.Empty) Then
                        lbprodutor = True
                    End If
                    If Not txt_nm_produtor_pedido.Text.Equals(String.Empty) Then
                        lbprodutor = True
                    End If
                    If Not txt_propriedade.Text.Equals(String.Empty) Then
                        lbprodutor = True
                    End If
                    If Not txt_propriedade_matriz.Text.Equals(String.Empty) Then
                        lbprodutor = True
                    End If
                    'se nao informou nenhum filtro de produtor ou fornecdor
                    If lbfornecedor = False And lbprodutor = False Then
                        args.IsValid = False
                        lmsg = "Para prosseguir com a seleção de pedidos, no filtro de pedidos é necessário informar algum campo relacionado ao Fornecedor Emitente da nota e algum campo relacionado ao Produtor Destinatário da nota."
                    Else
                        If lbfornecedor = False Then
                            args.IsValid = False
                            lmsg = "Para prosseguir com a seleção de pedidos, algum campo relacionado ao Fornecedor Emitente deve ser informado!"
                        End If
                        If lbprodutor = False Then
                            args.IsValid = False
                            lmsg = "Para prosseguir com a seleção de pedidos, algum campo relacionado ao Produtor Destinatário deve ser informado!"
                        End If
                    End If

                End If
            End If

            If args.IsValid Then
                Dim pessoa As New Pessoa
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_produtor.Value)

                Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()

                'verifica se existe a propriedade informada
                If Not txt_propriedade.Text.Trim.Equals(String.Empty) Then
                    Dim drprops As DataRow() = dspropriedades.Tables(0).Select("id_propriedade=" & txt_propriedade.Text)
                    If drprops.Length = 0 Then
                        args.IsValid = False
                        lmsg = "A propriedade informada para busca não está associada ao Produtor ou Grupo Matriz do Produtor."
                    End If
                End If

                If Not txt_propriedade_matriz.Text.Trim.Equals(String.Empty) Then
                    Dim drmatrizs As DataRow() = dspropriedades.Tables(0).Select("id_propriedade_matriz=" & txt_propriedade_matriz.Text)
                    If drmatrizs.Length = 0 Then
                        args.IsValid = False
                        lmsg = "A propriedade matriz informada para busca não está associada ao Produtor ou Grupo Matriz do Produtor."
                    End If
                End If


            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub btn_incluirnotapedidonovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirnotapedidonovo.Click
        If Page.IsValid Then
            Try
                Dim notas As New CentralNotas

                notas.id_central_pedido = ViewState.Item("id_central_pedido_selecionado")
                notas.id_central_notas_importacao = ViewState.Item("id_central_notas_importacao_detalhe")
                notas.id_modificador = Session("id_login")

                notas.atulizarPedidosNotasManual()

                loadDataFiles()
                pnl_pedido.Visible = False
                pnl_romaneio.Visible = False
                pnl_selecao_pedidos.Visible = False
                ViewState.Item("id_central_pedido_selecionado") = 0
                ViewState.Item("id_central_notas_importacao_detalhe") = 0

                messageControl.Alert("Nota Incluída com sucesso!")
            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try


        End If
    End Sub

    Protected Sub cv_novopedido_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_novopedido.ServerValidate
        Try

            Dim lmsg As String = String.Empty
            args.IsValid = True

            If CInt(ViewState.Item("id_central_pedido_selecionado")) = 0 Then
                lmsg = "Um pedido deve ser selecionado para início do processo de inclusão da nota."
                args.IsValid = False
            End If

            If args.IsValid = True Then
                Dim centralnotas As New CentralNotas(CInt(ViewState.Item("id_central_notas_importacao_detalhe")))

                Dim pedido As New Pedido
                pedido.id_central_pedido = CInt(ViewState.Item("id_central_pedido_selecionado"))
                pedido.nr_valor_nota = centralnotas.nr_valor_nf

                Dim dspedido As DataSet = pedido.getCentralPedidoConsTotalPedidoExcedido

                If dspedido.Tables(0).Rows.Count > 0 Then
                    If dspedido.Tables(0).Rows(0).Item("valorexcedido") = 1 Then
                        args.IsValid = False
                        lmsg = "O valor da Nota Fiscal selecionada excede o valor total do Pedido em mais de 20%. A nota não pode ser associada ao pedido."
                    End If
                Else
                    args.IsValid = False
                    lmsg = "Erro na passagem de parâmetros. Contacte o administrador do sistema."

                End If

            End If


            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_manterpedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_manterpedido.Click
        If Page.IsValid Then
            Try
                Dim notas As New CentralNotas

                notas.id_central_pedido = lbl_pedido.Text
                notas.id_central_notas_importacao = ViewState.Item("id_central_notas_importacao_detalhe")
                notas.id_modificador = Session("id_login")

                notas.atulizarPedidosNotasManual()

                loadDataFiles()
                pnl_pedido.Visible = False
                pnl_romaneio.Visible = False
                pnl_selecao_pedidos.Visible = False
                ViewState.Item("id_central_pedido_selecionado") = 0
                ViewState.Item("id_central_notas_importacao_detalhe") = 0

                messageControl.Alert("Nota Incluída com sucesso!")
            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try


        End If
    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        Me.carregarCamposProdutor()

    End Sub
    Private Sub carregarCamposProdutor()
        Try
            Me.lbl_nm_pessoa.Text = String.Empty
            Me.lbl_cpf_produtor.Text = String.Empty

            If (Not Me.customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = Me.customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString()
            End If
            If Not (Me.customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = Me.customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString()
                If (Convert.ToInt32(Me.hf_id_produtor.Value.ToString()) > 0) Then
                    Me.loadDadosProdutor(Convert.ToInt32(Me.hf_id_produtor.Value))
                End If
            End If
            Me.customPage.clearFilters("lupa_produtor")
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_notas_importar.aspx")

    End Sub

 
End Class
