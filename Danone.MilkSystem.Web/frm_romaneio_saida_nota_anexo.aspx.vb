Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports system.Data.SqlClient
Imports RK.GlobalTools
Imports System.Xml

Partial Class frm_romaneio_saida_nota_anexo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_nota_anexo.aspx")

        If Not Page.IsPostBack Then
            'If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
            '    Dim usuariolog As New UsuarioLog
            '    usuariolog.id_usuario = Session("id_login")
            '    usuariolog.ds_id_session = Session.SessionID.ToString()
            '    usuariolog.id_tipo_log = 2 'ACESSO
            '    usuariolog.id_nr_processo = Request("id")
            '    usuariolog.nm_nr_processo = Request("id")
            '    usuariolog.ds_nm_processo = "Anexar Documento"
            '    usuariolog.id_menu_item = 22
            '    usuariolog.insertUsuarioLog()
            'End If
            loadDetails()

        End If
    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("id") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id")
                ViewState.Item("tela") = Request("tela")
                ViewState.Item("id_origem") = Request("id_origem")
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()

                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Function consistirAnexo() As Boolean

        Try

            Dim lberro As Boolean = False
            Dim lmsg As String
            Dim lower As String = String.Empty

            ViewState.Item("id_tipo_anexo") = 0

            If txt_nm_documento.Text.Equals(String.Empty) Then
                lmsg = "Nome do Arquivo a ser exibido deve ser informado para continuar!"
                lberro = True
            End If

            If lberro = False Then
                If ful_documento.HasFile Then
                    lower = Me.ful_documento.PostedFile.FileName
                    lower = lower.Substring(lower.LastIndexOf("."))
                    lower = lower.ToLower()

                    If (Me.ful_documento.PostedFile.ContentLength > 2000000) Then
                        lmsg = "O documento deve possuir tamanho máximo de 2000 KB."
                        lberro = True
                    Else
                        If lower = ".pdf" OrElse lower = ".xml" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
                        Else
                            lmsg = "Somente são suportados arquivos no formato pdf, xml, jpg, jpeg, png, xls, xlsx, doc, docx."
                            lberro = True
                        End If

                    End If

                Else
                    lmsg = "Selecione um documento para anexar."
                    lberro = True
                End If
            End If
            If lberro = False Then
                Select Case cbo_tipo_documento.SelectedValue
                    Case "NF"
                        If lower = ".pdf" Then
                            ViewState.Item("id_tipo_anexo") = 1
                        Else
                            If lower = ".xml" Then
                                ViewState.Item("id_tipo_anexo") = 2
                            Else
                                lmsg = "O arquivo do tipo NF deve ser do tipo PDF ou XML."
                                lberro = True
                            End If
                        End If

                    Case "CTE"
                        If lower = ".pdf" Then
                            ViewState.Item("id_tipo_anexo") = 3
                        Else
                            If lower = ".xml" Then
                                ViewState.Item("id_tipo_anexo") = 4
                            Else
                                lmsg = "O arquivo do tipo CTE deve ser do tipo PDF ou XML."
                                lberro = True
                            End If
                        End If
                        If txt_nr_nota.Text = String.Empty Then
                            lmsg = "Para o tipo de arquivo CTE, informe o campo 'Nr Nota/CTE'."
                            lberro = True

                        End If
                        'Case "ICMS"
                        '    If lower = ".pdf" Then
                        '        ViewState.Item("id_tipo_anexo") = 6
                        '    Else
                        '        If lower = ".xml" Then
                        '            ViewState.Item("id_tipo_anexo") = 7
                        '        Else
                        '            ViewState.Item("id_tipo_anexo") = 5
                        '            cbo_tipo_documento.SelectedValue = "O"
                        '        End If
                        '    End If
                    Case "O"
                        ViewState.Item("id_tipo_anexo") = 5

                End Select
            End If
            If lberro = False Then
                If cbo_tipo_documento.SelectedValue = "NF" Then
                    Dim anexo As New RomaneioSaidaNotaAnexo
                    anexo.id_origem = ViewState.Item("id_origem").ToString
                    anexo.id_tipo_anexo = ViewState.Item("id_tipo_anexo").ToString
                    anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                    If anexo.getRomaneioSaidaNotaAnexo.Tables(0).Rows.Count > 0 Then
                        lmsg = String.Concat("Já existe NOTA FISCAL no formato ", UCase(lower), " anexada ao Romaneio de Saída.")
                        lberro = True
                    End If
                End If
                If cbo_tipo_documento.SelectedValue = "CTE" Then
                    Dim anexo As New RomaneioSaidaNotaAnexo
                    anexo.id_origem = ViewState.Item("id_origem").ToString
                    anexo.id_tipo_anexo = ViewState.Item("id_tipo_anexo").ToString
                    anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                    If anexo.getRomaneioSaidaNotaAnexo.Tables(0).Rows.Count > 0 Then
                        lmsg = String.Concat("Já existe CTE no formato ", UCase(lower), " anexado ao Romaneio de Saída.")
                        lberro = True
                    End If
                End If

            End If

            If lberro = True Then
                consistirAnexo = True
                messageControl.Alert(lmsg)
            Else
                consistirAnexo = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function


    Private Sub loadData()
        Try

            Dim anexo As New RomaneioSaidaNotaAnexo
            Dim romaneio As New RomaneioSaida

            anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida").ToString
            romaneio.id_romaneio_saida = anexo.id_romaneio_saida

            lbl_id_romaneio.Text = anexo.id_romaneio_saida.ToString

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaSolicitacaoNF
            If dsromaneio.Tables(0).Rows.Count > 0 Then
                With dsromaneio.Tables(0).Rows(0)
                    ViewState.Item("id_romaneio_saida_nota") = .Item("id_romaneio_saida_nota")
                    ViewState.Item("id_situacao_romaneio_saida_nota") = .Item("id_situacao_romaneio_saida_nota")
                    ViewState.Item("id_situacao_romaneio_saida") = .Item("id_situacao_romaneio_saida")

                    'DADOS romaneio
                    lbl_nm_st_romaneio.Text = .Item("nm_situacao_romaneio_saida").ToString
                    lbl_abertura.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                    'lbl_estabelecimento.Text = .Item("nm_estabelecimento").ToString
                    Me.lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                    Me.lbl_nm_item.Text = .Item("nm_item").ToString
                    lbl_placa.Text = .Item("ds_placa").ToString
                    lbl_destino.Text = .Item("nm_cooperativa").ToString
                    lbl_transportador.Text = .Item("nm_transportador").ToString


                    lbl_qtde.Text = FormatNumber(.Item("nr_quantidade"), 0)
                    lbl_peso_liquido_nf.Text = FormatNumber(.Item("nr_peso_liquido_nota"), 0)
                    lbl_valor_total_nf.Text = FormatNumber(.Item("nr_valor_nota_fiscal"), 2)

                    'Frete
                    If Not IsDBNull(.Item("id_frete_nf")) Then
                        'se frete CIF quem paga é o emitente, nesta caso a Danone
                        If .Item("id_frete_nf").ToString.Equals("1") Then
                            lbl_frete.Text = "Danone"
                        End If
                        'se frete FOB quem paga é o destinatario, nesta caso a COOP
                        If .Item("id_frete_nf").ToString.Equals("2") Then
                            lbl_frete.Text = "Destinatário"
                        End If
                    End If
                    If Not IsDBNull(.Item("nr_valor_frete_acordado")) Then
                        lbl_valor_frete.Text = FormatNumber(.Item("nr_valor_frete_acordado"), 2)
                    End If
                    lbl_nm_situacao_nota.Text = .Item("nm_situacao_romaneio_saida_nota").ToString

                End With
            End If
            'se veio da solicitacao de nota fiscal, é apenas um documento
            If ViewState.Item("id_origem") = "1" Then
                'tr_nota.Visible = False
                cbo_tipo_documento.Items(0).Enabled = False
                cbo_tipo_documento.Items(1).Enabled = False
                cbo_tipo_documento.Items(2).Enabled = False
                cbo_tipo_documento.Items(3).Enabled = False
                cbo_tipo_documento.SelectedValue = "O"
                anexo.id_origem = 1
            End If
            If ViewState.Item("id_origem") = "2" Then 'nota fiscal leite
                'tr_nota.Visible = True
                cbo_tipo_documento.Items(0).Enabled = False
                cbo_tipo_documento.Items(1).Enabled = False
                cbo_tipo_documento.Items(3).Enabled = False
                cbo_tipo_documento.Items(4).Enabled = False
                cbo_tipo_documento.SelectedValue = "NF"
            End If
            If ViewState.Item("id_origem") = "3" Then ' cte
                'tr_nota.Visible = True
                cbo_tipo_documento.Items(0).Enabled = False
                cbo_tipo_documento.Items(2).Enabled = False
                cbo_tipo_documento.Items(3).Enabled = False
                cbo_tipo_documento.Items(4).Enabled = False
                cbo_tipo_documento.SelectedValue = "CTE"
            End If

            Dim dsdocumentos As DataSet = anexo.getRomaneioSaidaNotaAnexo()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If ViewState.Item("id_origem") = "1" Then
                    gridResults.Columns(3).Visible = False
                End If
            Else
                btn_anexar.Enabled = True
                btn_anexar.ToolTip = String.Empty

                Dim dataRow As System.Data.DataRow = dsdocumentos.Tables(0).NewRow()
                dsdocumentos.Tables(0).Rows.InsertAt(dataRow, 0)
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdocumentos.Tables(0), "")
                gridResults.DataBind()
                gridResults.Rows(0).Cells.Clear()
                gridResults.Rows(0).Cells.Add(New TableCell())
                gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridResults.Rows(0).Cells(0).Text = "Não existem documentos anexados!"
                gridResults.Rows(0).Cells(0).ColumnSpan = 7
            End If

            'Select Case CInt(ViewState.Item("id_st_romaneio"))
            '    Case 2, 3, 7, 8
            '        btn_anexar.Visible = True
            '    Case 1,
            '        btn_anexar.Visible = False
            '        gridResults.Columns(4).Visible = False

            'End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lid As String
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim lbl_id_tipo_anexo As Label = CType(e.Row.FindControl("lbl_id_tipo_anexo"), Label)
            Dim lbl_id_origem As Label = CType(e.Row.FindControl("lbl_id_origem"), Label)
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = Me.gridResults.DataKeys(e.Row.RowIndex).Value.ToString

                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 11)
            End If

            If CInt(ViewState.Item("id_situacao_romaneio_saida")) >= 8 Then
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
            Else
                Select Case CInt(ViewState.Item("id_situacao_romaneio_saida_nota"))
                    Case 2, 3
                        If lbl_id_origem.Text = "1" Then 'anexo veio da solicitacao
                            btn_delete.Enabled = False
                            btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                            btn_delete.ToolTip = "NF já foi solicitada."
                        End If
                    Case 4 'NF Anexada
                        If lbl_id_origem.Text = "1" Then 'anexo veio da solicitacao
                            btn_delete.Enabled = False
                            btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                            btn_delete.ToolTip = "NF já foi solicitada."
                        End If
                        If lbl_id_origem.Text = "2" Then 'anexo veio da NF
                            btn_delete.Enabled = False
                            btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                            btn_delete.ToolTip = "NF já foi anexada."
                        End If
                    Case 5 'NF Anexada
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "NF e CTE já foram anexados e liberados."

                End Select
            End If
            'FRAN
            'nao podera deletar nf transf icms se a nota ja foi utilizada em outros processos... por enquando nao deixa deletar

            'If lbl_romaneio.Text = "Cooperativa" Then
            '    'se pdf ou xml de trans icms, nao deixa deletar
            '    If lbl_id_tipo_anexo.Text = "6" OrElse lbl_id_tipo_anexo.Text = "7" Then
            '        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
            '    End If
            'End If
            'If CLng(ViewState.Item("analise102coop")) > 0 Then 'se é cooperativa e tem analise 102 que obriga docto
            '    If lbl_cd_analise.Text = "102" AndAlso CInt(ViewState.Item("id_st_romaneio")) = 4 Then 'se o grid é analise 102
            '        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
            '    End If
            'End If
        End If
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nm_arquivo"
                If (ViewState.Item("sortExpression")) = "nm_documento asc" Then
                    ViewState.Item("sortExpression") = "nm_documento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_documento asc"
                End If

        End Select

        loadData()


    End Sub

    'Protected Sub deleteArquivos()
    '    Dim arquivos() As String
    '    Dim index As Integer

    '    'Obtem a lista de arquivos no diretório 
    '    arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

    '    For index = 0 To arquivos.Length - 1
    '        arquivos(index) = New FileInfo(arquivos(index)).FullName

    '        Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
    '        'Se o arquivo existir no servidor
    '        If arquivos(index) = ViewState.Item("nm_arquivo").ToString Then
    '            Arquivo.Delete()
    '        End If
    '    Next index
    'End Sub

    Protected Sub btn_anexar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anexar.Click

        Try
            If Page.IsValid AndAlso consistirAnexo() = False Then

                'If consistirAnexo() = False Then

                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + ful_documento.FileName

                Dim fileName As String = Me.ful_documento.PostedFile.FileName
                Dim lower As String = fileName.Substring(fileName.LastIndexOf("."))
                lower = lower.ToLower()
                Dim contentType As Object = Me.ful_documento.PostedFile.ContentType
                Dim contentLength As Integer = Me.ful_documento.PostedFile.ContentLength
                Dim inputStream As Stream = Me.ful_documento.PostedFile.InputStream
                Dim nrnota As String = String.Empty
                Dim schavenf As String = String.Empty
                Dim serro As String = String.Empty
                Dim smodelofrete As String = String.Empty
                Dim snrnf As String = String.Empty
                Dim sValorLiq As String = String.Empty
                Dim sDtEmissao As String = String.Empty
                Dim sserie As String = String.Empty
                Dim sqtde As String = String.Empty
                Dim scfop As String = String.Empty
                Dim schavecte As String = String.Empty
                Dim lberro As Boolean = False

                Dim romaneionota As New RomaneioSaidaNota

                romaneionota.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                romaneionota.id_romaneio_saida_nota = ViewState.Item("id_romaneio_saida_nota")
                romaneionota.id_modificador = Session("id_login")

                If ful_documento.FileName <> "" Then
                    ful_documento.SaveAs(ViewState.Item("nm_arquivo").ToString)
                End If

                'se anexo é xml e tipo de arquivo é NF, CTE 
                If lower = ".xml" AndAlso (ViewState.Item("id_tipo_anexo") = 2 OrElse ViewState.Item("id_tipo_anexo") = 4 OrElse ViewState.Item("id_tipo_anexo") = 7) Then
                    'trata o xml
                    Dim arq As New XmlDocument
                    arq.Load(ViewState.Item("nm_arquivo").ToString)
                    Dim ns As New XmlNamespaceManager(arq.NameTable)

                    Select Case CInt(ViewState.Item("id_tipo_anexo").ToString)
                        Case 2 'nf
                            ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe")
                            Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                            Dim node As XPath.XPathNavigator

                            'busca o id da chave, se nao encontrar nao é xml de NF
                            node = xpathNav.SelectSingleNode("//nfe:protNFe/nfe:infProt/nfe:chNFe", ns)
                            If node Is Nothing Then 'arquivo nao tem formato nfe
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/@Id", ns)
                                If node Is Nothing Then
                                    schavenf = "Chave não econtrada"
                                    serro = "O arquivo XML selecionado não é do tipo Nota Fiscal."
                                    lberro = True
                                End If
                            End If

                            If lberro = False Then
                                schavenf = node.InnerXml.ToString
                                'se for maior que 44 posicoes trouxe a chave do id entao retira NFE
                                If Len(schavenf) > 44 Then
                                    schavenf = Mid(schavenf, 4)
                                End If

                                romaneionota.ds_chave_nf = schavenf

                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:det/nfe:prod/nfe:CFOP", ns)
                                If Not node Is Nothing Then
                                    'guarda cfop
                                    romaneionota.cd_cfop = node.InnerXml.ToString
                                End If

                                'busca nr nota fiscal 
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
                                romaneionota.nr_nota_fiscal = node.InnerXml.ToString

                                'busca nr serie
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:serie", ns)
                                romaneionota.nr_serie_nota_fiscal = node.InnerXml.ToString

                                'busca dt emissao 
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns)
                                romaneionota.dt_emissao_nota = CDate(node.InnerXml.ToString).ToString("dd/MM/yyyy")

                                'busca valor nf
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:total/nfe:ICMSTot/nfe:vNF", ns)
                                sValorLiq = node.InnerXml.ToString

                                'busca o peso liquido da nota
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:det/nfe:prod/nfe:qCom", ns)
                                If node Is Nothing Then 'arquivo nao peso liquido
                                    sqtde = "0"
                                Else
                                    sqtde = node.InnerXml.ToString
                                End If
                                sValorLiq = Replace(sValorLiq, ".", ",")
                                sqtde = Replace(sqtde, ".", ",")

                                'busca tipo frete
                                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:transp/nfe:modFrete", ns)
                                smodelofrete = node.InnerXml.ToString
                                If smodelofrete.ToString.Equals(String.Empty) Then
                                    smodelofrete = 0
                                End If
                                romaneionota.nr_valor_nf_anexo = CDec(sValorLiq)
                                romaneionota.nr_qtde_nf_anexo = CDec(sqtde)
                                romaneionota.nr_modelo_frete = smodelofrete

                                'atualiza dadod da nota no romaneio saida nota
                                romaneionota.updateRomaneioSaidaNotaAnexoNF()


                            End If

                        Case 4 'cte
                            ns.AddNamespace("cte", "http://www.portalfiscal.inf.br/cte")

                            Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                            Dim node As XPath.XPathNavigator

                            'busca o id da chave
                            node = xpathNav.SelectSingleNode("//cte:protCTe/cte:infProt/cte:chCTe", ns)
                            If node Is Nothing Then 'arquivo nao tem formato nfe
                                node = xpathNav.SelectSingleNode("//cte:infCte/@Id", ns)
                                If node Is Nothing Then
                                    schavecte = "Chave não econtrada"
                                    serro = "O arquivo XML selecionado não é do tipo CTE."
                                    lberro = True
                                End If
                            End If

                            If lberro = False Then

                                schavecte = node.InnerXml.ToString
                                If Len(schavecte) > 44 Then
                                    schavecte = Mid(schavecte, 4)
                                End If
                                romaneionota.ds_chave_cte = schavecte

                                Dim lnodenameicms As String = String.Empty

                                'busca nr nota fiscal 
                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
                                romaneionota.nr_nota_fiscal_cte = node.InnerXml.ToString
                                'busca serie
                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:serie", ns)
                                romaneionota.nr_serie_cte = node.InnerXml.ToString
                                'busca dt emissao 
                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:dhEmi", ns)
                                romaneionota.dt_emissao_cte = CDate(node.InnerXml.ToString).ToString("dd/MM/yyyy")
                                'valor nota frete
                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:vPrest/cte:vRec", ns)
                                romaneionota.nr_valor_nota_fiscal_cte = CDec(Replace(node.InnerXml.ToString, ".", ","))
                                'CST
                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:*/cte:CST", ns)
                                romaneionota.cd_cst = node.InnerXml.ToString

                                If romaneionota.cd_cst = "40" Then
                                    romaneionota.nr_valor_icms_cte = "0"
                                Else
                                    'ir para elemento pai do CST (para saber se a tag é ICMS00 ou ICMS45 ou ICMSetc etc
                                    node.MoveToParent()
                                    lnodenameicms = node.Name.ToString

                                    'se o cst é 90 (outros) verifica se é outros ou utros outra uf ou outros simples
                                    If romaneionota.cd_cst = "90" Then
                                        Select Case Left(node.Name.ToString.ToLower, 9)
                                            Case "icmsoutra"
                                                romaneionota.cd_cst = "90_OU"
                                            Case "icmssimpl"
                                                romaneionota.cd_cst = "90_SN"

                                        End Select
                                    End If

                                    'busca valor ICMS procurando por v concatenando o nome da tag pai
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:v" + lnodenameicms, ns)
                                    If node Is Nothing Then
                                        'busca por vICMS apenas
                                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:vICMS", ns)
                                        If node Is Nothing Then
                                            romaneionota.nr_valor_icms_cte = "0"
                                        Else
                                            romaneionota.nr_valor_icms_cte = CDec(Replace(node.InnerXml.ToString, ".", ","))
                                        End If
                                    Else
                                        romaneionota.nr_valor_icms_cte = CDec(Replace(node.InnerXml.ToString, ".", ","))
                                    End If
                                End If

                                romaneionota.updateRomaneioSaidaNotaAnexoCte()

                            End If

                    End Select

                End If

                If lberro = False Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida")
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida")
                    usuariolog.ds_nm_processo = String.Concat("Anexar Docto", " - ", Mid(ViewState.Item("tela"), 1, InStr(ViewState.Item("tela"), ".aspx") - 1), " Tipo ", ViewState.Item("id_tipo_anexo").ToString)
                    If ViewState.Item("id_origem") = "1" Then
                        usuariolog.id_menu_item = 250
                    Else
                        usuariolog.id_menu_item = 251

                    End If
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Me.AnexarDocumento(lower, inputStream, contentLength, contentType, fileName)

                    'lbl_msg.Text = "Documento anexado com sucesso!"
                    txt_nm_documento.Text = String.Empty
                    If ViewState.Item("id_origem") = "1" Then
                        cbo_tipo_documento.SelectedValue = "O"
                    Else
                        cbo_tipo_documento.SelectedValue = String.Empty

                    End If
                    txt_nr_nota.Text = String.Empty
                    txt_ds_descricao.Text = String.Empty
                    ViewState.Item("id_tipo_anexo") = 0

                    ful_documento.FileContent.Close()
                    ful_documento.FileContent.Dispose()
                    ful_documento.FileContent.Flush()
                    ful_documento.PostedFile.InputStream.Dispose()
                    ful_documento.Dispose()

                    If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
                        File.Delete(ViewState.Item("nm_arquivo").ToString)
                    End If

                    messageControl.Alert("Arquivo anexado com sucesso!")

                    loadData()
                Else
                    ful_documento.FileContent.Close()
                    ful_documento.FileContent.Dispose()
                    ful_documento.FileContent.Flush()
                    ful_documento.PostedFile.InputStream.Dispose()
                    ful_documento.Dispose()

                    If File.Exists(ViewState.Item("nm_arquivo").ToString) Then
                        File.Delete(ViewState.Item("nm_arquivo").ToString)
                    End If

                    messageControl.Alert(serro)

                End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub AnexarDocumento(ByVal pext As String, ByVal inputStream As Stream, ByVal contentlength As Integer, ByVal contentType As String, ByVal filename As String)
        Try

            Dim numArray(contentlength + 1 - 1) As Byte
            inputStream.Read(numArray, 0, contentlength)

            Dim con As New SqlConnection
            con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
            con.Open()

            Dim sqlcmd As New SqlCommand
            sqlcmd.CommandType = CommandType.StoredProcedure
            sqlcmd.CommandText = "ms_insertRomaneioSaidaNotaAnexo"
            sqlcmd.Connection = con

            Dim sqlparam As New SqlParameter("@id_romaneio_saida_nota", SqlDbType.Int)
            sqlparam.Value = Convert.ToInt32(ViewState.Item("id_romaneio_saida_nota").ToString)
            sqlcmd.Parameters.Add(sqlparam)

            Dim sqlparam1 As New SqlParameter("@id_romaneio_saida", SqlDbType.Int)
            sqlparam1.Value = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
            sqlcmd.Parameters.Add(sqlparam1)

            Dim sqlparam2 As New SqlParameter("@id_tipo_anexo", SqlDbType.Int)
            sqlparam2.Value = ViewState.Item("id_tipo_anexo")
            sqlcmd.Parameters.Add(sqlparam2)

            Dim sqlparam3 As New SqlParameter("@id_origem", SqlDbType.Int)
            sqlparam3.Value = ViewState.Item("id_origem")
            sqlcmd.Parameters.Add(sqlparam3)

            Dim sqlparam4 As New SqlParameter("@nr_nota_fiscal", SqlDbType.VarChar)
            sqlparam4.Value = txt_nr_nota.Text
            sqlcmd.Parameters.Add(sqlparam4)

            Dim sqlparam5 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            sqlparam5.Value = txt_nm_documento.Text
            sqlcmd.Parameters.Add(sqlparam5)

            Dim sqlparam6 As New SqlParameter("@ds_descricao", SqlDbType.VarChar)
            sqlparam6.Value = txt_ds_descricao.Text
            sqlcmd.Parameters.Add(sqlparam6)

            Dim sqlparam7 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            sqlparam7.Value = pext
            sqlcmd.Parameters.Add(sqlparam7)

            Dim sqlparam8 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            sqlparam8.Value = filename
            sqlcmd.Parameters.Add(sqlparam8)

            Dim sqlparam9 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            sqlparam9.Value = contentlength
            sqlcmd.Parameters.Add(sqlparam9)

            Dim sqlparam10 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
            sqlparam10.Value = numArray
            sqlcmd.Parameters.Add(sqlparam10)

            Dim sqlparam11 As New SqlParameter("@id_modificador", SqlDbType.Int)
            sqlparam11.Value = Convert.ToInt32(Me.Session("id_login"))
            sqlcmd.Parameters.Add(sqlparam11)

            sqlcmd.ExecuteNonQuery()
            con.Close()

            inputStream.Close()
            inputStream.Flush()

            ' End If
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub



    'Protected Sub btn_pesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisar.Click

    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_ciq_filtro") = cbo_tipo_incidente_filtro.SelectedValue
    '    lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text

    '    'limpa inclusao de documentos
    '    cbo_ds_tipo_incidente.SelectedValue = 0
    '    chk_obrigatorio.Checked = False
    '    txt_nm_documento.Text = String.Empty
    '    fup_documento.FileContent.Flush()
    '    fup_documento.Attributes.Clear()
    '    fup_documento.Dispose()

    '    lbl_msg.Text = String.Empty


    '    loadData()

    'End Sub

    'Protected Sub btn_limpar_selecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_limpar_selecao.Click

    '    fup_documento.FileContent.Flush()
    '    fup_documento.Dispose()
    '    fup_documento.Attributes.Clear()
    '    lbl_msg.Text = String.Empty

    'End Sub

    'Protected Sub btn_limpar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limpar.Click

    '    cbo_estabelecimento.SelectedValue = 1
    '    cbo_tipo_incidente_filtro.SelectedValue = 0
    '    fup_documento.FileContent.Flush()
    '    fup_documento.Dispose()
    '    fup_documento.Attributes.Clear()

    '    txt_nm_documento.Text = String.Empty
    '    cbo_ds_tipo_incidente.SelectedValue = 0
    '    chk_obrigatorio.Checked = False
    '    lbl_msg.Text = String.Empty
    '    lbl_estabelecimento.Text = cbo_estabelecimento.SelectedItem.Text
    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_tipo_incidente_filtro") = cbo_tipo_incidente_filtro.SelectedValue
    '    gridResults.Visible = False

    '    'Response.Redirect("lst_ciq_documentos.aspx?st_incluirlog=N")

    'End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteRomaneioSaidaNotaAnexo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteRomaneioSaidaNotaAnexo(ByVal id_romaneio_saida_nota_anexo As Integer)
        Try
            Dim romaneioanexo As New RomaneioSaidaNotaAnexo

            romaneioanexo.id_romaneio_saida_nota_anexo = id_romaneio_saida_nota_anexo
            romaneioanexo.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            romaneioanexo.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
            romaneioanexo.deleteRomaneioSaidaNotaAnexo()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            If ViewState.Item("id_origem") = "1" Then
                usuariolog.id_menu_item = 250
            Else
                usuariolog.id_menu_item = 251
            End If
            usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida")
            usuariolog.nm_nr_processo = String.Concat("Romaneio Saida Nota Anexo - ", id_romaneio_saida_nota_anexo.ToString)
            usuariolog.ds_nm_processo = String.Concat("Limpar Anexo Docto", " - ", Mid(ViewState.Item("tela"), 1, InStr(ViewState.Item("tela"), ".aspx") - 1)) ', " Tipo ", ViewState.Item("id_tipo_anexo").ToString)

            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()
        Catch ex As System.Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    'Protected Sub cv_anexar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_anexar.ServerValidate
    '    If Page.IsValid Then
    '        Try

    '            Dim transitpoint As New TransitPoint
    '            Dim lmsg As String
    '            Dim lower As String

    '            args.IsValid = True

    '            If fup_documento.HasFile Then
    '                lower = Me.fup_documento.PostedFile.FileName
    '                lower = lower.Substring(lower.LastIndexOf("."))
    '                lower = lower.ToLower()

    '                If (Me.fup_documento.PostedFile.ContentLength > 2000000) Then
    '                    lmsg = "O documento deve possuir tamanho máximo de 2000 KB."
    '                    args.IsValid = False
    '                Else
    '                    If lower = ".pdf" OrElse lower = ".jpg" OrElse lower = ".png" OrElse lower = ".jpeg" OrElse lower = ".xls" OrElse lower = ".xlsx" OrElse lower = ".doc" OrElse lower = ".docx" Then
    '                    Else
    '                        lmsg = "Somente são suportados arquivos no formato pdf, jpg, jpeg, png, xls, xlsx, doc, docx."
    '                        args.IsValid = False
    '                    End If

    '                End If

    '            Else
    '                lmsg = "Selecione um documento para anexar ao CIQ."
    '                args.IsValid = False

    '            End If

    '            If args.IsValid = True Then
    '                'verifica se ja tem o documento
    '                Dim ciq As New CIQDocumentos

    '                ciq.nm_documento = txt_nm_documento.Text
    '                ciq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '                ciq.id_ciq = cbo_ds_tipo_incidente.SelectedValue
    '                If ciq.getCIQDocumentos.Tables(0).Rows.Count > 0 Then
    '                    lmsg = "Já existe este documento anexado para o incidente de qualidade " & cbo_ds_tipo_incidente.SelectedItem.Text & "."
    '                    args.IsValid = False
    '                End If

    '            End If
    '            If args.IsValid = False Then
    '                messageControl.Alert(lmsg)
    '            End If

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect(ViewState.Item("tela").ToString)

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect(ViewState.Item("tela").ToString)
    End Sub



    'Protected Sub cbo_tipo_documento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_documento.SelectedIndexChanged
    '    If Left(lbl_abertura.Text, 1) = "M" Then
    '        'se for cooperativa manual
    '        If cbo_tipo_documento.SelectedValue = "O" OrElse cbo_tipo_documento.SelectedValue = String.Empty Then
    '            rf_nrnota.enabled = False

    '        Else
    '            rf_nrnota.enabled = True
    '        End If
    '    End If
    'End Sub
End Class
