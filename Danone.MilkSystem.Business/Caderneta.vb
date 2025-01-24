Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Caderneta

    Private _id_coleta As Int32
    Private _nr_caderneta As Int32
    Private _id_linha As Int32
    Private _id_linha_item As Int32
    Private _id_estabelecimento As Int32
    Private _id_propriedade As Int32
    Private _nr_unid_producao As Int32
    Private _id_origem_resfriador As Int32
    Private _id_motivo_nao_coleta As Int32
    Private _id_motivo_desvio As Int32
    Private _nr_ordem As Int32
    Private _id_romaneio As Int32
    Private _id_situacao_coleta As Int32
    Private _dt_coleta As String
    Private _nr_temperatura As Decimal
    Private _id_alizarol As Int32
    Private _nr_alizarol As Int32
    Private _id_compartimento As Int32
    Private _nr_volume As Decimal
    Private _nm_linha As String
    Private _nm_estabelecimento As String
    Private _cd_cnh As String
    Private _nm_motorista As String
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _cd_transportador2 As String
    Private _nm_transportador2 As String
    Private _ds_transportador As String
    Private _ds_linha As String
    Private _ds_placa As String
    Private _ds_placa_julieta As String
    Private _cd_produtor As String
    Private _nm_produtor As String
    Private _nm_propriedade As String
    Private _nm_unid_producao As String
    Private _cd_propriedade_resfriador As String
    Private _dia_impar_par As String
    Private _st_leite_coletado As String
    Private _st_leite_desviado As String
    Private _st_volume_descartado As String
    Private _ds_estabelecimento As String
    Private _st_transmitido As String
    Private _id_coleta_veiculo As Int32
    Private _currentidentity As Int32
    Private _id_protocolo As Int32
    Private _id_modificador As Int32
    Private _dt_transmissao_ini As String 'Fran 29/11/2008
    Private _dt_transmissao_fim As String 'Fran 29/11/2008
    Private _dt_transmissao As String 'Fran 29/11/2008
    Private _ds_placa_frete As String   ' Adri 21/09/2009 Rls 21
    Private _id_nao_conformidade As Int32    ' Adri 29/09/2009 rls 21 frete
    Private _id_coleta_nao_conformidade As Int32    ' Adri 29/09/2009 rls 21 frete

    Public Property id_coleta() As Int32
        Get
            Return _id_coleta
        End Get
        Set(ByVal value As Int32)
            _id_coleta = value
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

    Public Property id_linha() As Int32
        Get
            Return _id_linha
        End Get
        Set(ByVal value As Int32)
            _id_linha = value
        End Set
    End Property

    Public Property id_linha_item() As Int32
        Get
            Return _id_linha_item
        End Get
        Set(ByVal value As Int32)
            _id_linha_item = value
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

    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property

    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property

    Public Property id_origem_resfriador() As Int32
        Get
            Return _id_origem_resfriador
        End Get
        Set(ByVal value As Int32)
            _id_origem_resfriador = value
        End Set
    End Property

    Public Property id_motivo_nao_coleta() As Int32
        Get
            Return _id_motivo_nao_coleta
        End Get
        Set(ByVal value As Int32)
            _id_motivo_nao_coleta = value
        End Set
    End Property

    Public Property id_motivo_desvio() As Int32
        Get
            Return _id_motivo_desvio
        End Get
        Set(ByVal value As Int32)
            _id_motivo_desvio = value
        End Set
    End Property

    Public Property nr_ordem() As Int32
        Get
            Return _nr_ordem
        End Get
        Set(ByVal value As Int32)
            _nr_ordem = value
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

    Public Property id_situacao_coleta() As Int32
        Get
            Return _id_situacao_coleta
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta = value
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
    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
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
    Public Property nr_temperatura() As Decimal
        Get
            Return _nr_temperatura
        End Get
        Set(ByVal value As Decimal)
            _nr_temperatura = value
        End Set
    End Property

    Public Property id_alizarol() As Int32
        Get
            Return _id_alizarol
        End Get
        Set(ByVal value As Int32)
            _id_alizarol = value
        End Set
    End Property
    Public Property nr_alizarol() As Int32
        Get
            Return _nr_alizarol
        End Get
        Set(ByVal value As Int32)
            _nr_alizarol = value
        End Set
    End Property
    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
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
    Public Property st_transmitido() As String
        Get
            Return _st_transmitido
        End Get
        Set(ByVal value As String)
            _st_transmitido = value
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
    Public Property ds_transportador() As String
        Get
            Return _ds_transportador
        End Get
        Set(ByVal value As String)
            _ds_transportador = value
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

    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Property ds_placa_julieta() As String
        Get
            Return _ds_placa_julieta
        End Get
        Set(ByVal value As String)
            _ds_placa_julieta = value
        End Set
    End Property

    Public Property cd_produtor() As String
        Get
            Return _cd_produtor
        End Get
        Set(ByVal value As String)
            _cd_produtor = value
        End Set
    End Property

    Public Property nm_produtor() As String
        Get
            Return _nm_produtor
        End Get
        Set(ByVal value As String)
            _nm_produtor = value
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

    Public Property nm_unid_producao() As String
        Get
            Return _nm_unid_producao
        End Get
        Set(ByVal value As String)
            _nm_unid_producao = value
        End Set
    End Property

    Public Property cd_propriedade_resfriador() As String
        Get
            Return _cd_propriedade_resfriador
        End Get
        Set(ByVal value As String)
            _cd_propriedade_resfriador = value
        End Set
    End Property

    Public Property dia_impar_par() As String
        Get
            Return _dia_impar_par
        End Get
        Set(ByVal value As String)
            _dia_impar_par = value
        End Set
    End Property

    Public Property st_leite_coletado() As String
        Get
            Return _st_leite_coletado
        End Get
        Set(ByVal value As String)
            _st_leite_coletado = value
        End Set
    End Property

    Public Property st_leite_desviado() As String
        Get
            Return _st_leite_desviado
        End Get
        Set(ByVal value As String)
            _st_leite_desviado = value
        End Set
    End Property

    Public Property st_volume_descartado() As String
        Get
            Return _st_volume_descartado
        End Get
        Set(ByVal value As String)
            _st_volume_descartado = value
        End Set
    End Property
    Public Property nr_volume() As Decimal
        Get
            Return _nr_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_volume = value
        End Set
    End Property
    Public Property id_coleta_veiculo() As Int32
        Get
            Return _id_coleta_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_coleta_veiculo = value
        End Set
    End Property
    Public Property cd_transportador2() As String
        Get
            Return _cd_transportador2
        End Get
        Set(ByVal value As String)
            _cd_transportador2 = value
        End Set
    End Property

    Public Property nm_transportador2() As String
        Get
            Return _nm_transportador2
        End Get
        Set(ByVal value As String)
            _nm_transportador2 = value
        End Set
    End Property
    Public Property currentidentity() As Int32
        Get
            Return _currentidentity
        End Get
        Set(ByVal value As Int32)
            _currentidentity = value
        End Set
    End Property
    Public Property id_protocolo() As Int32
        Get
            Return _id_protocolo
        End Get
        Set(ByVal value As Int32)
            _id_protocolo = value
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
    Public Property ds_placa_frete() As String
        Get
            Return _ds_placa_frete
        End Get
        Set(ByVal value As String)
            _ds_placa_frete = value
        End Set
    End Property
    Public Property id_nao_conformidade() As Int32
        Get
            Return _id_nao_conformidade
        End Get
        Set(ByVal value As Int32)
            _id_nao_conformidade = value
        End Set
    End Property
    Public Property id_coleta_nao_conformidade() As Int32
        Get
            Return _id_coleta_nao_conformidade
        End Get
        Set(ByVal value As Int32)
            _id_coleta_nao_conformidade = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.nr_caderneta = id
        loadCadernetaHeader()

    End Sub



    Public Sub New()

    End Sub


    Public Function getCadernetaHeaderByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCadernetasTransmitidas", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioCadernetaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneio_CadernetasTransmitidas", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getCadernetaColetasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCadernetasColetasTransmitidas", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getCadernetaPlacas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCadernetaPlacas", parameters, "ms_coleta_veiculos")
            Return dataSet

        End Using

    End Function
    Public Function getCadernetaPlacaFreteContingencia() As DataSet

        ' 21/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCadernetaPlacaFreteContingencia", parameters, "ms_coletas_frete_contingencia")
            Return dataSet

        End Using
        ' 21/09/2009 - Rls 21 - Frete - f

    End Function
    Private Sub loadCadernetaHeader()

        Dim dataSet As DataSet = getCadernetaHeaderByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function loadColetasContingencia() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_loadColetasContingencia", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getColetaLitrosContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetaLitrosContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getColetasContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetasContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function

    Public Function getRoteiroContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRoteiroContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getColetaHeaderContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetaHeaderContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function

    Public Function insertColetasContingencia() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Return CType(data.ExecuteScalar("ms_insertColetaLitros", parameters, ExecuteType.Insert), Int32)
            Return CType(data.ExecuteScalar("ms_insertColetaLitrosContingencia", parameters, ExecuteType.Insert), Int32)  ' 23/09/2009 - Frete

        End Using


    End Function
    Public Sub updateMotivoNaoColetaContingencia()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateMotivoNaoColetaContingencia", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetasContingenciaDataColeta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetasContingenciaDataColeta", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetasContingencia()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaLitrosContingencia", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteColetasContingencia()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetasContingencia", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub deleteCaderneta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCaderneta", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub transmitir()
        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)
            Dim li As Int32

            parameters = ParametersEngine.getParametersFromObject(Me)
            Dim dsRoteiro As New DataSet
            transacao.Fill(dsRoteiro, "ms_getRoteiroContingencia", parameters, "ms_coletas")

            For li = 0 To dsRoteiro.Tables(0).Rows.Count - 1

                Me.id_coleta = Convert.ToInt32(dsRoteiro.Tables(0).Rows(li).Item("id_coleta"))
                If IsDBNull(dsRoteiro.Tables(0).Rows(li).Item("id_motivo_nao_coleta")) Then
                    Me.st_leite_coletado = "S"
                    Me.id_motivo_nao_coleta = 0     ' 06/10/2008
                Else
                    Me.st_leite_coletado = "N"
                    Me.id_motivo_nao_coleta = Convert.ToInt32(dsRoteiro.Tables(0).Rows(li).Item("id_motivo_nao_coleta"))
                End If
                Me.st_leite_desviado = "N"
                Me.st_volume_descartado = "N"
                Me.id_situacao_coleta = 2  ' Transmitida

                Parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateColetasContingencia", parameters, ExecuteType.Update)

            Next

            transacao.Commit()

        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)

        End Try


    End Sub
    Public Function getColetaPendenteContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetaPendenteContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getRoteiroTransmitidoContingencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRoteiroTransmitidoContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function insertColetaNaoProgramadaContingencia() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetaNaoProgramadaContingencia", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getColetaNaoProgramadaContingencia() As DataSet

        ' 13/02/2009 - Rls16 Verifica se a propriedade/up já existe na caderneta - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetaNaoProgramadaContingencia", parameters, "ms_coletas")
            Return dataSet

        End Using
        ' 13/02/2009 - Rls16 - i

    End Function
    Public Function getCadernetaDifMenorColetaNow() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCadernetaDifMenorColetaNow", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCadernetaTotalLitros() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCadernetaTotalLitros", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Sub updateCadernetaPlacaFrete()

        ' 21/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCadernetaPlacaFrete", parameters, ExecuteType.Update)

        End Using
        ' 21/09/2009 - Rls 21 - Frete - f

    End Sub
    Public Function getColetasNaoConformidades() As DataSet

        ' 28/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetasNaoConformidades", parameters, "ms_coletas_nao_conformidades")
            Return dataSet

        End Using
        ' 28/09/2009 - Rls 21 - Frete - f

    End Function
    Public Sub deleteColetasNaoConformidades()

        ' 28/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetasNaoConformidades", parameters, ExecuteType.Delete)

        End Using
        ' 28/09/2009 - Rls 21 - Frete - f

    End Sub
    Public Function insertColetasNaoConformidades() As Int32

        ' 28/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetasNaoConformidades", parameters, ExecuteType.Insert), Int32)  ' 23/09/2009 - Frete

        End Using
        ' 28/09/2009 - Rls 21 - Frete - f

    End Function
    Public Sub updateColetasNaoConformidades()

        ' 28/09/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetasNaoConformidades", parameters, ExecuteType.Update)

        End Using
        ' 28/09/2009 - Rls 21 - Frete - f

    End Sub
    Public Function getCadernetaNovaPlaca() As DataSet

        ' 05/10/2009 - Rls 21 - Frete - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCadernetaNovaPlaca", parameters, "ms_coletas")
            Return dataSet

        End Using
        ' 21/09/2009 - Rls 21 - Frete - f

    End Function

End Class
