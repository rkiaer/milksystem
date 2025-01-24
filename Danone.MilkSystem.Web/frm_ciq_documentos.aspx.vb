Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports RK.GlobalTools
Partial Class frm_ciq_documentos


    Inherits Page

    Private customPage As RK.PageTools.CustomPage
    Private Sub AnexarDocumento(ByVal pext As String)
        Try
            If Not (Me.ful_documento.PostedFile Is Nothing) AndAlso Me.ful_documento.PostedFile.FileName <> "" Then
                Dim inputStream As Stream = Me.ful_documento.PostedFile.InputStream
                Dim contentLength As Integer = Me.ful_documento.PostedFile.ContentLength
                Dim contentType As String = Me.ful_documento.PostedFile.ContentType
                Dim fileName As String = Me.ful_documento.PostedFile.FileName
                Dim numArray(contentLength + 1 - 1) As Byte
                inputStream.Read(numArray, 0, contentLength)

                Dim con As New SqlConnection
                con.ConnectionString = Tools.getConnectionString(DataBaseType.SqlServer)
                con.Open()

                Dim sqlcmd As New SqlCommand
                sqlcmd.CommandType = CommandType.StoredProcedure
                sqlcmd.CommandText = "ms_insertPoupancaParametroAnexo"
                sqlcmd.Connection = con

                Dim sqlparam As New SqlParameter("@id_poupanca_parametro", SqlDbType.Int)
                sqlparam.Value = Convert.ToInt32(Me.ViewState("id_poupanca_parametro"))
                sqlcmd.Parameters.Add(sqlparam)

                Dim sqlparam1 As New SqlParameter("@nm_tabela", SqlDbType.VarChar)
                sqlparam1.Value = "ms_poupanca_parametro_anexo"
                sqlcmd.Parameters.Add(sqlparam1)

                Dim sqlparam2 As New SqlParameter("@varbin_documento", SqlDbType.VarBinary, CInt(numArray.Length))
                sqlparam2.Value = numArray
                sqlcmd.Parameters.Add(sqlparam2)

                Dim sqlparam3 As New SqlParameter("@nm_documento", SqlDbType.VarChar)
                sqlparam3.Value = txt_nm_documento.Text
                sqlcmd.Parameters.Add(sqlparam3)

                Dim sqlparam4 As New SqlParameter("@nm_arquivo", SqlDbType.VarChar)
                sqlparam4.Value = fileName
                sqlcmd.Parameters.Add(sqlparam4)

                Dim sqlparam5 As New SqlParameter("@nm_extensao", SqlDbType.VarChar)
                sqlparam5.Value = pext
                sqlcmd.Parameters.Add(sqlparam5)

                Dim sqlparam6 As New SqlParameter("@nr_tamanho", SqlDbType.Int)
                sqlparam6.Value = contentLength
                sqlcmd.Parameters.Add(sqlparam6)

                Dim sqlparam7 As New SqlParameter("@id_modificador", SqlDbType.Int)
                sqlparam7.Value = Convert.ToInt32(Me.Session("id_login"))
                sqlcmd.Parameters.Add(sqlparam7)


                sqlcmd.ExecuteNonQuery()
                con.Close()

            End If
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_poupanca_manutencao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_poupanca_parametro") Is Nothing) Then
                ViewState.Item("id_poupanca_parametro") = Request("id_poupanca_parametro")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadParamQualidade()

        Try
            Dim paramQualidade As New PoupancaParametroQualidade


            'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            paramQualidade.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)

            Dim dsqualidade As DataSet = paramQualidade.getPoupancaParametroQualidade()

            If (dsqualidade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsqualidade.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim poupancaparam As New PoupancaParametro(ViewState.Item("id_poupanca_parametro"))

            lbl_periodo.Text = String.Concat("Período de ", DateTime.Parse(poupancaparam.dt_referencia_ini).ToString("MMM/yyyy").ToUpper, " à ", DateTime.Parse(poupancaparam.dt_referencia_fim).ToString("MMM/yyyy").ToUpper)
            lbl_nm_situacao_poupanca.Text = poupancaparam.nm_situacao_poupanca.ToString

            Dim estabelecimento As New Estabelecimento(poupancaparam.id_estabelecimento)
            lbl_estabelecimento.Text = estabelecimento.nm_estabelecimento.ToString

            If Not (poupancaparam.dt_adesao_limite Is Nothing) AndAlso poupancaparam.dt_adesao_limite.ToString.Equals(String.Empty) Then
                txt_dt_adesao_limite.Text = Format(DateTime.Parse(poupancaparam.dt_adesao_limite), "dd/MM/yyyy").ToString
            End If

            lbl_modificador.Text = poupancaparam.id_modificador.ToString()
            lbl_dt_modificacao.Text = poupancaparam.dt_modificacao.ToString()
            ViewState.Item("id_situacao_poupanca") = poupancaparam.id_situacao_poupanca
            If (Not poupancaparam.id_situacao_poupanca.Equals("1")) Then
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                btn_anexar.Enabled = False
            End If
            loadAnexos()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_poupanca_parametro.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_poupanca_parametro.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
    End Sub


    Protected Sub btn_anexar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anexar.Click
        If (Me.Page.IsValid) Then
            Dim fileName As String = Me.ful_documento.PostedFile.FileName
            Dim lower As String = fileName.Substring(fileName.LastIndexOf("."))
            lower = lower.ToLower()
            Dim contentType As Object = Me.ful_documento.PostedFile.ContentType
            If (Me.ful_documento.PostedFile.ContentLength > 2000000) Then
                Me.messageControl.Alert("O documento deve possuir tamanho máximo de 2000 KB.")
            Else
                If lower <> ".pdf" Then
                    Me.messageControl.Alert("Somente são suportados arquivos no formato pdf.")
                Else
                    Me.AnexarDocumento(lower)
                    Me.messageControl.Alert("Registro inserido com sucesso.")
                    Me.txt_nm_documento.Text = ""
                End If
            End If
        End If

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        Me.gridResults.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteParametroQualidade(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub
    Private Sub deleteParametroQualidade(ByVal id_poupancaparametroqualidade As Integer)
        Try
            Dim poupancaparam As New PoupancaParametroQualidade

            poupancaparam.id_poupanca_parametro_qualidade = id_poupancaparametroqualidade
            poupancaparam.id_modificador = Convert.ToInt32(Me.Session("id_login"))
            poupancaparam.deletePoupancaParametroQualidade()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = DataControlRowState.Edit)) Then
            Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            txt_dt_referencia_fim_qualidade.Text = DateTime.Parse(txt_dt_referencia_fim_qualidade.Text).ToString("MM/yyyy")

        Else
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim lbl_dt_referencia_ini As Label = CType(e.Row.FindControl("lbl_dt_referencia_ini"), Label)
                Dim lbl_dt_referencia_fim As Label = CType(e.Row.FindControl("lbl_dt_referencia_fim"), Label)
                Dim st_rejeicao_antibiotico As Label = CType(e.Row.FindControl("st_rejeicao_antibiotico"), Label)
                Dim st_analises_romaneio As Label = CType(e.Row.FindControl("st_analises_romaneio"), Label)
                Dim img_rejeicao_antibiotico As Anthem.Image = CType(e.Row.FindControl("img_rejeicao_antibiotico"), Anthem.Image)
                Dim img_analises_romaneio As Anthem.Image = CType(e.Row.FindControl("img_analises_romaneio"), Anthem.Image)


                'se nao tem calculo definitivo para o perifo de poupanca, deixa excluir a qualidade e incluir nova
                If ViewState.Item("PoupancaUltimoCalculo").Equals(String.Empty) Then
                    btn_editar.Visible = False
                    btn_delete.Visible = True
                Else
                    btn_editar.Visible = True
                    btn_delete.Visible = True

                    'se data calculo definitivo for maior ou  igual a data de validade inmicial nao deixa excluir
                    If CDate(ViewState.Item("PoupancaUltimoCalculo").ToString) >= CDate(lbl_dt_referencia_ini.Text) Then
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Não é possível excluir o registro. Já existe cálculo definitivo."
                    Else
                        'se data calculo for menor, deixa excluir linha
                        btn_editar.Visible = False
                        btn_delete.Enabled = True
                        btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                        btn_delete.ToolTip = String.Empty
                    End If
                End If
                lbl_dt_referencia_ini.Text = DateTime.Parse(lbl_dt_referencia_ini.Text).ToString("MM/yyyy")
                lbl_dt_referencia_fim.Text = DateTime.Parse(lbl_dt_referencia_fim.Text).ToString("MM/yyyy")
                If st_rejeicao_antibiotico.Text.Equals("S") Then
                    img_rejeicao_antibiotico.ImageUrl = "~/img/ico_chk_true.gif"
                    e.Row.Cells(5).Text = String.Empty 'faixa inicial
                    e.Row.Cells(6).Text = String.Empty 'faixa final
                Else
                    img_rejeicao_antibiotico.ImageUrl = "~/img/ico_chk_false.gif"

                End If
                If st_analises_romaneio.Text.Equals("S") Then
                    img_analises_romaneio.ImageUrl = "~/img/ico_chk_true.gif"
                    e.Row.Cells(5).Text = String.Empty 'faixa inicial
                    e.Row.Cells(6).Text = String.Empty 'faixa final
                Else
                    img_analises_romaneio.ImageUrl = "~/img/ico_chk_false.gif"

                End If

            End If
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try
            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As System.Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim qualidade As New PoupancaParametroQualidade

                    Dim lbl_id_poupanca_parametro_qualidade As Label = CType(row.FindControl("lbl_id_poupanca_parametro_qualidade"), Label)
                    Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

                    qualidade.dt_referencia_fim = DateTime.Parse(String.Concat("01/", txt_dt_referencia_fim_qualidade.Text)).ToString("dd/MM/yyyy")
                    qualidade.id_modificador = Session("id_login")
                    qualidade.id_poupanca_parametro_qualidade = Convert.ToInt32(lbl_id_poupanca_parametro_qualidade.Text)
                    qualidade.updatePoupancaParametroQualidade()
                    gridResults.EditIndex = -1

                    loadParamQualidade()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadAnexos()

        Try
            Dim param As New PoupancaParametro

            param.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)

            Dim dsparamanexo As DataSet = param.getPoupancaParametroAnexo()
            If (dsparamanexo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsparamanexo.Tables(0), "")
                gridResults.DataBind()
            Else
                Dim dataRow As System.Data.DataRow = dsparamanexo.Tables(0).NewRow()
                dsparamanexo.Tables(0).Rows.InsertAt(dataRow, 0)
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsparamanexo.Tables(0), "")
                gridResults.DataBind()
                gridResults.Rows(0).Cells.Clear()
                gridResults.Rows(0).Cells.Add(New TableCell())
                gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridResults.Rows(0).Cells(0).Text = "Não existem documentos anexados para este Programa Mais Sólidos!"
                gridResults.Rows(0).Cells(0).ColumnSpan = 9
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class

