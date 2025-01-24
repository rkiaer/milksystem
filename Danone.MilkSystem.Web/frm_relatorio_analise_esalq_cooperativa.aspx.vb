Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_analise_esalq_cooperativa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_analise_esalq_cooperativa.aspx")
        If Not Page.IsPostBack Then

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
            Dim analiseesalqerro As New AnaliseEsalqErro
            analiseesalqerro.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = analiseesalqerro.getAnalisesEsalqErroByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

End Class
