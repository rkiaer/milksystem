<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_controle_saida_excel.aspx.vb" Inherits="frm_romaneio_saida_controle_saida_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Romaneio Saída - Relatório Controle de Saída</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="id_romaneio_saida" HeaderText="Rom.Sa&#237;da" ReadOnly="True" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_romaneio_entrada" HeaderText="Rom.Origem">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy hh:mm}"  >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_hora_saida" DataFormatString="{0:dd/MM/yyyy hh:mm}" HeaderText="Sa&#237;da">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_destino" HeaderText="Destinat&#225;rio" >
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" >
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_tipo_operacao" HeaderText="Tipo Opera&#231;&#227;o" ReadOnly="True" >
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
               <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr NF" ReadOnly="True" >
                   <itemstyle horizontalalign="Center" />
               </asp:BoundField>
                <asp:BoundField DataField="nr_qtde_nf_anexo" HeaderText="Qtde" DataFormatString="{0:N0}" >
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_nf_anexo" HeaderText="Valor NF" DataFormatString="{0:N2}" >
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_motivo_saida" HeaderText="Motivo Sa&#237;da">
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador">
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_frete_nf" HeaderText="Frete">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_nota_fiscal_cte" HeaderText="Nr CTE">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_nota_fiscal_cte" DataFormatString="{0:N2}" HeaderText="Valor CTE">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                                                

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
