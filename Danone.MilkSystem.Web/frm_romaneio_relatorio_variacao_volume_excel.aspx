<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_relatorio_variacao_volume_excel.aspx.vb" Inherits="frm_romaneio_relatorio_variacao_volume_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Desvio de Variação de Volume</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False" CssClass="texto">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_produtor" HeaderText="Cod Produtor" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="prop" HeaderText="Propriedade" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Matriz?">
                                                    <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_dt_coleta" HeaderText="Data Coleta" DataFormatString="{0:dd/MM/yyyy}" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="totallitrosdataanterior" HeaderText="Litros &#218;lt. Coleta" DataFormatString="{0:N0}" >
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Litros Romaneio" DataField="totallitrosbyromaneio" DataFormatString="{0:N0}" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Litros Por Dia" DataField="totallitrosbydata" DataFormatString="{0:N0}" >
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                </asp:BoundField>
                <asp:BoundField DataField="nr_variacao" DataFormatString="{0:N2}" HeaderText="Desvio">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" >
                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Varia&#231;&#227;o" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_variacao" runat="server" Text='<%# Bind("nr_variacao", "{0:N2}") %>'></asp:Label>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>

            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <cc1:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
            UpdateAfterCallBack="True"></cc1:AlertMessages></div>
    </form>
</body>
</html>
