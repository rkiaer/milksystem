Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class AnaliseEsalq

    Private _id_analise_esalq As Int32
    Private _id_analise_esalq_global As Int32
    Private _id_analise_esalq_silo As Int32
    Private _id_propriedade As Int32
    Private _nr_valor_esalq As Decimal
    Private _dt_coleta_start As String
    Private _dt_coleta_end As String
    Private _dt_coleta As String
    Private _dt_processamento As String
    Private _dt_analise As String
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _id_situacao As Int32
    Private _cd_analise_esalq As Int32
    Private _id_analise As Int32    ' 12/11/2009 - Chamado 515 - Maracanau
    Private _dt_modificacao As String
    Private _id_modificador As Int32
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_criacao As Int32
    Private _st_tipo_analise As String
    Private _id_romaneio As Int32       ' 05/11/2008
    Private _id_resultado As Int32      ' 05/11/2008
    Private _ds_placa As String
    Private _id_silo As Int32           ' 10/12/2008
    Private _id_estabelecimento As Int32    ' 10/12/2008
    Private _nr_silo As Int32    ' 10/12/2008

    ' Adri 09/06/2016 - chamado 2441 - i
    Private _id_importacao As Int32
    Private _dt_referencia As String   ' Para incluir a ms_analise_esalq_header
    Private _nr_media_mg As Decimal
    Private _nr_variacao_mg As Decimal
    Private _id_situacao_analise_esalq As Int32
    Private _id_aprovacao_analise_esalq As Int32
    Private _st_selecao As String
    Private _nr_analiseesalq_percvariacaoMG As Decimal
    ' Adri 09/06/2016 - chamado 2441 - f

    Private _st_transferencia As String   ' fran 21/07/2016
    Private _id_tipo_coleta_analise_esalq As Int32   ' fran 26/07/2016
    Private _id_pessoa As Int32   ' fran 26/07/2016
    Private _id_conta_teor As Int32 '07/12/2016 - Mirella
    Private _id_conta_bonus As Int32 '07/12/2016 - Mirella
    Private _id_conta_desconto As Int32 '07/12/2016 - Mirella
    Private _id_conta_teor_complience As Int32 '20/12/2016 - Mirella
    Private _id_conta_teor_mensal As Int32 '23/12/2016 - adri
    Private _id_conta_teor_trimestral As Int32 '23/12/2016 - adri
    Private _estabelecimentos As String  '08/02/2017 - adri chamado 2500 acertos (permitir busca de Poços com Águas) 
    Private _id_grupo As Int32  '08/02/2017 - adri chamado 2500 acertos (filtrar Produtores / Cooperativas)
    Private _st_pagamento As String ' 14/02/2017 - chamado 2501

    Private _id_cooperativa As Int32   ' fran dez/2018
    Private _nr_nota_fiscal As String   ' fran dez/2018
    Private _id_tecnico As Int32 ' fran out/2020
    Private _st_categoria_tecnico As String 'fran out/2020
    Private _st_tipo_propriedade As String 'fran out/2020
    Private _ds_compl As String 'fran out/2020
    Private _nr_compl As Int32 'fran out/2020

    Private _dt_referencia_ini As String   ' 06/06/2017 - Curva ABC fase 2 - relatório KPI Qualidade
    Private _dt_referencia_fim As String   ' 06/06/2017 - Curva ABC fase 2 - relatório KPI Qualidade
    Private _nr_faixa_ini As Decimal       ' 14/06/2017 - Curva ABC fase 2 - relatório Overview
    Private _nr_faixa_fim As Decimal       ' 14/06/2017 - Curva ABC fase 2 - relatório Overview

    Private _st_exportacao As String ' 06/04/2021 - fran
    Private _id_propriedade_matriz As Int32 ' 06/04/2021 - fran
    Private _id_analise_esalq_protocolo As Int32 ' 06/04/2021 - fran
    Private _cd_protocolo As String ' 06/04/2021 - fran
    Private _id_tecnico_comquali As Int32
    Private _id_tecnico_educampo As Int32



    Public Property id_conta_teor() As Int32 '07/12/2016 - Mirella i
        Get
            Return _id_conta_teor
        End Get
        Set(ByVal value As Int32)
            _id_conta_teor = value
        End Set
    End Property
    Public Property id_conta_teor_complience() As Int32
        Get
            Return _id_conta_teor_complience
        End Get
        Set(ByVal value As Int32)
            _id_conta_teor_complience = value
        End Set
    End Property
    Public Property id_conta_teor_mensal() As Int32 '23/12/2016 - adri
        Get
            Return _id_conta_teor_mensal
        End Get
        Set(ByVal value As Int32)
            _id_conta_teor_mensal = value
        End Set
    End Property
    Public Property id_conta_teor_trimestral() As Int32 '23/12/2016 - adri
        Get
            Return _id_conta_teor_trimestral
        End Get
        Set(ByVal value As Int32)
            _id_conta_teor_trimestral = value
        End Set
    End Property
    Public Property id_conta_bonus() As Int32
        Get
            Return _id_conta_bonus
        End Get
        Set(ByVal value As Int32)
            _id_conta_bonus = value
        End Set
    End Property

    Public Property id_conta_desconto() As Int32
        Get
            Return _id_conta_desconto
        End Get
        Set(ByVal value As Int32)
            _id_conta_desconto = value
        End Set
    End Property    '07/12/2016 - Mirella f

    Public Property id_analise_esalq() As Int32
        Get
            Return _id_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq = value
        End Set
    End Property
    Public Property id_analise_esalq_global() As Int32
        Get
            Return _id_analise_esalq_global
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq_global = value
        End Set
    End Property
    Public Property id_analise_esalq_silo() As Int32
        Get
            Return _id_analise_esalq_silo
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq_silo = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property

    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property
    Public Property id_tecnico_comquali() As Int32
        Get
            Return _id_tecnico_comquali
        End Get
        Set(ByVal value As Int32)
            _id_tecnico_comquali = value
        End Set
    End Property
    Public Property id_tecnico_educampo() As Int32
        Get
            Return _id_tecnico_educampo
        End Get
        Set(ByVal value As Int32)
            _id_tecnico_educampo = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property

    Public Property nr_valor_esalq() As Decimal
        Get
            Return _nr_valor_esalq
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_esalq = value
        End Set
    End Property

    Public Property nr_linhaslidas() As Int32
        Get
            Return _nr_linhaslidas
        End Get
        Set(ByVal value As Int32)
            _nr_linhaslidas = value
        End Set
    End Property

    Public Property nr_linhasimportadas() As Int32
        Get
            Return _nr_linhasimportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasimportadas = value
        End Set
    End Property

    Public Property dt_coleta_start() As String
        Get
            Return _dt_coleta_start
        End Get
        Set(ByVal value As String)
            _dt_coleta_start = value
        End Set
    End Property
    Public Property dt_coleta_end() As String
        Get
            Return _dt_coleta_end
        End Get
        Set(ByVal value As String)
            _dt_coleta_end = value
        End Set
    End Property

    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
        End Set
    End Property

    Public Property st_tipo_analise() As String
        Get
            Return _st_tipo_analise
        End Get
        Set(ByVal value As String)
            _st_tipo_analise = value
        End Set
    End Property
    Public Property st_categoria_tecnico() As String
        Get
            Return _st_categoria_tecnico
        End Get
        Set(ByVal value As String)
            _st_categoria_tecnico = value
        End Set
    End Property
    Public Property st_tipo_propriedade() As String
        Get
            Return _st_tipo_propriedade
        End Get
        Set(ByVal value As String)
            _st_tipo_propriedade = value
        End Set
    End Property
    Public Property ds_compl() As String
        Get
            Return _ds_compl
        End Get
        Set(ByVal value As String)
            _ds_compl = value
        End Set
    End Property
    Public Property nr_compl() As Int32
        Get
            Return _nr_compl
        End Get
        Set(ByVal value As Int32)
            _nr_compl = value
        End Set
    End Property
    Public Property dt_processamento() As String
        Get
            Return _dt_processamento
        End Get
        Set(ByVal value As String)
            _dt_processamento = value
        End Set
    End Property
    Public Property dt_analise() As String
        Get
            Return _dt_analise
        End Get
        Set(ByVal value As String)
            _dt_analise = value
        End Set
    End Property
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property
    Public Property st_transferencia() As String
        Get
            Return _st_transferencia
        End Get
        Set(ByVal value As String)
            _st_transferencia = value
        End Set
    End Property
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property

    Public Property cd_analise_esalq() As Int32
        Get
            Return _cd_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _cd_analise_esalq = value
        End Set
    End Property
    Public Property id_analise() As Int32
        Get
            Return _id_analise
        End Get
        Set(ByVal value As Int32)
            _id_analise = value
        End Set
    End Property
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_resultado() As Int32
        Get
            Return _id_resultado
        End Get
        Set(ByVal value As Int32)
            _id_resultado = value
        End Set
    End Property
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Property id_silo() As Int32
        Get
            Return _id_silo
        End Get
        Set(ByVal value As Int32)
            _id_silo = value
        End Set
    End Property
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property nr_silo() As Int32
        Get
            Return _nr_silo
        End Get
        Set(ByVal value As Int32)
            _nr_silo = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Property nr_media_mg() As Decimal
        Get
            Return _nr_media_mg
        End Get
        Set(ByVal value As Decimal)
            _nr_media_mg = value
        End Set
    End Property

    Public Property nr_variacao_mg() As Decimal
        Get
            Return _nr_variacao_mg
        End Get
        Set(ByVal value As Decimal)
            _nr_variacao_mg = value
        End Set
    End Property
    Public Property id_situacao_analise_esalq() As Int32
        Get
            Return _id_situacao_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_situacao_analise_esalq = value
        End Set
    End Property
    Public Property id_aprovacao_analise_esalq() As Int32
        Get
            Return _id_aprovacao_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_aprovacao_analise_esalq = value
        End Set
    End Property
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Property st_exportacao() As String
        Get
            Return _st_exportacao
        End Get
        Set(ByVal value As String)
            _st_exportacao = value
        End Set
    End Property
    Public Property nr_analiseesalq_percvariacaoMG() As Decimal
        Get
            Return _nr_analiseesalq_percvariacaoMG
        End Get
        Set(ByVal value As Decimal)
            _nr_analiseesalq_percvariacaoMG = value
        End Set
    End Property
    Public Property id_tipo_coleta_analise_esalq() As Int32
        Get
            Return _id_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta_analise_esalq = value
        End Set
    End Property
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property
    ' adri 08/02/2017 - chamado 2500 - i
    Public Property estabelecimentos() As String
        Get
            Return _estabelecimentos
        End Get
        Set(ByVal value As String)
            _estabelecimentos = value
        End Set
    End Property
    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property
    ' adri 08/02/2017 - chamado 2500 - f
    Public Property st_pagamento() As String ' 14/02/2017 - chamado 2501 i
        Get
            Return _st_pagamento
        End Get
        Set(ByVal value As String)
            _st_pagamento = value
        End Set
    End Property ' 14/02/2017 - chamado 2501 f
    Public Property dt_referencia_ini() As String
        Get
            Return _dt_referencia_ini
        End Get
        Set(ByVal value As String)
            _dt_referencia_ini = value
        End Set
    End Property
    Public Property dt_referencia_fim() As String
        Get
            Return _dt_referencia_fim
        End Get
        Set(ByVal value As String)
            _dt_referencia_fim = value
        End Set
    End Property
    Public Property nr_faixa_ini() As Decimal
        Get
            Return _nr_faixa_ini
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_ini = value
        End Set
    End Property
    Public Property nr_faixa_fim() As Decimal
        Get
            Return _nr_faixa_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_fim = value
        End Set
    End Property
    Public Property id_analise_esalq_protocolo() As Int32
        Get
            Return _id_analise_esalq_protocolo
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq_protocolo = value
        End Set
    End Property
    Public Property cd_protocolo() As String
        Get
            Return _cd_protocolo
        End Get
        Set(ByVal value As String)
            _cd_protocolo = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_analise_esalq = id
        loadAnaliseEsalq()

    End Sub
    Public Sub New()

    End Sub
    Public Function getAnaliseEsalqSiloByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqSilo", parameters, "ms_getAnalisesEsalqSilo")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento() As DataSet '07/12/2016 - Mirella i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcIN76() As DataSet '10/2020 - Fran i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcIN76", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento_Cat1() As DataSet '10/2020 - Fran i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento_Cat1", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento_Cat2() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento_Cat2", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento_Cat3() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento_Cat3", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento_Cat4() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento_Cat4", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresPagamento_CatTodas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresPagamento_CatTodas", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function

    Public Function getCurvaAbcProdutoresAnalises() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresAnalises", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function    '07/12/2016 - Mirella f
    Public Function getCurvaAbcProdutoresComplience() As DataSet '19/12/2016 - Adri i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplience", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceSintetico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceSinteticoKPI() As DataSet ' adri 06/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceSinteticoKPI", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewCBTSintetico() As DataSet ' adri 13/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewCBTSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewCCSSintetico() As DataSet ' adri 13/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewCCSSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewProteinaSintetico() As DataSet ' adri 13/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewProteinaSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewGorduraSintetico() As DataSet ' adri 19/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewGorduraSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewVolumeTeorPorFaixa() As DataSet ' adri 14/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewVolumeTeorPorFaixa", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo() As DataSet ' adri 14/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo() As DataSet ' adri 14/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewVolumeTeorPorFaixaComComquali() As DataSet ' adri 18/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewVolumeTeorPorFaixaComComquali", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali() As DataSet ' adri 18/06/2017 - Curva ABC Fase 2 Overview Quality

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceVolumeTotal() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceVolumeTotal", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceVolumeTotalKPI() As DataSet  ' adri 06/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceVolumeTotalKPI", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcVolumeLeiteProdutores() As DataSet  ' adri 23/08/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcVolumeLeiteProdutores", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceVolumeTotalComplienceKPI() As DataSet  ' adri 07/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceVolumeTotalComplienceKPI", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcVolumeLeiteRejeitadoATBSintetico() As DataSet  ' adri 08/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcVolumeLeiteRejeitadoATBSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcVolumeLeiteRejeitadoATB() As DataSet  ' adri 08/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcVolumeLeiteRejeitadoATB", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcVolumeTracadoControladoSintetico() As DataSet  ' adri 08/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcVolumeTracadoControladoSintetico", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcVolumeLeiteCooperativa() As DataSet  ' adri 09/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcVolumeLeiteCooperativa", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceMediaGeo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceMediaGeo", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceMediaGeoKPI() As DataSet   ' adri 06/06/2017 - Curva ABC Fase 2 KPI Qualidade

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceMediaGeoKPI", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCurvaAbcProdutoresComplienceVolumeTotalDesprezado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCurvaAbcProdutoresComplienceVolumeTotalDesprezado", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    '19/12/2016 - Adri f

    Public Function getAnaliseEsalqByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalq", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnaliseEsalqCoopByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqCoop", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    'adri 13/06/2016 - chamado 2441 - Calcular Média MG - i
    Public Function getAnaliseEsalqMediaMG() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnaliseEsalqMediaMG", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    'adri 13/06/2016 - chamado 2441 - Calcular Média MG - f

    Public Function getAnaliseEsalqGlobalByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqGlobal", parameters, "ms_analise_esalq_global")
            Return dataSet

        End Using

    End Function

    Public Function getAnaliseEsalqRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqRomaneio", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    ' adri 06/07/2016 - chamado 2441 - Conciliacao - Trazer análises sem Romaneio - i
    Public Function getAnaliseEsalqSemRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqSemRomaneio", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnalisesEsalqCTBCCSNaoPareadas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqCTBCCSNaoPareadas", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnalisesEsalqAnalisesDuplicadas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqAnalisesDuplicadas", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnalisesEsalqConsistencias() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqConsistencias", parameters, "ms_analise_esalq_consistencias")
            Return dataSet

        End Using

    End Function
    Public Function getAnalisesEsalqSelecionadas() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getAnalisesEsalqSelecionadas", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    ' adri 06/07/2016 - chamado 2441 - Conciliacao - Trazer análises sem Romaneio - f

    Public Function getAnaliseEsalqImportadaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqImportada", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnaliseEsalqCoopImportadaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqCoopImportada", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnaliseEsalqGlobalImportadaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqGlobalImportada", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getAnaliseEsalqSiloImportadaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqSiloImportada", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function

    Private Sub loadAnaliseEsalq()

        Dim dataSet As DataSet = getAnaliseEsalqByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertAnaliseEsalqCoop() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalqCoop", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertAnaliseEsalq() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalq", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    ' Adri 10/06/2016 - chamado 2441 - i
    Public Function insertAnaliseEsalqHeader() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalqHeader", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    ' Adri 10/06/2016 - chamado 2441 - f
    Public Function insertAnaliseEsalqGlobal() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalqGlobal", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Function insertAnaliseEsalqSilo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalqSilo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateAnaliseEsalq()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalq", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnaliseEsalqCoop()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqCoop", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnaliseEsalqGlobal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqGlobal", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateAnaliseEsalqSilo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqSilo", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' adri 04/07/2016 - chamado 2441 - Tela de conciliação - i
    Public Sub updateAnalisesEsalqSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqSituacaoSelecionadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqSituacaoSelecionadas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqSituacaoSelecionadasAtivar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqSituacaoSelecionadasAtivar", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqSelecaoTodas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqSelecaoTodas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqHeader()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqHeader", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqAprovarSelecionadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqAprovarSelecionadas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqNaoAprovarSelecionadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqNaoAprovarSelecionadas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAnalisesEsalqAprovacaoCancelarSelecionadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqAprovacaoCancelarSelecionadas", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' adri 04/07/2016 - chamado 2441 - Tela de conciliação - f

    Public Sub deleteAnaliseEsalq()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAnalisesEsalq", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteAnaliseEsalqGlobal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAnalisesEsalqGlobal", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteAnaliseEsalqSilo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAnalisesEsalqSilo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Function importAnaliseEsalq() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim id_linha As Int32
            Dim erro As Boolean

            Dim id_propriedade As String
            Dim id_unidade_producao As String
            Dim nr_unidade_producao As String   ' 15/09/2008
            Dim id_rota As String               ' 05/11/2008 - Código da Rota
            Dim nm_produtor As String           ' 13/11/2008
            Dim dta_coleta As String
            Dim dta_processamento As String
            Dim dta_analise As String
            Dim cd_analise As String
            Dim id_analise_arquivo As Int32                ' 12/11/2009 - Chamado 515 Maracanau
            Dim resultado As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim analiseesalqerro As New AnaliseEsalqErro    ' 13/11/2008
            Dim id_analise_esalq_erro As Int32              ' 13/11/2008 
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim tipo_analise As String
            Dim id_estabelecimento_romaneio As Int32        ' 05/11/2008 - Estabelecimento do Romaneio
            Dim id_item_romaneio As Int32                   ' 12/11/2009 - Chamado 515 Maracanau
            Dim lid_propriedade_arquivo As Integer 'fran 21/07/2016 i
            Dim lid_up_arquivo As Integer 'fran 21/07/2016 i

            Dim cdprotocolo As String 'fran 05/2021
            Dim lid_analise_esalq_protocolo As Integer 'fran 18/05/2021 i
            Dim lid_tipo_coleta_analise_esalq_protocolo As Integer = 0
            Dim lid_propriedade_matriz As Integer 'fran 18/05/2021 i
            Dim lid_item_propriedade As Integer
            Dim ldt_coleta_protocolo As String

            Dim propriedadetanque As New PropriedadeTanque
            Dim dsproptanque As DataSet
            Dim row As DataRow

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - i 
            Dim id_analise_esalq_importacao_itens As Int32
            Dim analiseesalqimportacaoitens As New AnaliseEsalqImportacaoItens
            importacao.st_tipo_importacao = 2
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo
            importacao.id_estabelecimento = Convert.ToInt32(Me.id_estabelecimento)

            id_importacao = importacao.insertImportacao()


            tipo_analise = 1
            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                '==========================================================================================================
                ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico (arquivo voltou a ser posicional) - i
                '==========================================================================================================
                'id_propriedade = Trim(Mid(linhaarquivo, 1, 5))
                'nr_unidade_producao = Trim(Mid(linhaarquivo, 6, 1))
                'id_rota = Trim(Mid(linhaarquivo, 7, 3))     ' 05/11/2008
                'nm_produtor = Trim(Mid(linhaarquivo, 10, 40))
                'dta_coleta = Trim(Mid(linhaarquivo, 50, 8))
                'dta_processamento = Trim(Mid(linhaarquivo, 58, 8))
                'dta_analise = Trim(Mid(linhaarquivo, 66, 8))
                'cd_analise = Trim(Mid(linhaarquivo, 75, 2))
                'resultado = Trim(Mid(linhaarquivo, 77, 4))

                '==========================================================================================================
                ' Fran 06/06/2016 - Acertos lay-out para qualidade  - i
                '==========================================================================================================
                id_propriedade = Trim(Mid(linhaarquivo, 1, 5))
                nr_unidade_producao = Trim(Mid(linhaarquivo, 6, 1))
                id_rota = Trim(Mid(linhaarquivo, 8, 3))     ' 05/11/2008
                nm_produtor = Trim(Mid(linhaarquivo, 11, 40))
                dta_coleta = Trim(Mid(linhaarquivo, 51, 8))
                dta_processamento = Trim(Mid(linhaarquivo, 59, 8))
                dta_analise = Trim(Mid(linhaarquivo, 67, 8))
                cd_analise = Trim(Mid(linhaarquivo, 75, 3))
                resultado = Trim(Mid(linhaarquivo, 78, 4))
                cdprotocolo = Trim(Mid(linhaarquivo, 82, 20))


                analiseesalqimportacaoitens.id_propriedade = id_propriedade
                analiseesalqimportacaoitens.id_unid_producao = nr_unidade_producao
                analiseesalqimportacaoitens.cd_rota = id_rota
                analiseesalqimportacaoitens.nm_rota = nm_produtor
                analiseesalqimportacaoitens.dt_coleta = dta_coleta
                analiseesalqimportacaoitens.dt_processamento = dta_processamento
                analiseesalqimportacaoitens.dt_analise = dta_analise
                analiseesalqimportacaoitens.cd_analise_esalq = cd_analise
                analiseesalqimportacaoitens.nr_valor_esalq = resultado
                analiseesalqimportacaoitens.id_importacao = id_importacao
                analiseesalqimportacaoitens.id_modificador = Me.id_criacao
                analiseesalqimportacaoitens.cd_protocolo = cdprotocolo 'fran 05/2021  arrastao ualidade

                id_analise_esalq_importacao_itens = analiseesalqimportacaoitens.insertAnaliseEsalqImportacaoItens()


                '=========================================
                ' Consistencias
                '=========================================
                erro = False
                lid_propriedade_arquivo = 0
                Dim propriedade As New Propriedade
                If IsNumeric(id_propriedade) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20001"
                    importacaolog.nm_erro = "Código da propriedade não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                Else
                    propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                    Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 


                        With dsPropriedade.Tables(0).Rows(0)
                            'se a propriedade é inativa pot transferencia
                            If .Item("id_situacao") = 2 AndAlso .Item("st_transferencia") = "S" Then
                                'guarda a propriedade que veio no arquivo esalq
                                lid_propriedade_arquivo = id_propriedade
                            End If

                            If IsDBNull(.Item("id_propriedade_matriz")) Then
                                lid_propriedade_matriz = 0
                            Else
                                lid_propriedade_matriz = .Item("id_propriedade_matriz")
                            End If

                        End With

                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20002"
                        importacaolog.nm_erro = "Propriedade não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log
                        analiseesalqerro.cd_protocolo = cdprotocolo

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If

                Dim unidade_producao As New UnidadeProducao
                id_unidade_producao = 0
                If IsNumeric(nr_unidade_producao) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20003"
                    importacaolog.nm_erro = "Código da un. produção não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True

                ElseIf erro = False Then 'deve verificar se tem erro antes de verificar propriedade, pois se houver erro na propriedade nao conseugue buscar UP fran 22/07/2016

                    unidade_producao.id_propriedade = Convert.ToInt32(id_propriedade)
                    unidade_producao.nr_unid_producao = Convert.ToInt32(nr_unidade_producao)

                    'se tem prop matriz e a prop matriz é diferente da propriedade que veio do arquivo, assume propriedade matriz 
                    If lid_propriedade_matriz > 0 AndAlso lid_propriedade_matriz <> CInt(id_propriedade) Then
                        unidade_producao.id_propriedade = lid_propriedade_matriz
                        unidade_producao.nr_unid_producao = 1 'assume 1 para prop matriz
                    End If

                    Dim dsUnidadeProducao As DataSet = unidade_producao.getUnidadeProducaoByFilters()

                    If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a un.produção existe 
                        id_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")

                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20004"
                        importacaolog.nm_erro = "Unidade de produção não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log
                        analiseesalqerro.cd_protocolo = cdprotocolo

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If

                    'Consiste datas

                If IsDate(dta_coleta) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20005"
                    importacaolog.nm_erro = "Data de coleta inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_processamento) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20006"
                    importacaolog.nm_erro = "Data de processamento inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_analise) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20007"
                    importacaolog.nm_erro = "Data de análise inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If


                If IsNumeric(resultado) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20010"
                    importacaolog.nm_erro = "Resultado não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    'If cd_analise = 11 Then
                    If cd_analise = 11 Or cd_analise = 8 Or cd_analise = 12 Or cd_analise = 13 Then  ' 29/11/2008
                        resultado = resultado / 100
                    Else

                        resultado = Replace(resultado, ".", ",") 'Fran DANGO 2018 ALGUMAS ANALISES VEM COM RESULTADO MENOR QUE ZERO E COM PONTO AO MULTIPLICAR IGNORA O PONTO

                        If cd_analise = 53 Then
                            resultado = resultado * 1000
                        Else
                            If cd_analise = 52 Then
                                resultado = resultado * 1000
                            Else
                                'fran 09/03/2016
                                If cd_analise = 99 Then
                                    resultado = resultado / 100
                                End If
                                'fran 09/03/2016 f

                            End If
                        End If
                    End If
                End If


                If IsNumeric(cdprotocolo) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20011"
                    importacaolog.nm_erro = "Código do protocolo não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log
                    analiseesalqerro.cd_protocolo = cdprotocolo

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                Else
                    'se o cdprotocolo nao tem 20 posicoes
                    If Len(cdprotocolo) <> 20 Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20015"
                        importacaolog.nm_erro = "Código do protocolo deve ter 20 posições."
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log
                        analiseesalqerro.cd_protocolo = cdprotocolo

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        erro = True
                    ElseIf erro = False Then 'deve verificar se tem erro acima porque precisa da PROPRIEDADE E UP

                        Dim protocolo As New AnaliseEsalqProtocolo

                        'se o cd protocolo tem os 20 caracteres, verifica se existe no milk
                        protocolo.id_estabelecimento = Me.id_estabelecimento
                        protocolo.cd_protocolo_esalq = cdprotocolo
                        'protocolo.id_propriedade = CInt(id_propriedade)
                        'protocolo.id_unid_producao = id_unid_producao
                        'protocolo.id_propriedade_matriz = lid_propriedade_matriz

                        Dim dsProtocolo As DataSet = protocolo.getAnaliseEsalqProtocoloByFilters()

                        lid_analise_esalq_protocolo = 0
                        lid_item_propriedade = 0
                        ldt_coleta_protocolo = ""

                        If (dsProtocolo.Tables(0).Rows.Count > 0) Then  '  Se ptotocolo existe 

                            With dsProtocolo.Tables(0).Rows(0)

                                'se não é prop matriz e a ropriedade/up cadastrada no protocolo não é a mesma informada no arquivo de improtacao da esalq
                                'exibe erro 20016
                                If lid_propriedade_matriz = 0 Then
                                    If Not (.Item("id_propriedade") = id_propriedade And .Item("id_unid_producao") = id_unidade_producao) Then
                                        importacaolog.nr_linha = li
                                        importacaolog.st_importacao = "2"
                                        importacaolog.cd_erro = "20016"
                                        importacaolog.nm_erro = "Código do protocolo está associado a outra Propriedade/UP (" & .Item("ds_propriedade").ToString & ")."
                                        importacaolog.id_importacao = id_importacao

                                        id_importacao_log = importacaolog.insertImportacaoLog()

                                        analiseesalqerro.id_propriedade = id_propriedade
                                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                                        analiseesalqerro.id_linha = id_rota
                                        analiseesalqerro.nm_produtor = nm_produtor
                                        analiseesalqerro.dt_coleta = dta_coleta
                                        analiseesalqerro.dt_processamento = dta_processamento
                                        analiseesalqerro.dt_analise = dta_analise
                                        analiseesalqerro.cd_analise_esalq = cd_analise
                                        analiseesalqerro.nr_valor_esalq = resultado
                                        analiseesalqerro.id_importacao_log = id_importacao_log
                                        analiseesalqerro.cd_protocolo = cdprotocolo

                                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                                        erro = True

                                    End If
                                Else
                                    If IsDBNull(.Item("id_propriedade_matriz")) = True AndAlso lid_propriedade_matriz > 0 Then
                                        importacaolog.nr_linha = li
                                        importacaolog.st_importacao = "2"
                                        importacaolog.cd_erro = "20017"
                                        importacaolog.nm_erro = "Divergencias no cadastro de Propriedade Matriz. A Matriz " & lid_propriedade_matriz.ToString & " criada recentemente."
                                        importacaolog.id_importacao = id_importacao

                                        id_importacao_log = importacaolog.insertImportacaoLog()

                                        analiseesalqerro.id_propriedade = id_propriedade
                                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                                        analiseesalqerro.id_linha = id_rota
                                        analiseesalqerro.nm_produtor = nm_produtor
                                        analiseesalqerro.dt_coleta = dta_coleta
                                        analiseesalqerro.dt_processamento = dta_processamento
                                        analiseesalqerro.dt_analise = dta_analise
                                        analiseesalqerro.cd_analise_esalq = cd_analise
                                        analiseesalqerro.nr_valor_esalq = resultado
                                        analiseesalqerro.id_importacao_log = id_importacao_log
                                        analiseesalqerro.cd_protocolo = cdprotocolo

                                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                                        erro = True


                                    Else

                                        'se é prop. matriz , e o protocolo existe em outra propriedade matriz
                                        If Not (.Item("id_propriedade_matriz") = lid_propriedade_matriz) Then
                                            importacaolog.nr_linha = li
                                            importacaolog.st_importacao = "2"
                                            importacaolog.cd_erro = "20017"
                                            importacaolog.nm_erro = "Código do protocolo está associado a outra Propriedade Matriz (" & .Item("id_propriedade_matriz").ToString & ")."
                                            importacaolog.id_importacao = id_importacao

                                            id_importacao_log = importacaolog.insertImportacaoLog()

                                            analiseesalqerro.id_propriedade = id_propriedade
                                            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                                            analiseesalqerro.id_linha = id_rota
                                            analiseesalqerro.nm_produtor = nm_produtor
                                            analiseesalqerro.dt_coleta = dta_coleta
                                            analiseesalqerro.dt_processamento = dta_processamento
                                            analiseesalqerro.dt_analise = dta_analise
                                            analiseesalqerro.cd_analise_esalq = cd_analise
                                            analiseesalqerro.nr_valor_esalq = resultado
                                            analiseesalqerro.id_importacao_log = id_importacao_log
                                            analiseesalqerro.cd_protocolo = cdprotocolo

                                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                                            erro = True

                                        End If
                                    End If
                                End If
                                If erro = False Then
                                    'se o protocolo não foi exportado para esaqlQ
                                    If .Item("st_exportacao").Equals("S") Then
                                        'guarda a propriedade que veio no arquivo esalq
                                        lid_analise_esalq_protocolo = .Item("id_analise_esalq_protocolo")
                                        lid_tipo_coleta_analise_esalq_protocolo = .Item("id_tipo_coleta_analise_esalq")
                                        lid_item_propriedade = .Item("id_item")
                                        ldt_coleta_protocolo = .Item("dt_coleta").ToString
                                        Me.id_romaneio = .Item("id_romaneio")
                                    Else

                                        importacaolog.nr_linha = li
                                        importacaolog.st_importacao = "2"
                                        importacaolog.cd_erro = "20013"
                                        importacaolog.nm_erro = "Código do protocolo não foi exportado para ESALQ pelo MILKSYSTEM."
                                        importacaolog.id_importacao = id_importacao

                                        id_importacao_log = importacaolog.insertImportacaoLog()

                                        analiseesalqerro.id_propriedade = id_propriedade
                                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                                        analiseesalqerro.id_linha = id_rota
                                        analiseesalqerro.nm_produtor = nm_produtor
                                        analiseesalqerro.dt_coleta = dta_coleta
                                        analiseesalqerro.dt_processamento = dta_processamento
                                        analiseesalqerro.dt_analise = dta_analise
                                        analiseesalqerro.cd_analise_esalq = cd_analise
                                        analiseesalqerro.nr_valor_esalq = resultado
                                        analiseesalqerro.id_importacao_log = id_importacao_log
                                        analiseesalqerro.cd_protocolo = cdprotocolo

                                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                                        erro = True
                                    End If

                                End If
                            End With

                        Else

                            'se nao tem protocolo na esalprotocolo para a propridade
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20012"
                            importacaolog.nm_erro = "Código do Protocolo não existente para o estabelecimento."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.id_propriedade = id_propriedade
                            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log
                            analiseesalqerro.cd_protocolo = cdprotocolo

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            erro = True

                        End If

                    End If
                End If

                ' 07/11/2008 - Buscar Análise na ms_analise - i 
                If erro = False Then
                    Dim cd_esalq As New CodigoEsalq
                    If IsNumeric(cd_analise) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20008"
                        importacaolog.nm_erro = "Código da análise não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log
                        analiseesalqerro.cd_protocolo = cdprotocolo

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True

                    Else
                        'cd_esalq.cd_analise_esalc = Convert.ToInt32(cd_analise)
                        'Dim dsCodigoEsalq As DataSet = cd_esalq.getCodigosEsalqByFilters

                        Dim analise As New Analise
                        analise.cd_analise = Convert.ToInt32(cd_analise)
                        analise.id_estabelecimento = Me.id_estabelecimento
                        analise.id_item = lid_item_propriedade   ' Leite in Natura

                        Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                        If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                            id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))  ' 12/11/2009 - Chamado 515 Maracanau
                            If dsCodigoEsalq.Tables(0).Rows(0).Item("id_formato_analise") <> 3 Then  ' Se não for análise lógica
                                If Convert.ToDecimal(resultado) >= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_inicial")) And Convert.ToDecimal(resultado) <= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_final")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            Else
                                If Convert.ToDecimal(resultado) = Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("id_faixa_referencia_logica")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20009"
                            importacaolog.nm_erro = "Código da Análise não cadastrado."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.id_propriedade = id_propriedade
                            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log
                            analiseesalqerro.cd_protocolo = cdprotocolo

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            erro = True
                        End If
                    End If
                End If
                ' 07/11/2008 - Buscar Análise na ms_analise - f 

                lid_up_arquivo = 0

                ''fran 20/05/2021 ARRASTAO QUALIDADE verifica transferencia apenas se nao for grupo de propriedade matriz
                If lid_propriedade_matriz = 0 Then
                    'fran 21/07/2016 i Verificar se a propriedade foi transferida
                    'se nao tem erro e a propriedadearquivo é maior que zero, significa que a propriedade foi transferida e deve verificar destino
                    lid_up_arquivo = 0
                    If erro = False AndAlso lid_propriedade_arquivo > 0 Then
                        Dim transfvolume As New TransferenciaVolume
                        transfvolume.id_propriedade = id_propriedade
                        'busca transferencia propriedade
                        Dim dstransferencia As DataSet = transfvolume.getTransferenciaPropriedadeDestino
                        'se tem linhasna transferencia
                        If dstransferencia.Tables(0).Rows.Count > 0 Then
                            'atualiza a variavel id_propriedade com a propriedade destino 
                            id_propriedade = dstransferencia.Tables(0).Rows(0).Item("id_propriedade_destino")

                            lid_up_arquivo = id_unid_producao 'guarda a up que veio da esalq

                            'busca o id da UP ativa da propriedade destino
                            unidade_producao.id_propriedade = Convert.ToInt32(id_propriedade)
                            unidade_producao.id_situacao = 1

                            Dim dsUnidadeProducao As DataSet = unidade_producao.getUnidadeProducaoByFilters()
                            If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a un.produção existe 
                                id_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")
                                nr_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("nr_unid_producao")
                            End If

                        End If
                    End If
                    'fran 21/07/2016 fi Verificar se a propriedade foi transferida
                End If
                ''fran 20/05/2021 f ARRASTAO QUALIDADE verifica transferencia apenas se nao for grupo de propriedade matriz

                'Fran 05/2021 - nao precisa mais associar ao romaneio porque a amostra ja esta associada ao coletor 
                '' 05/11/2008 - Buscar o id_romaneio - i 
                'If erro = False Then
                '    Me.id_propriedade = id_propriedade
                '    Me.nr_unid_producao = nr_unidade_producao
                '    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - i
                '    'Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                '    Me.dt_coleta_start = "01/" & DateTime.Parse(dta_coleta).ToString("MM/yyyy")
                '    Me.dt_coleta_end = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                '    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - f
                '    Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                '    If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                '        Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                '        id_estabelecimento_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_estabelecimento")
                '        id_item_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau
                '    Else
                '        'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                '        'se não encontrou romaneio pela data de coleta
                '        Me.dt_coleta_end = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                '        Dim dsEsalqRomaneio2 As DataSet = Me.getAnaliseEsalqRomaneio()
                '        If (dsEsalqRomaneio2.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                '            Me.id_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_romaneio")
                '            id_estabelecimento_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_estabelecimento")
                '            id_item_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_item")

                '            'fran 24/07/2016 f
                '        Else 'se nao encontrou romaneio nem por data de analise, envia erro

                '            'fran 24/07/2016 f
                '            ' Logar
                '            importacaolog.nr_linha = li
                '            importacaolog.st_importacao = "2"
                '            importacaolog.cd_erro = "20015"
                '            importacaolog.nm_erro = "Romaneio não encontrado ou incompleto para a Propriedade/U.Produção/Período."
                '            importacaolog.id_importacao = id_importacao

                '            id_importacao_log = importacaolog.insertImportacaoLog()

                '            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                '            analiseesalqerro.id_propriedade = id_propriedade
                '            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                '            analiseesalqerro.id_linha = id_rota
                '            analiseesalqerro.nm_produtor = nm_produtor
                '            analiseesalqerro.dt_coleta = dta_coleta
                '            analiseesalqerro.dt_processamento = dta_processamento
                '            analiseesalqerro.dt_analise = dta_analise
                '            analiseesalqerro.cd_analise_esalq = cd_analise
                '            analiseesalqerro.nr_valor_esalq = resultado
                '            analiseesalqerro.id_importacao_log = id_importacao_log

                '            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                '            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                '            ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                '            'erro = True  ' desabilitado em 13/06/2016 para gravar na tabela
                '            ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                '            'Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                '            'Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema
                '            ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i

                '            ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f
                '        End If
                '    End If
                'End If
                '' 05/11/2008 - Buscar o id_romaneio - f 

                If erro = False Then

                    If lid_propriedade_matriz > 0 AndAlso id_propriedade <> lid_propriedade_matriz Then
                        Me.id_propriedade = lid_propriedade_matriz
                    Else
                        Me.id_propriedade = id_propriedade
                    End If
                    Me.id_unid_producao = id_unidade_producao
                    Me.dt_processamento = DateTime.Parse(dta_processamento).ToString("dd/MM/yyyy")
                    Me.dt_analise = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    Me.cd_analise_esalq = cd_analise
                    Me.id_analise = id_analise_arquivo  ' 12/11/2009 - Chamado 515 Maracanau
                    Me.nr_valor_esalq = Convert.ToDecimal(resultado)
                    'Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy") 'pega data da coleta do coletor (protocolo)
                    Me.id_modificador = Me.id_criacao
                    Me.st_tipo_analise = tipo_analise
                    Me.id_situacao = 1  ' 05/11/2008 (Verifica se existe a linha ATIVA)
                    Me.id_propriedade_matriz = lid_propriedade_matriz
                    Me.id_analise_esalq_protocolo = lid_analise_esalq_protocolo
                    Me.cd_protocolo = cdprotocolo
                    Me.dt_coleta = DateTime.Parse(ldt_coleta_protocolo).ToString("dd/MM/yyyy")
                    Me.id_tipo_coleta_analise_esalq = lid_tipo_coleta_analise_esalq_protocolo

                    '==================================================================================================================
                    ' Adri -- 10/06/2016 - chamado 2441 (para ligar com a tabela ms_importacao e ms_analise_esalq_importacao_itens) - i
                    Me.id_situacao_analise_esalq = 1   ' 1-Importada
                    Me.id_aprovacao_analise_esalq = 4  ' 4-Aguardando Aprovação (Stand By)
                    Me.id_importacao = id_importacao
                    Me.nr_media_mg = 0
                    Me.nr_variacao_mg = 0

                    ' Calcula média das últimas 15 análises MG
                    If cd_analise_esalq = "8" Then  ' Se análise de MG
                        Dim dsAnaliseEsalqMG As DataSet = Me.getAnaliseEsalqMediaMG()

                        ' Salva as coletas de Proteína
                        Dim li_analise As Int16 = 0
                        Dim li_coletas As Int16 = 0
                        Dim lvalor_total_analise_esalq_mg As Decimal = 0

                        If dsAnaliseEsalqMG.Tables(0).Rows.Count > 0 Then
                            For li_analise = 0 To dsAnaliseEsalqMG.Tables(0).Rows.Count - 1
                                li_coletas = li_coletas + 1
                                lvalor_total_analise_esalq_mg = lvalor_total_analise_esalq_mg + Convert.ToDecimal(dsAnaliseEsalqMG.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                            Next
                            Me.nr_media_mg = (lvalor_total_analise_esalq_mg / li_coletas)
                            Me.nr_media_mg = Round(Me.nr_media_mg, 2)
                        Else
                            Me.nr_media_mg = 0
                        End If

                        ' Calcula a variação de mg
                        If Me.nr_media_mg > 0 Then
                            Me.nr_variacao_mg = 100 * (Me.nr_valor_esalq - Me.nr_media_mg) / Me.nr_media_mg
                            Me.nr_variacao_mg = Round(Me.nr_variacao_mg, 2)
                        Else
                            Me.nr_variacao_mg = 0
                        End If

                    End If
                    ' Adri -- 10/06/2016 - chamado 2441 (para ligar com a tabela ms_importacao e ms_analise_esalq_importacao_itens) - f
                    '==================================================================================================================
                    Dim dsanaliseesalqimportada As DataSet = Me.getAnaliseEsalqImportadaByFilters()

                    'fran 21/07/2016 i se tem propriedade na variavel a propriedade do arquivo estava inativa por transferencioa
                    If lid_propriedade_arquivo > 0 Then
                        Me.st_transferencia = "S"
                    Else
                        Me.st_transferencia = "N"
                    End If
                    'fran 21/07/2016 f

                    If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha

                        Me.id_analise_esalq = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq")
                        Me.updateAnaliseEsalq()
                        liimportada = liimportada + 1

                    Else
                        ' Gerar as tabelas
                        Me.dt_referencia = "01/" & DateTime.Parse(dta_coleta).ToString("MM/yyyy")
                        Me.insertAnaliseEsalqHeader()

                        'fran 05/2017 i
                        'se o estabelecimento é Poços, insere a header de aguas tambem
                        If Me.id_estabelecimento = 1 Then
                            Me.id_estabelecimento = 6 'Aguas da Prata
                            Me.insertAnaliseEsalqHeader()

                            Me.id_estabelecimento = 1 'retorna a variavel de estabelecimento
                        End If
                        'fran 05/2017 f

                        id_linha = Me.insertAnaliseEsalq()
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If

                    'Fran 05/2021 i retirado a inclusa dos analises de tanque pois substituimos por propriedade matriz... inclusive calculo
                    ' ''Fran - Maracanau chamado 524 01/12/2009 i
                    ''propriedadetanque.id_propriedade = Me.id_propriedade
                    ''propriedadetanque.id_unid_producao = Me.id_unid_producao
                    ''propriedadetanque.id_situacao = 1
                    ''dsproptanque = propriedadetanque.getPropriedadesParceiras
                    ''If dsproptanque.Tables(0).Rows.Count > 0 Then
                    ''    For Each row In dsproptanque.Tables(0).Rows 'para cada propriedade parceira de tanque existente

                    ''        'Buscar o id_romaneio - i 
                    ''        Me.id_propriedade = Convert.ToInt32(row.Item("id_propriedade_parceira"))
                    ''        Me.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao_parceira"))
                    ''        Me.dt_coleta_start = "01/" & DateTime.Parse(Me.dt_coleta).ToString("MM/yyyy")

                    ''        'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                    ''        ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - i
                    ''        'Me.dt_coleta_end = DateTime.Parse(Me.dt_coleta).ToString("dd/MM/yyyy")
                    ''        'Me.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_coleta_start)))
                    ''        ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - f
                    ''        Me.dt_coleta_end = DateTime.Parse(Me.dt_coleta).ToString("dd/MM/yyyy")
                    ''        'fran 24/07/2016 f
                    ''        Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                    ''        If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                    ''            Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                    ''            id_estabelecimento_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_estabelecimento")
                    ''            id_item_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau

                    ''            Dim analise As New Analise
                    ''            analise.cd_analise = Me.cd_analise_esalq
                    ''            analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                    ''            analise.id_item = id_item_romaneio
                    ''            Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                    ''            If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                    ''                id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))
                    ''            Else
                    ''                'força zero
                    ''                Me.id_romaneio = 0 'se não encontrou o cod de analise para o estabelecimento e item do romaneio não exporta a prop tanque compartilhada
                    ''            End If

                    ''        Else
                    ''            'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                    ''            'se não encontrou romaneio pela data de coleta verifica por data de analise
                    ''            Me.dt_coleta_end = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    ''            Dim dsEsalqRomaneio2 As DataSet = Me.getAnaliseEsalqRomaneio()
                    ''            If (dsEsalqRomaneio2.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                    ''                Me.id_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_romaneio")
                    ''                id_estabelecimento_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_estabelecimento")
                    ''                id_item_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_item")

                    ''                Dim analise As New Analise
                    ''                analise.cd_analise = Me.cd_analise_esalq
                    ''                analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                    ''                analise.id_item = id_item_romaneio
                    ''                Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                    ''                If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                    ''                    id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))
                    ''                Else
                    ''                    'força zero
                    ''                    Me.id_romaneio = 0 'se não encontrou o cod de analise para o estabelecimento e item do romaneio não exporta a prop tanque compartilhada
                    ''                End If

                    ''                'fran 24/07/2016 f
                    ''            Else 'se nao encontrou romaneio nem por data de analise, envia erro
                    ''                Me.id_romaneio = 0


                    ''                ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                    ''                '' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                    ''                'Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                    ''                'Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema
                    ''                '' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f
                    ''                ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                    ''            End If

                    ''        End If
                    ''        'Buscar o id_romaneio - f 

                    ''        ' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                    ''        'se tem romaneio insere a propriedade tanque compartilhada
                    ''        'If Me.id_romaneio > 0 Then
                    ''        ' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f

                    ''        Me.id_propriedade = Convert.ToInt32(row.Item("id_propriedade_parceira"))
                    ''        Me.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao_parceira"))
                    ''        dsanaliseesalqimportada = Me.getAnaliseEsalqImportadaByFilters()

                    ''        If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha
                    ''            Me.id_analise_esalq = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq")
                    ''            Me.updateAnaliseEsalq()
                    ''            liimportada = liimportada + 1
                    ''        Else
                    ''            ' Gerar as tabelas
                    ''            id_linha = Me.insertAnaliseEsalq()
                    ''            liimportada = liimportada + 1

                    ''            importacaolog.nr_linha = li
                    ''            importacaolog.st_importacao = "1"
                    ''            importacaolog.cd_erro = ""
                    ''            importacaolog.nm_erro = ""
                    ''            importacaolog.id_importacao = id_importacao
                    ''            id_importacao_log = importacaolog.insertImportacaoLog
                    ''        End If
                    ''        'End If
                    ''    Next
                    ''End If
                    ' ''Fran - Maracanau chamado 524 01/12/2009 f

                End If

            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function
    Function importAnaliseEsalqold() As Int32
        'copia da importacao esalq ate nao ter coletas de amostras no coletor, por conta de mudancas no processo como  as verificaçes por protocolo cadastrado
        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim id_linha As Int32
            Dim erro As Boolean

            Dim id_propriedade As String
            Dim id_unidade_producao As String
            Dim nr_unidade_producao As String   ' 15/09/2008
            Dim id_rota As String               ' 05/11/2008 - Código da Rota
            Dim nm_produtor As String           ' 13/11/2008
            Dim dta_coleta As String
            Dim dta_processamento As String
            Dim dta_analise As String
            Dim cd_analise As String
            Dim id_analise_arquivo As Int32                ' 12/11/2009 - Chamado 515 Maracanau
            Dim resultado As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim analiseesalqerro As New AnaliseEsalqErro    ' 13/11/2008
            Dim id_analise_esalq_erro As Int32              ' 13/11/2008 
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim tipo_analise As String
            Dim id_estabelecimento_romaneio As Int32        ' 05/11/2008 - Estabelecimento do Romaneio
            Dim id_item_romaneio As Int32                   ' 12/11/2009 - Chamado 515 Maracanau
            Dim lid_propriedade_arquivo As Integer 'fran 21/07/2016 i
            Dim lid_up_arquivo As Integer 'fran 21/07/2016 i

            'Fran - Maracanau chamado 524 01/12/2009 i
            Dim propriedadetanque As New PropriedadeTanque
            Dim dsproptanque As DataSet
            Dim row As DataRow
            'fran 27/11/2009 f maracanau chamado 523

            'Fran - Maracanau chamado 524 01/12/2009 f

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - i 
            Dim id_analise_esalq_importacao_itens As Int32
            Dim analiseesalqimportacaoitens As New AnaliseEsalqImportacaoItens
            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - f
            importacao.st_tipo_importacao = 2
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo
            'fran 27/11/2009 i maracanau chamado 523
            importacao.id_estabelecimento = Convert.ToInt32(Me.id_estabelecimento)
            'fran 27/11/2009 f maracanau chamado 523

            id_importacao = importacao.insertImportacao()


            tipo_analise = 1
            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                ' Guarda variáveis para ms_codigo_esalq

                ' 24/11/2008 - i
                'id_propriedade = Trim(Mid(linhaarquivo, 1, 5))     ' 18/11/2008
                'nr_unidade_producao = Trim(Mid(linhaarquivo, 6, 1))
                'id_rota = Trim(Mid(linhaarquivo, 7, 3))     ' 05/11/2008
                'nm_produtor = Trim(Mid(linhaarquivo, 10, 40))
                'dta_coleta = Trim(Mid(linhaarquivo, 50, 8))
                'dta_processamento = Trim(Mid(linhaarquivo, 58, 8))
                'dta_analise = Trim(Mid(linhaarquivo, 66, 8))
                'cd_analise = Trim(Mid(linhaarquivo, 75, 2))
                'resultado = Trim(Mid(linhaarquivo, 77, 4))

                ' 27/11/2008 - i
                'id_propriedade = Trim(Mid(linhaarquivo, 1, 10))     ' 18/11/2008
                'nr_unidade_producao = Trim(Mid(linhaarquivo, 11, 1))
                'id_rota = Trim(Mid(linhaarquivo, 12, 3))     ' 05/11/2008
                'nm_produtor = Trim(Mid(linhaarquivo, 15, 40))
                'dta_coleta = Trim(Mid(linhaarquivo, 55, 8))
                'dta_processamento = Trim(Mid(linhaarquivo, 63, 8))
                'dta_analise = Trim(Mid(linhaarquivo, 71, 8))
                'cd_analise = Trim(Mid(linhaarquivo, 79, 3))
                'resultado = Trim(Mid(linhaarquivo, 82, 4))


                '==========================================================================================================
                ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico (arquivo voltou a ser posicional) - i
                '==========================================================================================================
                id_propriedade = Trim(Mid(linhaarquivo, 1, 5))
                nr_unidade_producao = Trim(Mid(linhaarquivo, 6, 1))
                id_rota = Trim(Mid(linhaarquivo, 7, 3))     ' 05/11/2008
                nm_produtor = Trim(Mid(linhaarquivo, 10, 40))
                dta_coleta = Trim(Mid(linhaarquivo, 50, 8))
                dta_processamento = Trim(Mid(linhaarquivo, 58, 8))
                dta_analise = Trim(Mid(linhaarquivo, 66, 8))
                cd_analise = Trim(Mid(linhaarquivo, 75, 2))
                resultado = Trim(Mid(linhaarquivo, 77, 4))

                analiseesalqimportacaoitens.id_propriedade = id_propriedade
                analiseesalqimportacaoitens.id_unid_producao = nr_unidade_producao
                analiseesalqimportacaoitens.cd_rota = id_rota
                analiseesalqimportacaoitens.nm_rota = nm_produtor
                analiseesalqimportacaoitens.dt_coleta = dta_coleta
                analiseesalqimportacaoitens.dt_processamento = dta_processamento
                analiseesalqimportacaoitens.dt_analise = dta_analise
                analiseesalqimportacaoitens.cd_analise_esalq = cd_analise
                analiseesalqimportacaoitens.nr_valor_esalq = resultado
                analiseesalqimportacaoitens.id_importacao = id_importacao
                analiseesalqimportacaoitens.id_modificador = Me.id_criacao

                id_analise_esalq_importacao_itens = analiseesalqimportacaoitens.insertAnaliseEsalqImportacaoItens()

                '' Codigo da Propriedade
                'lpos_ini = 1
                'id_propriedade = ""
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'If lpos_fim > 0 Then
                '    id_propriedade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' Unidade de Producao
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'nr_unidade_producao = ""
                'If lpos_fim > 0 Then
                '    nr_unidade_producao = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' Rota
                'id_rota = ""
                ''lpos_ini = lpos_fim + 1
                ''lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                ''If lpos_fim > 0 Then
                ''    id_rota = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                ''End If

                '' Nome do Produtor
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'nm_produtor = ""
                'If lpos_fim > 0 Then
                '    nm_produtor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' dta_coleta
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'dta_coleta = ""
                'If lpos_fim > 0 Then
                '    dta_coleta = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' dta_processamento
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'dta_processamento = ""
                'If lpos_fim > 0 Then
                '    dta_processamento = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' dta_analise
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'dta_analise = ""
                'If lpos_fim > 0 Then
                '    dta_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' cd_analise
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'cd_analise = ""
                'If lpos_fim > 0 Then
                '    cd_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' resultado
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'resultado = ""
                'If lpos_fim > 0 Then
                '    resultado = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                'End If

                '' 27/11/2008 - f

                ' Insere dados nas tabelas ms_analise_esalq_importacao e ms_analise_esalq_importacao_itens (espelho dos arquivos importados)

                '========================================================================
                ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - f
                '========================================================================

                '=========================================
                ' Consistencias
                '=========================================
                erro = False
                lid_propriedade_arquivo = 0 'fran 21/07/2016 i
                Dim propriedade As New Propriedade
                If IsNumeric(id_propriedade) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20001"
                    importacaolog.nm_erro = "Código da propriedade não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                    Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 

                        'fran 21/07/2016 i 
                        With dsPropriedade.Tables(0).Rows(0)
                            'se a propriedade é inativa pot transferencia
                            If .Item("id_situacao") = 2 AndAlso .Item("st_transferencia") = "S" Then
                                'guarda a propriedade que veio no arquivo esalq
                                lid_propriedade_arquivo = id_propriedade
                            End If
                        End With
                        'fran 21/07/2016 f 

                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20002"
                        importacaolog.nm_erro = "Propriedade não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If

                Dim unidade_producao As New UnidadeProducao
                id_unidade_producao = 0
                If IsNumeric(nr_unidade_producao) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20003"
                    importacaolog.nm_erro = "Código da un. produção não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                ElseIf erro = False Then 'deve verificar se tem erro antes de verificar propriedade, pois se houver erro na propriedade nao conseugue buscar UP fran 22/07/2016
                    unidade_producao.id_propriedade = Convert.ToInt32(id_propriedade)
                    unidade_producao.nr_unid_producao = Convert.ToInt32(nr_unidade_producao)

                    Dim dsUnidadeProducao As DataSet = unidade_producao.getUnidadeProducaoByFilters()

                    If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a un.produção existe 
                        id_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")

                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20004"
                        importacaolog.nm_erro = "Unidade de produção não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If

                ' 05/11/2008 - COnsiste  Rota - i
                'If erro = False Then  ' Se até aqui não há erros (propriedade e unidade de produção ok)
                '    If IsNumeric(id_rota) = False Then

                '        importacaolog.nr_linha = li
                '        importacaolog.st_importacao = "2"
                '        importacaolog.cd_erro = "20012"
                '        importacaolog.nm_erro = "Código da Rota não é numérico"
                '        importacaolog.id_importacao = id_importacao

                '        id_importacao_log = importacaolog.insertImportacaoLog()

                '        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                '        analiseesalqerro.id_propriedade = id_propriedade
                '        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                '        analiseesalqerro.id_linha = id_rota
                '        analiseesalqerro.nm_produtor = nm_produtor
                '        analiseesalqerro.dt_coleta = dta_coleta
                '        analiseesalqerro.dt_processamento = dta_processamento
                '        analiseesalqerro.dt_analise = dta_analise
                '        analiseesalqerro.cd_analise_esalq = cd_analise
                '        analiseesalqerro.nr_valor_esalq = resultado
                '        analiseesalqerro.id_importacao_log = id_importacao_log

                '        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                '        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                '        erro = True
                '    Else
                '        Dim linha As New Linha
                '        linha.id_linha = Convert.ToInt32(id_rota)
                '        Dim dsLinha As DataSet = linha.getLinhaByFilters()

                '        If (dsLinha.Tables(0).Rows.Count <= 0) Then  '  Se a rota NÃO existe 
                '            importacaolog.nr_linha = li
                '            importacaolog.st_importacao = "2"
                '            importacaolog.cd_erro = "20013"
                '            importacaolog.nm_erro = "Rota não cadastrada"
                '            importacaolog.id_importacao = id_importacao

                '            id_importacao_log = importacaolog.insertImportacaoLog

                '            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                '            analiseesalqerro.id_propriedade = id_propriedade
                '            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                '            analiseesalqerro.id_linha = id_rota
                '            analiseesalqerro.nm_produtor = nm_produtor
                '            analiseesalqerro.dt_coleta = dta_coleta
                '            analiseesalqerro.dt_processamento = dta_processamento
                '            analiseesalqerro.dt_analise = dta_analise
                '            analiseesalqerro.cd_analise_esalq = cd_analise
                '            analiseesalqerro.nr_valor_esalq = resultado
                '            analiseesalqerro.id_importacao_log = id_importacao_log

                '            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                '            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                '            erro = True

                '        Else
                '            Dim linhaitem As New LinhaItens
                '            linhaitem.id_linha = Convert.ToInt32(id_rota)
                '            linhaitem.id_propriedade = Convert.ToInt32(id_propriedade)
                '            linhaitem.id_unid_producao = Convert.ToInt32(id_unidade_producao)
                '            Dim dsLinhaItem As DataSet = linhaitem.getLinhaItensByFilters()
                '            If (dsLinhaItem.Tables(0).Rows.Count > 0) Then  '  Se a propriedade/up existe para a rota

                '            Else
                '                importacaolog.nr_linha = li
                '                importacaolog.st_importacao = "2"
                '                importacaolog.cd_erro = "20014"
                '                importacaolog.nm_erro = "A Propriedade/U.Produção não está cadastrada para a Rota."
                '                importacaolog.id_importacao = id_importacao

                '                id_importacao_log = importacaolog.insertImportacaoLog

                '                ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                '                analiseesalqerro.id_propriedade = id_propriedade
                '                analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                '                analiseesalqerro.id_linha = id_rota
                '                analiseesalqerro.nm_produtor = nm_produtor
                '                analiseesalqerro.dt_coleta = dta_coleta
                '                analiseesalqerro.dt_processamento = dta_processamento
                '                analiseesalqerro.dt_analise = dta_analise
                '                analiseesalqerro.cd_analise_esalq = cd_analise
                '                analiseesalqerro.nr_valor_esalq = resultado
                '                analiseesalqerro.id_importacao_log = id_importacao_log

                '                id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                '                ' 13/11/2008 - Insere os dados para o relatório de consistência - f


                '                erro = True
                '            End If
                '        End If
                '    End If

                'End If
                '' 05/11/2008 - COnsiste  Rota - f

                'Consiste datas

                If IsDate(dta_coleta) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20005"
                    importacaolog.nm_erro = "Data de coleta inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_processamento) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20006"
                    importacaolog.nm_erro = "Data de processamento inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_analise) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20007"
                    importacaolog.nm_erro = "Data de análise inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                'fran 21/07/2016 i Fazer esta buscar por ultimo, antes de incluir na esalq, porque a propriedade pode ter sido transferida 
                ' '' 05/11/2008 - Buscar o id_romaneio - i 
                ''If erro = False Then
                ''    Me.id_propriedade = id_propriedade
                ''    Me.nr_unid_producao = nr_unidade_producao
                ''    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - i
                ''    'Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                ''    Me.dt_coleta_start = "01/" & DateTime.Parse(dta_coleta).ToString("MM/yyyy")
                ''    Me.dt_coleta_end = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                ''    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - f
                ''    Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                ''    If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                ''        Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                ''        id_estabelecimento_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_estabelecimento")
                ''        id_item_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau
                ''    Else
                ''        ' Logar
                ''        importacaolog.nr_linha = li
                ''        importacaolog.st_importacao = "2"
                ''        importacaolog.cd_erro = "20015"
                ''        importacaolog.nm_erro = "Romaneio não encontrado ou incompleto para a Propriedade/U.Produção/Período."
                ''        importacaolog.id_importacao = id_importacao

                ''        id_importacao_log = importacaolog.insertImportacaoLog()

                ''        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                ''        analiseesalqerro.id_propriedade = id_propriedade
                ''        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                ''        analiseesalqerro.id_linha = id_rota
                ''        analiseesalqerro.nm_produtor = nm_produtor
                ''        analiseesalqerro.dt_coleta = dta_coleta
                ''        analiseesalqerro.dt_processamento = dta_processamento
                ''        analiseesalqerro.dt_analise = dta_analise
                ''        analiseesalqerro.cd_analise_esalq = cd_analise
                ''        analiseesalqerro.nr_valor_esalq = resultado
                ''        analiseesalqerro.id_importacao_log = id_importacao_log

                ''        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                ''        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                ''        ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                ''        'erro = True  ' desabilitado em 13/06/2016 para gravar na tabela
                ''        ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                ''        'Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                ''        'Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema
                ''        ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i

                ''        ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f

                ''    End If
                ''End If
                ' '' 05/11/2008 - Buscar o id_romaneio - f 
                'fran 21/07/2016 f Fazer esta buscar por ultimo, antes de incluir na esalq, porque a propriedade pode ter sido transferida 

                If IsNumeric(resultado) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20010"
                    importacaolog.nm_erro = "Resultado não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_propriedade = id_propriedade
                    analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    'If cd_analise = 11 Then
                    If cd_analise = 11 Or cd_analise = 8 Or cd_analise = 12 Or cd_analise = 13 Then  ' 29/11/2008
                        resultado = resultado / 100
                    Else

                        resultado = Replace(resultado, ".", ",") 'Fran DANGO 2018 ALGUMAS ANALISES VEM COM RESULTADO MENOR QUE ZERO E COM PONTO AO MULTIPLICAR IGNORA O PONTO

                        If cd_analise = 53 Then
                            resultado = resultado * 1000
                        Else
                            If cd_analise = 52 Then
                                resultado = resultado * 1000
                            Else
                                'fran 09/03/2016
                                If cd_analise = 99 Then
                                    resultado = resultado / 100
                                End If
                                'fran 09/03/2016 f

                            End If
                        End If
                    End If
                End If


                ' 07/11/2008 - Buscar Análise na ms_analise - i 
                If erro = False Then
                    Dim cd_esalq As New CodigoEsalq
                    If IsNumeric(cd_analise) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20008"
                        importacaolog.nm_erro = "Código da análise não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_propriedade = id_propriedade
                        analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True

                    Else
                        'cd_esalq.cd_analise_esalc = Convert.ToInt32(cd_analise)
                        'Dim dsCodigoEsalq As DataSet = cd_esalq.getCodigosEsalqByFilters

                        Dim analise As New Analise
                        analise.cd_analise = Convert.ToInt32(cd_analise)
                        analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                        ' 12/11/2009 - Adri Chamado 515 - Maracanau - i
                        'analise.id_item = 1   ' Leite in Natura
                        analise.id_item = id_item_romaneio   ' Leite in Natura
                        ' 12/11/2009 - Adri Chamado 515 - Maracanau - 2
                        Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                        If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                            id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))  ' 12/11/2009 - Chamado 515 Maracanau
                            If dsCodigoEsalq.Tables(0).Rows(0).Item("id_formato_analise") <> 3 Then  ' Se não for análise lógica
                                If Convert.ToDecimal(resultado) >= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_inicial")) And Convert.ToDecimal(resultado) <= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_final")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            Else
                                If Convert.ToDecimal(resultado) = Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("id_faixa_referencia_logica")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20009"
                            importacaolog.nm_erro = "Código da Análise não cadastrado."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.id_propriedade = id_propriedade
                            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            erro = True
                        End If
                    End If
                End If
                ' 07/11/2008 - Buscar Análise na ms_analise - f 

                'fran 21/07/2016 i Verificar se a propriedade foi transferida
                'se nao tem erro e a propriedadearquivo é maior que zero, significa que a propriedade foi transferida e deve verificar destino
                lid_up_arquivo = 0
                If erro = False AndAlso lid_propriedade_arquivo > 0 Then
                    Dim transfvolume As New TransferenciaVolume
                    transfvolume.id_propriedade = id_propriedade
                    'busca transferencia propriedade
                    Dim dstransferencia As DataSet = transfvolume.getTransferenciaPropriedadeDestino
                    'se tem linhasna transferencia
                    If dstransferencia.Tables(0).Rows.Count > 0 Then
                        'atualiza a variavel id_propriedade com a propriedade destino 
                        id_propriedade = dstransferencia.Tables(0).Rows(0).Item("id_propriedade_destino")

                        lid_up_arquivo = id_unid_producao 'guarda a up que veio da esalq

                        'busca o id da UP ativa da propriedade destino
                        unidade_producao.id_propriedade = Convert.ToInt32(id_propriedade)
                        unidade_producao.id_situacao = 1

                        Dim dsUnidadeProducao As DataSet = unidade_producao.getUnidadeProducaoByFilters()
                        If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a un.produção existe 
                            id_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")
                            nr_unidade_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("nr_unid_producao")
                        End If

                    End If
                End If
                'fran 21/07/2016 fi Verificar se a propriedade foi transferida

                ' 05/11/2008 - Buscar o id_romaneio - i 
                If erro = False Then
                    Me.id_propriedade = id_propriedade
                    Me.nr_unid_producao = nr_unidade_producao
                    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - i
                    'Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    Me.dt_coleta_start = "01/" & DateTime.Parse(dta_coleta).ToString("MM/yyyy")
                    Me.dt_coleta_end = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    ' 28/11/2008 - Solicitação do Ricardo (procurar romaneio no período - f
                    Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                    If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                        Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                        id_estabelecimento_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_estabelecimento")
                        id_item_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau
                    Else
                        'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                        'se não encontrou romaneio pela data de coleta
                        Me.dt_coleta_end = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                        Dim dsEsalqRomaneio2 As DataSet = Me.getAnaliseEsalqRomaneio()
                        If (dsEsalqRomaneio2.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                            Me.id_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_romaneio")
                            id_estabelecimento_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_estabelecimento")
                            id_item_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_item")

                            'fran 24/07/2016 f
                        Else 'se nao encontrou romaneio nem por data de analise, envia erro

                            'fran 24/07/2016 f
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20015"
                            importacaolog.nm_erro = "Romaneio não encontrado ou incompleto para a Propriedade/U.Produção/Período."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.id_propriedade = id_propriedade
                            analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                            'erro = True  ' desabilitado em 13/06/2016 para gravar na tabela
                            ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                            'Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                            'Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema
                            ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i

                            ' adri 13/06/2016 - chamado 2441 - Gera log com o erro mas deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f
                        End If
                    End If
                End If
                ' 05/11/2008 - Buscar o id_romaneio - f 

                If erro = False Then

                    Me.id_propriedade = id_propriedade
                    Me.id_unid_producao = id_unidade_producao
                    Me.dt_processamento = DateTime.Parse(dta_processamento).ToString("dd/MM/yyyy")
                    Me.dt_analise = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    Me.cd_analise_esalq = cd_analise
                    Me.id_analise = id_analise_arquivo  ' 12/11/2009 - Chamado 515 Maracanau
                    Me.nr_valor_esalq = Convert.ToDecimal(resultado)
                    Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    Me.id_modificador = Me.id_criacao
                    Me.st_tipo_analise = tipo_analise
                    Me.id_situacao = 1  ' 05/11/2008 (Verifica se existe a linha ATIVA)

                    '==================================================================================================================
                    ' Adri -- 10/06/2016 - chamado 2441 (para ligar com a tabela ms_importacao e ms_analise_esalq_importacao_itens) - i
                    Me.id_situacao_analise_esalq = 1   ' 1-Importada
                    Me.id_aprovacao_analise_esalq = 4  ' 4-Aguardando Aprovação (Stand By)
                    Me.id_importacao = id_importacao
                    Me.nr_media_mg = 0
                    Me.nr_variacao_mg = 0

                    ' Calcula média das últimas 15 análises MG
                    If cd_analise_esalq = "8" Then  ' Se análise de MG
                        Dim dsAnaliseEsalqMG As DataSet = Me.getAnaliseEsalqMediaMG()

                        ' Salva as coletas de Proteína
                        Dim li_analise As Int16 = 0
                        Dim li_coletas As Int16 = 0
                        Dim lvalor_total_analise_esalq_mg As Decimal = 0

                        If dsAnaliseEsalqMG.Tables(0).Rows.Count > 0 Then
                            For li_analise = 0 To dsAnaliseEsalqMG.Tables(0).Rows.Count - 1
                                li_coletas = li_coletas + 1
                                lvalor_total_analise_esalq_mg = lvalor_total_analise_esalq_mg + Convert.ToDecimal(dsAnaliseEsalqMG.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                            Next
                            Me.nr_media_mg = (lvalor_total_analise_esalq_mg / li_coletas)
                            Me.nr_media_mg = Round(Me.nr_media_mg, 2)
                        Else
                            Me.nr_media_mg = 0
                        End If

                        ' Calcula a variação de mg
                        If Me.nr_media_mg > 0 Then
                            Me.nr_variacao_mg = 100 * (Me.nr_valor_esalq - Me.nr_media_mg) / Me.nr_media_mg
                            Me.nr_variacao_mg = Round(Me.nr_variacao_mg, 2)
                        Else
                            Me.nr_variacao_mg = 0
                        End If

                    End If
                    ' Adri -- 10/06/2016 - chamado 2441 (para ligar com a tabela ms_importacao e ms_analise_esalq_importacao_itens) - f
                    '==================================================================================================================
                    Dim dsanaliseesalqimportada As DataSet = Me.getAnaliseEsalqImportadaByFilters()

                    'fran 21/07/2016 i se tem propriedade na variavel a propriedade do arquivo estava inativa por transferencioa
                    If lid_propriedade_arquivo > 0 Then
                        Me.st_transferencia = "S"
                    Else
                        Me.st_transferencia = "N"
                    End If
                    'fran 21/07/2016 f

                    If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha
                        'importacaolog.nr_linha = li
                        'importacaolog.st_importacao = "2"
                        'importacaolog.cd_erro = "20011"
                        'importacaolog.nm_erro = "Essa linha já foi importada"
                        'importacaolog.id_importacao = id_importacao

                        'id_importacao_log = importacaolog.insertImportacaoLog()

                        '' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        'analiseesalqerro.id_propriedade = id_propriedade
                        'analiseesalqerro.nr_unidade_producao = nr_unidade_producao
                        'analiseesalqerro.id_linha = id_rota
                        'analiseesalqerro.nm_produtor = nm_produtor
                        'analiseesalqerro.dt_coleta = dta_coleta
                        'analiseesalqerro.dt_processamento = dta_processamento
                        'analiseesalqerro.dt_analise = dta_analise
                        'analiseesalqerro.cd_analise_esalq = cd_analise
                        'analiseesalqerro.nr_valor_esalq = resultado
                        'analiseesalqerro.id_importacao_log = id_importacao_log

                        'id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        '' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        ' 16/11/2008 - i
                        Me.id_analise_esalq = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq")
                        Me.updateAnaliseEsalq()
                        liimportada = liimportada + 1
                        ' 16/11/2008 - i

                    Else
                        ' Gerar as tabelas
                        ' Adri 10/06/2016 - chamado 2441 - i
                        Me.dt_referencia = "01/" & DateTime.Parse(dta_coleta).ToString("MM/yyyy")
                        Me.insertAnaliseEsalqHeader()

                        'fran 05/2017 i
                        'se o estabelecimento é Poços, insere a header de aguas tambem
                        If Me.id_estabelecimento = 1 Then
                            Me.id_estabelecimento = 6 'Aguas da Prata
                            Me.insertAnaliseEsalqHeader()

                            Me.id_estabelecimento = 1 'retorna a variavel de estabelecimento
                        End If
                        'fran 05/2017 f

                        ' Adri 10/06/2016 - chamado 2441 - f

                        id_linha = Me.insertAnaliseEsalq()
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If
                    'Fran - Maracanau chamado 524 01/12/2009 i
                    propriedadetanque.id_propriedade = Me.id_propriedade
                    propriedadetanque.id_unid_producao = Me.id_unid_producao
                    propriedadetanque.id_situacao = 1
                    dsproptanque = propriedadetanque.getPropriedadesParceiras
                    If dsproptanque.Tables(0).Rows.Count > 0 Then
                        For Each row In dsproptanque.Tables(0).Rows 'para cada propriedade parceira de tanque existente

                            'Buscar o id_romaneio - i 
                            Me.id_propriedade = Convert.ToInt32(row.Item("id_propriedade_parceira"))
                            Me.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao_parceira"))
                            Me.dt_coleta_start = "01/" & DateTime.Parse(Me.dt_coleta).ToString("MM/yyyy")

                            'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - i
                            'Me.dt_coleta_end = DateTime.Parse(Me.dt_coleta).ToString("dd/MM/yyyy")
                            'Me.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_coleta_start)))
                            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - f
                            Me.dt_coleta_end = DateTime.Parse(Me.dt_coleta).ToString("dd/MM/yyyy")
                            'fran 24/07/2016 f
                            Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                            If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                                Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                                id_estabelecimento_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_estabelecimento")
                                id_item_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau

                                Dim analise As New Analise
                                analise.cd_analise = Me.cd_analise_esalq
                                analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                                analise.id_item = id_item_romaneio
                                Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                                If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                                    id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))
                                Else
                                    'força zero
                                    Me.id_romaneio = 0 'se não encontrou o cod de analise para o estabelecimento e item do romaneio não exporta a prop tanque compartilhada
                                End If

                            Else
                                'fran 24/07/2016 i solicitação realizada pela Ana Souza por email, ocorre que algumas vezes a qualidade envia uma data de coleta para esalq provavel, mas pode ocorrer um ou dois dias depois, por isso estamos usando a data de analise
                                'se não encontrou romaneio pela data de coleta verifica por data de analise
                                Me.dt_coleta_end = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                                Dim dsEsalqRomaneio2 As DataSet = Me.getAnaliseEsalqRomaneio()
                                If (dsEsalqRomaneio2.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                                    Me.id_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_romaneio")
                                    id_estabelecimento_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_estabelecimento")
                                    id_item_romaneio = dsEsalqRomaneio2.Tables(0).Rows(0).Item("id_item")

                                    Dim analise As New Analise
                                    analise.cd_analise = Me.cd_analise_esalq
                                    analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                                    analise.id_item = id_item_romaneio
                                    Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                                    If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                                        id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))
                                    Else
                                        'força zero
                                        Me.id_romaneio = 0 'se não encontrou o cod de analise para o estabelecimento e item do romaneio não exporta a prop tanque compartilhada
                                    End If

                                    'fran 24/07/2016 f
                                Else 'se nao encontrou romaneio nem por data de analise, envia erro
                                    Me.id_romaneio = 0


                                    ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                                    '' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                                    'Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                                    'Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema
                                    '' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f
                                    ' adri 06/07/2016 - Desabilitado porque na importacao, o id_situacao_analise_esalq deve sempre estar com 1-Importada, ou seja, está aguardando  o processo de consistencia na tela de conciliacao - i
                                End If

                            End If
                            'Buscar o id_romaneio - f 

                            ' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - i
                            'se tem romaneio insere a propriedade tanque compartilhada
                            'If Me.id_romaneio > 0 Then
                            ' adri 13/06/2016 - chamado 2441 - Deixa gravar a linha sem romaneio com id_situacao_analise_esalq = 5 (Sem Romaneio) - f

                            Me.id_propriedade = Convert.ToInt32(row.Item("id_propriedade_parceira"))
                            Me.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao_parceira"))
                            dsanaliseesalqimportada = Me.getAnaliseEsalqImportadaByFilters()

                            If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha
                                Me.id_analise_esalq = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq")
                                Me.updateAnaliseEsalq()
                                liimportada = liimportada + 1
                            Else
                                ' Gerar as tabelas
                                id_linha = Me.insertAnaliseEsalq()
                                liimportada = liimportada + 1

                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "1"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = ""
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog
                            End If
                            'End If
                        Next
                    End If
                    'Fran - Maracanau chamado 524 01/12/2009 f

                End If

            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function

    Function importAnaliseEsalqCooperativa() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim id_linha As Int32
            Dim erro As Boolean

            Dim cdcooperativa As String    'cod cooperativa
            Dim id_rota As String           'rota para cooperativa mandar mes
            Dim nm_produtor As String       'a esalq esp0era 40 posicoes mas para cooperativa mandam o romaneio  e a nf e uma descricao da cooperativa 
            Dim nm_cooperativa_descr As String
            Dim nrnotafiscal As String
            Dim idromaneio As String
            Dim dta_coleta As String
            Dim dta_processamento As String
            Dim dta_analise As String
            Dim cd_analise As String
            Dim id_analise_arquivo As Int32                ' 12/11/2009 - Chamado 515 Maracanau
            Dim resultado As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim analiseesalqerro As New AnaliseEsalqErro    ' 13/11/2008
            Dim id_analise_esalq_erro As Int32              ' 13/11/2008 
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim tipo_analise As String
            Dim id_estabelecimento_romaneio As Int32        ' 05/11/2008 - Estabelecimento do Romaneio
            Dim id_item_romaneio As Int32                   ' 12/11/2009 - Chamado 515 Maracanau
            Dim lid_propriedade_arquivo As Integer 'fran 21/07/2016 i
            Dim lid_up_arquivo As Integer 'fran 21/07/2016 i

            Dim lid_cooperativa As Int32    'id_cooperativa
            Dim lnm_cooperativa As String    'nm cooperativa


            Dim row As DataRow

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - i 
            Dim id_analise_esalq_importacao_itens As Int32
            Dim analiseesalqimportacaoitens As New AnaliseEsalqImportacaoItens
            ' Adri 06/06/2016 - chamado 2441 - Acertos lay-out para cálculo geométrico - f
            importacao.st_tipo_importacao = 2
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo
            'fran 27/11/2009 i maracanau chamado 523
            importacao.id_estabelecimento = Convert.ToInt32(Me.id_estabelecimento)
            'fran 27/11/2009 f maracanau chamado 523

            id_importacao = importacao.insertImportacao()


            tipo_analise = 1
            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                ' Guarda variáveis para ms_codigo_esalq

                '==========================================================================================================
                ' Arquivo posicional
                '==========================================================================================================
                cdcooperativa = Trim(Mid(linhaarquivo, 1, 6))
                id_rota = Trim(Mid(linhaarquivo, 7, 3))     ' 05/11/2008
                nm_cooperativa_descr = Trim(Mid(linhaarquivo, 10, 7))
                idromaneio = Trim(Mid(linhaarquivo, 17, 7))
                nrnotafiscal = Trim(Mid(linhaarquivo, 24, 26))
                nm_produtor = Trim(Mid(linhaarquivo, 10, 40))
                dta_coleta = Trim(Mid(linhaarquivo, 50, 8))
                dta_processamento = Trim(Mid(linhaarquivo, 58, 8))
                dta_analise = Trim(Mid(linhaarquivo, 66, 8))
                cd_analise = Trim(Mid(linhaarquivo, 75, 2))
                resultado = Trim(Mid(linhaarquivo, 77, 4))

                analiseesalqimportacaoitens.cd_cooperativa = cdcooperativa
                analiseesalqimportacaoitens.cd_rota = id_rota
                analiseesalqimportacaoitens.nm_rota = nm_produtor
                analiseesalqimportacaoitens.dt_coleta = dta_coleta
                analiseesalqimportacaoitens.dt_processamento = dta_processamento
                analiseesalqimportacaoitens.dt_analise = dta_analise
                analiseesalqimportacaoitens.cd_analise_esalq = cd_analise
                analiseesalqimportacaoitens.nr_valor_esalq = resultado
                analiseesalqimportacaoitens.id_importacao = id_importacao
                analiseesalqimportacaoitens.id_modificador = Me.id_criacao

                id_analise_esalq_importacao_itens = analiseesalqimportacaoitens.insertAnaliseEsalqImportacaoItens()

                '=========================================
                ' Consistencias
                '=========================================
                erro = False
                lid_propriedade_arquivo = 0 'fran 21/07/2016 i
                Dim cooperativa As New Pessoa
                If IsNumeric(cdcooperativa) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20201"
                    importacaolog.nm_erro = "Código da Cooperativa não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.cd_cooperativa = cdcooperativa
                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                    analiseesalqerro.id_romaneio = idromaneio
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    cooperativa.cd_pessoa = cdcooperativa
                    Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()

                    If (dscooperativa.Tables(0).Rows.Count > 0) Then  '  Se a coopertaiva existe 

                        With dscooperativa.Tables(0).Rows(0)
                            'guarda os dados da cooperativa
                            lid_cooperativa = .Item("id_pessoa")
                            lnm_cooperativa = .Item("nm_pessoa")
                        End With
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20202"
                        importacaolog.nm_erro = "Cooperativa não cadastrada ou inativa."
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.cd_cooperativa = cdcooperativa
                        analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                        analiseesalqerro.id_romaneio = idromaneio
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If

                'Consiste datas
                If IsDate(dta_coleta) = False Then
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20205"
                    importacaolog.nm_erro = "Data de coleta inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.cd_cooperativa = cdcooperativa
                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                    analiseesalqerro.id_romaneio = idromaneio
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_processamento) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20206"
                    importacaolog.nm_erro = "Data de processamento inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.cd_cooperativa = cdcooperativa
                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                    analiseesalqerro.id_romaneio = idromaneio
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_analise) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20207"
                    importacaolog.nm_erro = "Data de análise inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.cd_cooperativa = cdcooperativa
                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                    analiseesalqerro.id_romaneio = idromaneio
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If


                If IsNumeric(resultado) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "20210"
                    importacaolog.nm_erro = "Resultado não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.cd_cooperativa = cdcooperativa
                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                    analiseesalqerro.id_romaneio = idromaneio
                    analiseesalqerro.id_linha = id_rota
                    analiseesalqerro.nm_produtor = nm_produtor
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    'If cd_analise = 11 Then
                    If cd_analise = 11 Or cd_analise = 8 Or cd_analise = 12 Or cd_analise = 13 Then  ' 29/11/2008
                        resultado = resultado / 100
                    Else

                        resultado = Replace(resultado, ".", ",") 'Fran DANGO 2018 ALGUMAS ANALISES VEM COM RESULTADO MENOR QUE ZERO E COM PONTO AO MULTIPLICAR IGNORA O PONTO

                        If cd_analise = 53 Then
                            resultado = resultado * 1000
                        Else
                            If cd_analise = 52 Then
                                resultado = resultado * 1000
                            Else
                                'fran 09/03/2016
                                If cd_analise = 99 Then
                                    resultado = resultado / 100
                                End If
                                'fran 09/03/2016 f

                            End If
                        End If
                    End If
                End If

                If erro = False Then 'verificar romaneio
                    If IsNumeric(idromaneio) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20220"
                        importacaolog.nm_erro = "Nr do Romaneio não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        analiseesalqerro.cd_cooperativa = cdcooperativa
                        analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                        analiseesalqerro.id_romaneio = idromaneio
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        erro = True
                    Else
                        Dim romaneiocoop As New Romaneio
                        romaneiocoop.id_romaneio = Convert.ToInt32(idromaneio)
                        Dim dsromaneiocoop As DataSet = romaneiocoop.getRomaneioCooperativa()

                        If (dsromaneiocoop.Tables(0).Rows.Count > 0) Then  '  Se o romaneio de coopertaiva existe 

                            With dsromaneiocoop.Tables(0).Rows(0)
                                'guarda os dados do romaneio
                                id_estabelecimento_romaneio = .Item("id_estabelecimento")
                                id_item_romaneio = .Item("id_item")
                                'se o id da cooperativa do romaneio for diferente do cadastrado exisbe msg erro
                                If CInt(.Item("id_cooperativa")) <> lid_cooperativa Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "2"
                                    importacaolog.cd_erro = "20222"
                                    importacaolog.nm_erro = "A Cooperativa do Romaneio é diferente da Cooperativa do arquivo."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    analiseesalqerro.cd_cooperativa = cdcooperativa
                                    analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                                    analiseesalqerro.id_romaneio = idromaneio
                                    analiseesalqerro.id_linha = id_rota
                                    analiseesalqerro.nm_produtor = nm_produtor
                                    analiseesalqerro.dt_coleta = dta_coleta
                                    analiseesalqerro.dt_processamento = dta_processamento
                                    analiseesalqerro.dt_analise = dta_analise
                                    analiseesalqerro.cd_analise_esalq = cd_analise
                                    analiseesalqerro.nr_valor_esalq = resultado
                                    analiseesalqerro.id_importacao_log = id_importacao_log

                                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                                    erro = True

                                End If
                            End With
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20221"
                            importacaolog.nm_erro = "Nr Romaneio não é de cooperativa ou é inexistente."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.cd_cooperativa = cdcooperativa
                            analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                            analiseesalqerro.id_romaneio = idromaneio
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            erro = True
                        End If

                    End If

                End If

                If erro = False Then
                    Dim cd_esalq As New CodigoEsalq
                    If IsNumeric(cd_analise) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20228"
                        importacaolog.nm_erro = "Código da análise não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        analiseesalqerro.cd_cooperativa = cdcooperativa
                        analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                        analiseesalqerro.id_romaneio = idromaneio
                        analiseesalqerro.id_linha = id_rota
                        analiseesalqerro.nm_produtor = nm_produtor
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        erro = True

                    Else
                        'cd_esalq.cd_analise_esalc = Convert.ToInt32(cd_analise)
                        'Dim dsCodigoEsalq As DataSet = cd_esalq.getCodigosEsalqByFilters

                        Dim analise As New Analise
                        analise.cd_analise = Convert.ToInt32(cd_analise)
                        analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                        analise.id_item = id_item_romaneio   ' Leite in Natura
                        Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                        If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                            id_analise_arquivo = Convert.ToInt32(dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise"))  ' 12/11/2009 - Chamado 515 Maracanau
                            If dsCodigoEsalq.Tables(0).Rows(0).Item("id_formato_analise") <> 3 Then  ' Se não for análise lógica
                                If Convert.ToDecimal(resultado) >= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_inicial")) And Convert.ToDecimal(resultado) <= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_final")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            Else
                                If Convert.ToDecimal(resultado) = Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("id_faixa_referencia_logica")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "20209"
                            importacaolog.nm_erro = "Código da Análise não cadastrado."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            analiseesalqerro.cd_cooperativa = cdcooperativa
                            analiseesalqerro.nr_nota_fiscal = nrnotafiscal
                            analiseesalqerro.id_romaneio = idromaneio
                            analiseesalqerro.id_linha = id_rota
                            analiseesalqerro.nm_produtor = nm_produtor
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                            erro = True
                        End If
                    End If
                End If

                If erro = False Then
                    Me.id_cooperativa = Convert.ToInt32(lid_cooperativa)
                    Me.nr_nota_fiscal = nrnotafiscal
                    Me.id_romaneio = Convert.ToInt32(idromaneio)
                    Me.dt_processamento = DateTime.Parse(dta_processamento).ToString("dd/MM/yyyy")
                    Me.dt_analise = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    Me.cd_analise_esalq = cd_analise
                    Me.id_analise = id_analise_arquivo
                    Me.nr_valor_esalq = Convert.ToDecimal(resultado)
                    Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    Me.id_modificador = Me.id_criacao
                    Me.st_tipo_analise = tipo_analise
                    Me.id_situacao = 1  ' 05/11/2008 (Verifica se existe a linha ATIVA)

                    Me.id_situacao_analise_esalq = 1   ' 1-Importada
                    Me.id_importacao = id_importacao

                    Dim dsanaliseesalqimportada As DataSet = Me.getAnaliseEsalqCoopImportadaByFilters()

                    If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha
                        Me.id_analise_esalq = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq")
                        Me.updateAnaliseEsalqCoop()
                        liimportada = liimportada + 1

                    Else
                        id_linha = Me.insertAnaliseEsalqCoop()
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If

                End If

            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function

    Function importAnaliseEsalqGlobal() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim id_linha As Int32
            Dim erro As Boolean

            Dim id_romaneio As String
            Dim dta_coleta As String
            Dim dta_processamento As String
            Dim dta_analise As String
            Dim cd_analise As String
            Dim id_analise_arquivo As Int32                 ' 12/11/2009 - Chamado 515 Maracanau
            Dim resultado As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim analiseesalqerro As New AnaliseEsalqErro    ' 13/11/2008
            Dim id_analise_esalq_erro As Int32              ' 13/11/2008 
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim tipo_analise As String
            Dim id_estabelecimento_romaneio As Int32        ' 05/11/2008 - Estabelecimento do Romaneio
            Dim id_item_romaneio As Int32                   ' 12/11/2009 - Chamado 515 Maracanau

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            importacao.st_tipo_importacao = 2
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo
            'fran 27/11/2009 i maracanau chamado 523
            importacao.id_estabelecimento = Convert.ToInt32(Me.id_estabelecimento)
            'fran 27/11/2009 f maracanau chamado 523

            id_importacao = importacao.insertImportacao()


            tipo_analise = 1
            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                ' Guarda variáveis para ms_codigo_esalq

                ' 24/11/2008 - i
                'id_romaneio = Trim(Mid(linhaarquivo, 1, 8))   ' 18/11/2008 - Confirmar tamanho
                'dta_coleta = Trim(Mid(linhaarquivo, 9, 8))
                'dta_processamento = Trim(Mid(linhaarquivo, 17, 8))
                'dta_analise = Trim(Mid(linhaarquivo, 25, 8))
                'cd_analise = Trim(Mid(linhaarquivo, 33, 3))
                'resultado = Trim(Mid(linhaarquivo, 36, 4))

                ' 28/11/2008 - i
                'id_romaneio = Trim(Mid(linhaarquivo, 1, 10))   ' 18/11/2008 - Confirmar tamanho
                'dta_coleta = Trim(Mid(linhaarquivo, 11, 8))
                'dta_processamento = Trim(Mid(linhaarquivo, 19, 8))
                'dta_analise = Trim(Mid(linhaarquivo, 27, 8))
                'cd_analise = Trim(Mid(linhaarquivo, 35, 3))
                'resultado = Trim(Mid(linhaarquivo, 38, 4))

                ' Codigo do Romaneio
                lpos_ini = 1
                id_romaneio = ""
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    id_romaneio = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' dta_coleta
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_coleta = ""
                If lpos_fim > 0 Then
                    dta_coleta = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' dta_processamento
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_processamento = ""
                If lpos_fim > 0 Then
                    dta_processamento = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' dta_analise
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_analise = ""
                If lpos_fim > 0 Then
                    dta_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' cd_analise
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                cd_analise = ""
                If lpos_fim > 0 Then
                    cd_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' resultado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                resultado = ""
                If lpos_fim > 0 Then
                    resultado = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' 28/11/2008 - f

                '=========================================
                ' Consistencias
                '=========================================
                erro = False

                Dim romaneio As New Romaneio
                If IsNumeric(id_romaneio) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "30001"
                    importacaolog.nm_erro = "Número do Romaneio não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_romaneio = id_romaneio
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    romaneio.id_romaneio = Convert.ToInt32(id_romaneio)
                    Dim dsRomaneio As DataSet = romaneio.getRomaneioByFilters()

                    If (dsRomaneio.Tables(0).Rows.Count > 0) Then  '  Se o Romaneio existe 
                        id_estabelecimento_romaneio = dsRomaneio.Tables(0).Rows(0).Item("id_estabelecimento") ' 12/11/2009 - Chamado 515 Maracanau
                        id_item_romaneio = dsRomaneio.Tables(0).Rows(0).Item("id_item")  ' 12/11/2009 - Chamado 515 Maracanau

                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "30002"
                        importacaolog.nm_erro = "Romaneio não cadastrado"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_romaneio = id_romaneio
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True
                    End If
                End If


                'Consiste datas

                If IsDate(dta_coleta) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "30005"
                    importacaolog.nm_erro = "Data de coleta inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_romaneio = id_romaneio
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_processamento) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "30006"
                    importacaolog.nm_erro = "Data de processamento inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_romaneio = id_romaneio
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_analise) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "30007"
                    importacaolog.nm_erro = "Data de análise inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_romaneio = id_romaneio
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If


                If IsNumeric(resultado) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "30010"
                    importacaolog.nm_erro = "Resultado não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                    analiseesalqerro.id_romaneio = id_romaneio
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                Else
                    'If cd_analise = 11 Then
                    If cd_analise = 11 Or cd_analise = 8 Or cd_analise = 12 Or cd_analise = 13 Then  ' 29/11/2008
                        resultado = resultado / 100
                    Else
                        resultado = Replace(resultado, ".", ",") 'Fran DANGO 2018 ALGUMAS ANALISES VEM COM RESULTADO MENOR QUE ZERO E COM PONTO AO MULTIPLICAR IGNORA O PONTO

                        If cd_analise = 53 Then
                            resultado = resultado * 1000
                        Else
                            If cd_analise = 52 Then
                                resultado = resultado * 1000
                            End If
                        End If
                    End If
                End If


                ' 07/11/2008 - Buscar Análise na ms_analise - i 
                If erro = False Then
                    Dim cd_esalq As New CodigoEsalq
                    If IsNumeric(cd_analise) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "30008"
                        importacaolog.nm_erro = "Código da análise não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                        analiseesalqerro.id_romaneio = id_romaneio
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                        ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                        erro = True

                    Else

                        Dim analise As New Analise
                        analise.cd_analise = Convert.ToInt32(cd_analise)
                        analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento_romaneio)
                        'analise.id_item = 1   ' Leite in Natura
                        analise.id_item = id_item_romaneio   ' 12/11/2009 chamado 515 Maracanau
                        Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                        If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                            id_analise_arquivo = dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise")  ' 12/11/2009 chamado 515 Maracanau
                            If dsCodigoEsalq.Tables(0).Rows(0).Item("id_formato_analise") <> 3 Then  ' Se não for análise lógica
                                If Convert.ToDecimal(resultado) >= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_inicial")) And Convert.ToDecimal(resultado) <= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_final")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            Else
                                If Convert.ToDecimal(resultado) = Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("id_faixa_referencia_logica")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "30009"
                            importacaolog.nm_erro = "Código da Análise não cadastrado."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            ' 13/11/2008 - Insere os dados para o relatório de consistência - i
                            analiseesalqerro.id_romaneio = id_romaneio
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                            ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                            erro = True
                        End If
                    End If
                End If
                ' 07/11/2008 - Buscar Análise na ms_analise - f 



                If erro = False Then

                    Me.id_romaneio = id_romaneio
                    Me.dt_processamento = DateTime.Parse(dta_processamento).ToString("dd/MM/yyyy")
                    Me.dt_analise = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    Me.cd_analise_esalq = cd_analise
                    Me.id_analise = id_analise_arquivo  ' 12/11/2009 chamado 515 Maracanau
                    Me.nr_valor_esalq = Convert.ToDecimal(resultado)
                    Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    Me.id_modificador = Me.id_criacao
                    Me.st_tipo_analise = tipo_analise
                    Me.id_situacao = 1  ' 05/11/2008 (Verifica se existe a linha ATIVA)


                    Dim dsanaliseesalqimportada As DataSet = Me.getAnaliseEsalqGlobalImportadaByFilters()

                    If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha
                        'importacaolog.nr_linha = li
                        'importacaolog.st_importacao = "2"
                        'importacaolog.cd_erro = "30011"
                        'importacaolog.nm_erro = "Essa linha já foi importada"
                        'importacaolog.id_importacao = id_importacao

                        'id_importacao_log = importacaolog.insertImportacaoLog()

                        'analiseesalqerro.id_romaneio = id_romaneio
                        'analiseesalqerro.dt_coleta = dta_coleta
                        'analiseesalqerro.dt_processamento = dta_processamento
                        'analiseesalqerro.dt_analise = dta_analise
                        'analiseesalqerro.cd_analise_esalq = cd_analise
                        'analiseesalqerro.nr_valor_esalq = resultado
                        'analiseesalqerro.id_importacao_log = id_importacao_log

                        'id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        ' 16/11/2008 - i
                        Me.id_analise_esalq_global = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq_global")
                        Me.updateAnaliseEsalqGlobal()
                        liimportada = liimportada + 1
                        ' 16/11/2008 - i

                    Else
                        ' Gerar as tabelas
                        id_linha = Me.insertAnaliseEsalqGlobal()
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If

                End If
            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function
    Function importAnaliseEsalqSilo() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim id_linha As Int32
            Dim erro As Boolean

            Dim cd_estabelecimento As String
            Dim nr_silo As String
            Dim dta_coleta As String
            Dim dta_processamento As String
            Dim dta_analise As String
            Dim cd_analise As String
            Dim id_analise_arquivo As Int32                 ' 12/11/2009 - Chamado 515 Maracanau
            Dim resultado As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim analiseesalqerro As New AnaliseEsalqErro
            Dim id_analise_esalq_erro As Int32
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim tipo_analise As String
            Dim id_estabelecimento As Int32

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            importacao.st_tipo_importacao = 2
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo
            'fran 27/11/2009 i maracanau chamado 523
            importacao.id_estabelecimento = Convert.ToInt32(Me.id_estabelecimento)
            'fran 27/11/2009 f maracanau chamado 523

            id_importacao = importacao.insertImportacao()


            tipo_analise = 1
            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1



                ' Codigo do Estabelecimento
                lpos_ini = 1
                cd_estabelecimento = ""
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    cd_estabelecimento = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' Número do Silo
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                nr_silo = ""
                If lpos_fim > 0 Then
                    nr_silo = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If


                ' dta_coleta
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_coleta = ""
                If lpos_fim > 0 Then
                    dta_coleta = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' dta_processamento
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_processamento = ""
                If lpos_fim > 0 Then
                    dta_processamento = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' dta_analise
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                dta_analise = ""
                If lpos_fim > 0 Then
                    dta_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' cd_analise
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                cd_analise = ""
                If lpos_fim > 0 Then
                    cd_analise = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If

                ' resultado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                resultado = ""
                If lpos_fim > 0 Then
                    resultado = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                End If


                '=========================================
                ' Consistencias
                '=========================================
                erro = False

                Dim estabelecimento As New Estabelecimento
                estabelecimento.cd_estabelecimento = cd_estabelecimento
                id_estabelecimento = 0
                Dim dsEstabelecimento As DataSet = estabelecimento.getEstabelecimentoByFilters

                If (dsEstabelecimento.Tables(0).Rows.Count > 0) Then  '  Se o estabelecimento existe
                    id_estabelecimento = dsEstabelecimento.Tables(0).Rows(0).Item("id_estabelecimento")
                Else
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40002"
                    importacaolog.nm_erro = "Estabelecimento não cadastrado"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                End If

                Dim silo As New Silo
                nr_silo = 0
                If IsNumeric(nr_silo) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40003"
                    importacaolog.nm_erro = "Número do silo não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                Else
                    silo.id_estabelecimento = Convert.ToInt32(id_estabelecimento)
                    silo.nr_silo = Convert.ToInt32(nr_silo)

                    Dim dsSilo As DataSet = silo.getSiloByFilters()

                    If (dsSilo.Tables(0).Rows.Count > 0) Then  '  Se o silo não existe
                        id_silo = dsSilo.Tables(0).Rows(0).Item("id_silo")
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "40004"
                        importacaolog.nm_erro = "Silo não cadastrado para o Estabelecimento."
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog

                        analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                        analiseesalqerro.nr_silo = nr_silo
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        erro = True
                    End If
                End If


                'Consiste datas

                If IsDate(dta_coleta) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40005"
                    importacaolog.nm_erro = "Data de coleta inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()
                    ' 13/11/2008 - Insere os dados para o relatório de consistência - f

                    erro = True
                End If

                If IsDate(dta_processamento) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40006"
                    importacaolog.nm_erro = "Data de processamento inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                End If

                If IsDate(dta_analise) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40007"
                    importacaolog.nm_erro = "Data de análise inválida."
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                End If

                If IsNumeric(resultado) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "40010"
                    importacaolog.nm_erro = "Resultado não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                    analiseesalqerro.nr_silo = nr_silo
                    analiseesalqerro.dt_coleta = dta_coleta
                    analiseesalqerro.dt_processamento = dta_processamento
                    analiseesalqerro.dt_analise = dta_analise
                    analiseesalqerro.cd_analise_esalq = cd_analise
                    analiseesalqerro.nr_valor_esalq = resultado
                    analiseesalqerro.id_importacao_log = id_importacao_log

                    id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                    erro = True
                Else
                    'If cd_analise = 11 Then
                    If cd_analise = 11 Or cd_analise = 8 Or cd_analise = 12 Or cd_analise = 13 Then  ' 29/11/2008
                        resultado = resultado / 100
                    Else
                        If cd_analise = 53 Then
                            resultado = resultado * 1000
                        Else
                            If cd_analise = 52 Then
                                resultado = resultado * 1000
                            End If
                        End If
                    End If
                End If


                ' 07/11/2008 - Buscar Análise na ms_analise - i 
                If erro = False Then
                    Dim cd_esalq As New CodigoEsalq
                    If IsNumeric(cd_analise) = False Then

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "40008"
                        importacaolog.nm_erro = "Código da análise não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                        analiseesalqerro.nr_silo = nr_silo
                        analiseesalqerro.dt_coleta = dta_coleta
                        analiseesalqerro.dt_processamento = dta_processamento
                        analiseesalqerro.dt_analise = dta_analise
                        analiseesalqerro.cd_analise_esalq = cd_analise
                        analiseesalqerro.nr_valor_esalq = resultado
                        analiseesalqerro.id_importacao_log = id_importacao_log

                        id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                        erro = True

                    Else

                        Dim analise As New Analise
                        analise.cd_analise = Convert.ToInt32(cd_analise)
                        analise.id_estabelecimento = Convert.ToInt32(id_estabelecimento)
                        analise.id_item = 1   ' Leite in Natura
                        Dim dsCodigoEsalq As DataSet = analise.getAnaliseByFilters()
                        If (dsCodigoEsalq.Tables(0).Rows.Count > 0) Then  '  Se o cod analise existe 
                            id_analise_arquivo = dsCodigoEsalq.Tables(0).Rows(0).Item("id_analise") ' 12/11/2009 - chamado 515 Maracanau
                            If dsCodigoEsalq.Tables(0).Rows(0).Item("id_formato_analise") <> 3 Then  ' Se não for análise lógica
                                If Convert.ToDecimal(resultado) >= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_inicial")) And Convert.ToDecimal(resultado) <= Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("nr_faixa_final")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            Else
                                If Convert.ToDecimal(resultado) = Convert.ToDecimal(dsCodigoEsalq.Tables(0).Rows(0).Item("id_faixa_referencia_logica")) Then
                                    Me.id_resultado = 1  ' Aprovado
                                Else
                                    Me.id_resultado = 2  ' Reprovado
                                End If
                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "40009"
                            importacaolog.nm_erro = "Código da Análise não cadastrado."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog

                            analiseesalqerro.cd_estabelecimento = cd_estabelecimento
                            analiseesalqerro.nr_silo = nr_silo
                            analiseesalqerro.dt_coleta = dta_coleta
                            analiseesalqerro.dt_processamento = dta_processamento
                            analiseesalqerro.dt_analise = dta_analise
                            analiseesalqerro.cd_analise_esalq = cd_analise
                            analiseesalqerro.nr_valor_esalq = resultado
                            analiseesalqerro.id_importacao_log = id_importacao_log

                            id_analise_esalq_erro = analiseesalqerro.insertAnaliseEsalqErro()

                            erro = True
                        End If
                    End If
                End If
                ' 07/11/2008 - Buscar Análise na ms_analise - f 



                If erro = False Then

                    Me.id_estabelecimento = id_estabelecimento
                    Me.id_silo = id_silo
                    Me.dt_processamento = DateTime.Parse(dta_processamento).ToString("dd/MM/yyyy")
                    Me.dt_analise = DateTime.Parse(dta_analise).ToString("dd/MM/yyyy")
                    Me.cd_analise_esalq = cd_analise
                    Me.id_analise = id_analise_arquivo  ' 12/11/2009 chamado 515 Maracanau
                    Me.nr_valor_esalq = Convert.ToDecimal(resultado)
                    Me.dt_coleta = DateTime.Parse(dta_coleta).ToString("dd/MM/yyyy")
                    Me.id_modificador = Me.id_criacao
                    Me.st_tipo_analise = tipo_analise
                    Me.id_situacao = 1  ' 05/11/2008 (Verifica se existe a linha ATIVA)


                    Dim dsanaliseesalqimportada As DataSet = Me.getAnaliseEsalqSiloImportadaByFilters()

                    If (dsanaliseesalqimportada.Tables(0).Rows.Count > 0) Then  '  Se já existe a linha

                        Me.id_analise_esalq_silo = dsanaliseesalqimportada.Tables(0).Rows(0).Item("id_analise_esalq_silo")
                        'Me.updateAnaliseEsalq()
                        Me.updateAnaliseEsalqSilo()   ' 12/11/2009 - Criar esta procedure
                        liimportada = liimportada + 1

                    Else
                        ' Gerar as tabelas
                        id_linha = Me.insertAnaliseEsalqSilo()
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If

                End If
            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function

    ' adri chamado 2441 - Conciliação das Análises Esalq - i
    Public Sub ConsistirAnalises()

        '====================================================================
        ' Obtem Parâmetro do Percentual de Variação MG para o Estabelecimento
        '====================================================================
        Dim estabelecimento As New Estabelecimento
        estabelecimento.id_estabelecimento = Me.id_estabelecimento
        Dim dsEstabelecimento As DataSet
        dsEstabelecimento = estabelecimento.getEstabelecimentoByFilters()
        Dim lPercentual_VariacaoMG As Decimal = 0
        If dsEstabelecimento.Tables(0).Rows.Count > 0 Then
            lPercentual_VariacaoMG = dsEstabelecimento.Tables(0).Rows(0).Item("nr_analiseesalq_percvariacaoMG")
        End If

        Dim dsAnaliseSemRomaneio As DataSet
        dsAnaliseSemRomaneio = Me.getAnaliseEsalqSemRomaneio()

        Dim dsAnaliseCTBCCSNaoPareadas As DataSet
        dsAnaliseCTBCCSNaoPareadas = Me.getAnalisesEsalqCTBCCSNaoPareadas()

        Dim dsAnalisesDuplicadas As DataSet
        dsAnalisesDuplicadas = Me.getAnalisesEsalqAnalisesDuplicadas()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)

        Try

            Dim param As List(Of Parameters)

            '======================================================================================================
            ' Inicializa todas as análises do Filtro como Sem Restrições e Aguardando Aprovação
            '======================================================================================================
            ' 1 Aprovado / 2 Não Aprovado / 3 Não Aprovado SISTEMA /4 Stand BY (Aguardando Aprovação) 
            Me.id_situacao_analise_esalq = 2  ' Inicializa com 2-Sem restrições (indica que passou pelas consitências e não tem restrições para ser liberada para o cálculo)
            Me.id_aprovacao_analise_esalq = 4  ' Inicializa todas as análises do Estabelecimento/Referência para 4-Aguardando Aprovação
            param = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateAnalisesEsalqSituacaoAnaliseAprovacaoTodas", param, ExecuteType.Update)  ' Atualiza colunas id_situacao_analise e id_aprovacao_analise

            transacao.Execute("ms_deleteAnalisesEsalqConsistencias", param, ExecuteType.Delete)  ' 11/07/2016 Deleta todas as linhas inseridas na tabela ms_analise_esalq_consistencias, para reiniciar consistencias


            '==========================================
            ' Verifica se existem Análises sem romaneio
            '==========================================
            Dim li As Int32

            If dsAnaliseSemRomaneio.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsAnaliseSemRomaneio.Tables(0).Rows.Count - 1

                    Me.id_analise_esalq = dsAnaliseSemRomaneio.Tables(0).Rows(li).Item("id_analise_esalq")

                    ' Verificase encontra o Romaneio referente ao período da coleta
                    Me.id_propriedade = dsAnaliseSemRomaneio.Tables(0).Rows(li).Item("id_propriedade")
                    Me.nr_unid_producao = dsAnaliseSemRomaneio.Tables(0).Rows(li).Item("nr_unid_producao")
                    Dim dsEsalqRomaneio As DataSet = Me.getAnaliseEsalqRomaneio()

                    Me.id_analise_esalq = dsAnaliseSemRomaneio.Tables(0).Rows(li).Item("id_analise_esalq")
                    If (dsEsalqRomaneio.Tables(0).Rows.Count > 0) Then  ' Se encontrou  
                        Me.id_romaneio = dsEsalqRomaneio.Tables(0).Rows(0).Item("id_romaneio")
                        param = ParametersEngine.getParametersFromObject(Me)
                        transacao.Execute("ms_updateAnalisesEsalqRomaneio", param, ExecuteType.Update)
                    Else

                        ' Se não encontrou, insere uma linha na ms_analise_esalq_consistencias, troca o id_situacao_analise_esalq para 5-Sem Romaneio, e o id_aprovacao_analise_esalq para 3-Não aprovado pelo sistema
                        Me.id_situacao_analise_esalq = 5  ' 5 - Sem Romaneio
                        Me.id_aprovacao_analise_esalq = 3 ' 3 - Não aprovado pelo Sistema

                        param = ParametersEngine.getParametersFromObject(Me)
                        transacao.Execute("ms_updateAnalisesEsalqSituacaoAnaliseAprovacao", param, ExecuteType.Update)
                        transacao.Execute("ms_insertAnalisesEsalqConsistencias", param, ExecuteType.Insert)

                    End If

                Next

            End If

            '=====================================================================================
            ' Verifica Variação MG maior que o percentual indicado no Estabelecimento
            '=====================================================================================
            Me.nr_analiseesalq_percvariacaoMG = lPercentual_VariacaoMG  ' Percentual cadastrado no Estabelecimento
            Me.id_propriedade = 0 'fran 25/07 limpar propriedade
            param = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateAnalisesEsalqVariacaoMG", param, ExecuteType.Update)

            'fran 31/07/2016 - busca as analises que foram atualizadas com situacao 4 variacao mg
            Dim dsAnaliseVariacaoMG As New DataSet
            Dim dsrow As DataRow
            transacao.Fill(dsAnaliseVariacaoMG, "ms_getAnaliseEsalqVariacaoMG", param, "ms_analise_esalq")
            'para cada propriedade com variacao mg deve ataulizar todas as analises da propriedade,up, estabelecimento e tipo coleta e sinalizar MG
            For Each dsrow In dsAnaliseVariacaoMG.Tables(0).Rows
                Me.id_propriedade = dsrow.Item("id_propriedade")
                Me.id_unid_producao = dsrow.Item("id_unid_producao")
                Me.id_tipo_coleta_analise_esalq = dsrow.Item("id_tipo_coleta_analise_esalq")

                param = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateAnalisesEsalqVariacaoMGTodas", param, ExecuteType.Update)

            Next 'proxima propriedade
            'fran 31/07/2016

            'fran 05/2017 i 
            '=====================================================================================
            ' Verifica CBT  maior que 9.999.999
            '=====================================================================================
            Me.id_propriedade = 0 'fran 25/07 limpar propriedade
            param = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateAnalisesEsalqCBTMaior", param, ExecuteType.Update)
            'fran 05/2017 f

            '===============================
            ' Verifica CBT e CSS não pareado
            '===============================
            If dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows.Count - 1
                    'fran 31/07/2016 i fazer por tipo coleta  nao por data
                    'Me.dt_coleta = dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows(li).Item("dt_coleta")
                    Me.id_tipo_coleta_analise_esalq = dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq")
                    'fran 31/07/2016 i fazer por tipo coleta  nao por data
                    Me.id_propriedade = dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows(li).Item("id_propriedade")
                    Me.id_unid_producao = dsAnaliseCTBCCSNaoPareadas.Tables(0).Rows(li).Item("id_unid_producao")
                    param = ParametersEngine.getParametersFromObject(Me)
                    transacao.Execute("ms_updateAnalisesEsalqCTBCCSNaoPareadas", param, ExecuteType.Update)  '  3 - CTB e CCS não pareadas
                Next
            End If

            '===============================
            ' Verifica análises duplicadas
            '===============================
            If dsAnalisesDuplicadas.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsAnalisesDuplicadas.Tables(0).Rows.Count - 1
                    'fran 31/07/2016 i fazer por tipo coleta  nao por data
                    'Me.dt_coleta = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("dt_coleta")
                    Me.id_tipo_coleta_analise_esalq = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq")
                    'fran 31/07/2016 f fazer por tipo coleta  nao por data
                    Me.id_propriedade = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("id_propriedade")
                    Me.id_unid_producao = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("id_unid_producao")
                    Me.cd_analise_esalq = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("cd_analise_esalq")
                    'Me.nr_valor_esalq = dsAnalisesDuplicadas.Tables(0).Rows(li).Item("nr_valor_esalq")
                    param = ParametersEngine.getParametersFromObject(Me)
                    transacao.Execute("ms_updateAnalisesEsalqDuplicadas", param, ExecuteType.Update)  ' 6 - Análises Duplicadas
                Next
            End If



            'Comita
            transacao.Commit()


        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ' adri chamado 2441 - Conciliação das Análises Esalq - f
    Public Function getGestaoCurvaAbc() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGestaoCurvaAbc", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getGestaoDadosEPLProteina() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGestaoDadosEplProteina", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getGestaoDadosEPLGordura() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGestaoDadosEplGordura", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getGestaoDadosEPLCCS() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGestaoDadosEplCCS", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    ' adri 09/10/2023 - importacao analises Clinica do Leite via WebService - i
    Public Function insertClinicaLeiteHeader() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertClinicaleiteHeader", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Function getClinicaLeiteHeaderMax() As Int32  ' 10/10/2023
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getClinicaLeiteHeaderMax", parameters, ExecuteType.Select), Int32)  ' devolve o max id_importacao

        End Using
    End Function
    Public Function getClinicaLeiteByFilters() As DataSet ' 11/10/2023

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getClinicaLeite", parameters, "ms_clinicaleite")
            Return dataSet

        End Using
    End Function
    Public Function getClinicaLeiteStatusImportacao() As DataSet ' 19/10/2023

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getClinicaLeiteStatusImportacao", parameters, "ms_clinicaleite")
            Return dataSet

        End Using
    End Function

    ' adri 09/10/2023 - importacao analises Clinica do Leite via WebService - f

End Class

