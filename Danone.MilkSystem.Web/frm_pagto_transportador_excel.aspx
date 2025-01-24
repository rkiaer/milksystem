<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pagto_transportador_excel.aspx.vb" Inherits="frm_pagto_transportador_excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Pagamentos de Frete ao Transportador - Versão Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod.Transportador" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Transportador" />
                <asp:BoundField DataField="dt_pagto" HeaderText="Data Pagto" />
                <asp:BoundField DataField="dt_emissao" HeaderText="Data Emiss&#227;o" />
                <asp:BoundField DataField="nr_valor_frete" HeaderText="Vl Pagto" />
                <asp:BoundField DataField="cd_codigo_sap" HeaderText="Cod. SAP" />
                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                <asp:BoundField DataField="st_exportacao" HeaderText="Exportado" />
                <asp:BoundField DataField="dt_exportacao" HeaderText="Data Exporta&#231;&#227;o" />
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
