Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_CIQT
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tirado em 16/11/2008 (para não ocrrer erro de acesso negado)
        'customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
        If Not Page.IsPostBack Then

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio_compartimento") Is Nothing) Then
                ViewState.Item("id_romaneio_compartimento") = Request("id_romaneio_compartimento")   ' Produtor
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

            Dim CIQT As New Romaneio_Compartimento


            CIQT.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))

            Dim ds_ciqt As DataSet = CIQT.getRelatorioCIQT

            If ds_ciqt.Tables(0).Rows.Count > 0 Then
                With ds_ciqt.Tables(0).Rows(0)
                    Me.lbl_nr_ciqt.Text = CIQT.id_romaneio_compartimento.ToString & .Item("id_transportador").ToString
                    Me.lbl_nr_ciq.Text = .Item("id_romaneio_compartimento")
                    Me.lbl_id_romaneio.Text = .Item("id_romaneio").ToString
                    Me.lbl_emitente.Text = .Item("nm_analista")
                    'Se tem analista cadastrado
                    If Not lbl_emitente.Text.Trim.Equals(String.Empty) Then
                        'se  é o login
                        Dim usuario As New Usuario
                        usuario.ds_login = .Item("nm_analista")
                        Dim dsusuario As DataSet = usuario.getUsuarioByFilters
                        If dsusuario.Tables(0).Rows.Count > 0 Then
                            'Pega o nome do usuario
                            lbl_emitente.Text = dsusuario.Tables(0).Rows(0).Item("nm_usuario")
                        End If
                    End If

                    Me.lbl_data.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
                    Me.lbl_copias.Text = "DAL, Técnico, Transportador"
                    Me.lbl_transportador.Text = .Item("nm_abreviado_transportador")
                    Me.lbl_placa.Text = .Item("ds_placa")
                    Me.lbl_nr_compartimento.Text = .Item("nr_compartimento").ToString & " - " & .Item("nm_compartimento")

                    'Assume que os total não conforme é o total do compartimento
                    Me.lbl_qtd_nao_conforme.Text = FormatNumber(.Item("nr_total_litros"), 0).ToString
                    Me.lbl_qtd_rejeitada.Text = FormatNumber(.Item("nr_total_litros"), 0).ToString

                    If Not IsDBNull(.Item("nr_nota_fiscal")) Then
                        Me.lbl_rota.Text = .Item("nr_nota_fiscal")
                        Me.lbl_rota_nota.Text = "Nota Fiscal"
                        If Not (.Item("nm_abreviado_cooperativa").Equals(String.Empty)) Then
                            Me.lbl_id_romaneio.Text = String.Concat(lbl_id_romaneio.Text.ToString, " - ", "Cooperativa ", .Item("nm_abreviado").ToString)
                        End If
                        Me.lbl_qtd_recebida.Text = FormatNumber(.Item("nr_peso_liquido_nota"), 0).ToString

                    Else
                        Me.lbl_rota_nota.Text = "Rota"
                        If Not IsDBNull(.Item("nm_linha")) Then
                            Me.lbl_rota.Text = .Item("nm_linha")
                        End If
                        Me.lbl_qtd_recebida.Text = FormatNumber(.Item("nr_peso_liquido_caderneta"), 0).ToString

                    End If

                    Me.lbl_dt_recebimento.Text = DateTime.Parse(.Item("dt_hora_entrada")).ToString("dd/MM/yyyy")
                    Me.lbl_disposicao.Text = "Descartado"
                End With

                Dim ds_ciq_analise As DataSet = CIQT.getRelatorioCIQ_Analises
                ViewState.Item("antibiotico") = "N"
                If ds_ciq_analise.Tables(0).Rows.Count > 0 Then
                    grdresults.Visible = True
                    grdresults.DataSource = Helper.getDataView(ds_ciq_analise.Tables(0), ViewState.Item("sortExpression"))
                    grdresults.DataBind()
                End If

            End If


            If ViewState.Item("antibiotico") = "S" Then
                Me.lbl_disposicao.Text = "Descarte na Estação de Tratamento de Efluentes Industriais da Danone"
            Else
                Me.lbl_disposicao.Text = "Encaminhado para destinação conforme norma complementar específica"
            End If



        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub grdresults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Dim lbl_nr_valor_int As Label = CType(e.Row.FindControl("lbl_nr_valor_int"), Label)
                Dim lbl_nr_valor_dec As Label = CType(e.Row.FindControl("lbl_nr_valor_dec"), Label)
                Dim lbl_nr_valor_logica As Label = CType(e.Row.FindControl("lbl_nr_valor_logico"), Label)
                Dim lbl_cd_analise As Label = CType(e.Row.FindControl("lbl_cd_analise"), Label)
                If Not (id_formato_analise Is Nothing) Then

                    Select Case id_formato_analise.Text.Trim
                        Case "1" 'Decimal
                            lbl_nr_valor_dec.Visible = True
                            lbl_nr_valor_int.Visible = False
                            lbl_nr_valor_logica.Visible = False
                        Case "2" 'Inteiro
                            lbl_nr_valor_dec.Visible = False
                            lbl_nr_valor_int.Visible = True
                            lbl_nr_valor_logica.Visible = False
                            lbl_nr_valor_int.Text = CInt(lbl_nr_valor_int.Text)
                        Case "3" 'Logico
                            lbl_nr_valor_dec.Visible = False
                            lbl_nr_valor_int.Visible = False
                            lbl_nr_valor_logica.Visible = True
                    End Select
                End If
                If Not lbl_cd_analise.Text.Equals(String.Empty) Then
                    'Se antibiotico
                    If lbl_cd_analise.Text.Trim = "63" OrElse lbl_cd_analise.Text.Trim = "4" OrElse lbl_cd_analise.Text.Trim = "5" Then

                        ViewState.Item("antibiotico") = "S"
                    End If
                End If

            Catch ex As Exception
                messagecontrol.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
