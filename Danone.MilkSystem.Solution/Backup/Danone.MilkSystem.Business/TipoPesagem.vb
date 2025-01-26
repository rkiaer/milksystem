Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TipoPesagem

    Private _id_tipo_pesagem As Int32
    Private _nm_tipo_pesagem As String
 

    Public Property id_tipo_pesagem() As Int32
        Get
            Return _id_tipo_pesagem
        End Get
        Set(ByVal value As Int32)
            _id_tipo_pesagem = value
        End Set
    End Property

  
    Public Property nm_tipo_pesagem() As String
        Get
            Return _nm_tipo_pesagem
        End Get
        Set(ByVal value As String)
            _nm_tipo_pesagem = value
        End Set
    End Property
   


    Public Sub New(ByVal id As Int32)

        Me.id_tipo_pesagem = id
        loadBalanca()

    End Sub



    Public Sub New()

    End Sub


    Public Function getTipoPesagemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoPesagem", parameters, "ms_ztipopesagem")
            Return dataSet

        End Using

    End Function

    Private Sub loadBalanca()

        Dim dataSet As DataSet = getTipoPesagemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


 

End Class
