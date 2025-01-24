Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_poupanca_mensal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_poupanca_mensal.aspx")
        If Not Page.IsPostBack Then

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_referencia_ini") Is Nothing) Then
                ViewState.Item("dt_referencia_ini") = Request("dt_referencia_ini")
                ViewState.Item("dt_referencia_fim") = Request("dt_referencia_fim")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                'ViewState.Item("id_unid_producao") = Request("id_unid_producao")
                ViewState.Item("dspropriedade") = Request("dspropriedade")

                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If
        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))

            'Monta cabeçalho
            lbl_dspropriedade.Text = ViewState.Item("dspropriedade").ToString
            lbl_cd_produtor.Text = propriedade.cd_pessoa
            lbl_nm_produtor.Text = propriedade.nm_pessoa
            lbl_ano.Text = DatePart(DateInterval.Year, CDate(ViewState.Item("dt_referencia_fim"))).ToString
            lbl_dtatual.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy").ToString
            Dim poupancamensal As New Poupanca

            poupancamensal.dt_referencia_ini = ViewState.Item("dt_referencia_ini").ToString
            poupancamensal.dt_referencia_fim = ViewState.Item("dt_referencia_fim").ToString
            poupancamensal.id_propriedade = ViewState.Item("id_propriedade")
            poupancamensal.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString

            Dim dsextratopoupancames As DataSet = poupancamensal.getExtratoPoupancaMensal()

            Dim dstable As New DataTable
            Dim ilinha As Integer

            dstable.Columns.Add("ds_mes_referencia")
            dstable.Columns.Add("nr_volume_leite")
            dstable.Columns.Add("nr_cbt")
            dstable.Columns.Add("nr_ccs")
            dstable.Columns.Add("nr_proteina")
            dstable.Columns.Add("nr_mg")
            dstable.Columns.Add("ds_incidente")
            dstable.Columns.Add("nr_valor_bonus")
            dstable.Columns.Add("ds_status")

            Dim row As DataRow
            Dim lnrmes As Int32 = 0
            Dim lvalortotalvolume As Decimal = 0
            Dim lvalortotalbonus As Decimal = 0
            Dim lvalortotalcomprascentral As Decimal = 0
            Dim lvalorbonusspend As Decimal = 0
            ilinha = 0
            'Insere na table
            dstable.Rows.InsertAt(dstable.NewRow(), ilinha) 'insere primeira linha


            For Each row In dsextratopoupancames.Tables(0).Rows
                'se mes anterior igual a mes
                If lnrmes <> CInt(row.Item("nr_mes")) Then
                    'se primeira vez 
                    If lnrmes > 0 Then 'se for outra referencia e não é o primeiro
                        'Insere na table
                        ilinha = ilinha + 1
                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    End If

                    'busca dados 
                    With dstable.Rows.Item(ilinha)
                        Select Case row.Item("nr_mes")
                            Case 1
                                .Item(0) = "Janeiro"
                            Case 2
                                .Item(0) = "Fevereiro"
                            Case 3
                                .Item(0) = "Março"
                            Case 4
                                .Item(0) = "Abril"
                            Case 5
                                .Item(0) = "Maio"
                            Case 6
                                .Item(0) = "Junho"
                            Case 7
                                .Item(0) = "Julho"
                            Case 8
                                .Item(0) = "Agosto"
                            Case 9
                                .Item(0) = "Setembro"
                            Case 10
                                .Item(0) = "Outubro"
                            Case 11
                                .Item(0) = "Novembro"
                            Case 12
                                .Item(0) = "Dezembro"
                        End Select

                        .Item(6) = row.Item("ds_incidente").ToString
                    End With
                End If
                'busca dados 
                With dstable.Rows.Item(ilinha)
                    Select Case (row.Item("id_conta"))
                        Case 1 'Volume
                            lvalortotalvolume = lvalortotalvolume + Convert.ToDecimal(row.Item("nr_valor_conta").ToString)
                            .Item(1) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 0, , , TriState.True)
                        Case 252 'ctm teor
                            .Item(2) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 0, , , TriState.True)
                        Case 253 'ccs teor
                            .Item(3) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 0, , , TriState.True)
                        Case 251 'proteína teor
                            .Item(4) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 4, , , TriState.True)
                        Case 156 'Materia Gorda Teor
                            .Item(5) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 4, , , TriState.True)
                        Case 254 'bonus poupanca mensal
                            lvalortotalbonus = lvalortotalbonus + Convert.ToDecimal(row.Item("nr_valor_conta").ToString)
                            If Convert.ToDecimal(row.Item("nr_valor_conta").ToString) > 0 Then 'se a conta de bonus nao esta zerada
                                .Item(7) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_conta").ToString), 2, , , TriState.True).ToString
                                .Item(8) = "Crédito"
                            Else
                                .Item(7) = String.Empty
                                .Item(8) = "Falhas na Qualidade"
                            End If
                    End Select
                End With
                lnrmes = row.Item("nr_mes").ToString
            Next

            'acrescenta linhas no grid (grid deve ter espaco de 12 meses)
            Do While ilinha < 11
                'Insere na table
                ilinha = ilinha + 1
                dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
            Loop

            ViewState.Item("gridtable") = dstable

            If (dsextratopoupancames.Tables(0).Rows.Count > 0) Then
                gridbonus.Visible = True
                gridbonus.Columns(5).Visible = False
                gridbonus.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
                gridbonus.DataBind()
            Else
                gridbonus.Visible = False
                messagecontrol.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'TOTALIZADORES
            lbl_total_volume.Text = FormatNumber(lvalortotalvolume, 0, , , TriState.True).ToString
            lbl_total_bonus.Text = FormatNumber(lvalortotalbonus, 2, , , TriState.True).ToString
            Dim centralcompras As New Pedido
            centralcompras.dt_inicio = poupancamensal.dt_referencia_ini
            centralcompras.dt_fim = poupancamensal.dt_referencia_fim
            centralcompras.id_propriedade = poupancamensal.id_propriedade
            lbl_nr_compras_central.Text = FormatNumber(centralcompras.getCentralPedidoTotalCompras / lvalortotalvolume, 4, , , TriState.True).ToString
            lbl_bonus_adicional_spend.Text = FormatNumber(lvalortotalbonus * 1.15, 2, , , TriState.True).ToString
  

        Catch ex As Exception

            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    

   
End Class
