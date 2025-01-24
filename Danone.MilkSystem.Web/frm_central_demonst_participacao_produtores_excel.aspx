<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_demonst_participacao_produtores_excel.aspx.vb" Inherits="frm_central_demonst_participacao_produtores_excel" %>

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
                <asp:BoundField DataField="periodo" HeaderText="Per&#237;odo" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField HeaderText="Faturamento Prod." DataField="nr_faturamento_produtores"><itemstyle horizontalalign="Right" /></asp:BoundField>
                <asp:BoundField HeaderText="Volume Prod." DataField="nr_volume_produtores"><itemstyle horizontalalign="Right" /></asp:BoundField>
                <asp:BoundField HeaderText="N&#186; Prod." DataField="nr_produtores"><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField HeaderText="N&#186; Prod. Educampo" DataField="nr_produtores_educampo" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField HeaderText="Prod. Central" DataField="nr_produtores_central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField HeaderText="% Prod. Central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField DataField="nr_educampo_central" HeaderText="Educampo Central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField HeaderText="% Educampo Central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField DataField="nr_compras_central" HeaderText="Compras Central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                <asp:BoundField HeaderText="% Compras Central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                <asp:BoundField DataField="nr_volume_central" HeaderText="Volume Central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                <asp:BoundField HeaderText="% Volume Central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp; &nbsp; &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
