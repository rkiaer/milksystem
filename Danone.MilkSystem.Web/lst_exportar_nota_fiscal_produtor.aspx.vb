Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_exportar_nota_fiscal_produtor

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_nota_fiscal_produtor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function exportData() As Boolean

        Try

            Dim notafiscal As New NotaFiscal
            ViewState.Item("SemNaturezaOperacao") = "N"
            ViewState.Item("nm_erro") = String.Empty
            notafiscal.id_estabelecimento = ViewState.Item("id_estabelecimento")
            notafiscal.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)
            notafiscal.nm_arquivo = ViewState.Item("nm_arquivo")
            notafiscal.st_exportacao = ViewState.Item("st_exportacao")
            'notafiscal.id_situacao = 1      'Somente notas ativas
            notafiscal.id_modificador = Session("id_login")   'Para exportar o usuário que está logado

            '01/12/2008 - i
            'notafiscal.exportNotaFiscalProdutor()
            exportData = notafiscal.exportNotaFiscalProdutor()
            'fran 07/06/2010 i erros
            ''If Left(notafiscal.cd_natureza_operacao, 3) = "SEM" Then
            ''    ViewState.Item("SemNaturezaOperacao") = notafiscal.cd_natureza_operacao
            ''    'fran 03/03/2010 i
            ''    ViewState.Item("SNO_cod_pessoa") = notafiscal.cd_pessoa
            ''    ViewState.Item("SNO_nr_nota_fiscal") = notafiscal.nr_nota_fiscal
            ''    ViewState.Item("SNO_nr_serie") = notafiscal.nr_serie
            ''    ViewState.Item("SNO_id_propriedade") = notafiscal.id_propriedade
            ''    'fran 03/03/2010 f
            ''Else
            ''    ViewState.Item("SemNaturezaOperacao") = String.Empty
            ''End If
            If exportData = False Then 'se tem erros

                If notafiscal.cd_erro <> "SEM LINHAS" Then 'se existem linhas, concatena com a mensagem dados do produtor com erro
                    notafiscal.nm_erro = notafiscal.nm_erro.ToString & " Produtor: " & notafiscal.cd_pessoa & ", propriedade: " & notafiscal.id_propriedade.ToString & ", nota fiscal: " & notafiscal.nr_nota_fiscal & " e série: " & notafiscal.nr_serie & "."
                End If
                ViewState.Item("nm_erro") = notafiscal.nm_erro.ToString
            End If
            'fran 07/06/2010 f erros

            '01/12/2008 - f

            lbl_totallidas.Text = notafiscal.nr_linhaslidas
            lbl_totallinhas.Text = notafiscal.nr_linhasexportadas
            'If notafiscal.nr_linhasexportadas > 0 Then
            '    Return True
            'Else
            '    If Left(notafiscal.cd_natureza_operacao, 3) = "SEM" Then
            '        ViewState.Item("SemNaturezaOperacao") = notafiscal.cd_natureza_operacao
            '    End If
            '    Return False
            'End If

        Catch ex As Exception

            ViewState.Item("nm_erro") = ex.Message.ToString 'fran 07/06/2010
            messageControl.Alert(ex.Message)
            Return False

        End Try

    End Function


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            Dim lnomearquivo As String

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            If ck_notas_exportadas.Checked = True Then
                ViewState.Item("st_exportacao") = "S"           ' 01/12/2008
            Else
                ViewState.Item("st_exportacao") = "N"
            End If


            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
            lnomearquivo = "\MilkSystem_NotaFiscal_Produtor_" & Now() & Session.SessionID & ".txt"
            lnomearquivo = Replace(lnomearquivo, ":", "")
            lnomearquivo = Replace(lnomearquivo, " ", "")
            lnomearquivo = Replace(lnomearquivo, "/", "")


            ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") & lnomearquivo

            deleteArquivos()

            lbl_totallidas.Visible = True
            lbl_totallinhas.Visible = True

            'If exportData() = True Then

            '    Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
            'Else
            '    If ViewState.Item("SemNaturezaOperacao") = "N" Then
            '        messageControl.Alert("Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente.")
            '    Else
            '        If ViewState.Item("SemNaturezaOperacao") = "SEM REGRA" Then
            '            messageControl.Alert("Há divergências nas regras para Natureza de Operação. O arquivo não pode ser gerado.")
            '        End If
            '        If ViewState.Item("SemNaturezaOperacao") = "SEM CADASTRO" Then
            '            messageControl.Alert("Nenhum cadastro foi encontrado para a Natureza de Operação informada. O arquivo não pode ser gerado.")
            '        End If

            '    End If
            'End If

            ' 01/12/2008 - i
            If exportData() = True Then
                Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
                'If ViewState.Item("SemNaturezaOperacao") = "N" Then
                '    messageControl.Alert("Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente.")
                'Else
                '    If ViewState.Item("SemNaturezaOperacao") = "SEM REGRA" Then
                '        messageControl.Alert("Há divergências nas regras para Natureza de Operação. O arquivo não pode ser gerado.")
                '    Else
                '        If ViewState.Item("SemNaturezaOperacao") = "SEM CADASTRO" Then
                '            messageControl.Alert("Nenhum cadastro foi encontrado para a Natureza de Operação informada. O arquivo não pode ser gerado.")
                '        Else
                '            Response.Redirect("frm_download.aspx?arquivo=" + ViewState.Item("nm_arquivo").ToString)
                '        End If
                '    End If

                'End If
            Else
                'fran 07/06/2010 i 
                ' ''fran 03/03/2010 i
                ''Dim lmsg As String
                ''If ViewState.Item("SemNaturezaOperacao") = "N" Then
                ''    messageControl.Alert("Nenhum registro foi encontrado para geração do arquivo. Por favor tente novamente.")
                ''Else
                ''    If ViewState.Item("SemNaturezaOperacao") = "SEM REGRA" Then
                ''        lmsg = "Regras de Natureza de Operação não especificadas para o produtor " & ViewState.Item("SNO_cod_pessoa").ToString & ", propriedade " & ViewState.Item("SNO_id_propriedade").ToString & ", nota fiscal " & ViewState.Item("SNO_nr_nota_fiscal").ToString & " e série " & ViewState.Item("SNO_nr_serie").ToString
                ''        messageControl.Alert(lmsg)
                ''    Else
                ''        If ViewState.Item("SemNaturezaOperacao") = "SEM CADASTRO" Then
                ''            lmsg = "Nenhum cadastro foi encontrado para regra de Natureza de Operação do produtor " & ViewState.Item("SNO_cod_pessoa").ToString & ", propriedade " & ViewState.Item("SNO_id_propriedade").ToString & ", nota fiscal " & ViewState.Item("SNO_nr_nota_fiscal").ToString & " e série " & ViewState.Item("SNO_nr_serie").ToString
                ''            messageControl.Alert(lmsg)
                ''        End If
                ''    End If

                ''End If
                ' ''fran 03/03/2010 f
                messageControl.Alert(ViewState.Item("nm_erro").ToString)
                'fran 07/06/2010 f 

            End If
            ' 01/12/2008 - f

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


            If InStr(arquivos(index), "MilkSystem_NotaFiscal_Produtor") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub
End Class
