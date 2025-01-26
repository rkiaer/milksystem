Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class NotaFiscalMensagem
    Private _ds_mensagem_lst
    Private _id_nota_fiscal_mensagem As Int32
    Private _ds_mensagem As String
    Private _st_transferencia_credito As String
    Private _id_modificador As Int32
    Private _st_incentivo_21 As String
    Private _st_incentivo_24 As String   ' 03/06/2009 - Chamado 277
    Private _st_incentivo_25 As String
    Private _dt_modificacao As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_estado_array As New ArrayList
    Public notaFiscalMsgEstado As New NotaFiscalMensagem_Estado

    Public Property id_estado_array() As ArrayList
        Get
            Return _id_estado_array
        End Get
        Set(ByVal value As ArrayList)
            _id_estado_array = value
        End Set
    End Property

    Public Property id_nota_fiscal_mensagem() As Int32
        Get
            Return _id_nota_fiscal_mensagem
        End Get
        Set(ByVal value As Int32)
            _id_nota_fiscal_mensagem = value
        End Set
    End Property

    Public Property ds_mensagem_lst() As String
        Get
            Return _ds_mensagem_lst
        End Get
        Set(ByVal value As String)
            _ds_mensagem_lst = value
        End Set
    End Property
    Public Property ds_mensagem() As String
        Get
            Return _ds_mensagem
        End Get
        Set(ByVal value As String)
            _ds_mensagem = value
        End Set
    End Property

    Public Property st_incentivo_25() As String
        Get
            Return _st_incentivo_25
        End Get
        Set(ByVal value As String)
            _st_incentivo_25 = value
        End Set
    End Property

    Public Property st_incentivo_21() As String
        Get
            Return _st_incentivo_21
        End Get
        Set(ByVal value As String)
            _st_incentivo_21 = value
        End Set
    End Property
    Public Property st_incentivo_24() As String
        Get
            Return _st_incentivo_24
        End Get
        Set(ByVal value As String)
            _st_incentivo_24 = value
        End Set
    End Property

    Public Property st_transferencia_credito() As String
        Get
            Return _st_transferencia_credito
        End Get
        Set(ByVal value As String)
            _st_transferencia_credito = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_nota_fiscal_mensagem = id
        loadNotaFiscal()

    End Sub



    Public Sub New()

    End Sub

    

    Public Function getNotaFiscalMensagemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNotaFiscalMensagem", parameters, "ms_nota_fiscal_mensagem")
            Return dataSet

        End Using

    End Function

    Private Sub loadNotaFiscal()

        Dim dataSet As DataSet = getNotaFiscalMensagemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertNotaFiscalMensagem() As Int32



        
        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Return CType(transacao.ExecuteScalar("ms_insertNotaFiscalMensagem", parameters, ExecuteType.Insert), Int32)

            Me.notaFiscalMsgEstado.id_nota_fiscal_mensagem =  CType(transacao.ExecuteScalar("ms_insertNotaFiscalMensagem", parameters, ExecuteType.Insert), Int32)
            
            parameters = ParametersEngine.getParametersFromObject(notaFiscalMsgEstado)
            transacao.Execute("ms_deleteNotaFiscalMensagemEstado", parameters, ExecuteType.Delete)
            Dim i As Short
            For i = 0 To Convert.ToInt32(id_estado_array.Count) - 1

                Me.notaFiscalMsgEstado.id_estado = Convert.ToInt32(Me.id_estado_array(i))
                parameters = ParametersEngine.getParametersFromObject(notaFiscalMsgEstado)
                transacao.Execute("ms_insertNotaFiscalMensagemEstado", parameters, ExecuteType.Insert)
            Next

            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.notaFiscalMsgEstado.id_nota_fiscal_mensagem
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try

    End Function


    Public Function updateNotaFiscalMensagem() As Int32



        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            
            transacao.ExecuteScalar("ms_updateNotaFiscalMensagem", parameters, ExecuteType.Update)
            Me.notaFiscalMsgEstado.id_nota_fiscal_mensagem = Me.id_nota_fiscal_mensagem
            parameters = ParametersEngine.getParametersFromObject(notaFiscalMsgEstado)

            transacao.Execute("ms_deleteNotaFiscalMensagemEstado", parameters, ExecuteType.Delete)
            Dim i As Short
            For i = 0 To Convert.ToInt32(id_estado_array.Count) - 1

                Me.notaFiscalMsgEstado.id_estado = Convert.ToInt32(Me.id_estado_array(i))
                parameters = ParametersEngine.getParametersFromObject(notaFiscalMsgEstado)
                transacao.Execute("ms_insertNotaFiscalMensagemEstado", parameters, ExecuteType.Insert)
            Next

            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_nota_fiscal_mensagem
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    
    Public Sub deleteNotaFiscalMensagem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteNotaFiscalMensagem", parameters, ExecuteType.Delete)

        End Using


    End Sub





End Class
