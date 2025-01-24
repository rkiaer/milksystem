<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_desconto_importar_excel.aspx.vb" Inherits="frm_frete_desconto_importar_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Resultado Importação Desconto Frete Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>

        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                    <asp:BoundField DataField="nr_linha" HeaderText="Nr Linha" SortExpression="nr_linha" >
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" >
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_valor_desconto" HeaderText="Vl Desconto" />
                    <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" />
                    <asp:BoundField DataField="ds_mes_ano_pagamento" HeaderText="M&#234;s/Ano Pagto" />
                    <asp:BoundField DataField="nm_erro" HeaderText="Observa&#231;&#227;o" SortExpression="nm_erro" />
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
