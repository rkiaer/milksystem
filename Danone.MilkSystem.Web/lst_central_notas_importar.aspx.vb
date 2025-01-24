
Imports Danone.MilkSystem.Business
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Data
Imports System.Xml
Imports system.Data.SqlClient
Imports RK.GlobalTools
Partial Class lst_central_notas_importar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_notas_importar.aspx")
        If Not Page.IsPostBack Then
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 235
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 
            End If
            loadDetails()
        End If
    End Sub
    Private Sub loadDetails()

        Dim status As New SituacaoCentralNotas

        'busca o ultimo nr de importacao e força no filtro de pesquisa
        Dim importacao As New Importacao
        importacao.st_tipo_importacao = 5

        Dim dsimportacao As DataSet = importacao.getImportacaoByFilters
        ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationSettings.AppSettings("ArquivoCentralNFe").ToString()

        lbl_nm_diretorio.Text = String.Concat("..", Mid(ViewState.Item("caminho_arquivo").ToString, InStrRev(ViewState.Item("caminho_arquivo").ToString, "\")))

        If dsimportacao.Tables(0).Rows.Count > 0 Then
            lbl_nr_importacao_ultimo.Text = Helper.getDataView(dsimportacao.Tables(0), "id_importacao desc").Item(0).Item("id_importacao").ToString
        End If

        cbo_situacao_nota.DataSource = status.getSituacoesCentralNotasByFilters()
        cbo_situacao_nota.DataTextField = "nm_situacao_central_notas"
        cbo_situacao_nota.DataValueField = "id_situacao_central_notas"
        cbo_situacao_nota.DataBind()
        cbo_situacao_nota.Items.Insert(0, New ListItem("[Todas Incluídas]", "90"))
        cbo_situacao_nota.Items.Insert(0, New ListItem("[Todas Pendentes]", "99"))
        cbo_situacao_nota.Items.Insert(0, New ListItem("[Selecione]", "0"))

        loadDataFiles()

    End Sub
 
    Private Sub loadDataFiles()

        Try

            Dim bsemfiltro As Boolean = False
            Dim centralnota As New CentralNotas

            If Not Me.txt_dt_referencia.Text.Trim = String.Empty Then
                ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
                ViewState.Item("dt_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
                ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate("01/" + Me.txt_dt_referencia.Text.Trim))).ToString

                If Not txt_dia_fim.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_ini") = DateTime.Parse(Right("00" & txt_dia_ini.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                    ViewState.Item("dt_fim") = DateTime.Parse(Right("00" & txt_dia_fim.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                End If
                centralnota.dt_ini = ViewState.Item("dt_ini")
                centralnota.dt_fim = ViewState.Item("dt_fim")

                bsemfiltro = True
            Else
                ViewState.Item("dt_referencia") = String.Empty
                ViewState.Item("dt_ini") = String.Empty
                ViewState.Item("dt_fim") = String.Empty
            End If

            If Not Me.txt_dt_importacao.Text.Trim = String.Empty Then
                centralnota.dt_criacao = Me.txt_dt_importacao.Text.Trim
                bsemfiltro = True
            End If
            If Not Me.txt_nr_importacao.Text.Trim = String.Empty Then
                centralnota.id_importacao = txt_nr_importacao.Text.Trim()
                bsemfiltro = True
            End If
            If cbo_situacao_nota.SelectedValue > 0 Then
                centralnota.id_situacao_central_notas = cbo_situacao_nota.SelectedValue
                bsemfiltro = True
            End If
            If Not txt_nm_emitente.Text = String.Empty Then
                centralnota.nm_emitente = txt_nm_emitente.Text
                bsemfiltro = True
            End If
            If Not txt_nm_produtor.Text = String.Empty Then
                centralnota.nm_destino = txt_nm_produtor.Text
                bsemfiltro = True
            End If
            If Not txt_nr_nota.Text = String.Empty Then
                centralnota.nr_nota_fiscal = txt_nr_nota.Text
                bsemfiltro = True
            End If
            If Not txt_nr_pedido_nota.Text = String.Empty Then
                centralnota.nr_pedido = txt_nr_pedido_nota.Text
                bsemfiltro = True
            End If
            If Not txt_id_pedido_central.Text = String.Empty Then
                centralnota.id_central_pedido = txt_id_pedido_central.Text
                bsemfiltro = True
            End If

            'notas nao importadas
            If chk_notasnaoimportadas.Checked = True Then
                gridFiles.Visible = False
                Dim importacaolog As New ImportacaoLog
                importacaolog.st_importacao = 5
                If Not txt_nr_importacao.Text = String.Empty Then
                    importacaolog.id_importacao = txt_nr_importacao.Text
                End If
                gridFiles.Visible = False
                gridDoc.Visible = False
                pnl_romaneio.Visible = False

                Dim dslog As DataSet = importacaolog.getImportacaoLogByFilters()
                If (dslog.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dslog.Tables(0), "id_importacao desc, nr_linha")
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False
                'se nao tem filtro
                If bsemfiltro = False Then
                    Me.txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
                    Me.txt_dia_ini.Enabled = True
                    txt_dia_fim.Enabled = True
                    ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
                    ViewState.Item("dt_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
                    ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate("01/" + Me.txt_dt_referencia.Text.Trim))).ToString

                    centralnota.dt_ini = ViewState.Item("dt_ini")
                    centralnota.dt_fim = ViewState.Item("dt_fim")
                End If

                Dim dsnotas As DataSet = centralnota.getCentralNotasImportacao
                If (dsnotas.Tables(0).Rows.Count > 0) Then
                    gridFiles.Visible = True
                    gridDoc.Visible = False
                    pnl_romaneio.Visible = False

                    gridFiles.DataSource = Helper.getDataView(dsnotas.Tables(0), "nm_emitente, nm_destino")
                    gridFiles.DataBind()
                Else
                    gridFiles.Visible = False
                    gridDoc.Visible = False
                    pnl_romaneio.Visible = False

                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            End If


            'Dim lscaminhoarquivo As String = txt_caminho_arquivos.Text

            'Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
            'Dim lAllFiles As IO.FileInfo() = lDirectory.GetFiles("*nfe*.xml")
            'Dim lfoundFile As IO.FileInfo
            'Dim dstable As New DataTable
            'Dim ilinha As Integer = 0
            'Dim ilinhaimportada As Integer = 0

            'Dim arrayxml As Byte()

            'Dim lpos As Int16 = 0
            'Dim lnrpedido As String = String.Empty
            'Dim importacao As New Importacao

            'importacao.id_importacao = ViewState.Item("id_importacao")
            'importacao.id_criacao = Session("id_login")

            'Dim importacaolog As New ImportacaoLog
            'importacaolog.id_importacao = importacao.id_importacao

            'Dim centralnotas As New CentralNotas
            'centralnotas.id_importacao = importacao.id_importacao
            'centralnotas.id_modificador = importacao.id_criacao

            'For Each lfoundFile In lAllFiles

            '    ilinha = ilinha + 1

            '    'trata o xml
            '    Dim arq As New XmlDocument
            '    arq.Load(lfoundFile.FullName.ToString)
            '    Dim ns As New XmlNamespaceManager(arq.NameTable)
            '    ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe")

            '    Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
            '    Dim node As XPath.XPathNavigator

            '    'busca o id da chave
            '    node = xpathNav.SelectSingleNode("//nfe:protNFe/nfe:infProt/nfe:chNFe", ns)
            '    Dim schavenf As String = node.InnerXml.ToString

            '    'antes de continuar verifica se a nota já foi importada
            '    centralnotas.ds_chave_acesso = schavenf
            '    'se tem chave de acesso o arquivo ja foi importado
            '    If centralnotas.getCentralNotasImportacao.Tables.Count > 0 Then
            '        importacaolog.nr_linha = ilinha
            '        importacaolog.st_importacao = "10"
            '        importacaolog.cd_erro = "00001"
            '        importacaolog.nm_erro = "Erro: Chave da nota já existe nos cadastros do MILK.*" & lfoundFile.FullName.ToString
            '        importacaolog.insertImportacaoLog()
            '    Else
            '        ilinhaimportada = ilinhaimportada + 1
            '        'busca nr nota fiscal 
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
            '        Dim sNF As String = node.InnerXml.ToString
            '        'busca dt emissao 
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns)
            '        Dim sDtEmissao As String = node.InnerXml.ToString
            '        'busca cnpj emitente
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns)
            '        Dim sCNPJ As String = node.InnerXml.ToString
            '        'busca nome emitente
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:xNome", ns)
            '        Dim sNomeEmit As String = node.InnerXml.ToString
            '        'busca cnpj emitente
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:CPF", ns)
            '        Dim sCPFdest As String = node.InnerXml.ToString
            '        'busca cnpj emitente
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:xNome", ns)
            '        Dim sNomedest As String = node.InnerXml.ToString
            '        'busca cnpj emitente
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:cobr/nfe:fat/nfe:vLiq", ns)
            '        Dim sValorLiq As String = node.InnerXml.ToString
            '        'busca nome informcoes do pedido
            '        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:infAdic/nfe:infCpl", ns)
            '        Dim sinformacoes As String = node.InnerXml.ToString
            '        lpos = InStr(1, sinformacoes, "DAN*")
            '        'Se encontrou, pega o nr do pedido, se nao encontrou não tem nrmero na nota
            '        If lpos > 0 Then
            '            sinformacoes = Mid(sinformacoes, lpos + 4)
            '            lpos = InStr(1, sinformacoes, "*")
            '            If lpos > 0 Then
            '                lnrpedido = Mid(sinformacoes, 1, lpos - 1)
            '            Else
            '                lnrpedido = "0"
            '            End If
            '        End If

            '        'prepara para incluir centra_notas_imprtcao
            '        If Len(sCNPJ) = 14 Then
            '            sCNPJ = Left(sCNPJ, 2) & "." & Mid(sCNPJ, 3, 3) & "." & Mid(sCNPJ, 6, 3) & "/" & Mid(sCNPJ, 9, 4) & "-" & Mid(sCNPJ, 13, 2)
            '        End If

            '        ' CPF
            '        If Trim(sCPFdest) <> "" And Trim(sCPFdest) <> "?" And Len(sCPFdest) = 11 Then
            '            sCPFdest = Left(sCPFdest, 3) & "." & Mid(sCPFdest, 4, 3) & "." & Mid(sCPFdest, 7, 3) & "-" & Mid(sCPFdest, 10, 2)
            '        End If

            '        'INCLUI A CENTRAL NOTA
            '        centralnotas.ds_chave_acesso = schavenf
            '        centralnotas.nr_nota_fiscal = sNF
            '        centralnotas.dt_emissao = sDtEmissao
            '        centralnotas.nr_valor_nf = CDec(sValorLiq)
            '        centralnotas.nm_emitente = sNomeEmit
            '        centralnotas.cd_cnpj_emit = sCNPJ
            '        centralnotas.nm_destino = sNomedest
            '        centralnotas.nr_pedido = lnrpedido
            '        'incluir 
            '        centralnotas.id_central_notas_importacao = centralnotas.insertCentralNotasImportacao()

            '        'PREPARA PARA GRAVAR NO BANCO O XML DA NOTA
            '        Dim arqxml As StreamReader = New StreamReader(lfoundFile.FullName.ToString)
            '        arrayxml = New Byte(arqxml.BaseStream.Length - 1) {}
            '        arqxml.BaseStream.Read(arrayxml, 0, arrayxml.Length)

            '        arqxml.Close()
            '        arqxml.Dispose()

            '        Dim con As New SqlConnection
            '        con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
            '        con.Open()

            '        Dim sqlcmd As New SqlCommand
            '        sqlcmd.CommandType = CommandType.StoredProcedure
            '        sqlcmd.CommandText = "ms_insertCentralNotasImportacaoAnexo"
            '        sqlcmd.Connection = con

            '        Dim sqlparam As New SqlParameter("@id_central_notas_importacao", SqlDbType.Int)
            '        sqlparam.Value = Convert.ToInt32(centralnotas.id_central_notas_importacao)
            '        sqlcmd.Parameters.Add(sqlparam)

            '        Dim sqlparam1 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
            '        sqlparam1.Value = lfoundFile.Name.ToString
            '        sqlcmd.Parameters.Add(sqlparam1)

            '        Dim sqlparam2 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
            '        sqlparam2.Value = lfoundFile.FullName
            '        sqlcmd.Parameters.Add(sqlparam2)

            '        Dim sqlparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
            '        sqlparam3.Value = lfoundFile.Extension
            '        sqlcmd.Parameters.Add(sqlparam3)

            '        Dim sqlparam4 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
            '        sqlparam4.Value = lfoundFile.Length.ToString
            '        sqlcmd.Parameters.Add(sqlparam4)

            '        Dim sqlparam5 As New SqlParameter("@varbinary_nota", SqlDbType.VarBinary, arrayxml.Length)
            '        sqlparam5.Value = arrayxml 'buffer
            '        sqlcmd.Parameters.Add(sqlparam5)

            '        Dim sqlparam6 As New SqlParameter("@id_modificador", SqlDbType.Int)
            '        sqlparam6.Value = Convert.ToInt32(Me.Session("id_login"))
            '        sqlcmd.Parameters.Add(sqlparam6)

            '        sqlcmd.ExecuteNonQuery()

            '        'PREPARA PARA INCLUIR NO BANCO O PDF DA NOTA
            '        'procura o pdf da nota para anexar
            '        Dim larqpdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", node.InnerXml.ToString, "*.pdf"))
            '        'se o pdf da nota existe
            '        If larqpdf(0).Exists Then
            '            Dim oStreamReader As StreamReader = New StreamReader(larqpdf(0).FullName.ToString)
            '            Dim arraypdf As Byte() = New Byte(oStreamReader.BaseStream.Length - 1) {}

            '            oStreamReader.BaseStream.Read(arraypdf, 0, arraypdf.Length)
            '            oStreamReader.Close()
            '            oStreamReader.Dispose()

            '            Dim sqlcmdpdf As New SqlCommand
            '            sqlcmdpdf.CommandType = CommandType.StoredProcedure
            '            sqlcmdpdf.CommandText = "ms_insertCentralNotasImportacaoAnexo"
            '            sqlcmdpdf.Connection = con

            '            '"@id_central_notas_importacao"
            '            sqlcmdpdf.Parameters.Add(sqlparam)

            '            '"@nm_documento", SqlDbType.VarChar)
            '            sqlparam1.Value = larqpdf(0).Name.ToString
            '            sqlcmdpdf.Parameters.Add(sqlparam1)

            '            '"@nm_arquivo", SqlDbType.VarChar)
            '            sqlparam2.Value = larqpdf(0).FullName
            '            sqlcmdpdf.Parameters.Add(sqlparam2)

            '            '"@nm_extensao", SqlDbType.VarChar)
            '            sqlparam3.Value = larqpdf(0).Extension
            '            sqlcmdpdf.Parameters.Add(sqlparam3)

            '            '"@nr_tamanho", SqlDbType.Int)
            '            sqlparam4.Value = larqpdf(0).Length.ToString
            '            sqlcmdpdf.Parameters.Add(sqlparam4)

            '            Dim sqlparam7 As New SqlParameter("@varbinary_nota", SqlDbType.VarBinary, arraypdf.Length)
            '            sqlparam7.Value = arraypdf 'buffer
            '            sqlcmdpdf.Parameters.Add(sqlparam7)

            '            '@id_modificador", SqlDbType.Int)
            '            sqlcmdpdf.Parameters.Add(sqlparam6)

            '            sqlcmdpdf.ExecuteNonQuery()

            '        End If

            '        con.Close()

            '    End If
            'Next


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadDetalhe()

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
    Private Sub saveFilters()

        Try


            customPage.setFilter("lst_centralnotasimp", txt_dt_referencia.ID, txt_dt_referencia.Text)
            customPage.setFilter("lst_centralnotasimp", txt_dia_ini.ID, txt_dia_ini.Text)
            customPage.setFilter("lst_centralnotasimp", txt_dia_fim.ID, txt_dia_fim.Text)
            customPage.setFilter("lst_centralnotasimp", txt_dt_importacao.ID, txt_dt_importacao.Text)
            customPage.setFilter("lst_centralnotasimp", txt_nr_importacao.ID, txt_nr_importacao.Text.ToString)
            customPage.setFilter("lst_centralnotasimp", cbo_situacao_nota.ID, cbo_situacao_nota.SelectedValue)
            customPage.setFilter("lst_centralnotasimp", txt_nm_emitente.ID, txt_nm_emitente.Text)
            customPage.setFilter("lst_centralnotasimp", txt_nm_produtor.ID, txt_nm_produtor.Text)
            customPage.setFilter("lst_centralnotasimp", txt_nr_nota.ID, txt_nr_nota.Text)
            customPage.setFilter("lst_centralnotasimp", txt_nr_pedido_nota.ID, txt_nr_pedido_nota.Text)
            customPage.setFilter("lst_centralnotasimp", txt_id_pedido_central.ID, txt_id_pedido_central.Text)
            customPage.setFilter("lst_centralnotasimp", chk_notasnaoimportadas.ID, chk_notasnaoimportadas.Checked)
            customPage.setFilter("lst_centralnotasimp", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            If Page.IsValid Then
                lbl_Aguarde.Visible = True

                ViewState.Item("lbl_totallinhaslidas.Text") = 0
                ViewState.Item("lbl_totallinhasimportadas.Text") = 0

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 235
                usuariolog.ds_nm_processo = "Importação NFe"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                importData()

                lbl_totalarqsxml.Visible = True
                lbl_totalimportadas.Visible = True
                lbl_totallinhasimportadas.Visible = True
                'lbl_totallinhaslidas.Text = ViewState.Item("lbl_totallinhaslidas.Text").ToString
                lbl_totallinhasimportadas.Text = ViewState.Item("lbl_totallinhasimportadas.Text").ToString
                lbl_nrarqsxml.Text = ViewState.Item("lbl_totallinhaslidas.Text").ToString
                'loadDataFiles()
                'ViewState.Item("lidimportacao") = limportacao
                lbl_nr_importacao_ultimo.Text = ViewState.Item("id_importacao").ToString

                'loadData(limportacao)
                lbl_Aguarde.Visible = False
                If CInt(ViewState.Item("lbl_totallinhasimportadas.Text").ToString) > 0 Then
                    'limpar filtro

                    Me.txt_dt_referencia.Text = String.Empty
                    ViewState.Item("dt_referencia") = String.Empty
                    ViewState.Item("dt_ini") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                    Me.txt_dt_importacao.Text = String.Empty
                    Me.txt_nr_importacao.Text = String.Empty
                    cbo_situacao_nota.SelectedValue = 0
                    txt_nm_emitente.Text = String.Empty
                    txt_nm_produtor.Text = String.Empty
                    txt_nr_nota.Text = String.Empty
                    txt_nr_pedido_nota.Text = String.Empty
                    txt_id_pedido_central.Text = String.Empty
                    chk_notasnaoimportadas.Checked = False
                    gridResults.Visible = False

                    lbl_nr_importacao_ultimo.Text = ViewState.Item("id_importacao").ToString
                    txt_nr_importacao.Text = ViewState.Item("id_importacao").ToString

                    Dim centralnotas As New CentralNotas
                    centralnotas.id_importacao = ViewState.Item("id_importacao").ToString
                    Dim dsnotas As DataSet = centralnotas.getCentralNotasImportacao
                    If (dsnotas.Tables(0).Rows.Count > 0) Then
                        gridFiles.Visible = True
                        gridFiles.DataSource = Helper.getDataView(dsnotas.Tables(0), "nm_emitente, nm_destino")
                        gridFiles.DataBind()
                    Else
                        gridFiles.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                    messageControl.Alert("Importação realizada com sucesso!.")

                Else
                    Me.txt_dt_referencia.Text = String.Empty
                    ViewState.Item("dt_referencia") = String.Empty
                    ViewState.Item("dt_ini") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                    Me.txt_dt_importacao.Text = String.Empty
                    Me.txt_nr_importacao.Text = String.Empty
                    cbo_situacao_nota.SelectedValue = 0
                    txt_nm_emitente.Text = String.Empty
                    txt_nm_produtor.Text = String.Empty
                    txt_nr_nota.Text = String.Empty
                    txt_nr_pedido_nota.Text = String.Empty
                    txt_id_pedido_central.Text = String.Empty
                    chk_notasnaoimportadas.Checked = True
                    gridResults.Visible = True
                    gridFiles.Visible = False

                    Dim importacaolog As New ImportacaoLog
                    importacaolog.st_importacao = 5
                    importacaolog.id_importacao = lbl_nr_importacao_ultimo.Text

                    Dim dslog As DataSet = importacaolog.getImportacaoLogByFilters()
                    If (dslog.Tables(0).Rows.Count > 0) Then
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dslog.Tables(0), "nr_linha")
                        gridResults.DataBind()
                    Else
                        gridResults.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try
            Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

            ViewState.Item("tudook") = False

            Dim importacao As New Importacao
            importacao.id_criacao = Convert.ToInt32(Session("id_login"))
            importacao.nm_arquivo = lscaminhoarquivo
            importacao.st_tipo_importacao = 5
            importacao.dt_inicio_importacao = Now()

            ViewState.Item("id_importacao") = importacao.insertImportacao()

            Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)
            Dim lAllFiles As IO.FileInfo() = lDirectory.GetFiles("*nfe*.xml", SearchOption.TopDirectoryOnly)
            Dim lsarqxml(0) As String ' = Directory.GetFiles(lscaminhoarquivo, "*nfe*.xml")
            Dim lsarqpdf(0) As String
            Dim lfoundFile As IO.FileInfo
            Dim dstable As New DataTable
            Dim ilinha As Integer = 0
            Dim ilinhaimportada As Integer = 0
            Dim sNFErro As String = String.Empty
            Dim sNomeEmitErro As String = String.Empty

            Dim arrayxml As Byte()

            Dim lpos As Int16 = 0
            Dim lnrpedido As String = String.Empty

            importacao.id_importacao = ViewState.Item("id_importacao")
            importacao.id_criacao = Session("id_login")

            Dim importacaolog As New ImportacaoLog
            importacaolog.id_importacao = importacao.id_importacao
            'instancia de notas para buscar sem nenhum propriedade da classe
            Dim notas As New CentralNotas

            Dim centralnotas As New CentralNotas
            centralnotas.id_importacao = importacao.id_importacao
            centralnotas.id_modificador = importacao.id_criacao

            For Each lfoundFile In lAllFiles
                ilinha = ilinha + 1

                'trata o xml
                Dim arq As New XmlDocument
                arq.Load(lfoundFile.FullName.ToString)
                Dim ns As New XmlNamespaceManager(arq.NameTable)
                ns.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe")

                Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                Dim node As XPath.XPathNavigator

                'busca o id da chave
                node = xpathNav.SelectSingleNode("//nfe:protNFe/nfe:infProt/nfe:chNFe", ns)
                If node Is Nothing Then 'arquivo nao tem formato nfe
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/@Id", ns)
                    If node Is Nothing Then

                        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
                        If node Is Nothing Then
                            sNFErro = String.Empty
                        Else
                            sNFErro = node.InnerXml.ToString
                        End If
                        'busca nome emitente
                        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:xNome", ns)
                        If node Is Nothing Then
                            sNomeEmitErro = String.Empty
                        Else
                            sNomeEmitErro = node.InnerXml.ToString
                        End If

                        importacaolog.nr_linha = ilinha
                        importacaolog.st_importacao = "5"
                        importacaolog.cd_erro = "00002"
                        importacaolog.nm_erro = "Erro: Chave da nota não encontrada no XML.*" & lfoundFile.Name.ToString & " *" & sNFErro & "*" & sNomeEmitErro
                        importacaolog.insertImportacaoLog()

                        Continue For
                    End If
                End If
                Dim schavenf As String = node.InnerXml.ToString

                If Len(schavenf) > 44 Then
                    schavenf = Mid(schavenf, 4)
                End If

                'guarda os arquivos que serao retirados do diretorio
                Dim lpdfnota As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavenf.ToString, "*.pdf"))
                'se o pdf da nota existe
                If lpdfnota.Length > 0 Then
                    If lpdfnota(0).Exists Then
                        If lsarqpdf.Length > 1 OrElse (lsarqpdf.Length = 1 And Not lsarqpdf(0) Is Nothing) Then
                            ReDim Preserve lsarqpdf(lsarqpdf.Length)
                        End If
                        lsarqpdf(lsarqpdf.Length - 1) = lpdfnota(0).Name
                    Else
                        importacaolog.nr_linha = ilinha
                        importacaolog.st_importacao = "5"
                        importacaolog.cd_erro = "00003"
                        importacaolog.nm_erro = "Erro: Não existe PDF associado ao xml.*" & lfoundFile.Name.ToString & " *" & " " & "*" & " "
                        importacaolog.insertImportacaoLog()
                        Continue For

                    End If
                Else 'nao encontrou pdf
                    importacaolog.nr_linha = ilinha
                    importacaolog.st_importacao = "5"
                    importacaolog.cd_erro = "00003"
                    importacaolog.nm_erro = "Erro: Não existe PDF associado ao xml.*" & lfoundFile.Name.ToString & " *" & " " & "*" & " "
                    importacaolog.insertImportacaoLog()
                    Continue For

                End If
                If lsarqxml.Length > 1 OrElse (lsarqxml.Length = 1 And Not lsarqxml(0) Is Nothing) Then
                    ReDim Preserve lsarqxml(lsarqxml.Length)
                End If
                lsarqxml(lsarqxml.Length - 1) = lfoundFile.Name

                'antes de continuar verifica se a nota já foi importada
                notas.ds_chave_acesso = schavenf

                'se tem chave de acesso o arquivo ja foi importado
                If notas.getCentralNotasImportacao.Tables(0).Rows.Count > 0 Then

                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
                    If node Is Nothing Then
                        sNFErro = String.Empty
                    Else
                        sNFErro = node.InnerXml.ToString
                    End If
                    'busca nome emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:xNome", ns)
                    If node Is Nothing Then
                        sNomeEmitErro = String.Empty
                    Else
                        sNomeEmitErro = node.InnerXml.ToString
                    End If

                    importacaolog.nr_linha = ilinha
                    importacaolog.st_importacao = "5"
                    importacaolog.cd_erro = "00001"
                    importacaolog.nm_erro = "Erro: Chave da nota já existe nos cadastros do MILK.*" & lfoundFile.Name.ToString & " *" & sNFErro & "*" & sNomeEmitErro
                    importacaolog.insertImportacaoLog()
                Else

                    ilinhaimportada = ilinhaimportada + 1
                    'busca nr nota fiscal 
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:nNF", ns)
                    Dim sNF As String = node.InnerXml.ToString
                    'busca dt emissao 
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:ide/nfe:dhEmi", ns)
                    Dim sDtEmissao As String = node.InnerXml.ToString
                    'busca cnpj emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:CNPJ", ns)
                    Dim sCNPJ As String = node.InnerXml.ToString
                    'busca nome emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:emit/nfe:xNome", ns)
                    Dim sNomeEmit As String = node.InnerXml.ToString
                    'busca cnpj emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:CPF", ns)
                    Dim sCPFdest As String = String.Empty
                    Dim sCNPJdest As String = String.Empty
                    If node Is Nothing Then
                        sCPFdest = String.Empty
                        'busca cnpj destino
                        node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:CNPJ", ns)
                        sCNPJdest = node.InnerXml.ToString
                    Else
                        sCPFdest = node.InnerXml.ToString
                    End If
                    'busca cnpj emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:dest/nfe:xNome", ns)
                    Dim sNomedest As String = node.InnerXml.ToString
                    'busca cnpj emitente
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:total/nfe:ICMSTot/nfe:vNF", ns)
                    Dim sValorLiq As String = node.InnerXml.ToString
                    'busca nome informcoes do pedido
                    node = xpathNav.SelectSingleNode("//nfe:infNFe/nfe:infAdic", ns)

                    If node Is Nothing Then
                        lnrpedido = "0"
                    Else
                        Dim sinformacoes As String = node.InnerXml.ToString
                        lpos = InStr(1, sinformacoes, "DAN*")
                        'Se encontrou, pega o nr do pedido, se nao encontrou não tem nrmero na nota
                        If lpos > 0 Then
                            sinformacoes = Mid(sinformacoes, lpos + 4)
                            lpos = InStr(1, sinformacoes, "*")
                            If lpos > 0 Then
                                lnrpedido = Mid(sinformacoes, 1, lpos - 1)
                                If IsNumeric(lnrpedido) = False Then
                                    lnrpedido = "0"
                                End If
                            Else
                                lnrpedido = "0"
                            End If
                        Else
                            lnrpedido = "0"

                        End If

                    End If


                    'prepara para incluir centra_notas_imprtcao
                    If Len(sCNPJ) = 14 Then
                        sCNPJ = Left(sCNPJ, 2) & "." & Mid(sCNPJ, 3, 3) & "." & Mid(sCNPJ, 6, 3) & "/" & Mid(sCNPJ, 9, 4) & "-" & Mid(sCNPJ, 13, 2)
                    End If

                    ' CPF
                    If Trim(sCPFdest) <> "" And Trim(sCPFdest) <> "?" And Len(sCPFdest) = 11 Then
                        sCPFdest = Left(sCPFdest, 3) & "." & Mid(sCPFdest, 4, 3) & "." & Mid(sCPFdest, 7, 3) & "-" & Mid(sCPFdest, 10, 2)
                    End If
                    If Len(sCNPJdest) = 14 Then
                        sCNPJdest = Left(sCNPJdest, 2) & "." & Mid(sCNPJdest, 3, 3) & "." & Mid(sCNPJdest, 6, 3) & "/" & Mid(sCNPJdest, 9, 4) & "-" & Mid(sCNPJdest, 13, 2)
                    End If

                    sValorLiq = Replace(sValorLiq, ".", ",")
                    sDtEmissao = CDate(sDtEmissao).ToString("dd/MM/yyyy")

                    'INCLUI A CENTRAL NOTA
                    centralnotas.ds_chave_acesso = schavenf
                    centralnotas.nr_nota_fiscal = sNF
                    centralnotas.dt_emissao = sDtEmissao
                    centralnotas.nr_valor_nf = CDec(sValorLiq)
                    centralnotas.nm_emitente = sNomeEmit
                    centralnotas.cd_cnpj_emit = sCNPJ
                    centralnotas.nm_destino = sNomedest
                    centralnotas.cd_cpf_dest = sCPFdest
                    centralnotas.cd_cnpj_dest = sCNPJdest
                    centralnotas.nr_pedido = lnrpedido
                    'incluir 
                    centralnotas.id_central_notas_importacao = centralnotas.insertCentralNotasImportacao()

                    'PREPARA PARA GRAVAR NO BANCO O XML DA NOTA
                    Dim arqxml As StreamReader = New StreamReader(lfoundFile.FullName.ToString)
                    arrayxml = New Byte(arqxml.BaseStream.Length - 1) {}
                    arqxml.BaseStream.Read(arrayxml, 0, arrayxml.Length)

                    arqxml.Close()
                    arqxml.Dispose()

                    Dim con As New SqlConnection
                    con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                    con.Open()

                    Dim sqlcmd As New SqlCommand
                    sqlcmd.CommandType = CommandType.StoredProcedure
                    sqlcmd.CommandText = "ms_insertCentralNotasImportacaoAnexo"
                    sqlcmd.Connection = con

                    Dim sqlparam As New SqlParameter("@id_central_notas_importacao", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(centralnotas.id_central_notas_importacao)
                    sqlcmd.Parameters.Add(sqlparam)

                    Dim sqlparam1 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                    sqlparam1.Value = lfoundFile.Name.ToString
                    sqlcmd.Parameters.Add(sqlparam1)

                    Dim sqlparam2 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                    sqlparam2.Value = lfoundFile.FullName
                    sqlcmd.Parameters.Add(sqlparam2)

                    Dim sqlparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                    sqlparam3.Value = lfoundFile.Extension
                    sqlcmd.Parameters.Add(sqlparam3)

                    Dim sqlparam4 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                    sqlparam4.Value = lfoundFile.Length.ToString
                    sqlcmd.Parameters.Add(sqlparam4)

                    Dim sqlparam5 As New SqlParameter("@varbin_nota", SqlDbType.VarBinary, arrayxml.Length)
                    sqlparam5.Value = arrayxml 'buffer
                    sqlcmd.Parameters.Add(sqlparam5)

                    Dim sqlparam6 As New SqlParameter("@id_modificador", SqlDbType.Int)
                    sqlparam6.Value = Convert.ToInt32(Me.Session("id_login"))
                    sqlcmd.Parameters.Add(sqlparam6)

                    sqlcmd.ExecuteNonQuery()

                    'PREPARA PARA INCLUIR NO BANCO O PDF DA NOTA
                    'procura o pdf da nota para anexar
                    Dim larqpdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavenf.ToString, "*.pdf"))

                    'se o pdf da nota existe
                    If larqpdf.Length > 0 AndAlso larqpdf(0).Exists Then

                        Dim oStreamReader As StreamReader = New StreamReader(larqpdf(0).FullName.ToString)
                        Dim arraypdf As Byte() = New Byte(oStreamReader.BaseStream.Length - 1) {}

                        oStreamReader.BaseStream.Read(arraypdf, 0, arraypdf.Length)
                        oStreamReader.Close()
                        oStreamReader.Dispose()

                        Dim sqlcmdpdf As New SqlCommand
                        sqlcmdpdf.CommandType = CommandType.StoredProcedure
                        sqlcmdpdf.CommandText = "ms_insertCentralNotasImportacaoAnexo"
                        sqlcmdpdf.Connection = con

                        '"@id_central_notas_importacao"
                        Dim sparam As New SqlParameter("@id_central_notas_importacao", SqlDbType.Int)
                        sparam.Value = Convert.ToInt32(centralnotas.id_central_notas_importacao)
                        sqlcmdpdf.Parameters.Add(sparam)

                        Dim sparam1 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                        sparam1.Value = larqpdf(0).Name.ToString
                        sqlcmdpdf.Parameters.Add(sparam1)

                        Dim sparam2 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                        sparam2.Value = larqpdf(0).FullName
                        sqlcmdpdf.Parameters.Add(sparam2)

                        Dim sparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                        sparam3.Value = larqpdf(0).Extension
                        sqlcmdpdf.Parameters.Add(sparam3)

                        Dim sparam4 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                        sparam4.Value = larqpdf(0).Length.ToString
                        sqlcmdpdf.Parameters.Add(sparam4)

                        Dim sparam5 As New SqlParameter("@varbin_nota", SqlDbType.VarBinary, arraypdf.Length)
                        sparam5.Value = arraypdf 'buffer
                        sqlcmdpdf.Parameters.Add(sparam5)

                        Dim sparam6 As New SqlParameter("@id_modificador", SqlDbType.Int)
                        sparam6.Value = Convert.ToInt32(Me.Session("id_login"))
                        sqlcmdpdf.Parameters.Add(sparam6)

                        sqlcmdpdf.ExecuteNonQuery()

                    End If

                    con.Close()
                End If
            Next

            lAllFiles = lDirectory.GetFiles("*cte*.xml", SearchOption.TopDirectoryOnly)

            For Each lfoundFile In lAllFiles
                ilinha = ilinha + 1

                'trata o xml
                Dim arq As New XmlDocument
                arq.Load(lfoundFile.FullName.ToString)
                Dim ns As New XmlNamespaceManager(arq.NameTable)
                ns.AddNamespace("cte", "http://www.portalfiscal.inf.br/cte")

                Dim xpathNav As XPath.XPathNavigator = arq.CreateNavigator()
                Dim node As XPath.XPathNavigator

                'busca o id da chave
                node = xpathNav.SelectSingleNode("//cte:protCTe/cte:infProt/cte:chCTe", ns)
                'If node Is Nothing Then 'arquivo nao tem formato nfe
                '    Continue For
                'End If
                'Dim schavenf As String = node.InnerXml.ToString

                If node Is Nothing Then 'arquivo nao tem formato nfe
                    node = xpathNav.SelectSingleNode("//cte:infCte/@Id", ns)
                    If node Is Nothing Then

                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
                        If node Is Nothing Then
                            sNFErro = String.Empty
                        Else
                            sNFErro = node.InnerXml.ToString
                        End If
                        'busca nome emitente
                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:emit/cte:xNome", ns)
                        If node Is Nothing Then
                            sNomeEmitErro = String.Empty
                        Else
                            sNomeEmitErro = node.InnerXml.ToString
                        End If

                        importacaolog.nr_linha = ilinha
                        importacaolog.st_importacao = "5"
                        importacaolog.cd_erro = "00002"
                        importacaolog.nm_erro = "Erro: Chave da nota não encontrada no CTE XML.*" & lfoundFile.Name.ToString & " *" & sNFErro & "*" & sNomeEmitErro
                        importacaolog.insertImportacaoLog()

                        Continue For
                    End If
                End If
                Dim schavenf As String = node.InnerXml.ToString


                If Len(schavenf) > 44 Then
                    schavenf = Mid(schavenf, 4)
                End If


                Dim lpdfnota As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavenf.ToString, "*.pdf"))
                'se o pdf da nota existe
                If lpdfnota.Length > 0 Then
                    If lpdfnota(0).Exists Then
                        If lsarqpdf.Length > 1 OrElse (lsarqpdf.Length = 1 And Not lsarqpdf(0) Is Nothing) Then
                            ReDim Preserve lsarqpdf(lsarqpdf.Length)
                        End If
                        lsarqpdf(lsarqpdf.Length - 1) = lpdfnota(0).Name
                    End If
                End If
                If lsarqxml.Length > 1 OrElse (lsarqxml.Length = 1 And Not lsarqxml(0) Is Nothing) Then
                    ReDim Preserve lsarqxml(lsarqxml.Length)
                End If
                lsarqxml(lsarqxml.Length - 1) = lfoundFile.Name

                'antes de continuar verifica se a nota já foi importada
                notas.ds_chave_acesso = schavenf

                'se tem chave de acesso o arquivo ja foi importado
                If notas.getCentralNotasImportacao.Tables(0).Rows.Count > 0 Then

                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
                    If node Is Nothing Then
                        sNFErro = String.Empty
                    Else
                        sNFErro = node.InnerXml.ToString
                    End If
                    'busca nome emitente
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:emit/cte:xNome", ns)
                    If node Is Nothing Then
                        sNomeEmitErro = String.Empty
                    Else
                        sNomeEmitErro = node.InnerXml.ToString
                    End If

                    importacaolog.nr_linha = ilinha
                    importacaolog.st_importacao = "5"
                    importacaolog.cd_erro = "00001"
                    importacaolog.nm_erro = "Erro: Chave da nota já existe nos cadastros do MILK.*" & lfoundFile.Name.ToString & " *" & sNFErro & "*" & sNomeEmitErro
                    importacaolog.insertImportacaoLog()
                Else

                    ilinhaimportada = ilinhaimportada + 1
                    'busca nr nota fiscal 
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:nCT", ns)
                    Dim sNF As String = node.InnerXml.ToString
                    'busca dt emissao 
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:ide/cte:dhEmi", ns)
                    Dim sDtEmissao As String = node.InnerXml.ToString
                    'busca cnpj emitente
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:emit/cte:CNPJ", ns)
                    Dim sCNPJ As String = node.InnerXml.ToString
                    'busca nome emitente
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:emit/cte:xNome", ns)
                    Dim sNomeEmit As String = node.InnerXml.ToString
                    'busca cnpj remetente
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:rem/cte:CNPJ", ns)
                    Dim sCNPJrem As String = node.InnerXml.ToString
                    'busca nome remetente
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:rem/cte:xNome", ns)
                    Dim sNomeRem As String = node.InnerXml.ToString
                    'busca cnpj destino
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:dest/cte:CPF", ns)
                    Dim sCPFdest As String = String.Empty
                    Dim sCNPJdest As String = String.Empty
                    If node Is Nothing Then
                        sCPFdest = String.Empty
                        'busca cnpj destino
                        node = xpathNav.SelectSingleNode("//cte:infCte/cte:dest/cte:CNPJ", ns)
                        sCNPJdest = node.InnerXml.ToString
                    Else
                        sCPFdest = node.InnerXml.ToString
                    End If
                    'busca nome destino
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:dest/cte:xNome", ns)
                    Dim sNomedest As String = node.InnerXml.ToString
                    'busca 
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:vPrest/cte:vRec", ns)
                    Dim sValorLiq As String = node.InnerXml.ToString
                    'busca nome informcoes do pedido
                    node = xpathNav.SelectSingleNode("//cte:infCte/cte:compl/cte:xObs", ns)

                    If node Is Nothing Then
                        lnrpedido = "0"
                    Else
                        Dim sinformacoes As String = node.InnerXml.ToString
                        lpos = InStr(1, sinformacoes, "DAN*")
                        'Se encontrou, pega o nr do pedido, se nao encontrou não tem nrmero na nota
                        If lpos > 0 Then
                            sinformacoes = Mid(sinformacoes, lpos + 4)
                            lpos = InStr(1, sinformacoes, "*")
                            If lpos > 0 Then
                                lnrpedido = Mid(sinformacoes, 1, lpos - 1)
                            Else
                                lnrpedido = "0"
                            End If
                        Else
                            lnrpedido = "0"

                        End If

                    End If

                    'prepara para incluir centra_notas_imprtcao
                    If Len(sCNPJ) = 14 Then
                        sCNPJ = Left(sCNPJ, 2) & "." & Mid(sCNPJ, 3, 3) & "." & Mid(sCNPJ, 6, 3) & "/" & Mid(sCNPJ, 9, 4) & "-" & Mid(sCNPJ, 13, 2)
                    End If

                    If Len(sCNPJrem) = 14 Then
                        sCNPJrem = Left(sCNPJrem, 2) & "." & Mid(sCNPJrem, 3, 3) & "." & Mid(sCNPJrem, 6, 3) & "/" & Mid(sCNPJrem, 9, 4) & "-" & Mid(sCNPJrem, 13, 2)
                    End If

                    ' CPF
                    If Trim(sCPFdest) <> "" And Trim(sCPFdest) <> "?" And Len(sCPFdest) = 11 Then
                        sCPFdest = Left(sCPFdest, 3) & "." & Mid(sCPFdest, 4, 3) & "." & Mid(sCPFdest, 7, 3) & "-" & Mid(sCPFdest, 10, 2)
                    End If
                    If Len(sCNPJdest) = 14 Then
                        sCNPJdest = Left(sCNPJdest, 2) & "." & Mid(sCNPJdest, 3, 3) & "." & Mid(sCNPJdest, 6, 3) & "/" & Mid(sCNPJdest, 9, 4) & "-" & Mid(sCNPJdest, 13, 2)
                    End If

                    sValorLiq = Replace(sValorLiq, ".", ",")
                    sDtEmissao = CDate(sDtEmissao).ToString("dd/MM/yyyy")

                    'INCLUI A CENTRAL NOTA
                    centralnotas.ds_chave_acesso = schavenf
                    centralnotas.nr_nota_fiscal = sNF
                    centralnotas.dt_emissao = sDtEmissao
                    centralnotas.nr_valor_nf = CDec(sValorLiq)
                    centralnotas.nm_emitente = sNomeEmit
                    centralnotas.cd_cnpj_emit = sCNPJ
                    centralnotas.nm_destino = sNomedest
                    centralnotas.cd_cpf_dest = sCPFdest
                    centralnotas.cd_cnpj_dest = sCNPJdest
                    centralnotas.nr_pedido = lnrpedido
                    centralnotas.cd_cnpj_rem = sCNPJrem
                    centralnotas.nm_remetente = sNomeRem
                    'incluir 
                    centralnotas.id_central_notas_importacao = centralnotas.insertCentralNotasImportacao()

                    'PREPARA PARA GRAVAR NO BANCO O XML DA NOTA
                    Dim arqxml As StreamReader = New StreamReader(lfoundFile.FullName.ToString)
                    arrayxml = New Byte(arqxml.BaseStream.Length - 1) {}
                    arqxml.BaseStream.Read(arrayxml, 0, arrayxml.Length)

                    arqxml.Close()
                    arqxml.Dispose()

                    Dim con As New SqlConnection
                    con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                    con.Open()

                    Dim sqlcmd As New SqlCommand
                    sqlcmd.CommandType = CommandType.StoredProcedure
                    sqlcmd.CommandText = "ms_insertCentralNotasImportacaoAnexo"
                    sqlcmd.Connection = con

                    Dim sqlparam As New SqlParameter("@id_central_notas_importacao", SqlDbType.Int)
                    sqlparam.Value = Convert.ToInt32(centralnotas.id_central_notas_importacao)
                    sqlcmd.Parameters.Add(sqlparam)

                    Dim sqlparam1 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                    sqlparam1.Value = lfoundFile.Name.ToString
                    sqlcmd.Parameters.Add(sqlparam1)

                    Dim sqlparam2 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                    sqlparam2.Value = lfoundFile.FullName
                    sqlcmd.Parameters.Add(sqlparam2)

                    Dim sqlparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                    sqlparam3.Value = lfoundFile.Extension
                    sqlcmd.Parameters.Add(sqlparam3)

                    Dim sqlparam4 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                    sqlparam4.Value = lfoundFile.Length.ToString
                    sqlcmd.Parameters.Add(sqlparam4)

                    Dim sqlparam5 As New SqlParameter("@varbin_nota", SqlDbType.VarBinary, arrayxml.Length)
                    sqlparam5.Value = arrayxml 'buffer
                    sqlcmd.Parameters.Add(sqlparam5)

                    Dim sqlparam6 As New SqlParameter("@id_modificador", SqlDbType.Int)
                    sqlparam6.Value = Convert.ToInt32(Me.Session("id_login"))
                    sqlcmd.Parameters.Add(sqlparam6)

                    sqlcmd.ExecuteNonQuery()

                    'PREPARA PARA INCLUIR NO BANCO O PDF DA NOTA
                    'procura o pdf da nota para anexar
                    Dim larqpdf As IO.FileInfo() = lDirectory.GetFiles(String.Concat("*", schavenf.ToString, "*.pdf"))

                    'se o pdf da nota existe
                    If larqpdf.Length > 0 AndAlso larqpdf(0).Exists Then

                        Dim oStreamReader As StreamReader = New StreamReader(larqpdf(0).FullName.ToString)
                        Dim arraypdf As Byte() = New Byte(oStreamReader.BaseStream.Length - 1) {}

                        oStreamReader.BaseStream.Read(arraypdf, 0, arraypdf.Length)
                        oStreamReader.Close()
                        oStreamReader.Dispose()

                        Dim sqlcmdpdf As New SqlCommand
                        sqlcmdpdf.CommandType = CommandType.StoredProcedure
                        sqlcmdpdf.CommandText = "ms_insertCentralNotasImportacaoAnexo"
                        sqlcmdpdf.Connection = con

                        '"@id_central_notas_importacao"
                        Dim sparam As New SqlParameter("@id_central_notas_importacao", SqlDbType.Int)
                        sparam.Value = Convert.ToInt32(centralnotas.id_central_notas_importacao)
                        sqlcmdpdf.Parameters.Add(sparam)

                        Dim sparam1 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                        sparam1.Value = larqpdf(0).Name.ToString
                        sqlcmdpdf.Parameters.Add(sparam1)

                        Dim sparam2 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                        sparam2.Value = larqpdf(0).FullName
                        sqlcmdpdf.Parameters.Add(sparam2)

                        Dim sparam3 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                        sparam3.Value = larqpdf(0).Extension
                        sqlcmdpdf.Parameters.Add(sparam3)

                        Dim sparam4 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                        sparam4.Value = larqpdf(0).Length.ToString
                        sqlcmdpdf.Parameters.Add(sparam4)

                        Dim sparam5 As New SqlParameter("@varbin_nota", SqlDbType.VarBinary, arraypdf.Length)
                        sparam5.Value = arraypdf 'buffer
                        sqlcmdpdf.Parameters.Add(sparam5)

                        Dim sparam6 As New SqlParameter("@id_modificador", SqlDbType.Int)
                        sparam6.Value = Convert.ToInt32(Me.Session("id_login"))
                        sqlcmdpdf.Parameters.Add(sparam6)

                        sqlcmdpdf.ExecuteNonQuery()

                    End If

                    con.Close()
                End If
            Next

            If ilinhaimportada > 0 Then
                'limpa para garantir que o processo seja feita para toda importacao
                centralnotas.id_central_notas_importacao = 0
                'atualizar divergencias para processo e nota
                centralnotas.atulizarDivergencias()

                centralnotas.id_situacao_central_notas = 6 'notas validas

                'atualiza os pedidos com as notas validas
                centralnotas.atulizarPedidosNotasValidas()

            End If

            importacaolog.nr_linha = ilinha.ToString
            importacaolog.st_importacao = "5"
            importacaolog.cd_erro = ""
            importacaolog.nm_erro = ""
            importacaolog.id_importacao = importacao.id_importacao
            importacaolog.insertImportacaoLog()
            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            ViewState.Item("lbl_totallinhaslidas.Text") = ilinha
            ViewState.Item("lbl_totallinhasimportadas.Text") = ilinhaimportada

            ViewState.Item("tudook") = True

            ' Exclui o arquivo do servidor
            Dim ldestino As String = String.Concat(lscaminhoarquivo, "\lixo\")

            For Each li As String In lsarqxml
                If System.IO.File.Exists(String.Concat(ldestino, li)) Then 'verifica se existe no lixo
                    File.Delete(String.Concat(ldestino, li)) 'delete se existit
                End If
                File.Move(String.Concat(lscaminhoarquivo, "\", li), String.Concat(ldestino, li))
            Next

            For Each li As String In lsarqpdf
                If System.IO.File.Exists(String.Concat(ldestino, li)) Then 'verifica se existe no lixo
                    File.Delete(String.Concat(ldestino, li)) 'delete se existit
                End If
                File.Move(String.Concat(lscaminhoarquivo, "\", li), String.Concat(ldestino, li))
            Next


        Catch ex As Exception
            If ViewState.Item("tudook") = True Then
                'se a rotina foi ate o fim o erro é na movimentaçao dos arquivos
                Dim importacaolog As New ImportacaoLog
                importacaolog.nr_linha = 0
                importacaolog.st_importacao = "5"
                importacaolog.cd_erro = ""
                importacaolog.nm_erro = Left(ex.Message.ToString, 200)
                importacaolog.id_importacao = ViewState.Item("id_importacao")
                importacaolog.insertImportacaoLog()
            Else
                'messageControl.Alert(ex.Message)
                Throw New Exception(ex.Message)

            End If


        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadDataFiles()
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim txt_nomearquivo As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)
            Dim txt_erro As DataControlFieldCell = CType(e.Row.Cells(4), DataControlFieldCell)
            Dim txtnrnota As DataControlFieldCell = CType(e.Row.Cells(5), DataControlFieldCell)
            Dim txtemitente As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
            Dim ltextoerro As String = String.Empty
            Dim lPos As Integer = 0

            If Not txt_erro.Text.Equals(String.Empty) And Not txt_erro.Text.Equals("&nbsp;") Then

                'txt_nomearquivo.Text = Mid(txt_nomearquivo.Text, InStr(txt_nomearquivo.Text, "*") + 1)

                'If InStr(txt_erro.Text, "*") = 0 Then
                '    txt_erro.Text = String.Empty
                'Else
                '    txt_erro.Text = Mid(txt_erro.Text, 1, InStr(txt_erro.Text, "*") - 1)
                'End If

                ltextoerro = txt_erro.Text
                lPos = InStr(ltextoerro, "*")

                txt_erro.Text = String.Empty
                txtnrnota.Text = String.Empty
                txtemitente.Text = String.Empty
                txt_nomearquivo.Text = String.Empty

                If lPos = 0 Then
                    txt_nomearquivo.Text = ltextoerro
                    txt_erro.Text = String.Empty
                    txtnrnota.Text = String.Empty
                    txtemitente.Text = String.Empty
                Else
                    'pega as primeiras posioes o erro
                    txt_erro.Text = Mid(ltextoerro, 1, lPos - 1)
                    ltextoerro = Mid(ltextoerro, lPos + 1) 'atualiza texto

                    'nome arquivo
                    lPos = InStr(ltextoerro, "*") 'verifica se tem outro asterisco finalizando nome do arquivo
                    If lPos = 0 Then
                        txt_nomearquivo.Text = ltextoerro
                        txtnrnota.Text = String.Empty
                        txtemitente.Text = String.Empty
                    Else
                        txt_nomearquivo.Text = Mid(ltextoerro, 1, lPos - 1)

                        ltextoerro = Mid(ltextoerro, lPos + 1) 'atualiza texto

                        'nr nota
                        lPos = InStr(ltextoerro, "*") 'verifica se tem outro asterisco finalizando nr nota
                        If lPos = 0 Then
                            txtnrnota.Text = ltextoerro
                            txtemitente.Text = String.Empty
                        Else
                            'achou asterisco na 1a posicao, nao tem nr nota
                            If lPos = 1 Then
                                txtnrnota.Text = String.Empty
                                If Len(ltextoerro) = 1 Then 'se so tem 1 posicao, nao tem emitente
                                    txtemitente.Text = String.Empty
                                Else
                                    txtemitente.Text = Mid(ltextoerro, lPos + 1)
                                End If
                            Else
                                txtnrnota.Text = Mid(ltextoerro, 1, lPos - 1)

                                If Len(ltextoerro) = lPos Then
                                    'nao tem nome emitente
                                    txtemitente.Text = String.Empty
                                Else
                                    txtemitente.Text = Mid(ltextoerro, lPos + 1)
                                End If

                            End If
                        End If

                    End If

                End If
            End If

        End If

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

    Protected Sub cv_importacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_importacao.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            Dim lscaminhoarquivo As String = ViewState.Item("caminho_arquivo").ToString

            Dim lDirectory As New IO.DirectoryInfo(lscaminhoarquivo)

            If Not lDirectory.Exists Then
                lmsg = String.Concat("O caminho de diretórios '", ViewState.Item("caminho_arquivo").ToString, "' dos arquivos de NFe não foi encontrado.")
                args.IsValid = False
            Else
                Dim lAllFiles As IO.FileInfo() = lDirectory.GetFiles("*nfe*.xml")
                Me.lbl_nrarqsxml.Text = lAllFiles.Length
                If lAllFiles.Length = 0 Then
                    lmsg = String.Concat("Não existem arquivos de NFe do tipo XML, no diretóriro informado ('", ViewState.Item("caminho_arquivo").ToString, "') para serem importados.")
                    args.IsValid = False
                End If

                If args.IsValid = False Then
                    lAllFiles = lDirectory.GetFiles("*cte*.xml")
                    If lAllFiles.Length > 0 Then
                        lmsg = String.Empty
                        args.IsValid = True
                    End If

                End If


            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            Else
                lbl_Aguarde.Visible = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_dt_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_referencia.TextChanged
        If txt_dt_referencia.Text.Equals(String.Empty) Then
            txt_dia_ini.Enabled = False
            txt_dia_ini.ToolTip = "Para informar período em dias da data de Emissão da Nota, a Referência de Emissão dever ser informada."
            txt_dia_fim.Enabled = False
            txt_dia_fim.ToolTip = "Para informar período em dias da data de Emissão da Nota, a Referência de Emissão dever ser informada."

            txt_dia_ini.Text = String.Empty
            txt_dia_fim.Text = String.Empty
        Else
            txt_dia_ini.Enabled = True
            txt_dia_fim.Enabled = True
            txt_dia_ini.ToolTip = String.Empty
            txt_dia_ini.ToolTip = String.Empty

        End If
    End Sub

    Protected Sub gridFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridFiles.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "select"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)


                ViewState.Item("id_central_notas_importacao_detalhe") = Me.gridFiles.DataKeys(row.RowIndex).Value.ToString

                tr_detalhes.Visible = True
                pnl_romaneio.Visible = True
                loadDetalhe()


                'Response.Redirect("frm_relacao_CIQ_CIQPEmitidos_excel.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))
            Case "delete"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                deleteNota(Convert.ToInt32(e.CommandArgument.ToString()), Me.gridFiles.Rows.Item(row.RowIndex).Cells(3).Text, CType(Me.gridFiles.Rows.Item(row.RowIndex).FindControl("hl_download"), System.Web.UI.WebControls.HyperLink).Text)

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

            If lbl_id_situacao_nota.Text = "1" OrElse lbl_id_situacao_nota.Text = "2" OrElse lbl_id_situacao_nota.Text = "6" Then 'se for importada ou incluida milk nao tem diveregencia para mostra
                btndetalhe.ImageUrl = "~/img/icon_preview_desabilitado.gif"
                btndetalhe.Enabled = False
                btndetalhe.ToolTip = "A nota não possui divergências."
            Else
                btndetalhe.ImageUrl = "~/img/icon_preview.gif"
                btndetalhe.Enabled = True
                btndetalhe.ToolTip = "Visualizar divergências."
            End If

            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)

            btn_delete.Visible = True

            If lbl_id_situacao_nota.Text = "2" OrElse lbl_id_situacao_nota.Text = "3" Then 'se for incluida manual ou incluida milk nao pode deletar
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                btn_delete.ToolTip = "Não é possível excluir a Nota Importada. Já foi efetuada sua inclusão em um pedido do sistema."
            Else
                btn_delete.Enabled = True
                btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                btn_delete.ToolTip = "Excluir Nota Importada"

            End If

        End If

    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then
            Try
                loadDataFiles()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_central_notas_importar.aspx?st_incluirlog=N")

    End Sub

    Protected Sub btn_atualizarpedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizarpedido.Click
        If Page.IsValid Then

            Dim centralnotas As New CentralNotas
            centralnotas.id_modificador = Session("id_login")
            centralnotas.id_situacao_central_notas = 6 'notas validas
            'se tem alguma nota valida que por algum motivo nao foi finalizada
            If centralnotas.getCentralNotasImportacao.Tables(0).Rows.Count > 0 Then
                centralnotas.atulizarPedidosNotasValidas()
                messageControl.Alert("Notas foram incluídas nod pedidos com sucesso!")

            Else
                messageControl.Alert("Não há notas válidas para prosseguir com atualização de pedidos.")
            End If

        End If
    End Sub

    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        gridDoc.Visible = False
        pnl_romaneio.Visible = False
    End Sub

    Protected Sub btn_atualizarmanual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizarmanual.Click
        If Page.IsValid Then
            Response.Redirect("lst_central_notas_divergentes.aspx")

        End If
    End Sub

    Protected Sub btn_revalidardivergencias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_revalidardivergencias.Click
        If Page.IsValid Then
            Try

                Dim centralnotas As New CentralNotas

                centralnotas.id_modificador = Session("id_login")
                'atualizar divergencias para processo e nota
                centralnotas.reavaliarDivergencias()

                centralnotas.id_situacao_central_notas = 10 'notas validas reavaliadas

                'atualiza os pedidos com as notas validas
                centralnotas.atulizarPedidosNotasValidas()

                cbo_situacao_nota.SelectedValue = 8
                loadDataFiles()
                messageControl.Alert("Notas Revalidadas Com Sucesso!")

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub btn_excluirnotas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_excluirnotas.Click
        'Try
        '    Dim analiseesalq As New AnaliseEsalq

        '    'If saveCheckBox() = True Then
        '    If Page.IsValid Then
        '        'Filtro
        '        analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
        '        If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
        '            analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
        '            analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
        '        Else
        '            analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
        '            analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
        '        End If

        '        If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
        '            analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
        '        End If
        '        If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
        '            analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
        '        End If
        '        analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
        '        analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
        '        analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
        '        analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
        '        analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


        '        'Dados para o Update
        '        analiseesalq.id_situacao = 2  '  Inativo
        '        analiseesalq.id_modificador = Session("id_login")
        '        analiseesalq.updateAnalisesEsalqSituacaoSelecionadas()

        '        loadData()

        '        messageControl.Alert("Análises Desativadas com sucesso.")
        '    End If
        '    'Else
        '    'messageControl.Alert("Nenhum item foi selecionado para ser desativado. Por favor selecione alguma análise.")
        '    'End If


        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try

    End Sub

    'Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try

    '        Dim wc As WebControl = CType(sender, WebControl)
    '        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
    '        Dim chk_selec As CheckBox

    '        chk_selec = CType(sender, CheckBox)

    '        '' Seleciona o item selecionado
    '        Dim notas As New CentralNotas

    '        notas.id_central_notas_importacao = Convert.ToInt32(gridFiles.DataKeys.Item(row.RowIndex).Value)
    '        If chk_selec.Checked = True Then
    '            notas.st_selecao = "1"
    '        Else
    '            notas.st_selecao = "0"
    '        End If
    '        notas.updateCentralNotasImportacaoSelecao()

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)

    '    End Try


    'End Sub

    'Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try

    '        Dim li As Integer
    '        Dim ch As CheckBox
    '        Dim ck_header As CheckBox

    '        ck_header = CType(sender, CheckBox)

    '        Dim lsituacaonota As String = CType(gridFiles.Rows(li).FindControl("lbl_id_situacao_nota"), Label).Text.Trim
    '        For li = 0 To gridFiles.Rows.Count - 1
    '            'se aprovacao <> 3- nao aprovado pelo sistema
    '            If Not lsituacaonota.Equals("2") And Not lsituacaonota.Equals("3") Then
    '                ch = CType(gridFiles.Rows(li).FindControl("ck_item"), CheckBox)
    '                ch.Checked = ck_header.Checked
    '            End If
    '        Next

    '        ' Seleciona tudo o que o botão Pesquisar trouxer - i

    '        'Instancio um datatable chamado tb
    '        Dim tb As New DataTable
    '        'Preencho meu novo datatable (tb) com os dados do meu datagridview (gridpesquisa) que foi preenchido anteriormente por outro datatable
    '        tb = TryCast(gridFiles.DataSource, DataTable)

    '        Dim row As DataRow
    '        Dim notas As New CentralNotas
    '        Dim chk_selec As CheckBox

    '        If ck_header.Checked = True Then
    '            notas.st_selecao = "1"
    '        Else
    '            notas.st_selecao = "0"
    '        End If

    '        'Após ter preenchido o datatable (tb), verifico se há linhas (se há dados)
    '        If tb.Rows.Count > 0 Then
    '            For Each row In tb.Rows
    '                If Not row.Item("id_central_notas_importacao").ToString.Equals("2") And Not row.Item("id_central_notas_importacao").ToString.Equals("3") Then
    '                    notas.id_central_notas_importacao = Convert.ToInt32(row.Item("id_central_notas_importacao"))
    '                    notas.updateCentralNotasImportacaoSelecao()
    '                End If
    '            Next

    '            'Preencho um novo datagridview (datagridview1) com o datatable (tb)
    '            'Aqui eu preenchi um novo datagridview só para ter visualmente o código funcionando, mas a partir do momento que você tem o datatable preenchido, você pode fazer qualquer outra coisa. No meu caso isso foi apenas um exemplo.
    '            Me.DataGridView1.DataSource = tb
    '        End If

    '        Dim analiseesalq As New AnaliseEsalq
    '        analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")

    '        If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '            analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '            analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '        Else
    '            analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '        End If

    '        If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '            analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '        End If
    '        If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '            analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '        End If
    '        analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '        analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '        analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '        analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '        analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))  ' adri 02/09/2016 - chamado 2480 

    '        If ck_header.Checked = True Then
    '            analiseesalq.st_selecao = "1"
    '        Else
    '            analiseesalq.st_selecao = "0"
    '        End If
    '        analiseesalq.updateAnalisesEsalqSelecaoTodas()
    '        ' Seleciona tudo o que o botão Pesquisar trouxe - f


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Sub deleteNota(ByVal id_central_notas_importacao As Integer, ByVal dsfornecedornota As String, ByVal dsnrnota As String)

        Try

            Dim nota As New CentralNotas

            nota.id_central_notas_importacao = id_central_notas_importacao
            nota.id_modificador = Convert.ToInt32(Session("id_login"))
            nota.deleteCentralNotasImportacao()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 235
            usuariolog.ds_nm_processo = "Importação Notas"
            usuariolog.id_nr_processo = id_central_notas_importacao.ToString
            usuariolog.nm_nr_processo = String.Concat("Emitente ", dsfornecedornota.ToString, " - Nr Nota ", dsnrnota.ToString)
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro excluido com sucesso.")
            loadDataFiles()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridFiles_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridFiles.RowDeleting
        e.Cancel = True

    End Sub
End Class
