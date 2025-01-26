Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data


<Serializable()> Public Class Romaneio
    Private _id_romaneio As Int32
    Private _id_romaneio_compartimento As Int32
    Private _id_romaneio_transbordo As Int32
    Private _id_estabelecimento As Int32
    Private _id_estabelecimento_frete As Int32
    Private _id_cooperativa As Int32
    Private _cd_cooperativa As String
    Private _nm_cooperativa As String
    Private _id_transportador As Int32
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _cd_cnpj_transportador As String 'fran 24/02/2012 frete
    Private _cd_cnh As String
    Private _nm_motorista As String
    Private _id_motorista As Int32
    Private _ds_placa As String
    Private _id_linha As Int32
    Private _ds_linha As String
    Private _dt_hora_entrada As String
    Private _dt_hora_entrada_ini As String 'fran 23/09/2009 i
    Private _dt_hora_entrada_fim As String 'fran 23/09/2009 f
    Private _dt_hora_saida As String
    Private _dt_hora_saida_ini As String 'fran 03/2017 i
    Private _dt_hora_saida_fim As String 'fran 03/2017 f
    Private _dt_pesagem_inicial As String
    Private _dt_pesagem_final As String
    Private _nr_tara As Decimal
    Private _nr_pesagem_inicial As Decimal
    Private _nr_pesagem_final As Decimal
    Private _nr_peso_liquido As Decimal
    Private _nr_peso_liquido_caderneta As Decimal
    Private _nr_peso_liquido_nota As Decimal
    Private _nr_nota_fiscal As String
    Private _nr_serie_nota_fiscal As String
    Private _nr_valor_nota_fiscal As Decimal
    Private _dt_saida_nota As String
    Private _id_item As Int32
    Private _nm_item As String
    Private _nr_caderneta As Int32
    Private _id_st_romaneio As Int32
    Private _id_st_romaneio_ini As Int32
    Private _id_st_analise_global As Int32
    Private _id_st_analise_compartimento As Int32
    Private _id_st_analise_uproducao As Int32
    Private _id_coleta_transmissao As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _romaneio_compartimento As Romaneio_Compartimento
    Private _ds_estabelecimento As String
    Private _ds_transportador As String
    Private _nm_st_romaneio As String
    Private _st_reanalise As String
    Private _nm_st_analise_compartimento As String
    Private _nm_st_analise_uproducao As String
    Private _data_inicio As String
    Private _data_fim As String
    Private _rc_ds_placa As New ArrayList
    Private _rc_id_compartimento As New ArrayList
    Private _rc_nr_total_volume As New ArrayList
    Private _id_linha_ini As Int32
    Private _id_linha_fim As Int32
    Private _nr_peso_liquido_nota_transf As Decimal
    Private _nr_nota_fiscal_transf As String
    Private _nr_serie_nota_fiscal_transf As String
    Private _dt_emissao_nota_transf As String
    Private _st_romaneio_transbordo As String
    Private _st_romaneio_transbordo_nulo As String
    Private _total_volume_max_compartimentos As Decimal
    Private _dt_transmissao_ini As String 'Fran 29/11/2008
    Private _dt_transmissao_fim As String 'Fran 29/11/2008
    Private _dt_transmissao As String 'Fran 29/11/2008
    Private _nm_linha As String 'Fran 29/11/2008
    Private _ds_placa_frete As String
    Private _path_arquivofrete As String
    Private _st_exportacao_frete As String
    Private _dt_exportacao_frete As String
    Private _id_exportacao_frete_execucao As Int32
    Private _id_exportacao_frete_execucao_itens As Int32
    Private _id_nota_fiscal As Int32  'Fran 05/11/2011 gko
    Private _id_registro_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_registro_exportacao_batch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_usuario_registro_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _st_exportacao_batch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_exportacao_batch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_usuario_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_exportacao_batch_execucao As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_exportacao_batch_itens As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _path_arquivobatch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_referencia As String 'fran themis
    Private _id_propriedade As Int32 'fran themis 30/03/2012
    Private _dt_pesagem_intermediaria As String     ' adri themis 14/05/2012 - chamado 1547
    Private _nr_pesagem_intermediaria As Decimal    ' adri themis 14/05/2012 - chamado 1547
    Private _nr_peso_leiturabalanca_inicial As Decimal ' Mirella themis 14/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nr_peso_leiturabalanca_inter As Decimal ' Mirella themis 14/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nr_peso_leiturabalanca_final As Decimal ' Mirella themis 15/05/2012 - chamado 1547 (valor que a balança devolveu, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_inicial As String ' Mirella themis 14/05/2012 - chamado 1547 (datahora que leu a balança , o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_inter As String ' Mirella themis 14/05/2012 - chamado 1547 (datahora que leu a balança , o usuário pode alterar por isto estamos salvando o valor lido)
    Private _dt_leiturabalanca_final As String ' Mirella themis 15/05/2012 - chamado 1547 (datahora que leu a balança, o usuário pode alterar por isto estamos salvando o valor lido)
    Private _nm_linha_ini As String ' adri themis 02/08/2012 - chamado 1577 
    Private _nm_linha_fim As String ' adri themis 02/08/2012 - chamado 1577 
    Private _nr_litros_rejeitado As Decimal 'fran  06/2016
    Private _nr_litros_desconto As Decimal 'fran  06/2016
    Private _cadernetas As String ' fran 10/09 lista de cadernetas
    Private _st_tipo_romaneio_cooperativa As String

    ' adri 11/2016 - chamado 2491 - Conciliação Frete x Romaneio - i
    Private _id_divergencia_km_frete As Int32  ' 1 Sem divergências / 2 Com divergências
    Private _id_aprovacao_km_frete As Int32  ' 1 Aprovado / 2 Não Aprovado / 3 Aguardando Aprovação
    Private _st_selecao As String  ' 0-Não selecionado / 1 Selecionado
    Private _nr_km_frete As Decimal
    Private _id_justificativa_km_frete As Int32
    ' adri 11/2016 - chamado 2491 - Conciliação Frete x Romaneio - f
    'fran 12/2016 - TransitPoint
    Private _id_pre_romaneio_transit_point As Int32 'criada para guardar o pre_romaneio de romaneios criados por rejeicao
    Private _id_transit_point_unidade As Int32
    Private _id_transit_point As Int32  ' Indica qual é o transit point para o Romaneio aberto de um Transit Point
    Private _id_transit_point_frete As Int32  ' Indica no pre-romaneio qual é o transit point responsavel por pagar o frete do pre romaneio
    Private _nr_total_litros_tp_disponivel As Decimal 'total de litros do pre romaneio disponiveis para serem utilizados no transit point
    Private _nr_total_litros_tp_transferidos As Decimal 'total de litros do pre romaneio já transferidos para algum caminhao de transit point

    'Fran 03/2017 - NOTA FRETE  i
    Private _ds_chave_nfe As String 'chave nfe em ms_nota_fiscal
    Private _id_tipo_nota_fiscal As Int32 'Tipo Nota Fiscal em ms_nota_fiscal
    Private _id_natureza_operacao As Int32 'Natureza Operação em ms_nota_fiscal
    Private _id_frete_nf As Int32 'Frete em ms_nota_fiscal (1-cif opu 2-FOB)
    Private _nr_cte As Int32 'Nr CTE em ms_nota_fiscal
    Private _nr_valor_cte As Decimal 'Valor CTE em ms_nota_fiscal
    Private _ds_chave_cte As String 'chave cte em ms_nota_fiscal
    Private _id_tipo_nota_fiscal2 As Int32 'Tipo Nota Fiscal 2 em ms_nota_fiscal
    Private _nr_nota_fiscal2 As String 'numero nota fiscal 2 em ms_nota_fiscal
    Private _nr_serie_nota_fiscal2 As String 'numero serie nota fiscal 2 em ms_nota_fiscal
    Private _nr_valor_nota_fiscal2 As Decimal ' valor nota fiscal 2 em ms_nota_fiscal
    Private _nr_litros_nota_fiscal2 As Decimal 'litros nota fiscal 2 em ms_nota_fiscal
    Private _cd_cfop_cte As String
    Private _dt_emissao_completa_cte As String
    Private _nr_base_icms_cte As Decimal
    Private _cd_uf_origem_cte As String
    Private _cd_uf_destino_cte As String
    Private _cd_ibge_origem_cte As String
    Private _cd_ibge_destino_cte As String
    Private _ds_protocolo_cte As String
    'Fran 03/2017 - NOTA FRETE  f
    Private _nr_tempo_rota_ini As Int32
    Private _nr_tempo_rota_fim As Int32
    Private _nr_serie_cte As String
    Private _cd_cst_cte As String
    Private _nr_valor_icms_cte As Decimal
    Private _cd_cfop As String

    Private _st_leite_total_rejeitado As String
    Private _ds_cd_protocolo_esalq As String
    Private _id_tipo_coleta As Int32
    Private _id_ciq As Int32
    Private _id_ciq_documentos As Int32
    Private _id_romaneio_ciq_documentos As Int32
    Private _id_romaneio_uproducao As Int32
    Private _nm_documento As String
    Private _id_transvase As Int32
    Private _nr_po_cooperativa As String
    Private _cd_analise As Int32

    Public Property romaneio_compartimento() As Romaneio_Compartimento

        Get
            Return _romaneio_compartimento
        End Get

        Set(ByVal value As Romaneio_Compartimento)
            _romaneio_compartimento = value
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
    Public Property id_pre_romaneio_transit_point() As Int32
        Get
            Return _id_pre_romaneio_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_pre_romaneio_transit_point = value
        End Set
    End Property
    Public Property id_romaneio_compartimento() As Int32
        Get
            Return _id_romaneio_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_compartimento = value
        End Set
    End Property
    Public Property id_romaneio_uproducao() As Int32
        Get
            Return _id_romaneio_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_uproducao = value
        End Set
    End Property
    Public Property id_nota_fiscal() As Int32
        Get
            Return _id_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_nota_fiscal = value
        End Set
    End Property
    Public Property id_romaneio_transbordo() As Int32
        Get
            Return _id_romaneio_transbordo
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_transbordo = value
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
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
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
    Public Property st_leite_total_rejeitado() As String
        Get
            Return _st_leite_total_rejeitado
        End Get
        Set(ByVal value As String)
            _st_leite_total_rejeitado = value
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
    Public Property nm_cooperativa() As String
        Get
            Return _nm_cooperativa
        End Get
        Set(ByVal value As String)
            _nm_cooperativa = value
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
    Public Property cd_cnpj_transportador() As String
        Get
            Return _cd_cnpj_transportador
        End Get
        Set(ByVal value As String)
            _cd_cnpj_transportador = value
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
    Public Property st_romaneio_transbordo() As String
        Get
            Return _st_romaneio_transbordo
        End Get
        Set(ByVal value As String)
            _st_romaneio_transbordo = value
        End Set
    End Property
    Public Property st_romaneio_transbordo_nulo() As String
        Get
            Return _st_romaneio_transbordo_nulo
        End Get
        Set(ByVal value As String)
            _st_romaneio_transbordo_nulo = value
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
    Public Property id_motorista() As Int32
        Get
            Return _id_motorista
        End Get
        Set(ByVal value As Int32)
            _id_motorista = value
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
    Public Property ds_placa_frete() As String
        Get
            Return _ds_placa_frete
        End Get
        Set(ByVal value As String)
            _ds_placa_frete = value
        End Set
    End Property
    Public Property nr_tempo_rota_ini() As Int32
        Get
            Return _nr_tempo_rota_ini
        End Get
        Set(ByVal value As Int32)
            _nr_tempo_rota_ini = value
        End Set
    End Property
    Public Property nr_tempo_rota_fim() As Int32
        Get
            Return _nr_tempo_rota_fim
        End Get
        Set(ByVal value As Int32)
            _nr_tempo_rota_fim = value
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
    Public Property ds_linha() As String
        Get
            Return _ds_linha
        End Get
        Set(ByVal value As String)
            _ds_linha = value
        End Set
    End Property
    Public Property st_tipo_romaneio_cooperativa() As String
        Get
            Return _st_tipo_romaneio_cooperativa
        End Get
        Set(ByVal value As String)
            _st_tipo_romaneio_cooperativa = value
        End Set
    End Property
    Public Property id_coleta_transmissao() As Int32
        Get
            Return _id_coleta_transmissao
        End Get
        Set(ByVal value As Int32)
            _id_coleta_transmissao = value
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
    Public Property dt_hora_entrada_ini() As String
        Get
            Return _dt_hora_entrada_ini
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada_ini = value
        End Set
    End Property
    Public Property dt_hora_entrada_fim() As String
        Get
            Return _dt_hora_entrada_fim
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada_fim = value
        End Set
    End Property
    Public Property dt_hora_saida_ini() As String
        Get
            Return _dt_hora_saida_ini
        End Get
        Set(ByVal value As String)
            _dt_hora_saida_ini = value
        End Set
    End Property
    Public Property dt_hora_saida_fim() As String
        Get
            Return _dt_hora_saida_fim
        End Get
        Set(ByVal value As String)
            _dt_hora_saida_fim = value
        End Set
    End Property
    Public Property cadernetas() As String
        Get
            Return _cadernetas
        End Get
        Set(ByVal value As String)
            _cadernetas = value
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

    Public Property nr_peso_liquido_caderneta() As Decimal
        Get
            Return _nr_peso_liquido_caderneta
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_caderneta = value
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
    Public Property nr_po_cooperativa() As String
        Get
            Return _nr_po_cooperativa
        End Get
        Set(ByVal value As String)
            _nr_po_cooperativa = value
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
    Public Property dt_saida_nota() As String
        Get
            Return _dt_saida_nota
        End Get
        Set(ByVal value As String)
            _dt_saida_nota = value
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
    Public Property id_st_romaneio() As Int32
        Get
            Return _id_st_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_st_romaneio = value
        End Set
    End Property
    Public Property id_st_romaneio_ini() As Int32
        Get
            Return _id_st_romaneio_ini
        End Get
        Set(ByVal value As Int32)
            _id_st_romaneio_ini = value
        End Set
    End Property
    Public Property id_st_analise_global() As Int32
        Get
            Return _id_st_analise_global
        End Get
        Set(ByVal value As Int32)
            _id_st_analise_global = value
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

    Public Property id_st_analise_uproducao() As Int32
        Get
            Return _id_st_analise_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_st_analise_uproducao = value
        End Set
    End Property

    Public Property nm_st_romaneio() As String
        Get
            Return _nm_st_romaneio
        End Get
        Set(ByVal value As String)
            _nm_st_romaneio = value
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
    Public Property nm_st_analise_uproducao() As String
        Get
            Return _nm_st_analise_uproducao
        End Get
        Set(ByVal value As String)
            _nm_st_analise_uproducao = value
        End Set
    End Property
    Public Property nr_caderneta() As Int32
        Get
            Return _nr_caderneta
        End Get
        Set(ByVal value As Int32)
            _nr_caderneta = value
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
    Public Property data_inicio() As String
        Get
            Return _data_inicio
        End Get
        Set(ByVal value As String)
            _data_inicio = value
        End Set
    End Property
    Public Property data_fim() As String
        Get
            Return _data_fim
        End Get
        Set(ByVal value As String)
            _data_fim = value
        End Set
    End Property
    Public Property id_linha_ini() As Int32
        Get
            Return _id_linha_ini
        End Get
        Set(ByVal value As Int32)
            _id_linha_ini = value
        End Set
    End Property
    Public Property id_linha_fim() As Int32
        Get
            Return _id_linha_fim
        End Get
        Set(ByVal value As Int32)
            _id_linha_fim = value
        End Set
    End Property
    Public Property nr_peso_liquido_nota_transf() As Decimal
        Get
            Return _nr_peso_liquido_nota_transf
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_nota_transf = value
        End Set
    End Property
    Public Property nr_nota_fiscal_transf() As String
        Get
            Return _nr_nota_fiscal_transf
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal_transf = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal_transf() As String
        Get
            Return _nr_serie_nota_fiscal_transf
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal_transf = value
        End Set
    End Property

    Public Property dt_emissao_nota_transf() As String
        Get
            Return _dt_emissao_nota_transf
        End Get
        Set(ByVal value As String)
            _dt_emissao_nota_transf = value
        End Set
    End Property
    Public Property total_volume_max_compartimentos() As Decimal
        Get
            Return _total_volume_max_compartimentos
        End Get
        Set(ByVal value As Decimal)
            _total_volume_max_compartimentos = value
        End Set
    End Property
    Public Property dt_transmissao_ini() As String
        Get
            Return _dt_transmissao_ini
        End Get
        Set(ByVal value As String)
            _dt_transmissao_ini = value
        End Set
    End Property
    Public Property dt_transmissao_fim() As String
        Get
            Return _dt_transmissao_fim
        End Get
        Set(ByVal value As String)
            _dt_transmissao_fim = value
        End Set
    End Property
    Public Property dt_transmissao() As String
        Get
            Return _dt_transmissao
        End Get
        Set(ByVal value As String)
            _dt_transmissao = value
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
    Public Property path_arquivofrete() As String
        Get
            Return _path_arquivofrete
        End Get
        Set(ByVal value As String)
            _path_arquivofrete = value
        End Set
    End Property
    Public Property st_exportacao_frete() As String
        Get
            Return _st_exportacao_frete
        End Get
        Set(ByVal value As String)
            _st_exportacao_frete = value
        End Set
    End Property

    Public Property dt_exportacao_frete() As String
        Get
            Return _dt_exportacao_frete
        End Get
        Set(ByVal value As String)
            _dt_exportacao_frete = value
        End Set
    End Property
    Public Property id_exportacao_frete_execucao() As Int32
        Get
            Return _id_exportacao_frete_execucao
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_frete_execucao = value
        End Set
    End Property
    Public Property id_exportacao_frete_execucao_itens() As Int32
        Get
            Return _id_exportacao_frete_execucao_itens
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_frete_execucao_itens = value
        End Set
    End Property
    Public Property id_registro_exportacao_batch() As Int32
        Get
            Return _id_registro_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_registro_exportacao_batch = value
        End Set
    End Property

    Public Property dt_registro_exportacao_batch() As String
        Get
            Return _dt_registro_exportacao_batch
        End Get
        Set(ByVal value As String)
            _dt_registro_exportacao_batch = value
        End Set
    End Property
    Public Property id_usuario_registro_exportacao_batch() As Int32
        Get
            Return _id_usuario_registro_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_usuario_registro_exportacao_batch = value
        End Set
    End Property

    Public Property st_exportacao_batch() As String
        Get
            Return _st_exportacao_batch
        End Get
        Set(ByVal value As String)
            _st_exportacao_batch = value
        End Set
    End Property
    Public Property id_usuario_exportacao_batch() As Int32
        Get
            Return _id_usuario_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_usuario_exportacao_batch = value
        End Set
    End Property

    Public Property dt_exportacao_batch() As String
        Get
            Return _dt_exportacao_batch
        End Get
        Set(ByVal value As String)
            _dt_exportacao_batch = value
        End Set
    End Property
    Public Property id_exportacao_batch_execucao() As Int32
        Get
            Return _id_exportacao_batch_execucao
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_batch_execucao = value
        End Set
    End Property
    Public Property id_exportacao_batch_itens() As Int32
        Get
            Return _id_exportacao_batch_itens
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_batch_itens = value
        End Set
    End Property
    Public Property path_arquivobatch() As String
        Get
            Return _path_arquivobatch
        End Get
        Set(ByVal value As String)
            _path_arquivobatch = value
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
    ' adri themis 14/05/2012 - chamado 1547 - i
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
    ' adri themis 14/05/2012 - chamado 1547 - f
    ' adri themis 02/08/2012 - chamado 1577 - i
    Public Property nm_linha_ini() As String
        Get
            Return _nm_linha_ini
        End Get
        Set(ByVal value As String)
            _nm_linha_ini = value
        End Set
    End Property
    Public Property nm_linha_fim() As String
        Get
            Return _nm_linha_fim
        End Get
        Set(ByVal value As String)
            _nm_linha_fim = value
        End Set
    End Property
    ' adri themis 02/08/2012 - chamado 1577 - f

    ' adri 11/2016 - chamado 2491 - Conciliação Frete x Romaneio - i
    Public Property id_divergencia_km_frete() As Int32
        Get
            Return _id_divergencia_km_frete
        End Get
        Set(ByVal value As Int32)
            _id_divergencia_km_frete = value
        End Set
    End Property
    Public Property id_aprovacao_km_frete() As Int32
        Get
            Return _id_aprovacao_km_frete
        End Get
        Set(ByVal value As Int32)
            _id_aprovacao_km_frete = value
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
    Public Property nr_km_frete() As Decimal
        Get
            Return _nr_km_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_km_frete = value
        End Set
    End Property

    Public Property id_justificativa_km_frete() As Int32
        Get
            Return _id_justificativa_km_frete
        End Get
        Set(ByVal value As Int32)
            _id_justificativa_km_frete = value
        End Set
    End Property

    ' adri 11/2016 - chamado 2491 - Conciliação Frete x Romaneio - f
    Public Property nr_total_litros_tp_disponivel() As Decimal
        Get
            Return _nr_total_litros_tp_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros_tp_disponivel = value
        End Set
    End Property
    Public Property nr_total_litros_tp_transferidos() As Decimal
        Get
            Return _nr_total_litros_tp_transferidos
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros_tp_transferidos = value
        End Set
    End Property
    Public Property id_transit_point_unidade() As Int32
        Get
            Return _id_transit_point_unidade
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_unidade = value
        End Set
    End Property
    Public Property id_transit_point_frete() As Int32
        Get
            Return _id_transit_point_frete
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_frete = value
        End Set
    End Property
    Public Property id_transit_point() As Int32
        Get
            Return _id_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_transit_point = value
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
    Public Property id_frete_nf() As Int32
        Get
            Return _id_frete_nf
        End Get
        Set(ByVal value As Int32)
            _id_frete_nf = value
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
    Public Property nr_serie_cte() As String
        Get
            Return _nr_serie_cte
        End Get
        Set(ByVal value As String)
            _nr_serie_cte = value
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
    Public Property cd_cst_cte() As String
        Get
            Return _cd_cst_cte
        End Get
        Set(ByVal value As String)
            _cd_cst_cte = value
        End Set
    End Property
    Public Property nr_valor_icms_cte() As Decimal
        Get
            Return _nr_valor_icms_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms_cte = value
        End Set
    End Property
    Public Property cd_cfop() As String
        Get
            Return _cd_cfop
        End Get
        Set(ByVal value As String)
            _cd_cfop = value
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
    Public Property id_tipo_nota_fiscal2() As Int32
        Get
            Return _id_tipo_nota_fiscal2
        End Get
        Set(ByVal value As Int32)
            _id_tipo_nota_fiscal2 = value
        End Set
    End Property
    Public Property id_tipo_coleta() As Int32
        Get
            Return _id_tipo_coleta
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta = value
        End Set
    End Property
    Public Property id_ciq() As Int32
        Get
            Return _id_ciq
        End Get
        Set(ByVal value As Int32)
            _id_ciq = value
        End Set
    End Property
    Public Property id_ciq_documentos() As Int32
        Get
            Return _id_ciq_documentos
        End Get
        Set(ByVal value As Int32)
            _id_ciq_documentos = value
        End Set
    End Property
    Public Property id_romaneio_ciq_documentos() As Int32
        Get
            Return _id_romaneio_ciq_documentos
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_ciq_documentos = value
        End Set
    End Property
    Public Property nm_documento() As String
        Get
            Return _nm_documento
        End Get
        Set(ByVal value As String)
            _nm_documento = value
        End Set
    End Property
    Public Property nr_nota_fiscal2() As String
        Get
            Return _nr_nota_fiscal2
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal2() As String
        Get
            Return _nr_serie_nota_fiscal2
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal2 = value
        End Set
    End Property
    Public Property ds_cd_protocolo_esalq() As String
        Get
            Return _ds_cd_protocolo_esalq
        End Get
        Set(ByVal value As String)
            _ds_cd_protocolo_esalq = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal2() As Decimal
        Get
            Return _nr_valor_nota_fiscal2
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_litros_nota_fiscal2() As Decimal
        Get
            Return _nr_litros_nota_fiscal2
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_nota_fiscal2 = value
        End Set
    End Property
    Public Property id_transvase() As Int32
        Get
            Return _id_transvase
        End Get
        Set(ByVal value As Int32)
            _id_transvase = value
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
    Public Property cd_cfop_cte() As String
        Get
            Return _cd_cfop_cte
        End Get
        Set(ByVal value As String)
            _cd_cfop_cte = value
        End Set
    End Property
    Public Property dt_emissao_completa_cte() As String
        Get
            Return _dt_emissao_completa_cte
        End Get
        Set(ByVal value As String)
            _dt_emissao_completa_cte = value
        End Set
    End Property
    Public Property nr_base_icms_cte() As Decimal
        Get
            Return _nr_base_icms_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_base_icms_cte = value
        End Set
    End Property
    Public Property cd_uf_origem_cte() As String
        Get
            Return _cd_uf_origem_cte
        End Get
        Set(ByVal value As String)
            _cd_uf_origem_cte = value
        End Set
    End Property
    Public Property cd_uf_destino_cte() As String
        Get
            Return _cd_uf_destino_cte
        End Get
        Set(ByVal value As String)
            _cd_uf_destino_cte = value
        End Set
    End Property
    Public Property cd_ibge_origem_cte() As String
        Get
            Return _cd_ibge_origem_cte
        End Get
        Set(ByVal value As String)
            _cd_ibge_origem_cte = value
        End Set
    End Property
    Public Property cd_ibge_destino_cte() As String
        Get
            Return _cd_ibge_destino_cte
        End Get
        Set(ByVal value As String)
            _cd_ibge_destino_cte = value
        End Set
    End Property
    Public Property ds_protocolo_cte() As String
        Get
            Return _ds_protocolo_cte
        End Get
        Set(ByVal value As String)
            _ds_protocolo_cte = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_romaneio = id
        loadRomaneio()

    End Sub

    Public Function getRomaneioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCalculado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCalculado", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioRejeitadoCalculado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioRejeitadoCalculado", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioTransitPointByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioTransitPoint", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioDisponivelTransitPoint() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioDisponivelTransitPoint", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioDisponivelTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioDisponivelTransvase", parameters, "ms_romaneio")
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
    Public Function getRomaneioNotaTransfByStatus() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioNotaTransf", parameters, "ms_romaneio")
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

    Public Function getRomaneioMotoristaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioMotoristas", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSL0013Sintetico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSL0013Sintetico", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSL0013() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSL0013", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioControleLeite() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioControleLeite", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    ' 01/08/2012 - adri - chamado 1577 - i
    Public Function getRomaneioControleLeiteByRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioControleLeiteByRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    ' 01/08/2012 - adri - chamado 1577 - i
    Public Function getRomaneioAnaliseFisicoQuimica() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnaliseFisicoQuimica", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAnaliseFisicoQuimicaComentarios() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnaliseFisicoQuimicaComentarios", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneio()

        Dim dataSet As DataSet = getRomaneioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Private Sub reloadRomaneio()
        'limpar propriedades romaneio
        Me.id_romaneio_transbordo = 0
        Me.id_estabelecimento = 0
        Me.id_cooperativa = 0
        Me.cd_cooperativa = String.Empty
        Me.nm_cooperativa = String.Empty
        Me.id_transportador = 0
        Me.cd_transportador = String.Empty
        Me.nm_transportador = String.Empty
        Me.cd_cnh = String.Empty
        Me.nm_motorista = String.Empty
        Me.id_motorista = 0
        Me.ds_placa = String.Empty
        Me.id_linha = 0
        Me.ds_linha = String.Empty
        Me.dt_hora_entrada = String.Empty
        Me.dt_hora_entrada_ini = String.Empty
        Me.dt_hora_entrada_fim = String.Empty
        Me.dt_hora_saida = String.Empty
        Me.dt_pesagem_inicial = String.Empty
        Me.dt_pesagem_final = String.Empty
        Me.nr_tara = 0
        Me.nr_pesagem_inicial = 0
        Me.nr_pesagem_final = 0
        Me.nr_peso_liquido = 0
        Me.nr_peso_liquido_caderneta = 0
        Me.nr_peso_liquido_nota = 0
        Me.nr_nota_fiscal = String.Empty
        Me.nr_serie_nota_fiscal = String.Empty
        Me.nr_valor_nota_fiscal = 0
        Me.dt_saida_nota = String.Empty
        Me.id_item = 0
        Me.nm_item = String.Empty
        Me.nr_caderneta = 0
        Me.id_st_romaneio = 0
        Me.id_st_analise_global = 0
        Me.id_st_analise_compartimento = 0
        Me.id_st_analise_uproducao = 0
        Me.id_coleta_transmissao = 0
        Me.id_criacao = 0
        Me.id_modificador = 0
        Me.dt_criacao = String.Empty
        Me.dt_modificacao = String.Empty
        Me.ds_estabelecimento = String.Empty
        Me.ds_transportador = String.Empty
        Me.nm_st_romaneio = String.Empty
        Me.st_reanalise = String.Empty
        Me.nm_st_analise_compartimento = String.Empty
        Me.nm_st_analise_uproducao = String.Empty
        Me.data_inicio = String.Empty
        Me.data_fim = String.Empty
        Me.id_linha_ini = 0
        Me.id_linha_fim = 0
        Me.nr_peso_liquido_nota_transf = 0
        Me.nr_nota_fiscal_transf = String.Empty
        Me.nr_serie_nota_fiscal_transf = String.Empty
        Me.dt_emissao_nota_transf = String.Empty
        Me.st_romaneio_transbordo = String.Empty
        Me.total_volume_max_compartimentos = 0
        Me.dt_transmissao_ini = String.Empty
        Me.dt_transmissao_fim = String.Empty
        Me.dt_transmissao = String.Empty
        Me.nm_linha = String.Empty
        Me.ds_placa_frete = String.Empty
        Me.path_arquivofrete = String.Empty
        Me.st_exportacao_frete = String.Empty
        Me.id_exportacao_frete_execucao = 0
        Me.id_exportacao_frete_execucao_itens = 0
        Me.id_estabelecimento_frete = 0
        Me.nr_km_frete = 0
        Me.id_transit_point = 0
        Me.id_aprovacao_km_frete = 0
        Me.nr_po_cooperativa = String.Empty
        Dim dataSet As DataSet = getRomaneioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertRomaneioAnaliseCompartimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertRomaneio() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertPreRomaneioTransitPointAmostra() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPreRomaneioTransitPointAmostra", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function insertRomaneioCooperativabyNota() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioCooperativabyNota", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function abrirRomaneioTransitPoint()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioTransitPoint", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimentoTransitPoint", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducaoTransitPoint", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)

            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i


            'Comita
            transacao.Commit()
            transacao.Dispose()
            'Retorna ao id da propriedade
            Return Me.id_romaneio

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Function abrirRomaneioTransvase()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioTransvase", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimentoTransvase", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducaoTransvase", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)

            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i


            'Comita
            transacao.Commit()
            transacao.Dispose()
            'Retorna ao id da propriedade
            Return Me.id_romaneio

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Function abrirRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'fran 26/11/2009 - Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado
            'Insere Analise Compartimento
            'transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)
            'fran 26/11/2009 f- Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

            'Insere romaneio mapa de leite
            'transacao.Execute("ms_insertRomaneioMapaLeite", param_comp, ExecuteType.Insert)

            'Insere romaneio analise global
            'transacao.Execute("ms_insertRomaneioAnaliseGlobal", param_comp, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            transacao.Dispose()     ' 14/11/2008
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function abrirRomaneioCooperativa()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'fran 03/01/2024 i
            If Me.id_romaneio > 0 Then
                'se ja tem romaneio é abertura de romaneio coop por nota fiscal
                transacao.Execute("ms_updateRomaneioCooperativaNotas", parameters, ExecuteType.Update)
            Else
                'Inclui romaneio
                Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativa", parameters, ExecuteType.Insert), Int32)

            End If

            parameters = ParametersEngine.getParametersFromObject(Me)
            Me.romaneio_compartimento = New Romaneio_Compartimento
            'Pega os parametros para romaneio_compartimento
            Me.romaneio_compartimento.id_romaneio = Me.id_romaneio
            Me.romaneio_compartimento.id_modificador = Me.id_modificador
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.romaneio_compartimento.ds_placa = Me.rc_ds_placa(i).ToString
                Me.romaneio_compartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
                Me.romaneio_compartimento.nr_total_litros = Me.rc_nr_total_volume(i)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio_compartimento)
                transacao.Execute("ms_insertRomaneioCompartimentoCooperativa", param_comp, ExecuteType.Insert)
            Next

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
            Me.id_nota_fiscal = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativaNotaFiscal", parameters, ExecuteType.Insert), Int32)
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
            Me.romaneio_compartimento = New Romaneio_Compartimento
            'Pega os parametros para romaneio_compartimento
            Me.romaneio_compartimento.id_romaneio = Me.id_romaneio
            Me.romaneio_compartimento.id_modificador = Me.id_modificador
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.romaneio_compartimento.ds_placa = Me.rc_ds_placa(i).ToString
                Me.romaneio_compartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
                Me.romaneio_compartimento.nr_total_litros = Me.rc_nr_total_volume(i)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio_compartimento)
                transacao.Execute("ms_insertRomaneioCompartimentoCooperativa", param_comp, ExecuteType.Insert)
            Next

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
            Me.id_nota_fiscal = CType(transacao.ExecuteScalar("ms_insertRomaneioCooperativaNotaFiscal", parameters, ExecuteType.Insert), Int32)
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
    Public Function abrirPreRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'Pre romaneio
            Me.id_st_romaneio = 5
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)
            'Comita
            transacao.Commit()
            'Retorna ao id do romaneio
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function abrirPreRomaneioTransitPoint() 'Fran 12/2016 i transit point

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)
            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)
            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            ''Insere romaneio analise compartimento
            'transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

            'Pre romaneio Aberto
            Me.id_st_romaneio = 7
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updatePreRomaneioTransitPointAbrir", parameters, ExecuteType.Update)
            'Comita
            transacao.Commit()
            transacao.Dispose()     ' 14/11/2008

            'Retorna ao id do romaneio
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function abrirPreRomaneioTransvase() 'Fran 07/2022 i transit point

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)
            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)
            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            ''Insere romaneio analise compartimento
            'transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

            'Pre romaneio Transvase Aberto
            Me.id_st_romaneio = 13
            parameters = ParametersEngine.getParametersFromObject(Me)
            'faz o mesmo sql que transit point para atualizar status
            transacao.Execute("ms_updatePreRomaneioTransitPointAbrir", parameters, ExecuteType.Update)

            'como transvase ao tem analise simula a liberacao do pre romaneio
            transacao.Execute("ms_updatePreRomaneioTransvaseDisponivel", parameters, ExecuteType.Update)
            transacao.Execute("ms_insertPreRomaneioTransvaseAmostra", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            transacao.Dispose()     ' 14/11/2008

            'Retorna ao id do romaneio
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
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
    Public Sub FecharRomaneio()

        Dim transacao As New DataAccess
        Dim dsromcomprejeitado As New DataSet
        Dim dsrow As DataRow
        Dim dsrowprop As DataRow
        Dim inr_count_propriedades As Integer
        Dim nr_saldo_litros As Decimal
        Dim nr_desconto_primprop As Decimal
        Dim nr_desconto_propriedade As Decimal
        Dim laux As Decimal
        Dim dsruppropriedades As New DataSet

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualizar romaneio
            transacao.Execute("ms_updateRomaneioFechar", parameters, ExecuteType.Update)
            'Atualizar pesagens
            transacao.Execute("ms_updateRomaneioPesagens", parameters, ExecuteType.Update)

            transacao.Execute("ms_updateRomaneioDataColetaFechamento", parameters, ExecuteType.Update) 'fran 28/12/2020 i atualiza data de coleta da uproducao se o fechamento for em mes diferente da coleta(1o dia do mes)

            If Me.id_cooperativa > 0 Then
                'Insere romaneio mapa de leite
                transacao.Execute("ms_insertRomaneioMapaLeiteCooperativa", parameters, ExecuteType.Insert)

                'Insere romaneio mapa de leite
                transacao.Execute("ms_insertRomaneioMapaLeiteDescartadoCooperativa", parameters, ExecuteType.Insert)
            Else
                'Insere romaneio mapa de leite
                transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

                'Insere romaneio mapa de leite
                transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)

                'fran 24/10/2024
                'insere em lançamento de frete, o valor desconto transportador (se existir), 
                'de acordo com variacao entre caderneta e peso (0,2%) (= relatorio relatoriocontroleleite)
                transacao.Execute("ms_insertRomaneioFreteLancamentoDescontoTransportador", parameters, ExecuteType.Insert)
            End If

            If Me.st_romaneio_transbordo = "S" Then
                transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
            End If

            'Fran 30/11/2008 i - Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
            transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
            Dim li As Integer = 0
            'fran i 06/2016- apurar rejeicao antibiotico para geração da conta 0114 em conta parcelada do saldo do leite bom que foi misturado com antibiotico
            'maracanau nao tem a mesma regra... so cria conta antibiotico para poços
            If (Me.nr_caderneta > 0) And (Me.id_estabelecimento <> 9) Then 'romaneio de produtor
                'Buscar os compartimentos e diferença do volume rejeitado da propriedade para o volume total do compartimento, ou seja deve buscar o valor de leite bom que foi misturado ao de antibiotico para que o produtor possa paga-lo
                transacao.Fill(dsromcomprejeitado, "ms_getRomaneioCompartimentoRejeicaoAntibiotico", parameters, "ms_romaneio_compartimento")
                For Each dsrow In dsromcomprejeitado.Tables(0).Rows
                    Me.id_romaneio_compartimento = dsrow.Item("id_romaneio_compartimento")
                    'quantas propriedades vao ratear o volume
                    inr_count_propriedades = dsrow.Item("nr_count_propriedades")
                    Me.nr_litros_rejeitado = dsrow.Item("nr_litros_rejeitados_compartimento")
                    'o total a ser rateado (litros de leite bom)
                    nr_saldo_litros = dsrow.Item("nr_saldo_litros")
                    'o valor de cada propriedade
                    nr_desconto_propriedade = dsrow.Item("nr_desconto_propriedade")
                    If inr_count_propriedades = 1 Then
                        'se ttem apenas uma propriedade, arredonda sem deciamis pois volume leite deve ser inteiro
                        nr_desconto_primprop = Round(nr_desconto_propriedade, 0)
                    Else
                        'se o valor deve ser dividido entre mais de umma propriedade, joga os litros perdidos para a primeira
                        laux = Round((nr_desconto_propriedade - Truncate(nr_desconto_propriedade)) * inr_count_propriedades, 0)
                        nr_desconto_primprop = Truncate(nr_desconto_propriedade) + laux
                        nr_desconto_propriedade = Truncate(nr_desconto_propriedade)
                    End If

                    'Busca quais sao as propriedades que devem pagar o leite, as que tiveram rejeicao antibiotico
                    li = 0
                    parameters = ParametersEngine.getParametersFromObject(Me)
                    transacao.Fill(dsruppropriedades, "ms_getRomaneioUProducaoPropriedadesRejeicaoAntibiotico", parameters, "ms_romaneio_uproducao")
                    For Each dsrowprop In dsruppropriedades.Tables(0).Rows
                        li = li + 1
                        Me.id_propriedade = dsrowprop.Item("id_propriedade")
                        Me.dt_referencia = DateTime.Parse(dsrowprop.Item("dt_referencia")).ToString("dd/MM/yyyy")
                        'se for a primeira propriedade joga o volume dividido + o decimal
                        If li = 1 Then
                            Me.nr_litros_desconto = nr_desconto_primprop
                        Else
                            Me.nr_litros_desconto = nr_desconto_propriedade
                        End If
                        parameters = ParametersEngine.getParametersFromObject(Me)
                        transacao.Execute("ms_insertRomaneioContaParcelada", parameters, ExecuteType.Insert)

                    Next 'proxima propriedade
                Next 'proximo romaneio compartimento

            End If
            'fran f 06/2016
            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            'Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    'fran 26/03/2012 - themis
    Public Sub RegerarRomaneioMapaLeite()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'deletar mapa de leite
            transacao.Execute("ms_deleteRomaneioMapaLeite", parameters, ExecuteType.Delete)

            'Insere romaneio mapa de leite
            transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

            'Insere romaneio mapa de leite
            transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)

            If Me.st_romaneio_transbordo = "S" Then
                transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
            End If

            ' Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
            transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)


            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            'Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
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
    Public Function registrarAnaliseCompartimentoRejeitada()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.romaneio_compartimento)

            'Atualiza status em Romaneio Compartimento
            transacao.Execute("ms_updateRomaneioCompartimento", params, ExecuteType.Update)


            'Atualiza status da analise compartimento no romaneio
            transacao.Execute("ms_updateRomaneioStatusAnaliseCompartimento", parameters, ExecuteType.Update)

            Dim romaneioanaliseuproducao As New RomaneioAnaliseUProducao
            romaneioanaliseuproducao.id_romaneio = Me.id_romaneio
            romaneioanaliseuproducao.id_romaneio_compartimento = Me.romaneio_compartimento.id_romaneio_compartimento

            'Dim dsanaliseuproducao As DataSet = romaneioanaliseuproducao.getRomaneioAnalisesUProducaoByFilters
            Dim dataSet As New DataSet
            transacao.Fill(dataSet, "ms_getRomaneioAnalisesUProducao", params, "ms_romaneio_analise_uproducao")

            If (dataSet.Tables(0).Rows.Count = 0) Then
                ''If Me.st_reanalise = "S" Then
                'Se não tem linhas cria as analises uproducao para o compartimento
                'Se é uma reanalise gera as linhas com a diferença que só traz da análise as que estiverem com flag de reanalise
                ''transacao.Execute("ms_insertRomaneioAnaliseUProducaoReanalise", params, ExecuteType.Insert)
                ''Else
                'Se não tem linhas cria as analises uproducao para o compartimento
                transacao.Execute("ms_insertRomaneioAnaliseUProducao", params, ExecuteType.Insert)
                ''End If
            End If

            'Atualiza todos os compartimentos do romaneio com o nome do analista e a hora (nova tela)
            Me.romaneio_compartimento.id_romaneio_compartimento = 0
            params = ParametersEngine.getParametersFromObject(Me.romaneio_compartimento)
            transacao.Execute("ms_updateRomaneioCompartimentosAnalista", params, ExecuteType.Update)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function registrarAnaliseCompartimentoAprovada()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.romaneio_compartimento)

            'Atualiza status em Romaneio Compartimento
            transacao.Execute("ms_updateRomaneioCompartimento", params, ExecuteType.Update)

            'Dim romaneiocompartimento As New Romaneio_Compartimento
            'romaneiocompartimento.id_romaneio = Me.id_romaneio
            'Pega todos os compartimentos rejeitados (status 3 ) e diferentes de nmulo
            'verifica se tem algum comp rejeitado
            Dim dataSet As New DataSet
            transacao.Fill(dataSet, "ms_getRomaneioCompartimentosSituacaoRejeitados", parameters, "ms_romaneio_compartimento")
            'se não tem ninguem rejeitado
            If (dataSet.Tables(0).Rows.Count = 0) Then
                'Atualiza status da analise compartimento no romaneio para aprovado
                'parameters.Find(
                transacao.Execute("ms_updateRomaneioStatusAnaliseCompartimento", parameters, ExecuteType.Update)

            End If

            'Atualiza todos os compartimentos do romaneio com o nome do analista e a hora (nova tela)
            Me.romaneio_compartimento.id_romaneio_compartimento = 0
            params = ParametersEngine.getParametersFromObject(Me.romaneio_compartimento)
            transacao.Execute("ms_updateRomaneioCompartimentosAnalista", params, ExecuteType.Update)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
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
    Public Sub updateRomaneioStatusAnaliseUProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioStatusAnaliseUProducao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioFechar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioFechar", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioPesagens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioPesagens", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioPesagemFinal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioPesagemFinal", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioAbertoEmAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAbertoEmAnalise", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioTransitPointAbertoEmAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioTransitPointAbertoEmAnalise", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    'fran 02/03/2012 i Themis - Batch
    Public Function getRomaneioRegistrosFinais() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioRegistrosFinais", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    'fran 02/03/2012 f Themis - Batch

    Public Function getRomaneioFecharEmAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioFecharEmAnalise", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioReajuste() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioReajuste", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAnalisesCompartimentosDistinct() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnalisesCompartimentosDistinct", parameters, "ms_romaneio_analise_compartimento")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAnalisesNullNavegacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnalisesNullNavegacao", parameters, "ms_romaneio_analise_compartimento")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioCompartimentoMediaDens() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaDens", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    'Public Function getRomaneioCompartimentoMediaProt() As Decimal 'THEMIS BATCH
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaProt", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    'Public Function getRomaneioCompartimentoMediaMG() As Decimal 'THEMIS BATCH
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaMG", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    'Public Function getPOProdutorbyRomaneioEstabelecimento() As DataSet 'THEMIS BATCH
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getPOProdutorbyRomaneioEstabelecimento", parameters, "ms_po_produtor")
    '        Return dataSet

    '    End Using

    'End Function

    'Public Function getPOCooperativabyCooperativa() As DataSet 'THEMIS BATCH
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getPOCooperativabyCooperativa", parameters, "ms_po_cooperativa")
    '        Return dataSet

    '    End Using

    'End Function
    Public Function getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getRomaneioCompartimentosSomaVolumebyRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumebyRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function

    Public Function getRomaneioSomaCadernetasbyNotaTransf() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSomaCadernetasbyNotaTransf", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getRomaneioSomaVolumebyCadernetas() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSomaVolumebyCadernetas", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function abrirRomaneioTransbordo()

        Dim transacao As New DataAccess
        Dim liromaneio_transbordo As Integer
        Dim liid_modificador As Integer
        Dim liid_estabelecimento As Integer

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            liid_modificador = Me.id_modificador
            liid_estabelecimento = Me.id_estabelecimento

            '*************************************************************************************************************
            ' INCLUI TRANSBORDO
            '**************************************************************************************************************
            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioTransbordo", parameters, ExecuteType.Insert), Int32)
            Me.id_romaneio_transbordo = Me.id_romaneio
            liromaneio_transbordo = Me.id_romaneio_transbordo
            parameters = ParametersEngine.getParametersFromObject(Me)

            Me.romaneio_compartimento = New Romaneio_Compartimento
            'Pega os parametros para romaneio_compartimento
            Me.romaneio_compartimento.id_romaneio = Me.id_romaneio
            Me.romaneio_compartimento.id_modificador = Me.id_modificador
            For i As Integer = 0 To rc_ds_placa.Count - 1
                Me.romaneio_compartimento.ds_placa = Me.rc_ds_placa(i).ToString
                Me.romaneio_compartimento.id_compartimento = Convert.ToInt32(Me.rc_id_compartimento(i))
                Me.romaneio_compartimento.nr_total_litros = Me.rc_nr_total_volume(i)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio_compartimento)
                transacao.Execute("ms_insertRomaneioCompartimentoCooperativa", param_comp, ExecuteType.Insert)
            Next

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)
            'Fran 30/09/2008 i - pesagem inicial na tela de cooperativa
            'atualiza o romaneio para status ABERTO pois já informou dados de pesagem
            transacao.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)
            'transacao.Execute("ms_insertRomaneioUProducaoTransbordo", parameters, ExecuteType.Insert)

            '**************************************************************************************************
            'INCLUI PRE ROMANEIOS
            '**************************************************************************************************
            Dim llistacadernetas As String = Me.cadernetas
            Dim licaderneta As Integer
            Dim lpos As Integer
            Dim liIni As Integer

            'lista de cadernetas, troca por separador pipe
            llistacadernetas = Me.cadernetas
            llistacadernetas = Replace(llistacadernetas, "''", "|")
            llistacadernetas = Replace(llistacadernetas, "'", "")

            lpos = InStr(1, llistacadernetas, "|", CompareMethod.Text)
            liIni = 1
            Do While liIni > 0
                'procura caderneta na posição
                If lpos > 0 Then
                    licaderneta = Mid(llistacadernetas, liIni, lpos - 1)
                Else
                    licaderneta = Mid(llistacadernetas.Trim, liIni)
                End If

                Me.nr_caderneta = licaderneta
                Me.id_modificador = liid_modificador
                Me.romaneio_compartimento = New Romaneio_Compartimento
                Me.romaneio_compartimento.id_modificador = Me.id_modificador
                Me.romaneio_compartimento.romaneio_uproducao.id_modificador = Me.id_modificador
                parameters = ParametersEngine.getParametersFromObject(Me)
                'Inclui romaneio
                Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
                parameters = ParametersEngine.getParametersFromObject(Me)
                'Pega os parametros para romaneio_compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                'Insere romaneio compartimento
                transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)
                'Insere romaneio compartimento unidade producao
                transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)
                'Insere romaneio placas
                transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
                'Atualiza a Placa Principal
                transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)

                If lpos > 0 Then
                    liIni = lpos + 1
                    lpos = InStr(lpos + 1, llistacadernetas, "|", CompareMethod.Text)
                Else
                    liIni = 0
                End If

            Loop


            '**************************************************************************************************
            'ATUALIZA PRE ROMANEIOS COM ID_TRANSBORDO
            '**************************************************************************************************
            'Atualiza os pre romaneios da nota para status
            'Atualiza romaneio Pre romaneio para status já em uso, para as cadernetas 
            Me.id_st_romaneio = 6
            Me.id_romaneio_transbordo = liromaneio_transbordo
            Me.cadernetas = llistacadernetas
            Me.id_estabelecimento = liid_estabelecimento

            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateRomaneioPre", parameters, ExecuteType.Update)

            transacao.Execute("ms_insertRomaneioUProducaoTransbordo", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio_transbordo
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
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

            If isvalid = True Then
                If exc_AnaliseObrigatoriaUproducaoNula(Me.id_romaneio) = False Then
                    FecharRomaneioConsistir = False
                    isvalid = False
                    Throw New Exception("Há análises obrigatórias de Unidades de Produção/Produtores sem preenchimento de resultado. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
                End If
            End If
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

    Public Function exc_AnaliseObrigatoriaUproducaoNula(ByVal id_romaneio As Int32) As Boolean
        Try
            Dim isvalid As Boolean = True

            Dim analisesup As New RomaneioAnaliseUProducao
            analisesup.id_romaneio = id_romaneio
            If analisesup.getRomaneioAnaliseUProducaoSemResultado > 0 Then
                isvalid = False
            End If

            exc_AnaliseObrigatoriaUproducaoNula = isvalid

        Catch ex As Exception
            Throw New Exception(ex.Message)
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
    Public Function exc_LacresSaidaNulo(ByVal id_romaneio As Int32) As Boolean
        Try
            'Verifica se os lacres de sída foram preenchidos
            Dim isvalid As Boolean = True

            Dim lacres As New RomaneioLacre

            lacres.id_romaneio = id_romaneio
            If lacres.getRomaneioLacresSaidaNulosByRomaneio > 0 Then
                isvalid = False
            End If

            exc_LacresSaidaNulo = isvalid

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
    Public Function getFreteRomaneioByTransportadora() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteRomaneioByTransportadora", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getFreteRomaneioCooperativaByTransportadora() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteRomaneioCooperativaByTransportadora", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getFreteSomaKm() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFreteSomaKm", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getFreteSomaKmBiTruck() As Decimal 'fran 25/12/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFreteSomaKmBiTruck", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    'Fran 04/12/2009 chamado  569 - frete i
    Public Function getFreteSomaLitrosbyPlaca() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFreteSomaLitrosbyPlaca", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function


    Public Function getFreteColetas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteColetas", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getFreteColetasSemLitros() As DataSet 'fran 18/12/2009

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteColetasSemLitros", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    'fran 22/09/2009 i rls21 - GKO
    Private Function Frete_Registro_000() As String


        Try

            Dim linhatexto As String

            ' Registro 000
            Dim tp_registro As String   'Num 3 posições
            Dim num_interface As String 'alfnum 10 posições
            Dim versao As String        'alfnum 6 posições
            Dim remetente As String     'alfnum 40 posições
            Dim destinatario As String  'alfnum 40 posições
            Dim cd_ambiente As String   'alfnum 3 posições


            '====================================================================================
            ' Registro Tipo 000
            '====================================================================================

            'Tipo de Registro - Fixo 000
            tp_registro = "000"

            'Num Interface - Fixo INTDNE - 10 posições
            num_interface = String.Concat("INTDNE", Space(4))

            'Versao - Fixo 5.71a - 6 posições
            versao = String.Concat("5.71a", Space(1))

            'remetente - Fixo DANONE LTDA - 40 posições
            remetente = "DANONE LTDA"
            remetente = String.Concat(remetente, Space(40 - Len(remetente)))

            'destinatario - Fixo DANONE LTDA - 40 posições
            destinatario = "DANONE LTDA"
            destinatario = String.Concat(destinatario, Space(40 - Len(destinatario)))

            'cod ambiente - Fixo BRANCO - 3 posições
            cd_ambiente = Space(3)

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tp_registro + num_interface + versao + remetente
            'Fran 14/07/2012 i mudança layout GKO
            'linhatexto = linhatexto + destinatario + cd_ambiente
            linhatexto = linhatexto + destinatario
            'Fran 14/07/2012 i mudança layout GKO

            Frete_Registro_000 = linhatexto

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    'fran 22/09/2009 i rls21 - GKO
    'Private Function Frete_Registro_060(ByVal pCNPJEstabel As String, ByVal pCdEstabel As String, ByVal pCidadeEstabel As String, ByVal pUFEstabel As String, ByVal pCNPJTransportadora As String, ByVal pPlaca_Frete As String, ByVal pnmEquipamento As String, Optional ByVal pnmCidadeMaiorDistancia As String = "", Optional ByVal pcdUFMaiorDistancia As String = "", Optional ByVal pnrValorKm As String = "") As String 'fran 20/12/2009
    Private Function Frete_Registro_060(ByVal pCNPJEstabel As String, ByVal pCdEstabel As String, ByVal pCidadeEstabel As String, ByVal pUFEstabel As String, ByVal pCNPJTransportadora As String, ByVal pPlaca_Frete As String, ByVal pnmEquipamento As String, Optional ByVal pnmCidadeMaiorDistancia As String = "", Optional ByVal pcdUFMaiorDistancia As String = "", Optional ByVal pnrValorKm As String = "", Optional ByVal pMediaDensidade As Decimal = 0, Optional ByVal pbTransitPoint As Boolean = False, Optional ByVal pbTransbordo As Boolean = False) As String


        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim floperacao As String   'alfnum 1 posições
            Dim cdromaneio As String   'alfnum 10 posições
            Dim chaverespfrete As String 'alfnum 15 posições
            Dim dtembarque As String   'data 10 posições
            Dim hrembarque As String   'num 4 posições
            Dim cdtransportadora As String 'alfnum 15 posicoes
            Dim cdremessa As String    'alfanum 12 posicoes
            Dim cdZonaMaiorDistancia As String  'alfanum 8 posicoes
            Dim nmCidMaiorDistancia As String   'alfanum 30 posicoes
            Dim cdUFMaiorDistancia As String    'alfanum 2 posicoes
            Dim vrtotalpeso As String         'num 15 posicoes
            Dim vrtotalkm As String           'num 5 posicoes
            Dim cdequipamento As String        'alfanum 10 posicoes
            Dim dsplacaveiculo As String       'alfanum 10 posicoes
            Dim nmmotorista As String          'alfanum 40 posicoes
            Dim txobs As String                'alfanum 80 posicoes
            Dim tpviagem As String
            Dim stexcluirefextromaneio As String
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            '====================================================================================
            ' Registro Tipo 060
            '====================================================================================

            'Tipo de Registro - Fixo 060
            tpregistro = "060"

            'Fl Operacao - Fixo A - 1 posição
            floperacao = "A"

            'Cód Romaneio - 10 posições
            'Fran 16/10/2009 i  chamado 477
            'cdromaneio = Me.id_romaneio.ToString.Trim
            'If Len(cdromaneio) > 10 Then
            'cdromaneio = Left(cdromaneio, 10)
            'Else
            'cdromaneio = String.Concat(cdromaneio, Space(Len(cdromaneio)))
            'End If
            If Me.id_cooperativa > 0 Then
                'Fran 07/01/2010 i gko rls 27 anexoi_03
                'cdromaneio = String.Concat("C", Left(Me.id_romaneio.ToString.Trim, 9))
                'fran 20/05/2011i chamado 1296
                'cdromaneio = String.Concat("C", Left(Me.nr_nota_fiscal.ToString.Trim, 9))
                cdromaneio = String.Concat("D", Me.id_romaneio.ToString.Trim)
                'fran 20/05/2011 f chamado 1296
                'Fran 07/01/2010 f gko rls 27 anexoi_03

            Else
                'Fran 14/07/2012 i mudança layout GKO
                'cdromaneio = String.Concat("D", Left(Me.id_romaneio.ToString.Trim, 9))
                cdromaneio = String.Concat("D", Left(Me.id_romaneio.ToString.Trim, 13))
                'Fran 14/07/2012 f mudança layout GKO
            End If
            'Fran 14/07/2012 i mudança layout GKO
            'If Len(cdromaneio) > 10 Then
            '    cdromaneio = Left(cdromaneio, 10)
            'Else
            '    cdromaneio = String.Concat(cdromaneio, Space(10 - Len(cdromaneio)))
            'End If
            If Len(cdromaneio) > 14 Then
                cdromaneio = Left(cdromaneio, 14)
            Else
                cdromaneio = String.Concat(cdromaneio, Space(14 - Len(cdromaneio)))
            End If
            'Fran 14/07/2012 f mudança layout GKO
            'Fran 16/10/2009 f

            'chave resp frete - CNPJ do estabelecimento do romaneio - 15 posições
            chaverespfrete = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            chaverespfrete = String.Concat(chaverespfrete, Space(15 - Len(chaverespfrete)))

            'data de embarque - dt abertura do romaneio 10 posições
            'Fran 19/11/2009 I
            'dtembarque = Left(Me.dt_hora_entrada, 10).ToString
            'Fran 6/08/2012 i conforme email do Edson Freitas de 6/08, a data deve vir no formato MM/DD/YYYY
            'dtembarque = Left(DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy"), 10)
            'fran 15/08/2012 i
            'dtembarque = Left(DateTime.Parse(Me.dt_hora_entrada).ToString("yyyyMMdd"), 10)
            dtembarque = Left(String.Concat(Left(DateTime.Parse(Me.dt_hora_entrada).ToString("yyyyMMdd"), 8), Space(2)), 10)
            'fran 15/08/2012 f
            'Fran 6/08/2012 f conforme email do Edson Freitas de 6/08, a data deve vir no formato MM/DD/YYYY

            'Fran 19/11/2009 F

            'hora de embarque - Fixo 0000 4 posições
            hrembarque = "0000"

            'cd transportadora - CNPJ Transportadora - 15 posições
            cdtransportadora = FormataCampo(pCNPJTransportadora.Trim.ToString).Trim
            cdtransportadora = String.Concat(cdtransportadora, Space(15 - Len(cdtransportadora)))

            'cd remessa - Nr_caderneta + Cd Estabelecimento ou Nr Nota Fiscal + '-COOP' para Cooperativa - 15 posições

            If Me.id_cooperativa > 0 Then
                'cdremessa = String.Concat(Me.nr_nota_fiscal.ToString, "-COOP") 'Fran 19/10/2009 chamado 477
                'fran 07/01/2010 i data emissao nota gko rls 27
                'cdremessa = Me.nr_nota_fiscal.ToString.Trim 'Fran 19/10/2009 chamado 477

                'Fran 23/09/2013 i Alteração layout frete - escopo melhorias milk fase 1
                'Com as notas fiscais eletrônicas, para evitar problemas de duplicidade, apenas para cooperativas 
                'o campo CDREMESSA do registro 060 passe a enviar o valor “R” acrescido do número do romaneio.

                'cdremessa = String.Concat("R", Me.nr_nota_fiscal.ToString.Trim)
                'Fran 18/12/2014 i Para que não ocorra duplicidade trocar para RA
                'cdremessa = String.Concat("R", Me.id_romaneio.ToString.Trim)
                cdremessa = String.Concat("RA", Me.id_romaneio.ToString.Trim)
                'Fran 18/12/2014 f Para que não ocorra duplicidade trocar para RA
                'Fran 23/09/2013 f Alteração layout frete - escopo melhorias milk fase 1

                'Fran 6/08/2012 i conforme email do Edson Freitas de 6/08, a data deve vir no formato MM/DD/YYYY
                'dtembarque = Left(DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy"), 10)
                'fran 15/08/2012 i
                'dtembarque = Left(DateTime.Parse(Me.dt_saida_nota).ToString("yyyyMMdd"), 10)
                dtembarque = Left(String.Concat(Left(DateTime.Parse(Me.dt_saida_nota).ToString("yyyyMMdd"), 8), Space(2)), 10)
                'fran 15/08/2012 f

                'Fran 6/08/2012 f conforme email do Edson Freitas de 6/08, a data deve vir no formato MM/DD/YYYY
                'fran 07/01/2010 f data emissao nota gko rls 27
            Else
                'cdremessa = String.Concat(Me.nr_caderneta.ToString, "-", pCdEstabel.ToString) 'Fran 19/10/2009 chamado 477
                cdremessa = Me.nr_caderneta.ToString.Trim 'Fran 19/10/2009 chamado 477
            End If
            'fran - 18/10/2012 i trocar de 12 para 13 de acordo com emial de Edson Freitas de 8/10
            'If Len(cdremessa) > 12 Then
            '    cdremessa = Left(cdremessa, 12)
            'Else
            '    cdremessa = String.Concat(cdremessa, Space(12 - Len(cdremessa)))
            'End If
            If Len(cdremessa) > 13 Then
                cdremessa = Left(cdremessa, 13)
            Else
                cdremessa = String.Concat(cdremessa, Space(13 - Len(cdremessa)))
            End If
            'fran - 18/10/2012 f trocar de 12 para 13 de acordo com emial de Edson Freitas de 8/10

            'cod zona - Fixo BRANCO - 10 posições
            'fran - 18/10/2012 i trocar de 10 para 9 de acordo com email de Edson Freitas de 8/10
            'cdZonaMaiorDistancia = Space(10) 'alterada de 8 para 10 posições chamado 475
            cdZonaMaiorDistancia = Space(9) 'alterada de 8 para 10 posições chamado 475
            'fran - 18/10/2012 f trocar de 12 para 13 de acordo com emial de Edson Freitas de 8/10

            'Nm cidade - 30 posições
            'UF - 2 posições
            If Me.id_cooperativa > 0 Then 'Pega o nm dos dados de cooperativa 
                Dim coop As New Pessoa(Me.id_cooperativa)
                If coop.nm_cidade Is Nothing Then
                    coop.nm_cidade = String.Empty
                End If
                If coop.cd_uf Is Nothing Then
                    coop.cd_uf = String.Empty
                End If
                nmCidMaiorDistancia = Left(coop.nm_cidade.Trim, 30)
                cdUFMaiorDistancia = Left(coop.cd_uf.Trim, 2)
                vrtotalpeso = Me.nr_peso_liquido_nota
            Else
                'fran 26/10/2009 i utilizar a cidade e estado do primeiro produtor
                'nmCidMaiorDistancia = Left(pCidadeEstabel, 30)
                'cdUFMaiorDistancia = Left(pUFEstabel, 2)
                nmCidMaiorDistancia = Left(pnmCidadeMaiorDistancia, 30)
                cdUFMaiorDistancia = Left(pcdUFMaiorDistancia, 2)
                'fran 26/10/2009 f
                'fran 04/12/2009 i chamado 569
                'vrtotalpeso = Me.nr_peso_liquido_caderneta.ToString
                'fran 03/2017 i - se for romaneio de transit poin ou de transbordo pega o peso liquido caderneta
                If pbTransitPoint = True OrElse pbTransbordo = True Then
                    vrtotalpeso = (0.01 * pMediaDensidade).ToString 'nao deixa zertar
                    'fran 03/2017 f - se for romaneio de transit poin ou de transbordo
                Else
                    vrtotalpeso = (Me.getFreteSomaLitrosbyPlaca() * pMediaDensidade).ToString
                End If

                'fran 04/12/2009 f
            End If
            nmCidMaiorDistancia = String.Concat(nmCidMaiorDistancia, Space(30 - Len(nmCidMaiorDistancia)))
            cdUFMaiorDistancia = String.Concat(cdUFMaiorDistancia, Space(2 - Len(cdUFMaiorDistancia)))

            ' 13 inteiros, sem virgula  e 2 decimais (15 caracteres)
            lpos = InStr(1, vrtotalpeso, ",")
            If lpos = 0 Then   ' Se não tem casas decimais
                vrtotalpeso = Right(String.Concat(StrDup(13 - Len(vrtotalpeso.Trim), "0"), vrtotalpeso), 13)
                vrtotalpeso = String.Concat(vrtotalpeso, "00")
            Else
                lvalorint = CStr(Left(vrtotalpeso, lpos - 1))  ' Pegar somente o valor inteiro
                lvalorint = Right(String.Concat(StrDup(13 - Len(lvalorint.Trim), "0"), lvalorint), 13)
                lvalordec = CStr(Mid(CStr(vrtotalpeso), lpos + 1))  ' Pegar somente o valor decimal
                If Len(lvalordec) >= 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                End If

                vrtotalpeso = String.Concat(lvalorint, lvalordec)
            End If

            'valor total km - somatoria de toda km incluido não coleta com motivos permitidos
            If Me.id_cooperativa > 0 Then 'gera total de km zerado pois GKO tratara
                'fran 19/11/2009 i
                'vrtotalkm = "00000"
                'Fran 14/07/2012 i mudança layout GKO
                'vrtotalkm = Right(String.Concat(StrDup(5 - Len(pnrValorKm.Trim), "0"), pnrValorKm), 5)
                'vrtotalkm = Right(String.Concat(StrDup(8 - Len(pnrValorKm.Trim), "0"), pnrValorKm), 8)'fran 17/09/2012 tem casas decimais themis
                'Fran 14/07/2012 f mudança layout GKO
                'fran 19/11/2009 f
                vrtotalkm = pnrValorKm 'fran 17/09/2012 tem casas decimais themis
            Else 'se caderneta
                Me.ds_placa_frete = pPlaca_Frete.Trim
                ' 5 inteiros
                'fran 03/2017 i a kmtotal vem do campo nr_km_frete de romaneio, que foi aprovada pelo usuario
                ''fran 25/12/2015 i se for bitruck, como esta pegando a placa de frete como palaca princiipal, nao encontra valor de km com sql getsomafretekm
                ''solução: quando for bitruck busca km pela placa principal
                'If pnmEquipamento.Trim.ToString.Equals("BI-TRUCK") Then
                '    vrtotalkm = CDec(Me.getFreteSomaKmBiTruck).ToString 'fran 17/09/2012 tem casas decimais themis
                'Else
                '    'fran 25/12/2015 f
                '    vrtotalkm = CDec(Me.getFreteSomaKm).ToString 'fran 17/09/2012 tem casas decimais themis
                'End If
                ''Fran 14/07/2012 i mudança layout GKO
                ''vrtotalkm = Right(String.Concat(StrDup(5 - Len(vrtotalkm.Trim), "0"), vrtotalkm), 5)
                ''vrtotalkm = Right(String.Concat(StrDup(8 - Len(vrtotalkm.Trim), "0"), vrtotalkm), 8) fran 17/09/2012 tem casas decimais themis
                ''Fran 14/07/2012 f mudança layout GKO
                vrtotalkm = CDec(Me.nr_km_frete).ToString
                'fran 03/2017 f a kmtotal vem do campo nr_km_frete de romaneio, que foi aprovada pelo usuario

            End If
            'fran 17/09/2012 i tem casas decimais themis
            lpos = InStr(1, vrtotalkm, ",")
            If lpos = 0 Then   ' Se não tem casas decimais
                If Len(vrtotalkm.Trim) > 6 Then
                    vrtotalkm = Right(vrtotalkm.Trim, 6)
                End If
                vrtotalkm = Right(String.Concat(StrDup(6 - Len(vrtotalkm.Trim), "0"), vrtotalkm), 6)
                vrtotalkm = String.Concat(vrtotalkm, "00")
            Else
                lvalorint = CStr(Left(vrtotalkm, lpos - 1))  ' Pegar somente o valor inteiro
                lvalorint = Right(String.Concat(StrDup(6 - Len(lvalorint.Trim), "0"), lvalorint), 6)
                lvalordec = CStr(Mid(CStr(vrtotalkm), lpos + 1))  ' Pegar somente o valor decimal
                If Len(lvalordec) >= 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                End If

                vrtotalkm = String.Concat(lvalorint, lvalordec)
            End If
            'fran 17/09/2012 tem casas decimais themis


            'Cd equipamento 10 posiçoes
            'cdequipamento = pcdEquipamento.Trim 'fran 19/10/2009 i
            cdequipamento = pnmEquipamento 'fran 19/10/2009 i
            If Len(cdequipamento) > 10 Then
                cdequipamento = Left(cdequipamento, 10)
            Else
                cdequipamento = String.Concat(cdequipamento, Space(10 - Len(cdequipamento)))
            End If


            'Placa 10 posições
            dsplacaveiculo = pPlaca_Frete.Trim
            dsplacaveiculo = String.Concat(dsplacaveiculo, Space(10 - Len(dsplacaveiculo)))

            'Motorista 40 posições
            nmmotorista = pPlaca_Frete.Trim
            nmmotorista = String.Concat(nmmotorista, Space(40 - Len(nmmotorista)))

            txobs = Space(80)
            tpviagem = "1"
            stexcluirefextromaneio = "0"

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + floperacao + cdromaneio + chaverespfrete + dtembarque + hrembarque
            linhatexto = linhatexto + cdtransportadora + cdremessa + cdZonaMaiorDistancia + nmCidMaiorDistancia
            linhatexto = linhatexto + cdUFMaiorDistancia + vrtotalpeso + vrtotalkm + cdequipamento
            linhatexto = linhatexto + dsplacaveiculo + nmmotorista + txobs + tpviagem + stexcluirefextromaneio

            Frete_Registro_060 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    'fran 22/09/2009 i rls21 - GKO
    'Private Function Frete_Registro_100(Optional ByVal pEstabeldoRomaneio As DataRow = Nothing, Optional ByVal pDadosCooperativa As DataRow = Nothing, Optional ByVal pDadosProdutor As DataRow = Nothing) As String
    Private Function Frete_Registro_100(Optional ByVal pEstabeldoRomaneio As DataRow = Nothing, Optional ByVal pDadosCooperativa As DataRow = Nothing, Optional ByVal pDadosProdutor As DataRow = Nothing, Optional ByVal pDadosPropriedade As DataRow = Nothing) As String


        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim floperacao As String   'alfnum 1 posições
            Dim nrcnpjcpf As String
            Dim tpparceirocomercial As String
            Dim cdparceirocoml As String
            Dim nmparceirocoml As String
            Dim dsendereco As String
            Dim dsbairro As String
            Dim nomecidade As String
            Dim uf As String
            Dim cep As String
            Dim cdzonatransporte As String
            Dim tppessoa As String
            Dim dsinscrmunicipal As String
            Dim dsinscrestadual As String
            Dim stcontribuinteicms As String
            Dim stregcredicms As String
            Dim stexcluirefextparcom As String

            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            '====================================================================================
            ' Registro Tipo 100
            '====================================================================================

            'Tipo de Registro - Fixo 100
            tpregistro = "100"

            'Fl Operacao - Fixo A - 1 posição
            floperacao = "A"

            If Me.id_cooperativa > 0 Then
                'fran 26/11/2009 i chamado 549
                'nrcnpjcpf = FormataCampo(pDadosCooperativa.Item("cd_cnpj").ToString.Trim)
                'cdparceirocoml = nrcnpjcpf
                'nmparceirocoml = pDadosCooperativa.Item("nm_pessoa").ToString.Trim
                'dsendereco = String.Concat(pDadosCooperativa.Item("ds_endereco").ToString.Trim, Space(1), pDadosCooperativa.Item("nr_endereco").ToString.Trim)
                'dsbairro = pDadosCooperativa.Item("ds_bairro").ToString.Trim
                'nomecidade = pDadosCooperativa.Item("nm_cidade").ToString.Trim
                'uf = pDadosCooperativa.Item("cd_uf").ToString.Trim
                'cep = FormataCampo(pDadosCooperativa.Item("cd_cep").ToString.Trim)
                'dsinscrestadual = FormataCampo(pDadosCooperativa.Item("cd_inscricao_estadual").ToString.Trim)
                'fran 07/01/2011 rls 27 gko anexoi_03 i
                'nrcnpjcpf = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'cdparceirocoml = Left(nrcnpjcpf, 14).ToString
                'nmparceirocoml = String.Concat("Danone Ltda", Space(1), pEstabeldoRomaneio.Item("nm_estabelecimento").ToString.Trim)
                'dsendereco = Left(String.Concat(pEstabeldoRomaneio.Item("ds_endereco").ToString.Trim, Space(1), pEstabeldoRomaneio.Item("nr_endereco").ToString.Trim), 50)
                'dsbairro = Left(pEstabeldoRomaneio.Item("ds_bairro").ToString.Trim, 20)
                'nomecidade = Left(pEstabeldoRomaneio.Item("nm_cidade").ToString.Trim, 30)
                'uf = pEstabeldoRomaneio.Item("cd_uf").ToString.Trim
                'cep = Left(FormataCampo(pEstabeldoRomaneio.Item("cd_cep").ToString.Trim), 8)
                'dsinscrestadual = FormataCampo(pEstabeldoRomaneio.Item("cd_inscricao_estadual").ToString.Trim)
                nrcnpjcpf = FormataCampo(pDadosCooperativa.Item("cd_cnpj").ToString.Trim)
                cdparceirocoml = Left(nrcnpjcpf, 14)
                nmparceirocoml = Left(pDadosCooperativa.Item("nm_pessoa").ToString.Trim, 40)
                dsendereco = Left(String.Concat(pDadosCooperativa.Item("ds_endereco").ToString.Trim, Space(1), pDadosCooperativa.Item("nr_endereco").ToString.Trim), 50)
                dsbairro = Left(pDadosCooperativa.Item("ds_bairro").ToString.Trim, 20)
                nomecidade = Left(pDadosCooperativa.Item("nm_cidade").ToString.Trim, 30)
                uf = pDadosCooperativa.Item("cd_uf").ToString.Trim
                cep = Left(FormataCampo(pDadosCooperativa.Item("cd_cep").ToString.Trim), 8)
                dsinscrestadual = FormataCampo(pDadosCooperativa.Item("cd_inscricao_estadual").ToString.Trim)
                'fran 07/01/2011 rls 27 gko anexoi_03 f
                'fran 26/11/2009 f chamado 549
                'fran 16/11/2009 i
                'fran 07/01/2011 rls 27 gko anexoi_03 '
                'If pDadosCooperativa.Item("st_categoria") = "J" Then
                '    tppessoa = "2"
                'Else
                '    tppessoa = "1"
                'End If
                ' Adri 19/01/2011 - chamado 1161 (Foi solicitado para ser conforme categoria) - i
                'tppessoa = "1"  
                If pDadosCooperativa.Item("st_categoria") = "J" Then
                    tppessoa = "2"
                Else
                    tppessoa = "1"
                End If
                ' Adri 19/01/2011 - chamado 1161 (Foi solicitado para ser conforme categoria) - f
                'fran 07/01/2011 rls 27 gko anexoi_03 f
                'fran 16/11/2009 f
            Else
                'fran 17/12/2009 i chamado 477
                'nrcnpjcpf = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'cdparceirocoml = Left(nrcnpjcpf, 14).ToString
                'nmparceirocoml = String.Concat("Danone Ltda", Space(1), pEstabeldoRomaneio.Item("nm_estabelecimento").ToString.Trim)
                'dsendereco = String.Concat(pEstabeldoRomaneio.Item("ds_endereco").ToString.Trim, Space(1), pEstabeldoRomaneio.Item("nr_endereco").ToString.Trim)
                'dsbairro = pEstabeldoRomaneio.Item("ds_bairro").ToString.Trim
                'nomecidade = pEstabeldoRomaneio.Item("nm_cidade").ToString.Trim
                'uf = pEstabeldoRomaneio.Item("cd_uf").ToString.Trim
                'cep = FormataCampo(pEstabeldoRomaneio.Item("cd_cep").ToString.Trim)
                'dsinscrestadual = FormataCampo(pEstabeldoRomaneio.Item("cd_inscricao_estadual").ToString.Trim)
                If Not pDadosProdutor.Item("cd_cpf").ToString.Trim.Equals(String.Empty) Then
                    nrcnpjcpf = FormataCampo(pDadosProdutor.Item("cd_cpf").ToString.Trim)
                Else
                    nrcnpjcpf = FormataCampo(pDadosProdutor.Item("cd_cnpj").ToString.Trim)
                End If
                cdparceirocoml = Left(nrcnpjcpf, 14).ToString
                'fran 12/04/2011 i frete
                'nmparceirocoml = pDadosProdutor.Item("nm_pessoa").ToString.Trim
                'dsendereco = String.Concat(pDadosProdutor.Item("ds_endereco").ToString.Trim, Space(1), pDadosProdutor.Item("nr_endereco").ToString.Trim)
                'dsbairro = pDadosProdutor.Item("ds_bairro").ToString.Trim
                'nomecidade = pDadosProdutor.Item("nm_cidade").ToString.Trim
                'cep = FormataCampo(pDadosProdutor.Item("cd_cep").ToString.Trim)
                nmparceirocoml = Left(pDadosProdutor.Item("nm_pessoa").ToString.Trim, 40)

                'dsendereco = Left(String.Concat(pDadosProdutor.Item("ds_endereco").ToString.Trim, Space(1), pDadosProdutor.Item("nr_endereco").ToString.Trim), 50)
                'dsbairro = Left(pDadosProdutor.Item("ds_bairro").ToString.Trim, 20)
                'nomecidade = Left(pDadosProdutor.Item("nm_cidade").ToString.Trim, 30)
                'cep = Left(FormataCampo(pDadosProdutor.Item("cd_cep").ToString.Trim), 8)
                'fran 12/04/2011 f frete
                'uf = pDadosProdutor.Item("cd_uf").ToString.Trim
                'dsinscrestadual = FormataCampo(pDadosProdutor.Item("cd_inscricao_estadual").ToString.Trim)
                'fran 17/10/2009 f

                dsendereco = Left(String.Concat(pDadosPropriedade("ds_endereco").ToString.Trim, Space(1), pDadosPropriedade("nr_endereco").ToString.Trim), 50)
                dsbairro = Left(pDadosPropriedade("ds_bairro").ToString.Trim(), 20)
                nomecidade = Left(pDadosPropriedade.Item("nm_cidade").ToString.Trim, 30)
                cep = Left(FormataCampo(pDadosPropriedade.Item("cd_cep").ToString.Trim), 8)
                uf = pDadosPropriedade.Item("cd_uf").ToString.Trim
                dsinscrestadual = FormataCampo(pDadosPropriedade.Item("cd_inscricao_estadual").ToString.Trim)

                'fran 16/11/2009 i
                If pDadosProdutor.Item("st_categoria") = "J" Then
                    tppessoa = "2"
                Else
                    tppessoa = "1"
                End If
                'fran 16/11/2009 f
            End If

            'Formata campos
            nrcnpjcpf = Right(String.Concat(StrDup(15 - Len(nrcnpjcpf), "0"), nrcnpjcpf), 15)
            cdparceirocoml = Left(String.Concat(cdparceirocoml, Space(14 - Len(cdparceirocoml))), 14)
            nmparceirocoml = Left(String.Concat(nmparceirocoml, Space(40 - Len(nmparceirocoml))), 40)
            dsendereco = Left(String.Concat(dsendereco, Space(50 - Len(dsendereco))), 50)
            dsbairro = Left(String.Concat(dsbairro, Space(20 - Len(dsbairro))), 20)
            nomecidade = Left(String.Concat(nomecidade, Space(30 - Len(nomecidade))), 30)
            uf = Left(String.Concat(uf, Space(2 - Len(uf))), 2)
            cep = Right(String.Concat(StrDup(8 - Len(cep), "0"), cep), 8)
            dsinscrestadual = Left(String.Concat(dsinscrestadual, Space(15 - Len(dsinscrestadual))), 15)

            'TpParcComls fixo 
            'Fran 16/10/2009 i chamado 477
            'tpparceirocomercial = "2"
            tpparceirocomercial = "3"
            'fran 16/10/2009 f
            'cdzonatransporte 10 posições
            cdzonatransporte = Space(10)
            'Tp Pessoa 2 posições
            'fran 17/11/2009 i
            'Fran 16/10/2009 i chamado 477
            'tppessoa = "2"
            'tppessoa = "3"
            'Fran 16/10/2009 f
            'fran 17/11/2009 f
            'Inscr Municipal 15 posições
            dsinscrmunicipal = Space(15)
            stcontribuinteicms = "1"
            stregcredicms = "0"
            stexcluirefextparcom = Space(1)

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + floperacao + nrcnpjcpf + tpparceirocomercial + cdparceirocoml + nmparceirocoml
            linhatexto = linhatexto + dsendereco + dsbairro + nomecidade + uf + cep
            linhatexto = linhatexto + cdzonatransporte + tppessoa + dsinscrmunicipal + dsinscrestadual
            linhatexto = linhatexto + stcontribuinteicms + stregcredicms + stexcluirefextparcom

            Frete_Registro_100 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    'fran 22/09/2009 i rls21 - GKO
    'Private Function Frete_Registro_140(ByVal pCNPJTransportadora As String, ByVal pnmequipamento As String, Optional ByVal pId_coleta As String = "0", Optional ByVal pcoletaNprogramada As String = "N", Optional ByVal pEstabeldoRomaneio As DataRow = Nothing, Optional ByVal pDadosCooperativa As DataRow = Nothing, Optional ByVal pDadosProdutor As DataRow = Nothing, Optional ByVal pDadosPropriedade As DataRow = Nothing, Optional ByVal pcdnaturezaoperacao As String = "") As String 'fran 20/12/2009
    Private Function Frete_Registro_140(ByVal pCNPJTransportadora As String, ByVal pnmequipamento As String, Optional ByVal pId_coleta As String = "0", Optional ByVal pcoletaNprogramada As String = "N", Optional ByVal pEstabeldoRomaneio As DataRow = Nothing, Optional ByVal pDadosCooperativa As DataRow = Nothing, Optional ByVal pDadosProdutor As DataRow = Nothing, Optional ByVal pDadosPropriedade As DataRow = Nothing, Optional ByVal pcdnaturezaoperacao As String = "", Optional ByVal pnrunidproducao As String = "", Optional ByVal pbTransitPoint As Boolean = False, Optional ByVal pbTransbordo As Boolean = False) As String


        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim floperacao As String   'alfnum 1 posições
            Dim tpdocumento As String
            Dim parceirocomercial As String
            Dim cdnota As String
            Dim cdserie As String
            Dim dtemissao As String
            Dim dtembarque As String
            Dim tpentradasaida As String
            Dim pardestremet As String
            Dim dsenderecodestremet As String
            Dim dsbairrodestremet As String
            Dim nomecidade As String
            Dim uf As String
            Dim nrcepdestremet As String
            Dim cdzonatransporte As String
            Dim cddocnegfrete As String
            Dim cdtiponota As String
            Dim cdequipamento As String
            Dim cdembalagem As String
            Dim cdmeiotransporte As String
            Dim cdterritorio As String
            Dim dsseparadorconhecimento As String
            Dim dslote As String
            Dim cdromaneio As String
            Dim cdtransportadora As String
            Dim tpfrete As String
            Dim cddoctovinculado As String
            Dim cdseriedoctovinculado As String
            Dim cdnaturezaoperacao As String
            Dim stisentoimposto As String
            Dim stcreditoicms As String
            Dim stitemsubtribnacompra As String
            Dim tpfinalidadeoperacao As String
            Dim cdindfinanceiro As String
            Dim stentregaurgente As String
            Dim stfretediferenciado As String
            Dim dtentrega As String
            Dim chaverespfrete As String
            Dim dttabpreco As String
            Dim dtprevisaoentrega As String
            Dim stexcluiitemdne As String
            Dim stexcluirefext As String
            Dim vrfretepgcliente As String
            Dim Brancos1 As String 'fran 14/07/2012
            Dim Brancos2 As String 'fran 14/07/2012
            Dim dschaveacesso As String 'fran 14/07/2012
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            '====================================================================================
            ' Registro Tipo 140
            '====================================================================================

            'Tipo de Registro - Fixo 140
            tpregistro = "140"

            'Fl Operacao - Fixo A - 1 posição
            floperacao = "A"

            tpdocumento = "1"

            If Me.id_cooperativa > 0 Then
                'fran 18/12/2009 i chamdo 587
                'parceirocomercial = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                parceirocomercial = FormataCampo(pDadosCooperativa.Item("cd_cnpj").ToString.Trim)
                'fran 18/12/2009 f chamdo 587
                'fran 20/5/2011 chamado 1272 i
                'cdnota = Left(String.Concat(Me.nr_nota_fiscal, Space(12 - Len(Me.nr_nota_fiscal))), 12)
                'cdserie = Left(String.Concat(Me.nr_serie_nota_fiscal, Space(3 - Len(Me.nr_serie_nota_fiscal))), 3)
                If Len(Me.nr_nota_fiscal) > 12 Then
                    cdnota = Left(Me.nr_nota_fiscal, 12)
                Else
                    cdnota = Left(String.Concat(Me.nr_nota_fiscal, Space(12 - Len(Me.nr_nota_fiscal))), 12)
                End If
                If Len(Me.nr_serie_nota_fiscal) > 3 Then
                    cdserie = Left(Me.nr_serie_nota_fiscal, 3)
                Else
                    cdserie = Left(String.Concat(Me.nr_serie_nota_fiscal, Space(3 - Len(Me.nr_serie_nota_fiscal))), 3)
                End If
                'fran 20/5/2011 chamado 1272 f
                dtemissao = DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy")
                dtembarque = DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy")
                tpentradasaida = "1"
                'fran 12/02/2010 i chamado 176
                'pardestremet = FormataCampo(pDadosCooperativa.Item("cd_cnpj").ToString.Trim)
                pardestremet = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'fran 12/02/2010 f chamado 176

                dsenderecodestremet = String.Concat(pDadosCooperativa.Item("ds_endereco").ToString.Trim, Space(1), pDadosCooperativa.Item("nr_endereco").ToString.Trim)
                dsbairrodestremet = pDadosCooperativa.Item("ds_bairro").ToString.Trim
                nomecidade = Left(pDadosCooperativa.Item("nm_cidade").ToString.Trim, 30)
                uf = pDadosCooperativa.Item("cd_uf").ToString.Trim
                nrcepdestremet = FormataCampo(pDadosCooperativa.Item("cd_cep").ToString.Trim)

                'fran 18/08/2012 i
                'dtentrega = DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy")
                dtentrega = Left(String.Concat(Left(DateTime.Parse(Me.dt_saida_nota).ToString("yyyyMMdd"), 8), Space(2)), 10)
                'fran 18/08/2012 f

                'fran 17/11/2009 i
                'chaverespfrete = pardestremet
                'fran 18/12/2009 i chamdo 587
                'chaverespfrete = parceirocomercial
                chaverespfrete = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'fran 18/12/2009 f
                'fran 17/11/2009 f 
                'fran 12/02/2012 i release frete
                'se cooperativa assume que cdmeiotransporte= 6 (DAL COOPERATIVA)
                cdmeiotransporte = String.Concat("6", Space(3))
                'fran 12/02/2012 f release frete

            Else
                'fran 18/12/2009 i chamdo 588
                'parceirocomercial = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'fran 18/12/2009 f chamdo 587

                cdnota = Left(String.Concat(pId_coleta, Space(12 - Len(pId_coleta))), 12)
                'fran 18/10/2009 i chamado 477
                'cdserie = Space(3)
                'dtemissao = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
                'dtembarque = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
                'tpentradasaida = "1"
                'pardestremet = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'dsenderecodestremet = String.Concat(pEstabeldoRomaneio.Item("ds_endereco").ToString.Trim, Space(1), pEstabeldoRomaneio.Item("nr_endereco").ToString.Trim)
                'dsbairrodestremet = pEstabeldoRomaneio.Item("ds_bairro").ToString.Trim
                'nomecidade = pEstabeldoRomaneio.Item("nm_cidade").ToString.Trim
                'uf = pEstabeldoRomaneio.Item("cd_uf").ToString.Trim
                'nrcepdestremet = FormataCampo(pEstabeldoRomaneio.Item("cd_cep").ToString.Trim)
                'dtentrega = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
                'chaverespfrete = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                cdserie = "DAL"
                dtemissao = DateTime.Parse(Me.dt_transmissao).ToString("dd/MM/yyyy")
                dtembarque = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
                tpentradasaida = "1"

                'pardestremet = FormataCampo(pDadosProdutor.Item("cd_cpf").ToString.Trim)
                'fran 12/03/2010 i chamado 716
                'If Not pDadosProdutor.Item("cd_cpf").ToString.Trim.Equals(String.Empty) Then
                '    pardestremet = FormataCampo(pDadosProdutor.Item("cd_cpf").ToString.Trim)
                'Else
                '    pardestremet = FormataCampo(pDadosProdutor.Item("cd_cnpj").ToString.Trim)
                'End If
                pardestremet = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'fran 12/03/2010 f chamado 716

                'fran 16/03/2010 i chamado 716
                'fran 18/12/2009 i chamdo 588
                'parceirocomercial = pardestremet
                'fran 18/12/2009 f chamdo 588
                If Not pDadosProdutor.Item("cd_cpf").ToString.Trim.Equals(String.Empty) Then
                    parceirocomercial = FormataCampo(pDadosProdutor.Item("cd_cpf").ToString.Trim)
                Else
                    parceirocomercial = FormataCampo(pDadosProdutor.Item("cd_cnpj").ToString.Trim)
                End If
                'fran 16/03/2010 f chamado 716

                'fran i - chamado 569
                'dsenderecodestremet = String.Concat(pDadosPropriedade.Item("id_propriedade").ToString.Trim, pDadosPropriedade.Item("nm_propriedade").ToString.Trim)
                dsenderecodestremet = String.Concat(pDadosPropriedade.Item("id_propriedade").ToString.Trim, "-", pnrunidproducao, pDadosPropriedade.Item("nm_propriedade").ToString.Trim)
                'fran f - chamado 569
                dsbairrodestremet = dsenderecodestremet
                nomecidade = Left(pDadosPropriedade.Item("nm_cidade").ToString.Trim, 30)
                uf = pDadosPropriedade.Item("cd_uf").ToString.Trim
                nrcepdestremet = FormataCampo(pDadosPropriedade.Item("cd_cep").ToString.Trim)
                'fran 18/08/2012 i
                'dtentrega = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
                dtentrega = Left(String.Concat(Left(DateTime.Parse(Me.dt_hora_entrada).ToString("yyyyMMdd"), 8), Space(2)), 10)
                'fran 18/08/2012 f

                chaverespfrete = FormataCampo(pEstabeldoRomaneio.Item("cd_cnpj").ToString.Trim)
                'fran 12/02/2012 i release frete
                'se produtor assume que cdmeiotransporte= 5 (FRETE FOB)
                'fran 18/12/2014 i  email enviado por Ana em 14/10/2014 solicitando alteração de frete para 4 pois 4 é FOB no GKO e 5 é CIF
                'cdmeiotransporte = String.Concat("5", Space(3))
                cdmeiotransporte = String.Concat("4", Space(3))
                'fran 18/12/2014 f
                'fran 12/02/2012 f release frete

                'fran 26/04/2015 i
                If uf = "MG" Then
                    'cdmeiotransporte = String.Concat("5", Space(3))
                    cdmeiotransporte = String.Concat("4", Space(3))
                End If
                'fran 26/04/2015 f

                'fran 31/08/2020 i se for cidade de poços de caldas
                If pDadosPropriedade.Item("id_cidade").ToString.Trim.Equals("2324") Then
                    cdmeiotransporte = String.Concat("4", Space(3))
                End If

                'fran 16/05/2017
                If pbTransitPoint = True OrElse pbTransbordo = True Then
                    cdmeiotransporte = String.Concat("4", Space(3)) 'força 4 para transit e transbordo
                End If

            End If

            'Formata campos
            parceirocomercial = Left(String.Concat(parceirocomercial, Space(15 - Len(parceirocomercial))), 15)
            pardestremet = Left(String.Concat(pardestremet, Space(15 - Len(pardestremet))), 15)

            If Len(dtemissao.Trim) > 10 Then
                dtemissao = Left(dtemissao, 10)
            Else
                dtemissao = Left(String.Concat(dtemissao, Space(10 - Len(dtemissao))), 10)
            End If
            If Len(dtembarque.Trim) > 10 Then
                dtembarque = Left(dtembarque, 10)
            Else
                dtembarque = Left(String.Concat(dtembarque, Space(10 - Len(dtembarque))), 10)
            End If
            If Len(dtentrega.Trim) > 10 Then
                dtentrega = Left(dtentrega, 10)
            Else
                dtentrega = Left(String.Concat(dtentrega, Space(10 - Len(dtentrega))), 10)
            End If
            If Len(dsenderecodestremet) > 50 Then
                dsenderecodestremet = Left(dsenderecodestremet, 50)
            Else
                dsenderecodestremet = Left(String.Concat(dsenderecodestremet, Space(50 - Len(dsenderecodestremet))), 50)
            End If
            If Len(dsbairrodestremet) > 20 Then
                dsbairrodestremet = Left(dsbairrodestremet, 20)
            Else
                dsbairrodestremet = Left(String.Concat(dsbairrodestremet, Space(20 - Len(dsbairrodestremet))), 20)
            End If
            nomecidade = Left(String.Concat(nomecidade, Space(30 - Len(nomecidade))), 30)
            uf = Left(String.Concat(uf, Space(2 - Len(uf))), 2)
            nrcepdestremet = Right(String.Concat(StrDup(8 - Len(nrcepdestremet), "0"), nrcepdestremet), 8)
            chaverespfrete = Left(String.Concat(chaverespfrete, Space(15 - Len(chaverespfrete))), 15)

            'cdzonatransporte 10 posições
            cdzonatransporte = Space(10)

            cddocnegfrete = Space(12)
            'fran 18/10/2009 chamado 477
            'cdtiponota = "TRAN"
            cdtiponota = "COMP"
            'fran 18/10/2009 f
            'Cd equipamento 10 posiçoes
            cdequipamento = pnmequipamento.Trim
            If Len(cdequipamento) > 10 Then
                cdequipamento = Left(cdequipamento, 10)
            Else
                cdequipamento = Left(String.Concat(cdequipamento, Space(10 - Len(cdequipamento))), 10)
            End If

            cdembalagem = (Space(4))
            'fran 18/10/2009 chamado 477
            'cdmeiotransporte = String.Concat("1", Space(3))
            'cdmeiotransporte = String.Concat("4", Space(3)) 'fran 12/02/2012 i alteração frete
            'fran 18/10/2009 f
            cdterritorio = Space(10)
            dsseparadorconhecimento = Space(10)
            'fran 18/10/2009 chamado 477
            'dslote = Space(20)
            'Fran 26/10/2009 i
            'dslote = String.Concat(Me.ds_placa_frete.ToString.Trim, Me.dt_transmissao).Trim
            'fran 07/01/2011 rls 27 gko anexoi_03 i
            If Me.id_cooperativa > 0 Then
                dslote = String.Concat(Me.ds_placa_frete.ToString.Trim, DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy")).Trim
            Else
                'fran 07/01/2011 rls 27 gko anexoi_03 f
                dslote = String.Concat(Me.ds_placa_frete.ToString.Trim, DateTime.Parse(Me.dt_transmissao).ToString("dd/MM/yyyy")).Trim
            End If
            'Fran 26/10/2009 f

            If Len(dslote) > 20 Then
                dslote = Left(dslote, 20)
            Else
                dslote = Left(String.Concat(dslote, Space(20 - Len(dslote))), 20)
            End If
            'fran 18/10/2009 f

            'fran 18/20/2009 i chamado 477
            'If Len(Me.id_romaneio.ToString.Trim) > 10 Then
            '    cdromaneio = Left(Me.id_romaneio.ToString.Trim, 10)
            'Else
            '    cdromaneio = Left(String.Concat(Me.id_romaneio.ToString.Trim, Space(10 - Len(Me.id_romaneio.ToString.Trim))), 10)
            'End If
            If Me.id_cooperativa > 0 Then
                ' adri 19/01/2011 - chamado 1161 - Concatenar com o n.o da NF conforme anexo 03 - i
                'cdromaneio = String.Concat("C", Me.id_romaneio.ToString.Trim)
                'fran 20/05/2011i chamado 1296
                'cdromaneio = String.Concat("C", Me.nr_nota_fiscal.ToString.Trim)
                cdromaneio = String.Concat("D", Me.id_romaneio.ToString.Trim)
                'fran 20/05/2011 f chamado 1296

                ' adri 19/01/2011 - chamado 1161 - Concatenar com o n.o da NF conforme anexo 03 - i
            Else
                cdromaneio = String.Concat("D", Me.id_romaneio.ToString.Trim)
            End If
            'Fran 14/07/2012 i mudança layout GKO
            'If Len(cdromaneio) > 10 Then
            '    cdromaneio = Left(cdromaneio, 10)
            'Else
            '    cdromaneio = Left(String.Concat(cdromaneio, Space(10 - Len(cdromaneio))), 10)
            'End If
            If Len(cdromaneio) > 14 Then
                cdromaneio = Left(cdromaneio, 14)
            Else
                cdromaneio = Left(String.Concat(cdromaneio, Space(14 - Len(cdromaneio))), 14)
            End If
            'Fran 14/07/2012 f mudança layout GKO

            'fran 18/20/2009 f chamado 477

            'cd transportadora - CNPJ Transportadora - 15 posições
            cdtransportadora = FormataCampo(pCNPJTransportadora.Trim.ToString).Trim
            cdtransportadora = String.Concat(cdtransportadora, Space(15 - Len(cdtransportadora)))

            'Fran 14/07/2012 i mudança layout GKO
            'tpfrete = "2"
            tpfrete = "02"
            'Fran 14/07/2012 f mudança layout GKO

            cddoctovinculado = Space(12)
            If pcoletaNprogramada = "S" Then
                cddoctovinculado = "NPROGRAMADA "
            End If
            'Fran 14/07/2012 i mudança layout GKO
            'cdseriedoctovinculado = Space(3)
            cdseriedoctovinculado = Space(2)
            'Fran 14/07/2012 f mudança layout GKO

            'NATUREZA de OPERAÇÃO
            'Fran 19/10/2009 i
            If Me.id_cooperativa > 0 Then
                'fran 26/11/2009 i chamado 550
                'cdnaturezaoperacao = Space(6)
                cdnaturezaoperacao = pcdnaturezaoperacao
                If Len(cdnaturezaoperacao) > 6 Then
                    cdnaturezaoperacao = Left(cdnaturezaoperacao, 6)
                End If
                cdnaturezaoperacao = Left(String.Concat(cdnaturezaoperacao, Space(6 - Len(cdnaturezaoperacao))), 6)
                'fran 26/11/2009 f chamado 550

            Else
                cdnaturezaoperacao = Space(6)
                'Verifica qual o estado da propriedade/produtotr
                Select Case pDadosPropriedade.Item("cd_uf")
                    Case "MG"
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito,  NAO TEM incentivo 2,1 e NAO TEM incentivo 2,4
                        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                            cdnaturezaoperacao = "1101  "
                        End If
                        'Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        If pDadosPropriedade.Item("st_incentivo_fiscal") <> "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                            cdnaturezaoperacao = "1101  "
                        End If
                        'Se NAO TEM incentivo 2,5, TEM transf credito e NAO TEM incentivo 2,1
                        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "S" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                            cdnaturezaoperacao = "1101  "
                        End If
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e TEM incentivo 2,1
                        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And (pDadosPropriedade.Item("st_incentivo_21") = "S" Or pDadosPropriedade.Item("st_incentivo_24") = "S") Then
                            cdnaturezaoperacao = "1101  "
                        End If
                    Case "SP"
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                            'poços dde caldas
                            If Me.id_estabelecimento = 1 Then
                                cdnaturezaoperacao = "2101  "
                            End If
                            'guara
                            If Me.id_estabelecimento = 2 Then
                                cdnaturezaoperacao = "1101  "
                            End If
                            'águas prata
                            If Me.id_estabelecimento = 6 Then
                                cdnaturezaoperacao = "1101  "
                            End If
                        End If
                    Case "RJ"
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                            'guara
                            If Me.id_estabelecimento = 2 Then
                                cdnaturezaoperacao = "2101  "
                            End If
                        End If
                    Case Else
                        cdnaturezaoperacao = Space(6)
                End Select

            End If
            'Fran 14/07/2012 i mudança layout GKO
            cdnaturezaoperacao = Space(6)
            'Fran 14/07/2012 i mudança layout GKO

            stisentoimposto = "N"
            stcreditoicms = "N"
            stitemsubtribnacompra = "N"
            'tpfinalidadeoperacao = "03" 'fran 23/10/2009
            tpfinalidadeoperacao = "02" 'fran 23/10/2009
            'Fran 14/07/2012 i mudança layout GKO
            'cdindfinanceiro = Space(10)
            cdindfinanceiro = Space(76)
            'Fran 14/07/2012 f mudança layout GKO
            stentregaurgente = "N"
            stfretediferenciado = "N"
            'Fran 14/07/2012 i mudança layout GKO
            'dttabpreco = Space(10)
            'dtprevisaoentrega = Space(8)
            'stexcluiitemdne = "N"
            'stexcluirefext = "N"
            'vrfretepgcliente = StrDup(15, "0")
            dttabpreco = Space(8)
            Brancos1 = Space(5)
            Brancos2 = Space(22)
            dschaveacesso = Space(44)
            'Fran 14/07/2012 f mudança layout GKO


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + floperacao + tpdocumento + parceirocomercial + cdnota + cdserie + dtemissao
            linhatexto = linhatexto + dtembarque + tpentradasaida + pardestremet + dsenderecodestremet + dsbairrodestremet + nomecidade + uf + nrcepdestremet
            linhatexto = linhatexto + cdzonatransporte + cddocnegfrete + cdtiponota + cdequipamento + cdembalagem + cdmeiotransporte + cdterritorio
            linhatexto = linhatexto + dsseparadorconhecimento + dslote + cdromaneio + cdtransportadora + tpfrete + cddoctovinculado + cdseriedoctovinculado
            linhatexto = linhatexto + cdnaturezaoperacao + stisentoimposto + stcreditoicms + stitemsubtribnacompra + tpfinalidadeoperacao + cdindfinanceiro + stentregaurgente + stfretediferenciado
            'Fran 14/07/2012 i mudança layout GKO
            'linhatexto = linhatexto + dtentrega + chaverespfrete + dttabpreco + dtprevisaoentrega + stexcluiitemdne + stexcluirefext + vrfretepgcliente
            linhatexto = linhatexto + dtentrega + chaverespfrete + dttabpreco + Brancos1 + Brancos2 + dschaveacesso
            'Fran 14/07/2012 f mudança layout GKO

            Frete_Registro_140 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    'Private Function Frete_Registro_142(ByVal pCNPJEstabelRomaneio As String, ByVal pcnpjcpf As String, ByVal pproprietariotanque As String, Optional ByVal pnmabreviadotecnico As String = "", Optional ByVal pId_coleta As String = "0") As String 'fran20/12/2009
    'Private Function Frete_Registro_142(ByVal pCNPJEstabelRomaneio As String, ByVal pcnpjcpf As String, ByVal pproprietariotanque As String, Optional ByVal pnmabreviadotecnico As String = "", Optional ByVal pId_coleta As String = "0", Optional ByVal pvltotalkm As String = "0", Optional ByVal pcoletasemlitros As Boolean = False) As String Fran gkorls 27 07/01/2011 
    'Private Function Frete_Registro_142(ByVal pCNPJEstabelRomaneio As String, ByVal pcnpjcpf As String, ByVal pproprietariotanque As String, Optional ByVal pnmabreviadotecnico As String = "", Optional ByVal pId_coleta As String = "0", Optional ByVal pvltotalkm As String = "0", Optional ByVal pcoletasemlitros As Boolean = False, Optional ByVal pcdnaturezaoperacao As String = "") As String 'fran 03/2017
    Private Function Frete_Registro_142(ByVal pCNPJEstabelRomaneio As String, ByVal pcnpjcpf As String, ByVal pproprietariotanque As String, Optional ByVal pnmabreviadotecnico As String = "", Optional ByVal pId_coleta As String = "0", Optional ByVal pvltotalkm As String = "0", Optional ByVal pcoletasemlitros As Boolean = False, Optional ByVal pcdnaturezaoperacao As String = "", Optional ByVal pbTransitPoint As Boolean = False, Optional ByVal pbTransbordo As Boolean = False) As String


        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim parceirocoml As String   'Num 15 posições
            Dim cdnota As String   'Num 12 posições
            Dim cdserie As String   'Num 2 posições
            Dim codref1 As String '15 posições
            Dim dsref1 As String  '15 posições
            Dim codref2 As String '15 posições
            Dim dsref2 As String  '15 posições
            Dim codref3 As String '15 posições
            Dim dsref3 As String  '15 posições
            Dim codref4 As String '15 posições
            Dim dsref4 As String  '15 posições
            Dim codref5 As String '15 posições
            Dim dsref5 As String  '15 posições
            Dim codref6 As String '15 posições
            Dim dsref6 As String  '15 posições
            Dim codref7 As String '15 posições
            Dim dsref7 As String  '15 posições
            Dim codref8 As String '15 posições
            Dim dsref8 As String  '15 posições
            '====================================================================================
            ' Registro Tipo 142
            '====================================================================================

            'Tipo de Registro - Fixo 142
            tpregistro = "142"
            'fran 17/11/2009 i
            'parceirocoml = FormataCampo(pcnpjcpf.ToString) 'fran 18/10/2009 i chamado 477
            parceirocoml = FormataCampo(pCNPJEstabelRomaneio.ToString)
            'fran 17/11/2009 f
            If Len(parceirocoml.Trim) > 15 Then
                parceirocoml = Left(parceirocoml.Trim, 15)
            Else
                parceirocoml = String.Concat(parceirocoml.Trim, Space(15 - Len(parceirocoml.Trim)))
            End If

            'cnpj romaneio
            'codref1 = Left(String.Concat(pCNPJEstabelRomaneio, Space(15 - Len(pCNPJEstabelRomaneio))), 15) 'fran 18/10/2009 chamado 477

            If Me.id_cooperativa > 0 Then
                'fran 18/10/2009 i chamado 477
                'If Len(Me.nr_nota_fiscal) + Len(Me.nr_serie_nota_fiscal) >= 15 Then
                '    dsref1 = Left(String.Concat(Me.nr_nota_fiscal, Me.nr_serie_nota_fiscal), 15)
                'Else
                '    dsref1 = Left(String.Concat(Me.nr_nota_fiscal, Me.nr_serie_nota_fiscal, Space(15 - (Len(Me.nr_nota_fiscal) + Len(Me.nr_serie_nota_fiscal)))), 15)
                'End If
                cdnota = Me.nr_nota_fiscal.ToString.Trim
                If Len(cdnota) > 12 Then
                    cdnota = Left(cdnota, 12)
                Else
                    cdnota = Left(String.Concat(cdnota, Space(12 - Len(cdnota))), 12)
                End If

                cdserie = Me.nr_serie_nota_fiscal.ToString.Trim
                If Len(cdserie) > 3 Then
                    cdserie = Left(cdserie, 3)
                Else
                    cdserie = Left(String.Concat(cdserie, Space(3 - Len(cdserie))), 3)
                End If

                'fran 18/10/2009 f chamado 477
                codref1 = String.Concat("CANAL", Space(10))
                'Fran 14/07/2012 i mudança layout GKO
                'dsref1 = String.Concat("COOPERATIVA", Space(4))
                dsref1 = String.Concat("COOPERATIVA", Space(19))
                'Fran 14/07/2012 f mudança layout GKO

            Else
                'fran 18/10/2009 i chamado 477
                'If Len(pId_coleta) >= 15 Then
                '    dsref1 = Left(pId_coleta, 15)
                'Else
                '    dsref1 = Left(String.Concat(pId_coleta, Space(15 - Len(pId_coleta))), 15)
                'End If
                If Len(pId_coleta) > 12 Then
                    cdnota = Left(pId_coleta, 12)
                Else
                    cdnota = Left(String.Concat(pId_coleta, Space(12 - Len(pId_coleta))), 12)
                End If
                cdserie = "DAL"
                codref1 = String.Concat("CANAL", Space(10))
                'Fran 14/07/2012 i mudança layout GKO
                'dsref1 = String.Concat("PRODUTOR", Space(7))
                dsref1 = String.Concat("PRODUTOR", Space(22))
                'Fran 14/07/2012 f mudança layout GKO
                'fran 18/10/2009 f chamado 477
            End If

            'fran 18/10/2009 i chamado 477
            'codref2 = String.Concat("CANAL", Space(10))
            'dsref2 = Space(15)
            'codref3 = Space(15)
            'dsref3 = Space(15)
            'codref4 = "TIPO TRANSPORTE"
            'dsref4 = String.Concat("PRIMARIO", Space(7))
            'codref5 = String.Concat("TIPO DE BAU", Space(4))
            'dsref5 = String.Concat("PROPRIO", Space(8))
            'codref6 = String.Concat("ROTEIRO", Space(8))
            'dsref6 = String.Concat(Me.nm_linha, Space(15 - Len(nm_linha)))
            'codref7 = Space(15)
            'dsref7 = Space(15)
            'codref8 = Space(15)
            'dsref8 = Space(15)

            codref2 = String.Concat("OCORRENCIA", Space(5))
            'fran 18/12/2009 i chamado 587 - se o total km para cooperativa for zerado envia msg pelo campo para que usuario revise cooperativa
            'dsref2 = Space(15)
            If Me.id_cooperativa > 0 Then
                If pvltotalkm = "00000000" Then 'se nAo tem distancia cadastrada
                    dsref2 = "REVISAR COOP.  " 'assume texto revisar coop.
                    'fran 07/01/2011 i rla27 gko
                    'se nao tem distancia nem natureza operação no cadastro
                    If pcdnaturezaoperacao.ToString.Trim.Equals(String.Empty) Then
                        dsref2 = "REV. COOP/NF   " 'assume revisar coop e npota fiscal
                    End If
                    'fran 07/01/2011 f rla27 gko
                Else 'se tem valor em distancia
                    dsref2 = Space(15) 'assume que não tem tem nenhuma revisao a ser feita
                    'fran 07/01/2011 i rla27 gko
                    'se natureza operação no cadastro
                    If pcdnaturezaoperacao.ToString.Trim.Equals(String.Empty) Then
                        dsref2 = "REVISAR NF     "
                    End If
                    'fran 07/01/2011 f rla27 gko
                End If
            Else
                If pcoletasemlitros = True Then
                    dsref2 = "REVISAR ROTA   "
                Else
                    dsref2 = Space(15)
                End If

            End If
            'fran 18/12/2009 f 
            codref3 = "TIPO TRANSPORTE"
            dsref3 = String.Concat("DAL", Space(12))
            codref4 = String.Concat("TIPO DE BAU", Space(4))
            dsref4 = Space(15)
            If pproprietariotanque.ToString.Trim = "T" Then
                dsref4 = String.Concat("PROPRIO", Space(8))
            End If
            If pproprietariotanque.ToString.Trim = "D" Then
                dsref4 = String.Concat("DANONE", Space(9))
            End If
            codref5 = String.Concat("ROTEIRO", Space(8))
            'fran 26/11/2009 i chamado 551
            'dsref5 = String.Concat(Me.nm_linha, Space(15 - Len(nm_linha)))
            If Me.id_cooperativa > 0 Then
                dsref5 = "ROTCOOPERATIVA "
            Else
                dsref5 = String.Concat(Me.nm_linha, Space(15 - Len(nm_linha)))

                If pbTransitPoint = True Then
                    dsref5 = String.Concat("TP", Me.nm_linha, Space(15 - Len(nm_linha)))
                End If
                If pbTransbordo = True Then
                    dsref5 = String.Concat("TR", Me.nm_linha, Space(15 - Len(nm_linha)))
                End If

            End If
            'fran 26/11/2009 f chamado 551
            codref6 = Space(15)
            dsref6 = Space(15)
            codref7 = String.Concat("GER_REGIO", Space(6))
            dsref7 = String.Concat(pnmabreviadotecnico, Space(15 - Len(pnmabreviadotecnico)))
            codref8 = String.Concat("TIPONF", Space(9))
            dsref8 = String.Concat("1", Space(14))
            'fran 18/10/2009 f chamado 477

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            'fran 18/10/2009 i chamado 477
            'linhatexto = tpregistro + dsref1 + codref2 + dsref2 + codref3 + dsref3 + codref4 + dsref4
            linhatexto = tpregistro + parceirocoml + cdnota + cdserie + codref1 + dsref1 + codref2 + dsref2 + codref3 + dsref3 + codref4 + dsref4
            linhatexto = linhatexto + codref5 + dsref5 + codref6 + dsref6 + codref7 + dsref7 + codref8 + dsref8
            'Fran 14/07/2012 i mudança layout GKO
            linhatexto = linhatexto + Space(30)
            'Fran 14/07/2012 F mudança layout GKO

            Frete_Registro_142 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function Frete_Registro_120(ByVal pCdItem As String, ByVal pNmItem As String, ByVal ptotallitros As String, ByVal pMediaDensidade As String) As String


        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim floperacao As String '1 posições
            Dim dsitem As String  '40 posições
            Dim cditem As String '20 posições
            Dim cditemcategoria As String  '10 posições
            Dim cditemcategoria2 As String '10 posições
            Dim unidade1 As String  '3 posições
            Dim qtref1 As String '7 posições
            Dim peso1 As String  '7 posições
            Dim unidade2 As String  '3 posições
            Dim qtref2 As String '7 posições
            Dim peso2 As String  '7 posições
            Dim unidade3 As String  '3 posições
            Dim qtref3 As String '7 posições
            Dim peso3 As String  '7 posições
            Dim unidade4 As String  '3 posições
            Dim qtref4 As String '7 posições
            Dim peso4 As String  '7 posições
            '====================================================================================
            ' Registro Tipo 120
            '====================================================================================
            Dim lvalorint As String
            Dim lvalordec As String
            Dim lpos As Integer

            'Tipo de Registro - Fixo 120
            tpregistro = "120"

            floperacao = "A"

            dsitem = pNmItem
            'fran rls 27 gko 07/01/2011 i
            If Me.id_cooperativa > 0 Then
                dsitem = "LEITE"
            End If
            'fran rls 27 gko 07/01/2011 f

            dsitem = String.Concat(dsitem, Space(40 - Len(dsitem)))

            cditem = pCdItem
            cditem = String.Concat(cditem, Space(20 - Len(cditem)))

            cditemcategoria = Space(10)
            'cditemcategoria2 = Space(10) 'fran 23/10/2009
            cditemcategoria2 = String.Concat("1", Space(9)) 'fran 23/10/2009
            'Fran 18/10/2009 i chamado 477
            'unidade1 = "LT "
            unidade1 = "L  "
            'Fran 18/10/2009 f chamado 477

            'qtref1 = StrDup(7, "0") 'Fran 28/10/2009 i
            If ptotallitros.Equals(String.Empty) Then
                ptotallitros = "0"
            End If
            lpos = InStr(1, ptotallitros, ",")
            If lpos > 0 Then
                lvalorint = Mid(ptotallitros, 1, lpos - 1)
            Else
                lvalorint = ptotallitros
            End If
            'Fran 28/10/2009 i
            'peso1 = Right(String.Concat(StrDup(7 - Len(lvalorint), "0"), lvalorint), 7)

            If Len(lvalorint) > 5 Then
                qtref1 = Left(lvalorint, 5)
            Else
                qtref1 = Right(String.Concat(StrDup(5 - Len(lvalorint), "0"), lvalorint), 5)
            End If
            '7 posicoes 5 inteiro 2 decimais
            qtref1 = String.Concat(qtref1, "00")

            'peso 1 7 posiçõe - 5 inteiro e 2 decimais
            peso1 = Round(CDec(ptotallitros) * pMediaDensidade, 2).ToString

            lpos = InStr(1, peso1, ",")
            If lpos > 0 Then
                lvalorint = Mid(peso1, 1, lpos - 1)
                lvalordec = Mid(peso1, lpos + 1)
                If Len(lvalorint) > 5 Then
                    lvalorint = Left(lvalorint, 5)
                Else
                    lvalorint = Right(String.Concat(StrDup(5 - Len(lvalorint), "0"), lvalorint), 5)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                End If

            Else
                lvalorint = peso1
                If Len(lvalorint) > 5 Then
                    lvalorint = Left(lvalorint, 5)
                Else
                    lvalorint = Right(String.Concat(StrDup(5 - Len(lvalorint), "0"), lvalorint), 5)
                End If
                lvalordec = "00"
            End If

            peso1 = Right(String.Concat(lvalorint, lvalordec), 7)
            'fran 28/10/2009 f
            unidade2 = Space(3)
            qtref2 = StrDup(7, "0")
            peso2 = StrDup(7, "0")

            unidade3 = Space(3)
            qtref3 = StrDup(7, "0")
            peso3 = StrDup(7, "0")

            unidade4 = Space(3)
            qtref4 = StrDup(7, "0")
            peso4 = StrDup(7, "0")


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + floperacao + dsitem + cditem + cditemcategoria + cditemcategoria2
            linhatexto = linhatexto + unidade1 + qtref1 + peso1 + unidade2 + qtref2 + peso2
            linhatexto = linhatexto + unidade3 + qtref3 + peso3 + unidade4 + qtref4 + peso4

            Frete_Registro_120 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    'Private Function Frete_Registro_160(ByVal pCdItem As String, ByVal pNrLitrosColeta As String, ByVal pCNPJEstabel As String, ByVal pMediaDensidade As Decimal, Optional ByVal pId_coleta As String = "0", Optional ByVal ppreconegociado As String = "0") As String 'fran1 20/12/2009
    'Private Function Frete_Registro_160(ByVal pCdItem As String, ByVal pNrLitrosColeta As String, ByVal pCNPJEstabel As String, ByVal pMediaDensidade As Decimal, Optional ByVal pId_coleta As String = "0", Optional ByVal ppreconegociado As String = "0", Optional ByVal pCNPJCooperativa As String = "", Optional ByVal pCNPJCPFProdutor As String = "") As String 'fran 14/07/2012
    Private Function Frete_Registro_160(ByVal pCdItem As String, ByVal pNrLitrosColeta As String, ByVal pCNPJEstabel As String, ByVal pMediaDensidade As Decimal, Optional ByVal pId_coleta As String = "0", Optional ByVal ppreconegociado As String = "0", Optional ByVal pCNPJCooperativa As String = "", Optional ByVal pCNPJCPFProdutor As String = "", Optional ByVal pcdnaturezaoperacao As String = "", Optional ByVal pDadosPropriedade As DataRow = Nothing) As String

        Try

            Dim linhatexto As String
            ' Registro 000
            Dim tpregistro As String   'Num 3 posições
            Dim floperacao As String '1 posições
            Dim chaveemitente As String
            Dim cdnota As String
            Dim cdserie As String
            Dim nrnotaitem As String
            Dim cditem As String
            Dim vlnotaitem As String
            Dim qtpesobruto As String
            Dim qtpesocubado As String
            Dim qtpesoliquido As String
            Dim qtvolume As String
            Dim vlcubagem As String
            Dim cdcontacontabil As String
            Dim cdcentrocusto As String
            Dim qtitem As String
            Dim dsuniitem As String
            Dim vlfretepgclitab As String
            Dim vlfretepgcliente As String
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            Dim lvaloritemnota As Decimal
            Dim cdnaturezaoperacao As String
            '
            Dim parceirocomercial As String 'fran 18/10/2009

            '====================================================================================
            ' Registro Tipo 160
            '====================================================================================

            'Tipo de Registro - Fixo 160
            tpregistro = "160"

            floperacao = "A"
            'fran 18/12/2009 i chamdo 587 /588
            ''fran 18/10/2009 i chamado 477
            ''If Len(Me.id_romaneio) >= 15 Then
            ''    chaveemitente = Left(Me.id_romaneio.ToString, 15)
            ''Else
            ''    chaveemitente = Left(String.Concat(Me.id_romaneio.ToString, Space(15 - Len(Me.id_romaneio.ToString))), 15)
            ''End If
            ''parceirocomercial - CNPJ do estabelecimento do romaneio - 15 posições
            'parceirocomercial = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            'parceirocomercial = String.Concat(parceirocomercial, Space(15 - Len(parceirocomercial)))
            'fran 18/12/2009 f chamdo 587 /588


            If Me.id_cooperativa > 0 Then
                cdnota = Left(String.Concat(Me.nr_nota_fiscal.ToString, Space(12 - Len(Me.nr_nota_fiscal.ToString))), 12)
                cdserie = Left(String.Concat(Me.nr_serie_nota_fiscal.ToString, Space(3 - Len(Me.nr_serie_nota_fiscal.ToString))), 3)
                'Fran 28/10/2009 i
                'qtpesobruto = Me.nr_peso_liquido_nota.ToString
                qtpesobruto = Round(Me.nr_peso_liquido_nota * pMediaDensidade, 2).ToString
                qtitem = Me.nr_peso_liquido_nota.ToString
                'Fran 28/10/2009 f
                'Fran 18/12/2009 i chamado 587 
                parceirocomercial = FormataCampo(pCNPJCooperativa.Trim.ToString).Trim
                parceirocomercial = String.Concat(parceirocomercial, Space(15 - Len(parceirocomercial)))
                'Fran 18/12/2009 f
            Else
                'fran 18/12/2009 i chamado 588
                parceirocomercial = FormataCampo(pCNPJCPFProdutor.ToString)
                If Len(parceirocomercial.Trim) > 15 Then
                    parceirocomercial = Left(parceirocomercial.Trim, 15)
                Else
                    parceirocomercial = String.Concat(parceirocomercial.Trim, Space(15 - Len(parceirocomercial.Trim)))
                End If
                'fran 18/12/2009 f chamado 588
                'fran 18/10/2009 i chamado 477
                'If Len(Me.id_romaneio) >= 12 Then
                '    cdnota = Left(Me.id_romaneio.ToString, 12)
                'Else
                '    cdnota = Left(String.Concat(Me.id_romaneio.ToString, Space(12 - Len(Me.id_romaneio.ToString))), 12)
                'End If
                'cdserie = Space(3)
                If Len(pId_coleta) > 12 Then
                    cdnota = Left(pId_coleta.ToString, 12)
                Else
                    cdnota = Left(String.Concat(pId_coleta.ToString, Space(12 - Len(pId_coleta.ToString))), 12)
                End If
                cdserie = "DAL"

                'fran 18/10/2009 f chamado 477
                'Fran 28/10/2009 i
                'qtpesobruto = pNrLitrosColeta
                If pNrLitrosColeta.Equals(String.Empty) Then
                    pNrLitrosColeta = "0"
                End If
                qtpesobruto = Round(CDec(pNrLitrosColeta) * pMediaDensidade, 2).ToString
                qtitem = pNrLitrosColeta
                'Fran 28/10/2009 f
            End If
            'Fran 28/10/2009 i
            lpos = InStr(1, qtpesobruto, ",")
            If lpos > 0 Then
                lvalorint = Mid(qtpesobruto, 1, lpos - 1)
                lvalordec = Mid(qtpesobruto, lpos + 1)
            Else
                lvalorint = qtpesobruto
                lvalordec = "00"
            End If
            If Len(lvalorint) > 13 Then
                lvalorint = Left(lvalorint, 13)
            Else
                lvalorint = Right(String.Concat(StrDup(13 - Len(lvalorint), "0"), lvalorint), 13)
            End If
            If Len(lvalordec) > 2 Then
                lvalordec = Left(lvalordec, 2)
            Else
                lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
            End If
            qtpesobruto = String.Concat(lvalorint, lvalordec)
            'Fran 28/10/2009 f

            nrnotaitem = "001" 'Numero seuqencial de itens. NO MIlk sempre temos apena um item por coleta (leite)

            cditem = pCdItem
            cditem = String.Concat(cditem, Space(20 - Len(cditem)))

            qtpesobruto = Right(String.Concat(StrDup(15 - Len(qtpesobruto), "0"), qtpesobruto), 15)

            qtpesocubado = StrDup(15, "0")

            qtpesoliquido = qtpesobruto

            'vlnotaitem = StrDup(12, "0")
            'fran 23/10/2009 i 
            'vlnotaitem = Right(qtpesobruto, 12)
            'qtvolume = StrDup(4, "0")
            ' 10 inteiros, sem virgula  e 2 decimais (12 caracteres)
            If Me.id_cooperativa > 0 Then
                'fran 12/03/2010 i chamado 716
                'lvaloritemnota = Round((Me.nr_valor_nota_fiscal / Me.nr_peso_liquido_nota), 2)
                lvaloritemnota = Round(Me.nr_valor_nota_fiscal, 2)
                'fran 12/03/2010 f chamado 716

                If lvaloritemnota > 0 Then
                    lpos = InStr(1, lvaloritemnota.ToString, ",")
                    If lpos = 0 Then   ' Se não tem casas decimais
                        vlnotaitem = Right(String.Concat(StrDup(10 - Len(lvaloritemnota.ToString.Trim), "0"), lvaloritemnota.ToString.Trim), 10)
                        vlnotaitem = String.Concat(vlnotaitem, "00")
                    Else
                        lvalorint = CStr(Left(lvaloritemnota.ToString, lpos - 1))  ' Pegar somente o valor inteiro
                        lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint.Trim), "0"), lvalorint), 10)
                        lvalordec = CStr(Mid(CStr(lvaloritemnota.ToString), lpos + 1))  ' Pegar somente o valor decimal
                        If Len(lvalordec) >= 2 Then
                            lvalordec = Left(lvalordec, 2)
                        Else
                            lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                        End If

                        vlnotaitem = Right(String.Concat(lvalorint, lvalordec).Trim, 12)
                    End If
                Else
                    vlnotaitem = StrDup(12, "0")
                End If

            Else
                If CInt(ppreconegociado) > 0 Then
                    'fran 12/03/2010 i chamado 716
                    'lpos = InStr(1, ppreconegociado, ",")
                    'If lpos = 0 Then   ' Se não tem casas decimais
                    '    vlnotaitem = Right(String.Concat(StrDup(10 - Len(ppreconegociado.Trim), "0"), ppreconegociado), 10)
                    '    vlnotaitem = String.Concat(vlnotaitem, "00")
                    'Else
                    '    lvalorint = CStr(Left(ppreconegociado, lpos - 1))  ' Pegar somente o valor inteiro
                    '    lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint.Trim), "0"), lvalorint), 10)
                    '    lvalordec = CStr(Mid(CStr(ppreconegociado), lpos + 1))  ' Pegar somente o valor decimal
                    '    If Len(lvalordec) >= 2 Then
                    '        lvalordec = Left(lvalordec, 2)
                    '    Else
                    '        lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                    '    End If

                    '    vlnotaitem = Right(String.Concat(lvalorint, lvalordec).Trim, 12)
                    'End If

                    lvaloritemnota = CDec(qtitem) * CDec(ppreconegociado)
                    lpos = InStr(1, CStr(lvaloritemnota).Trim, ",")
                    If lpos = 0 Then   ' Se não tem casas decimais
                        If Len(lvaloritemnota.ToString.Trim) <= 10 Then
                            vlnotaitem = Right(String.Concat(StrDup(10 - Len(lvaloritemnota.ToString.Trim), "0"), lvaloritemnota.ToString.Trim), 10)
                            vlnotaitem = String.Concat(vlnotaitem, "00")
                        Else
                            vlnotaitem = Left(lvaloritemnota.ToString.Trim, 10)
                            vlnotaitem = String.Concat(vlnotaitem, "00")

                        End If
                    Else
                        lvalorint = CStr(Left(lvaloritemnota.ToString.Trim, lpos - 1))  ' Pegar somente o valor inteiro
                        If Len(lvalorint) <= 10 Then
                            lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint.Trim), "0"), lvalorint), 10)
                        Else
                            lvalorint = Left(lvalorint, 10)
                        End If
                        lvalordec = CStr(Mid(CStr(lvaloritemnota).Trim, lpos + 1))  ' Pegar somente o valor decimal
                        If Len(lvalordec) >= 2 Then
                            lvalordec = Left(lvalordec, 2)
                        Else
                            lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                        End If

                        vlnotaitem = Right(String.Concat(lvalorint, lvalordec).Trim, 12)
                    End If
                    'fran 12/03/2010 f chamado 716

                Else
                    '' Fran 15/02/2011 - Chamado 1166 - Assumir R$ 1,00 para preço que não existir (novos produtores ou estiver zerado na referência, para não gerar erro no GKO) - i
                    'vlnotaitem = StrDup(12, "0")
                    vlnotaitem = String.Concat(StrDup(9, "0"), "100")
                    '' fran 15/02/2011 - Chamado 1166 - Assumir R$ 1,00 para preço que não existir (novos produtores ou estiver zerado na referência, para não gerar erro no GKO) - f
                End If

            End If
            'Fran 14/07/2012 i mudança layout GKO
            'qtvolume = "0001"
            qtvolume = "000000000001"
            'Fran 14/07/2012 f mudança layout GKO
            'fran 23/10/2009 f

            vlcubagem = StrDup(10, "0")
            cdcontacontabil = Space(15)
            cdcentrocusto = Space(10)
            'Fran 30/10/2009 i 
            'qtitem = qtpesobruto
            lpos = InStr(1, qtitem.Trim, ",")
            If lpos > 0 Then
                qtitem = Left(qtitem, lpos - 1)
            End If
            If Len(qtitem.Trim) >= 13 Then
                qtitem = String.Concat(Left(qtitem.Trim, 13), "00")
            Else
                qtitem = String.Concat(Right(String.Concat(StrDup(13 - Len(qtitem.Trim), "0"), qtitem.Trim), 13), "00")
            End If
            'Fran 30/10/2009 f

            'dsuniitem = "LT "
            dsuniitem = "L  "
            vlfretepgclitab = StrDup(15, "0")
            vlfretepgcliente = StrDup(15, "0")

            'NATUREZA de OPERAÇÃO
            'Fran 14/07/2012 f mudança layout GKO
            If Me.id_cooperativa > 0 Then
                cdnaturezaoperacao = pcdnaturezaoperacao
                If Len(cdnaturezaoperacao) > 4 Then
                    cdnaturezaoperacao = Left(cdnaturezaoperacao, 4)
                End If
                cdnaturezaoperacao = Left(String.Concat(cdnaturezaoperacao, Space(4 - Len(cdnaturezaoperacao))), 4)
                'Fran 23/09/2013 i Alteração layout frete - escopo melhorias milk fase 1 assumir 1101 para todas as linhas
                cdnaturezaoperacao = "1101"
                'Fran 23/09/2013 f Alteração layout frete - escopo melhorias milk fase 1

            Else
                cdnaturezaoperacao = Space(4)

                'Fran 23/09/2013 i Alteração layout frete - escopo melhorias milk fase 1
                'Assume para qualquer cidade natureza operação 1101, desabilita rotina de dedução de natureza operação por incentivo e estado
                cdnaturezaoperacao = "1101"
                'Verifica qual o estado da propriedade/produtotr
                'Select Case pDadosPropriedade.Item("cd_uf")
                '    Case "MG"
                '        'Se NAO TEM incentivo 2,5, NAO TEM transf credito,  NAO TEM incentivo 2,1 e NAO TEM incentivo 2,4
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                '            cdnaturezaoperacao = "1101"
                '        End If
                '        'Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") <> "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                '            cdnaturezaoperacao = "1101"
                '        End If
                '        'Se NAO TEM incentivo 2,5, TEM transf credito e NAO TEM incentivo 2,1
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "S" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                '            cdnaturezaoperacao = "1101"
                '        End If
                '        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e TEM incentivo 2,1
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And (pDadosPropriedade.Item("st_incentivo_21") = "S" Or pDadosPropriedade.Item("st_incentivo_24") = "S") Then
                '            cdnaturezaoperacao = "1101"
                '        End If
                '    Case "SP"
                '        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                '            'poços dde caldas
                '            If Me.id_estabelecimento = 1 Then
                '                cdnaturezaoperacao = "2101"
                '            End If
                '            'guara
                '            If Me.id_estabelecimento = 2 Then
                '                cdnaturezaoperacao = "1101"
                '            End If
                '            'águas prata
                '            If Me.id_estabelecimento = 6 Then
                '                cdnaturezaoperacao = "1101"
                '            End If
                '        End If
                '    Case "RJ"
                '        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                '        If pDadosPropriedade.Item("st_incentivo_fiscal") = "N" And pDadosPropriedade.Item("st_transferencia_credito") = "N" And pDadosPropriedade.Item("st_incentivo_21") = "N" And pDadosPropriedade.Item("st_incentivo_24") = "N" Then
                '            'guara
                '            If Me.id_estabelecimento = 2 Then
                '                cdnaturezaoperacao = "2101"
                '            End If
                '        End If
                '    Case Else
                '        cdnaturezaoperacao = Space(4)
                'End Select
                'Fran 23/09/2013 f Alteração layout frete - escopo melhorias milk fase 1

            End If
            'Fran 14/07/2012 f mudança layout GKO

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            'linhatexto = tpregistro + floperacao + chaveemitente + cdnota + cdserie + nrnotaitem
            linhatexto = tpregistro + floperacao + parceirocomercial + cdnota + cdserie + nrnotaitem
            linhatexto = linhatexto + cditem + vlnotaitem + qtpesobruto + qtpesocubado + qtpesoliquido + qtvolume
            linhatexto = linhatexto + vlcubagem + cdcontacontabil + cdcentrocusto + qtitem + dsuniitem + vlfretepgclitab + vlfretepgcliente
            linhatexto = linhatexto + cdnaturezaoperacao 'fran 14/07/2012 i mudança layout gko

            Frete_Registro_160 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try
    End Function
    Public Function exportFrete() As Boolean

        Dim ArquivoTexto As StreamWriter

        Try

            Dim nomearquivo As String
            Dim filtro_estabel As Int32
            Dim filtro_id_romaneio As Int32
            Dim filtro_dt_ini As String
            Dim filtro_dt_fim As String
            Dim filtro_path_arquivofrete As String
            Dim id_frete_execucao As Int32
            Dim lrow As DataRow
            Dim lrowcoleta As DataRow
            Dim ltransportadora_ant As Int32
            Dim linhaarquivo As String
            Dim cnpjtransportadora As String
            Dim cnpjprodutor As String
            Dim cdnaturezaoperacao As String
            Dim propriedade As New Propriedade
            Dim Calculo As New CalculoProdutor
            Dim dspropriedade As DataSet
            Dim pessoa As New Pessoa
            Dim Item As New Item
            Dim veiculo As New Veiculo
            Dim freteexecucao As New ExportacaoFreteExecucao
            Dim parametro As New Parametro
            Dim lmediaDensidade As Decimal
            Dim notafiscal As New NotaFiscal
            Dim estabelfrete As New Estabelecimento 'fran 18/02/2012
            Dim dsestabelfrete As DataSet
            Dim SequenceFreteColeta As New SequenceFreteColeta 'fran 26/06/2015
            Dim lsequencefretecoleta As Integer = 0 'fran 26/06/2015
            Dim lbtransit_point As Boolean = False 'fran 03/2017 frete transit point
            Dim lbtransbordo As Boolean = False 'fran 03/2017 frete transbordo


            filtro_estabel = Me.id_estabelecimento
            filtro_id_romaneio = Me.id_romaneio
            'fran 03/2017 i
            'filtro_dt_ini = Me.dt_hora_entrada_ini
            'filtro_dt_fim = Me.dt_hora_entrada_fim
            filtro_dt_ini = Me.dt_hora_saida_ini
            filtro_dt_fim = Me.dt_hora_saida_fim
            'fran 03/2017 f

            filtro_path_arquivofrete = Me.path_arquivofrete
            id_frete_execucao = Me.id_exportacao_frete_execucao

            freteexecucao.id_exportacao_frete_execucao = id_frete_execucao
            Dim dsfreteexecucao As DataSet = freteexecucao.getExportacaoFreteExecucaoItensByFilters

            Dim estabelromaneio As New Estabelecimento(Me.id_estabelecimento)
            Dim dsestabel As DataSet = estabelromaneio.getEstabelecimentoByFilters
            Dim dsDadosCooperativa As DataSet
            Dim dsDadosColetas As DataSet
            Dim dsprodutor As DataSet
            Dim dsitem As DataSet
            Dim dsveiculo As DataSet
            Dim lpreconegociado As Decimal
            Dim lbregistro060executado As Boolean = False
            Dim lbColetaSemLitros As Boolean = False 'fran 20/12/2009
            Dim dsnota As DataSet


            nomearquivo = String.Empty

            'Para cada linha do sql que traz os romaneios agrupados por transportadora e placa
            For Each lrow In dsfreteexecucao.Tables(0).Rows

                'reinicializa romaneio
                Me.id_romaneio = lrow.Item("id_romaneio")
                Me.Finalize()
                Me.reloadRomaneio()
                lmediaDensidade = Me.getRomaneioCompartimentoMediaDens 'fran 28/10/2009
                Me.id_exportacao_frete_execucao_itens = lrow.Item("id_exportacao_frete_execucao_itens")
                Me.id_exportacao_frete_execucao = id_frete_execucao
                'fran 03/2017 i inicializa variaveis frete 
                If lrow.Item("st_transit_point").ToString.Trim.Equals("S") Then
                    lbtransit_point = True
                Else
                    lbtransit_point = False
                End If
                If lrow.Item("st_transbordo").ToString.Trim.Equals("S") Then
                    lbtransbordo = True
                Else
                    lbtransbordo = False
                End If
                'fran 03/2017 f inicializa variaveis frete 

                'fran 26/11/2009 i - chamado 550 - desabilitado pois deve fazer mais validações
                'Fran 19/11/2009 i 
                'If lrow.Item("ds_placa_frete").ToString.Equals(String.Empty) Then
                '    Dim execucaoerro As New ExportacaoFreteExecucao
                '    execucaoerro.st_exportacao_frete_execucao = "E"
                '    execucaoerro.id_exportacao_frete_execucao = Me.id_exportacao_frete_execucao
                '    execucaoerro.id_exportacao_frete_execucao_itens = Me.id_exportacao_frete_execucao_itens
                '    execucaoerro.nm_erro = "Não há dados de frete para este romaneio."
                '    execucaoerro.insertExportacaoFreteExecucaoErro()

                '    freteexecucao.id_exportacao_frete_execucao_itens = execucaoerro.id_exportacao_frete_execucao_itens
                '    freteexecucao.st_exportacao_frete_execucao_itens = "E"
                '    freteexecucao.updateExportacaoFreteExecucaoItens() 'atualiza status

                'Else
                'Fran 19/11/2009 f
                cdnaturezaoperacao = String.Empty
                'fran 18/02/2012 i
                ' If Validar(lrow.Item("ds_placa_frete").ToString, cdnaturezaoperacao) = True Then
                If Validar(lrow.Item("ds_placa_frete").ToString, cdnaturezaoperacao, lrow.Item("id_estabelecimento_frete")) = True Then
                    'fran 18/02/2012 f
                    If ltransportadora_ant <> lrow.Item("id_transportadora") Then
                        'Se ainda tem nome de arquivo fecha arquivo anterior
                        If Not nomearquivo.ToString.Trim.Equals(String.Empty) Then
                            'fecha arquivo anterior
                            ArquivoTexto.Close()
                            ArquivoTexto.Dispose()
                        End If
                        'abre novo arquivo
                        nomearquivo = "\cltes-milk_" + estabelromaneio.cd_estabelecimento.Trim + "_" + DateTime.Parse(Me.dt_hora_entrada).ToString("ddMMyyyy") + "_" + DateTime.Parse(Me.dt_modificacao).ToString("ddMMyyyy") + "_" + DateTime.Parse(Now()).ToString("ddMMyyyyHHmmss") + ".txt"
                        nomearquivo = Replace(nomearquivo, ":", "")
                        nomearquivo = Replace(nomearquivo, " ", "")
                        nomearquivo = Replace(nomearquivo, "/", "")
                        nomearquivo = filtro_path_arquivofrete & nomearquivo
                        ArquivoTexto = New StreamWriter(nomearquivo)

                        ltransportadora_ant = lrow.Item("id_transportadora")

                        pessoa.id_pessoa = Convert.ToInt32(lrow.Item("id_transportadora"))
                        cnpjtransportadora = FormataCampo(pessoa.getCNPJPessoa)

                        'Gera registro 000
                        linhaarquivo = Me.Frete_Registro_000
                        ArquivoTexto.WriteLine(linhaarquivo)

                    End If

                    'Grava execucao itens
                    freteexecucao.id_exportacao_frete_execucao_itens = lrow.Item("id_exportacao_frete_execucao_itens")
                    freteexecucao.nm_arquivo = nomearquivo
                    freteexecucao.st_exportacao_frete_execucao_itens = "I" 'inicializada
                    freteexecucao.updateExportacaoFreteExecucaoItens() 'atualiza status

                    'busca dadps do item do romaneio
                    Item.id_item = Me.id_item
                    dsitem = Item.getItensByFilters

                    'busca dados do veiculo
                    Me.ds_placa_frete = lrow.Item("ds_placa_frete").ToString.Trim
                    'fran 03/2017 traz dados de veiculo no sql na execucao itens i
                    'veiculo.ds_placa = Me.ds_placa_frete
                    'dsveiculo = veiculo.getVeiculoByFilters
                    'fran 03/2017 traz dados de veiculo no sql na execucao itens f

                    'Fran 26/10/2009 i - desabilitado pois rotina será chamada para cooperativa ou para produtor pois tem valores especificos
                    'Gera registro 060 
                    ''linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, lrow.Item("cd_tipo_equipamento").ToString)
                    'linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim)
                    'ArquivoTexto.WriteLine(linhaarquivo)
                    lbregistro060executado = False
                    'Fran 26/10/2009 f - desabilitado pois rotina será chamada para cooperativa ou para produtor pois tem valores especificos

                    If Me.id_cooperativa > 0 Then

                        pessoa.id_pessoa = Me.id_cooperativa
                        dsDadosCooperativa = pessoa.getPessoaByFilters
                        'fran 19/11/2009 i
                        Dim lvalortotalkm As String
                        If IsDBNull(dsDadosCooperativa.Tables(0).Rows(0).Item("nr_distancia")) Then
                            'lvalortotalkm = "00000"
                            lvalortotalkm = "00000000" 'fran themis casa com 8 posioções 17/09/2012
                        Else
                            'lvalortotalkm = CLng(dsDadosCooperativa.Tables(0).Rows(0).Item("nr_distancia")).ToString
                            lvalortotalkm = CDec(dsDadosCooperativa.Tables(0).Rows(0).Item("nr_distancia"))
                        End If
                        'fran 19/11/2009 f


                        'Fran 26/10/2009 i - 
                        'Gera registro 060 
                        'fran 03/2017 i linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, , , lvalortotalkm)
                        linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, lrow.Item("nm_tipo_equipamento_frete").ToString.Trim, , , lvalortotalkm)
                        ArquivoTexto.WriteLine(linhaarquivo)
                        'Fran 26/10/2009 f 

                        'Gera registro 100
                        'linhaarquivo = Me.Frete_Registro_100(dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0))
                        linhaarquivo = Me.Frete_Registro_100(dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0), , )
                        ArquivoTexto.WriteLine(linhaarquivo)

                        'Gera registro 140
                        'fran 26/11/2009 i chamado 550 
                        'Fran 19/10/2009 i
                        'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora,  lrow.Item("cd_tipo_equipamento"), , , dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0))
                        'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento"), , , dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0))
                        'Fran 19/10/2009 f
                        'fran 03/2017 i linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento"), , , dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0), , , cdnaturezaoperacao)
                        linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, lrow.Item("nm_tipo_equipamento_frete").ToString.Trim, , , dsestabel.Tables(0).Rows(0), dsDadosCooperativa.Tables(0).Rows(0), , , cdnaturezaoperacao)
                        'fran 26/11/2009 f
                        ArquivoTexto.WriteLine(linhaarquivo)

                        'Gera registro 142
                        'Fran 18/12/2009 i chamado 587 - deve passar valor total km 
                        'linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsDadosCooperativa.Tables(0).Rows(0).Item("cd_cnpj").ToString, dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque"))
                        'fran 07/01/2011 i gko rls 27
                        'linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsDadosCooperativa.Tables(0).Rows(0).Item("cd_cnpj").ToString, dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque"), , , lvalortotalkm)
                        'fran 03/2017  linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsDadosCooperativa.Tables(0).Rows(0).Item("cd_cnpj").ToString, dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque"), , , lvalortotalkm, , cdnaturezaoperacao)
                        linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsDadosCooperativa.Tables(0).Rows(0).Item("cd_cnpj").ToString, lrow.Item("ds_proprietario_tanque_frete").ToString.Trim, , , lvalortotalkm, , cdnaturezaoperacao)
                        'fran 07/01/2011 f gko rls 27
                        'Fran 18/12/2009 f chamado 587
                        ArquivoTexto.WriteLine(linhaarquivo)

                        'Gera registro 120
                        linhaarquivo = Me.Frete_Registro_120(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, dsitem.Tables(0).Rows(0).Item("nm_item").ToString.Trim, Me.nr_peso_liquido_nota.ToString.Trim, lmediaDensidade)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        'Gera registro 160
                        'fran 18/12/2009 i chamado 587
                        'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, Me.nr_peso_liquido_nota.ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade)
                        linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, Me.nr_peso_liquido_nota.ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, , , dsDadosCooperativa.Tables(0).Rows(0).Item("cd_cnpj").ToString)
                        'fran 18/12/2009 f chamado 587
                        ArquivoTexto.WriteLine(linhaarquivo)

                    Else
                        lbColetaSemLitros = False

                        'Busca as coletas para a caderneta e a placa_frete
                        Me.ds_placa_frete = lrow.Item("ds_placa_frete").ToString.Trim
                        'fran 18/02/2012 i
                        Me.id_estabelecimento_frete = lrow.Item("id_estabelecimento_frete")
                        estabelfrete.id_estabelecimento = Me.id_estabelecimento_frete
                        dsestabelfrete = estabelfrete.getEstabelecimentoByFilters
                        'fran 18/02/2012 f

                        dsDadosColetas = Me.getFreteColetas

                        'fran 03/2017 - se nao for romaneio de transbordo nem de transit point, deixa verificar coleta sem litros
                        If lbtransit_point = False AndAlso lbtransbordo = False Then
                            'fran 18/12/2009 i chamdo 588 - se alguma coleta estiver sem litros
                            If Me.getFreteColetasSemLitros.Tables(0).Rows.Count > 0 Then
                                lbColetaSemLitros = True
                            End If
                            'fran 18/12/2009 f chamdo 588 - se alguma coleta estiver sem litros
                        End If

                        For Each lrowcoleta In dsDadosColetas.Tables(0).Rows
                            propriedade.id_propriedade = lrowcoleta.Item("id_propriedade")
                            dspropriedade = propriedade.getPropriedadeByFilters()
                            pessoa.id_pessoa = Convert.ToInt32(dspropriedade.Tables(0).Rows(0).Item("id_pessoa").ToString.Trim)
                            dsprodutor = pessoa.getPessoaByFilters

                            'fran 18/12/2009 i chamdo 588 - se a coleta estiver zerada não gera linha no arquivo
                            If CLng(lrowcoleta.Item("nr_litros")) > 0 Then
                                'Fran 26/10/2009 i - se for 1a vez...
                                If lbregistro060executado = False Then
                                    'Gera registro 060 
                                    'fran 04/12/2009 i chamado 469
                                    'linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, dsprodutor.Tables(0).Rows(0).Item("nm_cidade"), dsprodutor.Tables(0).Rows(0).Item("cd_uf"))
                                    'fran 12/03/2010 i chamado 716 - cidade e estado maior distancia devem ser da propriedade
                                    'linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, dsprodutor.Tables(0).Rows(0).Item("nm_cidade"), dsprodutor.Tables(0).Rows(0).Item("cd_uf"), , lmediaDensidade)
                                    'fran 18/02/2012 i 
                                    'Pega os dados do estabelecimento do frete
                                    'linhaarquivo = Me.Frete_Registro_060(FormataCampo(estabelromaneio.cd_cnpj), estabelromaneio.cd_estabelecimento, estabelromaneio.nm_cidade, estabelromaneio.cd_uf, cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_cidade"), dspropriedade.Tables(0).Rows(0).Item("cd_uf"), , lmediaDensidade)
                                    'fran 03/2017 i linhaarquivo = Me.Frete_Registro_060(FormataCampo(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj")), dsestabelfrete.Tables(0).Rows(0).Item("cd_estabelecimento"), dsestabelfrete.Tables(0).Rows(0).Item("nm_cidade"), dsestabelfrete.Tables(0).Rows(0).Item("cd_uf"), cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_cidade"), dspropriedade.Tables(0).Rows(0).Item("cd_uf"), , lmediaDensidade)
                                    linhaarquivo = Me.Frete_Registro_060(FormataCampo(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj")), dsestabelfrete.Tables(0).Rows(0).Item("cd_estabelecimento"), dsestabelfrete.Tables(0).Rows(0).Item("nm_cidade"), dsestabelfrete.Tables(0).Rows(0).Item("cd_uf"), cnpjtransportadora.ToString, lrow.Item("ds_placa_frete").ToString.Trim, lrow.Item("nm_tipo_equipamento_frete").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_cidade"), dspropriedade.Tables(0).Rows(0).Item("cd_uf"), , lmediaDensidade, lbtransit_point, lbtransbordo) 'fran 03/2017
                                    'fran 18/02/2012 f
                                    'fran 12/03/2010 f
                                    'fran 04/12/2009 f chamado 469
                                    ArquivoTexto.WriteLine(linhaarquivo)
                                    lbregistro060executado = True
                                End If
                                'Fran 26/10/2009 f 
                                Calculo.dt_referencia = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(String.Concat("01/", DateTime.Parse(Me.dt_hora_entrada).ToString("MM/yyyy"))))
                                Calculo.id_propriedade = propriedade.id_propriedade
                                'fran 12/2017 i 
                                'lpreconegociado = Calculo.getCalculoPrecoNegociado().ToString
                                lpreconegociado = Calculo.getFichaFinanceiraPrecoNegociado()  '  Preço do mes anterior
                                'fran 12/2017 f 

                                lpreconegociado = lpreconegociado - parametro.nr_deflator
                                '' Adriana 15/02/2011 - Chamado 1166 - Assumir R$ 1,00 para preço que não existir (novos produtores ou estiver zerado na referência, para não gerar erro no GKO) - i
                                'If lpreconegociado <= 0 Then  ' Se preço menor ou igual a zero, assume 1 (um)
                                '    lpreconegociado = 1
                                'End If
                                '' Adriana 15/02/2011 - Chamado 1166 - Assumir R$ 1,00 para preço que não existir (novos produtores ou estiver zerado na referência, para não gerar erro no GKO) - f

                                'Pega sequence para substituir id_coleta 26/06/2015
                                lsequencefretecoleta = SequenceFreteColeta.getSequenceFreteColeta

                                'Gera registro 100
                                'linhaarquivo = Me.Frete_Registro_100(dsestabel.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0))
                                linhaarquivo = Me.Frete_Registro_100(dsestabel.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0))
                                ArquivoTexto.WriteLine(linhaarquivo)

                                'Gera registro 140
                                'fran 04/12/2009 i chamado 469
                                'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, lrowcoleta.Item("id_coleta").ToString.Trim, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabel.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0))
                                'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete
                                'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, lrowcoleta.Item("id_coleta").ToString.Trim, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabel.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0), , lrowcoleta.Item("nr_unid_producao").ToString)
                                'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, lrowcoleta.Item("id_coleta").ToString.Trim, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabelfrete.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0), , lrowcoleta.Item("nr_unid_producao").ToString) '26/06/2015
                                'fran 03/2017 ilinhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, dsveiculo.Tables(0).Rows(0).Item("nm_tipo_equipamento").ToString.Trim, lsequencefretecoleta.ToString, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabelfrete.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0), , lrowcoleta.Item("nr_unid_producao").ToString)
                                'linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, lrow.Item("nm_tipo_equipamento_frete").ToString.Trim, lsequencefretecoleta.ToString, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabelfrete.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0), , lrowcoleta.Item("nr_unid_producao").ToString) 'fran 03/2017 'fran 08/2020
                                linhaarquivo = Me.Frete_Registro_140(cnpjtransportadora, lrow.Item("nm_tipo_equipamento_frete").ToString.Trim, lsequencefretecoleta.ToString, lrowcoleta.Item("st_coleta_nao_programada").ToString.Trim, dsestabelfrete.Tables(0).Rows(0), , dsprodutor.Tables(0).Rows(0), dspropriedade.Tables(0).Rows(0), , lrowcoleta.Item("nr_unid_producao").ToString, lbtransit_point, lbtransbordo) 'fran 03/2017 'fran082020
                                'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete
                                'fran 04/12/2009 f chamado 469
                                ArquivoTexto.WriteLine(linhaarquivo)

                                'Gera registro 142
                                If dsprodutor.Tables(0).Rows(0).Item("cd_cpf").Equals(String.Empty) Then
                                    'Fran 18/09/2009 i 588
                                    'linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros)
                                    'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete
                                    ' linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros)
                                    'linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros) 26/06/2015
                                    'fran 03/2017 linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lsequencefretecoleta.ToString.Trim, , lbColetaSemLitros)
                                    linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), lrow.Item("ds_proprietario_tanque_frete").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lsequencefretecoleta.ToString.Trim, , lbColetaSemLitros, , lbtransit_point, lbtransbordo)
                                    'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete

                                    'Fran 18/09/2009 f 588
                                Else
                                    'Fran 18/09/2009 i 588
                                    'linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros)
                                    'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete
                                    'linhaarquivo = Me.Frete_Registro_142(estabelromaneio.cd_cnpj, dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros)
                                    'linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lrowcoleta.Item("id_coleta").ToString.Trim, , lbColetaSemLitros) 26/06/2015
                                    'fran 03/2017 i linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), dsveiculo.Tables(0).Rows(0).Item("ds_proprietario_tanque").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lsequencefretecoleta.ToString.Trim, , lbColetaSemLitros)
                                    linhaarquivo = Me.Frete_Registro_142(dsestabelfrete.Tables(0).Rows(0).Item("cd_cnpj"), dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), lrow.Item("ds_proprietario_tanque_frete").ToString.Trim, dspropriedade.Tables(0).Rows(0).Item("nm_abreviado_tecnico"), lsequencefretecoleta.ToString.Trim, , lbColetaSemLitros, , lbtransit_point, lbtransbordo) 'fran 03/2017
                                    'fran 17/09/2012 conforme email do joel (14/9) cnpj deve ser do frete
                                    'Fran 18/09/2009 f 588
                                End If
                                ArquivoTexto.WriteLine(linhaarquivo)

                                'fran 03/2017 i 
                                If lbtransit_point = True OrElse lbtransbordo = True Then
                                    'Gera registro 120
                                    linhaarquivo = Me.Frete_Registro_120(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, dsitem.Tables(0).Rows(0).Item("nm_item").ToString.Trim, "0,01", lmediaDensidade)
                                Else
                                    'fran 03/2017 f
                                    'Gera registro 120
                                    linhaarquivo = Me.Frete_Registro_120(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, dsitem.Tables(0).Rows(0).Item("nm_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, lmediaDensidade)
                                End If
                                ArquivoTexto.WriteLine(linhaarquivo)

                                'Gera registro 160
                                'Fran 18/09/2009 i 588
                                'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lrowcoleta.Item("id_coleta").ToString.Trim, lpreconegociado.ToString )
                                If dsprodutor.Tables(0).Rows(0).Item("cd_cpf").Equals(String.Empty) Then
                                    'fran 08/08/2012 i gko 
                                    'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lrowcoleta.Item("id_coleta").ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"))
                                    'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lrowcoleta.Item("id_coleta").ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), , dspropriedade.Tables(0).Rows(0)) 26/06/2015
                                    'fran 03/2017 i
                                    If lbtransit_point = True OrElse lbtransbordo = True Then
                                        'se transit point ou transbordo envia numero simbolico 
                                        linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, "0,01", estabelromaneio.cd_cnpj, lmediaDensidade, lsequencefretecoleta.ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), , dspropriedade.Tables(0).Rows(0))
                                    Else
                                        'fran 03/2017 f
                                        linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lsequencefretecoleta.ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cnpj"), , dspropriedade.Tables(0).Rows(0))
                                    End If
                                    'fran 08/08/2012 f gko 
                                Else
                                    'fran 08/08/2012 i gko 
                                    'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lrowcoleta.Item("id_coleta").ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cpf"))
                                    'linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lrowcoleta.Item("id_coleta").ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), , dspropriedade.Tables(0).Rows(0)) 26/06/2015
                                    'fran 03/2017 i
                                    If lbtransit_point = True OrElse lbtransbordo = True Then
                                        'se transit point ou transbordo envia numero simbolico 
                                        linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, "0,01", estabelromaneio.cd_cnpj, lmediaDensidade, lsequencefretecoleta.ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), , dspropriedade.Tables(0).Rows(0))
                                    Else
                                        'fran 03/2017 f
                                        linhaarquivo = Me.Frete_Registro_160(dsitem.Tables(0).Rows(0).Item("cd_item").ToString.Trim, lrowcoleta.Item("nr_litros").ToString.Trim, estabelromaneio.cd_cnpj, lmediaDensidade, lsequencefretecoleta.ToString.Trim, lpreconegociado.ToString, , dsprodutor.Tables(0).Rows(0).Item("cd_cpf"), , dspropriedade.Tables(0).Rows(0))
                                        'fran 08/08/2012 f gko 
                                    End If

                                End If
                                'Fran 18/09/2009 f 588

                                ArquivoTexto.WriteLine(linhaarquivo)
                                'fran 03/2017 i
                                'se transbordo ou transit point
                                If lbtransbordo = True OrElse lbtransit_point = True Then
                                    'pega so a primeira coleta para gerar nota para GKO
                                    Exit For
                                End If
                                'fran 03/2017 f

                            End If
                        Next
                    End If

                    'finaliza na item execucao e no romaneio se nao houver mais de um registro romaneio (transportadoreas diferentes)
                    freteexecucao.st_exportacao_frete_execucao_itens = "F"
                    freteexecucao.updateExportacaoFreteExecucaoItens() 'atualiza status
                    If lrow.Item("nr_qtde_romaneio_execucao") = 1 Then
                        Me.st_exportacao_frete = "S" 'atualiza status exportacao frete do romaneio 
                        Me.updateRomaneioStatusFreteExportacao()
                    End If
                End If 'fran 18/11/2009
            Next

            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If

            'Finaliza execução (romaneios e execucao)
            freteexecucao.id_exportacao_frete_execucao = id_frete_execucao
            freteexecucao.updateFreteExportacaoStatusFinalizacao()

            exportFrete = True

        Catch ex As Exception
            exportFrete = False   ' 01/12/2008
            Dim execucaoerro As New ExportacaoFreteExecucao
            execucaoerro.st_exportacao_frete_execucao = "E"
            execucaoerro.id_exportacao_frete_execucao = Me.id_exportacao_frete_execucao
            execucaoerro.id_exportacao_frete_execucao_itens = Me.id_exportacao_frete_execucao_itens
            execucaoerro.nm_erro = ex.Message
            execucaoerro.insertExportacaoFreteExecucaoErro()
            execucaoerro.updateExportacaoFreteExecucao()
            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If

            Throw New Exception(ex.Message)

        End Try

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
    Public Sub updateRomaneioStatusFreteExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioFreteExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
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
    'fran 26/11/2009 i rls21 - GKO - chamado 550
    Private Function Validar(ByVal pplacafrete As String, ByRef pcodnaturezaoperacao As String, ByVal pestabelecimentofrete As Int32) As Boolean


        Try
            Dim notafiscal As New NotaFiscal
            Dim dsnota As DataSet
            Dim execucaoerro As New ExportacaoFreteExecucao

            Validar = True

            execucaoerro.st_exportacao_frete_execucao = "E"
            execucaoerro.id_exportacao_frete_execucao = Me.id_exportacao_frete_execucao
            execucaoerro.id_exportacao_frete_execucao_itens = Me.id_exportacao_frete_execucao_itens
            execucaoerro.st_exportacao_frete_execucao_itens = "E"

            If pplacafrete.ToString.Trim.Equals(String.Empty) Then
                execucaoerro.nm_erro = "Não há placa de frete informada para este romaneio."
                execucaoerro.insertExportacaoFreteExecucaoErro()
                execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                Validar = False
            Else
                'fran 01/04/2012 i
                'se tem a place de frete, verifica se existe no cadastro
                Dim veiculo As New Veiculo
                veiculo.ds_placa = pplacafrete.ToString
                Dim dsveiculo As DataSet = veiculo.getVeiculoByFilters()
                If Not dsveiculo.Tables(0).Rows.Count > 0 Then
                    execucaoerro.nm_erro = String.Concat("Não existe o cadastro em Veículos para a placa de frete ", pplacafrete.ToString, ".")
                    execucaoerro.insertExportacaoFreteExecucaoErro()
                    execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                    Validar = False
                Else
                    'fran 03/2017 i
                    'se a placa do romaneio é diferente da placa de frete, verifica se sao da mesma transportadora
                    If Me.ds_placa.ToString <> pplacafrete.ToString Then
                        Dim veiculoprincipal As New Veiculo
                        veiculoprincipal.ds_placa = Me.ds_placa
                        Dim dsveiculoprincipal As DataSet = veiculoprincipal.getVeiculoByFilters
                        If Not dsveiculoprincipal.Tables(0).Rows.Count > 0 Then
                            execucaoerro.nm_erro = String.Concat("Não existe o cadastro em Veículos para a placa do romaneio ", Me.ds_placa.ToString, ".")
                            execucaoerro.insertExportacaoFreteExecucaoErro()
                            execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                            Validar = False
                        Else
                            'se a transportadora da placa do romaneio for diferente da transportadora da placa de frete, sinaliza problema
                            If Not (dsveiculo.Tables(0).Rows(0).Item("id_pessoa").ToString = dsveiculoprincipal.Tables(0).Rows(0).Item("id_pessoa").ToString) Then
                                execucaoerro.nm_erro = String.Concat("A transportadora cadastrada para a placa do romaneio ", Me.ds_placa.ToString, " é diferente da transportadora cadastrada para a placa de frete ", pplacafrete.ToString, ".")
                                execucaoerro.insertExportacaoFreteExecucaoErro()
                                execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                                Validar = False

                            End If
                        End If
                    End If
                    'fran 03/2017 f

                End If
                'fran 01/04/2012 f
            End If

            If Me.id_cooperativa > 0 Then
                notafiscal.id_estabelecimento = Me.id_estabelecimento
                notafiscal.nr_nota_fiscal = Me.nr_nota_fiscal
                dsnota = notafiscal.getNotasFiscaisByFilters
                If dsnota.Tables(0).Rows.Count = 0 Then
                    execucaoerro.nm_erro = "Não há dados cadastrados em Nota Fiscal de Entrada para cooperativa deste romaneio."
                    execucaoerro.insertExportacaoFreteExecucaoErro()
                    execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                    Validar = False
                Else
                    pcodnaturezaoperacao = dsnota.Tables(0).Rows(0).Item("cd_natureza_operacao").ToString
                End If
                'fran 18/02/2012 i
            Else
                If Not pestabelecimentofrete > 0 Then
                    execucaoerro.nm_erro = "Não há estabelecimento de frete cadastrado para alguma propriedade deste romaneio."
                    execucaoerro.insertExportacaoFreteExecucaoErro()
                    execucaoerro.updateExportacaoFreteExecucaoItens() 'atualiza status
                    Validar = False

                End If

            End If

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    'Private Function ValidarBatch(ByVal pcd_estabelecimento_sap As String, ByVal pcd_transportador_sap As String, ByVal pcd_item_sap As String, ByVal pnr_po As String) As Boolean


    '    Try
    '        Dim execucaoerro As New ExportacaoBatch

    '        ValidarBatch = True

    '        execucaoerro.st_exportacao_batch_execucao = "E"
    '        execucaoerro.id_exportacao_batch_execucao = Me.id_exportacao_batch_execucao
    '        execucaoerro.id_exportacao_batch_itens = Me.id_exportacao_batch_itens
    '        execucaoerro.st_exportacao_batch_itens = "E"

    '        If pcd_estabelecimento_sap.ToString.Trim.Equals(String.Empty) Then
    '            execucaoerro.nm_erro = "Não há código de estabelecimento SAP cadastrado para este romaneio."
    '            execucaoerro.insertExportacaoBatchErro()
    '            execucaoerro.updateExportacaoBatchItens() 'atualiza status
    '            ValidarBatch = False
    '        End If

    '        If pcd_transportador_sap.ToString.Trim.Equals(String.Empty) Then
    '            execucaoerro.nm_erro = "Não há código de Transportador SAP cadastrado para este romaneio."
    '            execucaoerro.insertExportacaoBatchErro()
    '            execucaoerro.updateExportacaoBatchItens() 'atualiza status
    '            ValidarBatch = False
    '        End If

    '        If pcd_item_sap.ToString.Trim.Equals(String.Empty) Then
    '            execucaoerro.nm_erro = "Não há código de item SAP cadastrado para este romaneio."
    '            execucaoerro.insertExportacaoBatchErro()
    '            execucaoerro.updateExportacaoBatchItens() 'atualiza status
    '            ValidarBatch = False
    '        End If

    '        If pnr_po.ToString.Trim.Equals(String.Empty) Then
    '            execucaoerro.nm_erro = "Não há número de PO cadastrado para este produtor/cooperativa."
    '            execucaoerro.insertExportacaoBatchErro()
    '            execucaoerro.updateExportacaoBatchItens() 'atualiza status
    '            ValidarBatch = False
    '        End If

    '    Catch ex As Exception
    '        ' ArquivoTexto.Close()
    '        Throw New Exception(ex.Message)

    '    End Try

    'End Function

    'fran maracanau  rekatorio ciqciqp
    Public Function getRelacaoCIQEmitidos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelacaoCIQEmitidos", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    'fran maracanau  relatorio ciqciqp
    Public Function getRelacaoCIQPEmitidos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelacaoCIQPEmitidos", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    'fran 22/01/2011 gko fase 2 i
    Public Function getRomaneioProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioProdutor", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCooperativa", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioCooperativaNotas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCooperativaNotas", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    'fran 22/01/2011 gko fase 2 f
    Public Sub updateRomaneioNota() 'fran chamado 1272

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioNota", parameters, ExecuteType.Update)

        End Using

    End Sub

    'fran 20/02/2012 - relatorio termo ocorrencia
    Public Function getRelatorioTermoOcorrencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioTermoOcorrencia", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function


    Public Sub updateRomaneioRegistroExportacaoBatch() 'fran THEMIS - Batch Declaration

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioRegistroExportacaoBatch", parameters, ExecuteType.Update)

        End Using

    End Sub
    'Public Sub updateRomaneioBatchExportacao() 'fran THEMIS - Batch Declaration

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        data.Execute("ms_updateRomaneioBatchExportacao", parameters, ExecuteType.Update)

    '    End Using

    'End Sub
    'Public Function exportBatchDeclaration() As Boolean

    '    Dim ArquivoTexto As StreamWriter

    '    Try

    '        Dim nomearquivo As String
    '        Dim filtro_estabel As Int32
    '        Dim filtro_id_romaneio As Int32
    '        Dim filtro_dt_ini As String
    '        Dim filtro_dt_fim As String
    '        Dim filtro_path_arquivobatch As String
    '        Dim id_batch_execucao As Int32
    '        Dim lrow As DataRow
    '        Dim batchexecucao As New ExportacaoBatch
    '        Dim parametro As New Parametro
    '        Dim lmediaDensidade As Decimal
    '        Dim lbAbrirArquivo As Boolean = False
    '        Dim linhatexto As String

    '        ' Arquivo Batch
    '        Dim reg_documentdate As String      '8 posições Dt_abertura_romaneio
    '        Dim reg_postingdate As String       '8 posições Dt inicio descarga
    '        Dim reg_referencedocument As String 'alfnum 16 posições Cooperativa: NrNotaFiscal Produtor:NrRomaneio
    '        Dim reg_headertext As String        'alfnum 25 posições Nr Romaneio (zeroa a esquerda)
    '        Dim reg_transactioncode As String   'alfnum 20 posições FIXO :'MB01'
    '        Dim reg_materialnb As String        '18 posições Código do Item do SAP
    '        Dim reg_plant As String             '4 posições Cod estabelecimento SAP
    '        Dim reg_storagelocation As String   'alfnum 4 posições FIXO: '0200'
    '        Dim reg_batchnumber As String        'alfnum 10 posições Nr Romaneio (zeroa a esquerda)
    '        Dim reg_movtype As String           'alfnum 3 posições FIXO :'101'
    '        Dim reg_quantityinstock As String   '15 posições (zeros a esquerda) Produtores: Somatória do Campo Volume Descarregado Real por romaneio COOPERATIVA:Volume da Nota Fiscal
    '        Dim reg_unitofentry As String       '3 posições FIXO: 'L'
    '        Dim reg_quantityweighed As String   '15 posições (zeros a esquerda) Diferença Da Pesagem da Balança
    '        Dim reg_unitofentryweighed As String 'alfnum 3 posições FIXO: 'KG'
    '        Dim reg_purchdocnumber As String        'alfnum 10 posições Nr Romaneio (zeroa a esquerda)
    '        Dim reg_itemofpo As String          'alfnum 5 posições FIXO :'00010'
    '        Dim reg_dateofmanufacture As String  '8 posições Data Inicio Descarga
    '        Dim reg_fatcontent As String        '30 posições (zeros a esquerda) Media da analise Materia Gorda do caminhão
    '        Dim reg_proteincontent As String   '30 posições (zeros a esquerda) Media da analise proteina do caminhão
    '        Dim reg_supplymodeofthebatch As String   'alfnum 30  posições FIXO: 'C' para produtor 'P' cooperativa
    '        Dim reg_idtransport As String        'alfnum 30 posições (zeros a esquerda) código do transportador no SAP

    '        filtro_estabel = Me.id_estabelecimento
    '        filtro_id_romaneio = Me.id_romaneio
    '        filtro_dt_ini = Me.dt_hora_entrada_ini
    '        filtro_dt_fim = Me.dt_hora_entrada_fim
    '        filtro_path_arquivobatch = Me.path_arquivobatch
    '        id_batch_execucao = Me.id_exportacao_batch_execucao

    '        batchexecucao.id_exportacao_batch_execucao = id_batch_execucao
    '        Dim dsbatchexecucao As DataSet = batchexecucao.getExportacaoBatchItensByFilters

    '        nomearquivo = String.Empty
    '        Dim dspo As DataSet
    '        lbAbrirArquivo = True
    '        'Para cada linha do sql que traz os romaneios fechados (4), com registro de exportacao batch liberado (2)
    '        For Each lrow In dsbatchexecucao.Tables(0).Rows

    '            'reinicializa romaneio
    '            Me.id_romaneio = lrow.Item("id_romaneio")
    '            Me.Finalize()
    '            Me.reloadRomaneio()
    '            lmediaDensidade = Me.getRomaneioCompartimentoMediaDens

    '            Me.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
    '            Me.id_exportacao_batch_execucao = id_batch_execucao

    '            'busca o nr_po
    '            If Me.id_cooperativa > 0 Then
    '                Me.dt_referencia = DateTime.Parse(Me.dt_hora_entrada).ToString("dd/MM/yyyy")
    '                dspo = Me.getPOCooperativabyCooperativa
    '                If dspo.Tables(0).Rows.Count > 0 Then
    '                    batchexecucao.nr_po = dspo.Tables(0).Rows(0).Item("nr_po")
    '                    batchexecucao.id_po_cooperativa = dspo.Tables(0).Rows(0).Item("id_po")
    '                    batchexecucao.id_po_produtor = 0
    '                Else
    '                    batchexecucao.nr_po = String.Empty
    '                    batchexecucao.id_po_produtor = 0
    '                    batchexecucao.id_po_cooperativa = 0
    '                End If

    '            Else
    '                Me.dt_referencia = String.Concat("01/", DateTime.Parse(Me.dt_hora_entrada).ToString("MM/yyyy"))
    '                dspo = Me.getPOProdutorbyRomaneioEstabelecimento
    '                If dspo.Tables(0).Rows.Count > 0 Then
    '                    batchexecucao.nr_po = dspo.Tables(0).Rows(0).Item("nr_po")
    '                    batchexecucao.id_po_produtor = dspo.Tables(0).Rows(0).Item("id_po")
    '                    batchexecucao.id_po_cooperativa = 0
    '                Else
    '                    batchexecucao.nr_po = String.Empty
    '                    batchexecucao.id_po_produtor = 0
    '                    batchexecucao.id_po_cooperativa = 0
    '                End If

    '            End If

    '            'Grava medias e po
    '            batchexecucao.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
    '            batchexecucao.nr_media_materia_gorda = Me.getRomaneioCompartimentoMediaMG
    '            batchexecucao.nr_media_proteina = Me.getRomaneioCompartimentoMediaProt
    '            batchexecucao.updateExportacaoBatchItensMediasPO() 'atualiza status

    '            If ValidarBatch(lrow.Item("cd_estabelecimento_sap").ToString, lrow.Item("cd_transportador_sap").ToString, lrow.Item("cd_item_sap"), batchexecucao.nr_po) = True Then
    '                If lbAbrirArquivo = True Then
    '                    lbAbrirArquivo = False
    '                    'Se ainda tem nome de arquivo fecha arquivo anterior
    '                    If Not nomearquivo.ToString.Trim.Equals(String.Empty) Then
    '                        'fecha arquivo anterior
    '                        ArquivoTexto.Close()
    '                        ArquivoTexto.Dispose()
    '                    End If
    '                    'abre novo arquivo ZBRXWMMBXY_YYYYMMDDHHMMSS 
    '                    nomearquivo = "\ZBRXWMMBXY_" + DateTime.Parse(Now()).ToString("yyyyMMddHHmmss") + ".txt"
    '                    nomearquivo = Replace(nomearquivo, ":", "")
    '                    nomearquivo = Replace(nomearquivo, " ", "")
    '                    nomearquivo = Replace(nomearquivo, "/", "")
    '                    nomearquivo = filtro_path_arquivobatch & nomearquivo
    '                    ArquivoTexto = New StreamWriter(nomearquivo)

    '                End If

    '                'Grava execucao itens
    '                batchexecucao.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
    '                batchexecucao.nm_arquivo = nomearquivo
    '                batchexecucao.st_exportacao_batch_itens = "I" 'inicializada
    '                batchexecucao.updateExportacaoBatchItens() 'atualiza status

    '                reg_documentdate = String.Concat(DateTime.Parse(lrow.Item("dt_hora_entrada")).ToString("ddMMyyyy").ToString, ";")
    '                reg_postingdate = String.Concat(DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("ddMMyyyy").ToString, ";")

    '                If Me.id_cooperativa > 0 Then
    '                    reg_referencedocument = String.Concat(Me.nr_nota_fiscal, ";")
    '                Else
    '                    reg_referencedocument = String.Concat(Me.id_romaneio.ToString, ";")
    '                End If
    '                reg_headertext = String.Concat(Me.id_romaneio.ToString, ";")
    '                reg_transactioncode = "MB01;"
    '                reg_materialnb = String.Concat(lrow.Item("cd_item_sap"), ";")
    '                reg_plant = String.Concat(lrow.Item("cd_estabelecimento_sap"), ";")
    '                reg_storagelocation = "0200;"
    '                reg_batchnumber = String.Concat(Me.id_romaneio.ToString, ";")
    '                reg_movtype = "101;"

    '                If Me.id_cooperativa > 0 Then
    '                    reg_quantityinstock = String.Concat(CInt(Me.nr_peso_liquido_nota).ToString, ";")
    '                Else
    '                    reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_descarregado")).ToString, ";")
    '                End If

    '                reg_unitofentry = "L;"
    '                reg_quantityweighed = String.Concat(CInt(Me.nr_peso_liquido).ToString, ";")
    '                reg_unitofentryweighed = "KG;"
    '                reg_purchdocnumber = String.Concat(batchexecucao.nr_po, ";")
    '                reg_itemofpo = "00010;"
    '                reg_dateofmanufacture = String.Concat(DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("ddMMyyyy").ToString, ";")
    '                reg_fatcontent = String.Concat(batchexecucao.nr_media_materia_gorda.ToString, ";")
    '                reg_proteincontent = String.Concat(batchexecucao.nr_media_proteina.ToString, ";")
    '                If Me.id_cooperativa > 0 Then
    '                    reg_supplymodeofthebatch = "P;"
    '                Else
    '                    reg_supplymodeofthebatch = "C;"

    '                End If
    '                reg_idtransport = String.Concat(lrow.Item("cd_transportador_sap").ToString, ";")


    '                linhatexto = ""

    '                'Monta a linha a ser inserida no arquivo texto
    '                linhatexto = reg_documentdate + reg_postingdate + reg_referencedocument + reg_headertext
    '                linhatexto = linhatexto + reg_transactioncode + reg_materialnb + reg_plant + reg_storagelocation
    '                linhatexto = linhatexto + reg_batchnumber + reg_movtype + reg_quantityinstock + reg_unitofentry
    '                linhatexto = linhatexto + reg_quantityweighed + reg_unitofentryweighed + reg_purchdocnumber + reg_itemofpo
    '                linhatexto = linhatexto + reg_dateofmanufacture + reg_fatcontent + reg_proteincontent
    '                linhatexto = linhatexto + reg_supplymodeofthebatch + reg_idtransport


    '                ArquivoTexto.WriteLine(linhatexto)

    '                'finaliza na item execucao e no romaneio se nao houver mais de um registro romaneio (transportadoreas diferentes)
    '                batchexecucao.st_exportacao_batch_itens = "F"
    '                batchexecucao.updateExportacaoBatchItens() 'atualiza status
    '                Me.st_exportacao_batch = "S" 'atualiza status exportacao frete do romaneio 
    '                Me.updateRomaneioBatchExportacao()

    '            End If
    '        Next

    '        If Not ArquivoTexto Is Nothing Then
    '            ArquivoTexto.Close()
    '        End If

    '        'Finaliza execução (romaneios e execucao)
    '        batchexecucao.id_exportacao_batch_execucao = id_batch_execucao
    '        batchexecucao.updateBatchExportacaoStatusFinalizacao()

    '        exportBatchDeclaration = True

    '    Catch ex As Exception
    '        exportBatchDeclaration = False   ' 01/12/2008
    '        Dim execucaoerro As New ExportacaoBatch
    '        execucaoerro.st_exportacao_batch_execucao = "E"
    '        execucaoerro.id_exportacao_batch_execucao = Me.id_exportacao_batch_execucao
    '        execucaoerro.id_exportacao_batch_itens = Me.id_exportacao_batch_itens
    '        execucaoerro.nm_erro = ex.Message
    '        execucaoerro.insertExportacaoBatchErro()
    '        execucaoerro.updateExportacaoBatchExecucao()
    '        If Not ArquivoTexto Is Nothing Then
    '            ArquivoTexto.Close()
    '        End If

    '        Throw New Exception(ex.Message)

    '    End Try

    'End Function

    'Public Function getRomaneioExportacaoBatch() As DataSet

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getRomaneioExportacaoBatch", parameters, "ms_romaneio")
    '        Return dataSet

    '    End Using

    'End Function
    '  14/05/2012 - chamado 1547 - i
    Public Sub updateRomaneioPesagemInicial() 'chamado 1547 - Mirellla i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioPesagemInicial", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioPesagemIntermediaria()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioPesagemIntermediaria", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioPesagemBalanca() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioPesagemBalanca", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    '  14/05/2012 - chamado 1547 - f
    ' adri 07/08/2012 - chamado 1577 - i
    Public Function getExportacaoBatchRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoBatchRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    ' adri 07/08/2012 - chamado 1577 - f

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
    Private Function abrirTransbordoPreRomaneio(ByRef ptransacao As DataAccess)

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'Pre romaneio
            Me.id_st_romaneio = 5
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneio", parameters, ExecuteType.Update)
            'Comita
            transacao.Commit()
            'Retorna ao id do romaneio
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function

    ' adri 17/10/2016 - chamado 2491 - Conciliação de Rotas x Romaneios (Km) - i
    Public Function getRomaneioConciliacaoRotas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotas", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioConciliacaoRotasTransitPoint() As DataSet 'fran 03/2017 conciliação rotas transit point

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransitPoint", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotasTransbordo() As DataSet 'fran 03/2017 conciliação rotas transbordo

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransbordo", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotasTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransvase", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotasPreRomaneioTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransvasePreRom", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioConciliacaoRotasPreRomaneioTransitPoint() As DataSet 'fran 03/2017 conciliação rotas pre romaneo transit point

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransitPointPreRom", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotasPreRomaneioTransbordo() As DataSet 'fran 03/2017 conciliação rotas pre romaneio transbordo

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasTransbordoPreRom", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotaDetalhes() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotaDetalhes", parameters, "ms_view_romaneio_conciliacao")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotaPreDetalhes() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotaPreDetalhes", parameters, "ms_view_romaneio_conciliacao_pre_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioConciliacaoRotasKm() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioConciliacaoRotasKm", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAprovacaoKmFrete() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAprovacaoKmFrete", parameters, "ms_zaprovacao_km_frete")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioJustificativaKmFrete() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioJustificativaKmFrete", parameters, "ms_zjustificativa_km_frete")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSituacaoKmFrete() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSituacaoKmFrete", parameters, "ms_zsituacao_km_frete")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioSelecionar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioSelecionar", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioTransvaseSelecionar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioTransvaseSelecionar", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioPesagemSelecionar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioPesagemSelecionar", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioTransvasePesagemSelecionar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioTransvasePesagemSelecionar", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioTempoRotabyRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioTempoRotabyRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostrasbyFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostrasbyFilters", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostrasbyProtocolo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostrasbyProtocolo", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostraTransitPoint() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostraTransitPoint", parameters, "ms_coleta_amostras")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostraTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostraTransvase", parameters, "ms_coleta_amostras")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostraTransbordo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostraTransbordo", parameters, "ms_coleta_amostras")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAmostra() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAmostra", parameters, "ms_coleta_amostras")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioFecharAmostraPendente() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioFecharAmostraPendente", parameters, "ms_coleta_amostras")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioTempoRotaSintetico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioTempoRotaSintetico", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioTransitPointUP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioTransitPointUP", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioTransvaseUP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioTransvaseUP", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCIQ() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCIQ", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCIQP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCIQP", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCiqDocumentosGrid() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCiqDocumentosGrid", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCiqDocumentos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCiqDocumentos", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function

    Public Function getRomaneioCiqDocumentosAnexados() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCiqDocumentosAnexados", parameters, "ms_romaneio_ciq_documentos")
            Return dataSet

        End Using

    End Function
    Public Sub deleteRomaneioCIQDocumentos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRomaneioCIQDocumentos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getRomaneioCiqDocumentosGridCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioCiqDocumentosGridCooperativa", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioControleLeitePreRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioControleLeitePreRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioControleFrete() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioControleFrete", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioControleFreteCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioControleFreteCooperativa", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioTempoRota() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioTempoRota", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioETransitPoint() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioETransitPoint", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getPreRomaneioETransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioETransvase", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Sub updateRomaneioSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioKMFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioKMFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioNaoAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioNaoAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateRomaneioAprovacaoCancelarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioAprovacaoCancelarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePreRomaneioDisponivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePreRomaneioDisponivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub ConsistirRomaneioRotas()   ' Conciliação


        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)

        Try

            Dim param As List(Of Parameters)

            '=================================================================================================================
            ' Inicializa todas os romaneios do Filtro Estabelecimento/Referência como Sem Divergencias e Aguardando Aprovação
            '=================================================================================================================
            ' Inicializa com id_situacao_analise = 0-Sem divergências (indica que passou pelas consitências e não tem divergências)
            ' Inicializa todas os romaneios do Estabelecimento/Referência para id_aprovacao_analise = 3-Aguardando Aprovação
            param = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateRomaneioConciliacaoRotaInicializacao", param, ExecuteType.Update)  ' Atualiza colunas id_situacao_analise e id_aprovacao_analise

            '=====================================================================================
            ' Atualiza os Romaneios com 1-Sem diverngencias e 2-Com divergencias pelos TOTAIS
            '=====================================================================================
            transacao.Execute("ms_updateRomaneioConciliacaoRotaDivergencias", param, ExecuteType.Update)

            '=====================================================================================
            ' Atualiza os Romaneios com 1-Sem diverngencias e 2-Com divergencias pelos TOTAIS para pre romaneios de transit point
            '=====================================================================================
            transacao.Execute("ms_updateRomaneioConciliacaoRotaDivergenciasTransitPoint", param, ExecuteType.Update)

            '=====================================================================================
            ' Atualiza os Romaneios com 1-Sem diverngencias e 2-Com divergencias pelos TOTAIS para pre romaneios de transbordo
            '=====================================================================================
            transacao.Execute("ms_updateRomaneioConciliacaoRotaDivergenciasTransbordo", param, ExecuteType.Update)

            '=====================================================================================
            ' Atualiza os Romaneios com 1-Sem diverngencias e 2-Com divergencias pelos TOTAIS para pre romaneios de transvase
            '=====================================================================================
            transacao.Execute("ms_updateRomaneioConciliacaoRotaDivergenciasTransvase", param, ExecuteType.Update)

            '=====================================================================================================
            ' Verifica se os Romaneios com 1-Sem diverngencias estão com todas as propriedades/up iguais à da ROTA
            '=====================================================================================================


            'Comita
            transacao.Commit()


        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ' adri 17/10/2016 - chamado 2491 - Conciliação de Rotas x Romaneios (Km) - f
    Public Function abrirRomaneioPreRomaneioRejeitado()

        Dim transacao As New DataAccess
        Dim dsromcomprejeitado As New DataSet
        Dim dsrow As DataRow
        Dim dsrowprop As DataRow
        Dim inr_count_propriedades As Integer
        Dim nr_saldo_litros As Decimal
        Dim nr_desconto_primprop As Decimal
        Dim nr_desconto_propriedade As Decimal
        Dim laux As Decimal
        Dim dsruppropriedades As New DataSet

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_romaneio = CType(transacao.ExecuteScalar("ms_insertRomaneioRejeitadobyPreRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompRejeitadobyPreRomaneio", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUPRejeitadobyPreRomaneio", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacasRejeitadobyPreRomaneio", parameters, ExecuteType.Insert)

            'Insere Analise Compartimento
            transacao.Execute("ms_insertRomaneioAnalisesCompRejeitadobyPreRomaneio", parameters, ExecuteType.Insert)

            'Insere Analise UP
            transacao.Execute("ms_insertRomaneioAnalisesUPRejeitadobyPreRomaneio", parameters, ExecuteType.Insert)

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

            'Insere romaneio mapa de leite
            transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

            'Insere romaneio mapa de leite
            transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)

            ' Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
            transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
            Dim li As Integer = 0
            'apurar rejeicao antibiotico para geração da conta 0114 em conta parcelada do saldo do leite bom que foi misturado com antibiotico
            'maracanau nao tem a mesma regra... so cria conta antibiotico para poços
            If (Me.id_estabelecimento <> 9) Then 'romaneio de produtor
                'Buscar os compartimentos e diferença do volume rejeitado da propriedade para o volume total do compartimento, ou seja deve buscar o valor de leite bom que foi misturado ao de antibiotico para que o produtor possa paga-lo
                transacao.Fill(dsromcomprejeitado, "ms_getRomaneioCompartimentoRejeicaoAntibiotico", parameters, "ms_romaneio_compartimento")
                For Each dsrow In dsromcomprejeitado.Tables(0).Rows
                    Me.id_romaneio_compartimento = dsrow.Item("id_romaneio_compartimento")
                    'quantas propriedades vao ratear o volume
                    inr_count_propriedades = dsrow.Item("nr_count_propriedades")
                    Me.nr_litros_rejeitado = dsrow.Item("nr_litros_rejeitados_compartimento")
                    'o total a ser rateado (litros de leite bom)
                    nr_saldo_litros = dsrow.Item("nr_saldo_litros")
                    'o valor de cada propriedade
                    nr_desconto_propriedade = dsrow.Item("nr_desconto_propriedade")
                    If inr_count_propriedades = 1 Then
                        'se ttem apenas uma propriedade, arredonda sem deciamis pois volume leite deve ser inteiro
                        nr_desconto_primprop = Round(nr_desconto_propriedade, 0)
                    Else
                        'se o valor deve ser dividido entre mais de umma propriedade, joga os litros perdidos para a primeira
                        laux = Round((nr_desconto_propriedade - Truncate(nr_desconto_propriedade)) * inr_count_propriedades, 0)
                        nr_desconto_primprop = Truncate(nr_desconto_propriedade) + laux
                        nr_desconto_propriedade = Truncate(nr_desconto_propriedade)
                    End If

                    'Busca quais sao as propriedades que devem pagar o leite, as que tiveram rejeicao antibiotico
                    li = 0
                    parameters = ParametersEngine.getParametersFromObject(Me)
                    transacao.Fill(dsruppropriedades, "ms_getRomaneioUProducaoPropriedadesRejeicaoAntibiotico", parameters, "ms_romaneio_uproducao")
                    For Each dsrowprop In dsruppropriedades.Tables(0).Rows
                        li = li + 1
                        Me.id_propriedade = dsrowprop.Item("id_propriedade")
                        Me.dt_referencia = DateTime.Parse(dsrowprop.Item("dt_referencia")).ToString("dd/MM/yyyy")
                        'se for a primeira propriedade joga o volume dividido + o decimal
                        If li = 1 Then
                            Me.nr_litros_desconto = nr_desconto_primprop
                        Else
                            Me.nr_litros_desconto = nr_desconto_propriedade
                        End If
                        parameters = ParametersEngine.getParametersFromObject(Me)
                        transacao.Execute("ms_insertRomaneioContaParcelada", parameters, ExecuteType.Update)

                    Next 'proxima propriedade
                Next 'proximo romaneio compartimento

            End If

            'Comita
            transacao.Commit()
            transacao.Dispose()     ' 14/11/2008
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function

    '=====================================================================
    ' 27/02/2024 - Projeto Log stica - Exporta  o de Frete Cooperativa - i
    '=====================================================================
    Public Function exportFreteCooperativa() As Boolean

        Dim ArquivoTexto As StreamWriter
        Dim ArquivoTexto2 As StreamWriter

        Try

            Dim nomearquivo As String
            Dim filtro_estabel As Int32
            Dim filtro_id_romaneio As Int32
            Dim filtro_dt_ini As String
            Dim filtro_dt_fim As String
            Dim filtro_path_arquivofrete As String
            Dim id_frete_execucao As Int32
            Dim lrow As DataRow
            Dim linhaarquivo As String
            Dim cnpjtransportadora As String
            Dim cnpjcooperativa As String
            Dim cnpjestabelecimento As String
            Dim cdnaturezaoperacao As String
            Dim propriedade As New Propriedade
            Dim pessoa As New Pessoa
            Dim Item As New Item
            Dim veiculo As New Veiculo
            Dim freteexecucao As New ExportacaoFreteExecucao
            Dim parametro As New Parametro
            Dim notafiscal As New NotaFiscal
            Dim estabelfrete As New Estabelecimento 'fran 18/02/2012
            Dim SequenceFreteColeta As New SequenceFreteColeta 'fran 26/06/2015
            Dim lsequencefretecoleta As Integer = 0 'fran 26/06/2015
            Dim nomearquivo2 As String 'fran 14/10/2024 incluindo outro arquivo para geracao para sap
            Dim linhaarquivo2 As String 'fran 14/10/2024 incluindo outro arquivo para geracao para sap


            filtro_estabel = Me.id_estabelecimento
            filtro_id_romaneio = Me.id_romaneio
            filtro_dt_ini = Me.dt_hora_saida_ini
            filtro_dt_fim = Me.dt_hora_saida_fim

            filtro_path_arquivofrete = Me.path_arquivofrete
            id_frete_execucao = Me.id_exportacao_frete_execucao

            freteexecucao.id_exportacao_frete_execucao = id_frete_execucao
            Dim dsfreteexecucao As DataSet = freteexecucao.getExportacaoFreteExecucaoItensCooperativaByFilters


            ' adri 02/2024 
            nomearquivo = String.Empty
            nomearquivo2 = String.Empty

            'Dim estabelromaneio As New Estabelecimento(Me.id_estabelecimento)
            'Dim dsDadosCooperativa As DataSet
            'Dim dsDadosCooperativa As DataSet
            Dim dtemissaoNF As String
            Dim dtpagto As String

            '==================================================
            'abre arquivo e gera registro 000 - adri 02/2024 - i
            '==================================================
            'nomearquivo = "\cooperativa-milk_" + estabelromaneio.cd_estabelecimento.Trim + "_" + DateTime.Parse(Me.dt_hora_entrada).ToString("ddMMyyyy") + "_" + DateTime.Parse(Me.dt_modificacao).ToString("ddMMyyyy") + "_" + DateTime.Parse(Now()).ToString("ddMMyyyyHHmmss") + ".txt"
            'nomearquivo = "\cooperativa-milk_" + estabelromaneio.cd_estabelecimento.Trim + "_" + DateTime.Parse(Now()).ToString("ddMMyyyyHHmmss") + ".txt"
            nomearquivo = "\FRPFAPPAGCOMPRA" + Me.id_exportacao_frete_execucao.ToString + DateTime.Parse(Now()).ToString("ddMMyyyyHHmmss") + "_" + Me.id_exportacao_frete_execucao.ToString + ".txt"
            nomearquivo = Replace(nomearquivo, ":", "")
            nomearquivo = Replace(nomearquivo, " ", "")
            nomearquivo = Replace(nomearquivo, "/", "")
            nomearquivo = filtro_path_arquivofrete & nomearquivo
            ArquivoTexto = New StreamWriter(nomearquivo)

            'fran inclusao de novo arquivo
            nomearquivo2 = String.Concat("\FRNC_COMPRA_SAP_AH_", dsfreteexecucao.Tables(0).Rows(0).Item("cd_cnpj_estabelecimento").ToString, "_", DateTime.Parse(Now()).ToString("ddMM"), DateTime.Parse(Now()).ToString("MM_HHmmss"), Me.id_exportacao_frete_execucao.ToString)
            nomearquivo2 = Replace(nomearquivo2, ":", "")
            nomearquivo2 = Replace(nomearquivo2, "/", "")
            nomearquivo2 = Replace(nomearquivo2, "-", "")
            nomearquivo2 = Replace(nomearquivo2, ".", "")
            nomearquivo2 = Replace(nomearquivo2, " ", "")
            nomearquivo2 = filtro_path_arquivofrete & nomearquivo2
            ArquivoTexto2 = New StreamWriter(nomearquivo2)

            ' Monta Registro 0 
            linhaarquivo = Me.FreteCooperativa_Registro_000
            ArquivoTexto.WriteLine(linhaarquivo)

            '===================================================
            'abre arquivo e gera registro 000 - adri 02/2024 - f
            '===================================================

            'Para cada linha do sql que traz os romaneios agrupados por Romaneio
            For Each lrow In dsfreteexecucao.Tables(0).Rows

                'reinicializa romaneio
                Me.id_romaneio = lrow.Item("id_romaneio")
                Me.Finalize()
                Me.reloadRomaneio()

                Me.id_exportacao_frete_execucao_itens = lrow.Item("id_exportacao_frete_execucao_itens")
                Me.id_exportacao_frete_execucao = id_frete_execucao

                cdnaturezaoperacao = String.Empty
                If Validar(lrow.Item("ds_placa_frete").ToString, cdnaturezaoperacao, lrow.Item("id_estabelecimento_frete")) = True Then

                    'Grava execucao itens
                    freteexecucao.id_exportacao_frete_execucao_itens = lrow.Item("id_exportacao_frete_execucao_itens")
                    freteexecucao.nm_arquivo = nomearquivo
                    freteexecucao.nm_arquivo2 = nomearquivo2
                    freteexecucao.st_exportacao_frete_execucao_itens = "I" 'inicializada
                    freteexecucao.updateExportacaoFreteExecucaoItens() 'atualiza status

                    'busca dados do veiculo
                    Me.ds_placa_frete = lrow.Item("ds_placa_frete").ToString.Trim

                    If Me.id_cooperativa > 0 Then

                        'pessoa.id_pessoa = Me.id_cooperativa
                        'dsDadosCooperativa = pessoa.getPessoaByFilters

                        'pessoa.id_pessoa = Convert.ToInt32(lrow.Item("id_transportadora"))
                        'cnpjtransportadora = FormataCampo(pessoa.getCNPJPessoa)

                        cnpjtransportadora = lrow.Item("cd_cnpj_transp").ToString
                        If cnpjtransportadora.Equals(String.Empty) Then
                            cnpjtransportadora = lrow.Item("cd_cpf_transp").ToString
                        End If
                        cnpjcooperativa = lrow.Item("cd_cnpj_coop").ToString
                        If cnpjcooperativa.Equals(String.Empty) Then
                            cnpjcooperativa = lrow.Item("cd_cpf_coop").ToString
                        End If

                        cnpjtransportadora = FormataCampo(cnpjtransportadora)
                        cnpjcooperativa = FormataCampo(cnpjcooperativa)
                        cnpjestabelecimento = FormataCampo(lrow.Item("cd_cnpj_estabelecimento").ToString)

                        dtemissaoNF = ""
                        dtpagto = ""
                        If Me.dt_saida_nota.ToString <> "" Then
                            dtemissaoNF = DateTime.Parse(Me.dt_saida_nota).ToString("dd/MM/yyyy")
                            dtpagto = DateAdd(DateInterval.Month, 3, Convert.ToDateTime(String.Concat("01/", DateTime.Parse(dtemissaoNF).ToString("MM/yyyy"))))
                            dtpagto = String.Concat("15/", DateTime.Parse(dtpagto).ToString("MM/yyyy"))
                        End If


                        '=========================================================
                        ' Adri 02/2024 - Gera registros tipo 000 070 073 e 075 - i
                        '=========================================================
                        ' Monta Registro 70 
                        linhaarquivo = Me.FreteCooperativa_Registro_070(lrow.Item("cd_codigo_sap_transp").ToString, cnpjestabelecimento, dtemissaoNF, dtpagto)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        ' Monta Registro 73 
                        linhaarquivo = Me.FreteCooperativa_Registro_073(cnpjtransportadora, cnpjestabelecimento, dtemissaoNF, cnpjcooperativa.ToString, lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        ' Monta Registro 75 
                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "220000", "C", "10", "  ", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "220550", "C", "10", "  ", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "220550", "D", "10", "  ", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        'Verifica se a nota tem ICMS
                        If Not lrow.Item("cd_cst_cte").ToString.Equals("40") Then
                            linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "243000", "D", "11", "70", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                            ArquivoTexto.WriteLine(linhaarquivo)
                        End If

                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "243011", "D", "11", "50", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "243012", "D", "11", "60", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        linhaarquivo = Me.FreteCooperativa_Registro_075(lrow.Item("cd_codigo_sap_transp").ToString, "810600", "D", "01", "  ", lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString)
                        ArquivoTexto.WriteLine(linhaarquivo)

                        '=========================================================
                        ' Adri 02/2024 - Gera registros tipo 000 070 073 e 075 - f
                        '=========================================================


                        '=========================================================
                        ' fran 10/2024 - Gera registros tipo 700 720 e 740 do arquivo2 - i
                        '=========================================================
                        ' Monta Registro 700
                        linhaarquivo2 = Me.FreteCooperativa_Registro_700(cnpjtransportadora, lrow.Item("cd_ie_transp").ToString, lrow.Item("cd_codigo_sap_transp").ToString, cnpjestabelecimento, dtemissaoNF, lrow.Item("nr_cte").ToString, lrow.Item("nr_serie_cte").ToString, lrow.Item("cd_cfop_cte").ToString, lrow.Item("nr_valor_cte").ToString, lrow.Item("nr_valor_icms_cte").ToString, lrow.Item("cd_uf_origem_cte").ToString, lrow.Item("cd_ibge_origem_cte").ToString, lrow.Item("cd_uf_destino_cte").ToString, lrow.Item("cd_ibge_destino_cte").ToString, lrow.Item("ds_chave_cte").ToString, lrow.Item("dt_emissao_completa_cte").ToString, lrow.Item("ds_protocolo_cte").ToString)
                        ArquivoTexto2.WriteLine(linhaarquivo2)

                        'Verifica se a nota tem ICMS
                        If Not lrow.Item("cd_cst_cte").ToString.Equals("40") Then
                            ' Monta Registro 720 cd 001
                            linhaarquivo2 = Me.FreteCooperativa_Registro_720("001", CDec(lrow.Item("nr_valor_cte").ToString).ToString, CDec(lrow.Item("nr_valor_icms_cte").ToString), CDec(lrow.Item("nr_base_icms_cte").ToString))
                            ArquivoTexto2.WriteLine(linhaarquivo2)
                        End If

                        ' Monta Registro 720 cd 054
                        linhaarquivo2 = Me.FreteCooperativa_Registro_720("054", CDec(lrow.Item("nr_valor_cte").ToString).ToString, CDec(lrow.Item("nr_valor_icms_cte").ToString), CDec(lrow.Item("nr_base_icms_cte").ToString))
                        ArquivoTexto2.WriteLine(linhaarquivo2)

                        ' Monta Registro 720 cd 064
                        'trocar o cd imposto de 054 para 064, as linhas sao identicas
                        linhaarquivo2 = Left(linhaarquivo2, 18) & Replace(linhaarquivo2, "054", "064", 19, 1)
                        ArquivoTexto2.WriteLine(linhaarquivo2)

                        linhaarquivo2 = Me.FreteCooperativa_Registro_740(cnpjestabelecimento, dtemissaoNF, lrow.Item("nr_nota_fiscal").ToString, lrow.Item("nr_serie").ToString, cnpjcooperativa.ToString)
                        ArquivoTexto2.WriteLine(linhaarquivo2)

                        '=========================================================
                        ' fran 10/2024  - f
                        '=========================================================


                    End If

                    'finaliza na item execucao e no romaneio se nao houver mais de um registro romaneio (transportadoreas diferentes)
                    freteexecucao.st_exportacao_frete_execucao_itens = "F"
                    freteexecucao.updateExportacaoFreteExecucaoItens() 'atualiza status
                    If lrow.Item("nr_qtde_romaneio_execucao") = 1 Then
                        Me.st_exportacao_frete = "S" 'atualiza status exportacao frete do romaneio 
                        Me.updateRomaneioStatusFreteExportacao()
                    End If

                End If
            Next


            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If

            If Not ArquivoTexto2 Is Nothing Then
                ArquivoTexto2.Close()
            End If

            'Finaliza execu  o (romaneios e execucao)
            freteexecucao.id_exportacao_frete_execucao = id_frete_execucao
            freteexecucao.updateFreteExportacaoStatusFinalizacao()

            exportFreteCooperativa = True

        Catch ex As Exception
            exportFreteCooperativa = False
            Dim execucaoerro As New ExportacaoFreteExecucao
            execucaoerro.st_exportacao_frete_execucao = "E"
            execucaoerro.id_exportacao_frete_execucao = Me.id_exportacao_frete_execucao
            execucaoerro.id_exportacao_frete_execucao_itens = Me.id_exportacao_frete_execucao_itens
            execucaoerro.nm_erro = ex.Message
            execucaoerro.insertExportacaoFreteExecucaoErro()
            execucaoerro.updateExportacaoFreteExecucao()
            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If
            If Not ArquivoTexto2 Is Nothing Then
                ArquivoTexto2.Close()
            End If


            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_000() As String  ' 28/02/2024 - Frete Cooperativa 


        Try

            Dim linhatexto As String

            ' Registro 000
            Dim tp_registro As String   'Num 3 posi  es
            Dim num_interface As String 'alfnum 10 posi  es
            Dim versao As String        'alfnum 6 posi  es
            Dim remetente As String     'alfnum 40 posi  es
            Dim destinatario As String  'alfnum 40 posi  es


            '====================================================================================
            ' Registro Tipo 000
            '====================================================================================

            'Tipo de Registro - Fixo 000
            tp_registro = "000"

            'Num Interface - Fixo INTPFAR - 10 posi  es
            num_interface = String.Concat("INTPFAR", Space(3))

            'Versao - Fixo 4.0 - 6 posi  es
            versao = String.Concat("4.0", Space(3))

            'remetente - Fixo Danone - MULTICTE FRETE - 40 posi  es
            remetente = "DANONE - MULTICTE FRETE"
            remetente = String.Concat(remetente, Space(40 - Len(remetente)))

            'destinatario - Fixo DANONE - SIS. CORPORATIVO - 40 posi  es
            destinatario = "DANONE - SIS. CORPORATIVO"
            destinatario = String.Concat(destinatario, Space(40 - Len(destinatario)))


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tp_registro + num_interface + versao + remetente + destinatario

            FreteCooperativa_Registro_000 = linhatexto

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_070(ByVal pcdtransportadoraSAP As String, ByVal pCNPJEstabel As String, ByVal pdtemissaoNF As String, ByVal pdtpagto As String) As String


        Try

            Dim linhatexto As String

            ' Registro 070
            Dim tpregistro As String   'Num 3 posi  es
            Dim tplancamento As String   'alfnum 1 posi  es
            Dim cdromaneio As String   'alfnum 16 posi  es
            Dim CNPJEstabel As String 'alfnum 15 posi  es
            Dim cdtransportadora As String 'alfnum 15 posicoes
            Dim cdreferencia As String  ' alfanum 16 posicoes
            Dim dtpagto As String       ' alfanum 10 posicoes
            Dim dtemissao As String     ' alfanum 10 posicoes
            Dim dtgeracao As String     ' alfanum 10 posicoes

            '====================================================================================
            ' Registro Tipo 070
            '====================================================================================

            'Tipo de Registro - Fixo 070
            tpregistro = "070"

            'ID Documento - 16 posi  es
            cdromaneio = Me.id_romaneio.ToString.Trim
            If Len(cdromaneio) > 16 Then
                cdromaneio = Left(cdromaneio, 16)
            Else
                cdromaneio = Right(String.Concat(StrDup(16 - Len(cdromaneio), "0"), cdromaneio), 16)   ' Zeros a esquerda de acordo com o modelo do arquivo enviado
            End If

            'TIPO LANCAMENTO - Fixo 2 - 1 posi  o
            tplancamento = "2"

            'cd transportadora - Cod SAP Transportadora - 14 posi  es
            cdtransportadora = FormataCampo(CLng(pcdtransportadoraSAP).ToString).Trim
            cdtransportadora = String.Concat(cdtransportadora, Space(14 - Len(cdtransportadora)))

            ' cod. refer ncia (mm/aaaa da dt. pagto)
            'cdreferencia = DateTime.Parse(pdtpagto).ToString("MM/yyyy")
            cdreferencia = Left(String.Concat(Me.id_exportacao_frete_execucao.ToString, "-", DateTime.Parse(Now()).ToString("yyyy"), Space(16)), 16)

            ' CNPJ Estabelecimento do Romaneio
            CNPJEstabel = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            CNPJEstabel = String.Concat(CNPJEstabel, Space(15 - Len(CNPJEstabel)))

            ' data de gera  o da exporta  o 
            'dtgeracao = DateTime.Parse(Me.dt_exportacao_frete).ToString("dd/MM/yyyy")
            dtgeracao = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            dtgeracao = String.Concat(dtgeracao, Space(10 - Len(dtgeracao)))

            ' data pagamento (dia 15 de M+3 da data de emissao da nota)
            dtpagto = String.Concat(pdtpagto, Space(10 - Len(pdtpagto)))

            ' data emiss o 
            dtemissao = String.Concat(pdtemissaoNF, Space(10 - Len(pdtemissaoNF)))


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + cdromaneio + tplancamento + cdtransportadora + cdreferencia
            linhatexto = linhatexto + CNPJEstabel + dtgeracao + dtpagto + dtemissao

            FreteCooperativa_Registro_070 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_073(ByVal pCNPJTransportadora As String, ByVal pCNPJEstabel As String, ByVal pdtemissaoNF As String, ByVal pCNPJCooperativa As String, ByVal pnrcte As String, ByVal pseriecte As String, ByVal pvalorcte As String, ByVal pvaloricms As String) As String


        Try

            Dim linhatexto As String

            ' Registro 073
            Dim tpregistro As String   'Num 3 posi  es
            Dim cnpjtransportadora As String 'alfnum 15 posicoes
            Dim CNPJEstabel As String 'alfnum 15 posi  es
            Dim nrcte As String   'alfnum 10 posi  es
            Dim cdseriecte As String   'alfnum 1 posi  es
            Dim dtemissao As String     ' alfanum 10 posicoes
            Dim dtgeracao As String     ' alfanum 10 posicoes
            Dim cdfiller As String     ' alfanum 6 posicoes
            Dim cdfiller2 As String     ' alfanum 6 posicoes
            Dim cdmodelo As String     ' alfanum 4 posicoes
            Dim substributaria As String     ' alfanum 1 posicoes
            Dim nrfatura As String      ' alfanum 12 posicoes
            Dim cdimposto As String     ' alfanum 1 posicoes
            Dim basecalculo As String   ' alfanum 12 posicoes 
            Dim valorICMS As String  ' 10 inteiros e 2 decimais
            Dim valorcte As String   ' 10 inteiros e 2 decimais
            Dim aliqimposto As String  ' 10 inteiros e 2 decimais
            Dim cnpjcooperativa As String 'alfnum 15 posicoes
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String


            '====================================================================================
            ' Registro Tipo 073
            '====================================================================================

            'Tipo de Registro - Fixo 073
            tpregistro = "073"

            'CNPJ Transportadora - 15 posi  es"
            cnpjtransportadora = FormataCampo(pCNPJTransportadora.Trim.ToString).Trim
            cnpjtransportadora = String.Concat(cnpjtransportadora, Space(15 - Len(cnpjtransportadora)))

            'CNPJ Estabelecimento do Romaneio - 15 posi  es"
            CNPJEstabel = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            CNPJEstabel = String.Concat(CNPJEstabel, Space(15 - Len(CNPJEstabel)))

            'nr_cte - 12 posi  es"
            If Len(pnrcte) > 12 Then
                nrcte = Left(pnrcte, 12)
            Else
                nrcte = Left(String.Concat(pnrcte, Space(12)), 12)
            End If

            'nr_serie_cte - 5 posi  es"
            cdseriecte = pseriecte  ' assume 1 por enquanto ate Fran implementar
            cdseriecte = Left(String.Concat(cdseriecte, Space(5)), 5)

            ' data de gera  o da exporta  o 
            'dtgeracao = DateTime.Parse(Me.dt_exportacao_frete).ToString("dd/MM/yyyy")
            dtgeracao = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            dtgeracao = String.Concat(dtgeracao, Space(10 - Len(dtgeracao)))

            ' data emiss o 
            dtemissao = String.Concat(pdtemissaoNF, Space(10 - Len(pdtemissaoNF)))

            ' filler 6 posicoes
            cdfiller = Space(6)

            ' modelo documento 4 posicoes
            cdmodelo = "57  "

            ' Valor da faturavalor cte - 13 posicoes inteiras e 2 decimais
            valorcte = Round(CDec(pvalorcte), 2).ToString
            lpos = InStr(1, valorcte, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorcte, 1, lpos - 1)
                lvalordec = Mid(valorcte, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorcte
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorcte = Right(String.Concat(lvalorint, lvalordec), 15)

            ' Substitui  o Tribut ria 1 posicoes
            substributaria = "N"

            ' 08/03/2024 - Numero da fatura alfanum 12 posicoes
            nrfatura = Me.id_romaneio.ToString.Trim
            If Len(nrfatura) > 12 Then
                nrfatura = Left(nrfatura, 12)
            Else
                nrfatura = String.Concat(nrfatura, Space(12 - Len(nrfatura)))
            End If

            ' C digo Imposto 1 posicoes
            cdimposto = "7"

            ' base de calculo - 08/03/2024
            If CDbl(pvaloricms) = 0 Then
                basecalculo = Right(StrDup(12, "0"), 12)
            Else
                basecalculo = Right(valorcte, 12)
            End If

            ' valor imposto - 10 posicoes inteiras e 2 decimais
            'valorICMS = Round(CDec(pvalorcte) * 0.12, 2).ToString
            valorICMS = pvaloricms

            lpos = InStr(1, valorICMS, ",")
            If lpos > 0 Then
                lvalorint = Mid(valorICMS, 1, lpos - 1)
                lvalordec = Mid(valorICMS, lpos + 1)
                If Len(lvalorint) > 10 Then
                    lvalorint = Left(lvalorint, 10)
                Else
                    lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint), "0"), lvalorint), 10)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                End If

            Else
                lvalorint = valorICMS
                If Len(lvalorint) > 10 Then
                    lvalorint = Left(lvalorint, 10)
                Else
                    lvalorint = Right(String.Concat(StrDup(5 - Len(lvalorint), "0"), lvalorint), 10)
                End If
                lvalordec = "00"
            End If
            valorICMS = Right(String.Concat(lvalorint, lvalordec), 12)

            ' Al quota Imposto 1 posicoes
            lvalorint = "0"
            lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint), "0"), lvalorint), 10)
            lvalordec = "00"
            aliqimposto = Right(String.Concat(lvalorint, lvalordec), 12)


            'CNPJ cooperativa - 14 posi  es"
            cnpjcooperativa = FormataCampo(pCNPJCooperativa.Trim.ToString).Trim
            cnpjcooperativa = String.Concat(cnpjcooperativa, Space(14 - Len(cnpjcooperativa)))

            ' filler 1 posi  o
            cdfiller2 = Space(1)


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + cnpjtransportadora + CNPJEstabel + nrcte + cdseriecte + dtgeracao + dtemissao + cdfiller
            linhatexto = linhatexto + cdmodelo + valorcte + substributaria + nrfatura + cdimposto + basecalculo + aliqimposto + valorICMS + cnpjcooperativa + cdfiller2

            FreteCooperativa_Registro_073 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_075(ByVal pcdtransportadoraSAP As String, ByVal pcdcontacontabil As String, ByVal pdebitocredito As String, ByVal ptplancamento As String, ByVal pcdimposto As String, ByVal pnrcte As String, ByVal pseriecte As String, ByVal pvalorcte As String, ByVal pvaloricms As Decimal) As String


        Try

            Dim linhatexto As String

            ' Registro 075
            Dim tpregistro As String   'Num 3 posi  es
            Dim cdtransportadora As String 'alfnum 15 posicoes
            Dim cdcontacontabil As String  'alfanum 10 posicoes
            Dim cdcentrocusto As String  'alfanum 10 posicoes
            Dim cditem As String  'alfanum 20 posicoes
            Dim debitocredito As String  'alfanum 1 posicoes
            Dim valorlancamento As String 'decimal 8 inteiros e 2 decimais
            Dim numeroNF As String   'alfnum 10 posi  es
            Dim serieNF As String   'alfnum 3 posi  es
            Dim iddocumento As String   'alfnum 16 posi  es
            Dim tplancamento As String   'alfnum 2 posi  es
            Dim cdimposto As String     ' alfanum 2 posicoes
            Dim numerofatura As String     ' alfanum 15 posicoes
            Dim tipofatura As String  'alfanum 4 posicoes
            Dim cdseriecte As String
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            Dim valorICMS As String
            Dim valorPIS As String
            Dim valorCOFINS As String


            '====================================================================================
            ' Registro Tipo 075 - Conta Cont bel 
            '====================================================================================

            'Tipo de Registro - Fixo 075
            tpregistro = "075"

            'cd transportadora - Cod SAP Transportadora - 15 posi  es
            cdtransportadora = FormataCampo(CLng(pcdtransportadoraSAP).ToString).Trim
            cdtransportadora = String.Concat(cdtransportadora, Space(15 - Len(cdtransportadora)))

            'cd conta contabil -  10 posi  es
            cdcontacontabil = pcdcontacontabil  ' conta de cr dito
            cdcontacontabil = String.Concat(cdcontacontabil, Space(10 - Len(cdcontacontabil)))

            'cd centro custo -  10 posi  es
            cdcentrocusto = "321018"
            cdcentrocusto = String.Concat(cdcentrocusto, Space(10 - Len(cdcentrocusto)))

            'cd item -  20 posi  es
            cditem = Space(20)

            'D bito ou cr dito -  1 posi ao
            debitocredito = pdebitocredito

            ' valor lancamento - 8 posicoes inteiras e 2 decimais
            valorlancamento = 0
            'valorICMS = Round(CDec(pvalorcte) * 0.12, 2).ToString
            valorICMS = pvaloricms.ToString
            'valorPIS = Round(CDec(pvalorcte) * 0.0165, 2).ToString
            'valorCOFINS = Round(CDec(pvalorcte) * 0.076, 2).ToString
            valorPIS = Round((CDec(pvalorcte) - pvaloricms) * 0.0165, 2).ToString
            valorCOFINS = Round((CDec(pvalorcte) - pvaloricms) * 0.076, 2).ToString
            Select Case pcdcontacontabil
                Case "220000"
                    valorlancamento = Round(CDec(pvalorcte), 2).ToString
                Case "220550"
                    valorlancamento = Round(CDec(pvalorcte), 2).ToString
                Case "243000"  ' ICMS
                    valorlancamento = valorICMS.ToString
                Case "243011"  ' PIS
                    valorlancamento = valorPIS.ToString
                Case "243012"  ' COFINS
                    valorlancamento = valorCOFINS.ToString
                Case "810600"
                    valorlancamento = Round(CDec(pvalorcte) - CDec(valorICMS) - CDec(valorPIS) - CDec(valorCOFINS), 2).ToString
            End Select

            lpos = InStr(1, valorlancamento, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorlancamento, 1, lpos - 1)
                lvalordec = Mid(valorlancamento, lpos + 1)
                If Len(lvalorint) > 10 Then
                    lvalorint = Left(lvalorint, 8)
                Else
                    lvalorint = Right(String.Concat(StrDup(10 - Len(lvalorint), "0"), lvalorint), 8)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2 - Len(lvalordec), "0")), 2)
                End If

            Else
                lvalorint = valorlancamento
                If Len(lvalorint) > 8 Then
                    lvalorint = Left(lvalorint, 8)
                Else
                    lvalorint = Right(String.Concat(StrDup(8 - Len(lvalorint), "0"), lvalorint), 8)
                End If
                lvalordec = "00"
            End If

            valorlancamento = Right(String.Concat(lvalorint, lvalordec), 10)

            'numero NF -  10 posi  es
            numeroNF = Space(10)

            'serie NF -  3 posi  es
            serieNF = Space(3)

            'id documento -  16 posi  es
            iddocumento = Space(16)

            ' tp lancamento - 2 posicoes
            tplancamento = ptplancamento

            ' cd imposto - 2 posicoes
            cdimposto = pcdimposto

            ' numero fatura - 15 posicoes
            cdseriecte = pseriecte  ' assume 1 por enquanto ate Fran implementar
            'cdseriecte = "1"  ' assume 1 por enquanto ate Fran implementar
            numerofatura = pnrcte + "/" + cdseriecte.ToString
            numerofatura = Left(String.Concat(numerofatura, Space(15 - Len(numerofatura))), 15)

            ' tipo fatura
            tipofatura = "57"
            tipofatura = Left(String.Concat(tipofatura, Space(4 - Len(tipofatura))), 4)


            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + cdtransportadora + cdcontacontabil + cdcentrocusto + cditem + debitocredito + valorlancamento + numeroNF
            linhatexto = linhatexto + serieNF + iddocumento + tplancamento + cdimposto + numerofatura + tipofatura

            FreteCooperativa_Registro_075 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    '=====================================================================
    ' 27/02/2024 - Projeto Log stica - Exporta  o de Frete Cooperativa - f
    '=====================================================================
    Private Function FreteCooperativa_Registro_700(ByVal pCNPJTransportadora As String, ByVal pIETransportadora As String, ByVal pcdtransportadoraSAP As String, ByVal pCNPJEstabel As String, ByVal pdtemissaoNF As String, ByVal pnrcte As String, ByVal pseriecte As String, ByVal pCFOPcte As String, ByVal pvalorcte As String, ByVal pvaloricms As String, ByVal pUForigem As String, ByVal pIBGEorigem As String, ByVal pUFdestino As String, ByVal pIBGEdestino As String, ByVal pchaveCTE As String, ByVal pdtemissaocompleta As String, ByVal pnrprotocolocte As String) As String


        Try

            Dim linhatexto As String

            ' Registro 700
            Dim tpregistro As String   'Num 3 posi  es
            Dim idnotacobranca As String   'Num 15 inteiros
            Dim cdmodelo As String   'alfnum 4 posiçoes
            Dim nrcte As String   'alfnum 12 posi  es
            Dim cdseriecte As String   'alfnum 5 posi  es
            Dim tppessoatransp As String   'alfnum 1 posi  es
            Dim cnpjtransportadora As String 'alfnum 14 posicoes
            Dim ietransportadora As String 'alfnum 15 posicoes
            Dim cdtransportadora As String 'alfnum 14 posicoes
            Dim CNPJEstabel As String 'alfnum 14 posi  es
            Dim dtemissao As String     ' alfanum 10 posicoes
            Dim dtgeracao As String     ' alfanum 10 posicoes
            Dim cdnaturezaoperacao As String     ' alfanum 6 posicoes
            Dim valordesconto As String   ' 13 inteiros e 2 decimais
            Dim substributaria As String     ' alfanum 1 posicoes
            Dim uforigem As String   ' char 2
            Dim ufdestino As String   ' char 2
            Dim nrfatura As String   ' char 12
            Dim valorBaseICMS As String  ' 13 inteiros e 2 decimais
            Dim cdfiller As String     ' numerico 31 posicoes zeros (valorbaseicmsst + valor baseicmsdiferencialaliquota + percentualdiferencialaliquota
            Dim grupocfop As String  ' alfnum 4
            Dim cdtiponota As String  ' alfnum 4 TRAN
            Dim finalidade As String  ' alfnum 1 3
            Dim notaentrada As String  ' inteito 6
            Dim cdCFOP As String  ' alfnum 4 
            Dim tipofrete As String  ' alfnum 3 FOB
            Dim pesoliquido As String  ' numerico 15 posicoes 
            Dim pesobruto As String  ' numerico 15 posicoes 
            Dim qtdevolumes As String  ' char 5 0
            Dim chaveCTe As String     ' alfanum 44 posicoes
            Dim dthoraemissao As String      ' alfanum 18 posicoes dd/mm/aaaahhmmssss
            Dim protocolocte As String     ' alfanum 15 posicoes
            Dim cancelamento As String     ' alfanum 4 posicoes
            Dim IBGEorigem As String     ' alfanum 9 posicoes
            Dim IBGEseparador As String     ' alfanum 1 posicoes "/"
            Dim IBGEdestino As String     ' alfanum 10 posicoes
            Dim tipocte As String     ' alfanum 4 posicoes
            Dim valorcte As String   ' 13 inteiros e 2 decimais
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String


            '====================================================================================
            ' Registro Tipo 700
            '====================================================================================

            'Tipo de Registro - Fixo 700
            tpregistro = "700"

            'ID nota cobranca - 15 inteiros
            idnotacobranca = Me.id_romaneio.ToString.Trim
            If Len(idnotacobranca) > 15 Then
                idnotacobranca = Left(idnotacobranca, 15)
            Else
                idnotacobranca = Right(String.Concat(StrDup(15, "0"), idnotacobranca), 15)   ' Zeros a esquerda de acordo com o modelo do arquivo enviado
            End If

            'codmodelo fixo 57 4 posiçoes
            cdmodelo = "57  "

            'nr_cte - 12 posi  es"
            If Len(pnrcte) > 12 Then
                nrcte = Left(pnrcte, 12)
            Else
                nrcte = Left(String.Concat(pnrcte, Space(12)), 12)
            End If

            'nr_serie_cte - 5 posi  es"
            cdseriecte = pseriecte  ' assume 1 por enquanto ate Fran implementar
            cdseriecte = Left(String.Concat(cdseriecte, Space(5)), 5)

            'tipopessoatransportadora
            tppessoatransp = "2"

            'CNPJ Transportadora - 14 posi  es"
            cnpjtransportadora = FormataCampo(pCNPJTransportadora.Trim.ToString).Trim
            cnpjtransportadora = Left(String.Concat(cnpjtransportadora, Space(14)), 14)

            'ie transportadora
            ietransportadora = FormataCampo(pIETransportadora.Trim.ToString).Trim
            ietransportadora = Left(String.Concat(ietransportadora, Space(15)), 15)

            'cd transportadora - Cod SAP Transportadora - 14 posi  es
            cdtransportadora = FormataCampo(CLng(pcdtransportadoraSAP).ToString).Trim
            cdtransportadora = Left(String.Concat(cdtransportadora, Space(14)), 14)

            'CNPJ Estabelecimento do Romaneio - 15 posi  es"
            CNPJEstabel = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            CNPJEstabel = Left(String.Concat(CNPJEstabel, Space(14)), 14)

            ' data atual 
            dtgeracao = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            dtgeracao = String.Concat(dtgeracao, Space(10 - Len(dtgeracao)))

            ' data emiss o 
            dtemissao = String.Concat(pdtemissaoNF, Space(10 - Len(pdtemissaoNF)))

            'cd natureza operacao char6
            cdnaturezaoperacao = Left(String.Concat(pCFOPcte.Trim, Space(6)), 6)
            ' se entre estados 
            If pUForigem.ToUpper.Trim <> pUFdestino.ToUpper.Trim Then
                cdnaturezaoperacao = Left(String.Concat("2", Mid(pCFOPcte.Trim, 2, 3), "AA", Space(6)), 6)
            Else
                cdnaturezaoperacao = Left(String.Concat("1", Mid(pCFOPcte.Trim, 2, 3), "AA", Space(6)), 6)
            End If

            ' Valor do frete cte - 13 posicoes inteiras e 2 decimais
            valorcte = Round(CDec(pvalorcte), 2).ToString
            lpos = InStr(1, valorcte, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorcte, 1, lpos - 1)
                lvalordec = Mid(valorcte, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorcte
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorcte = Right(String.Concat(lvalorint, lvalordec), 15)

            ' valor desconto nc 13 int 2 dec
            valordesconto = StrDup(15, "0")

            ' Substitui  o Tribut ria 1 posicoes
            substributaria = "0"
            '
            'UF origem char 2
            uforigem = Left(String.Concat(pUForigem.Trim, "  "), 2)

            'UF destino char2
            ufdestino = Left(String.Concat(pUFdestino.Trim, "  "), 2)


            ' cod da fatura alfanum 12 posicoes assumiremos nr execucao
            nrfatura = Me.id_exportacao_frete_execucao.ToString.Trim
            If Len(nrfatura) > 12 Then
                nrfatura = Left(nrfatura, 12)
            Else
                nrfatura = Left(String.Concat(nrfatura, Space(12)), 12)
            End If

            ' valor base icms
            If CDbl(pvaloricms) = 0 Then
                valorBaseICMS = Right(StrDup(15, "0"), 15)
            Else
                valorBaseICMS = valorcte
            End If

            'valorbaseicmsst + valorbaseicmsdiferencialaliquotra + percentual diferencial 15 pos + 15pos +1 pos
            cdfiller = StrDup(31, "0")

            'grupo cfop
            If pCFOPcte = String.Empty Then
                grupocfop = StrDup(4, " ")
            Else
                grupocfop = String.Concat(Left(pCFOPcte, 1), StrDup(3, "000"))
            End If

            'codigo tipo nota
            cdtiponota = "TRAN"
            'finalidade operacao
            finalidade = "3"

            'nota entrada
            notaentrada = StrDup(6, "0")

            'cfop
            If pCFOPcte = String.Empty Then
                cdCFOP = StrDup(4, " ")
            Else
                cdCFOP = Left(String.Concat(pCFOPcte, StrDup(4, " ")), 4)
            End If

            'tipofrete
            tipofrete = "FOB"

            'cd cfop grupo

            'peso liquido
            pesoliquido = StrDup(15, "0")

            'pesobruto 
            pesobruto = StrDup(15, "0")

            qtdevolumes = "0    "

            'chave cte 44 posiçoes
            chaveCTe = Left(String.Concat(pchaveCTE.Trim, StrDup(44, " ")), 44)

            'datahota autorizacao cte 18 posicoes
            If Not IsDBNull(pdtemissaocompleta) AndAlso Not pdtemissaocompleta.Equals(String.Empty) Then
                dthoraemissao = Left(String.Concat(DateTime.Parse(pdtemissaocompleta).ToString("dd/MM/yyyy"), "00", DateTime.Parse(pdtemissaocompleta).ToString("HHmmss"), StrDup(8, "0")), 18)
            Else
                dthoraemissao = Left(String.Concat(dtemissao, "00", "000000", StrDup(8, "0")), 18)

            End If

            'nr ptotocolo cte 15 posiçoes alfanumerico
            protocolocte = Left(String.Concat(pnrprotocolocte.Trim, Space(15)), 15)

            'cancelamento 4 posicoes
            cancelamento = Space(4)

            'ibge origem 9 posicoes
            IBGEorigem = Left(String.Concat(pIBGEorigem.Trim, Space(9)), 9)

            'separador ibge
            IBGEseparador = "/"
            'ibge destino
            IBGEdestino = Left(String.Concat(pIBGEdestino.Trim, Space(10)), 10)

            tipocte = "0    "

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + idnotacobranca + cdmodelo + nrcte + cdseriecte + tppessoatransp + cnpjtransportadora + ietransportadora + cdtransportadora
            linhatexto = linhatexto + CNPJEstabel + dtgeracao + dtemissao + cdnaturezaoperacao + valorcte + valordesconto + substributaria
            linhatexto = linhatexto + uforigem + ufdestino + nrfatura + valorcte + "00" + idnotacobranca + valorBaseICMS + cdfiller
            linhatexto = linhatexto + grupocfop + cdtiponota + finalidade + notaentrada + cdCFOP + tipofrete + grupocfop
            linhatexto = linhatexto + pesoliquido + pesobruto + qtdevolumes + chaveCTe + dthoraemissao + protocolocte + cancelamento + IBGEorigem + IBGEseparador + IBGEdestino + tipocte

            FreteCooperativa_Registro_700 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_720(ByVal pcdimposto As String, ByVal pvalorcte As String, ByVal pvaloricms As Decimal, ByVal pvalorbaseicms As Decimal) As String


        Try

            Dim linhatexto As String

            ' Registro 720
            Dim tpregistro As String   'Num 3 posi  es
            Dim idnotacobranca As String   'Num 15 inteiros
            Dim cdimposto As String     ' alfanum 3 posicoes
            Dim percentualICMS As String     ' decimal 6 inteiros 2 decimais
            Dim lpos As Integer
            Dim lvalorint As String
            Dim lvalordec As String
            Dim valorICMS As String
            Dim valorbaseICMS As String
            Dim valorPIS As String
            Dim valorCOFINS As String
            Dim valorbasePISCOFINS As String
            Dim valorAPagarComCredito As String


            '====================================================================================
            ' Registro Tipo 720
            '====================================================================================

            'Tipo de Registro - Fixo 720
            tpregistro = "720"

            'ID nota cobranca - 15 inteiros
            idnotacobranca = Me.id_romaneio.ToString.Trim
            If Len(idnotacobranca) > 15 Then
                idnotacobranca = Left(idnotacobranca, 15)
            Else
                idnotacobranca = Right(String.Concat(StrDup(15, "0"), idnotacobranca), 15)   ' Zeros a esquerda de acordo com o modelo do arquivo enviado
            End If

            'cd imposto -  3 posi  es
            cdimposto = Left(String.Concat(pcdimposto.Trim, Space(3)), 3)

            ' valor base icms
            If CDbl(pvaloricms) = 0 Then
                valorbaseICMS = StrDup(15, "0")
                percentualICMS = StrDup(8, "0")
                valorICMS = StrDup(15, "0")
            Else
                valorbaseICMS = pvalorbaseicms
                If cdimposto = "001" Then
                    percentualICMS = "00001200"
                    valorICMS = pvaloricms
                Else
                    percentualICMS = StrDup(8, "0")
                    valorICMS = StrDup(15, "0")
                End If
            End If

            ' Valor do frete cte - 13 posicoes inteiras e 2 decimais
            valorbaseICMS = Round(CDec(valorbaseICMS), 2).ToString
            lpos = InStr(1, valorbaseICMS, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorbaseICMS, 1, lpos - 1)
                lvalordec = Mid(valorbaseICMS, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If
            Else
                lvalorint = valorbaseICMS
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorbaseICMS = Right(String.Concat(lvalorint, lvalordec), 15)

            ' Valor icms - 13 posicoes inteiras e 2 decimais
            valorICMS = Round(CDec(valorICMS), 2).ToString
            lpos = InStr(1, valorICMS, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorICMS, 1, lpos - 1)
                lvalordec = Mid(valorICMS, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorICMS
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorICMS = Right(String.Concat(lvalorint, lvalordec), 15)

            'valor base pis e cofins
            valorbasePISCOFINS = Round(CDec(pvalorcte) - pvaloricms, 2).ToString
            lpos = InStr(1, valorbasePISCOFINS, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorbasePISCOFINS, 1, lpos - 1)
                lvalordec = Mid(valorbasePISCOFINS, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorbasePISCOFINS
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorbasePISCOFINS = Right(String.Concat(lvalorint, lvalordec), 15)

            'valor pis
            valorPIS = Round((CDec(pvalorcte) - pvaloricms) * 0.0165, 2).ToString
            lpos = InStr(1, valorPIS, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorPIS, 1, lpos - 1)
                lvalordec = Mid(valorPIS, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorPIS
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorPIS = Right(String.Concat(lvalorint, lvalordec), 15)

            'valor cofins
            valorCOFINS = Round((CDec(pvalorcte) - pvaloricms) * 0.076, 2).ToString
            lpos = InStr(1, valorCOFINS, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorCOFINS, 1, lpos - 1)
                lvalordec = Mid(valorCOFINS, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If

            Else
                lvalorint = valorCOFINS
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorCOFINS = Right(String.Concat(lvalorint, lvalordec), 15)

            If cdimposto = "001" Then
                valorAPagarComCredito = Round(CDec(pvalorcte), 2)
            Else
                valorAPagarComCredito = StrDup(15, "0")
            End If
            lpos = InStr(1, valorAPagarComCredito, ",")

            If lpos > 0 Then
                lvalorint = Mid(valorAPagarComCredito, 1, lpos - 1)
                lvalordec = Mid(valorAPagarComCredito, lpos + 1)
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                If Len(lvalordec) > 2 Then
                    lvalordec = Left(lvalordec, 2)
                Else
                    lvalordec = Left(String.Concat(lvalordec, StrDup(2, "0")), 2)
                End If
            Else
                lvalorint = valorAPagarComCredito
                If Len(lvalorint) > 13 Then
                    lvalorint = Left(lvalorint, 13)
                Else
                    lvalorint = Right(String.Concat(StrDup(13, "0"), lvalorint), 13)
                End If
                lvalordec = "00"
            End If

            valorAPagarComCredito = Right(String.Concat(lvalorint, lvalordec), 15)

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + idnotacobranca + cdimposto + valorbaseICMS + percentualICMS + valorICMS + "0000"
            linhatexto = linhatexto + valorbasePISCOFINS + "00000165" + valorPIS + valorbasePISCOFINS + "00000760" + valorCOFINS
            linhatexto = linhatexto + valorbaseICMS + StrDup(15, "0") + valorICMS + StrDup(15, "0") + valorAPagarComCredito + StrDup(15, "0")

            FreteCooperativa_Registro_720 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

    Private Function FreteCooperativa_Registro_740(ByVal pCNPJEstabel As String, ByVal pdtemissaoNF As String, ByVal pnrnotanfe As String, ByVal pserienfe As String, ByVal pCNPJCooperativa As String) As String


        Try

            Dim linhatexto As String

            ' Registro 740
            Dim tpregistro As String   'Num 3 posi  es
            Dim idnotacobranca As String   'Num 15 inteiros
            Dim cnpjcooperativa As String 'alfnum 14 posicoes
            Dim CNPJEstabel As String 'alfnum 14 posi  es
            Dim nrnotafiscal As String   'alfnum 12 posi  es
            Dim cdserienfe As String   'alfnum 3 posi  es
            Dim dtemissao As String     ' alfanum 10 posicoes


            '====================================================================================
            ' Registro Tipo 740
            '====================================================================================

            'Tipo de Registro - Fixo 740
            tpregistro = "740"

            'ID nota cobranca - 15 inteiros
            idnotacobranca = Me.id_romaneio.ToString.Trim
            If Len(idnotacobranca) > 15 Then
                idnotacobranca = Left(idnotacobranca, 15)
            Else
                idnotacobranca = Right(String.Concat(StrDup(15, "0"), idnotacobranca), 15)   ' Zeros a esquerda de acordo com o modelo do arquivo enviado
            End If

            'CNPJ Estabelecimento do Romaneio - 14 posi  es"
            CNPJEstabel = FormataCampo(pCNPJEstabel.Trim.ToString).Trim
            CNPJEstabel = Left(String.Concat(CNPJEstabel, Space(14)), 14)

            'nr_cte - 12 posi  es"
            If Len(pnrnotanfe) > 12 Then
                nrnotafiscal = Left(pnrnotanfe, 12)
            Else
                nrnotafiscal = Left(String.Concat(pnrnotanfe, Space(12)), 12)
            End If

            'nr_serie nfe - 3 posi  es"
            cdserienfe = pserienfe
            cdserienfe = Left(String.Concat(cdserienfe, Space(3)), 3)

            ' data emiss o 
            dtemissao = String.Concat("01/", DateTime.Parse(pdtemissaoNF).ToString("MM/yyyy"))

            'CNPJ cooperativa - 14 posi  es"
            cnpjcooperativa = FormataCampo(pCNPJCooperativa.Trim.ToString).Trim
            cnpjcooperativa = String.Concat(cnpjcooperativa, Space(14 - Len(cnpjcooperativa)))

            linhatexto = ""

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = tpregistro + idnotacobranca + CNPJEstabel + nrnotafiscal + cdserienfe + "2" + cnpjcooperativa + "2"
            linhatexto = linhatexto + Space(6) + StrDup(45, "0") + dtemissao + "1"

            FreteCooperativa_Registro_740 = formatarTexto(linhatexto)

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function

End Class
