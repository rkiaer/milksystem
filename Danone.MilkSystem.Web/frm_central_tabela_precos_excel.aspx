<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_tabela_precos_excel.aspx.vb" Inherits="frm_central_tabela_precos_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="cd_fornecedor" HeaderText="Parceiro"  />
                <asp:BoundField DataField="nm_fornecedor" HeaderText="Nome Parceiro"  />
                <asp:BoundField DataField="cd_item" HeaderText="Item"  />
                <asp:BoundField DataField="nm_item" HeaderText="Nome Item"  />
                <asp:BoundField DataField="cd_unidade_medida" HeaderText="UN" />
                <asp:BoundField DataField="cd_uf_origem" HeaderText="UF Origem" />
                <asp:BoundField DataField="nm_cidade_origem" HeaderText="Cidade Origem" />
                <asp:BoundField DataField="cd_uf_destino" HeaderText="UF Destino" />
                <asp:BoundField DataField="nm_cidade_destino" HeaderText="Cidade Destino" />
                <asp:BoundField DataField="dt_cotacao" HeaderText="Data/Hora" />
                <asp:BoundField DataField="nr_valor" HeaderText="Valor" />
                <asp:BoundField DataField="nr_valor_sacaria" HeaderText="Valor Sacaria" />
                <asp:BoundField DataField="nr_valor_padrao" HeaderText="Valor Padr&#227;o" />
                <asp:BoundField DataField="cd_estabelecimento" HeaderText="Cod. Estabelecimento" />
                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Nome Estabelecimento" />
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
