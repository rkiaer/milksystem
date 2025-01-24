<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_relatorio_resultados_analitico_excel.aspx.vb" Inherits="frm_central_relatorio_resultados_analitico_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatorio Resultados Analitico Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" DataFormatString="{0:MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_propriedade_matriz" HeaderText="Prop. Matriz?">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="propriedade" HeaderText="Propriedade">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="T&#233;cnico">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volumemes" HeaderText="Volume M&#234;s" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Prop.M&#234;s" DataField="nr_qtde_propriedade_calculo" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_propriedade_spend_central" HeaderText="Prop.SpendCentral" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_desconto_central_calculo" HeaderText="Desc.Calculo?">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_tipo_parcelamento" HeaderText="Parcelamento">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_parcelas" HeaderText="Nr.Parcelas">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_pedido_indireto" HeaderText="Ped.Ind.">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Item">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tipo" HeaderText="Tipo">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_fornecedor_insumo" HeaderText="Fornecedor_Insumo">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nr.NF">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_inclusao_nota" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Inclus&#227;o">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_emissao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emiss&#227;o" />
                                                <asp:BoundField DataField="nr_quantidade" DataFormatString="{0:n2}" HeaderText="QtdePrevista" />
                                                <asp:BoundField DataField="nr_qtde_calculada" DataFormatString="{0:n2}" HeaderText="QtdeReal" />
                                                <asp:BoundField DataField="nr_unitario" DataFormatString="{0:n2}" HeaderText="Valor Unit&#225;rio" />
                                                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:n2}" HeaderText="Valor NF">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="menordata" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Pagto">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="valor_spend" HeaderText="Spend" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_item_milho" HeaderText="Milho" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_item_algodao" HeaderText="Farelo/Caro&#231;o Algod&#227;o" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_item_polpa" HeaderText="Polpa C&#237;trica" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_item_soja" HeaderText="Soja" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_item_casca" DataFormatString="{0:n2}" HeaderText="Casca" />
                                                <asp:BoundField DataField="nr_item_outros" HeaderText="Outros" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_tipo_fornecedor" HeaderText="TipoPedido">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="dt_referencia" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" Text='<%# Bind("dt_referencia") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
