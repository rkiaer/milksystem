<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_entrada_cooperativa_notas_excel.aspx.vb" Inherits="frm_relatorio_entrada_cooperativa_notas_excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório de Entrada de Cooperativas Notas Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                    <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabel." >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d.Transportador"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dt_entrada_romaneio" HeaderText="Entrada" DataFormatString="{0:MM/yyyy}" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dt_saida_romaneio" HeaderText="Sa&#237;da" DataFormatString="{0:MM/yyyy}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Cooperativa"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa" >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cd_cnpj" HeaderText="CNPJ"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_item" HeaderText="Item" >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_peso_liquido_romaneio" HeaderText="Peso L&#237;q. Rom." DataFormatString="{0:n0}" >
                        <headerstyle wrap="False" horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_peso_liquido_nota" HeaderText="Peso L&#237;q. NF" DataFormatString="{0:n0}" >
                        <headerstyle wrap="False" horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="valor_nota_fiscal" HeaderText="Valor NF" DataFormatString="{0:n2}" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_tipo_nota_fiscal" HeaderText="Tipo NF"  >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cd_natureza_operacao" HeaderText="CFOP"  >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_natureza_operacao" HeaderText="Nome Natureza Opera&#231;&#227;o"  >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr NF" DataFormatString="{0:n0}" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_serie" HeaderText="Nr S&#233;rie"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dt_emissao_nota" HeaderText="Emiss&#227;o NF" DataFormatString="{0:MM/yyyy}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dt_transacao_nota" HeaderText="Transa&#231;&#227;o NF" DataFormatString="{0:MM/yyyy}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dt_saida_nota" HeaderText="Sa&#237;da NF" DataFormatString="{0:MM/yyyy}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_chave_nfe" HeaderText="Chave NFE"  >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="valor_icms" HeaderText="Valor ICMS"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_po_cooperativa" HeaderText="Nr. PO" >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nm_frete_nf" HeaderText="Frete NF" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_cte" HeaderText="Nr CTE" >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_valor_cte" HeaderText="Valor CTE" DataFormatString="{0:n2}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_chave_cte" HeaderText="Chave CTE"  >
                        <headerstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="tipo_2a_nota_fiscal" HeaderText="Tipo 2a. NF"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_nota_fiscal2" HeaderText="Nr 2a. NF" DataFormatString="{0:n0}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_serie_nota_fiscal2" HeaderText="S&#233;rie 2a. NF"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_litros_nota_fiscal2" HeaderText="Litros 2a NF" DataFormatString="{0:n0}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_valor_nota_fiscal2" HeaderText="Valor 2a. NF" DataFormatString="{0:n2}"  >
                        <headerstyle horizontalalign="Center" />
                        <itemstyle horizontalalign="Right" />
                    </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
