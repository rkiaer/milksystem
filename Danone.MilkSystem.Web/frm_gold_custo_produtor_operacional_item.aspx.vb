Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_gold_custo_produtor_operacional_item
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_gold_custo_produtor_operacional_item.aspx")
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




            If Not (Request("id_gold_custo_produtor_operacional_item") Is Nothing) Then
                ViewState.Item("id_gold_custo_produtor_operacional_item") = Request("id_gold_custo_produtor_operacional_item")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim custoProdOpItem As New GoldCustoProdutorOperacionalItem(Convert.ToInt32(ViewState.Item("id_gold_custo_produtor_operacional_item")))

            ' 19/01/2010 - Chamado 597 - i
            If Not (ViewState.Item("id_gold_custo_produtor_operacional_item") Is Nothing) Then     ' Não permite alteração do Código do Grupo
                txt_nm_gold_custo_produtor_operacional_item.Enabled = False
                lk_concluir.OnClientClick = ""
                lk_concluirFooter.OnClientClick = ""

            Else
                txt_nm_gold_custo_produtor_operacional_item.Enabled = True
            End If

            txt_nm_gold_custo_produtor_operacional_item.Text = custoProdOpItem.nm_gold_custo_produtor_operacional_item
            cbo_situacao.SelectedValue = custoProdOpItem.id_situacao
            lbl_modificador.Text = custoProdOpItem.nm_modificador.ToString()
            lbl_dt_modificacao.Text = custoProdOpItem.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try
            Dim custoProdOpItem As New GoldCustoProdutorOperacionalItem

            custoProdOpItem.nm_gold_custo_produtor_operacional_item = txt_nm_gold_custo_produtor_operacional_item.Text
            

          
            custoProdOpItem.id_modificador = Session("id_login")
          
            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                custoProdOpItem.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            If Not (ViewState.Item("id_gold_custo_produtor_operacional_item") Is Nothing) Then
                custoProdOpItem.id_gold_custo_produtor_operacional_item = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor_operacional_item"))
                custoProdOpItem.updateGoldCustoProdutorOperacionalItem()
                messageControl.Alert("Registro alterado com sucesso.")
            Else
                ViewState.Item("id_gold_custo_produtor_operacional_item") = custoProdOpItem.insertGoldCustoProdutorOperacionalItem
                messageControl.Alert("Registro inserido com sucesso.")

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_gold_custo_produtor_operacional_item.aspx?")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_gold_custo_produtor_operacional_item.aspx")
    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_gold_custo_produtor_operacional_item.aspx")  ' Adri
    End Sub

End Class
