Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class NotaFiscalMensagem_Estado

    Private _id_nota_fiscal_mensagem As Int32
    Private _id_estado As Int32
    Private _id_nota_fiscal_mensagem_estado As Int32
    Private _id_estado_ini As Int32
    Private _id_estado_fim As Int32
    Public Property id_estado_fim() As Int32
        Get
            Return _id_estado_fim
        End Get
        Set(ByVal value As Int32)
            _id_estado_fim = value
        End Set
    End Property
    Public Property id_estado_ini() As Int32
        Get
            Return _id_estado_ini
        End Get
        Set(ByVal value As Int32)
            _id_estado_ini = value
        End Set
    End Property
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
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
    
    Public Property id_nota_fiscal_mensagem_estado() As Int32
        Get
            Return _id_nota_fiscal_mensagem_estado
        End Get
        Set(ByVal value As Int32)
            _id_nota_fiscal_mensagem_estado = value
        End Set
    End Property
    

    Public Sub New(ByVal id As Int32)

        Me.id_nota_fiscal_mensagem_estado = id
        loadNotaFiscal()

    End Sub



    Public Sub New()

    End Sub

    Public Function getEstadosSelecionadosByEstados() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNotaFiscalMsgEstadosSelecionados", parameters, "ms_zestado")

            Return dataSet


        End Using

    End Function
    Public Function getNotasFiscaisByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNotaFiscalMensagemEstado", parameters, "ms_nota_fiscal_msg_estado")
            Return dataSet

        End Using

    End Function

    Private Sub loadNotaFiscal()

        Dim dataSet As DataSet = getNotasFiscaisByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertNotaFiscal() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertNotaFiscalMensagemEstado", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateNotaFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateNotaFiscalMensagemEstado", parameters, ExecuteType.Update)

        End Using

    End Sub
    
    Public Sub deleteNotaFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteNotaFiscalMensagemEstado", parameters, ExecuteType.Delete)

        End Using


    End Sub


End Class
