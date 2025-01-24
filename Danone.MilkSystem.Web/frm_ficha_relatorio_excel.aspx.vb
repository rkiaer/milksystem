Imports System.IO
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_ficha_relatorio_excel
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"

        If Not (Request("id_tecnico") Is Nothing) Then
            ViewState.Item("id_tecnico") = Request("id_tecnico")
        End If
        If Not (Request("id_pessoa") Is Nothing) Then
            ViewState.Item("id_pessoa") = Request("id_pessoa")
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If
        If Not (Request("dt_referencia_fim") Is Nothing) Then
            ViewState.Item("dt_referencia_fim") = Request("dt_referencia_fim")
        End If
        If Not (Request("dt_referencia_ini") Is Nothing) Then
            ViewState.Item("dt_referencia_ini") = Request("dt_referencia_ini")
        End If
        If Not (Request("id_estabelecimento") Is Nothing) Then
            ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
        End If
        If Not (Request("id_propriedade") Is Nothing) Then
            ViewState.Item("id_propriedade") = Request("id_propriedade")
        End If
        If Not (Request("cd_codigo_sap") Is Nothing) Then
            ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")
        End If

        Try
            Dim Ficha As New FichaFinanceira

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                Ficha.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                Ficha.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            If Not (ViewState("dt_referencia_fim").ToString().Equals(String.Empty)) Then
                Ficha.dt_referencia_ficha_end = Convert.ToString(ViewState.Item("dt_referencia_fim"))
            End If
            If Not (ViewState("dt_referencia_ini").ToString().Equals(String.Empty)) Then
                Ficha.dt_referencia_ficha_start = Convert.ToString(ViewState.Item("dt_referencia_ini"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                Ficha.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                Ficha.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                Ficha.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If

            ViewState.Item("sortExpression") = ""

            Dim dsficha As DataSet = Ficha.getFichaRelatorio()

            If (dsficha.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsficha.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If

            gridResults.AllowPaging = False

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                If gridResults.Rows.Count > 0 Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "RelatorioFicha_" & Replace(Ficha.dt_referencia_ficha_start, "/", "").ToString & "_" & Replace(Ficha.dt_referencia_ficha_end, "/", "") & ".xls")
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

                messageControl.Alert(" Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

            End If


        Catch ex As Exception

            ' messageControl.Alert(ex.Message)
        End Try
        'End If
    End Sub
End Class
