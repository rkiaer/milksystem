Imports Danone.MilkSystem.Business
Imports System
Imports System.IO
Imports System.data
Partial Class frm_nota_fiscal_mensagem
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_nota_fiscal_mensagem.aspx")
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

            If Not (Request("id_nota_fiscal_mensagem") Is Nothing) Then
                ViewState.Item("id_nota_fiscal_mensagem") = Request("id_nota_fiscal_mensagem")
                loadData()
            Else
                Dim estado As New NotaFiscalMensagem_Estado
                estado.id_estado_ini = 1
                estado.id_estado_fim = 14
                'estado.id_nota_fiscal_mensagem = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
                Dim dsMensagem As DataSet
                dsMensagem = estado.getEstadosSelecionadosByEstados()
                If (dsMensagem.Tables(0).Rows.Count > 0) Then
                    gridestado1.Visible = True
                    gridestado1.DataSource = Helper.getDataView(dsMensagem.Tables(0), "id_estado")
                    gridestado1.DataBind()
                Else
                    gridestado1.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

                Dim estado1 As New NotaFiscalMensagem_Estado
                estado1.id_estado_ini = 15
                estado1.id_estado_fim = 27
                'estado1.id_nota_fiscal_mensagem = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
                Dim dsMensagem1 As New DataSet
                dsMensagem1 = estado1.getEstadosSelecionadosByEstados()
                If (dsMensagem1.Tables(0).Rows.Count > 0) Then
                    gridestado2.Visible = True
                    gridestado2.DataSource = Helper.getDataView(dsMensagem1.Tables(0), "id_estado")
                    gridestado2.DataBind()
                Else
                    gridestado2.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_nota_fiscal_mensagem As Int32 = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
            Dim notafiscalmensagem1 As New NotaFiscalMensagem(id_nota_fiscal_mensagem)
            txt_mensagem.Text = notafiscalmensagem1.ds_mensagem

            If Not (notafiscalmensagem1.st_incentivo_25.Trim().Equals(String.Empty)) Then
                cbo_incentivo_25.SelectedValue = notafiscalmensagem1.st_incentivo_25
            End If

            If Not (notafiscalmensagem1.st_transferencia_credito.Trim().Equals(String.Empty)) Then
                cbo_transferencia.SelectedValue = notafiscalmensagem1.st_transferencia_credito
            End If

            If Not (notafiscalmensagem1.st_incentivo_21.Trim().Equals(String.Empty)) Then
                cbo_incentivo_21.SelectedValue = notafiscalmensagem1.st_incentivo_21
            End If

            ' 03/06/2009 - Chamado 277 - i
            If Not (notafiscalmensagem1.st_incentivo_24.Trim().Equals(String.Empty)) Then
                cbo_incentivo_24.SelectedValue = notafiscalmensagem1.st_incentivo_24
            End If
            ' 03/06/2009 - Chamado 277 - f

            If (notafiscalmensagem1.id_situacao > 0) Then
                cbo_situacao.SelectedValue = notafiscalmensagem1.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            ' lbl_modificador.Text = notafiscalmensagem1.id_modificador.ToString()
            'lbl_dt_modificacao.Text = notafiscalmensagem1.dt_modificacao.ToString()

            Dim estado As New NotaFiscalMensagem_Estado
            estado.id_estado_ini = 1
            estado.id_estado_fim = 14
            estado.id_nota_fiscal_mensagem = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
            Dim dsMensagem As DataSet
            dsMensagem = estado.getEstadosSelecionadosByEstados()
            If (dsMensagem.Tables(0).Rows.Count > 0) Then
                gridestado1.Visible = True
                gridestado1.DataSource = Helper.getDataView(dsMensagem.Tables(0), "id_estado")
                gridestado1.DataBind()
            Else
                gridestado1.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            Dim estado1 As New NotaFiscalMensagem_Estado
            estado1.id_estado_ini = 15
            estado1.id_estado_fim = 27
            estado1.id_nota_fiscal_mensagem = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
            Dim dsMensagem1 As New DataSet
            dsMensagem1 = estado1.getEstadosSelecionadosByEstados()
            If (dsMensagem1.Tables(0).Rows.Count > 0) Then
                gridestado2.Visible = True
                gridestado2.DataSource = Helper.getDataView(dsMensagem1.Tables(0), "id_estado")
                gridestado2.DataBind()
            Else
                gridestado2.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Public Sub updateData()
        If Page.IsValid = True Then


            Try

                Dim notafiscalmensagem As New NotaFiscalMensagem
                notafiscalmensagem.st_incentivo_25 = cbo_incentivo_25.SelectedItem.ToString
                notafiscalmensagem.st_incentivo_21 = cbo_incentivo_21.SelectedItem.ToString
                notafiscalmensagem.st_incentivo_24 = cbo_incentivo_24.SelectedItem.ToString  ' 03/06/2009 - Chamado 277 
                notafiscalmensagem.st_transferencia_credito = cbo_transferencia.SelectedItem.ToString
                notafiscalmensagem.ds_mensagem = txt_mensagem.Text.ToString

                ' I() 'f Not (txt_nr_incentivo_fiscal.Text.Trim().Equals(String.Empty)) Then
                'notafiscalmensagem.nr_incentivo_fiscal = Convert.ToDouble(txt_nr_incentivo_fiscal.Text)
                'End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    notafiscalmensagem.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                Dim li As Integer
                'Dim notafiscalmensagem2 As New NotaFiscalMensagem
                For li = 0 To gridestado1.Rows.Count - 1

                    If CType(gridestado1.Rows(li).FindControl("chk_item"), CheckBox).Checked() Then
                        notafiscalmensagem.id_estado_array.Add((gridestado1.DataKeys(li).Value))
                    End If
                Next

                Dim ll As Integer
                'Dim notafiscalmensagem2 As New NotaFiscalMensagem
                For ll = 0 To gridestado2.Rows.Count - 1

                    If CType(gridestado2.Rows(ll).FindControl("chk_item"), CheckBox).Checked() Then
                        notafiscalmensagem.id_estado_array.Add((gridestado2.DataKeys(ll).Value))
                    End If
                Next

                notafiscalmensagem.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_nota_fiscal_mensagem") Is Nothing) Then

                        notafiscalmensagem.id_nota_fiscal_mensagem = Convert.ToInt32(ViewState.Item("id_nota_fiscal_mensagem"))
                        notafiscalmensagem.updateNotaFiscalMensagem()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 66
                        usuariolog.id_nr_processo = ViewState.Item("id_nota_fiscal_mensagem")

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango
                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_nota_fiscal_mensagem") = notafiscalmensagem.insertNotaFiscalMensagem
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 66
                        usuariolog.id_nr_processo = ViewState.Item("id_nota_fiscal_mensagem")

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango
                        messageControl.Alert("Registro inserido com sucesso.")

                    End If

                    loadData()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_nota_fiscal_mensagem.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_nota_fiscal_mensagem.aspx")
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

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    'End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mensagem.TextChanged

    End Sub

    Public Sub New()

    End Sub


    Protected Sub Gridresults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridestado1.SelectedIndexChanged

    End Sub

    Protected Sub cv_estados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles cv_estados.Load

    End Sub

    Protected Sub cv_estados_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_estados.ServerValidate
        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim iprincipal As Integer = 0
            Dim estadosid As New ArrayList
            args.IsValid = True
            For Each row In gridestado1.Rows
                Dim chk_placa_principal As Anthem.CheckBox = CType(row.FindControl("chk_item"), Anthem.CheckBox)

                If chk_placa_principal.Checked = True Then
                    iprincipal += 1
                End If
            Next

            For Each row In gridestado2.Rows
                Dim chk_placa_principal As Anthem.CheckBox = CType(row.FindControl("chk_item"), Anthem.CheckBox)

                If chk_placa_principal.Checked = True Then
                    iprincipal += 1
                End If
            Next

            If iprincipal = 0 Then 'Se  há erros, se não selecionou um
                args.IsValid = False
                messageControl.Alert("Selecionte um ou mais estados.")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_nota_fiscal_mensagem.aspx")

    End Sub
End Class
