Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_pagto_conciliacao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then


            ViewState.Item("txt_dt_referencia") = String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)
            If chk_indiretos.Checked = True Then
                ViewState.Item("st_pedido_indireto") = "S"
            Else
                ViewState.Item("st_pedido_indireto") = "N"

            End If
            If chk_todas_referencias.Checked = True Then
                ViewState.Item("st_todas_referencias") = "S"
            Else
                ViewState.Item("st_todas_referencias") = "N"

            End If

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pagto_conciliacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pagto_conciliacao.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 237
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            txt_dt_referencia_ini.Text = DateTime.Parse(Now).ToString("MM/yyyy")

            'Dim pedido As New Pedido

            'Dim dsPedidoSaldoAcumuladoSAP As DataSet = pedido.getCentralSaldoAcumuladoSAP()
            'If dsPedidoSaldoAcumuladoSAP.Tables(0).Rows.Count > 0 Then
            '    With dsPedidoSaldoAcumuladoSAP.Tables(0).Rows(0)
            '        txt_dt_referencia_saldoSAP.Text = .Item("dt_referencia").ToString
            '        txt_nr_saldoacumuladoSAP.Text = .Item("nr_saldoacumuladoSAP").ToString
            '    End With
            'End If

            ViewState.Item("sortExpression") = ""

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido

            gridAbertos.Visible = False

            pedido.dt_referencia = ViewState.Item("txt_dt_referencia")
            pedido.st_pedido_indireto = ViewState.Item("st_pedido_indireto")

            Dim dspedidos As DataSet = pedido.getCentralPedidoPagtosConciliacao
            If (dspedidos.Tables(0).Rows.Count > 0) Then
                gridAbertos.Visible = True
                gridAbertos.DataSource = Helper.getDataView(dspedidos.Tables(0), ViewState.Item("sortExpression"))
                gridAbertos.DataBind()
            Else
                gridAbertos.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Page.IsValid Then

            Try

                'FRAN ViewState.Item("st_tipo_visao") 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~��o
                usuariolog.id_menu_item = 237
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                ViewState.Item("txt_dt_referencia") = String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)
                If chk_indiretos.Checked = True Then
                    ViewState.Item("st_pedido_indireto") = "S"
                Else
                    ViewState.Item("st_pedido_indireto") = "N"

                End If
                If chk_todas_referencias.Checked = True Then
                    ViewState.Item("st_todas_referencias") = "S"
                Else
                    ViewState.Item("st_todas_referencias") = "N"

                End If

                loadData()

                Response.Redirect("frm_central_pagto_conciliacao_excel.aspx?dt_referencia=" + ViewState.Item("txt_dt_referencia").ToString() + "&st_pedido_indireto=" + ViewState.Item("st_pedido_indireto").ToString() + "&st_todas_referencias=" + ViewState.Item("st_todas_referencias").ToString())

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub


    Protected Sub gridAbertos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridAbertos.PageIndexChanging
        gridAbertos.PageIndex = e.NewPageIndex
        loadData()

    End Sub



End Class
