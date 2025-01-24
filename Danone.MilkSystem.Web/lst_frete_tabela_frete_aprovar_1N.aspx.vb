Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_frete_tabela_frete_aprovar_1N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_tabela_frete_aprovar_1N.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 263
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            ViewState.Item("sortExpression") = "nm_transportador, nm_cooperativa,dstipofrete, dt_validade, nm_tipo_equipamento"

            loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim tabela As New FreteTabela

            tabela.id_situacao = 1 'ativo
            tabela.id_situacao_aprovacao = 1 'aguardando aprovacao

            Dim dstabela As DataSet = tabela.getFreteTabelaByFilters()

            If (dstabela.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstabela.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                Me.lk_aprovar.Enabled = True
                Me.lk_reprovar.Enabled = True

            Else
                Me.lk_aprovar.Enabled = False
                Me.lk_reprovar.Enabled = False
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
        loadData()

    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim tabela As New FreteTabela

            If saveCheckBox() = True Then

                tabela.id_modificador = Session("id_login")

                tabela.updateFreteTabelaAprovarSelecionados1Nivel()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 263
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Aprovação 1.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum item de tabela de frete.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim tabela As New FreteTabela()
                tabela.id_frete_tabela = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    tabela.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    tabela.st_selecao = "0"
                End If
                tabela.updateFreteTabelaSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim tabela As New FreteTabela

            If saveCheckBox() = True Then
                tabela.id_modificador = Session("id_login")
                tabela.updateFreteTabelaNaoAprovarSelecionados1Nivel()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 263
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")

            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum item de tabela de frete.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i
            Dim tabela As New FreteTabela
            tabela.id_situacao = 1 'ativo
            tabela.id_situacao_aprovacao = 1 'aguardando aprovacao

            If ck_header.Checked = True Then
                tabela.st_selecao = "1"
            Else
                tabela.st_selecao = "0"
            End If

            tabela.updateFreteTabelaSelecaoTodos()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 2.o Nível de Frete (Tabela de Frete)"
                    Dim lCorpo As String = "Existem itens de Frete, da Tabela de Frete para cálculo de frete, aprovados em 1.o Nível pendentes para aprovação 2.o Nível."

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 263
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    ' Parametro 18 - contrato 2.o Nível
                    If notificacao.enviaMensagemEmail(30, lAssunto, lCorpo, MailPriority.High) = True Then

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                    Else

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")

                    End If

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub




End Class
