Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data

Public Class ExceptionRK
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal pid_modificador As Int32, ByVal pds_id_session As String, ByVal pid_menu_item As Int32)

        MyBase.New()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = pid_modificador
            usuariolog.ds_id_session = pds_id_session.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = pid_menu_item
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            data.Execute("ms_insertUsuarioLog", parameters, ExecuteType.Insert)

        End Using


    End Sub

 

End Class
