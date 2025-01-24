<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_importar_pedido_excel.aspx.vb" Inherits="frm_importar_pedido_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Consistências Importação de Pedidos Fomento Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>

        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                                <asp:BoundField DataField="id_importacao" HeaderText="id_importacao" />
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP" />
                                                <asp:BoundField DataField="cd_fornecedor" HeaderText="C&#243;d.Fornec" />
                                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor" />
                                                <asp:BoundField DataField="nr_nota" HeaderText="Nota" />
                                                <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_nota" HeaderText="Vl Nota" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_pagto_fornecedor" HeaderText="Dt Pagto Fornec">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_desconto_produtor" HeaderText="Dt Desc Prod" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_central_pedido" HeaderText="Nr. Pedido"  />
                                                 <asp:BoundField DataField="dt_fim_execucao" HeaderText="Dt Importacao"  />
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
