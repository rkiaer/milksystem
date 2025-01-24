Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_relatorio_sif

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            gridResults.Visible = False
            gridResultsCoop.Visible = False
            gridResultsSintetico.Visible = False

            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
            ViewState.Item("tiporelatorio") = opt_tipo_relatorio.SelectedValue

            If txt_nr_dia_ini.Text.Equals(String.Empty) Then
                'se nao informou dia assume os dias do mes
                ViewState.Item("dt_referencia_ini") = ViewState.Item("dt_referencia")
                ViewState.Item("dt_referencia_fim") = String.Concat(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia")))).ToString("dd/MM/yyyy"), " 23:59:59")
                txt_nr_dia_fim.Text = String.Empty
            Else 'se informou dia inicial
                ViewState.Item("dt_referencia_ini") = String.Concat(Right("0" + txt_nr_dia_ini.Text, 2).ToString, "/", txt_dt_referencia.Text, " 00:00:00")
                If txt_nr_dia_fim.Text.Equals(String.Empty) Then 'se nao informou dia final
                    'assume o ultimo dia da referencia
                    ViewState.Item("dt_referencia_fim") = String.Concat(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia")))).ToString("dd/MM/yyyy"), " 23:59:59")
                    txt_nr_dia_fim.Text = Day(CDate(ViewState.Item("dt_referencia_fim").ToString)).ToString
                Else
                    ViewState.Item("dt_referencia_fim") = String.Concat(Right("0" + txt_nr_dia_fim.Text, 2).ToString, "/", txt_dt_referencia.Text, " 23:59:59")
                End If
            End If
            ViewState.Item("nm_cidade") = txt_nm_cidade.Text
            ViewState.Item("id_grupo") = cbo_Grupo.SelectedValue
            ViewState.Item("id_estado") = cbo_estado.SelectedValue

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_sif.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_sif.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 203
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.RemoveAt(1)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(1)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1  ' Assume como default na consulta o Produtor



            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim mapasif As New MapaLeite

            mapasif.dt_referencia = ViewState.Item("dt_referencia")
            mapasif.id_estado = ViewState.Item("id_estado")
            mapasif.nm_cidade = ViewState.Item("nm_cidade")
            mapasif.dt_inicio = ViewState.Item("dt_referencia_ini")
            mapasif.dt_fim = ViewState.Item("dt_referencia_fim")
            mapasif.id_grupo = ViewState.Item("id_grupo")

            If ViewState.Item("tiporelatorio").ToString.Equals("A") Then
                Dim dsmapa As DataSet
                If mapasif.id_grupo = 1 Then
                    dsmapa = mapasif.getRelatorioSIFbyDia
                Else
                    dsmapa = mapasif.getRelatorioSIFbyDiaCooperativa
                End If
                If dsmapa.Tables.Count > 0 Then
                    If ViewState.Item("id_grupo").ToString.Equals("1") Then
                        If (dsmapa.Tables(0).Rows.Count > 0) Then
                            Dim dr As DataRow = dsmapa.Tables(0).NewRow()
                            Dim i As Int16 = 0
                            Dim nrcolunas As Int16 'guarda quantas colunas (ate qual indice) deve retirar da visualizacao da tela para deixar exibir os ultimos 12 dias
                            dsmapa.Tables(0).Rows.InsertAt(dr, 0)

                            nrcolunas = ((dsmapa.Tables(0).Columns.Count - 2) - 24)
                            If nrcolunas > 0 Then 'se for valor negativo tem menos de 24 colunas ou seja menos de 12 dias assim nao precisa retirar
                                For i = 1 To nrcolunas
                                    dsmapa.Tables(0).Columns.RemoveAt(2)
                                Next i
                            End If

                            gridResults.Visible = True
                            gridResults.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                            gridResults.DataBind()

                        Else
                            gridResults.Visible = False
                            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                        End If

                    Else
                        If (dsmapa.Tables(0).Rows.Count > 0) Then
                            Dim dr As DataRow = dsmapa.Tables(0).NewRow()
                            Dim i As Int16 = 0
                            Dim nrcolunas As Int16 'guarda quantas colunas (ate qual indice) deve retirar da visualizacao da tela para deixar exibir os ultimos 12 dias
                            dsmapa.Tables(0).Rows.InsertAt(dr, 0)

                            nrcolunas = ((dsmapa.Tables(0).Columns.Count - 5) - 12)
                            If nrcolunas > 0 Then 'se for valor negativo tem menos de 12 colunas ou seja menos de 12 dias assim nao precisa retirar
                                For i = 1 To nrcolunas
                                    dsmapa.Tables(0).Columns.RemoveAt(5)
                                Next i
                            End If

                            gridResultsCoop.Visible = True
                            gridResultsCoop.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                            gridResultsCoop.DataBind()

                        Else
                            gridResultsCoop.Visible = False
                            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                        End If

                    End If
                Else
                    gridResultsCoop.Visible = False
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
            Else ' se sintetico
                Dim dsmapa As DataSet = mapasif.getRelatorioSIF
                If (dsmapa.Tables(0).Rows.Count > 0) Then
                    gridResultsSintetico.Visible = True
                    gridResultsSintetico.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                    gridResultsSintetico.DataBind()

                Else
                    gridResultsSintetico.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then


            e.Row.Cells(0).RowSpan = 2
            e.Row.Cells(1).RowSpan = 2
            e.Row.Cells(0).Text = "UF"
            e.Row.Cells(1).Text = "Cidade"

            'varre a partir da 3 coluna
            For i = 2 To e.Row.Cells.Count - 1
                If i Mod 2 = 0 Then 'coluna par (produtor)
                    laux = e.Row.Cells(i + 1).Text.ToString.Trim 'pega o valor da coluna impar (que é o dia do mes)
                    e.Row.Cells(i).ColumnSpan = 2
                    e.Row.Cells(i).Text = Right(String.Concat("0", laux.ToString, Right(ViewState.Item("dt_referencia").ToString, 8)), 10).ToString
                End If
            Next i

            'varre a partir da 3 coluna
            For i = 2 To e.Row.Cells.Count - 1
                If i <= e.Row.Cells.Count - 1 Then
                    If Len(e.Row.Cells(i).Text.Trim) <= 2 Then 'coluna par (produtor)
                        e.Row.Cells.RemoveAt(i)
                    End If
                Else
                    Exit For
                End If
            Next i


        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then

        End If
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            If e.Row.RowIndex = 0 Then
                For i = 2 To e.Row.Cells.Count - 1

                    e.Row.Cells(i).BackColor = System.Drawing.Color.FromName("#006699")
                    e.Row.Cells(i).ForeColor = Drawing.Color.White
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center

                    If i Mod 2 = 0 Then 'coluna par
                        e.Row.Cells(i).Text = "Prod."
                    Else
                        e.Row.Cells(i).Text = "Vol."
                    End If
                Next i

                e.Row.Cells.RemoveAt(0) ' remove uf
                e.Row.Cells.RemoveAt(0) 'remove cidade

            Else
                'se linha 1
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(1).Wrap = False


                'varre a partir da 3 coluna
                For i = 2 To e.Row.Cells.Count - 1
                    If i Mod 2 > 0 Then 'coluna impar (volume leite)
                        e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right

                        If (Not e.Row.Cells(i).Text.Equals(String.Empty) And Not e.Row.Cells(i).Text = "&nbsp;") Then
                            e.Row.Cells(i).Text = FormatNumber(e.Row.Cells(i).Text, 0).ToString()
                        End If
                    Else
                        e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center

                    End If
                Next i
            End If
        End If


    End Sub



    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then
            gridResults.Visible = False
            gridResultsCoop.Visible = False
            gridResultsSintetico.Visible = False

            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
            ViewState.Item("tiporelatorio") = opt_tipo_relatorio.SelectedValue

            If txt_nr_dia_ini.Text.Equals(String.Empty) Then
                'se nao informou dia assume os dias do mes
                ViewState.Item("dt_referencia_ini") = ViewState.Item("dt_referencia")
                ViewState.Item("dt_referencia_fim") = String.Concat(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia")))).ToString("dd/MM/yyyy"), " 23:59:59")
                txt_nr_dia_fim.Text = String.Empty
            Else 'se informou dia inicial
                ViewState.Item("dt_referencia_ini") = String.Concat(Right("0" + txt_nr_dia_ini.Text, 2).ToString, "/", txt_dt_referencia.Text, " 00:00:00")
                If txt_nr_dia_fim.Text.Equals(String.Empty) Then 'se nao informou dia final
                    'assume o ultimo dia da referencia
                    ViewState.Item("dt_referencia_fim") = String.Concat(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia")))).ToString("dd/MM/yyyy"), " 23:59:59")
                    txt_nr_dia_fim.Text = Day(CDate(ViewState.Item("dt_referencia_fim").ToString)).ToString
                Else
                    ViewState.Item("dt_referencia_fim") = String.Concat(Right("0" + txt_nr_dia_fim.Text, 2).ToString, "/", txt_dt_referencia.Text, " 23:59:59")
                End If
            End If
            ViewState.Item("nm_cidade") = txt_nm_cidade.Text
            ViewState.Item("id_grupo") = cbo_Grupo.SelectedValue
            ViewState.Item("id_estado") = cbo_estado.SelectedValue

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 203
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            If ViewState.Item("tiporelatorio").ToString.Equals("A") Then
                Dim mapasif As New MapaLeite

                mapasif.dt_referencia = ViewState.Item("dt_referencia")
                mapasif.id_estado = ViewState.Item("id_estado")
                mapasif.nm_cidade = ViewState.Item("nm_cidade")
                mapasif.dt_inicio = ViewState.Item("dt_referencia_ini")
                mapasif.dt_fim = ViewState.Item("dt_referencia_fim")
                mapasif.id_grupo = ViewState.Item("id_grupo")

                Dim dsmapa As DataSet
                If mapasif.id_grupo = 1 Then
                    dsmapa = mapasif.getRelatorioSIFbyDia
                Else
                    dsmapa = mapasif.getRelatorioSIFbyDiaCooperativa
                End If

                If dsmapa.Tables.Count > 0 Then
                    If ViewState.Item("id_grupo").ToString.Equals("1") Then 'se produtor
                        'analitico produtor
                        Response.Redirect("frm_relatorio_sif_produtor_excel.aspx?id_estado=" + ViewState.Item("id_estado").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString() + "&tiporelatorio=" + ViewState.Item("tiporelatorio").ToString() + "&nm_cidade=" + ViewState.Item("nm_cidade").ToString())
                    Else
                        'analitico cooperativa
                        Response.Redirect("frm_relatorio_sif_cooperativa_excel.aspx?id_estado=" + ViewState.Item("id_estado").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString() + "&tiporelatorio=" + ViewState.Item("tiporelatorio").ToString() + "&nm_cidade=" + ViewState.Item("nm_cidade").ToString())
                    End If
                Else
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If

            Else
                'sintetico
                Response.Redirect("frm_relatorio_sif_sintetico_excel.aspx?id_estado=" + ViewState.Item("id_estado").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString() + "&tiporelatorio=" + ViewState.Item("tiporelatorio").ToString() + "&nm_cidade=" + ViewState.Item("nm_cidade").ToString())

            End If


            loadData()
        End If

    End Sub


 
    Protected Sub opt_tipo_relatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles opt_tipo_relatorio.SelectedIndexChanged

        Select Case opt_tipo_relatorio.SelectedValue
            Case "S" 'sintético
                gridResultsSintetico.Visible = False
                gridResults.Visible = False
                gridResultsCoop.Visible = False
                lbl_informativo.Visible = False
                txt_nr_dia_ini.Text = String.Empty
                txt_nr_dia_fim.Text = String.Empty
                txt_nr_dia_ini.ToolTip = "Filtro de dias específicos apenas para REPORT SIF Analítico."
                txt_nr_dia_fim.ToolTip = "Filtro de dias específicos apenas para REPORT SIF Analítico."
                txt_nr_dia_ini.Enabled = False
                txt_nr_dia_fim.Enabled = False
                cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
                cbo_Grupo.SelectedValue = 1  ' Assume como default na consulta o Produtor

            Case "A" 'analítico
                gridResultsSintetico.Visible = False
                gridResults.Visible = False
                gridResultsCoop.Visible = False
                lbl_informativo.Visible = True
                txt_nr_dia_ini.ToolTip = String.Empty
                txt_nr_dia_fim.ToolTip = String.Empty
                txt_nr_dia_ini.Enabled = True
                txt_nr_dia_fim.Enabled = True
                cbo_Grupo.Items.RemoveAt(0)   ' Remove item selecione
                cbo_Grupo.SelectedValue = 1  ' Assume como default na consulta o Produtor

        End Select

    End Sub

    Protected Sub gridResultsSintetico_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsSintetico.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsSintetico.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_dt_referencia As Label = CType(e.Row.FindControl("lbl_dt_referencia"), Label)
            Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)

            lbl_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMM/yyyy")

            If (Not lbl_nr_volume.Text.Equals(String.Empty) And Not lbl_nr_volume.Text = "&nbsp;") Then
                lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0).ToString()
            End If
        End If

    End Sub
    Protected Sub gridResultsCoop_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsCoop.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsCoop_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsCoop.RowCreated
        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then


            e.Row.Cells(0).RowSpan = 2
            e.Row.Cells(1).RowSpan = 2
            e.Row.Cells(2).RowSpan = 2
            e.Row.Cells(3).RowSpan = 2
            e.Row.Cells(4).RowSpan = 2
            e.Row.Cells(0).Text = "UF"
            e.Row.Cells(1).Text = "Cidade"
            e.Row.Cells(2).Text = "Código"
            e.Row.Cells(3).Text = "Cooperativa"
            e.Row.Cells(4).Text = "Cód.SIF"

            'varre a partir da 5 coluna
            For i = 5 To e.Row.Cells.Count - 1
                laux = e.Row.Cells(i).Text.ToString.Trim 'pega o valor da coluna (que é o dia do mes)
                e.Row.Cells(i).Text = Right(String.Concat("0", laux.ToString, Right(DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("dd/MM/yy"), 6)), 8).ToString
            Next i


        End If
    End Sub

    Protected Sub gridResultsCoop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsCoop.RowDataBound

        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then

        End If
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            If e.Row.RowIndex = 0 Then
                For i = 5 To e.Row.Cells.Count - 1

                    e.Row.Cells(i).BackColor = System.Drawing.Color.FromName("#006699")
                    e.Row.Cells(i).ForeColor = Drawing.Color.White
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
                    e.Row.Cells(i).Text = "Volume"
                Next i

                e.Row.Cells.RemoveAt(0) ' remove uf
                e.Row.Cells.RemoveAt(0) 'remove cidade
                e.Row.Cells.RemoveAt(0) ' remove cdo cooperativa
                e.Row.Cells.RemoveAt(0) 'remove nome cooperativa
                e.Row.Cells.RemoveAt(0) ' remove cd sif

            Else
                'se linha 1
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(1).Wrap = False
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(3).Wrap = False
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center


                'varre a partir da 5 coluna
                For i = 5 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right

                    If (Not e.Row.Cells(i).Text.Equals(String.Empty) And Not e.Row.Cells(i).Text = "&nbsp;") Then
                        e.Row.Cells(i).Text = FormatNumber(e.Row.Cells(i).Text, 0).ToString()
                    End If
                Next i
            End If
        End If


    End Sub

End Class
