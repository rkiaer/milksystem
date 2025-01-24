Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PropriedadeTanque
    Private _id_propriedade_tanque As Int32
    Private _id_propriedade As Int32
    Private _id_situacao As Int32
    Private _id_unid_producao As Int32
    Private _id_propriedade_parceira As Int32
    Private _id_unid_producao_parceira As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _nr_unid_producao As Int32
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property
    Public Property id_propriedade_tanque() As Int32
        Get
            Return _id_propriedade_tanque
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_tanque = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property id_propriedade_parceira() As Int32
        Get
            Return _id_propriedade_parceira
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_parceira = value
        End Set
    End Property
    Public Property id_unid_producao_parceira() As Int32
        Get
            Return _id_unid_producao_parceira
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao_parceira = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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

  
    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_propriedade_tanque = id
        loadPropriedadeTanque()

    End Sub

    Public Function getPropriedadesParceiras() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getpropriedade_tanque", parameters, "ms_propriedade_tanque")
            Return dataSet

        End Using

    End Function

    Public Sub loadPropriedadeTanque()

        Dim dataSet As DataSet = getPropriedadesParceiras()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertPropriedadeTanque() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPropriedade_tanque", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updatePropriedadeTanque()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePropriedade_tanque", parameters, ExecuteType.Update)

        End Using

    End Sub

    'Public Function validarPropriedade() As Boolean

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getPropriedade", parameters, "ms_propriedade")
    '        If dataSet.Tables(0).Rows.Count > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    End Using

    'End Function
    Public Sub deletePropriedadeTanque()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePropriedade_tanque", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
