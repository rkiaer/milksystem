<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_ficha_relatorio_excel.aspx.vb" Inherits="frm_ficha_relatorio_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório de Ficha deCálculo Efetivo</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
            <Columns>
                    <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento"  />
                    <asp:BoundField DataField="cd_produtor" HeaderText="C&#243;d. Prod."  />
                    <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" />
                    <asp:BoundField DataField="nm_cluster" HeaderText="Mod. Relacionamento" />
                    <asp:BoundField DataField="ds_propriedade" HeaderText="Prop./UP"  />
                    <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;d. SAP" />
                    <asp:BoundField DataField="ds_relacionamento" HeaderText="Relacionamento"  />
                    <asp:BoundField DataField="id_propriedade_titular" HeaderText="Propriedade Titular"  />
                    <asp:BoundField DataField="nm_tecnico" HeaderText="EPL"  />
                    <asp:BoundField DataField="cd_contrato" HeaderText="C&#243;d. Contrato"  />
                    <asp:BoundField DataField="nm_contrato" HeaderText="Contrato"  />
                    <asp:BoundField DataField="dt_referencia" DataFormatString="{0:d}" HeaderText="Refer&#234;ncia" />
                    <asp:BoundField DataField="st_tipo_pagamento" HeaderText="Tipo Pagamento"  />
                    <asp:BoundField DataField="nr_volume_leite_nf" HeaderText="Volume Leite NF" />
                    <asp:BoundField DataField="nr_volume_leite_tabela" HeaderText="Volume Leite Tabela" />
                    <asp:BoundField DataField="nr_volume_leite_tabela_dia" HeaderText="Volume Leite Tabela Dia" />
                    <asp:BoundField DataField="nr_preco_negociado" HeaderText="Pre&#231;o Negociado" />
                    <asp:BoundField DataField="nr_preco_nota_fiscal" HeaderText="Pre&#231;o Nota Fiscal" />
                     <asp:BoundField DataField="nr_total_qualidade" HeaderText="Total Qualidade"  />
                    <asp:BoundField DataField="nr_proteina" HeaderText="B&#244;nus Prote&#237;na"  />
                    <asp:BoundField DataField="nr_mg" HeaderText="B&#244;nus MG"  />
                    <asp:BoundField DataField="nr_ctm" HeaderText="B&#244;nus CTM"  />
                   <asp:BoundField DataField="nr_ccs" HeaderText="B&#244;nus CCS" />
                    <asp:BoundField DataField="nr_teor_proteina" HeaderText="Teor Prote&#237;na"  />
                    <asp:BoundField DataField="nr_teor_mg" HeaderText="Teor MG"  />
                    <asp:BoundField DataField="nr_teor_ctm_trimestral" HeaderText="Teor CTM Trim."  />
                   <asp:BoundField DataField="nr_teor_ccs_trimestral" HeaderText="Teor CCS Trim." />
                    <asp:BoundField DataField="nr_teor_ctm_mensal" HeaderText="Teor CTM M&#234;s"  />
                   <asp:BoundField DataField="nr_teor_ccs_mensal" HeaderText="Teor CCS M&#234;s" />
                    <asp:BoundField DataField="nr_total_nota" HeaderText="Total Nota Fiscal" />
                    <asp:BoundField DataField="nr_volume_leite_propriedade" HeaderText="Volume Leite Propriedade"  />
                    <asp:BoundField DataField="nr_volume_leite_antecipacao" HeaderText="Volume Leite Antecipa&#231;&#227;o"  />
                    <asp:BoundField DataField="nr_antecipacao_bruto" HeaderText="Antecipa&#231;&#227;o Bruto"  />
                   <asp:BoundField DataField="nr_desconto_antecipacao" HeaderText="Desconto Antecipa&#231;&#227;o" />
                    <asp:BoundField DataField="nr_antecipacao" HeaderText="Antecipa&#231;&#227;o"  />
                   <asp:BoundField DataField="nr_antecipacao2" HeaderText="2a. Antecipa&#231;&#227;o" />
                    <asp:BoundField DataField="nr_adiantamento_quinzenal" HeaderText="Adiantamento Quinzenal" />
                    <asp:BoundField DataField="nr_desconto_clube_compras" HeaderText="Desconto Clube Compras" />
                    <asp:BoundField DataField="nr_adc_distancia" HeaderText="ADC Dist&#226;ncia"  />
                    <asp:BoundField DataField="nr_adc_crescimento" HeaderText="ADC Crescimento"  />
                    <asp:BoundField DataField="nr_bonus_poupanca_leite_mensal" HeaderText="B&#244;nus Poupan&#231;a Leite M&#234;s"  />
                   <asp:BoundField DataField="nr_bonus_poupanca_leite" HeaderText="B&#244;nus Poupan&#231;a Leite" />
                    <asp:BoundField DataField="nr_bonus_extra_poupanca_leite" HeaderText="B&#244;nus Extra Poupan&#231;a Leite"  />
                   <asp:BoundField DataField="nr_bonus_poupanca_leite2" HeaderText="2o. B&#244;nus Poupan&#231;a Leite" />
                    <asp:BoundField DataField="ds_compliance_proteina" HeaderText="Compl. Prote&#237;na" />
                    <asp:BoundField DataField="ds_compliance_mg" HeaderText="Compl. MG" />
                   <asp:BoundField DataField="ds_compliance_ctm" HeaderText="Compl. CTM" />
                    <asp:BoundField DataField="ds_compliance_ccs" HeaderText="Compl. CCS" />
                    <asp:BoundField DataField="ds_compliance_total" HeaderText="Compl. Total" />

           </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <cc1:AlertMessages ID="messageControl" runat="server"></cc1:AlertMessages>
    </div>
    </form>
</body>
</html>
