Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_po_produtor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_po_produtor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            If Not (Request("id_po_produtor") Is Nothing) Then
                ViewState.Item("id_po_produtor") = Request("id_po_produtor")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim po As New POProdutor(Convert.ToInt32(ViewState.Item("id_po_produtor")))


            txt_dt_referencia.Enabled = False
            txt_dt_referencia.Text = DateTime.Parse(po.dt_referencia).ToString("MM/yyyy")

            txt_nr_po.Text = po.nr_po

            If (po.id_estado > 0) Then
                cbo_estado.SelectedValue = po.id_estado.ToString()
                cbo_estado.Enabled = False
            End If

            If (po.id_situacao > 0) Then
                cbo_situacao.SelectedValue = po.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If (po.id_estabelecimento > 0) Then
                Me.cbo_estabelecimento.SelectedValue = po.id_estabelecimento.ToString
                Me.cbo_estabelecimento.Enabled = False
            End If
            If (po.id_item > 0) Then
                Me.cbo_id_item.SelectedValue = po.id_item.ToString
                Me.cbo_id_item.Enabled = False
            End If

            Dim usuario As New Usuario(po.id_modificador)

            lbl_modificador.Text = usuario.ds_login
            lbl_dt_modificacao.Text = DateTime.Parse(po.dt_modificacao).ToString("dd/MM/yyyy HH:mm:ss")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim po As New POProdutor()

                po.id_estado = Convert.ToInt32(cbo_estado.SelectedValue)
                po.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)
                po.nr_po = txt_nr_po.Text

                po.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                po.id_modificador = Session("id_login")

                po.id_estabelecimento = cbo_estabelecimento.SelectedValue
                po.id_item = cbo_id_item.SelectedValue

                If Not (ViewState.Item("id_po_produtor") Is Nothing) Then
                    po.id_po_produtor = Convert.ToInt32(ViewState.Item("id_po_produtor"))
                    po.updatePOProdutor()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 123
                    usuariolog.ds_nm_processo = "PO Produtor"
                    usuariolog.id_nr_processo = ViewState.Item("id_po_produtor").ToString
                    usuariolog.nm_nr_processo = po.nr_po.ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_po_produtor") = po.insertPOProdutor()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 123
                    usuariolog.ds_nm_processo = "PO Produtor"
                    usuariolog.id_nr_processo = ViewState.Item("id_po_produtor").ToString
                    usuariolog.nm_nr_processo = po.nr_po.ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")
                End If
                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_po_ordem_compra.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_po_ordem_compra.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_po_produtor.aspx")

    End Sub
End Class
