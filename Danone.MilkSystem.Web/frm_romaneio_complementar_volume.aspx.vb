Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_romaneio_complementar_volume
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_complementar_volume.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                If Not (Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                End If
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_dt_entrada.Text = DateTime.Parse(romaneio.dt_hora_entrada.ToString).ToString

            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = romaneio.nr_peso_liquido_caderneta.ToString
                lbl_tipoleite.Text = romaneio.nm_item
                loadgridresults()
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_caderneta.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False
                tr_transbordo.Visible = True
                lbl_nr_nota_transf.Text = romaneio.nr_nota_fiscal_transf
                lbl_serie_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                lbl_dt_emissao_transf.Text = romaneio.dt_emissao_nota_transf
                lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                lbl_id_item.Text = romaneio.nm_item
                lbl_soma_nr_peso_liquido_caderneta.Text = romaneio.nr_peso_liquido_caderneta
                grdresults.Columns(0).Visible = False
                loadgridresults()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridresults()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rp As New Romaneio_Comp_UProducao

            rp.id_romaneio = id_romaneio

            Dim dsprodutor As DataSet = rp.getRomaneioUProducaoReajuste()

            If (dsprodutor.Tables(0).Rows.Count > 0) Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(dsprodutor.Tables(0), "")
                grdresults.DataBind()
            Else
                grdresults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas com a passagem de parametros.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_complementar_volume.aspx")



    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_complementar_volume.aspx")


    End Sub
    Protected Sub grdresults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdresults.RowCancelingEdit
        Try

            grdresults.EditIndex = -1
            loadgridresults()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdresults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)


        End Select

    End Sub

    Protected Sub grdresults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim nr_litros As Label = CType(e.Row.FindControl("nr_litros"), Label)
                Dim nr_litros_sem_reajuste As Label = CType(e.Row.FindControl("nr_litros_sem_reajuste"), Label)
                Dim lbl_volume_ajustado As Label = CType(e.Row.FindControl("lbl_nr_litros_ajustado"), Label)
                Dim lbl_volume_real As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
                Dim lbl_diferenca As DataControlFieldCell = CType(e.Row.Cells(8), DataControlFieldCell)
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("btn_excluir"), ImageButton)
                Dim id_propriedade As Label = CType(e.Row.FindControl("lbl_propriedade"), Label)
                Dim btneditar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                If Not (btnexcluir Is Nothing) Then
                    If id_propriedade.Text.ToString.Trim = ViewState.Item("id_propriedade").ToString Then
                        btneditar.Enabled = True
                        btneditar.ImageUrl = "~/img/icone_editar_grid.gif"
                    Else
                        btneditar.Enabled = False
                        btneditar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"

                    End If
                End If
                If Not (nr_litros_sem_reajuste Is Nothing) Then
                    'Se não tem valor de reajuste o valor real esta em nr_total_litros
                    If nr_litros_sem_reajuste.Text.Equals(String.Empty) Then
                        If Not (btnexcluir Is Nothing) Then
                            btnexcluir.Enabled = False
                            btnexcluir.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        End If
                        lbl_volume_real.Text = FormatNumber(nr_litros.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = String.Empty
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            txt_volume_ajustado.Text = String.Empty
                        End If
                        lbl_diferenca.Text = String.Empty
                    Else
                        lbl_volume_real.Text = FormatNumber(nr_litros_sem_reajuste.Text, 0)
                        If Not (lbl_volume_ajustado Is Nothing) Then
                            lbl_volume_ajustado.Text = FormatNumber(nr_litros.Text, 0)
                        Else
                            Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            txt_volume_ajustado.Text = FormatNumber(nr_litros.Text, 0)
                        End If
                        lbl_diferenca.Text = CStr(FormatNumber(CDec(nr_litros_sem_reajuste.Text) - CDec(nr_litros.Text), 0))
                    End If
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdresults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdresults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdresults.RowEditing
        Try

            grdresults.EditIndex = e.NewEditIndex
            loadgridresults()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdresults.RowUpdating
        'Capturar valores

        If Page.IsValid = True Then
            Dim row As GridViewRow = grdresults.Rows(e.RowIndex)
            Try

                If (Not (row) Is Nothing) Then

                    Dim rp As New Romaneio_Comp_UProducao
                    Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)

                    rp.id_romaneio_compartimento = Convert.ToInt32(id_romaneio_compartimento.Text)
                    rp.id_romaneio_uproducao = Convert.ToInt32(grdresults.DataKeys.Item(e.RowIndex).Value)
                    rp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                    Dim nr_total_litros As Label = CType(row.FindControl("nr_total_litros"), Label)
                    Dim nr_total_litros_sem_reajuste As Label = CType(row.FindControl("nr_total_litros_sem_reajuste"), Label)
                    Dim nr_litros As Label = CType(row.FindControl("nr_litros"), Label)
                    Dim nr_litros_sem_reajuste As Label = CType(row.FindControl("nr_litros_sem_reajuste"), Label)
                    Dim txt_volume_ajustado As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_litros_ajustado"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                    If Not (nr_litros_sem_reajuste Is Nothing) Then
                        'Se não tem valor de reajuste o valor real esta em nr_total_litros
                        If nr_litros_sem_reajuste.Text.Equals(String.Empty) Then
                            rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_litros_sem_reajuste = Convert.ToDecimal(nr_litros.Text)
                        Else
                            rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_litros_sem_reajuste = nr_litros_sem_reajuste.Text
                        End If
                        If nr_total_litros_sem_reajuste.Text.Equals(String.Empty) Then
                            'O compartimento tb nao foi alterado
                            'Pega o valor total do compartimento - o valor do coletor e soma o novo valor
                            rp.nr_total_litros = Convert.ToDecimal(nr_total_litros.Text) - Convert.ToDecimal(nr_litros.Text)
                            rp.nr_total_litros = rp.nr_total_litros + Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_total_litros_sem_reajuste = Convert.ToDecimal(nr_total_litros.Text)
                        Else
                            rp.nr_total_litros = Convert.ToDecimal(nr_total_litros.Text) - Convert.ToDecimal(nr_litros.Text)
                            rp.nr_total_litros = rp.nr_total_litros + Convert.ToDecimal(txt_volume_ajustado.Text)
                            'rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                            rp.nr_total_litros_sem_reajuste = nr_total_litros_sem_reajuste.Text
                        End If
                    End If

                    rp.id_modificador = Session("id_login")

                    rp.updateRomaneioUProducaoReajuste()
                    Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
                    romaneio.id_modificador = Session("id_login")
                    romaneio.RegerarRomaneioMapaLeite()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 127
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    grdresults.EditIndex = -1
                    'loadgridresults()
                    loadData()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_volumeajustado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_nr_litros_ajustado As Anthem.TextBox = CType(row.FindControl("txt_nr_litros_ajustado"), Anthem.TextBox)
            Dim lmsg As String = String.Empty
            If txt_nr_litros_ajustado.Text >= 0 Then
                args.IsValid = True
                'fran 09/01/2011 i chamado 1101
                Dim rp As New Romaneio_Comp_UProducao
                Dim id_romaneio_compartimento As Label = CType(row.FindControl("id_romaneio_compartimento"), Label)
                rp.id_romaneio_compartimento = Convert.ToInt32(id_romaneio_compartimento.Text)
                rp.id_romaneio_uproducao = Convert.ToInt32(grdresults.DataKeys.Item(row.RowIndex).Value())
                rp.nr_litros = Convert.ToDecimal(txt_nr_litros_ajustado.Text)
                If rp.getAjusteExcedeuVolume > 0 Then 'se o volume informado para ajuste excedeu o volume do compartimento
                    args.IsValid = False
                    lmsg = "O volume ajustado excede o volume máximo permitido ao compartimento. Alteração não pode ser efetuada!"
                End If
                'fran 09/01/2011 f chamado 1101
            Else
                args.IsValid = False
                lmsg = "O volume ajustado do produtor deve ser maior ou igual a zero."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



End Class
