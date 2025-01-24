Imports Danone.MilkSystem.Business

Partial Class frm_conta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_conta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim natureza As New NaturezaConta

            cbo_natureza_conta.DataSource = natureza.getNaturezaContasByFilters()
            cbo_natureza_conta.DataTextField = "nm_natureza"
            cbo_natureza_conta.DataValueField = "id_natureza"
            cbo_natureza_conta.DataBind()
            cbo_natureza_conta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            cbo_qtd_valor.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_qtd_valor.Items.Add(New ListItem("Quantidade", "Q"))

            ' 18/05/2009 - Chamado 246 -  Emitir Nota Fiscal com valor unitátio e total (ctas da Central e Educampo) - Rls 17.5 - i
            'cbo_qtd_valor.Items.Add(New ListItem("Valor", "V"))
            cbo_qtd_valor.Items.Add(New ListItem("Valor Unitário", "V"))
            cbo_qtd_valor.Items.Add(New ListItem("Valor Total", "T"))
            ' 18/05/2009 - Chamado 246 -  Emitir Nota Fiscal com valor unitátio e total (ctas da Central e Educampo) - Rls 17.5 - f

            cbo_visualizar.Items.Add(New ListItem("Sim", "S"))
            cbo_visualizar.Items.Add(New ListItem("Não", "N"))

            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7 - i
            cbo_clube_compra.Items.Add(New ListItem("Sim", "S"))
            cbo_clube_compra.Items.Add(New ListItem("Não", "N"))
            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal  (ctas da Central e Educampo) - Rls 17.7 - i

            If Not (Request("id_conta") Is Nothing) Then
                ViewState.Item("id_conta") = Request("id_conta")
                lbl_reservada.Visible = True
                lbl_reservada_descr.Visible = True

                loadData()
            Else
                lbl_reservada.Visible = False
                lbl_reservada_descr.Visible = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_conta As Int32 = Convert.ToInt32(ViewState.Item("id_conta"))
            Dim conta As New Conta(id_conta)


            If Not (ViewState.Item("id_conta") Is Nothing) Then     ' Não permite alteração do Código da Conta
                txt_cd_conta.Enabled = False
            Else
                txt_cd_conta.Enabled = True
            End If

            txt_cd_conta.Text = conta.cd_conta
            txt_nm_conta.Text = conta.nm_conta


            If (conta.id_natureza > 0) Then
                cbo_natureza_conta.SelectedValue = conta.id_natureza.ToString()
            End If

            If Not (conta.st_qtd_valor.Trim().Equals(String.Empty)) Then
                cbo_qtd_valor.SelectedValue = conta.st_qtd_valor
            End If

            If Not (conta.st_visualizar.Trim().Equals(String.Empty)) Then
                cbo_visualizar.SelectedValue = conta.st_visualizar
            End If

            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7 - i
            If Not (conta.st_clube_compra.Trim().Equals(String.Empty)) Then
                cbo_clube_compra.SelectedValue = conta.st_clube_compra
            End If
            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7 - f

            txt_reservada.Text = conta.st_sistema   ' 20/05/2008
            If conta.st_sistema = "S" Then
                lbl_reservada.Text = "Sim"
            Else
                lbl_reservada.Text = "Não"
            End If

            txt_nr_ordem.Text = conta.nr_ordem

            If (conta.id_situacao > 0) Then
                cbo_situacao.SelectedValue = conta.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = conta.id_modificador.ToString()
            lbl_dt_modificacao.Text = conta.dt_modificacao.ToString()

            If Trim(txt_reservada.Text) = "S" Then ' 11/06/2008 - Se conta reservada do sistema, não permite alteraçao - i
                txt_nm_conta.Enabled = False
                cbo_natureza_conta.Enabled = False
                cbo_qtd_valor.Enabled = False
                cbo_situacao.Enabled = False
            Else
                txt_nm_conta.Enabled = True
                cbo_natureza_conta.Enabled = True
                cbo_qtd_valor.Enabled = True
                cbo_situacao.Enabled = True

            End If

            'Adri 15/09/2009 - Rls20 - i
            If Len(conta.cd_conta_contabil) > 0 Then
                txt_nr_conta_contabil.Text = Left(conta.cd_conta_contabil.ToString, 8) + "." + Right(conta.cd_conta_contabil.ToString, 8)
            Else
                txt_nr_conta_contabil.Text = ""
            End If
            'Adri 15/09/2009 - Rls20 - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim conta As New Conta()


            conta.cd_conta = txt_cd_conta.Text
            conta.nm_conta = txt_nm_conta.Text

            If Not (cbo_natureza_conta.SelectedValue.Trim().Equals(String.Empty)) Then
                conta.id_natureza = Convert.ToInt32(cbo_natureza_conta.SelectedValue)
            End If

            conta.st_qtd_valor = cbo_qtd_valor.SelectedValue

            conta.st_visualizar = cbo_visualizar.SelectedValue

            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7 - i
            conta.st_clube_compra = cbo_clube_compra.SelectedValue
            ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7 - f

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                conta.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            'conta.st_sistema = "N"  ' 20/05/2008 - quando integrar com o login, setar 'S' se usuário do sistema
            conta.st_sistema = txt_reservada.Text  ' 11/06/2008 
            conta.nr_ordem = txt_nr_ordem.Text ' 22/10/2008

            ' 15/09/2009 - Rls20 - i
            If Not (txt_nr_conta_contabil.Text.Trim.Equals(String.Empty)) Then
                conta.cd_conta_contabil = Replace(txt_nr_conta_contabil.Text, ".", "")
            Else
                conta.cd_conta_contabil = ""
            End If
            ' 15/09/2009 - Rls20 - i

            conta.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_conta") Is Nothing) Then

                conta.id_conta = Convert.ToInt32(ViewState.Item("id_conta"))
                conta.updateConta()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 28
                usuariolog.nm_nr_processo = conta.cd_conta
                usuariolog.id_nr_processo = ViewState.Item("id_conta").ToString


                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                conta.st_sistema = "N"  '23/07/2008
                ViewState.Item("id_conta") = conta.insertConta()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 28
                usuariolog.nm_nr_processo = conta.cd_conta
                usuariolog.id_nr_processo = ViewState.Item("id_conta").ToString

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
        Response.Redirect("lst_conta.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_conta.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_conta.aspx")

    End Sub
End Class
