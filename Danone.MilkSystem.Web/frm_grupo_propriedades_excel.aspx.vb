Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_grupo_propriedades_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

                If (Not Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                Else
                    ViewState.Item("id_pessoa") = String.Empty
                End If

                If (Not Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                Else
                    ViewState.Item("id_propriedade") = String.Empty
                End If

                If (Not Request("id_propriedade_matriz") Is Nothing) Then
                    ViewState.Item("id_propriedade_matriz") = Request("id_propriedade_matriz")
                Else
                    ViewState.Item("id_propriedade_matriz") = String.Empty
                End If

                If (Not Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")
                Else
                    ViewState.Item("id_situacao") = String.Empty
                End If

                Dim grupo As New GrupoPropriedades

                If Not (ViewState.Item("id_propriedade_matriz").Equals(String.Empty)) Then
                    grupo.id_propriedade_matriz = Convert.ToInt32(ViewState.Item("id_propriedade_matriz").ToString)
                Else
                    grupo.id_propriedade_matriz = 0
                End If
                If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                    grupo.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                Else
                    grupo.id_propriedade = 0
                End If
                If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                    grupo.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                Else
                    grupo.id_pessoa = 0
                End If

                grupo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                grupo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

                Dim dsgrupo As DataSet = grupo.getGrupoPropriedades()

                gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), "")
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "GrupoMatrizFilial" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResults)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResults.AllowPaging = "True"
                        gridResults.DataBind()
                    Else

                        messageControl.Alert("Não há linhas a serem exportadas!")
                    End If


                Else

                    messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

End Class
