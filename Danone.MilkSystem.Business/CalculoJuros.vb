Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class CalculoJuros

    Private _id_calculo_juros As Int32
    Private _dt_referencia As String
    Private _nr_valor As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _dt_modificacao As String
    Private _dt_criacao As String


    Public Property id_calculo_juros() As Int32
        Get
            Return _id_calculo_juros
        End Get
        Set(ByVal value As Int32)
            _id_calculo_juros = value
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
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_calculo_juros = id
        loadCalculoJuros()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCalculoJurosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoJuros", parameters, "ms_indicador_preco")
            Return dataSet

        End Using

    End Function

    Private Sub loadCalculoJuros()

        Dim dataSet As DataSet = getCalculoJurosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertCalculoJuros() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCalculoJuros", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

 
    Public Function getCalculoJurosMaiorReferencia() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoJurosMaiorReferencia", parameters, ExecuteType.Select), String)

        End Using

    End Function

    Public Sub deleteCalculoJuros()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCalculoJuros", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
