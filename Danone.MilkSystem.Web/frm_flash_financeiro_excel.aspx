<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_flash_financeiro_excel.aspx.vb" Inherits="frm_flash_financeiro_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Flash Financeiro</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    <table runat="server" id="tb_header" width="100%">
    <tr>
        <td style="height: 19px; font-weight: bold; color: white; background-color: #006699;" align="center">
            <anthem:Label ID="lbl_flash" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">FLASH FINANCEIRO 2020</anthem:Label>
    </td></tr></table>
                        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="3"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <Columns>
                                <asp:BoundField DataField="ds_descricao_conta" ShowHeader="False" />
                                <asp:BoundField DataField="nr_valor_1" HeaderText="Janeiro" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_2" HeaderText="Fevereiro" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_3" HeaderText="Mar&#231;o" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_4" HeaderText="Abril" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Maio" ReadOnly="True" DataField="nr_valor_5" >
                                    <itemstyle wrap="False" horizontalalign="Right" font-italic="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_6" HeaderText="Junho">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_7" HeaderText="Julho">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_8" HeaderText="Agosto">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_9" HeaderText="Setembro">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_10" HeaderText="Outubro">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_11" HeaderText="Novembro">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_12" HeaderText="Dezembro">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_mes_provisorio" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_mes_provisorio" runat="server" Text='<%# Bind("nr_mes_provisorio") %>' __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_conta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_conta" runat="server" Text='<%# Bind("id_conta") %>' __designer:wfdid="w12"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_ordem" HeaderText="nr_ordem" ReadOnly="True" Visible="False" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="White" ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" /><HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Left" ForeColor="#000066" />
                                        </anthem:GridView>
           &nbsp;<br />
        <anthem:Label runat="server" ID="lbl_informativo"  AutoUpdateAfterCallBack="True"
            CssClass="Texto" Font-Italic="True" Font-Size="X-Small" ForeColor="Blue" Height="16px"
            UpdateAfterCallBack="True" Visible="False">*Mês em destaque indicando PAGAMENTO PROVISÓRIO. Sujeito à alterações no fechamento de cálculo.</anthem:Label>
        &nbsp;<br />
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
