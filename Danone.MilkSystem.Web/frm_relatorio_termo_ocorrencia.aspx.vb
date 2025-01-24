Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_termo_ocorrencia
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
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 116
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("nr_preco") = Request("nr_preco")
                ViewState.Item("nr_volume_descontar") = Request("nr_volume_descontar")
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

            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

            lbl_romaneio.Text = romaneio.id_romaneio
            lbl_estabelecimento.Text = romaneio.ds_estabelecimento

            If romaneio.id_cooperativa > 0 Then
                lbl_rotanota.Text = romaneio.nr_nota_fiscal
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal
            Else

                lbl_rotanota.Text = romaneio.ds_linha
            End If

            lbl_transportador.Text = romaneio.ds_transportador
            lbl_cnpj_transportador.Text = romaneio.cd_cnpj_transportador
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_dt_hora_entrada.Text = DateTime.Parse(romaneio.dt_hora_entrada).ToString("dd/MM/yyyy")
            lbl_hora_entrada.Text = DateTime.Parse(romaneio.dt_hora_entrada).ToString("HH:mm")

            lbl_volume_descontado.Text = Decimal.Truncate(CDec(ViewState.Item("nr_volume_descontar")))
            lbl_valor_pagar.Text = FormatCurrency(CDec(ViewState.Item("nr_volume_descontar")) * CDec(ViewState.Item("nr_preco")), 2)



        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub


End Class
