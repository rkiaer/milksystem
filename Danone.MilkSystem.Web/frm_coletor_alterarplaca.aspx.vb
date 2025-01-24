Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_coletor_alterarplaca
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
            'loadFilters()
            'loadData()

            If Not (Request("currentidentity") Is Nothing) Then  ' Receb o n.o da caderneta
                'loadFilters()
                ViewState.Item("currentidentity") = Request("currentidentity")
                loadData()
            End If
        End If
    End Sub



    Private Sub loadFilters()

        'Dim hasFilters As Boolean


        'If Not (customPage.getFilterValue("alterarplaca", txt_ds_placa_frete.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("ds_placa_frete") = customPage.getFilterValue("alterarplaca", txt_ds_placa_frete.ID)
        '    txt_ds_placa_frete.Text = ViewState.Item("ds_placa_frete").ToString()
        'Else
        '    ViewState.Item("ds_placa_frete") = String.Empty
        'End If


        'If (hasFilters) Then
        '    loadData()
        '    customPage.clearFilters("alterarplaca")
        'End If

    End Sub

    Private Sub loadData()

        Try

            Dim caderneta As New Caderneta()
            caderneta.currentidentity = ViewState.Item("currentidentity")

            Dim dsCaderneta As DataSet = caderneta.getCadernetaPlacaFreteContingencia()

            If Not IsDBNull(dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")) Then
                txt_ds_placa_frete.Text = dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")
            End If
            If Not IsDBNull(dsCaderneta.Tables(0).Rows(0).Item("dt_alteracao_placa_frete")) Then
                lbl_dt_alteracao_placa_frete.Text = dsCaderneta.Tables(0).Rows(0).Item("dt_alteracao_placa_frete")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_salvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If Page.IsValid Then

            'Dim js As New System.Text.StringBuilder
            'js.Append("<script>")
            'js.Append("window.onload=FechaPagina();")
            'js.Append("</script>")

            'If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
            '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
            'End If

            'Page.ClientScript.RegisterHiddenField("txtDataHidden", txt_ds_placa_frete.Text)

            Dim caderneta As New Caderneta()
            caderneta.currentidentity = ViewState.Item("currentidentity")
            caderneta.ds_placa_frete = txt_ds_placa_frete.Text
            caderneta.id_modificador = Session("id_login")


            caderneta.updateCadernetaPlacaFrete()
            loadData()

            messageControl.Alert("Placa alterada com sucesso!")
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub

    Protected Sub cmv_placa_frete_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa_frete.ServerValidate
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_ds_placa_frete.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

End Class
