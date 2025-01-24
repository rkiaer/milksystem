Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_usuario_log_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'BUSCA OS PARAMETROS
            If Not (Request("dt_inicio") Is Nothing) Then
                If Not (Request("dt_inicio") Is Nothing) Then
                    ViewState.Item("dt_inicio") = Request("dt_inicio")
                End If
                If Not (Request("dt_fim") Is Nothing) Then
                    ViewState.Item("dt_fim") = Request("dt_fim")
                End If
                If Not (Request("id_tipo_log") Is Nothing) Then
                    ViewState.Item("id_tipo_log") = Request("id_tipo_log")
                End If
                If Not (Request("id_menu") Is Nothing) Then
                    ViewState.Item("id_menu") = Request("id_menu")
                End If
                If Not (Request("id_menu_item") Is Nothing) Then
                    ViewState.Item("id_menu_item") = Request("id_menu_item")
                End If
                If Not (Request("ds_login") Is Nothing) Then
                    ViewState.Item("ds_login") = Request("ds_login")
                End If

                Dim usuariolog As New UsuarioLog

                usuariolog.id_tipo_log = Convert.ToInt32(ViewState.Item("id_tipo_log").ToString)
                usuariolog.id_menu = Convert.ToInt32(ViewState.Item("id_menu").ToString())
                usuariolog.id_menu_item = Convert.ToInt32(ViewState.Item("id_menu_item").ToString())
                usuariolog.ds_login = ViewState.Item("ds_login").ToString
                usuariolog.dt_inicio = ViewState.Item("dt_inicio").ToString
                usuariolog.dt_fim = ViewState.Item("dt_fim").ToString

                Dim dsusuariolog As DataSet = usuariolog.getUsuarioLogByFilters()

                If (dsusuariolog.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsusuariolog.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


                gridResults.AllowPaging = False

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_LOG" & ".xls")
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
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
