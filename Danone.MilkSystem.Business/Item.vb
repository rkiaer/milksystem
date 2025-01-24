Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Item

    Private _id_item As Int32
    Private _cd_item As String
    Private _cd_item_sap As String 'fran 16/04/2012 i
    Private _nm_item As String
    Private _cd_deposito As String
    Private _cd_unidade_medida As String
    Private _cd_classificacao_fiscal As String
    'Alexandre 15/10/2009 i.
    Private _id_unidade_medida As Int32
    Private _id_grupo_itens As Int32
    Private _id_conta As Int32
    Private _st_central_compras As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_modificador As String  ' 04/11/2009 - Adri
    'Alexandre 15/10/2009 f.
    Private _id_categoria_item As Int32 'fran fase 3
    Private _id_canal As Int32 'fran fase 3
    Private _nm_categoria_item As String
    Private _ds_descricao_item As String
    Private _st_visualizar_web As String
    Private _st_importacao_pedido As String
    Public Property st_importacao_pedido() As String
        Get
            Return _st_importacao_pedido
        End Get
        Set(ByVal value As String)
            _st_importacao_pedido = value
        End Set
    End Property
    Public Property st_visualizar_web() As String
        Get
            Return _st_visualizar_web
        End Get
        Set(ByVal value As String)
            _st_visualizar_web = value
        End Set
    End Property
    Public Property ds_descricao_item() As String
        Get
            Return _ds_descricao_item
        End Get
        Set(ByVal value As String)
            _ds_descricao_item = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property

    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property
    Public Property nm_categoria_item() As String
        Get
            Return _nm_categoria_item
        End Get
        Set(ByVal value As String)
            _nm_categoria_item = value
        End Set
    End Property
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
        End Set
    End Property
    Public Property cd_item_sap() As String
        Get
            Return _cd_item_sap
        End Get
        Set(ByVal value As String)
            _cd_item_sap = value
        End Set
    End Property
    Public Property cd_deposito() As String
        Get
            Return _cd_deposito
        End Get
        Set(ByVal value As String)
            _cd_deposito = value
        End Set
    End Property

    Public Property cd_unidade_medida() As String
        Get
            Return _cd_unidade_medida
        End Get
        Set(ByVal value As String)
            _cd_unidade_medida = value
        End Set
    End Property
    Public Property cd_classificacao_fiscal() As String
        Get
            Return _cd_classificacao_fiscal
        End Get
        Set(ByVal value As String)
            _cd_classificacao_fiscal = value
        End Set
    End Property
    'Alexandre 15/10/2009 i.
    Public Property id_unidade_medida() As Int32
        Get
            Return _id_unidade_medida
        End Get
        Set(ByVal value As Int32)
            _id_unidade_medida = value
        End Set
    End Property
    Public Property id_conta() As Int32
        Get
            Return _id_conta
        End Get
        Set(ByVal value As Int32)
            _id_conta = value
        End Set
    End Property
    Public Property st_central_compras() As String
        Get
            Return _st_central_compras
        End Get
        Set(ByVal value As String)
            _st_central_compras = value
        End Set
    End Property
    Public Property id_grupo_itens() As Int32
        Get
            Return _id_grupo_itens
        End Get
        Set(ByVal value As Int32)
            _id_grupo_itens = value
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
    'Alexandre 15/10/2009 f.
    Public Property nm_modificador() As String
        Get
            Return _nm_modificador
        End Get
        Set(ByVal value As String)
            _nm_modificador = value
        End Set
    End Property
    Public Property id_categoria_item() As Int32
        Get
            Return _id_categoria_item
        End Get
        Set(ByVal value As Int32)
            _id_categoria_item = value
        End Set
    End Property
    Public Property id_canal() As Int32
        Get
            Return _id_canal
        End Get
        Set(ByVal value As Int32)
            _id_canal = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_item = id
        loadSituacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getItens", parameters, "ms_zitens")
            Return dataSet

        End Using

    End Function
    'fran 07/03/2010
    Public Function getItensByGrupoItem() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getItensByGrupoItem", parameters, "ms_zitens")
            Return dataSet

        End Using

    End Function
    'Adri 12/11/2009 - i
    Public Function getItensCentralByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getItensCentral", parameters, "ms_zitens")
            Return dataSet

        End Using

    End Function
    'Adri 12/11/2009 - f

    Private Sub loadSituacao()

        'Dim dataSet As DataSet = getItensByFilters()
        Me.st_central_compras = "" '  Adri 18/11/2009 para carregar qq item (central ou leite)
        Dim dataSet As DataSet = getItensCentralByFilters()  ' Adri 18/11/2009
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    'Public Function validarItem() As Int32 'fran 30/12/2009
    Public Function validarItemCentral() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getItensCentral", parameters, "ms_zitem")
            'fran 30/12/2009 i chamdo 556
            'If dataSet.Tables(0).Rows.Count > 0 Then
            '    Return True
            'Else
            '    Return False
            'End If
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item("id_item").ToString)
            Else
                Return 0
            End If
            'fran 30/12/2009 f


        End Using


    End Function
    'Alexandre 16/10/2009 i.
    Public Function insertitem() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertitem", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updateitem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateitem", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteitem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteitem", parameters, ExecuteType.Delete)

        End Using

    End Sub
    'Alexandre 16/10/2009 f.
End Class
