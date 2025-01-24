<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_kpi_custos_excel.aspx.vb" Inherits="frm_frete_kpi_custos_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Frete KPI - Custos</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView id="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" HorizontalAlign="Center">
            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="Gainsboro" ForeColor="Red" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
            <Columns>
                                <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MM/yyyy}" HeaderText="Refer&#234;ncia">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_densidade" DataFormatString="{0:N0}" HeaderText="Densidade">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_taxa_ocupacao" DataFormatString="{0:N2}" HeaderText="Tx.Ocupa&#231;&#227;o %">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_t1" DataFormatString="{0:N4}" HeaderText="Custo R$/L T1">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_t3" HeaderText="Custo R$/L T2TP" DataFormatString="{0:N4}">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_resfriamento" DataFormatString="{0:N4}" HeaderText="Resfriamento TP">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_t4" HeaderText="Custo R$/L T2 TVASE" DataFormatString="{0:N4}">
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
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
