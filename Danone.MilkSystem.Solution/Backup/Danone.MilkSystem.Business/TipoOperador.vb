Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TipoOperador

    Private _id_operador As Int32
    Private _nm_tipo_operador As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

 
    Public Property id_operador() As Int32
        Get
            Return _id_operador
        End Get
        Set(ByVal value As Int32)
            _id_operador = value
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

    Public Property nm_tipo_operador() As String
        Get
            Return _nm_tipo_operador
        End Get
        Set(ByVal value As String)
            _nm_tipo_operador = value
        End Set
    End Property
  
    Public Sub New(ByVal id As Int32)

        Me.id_operador = id
        loadTipoOperador()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoOperador() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoOperador", parameters, "ms_ztipo_operador")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoOperador()

        Dim dataSet As DataSet = getTipoOperador()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
