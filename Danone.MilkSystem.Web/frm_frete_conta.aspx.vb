Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_frete_conta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_frete_conta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            cbo_qtd_valor.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_qtd_valor.Items.Add(New ListItem("Quantidade", "Q"))
            cbo_qtd_valor.Items.Add(New ListItem("Valor", "V"))
            'cbo_qtd_valor.Items.Add(New ListItem("Valor Unitário", "V"))
            'cbo_qtd_valor.Items.Add(New ListItem("Valor Total", "T"))

            cbo_visualizar.Items.Add(New ListItem("Sim", "S"))
            cbo_visualizar.Items.Add(New ListItem("Não", "N"))

            If Not (Request("id_frete_conta") Is Nothing) Then
                ViewState.Item("id_frete_conta") = Request("id_frete_conta")
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

            Dim id_conta As Int32 = Convert.ToInt32(ViewState.Item("id_frete_conta"))
            Dim conta As New FreteConta()

            conta.id_frete_conta = id_conta
            Dim dsconta As DataSet = conta.getFreteContaByFilters

            If dsconta.Tables(0).Rows.Count > 0 Then
                With dsconta.Tables(0).Rows(0)
                    txt_cd_conta.Enabled = False
                    txt_cd_conta.Text = .Item("cd_frete_conta")
                    txt_nm_conta.Text = .Item("nm_frete_conta")
                    cbo_natureza_conta.SelectedValue = .Item("id_natureza")
                    cbo_qtd_valor.SelectedValue = .Item("st_qtd_valor").ToString
                    cbo_visualizar.SelectedValue = .Item("st_visualizar").ToString
                    txt_reservada.Text = .Item("st_sistema").ToString
                    If .Item("st_sistema").ToString = "S" Then
                        lbl_reservada.Text = "Sim"
                    Else
                        lbl_reservada.Text = "Não"
                    End If
                    txt_nr_ordem.Text = .Item("nr_ordem")
                    cbo_situacao.SelectedValue = .Item("id_situacao").ToString
                    cbo_situacao.Enabled = True
                    lbl_modificador.Text = .Item("id_modificador").ToString
                    lbl_dt_modificacao.Text = .Item("dt_modificacao").ToString

                    If Len(.Item("cd_conta_contabil")) > 0 Then

                        txt_nr_conta_contabil.Text = Left(.Item("cd_conta_contabil").ToString, 8) + "." + Right(.Item("cd_conta_contabil").ToString, 8)
                    Else
                        txt_nr_conta_contabil.Text = ""
                    End If

                End With
            End If
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

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim conta As New FreteConta()


            conta.cd_frete_conta = txt_cd_conta.Text
            conta.nm_frete_conta = txt_nm_conta.Text

            If Not (cbo_natureza_conta.SelectedValue.Trim().Equals(String.Empty)) Then
                conta.id_natureza = Convert.ToInt32(cbo_natureza_conta.SelectedValue)
            End If

            conta.st_qtd_valor = cbo_qtd_valor.SelectedValue

            conta.st_visualizar = cbo_visualizar.SelectedValue

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                conta.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            conta.st_sistema = txt_reservada.Text
            If Not txt_nr_ordem.Text.Equals(String.Empty) Then
                conta.nr_ordem = txt_nr_ordem.Text

            End If

            If Not (txt_nr_conta_contabil.Text.Trim.Equals(String.Empty)) Then
                conta.cd_conta_contabil = Replace(txt_nr_conta_contabil.Text, ".", "")
            Else
                conta.cd_conta_contabil = String.Empty
            End If

            conta.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_frete_conta") Is Nothing) Then

                conta.id_frete_conta = Convert.ToInt32(ViewState.Item("id_frete_conta"))
                conta.updateFreteConta()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 259
                usuariolog.nm_nr_processo = conta.cd_frete_conta
                usuariolog.id_nr_processo = ViewState.Item("id_frete_conta").ToString


                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                conta.st_sistema = "N"
                ViewState.Item("id_frete_conta") = conta.insertFreteConta()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 259
                usuariolog.nm_nr_processo = conta.cd_frete_conta
                usuariolog.id_nr_processo = ViewState.Item("id_frete_conta").ToString

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
        Response.Redirect("lst_frete_conta.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_frete_conta.aspx")
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
        Response.Redirect("frm_frete_conta.aspx")

    End Sub
End Class
