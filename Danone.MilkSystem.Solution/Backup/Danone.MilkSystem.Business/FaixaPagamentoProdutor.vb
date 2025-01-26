Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FaixaPagamentoProdutor

    Private _id_faixa_pagamento_produtor As Int32
    Private _nr_faixa_inicio As Decimal
    Private _nr_valor_produtor As Decimal
    Private _nr_faixa_fim As Decimal
    Private _nr_dia_pagamento As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_criador As Int32
    Private _dt_criacao As String

    Public Property id_faixa_pagamento_produtor() As Int32
        Get
            Return _id_faixa_pagamento_produtor
        End Get
        Set(ByVal value As Int32)
            _id_faixa_pagamento_produtor = value
        End Set
    End Property

    Public Property nr_faixa_inicio() As Decimal
        Get
            Return _nr_faixa_inicio
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_inicio = value
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
    Public Property nr_valor_produtor() As Decimal
        Get
            Return _nr_valor_produtor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_produtor = value
        End Set
    End Property

    Public Property nr_dia_pagamento() As Int32
        Get
            Return _nr_dia_pagamento
        End Get
        Set(ByVal value As Int32)
            _nr_dia_pagamento = value
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


    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property
    Public Property id_criador() As Int32
        Get
            Return _id_criador
        End Get
        Set(ByVal value As Int32)
            _id_criador = value
        End Set
    End Property


    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_faixa_pagamento_produtor = id
        loadFaixaPagamentoProdutor()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFaixasPagamentosProdutorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasPagamentosProdutor", parameters, "ms_faixa_pagamento_produtor")
            Return dataSet

        End Using

    End Function

    Private Sub loadFaixaPagamentoProdutor()

        Dim dataSet As DataSet = getFaixasPagamentosProdutorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertFaixaPagamentoProdutor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFaixaPagamentoProdutor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateFaixaPagamentoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFaixaPagamentoProdutor", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteFaixaPagamentoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFaixaPagamentoProdutor", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Function getFaixaPagamentoProdutorbyValor() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFaixaPagamentoProdutorbyValor", parameters, ExecuteType.Select), Int32)

        End Using
    End Function

End Class
