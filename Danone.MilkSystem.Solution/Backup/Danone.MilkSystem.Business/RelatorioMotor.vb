Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RelatorioMotor

    Private _relatorio As String
    Private _descricao As String
    Private _origem As String
    Private _conteudo As String
    Private _id_modificador As Int32
    Private _par_id_estabelecimento As Int32   ' 01/12/2009 - Maracanau
    Private _par_cd_pessoa As String ' 01/12/2009 - Maracanau

    Public Property relatorio() As String
        Get
            Return _relatorio
        End Get
        Set(ByVal value As String)
            _relatorio = value
        End Set
    End Property

    Public Property descricao() As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
        End Set
    End Property


    Public Property origem() As String
        Get
            Return _origem
        End Get
        Set(ByVal value As String)
            _origem = value
        End Set
    End Property
    Public Property conteudo() As String
        Get
            Return _conteudo
        End Get
        Set(ByVal value As String)
            _conteudo = value
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
    ' 01/12/2009 - Maracanau - i
    Public Property par_id_estabelecimento() As Int32
        Get
            Return _par_id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _par_id_estabelecimento = value
        End Set
    End Property
    Public Property par_cd_pessoa() As String
        Get
            Return _par_cd_pessoa
        End Get
        Set(ByVal value As String)
            _par_cd_pessoa = value
        End Set
    End Property
    ' 01/12/2009 - Maracanau - f

    Public Sub New()

    End Sub


    Public Function getRelatoriosMotorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatoriosMotor", parameters, "ms_relat_fila_impr")
            Return dataSet

        End Using

    End Function

    Public Function insertRelatorioQualidadeMotor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRelatorioQualidadeMotor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertRelatorioAnualMotor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRelatorioAnualMotor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deleteRelatorioMotor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRelatorioMotor", parameters, ExecuteType.Delete)

        End Using
    End Sub

End Class
