Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_entrada_cooperativa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_entrada_cooperativa.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 114
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_inicio") Is Nothing) Then
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
            Dim nota As New NotaFiscal

            nota.dt_inicio = ViewState.Item("dt_inicio").ToString
            nota.dt_fim = ViewState.Item("dt_fim").ToString
            nota.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            nota.dt_referencia = String.Concat("01/", Right(ViewState.Item("dt_inicio"), 7))
            nota.dt_fim_1quinz = String.Concat("15/", Right(ViewState.Item("dt_inicio"), 7))
            nota.dt_ini_2quinz = String.Concat("16/", Right(ViewState.Item("dt_inicio"), 7))

            Me.lbl_data_ini.Text = DateTime.Parse(ViewState.Item("dt_inicio").ToString).ToString("dd/MM/yyyy")
            Me.lbl_data_fim.Text = DateTime.Parse(ViewState.Item("dt_fim").ToString).ToString("dd/MM/yyyy")

            If nota.id_estabelecimento > 0 Then
                Dim estabelecimento As New Estabelecimento(nota.id_estabelecimento)
                Me.lbl_estabelecimento.Text = estabelecimento.cd_estabelecimento & " - " & estabelecimento.nm_estabelecimento
            Else
                lbl_estabelecimento.Text = String.Empty
            End If
 
            Dim dsnota As DataSet = nota.getRelatorioEntradaCooperativa()

            If (dsnota.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                ViewState.Item("diferenca") = "0"

                gridResults.DataSource = Helper.getDataView(dsnota.Tables(0), "")
                gridResults.DataBind()
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim nr_diferenca As Decimal

            If e.Row.Cells(3).Text = "Total 1.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Total 2.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Cálculo Final" Or e.Row.Cells(3).Text = "C&#225;lculo Final" Then
                e.Row.Cells(12).Text = ViewState.Item("diferenca").ToString
                ViewState.Item("diferenca") = "0"
            End If
        End If

    End Sub
End Class
