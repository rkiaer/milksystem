Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Threading




Partial Class frm_calculo_produtor

    Inherits Page

    'Shared Tempo As Integer
    'Shared bEmCalculo As Boolean = False
    'Shared idss As String



    Private SegundaThread As Thread

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_calculo_produtor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            'cbo_tipo_pagamento.Items.Add(New ListItem("[Selecione]", String.Empty))
            'If ViewState.Item("tp_pagamento") = "Q" Then
            '    cbo_tipo_pagamento.Items.Add(New ListItem("Quinzenal", "Q"))
            'Else
            '    cbo_tipo_pagamento.Items.Add(New ListItem("Mensal", "M"))
            'End If

            If Not (Request("id_selecao") Is Nothing) Then
                ViewState.Item("id_selecao") = Request("id_selecao")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                If Not (Request("tp_pagamento") Is Nothing) Then
                    ViewState.Item("tp_pagamento") = Request("tp_pagamento")
                Else
                    ViewState.Item("tp_pagamento") = "M"
                End If

                If ViewState.Item("tp_pagamento") = "Q" Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                    txt_dt_referencia.Text = ViewState.Item("dt_referencia")
                    txt_dt_referencia.Enabled = False
                    cbo_tipo_pagamento.Items.Add(New ListItem("Quinzenal", "Q"))
                Else
                    txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
                    cbo_tipo_pagamento.Items.Add(New ListItem("Mensal", "M"))
                End If

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            'Dim id_selecao As String = ViewState.Item("id_selecao").ToString
            'Dim calculoprodutor As New CalculoProdutor(id_selecao)

            Dim calculoprodutor As New CalculoProdutor
            calculoprodutor.id_selecao = ViewState.Item("id_selecao").ToString

            Dim dsCalculoProdutor As DataSet

            calculoprodutor.st_selecao = 1

            If ViewState.Item("tp_pagamento") = "Q" Then  'Se veio do Adiantamento Quinzenal
                dsCalculoProdutor = calculoprodutor.getCalculoAdiantamentoByFilters()
            Else
                dsCalculoProdutor = calculoprodutor.getCalculoProdutorByFilters()
            End If

            If (dsCalculoProdutor.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCalculoProdutor.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum Produtor foi selecionado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub calcularProdutor()

        Try


            Dim calculoprodutor As New CalculoProdutor()

            ' Inicializa Cálculo
            calculoprodutor.dt_referencia = String.Concat("01/", txt_dt_referencia.Text.Trim)
            calculoprodutor.st_tipo_pagamento = cbo_tipo_pagamento.SelectedValue
            ' 18/11/2008 - i
            If ck_calculo_definitivo.Checked = True Then
                calculoprodutor.st_pagamento = "D"      ' Calculo Definitivo
            Else
                calculoprodutor.st_pagamento = "P"      ' Calculo Provisório
            End If
            ' 18/11/2008 - f
            calculoprodutor.id_modificador = Session("id_login")
            calculoprodutor.id_selecao = ViewState.Item("id_selecao").ToString

            ' Adri 19/11/2008 - Foi criada fora da tread - i
            '' Inicializa Cálculo Execução
            'calculoprodutor.calculoexecucao.dt_referencia = calculoprodutor.dt_referencia
            'calculoprodutor.calculoexecucao.st_tipo_pagamento = calculoprodutor.st_tipo_pagamento
            'calculoprodutor.calculoexecucao.id_estabelecimento = ViewState.Item("id_estabelecimento")

            'calculoprodutor.id_calculo_execucao = calculoprodutor.calculoexecucao.insertCalculoExecucao()
            'calculoprodutor.calculoexecucao.id_calculo_execucao = calculoprodutor.id_calculo_execucao
            calculoprodutor.id_calculo_execucao = ViewState.Item("id_calculo_execucao")
            calculoprodutor.calculoexecucao.id_calculo_execucao = ViewState.Item("id_calculo_execucao")
            ' Adri 19/11/2008 - Foi criada fora da tread - f

            calculoprodutor.id_estabelecimento = ViewState.Item("id_estabelecimento")  ' adri 04/07/2016 - chamado 2448 - Cálculo Geométrico (precisa do estabelecimento para verificar se qualidade está liberada para cálculo)

            'fran 07/2017 i
            Dim antecipacao As New ParametroAntecipacao
            antecipacao.id_situacao = 1
            antecipacao.dt_referencia = calculoprodutor.dt_referencia
            Dim dsantecipacao As DataSet = antecipacao.getParametroAntecipacaoByFilters

            If dsantecipacao.Tables(0).Rows.Count > 0 Then
                calculoprodutor.nr_dias_antecipacao = dsantecipacao.Tables(0).Rows(0).Item("nr_dias_antecipacao")
            Else
                calculoprodutor.nr_dias_antecipacao = 0
            End If
            'fran 07/2017 f

            'fran 12/2021
            Dim calcjuros As New CalculoJuros
            calcjuros.id_situacao = 1
            calcjuros.dt_referencia = calculoprodutor.dt_referencia
            Dim dscalcjuros As DataSet = calcjuros.getCalculoJurosByFilters
            If dscalcjuros.Tables(0).Rows.Count > 0 Then
                calculoprodutor.nr_valor_juros = dscalcjuros.Tables(0).Rows(0).Item("nr_valor")
            Else
                calculoprodutor.nr_valor_juros = 0
            End If


            If ViewState.Item("tp_pagamento") = "Q" Then
                calculoprodutor.calcularAdiantamento()
            Else
                calculoprodutor.calcularProdutor()
            End If


            'Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + calculoprodutor.id_calculo_execucao.ToString())
            'Return calculoprodutor.id_calculo_execucao.ToString
        Catch ex As Exception
            'Return "0"
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        If ViewState.Item("tp_pagamento") = "Q" Then
            Response.Redirect("lst_calculo_adiantamento.aspx")
        Else
            Response.Redirect("lst_calculo_produtor.aspx")
        End If
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    'Protected Sub btn_calcula_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_calcula.Click
    '    ''btn_calcula.Enabled = False     ' 18/11/2008

    '    ''img_progresso.Visible = True

    '    ''Response.Redirect("frm_barra_progresso.aspx?id_selecao=" + ViewState.Item("id_selecao").ToString)

    '    ''Raul 20081119 Coloquei 1 timer para atualizar a execucao e uma thread para executar o calculo
    '    'btn_calcula.Enabled = False
    '    'btn_calcula.UpdateAfterCallBack = True
    '    'Label2.Visible = True
    '    'Tempo = 0
    '    'Label2.Text = "Execução em " & Tempo.ToString & " segundos"
    '    'Label2.UpdateAfterCallBack = True
    '    'Image1.Visible = True
    '    'Image1.UpdateAfterCallBack = True
    '    'Timer1.Interval = 1000
    '    'Timer1.Enabled = True
    '    'Timer1.StartTimer()
    '    'SegundaThread = New Thread(AddressOf ThreadCode)
    '    'SegundaThread.Start()
    '    ''Raul 20081119 Fim da alteracao
    'End Sub
    Public Sub ThreadCode()
        'bEmCalculo = True
        'em caso de excecao utilize o codigo abaixo para parar o timer e desligar a imagem 
        'Label2.Text = "Calculo Finalizado"
        'Label2.UpdateAfterCallBack = True
        'Image1.Visible = False
        'Image1.UpdateAfterCallBack = True
        'Timer1.StopTimer()


        'idss = calcularProdutor()
        calcularProdutor()
        'bEmCalculo = False
    End Sub
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.StopTimer()   'Para o timer para nao ter recursividade
        'Tempo = Tempo + 1
        ViewState.Item("tempo") = Convert.ToInt32(ViewState.Item("tempo")) + 1
        'Label2.Text = "Execução em " & Tempo.ToString & " segundos"
        Label2.Text = "Execução em " & ViewState.Item("tempo").ToString & " segundos"
        Label2.UpdateAfterCallBack = True
        Dim calculoexecucao As New CalculoExecucao
        Dim st_calculo_execucao As String
        calculoexecucao.id_calculo_execucao = ViewState.Item("id_calculo_execucao")
        st_calculo_execucao = calculoexecucao.getCalculoStatusExecucao()
        If st_calculo_execucao = "F" Or st_calculo_execucao = "E" Then  ' Se fim do cálculo (sucesso ou erro)
            Label2.Text = "Calculo Finalizado"
            If st_calculo_execucao = "E" Then
                Label2.Text = "Calculo Finalizado com ERRO!"
            End If
            Label2.UpdateAfterCallBack = True
            Image1.Visible = False
            Image1.UpdateAfterCallBack = True
            btn_resultado.Enabled = True
            btn_resultado.UpdateAfterCallBack = True
            gridResults.Enabled = False
            gridResults.UpdateAfterCallBack = True
        Else
            Timer1.StartTimer() 'se a execucao nao acabou continua com o timer

        End If
        'If bEmCalculo = False Then
        '    Label2.Text = "Calculo Finalizado"
        '    Label2.UpdateAfterCallBack = True
        '    Image1.Visible = False
        '    Image1.UpdateAfterCallBack = True
        '    btn_resultado.Enabled = True
        '    btn_resultado.UpdateAfterCallBack = True
        'Else
        '    Timer1.StartTimer() 'se a execucao nao acabou continua com o timer
        'End If
        
    End Sub

    Protected Sub btn_resultado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_resultado.Click
        'Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + idss)
        Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString)

    End Sub

    Protected Sub btn_calcula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_calcula.Click
        'btn_calcula.Enabled = False     ' 18/11/2008

        'img_progresso.Visible = True

        'Response.Redirect("frm_barra_progresso.aspx?id_selecao=" + ViewState.Item("id_selecao").ToString)

        'Adri 19112008 - Cria item na ms_calculo_execucao (fora da thread) i
        ' Inicializa Cálculo Execução
        Dim calculoprodutor As New CalculoProdutor()
        calculoprodutor.calculoexecucao.dt_referencia = String.Concat("01/", txt_dt_referencia.Text.Trim)
        CalculoProdutor.calculoexecucao.st_tipo_pagamento = cbo_tipo_pagamento.SelectedValue
        calculoprodutor.calculoexecucao.id_estabelecimento = ViewState.Item("id_estabelecimento")
        calculoprodutor.calculoexecucao.id_modificador = Session("id_login")
        ViewState.Item("id_calculo_execucao") = CalculoProdutor.calculoexecucao.insertCalculoExecucao()
        'Adri 19112008 - f

        'Raul 20081119 Coloquei 1 timer para atualizar a execucao e uma thread para executar o calculo
        btn_calcula.Enabled = False
        btn_calcula.UpdateAfterCallBack = True
        Label2.Visible = True
        'Tempo = 0
        ViewState.Item("tempo") = 0
        'Label2.Text = "Execução em " & Tempo.ToString & " segundos"
        Label2.Text = "Execução em " & ViewState.Item("tempo").ToString & " segundos"
        Label2.UpdateAfterCallBack = True
        Image1.Visible = True
        Image1.UpdateAfterCallBack = True
        Timer1.Interval = 1000
        Timer1.Enabled = True
        Timer1.StartTimer()
        SegundaThread = New Thread(AddressOf ThreadCode)
        SegundaThread.Start()
        'Raul 20081119 Fim da alteracao
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

End Class
