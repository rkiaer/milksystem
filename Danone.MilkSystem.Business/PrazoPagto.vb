
Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PrazoPagto

    Private _id_central_prazo_pagto As Int32
    Private _nm_central_prazo_pagto As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_central_prazo_pagto() As Int32
        Get
            Return _id_central_prazo_pagto
        End Get
        Set(ByVal value As Int32)
            _id_central_prazo_pagto = value
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

    Public Property nm_central_prazo_pagto() As String
        Get
            Return _nm_central_prazo_pagto
        End Get
        Set(ByVal value As String)
            _nm_central_prazo_pagto = value
        End Set
    End Property
    
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)

        Me.id_central_prazo_pagto = id
        loadPrazoPagto()

    End Sub

    Public Function getPrazoPagtoByfilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getcentralprazopagto", parameters, "ms_zcentral_prazo_pagto")

            Return dataSet

        End Using

    End Function

    Private Sub loadPrazoPagto()

        Dim dataSet As DataSet = getPrazoPagtoByfilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class



