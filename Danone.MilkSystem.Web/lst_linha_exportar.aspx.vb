Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_linha_exportar

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_linha_exportar.aspx")
        If Not Page.IsPostBack Then
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 55
            usuariolog.insertUsuarioLog()

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            cbo_status.DataSource = status.getSituacoesByFilters()
            cbo_status.DataTextField = "nm_situacao"
            cbo_status.DataValueField = "id_situacao"
            cbo_status.DataBind()
            cbo_status.Items.Insert(0, New ListItem("[Selecione]", "0"))


            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try



            Dim propriedade As New Propriedade

            If Not (cbo_estabelecimento.SelectedValue.ToString.Equals("0")) Then
                propriedade.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue.ToString)
            End If
        
            If Not (cbo_status.SelectedValue.ToString.Equals("0")) Then
                propriedade.id_situacao = Convert.ToInt32(cbo_status.SelectedValue.ToString)
            End If

            Dim dspropriedadeexportar As DataSet = propriedade.getPropriedadeRotasExportarExcel
            If dspropriedadeexportar.Tables(0).Rows.Count + 1 < 65536 Then
                If dspropriedadeexportar.Tables(0).Rows.Count > 0 Then

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 55
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Response.Redirect("frm_linha_exportar.aspx?&id_estabelecimento=" + cbo_estabelecimento.SelectedValue.ToString + "&id_situacao=" + cbo_status.SelectedValue.ToString)
                Else

                    messageControl.Alert("Não há linhas a serem exportadas!")
                End If
            Else
                messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


End Class
