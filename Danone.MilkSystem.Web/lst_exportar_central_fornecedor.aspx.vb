Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_central_fornecedor

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_adto.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            'Fran 31/05/2010 i chamado 818
            'Dim portador As New Portador
            'cbo_portador.DataSource = portador.getPortadoresByFilters()
            'cbo_portador.DataTextField = "nm_portador"
            'cbo_portador.DataValueField = "id_portador"
            'cbo_portador.DataBind()
            'cbo_portador.Items.Insert(0, New ListItem("[Selecione]", "0"))
            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'Fran 31/05/2010 f chamado 818

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function exportData() As Boolean

        Try

            Dim pagtofornecedor As New PedidoPagtoFornecedor
            Dim lmsg As String

            pagtofornecedor.dt_referencia = ViewState.Item("dt_referencia").ToString()
            pagtofornecedor.dt_inicio = ViewState("dt_referencia").ToString
            pagtofornecedor.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pagtofornecedor.dt_inicio)))
            'fran 31/05/2010 chamado 818 i
            'pagtofornecedor.dt_processamento = ViewState.Item("dt_processamento").ToString()
            'pagtofornecedor.dt_vencimento = ViewState.Item("dt_vencimento").ToString()
            'pagtofornecedor.nm_portador = ViewState.Item("nm_portador").ToString()o
            pagtofornecedor.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            'fran 31/05/2010 chamado 818 f

            pagtofornecedor.nm_arquivo = ViewState.Item("nm_arquivo")
            pagtofornecedor.st_exportacao = ViewState.Item("st_exportacao")

            If pagtofornecedor.exportPagtoFornecedor() = True Then
                exportData = True
            Else
                exportData = False
                If pagtofornecedor.cd_erro = "Sem Linhas" Then
                    If pagtofornecedor.st_natureza_operacao = "N" Then 'se não há cadastro de natureza de operação
                        lmsg = "Não há cadastro ativo em Natureza de Operação para o código 4100AA!"
                    Else
                        If pagtofornecedor.st_item = "N" Then 'se não há cadastro de item
                            lmsg = "Não há cadastro ativo em Item para o código 41242005!"
                        Else 'se há cadastros, não encontrou linhas no getCentralPedidoPagtoFornecedorExportacao
                            lmsg = "Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente."
                        End If
                    End If
                End If
                If pagtofornecedor.cd_erro = "Exception" Then
                    lmsg = pagtofornecedor.nm_erro
                End If

                messageControl.Alert(lmsg)
            End If
            'lbl_totallidas.Text = pagtofornecedor.nr_linhaslidas
            lbl_totallinhas.Text = pagtofornecedor.nr_linhasexportadas


        Catch ex As Exception
            messageControl.Alert(ex.Message)
         End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String


            ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(dt_referencia.Text).ToString("MM/yyyy"))
            'Fran 31/05/2010 i chamado 818
            'ViewState.Item("dt_processamento") = Me.dt_processamento.Text
            'ViewState.Item("dt_vencimento") = Me.dt_vencimento.Text
            'ViewState.Item("id_portador") = cbo_portador.SelectedValue
            'ViewState.Item("nm_portador") = cbo_portador.SelectedItem.Text
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            'Fran 31/05/2010 f chamado 818

            If ck_pagtos_exportados.Checked = True Then
                ViewState.Item("st_exportacao") = "S"
            Else
                ViewState.Item("st_exportacao") = "N"
            End If

            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            'Fran 31/05/2010 i chamado 818
            'lnomearquivo = "\PagtoFornecedor" & Left(cbo_portador.SelectedItem.Text, 5) & DateTime.Parse(Convert.ToDateTime(ViewState.Item("dt_referencia"))).ToString("yyyy/MM") & ".txt"
            lnomearquivo = "\PagtoFornecedor" & DateTime.Parse(Convert.ToDateTime(ViewState.Item("dt_referencia"))).ToString("yyyy/MM") & "_" & Now() & ".txt"
            'Fran 31/05/2010 f chamado 818
            lnomearquivo = Replace(lnomearquivo, ":", "")
            lnomearquivo = Replace(lnomearquivo, " ", "")
            lnomearquivo = Replace(lnomearquivo, "/", "")


            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

            deleteArquivos()

            lbl_totallinhas.Visible = True

            If exportData() = True Then
                Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer
        Dim ldata As Date
        Dim ldata_limite As Date

        ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName


            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor


            If InStr(arquivos(index), "PagtoFornecedor") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
