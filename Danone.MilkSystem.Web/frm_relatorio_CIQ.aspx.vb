Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_CIQ
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

            Dim CIQ As New Romaneio_Compartimento


            CIQ.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))

            Dim ds_ciq As DataSet = CIQ.getRelatorioCIQ

            If ds_ciq.Tables(0).Rows.Count > 0 Then
                With ds_ciq.Tables(0).Rows(0)
                    Me.lbl_nr_ciq.Text = CIQ.id_romaneio_compartimento.ToString
                    'Me.lbl_romaneio.Text = .Item("ïd_romaneio").ToString 'fran 28/12/2009 i chamado 594
                    Me.lbl_romaneio.Text = .Item("id_romaneio").ToString 'adri 28/12/2009 i chamado 594
                    'Me.lbl_nr_ciq.Text = ""
                    Me.lbl_emitente.Text = .Item("nm_analista")
                    'Fran 17/03/2009 i rls17 CIQ
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
                    'Fran 17/03/2009 f
                    Me.lbl_data.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")

                    ' 29/09/2008 - i
                    'Dim emails As New Notificacao
                    ''Tipo Notificacao CIQ
                    'emails.id_tipo_notificacao = 1
                    'emails.id_situacao = 1
                    'Dim ds_emails As DataSet = emails.getNotificacoesByFilters
                    'Dim row As DataRow
                    'If ds_emails.Tables(0).Rows.Count > 0 Then
                    '    For Each row In ds_emails.Tables(0).Rows
                    '        lbl_copias.Text = lbl_copias.Text & row.Item("ds_email").ToString & "; "
                    '    Next
                    'Else
                    '    Me.lbl_copias.Text = "Não há emails cadastrados"
                    'End If
                    lbl_copias.Text = "DPT / CQ / SUP"
                    ' 29/09/2008 - i

                    Me.lbl_placa.Text = .Item("ds_placa")
                    If Not IsDBNull(.Item("nr_nota_fiscal")) Then
                        Me.lbl_rota_nota.Text = .Item("nr_nota_fiscal")
                        Me.lbl_label_rota_nota.Text = "Nota Fiscal"
                        'Fran 09/01/2011 i rls 27
                        If Not (.Item("nm_abreviado").Equals(String.Empty)) Then
                            Me.lbl_romaneio.Text = String.Concat(lbl_romaneio.Text.ToString, " - ", "Cooperativa ", .Item("nm_abreviado").ToString)
                        End If
                        'Fran 09/01/2011 f rls 27
                    Else
                        Me.lbl_label_rota_nota.Text = "Rota"
                        ' 07/04/2009 - Rls 17.3 - i
                        'If Not IsDBNull(.Item("id_linha")) Then
                        '    Me.lbl_rota_nota.Text = .Item("id_linha")
                        'End If
                        If Not IsDBNull(.Item("nm_linha")) Then
                            Me.lbl_rota_nota.Text = .Item("nm_linha")
                        End If
                        ' 07/04/2009 - Rls 17.3 - f
                    End If
                    Me.lbl_dt_recebimento.Text = DateTime.Parse(.Item("dt_hora_entrada")).ToString("dd/MM/yyyy")
                    Me.lbl_dt_inicio_analise.Text = DateTime.Parse(.Item("dt_inicio_analise")).ToString("dd/MM/yyyy")
                    Me.lbl_nm_item.Text = .Item("nm_item")
                    Me.lbl_nr_compartimento.Text = .Item("nr_compartimento").ToString & " - " & .Item("nm_compartimento")
                    Me.lbl_qtd_nao_conforme.Text = .Item("nr_total_litros")
                    Me.lbl_qtd_rejeitada.Text = .Item("nr_total_litros")
                    Me.lbl_disposicao.Text = "Descarta"
                End With
            End If

            Dim ds_ciq_analise As DataSet = CIQ.getRelatorioCIQ_Analises
            ViewState.Item("antibiotico") = "N"

            If ds_ciq.Tables(0).Rows.Count > 0 Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(ds_ciq_analise.Tables(0), ViewState.Item("sortExpression"))
                grdresults.DataBind()
            End If
            'Fran 17/03/2009 i rls17
            If ViewState.Item("antibiotico") = "S" Then
                'fran 06/2019i
                '  Me.lbl_disposicao.Text = "Descarta"
                Me.lbl_disposicao.Text = "Descarte na Estação de Tratamento de Efluentes Industriais da Danone"
                'fran 06/2019 f

            Else
                'fran 06/2019i
                'Me.lbl_disposicao.Text = "Devolução ao Fornecedor"
                Me.lbl_disposicao.Text = "Encaminhado para destinação conforme norma complementar específica"
                'fran 06/2019i

            End If
            'Fran 17/03/2009 f rls17


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
                'Fran 17/03/2009 i rls 17
                If Not lbl_cd_analise.Text.Equals(String.Empty) Then
                    'Se antibiotico
                    'Fran  03/2014 fase 2 melhorias i - A analise 21foi inativada. O Descarte agora fica por conta da 63 DEVOLTEST
                    'If lbl_cd_analise.Text.Trim = "21" Then
                    'fran 06/2019 i incluindo alizarol
                    'If lbl_cd_analise.Text.Trim = "63" Then
                    If lbl_cd_analise.Text.Trim = "63" OrElse lbl_cd_analise.Text.Trim = "4" OrElse lbl_cd_analise.Text.Trim = "5" Then
                        'fran 06/2019 f
                        'Fran  03/2014 fase 2 melhorias f
                        ViewState.Item("antibiotico") = "S"
                    End If
                End If
                'Fran 17/03/2009 f rls 17
            Catch ex As Exception
                messagecontrol.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
