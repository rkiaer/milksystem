Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class PoupancaMotivoBonusConcessao

    Private _id_motivo_bonus_concessao As Int32
    Private _nm_motivo_bonus_concessao As String
    Private _id_situacao As Int32

    Public Property id_motivo_bonus_concessao() As Int32
        Get
            Return _id_motivo_bonus_concessao
        End Get
        Set(ByVal value As Int32)
            _id_motivo_bonus_concessao = value
        End Set
    End Property

    Public Property nm_motivo_bonus_concessao() As String
        Get
            Return _nm_motivo_bonus_concessao
        End Get
        Set(ByVal value As String)
            _nm_motivo_bonus_concessao = value
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

    Public Sub New()

    End Sub

    Public Function getPoupancaMotivoBonusConcessao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivoBonusConcessao", parameters, "ms_zmotivo_bonus_concessao")
            Return dataSet

        End Using

    End Function


End Class
