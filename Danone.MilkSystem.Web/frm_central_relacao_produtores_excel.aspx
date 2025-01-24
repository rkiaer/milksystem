<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_relacao_produtores_excel.aspx.vb" Inherits="frm_central_relacao_produtores_excel" %>

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
                <asp:BoundField HeaderText="Estabelecimento" />
                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome"  >
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia">
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total Nota" DataField="nr_valor_total_nota" DataFormatString="{0:n2}" >
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_volume_leite" HeaderText="Volume Leite" DataFormatString="{0:n0}" >
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_valor_por_litros" DataFormatString="{0:n2}" HeaderText="R$/L">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total_compras_central" HeaderText="Compras Total" ReadOnly="True" DataFormatString="{0:n2}" >
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Spend R$/L" DataField="nr_spend" DataFormatString="{0:n4}" >
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_perc_utilizado_faturamento" DataFormatString="{0:n2}"
                    HeaderText="% Utiliz. X Fat.">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="id_estabelecimento" Visible="False">
                    <edititemtemplate>
    <asp:Label runat="server" Text='<%# Eval("id_estabelecimento") %>' id="Label1"></asp:Label>
    
</edititemtemplate>
                    <itemtemplate>
    <asp:Label id="lbl_id_estabelecimento" runat="server" Text='<%# Bind("id_estabelecimento") %>'></asp:Label>
    
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
