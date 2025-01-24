Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_transbordo_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Dim lberro As Boolean = False

        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("cd_cnh") = txt_cd_transportador.Text.Trim.ToString
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim.ToString
        If txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_transmissao_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_transmissao_ini.Text = txt_dt_transmissao_fim.Text
            End If
        End If
        If txt_dt_transmissao_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_transmissao_fim.Text = txt_dt_transmissao_ini.Text
            End If
        End If
        ViewState.Item("dt_transmissao_ini") = txt_dt_transmissao_ini.Text.Trim.ToString
        ViewState.Item("dt_transmissao_fim") = txt_dt_transmissao_fim.Text.Trim.ToString
        If Not txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_transmissao_ini.Text) > CDate(txt_dt_transmissao_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de transmissão inicial deve ser menor do que a data de transmissão final!")
            End If
        End If

        If lberro = False Then

            loadData()

        End If


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        txt_nr_caderneta.Text = String.Empty
        txt_placa.Text = String.Empty
        txt_cd_transportador.Text = String.Empty
        txt_nm_linha.Text = String.Empty
        txt_dt_transmissao_ini.Text = String.Empty
        txt_dt_transmissao_fim.Text = String.Empty

        ViewState.Item("nr_caderneta") = String.Empty
        ViewState.Item("ds_placa") = String.Empty
        ViewState.Item("cd_cnh") = String.Empty
        ViewState.Item("nm_linha") = String.Empty
        ViewState.Item("dt_transmissao_ini") = String.Empty
        ViewState.Item("dt_transmissao_fim") = String.Empty

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_transbordo_caderneta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 20
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With bt_lupa_veiculo
            .Attributes.Add("onclick", "javascript:ShowDialogVeiculo()")
            .ToolTip = "Filtrar Veículos"
            '.Style("cursor") = "hand"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            'inicializa filtros com vazio apenas com data de transmissao, e carrega grid de caderneta
            txt_nr_caderneta.Text = String.Empty
            txt_placa.Text = String.Empty
            txt_cd_transportador.Text = String.Empty
            txt_nm_linha.Text = String.Empty
            txt_dt_transmissao_ini.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            txt_dt_transmissao_fim.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            ViewState.Item("nr_caderneta") = String.Empty
            ViewState.Item("ds_placa") = String.Empty
            ViewState.Item("cd_cnh") = String.Empty
            ViewState.Item("nm_linha") = String.Empty
            ViewState.Item("dt_transmissao_ini") = txt_dt_transmissao_ini.Text.Trim.ToString
            ViewState.Item("dt_transmissao_fim") = txt_dt_transmissao_fim.Text.Trim.ToString
            ViewState.Item("listacadernetas") = String.Empty 'utilizada para guardar as cadernetas que participam do transbordo
            ViewState.Item("gridcadernetaadicionada") = "N" 'assume que nao tem nenhuma caderneta adicionada para o transbordo
            ViewState.Item("sortExpression") = "dt_transmissao desc"

            loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim caderneta As New Caderneta

            If Not (ViewState.Item("nr_caderneta").ToString.Equals(String.Empty)) Then
                caderneta.nr_caderneta = Convert.ToInt32(ViewState.Item("nr_caderneta").ToString())
            End If
            caderneta.cd_transportador = ViewState.Item("cd_cnh").ToString()
            caderneta.ds_placa = ViewState.Item("ds_placa").ToString()
            caderneta.st_leite_desviado = "N"
            caderneta.nm_linha = ViewState.Item("nm_linha").ToString
            caderneta.dt_transmissao_ini = ViewState.Item("dt_transmissao_ini").ToString
            caderneta.dt_transmissao_fim = ViewState.Item("dt_transmissao_fim").ToString

            Dim dsCadernetaHeader As DataSet = caderneta.getRomaneioCadernetaByFilters()

            If (dsCadernetaHeader.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCadernetaHeader.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                Dim dr As DataRow = dsCadernetaHeader.Tables(0).NewRow()
                dsCadernetaHeader.Tables(0).Rows.InsertAt(dr, 0)
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCadernetaHeader.Tables(0), "")
                gridResults.DataBind()
                gridResults.Rows(0).Cells.Clear()
                gridResults.Rows(0).Cells.Add(New TableCell())
                gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridResults.Rows(0).Cells(0).Text = "Nenhum registro foi encontrado com os filtros utilizados. Por favor tente novamente."
                gridResults.Rows(0).Cells(0).ColumnSpan = 6
            End If

            loadgridtransbordo()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadgridtransbordo()

        Try

            Dim dstable As New DataTable
            Dim ilinha As Integer
            'se ja tem linha no transbordo
            If ViewState.Item("gridcadernetaadicionada").ToString.Equals("S") Then
                'guarda dstable
                dstable = CType(ViewState.Item("gridtransbordo"), DataTable)

                gridresultstransbordo.Visible = True
                gridresultstransbordo.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
                gridresultstransbordo.DataBind()
            Else
                ilinha = 0
                'prepara a dstable
                dstable.Columns.Add("id_protocolo")
                dstable.Columns.Add("ds_motorista")
                dstable.Columns.Add("ds_placa")
                dstable.Columns.Add("nm_linha")
                dstable.Columns.Add("dt_transmissao")
                dstable.Columns.Add("st_excluir")

                Dim dr As DataRow = dstable.NewRow()
                dstable.Rows.InsertAt(dr, 0)
                gridresultstransbordo.Visible = True
                gridresultstransbordo.DataSource = Helper.getDataView(dstable, "")
                gridresultstransbordo.DataBind()
                gridresultstransbordo.Rows(0).Cells.Clear()
                gridresultstransbordo.Rows(0).Cells.Add(New TableCell())
                gridresultstransbordo.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridresultstransbordo.Rows(0).Cells(0).Text = "Nenhuma caderneta foi adicionada para Transbordo."
                gridresultstransbordo.Rows(0).Cells(0).ColumnSpan = 6
            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub
    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()
            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If


            Case "nr_caderneta"
                If (ViewState.Item("sortExpression")) = "id_protocolo asc" Then
                    ViewState.Item("sortExpression") = "id_protocolo desc"
                Else
                    ViewState.Item("sortExpression") = "id_protocolo asc"
                End If


            Case "ds_motorista"
                If (ViewState.Item("sortExpression")) = "ds_motorista asc" Then
                    ViewState.Item("sortExpression") = "ds_motorista desc"
                Else
                    ViewState.Item("sortExpression") = "ds_motorista asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If
            Case "dt_transmissao"
                If (ViewState.Item("sortExpression")) = "dt_transmissao asc" Then
                    ViewState.Item("sortExpression") = "dt_transmissao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_transmissao asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("romaneiotransbordo", "listacadernetas", ViewState.Item("listacadernetas").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()
            Case "incluirnotransbordo"

                retirarCadernetaGridResults(Convert.ToInt32(e.CommandArgument.ToString()))


        End Select

    End Sub
    Private Sub retirarCadernetaGridResults(ByVal id_index_row As Integer)

        Try
            Dim dstable As New DataTable
            Dim ilinha As Integer


            'Guarda as cadernetas do grid de caderbnetas transbordo
            ViewState.Item("listacadernetas") = String.Concat(ViewState.Item("listacadernetas").ToString, "'", gridResults.DataKeys.Item(id_index_row).Value.ToString, "'")

            'se já tem linhas no grid de cadernetas de transbordo
            If ViewState.Item("gridcadernetaadicionada").ToString.Equals("S") Then
                'restaura grid guardado na dstable
                dstable = CType(ViewState.Item("gridtransbordo"), DataTable)
                'adiciona uma linha ao nr linha do grid transbordo
                ilinha = dstable.Rows.Count
            Else
                'se ainda nao tem 
                ilinha = 0
                'prepara a dstable
                dstable.Columns.Add("id_protocolo")
                dstable.Columns.Add("ds_motorista")
                dstable.Columns.Add("ds_placa")
                dstable.Columns.Add("nm_linha")
                dstable.Columns.Add("dt_transmissao")
                dstable.Columns.Add("st_excluir")

                ViewState.Item("gridcadernetaadicionada") = "S"

            End If

            'pega os dados da caderneta selecionada
            Dim lsprotocolo_results As DataControlFieldCell = CType(gridResults.Rows(id_index_row).Cells(0), DataControlFieldCell)
            Dim lsmotorista_results As DataControlFieldCell = CType(gridResults.Rows(id_index_row).Cells(1), DataControlFieldCell)
            Dim lsplaca_results As DataControlFieldCell = CType(gridResults.Rows(id_index_row).Cells(2), DataControlFieldCell)
            Dim lsrota_results As DataControlFieldCell = CType(gridResults.Rows(id_index_row).Cells(3), DataControlFieldCell)
            Dim lstransmissao_results As DataControlFieldCell = CType(gridResults.Rows(id_index_row).Cells(4), DataControlFieldCell)

            'adiciona linha na dstable
            dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
            'atribui valores na dstable do transbordo
            With dstable.Rows.Item(ilinha)
                .Item(0) = lsprotocolo_results.Text.ToString
                .Item(1) = lsmotorista_results.Text.ToString
                .Item(2) = lsplaca_results.Text.ToString
                .Item(3) = lsrota_results.Text.ToString
                .Item(4) = lstransmissao_results.Text.ToString
                .Item(5) = String.Empty
            End With

            'guarda dstable
            ViewState.Item("gridtransbordo") = dstable

            loadgridtransbordo()

            'retira a caderneta do gridresults
            gridResults.Rows(id_index_row).Visible = False

            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub
    Private Function abrirRomaneio(ByVal nr_caderneta As Int32) As Int32
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio()

                romaneio.nr_caderneta = Convert.ToInt32(nr_caderneta)
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.romaneio_uproducao.id_modificador = Session("id_login")

                Return Convert.ToInt32(romaneio.abrirRomaneio())

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Function
    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa.ServerValidate
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim ds_tempo_coleta_now As Label = CType(e.Row.FindControl("ds_tempo_coleta_now"), Label)

                Dim btnincluircaderneta As ImageButton = CType(e.Row.FindControl("btn_incluir_caderneta"), ImageButton)
                btnincluircaderneta.CommandArgument = e.Row.RowIndex.ToString
                'se a caderneta já foi selecionada para transbordo
                If InStr(1, ViewState.Item("listacadernetas").ToString, "'" & e.Row.Cells(0).Text & "'", CompareMethod.Text) > 0 Then
                    e.Row.Visible = False
                Else
                    e.Row.Visible = True

                    'Se o a data da coleta é maior que a data de agora nao pode abrir transbordo
                    If Not ds_tempo_coleta_now.Text.Equals(String.Empty) Then

                        If CDec(ds_tempo_coleta_now.Text) > 0 Then
                            btnincluircaderneta.Enabled = True
                            btnincluircaderneta.ImageUrl = "~/img/mais_red.gif"
                        Else
                            btnincluircaderneta.Enabled = False
                            btnincluircaderneta.ImageUrl = "~/img/mais_desabilitado.gif"
                            btnincluircaderneta.ToolTip = "Caderneta não pode ser utilizada! Data de Coleta é MAIOR que a data/hora atual."
                        End If
                    End If

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
    Protected Sub gridresultstransbordo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridresultstransbordo.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "retirardotransbordo"
                retirarGridResultsTransbordo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Protected Sub gridresultstransbordo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridresultstransbordo.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                'associa ao botão retirar o index como argumento
                Dim btnretirar As ImageButton = CType(e.Row.FindControl("btn_retirar_caderneta"), ImageButton)
                btnretirar.CommandArgument = e.Row.RowIndex.ToString

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub
    Private Sub retirarGridResultsTransbordo(ByVal id_index_row As Integer)

        Try
            Dim dstable As New DataTable
            Dim ilinha As Integer
            Dim lpos As Integer
            Dim llen As Integer
            Dim lcaderneta As String
            Dim llista_cadernetas As String


            'ACERTA A VIEW DA LISTA DE CADERNETAS QUE PARTICIPAM DO TRANSBORDO********************************************************************************
            lcaderneta = "'" & gridresultstransbordo.DataKeys.Item(id_index_row).Value.ToString & "'"
            llen = Len(lcaderneta)
            lpos = InStr(1, ViewState.Item("listacadernetas").ToString, lcaderneta, CompareMethod.Text) 'sempre deve encontrar a caderneta, pois se esta retirando do grid transbordo foi adicionado no grid results

            llista_cadernetas = ViewState.Item("listacadernetas").ToString
            ViewState.Item("listacadernetas") = Nothing
            ViewState.Item("listacadernetas") = String.Empty

            'retira a caderneta solicitada
            If lpos = 1 Then ' se esta na primeira posição do arquivo
                'pega todas as cadernetas e retira a primeira
                ViewState.Item("listacadernetas") = String.Concat(Mid(llista_cadernetas, lpos + llen)).Trim
            Else
                ViewState.Item("listacadernetas") = String.Concat(Mid(llista_cadernetas, 1, lpos - 1), Mid(llista_cadernetas, lpos + llen)).Trim
            End If

            'se retirou todas as cadernetas, seta que não há linhas adicionadas no grid
            If ViewState.Item("listacadernetas").ToString.Equals(String.Empty) Then
                ViewState.Item("gridcadernetaadicionada") = "N"
                ViewState.Item("gridtransbordo") = String.Empty
            End If

            lcaderneta = Replace(lcaderneta, "'", "")

            'PREPARA A VIEW DO GRID TRANSBORDO **********************************************************************************
            If ViewState.Item("gridcadernetaadicionada").Equals("S") Then
                ilinha = 0
                'prepara a dstable
                dstable.Columns.Add("id_protocolo")
                dstable.Columns.Add("ds_motorista")
                dstable.Columns.Add("ds_placa")
                dstable.Columns.Add("nm_linha")
                dstable.Columns.Add("dt_transmissao")
                dstable.Columns.Add("st_excluir")

                Dim row As GridViewRow
                For Each row In gridresultstransbordo.Rows
                    Dim nr_caderneta As DataControlFieldCell = CType(row.Cells(0), DataControlFieldCell)
                    'se a caderneta a ser retirada é diferente da linha do grid
                    If nr_caderneta.Text.Trim <> lcaderneta.Trim Then
                        Dim ds_motorista As DataControlFieldCell = CType(row.Cells(1), DataControlFieldCell)
                        Dim ds_placa As DataControlFieldCell = CType(row.Cells(2), DataControlFieldCell)
                        Dim nm_rota As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        Dim dt_transmissao As DataControlFieldCell = CType(row.Cells(4), DataControlFieldCell)
                        Dim st_excluir As Label = CType(row.FindControl("st_excluir"), Label)

                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                        With dstable.Rows.Item(ilinha)
                            .Item(0) = nr_caderneta.Text
                            .Item(1) = ds_motorista.Text
                            .Item(2) = ds_placa.Text
                            .Item(3) = nm_rota.Text
                            .Item(4) = dt_transmissao.Text
                        End With
                        ilinha = ilinha + 1
                    End If
                Next
                ViewState.Item("gridtransbordo") = String.Empty
                'guarda dstable
                ViewState.Item("gridtransbordo") = dstable

            Else
                ViewState.Item("gridtransbordo") = Nothing
                ViewState.Item("gridtransbordo") = String.Empty
                ViewState.Item("listacadernetas") = Nothing
                ViewState.Item("listacadernetas") = String.Empty

            End If

            'gridResults.Dispose()
            'gridCadernetasTransbordo.Dispose()
            loadData()
            'loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub cv_cadernetastransbordo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cadernetastransbordo.ServerValidate
        Try

            Dim lmsg As String
            'se não selecionou mais de uma caderneta
            If gridresultstransbordo.Rows.Count < 1 Then
                args.IsValid = False
                'lmsg = "Para prosseguir com a abertura do romaneio com transbordo, mais de uma caderneta devem ser selecionadas!"
                lmsg = "Para prosseguir com a abertura do romaneio com transbordo, ao menos uma caderneta deve ser selecionada!"
            End If
            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_avancar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_avancar.Click
        If Page.IsValid Then
            'salva a lista de cadernetas para a proxima tela
            saveFilters()

            Response.Redirect("frm_romaneio_transbordo_abertura.aspx")

        End If
    End Sub
End Class
