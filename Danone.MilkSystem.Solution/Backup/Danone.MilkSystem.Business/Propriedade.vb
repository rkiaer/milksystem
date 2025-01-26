Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Propriedade

    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _id_item As Int32
    Private _id_estabelecimento As Int32
    Private _cd_estabelecimento As String
    Private _nm_estabelecimento As String
    Private _id_estado As Int32
    Private _cd_uf As String
    Private _nm_estado As String 'fran fase 2 melhorias
    Private _id_situacao As Int32
    Private _nm_propriedade As String
    Private _nm_pessoa As String
    Private _cd_inscricao_estadual As String
    Private _ds_endereco As String
    Private _nr_endereco As Int32
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _id_cidade As Int32
    Private _cd_cep As String
    Private _nm_cidade As String '18/12/2008 i nota
    Private _id_tecnico As Int32
    Private _nm_tecnico As String
    Private _id_tecnico_educampo As Int32
    Private _nm_tecnico_educampo As String
    Private _id_linha As Int32 'rota
    Private _nm_linha As String
    Private _id_motivo_inativacao As Int32
    Private _nm_motivo_inativacao As String
    Private _dt_inicio As String
    Private _dt_reativacao As String
    Private _nr_capac_granel As Decimal
    Private _nr_capac_ensacado As Decimal
    Private _nr_vol_leite_dia As Decimal
    Private _nr_qtde_animais As Int32
    Private _nr_preco_negociado As Decimal
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _id_modificador As Int32
    Private _cd_pessoa As String
    Private _unidadeproducao As New UnidadeProducao
    Private _nr_latitude As Decimal
    Private _nr_longitude As Decimal
    Private _st_considera_qualidade As String
    Private _st_incentivo_fiscal As String
    Private _st_transferencia_credito As String
    ' 26/08/2008 - V2 da definição da roteirização
    Private _st_periodicidade_coleta As String
    Private _st_tipo_coleta As String
    ' V1 da definição da roteirização
    'Private _st_coleta_domingo As String
    'Private _st_coleta_segunda As String
    'Private _st_coleta_terca As String
    'Private _st_coleta_quarta As String
    'Private _st_coleta_quinta As String
    'Private _st_coleta_sexta As String
    'Private _st_coleta_sabado As String
    Private _id_linha_par As Int32
    Private _id_linha_impar As Int32
    Private _nm_linha_par As String
    Private _nm_linha_impar As String
    Private _st_incentivo_21 As String
    Private _st_incentivo_25 As String ' Fran para impressao nota fiscal
    Private _st_incentivo_24 As String ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5
    Private _ds_contato As String 'Fran 14/10/2009 i 
    Private _ds_email As String 'Fran 14/10/2009 i 
    Private _ds_email2 As String 'Fran 14/10/2009 i 
    Private _ds_telefone As String 'Fran 14/10/2009 i 
    Private _ds_celular As String 'Fran 14/10/2009 i 
    Private _id_grupo As Int32 'Alexandre 28/05/2010 - chamado 354 i.
    Private _id_estabelecimento_frete As Int32 'fran 12/02/2012 i
    Private _cd_codigo_SAP As String    ' 02/2012 Projeto Themis
    Private _st_gold As String 'fran projeto gold 11/2014 
    Private _st_transferencia As String 'fran 06/2016
    Private _id_tecnico_comquali As Int32 '07/12/2016 - Mirella 
    Private _nm_tecnico_comquali As String '07/12/2016 - Mirella 
    Private _ds_car As String '07/2018 DANGO
    Private _cd_nirf As String '07/2018 DANGO
    Private _cd_nrp As String '07/2018 DANGO
    Private _cd_farms As String '07/2018 DANGO
    Private _dt_expiracao_dqse As String
    Private _id_propriedade_matriz As Int32
    Private _st_tipo_propriedade As String
    Private _st_calculo_com_juros As String

    Public Property id_tecnico_comquali() As Int32 '07/12/2016 - Mirella i
        Get
            Return _id_tecnico_comquali
        End Get

        Set(ByVal value As Int32)
            _id_tecnico_comquali = value
        End Set
    End Property
    Public Property nm_tecnico_comquali() As String
        Get
            Return _nm_tecnico_comquali
        End Get
        Set(ByVal value As String)
            _nm_tecnico_comquali = value
        End Set
    End Property '07/12/2016 - Mirella f
    'Alexandre 28/05/2010 - chamado 354 i.
    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get

        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property
    'Alexandre 28/05/2010 - chamado 354 f.

    Public Property unidadeproducao() As UnidadeProducao

        Get
            Return _unidadeproducao
        End Get

        Set(ByVal value As UnidadeProducao)
            _unidadeproducao = value
        End Set
    End Property

    Public Property nr_qtde_animais() As Int32

        Get
            Return _nr_qtde_animais
        End Get

        Set(ByVal value As Int32)
            _nr_qtde_animais = value
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

    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_estabelecimento_frete() As Int32
        Get
            Return _id_estabelecimento_frete
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento_frete = value
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

    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
        End Set
    End Property

    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property
    Public Property nm_tecnico() As String
        Get
            Return _nm_tecnico
        End Get
        Set(ByVal value As String)
            _nm_tecnico = value
        End Set
    End Property
    Public Property id_tecnico_educampo() As Int32
        Get
            Return _id_tecnico_educampo
        End Get
        Set(ByVal value As Int32)
            _id_tecnico_educampo = value
        End Set
    End Property
    Public Property nm_tecnico_educampo() As String
        Get
            Return _nm_tecnico_educampo
        End Get
        Set(ByVal value As String)
            _nm_tecnico_educampo = value
        End Set
    End Property
    Public Property id_linha() As Int32
        Get
            Return _id_linha
        End Get
        Set(ByVal value As Int32)
            _id_linha = value
        End Set
    End Property
    Public Property nm_linha() As String
        Get
            Return _nm_linha
        End Get
        Set(ByVal value As String)
            _nm_linha = value
        End Set
    End Property
    Public Property id_motivo_inativacao() As Int32
        Get
            Return _id_motivo_inativacao
        End Get
        Set(ByVal value As Int32)
            _id_motivo_inativacao = value
        End Set
    End Property
    Public Property nm_motivo_inativacao() As String
        Get
            Return _nm_motivo_inativacao
        End Get
        Set(ByVal value As String)
            _nm_motivo_inativacao = value
        End Set
    End Property
    Public Property nm_cidade() As String
        Get
            Return _nm_cidade
        End Get
        Set(ByVal value As String)
            _nm_cidade = value
        End Set
    End Property
    Public Property nm_estado() As String
        Get
            Return _nm_estado
        End Get
        Set(ByVal value As String)
            _nm_estado = value
        End Set
    End Property
    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
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
    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
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

    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property

    Public Property dt_reativacao() As String
        Get
            Return _dt_reativacao
        End Get
        Set(ByVal value As String)
            _dt_reativacao = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property

    Public Property nr_preco_negociado() As Decimal
        Get
            Return _nr_preco_negociado
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_negociado = value
        End Set
    End Property

    Public Property nr_capac_granel() As Decimal
        Get
            Return _nr_capac_granel
        End Get
        Set(ByVal value As Decimal)
            _nr_capac_granel = value
        End Set
    End Property
    Public Property nr_capac_ensacado() As Decimal
        Get
            Return _nr_capac_ensacado
        End Get
        Set(ByVal value As Decimal)
            _nr_capac_ensacado = value
        End Set
    End Property

    Public Property nr_vol_leite_dia() As Decimal
        Get
            Return _nr_vol_leite_dia
        End Get
        Set(ByVal value As Decimal)
            _nr_vol_leite_dia = value
        End Set
    End Property

    Public Property cd_inscricao_estadual() As String
        Get
            Return _cd_inscricao_estadual
        End Get
        Set(ByVal value As String)
            _cd_inscricao_estadual = value
        End Set
    End Property

    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
        End Set
    End Property
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property

    Public Property ds_endereco() As String
        Get
            Return _ds_endereco
        End Get
        Set(ByVal value As String)
            _ds_endereco = value
        End Set
    End Property

    Public Property ds_complemento() As String
        Get
            Return _ds_complemento
        End Get
        Set(ByVal value As String)
            _ds_complemento = value
        End Set
    End Property

    Public Property ds_bairro() As String
        Get
            Return _ds_bairro
        End Get
        Set(ByVal value As String)
            _ds_bairro = value
        End Set
    End Property

    Public Property cd_cep() As String
        Get
            Return _cd_cep
        End Get
        Set(ByVal value As String)
            _cd_cep = value
        End Set
    End Property
    Public Property nr_latitude() As Decimal
        Get
            Return _nr_latitude
        End Get
        Set(ByVal value As Decimal)
            _nr_latitude = value
        End Set
    End Property

    Public Property nr_longitude() As Decimal
        Get
            Return _nr_longitude
        End Get
        Set(ByVal value As Decimal)
            _nr_longitude = value
        End Set
    End Property
    Public Property st_considera_qualidade() As String
        Get
            Return _st_considera_qualidade
        End Get
        Set(ByVal value As String)
            _st_considera_qualidade = value
        End Set
    End Property

    Public Property st_incentivo_fiscal() As String
        Get
            Return _st_incentivo_fiscal
        End Get
        Set(ByVal value As String)
            _st_incentivo_fiscal = value
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
    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
        End Set
    End Property
    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
        End Set
    End Property
    Public Property st_periodicidade_coleta() As String
        Get
            Return _st_periodicidade_coleta
        End Get
        Set(ByVal value As String)
            _st_periodicidade_coleta = value
        End Set
    End Property
    Public Property st_tipo_coleta() As String
        Get
            Return _st_tipo_coleta
        End Get
        Set(ByVal value As String)
            _st_tipo_coleta = value
        End Set
    End Property
    Public Property id_linha_par() As Int32

        Get
            Return _id_linha_par
        End Get

        Set(ByVal value As Int32)
            _id_linha_par = value
        End Set
    End Property
    Public Property id_linha_impar() As Int32

        Get
            Return _id_linha_impar
        End Get

        Set(ByVal value As Int32)
            _id_linha_impar = value
        End Set
    End Property
    Public Property nm_linha_par() As String
        Get
            Return _nm_linha_par
        End Get
        Set(ByVal value As String)
            _nm_linha_par = value
        End Set
    End Property
    Public Property nm_linha_impar() As String
        Get
            Return _nm_linha_impar
        End Get
        Set(ByVal value As String)
            _nm_linha_impar = value
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
    Public Property st_transferencia() As String
        Get
            Return _st_transferencia
        End Get
        Set(ByVal value As String)
            _st_transferencia = value
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
    Public Property st_incentivo_24() As String
        Get
            Return _st_incentivo_24
        End Get
        Set(ByVal value As String)
            _st_incentivo_24 = value
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
    Public Property ds_email2() As String
        Get
            Return _ds_email2
        End Get
        Set(ByVal value As String)
            _ds_email2 = value
        End Set
    End Property
    Public Property ds_contato() As String
        Get
            Return _ds_contato
        End Get
        Set(ByVal value As String)
            _ds_contato = value
        End Set
    End Property
    Public Property ds_telefone() As String
        Get
            Return _ds_telefone
        End Get
        Set(ByVal value As String)
            _ds_telefone = value
        End Set
    End Property
    Public Property ds_celular() As String
        Get
            Return _ds_celular
        End Get
        Set(ByVal value As String)
            _ds_celular = value
        End Set
    End Property
    Public Property st_gold() As String
        Get
            Return _st_gold
        End Get
        Set(ByVal value As String)
            _st_gold = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i
    Public Property cd_codigo_SAP() As String
        Get
            Return _cd_codigo_SAP
        End Get
        Set(ByVal value As String)
            _cd_codigo_SAP = value
        End Set
    End Property
    Public Property ds_car() As String
        Get
            Return _ds_car
        End Get
        Set(ByVal value As String)
            _ds_car = value
        End Set
    End Property
    Public Property cd_nirf() As String
        Get
            Return _cd_nirf
        End Get
        Set(ByVal value As String)
            _cd_nirf = value
        End Set
    End Property
    Public Property cd_nrp() As String
        Get
            Return _cd_nrp
        End Get
        Set(ByVal value As String)
            _cd_nrp = value
        End Set
    End Property
    Public Property cd_farms() As String
        Get
            Return _cd_farms
        End Get
        Set(ByVal value As String)
            _cd_farms = value
        End Set
    End Property
    Public Property dt_expiracao_dqse() As String
        Get
            Return _dt_expiracao_dqse
        End Get
        Set(ByVal value As String)
            _dt_expiracao_dqse = value
        End Set
    End Property
    Public Property st_tipo_propriedade() As String
        Get
            Return _st_tipo_propriedade
        End Get
        Set(ByVal value As String)
            _st_tipo_propriedade = value
        End Set
    End Property
    Public Property st_calculo_com_juros() As String
        Get
            Return _st_calculo_com_juros
        End Get
        Set(ByVal value As String)
            _st_calculo_com_juros = value
        End Set
    End Property
    Public Property id_propriedade_matriz() As Int32

        Get
            Return _id_propriedade_matriz
        End Get

        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i

    'Public Property st_coleta_domingo() As String
    '    Get
    '        Return _st_coleta_domingo
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_domingo = value
    '    End Set
    'End Property
    'Public Property st_coleta_segunda() As String
    '    Get
    '        Return _st_coleta_segunda
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_segunda = value
    '    End Set
    'End Property
    'Public Property st_coleta_terca() As String
    '    Get
    '        Return _st_coleta_terca
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_terca = value
    '    End Set
    'End Property
    'Public Property st_coleta_quarta() As String
    '    Get
    '        Return _st_coleta_quarta
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_quarta = value
    '    End Set
    'End Property
    'Public Property st_coleta_quinta() As String
    '    Get
    '        Return _st_coleta_quinta
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_quinta = value
    '    End Set
    'End Property
    'Public Property st_coleta_sexta() As String
    '    Get
    '        Return _st_coleta_sexta
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_sexta = value
    '    End Set
    'End Property
    'Public Property st_coleta_sabado() As String
    '    Get
    '        Return _st_coleta_sabado
    '    End Get
    '    Set(ByVal value As String)
    '        _st_coleta_sabado = value
    '    End Set
    'End Property

    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_propriedade = id
        loadPropriedade()

    End Sub

    Public Function getPropriedadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedade", parameters, "ms_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getPropriedadeAtivaseTransferidas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedadeAtivaseTransferidas", parameters, "ms_propriedade")
            Return dataSet

        End Using

    End Function

    Public Sub loadPropriedade()

        Dim dataSet As DataSet = getPropriedadeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPropriedade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPropriedade", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertPropriedade_UP()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction()
        Try
            'Pega os parametros para inclusão propriedade
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Inclui propriedade
            Me.unidadeproducao.id_propriedade = CType(transacao.ExecuteScalar("ms_insertPropriedade", parameters, ExecuteType.Insert), Int32)
            'Pega os parametros para unidade de produção
            Dim param_up As List(Of Parameters) = ParametersEngine.getParametersFromObject(unidadeproducao)
            'Insere unidade de produção
            transacao.Execute("ms_insertUnidadesProducao", param_up, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.unidadeproducao.id_propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub transbeginPropriedade()

        Using data As New DataAccess

            data.StartTransaction()

        End Using

    End Sub
    Public Sub transcommitPropriedade()

        Using data As New DataAccess

            data.Commit()

        End Using

    End Sub

    Public Sub updatePropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePropriedade", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deletePropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePropriedade", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function validarPropriedade() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedade", parameters, "ms_propriedade")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using


    End Function
    Public Function getNotaFiscalMensagembyPropriedade() As String

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getNotaFiscalMensagembyPropriedade", parameters, ExecuteType.Select), String)

        End Using
    End Function
    'Alexandre - 28/05/2010 chamado 354 i.
    Public Function getRelatorioPropriedade() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioPropriedades", parameters, "ms_propriedade")

            Return dataSet

        End Using
    End Function
    'Alexandre - 28/05/2010 chamado 354 f.
    'chamado 2473 - Mirella 22/08/2016 
    Public Function getPropriedadeRotasExportarExcel() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedadeRotasExportarExcel", parameters, "ms_propriedade")

            Return dataSet

        End Using
    End Function    'chamado 2473 - Mirella 22/08/2016

End Class
