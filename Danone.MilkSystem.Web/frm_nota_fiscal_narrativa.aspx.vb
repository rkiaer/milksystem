Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_nota_fiscal_narrativa
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
            If Not (Request("id_item_nota") Is Nothing) Then
                loadFilters()
                ViewState.Item("id_item_nota") = Request("id_item_nota")
                loadData()
            End If
        End If
    End Sub


 
    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("narrativa", txt_narrativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_narrativa") = customPage.getFilterValue("narrativa", txt_narrativa.ID)
            txt_narrativa.Text = ViewState.Item("ds_narrativa").ToString()
        Else
            ViewState.Item("ds_narrativa") = String.Empty
        End If

 
        If (hasFilters) Then
            loadData()
            customPage.clearFilters("narrativa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim itemnotafiscal As New ItemNotaFiscal(Convert.ToInt32(ViewState.Item("id_item_nota")))

 
            'txt_narrativa.Text = ViewState.Item("ds_narrativa").ToString()
            lbl_sequencia.Text = itemnotafiscal.nr_sequencia
            lbl_item.Text = itemnotafiscal.nm_item
            txt_narrativa.Text = itemnotafiscal.ds_narrativa


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_salvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        Dim itemnotafiscal As New ItemNotaFiscal
        itemnotafiscal.id_item_nota = Convert.ToInt32(ViewState.Item("id_item_nota"))
        itemnotafiscal.ds_narrativa = Trim(txt_narrativa.Text)
        itemnotafiscal.updateItemNotaNarrativa()
        'fran 08/12/2020 i dango
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 3 'alteracao
        usuariolog.ds_nm_processo = "Nota Fiscal - Item NF - Narrativa"
        usuariolog.id_menu_item = 25
        usuariolog.insertUsuarioLog()
        'fran 08/12/2020 f dango
        messageControl.Alert("Narrativa salva com sucesso!")


        'customPage.setFilter("narrativa", "txt_narrativa", txt_narrativa.Text)

        'Dim js As New System.Text.StringBuilder
        'js.Append("<script>")
        'js.Append("window.onload=FechaPagina();")
        'js.Append("</script>")

        'If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
        'End If



    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

    End Sub
End Class
