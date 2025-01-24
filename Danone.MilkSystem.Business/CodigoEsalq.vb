Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class CodigoEsalq

    Private _cd_analise_esalq As Int32
    Private _ds_analise_esalq As String
    Private _nm_codigo_esalq As String


    Public Property cd_analise_esalc() As Int32
        Get
            Return _cd_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _cd_analise_esalq = value
        End Set
    End Property

    Public Property nm_codigo_esalq() As String
        Get
            Return _nm_codigo_esalq
        End Get
        Set(ByVal value As String)
            _nm_codigo_esalq = value
        End Set
    End Property

    Public Property ds_analise_esalq() As String
        Get
            Return _ds_analise_esalq
        End Get
        Set(ByVal value As String)
            _ds_analise_esalq = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me._cd_analise_esalq = id
        loadCodigoEsalq()

    End Sub
    Public Sub New()

    End Sub

    Public Function getCodigosEsalqByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCodigosEsalq", parameters, "ms_zanalise_esalq")
            Return dataSet

        End Using

    End Function

    Private Sub loadCodigoEsalq()

        Dim dataSet As DataSet = getCodigosEsalqByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
