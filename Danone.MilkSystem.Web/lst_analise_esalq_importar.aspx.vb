Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports System.Windows.Forms


Partial Class lst_analise_esalq_importar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            If Page.IsValid Then

                'ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue ' 05/11/2008
                ' 16/07/2008 (não estava pegando o caminho do web.config)
                'ViewState.Item("caminho_arquivo") = "c:\home\milksystem\dados\"
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + fup_nm_arquivo.FileName
                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_nm_arquivo.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)
                ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' fran dez/2018

                If fup_nm_arquivo.FileName <> "" Then
                    fup_nm_arquivo.SaveAs(ViewState.Item("nm_arquivo").ToString)
                End If
                'fran 27/11/2009 i maracanau chamado 523
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                'fran 27/11/2009 f maracanau chamado 523
                ViewState.Item("id_tipo_coleta_analise_esalq") = cbo_tipo_coleta.SelectedValue 'fran 26/07/2016


                lbl_totallidas.Visible = True
                lbl_totalimportadas.Visible = True
                lbl_totallinhaslidas.Visible = True
                lbl_totallinhasimportadas.Visible = True

                importData()

                deleteArquivos()   ' 12/05/2010 - chamado 835 - i

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 26
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                loadData()

                'lbl_aguarde.ForeColor = Drawing.Color.White

                ' 16/11/2008
                messageControl.Alert("O processo de importação foi realizado. Verifique há erros e modifique se necessário.")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_importar.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 26
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020 i incluir log 

            loadDetails()
        End If
        btn_importar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            'fran 27/11/2009 i maracanau chamado 523
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran 27/11/2009 f maracanau chamado 523
            'fran 26/07/2016 i 
            Dim tipocoleta As New AnaliseEsalqTipoColeta
            cbo_tipo_coleta.DataSource = tipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran 26/07/2016 f 
            'fran dez/2018 i cooperativa
            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor
            'fran dez/2018 f cooperativa


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()
        Try

            'Dim importacaolog As New ImportacaoLog

            'importacaolog.id_importacao = ViewState.Item("id_importacao")

            'Dim dsimportacaolog As DataSet = importacaolog.getImportacaoLogByFilters

            Dim analiseesalqerro As New AnaliseEsalqErro
            analiseesalqerro.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = analiseesalqerro.getAnalisesEsalqErroByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True

                'fran dez/2018 i
                If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then 'grupo cooperativa
                    gridResults.Columns(2).Visible = True 'coluna cod cooperativa
                    gridResults.Columns(3).Visible = False 'coluna propriedade
                    gridResults.Columns(4).Visible = False 'coluna up
                Else
                    gridResults.Columns(2).Visible = False 'coluna cod cooperativa
                    gridResults.Columns(3).Visible = True 'coluna propriedade
                    gridResults.Columns(4).Visible = True 'coluna up
                End If
                'fran dez/2018 f

                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                ' 16/11/2008
                'Else
                '    gridResults.Visible = False
                '    messageControl.Alert("Nenhuma linha foi importada")
            End If

            'fran dez/2018 i
            If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then 'grupo cooperativa
                Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_analise_esalq_cooperativa.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
                Me.hl_imprimir.Enabled = True

            Else
                ' 14/11/2008
                Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_analise_esalq.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
                Me.hl_imprimir.Enabled = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim analiseesalq As New AnaliseEsalq
            'linha.id_estabelecimento = ViewState.Item("id_estabelecimento")
            analiseesalq.id_criacao = Convert.ToInt32(Session("id_login"))
            analiseesalq.nm_arquivo = ViewState.Item("nm_arquivo")
            'fran 27/11/2009 i maracanau chamado 523
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            'fran 27/11/2009 f maracanau chamado 523
            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq")) 'fran 26/07/2016

            'fran dez/2018 i
            If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then
                ViewState.Item("id_importacao") = analiseesalq.importAnaliseEsalqCooperativa
                'fran dez/2018 f
            Else
                ViewState.Item("id_importacao") = analiseesalq.importAnaliseEsalq
            End If


            lbl_totallinhaslidas.Text = analiseesalq.nr_linhaslidas
            lbl_totallinhasimportadas.Text = analiseesalq.nr_linhasimportadas

            '        Dim linhaitens As New LinhaItens
            '        Dim linhaarquivo As String
            '        Dim arqTemp As StreamReader

            '        Dim nome_linha As String
            '        Dim cd_placa As String
            '        Dim li As Int16
            '        Dim id_linha As Int32
            '        Dim id_estabelecimento As Int32
            '        Dim erro As Boolean
            '        Dim cd_placa_anterior As String

            '        Dim id_linha_itens As Int32
            '        Dim dia_impar_par As String
            '        Dim cd_produtor As String
            '        Dim id_propriedade As String
            '        Dim nr_dist_prim_produtor As String
            '        Dim nr_dist_produtores As String
            '        Dim nr_dist_ult_produtor As String
            '        Dim nr_seq_coleta As String
            '        Dim importacao As New Importacao
            '        Dim importacaolog As New ImportacaoLog
            '        Dim id_importacao_log As Int32
            '        Dim liimportada As Int16

            '        importacao.st_tipo_importacao = 1
            '        importacao.dt_inicio_importacao = Now
            '        importacao.id_estabelecimento = ViewState.Item("id_estabelecimento")
            '        importacao.id_criacao = Convert.ToInt32(Session("id_login"))
            '        importacao.nm_arquivo = ViewState.Item("nm_arquivo")

            '        ViewState.Item("id_importacao") = importacao.insertImportacao()


            '        arqTemp = File.OpenText(ViewState.Item("nm_arquivo"))

            '        li = 0
            '        cd_placa_anterior = ""
            '        Do While Not arqTemp.EndOfStream
            '            linhaarquivo = arqTemp.ReadLine
            '            li = li + 1

            '            ' Guarda variáveis para ms_linha
            '            nome_linha = "Rota " & li
            '            cd_placa = Mid(linhaarquivo, 1, 8)
            '            id_estabelecimento = ViewState.Item("id_estabelecimento")

            '            If cd_placa <> cd_placa_anterior Then
            '                cd_placa_anterior = cd_placa

            '                '=========================================
            '                ' Consistencias
            '                '=========================================
            '                erro = False

            '                ' Consiste se placa válida
            '                Dim veiculo As New Veiculo
            '                veiculo.ds_placa = Trim(cd_placa)
            '                If veiculo.validarPlaca = False Then
            '                    ' Logar
            '                    importacaolog.nr_linha = li
            '                    importacaolog.st_importacao = "2"
            '                    importacaolog.cd_erro = "10001"
            '                    importacaolog.nm_erro = "Placa não cadastrada"
            '                    importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                    id_importacao_log = importacaolog.insertImportacaoLog()

            '                    erro = True
            '                End If

            '                If erro = False Then


            '                    linha.ds_placa = cd_placa
            '                    Dim dsLinha As DataSet = linha.getLinhaByFilters()

            '                    If (dsLinha.Tables(0).Rows.Count > 0) Then  '  Se a rota  existe para a placa
            '                        id_linha = dsLinha.Tables(0).Rows(0).Item("id_linha")
            '                        importacaolog.nr_linha = li
            '                        importacaolog.st_importacao = "2"
            '                        importacaolog.cd_erro = "10007"
            '                        importacaolog.nm_erro = "Aviso: Esta rota já existe para essa placa"
            '                        importacaolog.id_importacao = ViewState.Item("id_importacao")
            '                        id_importacao_log = importacaolog.insertImportacaoLog()
            '                    Else
            '                        ' Gerar as tabelas
            '                        linha.nm_linha = nome_linha
            '                        linha.ds_placa = Trim(cd_placa)
            '                        linha.id_estabelecimento = id_estabelecimento
            '                        linha.id_criacao = Convert.ToInt32(Session("id_login"))
            '                        linha.id_modificador = Convert.ToInt32(Session("id_login"))

            '                        id_linha = linha.insertLinha()

            '                    End If

            '                End If
            '            End If

            '            ' Guarda variáveis para ms_linha_itens
            '            dia_impar_par = Trim(Mid(linhaarquivo, 9, 10))
            '            id_propriedade = Trim(Mid(linhaarquivo, 19, 8))
            '            nr_dist_prim_produtor = Trim(Mid(linhaarquivo, 27, 7))
            '            nr_dist_produtores = Trim(Mid(linhaarquivo, 34, 7))
            '            nr_dist_ult_produtor = Trim(Mid(linhaarquivo, 41, 7))
            '            nr_seq_coleta = Trim(Mid(linhaarquivo, 48, 3))

            '            '=========================================
            '            ' Consistencias
            '            '=========================================
            '            erro = False

            '            ' Dia Impar ou Par
            '            If dia_impar_par = "d1" Then
            '                dia_impar_par = "1"
            '            Else
            '                If dia_impar_par = "d2" Then
            '                    dia_impar_par = "2"
            '                Else
            '                    ' Logar Erro
            '                    importacaolog.nr_linha = li
            '                    importacaolog.st_importacao = "2"
            '                    importacaolog.cd_erro = "10002"
            '                    importacaolog.nm_erro = "Erro: Dia incorreto"
            '                    importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                    id_importacao_log = importacaolog.insertImportacaoLog()
            '                    erro = True
            '                End If
            '            End If

            '            ' Consite Propriedade
            '            Dim propriedade As New Propriedade
            '            cd_produtor = ""
            '            If IsNumeric(id_propriedade) = False Then

            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "2"
            '                importacaolog.cd_erro = "10008"
            '                importacaolog.nm_erro = "Erro: Código da propriedade não é numérico"
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                id_importacao_log = importacaolog.insertImportacaoLog()
            '                erro = True
            '            End If
            '            If erro = False Then
            '                propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
            '                Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

            '                If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 
            '                    cd_produtor = dsPropriedade.Tables(0).Rows(0).Item("id_pessoa")
            '                Else
            '                    importacaolog.nr_linha = li
            '                    importacaolog.st_importacao = "2"
            '                    importacaolog.cd_erro = "10003"
            '                    importacaolog.nm_erro = "Erro: Propriedade não cadastrada"
            '                    importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                    id_importacao_log = importacaolog.insertImportacaoLog


            '                    erro = True
            '                End If
            '            End If

            '            ' Consiste distâncias
            '            If IsNumeric(nr_dist_prim_produtor) = False Then

            '                ' Logar
            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "2"
            '                importacaolog.cd_erro = "10004"
            '                importacaolog.nm_erro = "Erro: Distância não é numérica"
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                id_importacao_log = importacaolog.insertImportacaoLog()

            '                erro = True
            '            End If

            '            If IsNumeric(nr_dist_produtores) = False Then
            '                ' Logar

            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "2"
            '                importacaolog.cd_erro = "10005"
            '                importacaolog.nm_erro = "Erro: Distância não é numérica"
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                id_importacao_log = importacaolog.insertImportacaoLog()

            '                erro = True
            '            End If

            '            If IsNumeric(nr_dist_ult_produtor) = False Then
            '                ' Logar

            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "2"
            '                importacaolog.cd_erro = "10005"
            '                importacaolog.nm_erro = "Erro: Distância não é numérica"
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                id_importacao_log = importacaolog.insertImportacaoLog()

            '                erro = True
            '            End If

            '            ' Consiste Sequencia
            '            If IsNumeric(nr_seq_coleta) = False Then
            '                ' Logar

            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "2"
            '                importacaolog.cd_erro = "10006"
            '                importacaolog.nm_erro = "Erro: Sequência da coleta não é numérica"
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")

            '                id_importacao_log = importacaolog.insertImportacaoLog()

            '                erro = True
            '            End If


            '            If erro = False Then
            '                ' Delete das linhas da ms_linha_itens
            '                linhaitens.id_linha = id_linha
            '                linhaitens.deleteLinhaItens()

            '                ' Gerar as tabelas


            '                linhaitens.dia_impar_par = dia_impar_par
            '                linhaitens.id_propriedade = Convert.ToInt32(id_propriedade)
            '                linhaitens.cd_produtor = Convert.ToInt32(cd_produtor)
            '                linhaitens.nr_dist_prim_produtor = Convert.ToDecimal(Replace(nr_dist_prim_produtor, ".", ","))
            '                linhaitens.nr_dist_produtores = Convert.ToDecimal(Replace(nr_dist_produtores, ".", ","))
            '                linhaitens.nr_dist_ult_produtor = Convert.ToDecimal(Replace(nr_dist_ult_produtor, ".", ","))
            '                linhaitens.nr_seq_coleta = Convert.ToInt32(nr_seq_coleta)

            '                id_linha_itens = linhaitens.insertLinhaItens()
            '                liimportada = liimportada + 1

            '                importacaolog.nr_linha = li
            '                importacaolog.st_importacao = "1"
            '                importacaolog.cd_erro = ""
            '                importacaolog.nm_erro = ""
            '                importacaolog.id_importacao = ViewState.Item("id_importacao")
            '                id_importacao_log = importacaolog.insertImportacaoLog


            '            End If
            '        Loop
            '        arqTemp.Close()

            '        importacao.dt_termino_importacao = Now
            '        importacao.updateImportacao()

            '        ViewState.Item("totallinhaslidas") = li
            '        ViewState.Item("totallinhasimportadas") = liimportada

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "nr_linha"
                If (ViewState.Item("sortExpression")) = "nr_linha asc" Then
                    ViewState.Item("sortExpression") = "nr_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nr_linha asc"
                End If


            Case "st_importacao"
                If (ViewState.Item("sortExpression")) = "st_importacao asc" Then
                    ViewState.Item("sortExpression") = "st_importacao desc"
                Else
                    ViewState.Item("sortExpression") = "st_importacao asc"
                End If

            Case "cd_erro"
                If (ViewState.Item("sortExpression")) = "cd_erro asc" Then
                    ViewState.Item("sortExpression") = "cd_erro desc"
                Else
                    ViewState.Item("sortExpression") = "cd_erro asc"
                End If

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        'If (e.Row.RowType <> DataControlRowType.Header _
        '   And e.Row.RowType <> DataControlRowType.Footer _
        '   And e.Row.RowType <> DataControlRowType.Pager) Then

        '    If (e.Row.Cells(1).Text.Trim().Equals("1")) Then
        '        e.Row.Cells(1).Text = "Linha Importada com Sucesso"
        '    Else
        '        e.Row.Cells(1).Text = "Linha com Erro"
        '    End If

        'End If

    End Sub
    ' chamado 835 - i (limpar arquivos de importação)
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
    ' chamado 835 - f (limpar arquivos de importação)

   
End Class
