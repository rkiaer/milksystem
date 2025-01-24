Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Threading
Partial Class lst_custo_financeiro_calculo

    Inherits Page


    Private SegundaThread As Thread

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_custo_financeiro_calculo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 224

                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim custo As New CustoFinanceiro

            txt_ano_referencia.Text = DateTime.Parse(Now).ToString("yyyy")

            'Dim dscalculo As DataSet = custo.getDataUltimoCalculoProjetado

            'If dscalculo.Tables(0).Rows.Count > 0 Then
            '    With dscalculo.Tables(0).Rows(0)
            '        lbl_calculoprojetado.Text = String.Concat("Execução ", .Item("id_custo_financeiro_calculo_execucao").ToString, " - Ano ", .Item("nr_ano").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16), " (", .Item("ds_login").ToString, ")")
            '    End With
            'Else
            '    lbl_calculoprojetado.Text = "Nenhum cálculo projetado foi realizado."
            'End If

            'custo.nr_ano = txt_ano_referencia.Text
            'Dim dscalculoexec As DataSet = custo.getDataUltimoCalculoProjetado

            'If dscalculoexec.Tables(0).Rows.Count > 0 Then
            '    With dscalculoexec.Tables(0).Rows(0)
            '        lbl_ultimo_calculo.Text = String.Concat("Execução ", .Item("id_custo_financeiro_calculo_execucao").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16))
            '    End With
            'Else
            '    lbl_ultimo_calculo.Text = String.Empty
            'End If

            atualizarUltimaExecucao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_selecao As String = ViewState.Item("id_selecao").ToString
            Dim calculoprodutor As New CalculoProdutor(id_selecao)

            Dim calculo As New CustoFinanceiro
            calculo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao")

            Dim dsCalculo As DataSet = calculo.getCustoFinanceiroCalculo()


            If (dsCalculo.Tables(0).Rows.Count > 0) Then
                'gridResults.Visible = True
                'gridResults.DataSource = Helper.getDataView(dsCalculo.Tables(0), "")
                'gridResults.DataBind()
            Else
                'gridResults.Visible = False
                messageControl.Alert("Nenhum calculo projetado foi encontrado.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub calcularCustoFinanceiro()

        Try

            Dim calculo As New CustoFinanceiro()
            Dim ldtreferenciaprovisorio As String

            Dim calc As New CalculoProdutor
            calc.dt_referencia_start = DateTime.Parse(String.Concat("01/01/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")
            calc.dt_referencia_end = DateTime.Parse(String.Concat("01/12/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")

            ldtreferenciaprovisorio = calc.getCalculoDefinitivoByPeriodo.ToString
            If ldtreferenciaprovisorio.Equals(String.Empty) Then
                ldtreferenciaprovisorio = calc.dt_referencia_start.ToString
            Else
                ldtreferenciaprovisorio = DateAdd(DateInterval.Month, 1, CDate(ldtreferenciaprovisorio))
            End If

            ' Inicializa Cálculo
            calculo.nr_ano = txt_ano_referencia.Text
            calculo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao").ToString
            calculo.dt_referencia_ini = DateTime.Parse(String.Concat("01/01/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")
            calculo.dt_referencia_fim = DateTime.Parse(String.Concat("01/12/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")
            calculo.dt_referencia = ldtreferenciaprovisorio
            calculo.id_modificador = Session("id_login")

            calculo.calcularCustoFinanceiroProjetado()


            'Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + calculoprodutor.id_calculo_execucao.ToString())
            'Return calculoprodutor.id_calculo_execucao.ToString
        Catch ex As Exception
            'Return "0"
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Protected Sub btn_calcula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcula.Click
    '    If Page.IsValid Then

    '        ' Inicializa Cálculo Execução
    '        Dim calculo As New CustoFinanceiro()
    '        Dim st_calculo_execucao As String

    '        calculo.id_modificador = Session("id_login")
    '        calculo.nr_ano = txt_ano_referencia.Text
    '        ViewState.Item("id_calculo_execucao") = calculo.insertCustoFinanceiroCalculoExecucao()

    '        btn_calcula.Enabled = False
    '        btn_calcula.UpdateAfterCallBack = True

    '        calcularCustoFinanceiro()

    '        atualizarUltimaExecucao()

    '        calculo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao")
    '        st_calculo_execucao = calculo.getCustoFinanceiroCalculoStatusExecucao()
    '        If st_calculo_execucao = "F" Or st_calculo_execucao = "E" Then  ' Se fim do cálculo (sucesso ou erro)
    '            Label2.Text = "Calculo Finalizado"
    '            If st_calculo_execucao = "E" Then
    '                Label2.Text = "Calculo Finalizado com ERRO!"
    '            End If
    '            Label2.UpdateAfterCallBack = True
    '            btn_resultado.Enabled = True
    '            btn_resultado.UpdateAfterCallBack = True
    '            gridResults.Enabled = False

    '        End If


    '    End If

    'End Sub


    Protected Sub cv_calculo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_calculo.ServerValidate
        Try

            Dim lmsg As String = String.Empty
            args.IsValid = True

            Dim custo As New CustoFinanceiro
            custo.nr_ano = txt_ano_referencia.Text
            custo.dt_referencia_ini = DateTime.Parse(String.Concat("01/01/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")
            custo.dt_referencia_fim = DateTime.Parse(String.Concat("01/12/", txt_ano_referencia.Text)).ToString("dd/MM/yyyy")

            'se o ano atual for maior que o ano para realizar calculo nao deixa
            If DateTime.Parse(Now()).Year > CInt(txt_ano_referencia.Text) Then
                args.IsValid = False
                lmsg = "O ano de referência informado para Cálculo Projetado é inferior ao ano atual. O Cálculo projetado para o ano selecionado não poderá ser efetuado."
            Else
                'verificar se tem algum custo parametrizavel nao preenchido
                If custo.getCustoFinanceiroConsistirObrigatorio.Tables(0).Rows.Count = 0 Then
                    args.IsValid = False
                    lmsg = "Há custos paremetrizáveis obrigatórios que não foram informados no cadastro. O Cálculo projetado para o ano selecionado não poderá ser efetuado."

                Else
                    If custo.getCustoFinanceiroConsistirVolumeLeite = 0 Then
                        args.IsValid = False
                        lmsg = "Não há volume de leite coletado no ano para realizar projeção. O Cálculo projetado para o ano selecionado não poderá ser efetuado."

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

    Protected Sub txt_ano_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ano_referencia.TextChanged
        Try


            If txt_ano_referencia.Text = String.Empty Then
                ViewState.Item("id_calculo_execucao") = 0
                lbl_ultimo_calculo.Text = String.Empty
            Else
                Dim custo As New CustoFinanceiro
                custo.nr_ano = txt_ano_referencia.Text

                Dim dscalculo As DataSet = custo.getDataUltimoCalculoProjetado

                If dscalculo.Tables(0).Rows.Count > 0 Then
                    With dscalculo.Tables(0).Rows(0)
                        lbl_ultimo_calculo.Text = String.Concat(.Item("id_custo_financeiro_calculo_execucao").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16))
                        ViewState.Item("id_calculo_execucao") = .Item("id_custo_financeiro_calculo_execucao").ToString

                    End With
                Else
                    lbl_ultimo_calculo.Text = String.Empty
                    ViewState.Item("id_calculo_execucao") = 0

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub atualizarUltimaExecucao()

        Try

            Dim custo As New CustoFinanceiro

            txt_ano_referencia.Text = DateTime.Parse(Now).ToString("yyyy")

            Dim dscalculo As DataSet = custo.getDataUltimoCalculoProjetado

            If dscalculo.Tables(0).Rows.Count > 0 Then
                With dscalculo.Tables(0).Rows(0)
                    lbl_calculoprojetado.Text = String.Concat("Execução ", .Item("id_custo_financeiro_calculo_execucao").ToString, " - Ano ", .Item("nr_ano").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16), " (", .Item("ds_login").ToString, ")")
                End With
            Else
                lbl_calculoprojetado.Text = "Nenhum cálculo projetado foi realizado."
            End If

            custo.nr_ano = txt_ano_referencia.Text
            Dim dscalculoexec As DataSet = custo.getDataUltimoCalculoProjetado

            If dscalculoexec.Tables(0).Rows.Count > 0 Then
                With dscalculoexec.Tables(0).Rows(0)
                    lbl_ultimo_calculo.Text = String.Concat("Execução ", .Item("id_custo_financeiro_calculo_execucao").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16))
                    ViewState.Item("id_calculo_execucao") = .Item("id_custo_financeiro_calculo_execucao").ToString
                End With
            Else
                lbl_ultimo_calculo.Text = String.Empty
                ViewState.Item("id_calculo_execucao") = 0
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_calcular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_calcular.Click
        If Page.IsValid Then

            ' Inicializa Cálculo Execução
            Dim calculo As New CustoFinanceiro()
            Dim st_calculo_execucao As String

            calculo.id_modificador = Session("id_login")
            calculo.nr_ano = txt_ano_referencia.Text
            ViewState.Item("id_calculo_execucao") = calculo.insertCustoFinanceiroCalculoExecucao()

            btn_calcular.Enabled = False
            btn_calcular.UpdateAfterCallBack = True

            calcularCustoFinanceiro()

            atualizarUltimaExecucao()

            calculo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao")
            st_calculo_execucao = calculo.getCustoFinanceiroCalculoStatusExecucao()
            If st_calculo_execucao = "F" Then
                Label2.Text = "Calculo Finalizado"
                Label2.UpdateAfterCallBack = True
                btn_calcular.Enabled = True
                btn_calcular.UpdateAfterCallBack = True

                'loadData()
            End If
            If st_calculo_execucao = "E" Then  ' Se fim do cálculo (sucesso ou erro)
                Label2.Text = "Calculo Finalizado com ERRO!"
                Label2.UpdateAfterCallBack = True
                btn_calcular.Enabled = True
                btn_calcular.UpdateAfterCallBack = True
                'gridResults.Visible = False
                ViewState.Item("id_calculo_execucao") = 0
            End If


        End If

    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then
            Try


                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub cv_pesquisar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pesquisar.ServerValidate
        Try

            Dim lmsg As String = String.Empty
            args.IsValid = True

            If CInt(ViewState.Item("id_calculo_execucao")) = 0 Then
                'se tem execução selecionou periodo valido
                args.IsValid = False
                lmsg = "Para o ano de referência informado não existe Cálculo Projetado."

            End If


            If args.IsValid = False Then
                messageControl.Alert(lmsg)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Page.IsValid Then

            Try

                'FRAN ViewState.Item("st_tipo_visao") 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 224
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 



                Response.Redirect("frm_custo_financeiro_calculo_excel.aspx?id_execucao=" + ViewState.Item("id_calculo_execucao").ToString())


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
