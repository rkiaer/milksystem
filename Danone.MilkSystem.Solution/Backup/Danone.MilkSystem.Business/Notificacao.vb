Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

<Serializable()> Public Class Notificacao

    Private _id_notificacao As Int32
    Private _id_estabelecimento As Int32 'fran 24/11/2009 maracanau 518
    Private _id_tipo_notificacao As Int32
    Private _nm_tipo_notificacao As String
    Private _ds_email As String
    Private _ds_email_remetente As String
    Private _st_para_copia As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _email_para_insert As ArrayList
    Private _email_copia_insert As ArrayList
    Private _email_para_update As ArrayList
    Private _email_copia_update As ArrayList
    Private _id_para_update As ArrayList
    Private _id_copia_update As ArrayList
    Private _id_copia_delete As ArrayList
    Private _id_para_delete As ArrayList
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property


    Public Property id_notificacao() As Int32
        Get
            Return _id_notificacao
        End Get
        Set(ByVal value As Int32)
            _id_notificacao = value
        End Set
    End Property
    Public Property id_tipo_notificacao() As Int32
        Get
            Return _id_tipo_notificacao
        End Get
        Set(ByVal value As Int32)
            _id_tipo_notificacao = value
        End Set
    End Property
    Public Property nm_tipo_notificacao() As String
        Get
            Return _nm_tipo_notificacao
        End Get
        Set(ByVal value As String)
            _nm_tipo_notificacao = value
        End Set
    End Property
    Public Property ds_email_remetente() As String
        Get
            Return _ds_email_remetente
        End Get
        Set(ByVal value As String)
            _ds_email_remetente = value
        End Set
    End Property
    Public Property ds_email() As String
        Get
            Return _ds_email
        End Get
        Set(ByVal value As String)
            _ds_email = value
        End Set
    End Property
    Public Property st_para_copia() As String
        Get
            Return _st_para_copia
        End Get
        Set(ByVal value As String)
            _st_para_copia = value
        End Set
    End Property
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property
    Public Property email_para_insert() As ArrayList
        Get
            Return _email_para_insert
        End Get
        Set(ByVal value As ArrayList)
            _email_para_insert = value
        End Set
    End Property
    Public Property email_copia_insert() As ArrayList
        Get
            Return _email_copia_insert
        End Get
        Set(ByVal value As ArrayList)
            _email_copia_insert = value
        End Set
    End Property
    Public Property id_copia_delete() As ArrayList
        Get
            Return _id_copia_delete
        End Get
        Set(ByVal value As ArrayList)
            _id_copia_delete = value
        End Set
    End Property
    Public Property email_para_update() As ArrayList
        Get
            Return _email_para_update
        End Get
        Set(ByVal value As ArrayList)
            _email_para_update = value
        End Set
    End Property
    Public Property id_para_delete() As ArrayList
        Get
            Return _id_para_delete
        End Get
        Set(ByVal value As ArrayList)
            _id_para_delete = value
        End Set
    End Property
    Public Property id_para_update() As ArrayList
        Get
            Return _id_para_update
        End Get
        Set(ByVal value As ArrayList)
            _id_para_update = value
        End Set
    End Property
    Public Property email_copia_update() As ArrayList
        Get
            Return _email_copia_update
        End Get
        Set(ByVal value As ArrayList)
            _email_copia_update = value
        End Set
    End Property
    Public Property id_copia_update() As ArrayList
        Get
            Return _id_copia_update
        End Get
        Set(ByVal value As ArrayList)
            _id_copia_update = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_notificacao = id
        loadNotificacao()

    End Sub




    Public Sub New()

    End Sub


    Public Function getNotificacoesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNotificacoes", parameters, "ms_notificacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadNotificacao()

        Dim dataSet As DataSet = getNotificacoesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertNotificacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertNotificacao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateNotificacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateNotificacao", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteNotificacoes()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteNotificacoes", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub atualizarNotificacao()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try

            Me.st_para_copia = "P"

            'Pega os parametros
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)


            'Insere os emails PARA 
            For i As Integer = 0 To email_para_insert.Count - 1
                Me.ds_email = Me.email_para_insert(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_insertNotificacao", parameters, ExecuteType.Insert)
            Next
            'UPDATE os emails PARA
            For i As Integer = 0 To email_para_update.Count - 1
                Me.ds_email = Me.email_para_update(i).ToString
                Me.id_notificacao = Me.id_para_update(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateNotificacao", parameters, ExecuteType.Update)
            Next
            'DELETE os emails PARA
            For i As Integer = 0 To id_para_delete.Count - 1
                Me.id_notificacao = Me.id_para_delete(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_deleteNotificacao", parameters, ExecuteType.Delete)
            Next
            Me.st_para_copia = "C"
            'Insere os emails COPIA 
            For i As Integer = 0 To email_copia_insert.Count - 1
                Me.ds_email = Me.email_copia_insert(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_insertNotificacao", parameters, ExecuteType.Insert)
            Next
            'UPDATE os emails copia
            For i As Integer = 0 To email_copia_update.Count - 1
                Me.ds_email = Me.email_copia_update(i).ToString
                Me.id_notificacao = Me.id_copia_update(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateNotificacao", parameters, ExecuteType.Update)
            Next
            'DELETE os emails copia
            For i As Integer = 0 To id_copia_delete.Count - 1
                Me.id_notificacao = Me.id_copia_delete(i).ToString
                'Pega os parametros 
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_deleteNotificacao", parameters, ExecuteType.Delete)
            Next
            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            'Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    ' 28/10/2009 - Rls 22 - Inserir parâmetro opcional email_formato (ex: HTML)
    Public Function enviaMensagemEmail(ByVal id_tipo_notificacao As Integer, ByVal Email_Assunto As String, ByVal Email_Corpo As String, Optional ByVal Email_Prioridade As System.Net.Mail.MailPriority = MailPriority.Normal, Optional ByVal Email_Tecnico As String = "", Optional ByVal email_formato As Boolean = False, Optional ByVal pid_estabelecimento As Int32 = 0) As Boolean

        Try

            Me.id_tipo_notificacao = id_tipo_notificacao
            Me.id_situacao = 1
            Me.st_para_copia = "P"
            'Fran 25/11/2009 i Maracanau chamado 518
            If pid_estabelecimento > 0 Then
                Me.id_estabelecimento = pid_estabelecimento
            End If
            'Fran 25/11/2009 f Maracanau chamado 518
            Dim dsemailspara As DataSet = Me.getNotificacoesByFilters()
            Me.st_para_copia = "C"
            Dim dsemailsCC As DataSet = Me.getNotificacoesByFilters()
            Dim row As DataRow
            If dsemailspara.Tables(0).Rows.Count > 0 Then
                'Pega o remetente
                Dim dsremetente As String = dsemailspara.Tables(0).Rows(0).Item("ds_email_remetente")
                'Cria uma instancia do mailmessgae
                Dim mailmessage As New MailMessage()

                'Endereço do remetente
                mailmessage.From = New MailAddress(dsremetente)

                'Busca os destinatarios - PARA
                For Each row In dsemailspara.Tables(0).Rows
                    mailmessage.To.Add(New MailAddress(row.Item("ds_email")))
                Next

                ' 29/09/2008 - insere o email do tecnico, caso tenha sido enviado - i
                If Trim(Email_Tecnico) <> "" Then
                    mailmessage.To.Add(New MailAddress(Email_Tecnico))
                End If
                ' 29/09/2008 - insere o email do tecnico, caso tenha sido enviado - f

                'Busca os destinatarios - COPIA
                If dsemailsCC.Tables(0).Rows.Count > 0 Then
                    For Each row In dsemailsCC.Tables(0).Rows
                        mailmessage.CC.Add(New MailAddress(row.Item("ds_email")))  ' 29/09/2008
                    Next
                End If
                'Define o Assunto
                mailmessage.Subject = Email_Assunto

                ' 29/10/2009 - Rls22 Central de Compras - i
                If email_formato = True Then
                    mailmessage.IsBodyHtml = True
                End If
                ' 29/10/2009 - Rls22 Central de Compras - f

                'Define o corpo da mensagem
                mailmessage.Body = Email_Corpo
                'Prioridade email
                mailmessage.Priority = Email_Prioridade

                'Cria instancia SMTP
                Dim smtpclient As New SmtpClient

                'ENVIA EMAIL
                smtpclient.Send(mailmessage)
                'Retorna que o email foi enviado
                enviaMensagemEmail = True
            Else
                ''Retorna que o email não foi enviado
                enviaMensagemEmail = False
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Function
    'fran melhorias fase 2 Public Function enviaMensagemEmail(ByVal Email_Assunto As String, ByVal Email_Corpo As String, ByVal Email_Remetente As String, ByVal Email_Para As String, Optional ByVal Email_CC As String = "", Optional ByVal Email_Prioridade As System.Net.Mail.MailPriority = MailPriority.Normal, Optional ByVal email_formato As Boolean = False) As Boolean
    Public Function enviaMensagemEmail(ByVal Email_Assunto As String, ByVal Email_Corpo As String, ByVal Email_Remetente As String, ByVal Email_Para As String, Optional ByVal Email_CC As String = "", Optional ByVal Email_Prioridade As System.Net.Mail.MailPriority = MailPriority.Normal, Optional ByVal email_formato As Boolean = False, Optional ByVal Email_Para2 As String = "", Optional ByVal btratarerro As Boolean = True) As Boolean

        Try

            'Cria uma instancia do mailmessgae
            Dim mailmessage As New MailMessage()

            'Endereço do remetente
            mailmessage.From = New MailAddress(Email_Remetente)

            'Busca os destinatarios - PARA
            mailmessage.To.Add(New MailAddress(Email_Para))

            'fran fase 2 melhorias i
            'Adiciona outro PARA se houver
            If Not Email_Para2.ToString.Equals(String.Empty) Then
                mailmessage.To.Add(New MailAddress(Email_Para2))
            End If
            'fran fase 2 melhorias f

            'Busca os destinatarios - COPIA
            If Not Email_CC.ToString.Equals(String.Empty) Then
                mailmessage.CC.Add(New MailAddress(Email_CC))
            End If
            'Define o Assunto
            mailmessage.Subject = Email_Assunto

            If email_formato = True Then
                mailmessage.IsBodyHtml = True
            End If

            'Define o corpo da mensagem
            mailmessage.Body = Email_Corpo
            'Prioridade email
            mailmessage.Priority = Email_Prioridade

            'Cria instancia SMTP
            Dim smtpclient As New SmtpClient

            'ENVIA EMAIL
            smtpclient.Send(mailmessage)
            'Retorna que o email foi enviado
            enviaMensagemEmail = True

        Catch err As Exception
            'Retorna que o email não foi enviado
            enviaMensagemEmail = False
            If btratarerro = True Then
                Throw New Exception(err.Message)
            End If
        End Try
    End Function

End Class
