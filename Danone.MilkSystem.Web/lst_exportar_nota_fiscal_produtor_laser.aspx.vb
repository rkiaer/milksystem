Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_nota_fiscal_produtor_laser

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_nota_fiscal_produtor_laser.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        'Fran 11/03/2009 rls 17
        btn_exportar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")
        'lbl_aguarde.Attributes.Add("onPropertyChange", "lbl_aguarde.className='aguardenormal';")


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function exportData() As Boolean

        Try

            Dim notafiscal As New NotaFiscal
            'ViewState.Item("SemNaturezaOperacao") = "N"

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                notafiscal.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
            notafiscal.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)
            notafiscal.nm_arquivo = ViewState.Item("nm_arquivo")
            If Trim(ViewState.Item("nr_nota_fiscal_ini")) <> "" Then
                notafiscal.nr_nota_fiscal_ini = Convert.ToDecimal(ViewState.Item("nr_nota_fiscal_ini").ToString)
                notafiscal.nr_nota_fiscal_fim = Convert.ToDecimal(ViewState.Item("nr_nota_fiscal_fim").ToString)
            End If

            'notafiscal.st_exportacao = ViewState.Item("st_exportacao")
            'notafiscal.id_situacao = 1      'Somente notas ativas
            notafiscal.id_modificador = Session("id_login")   'Para exportar o usuário que está logado
            'notafiscal.id_propriedade = 500
            notafiscal.imprimeNotaFiscalProdutor()

            lbl_totallidas.Text = notafiscal.nr_linhaslidas
            lbl_totallinhas.Text = notafiscal.nr_linhasexportadas
            If notafiscal.nr_linhasexportadas > 0 Then
                Return True
            Else
                'If Left(notafiscal.cd_natureza_operacao, 3) = "SEM" Then
                'ViewState.Item("SemNaturezaOperacao") = notafiscal.cd_natureza_operacao
                'End If
                Return False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
            Return False

        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid = True Then
            Try

                btn_exportar.Enabled = False
                'Fran 06/04/2009 
                hl_download.NavigateUrl = String.Empty
                hl_download.Enabled = True
                'fran 06/04/2009 f
                Dim lnomearquivo As String

                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = txt_dt_referencia.Text
                ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
                ViewState.Item("nr_nota_fiscal_ini") = Me.txt_nr_nota_fiscal_ini.Text.Trim()
                ViewState.Item("nr_nota_fiscal_fim") = Me.txt_nr_nota_fiscal_fim.Text.Trim()


                ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                'ViewState.Item("caminho_arquivo") = "c:"
                lnomearquivo = "\MilkSystem_NotaFiscal_Produtor_Laser_" & Now() & Session.SessionID & ".txt"
                lnomearquivo = Replace(lnomearquivo, ":", "")
                lnomearquivo = Replace(lnomearquivo, " ", "")
                lnomearquivo = Replace(lnomearquivo, "/", "")


                ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

                deleteArquivos()

                lbl_totallidas.Visible = True
                lbl_totallinhas.Visible = True

                If exportData() = True Then
                    lbl_aguarde.CssClass = "aguardenormal"
                    'lbl_aguarde.Text = ""
                    ''Me.RegisterStartupScript("x", "<script>showaguarde()</script>")
                    'lbl_aguarde.Text = ""
                    'Fran 06/04/2009 i
                    'Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
                    hl_download.Enabled = True
                    hl_download.NavigateUrl = String.Format("frm_download.aspx?arquivo={0}", ViewState.Item("nm_arquivo").ToString)
                    btn_exportar.Enabled = True
                    'Fran 06/04/2009 f

                    'Response.Redirect("lupa_veiculo.aspx")
                    'Else
                    '    If ViewState.Item("SemNaturezaOperacao") = "N" Then
                    '        messageControl.Alert("Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente.")
                    '    Else
                    '        If ViewState.Item("SemNaturezaOperacao") = "SEM REGRA" Then
                    '            messageControl.Alert("Há divergências nas regras para Natureza de Operação. O arquivo não pode ser gerado.")
                    '        End If
                    '        If ViewState.Item("SemNaturezaOperacao") = "SEM CADASTRO" Then
                    '            messageControl.Alert("Nenhum cadastro foi encontrado para a Natureza de Operação informada. O arquivo não pode ser gerado.")
                    '        End If

                    '    End If
                Else
                    'Fran 06/04/2009 i
                    hl_download.Enabled = False
                    hl_download.NavigateUrl = String.Empty
                    lbl_aguarde.CssClass = "aguardenormal"
                    btn_exportar.Enabled = True
                    'Fran 06/04/2009 f

                End If
                lbl_aguarde.CssClass = "aguardenormal"
                'lbl_aguarde.ForeColor = Drawing.Color.White
            Catch ex As Exception
                messageControl.Alert(ex.Message)
        End Try

        End If
    End Sub
    Private Function consistirDadosNotaFiscalProdutorLaser() As Boolean


        If Page.IsValid Then
            Try
                consistirDadosNotaFiscalProdutorLaser = True

                If cbo_estabelecimento.SelectedValue = 0 Then
                    consistirDadosNotaFiscalProdutorLaser = False
                    Throw New Exception("O estabelecimento deve ser informado.")
                End If

                If txt_dt_referencia.Text.Equals(String.Empty) Then
                    consistirDadosNotaFiscalProdutorLaser = False
                    Throw New Exception("O mês/ano de referência deve ser informado.")
                End If

                Dim lmsg As String = String.Empty
                Dim nrnota_isvalid As Boolean
                nrnota_isvalid = True
                'Se os campos são vazios deixa fazer sem informar nota porem antes deve verificar o count da ficha para evitar estouro de memória
                If txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) And txt_nr_nota_fiscal_fim.Text.Trim.Equals(String.Empty) Then
                    nrnota_isvalid = True
                Else
                    'Se a nota inicial ou a nota final foi informada verifica se uma das duas foi preenchida
                    If txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) Then
                        lmsg = "O número da nota fiscal inicial deve ser informada!"
                        nrnota_isvalid = False
                    End If
                    If txt_nr_nota_fiscal_fim.Text.Trim.Equals(String.Empty) Then
                        lmsg = "O número da nota fiscal final deve ser informada!"
                        nrnota_isvalid = False
                    End If
                    If nrnota_isvalid = True Then
                        If CDbl(txt_nr_nota_fiscal_ini.Text) > CDbl(txt_nr_nota_fiscal_fim.Text) Then
                            consistirDadosNotaFiscalProdutorLaser = False
                            Throw New Exception("O número informado para nota fiscal inicial não deve ser maior que o número informado para a nota fiscal final.")
                        End If
                    End If

                End If

                If nrnota_isvalid = True Then 'fazer count da ficha para ver se pode estourar memória

                    Dim fichafinanceira As New FichaFinanceira
                    fichafinanceira.id_grupo = 1
                    fichafinanceira.st_emite_nota_fiscal = "N"
                    fichafinanceira.st_exportacao_nota = "S"
                    fichafinanceira.st_pagamento = "D"
                    fichafinanceira.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                    If Not txt_cd_propriedade.Text.Trim.Equals(String.Empty) Then
                        fichafinanceira.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text)
                    End If
                    fichafinanceira.dt_referencia = String.Concat("01/", txt_dt_referencia.Text.Trim)
                    If Not txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) Then
                        fichafinanceira.nr_nota_fiscal_ini = Convert.ToDecimal(txt_nr_nota_fiscal_ini.Text)
                        fichafinanceira.nr_nota_fiscal_fim = Convert.ToDecimal(txt_nr_nota_fiscal_fim.Text)
                    End If
                    Dim countnota As Decimal
                    countnota = fichafinanceira.getFichaFinanceiraCountNota
                    If countnota = 0 Then
                        nrnota_isvalid = False
                        lmsg = "Não existem notas para geração do arquivo. Por favor tente novamente."
                    Else
                        If countnota > 200 Then
                            nrnota_isvalid = False
                            lmsg = "Foram encontradas " & CInt(countnota).ToString & " notas para geração do arquivo de exportação. Por favor informe o número inicial e final da nota fiscal que não ultrapasse o limite de 200 notas fiscais por arquivo."
                        End If
                    End If
                End If
                If nrnota_isvalid = False Then
                    consistirDadosNotaFiscalProdutorLaser = False
                    Throw New Exception(lmsg)
                End If




            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Function
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


            If InStr(arquivos(index), "MilkSystem_NotaFiscal_Produtor") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        If Me.cbo_estabelecimento.SelectedValue <> "0" Then
            Me.lbl_nm_propriedade.Visible = True
            carregarCamposPropriedade()
        End If

    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = ""
        lbl_nm_propriedade.Visible = False

    End Sub

    Protected Sub cv_range_nr_nota_fiscal_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_range_nr_nota_fiscal.ServerValidate
        Dim lmsg As String = String.Empty
        args.IsValid = True
        'Se os campos são vazios deixa fazer sem informar nota porem antes deve verificar o count da ficha para evitar estouro de memória
        If txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) And txt_nr_nota_fiscal_fim.Text.Trim.Equals(String.Empty) Then
            args.IsValid = True
        Else
            'Se a nota inicial ou a nota final foi informada verifica se uma das duas foi preenchida
            If txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) Then
                lmsg = "O número da nota fiscal inicial deve ser informada!"
                args.IsValid = False
            End If
            If txt_nr_nota_fiscal_fim.Text.Trim.Equals(String.Empty) Then
                lmsg = "O número da nota fiscal final deve ser informada!"
                args.IsValid = False
            End If
        End If

        If args.IsValid = True Then 'fazer count da ficha para ver se pode estourar memória

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.id_grupo = 1
            fichafinanceira.st_emite_nota_fiscal = "N"
            fichafinanceira.st_exportacao_nota = "S"
            fichafinanceira.st_pagamento = "D"
            fichafinanceira.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            If Not txt_cd_propriedade.Text.Trim.Equals(String.Empty) Then
                fichafinanceira.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text)
            End If
            fichafinanceira.dt_referencia = String.Concat("01/", txt_dt_referencia.Text.Trim)
            If Not txt_nr_nota_fiscal_ini.Text.Trim.Equals(String.Empty) Then
                fichafinanceira.nr_nota_fiscal_ini = Convert.ToDecimal(txt_nr_nota_fiscal_ini.Text)
                fichafinanceira.nr_nota_fiscal_fim = Convert.ToDecimal(txt_nr_nota_fiscal_fim.Text)
            End If
            Dim countnota As Decimal
            countnota = fichafinanceira.getFichaFinanceiraCountNota
            If countnota = 0 Then
                args.IsValid = False
                lmsg = "Não existem notas para geração do arquivo. Por favor tente novamente."
            Else
                If countnota > 200 Then
                    args.IsValid = False
                    lmsg = "Foram encontradas " & CInt(countnota).ToString & " notas para geração do arquivo de exportação. Por favor informe o número inicial e final da nota fiscal que não ultrapasse o limite de 200 notas fiscais por arquivo."
                End If
            End If
        End If
        If args.IsValid = False Then
            messageControl.Alert(lmsg)
        End If
    End Sub
End Class
