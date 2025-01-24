<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_custo_financeiro_flash_excel.aspx.vb" Inherits="frm_custo_financeiro_flash_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo Financeiro Relatorio</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridVolume" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="50" UpdateAfterCallBack="True"
            Visible="False" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField ShowHeader="False" />
                <asp:BoundField DataField="ds_descricao" HeaderText="Volumes por Cluster" ReadOnly="True">
                    <itemstyle width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="mes1" DataFormatString="{0:N0}" HeaderText="JAN">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes2" DataFormatString="{0:N0}" HeaderText="FEV">
                    <headerstyle wrap="True" />
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes3" DataFormatString="{0:N0}" HeaderText="MAR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes4" DataFormatString="{0:N0}" HeaderText="ABR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes5" DataFormatString="{0:N0}" HeaderText="MAI" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes6" DataFormatString="{0:N0}" HeaderText="JUN">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes7" DataFormatString="{0:N0}" HeaderText="JUL">
                    <itemstyle font-bold="False" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes8" DataFormatString="{0:N0}" HeaderText="AGO">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes9" DataFormatString="{0:N0}" HeaderText="SET">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes10" DataFormatString="{0:N0}" HeaderText="OUT" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes11" DataFormatString="{0:N0}" HeaderText="NOV">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes12" DataFormatString="{0:N0}" HeaderText="DEZ">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_total" DataFormatString="{0:N0}" HeaderText="Total"
                    Visible="False">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("Seq") %>' __designer:wfdid="w47"></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="70" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="ds_cluster" HeaderText="cluster" ShowHeader="False">
                    <itemstyle horizontalalign="Center" width="9%" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_descricao" HeaderText="Composi&#231;&#227;o do Pre&#231;o"
                    ReadOnly="True">
                    <itemstyle width="11%" wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="mes1" DataFormatString="{0:N4}" HeaderText="JAN">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes2" DataFormatString="{0:N4}" HeaderText="FEV">
                    <headerstyle wrap="True" />
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes3" DataFormatString="{0:N4}" HeaderText="MAR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes4" DataFormatString="{0:N4}" HeaderText="ABR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes5" DataFormatString="{0:N4}" HeaderText="MAI" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes6" DataFormatString="{0:N4}" HeaderText="JUN">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes7" DataFormatString="{0:N4}" HeaderText="JUL">
                    <itemstyle font-bold="False" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes8" DataFormatString="{0:N4}" HeaderText="AGO">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes9" DataFormatString="{0:N4}" HeaderText="SET">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes10" DataFormatString="{0:N4}" HeaderText="OUT" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes11" DataFormatString="{0:N4}" HeaderText="NOV">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes12" DataFormatString="{0:N4}" HeaderText="DEZ">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataFormatString="{0:N0}" HeaderText="Total" Visible="False">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="seq" ShowHeader="False" Visible="False">
                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>'></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        <br />
        <anthem:GridView ID="gridOutrosCustos" runat="server" AutoGenerateColumns="False"
            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="50"
            UpdateAfterCallBack="True" Width="100%">
            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField ShowHeader="False" />
                <asp:BoundField DataField="ds_descricao" HeaderText="Outros Custos" ReadOnly="True">
                    <headerstyle font-bold="True" font-size="X-Small" />
                    <itemstyle width="20%" wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="mes1" DataFormatString="{0:N4}" HeaderText="JAN">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes2" DataFormatString="{0:N4}" HeaderText="FEV">
                    <headerstyle wrap="True" />
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes3" DataFormatString="{0:N4}" HeaderText="MAR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes4" DataFormatString="{0:N4}" HeaderText="ABR">
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes5" DataFormatString="{0:N4}" HeaderText="MAI" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes6" DataFormatString="{0:N4}" HeaderText="JUN">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes7" DataFormatString="{0:N4}" HeaderText="JUL">
                    <itemstyle font-bold="False" horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="mes8" DataFormatString="{0:N4}" HeaderText="AGO">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes9" DataFormatString="{0:N4}" HeaderText="SET">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes10" DataFormatString="{0:N4}" HeaderText="OUT" ReadOnly="True">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes11" DataFormatString="{0:N4}" HeaderText="NOV">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="mes12" DataFormatString="{0:N4}" HeaderText="DEZ">
                    <itemstyle horizontalalign="Right" wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="seq" Visible="False">
                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
        </anthem:GridView>
        &nbsp; &nbsp;

        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
