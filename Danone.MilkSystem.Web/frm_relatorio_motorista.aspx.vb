Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_motorista
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_motorista.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 48
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_hora_ini") Is Nothing) Then
                ViewState.Item("dt_hora_ini") = Request("dt_hora_ini")
                ViewState.Item("dt_hora_fim") = Request("dt_hora_fim")
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

            romaneio.data_inicio = ViewState.Item("dt_hora_ini").ToString
            romaneio.data_fim = ViewState.Item("dt_hora_fim").ToString
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString

            Me.lbl_data_ini.Text = DateTime.Parse(ViewState.Item("dt_hora_ini").ToString).ToString("dd/MM/yyyy")
            Me.lbl_data_fim.Text = DateTime.Parse(ViewState.Item("dt_hora_fim").ToString).ToString("dd/MM/yyyy")

            Dim estabelecimento As New Estabelecimento(romaneio.id_estabelecimento)
            Me.lbl_estabelecimento.Text = estabelecimento.cd_estabelecimento & " - " & estabelecimento.nm_estabelecimento

            Dim dsMotoristas As DataSet = romaneio.getRomaneioMotoristaByFilters()

            If (dsMotoristas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsMotoristas.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

 
        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

End Class
