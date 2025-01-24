Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_transit_point_amostras
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transit_point_amostras.aspx")
            If Not Page.IsPostBack Then
                loadDetails()
            Else
                If ViewState.Item("gridAmostrasTemLinhas") Is Nothing Then
                    gridAmostras.Rows(0).Cells.Clear()
                    gridAmostras.Rows(0).Cells.Add(New TableCell())
                    gridAmostras.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridAmostras.Rows(0).Cells(0).Text = "Não existe nenhuma amostra de coleta de Pré-Romaneio para ser enviada neste Transit Point."
                    gridAmostras.Rows(0).Cells(0).ColumnSpan = 22

                End If
                If ViewState.Item("gridOutrasAmostrasTemLinhas") Is Nothing Then
                    gridOutrasAmostras.Rows(0).Cells.Clear()
                    gridOutrasAmostras.Rows(0).Cells.Add(New TableCell())
                    gridOutrasAmostras.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridOutrasAmostras.Rows(0).Cells(0).Text = "Não existe nenhuma amostra de coleta de Pré-Romaneio (de outros Transit Points) pendente para ser enviada neste Transit Point."
                    gridOutrasAmostras.Rows(0).Cells(0).ColumnSpan = 23

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Private Sub loadDetails()
        Try


            If Not (Request("id_transit_point") Is Nothing) Then
                ViewState.Item("id_transit_point") = Request("id_transit_point")

                loadData()
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim transitPoint As New TransitPoint(ViewState.Item("id_transit_point"))

            lbl_id_transit_point.Text = transitPoint.id_transit_point.ToString
            lbl_nm_situacao_transit_point.Text = transitPoint.nm_situacao_transit_point.ToString
            lbl_ds_unidade_transit_point.Text = transitPoint.ds_transit_point_unidade.ToString
            lbl_ds_placa.Text = transitPoint.ds_placa.ToString
            lbl_nm_linha.Text = transitPoint.nm_linha
            lbl_nr_total_litros_transit_point.Text = transitPoint.nr_total_litros
            ViewState.Item("id_transit_point_unidade") = transitPoint.id_transit_point_unidade

            If Not lbl_nr_total_litros_transit_point.Text.Equals(String.Empty) Then
                lbl_nr_total_litros_transit_point.Text = FormatNumber(lbl_nr_total_litros_transit_point.Text, 0)
            End If

            loadGridAmostras()
            loadGridOutrasAmostras()

            If transitPoint.id_situacao_transit_point = 3 Then 'se fechado
                gridAmostras.Columns(0).Visible = False 'check
                gridOutrasAmostras.Columns(0).Visible = False 'check
                btn_enviar.Enabled = False
                btn_Descartar.Enabled = False
                btn_aguardar_prox_tp.Enabled = False
                btn_enviar_oa.Enabled = False
                btn_descartar_oa.Enabled = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridAmostras()
        Try


            Dim tp As New TransitPoint

            tp.id_transit_point = ViewState.Item("id_transit_point")

            Dim dstpamostras As DataSet = tp.getTransitPointPreRomaneioAmostras()

            'se tem linhas em compartimento
            If (dstpamostras.Tables(0).Rows.Count > 0) Then
                gridAmostras.Visible = True
                Me.btn_enviar.Visible = True
                btn_Descartar.Visible = True
                btn_aguardar_prox_tp.Visible = True
                lbl_descarte.Visible = True
                cbo_motivo_descarte.Visible = True

                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco1") = 0 Then
                    gridAmostras.Columns.Item(6).Visible = False 'frasco amarelo
                Else
                    gridAmostras.Columns.Item(6).Visible = True 'frasco amarelo
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco2") = 0 Then
                    gridAmostras.Columns.Item(7).Visible = False 'frasco azul
                Else
                    gridAmostras.Columns.Item(7).Visible = True 'frasco azul
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco3") = 0 Then
                    gridAmostras.Columns.Item(8).Visible = False 'frasco branco
                Else
                    gridAmostras.Columns.Item(8).Visible = True 'frasco branco
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco4") = 0 Then
                    gridAmostras.Columns.Item(9).Visible = False 'frasco vermelho
                Else
                    gridAmostras.Columns.Item(9).Visible = True 'frasco verelho
                End If

                gridAmostras.DataSource = Helper.getDataView(dstpamostras.Tables(0), "")
                gridAmostras.DataBind()
                ViewState.Item("gridAmostrasTemLinhas") = "S"

                Me.cbo_motivo_descarte.SelectedValue = 0

            Else
                Dim dr As DataRow = dstpamostras.Tables(0).NewRow()
                dstpamostras.Tables(0).Rows.InsertAt(dr, 0)
                gridAmostras.Visible = True
                gridAmostras.DataSource = Helper.getDataView(dstpamostras.Tables(0), "")
                gridAmostras.DataBind()
                gridAmostras.Rows(0).Cells.Clear()
                gridAmostras.Rows(0).Cells.Add(New TableCell())
                gridAmostras.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridAmostras.Rows(0).Cells(0).Text = "Não existe nenhuma amostra de Pré-Romaneio para ser enviada neste Transit Point."
                gridAmostras.Rows(0).Cells(0).ColumnSpan = 22
                ViewState.Item("gridAmostrasTemLinhas") = Nothing
                Me.btn_enviar.Visible = False
                btn_Descartar.Visible = False
                btn_aguardar_prox_tp.Visible = False
                lbl_descarte.Visible = False
                cbo_motivo_descarte.Visible = False
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Private Sub loadGridOutrasAmostras()
        Try


            Dim tp As New TransitPoint

            tp.id_transit_point = ViewState.Item("id_transit_point")

            Dim dstpamostras As DataSet = tp.getTransitPointPreRomaneioAmostrasNaoEnviadas()

            'se tem linhas em compartimento
            If (dstpamostras.Tables(0).Rows.Count > 0) Then
                gridOutrasAmostras.Visible = True
                Me.btn_enviar_oa.Visible = True
                btn_descartar_oa.Visible = True
                lbl_motivo_descarte_oa.Visible = True
                cbo_motivo_descarte_oa.Visible = True

                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco1") = 0 Then
                    gridOutrasAmostras.Columns.Item(7).Visible = False 'frasco amarelo
                Else
                    gridOutrasAmostras.Columns.Item(7).Visible = True 'frasco amarelo
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco2") = 0 Then
                    gridOutrasAmostras.Columns.Item(8).Visible = False 'frasco azul
                Else
                    gridOutrasAmostras.Columns.Item(8).Visible = True 'frasco azul
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco3") = 0 Then
                    gridOutrasAmostras.Columns.Item(9).Visible = False 'frasco branco
                Else
                    gridOutrasAmostras.Columns.Item(9).Visible = True 'frasco branco
                End If
                If dstpamostras.Tables(0).Rows(0).Item("id_tipo_frasco4") = 0 Then
                    gridOutrasAmostras.Columns.Item(10).Visible = False 'frasco vermelho
                Else
                    gridOutrasAmostras.Columns.Item(10).Visible = True 'frasco verelho
                End If


                gridOutrasAmostras.DataSource = Helper.getDataView(dstpamostras.Tables(0), "")
                gridOutrasAmostras.DataBind()
                ViewState.Item("gridOutrasAmostrasTemLinhas") = "S"

                Me.cbo_motivo_descarte_oa.SelectedValue = 0

            Else
                Dim dr As DataRow = dstpamostras.Tables(0).NewRow()
                dstpamostras.Tables(0).Rows.InsertAt(dr, 0)
                gridOutrasAmostras.Visible = True
                gridOutrasAmostras.DataSource = Helper.getDataView(dstpamostras.Tables(0), "")
                gridOutrasAmostras.DataBind()
                gridOutrasAmostras.Rows(0).Cells.Clear()
                gridOutrasAmostras.Rows(0).Cells.Add(New TableCell())
                gridOutrasAmostras.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridOutrasAmostras.Rows(0).Cells(0).Text = "Não existe nenhuma amostra de coleta de Pré-Romaneio (de outros Transit Points) pendente para ser enviada neste Transit Point."
                gridOutrasAmostras.Rows(0).Cells(0).ColumnSpan = 23
                ViewState.Item("gridOutrasAmostrasTemLinhas") = Nothing
                Me.btn_enviar_oa.Visible = False
                btn_descartar_oa.Visible = False
                lbl_motivo_descarte_oa.Visible = False
                cbo_motivo_descarte_oa.Visible = False
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Protected Sub lk_voltar_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar_footer.Click

        Response.Redirect("frm_transit_point.aspx?id_transit_point=" + ViewState.Item("id_transit_point"))

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("frm_transit_point.aspx?id_transit_point=" + ViewState.Item("id_transit_point"))

    End Sub

    Protected Sub gridAmostras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAmostras.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_coleta_amostra"), Label)
            Dim lbl_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_situacao_coleta_amostra"), Label)
            Dim lbl_id_situacao_tp_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_tp_amostra"), Label)
            Dim lbl_id_transit_point_registro As Label = CType(e.Row.FindControl("lbl_id_transit_point_registro"), Label)
            Dim chk_item As CheckBox = CType(e.Row.FindControl("ck_item"), CheckBox)

            'se a situação da coleta amostra é realizada
            If lbl_id_situacao_coleta_amostra.Text.Trim.Equals("2") Then
                lbl_situacao_coleta_amostra.Text = "Realizada"
                'se aq situacao do tp amostra é pendente
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("1") Then
                    chk_item.Enabled = True
                Else
                    '7983
                    'se aq situacao do tp amostra é prox tp
                    If lbl_id_situacao_tp_amostra.Text.Trim.Equals("4") Then
                        'se o registro foi feito por esse transit point
                        If CLng(lbl_id_transit_point_registro.Text) = CLng(ViewState.Item("id_transit_point").ToString) Then
                            chk_item.ToolTip = "Coleta já aguardando próximo Transit Point para envio."
                            chk_item.Enabled = False
                            e.Row.Cells(11).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                        Else
                            chk_item.Enabled = True
                            e.Row.Cells(11).Text = "Pendente" 'troca situação de prox tp para pendente
                        End If
                    Else
                        'se situação esta registrada como descarte ou enviada
                        chk_item.Enabled = False

                        If lbl_id_situacao_tp_amostra.Text.Trim.Equals("2") Then ' enviada
                            chk_item.ToolTip = "Coleta já enviada."
                            e.Row.Cells(11).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(6).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(7).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(8).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(9).BackColor = Drawing.Color.Aquamarine

                        Else
                            chk_item.ToolTip = "Coleta já descartada."
                            e.Row.Cells(10).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(9).BackColor = Drawing.Color.Yellow

                        End If
                    End If
                End If

            Else
                'se a situação da coleta amostra é DESCARTADA e a situação do tp e pendente (significa que a amostra foi descartada no coletor)
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("1") Then 'pendente
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(10).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(11).Text = String.Empty 'situação do envio
                    e.Row.Cells(6).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(7).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(8).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")
                Else
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(10).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(11).BackColor = System.Drawing.Color.FromName("#FF5050")
                    e.Row.Cells(6).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(7).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(8).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")
                End If


                chk_item.Enabled = False
                chk_item.ToolTip = "Os frascos desta coleta devem ser descartados porque os protocolos não serão exportados para ESALQ!"
            End If


        End If

    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)


            If chk_selec.Checked = True Then
                row.ForeColor = Drawing.Color.Red
            Else
                row.ForeColor = System.Drawing.Color.FromName("#333333")
            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridAmostras.Rows.Count - 1
                ch = CType(gridAmostras.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then
                    ch.Checked = ck_header.Checked
                    If ch.Checked = True Then
                        gridAmostras.Rows(li).ForeColor = Drawing.Color.Red
                    Else
                        gridAmostras.Rows(li).ForeColor = System.Drawing.Color.FromName("#333333")
                    End If

                Else
                    ch.Checked = False
                End If
            Next



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function verificarSelecionadosAmostras() As Boolean

        Try

            verificarSelecionadosAmostras = False

            Dim row As GridViewRow

            For Each row In gridAmostras.Rows
                Dim chk_selecionar As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                'se está selecionado
                If chk_selecionar.Checked = True Then
                    verificarSelecionadosAmostras = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function
    Private Function verificarSelecionadosOutrasAmostras() As Boolean

        Try

            verificarSelecionadosOutrasAmostras = False

            Dim row As GridViewRow

            For Each row In gridOutrasAmostras.Rows
                Dim chk_selecionar As CheckBox = CType(row.FindControl("ck_item_oa"), CheckBox)

                'se está selecionado
                If chk_selecionar.Checked = True Then
                    verificarSelecionadosOutrasAmostras = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub ck_item_oa_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)


            If chk_selec.Checked = True Then
                row.ForeColor = Drawing.Color.Red
            Else
                row.ForeColor = System.Drawing.Color.FromName("#333333")
            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub ck_header_oa_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridOutrasAmostras.Rows.Count - 1
                ch = CType(gridOutrasAmostras.Rows(li).FindControl("ck_item_oa"), CheckBox)
                If ch.Enabled = True Then
                    ch.Checked = ck_header.Checked
                    If ch.Checked = True Then
                        gridOutrasAmostras.Rows(li).ForeColor = Drawing.Color.Red
                    Else
                        gridOutrasAmostras.Rows(li).ForeColor = System.Drawing.Color.FromName("#333333")
                    End If

                Else
                    ch.Checked = False
                End If
            Next



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridOutrasAmostras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridOutrasAmostras.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_coleta_amostra_oa"), Label)
            Dim lbl_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_situacao_coleta_amostra_oa"), Label)
            Dim lbl_id_situacao_tp_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_tp_amostra_oa"), Label)
            Dim lbl_id_transit_point_registro As Label = CType(e.Row.FindControl("lbl_id_transit_point_registro_oa"), Label)
            Dim chk_item As CheckBox = CType(e.Row.FindControl("ck_item_oa"), CheckBox)

            'se a situação da coleta amostra é realizada
            If lbl_id_situacao_coleta_amostra.Text.Trim.Equals("2") Then
                lbl_situacao_coleta_amostra.Text = "Realizada"
                'se aq situacao do tp amostra é pendente
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("1") Then
                    chk_item.Enabled = True
                Else
                    '7983
                    'se aq situacao do tp amostra é prox tp
                    If lbl_id_situacao_tp_amostra.Text.Trim.Equals("4") Then
                        'se o registro foi feito por esse transit point
                        If CLng(lbl_id_transit_point_registro.Text) = CLng(ViewState.Item("id_transit_point").ToString) Then
                            chk_item.ToolTip = "Coleta já aguardando próximo Transit Point para envio."
                            chk_item.Enabled = False
                            e.Row.Cells(12).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(10).BackColor = Drawing.Color.Aquamarine
                        Else
                            chk_item.Enabled = True
                            e.Row.Cells(12).Text = "Pendente" 'troca situação de prox tp para pendente
                        End If
                    Else
                        'se situação esta registrada como descarte ou enviada
                        chk_item.Enabled = False

                        If lbl_id_situacao_tp_amostra.Text.Trim.Equals("2") Then ' enviada
                            chk_item.ToolTip = "Coleta já enviada."
                            e.Row.Cells(12).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(7).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(8).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(9).BackColor = Drawing.Color.Aquamarine
                            e.Row.Cells(10).BackColor = Drawing.Color.Aquamarine

                        Else
                            chk_item.ToolTip = "Coleta já descartada."
                            e.Row.Cells(11).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                            e.Row.Cells(10).BackColor = Drawing.Color.Yellow

                        End If
                    End If
                End If

            Else
                'se a situação da coleta amostra é DESCARTADA e a situação do tp e pendente (significa que a amostra foi descartada no coletor)
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("1") Then 'pendente
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(11).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(12).Text = String.Empty 'situação do envio
                    e.Row.Cells(7).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(8).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(10).BackColor = System.Drawing.Color.FromName("#FF7983")
                Else
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(11).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(12).BackColor = System.Drawing.Color.FromName("#FF5050")
                    e.Row.Cells(7).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(8).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")
                    e.Row.Cells(10).BackColor = System.Drawing.Color.FromName("#FF7983")
                End If


                chk_item.Enabled = False
                chk_item.ToolTip = "Os frascos desta coleta devem ser descartados porque os protocolos não serão exportados para ESALQ!"
            End If


        End If


    End Sub

    Protected Sub cv_enviar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_enviar.ServerValidate
        Try
            args.IsValid = verificarSelecionadosAmostras()

            If args.IsValid = False Then
                messageControl.Alert("Para enviar as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_descartar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_descartar.ServerValidate
        Try
            args.IsValid = verificarSelecionadosAmostras()

            If args.IsValid = False Then
                messageControl.Alert("Para descartar as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_aguardar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_aguardar.ServerValidate
        Try
            args.IsValid = verificarSelecionadosAmostras()

            If args.IsValid = False Then
                messageControl.Alert("Para receber as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_enviar_oa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_enviar_oa.ServerValidate
        Try
            args.IsValid = verificarSelecionadosOutrasAmostras()

            If args.IsValid = False Then
                messageControl.Alert("Para receber as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_descartar_oa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_descartar_oa.ServerValidate
        Try
            args.IsValid = verificarSelecionadosOutrasAmostras()

            If args.IsValid = False Then
                messageControl.Alert("Para descartar as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_enviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim preromamostra As New PreRomaneioAmostra
                Dim lbenviado As Boolean = False

                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        preromamostra.id_pre_romaneio_amostras = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                        preromamostra.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
                        preromamostra.id_situacao_tp_amostra = 2
                        preromamostra.id_motivo_descarte_tp_amostra = 0
                        preromamostra.id_modificador = Session("id_login")
                        preromamostra.updatePreRomaneioAmostras()

                        lbenviado = True
                    End If
                Next

                If lbenviado = True Then
                    loadGridAmostras()
                End If

                messageControl.Alert("Registro de envio de amostra no Transit Point registrado com sucesso!")



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub btn_aguardar_prox_tp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aguardar_prox_tp.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim preromamostra As New PreRomaneioAmostra
                Dim lbaguardando As Boolean = False

                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        preromamostra.id_pre_romaneio_amostras = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                        preromamostra.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
                        preromamostra.id_situacao_tp_amostra = 4
                        preromamostra.id_motivo_descarte_tp_amostra = 0
                        preromamostra.id_modificador = Session("id_login")
                        preromamostra.updatePreRomaneioAmostras()

                        lbaguardando = True
                    End If
                Next

                If lbaguardando = True Then
                    loadGridAmostras()
                End If

                messageControl.Alert("Registro de amostra para 'Aguardar Próximo Transit Point' realizado com sucesso!")



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub btn_Descartar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Descartar.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim preromamostra As New PreRomaneioAmostra
                Dim coletaamostra As New ColetaAmostra

                Dim lbdescartado As Boolean = False

                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)
                    Dim lbl_id_coleta As Label = CType(row.FindControl("lbl_id_coleta"), Label)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        preromamostra.id_pre_romaneio_amostras = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                        preromamostra.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
                        preromamostra.id_situacao_tp_amostra = 3
                        preromamostra.id_motivo_descarte_tp_amostra = cbo_motivo_descarte.SelectedValue
                        preromamostra.id_modificador = Session("id_login")
                        preromamostra.updatePreRomaneioAmostras()

                        coletaamostra.id_coleta = lbl_id_coleta.Text.Trim
                        coletaamostra.id_modificador = Session("id_login")
                        coletaamostra.id_currentidentity = row.Cells(2).Text
                        coletaamostra.updateColetaAmostraDescarteTransitPoint()


                        lbdescartado = True
                    End If
                Next

                If lbdescartado = True Then
                    loadGridAmostras()
                End If

                messageControl.Alert("Registro de DESCARTE de amostra realizado com sucesso! Lembre de descartar os frascos.")



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_enviar_oa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_enviar_oa.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim preromamostra As New PreRomaneioAmostra
                Dim lbenviado As Boolean = False

                For Each row In gridOutrasAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item_oa"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        preromamostra.id_pre_romaneio_amostras = gridOutrasAmostras.DataKeys(row.RowIndex).Value.ToString
                        preromamostra.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
                        preromamostra.id_situacao_tp_amostra = 2
                        preromamostra.id_motivo_descarte_tp_amostra = 0
                        preromamostra.id_modificador = Session("id_login")
                        preromamostra.updatePreRomaneioAmostras()

                        lbenviado = True
                    End If
                Next

                If lbenviado = True Then

                    loadGridOutrasAmostras()
                End If

                messageControl.Alert("Registro de envio de amostra no Transit Point registrado com sucesso!")



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub btn_descartar_oa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_descartar_oa.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim preromamostra As New PreRomaneioAmostra
                Dim lbdescartado As Boolean = False
                Dim coletaamostra As New ColetaAmostra

                For Each row In gridOutrasAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item_oa"), CheckBox)
                    Dim lbl_id_coleta As Label = CType(row.FindControl("lbl_id_coleta_oa"), Label)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        preromamostra.id_pre_romaneio_amostras = gridOutrasAmostras.DataKeys(row.RowIndex).Value.ToString
                        preromamostra.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
                        preromamostra.id_situacao_tp_amostra = 3
                        preromamostra.id_motivo_descarte_tp_amostra = cbo_motivo_descarte_oa.SelectedValue
                        preromamostra.id_modificador = Session("id_login")
                        preromamostra.updatePreRomaneioAmostras()


                        coletaamostra.id_coleta = lbl_id_coleta.Text.Trim
                        coletaamostra.id_modificador = Session("id_login")
                        coletaamostra.id_currentidentity = row.Cells(2).Text
                        coletaamostra.updateColetaAmostraDescarteTransitPoint()

                        lbdescartado = True
                    End If
                Next

                If lbdescartado = True Then
                    loadGridOutrasAmostras()
                End If

                messageControl.Alert("Registro de DESCARTE de amostra realizado com sucesso! Lembre de descartar os frascos.")

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
