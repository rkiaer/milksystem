Imports Danone.MilkSystem.Business
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Data
Imports System.Xml
Imports system.Data.SqlClient
Imports RK.GlobalTools

Partial Class lst_romaneio_cooperativa_abertura_nota
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            If Page.IsValid Then

                lbl_Aguarde.Visible = True

                ViewState.Item("lbl_totallinhaslidas.Text") = 0
                ViewState.Item("lbl_totallinhasimportadas.Text") = 0



                loadDataFiles()
                'loadData(limportacao)
                lbl_Aguarde.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_SAP_importar_selecao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 243
            usuariolog.insertUsuarioLog()
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

            cbo_estabelecimento.SelectedValue = 1 'assume poços
            ViewState.Item("id_estabelecimento") = 1

            estabelecimento.id_estabelecimento = 1
            ViewState.Item("cd_cnpj_estabelecimento") = Replace(Replace(Replace(estabelecimento.getEstabelecimentoByFilters().Tables(0).Rows(0).Item("cd_cnpj").ToString, ".", ""), "/", ""), "-", "")

            'busca o caminho que estão os arquivos de fornecedor informados no webconfig
            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationSettings.AppSettings("ArquivoRomaneioNFe").ToString()
            ViewState.Item("sortExpressionfile") = "dt_criacao desc"

            lbl_diretorio.Text = String.Concat("..\", Right(ViewState.Item("caminho_arquivo").ToString, InStr(StrReverse(ViewState.Item("caminho_arquivo").ToString), "\") - 1))

            If Convert.ToInt32(Session("id_login")) = 102 Then 'teste para verificar acesso de diretorio
                btn_importar.Visible = True
                btnteste.Visible = True
            End If
            loadDataFiles()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Private Sub loadDataFiles()
        Try



            Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

            Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
            Dim lAllFiles As IO.FileInfo() = lDirectory.GetFiles("*nfe*.xml", SearchOption.TopDirectoryOnly)
            Dim lfoundFile As IO.FileInfo
            Dim dstable As New DataTable
            Dim ilinha As Integer = 0
            Dim arqTemp As StreamReader
            Dim llinhaarquivo As String
            Dim larraycampos() As String
            Dim schavenf As String
            Dim scnpjcoop As String
            Dim snomecoop As String
            Dim scnpjtransp As String
            Dim snometransp As String
            Dim serro As String
            Dim smodelofrete As String
            Dim snrnf As String
            Dim sValorLiq As String
            Dim sDtEmissao As String
            Dim sserie As String
            Dim sqtde As String
            Dim spocooperativa As String
            Dim scfop As String

            Dim lsarqxml(0) As String
            Dim lsarqpdf(0) As String

            dstable.Columns.Add("cd_cnpj_emitente")
            dstable.Columns.Add("nm_abreviado_cooperativa")
            dstable.Columns.Add("cd_cnpj_transportador")
            dstable.Columns.Add("nm_abreviado_transportador")
            dstable.Columns.Add("nr_nota_fiscal")
            dstable.Columns.Add("ds_chave")
            dstable.Columns.Add("nm_arquivo")
            dstable.Columns.Add("id_cooperativa")
            dstable.Columns.Add("id_transportador")
            dstable.Columns.Add("nr_modelo_frete")
            dstable.Columns.Add("nr_serie")
            dstable.Columns.Add("dt_emissao")
            dstable.Columns.Add("nr_valor_nf")
            dstable.Columns.Add("nr_peso_liquido_nota")
            dstable.Columns.Add("nr_po_cooperativa")
            dstable.Columns.Add("serro")
            dstable.Columns.Add("cd_cfop")

            For Each lfoundFile In lAllFiles

                schavenf = String.Empty
                serro = "N"

                'trata o xml
                Dim arq As New XmlDocument
                arq.Load(lfoundFile.FullName.ToString)
                Dim ns As New XmlNamespaceManager(arq.NameTable)
                ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe")

                Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                Dim node As XPath.XPathNavigator

                'busca cnpj destino que deve ser o mesmo do filtro estabelecimento
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:CNPJ", ns)
                If node Is Nothing Then 'se nao encontrar cnpj no destino vai para prox arq
                    Continue For
                Else
                    'se encontrou cnpj verifica se é o mesmo do estabelecimento
                    If Not (node.InnerXml.ToString = ViewState.Item("cd_cnpj_estabelecimento")) Then
                        Continue For 'se nao é o cnpj do estabelecimento do filtro vai para prox arq
                    End If
                End If

                'busca se nfe nao é de transferencia
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:det/nfe:prod/nfe:CFOP", ns)
                If node Is Nothing Then
                    Continue For
                End If

                ' se o cod cfop for entre 5600 e 5609 é transferencia icms
                If Left(node.InnerXml.ToString, 3) = "560" Then
                    Continue For
                End If

                'guarda cfop
                scfop = node.InnerXml.ToString

                'busca o id da chave
                node = xpathNav.SelectSingleNode("//nfe:protNFe/nfe:infProt/nfe:chNFe", ns)
                If node Is Nothing Then 'arquivo nao tem formato nfe
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/@Id", ns)
                    If node Is Nothing Then
                        schavenf = "Chave não econtrada"
                        serro = "S"
                    End If
                End If

                If schavenf.Equals(String.Empty) Then
                    schavenf = node.InnerXml.ToString
                    'se for maior que 44 posicoes trouxe a chave do id entao retira NFE
                    If Len(schavenf) > 44 Then
                        schavenf = Mid(schavenf, 4)
                    End If
                End If

                'busca nr nota fiscal 
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
                snrnf = node.InnerXml.ToString

                'busca nr serie
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:serie", ns)
                sserie = node.InnerXml.ToString

                'busca dt emissao 
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns)
                sDtEmissao = node.InnerXml.ToString

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

                'busca o nr PO
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:det/nfe:prod/nfe:xPed", ns)
                If node Is Nothing Then 'arquivo nao peso liquido
                    spocooperativa = ""
                Else
                    spocooperativa = node.InnerXml.ToString
                End If

                'busca cnpj emitente
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns)
                If node Is Nothing Then
                    scnpjcoop = "Não Encontrado XML"
                    serro = "S"
                Else
                    scnpjcoop = node.InnerXml.ToString
                    If Len(scnpjcoop) = 14 Then
                        scnpjcoop = Left(scnpjcoop, 2) & "." & Mid(scnpjcoop, 3, 3) & "." & Mid(scnpjcoop, 6, 3) & "/" & Mid(scnpjcoop, 9, 4) & "-" & Mid(scnpjcoop, 13, 2)
                    End If
                End If
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:xNome", ns)
                If node Is Nothing Then
                    snomecoop = "Não Encontrado XML"
                    serro = "S"
                Else
                    snomecoop = node.InnerXml.ToString
                End If

                'busca cnpj transportador
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:transp/nfe:transporta/nfe:CNPJ", ns)
                If node Is Nothing Then
                    scnpjtransp = "Não Encontrado XML"
                    serro = "S"
                Else
                    scnpjtransp = node.InnerXml.ToString
                    If Len(scnpjtransp) = 14 Then
                        scnpjtransp = Left(scnpjtransp, 2) & "." & Mid(scnpjtransp, 3, 3) & "." & Mid(scnpjtransp, 6, 3) & "/" & Mid(scnpjtransp, 9, 4) & "-" & Mid(scnpjtransp, 13, 2)
                    End If
                End If

                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:transp/nfe:transporta/nfe:xNome", ns)
                If node Is Nothing Then
                    snometransp = "Não Encontrado XML"
                    serro = "S"
                Else
                    snometransp = node.InnerXml.ToString
                End If

                'busca tipo frete
                node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:transp/nfe:modFrete", ns)
                smodelofrete = node.InnerXml.ToString


                sValorLiq = Replace(sValorLiq, ".", ",")
                sDtEmissao = CDate(sDtEmissao).ToString("dd/MM/yyyy")
                sqtde = Replace(sqtde, ".", ",")

                dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                With dstable.Rows.Item(ilinha)
                    arqTemp = New StreamReader(lfoundFile.FullName.ToString, Encoding.UTF7)
                    llinhaarquivo = arqTemp.ReadLine
                    larraycampos = Split(llinhaarquivo.ToString, ";")

                    .Item(0) = scnpjcoop
                    .Item(1) = snomecoop
                    .Item(2) = scnpjtransp
                    .Item(3) = snometransp
                    .Item(4) = snrnf
                    .Item(5) = schavenf
                    .Item(6) = lfoundFile.Name.ToString
                    .Item(7) = 0
                    .Item(8) = 0
                    .Item(9) = smodelofrete
                    .Item(10) = sserie
                    .Item(11) = sDtEmissao
                    .Item(12) = (sValorLiq).ToString
                    .Item(13) = (sqtde).ToString
                    .Item(14) = (spocooperativa).ToString
                    .Item(15) = serro
                    .Item(16) = scfop
                End With

                ilinha = ilinha + 1
                If Not arqTemp Is Nothing Then
                    arqTemp.Close()
                End If

            Next
            If ilinha = 0 Then
                dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

            End If
            gridFiles.Visible = True
            gridFiles.DataSource = Helper.getDataView(dstable, "")
            gridFiles.DataBind()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim importacao As New Importacao
            importacao.id_criacao = Convert.ToInt32(Session("id_login"))
            importacao.nm_arquivo = ViewState.Item("nm_arquivo")
            importacao.nm_arquivo_destino = ViewState.Item("nm_arquivo_destino")

            ViewState.Item("id_importacao") = importacao.importSAP()  ' 28/02/2012 - Projeto Themis - Importação de Fornecedores

            ViewState.Item("lbl_totallinhaslidas.Text") = CInt(ViewState.Item("lbl_totallinhaslidas.Text")) + importacao.nr_linhaslidas
            ViewState.Item("lbl_totallinhasimportadas.Text") = CInt(ViewState.Item("lbl_totallinhasimportadas.Text")) + importacao.nr_linhasimportadas


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
        Me.loadDataFiles()

    End Sub

    Protected Sub chk_todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim li As Integer
        Dim ch As CheckBox
        Dim chk_todos As CheckBox

        chk_todos = CType(sender, CheckBox)

        For li = 0 To gridFiles.Rows.Count - 1
            ch = CType(gridFiles.Rows(li).FindControl("chk_item"), CheckBox)
            ch.Checked = chk_todos.Checked
        Next
    End Sub

    Protected Sub gridFiles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridFiles.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_serro As Label = CType(e.Row.FindControl("lbl_serro"), Label)
            Dim btn_abrir As Anthem.ImageButton = CType(e.Row.FindControl("btn_abrir"), Anthem.ImageButton)

            If lbl_serro.Text = "S" Then
                btn_abrir.Enabled = False
            Else
                btn_abrir.Enabled = True
            End If
        End If
    End Sub

 
    Protected Sub gridFiles_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridFiles.Sorting
        Select Case e.SortExpression.ToLower()


            Case "nm_arquivo"
                If (ViewState.Item("sortExpressionfile")) = "nm_arquivo asc" Then
                    ViewState.Item("sortExpressionfile") = "nm_arquivo desc"
                Else
                    ViewState.Item("sortExpressionfile") = "nm_arquivo asc"
                End If

            Case "dt_criacao"
                If (ViewState.Item("sortExpressionfile")) = "dt_criacao asc" Then
                    ViewState.Item("sortExpressionfile") = "dt_criacao desc"
                Else
                    ViewState.Item("sortExpressionfile") = "dt_criacao asc"
                End If

            Case "nm_fornecedor"
                If (ViewState.Item("sortExpressionfile")) = "nm_fornecedor asc" Then
                    ViewState.Item("sortExpressionfile") = "nm_fornecedor desc"
                Else
                    ViewState.Item("sortExpressionfile") = "nm_fornecedor asc"
                End If

            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpressionfile")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpressionfile") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpressionfile") = "cd_codigo_sap asc"
                End If

        End Select

        loadDataFiles()
    End Sub

    Protected Sub btnteste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnteste.Click
        If Page.IsValid Then
            Dim li As Integer
            Dim limportacao() As Int64
            lbl_Aguarde.Visible = True

            ViewState.Item("lbl_totallinhaslidas.Text") = 0
            ViewState.Item("lbl_totallinhasimportadas.Text") = 0

            For li = 0 To gridFiles.Rows.Count - 1
                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + gridFiles.DataKeys(li).Value.ToString
                ViewState.Item("nm_arquivo_destino") = ViewState.Item("caminho_arquivo") + "\lixo\" + gridFiles.DataKeys(li).Value.ToString

                Dim importacao As New Importacao
                importacao.nm_arquivo = ViewState.Item("nm_arquivo")
                importacao.nm_arquivo_destino = ViewState.Item("nm_arquivo_destino")

                If System.IO.File.Exists(importacao.nm_arquivo_destino) Then 'verifica se existe no lixo
                    File.Delete(importacao.nm_arquivo_destino) 'delete se existit
                End If
                File.Move(importacao.nm_arquivo, importacao.nm_arquivo_destino)


                'Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(importacao.nm_arquivo)
                'If Arquivo.Exists Then
                '    'fran 27/09/2013 i melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp
                '    'Arquivo.Delete()
                '    If System.IO.File.Exists(importacao.nm_arquivo_destino) Then 'verifica se existe no TEMP
                '        File.Delete(importacao.nm_arquivo_destino) 'delete se existit
                '    End If
                '    File.Move(importacao.nm_arquivo, importacao.nm_arquivo_destino) 'move da pasta origem para TEMP
                '    'fran 27/09/2013 f melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp

                'End If

                'ReDim Preserve limportacao(li)
                ''limportacao(li) = ViewState.Item("id_importacao").ToString

            Next

            'lbl_totallidas.Visible = True
            'lbl_totalimportadas.Visible = True
            'lbl_diretorio.Visible = True
            'lbl_totallinhasimportadas.Visible = True
            'lbl_diretorio.Text = ViewState.Item("lbl_totallinhaslidas.Text").ToString
            'lbl_totallinhasimportadas.Text = ViewState.Item("lbl_totallinhasimportadas.Text").ToString
            'loadDataFiles()
            'ViewState.Item("lidimportacao") = limportacao
            'loadData(limportacao)
            'lbl_Aguarde.Visible = False
        End If


    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue = 0 Then
            ViewState.Item("cd_cnpj_estabelecimento") = String.Empty
            ViewState.Item("id_estabelecimento") = 0
        Else
            Dim estabelecimento As New Estabelecimento
            estabelecimento.id_estabelecimento = cbo_estabelecimento.SelectedValue
            ViewState.Item("cd_cnpj_estabelecimento") = Replace(Replace(Replace(estabelecimento.getEstabelecimentoByFilters().Tables(0).Rows(0).Item("cd_cnpj").ToString, ".", ""), "/", ""), "-", "")
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        End If
    End Sub

    'Protected Sub cv_files_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_files.ServerValidate
    '    Try

    '        Dim wc As WebControl = CType(source, WebControl)
    '        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
    '        Dim lbl_cnpj_cooperativa As Label = CType(row.FindControl("lbl_cnpj_cooperativa"), Label)
    '        Dim lbl_cnpj_transportador As Label = CType(row.FindControl("lbl_cnpj_transportador"), Label)
    '        Dim lbl_ds_chave As Label = CType(row.FindControl("lbl_ds_chave"), Label)
    '        Dim lbl_nm_arquivo As Label = CType(row.FindControl("lbl_nm_arquivo"), Label)
    '        Dim lbl_id_modelo_frete As Label = CType(row.FindControl("lbl_id_modelo_frete"), Label)
    '        Dim lbl_id_cooperativa As Label = CType(row.FindControl("lbl_id_cooperativa"), Label)
    '        Dim lbl_id_transportador As Label = CType(row.FindControl("lbl_id_transportador"), Label)

    '        Dim nota As New NotaFiscal
    '        Dim lmsg As String = String.Empty
    '        Dim lbpdfnfencontrado As Boolean = False
    '        Dim lbpdfctencontrado As Boolean = False
    '        Dim lbxmlctencontrado As Boolean = False
    '        Dim lidcooperativa As Integer = 0
    '        Dim lidtransportador As Integer = 0

    '        nota.ds_chave_nfe = lbl_ds_chave.Text
    '        Dim dsnotas As DataSet = nota.getNotasFiscaisByFilters
    '        If dsnotas.Tables(0).Rows.Count > 0 Then
    '            lmsg = "Chave da NFe já existe para o Romaneio " & dsnotas.Tables(0).Rows(0).Item("id_romaneio").ToString
    '            args.IsValid = False
    '        Else
    '            'se nao encontrou a chave nos cadastros
    '            Dim pessoa As New Pessoa
    '            Dim dspessoa As DataSet

    '            pessoa.cd_cnpj = lbl_cnpj_cooperativa.Text
    '            dspessoa = pessoa.getCooperativasByFilters
    '            If dspessoa.Tables(0).Rows.Count > 0 Then
    '                lidcooperativa = dspessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
    '            Else
    '                lmsg = "CNPJ Emitente não existe no Cadastro de Cooperativas do sistema."
    '                args.IsValid = False
    '            End If

    '            pessoa.cd_cnpj = lbl_cnpj_transportador.Text
    '            dspessoa = pessoa.getTransportadorCooperativaByFilters
    '            If dspessoa.Tables(0).Rows.Count > 0 Then
    '                lidtransportador = dspessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
    '            Else
    '                lmsg = "CNPJ Transportador não existe no Cadastro de Transportadores do sistema."
    '                args.IsValid = False
    '            End If

    '        End If

    '        If args.IsValid = True Then
    '            Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

    '            Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
    '            Dim lfoundFile As IO.FileInfo

    '            'verifica se existe nfe.pdf 

    '            'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + gridFiles.DataKeys(li).Value.ToString

    '            'procura o pdf da nota para anexar
    '            Dim larqpdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", lbl_ds_chave.Text, "*.pdf"), SearchOption.TopDirectoryOnly)
    '            If larqpdf.Length > 0 AndAlso larqpdf(0).Exists Then
    '                lbpdfnfencontrado = True
    '                ViewState.Item("nomearquivo_nf_pdf") = larqpdf(0).Name.ToString

    '                'verifica CTE
    '                If lbl_id_modelo_frete.Text = "1" Then
    '                    'se modelo do frete da noraé 1 significa que tem transportador cte
    '                    Dim schavecte As String
    '                    Dim schaveNFeNoCTE As String

    '                    Dim larqctexml As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", Replace(Replace(Replace(lbl_cnpj_transportador.Text, ".", ""), "/", ""), "-", ""), "57", "*.xml"), SearchOption.TopDirectoryOnly)
    '                    'procura todos os arquivos cuja chave tenha o cnpjtransportador + 57 (modelo nfe- 57 cte )
    '                    For Each lfoundFile In larqctexml
    '                        'trata o xml
    '                        Dim arq As New XmlDocument
    '                        arq.Load(lfoundFile.FullName.ToString)
    '                        Dim ns As New XmlNamespaceManager(arq.NameTable)
    '                        ns.AddNamespace("cte", "http://www.portalfiscal.inf.br/cte")

    '                        Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
    '                        Dim node As XPath.XPathNavigator

    '                        'busca o id da chave
    '                        node = xpathNav.SelectSingleNode("//cte:protCTe/cte:infProt/cte:chCTe", ns)
    '                        If node Is Nothing Then 'arquivo nao tem formato nfe
    '                            node = xpathNav.SelectSingleNode("//cte:infCte/@Id", ns)
    '                            If node Is Nothing Then
    '                                Continue For
    '                            End If
    '                        End If
    '                        schavecte = node.InnerXml.ToString
    '                        If Len(schavecte) > 44 Then
    '                            schavecte = Mid(schavecte, 4)
    '                        End If
    '                        node = xpathNav.SelectSingleNode("//cte:CTe/cte:infCte/cte:infCTeNorm/cte:infDoc/cte:infNFe/cte:chave", ns)
    '                        If node Is Nothing Then 'arquivo nao tem formato nfe
    '                            'nao encontrou chave da nota fiscal eletronica do leite
    '                            Continue For
    '                        End If
    '                        schaveNFeNoCTE = node.InnerXml.ToString
    '                        'se a chave nfe dentro do cte é a mesma chave da norta do leite
    '                        If lbl_ds_chave.Text = schaveNFeNoCTE Then
    '                            lbxmlctencontrado = True

    '                            Dim larqctepdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavecte, "*.pdf"), SearchOption.TopDirectoryOnly)
    '                            If larqctepdf.Length > 0 AndAlso larqctepdf(0).Exists Then
    '                                lbpdfctencontrado = True
    '                                ViewState.Item("nomearquivo_cte_xml") = lfoundFile.Name.ToString
    '                                ViewState.Item("nomearquivo_cte_pdf") = larqctepdf(0).Name.ToString
    '                                ViewState.Item("cte_chave") = schavecte.ToString

    '                                'busca nr nota fiscal 
    '                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
    '                                ViewState.Item("cte_nr_nota") = node.InnerXml.ToString
    '                                'busca serie
    '                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:serie", ns)
    '                                ViewState.Item("cte_serie") = node.InnerXml.ToString
    '                                'busca dt emissao 
    '                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:dhEmi", ns)
    '                                ViewState.Item("cte_dt_emissao") = CDate(node.InnerXml.ToString).ToString("dd/MM/yyyy")
    '                                'valor nota frete
    '                                node = xpathNav.SelectSingleNode("//cte:infCte/cte:vPrest/cte:vRec", ns)
    '                                ViewState.Item("cte_nr_valor") = Replace(node.InnerXml.ToString, ".", ",")

    '                                Exit For
    '                            End If
    '                        Else
    '                            Continue For 'se chave nfe encontrada no cte nao e a chave da NFe do leite, vai para prox arquivo
    '                        End If

    '                    Next


    '                    If lbxmlctencontrado = False Then
    '                        lmsg = "A Nota Fiscal selecionada tem frete FOB. O arquivo XML do CTE da Nota Fiscal não foi encontrado. O romaneio de cooperativa não pode ser aberto."
    '                        args.IsValid = False
    '                    Else
    '                        If lbpdfctencontrado = False Then
    '                            lmsg = "A Nota Fiscal selecionada tem frete FOB. O arquivo PDF do CTE da Nota Fiscal não foi encontrado. O romaneio de cooperativa não pode ser aberto."
    '                            args.IsValid = False
    '                        End If
    '                    End If
    '                Else
    '                    'se nao tem cte
    '                    ViewState.Item("nomearquivo_cte_xml") = String.Empty
    '                    ViewState.Item("nomearquivo_cte_pdf") = String.Empty
    '                    ViewState.Item("cte_chave") = String.Empty
    '                    ViewState.Item("cte_nr_nota") = String.Empty
    '                    ViewState.Item("cte_serie") = String.Empty
    '                    ViewState.Item("cte_dt_emissao") = String.Empty
    '                    ViewState.Item("cte_nr_valor") = String.Empty

    '                End If

    '            Else
    '                lmsg = "O arquivo PDF da Nota Fiscal selecionda nao foi encontrado. O romaneio de cooperativa não pode ser aberto."
    '                args.IsValid = False
    '                lbpdfnfencontrado = False
    '            End If
    '        End If


    '        If Not args.IsValid Then
    '            ViewState.Item("nomearquivo_cte_xml") = String.Empty
    '            ViewState.Item("nomearquivo_cte_pdf") = String.Empty
    '            ViewState.Item("nomearquivo_nf_pdf") = String.Empty
    '            ViewState.Item("cte_chave") = String.Empty
    '            ViewState.Item("cte_nr_nota") = String.Empty
    '            ViewState.Item("cte_serie") = String.Empty
    '            ViewState.Item("cte_dt_emissao") = String.Empty
    '            ViewState.Item("cte_nr_valor") = String.Empty

    '            messageControl.Alert(lmsg)
    '        Else
    '            'se nao tem erro
    '            'atualiza no grid id cooperativa e da transportadora
    '            lbl_id_cooperativa.Text = lidcooperativa.ToString
    '            lbl_id_transportador.Text = lidtransportador.ToString

    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Function validarNota(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs, ByRef pmsg As String) As Boolean
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            Dim lbl_cnpj_cooperativa As Label = CType(row.FindControl("lbl_cnpj_cooperativa"), Label)
            Dim lbl_cnpj_transportador As Label = CType(row.FindControl("lbl_cnpj_transportador"), Label)
            Dim lbl_ds_chave As Label = CType(row.FindControl("lbl_ds_chave"), Label)
            Dim lbl_nm_arquivo As Label = CType(row.FindControl("lbl_nm_arquivo"), Label)
            Dim lbl_id_modelo_frete As Label = CType(row.FindControl("lbl_id_modelo_frete"), Label)
            Dim lbl_id_cooperativa As Label = CType(row.FindControl("lbl_id_cooperativa"), Label)
            Dim lbl_id_transportador As Label = CType(row.FindControl("lbl_id_transportador"), Label)
            Dim bValid As Boolean = True
            Dim nota As New NotaFiscal
            Dim lmsg As String = String.Empty
            Dim lbpdfnfencontrado As Boolean = False
            Dim lbpdfctencontrado As Boolean = False
            Dim lbxmlctencontrado As Boolean = False
            Dim lidcooperativa As Integer = 0
            Dim lidtransportador As Integer = 0

            pmsg = String.Empty

            nota.ds_chave_nfe = lbl_ds_chave.Text
            Dim dsnotas As DataSet = nota.getNotasFiscaisByFilters
            If dsnotas.Tables(0).Rows.Count > 0 Then
                lmsg = "Chave da NFe já existe para o Romaneio " & dsnotas.Tables(0).Rows(0).Item("id_romaneio").ToString
                bValid = False
            Else
                'se nao encontrou a chave nos cadastros
                Dim pessoa As New Pessoa
                Dim dspessoa As DataSet

                pessoa.cd_cnpj = lbl_cnpj_cooperativa.Text
                dspessoa = pessoa.getCooperativasByFilters
                If dspessoa.Tables(0).Rows.Count > 0 Then
                    lidcooperativa = dspessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
                Else
                    lmsg = "CNPJ Emitente não existe no Cadastro de Cooperativas do sistema."
                    bValid = False
                End If

                pessoa.cd_cnpj = lbl_cnpj_transportador.Text
                dspessoa = pessoa.getTransportadorCooperativaByFilters
                If dspessoa.Tables(0).Rows.Count > 0 Then
                    lidtransportador = dspessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
                Else
                    lmsg = "CNPJ Transportador não existe no Cadastro de Transportadores do sistema."
                    bValid = False
                End If
            End If

            If bValid = True Then
                Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

                Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
                Dim lfoundFile As IO.FileInfo

                'verifica se existe nfe.pdf 

                'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + gridFiles.DataKeys(li).Value.ToString

                'procura o pdf da nota para anexar
                Dim larqpdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", lbl_ds_chave.Text, "*.pdf"), SearchOption.TopDirectoryOnly)
                If larqpdf.Length > 0 AndAlso larqpdf(0).Exists Then
                    lbpdfnfencontrado = True
                    ViewState.Item("nomearquivo_nf_pdf") = larqpdf(0).Name.ToString

                    'verifica CTE
                    If lbl_id_modelo_frete.Text = "1" Then
                        'se modelo do frete da noraé 1 significa que tem transportador cte
                        Dim schavecte As String
                        Dim schaveNFeNoCTE As String

                        Dim larqctexml As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", Replace(Replace(Replace(lbl_cnpj_transportador.Text, ".", ""), "/", ""), "-", ""), "57", "*.xml"), SearchOption.TopDirectoryOnly)
                        'procura todos os arquivos cuja chave tenha o cnpjtransportador + 57 (modelo nfe- 57 cte )
                        For Each lfoundFile In larqctexml
                            'trata o xml
                            Dim arq As New XmlDocument
                            arq.Load(lfoundFile.FullName.ToString)
                            Dim ns As New XmlNamespaceManager(arq.NameTable)
                            ns.AddNamespace("cte", "http://www.portalfiscal.inf.br/cte")

                            Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                            Dim node As XPath.XPathNavigator

                            'busca o id da chave
                            node = xpathNav.SelectSingleNode("//cte:protCTe/cte:infProt/cte:chCTe", ns)
                            If node Is Nothing Then 'arquivo nao tem formato nfe
                                node = xpathNav.SelectSingleNode("//cte:infCte/@Id", ns)
                                If node Is Nothing Then
                                    Continue For
                                End If
                            End If
                            schavecte = node.InnerXml.ToString
                            If Len(schavecte) > 44 Then
                                schavecte = Mid(schavecte, 4)
                            End If
                            node = xpathNav.SelectSingleNode("//cte:CTe/cte:infCte/cte:infCTeNorm/cte:infDoc/cte:infNFe/cte:chave", ns)
                            If node Is Nothing Then 'arquivo nao tem formato nfe
                                'nao encontrou chave da nota fiscal eletronica do leite
                                Continue For
                            End If
                            schaveNFeNoCTE = node.InnerXml.ToString
                            'se a chave nfe dentro do cte é a mesma chave da norta do leite
                            If lbl_ds_chave.Text = schaveNFeNoCTE Then
                                lbxmlctencontrado = True

                                Dim larqctepdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavecte, "*.pdf"), SearchOption.TopDirectoryOnly)
                                If larqctepdf.Length > 0 AndAlso larqctepdf(0).Exists Then
                                    lbpdfctencontrado = True
                                    Dim lnodenameicms As String = String.Empty

                                    ViewState.Item("nomearquivo_cte_xml") = lfoundFile.Name.ToString
                                    ViewState.Item("nomearquivo_cte_pdf") = larqctepdf(0).Name.ToString
                                    ViewState.Item("cte_chave") = schavecte.ToString

                                    'busca nr nota fiscal 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
                                    ViewState.Item("cte_nr_nota") = node.InnerXml.ToString
                                    'busca serie
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:serie", ns)
                                    ViewState.Item("cte_serie") = node.InnerXml.ToString
                                    'busca dt emissao 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:dhEmi", ns)
                                    ViewState.Item("cte_dt_emissao") = CDate(node.InnerXml.ToString).ToString("dd/MM/yyyy")
                                    ViewState.Item("cte_dt_emissao_completa") = CDate(node.InnerXml.ToString).ToString("dd/MM/yyyy HH:mm:ss")
                                    'valor nota frete
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:vPrest/cte:vRec", ns)
                                    ViewState.Item("cte_nr_valor") = Replace(node.InnerXml.ToString, ".", ",")
                                    'CST
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:*/cte:CST", ns)
                                    ViewState.Item("cte_cst") = node.InnerXml.ToString

                                    If ViewState.Item("cte_cst").ToString = "40" Then
                                        ViewState.Item("cte_icms") = "0"
                                        ViewState.Item("cte_base_icms") = "0"
                                    Else
                                        'ir para elemento pai do CST (para saber se a tag é ICMS00 ou ICMS45 ou ICMSetc etc
                                        node.MoveToParent()
                                        lnodenameicms = node.Name.ToString

                                        'se o cst é 90 (outros) verifica se é outros ou utros outra uf ou outros simples
                                        If ViewState.Item("cte_cst").ToString = "90" Then
                                            Select Case Left(node.Name.ToString.ToLower, 9)
                                                Case "icmsoutra"
                                                    ViewState.Item("cte_cst") = "90_OU"
                                                Case "icmssimpl"
                                                    ViewState.Item("cte_cst") = "90_SN"

                                            End Select
                                        End If

                                        'busca valor ICMS procurando por v concatenando o nome da tag pai
                                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:v" + lnodenameicms, ns)
                                        If node Is Nothing Then
                                            'busca por vICMS apenas
                                            node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:vICMS", ns)
                                            If node Is Nothing Then
                                                ViewState.Item("cte_icms") = "0"
                                            Else
                                                ViewState.Item("cte_icms") = Replace(node.InnerXml.ToString, ".", ",")
                                            End If
                                        Else
                                            ViewState.Item("cte_icms") = Replace(node.InnerXml.ToString, ".", ",")
                                        End If

                                        'busca valor base ICMS procurando por v concatenando o nome da tag pai
                                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:vBC" + lnodenameicms, ns)
                                        If node Is Nothing Then
                                            'busca por vBCICMS apenas
                                            node = xpathNav.SelectSingleNode("//cte:infCte/cte:imp/cte:ICMS/cte:" + lnodenameicms + "/cte:vBC", ns)
                                            If node Is Nothing Then
                                                ViewState.Item("cte_base_icms") = "0"
                                            Else
                                                ViewState.Item("cte_base_icms") = Replace(node.InnerXml.ToString, ".", ",")
                                            End If
                                        Else
                                            ViewState.Item("cte_base_icms") = Replace(node.InnerXml.ToString, ".", ",")
                                        End If
                                    End If

                                    'busca CFOP 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:CFOP", ns)
                                    ViewState.Item("cte_cfop") = node.InnerXml.ToString

                                    'busca UF ORIGEM 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:UFIni", ns)
                                    ViewState.Item("cte_uf_origem") = node.InnerXml.ToString

                                    'busca IBGE ORIGEM 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:cMunIni", ns)
                                    ViewState.Item("cte_ibge_origem") = node.InnerXml.ToString

                                    'busca UF destino 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:UFFim", ns)
                                    ViewState.Item("cte_uf_destino") = node.InnerXml.ToString

                                    'busca IBGE destino 
                                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:cMunFim", ns)
                                    ViewState.Item("cte_ibge_destino") = node.InnerXml.ToString

                                    'busca o id da chave
                                    node = xpathNav.SelectSingleNode("//cte:protCTe/cte:infProt/cte:nProt", ns)
                                    ViewState.Item("cte_protocolo") = node.InnerXml.ToString

                                End If
                                Exit For

                            Else
                                Continue For 'se chave nfe encontrada no cte nao e a chave da NFe do leite, vai para prox arquivo
                            End If

                        Next


                        If lbxmlctencontrado = False Then
                            lmsg = "A Nota Fiscal selecionada tem frete FOB. O arquivo XML do CTE da Nota Fiscal não foi encontrado. O romaneio de cooperativa não pode ser aberto."
                            bValid = False
                        Else
                            If lbpdfctencontrado = False Then
                                lmsg = "A Nota Fiscal selecionada tem frete FOB. O arquivo PDF do CTE da Nota Fiscal não foi encontrado. O romaneio de cooperativa não pode ser aberto."
                                bValid = False
                            End If
                        End If
                    Else
                        'se nao tem cte
                        ViewState.Item("nomearquivo_cte_xml") = String.Empty
                        ViewState.Item("nomearquivo_cte_pdf") = String.Empty
                        ViewState.Item("cte_chave") = String.Empty
                        ViewState.Item("cte_nr_nota") = String.Empty
                        ViewState.Item("cte_serie") = String.Empty
                        ViewState.Item("cte_dt_emissao") = String.Empty
                        ViewState.Item("cte_nr_valor") = String.Empty
                        ViewState.Item("cte_cst") = String.Empty
                        ViewState.Item("cte_icms") = String.Empty
                        ViewState.Item("cte_base_icms") = String.Empty
                        ViewState.Item("cte_cfop") = String.Empty
                        ViewState.Item("cte_uf_origem") = String.Empty
                        ViewState.Item("cte_ibge_origem") = String.Empty
                        ViewState.Item("cte_uf_destino") = String.Empty
                        ViewState.Item("cte_ibge_destino") = String.Empty
                        ViewState.Item("cte_protocolo") = String.Empty
                        ViewState.Item("cte_dt_emissao_completa") = String.Empty
                    End If

                Else
                    lmsg = "O arquivo PDF da Nota Fiscal selecionda nao foi encontrado. O romaneio de cooperativa não pode ser aberto."
                    bValid = False
                    lbpdfnfencontrado = False
                End If
            End If


            If Not bValid Then
                ViewState.Item("nomearquivo_cte_xml") = String.Empty
                ViewState.Item("nomearquivo_cte_pdf") = String.Empty
                ViewState.Item("nomearquivo_nf_pdf") = String.Empty
                ViewState.Item("cte_chave") = String.Empty
                ViewState.Item("cte_nr_nota") = String.Empty
                ViewState.Item("cte_serie") = String.Empty
                ViewState.Item("cte_dt_emissao") = String.Empty
                ViewState.Item("cte_nr_valor") = String.Empty
                ViewState.Item("cte_cst") = String.Empty
                ViewState.Item("cte_icms") = String.Empty
                ViewState.Item("cte_base_icms") = String.Empty
                ViewState.Item("cte_cfop") = String.Empty
                ViewState.Item("cte_uf_origem") = String.Empty
                ViewState.Item("cte_ibge_origem") = String.Empty
                ViewState.Item("cte_uf_destino") = String.Empty
                ViewState.Item("cte_ibge_destino") = String.Empty
                ViewState.Item("cte_protocolo") = String.Empty
                ViewState.Item("cte_dt_emissao_completa") = String.Empty
                pmsg = lmsg
                validarNota = False
            Else
                'se nao tem erro
                'atualiza no grid id cooperativa e da transportadora
                lbl_id_cooperativa.Text = lidcooperativa.ToString
                lbl_id_transportador.Text = lidtransportador.ToString
                validarNota = True

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Function

    Protected Sub btn_abrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim lmsg As String = String.Empty
        Try
            'se pagina valida e validacao nota ok
            If Page.IsValid AndAlso validarNota(sender, e, lmsg) = True Then

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 243
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Dim wc As WebControl = CType(sender, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

                Dim lbl_cnpj_cooperativa As Label = CType(row.FindControl("lbl_cnpj_cooperativa"), Label)
                Dim lbl_cnpj_transportador As Label = CType(row.FindControl("lbl_cnpj_transportador"), Label)
                Dim lbl_ds_chave As Label = CType(row.FindControl("lbl_ds_chave"), Label)
                Dim lbl_nr_po_cooperativa As Label = CType(row.FindControl("lbl_nr_po_cooperativa"), Label)
                Dim lbl_nm_arquivo As Label = CType(row.FindControl("lbl_nm_arquivo"), Label)
                Dim lbl_id_modelo_frete As Label = CType(row.FindControl("lbl_id_modelo_frete"), Label)
                Dim lbl_id_cooperativa As Label = CType(row.FindControl("lbl_id_cooperativa"), Label)
                Dim lbl_id_transportador As Label = CType(row.FindControl("lbl_id_transportador"), Label)
                Dim lbl_nr_nota_fiscal As Label = CType(row.FindControl("lbl_nr_nota_fiscal"), Label)
                Dim lbl_nr_serie As Label = CType(row.FindControl("lbl_nr_serie"), Label)
                Dim lbl_dt_emissao As Label = CType(row.FindControl("lbl_dt_emissao"), Label)
                Dim lbl_nr_valor_nf As Label = CType(row.FindControl("lbl_nr_valor_nf"), Label)
                Dim lbl_nr_peso_liquido_nota As Label = CType(row.FindControl("lbl_nr_peso_liquido_nota"), Label)
                Dim lbl_cd_cfop As Label = CType(row.FindControl("lbl_cd_cfop"), Label)
                Dim lberro As Boolean = False


                Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString
                Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
                Dim arrayxml As Byte()
                Dim romaneionota As New RomaneioNotas
                Dim romaneio As New Romaneio()
                Dim lidromaneionotaleite As Integer = 0
                Dim lidromaneionotacte As Integer = 0
                Dim larqNFeleite As IO.FileInfo() = lDirectory.GetFiles(lbl_nm_arquivo.Text.Trim, SearchOption.TopDirectoryOnly)
                Dim larqNFpdf As IO.FileInfo() = lDirectory.GetFiles(ViewState.Item("nomearquivo_nf_pdf").ToString, SearchOption.TopDirectoryOnly)
                Dim larqCTExml As IO.FileInfo()
                Dim larqCTEpdf As IO.FileInfo()
                If lbl_id_modelo_frete.Text = "1" Then
                    larqCTExml = lDirectory.GetFiles(ViewState.Item("nomearquivo_cte_xml").ToString, SearchOption.TopDirectoryOnly)
                    larqCTEpdf = lDirectory.GetFiles(ViewState.Item("nomearquivo_cte_pdf").ToString, SearchOption.TopDirectoryOnly)
                End If
                Dim i As Int16 = 0
                '************************************************************************
                'VERIFICA SE ARQUIVOS DE NOTAS ESTAO NO DIRETORIO DO WINDOWS (desabilitado pos ja faz no validarNota
                '************************************************************************
                ''se a nota fiscal do leite existe
                'If larqNFeleite.Length > 0 AndAlso larqNFeleite(0).Exists Then
                '    'se o pdf da nota de leite existe
                '    If larqNFpdf.Length > 0 AndAlso larqNFpdf(0).Exists Then
                '        'se a nota tem frete, deve incluir cte
                '        If lbl_id_modelo_frete.Text = "1" Then
                '            'se a nota cte xml existe, procura pdf
                '            If larqCTExml.Length > 0 AndAlso larqCTExml(0).Exists Then
                '                If larqCTEpdf.Length > 0 AndAlso larqCTEpdf(0).Exists Then
                '                    lberro = False
                '                Else
                '                    lberro = True
                '                    lmsg = String.Concat("O arquivo .PDF do CTE ", ViewState.Item("nomearquivo_cte_pdf").ToString, " não foi encontrado no diretório de notas fiscais. Por favor, verifique e tente novamente.")
                '                End If
                '            Else
                '                lberro = True
                '                lmsg = String.Concat("O arquivo .XML do CTE ", ViewState.Item("nomearquivo_cte_xml").ToString, " não foi encontrado no diretório de notas fiscais. Por favor, verifique e tente novamente.")
                '            End If
                '        End If
                '    Else
                '        'se nao encontrou a NF do leite em pdf
                '        lberro = True
                '        lmsg = String.Concat("O arquivo .PDF da NFe do leite ", ViewState.Item("nomearquivo_nf_pdf").ToString, " não foi encontrado no diretório de notas fiscais. Por favor, verifique e tente novamente.")
                '    End If
                'Else
                '    'se nao encontrou nf do leite
                '    lberro = True
                '    lmsg = String.Concat("O arquivo .XML da NFe do leite ", lbl_nm_arquivo.Text, " não foi encontrado no diretório de notas fiscais. Por favor, verifique e tente novamente.")
                'End If
                'SE NAO TEM ERRO NOS ARQUIVOS PARA INCLUSAO

                '************************************************************************
                'INCLUI MS_ROMANEIO_NOTA E MS_ROMANEIO_NOTA_ANEXO (ANEXANDO ARQUIVOS NO BANCO)
                '************************************************************************
                'INCLUI A ROMANEIO NOTA TIPO LEITE NF
                romaneionota.id_cooperativa = lbl_id_cooperativa.Text
                romaneionota.id_transportador = lbl_id_transportador.Text
                romaneionota.id_romaneio_tipo_nota = 1 'Nota fiscal do Leite
                romaneionota.ds_chave = lbl_ds_chave.Text
                romaneionota.nr_nota_fiscal = lbl_nr_nota_fiscal.Text
                romaneionota.nr_serie = lbl_nr_serie.Text
                romaneionota.dt_emissao = lbl_dt_emissao.Text
                romaneionota.nr_valor_nf = CDec(lbl_nr_valor_nf.Text)
                romaneionota.cd_cnpj_emitente = lbl_cnpj_cooperativa.Text
                romaneionota.cd_cnpj_transportador = lbl_cnpj_transportador.Text
                romaneionota.nr_modelo_frete = lbl_id_modelo_frete.Text
                romaneionota.ds_chave_nfe_leite = String.Empty
                romaneionota.nr_po_cooperativa = lbl_nr_po_cooperativa.Text
                romaneionota.cd_cst = String.Empty
                romaneionota.nr_valor_icms = 0
                romaneionota.cd_cfop = lbl_cd_cfop.Text

                'romaneionota.id_romaneio = romaneio.id_romaneio
                romaneionota.id_modificador = Session("id_login")
                lidromaneionotaleite = romaneionota.insertRomaneioNotas

                If romaneionota.nr_modelo_frete = 1 Then
                    'INCLUI A ROMANEIO NOTA TIPO CTE
                    romaneionota.id_romaneio_tipo_nota = 2 'Nota fiscal CTE
                    romaneionota.ds_chave_nfe_leite = romaneionota.ds_chave
                    romaneionota.cd_cnpj_emitente = romaneionota.cd_cnpj_transportador
                    romaneionota.cd_cnpj_transportador = String.Empty
                    romaneionota.ds_chave = ViewState.Item("cte_chave").ToString
                    romaneionota.nr_nota_fiscal = ViewState.Item("cte_nr_nota").ToString
                    romaneionota.nr_serie = ViewState.Item("cte_serie").ToString
                    romaneionota.dt_emissao = ViewState.Item("cte_dt_emissao").ToString
                    romaneionota.nr_valor_nf = CDec(ViewState.Item("cte_nr_valor").ToString)
                    romaneionota.cd_cst = ViewState.Item("cte_cst").ToString
                    romaneionota.nr_valor_icms = CDec(ViewState.Item("cte_icms").ToString)
                    romaneionota.nr_modelo_frete = 0
                    romaneionota.cd_cfop = ViewState.Item("cte_cfop").ToString
                    romaneionota.dt_emissao_completa = ViewState.Item("cte_dt_emissao_completa").ToString
                    romaneionota.nr_base_icms = CDec(ViewState.Item("cte_base_icms"))
                    romaneionota.cd_uf_origem = ViewState.Item("cte_uf_origem").ToString
                    romaneionota.cd_uf_destino = ViewState.Item("cte_uf_destino").ToString
                    romaneionota.cd_ibge_origem = ViewState.Item("cte_ibge_origem").ToString
                    romaneionota.cd_ibge_destino = ViewState.Item("cte_ibge_destino").ToString
                    romaneionota.ds_protocolo = ViewState.Item("cte_protocolo").ToString

                    lidromaneionotacte = romaneionota.insertRomaneioNotas
                End If

                If lidromaneionotaleite > 0 Then
                    If lbl_id_modelo_frete.Text = "1" Then
                        If lidromaneionotacte = 0 Then
                            lberro = True
                            lmsg = "Problemas na inclusão da Nota do CTE. Contacte o administrador do sistema."
                        End If
                    End If
                Else
                    lberro = True
                    lmsg = "Problemas na inclusão da Nota do Leite. Contacte o administrador do sistema."
                End If


                If lberro = False Then
                    'PREPARA PARA GRAVAR NO BANCO O XML DA NOTA
                    Dim arqxml As StreamReader = New StreamReader(larqNFeleite(0).FullName.ToString)
                    arrayxml = New Byte(arqxml.BaseStream.Length - 1) {}
                    arqxml.BaseStream.Read(arrayxml, 0, arrayxml.Length)
                    arqxml.Close()
                    arqxml.Dispose()

                    Dim con As New SqlConnection
                    con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                    con.Open()

                    Dim sqlcmd As New SqlCommand
                    sqlcmd.CommandType = CommandType.StoredProcedure
                    sqlcmd.CommandText = "ms_insertRomaneioNotasAnexo"
                    sqlcmd.Connection = con

                    'Dim sqlparam As New SqlParameter("@id_romaneio", SqlDbType.Int)
                    'sqlparam.Value = Convert.ToInt32(romaneionota.id_romaneio)
                    'sqlcmd.Parameters.Add(sqlparam)

                    Dim sqlparam1 As New SqlParameter("@id_romaneio_notas", SqlDbType.Int)
                    sqlparam1.Value = Convert.ToInt32(lidromaneionotaleite)
                    sqlcmd.Parameters.Add(sqlparam1)

                    Dim sqlparam2 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                    sqlparam2.Value = larqNFeleite(0).Name.ToString
                    sqlcmd.Parameters.Add(sqlparam2)

                    Dim sqlparam3 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                    sqlparam3.Value = larqNFeleite(0).FullName
                    sqlcmd.Parameters.Add(sqlparam3)

                    Dim sqlparam4 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                    sqlparam4.Value = larqNFeleite(0).Extension
                    sqlcmd.Parameters.Add(sqlparam4)

                    Dim sqlparam5 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                    sqlparam5.Value = larqNFeleite(0).Length.ToString
                    sqlcmd.Parameters.Add(sqlparam5)

                    Dim sqlparam6 As New SqlParameter("@varbin_nota", SqlDbType.VarBinary, arrayxml.Length)
                    sqlparam6.Value = arrayxml 'buffer
                    sqlcmd.Parameters.Add(sqlparam6)

                    Dim sqlparam7 As New SqlParameter("@id_modificador", SqlDbType.Int)
                    sqlparam7.Value = Convert.ToInt32(Me.Session("id_login"))
                    sqlcmd.Parameters.Add(sqlparam7)

                    i = sqlcmd.ExecuteNonQuery() 'inclui
                    If i = 0 Then
                        lberro = True
                        lmsg = "Não foi possível anexar o XML da Nota do Leite. Contacte o administrador do sistema."
                    Else
                        i = 0
                    End If

                    'PREPARA PARA INCLUIR NO BANCO O PDF DA NOTA
                    'procura o pdf da nota para anexar
                    Dim oStreamReader As StreamReader = New StreamReader(larqNFpdf(0).FullName.ToString)
                    Dim arraypdf As Byte() = New Byte(oStreamReader.BaseStream.Length - 1) {}
                    oStreamReader.BaseStream.Read(arraypdf, 0, arraypdf.Length)
                    oStreamReader.Close()
                    oStreamReader.Dispose()

                    'sqlcmd.Parameters("@id_romaneio").Value = Convert.ToInt32(romaneionota.id_romaneio)
                    'sqlcmd.Parameters("@id_romaneio_notas").Value = Convert.ToInt32(lidromaneionotaleite)
                    sqlcmd.Parameters("@nm_documento").Value = larqNFpdf(0).Name.ToString
                    sqlcmd.Parameters("@nm_arquivo").Value = larqNFpdf(0).FullName
                    sqlcmd.Parameters("@nm_extensao").Value = larqNFpdf(0).Extension
                    sqlcmd.Parameters("@nr_tamanho").Value = larqNFpdf(0).Length.ToString
                    'sqlcmd.Parameters("@id_modificador").Value = Convert.ToInt32(Me.Session("id_login"))

                    'sqlcmd.Parameters.Remove(sqlcmd.Parameters("@varbin_nota"))
                    sqlcmd.Parameters.Remove(sqlparam6) 'remove varbin
                    sqlparam6.Size = arraypdf.Length
                    sqlparam6.Value = arraypdf 'buffer
                    sqlcmd.Parameters.Add(sqlparam6)

                    i = sqlcmd.ExecuteNonQuery() 'inclui anexo nf pdf
                    If i = 0 Then
                        lberro = True
                        lmsg = "Não foi possível anexar o PDF da Nota do Leite. Contacte o administrador do sistema."
                    Else
                        i = 0
                    End If

                    'se deve anexar CTE
                    If lbl_id_modelo_frete.Text.Equals("1") Then

                        'PREPARA PARA GRAVAR NO BANCO O XML Do CTE
                        Dim arqxmlcte As StreamReader = New StreamReader(larqCTExml(0).FullName.ToString)
                        arrayxml = New Byte(arqxmlcte.BaseStream.Length - 1) {}
                        arqxmlcte.BaseStream.Read(arrayxml, 0, arrayxml.Length)
                        arqxmlcte.Close()
                        arqxmlcte.Dispose()

                        'sqlcmd.Parameters("@id_romaneio").Value = Convert.ToInt32(romaneionota.id_romaneio)
                        sqlcmd.Parameters("@id_romaneio_notas").Value = Convert.ToInt32(lidromaneionotacte)
                        sqlcmd.Parameters("@nm_documento").Value = larqCTExml(0).Name.ToString
                        sqlcmd.Parameters("@nm_arquivo").Value = larqCTExml(0).FullName
                        sqlcmd.Parameters("@nm_extensao").Value = larqCTExml(0).Extension
                        sqlcmd.Parameters("@nr_tamanho").Value = larqCTExml(0).Length.ToString
                        'sqlcmd.Parameters("@id_modificador").Value = Convert.ToInt32(Me.Session("id_login"))
                        sqlcmd.Parameters.Remove(sqlparam6) 'remove varbin
                        sqlparam6.Size = arrayxml.Length
                        sqlparam6.Value = arrayxml 'buffer
                        sqlcmd.Parameters.Add(sqlparam6)

                        i = sqlcmd.ExecuteNonQuery() 'inclui anexo cte xml
                        If i = 0 Then
                            lberro = True
                            lmsg = "Não foi possível anexar o XML do CTE. Contacte o administrador do sistema."
                        Else
                            i = 0
                        End If

                        'PREPARA PARA GRAVAR NO BANCO O PDF Do CTE
                        Dim arqpdfcte As StreamReader = New StreamReader(larqCTEpdf(0).FullName.ToString)
                        arraypdf = New Byte(arqpdfcte.BaseStream.Length - 1) {}
                        arqpdfcte.BaseStream.Read(arraypdf, 0, arraypdf.Length)
                        arqpdfcte.Close()
                        arqpdfcte.Dispose()

                        'sqlcmd.Parameters("@id_romaneio").Value = Convert.ToInt32(romaneionota.id_romaneio)
                        'sqlcmd.Parameters("@id_romaneio_notas").Value = Convert.ToInt32(lidromaneionotacte)
                        sqlcmd.Parameters("@nm_documento").Value = larqCTEpdf(0).Name.ToString
                        sqlcmd.Parameters("@nm_arquivo").Value = larqCTEpdf(0).FullName
                        sqlcmd.Parameters("@nm_extensao").Value = larqCTEpdf(0).Extension
                        sqlcmd.Parameters("@nr_tamanho").Value = larqCTEpdf(0).Length.ToString
                        'sqlcmd.Parameters("@id_modificador").Value = Convert.ToInt32(Me.Session("id_login"))
                        sqlcmd.Parameters.Remove(sqlparam6) 'remove varbin
                        sqlparam6.Size = arraypdf.Length
                        sqlparam6.Value = arraypdf 'buffer
                        sqlcmd.Parameters.Add(sqlparam6)

                        i = sqlcmd.ExecuteNonQuery() 'inclui anexo cte pdf
                        If i = 0 Then
                            lberro = True
                            lmsg = "Não foi possível anexar o PDF do CTE. Contacte o administrador do sistema."
                        Else
                            i = 0
                        End If

                    End If
                    con.Close()

                End If
                '************************************************************************
                'ABRE O ROMANEIO DE COOPERATIVA (APENAS MS_ROMANEIO ) abre com situacao aberto incompleto.
                '************************************************************************

                If lberro = False Then
                    'Abrir romaneio cooperativa
                    romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                    romaneio.id_cooperativa = Convert.ToInt32(lbl_id_cooperativa.Text)
                    romaneio.id_transportador = Convert.ToInt32(lbl_id_transportador.Text)
                    romaneio.nr_nota_fiscal = lbl_nr_nota_fiscal.Text.ToString
                    romaneio.nr_serie_nota_fiscal = lbl_nr_serie.Text.ToString
                    romaneio.dt_saida_nota = lbl_dt_emissao.Text
                    If Not (lbl_nr_peso_liquido_nota.Text.Trim.Equals("0")) Then
                        romaneio.nr_peso_liquido_nota = Convert.ToDecimal(lbl_nr_peso_liquido_nota.Text)
                    End If
                    romaneio.nr_valor_nota_fiscal = Convert.ToDecimal(lbl_nr_valor_nf.Text)
                    romaneio.nr_po_cooperativa = lbl_nr_po_cooperativa.Text.ToString
                    romaneio.id_modificador = Session("id_login")
                    romaneio.id_romaneio = romaneio.insertRomaneioCooperativabyNota

                    If romaneio.id_romaneio = 0 Then
                        lberro = True
                        lmsg = "Já existe o Romaneio cadastrado para a cooperativa e nota selecionada."
                    Else
                        'Atualiza o id_romaneio nas notas e anexos
                        romaneionota.id_romaneio = romaneio.id_romaneio
                        romaneionota.id_romaneio_notas = Convert.ToInt32(lidromaneionotaleite)
                        romaneionota.id_modificador = Session("id_login")
                        romaneionota.updateRomaneioNotasEAnexos()

                        If lidromaneionotacte > 0 Then
                            romaneionota.id_romaneio_notas = Convert.ToInt32(lidromaneionotacte)
                            romaneionota.updateRomaneioNotasEAnexos()
                        End If

                        ' Exclui o arquivo do servidor
                        Dim ldestino As String = String.Concat(lscaminhoarquivo, "\lixo\")
                        'arquivo nf leite xml
                        If System.IO.File.Exists(String.Concat(ldestino, lbl_nm_arquivo.Text)) Then 'verifica se existe no lixo
                            File.Delete(String.Concat(ldestino, lbl_nm_arquivo.Text)) 'delete se existit
                        End If
                        File.Move(String.Concat(lscaminhoarquivo, "\", lbl_nm_arquivo.Text), String.Concat(ldestino, lbl_nm_arquivo.Text))
                        'arquivo nf leite pdf
                        If System.IO.File.Exists(String.Concat(ldestino, ViewState.Item("nomearquivo_nf_pdf").ToString)) Then 'verifica se existe no lixo
                            File.Delete(String.Concat(ldestino, ViewState.Item("nomearquivo_nf_pdf").ToString)) 'delete se existit
                        End If
                        File.Move(String.Concat(lscaminhoarquivo, "\", ViewState.Item("nomearquivo_nf_pdf").ToString), String.Concat(ldestino, ViewState.Item("nomearquivo_nf_pdf").ToString))

                        If lbl_id_modelo_frete.Text.Equals("1") Then

                            'arquivo cte xml
                            If System.IO.File.Exists(String.Concat(ldestino, ViewState.Item("nomearquivo_cte_xml").ToString)) Then 'verifica se existe no lixo
                                File.Delete(String.Concat(ldestino, ViewState.Item("nomearquivo_cte_xml").ToString)) 'delete se existit
                            End If
                            File.Move(String.Concat(lscaminhoarquivo, "\", ViewState.Item("nomearquivo_cte_xml").ToString), String.Concat(ldestino, ViewState.Item("nomearquivo_cte_xml").ToString))

                            'arquivo cte pdf
                            If System.IO.File.Exists(String.Concat(ldestino, ViewState.Item("nomearquivo_cte_pdf").ToString)) Then 'verifica se existe no lixo
                                File.Delete(String.Concat(ldestino, ViewState.Item("nomearquivo_cte_pdf").ToString)) 'delete se existit
                            End If
                            File.Move(String.Concat(lscaminhoarquivo, "\", ViewState.Item("nomearquivo_cte_pdf").ToString), String.Concat(ldestino, ViewState.Item("nomearquivo_cte_pdf").ToString))

                        End If
                    End If
                End If
                If lberro = True Then
                    messageControl.Alert(lmsg)
                Else
                    Response.Redirect("frm_romaneio_cooperativa_abertura.aspx?id_romaneio_cooperativa=" + romaneio.id_romaneio.ToString)
                End If


            Else
                'se validacao tem erro
                If Not lmsg.Equals(String.Empty) Then
                    messageControl.Alert(lmsg)
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
End Class
