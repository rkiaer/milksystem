Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_analise_esalqWS
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_analise_esalqWS.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 239
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_importacao") Is Nothing) Then
                ViewState.Item("id_importacao") = Request("id_importacao")
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
            Dim analiseesalq As New AnaliseEsalq
            analiseesalq.id_importacao = ViewState.Item("id_importacao")
            Dim dsClinicaLeite As DataSet = analiseesalq.getClinicaLeiteByFilters()

            If (dsClinicaLeite.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsClinicaLeite.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If




        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

End Class
