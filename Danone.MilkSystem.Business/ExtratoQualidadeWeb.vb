Imports System
Imports System.data
Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


Public Class ExtratoQualidadeWeb
    Private _dt_referencia As String
    Private _dt_referencia_pagto As String
    Private _dt_analise As String
    Private _id_estabelecimento As Int32
    Private _cd_pessoa As String
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32 'fran 04/08/2010
    Private _id_unid_producao As Int32
    Private _dt_referencia_start As String
    Private _dt_referencia_end As String
    Private _cd_conta As String
    Private _st_tipo_pagamento As String
    Private _st_pagamento As String
    Private _ano_referencia As String  ' 19/04/2016 (Para extrato anual)
    Private _dt_referencia_calculogeometrico_start As String 'chamado 2478 - 02/09/2016 - Mirella 
    Private _dt_referencia_calculogeometrico_end As String 'chamado 2478 - 02/09/2016 - Mirella

    Public Property dt_referencia_calculogeometrico_start() As String 'chamado 2478 - 02/09/2016 - Mirella i
        Get
            Return _dt_referencia_calculogeometrico_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_calculogeometrico_start = value
        End Set
    End Property
    Public Property dt_referencia_calculogeometrico_end() As String
        Get
            Return _dt_referencia_calculogeometrico_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_calculogeometrico_end = value
        End Set
    End Property 'chamado 2478 - 02/09/2016 - Mirella f
    Public Property dt_referencia_start() As String
        Get
            Return _dt_referencia_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_start = value
        End Set
    End Property
    Public Property dt_referencia_end() As String
        Get
            Return _dt_referencia_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_end = value
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
    Public Property dt_referencia_pagto() As String
        Get
            Return _dt_referencia_pagto
        End Get
        Set(ByVal value As String)
            _dt_referencia_pagto = value
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

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_pessoa() As Int32 'fran chamado 899
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property

    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
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
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property st_tipo_pagamento() As String
        Get
            Return _st_tipo_pagamento
        End Get
        Set(ByVal value As String)
            _st_tipo_pagamento = value
        End Set
    End Property
    Public Property st_pagamento() As String
        Get
            Return _st_pagamento
        End Get
        Set(ByVal value As String)
            _st_pagamento = value
        End Set
    End Property
    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
        End Set
    End Property
    Public Property ano_referencia() As String
        Get
            Return _ano_referencia
        End Get
        Set(ByVal value As String)
            _ano_referencia = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Function getExtratoQualidadeWebbyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidade_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    Public Function getExtratoQualidadePropriedadesWeb() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidadePropriedades_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    Public Function getExtratoQualidade_pagto_web() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidade_pagto_web", parameter, "ms_ficha_financeira")
            Return dataset
        End Using
    End Function
    Public Function getExtratoQualidade_analise_web() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidade_analise2_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    Public Function getExtratoQualidade_analise_web_calculogeometrico() As DataSet     'chamado 2478 - 02/09/2016 - Mirella i
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidade_analise2_web_calculogeometrico", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function     'chamado 2478 - 02/09/2016 - Mirella f
    Public Function getExtratoQualidade_analise_valor_web() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidade_analise2_valor_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    ' adri 17/08/2015 - Fase 4 Melhorias - Extrato Web (procedure criada para trazer contas de média de análise de MG, Prot, etc) - i
    Public Function getExtratoQualidadeValorConta()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExtratoQualidadeValorConta", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    ' adri 17/08/2015 - Fase 4 Melhorias - Extrato Web - i
    ' adri 11/12/2015 - Fase 4 Melhorias - Extrato Anual Web - i 
    Public Function getExtratoAnualPropriedadesWeb() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoAnualPropriedades_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    ' adri 11/12/2015 - Fase 4 Melhorias - Extrato Anual Web - f 

    ' adri 19/04/2016 - Fase 4 Melhorias - Extrato Anual Web - i
    Public Function getExtratoPagtoWebbyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoPagto_web", parameter, "ms_mapa_leite")
            Return dataset
        End Using
    End Function
    ' adri 19/04/2016 - Fase 4 Melhorias - Extrato Anual Web - f
    ' 06/09/2016 - Unificação das UP's - i
    Public Function getExtratoQualidadePropriedadesUnidadeProducaoWeb() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExtratoQualidadePropriedadesUnidadeProducao_Web", parameter, "ms_ficha_financeira")
            Return dataset
        End Using
    End Function
    ' 06/09/2016 - Unificação das UP's - f

End Class
