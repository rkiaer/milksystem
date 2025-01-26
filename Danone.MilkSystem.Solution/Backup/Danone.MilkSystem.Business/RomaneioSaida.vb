Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data


<Serializable()> Public Class RomaneioSaida
    'campos ms_romaneio_saida
    Private _id_romaneio_saida As Int32
    Private _id_romaneio_entrada As Int32
    Private _id_estabelecimento As Int32
    Private _id_cooperativa As Int32
    Private _id_transportador As Int32
    Private _id_item As Int32
    Private _id_tipo_operacao As Int32
    Private _id_motivo_saida As Int32
    Private _id_frete_nf As Int32
    Private _id_motorista As Int32
    Private _dt_entrada_estimada As String
    Private _dt_hora_entrada As String
    Private _dt_hora_saida As String
    Private _ds_placa As String
    Private _cd_cnh As String
    Private _nm_motorista As String
    Private _dt_pesagem_inicial As String
    Private _dt_pesagem_final As String
    Private _nr_tara As Decimal
    Private _nr_pesagem_inicial As Decimal
    Private _nr_pesagem_final As Decimal
    Private _nr_peso_liquido As Decimal
    Private _nr_peso_liquido_nota As Decimal
    Private _nr_volume_estimado As Decimal
    Private _nr_preco_unitario_estimado As Decimal
    Private _nr_valor_frete_estimado As Decimal
    Private _nr_valor_nota_fiscal As Decimal
    Private _id_romaneio As Int32
    Private _nr_volume_disponivel As Decimal
    Private _nr_volume_utilizado As Decimal
    Private _id_situacao_romaneio_saida As Int32
    Private _id_st_analise_compartimento As Int32
    Private _st_solicitacao_entrada_transportador As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String

    'Campos apoio Filtro
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _id_situacao As Int32

    'Campos descritivos
    Private _id_romaneio_saida_compartimento As Int32
    Private _ds_estabelecimento As String
    Private _cd_cooperativa As String
    Private _nm_cooperativa As String
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _ds_transportador As String
    Private _cd_cnpj_transportador As String
    Private _nm_item As String
    Private _rc_ds_placa As New ArrayList
    Private _romaneiosaidacompartimento As RomaneioSaidaCompartimento
    Private _cd_cnh_cadastro As String
    Private _nm_motorista_cadastro As String

    'Private _romaneio_saida_compartimento As Romaneio_Saida_Compartimento
    Private _nm_situacao_romaneio_saida As String
    Private _st_reanalise As String
    Private _nm_st_analise_compartimento As String
    Private _rc_id_compartimento As New ArrayList
    Private _rc_nr_total_volume As New ArrayList
    Private _nm_linha As String 'Fran 29/11/2008
    Private _dt_referencia As String 'fran themis
    Private _dt_pesagem_intermediaria As String     ' adri themis 14/05/2012 - chamado 1547
    Private _nr_pesagem_intermediaria As Decimal    ' adri themis 14/05/2012 - chamado 1547
    Private _nr_peso_leiturabalanca_inicial As Decimal ' Mirella themis 14/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nr_peso_leiturabalanca_inter As Decimal ' Mirella themis 14/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nr_peso_leiturabalanca_final As Decimal ' Mirella themis 15/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_inicial As String ' Mirella themis 14/05/2012 - chamado 1547 (datahora que leu a balança , o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_inter As String ' Mirella themis 14/05/2012 - chamado 1547 (datahora que leu a balança , o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_final As String ' Mirella themis 15/05/2012 - chamado 1547 (datahora que leu a balança, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nr_litros_rejeitado As Decimal 'fran  06/2016
    Private _nr_litros_desconto As Decimal 'fran  06/2016
    Private _cd_analise As Int32

    Private _st_selecao As String  ' 0-Não selecionado / 1 Selecionado

    Private _nr_nota_fiscal As String
    Private _nr_serie_nota_fiscal As String

    'Fran 03/2017 - NOTA FRETE  i
    Private _ds_chave_nfe As String 'chave nfe em ms_nota_fiscal
    Private _id_tipo_nota_fiscal As Int32 'Tipo Nota Fiscal em ms_nota_fiscal
    Private _id_natureza_operacao As Int32 'Natureza Operação em ms_nota_fiscal
    'Private _id_frete_nf As Int32 'Frete em ms_nota_fiscal (1-cif opu 2-FOB)
    Private _nr_cte As Int32 'Nr CTE em ms_nota_fiscal
    Private _nr_valor_cte As Decimal 'Valor CTE em ms_nota_fiscal
    Private _ds_chave_cte As String 'chave cte em ms_nota_fiscal
    Public Property id_romaneio_saida() As Int32
        Get
            Return _id_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida = value
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
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
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
    Public Property id_tipo_operacao() As Int32
        Get
            Return _id_tipo_operacao
        End Get
        Set(ByVal value As Int32)
            _id_tipo_operacao = value
        End Set
    End Property
    Public Property id_motivo_saida() As Int32
        Get
            Return _id_motivo_saida
        End Get
        Set(ByVal value As Int32)
            _id_motivo_saida = value
        End Set
    End Property
    Public Property id_frete_nf() As Int32
        Get
            Return _id_frete_nf
        End Get
        Set(ByVal value As Int32)
            _id_frete_nf = value
        End Set
    End Property
    Public Property id_motorista() As Int32
        Get
            Return _id_motorista
        End Get
        Set(ByVal value As Int32)
            _id_motorista = value
        End Set
    End Property
    Public Property dt_entrada_estimada() As String
        Get
            Return _dt_entrada_estimada
        End Get
        Set(ByVal value As String)
            _dt_entrada_estimada = value
        End Set
    End Property
    Public Property dt_hora_entrada() As String
        Get
            Return _dt_hora_entrada
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada = value
        End Set
    End Property
    Public Property dt_hora_saida() As String
        Get
            Return _dt_hora_saida
        End Get
        Set(ByVal value As String)
            _dt_hora_saida = value
        End Set
    End Property
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Property cd_cnh() As String
        Get
            Return _cd_cnh
        End Get
        Set(ByVal value As String)
            _cd_cnh = value
        End Set
    End Property
    Public Property nm_motorista() As String
        Get
            Return _nm_motorista
        End Get
        Set(ByVal value As String)
            _nm_motorista = value
        End Set
    End Property
    Public Property cd_cnh_cadastro() As String
        Get
            Return _cd_cnh_cadastro
        End Get
        Set(ByVal value As String)
            _cd_cnh_cadastro = value
        End Set
    End Property
    Public Property nm_motorista_cadastro() As String
        Get
            Return _nm_motorista_cadastro
        End Get
        Set(ByVal value As String)
            _nm_motorista_cadastro = value
        End Set
    End Property
    Public Property dt_pesagem_inicial() As String
        Get
            Return _dt_pesagem_inicial
        End Get
        Set(ByVal value As String)
            _dt_pesagem_inicial = value
        End Set
    End Property
    Public Property dt_pesagem_final() As String
        Get
            Return _dt_pesagem_final
        End Get
        Set(ByVal value As String)
            _dt_pesagem_final = value
        End Set
    End Property
    Public Property nr_tara() As Decimal
        Get
            Return _nr_tara
        End Get
        Set(ByVal value As Decimal)
            _nr_tara = value
        End Set
    End Property
    Public Property nr_pesagem_inicial() As Decimal
        Get
            Return _nr_pesagem_inicial
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_inicial = value
        End Set
    End Property
    Public Property nr_pesagem_final() As Decimal
        Get
            Return _nr_pesagem_final
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_final = value
        End Set
    End Property
    Public Property nr_peso_liquido() As Decimal
        Get
            Return _nr_peso_liquido
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido = value
        End Set
    End Property
    Public Property nr_peso_liquido_nota() As Decimal
        Get
            Return _nr_peso_liquido_nota
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_nota = value
        End Set
    End Property
    Public Property nr_volume_estimado() As Decimal
        Get
            Return _nr_volume_estimado
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_estimado = value
        End Set
    End Property
    Public Property nr_preco_unitario_estimado() As Decimal
        Get
            Return _nr_preco_unitario_estimado
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_unitario_estimado = value
        End Set
    End Property
    Public Property nr_valor_frete_estimado() As Decimal
        Get
            Return _nr_valor_frete_estimado
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete_estimado = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal() As Decimal
        Get
            Return _nr_valor_nota_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal = value
        End Set
    End Property
    Public Property id_romaneio_entrada() As Int32
        Get
            Return _id_romaneio_entrada
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_entrada = value
        End Set
    End Property
    Public Property nr_volume_disponivel() As Decimal
        Get
            Return _nr_volume_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_disponivel = value
        End Set
    End Property
    Public Property nr_volume_utilizado() As Decimal
        Get
            Return _nr_volume_utilizado
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_utilizado = value
        End Set
    End Property
    Public Property id_situacao_romaneio_saida() As Int32
        Get
            Return _id_situacao_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_saida = value
        End Set
    End Property
    Public Property id_st_analise_compartimento() As Int32
        Get
            Return _id_st_analise_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_st_analise_compartimento = value
        End Set
    End Property
    Public Property st_solicitacao_entrada_transportador() As String
        Get
            Return _st_solicitacao_entrada_transportador
        End Get
        Set(ByVal value As String)
            _st_solicitacao_entrada_transportador = value
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

    'Campos apoio Filtro
    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property
    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
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

    'Campos descritivos
    Public Property id_romaneio_saida_compartimento() As Int32
        Get
            Return _id_romaneio_saida_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_compartimento = value
        End Set
    End Property
    Public Property cd_cooperativa() As String
        Get
            Return _cd_cooperativa
        End Get
        Set(ByVal value As String)
            _cd_cooperativa = value
        End Set
    End Property
    Public Property nm_cooperativa() As String
        Get
            Return _nm_cooperativa
        End Get
        Set(ByVal value As String)
            _nm_cooperativa = value
        End Set
    End Property
    Public Property cd_transportador() As String
        Get
            Return _cd_transportador
        End Get
        Set(ByVal value As String)
            _cd_transportador = value
        End Set
    End Property
    Public Property nm_transportador() As String
        Get
            Return _nm_transportador
        End Get
        Set(ByVal value As String)
            _nm_transportador = value
        End Set
    End Property
    Public Property cd_cnpj_transportador() As String
        Get
            Return _cd_cnpj_transportador
        End Get
        Set(ByVal value As String)
            _cd_cnpj_transportador = value
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
    Public Property cd_analise() As Int32
        Get
            Return _cd_analise
        End Get
        Set(ByVal value As Int32)
            _cd_analise = value
        End Set
    End Property

    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property nr_litros_rejeitado() As Decimal
        Get
            Return _nr_litros_rejeitado
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_rejeitado = value
        End Set
    End Property
    Public Property nr_litros_desconto() As Decimal
        Get
            Return _nr_litros_desconto
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_desconto = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal() As String
        Get
            Return _nr_serie_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal = value
        End Set
    End Property
    Public Property ds_transportador() As String
        Get
            Return _ds_transportador
        End Get
        Set(ByVal value As String)
            _ds_transportador = value
        End Set
    End Property
    Public Property ds_estabelecimento() As String
        Get
            Return _ds_estabelecimento
        End Get
        Set(ByVal value As String)
            _ds_estabelecimento = value
        End Set
    End Property
    Public Property nm_situacao_romaneio_saida() As String
        Get
            Return _nm_situacao_romaneio_saida
        End Get
        Set(ByVal value As String)
            _nm_situacao_romaneio_saida = value
        End Set
    End Property
    Public Property st_reanalise() As String
        Get
            Return _st_reanalise
        End Get
        Set(ByVal value As String)
            _st_reanalise = value
        End Set
    End Property
    Public Property nm_st_analise_compartimento() As String
        Get
            Return _nm_st_analise_compartimento
        End Get
        Set(ByVal value As String)
            _nm_st_analise_compartimento = value
        End Set
    End Property
    Public Property rc_nr_total_volume() As ArrayList
        Get
            Return _rc_nr_total_volume
        End Get
        Set(ByVal value As ArrayList)
            _rc_nr_total_volume = value
        End Set
    End Property
    Public Property rc_ds_placa() As ArrayList
        Get
            Return _rc_ds_placa
        End Get
        Set(ByVal value As ArrayList)
            _rc_ds_placa = value
        End Set
    End Property
    Public Property rc_id_compartimento() As ArrayList
        Get
            Return _rc_id_compartimento
        End Get
        Set(ByVal value As ArrayList)
            _rc_id_compartimento = value
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

    Public Property dt_pesagem_intermediaria() As String
        Get
            Return _dt_pesagem_intermediaria
        End Get
        Set(ByVal value As String)
            _dt_pesagem_intermediaria = value
        End Set
    End Property
    Public Property nr_pesagem_intermediaria() As Decimal
        Get
            Return _nr_pesagem_intermediaria
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_intermediaria = value
        End Set
    End Property
    Public Property nr_peso_leiturabalanca_inicial() As Decimal
        Get
            Return _nr_peso_leiturabalanca_inicial
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_leiturabalanca_inicial = value
        End Set
    End Property
    Public Property dt_leiturabalanca_inicial() As String
        Get
            Return _dt_leiturabalanca_inicial
        End Get
        Set(ByVal value As String)
            _dt_leiturabalanca_inicial = value
        End Set
    End Property
    Public Property nr_peso_leiturabalanca_inter() As Decimal
        Get
            Return _nr_peso_leiturabalanca_inter
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_leiturabalanca_inter = value
        End Set
    End Property
    Public Property nr_peso_leiturabalanca_final() As Decimal
        Get
            Return _nr_peso_leiturabalanca_final
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_leiturabalanca_final = value
        End Set
    End Property
    Public Property dt_leiturabalanca_inter() As String
        Get
            Return _dt_leiturabalanca_inter
        End Get
        Set(ByVal value As String)
            _dt_leiturabalanca_inter = value
        End Set
    End Property
    Public Property dt_leiturabalanca_final() As String
        Get
            Return _dt_leiturabalanca_final
        End Get
        Set(ByVal value As String)
            _dt_leiturabalanca_final = value
        End Set
    End Property

    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property

    Public Property ds_chave_nfe() As String
        Get
            Return _ds_chave_nfe
        End Get
        Set(ByVal value As String)
            _ds_chave_nfe = value
        End Set
    End Property
    Public Property id_tipo_nota_fiscal() As Int32
        Get
            Return _id_tipo_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_tipo_nota_fiscal = value
        End Set
    End Property
    Public Property id_natureza_operacao() As Int32
        Get
            Return _id_natureza_operacao
        End Get
        Set(ByVal value As Int32)
            _id_natureza_operacao = value
        End Set
    End Property
    Public Property nr_cte() As Int32
        Get
            Return _nr_cte
        End Get
        Set(ByVal value As Int32)
            _nr_cte = value
        End Set
    End Property
    Public Property nr_valor_cte() As Decimal
        Get
            Return _nr_valor_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_cte = value
        End Set
    End Property
    Public Property ds_chave_cte() As String
        Get
            Return _ds_chave_cte
        End Get
        Set(ByVal value As String)
            _ds_chave_cte = value
        End Set
    End Property
    Public Property romaneiosaidacompartimento() As RomaneioSaidaCompartimento

        Get
            Return _romaneiosaidacompartimento
        End Get

        Set(ByVal value As RomaneioSaidaCompartimento)
            _romaneiosaidacompartimento = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_romaneio_saida = id
        loadRomaneioSaida()

    End Sub

    Public Function getRomaneioSaidaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaida", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaFechar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaFechar", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaTodosAnexos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaTodosAnexos", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaSolicitarNota() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaSolicitarNota", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaSolicitarAbertura() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaSolicitarAbertura", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioComplementarVolume() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioComplementarVolume", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneiosComplementarByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneiosComplementar", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneiosComplementarCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneiosComplementarCooperativa", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneioSaida()

        Dim dataSet As DataSet = getRomaneioSaidaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertRomaneioAnaliseCompartimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertRomaneioSaida() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioSaida", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Function insertRomaneioSaidaSolicitacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioSaidaSolicitacao", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertRomaneioSaidaSituacaoLog() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertRomaneioCooperativabyNota() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioCooperativabyNota", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    'Public Function abrirRomaneio()

    '    Dim transacao As New DataAccess
    '    'Inicia Transação
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclusão romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'Inclui romaneio
    '        Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
    '        parameters = ParametersEngine.getParametersFromObject(Me)
    '        'Pega os parametros para romaneio_compartimento
    '        Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'Insere romaneio compartimento
    '        transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)

    '        'Insere romaneio compartimento unidade producao
    '        transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)

    '        'Insere romaneio placas
    '        transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
    '        'Atualiza a Placa Principal
    '        transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
    '        'fran 26/11/2009 - Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado
    '        'Insere Analise Compartimento
    '        'transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)
    '        'fran 26/11/2009 f- Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado

    '        'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
    '        transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
    '        'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
    '        transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

    '        'Insere romaneio mapa de leite
    '        'transacao.Execute("ms_insertRomaneioMapaLeite", param_comp, ExecuteType.Insert)

    '        'Insere romaneio analise global
    '        'transacao.Execute("ms_insertRomaneioAnaliseGlobal", param_comp, ExecuteType.Insert)

    '        'Comita
    '        transacao.Commit()
    '        transacao.Dispose()     ' 14/11/2008
    '        'Retorna ao id da propriedade
    '        Return Me.id_romaneio
    '    Catch err As Exception
    '        transacao.RollBack()
    '        transacao.Dispose()     ' 14/11/2008
    '        Throw New Exception(err.Message)
    '    End Try
    'End Function
    Public Function abrirRomaneioSaidaSolicitado()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dsplacaprincipal As String = Me.ds_placa

            transacao.Execute("ms_updateRomaneioSaidaAberturaSolicitado", parameters, ExecuteType.Update)

            'Insere romaneio placas
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.ds_placa = Me.rc_ds_placa(i).ToString
                'Pega os parametros para romaneio placa
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_insertRomaneioSaidaPlaca", parameters, ExecuteType.Insert)
            Next

            Me.ds_placa = dsplacaprincipal
            Me.id_situacao = Me.id_situacao_romaneio_saida
            parameters = ParametersEngine.getParametersFromObject(Me)

            'Atualiza a Placa Principal
            transacao.Execute("ms_updateRomaneioSaidaPlacaStPrincipal", parameters, ExecuteType.Update)
            'atualiza o log de situacao
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio_saida
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function abrirRomaneioCooperativabyNota()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativabyNota", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)
            'Me.romaneio_compartimento = New Romaneio_Compartimento
            ''Pega os parametros para romaneio_compartimento
            'Me.romaneio_compartimento.id_romaneio = Me.id_romaneio
            'Me.romaneio_compartimento.id_modificador = Me.id_modificador
            'For i As Integer = 0 To rc_ds_placa.Count - 1
            '    Me.romaneio_compartimento.ds_placa = Me.rc_ds_placa(i).ToString
            '    Me.romaneio_compartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
            '    Me.romaneio_compartimento.nr_total_litros = Me.rc_nr_total_volume(i)
            '    'Pega os parametros para romaneio_compartimento
            '    Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio_compartimento)
            '    transacao.Execute("ms_insertRomaneioCompartimentoCooperativa", param_comp, ExecuteType.Insert)
            'Next

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)
            'Fran 30/09/2008 i - pesagem inicial na tela de cooperativa
            'atualiza o romaneio para status ABERTO pois já informou dados de pesagem
            transacao.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)

            'Fran 05/01/2011 - GKO item 1 i
            'Me.id_nota_fiscal = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativaNotaFiscal", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_insertRomaneioCooperativaItemNota", parameters, ExecuteType.Insert)
            'Fran 05/01/2011 - GKO item 1 f

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function gerarRomaneioReanalises()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza todas as análise para reanalise = S, e limpa os status dastabelas de romaneio
            transacao.Execute("ms_updateRomaneioAnalisesReanalise", parameters, ExecuteType.Update)

            'Insere Analise Compartimento, como se estivesse iniciando processo
            transacao.Execute("ms_insertRomaneioAnaliseCompartimentoReanalise", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    'Public Sub FecharRomaneio()

    '    Dim transacao As New DataAccess
    '    Dim dsromcomprejeitado As New DataSet
    '    Dim dsrow As DataRow
    '    Dim dsrowprop As DataRow
    '    Dim inr_count_propriedades As Integer
    '    Dim nr_saldo_litros As Decimal
    '    Dim nr_desconto_primprop As Decimal
    '    Dim nr_desconto_propriedade As Decimal
    '    Dim laux As Decimal
    '    Dim dsruppropriedades As New DataSet

    '    'Inicia Transação
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclusão romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'Atualizar romaneio
    '        transacao.Execute("ms_updateRomaneioFechar", parameters, ExecuteType.Update)
    '        'Atualizar pesagens
    '        transacao.Execute("ms_updateRomaneioPesagens", parameters, ExecuteType.Update)

    '        transacao.Execute("ms_updateRomaneioDataColetaFechamento", parameters, ExecuteType.Update) 'fran 28/12/2020 i atualiza data de coleta da uproducao se o fechamento for em mes diferente da coleta(1o dia do mes)

    '        If Me.id_cooperativa > 0 Then
    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteCooperativa", parameters, ExecuteType.Insert)

    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteDescartadoCooperativa", parameters, ExecuteType.Insert)
    '        Else
    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)
    '        End If

    '        'If Me.st_romaneio_transbordo = "S" Then
    '        '    transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
    '        'End If

    '        'Fran 30/11/2008 i - Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
    '        transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
    '        Dim li As Integer = 0
    '        'fran i 06/2016- apurar rejeicao antibiotico para geração da conta 0114 em conta parcelada do saldo do leite bom que foi misturado com antibiotico
    '        'maracanau nao tem a mesma regra... so cria conta antibiotico para poços
    '        '' ''If (Me.nr_caderneta > 0) And (Me.id_estabelecimento <> 9) Then 'romaneio de produtor
    '        '' ''    'Buscar os compartimentos e diferença do volume rejeitado da propriedade para o volume total do compartimento, ou seja deve buscar o valor de leite bom que foi misturado ao de antibiotico para que o produtor possa paga-lo
    '        '' ''    transacao.Fill(dsromcomprejeitado, "ms_getRomaneioCompartimentoRejeicaoAntibiotico", parameters, "ms_romaneio_compartimento")
    '        '' ''    For Each dsrow In dsromcomprejeitado.Tables(0).Rows
    '        '' ''        Me.id_romaneio_compartimento = dsrow.Item("id_romaneio_compartimento")
    '        '' ''        'quantas propriedades vao ratear o volume
    '        '' ''        inr_count_propriedades = dsrow.Item("nr_count_propriedades")
    '        '' ''        Me.nr_litros_rejeitado = dsrow.Item("nr_litros_rejeitados_compartimento")
    '        '' ''        'o total a ser rateado (litros de leite bom)
    '        '' ''        nr_saldo_litros = dsrow.Item("nr_saldo_litros")
    '        '' ''        'o valor de cada propriedade
    '        '' ''        nr_desconto_propriedade = dsrow.Item("nr_desconto_propriedade")
    '        '' ''        If inr_count_propriedades = 1 Then
    '        '' ''            'se ttem apenas uma propriedade, arredonda sem deciamis pois volume leite deve ser inteiro
    '        '' ''            nr_desconto_primprop = Round(nr_desconto_propriedade, 0)
    '        '' ''        Else
    '        '' ''            'se o valor deve ser dividido entre mais de umma propriedade, joga os litros perdidos para a primeira
    '        '' ''            laux = Round((nr_desconto_propriedade - Truncate(nr_desconto_propriedade)) * inr_count_propriedades, 0)
    '        '' ''            nr_desconto_primprop = Truncate(nr_desconto_propriedade) + laux
    '        '' ''            nr_desconto_propriedade = Truncate(nr_desconto_propriedade)
    '        '' ''        End If

    '        '' ''        'Busca quais sao as propriedades que devem pagar o leite, as que tiveram rejeicao antibiotico
    '        '' ''        li = 0
    '        '' ''        parameters = ParametersEngine.getParametersFromObject(Me)
    '        '' ''        transacao.Fill(dsruppropriedades, "ms_getRomaneioUProducaoPropriedadesRejeicaoAntibiotico", parameters, "ms_romaneio_uproducao")
    '        '' ''        For Each dsrowprop In dsruppropriedades.Tables(0).Rows
    '        '' ''            li = li + 1
    '        '' ''            Me.id_propriedade = dsrowprop.Item("id_propriedade")
    '        '' ''            Me.dt_referencia = DateTime.Parse(dsrowprop.Item("dt_referencia")).ToString("dd/MM/yyyy")
    '        '' ''            'se for a primeira propriedade joga o volume dividido + o decimal
    '        '' ''            If li = 1 Then
    '        '' ''                Me.nr_litros_desconto = nr_desconto_primprop
    '        '' ''            Else
    '        '' ''                Me.nr_litros_desconto = nr_desconto_propriedade
    '        '' ''            End If
    '        '' ''            parameters = ParametersEngine.getParametersFromObject(Me)
    '        '' ''            transacao.Execute("ms_insertRomaneioContaParcelada", parameters, ExecuteType.Insert)

    '        '' ''        Next 'proxima propriedade
    '        '' ''    Next 'proximo romaneio compartimento

    '        '' ''End If
    '        'fran f 06/2016
    '        'Comita
    '        transacao.Commit()
    '        'Retorna ao id da propriedade
    '        'Return Me.id_romaneio
    '    Catch err As Exception
    '        transacao.RollBack()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    'fran 26/03/2012 - themis
    'Public Sub RegerarRomaneioMapaLeite()

    '    Dim transacao As New DataAccess
    '    'Inicia Transação
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclusão romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'deletar mapa de leite
    '        transacao.Execute("ms_deleteRomaneioMapaLeite", parameters, ExecuteType.Delete)

    '        'Insere romaneio mapa de leite
    '        transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

    '        'Insere romaneio mapa de leite
    '        transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)

    '        If Me.st_romaneio_transbordo = "S" Then
    '            transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
    '        End If

    '        ' Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
    '        transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)


    '        'Comita
    '        transacao.Commit()
    '        'Retorna ao id da propriedade
    '        'Return Me.id_romaneio
    '    Catch err As Exception
    '        transacao.RollBack()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    Public Function registrarAnaliseGlobalPositiva()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)

            'Atualiza status da analise global no romaneio
            transacao.Execute("ms_updateRomaneioStatusAnaliseGlobal", parameters, ExecuteType.Update)


            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function registrarRomSaidaAnaliseCompartimentoRejeitada()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.romaneiosaidacompartimento)

            'Atualiza status em Romaneio Compartimento
            transacao.Execute("ms_updateRomaneioSaidaCompartimento", params, ExecuteType.Update)


            'Atualiza status da analise compartimento no romaneio
            transacao.Execute("ms_updateRomaneioSaidaStatusAnaliseCompartimento", parameters, ExecuteType.Update)

            'Atualiza todos os compartimentos do romaneio com o nome do analista e a hora (nova tela)
            Me.romaneiosaidacompartimento.id_romaneio_saida_compartimento = 0
            params = ParametersEngine.getParametersFromObject(Me.romaneiosaidacompartimento)
            transacao.Execute("ms_updateRomaneioSaidaCompartimentoAnalista", params, ExecuteType.Update)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function registrarRomSaidaAnaliseCompartimentoAprovada()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.romaneiosaidacompartimento)

            'Atualiza status em Romaneio Compartimento
            transacao.Execute("ms_updateRomaneioSaidaCompartimento", params, ExecuteType.Update)

            'Dim romaneiocompartimento As New Romaneio_Compartimento
            'romaneiocompartimento.id_romaneio = Me.id_romaneio
            'Pega todos os compartimentos rejeitados (status 3 ) e diferentes de nmulo
            'verifica se tem algum comp rejeitado
            Dim dataSet As New DataSet
            transacao.Fill(dataSet, "ms_getRomaneioSaidaCompartimentoSituacaoRejeitados", parameters, "ms_romaneio_saida_compartimento")
            'se não tem ninguem rejeitado
            If (dataSet.Tables(0).Rows.Count = 0) Then
                'Atualiza status da analise compartimento no romaneio para aprovado
                'parameters.Find(
                transacao.Execute("ms_updateRomaneioSaidaStatusAnaliseCompartimento", parameters, ExecuteType.Update)

            End If

            'Atualiza todos os compartimentos do romaneio com o nome do analista e a hora (nova tela)
            Me.romaneiosaidacompartimento.id_romaneio_saida_compartimento = 0
            params = ParametersEngine.getParametersFromObject(Me.romaneiosaidacompartimento)
            transacao.Execute("ms_updateRomaneioSaidaCompartimentosAnalista", params, ExecuteType.Update)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio_saida
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Sub updateRomaneioStatusAnaliseGlobal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioStatusAnaliseGlobal", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioStatusAnaliseCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioStatusAnaliseCompartimento", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaVolume", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaCancelarAbertura()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaCancelarAbertura", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaSolicitacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaSolicitacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaFechar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaFechar", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaPesagens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaPesagens", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaPesagemFinal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaPesagemFinal", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSaidaSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioSaidaCarregadoEmAnalise() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaCarregadoEmAnalise", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaControleSaida() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaControleSaida", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaAbertoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaAberto", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaAnalisadosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaAnalisados", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaSolicitacaoNF() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaSolicitacaoNF", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    'fran 02/03/2012 i Themis - Batch
    'Public Function getRomaneioRegistrosFinais() As DataSet

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getRomaneioRegistrosFinais", parameters, "ms_romaneio")
    '        Return dataSet

    '    End Using

    'End Function
    ''fran 02/03/2012 f Themis - Batch

    'Public Function getRomaneioFecharEmAnaliseByFilters() As DataSet

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getRomaneioFecharEmAnalise", parameters, "ms_romaneio")
    '        Return dataSet

    '    End Using

    'End Function
    Public Function getRomaneioSaidaAnaliseCompartimentoDistinct() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaAnaliseCompartimentoDistinct", parameters, "ms_romaneio_saida_analise_compartimento")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaAnaliseNullNavegacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaAnaliseNullNavegacao", parameters, "ms_romaneio_saida_analise_compartimento")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioSaidaCompartimentoMediaDens() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSaidaCompartimentoMediaDens", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    'Public Function getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    'Public Function getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    'Public Function getRomaneioCompartimentosSomaVolumebyRomaneio() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumebyRomaneio", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function

    'Public Function getRomaneioSomaCadernetasbyNotaTransf() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioSomaCadernetasbyNotaTransf", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    'Public Function getRomaneioSomaVolumebyCadernetas() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioSomaVolumebyCadernetas", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    Public Function FecharRomaneioConsistir() As Boolean

        Dim isvalid As Boolean = True
        FecharRomaneioConsistir = True
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            If exc_AnaliseObrigatoriaCompartimentoNula(Me.id_romaneio) = False Then
                FecharRomaneioConsistir = False
                isvalid = False
                Throw New Exception("Há análises obrigatórias de Compartimentos sem preenchimento de resultado. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            End If

            'If isvalid = True Then
            '    If exc_AnaliseObrigatoriaUproducaoNula(Me.id_romaneio) = False Then
            '        FecharRomaneioConsistir = False
            '        isvalid = False
            '        Throw New Exception("Há análises obrigatórias de Unidades de Produção/Produtores sem preenchimento de resultado. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            '    End If
            'End If
            'If isvalid = True Then
            'If exc_LacresSaidaNulo(Me.id_romaneio) = False Then
            'isvalid = False
            'Throw New Exception("Para fechar o romaneio todos os lacres de saída devem ser informados no menu 'Registros Finais'.")
            'End If
            'End If
            'Fran 29/02/2012 i - Themis - Batch - Permitir finalizar romanei semfinalizar preenchimento dos regsitros finais (será realizado depois)
            'If isvalid = True Then
            '    If exc_RegistrosFinaisNulo(Me.id_romaneio) = False Then
            '        FecharRomaneioConsistir = False
            '        isvalid = False
            '        Throw New Exception("Para fechar o romaneio todas as informações das placas no menu 'Registros Finais' devem ser preenchidas.")
            '    End If
            'End If
            'Fran 29/02/2012 f - Themis - Batch - Permitir finalizar romanei semfinalizar preenchimento dos regsitros finais (será realizado depois)
        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Function


    Public Function exc_AnaliseObrigatoriaCompartimentoNula(ByVal id_romaneio As Int32) As Boolean
        Try
            Dim isvalid As Boolean = True

            Dim analisescomp As New RomaneioAnaliseCompartimento
            analisescomp.id_romaneio = id_romaneio
            If analisescomp.getRomaneioAnaliseCompartimentoSemResultado > 0 Then
                isvalid = False
            End If

            exc_AnaliseObrigatoriaCompartimentoNula = isvalid

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function exc_RegistrosFinaisNulo(ByVal id_romaneio As Int32) As Boolean
        Try
            'Verifica se o romaneio placa foi preenchido pela coluna dt_ini_descarga
            Dim isvalid As Boolean = True

            Dim placas As New RomaneioPlaca

            placas.id_romaneio = id_romaneio
            If placas.getRomaneioPlacasNulasByRomaneio > 0 Then
                isvalid = False
            End If

            exc_RegistrosFinaisNulo = isvalid

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function getRomaneioSomaControleLeitebyDia() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioControleLeiteSomabyDia", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function

    Private Function FormataCampo(ByVal pString) As String


        Try

            Dim lString As String

            lString = pString
            lString = Replace(lString, ".", "")
            lString = Replace(lString, "/", "")
            lString = Replace(lString, "-", "")

            FormataCampo = lString



        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function formatarTexto(ByVal texto As String) As String
        Try
            Dim ltexto As String

            ltexto = texto

            ltexto = Replace(ltexto, "á", "a")
            ltexto = Replace(ltexto, "à", "a")
            ltexto = Replace(ltexto, "ã", "a")
            ltexto = Replace(ltexto, "â", "a") 'Fran chamado 840 20/05/2010
            ltexto = Replace(ltexto, "Á", "A")
            ltexto = Replace(ltexto, "À", "A")
            ltexto = Replace(ltexto, "Ã", "A")
            ltexto = Replace(ltexto, "Â", "A") 'Fran chamado 840 20/05/2010
            ltexto = Replace(ltexto, "é", "e")
            ltexto = Replace(ltexto, "ê", "e")
            ltexto = Replace(ltexto, "É", "E")
            ltexto = Replace(ltexto, "Ê", "E")
            ltexto = Replace(ltexto, "í", "i")
            ltexto = Replace(ltexto, "Í", "I")
            ltexto = Replace(ltexto, "ó", "o")
            ltexto = Replace(ltexto, "ô", "o")
            ltexto = Replace(ltexto, "õ", "o")
            ltexto = Replace(ltexto, "Ó", "O")
            ltexto = Replace(ltexto, "Ô", "O")
            ltexto = Replace(ltexto, "Õ", "O")
            ltexto = Replace(ltexto, "ú", "u")
            ltexto = Replace(ltexto, "Ú", "U")
            ltexto = Replace(ltexto, "ü", "u")
            ltexto = Replace(ltexto, "Ü", "U")
            ltexto = Replace(ltexto, "'", " ")
            ltexto = Replace(ltexto, "ç", "c")
            ltexto = Replace(ltexto, "Ç", "C")
            ltexto = Replace(ltexto, ",", " ")


            formatarTexto = ltexto
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
    Public Sub updateRomaneioSaidaPesagemInicial() 'chamado 1547 - Mirellla i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaPesagemInicial", parameters, ExecuteType.Update)

        End Using

    End Sub
    'Public Sub updateRomaneioPesagemIntermediaria()

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        data.Execute("ms_updateRomaneioPesagemIntermediaria", parameters, ExecuteType.Update)

    '    End Using

    'End Sub
    Public Function getRomaneioSaidaPesagemBalanca() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaPesagemBalanca", parameters, "ms_romaneio_saida")
            Return dataSet

        End Using

    End Function
    '  14/05/2012 - chamado 1547 - f

    ' adri 01/02/2013 chamado 1644 - Atualiza romaneio e cria análises em transação - i
    Public Function ComplementarRomaneioAnaliseCompartimento() As Int32


        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza romaneio
            transacao.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)

            'Insere romaneio analise compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)


            'Comita
            transacao.Commit()
            transacao.Dispose()

            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try

    End Function
    ' adri 01/02/2013 chamado 1644 - Atualiza romaneio e cria análises em transação - f
    Public Function abrirRomaneioSaidabyRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)


            'Inclui romaneio
            Me.id_romaneio_saida = CType(transacao.ExecuteScalar("ms_insertRomaneioSaidabyRomaneio", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)
            Me.romaneiosaidacompartimento = New RomaneioSaidaCompartimento
            'Pega os parametros para romaneio_compartimento
            Me.romaneiosaidacompartimento.id_romaneio_saida = Me.id_romaneio_saida
            Me.romaneiosaidacompartimento.id_modificador = Me.id_modificador
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.romaneiosaidacompartimento.ds_placa = Me.rc_ds_placa(i).ToString
                Me.romaneiosaidacompartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
                Me.romaneiosaidacompartimento.nr_total_litros = Me.rc_nr_total_volume(i)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneiosaidacompartimento)
                transacao.Execute("ms_insertRomaneioSaidaCompartimento", param_comp, ExecuteType.Insert)
            Next

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioSaidaPlacasbyRomaneio", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateRomaneioSaidaPlacaStPrincipal", parameters, ExecuteType.Update)
            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioSaidaAnaliseCompartimento", parameters, ExecuteType.Insert)
            'atualiza o romaneio para status CARREGADO pois já informou dados de pesagem
            transacao.Execute("ms_updateRomaneioSaida", parameters, ExecuteType.Update)

            ''Fran 05/01/2011 - GKO item 1 i
            'Me.id_nota_fiscal = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativaNotaFiscal", parameters, ExecuteType.Insert), Int32)
            'parameters = ParametersEngine.getParametersFromObject(Me)
            'transacao.Execute("ms_insertRomaneioCooperativaItemNota", parameters, ExecuteType.Insert)
            ''Fran 05/01/2011 - GKO item 1 f
            'atualiza o log de situacao
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio_saida
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Function incluirRomaneioSaidaCompartimento()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Me.romaneiosaidacompartimento = New RomaneioSaidaCompartimento
            'Pega os parametros para romaneio_compartimento
            Me.romaneiosaidacompartimento.id_romaneio_saida = Me.id_romaneio_saida
            Me.romaneiosaidacompartimento.id_modificador = Me.id_modificador
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.romaneiosaidacompartimento.ds_placa = Me.rc_ds_placa(i).ToString
                Me.romaneiosaidacompartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
                Me.romaneiosaidacompartimento.nr_total_litros = Me.rc_nr_total_volume(i)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneiosaidacompartimento)
                transacao.Execute("ms_insertRomaneioSaidaCompartimento", param_comp, ExecuteType.Insert)
            Next

            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioSaidaAnaliseCompartimento", parameters, ExecuteType.Insert)
            'atualiza o romaneio para status CARREGADO e o volume estimado
            transacao.Execute("ms_updateRomaneioSaidaVolume", parameters, ExecuteType.Update)

            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio_saida
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function

End Class
