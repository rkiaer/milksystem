Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_CIQ_CIQPEmitidos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_CIQ_CIQPEmitidos.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 110
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("emitente") Is Nothing) Then
                ViewState.Item("emitente") = Request("emitente")
                ViewState.Item("dt_inicio") = Request("dt_inicio")
                ViewState.Item("dt_fim") = Request("dt_fim")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If
        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.data_inicio = ViewState.Item("dt_inicio").ToString
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                romaneio.data_fim = ViewState.Item("dt_fim").ToString
            Else
                romaneio.data_fim = ViewState("dt_inicio").ToString()
            End If

            If (ViewState.Item("emitente") = 1) Then

                Dim dsromaneio As DataSet = romaneio.getRelacaoCIQPEmitidos

                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    gridResults.Columns(4).Visible = False
                    gridResults.Columns(2).Visible = True
                    gridResults.Columns(6).Visible = True
                    gridResults.Columns(7).Visible = True
                    gridResults.Columns(8).Visible = True
                    gridResults.Columns(9).HeaderText = "Cod. Produtor"
                    gridResults.Columns(10).HeaderText = "Nome Produtor"
                    gridResults.Columns(11).Visible = True
                    gridResults.Columns(12).Visible = True
                    gridResults.Columns(13).Visible = True
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False

                    messagecontrol.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
            ElseIf (ViewState.Item("emitente") = 2) Then

                Dim dsromaneio As DataSet = romaneio.getRelacaoCIQEmitidos

                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    gridResults.Columns(2).Visible = False
                    gridResults.Columns(4).Visible = True
                    gridResults.Columns(6).Visible = False
                    gridResults.Columns(7).Visible = True
                    gridResults.Columns(8).Visible = False
                    gridResults.Columns(9).HeaderText = "Cod. Cooperativa"
                    gridResults.Columns(10).HeaderText = "Nome Cooperativa"
                    gridResults.Columns(11).Visible = False
                    gridResults.Columns(12).Visible = False
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messagecontrol.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_total_litros As Label = CType(e.Row.FindControl("lbl_nr_total_litros"), Label)
            Dim lbl_nr_litros As Label = CType(e.Row.FindControl("lbl_nr_litros"), Label)

            'If e.Row.Cells(7).Text.Equals(String.Empty) Then
            '    e.Row.Cells(7).Text = "0"
            'Else
            '    e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0).ToString
            'End If

            'If Me.ViewState.Item("emitente").ToString = "1" Then
            '    If e.Row.Cells(8).Text.Equals(String.Empty) Then
            '        e.Row.Cells(8).Text = "0"
            '    Else
            '        e.Row.Cells(8).Text = FormatNumber(e.Row.Cells(8).Text, 0).ToString
            '    End If
            'End If
            If lbl_nr_total_litros.Text.Equals(String.Empty) Then
                lbl_nr_total_litros.Text = "0"
            Else
                lbl_nr_total_litros.Text = FormatNumber(lbl_nr_total_litros.Text, 0).ToString
            End If

            If Me.ViewState.Item("emitente").ToString = "1" Then
                If lbl_nr_litros.Text.Equals(String.Empty) Then
                    lbl_nr_litros.Text = String.Empty
                Else
                    lbl_nr_litros.Text = FormatNumber(lbl_nr_litros.Text, 0).ToString
                End If
            End If

        End If
    End Sub
End Class
