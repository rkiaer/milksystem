Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_indicador_preco_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If txt_dt_referencia.Text.Equals(String.Empty) Then
            ViewState.Item("dt_referencia") = String.Empty
        Else
            ViewState.Item("dt_referencia") = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_indicador_preco_aprovar_2N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_indicador_preco_aprovar_2N.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 191
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            ViewState.Item("sortExpression") = "ds_indicador_tipo, dt_referencia desc"


            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim indicador As New IndicadorPreco

            indicador.dt_referencia = ViewState.Item("dt_referencia").ToString
            indicador.id_situacao = 1 'ativo
            indicador.id_situacao_indicador_preco = 2 'aguardando aprovacao

            Dim dsindicadores As DataSet = indicador.getIndicadorPrecoByFilters()

            If (dsindicadores.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsindicadores.Tables(0), ViewState.Item("sortExpression"))
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
            Dim indicador As New IndicadorPreco

            If saveCheckBox() = True Then

                indicador.id_modificador = Session("id_login")

                indicador.updateIndicadorPrecoAprovarSelecionados2Nivel()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 191
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 
                loadData()

                messageControl.Alert("Aprovação 2.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum contrato.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim indicador As New IndicadorPreco()
                indicador.id_indicador_preco = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    indicador.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    indicador.st_selecao = "0"
                End If
                indicador.updateIndicadorPrecoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim indicador As New IndicadorPreco

            If saveCheckBox() = True Then
                indicador.id_modificador = Session("id_login")
                indicador.updateIndicadorPrecoNaoAprovarSelecionados2Nivel()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 191
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")

            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum modelo de contrato.")
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
            Dim indicador As New IndicadorPreco
            indicador.dt_referencia = ViewState("dt_referencia").ToString
            indicador.id_situacao = 1 'ativo
            indicador.id_situacao_indicador_preco = 2 'aguardando aprovacao

            If ck_header.Checked = True Then
                indicador.st_selecao = "1"
            Else
                indicador.st_selecao = "0"
            End If

            indicador.updateIndicadorPrecoSelecaoTodos()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub






End Class
