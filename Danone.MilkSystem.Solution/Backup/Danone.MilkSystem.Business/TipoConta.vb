Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TipoConta


    Private _id_tipo_conta As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_tipo_conta As String

    Public Property id_tipo_conta() As Int32
        Get
            Return _id_tipo_conta
        End Get
        Set(ByVal value As Int32)
            _id_tipo_conta = value
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

    Public Property nm_tipo_conta() As String
        Get
            Return _nm_tipo_conta
        End Get
        Set(ByVal value As String)
            _nm_tipo_conta = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me._id_tipo_conta = id
        loadTipoConta()

    End Sub


    Public Sub New()

    End Sub

    Public Function getTiposConta() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTiposConta", parameters, "ms_tipo_conta")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoConta()

        Dim dataSet As DataSet = getTiposConta()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
