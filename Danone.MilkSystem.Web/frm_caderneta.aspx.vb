Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_caderneta.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("nr_caderneta") Is Nothing) Then
                ViewState.Item("nr_caderneta") = Request("nr_caderneta")
                ViewState.Item("sortExpression") = "nr_ordem"
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim nr_caderneta As String = ViewState.Item("nr_caderneta").ToString
            Dim caderneta As New Caderneta(nr_caderneta)

            'lbl_estabelecimento.Text = caderneta.nm_estabelecimento
            lbl_nr_caderneta.Text = caderneta.nr_caderneta
            lbl_transportador.Text = caderneta.cd_cnh & " - " & caderneta.nm_motorista

            ' 15/01/2009 - Adri - i
            'lbl_linha.Text = caderneta.ds_linha
            lbl_linha.Text = caderneta.nm_linha
            ' 15/01/2009 - Adri - f

            'lbl_ds_placa.Text = caderneta.ds_placa
            'lbl_leite_desviado.Text = "Leite não desviado"

            caderneta.nr_caderneta = Convert.ToInt32(nr_caderneta.Trim)
            'Fran 29/12/2008 i
            Dim dscadernetaplacas As DataSet = caderneta.getCadernetaPlacas
            Dim i As Integer = 0
            If dscadernetaplacas.Tables(0).Rows.Count > 0 Then

                For i = 0 To dscadernetaplacas.Tables(0).Rows.Count - 1
                    lbl_ds_placa.Text = lbl_ds_placa.Text & dscadernetaplacas.Tables(0).Rows(i).Item("ds_placa").ToString & ", "
                Next

                lbl_ds_placa.Text = Left(lbl_ds_placa.Text, Len(lbl_ds_placa.Text) - 2)
            End If
            'Fran 29/12/2008 f

            ' 01/10/2009 - Rls 21 Frete (isolar a função que carrega o grid para mudar cor da linha) - i
            'Dim dsCadernetaColeta As DataSet = caderneta.getCadernetaColetasByFilters()

            'If (dsCadernetaColeta.Tables(0).Rows.Count > 0) Then
            '    'ViewState.Item("id_coleta") = dsCadernetaColeta.Tables(0).Rows(0).Item("id_coleta")  ' 01/10/2009 - Adri Rls21 Frete
            '    gridResults.Visible = True
            '    gridResults.DataSource = Helper.getDataView(dsCadernetaColeta.Tables(0), ViewState.Item("sortExpression"))
            '    gridResults.DataBind()

            '    ' 13/02/2009 - Rls16 - i
            '    caderneta.currentidentity = caderneta.nr_caderneta
            '    lbl_total_litros.Text = FormatNumber(caderneta.getCadernetaTotalLitros, 0)
            '    ' 13/02/2009 - Rls16 - f
            'Else
            '    gridResults.Visible = False
            '    messageControl.Alert("Nenhuma Coleta está cadastrada. Por favor tente novamente.")
            'End If

            ' 13/02/2009 - Rls16 - i
            caderneta.currentidentity = caderneta.nr_caderneta
            lbl_total_litros.Text = FormatNumber(caderneta.getCadernetaTotalLitros, 0)
            ' 13/02/2009 - Rls16 - f

            loadGridCaderneta()

            ' 01/10/2009 - Rls 21 Frete (isolar a função que carrega o grid para mudar cor da linha) - i


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_caderneta.aspx")
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub



    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()


    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("lst_caderneta.aspx")

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        ' 01/10/2009 - Rls21 Frete - i
        Select Case e.CommandName.ToString().ToLower()
            Case "nconf"
                ViewState.Item("id_coleta") = e.CommandArgument.ToString
                loadGridNConf()
        End Select
        ' 01/10/2009 - Rls21 Frete - f

    End Sub

 
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            'If (e.Row.Cells(9).Text.Trim().Equals("0")) Then  ' 26/11/2009 - Rls 21 Frete
            If (e.Row.Cells(10).Text.Trim().Equals("0")) Then
                e.Row.Cells(10).Text = "Negativo"
            Else
                e.Row.Cells(10).Text = "Positivo"
            End If

            ' 01/10/2009 - Rls 21 Frete - i
            If CLng(gridResults.DataKeys.Item(e.Row.RowIndex).Value) = CLng(ViewState.Item("id_coleta")) Then
                e.Row.ForeColor = Drawing.Color.Red
            Else
                e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
            End If
            ' 01/10/2009 - Rls 21 Frete - f


        End If

    End Sub

    Protected Sub lk_voltarFooter_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_caderneta.aspx")
    End Sub
    Private Sub loadGridNConf()

        ' Adri 01/10/2009 - Rls21 Frete - i
        Try

            Dim caderneta As New Caderneta
            caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

            '' Carrega dados da coleta
            'Dim dsCadernetaColeta As DataSet = caderneta.getCadernetaColetasByFilters()
            'If dsCadernetaColeta.Tables(0).Rows.Count > 0 Then

            '    lbl_ds_placa.Text = dsCadernetaColeta.Tables(0).Rows(0).Item("ds_placa").ToString & ", "

            '    lbl_ds_placa.Text = Left(lbl_ds_placa.Text, Len(lbl_ds_placa.Text) - 2)
            'End If


            'Carrega os dados do Grid

            Dim dsColetasNConf As DataSet = caderneta.getColetasNaoConformidades()

            If (dsColetasNConf.Tables(0).Rows.Count > 0) Then
                GridNConf.Visible = True
                GridNConf.DataSource = Helper.getDataView(dsColetasNConf.Tables(0), "")
                GridNConf.DataBind()
            Else
                messageControl.Alert("Nenhuma Não Conformidade está cadastrada para a coleta.")
                GridNConf.Visible = False
            End If

            loadGridCaderneta()     ' Atualiza a cor da linha selecionada

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adri 01/10/2009 - Rls21 Frete - f

    End Sub
    Private Sub loadGridCaderneta()

        ' 01/10/2009 - Rls 21 Frete (isolar a função que carrega o grid para mudar cor da linha) - i

        Dim caderneta As New Caderneta
        caderneta.nr_caderneta = ViewState.Item("nr_caderneta").ToString
        Dim dsCadernetaColeta As DataSet = caderneta.getCadernetaColetasByFilters()

        If (dsCadernetaColeta.Tables(0).Rows.Count > 0) Then
            'ViewState.Item("id_coleta") = dsCadernetaColeta.Tables(0).Rows(0).Item("id_coleta")  ' 01/10/2009 - Adri Rls21 Frete
            gridResults.Visible = True
            gridResults.DataSource = Helper.getDataView(dsCadernetaColeta.Tables(0), ViewState.Item("sortExpression"))
            gridResults.DataBind()

        Else
            gridResults.Visible = False
        End If


        ' 01/10/2009 - Rls 21 Frete (isolar a função que carrega o grid para mudar cor da linha) - i


    End Sub

End Class
