Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_central_fornecedor_SAP

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_adto.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 122
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        'fran 16/09/2013 i
        With img_lupa_fornecedor
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiro Central"
        End With
        'fran 16/09/2013 f
    End Sub


    Private Sub loadDetails()

        Try


            'Fran 31/05/2010 i chamado 818
            'Dim portador As New Portador
            'cbo_portador.DataSource = portador.getPortadoresByFilters()
            'cbo_portador.DataTextField = "nm_portador"
            'cbo_portador.DataValueField = "id_portador"
            'cbo_portador.DataBind()
            'cbo_portador.Items.Insert(0, New ListItem("[Selecione]", "0"))
            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'Fran 31/05/2010 f chamado 818

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function exportData() As Boolean

        Try

            Dim pagtofornecedor As New PedidoPagtoFornecedor
            Dim lmsg As String

            pagtofornecedor.dt_referencia = ViewState.Item("dt_referencia").ToString()

            'fran 29/09/2013 - melhorias fase 1 i
            If Not ViewState.Item("dt_pagto").Equals(String.Empty) Then
                pagtofornecedor.dt_inicio = ViewState("dt_pagto").ToString
                pagtofornecedor.dt_fim = ViewState("dt_pagto").ToString
            Else
                'fran 29/09/2013 - melhorias fase 1 f
                pagtofornecedor.dt_inicio = ViewState("dt_referencia").ToString
                pagtofornecedor.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pagtofornecedor.dt_inicio)))
            End If
            'pagtofornecedor.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString() fran 16/09/2013 retirada obrigaryoriedade de estabelecimento

            pagtofornecedor.nm_arquivo = ViewState.Item("nm_arquivo")
            pagtofornecedor.st_exportacao = ViewState.Item("st_exportacao")
            pagtofornecedor.id_modificador = Session("id_login") '03/08/2012 fran - gko themis

            'fran 16/09/2013 i 
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pagtofornecedor.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            Else
                pagtofornecedor.id_fornecedor = 0

            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pagtofornecedor.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            'fran 16/09/2013 f 


            If pagtofornecedor.exportPagtoFornecedorSAP() = True Then       ' 09/03/2012 - Projeto Themis
                exportData = True
            Else
                exportData = False
                If pagtofornecedor.cd_erro = "Sem Linhas" Then
                    If pagtofornecedor.st_natureza_operacao = "N" Then 'se não há cadastro de natureza de operação
                        lmsg = "Não há cadastro ativo em Natureza de Operação para o código 4100AA!"
                    Else
                        If pagtofornecedor.st_item = "N" Then 'se não há cadastro de item
                            lmsg = "Não há cadastro ativo em Item para o código 41242005!"
                        Else 'se há cadastros, não encontrou linhas no getCentralPedidoPagtoFornecedorExportacao
                            lmsg = "Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente."
                        End If
                    End If
                End If
                If pagtofornecedor.cd_erro = "Exception" Then
                    lmsg = pagtofornecedor.nm_erro
                End If

                messageControl.Alert(lmsg)
            End If
            lbl_totallinhas.Text = pagtofornecedor.nr_linhasexportadas


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try
            If Page.IsValid = True Then


                Dim lnomearquivo As String

                'fran 16/09/2013 i escopo melhorias parte 1 MILK item 1.2.1
                If Not (txt_cd_fornecedor.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("cd_fornecedor") = txt_cd_fornecedor.Text.Trim()
                Else
                    ViewState.Item("cd_fornecedor") = String.Empty
                End If
                ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value
                'ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(dt_referencia.Text).ToString("MM/yyyy"))
                If dt_referencia.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_referencia") = String.Empty
                Else
                    ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(dt_referencia.Text).ToString("MM/yyyy"))
                End If
                If txt_dt_pagto.Text.Equals(String.Empty) Then
                    ViewState.Item("dt_pagto") = String.Empty
                Else
                    ViewState.Item("dt_pagto") = String.Concat(DateTime.Parse(txt_dt_pagto.Text).ToString("dd/MM/yyyy"))
                    ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(txt_dt_pagto.Text).ToString("MM/yyyy"))

                End If
                'fran 16/09/2013 f escopo melhorias parte 1 MILK

                'Fran 31/05/2010 i chamado 818
                'ViewState.Item("dt_processamento") = Me.dt_processamento.Text
                'ViewState.Item("dt_vencimento") = Me.dt_vencimento.Text
                'ViewState.Item("id_portador") = cbo_portador.SelectedValue
                'ViewState.Item("nm_portador") = cbo_portador.SelectedItem.Text
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                'Fran 31/05/2010 f chamado 818

                If ck_pagtos_exportados.Checked = True Then
                    ViewState.Item("st_exportacao") = "S"
                Else
                    ViewState.Item("st_exportacao") = "N"
                End If

                'ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("ArquivoPagtoFornec").ToString()
                'Fran 31/05/2010 i chamado 818
                'lnomearquivo = "\PagtoFornecedor" & Left(cbo_portador.SelectedItem.Text, 5) & DateTime.Parse(Convert.ToDateTime(ViewState.Item("dt_referencia"))).ToString("yyyy/MM") & ".txt"
                lnomearquivo = "\PagtoFornecedor" & DateTime.Parse(Convert.ToDateTime(ViewState.Item("dt_referencia"))).ToString("yyyy/MM") & "_" & Now() & ".txt"
                'Fran 31/05/2010 f chamado 818
                lnomearquivo = Replace(lnomearquivo, ":", "")
                lnomearquivo = Replace(lnomearquivo, " ", "")
                lnomearquivo = Replace(lnomearquivo, "/", "")


                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

                deleteArquivos()

                lbl_totallinhas.Visible = True

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 122
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                If exportData() = True Then
                    Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer
        Dim ldata As Date
        Dim ldata_limite As Date

        ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName


            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor


            If InStr(arquivos(index), "PagtoFornecedor") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub

    Protected Sub img_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_fornecedor.Click
        carregarCamposfornecedor()

    End Sub

    Private Sub carregarCamposfornecedor()
        Try

            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                lbl_nm_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If
            Me.ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value
            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged
        ' Fran 16/09/2013 - i
        lbl_nm_fornecedor.Text = String.Empty
        hf_id_fornecedor.Value = String.Empty
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou 
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_fornecedor.Enabled = True
                    lbl_nm_fornecedor.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_fornecedor.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Fran 16/09/2013 - f

    End Sub

    Protected Sub cv_exportar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_exportar.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True

            'se selecionou fornecdor e não tem id
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                If hf_id_fornecedor.Value.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "Código de Parceiro da Central informado é inválido."
                End If
            End If

            If txt_dt_pagto.Text.Equals(String.Empty) And dt_referencia.Text.Equals(String.Empty) Then
                args.IsValid = False
                lmsg = "O campo 'Data de Pagamento' ou o campo 'Mês/Ano Referência Pagamento' deve ser informado!"
            End If

            If (Not txt_dt_pagto.Text.Equals(String.Empty)) And (Not dt_referencia.Text.Equals(String.Empty)) Then
                args.IsValid = False
                lmsg = "Apenas um dos campos: 'Data de Pagamento' ou 'Mês/Ano Referência Pagamento' deve ser informado!"
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
End Class
