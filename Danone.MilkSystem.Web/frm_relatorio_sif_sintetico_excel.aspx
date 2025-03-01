<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_sif_sintetico_excel.aspx.vb" Inherits="frm_relatorio_sif_sintetico_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>REPORT SIF - Sintético</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResultsSintetico" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="15"
            UpdateAfterCallBack="True">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Refer&#234;ncia">
                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" __designer:wfdid="w17"></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cd_uf" HeaderText="UF">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nm_cidade" HeaderText="Cidade">
                    <headerstyle horizontalalign="Left" />
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_produtores" HeaderText="Total Produtores">
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Total Volume">
                    <itemtemplate>
<asp:Label id="lbl_nr_volume" runat="server" __designer:wfdid="w18" Text='<%# Bind("nr_volume") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" />
                    <itemstyle font-italic="False" horizontalalign="Center" wrap="False" />
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        &nbsp;
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
