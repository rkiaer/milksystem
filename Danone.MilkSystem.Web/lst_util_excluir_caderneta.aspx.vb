Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_excluir_caderneta


    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_excluir_caderneta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 76
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

        End If

    End Sub



    Private Sub loadData()
        If Page.IsValid Then

            Try
                Dim utilitario As New Utilitario
                Dim lmsg As String

                utilitario.nr_caderneta = Convert.ToInt32(txt_nr_caderneta.Text.Trim)
                utilitario.id_modificador = Session("id_login")

                utilitario.deleteCadernetaRomaneio()
                lmsg = "Execução da exclusão da Caderneta " + txt_nr_caderneta.Text + " realizada com sucesso!"
                messageControl.Alert(lmsg)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub


    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        If Page.IsValid Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 76
            usuariolog.id_nr_processo = txt_nr_caderneta.Text
            usuariolog.nm_nr_processo = txt_nr_caderneta.Text

            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            loadData()

        End If
    End Sub

    Protected Sub cv_caderneta_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_caderneta.ServerValidate
        Try

            Dim lmsg As String

            args.IsValid = True

            If lbl_linha.Text.Equals(String.Empty) Then

                lmsg = "A caderneta de número " + txt_nr_caderneta.Text.ToString + " não existe nos cadastros!"
                args.IsValid = False

            Else

                If Not lbl_romaneio.Text.Equals(String.Empty) Then
                    lmsg = "A caderneta de número " + txt_nr_caderneta.Text.ToString + " não pode ser excluída porque já está associada ao romaneio/pré-romaneio de número " + lbl_romaneio.Text.ToString + "."
                    args.IsValid = False
                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_nr_caderneta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_caderneta.TextChanged


        Dim caderneta As New Caderneta

        If txt_nr_caderneta.Text.Trim.Equals(String.Empty) Then
            lbl_linha.Text = String.Empty
            lbl_placa.Text = String.Empty
            lbl_transmissao.Text = String.Empty
            lbl_motorista.Text = String.Empty
            lbl_romaneio.Text = String.Empty
        Else
            caderneta.nr_caderneta = Convert.ToInt32(Me.txt_nr_caderneta.Text.Trim)
            Dim dscaderneta As DataSet = caderneta.getCadernetaHeaderByFilters()
            If dscaderneta.Tables(0).Rows.Count > 0 Then
                With dscaderneta.Tables(0).Rows(0)

                    ViewState.Item("id_romaneio") = .Item("id_romaneio").ToString()
                    If ViewState.Item("id_romaneio").ToString.Equals("0") Then
                        lbl_romaneio.Text = String.Empty
                    Else
                        lbl_romaneio.Text = ViewState.Item("id_romaneio").ToString
                    End If
                    lbl_motorista.Text = .Item("ds_motorista").ToString()
                    lbl_linha.Text = .Item("nm_linha").ToString()
                    lbl_transmissao.Text = Format(DateTime.Parse(.Item("dt_transmissao")), "dd/MM/yyyy HH:mm").ToString
                    lbl_placa.Text = .Item("ds_placa").ToString()

                End With
            Else
                lbl_linha.Text = String.Empty
                lbl_placa.Text = String.Empty
                lbl_transmissao.Text = String.Empty
                lbl_motorista.Text = String.Empty
                lbl_romaneio.Text = String.Empty

            End If
        End If

    End Sub
End Class
