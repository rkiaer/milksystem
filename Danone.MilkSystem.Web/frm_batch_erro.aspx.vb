Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_batch_erro
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim js As New System.Text.StringBuilder

        js.Append("<script>")
        js.Append(vbCrLf)
        js.Append("function FechaPagina()")
        js.Append(vbCrLf)
        js.Append("{")
        js.Append(vbCrLf)
        js.Append("window.returnValue=document.getElementById(""txtDataHidden"").value;")
        js.Append(vbCrLf)
        js.Append("window.close();")
        js.Append(vbCrLf)
        js.Append("}")
        js.Append(vbCrLf)
        js.Append("</script>")
        js.Append(vbCrLf)

        If (Not ClientScript.IsClientScriptBlockRegistered("fechar")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "fechar", js.ToString)
        End If
        customPage = MenuTools.getInitialContext(HttpContext.Current, "")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = ""
            If Not (Request("id") Is Nothing) Then
                ViewState.Item("id_exportacao_itens") = Request("id")
                loadData()
            Else
                messageControl.Alert("Problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            'Carrega os dados do Grid
            Dim batch As New ExportacaoBatch
            batch.id_exportacao_batch_itens = Convert.ToInt32(ViewState.Item("id_exportacao_itens"))

            Dim erro As DataSet = batch.getExportacaoBatchErrosByFilters

            If (erro.Tables(0).Rows.Count > 0) Then
                lbl_execucao.Text = erro.Tables(0).Rows(0).Item("id_exportacao_batch_execucao").ToString
                grderros.Visible = True
                grderros.DataSource = Helper.getDataView(erro.Tables(0), ViewState.Item("sortExpression"))
                grderros.DataBind()

            Else
                grderros.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub grderros_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grderros.PageIndexChanging
        grderros.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub grderros_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grderros.Sorting
        Select Case e.SortExpression.ToLower()



            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If


        End Select

        loadData()

    End Sub

End Class
