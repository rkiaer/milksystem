Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coletor_contingencia.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 15
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_coleta") Is Nothing) Then
                ViewState.Item("dt_coleta") = Request("dt_coleta")
                ViewState.Item("cd_cnh") = Request("cd_cnh")
                ViewState.Item("ds_placa") = Request("ds_placa")
                ViewState.Item("st_tipo_rota") = Request("tipo_rota")
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
            Dim caderneta As New Caderneta

            caderneta.dt_coleta = ViewState.Item("dt_coleta")
            caderneta.cd_transportador = ViewState.Item("cd_cnh")
            caderneta.ds_placa = ViewState.Item("ds_placa")
            caderneta.dia_impar_par = ViewState.Item("st_tipo_rota")
            If ViewState.Item("ds_placa_julieta") <> "" Then
                caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
            End If

            Me.lbl_data_coleta.Text = DateTime.Parse(ViewState.Item("dt_coleta").ToString).ToString("dd/MM/yyyy")
            Me.lbl_placa.Text = ViewState.Item("ds_placa")
            Me.lbl_cnh.Text = ViewState.Item("cd_cnh")
            If ViewState.Item("st_tipo_rota") = "1" Then
                Me.lbl_tipo_rota.Text = "Ímpar"
            Else
                Me.lbl_tipo_rota.Text = "Par"
            End If

            Dim dsColetas As DataSet = caderneta.getColetasContingencia()

            If (dsColetas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsColetas.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

End Class
