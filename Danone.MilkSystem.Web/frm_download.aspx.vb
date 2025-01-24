
Partial Class frm_download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strRequisicao As String = Request.QueryString("arquivo")


        'se algo foi passado como parâmetro

        If strRequisicao <> "" Then

            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(strRequisicao)
            'Se o arquivo existir no servidor

            If Arquivo.Exists Then
                'define os cabeçalhos apropriados

                Response.Clear()

                Response.AddHeader("Content-Disposition", "attachment; filename=" & Arquivo.Name)

                Response.AddHeader("Content-Length", Arquivo.Length.ToString())

                Response.ContentType = "application/octet-stream"

                Response.WriteFile(Arquivo.FullName)

                Response.End()

             Else

                Response.Write("O arquivo não existe.")

            End If

        Else

            Response.Write("Informe um arquivo para download.")

        End If


    End Sub
End Class
