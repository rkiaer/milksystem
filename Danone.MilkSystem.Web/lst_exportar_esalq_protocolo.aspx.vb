Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_esalq_protocolo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_esalq_protocolo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 210
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        'btn_exportar_esalq.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")
        ''btn_exportar_esalq.Attributes.Add("onclick", "document.body.style.cursor = 'wait'; this.value='Aguarde, Enviando...'; this.disabled = true; " + this.GetPostBackEventReference(Button1, string.Empty) + ";");
        'btn_exportar_esalq.Attributes.Add("onclick", "document.body.style.cursor = 'wait'; this.value='Aguarde, Enviando...'; this.disabled = true; " & Me.GetPostBackEventReference(btn_exportar_esalq, String.Empty) & ";")

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim analiseesalqtipocoleta As New AnaliseEsalqTipoColeta
            cbo_tipo_coleta.DataSource = analiseesalqtipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Private Function exportData() As Boolean

    '    Try

    '        Dim esalq As New AnaliseEsalq
    '        ViewState.Item("SemNaturezaOperacao") = "N"
    '        ViewState.Item("nm_erro") = String.Empty
    '        notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '        notafiscal.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)
    '        notafiscal.nm_arquivo = ViewState.Item("nm_arquivo")
    '        notafiscal.st_exportacao = ViewState.Item("st_exportacao")
    '        notafiscal.id_modificador = Session("id_login")   'Para exportar o usuário que está logado

    '        exportData = notafiscal.exportNotaFiscalProdutorSAP()   '  12/03/2012 - Projeto Themis
    '        If exportData = False Then 'se tem erros

    '            If notafiscal.cd_erro <> "SEM LINHAS" Then 'se existem linhas, concatena com a mensagem dados do produtor com erro
    '                notafiscal.nm_erro = notafiscal.nm_erro.ToString & " Produtor: " & notafiscal.cd_pessoa & ", propriedade: " & notafiscal.id_propriedade.ToString & ", nota fiscal: " & notafiscal.nr_nota_fiscal & " e série: " & notafiscal.nr_serie & "."
    '            End If
    '            ViewState.Item("nm_erro") = notafiscal.nm_erro.ToString
    '        End If


    '        lbl_totallidas.Text = notafiscal.nr_linhaslidas
    '        lbl_totallinhas.Text = notafiscal.nr_linhasexportadas

    '    Catch ex As Exception

    '        ViewState.Item("nm_erro") = ex.Message.ToString 'fran 07/06/2010
    '        messageControl.Alert(ex.Message)
    '        Return False

    '    End Try

    'End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try

            If Page.IsValid Then

                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                ViewState.Item("id_tipo_coleta") = cbo_tipo_coleta.SelectedValue

                If txt_dia_ini.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_ini") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                Else
                    ViewState.Item("dt_ini") = String.Concat(Right("00" & txt_dia_ini.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 00:00:00")
                    ViewState.Item("dt_fim") = String.Concat(Right("00" & txt_dia_fim.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 23:59:59")
                End If

                If ck_exportadas.Checked = True Then
                    ViewState.Item("st_exportacao") = "S"
                Else
                    ViewState.Item("st_exportacao") = "N"
                End If

                loadData()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 8 'exporta~ção
                    usuariolog.id_menu_item = 210
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 


                    Response.Redirect("frm_analise_esalq_protocolo_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&dt_ini=" + ViewState.Item("dt_ini").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_tipo_coleta=" + ViewState.Item("id_tipo_coleta").ToString + "&st_exportacao=" + ViewState.Item("st_exportacao").ToString())

                Else
                    messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                End If
            Else
                gridResults.Visible = False

            End If

            'Dim lnomearquivo As String

            'ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            'ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            'If ck_exportadas.Checked = True Then
            '    ViewState.Item("st_exportacao") = "S"
            'Else
            '    ViewState.Item("st_exportacao") = "N"
            'End If


            'ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            'lnomearquivo = "\MilkSystem_Esalq_Protocolos_" & txt_dt_referencia.Text & "_" & Now() & ".txt"
            'lnomearquivo = Replace(lnomearquivo, ":", "")
            'lnomearquivo = Replace(lnomearquivo, " ", "")
            'lnomearquivo = Replace(lnomearquivo, "/", "")


            'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

            'deleteArquivos()

            'lbl_totallidas.Visible = True
            'lbl_totallinhas.Visible = True

            ''FRAN 08/12/2020 i incluir log 
            'Dim usuariolog As New UsuarioLog
            'usuariolog.id_usuario = Session("id_login")
            'usuariolog.ds_id_session = Session.SessionID.ToString()
            'usuariolog.id_tipo_log = 6 'processo
            'usuariolog.id_menu_item = 118
            'usuariolog.insertUsuarioLog()
            ''FRAN 08/12/2020  incluir log 

            'If exportData() = True Then

            '    lbl_aguarde.CssClass = "aguardenormal"

            '    Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
            'Else
            '    lbl_aguarde.CssClass = "aguardenormal"

            '    messageControl.Alert(ViewState.Item("nm_erro").ToString)

            'End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Protected Sub deleteArquivos()
    '    Dim arquivos() As String
    '    Dim index As Integer
    '    Dim ldata As Date
    '    Dim ldata_limite As Date

    '    ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

    '    'Obtem a lista de arquivos no diretório 
    '    arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

    '    For index = 0 To arquivos.Length - 1
    '        arquivos(index) = New FileInfo(arquivos(index)).FullName


    '        Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
    '        'Se o arquivo existir no servidor


    '        If InStr(arquivos(index), "MilkSystem_Esalq_Protocolos") <> 0 Then
    '            ldata = Arquivo.CreationTime
    '            If ldata < ldata_limite Then
    '                Arquivo.Delete()
    '            End If
    '        End If
    '    Next index



    'End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Try

            If Page.IsValid Then


                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                ViewState.Item("id_tipo_coleta") = cbo_tipo_coleta.SelectedValue

                If txt_dia_ini.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_ini") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                Else
                    ViewState.Item("dt_ini") = String.Concat(Right("00" & txt_dia_ini.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 00:00:00")
                    ViewState.Item("dt_fim") = String.Concat(Right("00" & txt_dia_fim.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 23:59:59")
                End If

                If ck_exportadas.Checked = True Then
                    ViewState.Item("st_exportacao") = "S"
                Else
                    ViewState.Item("st_exportacao") = "N"
                End If

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData(Optional ByVal pexportesalq As Boolean = False)

        Try
            Dim protocolo As New AnaliseEsalqProtocolo

            protocolo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            protocolo.dt_referencia = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
            protocolo.id_tipo_coleta_analise_esalq = ViewState.Item("id_tipo_coleta").ToString
            protocolo.dt_coleta_ini = ViewState("dt_ini").ToString
            protocolo.dt_coleta_fim = ViewState("dt_fim").ToString
            protocolo.st_exportacao = ViewState.Item("st_exportacao").ToString

            Dim dsprotocolo As DataSet = protocolo.getAnaliseEsalqProtocoloByFilters()

            If (dsprotocolo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsprotocolo.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_esalq_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar_esalq.Click
        Try

            If Page.IsValid Then
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                ViewState.Item("id_tipo_coleta") = cbo_tipo_coleta.SelectedValue

                If txt_dia_ini.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_ini") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                Else
                    ViewState.Item("dt_ini") = String.Concat(Right("00" & txt_dia_ini.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 00:00:00")
                    ViewState.Item("dt_fim") = String.Concat(Right("00" & txt_dia_fim.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8), " 23:59:59")
                End If

                If ck_exportadas.Checked = True Then
                    ViewState.Item("st_exportacao") = "S"
                Else
                    ViewState.Item("st_exportacao") = "N"
                End If

                loadData()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 210
                    usuariolog.ds_nm_processo = "PROTOCOLOS ESALQ"
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    loadData()
                    Response.Redirect("frm_exportar_esalq_protocolo_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&dt_ini=" + ViewState.Item("dt_ini").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_tipo_coleta=" + ViewState.Item("id_tipo_coleta").ToString + "&st_exportacao=" + ViewState.Item("st_exportacao").ToString())



                Else
                    messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                End If
            Else
                gridResults.Visible = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub chk_protocolo_descartado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_protocolo_descartado.CheckedChanged
        If chk_protocolo_descartado.Checked = True Then
            btn_exportar_esalq.Enabled = False
            btn_exportar_esalq.ToolTip = "Exportação dos Protocolos ESALQ - Apenas protocolos Ativos"
        Else
            btn_exportar_esalq.Enabled = True
            btn_exportar_esalq.ToolTip = "Exportação dos Protocolos ESALQ"
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_exportar_esalq_protocolo.aspx?st_incluirlog=N")

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridDescartados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridDescartados.PageIndexChanging
        gridDescartados.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub
End Class
