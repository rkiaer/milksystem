Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_transit_point_pre_romaneio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transit_point_pre_romaneio.aspx")
            If Not Page.IsPostBack Then
                loadDetails()
            Else
                If ViewState.Item("gridPreRomaneioTemLinhas") Is Nothing Then
                    gridPreRomaneio.Rows(0).Cells.Clear()
                    gridPreRomaneio.Rows(0).Cells.Add(New TableCell())
                    gridPreRomaneio.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridPreRomaneio.Rows(0).Cells(0).Text = "Não existe nenhum Pré-Romaneio associado a este Transit Point!"
                    gridPreRomaneio.Rows(0).Cells(0).ColumnSpan = 11

                    gridDetalhePreRomaneio.Rows(0).Cells.Clear()
                    gridDetalhePreRomaneio.Rows(0).Cells.Add(New TableCell())
                    gridDetalhePreRomaneio.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridDetalhePreRomaneio.Rows(0).Cells(0).Text = "Não existe nenhuma Pré-Romaneio selecionado para visualização do detalhe!"
                    gridDetalhePreRomaneio.Rows(0).Cells(0).ColumnSpan = 16

                    gridTransitPoint.Rows(0).Cells.Clear()
                    gridTransitPoint.Rows(0).Cells.Add(New TableCell())
                    gridTransitPoint.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridTransitPoint.Rows(0).Cells(0).Text = "Não existe nenhum volume de pré-romaneio associado a esse Transit Point!"
                    gridTransitPoint.Rows(0).Cells(0).ColumnSpan = 16
                End If

            End If

            With btn_lupa_pre_romaneio
                .Attributes.Add("onclick", "javascript:ShowDialogPreRomaneio()")
                .ToolTip = "Filtrar Pré-Romaneios"
                '.Style("cursor") = "hand"
            End With
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Private Sub loadDetails()
        Try


            If Not (Request("id_transit_point") Is Nothing) Then
                ViewState.Item("id_transit_point") = Request("id_transit_point")
                hf_id_transit_point.Value = ViewState.Item("id_transit_point")

                'Monta grid de Placas do Transit Point
                Dim transitpointveiculo As New TransitPointVeiculo
                transitpointveiculo.id_transit_point = ViewState.Item("id_transit_point")
                Dim dvPlaca = New DataView(transitpointveiculo.getTransitPointVeiculoByFilters.Tables(0), "", "st_principal desc,ds_placa", DataViewRowState.OriginalRows)
                cbo_placa_tp.DataSource = dvPlaca
                cbo_placa_tp.DataTextField = "ds_placa"
                cbo_placa_tp.DataValueField = "id_transit_point_veiculo"
                cbo_placa_tp.DataBind()
                cbo_placa_tp.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                'cbo_placa_tp.Enabled = False

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
            lbl_transit_point.Text = lbl_id_transit_point.Text
            lbl_nm_situacao_transit_point.Text = transitPoint.nm_situacao_transit_point.ToString
            lbl_ds_unidade_transit_point.Text = transitPoint.ds_transit_point_unidade.ToString
            lbl_ds_placa.Text = transitPoint.ds_placa.ToString
            lbl_nm_linha.Text = transitPoint.nm_linha
            lbl_nr_total_litros_transit_point.Text = transitPoint.nr_total_litros
            ViewState.Item("id_transit_point_unidade") = transitPoint.id_transit_point_unidade

            If Not lbl_nr_total_litros_transit_point.Text.Equals(String.Empty) Then
                lbl_nr_total_litros_transit_point.Text = FormatNumber(lbl_nr_total_litros_transit_point.Text, 0)
            End If

            loadGridPreRomaneio()
            loadGridDetalhePreRomaneio()
            loadGridTransitPointProdutores()


            If transitPoint.id_situacao_transit_point = 3 Then 'se fechado
                gridPreRomaneio.Columns(11).Visible = False 'retirar
                gridDetalhePreRomaneio.Columns(0).Visible = False 'check
                gridDetalhePreRomaneio.Columns(10).Visible = False 'retirar
                btn_incluir_pre_romaneio.Enabled = False
                btn_adicionar_volume.Enabled = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                'Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    
    
    Protected Sub btn_lupa_pre_romaneio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_pre_romaneio.Click
        Try
            carregarCamposPreRomaneio()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Private Sub carregarCamposPreRomaneio()

        Try

            If Not (customPage.getFilterValue("lupa_tp_preromaneio", "id_romaneio").Equals(String.Empty)) Then
                Me.txt_id_pre_romaneio.Text = customPage.getFilterValue("lupa_tp_preromaneio", "id_romaneio").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_tp_preromaneio")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPreRomaneio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPreRomaneio.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

                Else 'se nao esta editando
                    If Not IsDBNull(gridPreRomaneio.DataKeys.Item(e.Row.RowIndex).Value) Then

                        'se for mesmo pre-romaneio
                        If CLng(gridPreRomaneio.DataKeys.Item(e.Row.RowIndex).Value) = CLng(ViewState.Item("id_pre_romaneio")) Then
                            e.Row.ForeColor = Drawing.Color.Red
                        Else
                            e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                        End If
                    End If

                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPreRomaneio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridPreRomaneio.RowCommand

        Try

            Select Case e.CommandName.ToString().ToLower()
                Case "viewdetalhepreromaneio"
                    If gridPreRomaneio.EditIndex = -1 Then
                        ViewState.Item("id_pre_romaneio") = e.CommandArgument.ToString()
                        lbl_pre_romaneio.Text = ViewState.Item("id_pre_romaneio").ToString
                        cbo_placa_tp.Enabled = True
                        cbo_placa_tp.SelectedValue = String.Empty
                        cbo_compartimento.SelectedValue = String.Empty
                        cbo_compartimento.Enabled = False
                        lbl_volume_maximo.Text = String.Empty
                        loadGridPreRomaneio()
                        loadGridDetalhePreRomaneio()
                    End If
                Case "retirar"

                    retirarPreRomaneio(Convert.ToInt32(e.CommandArgument.ToString()))

            End Select
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub retirarPreRomaneio(ByVal id_pre_romaneio As Integer)

        Try

            'se solicitoi a retirada de pre romaneio , limpa o detalhe
            ViewState.Item("id_pre_romaneio") = Nothing
            lbl_pre_romaneio.Text = String.Empty
            cbo_placa_tp.SelectedValue = String.Empty
            cbo_placa_tp.Enabled = True
            cbo_compartimento.SelectedValue = String.Empty
            cbo_compartimento.Enabled = False
            lbl_volume_maximo.Text = String.Empty

            'retirar volume do transit point pára o pre romaneio e atualizar os volumes do pre romaneio e do transit
            retirarVolumeTransitPoint(id_pre_romaneio)

            Dim transitpointup As New TransitPointUProducao

            'busca todas as propriedades do transit point que vieram do pre romaneio a ser retirado
            transitpointup.id_pre_romaneio = id_pre_romaneio
            transitpointup.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
            transitpointup.id_modificador = Session("id_login")

            'se nao tem mais linha de transit ponmt produtor para o transit ponit e pre romaneio
            If transitpointup.getTransitPointUPByFilters.Tables(0).Rows.Count = 0 Then
                Dim tppreromaneio As New TransitPointPreRomaneio
                tppreromaneio.id_transit_point = transitpointup.id_transit_point
                tppreromaneio.id_pre_romaneio = transitpointup.id_pre_romaneio

                tppreromaneio.deleteTransitPointPreRomaneio()
                messageControl.Alert("Pré-Romaneio retirado do Transit Point com sucesso!")
            Else
                messageControl.Alert("Pré-Romaneio não foi retirado do Transit Point. Entre em contato com administrador do sistema.")

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub retirarVolumeTransitPoint(ByVal param_id_pre_romaneio As Integer, Optional ByVal param_id_romaneio_uproducao As Integer = 0)

        Try


            Dim transitpointup As New TransitPointUProducao
            Dim lrow As DataRow

            'busca todas as propriedades do transit point que vieram do pre romaneio a ser retirado
            transitpointup.id_pre_romaneio = param_id_pre_romaneio
            transitpointup.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
            transitpointup.id_modificador = Session("id_login")
            If param_id_romaneio_uproducao > 0 Then
                transitpointup.id_romaneio_uproducao = param_id_romaneio_uproducao
            End If

            Dim dsTP_UP As DataSet = transitpointup.getTransitPointUPByFilters
            'para cada propriedade encontrada, remove o volume do transit point e retorna o volume  para o pre romaneio
            For Each lrow In dsTP_UP.Tables(0).Rows
                transitpointup.id_romaneio_uproducao = lrow.Item("id_romaneio_uproducao")
                transitpointup.id_transit_point_compartimento = lrow.Item("id_transit_point_compartimento")
                transitpointup.id_transit_point_up = lrow.Item("id_transit_point_up")
                transitpointup.nr_litros = lrow.Item("nr_litros")
                transitpointup.updateTransitPointPreRomaneioVolumeRetirar()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridDetalhePreRomaneio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridDetalhePreRomaneio.RowCommand

        Try

            Select Case e.CommandName.ToString().ToLower()
                Case "retirarup"
                    Dim lid_romaneio_uproducao As Label = CType(gridDetalhePreRomaneio.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_romaneio_uproducao"), Label)
                    Dim lpropriedade As DataControlFieldCell = CType(gridDetalhePreRomaneio.Rows.Item(e.CommandArgument.ToString).Cells(4), DataControlFieldCell)
                    Dim lprodutor As DataControlFieldCell = CType(gridDetalhePreRomaneio.Rows.Item(e.CommandArgument.ToString).Cells(3), DataControlFieldCell)


                    'retirar volume da propriedade/up do transit point e atualizar volume das tabelas do pre romaneio e transit point
                    retirarVolumeTransitPoint(CInt(ViewState.Item("id_pre_romaneio").ToString), CInt(lid_romaneio_uproducao.Text))

                    messageControl.Alert("O volume de leite do Produtor " & lprodutor.Text & ", propriedade/UP " & lpropriedade.Text & " do Pré-Romaneio " & ViewState.Item("id_pre_romaneio").ToString & " foi retirado do Transit Point com sucesso.")

                    'se solicitoi a retirada de pre romaneio , limpa o detalhe
                    cbo_placa_tp.SelectedValue = String.Empty
                    cbo_placa_tp.Enabled = True
                    cbo_compartimento.SelectedValue = String.Empty
                    cbo_compartimento.Enabled = False
                    lbl_volume_maximo.Text = String.Empty

                    loadData()

            End Select
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    
    Private Sub loadGridPreRomaneio()
        Try


            Dim tppreromaneio As New TransitPoint

            tppreromaneio.id_transit_point = ViewState.Item("id_transit_point")

            Dim dstppreromaneio As DataSet = tppreromaneio.getTransitPointPreRomaneio()

            'se tem linhas em compartimento
            If (dstppreromaneio.Tables(0).Rows.Count > 0) Then
                gridPreRomaneio.Visible = True
                gridPreRomaneio.DataSource = Helper.getDataView(dstppreromaneio.Tables(0), "")
                gridPreRomaneio.DataBind()
                ViewState.Item("gridPreRomaneioTemLinhas") = "S"
            Else
                Dim dr As DataRow = dstppreromaneio.Tables(0).NewRow()
                dstppreromaneio.Tables(0).Rows.InsertAt(dr, 0)
                gridPreRomaneio.Visible = True
                gridPreRomaneio.DataSource = Helper.getDataView(dstppreromaneio.Tables(0), "")
                gridPreRomaneio.DataBind()
                gridPreRomaneio.Rows(0).Cells.Clear()
                gridPreRomaneio.Rows(0).Cells.Add(New TableCell())
                gridPreRomaneio.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridPreRomaneio.Rows(0).Cells(0).Text = "Não existe nenhum Pré-Romaneio informado para o Transit Point!"
                gridPreRomaneio.Rows(0).Cells(0).ColumnSpan = 12
                ViewState.Item("gridPreRomaneioTemLinhas") = Nothing

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Private Sub loadGridDetalhePreRomaneio()
        Try

            If ViewState.Item("id_pre_romaneio") Is Nothing Then
                ViewState.Item("id_pre_romaneio") = 0
            End If

            Dim tppreromaneio As New Romaneio_Comp_UProducao
            If CLng(ViewState.Item("id_pre_romaneio")) > 0 Then
                tppreromaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_pre_romaneio"))
                Dim dstpup As DataSet = tppreromaneio.getPreRomaneioProdutor()

                'se tem linhas em compartimento
                If (dstpup.Tables(0).Rows.Count > 0) Then
                    gridDetalhePreRomaneio.Visible = True
                    gridDetalhePreRomaneio.DataSource = Helper.getDataView(dstpup.Tables(0), "ds_placa, nm_compartimento, dt_coleta, nm_pessoa")
                    gridDetalhePreRomaneio.DataBind()
                Else
                    Dim dr As DataRow = dstpup.Tables(0).NewRow()
                    dstpup.Tables(0).Rows.InsertAt(dr, 0)
                    gridDetalhePreRomaneio.Visible = True
                    gridDetalhePreRomaneio.DataSource = Helper.getDataView(dstpup.Tables(0), "")
                    gridDetalhePreRomaneio.DataBind()
                    gridDetalhePreRomaneio.Rows(0).Cells.Clear()
                    gridDetalhePreRomaneio.Rows(0).Cells.Add(New TableCell())
                    gridDetalhePreRomaneio.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridDetalhePreRomaneio.Rows(0).Cells(0).Text = "Não existe nenhum Pré-Romaneio selecionado para visualização do detalhe!"
                    gridDetalhePreRomaneio.Rows(0).Cells(0).ColumnSpan = 16
                End If
            Else
                tppreromaneio.id_romaneio = -1
                Dim dstpup As DataSet = tppreromaneio.getPreRomaneioProdutor()

                Dim dr As DataRow = dstpup.Tables(0).NewRow()
                dstpup.Tables(0).Rows.InsertAt(dr, 0)
                gridDetalhePreRomaneio.Visible = True
                gridDetalhePreRomaneio.DataSource = Helper.getDataView(dstpup.Tables(0), "")
                gridDetalhePreRomaneio.DataBind()
                gridDetalhePreRomaneio.Rows(0).Cells.Clear()
                gridDetalhePreRomaneio.Rows(0).Cells.Add(New TableCell())
                gridDetalhePreRomaneio.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridDetalhePreRomaneio.Rows(0).Cells(0).Text = "Não existe nenhum Pré-Romaneio selecionado para visualização do detalhe!"
                gridDetalhePreRomaneio.Rows(0).Cells(0).ColumnSpan = 16


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub
    Private Sub loadGridTransitPointProdutores()
        Try


            Dim transitpoint As New TransitPoint

            transitpoint.id_transit_point = ViewState.Item("id_transit_point")

            Dim dstransitpont As DataSet = transitpoint.getTransitPointCompartimentoProdutores()

            'se tem linhas em compartimento
            If (dstransitpont.Tables(0).Rows.Count > 0) Then
                gridTransitPoint.Visible = True
                gridTransitPoint.DataSource = Helper.getDataView(dstransitpont.Tables(0), "")
                gridTransitPoint.DataBind()
            Else
                Dim dr As DataRow = dstransitpont.Tables(0).NewRow()
                dstransitpont.Tables(0).Rows.InsertAt(dr, 0)
                gridTransitPoint.Visible = True
                gridTransitPoint.DataSource = Helper.getDataView(dstransitpont.Tables(0), "")
                gridTransitPoint.DataBind()
                gridTransitPoint.Rows(0).Cells.Clear()
                gridTransitPoint.Rows(0).Cells.Add(New TableCell())
                gridTransitPoint.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridTransitPoint.Rows(0).Cells(0).Text = "Não existe nenhum volume de Pré-Romaneio associado ao Transit Point!"
                gridTransitPoint.Rows(0).Cells(0).ColumnSpan = 16

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub chk_selecionar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try

        '    Dim wc As WebControl = CType(sender, WebControl)
        '    Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        '    Dim chk_selec As CheckBox

        '    chk_selec = CType(sender, CheckBox)

        '    Dim txtnrvolume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
        '    Dim lvolumeselecionado As Decimal = 0

        '    If Not lbl_volume_selecionado.Text.Equals(String.Empty) Then
        '        lvolumeselecionado = CDec(lbl_volume_selecionado.Text)
        '    End If

        '    If chk_selec.Checked = True Then
        '        'se tem valor informado e nao é zero
        '        If Not txtnrvolume.Text.Equals(String.Empty) AndAlso CInt(txtnrvolume.Text) > 0 Then
        '            lvolumeselecionado = lvolumeselecionado + CDec(txtnrvolume.Text)
        '        Else
        '            chk_selec.Checked = False 'assume que nao pode selecionar por nao ter informado volume
        '        End If
        '    Else
        '        If Not txtnrvolume.Text.Equals(String.Empty) AndAlso CInt(txtnrvolume.Text) > 0 Then
        '            lvolumeselecionado = lvolumeselecionado - CDec(txtnrvolume.Text)
        '        End If
        '    End If
        '    lbl_volume_selecionado.Text = FormatNumber(lvolumeselecionado, 0)




        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try

    End Sub

    Protected Sub btn_incluir_pre_romaneio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluir_pre_romaneio.Click
        Try
            If Page.IsValid Then

                Dim transitpointpreromaneio As New TransitPointPreRomaneio

                transitpointpreromaneio.id_transit_point = ViewState.Item("id_transit_point").ToString
                transitpointpreromaneio.id_pre_romaneio = txt_id_pre_romaneio.Text
                transitpointpreromaneio.id_modificador = Session("id_login")
                transitpointpreromaneio.insertTransitPointPreRomaneio()

                'se status é aberto
                If lbl_nm_situacao_transit_point.Text.Trim.Equals("Aberto") Then
                    'se situação é aberto, é o primeiro pre romaneio incluido, entao altera situacao do TP para 'Em Andamento'
                    Dim transitpoint As New TransitPoint
                    transitpoint.id_situacao_transit_point = 2 'em andamento
                    transitpoint.id_transit_point = ViewState.Item("id_transit_point").ToString
                    transitpoint.id_modificador = Session("id_login")
                    transitpoint.updateTransitPointSituacao()
                End If

                txt_id_pre_romaneio.Text = String.Empty
                hf_id_romaneio.Value = String.Empty

                loadGridPreRomaneio()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub cbo_placa_tp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_placa_tp.SelectedIndexChanged
        Try

            'atualiza volume selecionado (varre grid e soma os selecionados novamente)
            atualizarVolumeSelecionado()

            If cbo_placa_tp.SelectedValue <> String.Empty Then
                cbo_compartimento.Enabled = True

                Dim transitcomp As New TransitPointCompartimento

                transitcomp.id_transit_point_veiculo = cbo_placa_tp.SelectedValue
                transitcomp.id_transit_point = ViewState.Item("id_transit_point")
                transitcomp.id_situacao = 1 'ativo

                cbo_compartimento.DataSource = transitcomp.getTransitPointCompartimentoByFilters()
                cbo_compartimento.DataTextField = "nm_compartimento"
                cbo_compartimento.DataValueField = "id_transit_point_compartimento"
                cbo_compartimento.DataBind()
                cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                cbo_compartimento.SelectedValue = String.Empty
            Else
                cbo_compartimento.Items.Clear()
                cbo_compartimento.Enabled = False
                lbl_volume_maximo.Text = String.Empty
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

 
    Protected Sub btn_adicionar_volume_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_volume.Click
        Try
            If Page.IsValid Then

                Dim transitpointup As New TransitPointUProducao

                transitpointup.id_transit_point = ViewState.Item("id_transit_point").ToString
                transitpointup.id_pre_romaneio = ViewState.Item("id_pre_romaneio").ToString
                transitpointup.id_transit_point_compartimento = cbo_compartimento.SelectedValue
                transitpointup.id_modificador = Session("id_login")

                Dim row As GridViewRow
                Dim lvolumeselecionado As Decimal = 0
                Dim lsomavolumeromUP As Integer = 0
                Dim dstransitpropup As DataSet

                'para cada linha selecionada
                For Each row In gridDetalhePreRomaneio.Rows
                    Dim txtnrvolume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim chk_selec As Anthem.CheckBox = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("chk_selecionar"), Anthem.CheckBox)
                    Dim lid_romaneio_uproducao As Label = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("lbl_id_romaneio_uproducao"), Label)
                    Dim lid_propriedade As Label = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("lbl_id_propriedade"), Label)
                    Dim lid_unid_producao As Label = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("lbl_id_unid_producao"), Label)

                    transitpointup.id_transit_point_up = 0
                    transitpointup.nr_litros = 0

                    If chk_selec.Checked = True Then
                        'se tem valor informado e nao é zero
                        If Not txtnrvolume.Text.Equals(String.Empty) AndAlso CInt(txtnrvolume.Text) > 0 Then
                            transitpointup.id_romaneio_uproducao = lid_romaneio_uproducao.Text
                            transitpointup.id_propriedade = lid_propriedade.Text
                            transitpointup.id_unid_producao = lid_unid_producao.Text

                            dstransitpropup = transitpointup.getTransitPointUPByFilters

                            If dstransitpropup.Tables(0).Rows.Count > 0 Then
                                'se ja existe transit point up, pega o id_transit_point_up
                                transitpointup.id_transit_point_up = dstransitpropup.Tables(0).Rows(0).Item("id_transit_point_up").ToString
                            Else
                                'insere transit point up 
                                transitpointup.id_transit_point_up = transitpointup.insertTransitPointUP()
                            End If
                            'pega o volume informado 
                            transitpointup.nr_litros = txtnrvolume.Text

                            'atualiza volume do pre romaneio e dotransit point
                            transitpointup.updateTransitPointPreRomaneioVolumeAdicionar()

                        End If
                    End If
                Next
                messageControl.Alert("Os volumes selecionados foram adiconados ao Transit Point com sucesso!")

                cbo_placa_tp.SelectedValue = String.Empty
                cbo_compartimento.SelectedValue = String.Empty
                cbo_compartimento.Enabled = False
                lbl_volume_maximo.Text = String.Empty
                lbl_volume_selecionado.Text = String.Empty
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub



    Protected Sub cv_pre_romaneio_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pre_romaneio.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String

            Dim tppreromaneio As New TransitPointPreRomaneio
            tppreromaneio.id_pre_romaneio = txt_id_pre_romaneio.Text
            tppreromaneio.id_transit_point = ViewState.Item("id_transit_point").ToString
            'se encontrou o pre romaneio no cadastro do transit point
            If tppreromaneio.getTransitPointPreRomaneioByFilters().Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "O número informado no campo 'Pré-Romaneio' não pode ser incluído porque já existe no Transit Point."
            End If

            'se nao tem erros, verifica o pre romaneio
            If args.IsValid = True Then

                Dim romaneio As New Romaneio()
                romaneio.id_romaneio = txt_id_pre_romaneio.Text
                Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters()
                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    With dsromaneio.Tables(0).Rows(0)
                        'se status do romanei for maior ou igual a 7, significa que é um pre romaneio de transit point, se for menor nao é um pre romaneio
                        If CInt(.Item("id_st_romaneio").ToString) < 7 Then
                            args.IsValid = False
                            lmsg = "O número informado no campo 'Pré-Romaneio' não pode ser incluído porque não corresponde a um Pré-Romaneio de Transit Point."
                        Else
                            'se é um pre romaneio, verifica se é um pre romaneio da mesma unidade do transit point
                            If CInt(ViewState.Item("id_transit_point_unidade").ToString) = CInt(.Item("id_transit_point_unidade").ToString) Then
                                'se status do romaneio não é 9 (disponivel) nem 11 (em uso parcial), não pode ser utilizado no TRANSIT POINT
                                If Not (.Item("id_st_romaneio").ToString.Equals("9") OrElse .Item("id_st_romaneio").ToString.Equals("11")) Then
                                    args.IsValid = False
                                    lmsg = "O Pré-Romaneio informado não pode ser incluído porque sua situação é '" & .Item("nm_st_romaneio").ToString & "'. Para inclusão no Transit Point deve estar como disponível ou em uso parcial."
                                End If
                            Else
                                args.IsValid = False
                                lmsg = "O Pré-Romaneio informado não pode ser incluído porque não foi cadastrado na mesma Unidade de Transit Point do Transit Point " & lbl_id_transit_point.Text & "."

                            End If
                        End If
                    End With
                Else
                    args.IsValid = False
                    lmsg = "O número informado no campo 'Pré-Romaneio' não existe no cadastro."
                End If

            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub chk_selecionar_todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox
            Dim txtnrvolume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox
            Dim lvolumeselecionado As Decimal = 0

            ck_header = CType(sender, CheckBox)

            If ck_header.Checked = True Then
                For li = 0 To gridDetalhePreRomaneio.Rows.Count - 1
                    ch = CType(gridDetalhePreRomaneio.Rows(li).FindControl("chk_selecionar"), CheckBox)
                    txtnrvolume = CType(gridDetalhePreRomaneio.Rows(li).FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    'se informou volume e for maior que zero
                    If Not txtnrvolume.Text.Equals(String.Empty) AndAlso CInt(txtnrvolume.Text) > 0 Then
                        lvolumeselecionado = lvolumeselecionado + CDec(txtnrvolume.Text)
                        ch.Checked = True
                    Else
                        ch.Checked = False
                    End If
                Next
            Else
                For li = 0 To gridDetalhePreRomaneio.Rows.Count - 1
                    ch = CType(gridDetalhePreRomaneio.Rows(li).FindControl("chk_selecionar"), CheckBox)
                    ch.Checked = False
                Next
            End If
            lbl_volume_selecionado.Text = FormatNumber(lvolumeselecionado, 0)




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_volume_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_volume.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String
            Dim row As GridViewRow

            'atualiza volume selecionado (varre grid e soma os selecionados novamente)
            atualizarVolumeSelecionado()

            'se selecionou volume
            If Not (CLng(lbl_volume_selecionado.Text) > 0) Then
                args.IsValid = False
                lmsg = "Para adicionar volume ao Transit Point, alguma propriedade deve ser selecionada e o volume informado."

            Else
                Dim transitpointcomp As New TransitPointCompartimento(cbo_compartimento.SelectedValue)

                'se o total de litros existentes no compartimento somados ao volume selecionado para transferencia forem maiores que o volume maximo suportado pelo comp transit point
                If (CLng(transitpointcomp.nr_total_litros) + CLng(lbl_volume_selecionado.Text)) > CLng(transitpointcomp.nr_volume_maximo) Then
                    args.IsValid = False
                    lmsg = "O volume total selecionado não pode ultrapassar a capacidade máxima do compartimento do Transit Point que é de " & FormatNumber(transitpointcomp.nr_volume_maximo, 0).ToString & "."
                End If

                If args.IsValid = True Then
                    For Each row In gridDetalhePreRomaneio.Rows
                        Dim chk_selecionar As Anthem.CheckBox = CType(row.FindControl("chk_selecionar"), Anthem.CheckBox)
                        Dim txt_nr_volume_tp As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim nr_volume_saldo_pre_romaneio As DataControlFieldCell = CType(row.Cells(8), DataControlFieldCell)
                        'se está selecionado
                        If chk_selecionar.Checked = True Then

                            If CDec(txt_nr_volume_tp.Text) > CDec(nr_volume_saldo_pre_romaneio.Text) Then
                                args.IsValid = False
                                lmsg = String.Concat("O volume informado para o Transit Point não poder ser maior que o Volume Saldo do pré-romaneio, para a propriedade ", CType(row.Cells(4), DataControlFieldCell).Text, ", Placa/Comp ", CType(row.Cells(1), DataControlFieldCell).Text, "/", CType(row.Cells(2), DataControlFieldCell).Text, ".")
                            End If
                        End If
                    Next
                End If
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridDetalhePreRomaneio_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridDetalhePreRomaneio.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_delete As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
                btn_delete.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridDetalhePreRomaneio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridDetalhePreRomaneio.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim lid_romaneio_uproducao As Label = CType(e.Row.FindControl("lbl_id_romaneio_uproducao"), Label)
                Dim btn_delete As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
                Dim txt_nr_volume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                If Not ViewState.Item("id_pre_romaneio") Is Nothing AndAlso CInt(ViewState.Item("id_pre_romaneio")) > 0 Then

                    'atualizando valor do Campo volume Transf TP - que mostra o volume da propriedade que foi adicionado ao transit point
                    Dim transitpointup As New TransitPointUProducao
                    transitpointup.id_transit_point = ViewState.Item("id_transit_point")
                    transitpointup.id_romaneio_uproducao = lid_romaneio_uproducao.Text
                    e.Row.Cells(7).Text = FormatNumber(transitpointup.getTransitPointUPSomaVolume, 0).ToString

                    'se não tem volume adicionado no TRANIST POINT desta propriuedade
                    If CInt(e.Row.Cells(7).Text) = 0 Then
                        'desabilita botao de retirar volume
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/menos_desabilitado.gif"
                        btn_delete.ToolTip = "Não há volume desta propriedade adicionado no Transit Point."
                    Else
                        btn_delete.Enabled = True
                        btn_delete.ImageUrl = "~/img/menos_red.gif"
                        btn_delete.ToolTip = "Retirar todo volume desta propriedade existente no Transit Point."

                    End If
                    'se saldo = 0
                    If e.Row.Cells(8).Text.Equals("0") Then
                        txt_nr_volume.Text = String.Empty
                        txt_nr_volume.Enabled = False
                        txt_nr_volume.ToolTip = "Propriedade sem saldo para tranferência de volume."

                    Else
                        txt_nr_volume.Enabled = True
                        txt_nr_volume.ToolTip = String.Empty
                        txt_nr_volume.Text = e.Row.Cells(8).Text

                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
    Private Sub atualizarVolumeSelecionado()
        Try

            Dim row As GridViewRow

            Dim lvolumeselecionado As Decimal = 0

            For Each row In gridDetalhePreRomaneio.Rows
                Dim txtnrvolume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("txt_nr_volume_tp"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                Dim chk_selec As Anthem.CheckBox = CType(gridDetalhePreRomaneio.Rows(row.RowIndex).FindControl("chk_selecionar"), Anthem.CheckBox)

                If chk_selec.Checked = True Then
                    'se tem valor informado e nao é zero
                    If Not txtnrvolume.Text.Equals(String.Empty) AndAlso CInt(txtnrvolume.Text) > 0 Then
                        lvolumeselecionado = lvolumeselecionado + CDec(txtnrvolume.Text)
                    End If
                End If
            Next

            lbl_volume_selecionado.Text = FormatNumber(lvolumeselecionado, 0)

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

    Protected Sub cbo_compartimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_compartimento.SelectedIndexChanged
        Try

            If cbo_compartimento.SelectedValue <> String.Empty Then
                cbo_compartimento.Enabled = True

                Dim transitcomp As New TransitPointCompartimento
                transitcomp.id_transit_point_compartimento = cbo_compartimento.SelectedValue
                Dim dscomp As DataSet = transitcomp.getTransitPointCompartimentoByFilters
                Dim nrvolumemax As String

                If dscomp.Tables(0).Rows.Count > 0 Then
                    nrvolumemax = dscomp.Tables(0).Rows(0).Item("nr_volume_maximo").ToString
                    If Not nrvolumemax.Equals(String.Empty) Then
                        lbl_volume_maximo.Text = FormatNumber(nrvolumemax.ToString, 0)
                    End If
                End If
            Else
                lbl_volume_maximo.Text = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
End Class
