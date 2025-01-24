Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_preromaneio_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then
            Dim lberro As Boolean = False

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
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
                'fran 07/2022
                If ViewState.Item("menu") = "transitpoint" Then

                    If ViewState.Item("id_estabelecimento") <> "0" Then
                        cbo_transit_point.Enabled = True

                        Dim transit As New TransitPointUnidade

                        transit.id_estabelecimento = cbo_estabelecimento.SelectedValue
                        transit.id_situacao = 1 'ativo

                        cbo_transit_point.DataSource = transit.getTransitPointUnidadeByFilters()
                        cbo_transit_point.DataTextField = "ds_transit_point_unidade"
                        cbo_transit_point.DataValueField = "id_transit_point_unidade"
                        cbo_transit_point.DataBind()
                        cbo_transit_point.Items.Insert(0, New ListItem("[Selecione]", "0"))
                        cbo_transit_point.SelectedValue = 0
                    Else
                        cbo_transit_point.Items.Clear()
                        cbo_transit_point.Enabled = False
                    End If
                End If

                loadData()

            End If
        End If


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        'fran 07/2022
        If ViewState.Item("menu") = "transitpoint" Then
            Response.Redirect("lst_romaneio_preromaneio_caderneta.aspx?st_incluirlog=N")
        Else
            Response.Redirect("lst_romaneio_preromaneio_caderneta.aspx?id=2&st_incluirlog=N")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_preromaneio_caderneta.aspx")

        If Not Page.IsPostBack Then

            'fran 07/2022 transvase
            If Not Request("id") Is Nothing Then
                ViewState.Item("menu") = "transvase"
                lbl_unidade_transit_point.Visible = False
                cbo_transit_point.Visible = False
                rf_transitpoint.Visible = False
                cv_abrirpreromaneio.Visible = False
                lbl_titulo.Text = "Abertura do Pré Romaneio para Transvase"
            Else
                ViewState.Item("menu") = "transitpoint"
                lbl_titulo.Text = "Abertura do Pré Romaneio para Transit Point"

            End If


            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                'fran 07/2022
                If ViewState.Item("menu") = "transitpoint" Then
                    usuariolog.id_menu_item = 164
                Else
                    usuariolog.id_menu_item = 227 'pre romaneio transvase
                End If
                usuariolog.insertUsuarioLog()
            End If
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


            Try

                Dim estabelecimento As New Estabelecimento

                cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
                cbo_estabelecimento.DataTextField = "nm_estabelecimento"
                cbo_estabelecimento.DataValueField = "id_estabelecimento"
                cbo_estabelecimento.DataBind()
                cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

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

                'loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("preromaneio", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("preromaneio", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If

        If Not (customPage.getFilterValue("preromaneio", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("preromaneio", txt_cd_transportador.ID)
            txt_cd_transportador.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If

        If Not (customPage.getFilterValue("preromaneio", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("preromaneio", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("preromaneio", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("preromaneio", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If

        If Not (customPage.getFilterValue("preromaneio", txt_dt_transmissao_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_ini") = customPage.getFilterValue("preromaneio", txt_dt_transmissao_ini.ID)
            txt_dt_transmissao_ini.Text = ViewState.Item("dt_transmissao_ini").ToString()
            ViewState.Item("dt_transmissao_fim") = customPage.getFilterValue("preromaneio", txt_dt_transmissao_fim.ID)
            txt_dt_transmissao_fim.Text = ViewState.Item("dt_transmissao_fim").ToString()
        Else
            ViewState.Item("dt_transmissao_ini") = String.Empty
            ViewState.Item("dt_transmissao_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("preromaneio", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("preromaneio", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("caderneta")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim caderneta As New Caderneta

            If ViewState.Item("id_estabelecimento").ToString.Equals(9) Then 'se maracanau
                caderneta.ds_estabelecimento = "9"
            Else
                caderneta.ds_estabelecimento = "1|2|6"
            End If

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
                'cbo_transit_point.Items.Clear()
                'cbo_transit_point.Enabled = False
                'fran 07/2022
                If ViewState.Item("menu") = "transitpoint" Then
                    lbl_unidade_transit_point.Visible = True
                End If
                ' rfv_nota_transf.Visible = True
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCadernetaHeader.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                lbl_unidade_transit_point.Visible = False
                gridResults.Visible = False
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

                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
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

            customPage.setFilter("preromaneio", txt_nr_caderneta.ID, ViewState.Item("nr_caderneta").ToString)
            customPage.setFilter("preromaneio", txt_cd_transportador.ID, ViewState.Item("cd_cnh").ToString)
            customPage.setFilter("preromaneio", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("preromaneio", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("preromaneio", txt_dt_transmissao_ini.ID, ViewState.Item("dt_transmissao_ini").ToString)
            customPage.setFilter("preromaneio", txt_dt_transmissao_fim.ID, ViewState.Item("dt_transmissao_fim").ToString)
            customPage.setFilter("preromaneio", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Dim id_romaneio As Int32
             Dim lmsg As String
        Select Case e.CommandName.ToString().ToLower()
            Case "selecionar"
                'Dim strmessage As String
                If Page.IsValid Then

                    saveFilters()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    'fran 07/2022
                    If ViewState.Item("menu") = "transitpoint" Then
                        usuariolog.id_menu_item = 164
                    Else
                        usuariolog.id_menu_item = 227
                    End If
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    'fran 07/2022
                    If ViewState.Item("menu") = "transitpoint" Then
                        id_romaneio = abrirPreRomaneio(Convert.ToInt32(e.CommandArgument.ToString), ViewState.Item("id_estabelecimento").ToString, cbo_transit_point.SelectedValue)

                        If id_romaneio > 0 Then
                            lmsg = "O Pré-Romaneio da caderneta " + e.CommandArgument.ToString + ", para a unidade de Transit Point " + cbo_transit_point.SelectedItem.Text + ", foi aberto com o número " + id_romaneio.ToString + ". Este número assegura o processo de abertura do pré-romaneio e registro das análises."
                            Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=lst_romaneio_preromaneio_caderneta.aspx")
                        End If
                    Else
                        id_romaneio = abrirPreRomaneioTransvase(Convert.ToInt32(e.CommandArgument.ToString), ViewState.Item("id_estabelecimento").ToString)

                        If id_romaneio > 0 Then
                            lmsg = "O Pré-Romaneio da caderneta " + e.CommandArgument.ToString + ", para Transvase de " + cbo_estabelecimento.SelectedItem.Text + ", foi aberto com o número " + id_romaneio.ToString + ". Este número assegura o processo de abertura do pré-romaneio."
                            Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=lst_romaneio_preromaneio_caderneta.aspx?id=2")
                        End If

                    End If

                End If


        End Select

    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub


    Private Function abrirPreRomaneio(ByVal nr_caderneta As Int32, ByVal id_estabelecimento As Int32, ByVal id_transit_point_unidade As Int32) As Int32
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio()

                romaneio.nr_caderneta = Convert.ToInt32(nr_caderneta)
                romaneio.id_estabelecimento = Convert.ToInt32(id_estabelecimento)
                romaneio.id_transit_point_unidade = Convert.ToInt32(id_transit_point_unidade)
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.romaneio_uproducao.id_modificador = Session("id_login")

                romaneio.id_romaneio = Convert.ToInt32(romaneio.abrirPreRomaneioTransitPoint())

                romaneio.insertRomaneioAnaliseCompartimento()

                Return romaneio.id_romaneio

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Function

    Private Function abrirPreRomaneioTransvase(ByVal nr_caderneta As Int32, ByVal id_estabelecimento As Int32) As Int32
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio()

                romaneio.nr_caderneta = Convert.ToInt32(nr_caderneta)
                romaneio.id_estabelecimento = Convert.ToInt32(id_estabelecimento)
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.romaneio_uproducao.id_modificador = Session("id_login")

                romaneio.id_romaneio = Convert.ToInt32(romaneio.abrirPreRomaneioTransvase())

                'romaneio.insertRomaneioAnaliseCompartimento()

                Return romaneio.id_romaneio

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

    Protected Sub cv_abrirpreromaneio_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_abrirpreromaneio.ServerValidate
        Try
            Dim lmsg As String
            If (cbo_transit_point.SelectedValue.Trim.Equals("0")) Then
                lmsg = "A unidade de Transit Point deve ser preenchida para a abertura do Pré-Romaneio de Transit Point."
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim ds_tempo_coleta_now As Label = CType(e.Row.FindControl("ds_tempo_coleta_now"), Label)
                Dim img_editar As Anthem.ImageButton = CType(e.Row.FindControl("img_editar"), Anthem.ImageButton)

                If Not ds_tempo_coleta_now.Text.Equals(String.Empty) Then
                    If CDec(ds_tempo_coleta_now.Text) > 0 Then
                        img_editar.Enabled = True
                        img_editar.ImageUrl = "~/img/ico_tanktruck_yellow.gif"
                    Else
                        img_editar.Enabled = False
                        img_editar.ImageUrl = "~/img/ico_tanktruck_desabilitado.gif"
                        img_editar.ToolTip = "Não pode ser Aberto! Data de Coleta é MAIOR que a data/hora atual."
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
