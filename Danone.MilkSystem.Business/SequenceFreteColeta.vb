Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SequenceFreteColeta

    Private _id_sequence_fretecoleta As Int32


    Public Property id_sequence_fretecoleta() As Int32
        Get
            Return _id_sequence_fretecoleta
        End Get
        Set(ByVal value As Int32)
            _id_sequence_fretecoleta = value
        End Set
    End Property

    

    Public Sub New()
    End Sub

    Public Function getSequenceFreteColeta() As Integer

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_updatesequencefretecoleta", parameters, ExecuteType.Update), Int32)

        End Using

    End Function

   
End Class
