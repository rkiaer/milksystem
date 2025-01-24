Imports Danone.MilkSystem.Business

Partial Class frm_estabelecimento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_estabelecimento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try




            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

 
            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

 
    Protected Sub cbo_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado.SelectedIndexChanged

        If Not (cbo_estado.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
        Else
            cbo_cidade.Items.Clear()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Enabled = False
        End If

    End Sub

    Private Sub loadCidadesByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade.DataSource = cidade.getCidadeByFilters()
            cbo_cidade.DataTextField = "nm_cidade"
            cbo_cidade.DataValueField = "id_cidade"
            cbo_cidade.DataBind()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_estabelecimento As Int32 = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            Dim estabelecimento As New Estabelecimento(id_estabelecimento)


            txt_cd_estabelecimento.Text = estabelecimento.cd_estabelecimento
            txt_cd_estabelecimento.Enabled = False
            txt_codigo_SAP.Text = estabelecimento.cd_codigo_sap ' 08/03/2012 - Projeto Themis 

            txt_nm_estabelecimento.Text = estabelecimento.nm_estabelecimento


            txt_cnpj.Text = estabelecimento.cd_cnpj
            txt_cnpj.Enabled = False

            If Not (estabelecimento.st_categoria.Trim().Equals(String.Empty)) Then
                cbo_categoria.SelectedValue = estabelecimento.st_categoria
            End If

            txt_inscricao_estadual.Text = estabelecimento.cd_inscricao_estadual
            txt_inscricao_municipal.Text = estabelecimento.cd_inscricao_municipal

            txt_endereco.Text = estabelecimento.ds_endereco
            txt_numero.Text = estabelecimento.nr_endereco.ToString()
            txt_complemento.Text = estabelecimento.ds_complemento
            txt_bairro.Text = estabelecimento.ds_bairro

            If (estabelecimento.id_cidade > 0) Then
                loadCidadesByEstado(estabelecimento.id_estado)
                cbo_estado.SelectedValue = estabelecimento.id_estado.ToString()
                cbo_cidade.SelectedValue = estabelecimento.id_cidade.ToString()
            End If

            txt_cep.Text = estabelecimento.cd_cep

            txt_nr_mapa_leite.Text = estabelecimento.nr_mapa_leite.ToString()
            txt_aidf.Text = estabelecimento.ds_aidf

            'Fran 17/11/2008 i 
            txt_serie_nota_fiscal.Text = estabelecimento.nr_serie
            txt_nr_proxima_nota_fiscal.Text = estabelecimento.nr_nota_fiscal
            'Fran 17/11/2008 f

            'Fran 30/11/2008 i 
            txt_aidf_nf.Text = estabelecimento.ds_aidf_nf_produtor
            'Fran 30/11/2008 f
            'Fran 01/04/2009 i  rls 17
            txt_dt_validade_formulario.Text = estabelecimento.dt_validade_formulario
            'Fran 01/04/2009 f

            txt_km_minima.Text = estabelecimento.nr_km_minima.ToString 'fran 07/2017
            Me.txt_nr_analiseesalq_percvariacaoMG.Text = FormatNumber(estabelecimento.nr_analiseesalq_percvariacaoMG, 0)   'adri 26/07/2016 - chamado 2441 - Conciliacao

            If (estabelecimento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = estabelecimento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = estabelecimento.id_modificador.ToString()
            lbl_dt_modificacao.Text = estabelecimento.dt_modificacao.ToString()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim estabelecimento As New Estabelecimento()

            estabelecimento.cd_estabelecimento = txt_cd_estabelecimento.Text

            estabelecimento.cd_codigo_SAP = txt_codigo_SAP.Text ' 08/03/2012 - Projeto Themis - i
 
            estabelecimento.nm_estabelecimento = txt_nm_estabelecimento.Text


            estabelecimento.cd_cnpj = txt_cnpj.Text

            If Not (cbo_categoria.SelectedValue.Trim().Equals(String.Empty)) Then
                estabelecimento.st_categoria = cbo_categoria.SelectedValue
            End If

            estabelecimento.cd_inscricao_estadual = txt_inscricao_estadual.Text
            estabelecimento.cd_inscricao_municipal = txt_inscricao_municipal.Text

            estabelecimento.ds_endereco = txt_endereco.Text

            If Not (txt_numero.Text.Trim.Equals(String.Empty)) Then
                estabelecimento.nr_endereco = txt_numero.Text
            End If

            estabelecimento.ds_complemento = txt_complemento.Text
            estabelecimento.ds_bairro = txt_bairro.Text

            If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                estabelecimento.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
            End If

            estabelecimento.cd_cep = txt_cep.Text

            If Not (txt_nr_mapa_leite.Text.Trim.Equals(String.Empty)) Then
                estabelecimento.nr_mapa_leite = txt_nr_mapa_leite.Text
            End If

            estabelecimento.ds_aidf = txt_aidf.Text


            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                estabelecimento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            'Fran 17/11/2008 i 
            'Inclusão de serie e proxima NF para exportação da NF de produtores
            estabelecimento.nr_serie = txt_serie_nota_fiscal.Text
            If Not (txt_nr_proxima_nota_fiscal.Text.Trim.Equals(String.Empty)) Then
                estabelecimento.nr_nota_fiscal = txt_nr_proxima_nota_fiscal.Text
            End If
            'Fran 17/11/2008 f

            'Fran 30/11/2008 i 
            estabelecimento.ds_aidf_nf_produtor = txt_aidf_nf.Text
            'Fran 30/11/2008 f

            'Fran 11/03/2009 i rls 17
            estabelecimento.dt_validade_formulario = txt_dt_validade_formulario.Text
            'Fran 11/03/2009 f rls 17

            'adri 26/07/2016 - chamado 2441 - Conciliacao - i
            If Not (txt_nr_analiseesalq_percvariacaoMG.Text.Trim.Equals(String.Empty)) Then
                estabelecimento.nr_analiseesalq_percvariacaoMG = txt_nr_analiseesalq_percvariacaoMG.Text
            End If
            'adri 26/07/2016 - chamado 2441 - Conciliacao - f

            'fran 07/2017
            estabelecimento.nr_km_minima = txt_km_minima.Text

            estabelecimento.id_modificador = 1

            If Not (ViewState.Item("id_estabelecimento") Is Nothing) Then

                estabelecimento.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                estabelecimento.updateEstabelecimento()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 1
                usuariolog.id_nr_processo = estabelecimento.id_estabelecimento
                usuariolog.nm_nr_processo = estabelecimento.nm_estabelecimento

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                ViewState.Item("id_estabelecimento") = estabelecimento.insertEstabelecimento()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 1
                usuariolog.id_nr_processo = estabelecimento.id_estabelecimento
                usuariolog.nm_nr_processo = estabelecimento.nm_estabelecimento

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro inserido com sucesso.")

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_estabelecimento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_estabelecimento.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    'Fran 02/03/2009 i Rls 17
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_estabelecimento.aspx")
    End Sub
End Class
