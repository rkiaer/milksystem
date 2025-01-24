<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_demonst_parcelas_excel.aspx.vb" Inherits="frm_central_demonst_parcelas_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>frm_central_demonst_parcelas_excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="cd_parceiro" HeaderText="C&#243;d Parceiro Central" SortExpression="cd_parceiro" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_parceiro" HeaderText="Parceiro Central" SortExpression="nm_parceiro" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d. Produtor" SortExpression="cd_pessoa" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome Produtor" SortExpression="nm_pessoa" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_central_pedido" HeaderText="N. Pedido" SortExpression="id_central_pedido" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="N. NF" SortExpression="nr_nota_fiscal" DataFormatString="{0:n0}" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_nota_fiscal" HeaderText="Valor Total" SortExpression="nr_valor_nota_fiscal" DataFormatString="{0:n2}" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_pagto" HeaderText="Dt Pagto" SortExpression="dt_pagto" DataFormatString="{0:d}" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_parcela" HeaderText="Parcela" SortExpression="nr_parcela" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parcela" SortExpression="nr_valor_parcela" DataFormatString="{0:n2}" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="C&#225;lculo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_st_calculo" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="dt_pagto" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="dt_pagto" runat="server" Text='<%# Bind("dt_pagto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="id_ficha_financeira_calc" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lbl_calculo" runat="server" Text='<%# Bind("id_ficha_financeira_calc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
