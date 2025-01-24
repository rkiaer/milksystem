<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_preco_negociado_excel.aspx.vb" Inherits="frm_preco_negociado_excel" %>

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
                    <asp:BoundField HeaderText="Produtor" DataField="ds_produtor"  />
                    <asp:BoundField HeaderText="Propriedade" DataField="id_propriedade"   />
                    <asp:BoundField DataField="nm_cluster" HeaderText="Cluster"   />
                    <asp:BoundField HeaderText="Volume" DataField="nr_total_volume"   />
                    <asp:BoundField HeaderText="Pre&#231;o M-1" DataField="nr_preco_mes_anterior"   />
                    <asp:BoundField HeaderText="Adic. Mercado" DataField="nr_adicional_mercado"  />
                    <asp:BoundField HeaderText="Pre&#231;o Obj" DataField="subtotal"  />
                    <asp:BoundField HeaderText="Negociado" DataField="nr_preco_negociado"  />
                    <asp:BoundField HeaderText="Varia&#231;&#227;o" DataField="variacao"  />
                    <asp:BoundField HeaderText="Justificativa" DataField="nm_preco_justificativa"  />
                    <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" />
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
