Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_CIQP
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

            If Not (Request("id_romaneio_uproducao") Is Nothing) Then
                ViewState.Item("id_romaneio_uproducao") = Request("id_romaneio_uproducao")   ' Produtor
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

            Dim CIQP As New Romaneio_Comp_UProducao


            CIQP.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))

            Dim ds_ciqp As DataSet = CIQP.getRelatorioCIQP

            If ds_ciqp.Tables(0).Rows.Count > 0 Then
                With ds_ciqp.Tables(0).Rows(0)
                    Me.lbl_nr_ciqp.Text = CIQP.id_romaneio_uproducao.ToString
                    Me.lbl_nr_ciq.Text = .Item("id_romaneio_compartimento")
                    Me.lbl_emitente.Text = .Item("nm_analista")
                    'Fran 22/05/2009 i rls17.5 chamado 260 CIQ
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
                    Me.lbl_id_romaneio.Text = .Item("id_romaneio")
                    'Fran 22/05/2009 f

                    Me.lbl_data.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
                    Me.lbl_copias.Text = "DAL, Técnico, Produtor"
                    Me.lbl_produtor.Text = .Item("nm_produtor")
                    Me.lbl_placa.Text = .Item("ds_placa")
                    ' 07/04/2009 - Rls 17.3 - i
                    'If Not IsDBNull(.Item("id_linha")) Then
                    '    Me.lbl_rota.Text = .Item("id_linha")
                    'End If
                    If Not IsDBNull(.Item("nm_linha")) Then
                        Me.lbl_rota.Text = .Item("nm_linha")
                    End If
                    ' 07/04/2009 - Rls 17.3 - f
                    If Not IsDBNull(.Item("nm_tecnico")) Then
                        Me.lbl_tecnico.Text = .Item("nm_tecnico")
                    End If

                    Me.lbl_dt_recebimento.Text = DateTime.Parse(.Item("dt_hora_entrada")).ToString("dd/MM/yyyy")
                    'Fran 22/05/2009 i rls17.5 chamado 260 CIQ
                    'Me.lbl_qtd_recebida.Text = .Item("nr_litros")
                    'Me.lbl_qtd_nao_conforme.Text = .Item("nr_litros")
                    Me.lbl_qtd_recebida.Text = FormatNumber(.Item("nr_peso_liquido_caderneta"), 0).ToString
                    'Assume que os total não conforme é o total do compartimento
                    Dim romaneiocomp As New Romaneio_Compartimento(Convert.ToInt32(lbl_nr_ciq.Text.Trim))
                    Me.lbl_qtd_nao_conforme.Text = FormatNumber(romaneiocomp.nr_total_litros, 0).ToString
                    'Fran 22/05/2009 f
                    Me.lbl_qtd_rejeitada.Text = FormatNumber(.Item("nr_litros"), 0).ToString
                    'Fran 22/05/2009 i rls17.5 chamado 260 CIQ
                    'Me.lbl_propriedade.Text = .Item("id_propriedade").ToString & " - " & .Item("nm_propriedade").ToString
                    Me.lbl_propriedade.Text = .Item("id_propriedade").ToString & "-" & .Item("nr_unid_producao").ToString & "  " & .Item("nm_propriedade").ToString
                    'Fran 22/05/2009 f
                    Me.lbl_disposicao.Text = "Descartado"
                End With
            End If

            Dim ds_ciqp_analise As DataSet = CIQP.getRelatorioCIQP_Analises
            ViewState.Item("antibiotico") = "N"
            If ds_ciqp.Tables(0).Rows.Count > 0 Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(ds_ciqp_analise.Tables(0), ViewState.Item("sortExpression"))
                grdresults.DataBind()
            End If

            'Fran 22/05/2009 i rls17.5 chamado 260 CIQ
            If ViewState.Item("antibiotico") = "S" Then
                'fran 06/2019i
                '  Me.lbl_disposicao.Text = "Descartado"
                Me.lbl_disposicao.Text = "Descarte na Estação de Tratamento de Efluentes Industriais da Danone"
                'fran 06/2019 f
            Else
                'fran 06/2019i
                'Me.lbl_disposicao.Text = "Devolução ao Fornecedor"
                Me.lbl_disposicao.Text = "Encaminhado para destinação conforme norma complementar específica"
                'fran 06/2019i
            End If
            'Fran 22/05/2009 f 



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
                'Fran 22/05/2009 i rls17.5 chamado 260 CIQ
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
                'Fran 22/05/2009 f

            Catch ex As Exception
                messagecontrol.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
