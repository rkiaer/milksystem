<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_conciliacao_sintetico_excel.aspx.vb" Inherits="frm_central_conciliacao_sintetico_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório de Apoio Contabilidade</title>
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
                                <asp:BoundField DataField="dt_referencia" HeaderText="Per&#237;odo" DataFormatString="{0:MMM/yyyy}" >
                                    <headerstyle backcolor="Black" />
                                    <itemstyle wrap="False" backcolor="CornflowerBlue" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_debito" HeaderText="D&#233;bito" DataFormatString="{0:c2}" >
                                    <headerstyle backcolor="Black" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_credito" HeaderText="Cr&#233;dito" DataFormatString="{0:c2}" >
                                    <headerstyle backcolor="Black" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_saldo" HeaderText="Saldo" DataFormatString="{0:c2}" >
                                    <headerstyle backcolor="Black" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_saldoacumulado" HeaderText="Saldo Acumulado" DataFormatString="{0:c2}" >
                                    <headerstyle backcolor="Black" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_saldoinicialconta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_saldoinicialconta" runat="server" Text='<%# Bind("nr_saldoinicialconta") %>'></asp:Label>
</itemtemplate>
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
