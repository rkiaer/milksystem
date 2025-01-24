Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_transvase_impressao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tirado em 16/11/2008 (para não ocrrer erro de acesso negado)
        'customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'ACESSO
            usuariolog.id_menu_item = 230
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_transvase") Is Nothing) Then
                ViewState.Item("id_transvase") = Request("id_transvase")   ' Produtor
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

            Dim transitPoint As New Transvase


            transitPoint.id_transvase = Convert.ToInt32(ViewState.Item("id_transvase"))

            Dim ds_tp As DataSet = transitPoint.getTransvaseByFilters
            Dim usuario As New Usuario(Session("id_login"))


            If ds_tp.Tables(0).Rows.Count > 0 Then
                With ds_tp.Tables(0).Rows(0)
                    Me.lbl_nr_transit_point.Text = ViewState.Item("id_transvase").ToString
                    Me.lbl_transit_point_unidade.Text = .Item("nm_estabelecimento").ToString 'adri 28/12/2009 i chamado 594
                    Me.lbl_emitente.Text = usuario.nm_usuario
                    Me.lbl_data.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy HH:mm:ss")
                    Me.lbl_placa.Text = .Item("ds_placa")
                    Me.lbl_rota_nota.Text = .Item("nm_linha")
                    Me.lbl_nm_item.Text = .Item("nm_item")
                    Me.lbl_nr_volume_total.Text = FormatNumber(.Item("nr_total_litros").ToString, 0)
                    Me.lbl_dt_fechamento.Text = DateTime.Parse(.Item("dt_fechamento")).ToString("dd/MM/yyyy")
                    Me.lbl_transportador.Text = .Item("ds_transportador").ToString
                    Me.lbl_motorista.Text = .Item("nm_motorista").ToString
                End With
            End If

            Dim ds_tpprodutor As DataSet = transitPoint.getTransvaseCompartimentoProdutores

            If ds_tpprodutor.Tables(0).Rows.Count > 0 Then
                gridTransitPoint.Visible = True
                gridTransitPoint.DataSource = Helper.getDataView(ds_tpprodutor.Tables(0), ViewState.Item("sortExpression"))
                gridTransitPoint.DataBind()
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

End Class
