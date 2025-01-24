<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_Ficha_excel.aspx.vb" Inherits="frm_Ficha_excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="st_pagamento" HeaderText="Tipo C&#225;lculo" />
                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                <asp:BoundField DataField="nm_tecnico" HeaderText="Tecnico" />
                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                <asp:BoundField DataField="cd_contrato" HeaderText="Cod. Contrato" />
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop Matriz" />
                <asp:BoundField DataField="ds_relacionamento" HeaderText="Relacionamento" />
                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" />
                <asp:BoundField DataField="st_compartilha_qualidade" HeaderText="Compartilha Qualidade" />
                <asp:BoundField DataField="st_compartilha_volume" HeaderText="Compartilha Volume" />
                <asp:BoundField DataField="cd_conta" HeaderText="C&#243;digo" />
                <asp:BoundField DataField="nm_conta" HeaderText="Conta" />
                <asp:BoundField DataField="nm_abreviado_parceiro" HeaderText="Parceiro" />
                <asp:BoundField DataField="cd_transportador" HeaderText="Cod. Transp" />
                <asp:BoundField DataField="nm_transportador_abreviado" HeaderText="Transportador" />
                <asp:BoundField DataField="st_tipo_pagamento" HeaderText="Tp Pagto" />
                <asp:BoundField DataField="nr_valor_conta" HeaderText="Valor" />
                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" />
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
