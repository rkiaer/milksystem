Imports Microsoft.VisualBasic

Public Class Helper

    Public Shared Function getDataView(ByVal table As Data.DataTable, ByVal sortExpression As String) As Data.DataView

        Dim dv As New Data.DataView(table)
        dv.Sort = sortExpression

        Return dv

    End Function


End Class
