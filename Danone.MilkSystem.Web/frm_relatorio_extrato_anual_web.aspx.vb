Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_extrato_anual_web
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_extrato_anual_web.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 155
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("ano_referencia") Is Nothing) Then
                ViewState.Item("ano_referencia") = Request("ano_referencia")
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                ViewState.Item("id_unid_producao") = Request("id_unid_producao")


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
            Dim extratoqualidadeweb As New ExtratoQualidadeWeb

            extratoqualidadeweb.ano_referencia = ViewState.Item("ano_referencia").ToString
            extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
            extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString

            Me.lbl_dtatual.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            Me.lbl_dtreferencia.Text = ViewState.Item("ano_referencia").ToString

            Dim dsFinanceiro As DataSet = extratoqualidadeweb.getExtratoPagtoWebbyFilters()

            If (dsFinanceiro.Tables(0).Rows.Count > 0) Then

                ' Dados da Fonte Pagadora
                Me.lbl_fonte_pagadora.Text = dsFinanceiro.Tables(0).Rows(0).Item("cd_estabelecimento").ToString & " DANONE LTDA - " & dsFinanceiro.Tables(0).Rows(0).Item("nm_estabelecimento").ToString
                Me.lbl_endereco_fp.Text = dsFinanceiro.Tables(0).Rows(0).Item("ds_endereco").ToString & ", " & dsFinanceiro.Tables(0).Rows(0).Item("nr_endereco").ToString
                'Me.lbl_numero_fp.Text = dsFinanceiro.Tables(0).Rows(0).Item("nr_endereco").ToString
                Me.lbl_municipio_fp.Text = dsFinanceiro.Tables(0).Rows(0).Item("cidade2").ToString & " " & dsFinanceiro.Tables(0).Rows(0).Item("estado2").ToString
                'Me.lbl_estado_fp.Text = dsFinanceiro.Tables(0).Rows(0).Item("estado2").ToString
                Me.lbl_cpf_cnpj.Text = dsFinanceiro.Tables(0).Rows(0).Item("cd_cnpj").ToString

                ' Dados do Benficiario
                Me.lbl_dsprodutor.Text = dsFinanceiro.Tables(0).Rows(0).Item("cd_pessoa").ToString & " - " & dsFinanceiro.Tables(0).Rows(0).Item("nm_pessoa").ToString
                Me.lbl_dspropriedade.Text = dsFinanceiro.Tables(0).Rows(0).Item("id_propriedade").ToString & "-" & dsFinanceiro.Tables(0).Rows(0).Item("nr_unid_producao").ToString
                Me.lbl_dsrota.Text = dsFinanceiro.Tables(0).Rows(0).Item("linha_par").ToString
                Me.lbl_endereco.Text = dsFinanceiro.Tables(0).Rows(0).Item("nm_propriedade").ToString
                Me.lbl_municipio.Text = dsFinanceiro.Tables(0).Rows(0).Item("cidade1").ToString & " " & dsFinanceiro.Tables(0).Rows(0).Item("estado1").ToString
                'Me.lbl_estado.Text = dsFinanceiro.Tables(0).Rows(0).Item("estado1").ToString
                Me.lbl_inscricao_estadual.Text = dsFinanceiro.Tables(0).Rows(0).Item("cd_inscricao_estadual").ToString
            End If


            '=================================================================================
            ' Monta Grid 
            '================================================================================

            'Totais
            ViewState.Item("total_litros") = 0
            ViewState.Item("total_rendbruto") = 0
            ViewState.Item("total_funrural") = 0
            ViewState.Item("total_desconto") = 0
            ViewState.Item("total_valorliquido") = 0


            If (dsFinanceiro.Tables(0).Rows.Count > 0) Then
                GridFinanceiro.Visible = True
                GridFinanceiro.DataSource = Helper.getDataView(dsFinanceiro.Tables(0), ViewState.Item("sortExpression"))
                GridFinanceiro.DataBind()
            Else
                Dim dr As DataRow = dsFinanceiro.Tables(0).NewRow()
                dsFinanceiro.Tables(0).Rows.InsertAt(dr, 0)
                GridFinanceiro.Visible = True
                GridFinanceiro.DataSource = Helper.getDataView(dsFinanceiro.Tables(0), "")
                GridFinanceiro.DataBind()
                GridFinanceiro.Rows(0).Cells.Clear()
                GridFinanceiro.Rows(0).Cells.Add(New TableCell())
                GridFinanceiro.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                GridFinanceiro.Rows(0).Cells(0).Text = "Não existem dados de fornecimento de leite para o período!"
                GridFinanceiro.Rows(0).Cells(0).ColumnSpan = 4

            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub GridFinanceiro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridFinanceiro.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_litros As Label = CType(e.Row.FindControl("lbl_litros"), Label)
            Dim lbl_rendbruto As Label = CType(e.Row.FindControl("lbl_rendbruto"), Label)
            Dim lbl_funrural As Label = CType(e.Row.FindControl("lbl_funrural"), Label)
            Dim lbl_desconto As Label = CType(e.Row.FindControl("lbl_desconto"), Label)
            Dim lbl_valorliquido As Label = CType(e.Row.FindControl("lbl_valorliquido"), Label)

            lbl_litros.Text = FormatNumber(lbl_litros.Text, 0)

            ' Apura totais
            ViewState.Item("total_litros") = ViewState.Item("total_litros") + lbl_litros.Text
            ViewState.Item("total_rendbruto") = ViewState.Item("total_rendbruto") + lbl_rendbruto.Text
            ViewState.Item("total_funrural") = ViewState.Item("total_funrural") + lbl_funrural.Text
            ViewState.Item("total_desconto") = ViewState.Item("total_desconto") + lbl_desconto.Text
            ViewState.Item("total_valorliquido") = ViewState.Item("total_valorliquido") + lbl_valorliquido.Text


        End If

        If (e.Row.RowType = DataControlRowType.Footer) Then


            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(1).Text = FormatNumber(ViewState.Item("total_litros"), 0)
            e.Row.Cells(2).Text = FormatCurrency(ViewState.Item("total_rendbruto"), 2)
            e.Row.Cells(3).Text = FormatCurrency(ViewState.Item("total_funrural"), 2)
            e.Row.Cells(4).Text = FormatCurrency(ViewState.Item("total_desconto"), 2)
            e.Row.Cells(5).Text = FormatCurrency(ViewState.Item("total_valorliquido"), 2)

        End If

    End Sub
End Class
