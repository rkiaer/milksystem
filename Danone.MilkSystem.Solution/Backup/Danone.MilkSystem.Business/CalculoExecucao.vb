Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class CalculoExecucao

    Private _id_estabelecimento As Int32
    Private _id_pessoa As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _ds_propriedade As String
    Private _dt_referencia As String
    Private _st_tipo_pagamento As String
    Private _id_calculo_execucao As Int32
    Private _id_calculo_execucao_itens As Int32
    Private _st_calculo_execucao_itens As String
    Private _st_calculo_execucao As String
    Private _id_modificador As Int32
    Private _cd_erro As String
    Private _nm_erro As String

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
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

    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property


    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
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
    Public Property st_tipo_pagamento() As String
        Get
            Return _st_tipo_pagamento
        End Get
        Set(ByVal value As String)
            _st_tipo_pagamento = value
        End Set
    End Property

    Public Property id_calculo_execucao() As Int32
        Get
            Return _id_calculo_execucao
        End Get
        Set(ByVal value As Int32)
            _id_calculo_execucao = value
        End Set
    End Property
    Public Property id_calculo_execucao_itens() As Int32
        Get
            Return _id_calculo_execucao_itens
        End Get
        Set(ByVal value As Int32)
            _id_calculo_execucao_itens = value
        End Set
    End Property
    Public Property st_calculo_execucao_itens() As String
        Get
            Return _st_calculo_execucao_itens
        End Get
        Set(ByVal value As String)
            _st_calculo_execucao_itens = value
        End Set
    End Property
    Public Property st_calculo_execucao() As String
        Get
            Return _st_calculo_execucao
        End Get
        Set(ByVal value As String)
            _st_calculo_execucao = value
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
    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property
    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property

    Public Sub New(ByVal id As String)

        Me.id_calculo_execucao = id
        loadCalculoExecucao()

    End Sub
    Public Function getCalculoStatusExecucao() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoStatusExecucao", parameters, ExecuteType.Select), String)

        End Using
    End Function



    Public Sub New()

    End Sub


    Public Function getCalculoExecucaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoExecucao", parameters, "ms_calculo_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoExecucaoHistoricoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoExecucaoHistorico", parameters, "ms_calculo_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoExecucaoItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoExecucaoItens", parameters, "ms_calculo_execucao_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadCalculoExecucao()

        Dim dataSet As DataSet = getCalculoExecucaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertCalculoExecucao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCalculoExecucao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertCalculoExecucaoItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCalculoExecucaoItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateCalculoExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCalculoExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateCalculoExecucaoItens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCalculoExecucaoItens", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub insertCalculoExecucaoErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_insertCalculoExecucaoErro", parameters, ExecuteType.Update)

        End Using


    End Sub


End Class
