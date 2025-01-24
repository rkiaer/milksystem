<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_relatorio_resultados_excel.aspx.vb" Inherits="frm_central_relatorio_resultados_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Spend Produtores Excel</title>
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
                                                <asp:BoundField DataField="nr_spend" HeaderText="Spend" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume" HeaderText="Volume" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volumecentral" HeaderText="Volume Central" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volumecentral_percent" HeaderText="% Volume" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Prop. DAL" DataField="nr_qtde_propriedade" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_propriedade_central" HeaderText="Prop. Central" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% Prop." DataField="nr_qtdecentral_percent" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_milho" HeaderText="Milho/Fuba" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_milho" DataFormatString="{0:N4}" HeaderText="Qtde Milho/Fuba">
                                                    <headerstyle wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_algodao" HeaderText="Farelo/Caro&#231;o Algod&#227;o" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_algodao" DataFormatString="{0:N4}" HeaderText="Qtde Farelo/Caro&#231;o Algod&#227;o">
                                                    <headerstyle wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_polpacitrica" HeaderText="Polpa C&#237;trica" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_polpacitrica" DataFormatString="{0:N4}" HeaderText="Qtde Polpa C&#237;trica">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_soja" HeaderText="Soja" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_soja" DataFormatString="{0:N4}" HeaderText="Qtde Soja">
                                                    <headerstyle wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_casca" DataFormatString="{0:n2}" HeaderText="Casca" />
                                                <asp:BoundField DataField="nr_qtde_casca" DataFormatString="{0:N4}" HeaderText="Qtde Casca Soja">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_outros" HeaderText="Outros" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Total Descontos">
                                                    <itemtemplate>
<anthem:Label id="lbl_total_desconto" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True"></anthem:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Pagtos">
                                                    <itemtemplate>
<anthem:Label id="lbl_total_pagto" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True"></anthem:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_referencia" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" Text='<%# Bind("dt_referencia") %>'></asp:Label>
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
