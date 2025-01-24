Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_adto

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


            Dim portador As New Portador

            cbo_portador.DataSource = portador.getPortadoresByFilters()
            cbo_portador.DataTextField = "nm_portador"
            cbo_portador.DataValueField = "id_portador"
            cbo_portador.DataBind()
            cbo_portador.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub exportData()

        Try

            Dim adiantamento As New Adiantamento

            adiantamento.dt_referencia = "01/" & ViewState.Item("dt_referencia").ToString()
            adiantamento.dt_processamento = ViewState.Item("dt_processamento").ToString()
            adiantamento.dt_vencimento = ViewState.Item("dt_vencimento").ToString()
            adiantamento.id_portador = ViewState.Item("id_portador").ToString()
            adiantamento.nm_arquivo = ViewState.Item("nm_arquivo")
            adiantamento.st_exportacao = ViewState.Item("st_exportacao")   ' 19/11/2008

            adiantamento.exportAdiantamento()

            lbl_totallidas.Text = adiantamento.nr_linhaslidas
            lbl_totallinhas.Text = adiantamento.nr_linhasexportadas

            'If chk_efetivar.Checked = False Then
            '    fichafinanceira.st_pagamento = "Q"
            '    fichafinanceira.updateFichaFinanceiraDefinitivo()
            '    messageControl.Alert("O Pagamento do Adiantamento foi efetivado e não poderá mais ser recalculado.")
            'End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String


            ViewState.Item("dt_referencia") = dt_referencia.Text
            ViewState.Item("dt_processamento") = Me.dt_processamento.Text
            ViewState.Item("dt_vencimento") = Me.dt_vencimento.Text
            ViewState.Item("id_portador") = cbo_portador.SelectedValue
            ' 19/11/2008 - i
            If ck_adtos_exportados.Checked = True Then
                ViewState.Item("st_exportacao") = "S"
            Else
                ViewState.Item("st_exportacao") = "N"
            End If
            ' 19/11/2008 - f

            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\ArquivoAdto_" & Session.SessionID & Now() & ".txt"
            'lnomearquivo = "\MilkSystem_Adto_" & Now() & Session.SessionID & ".txt"
            lnomearquivo = "\adto" & Left(cbo_portador.SelectedItem.Text, 5) & DateTime.Parse(Convert.ToDateTime(ViewState.Item("dt_referencia"))).ToString("yyyy/MM") & ".txt"
            lnomearquivo = Replace(lnomearquivo, ":", "")
            lnomearquivo = Replace(lnomearquivo, " ", "")
            lnomearquivo = Replace(lnomearquivo, "/", "")


            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

            deleteArquivos()

            lbl_totallidas.Visible = True
            lbl_totallinhas.Visible = True

            exportData()
 
            Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)

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


            If InStr(arquivos(index), "MilkSystem_Adto") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
