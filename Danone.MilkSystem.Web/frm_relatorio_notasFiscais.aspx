<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_notasFiscais.aspx.vb" Inherits="frm_relatorio_notasFiscais" %>

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
                                                 <asp:BoundField DataField="Emitente" HeaderText="Emitente" SortExpression="Emitente" />
                                                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                                                <asp:BoundField DataField="cd_cpf_cnpj" HeaderText="CPF/CNPJ" />
                                                <asp:BoundField DataField="Estabelecimento" HeaderText="Estabel" SortExpression="Estabelecimento" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fabrica" HeaderText="Fabrica" SortExpression="Fabrica" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NF" HeaderText="Nota Fiscal" SortExpression="NF" />
                                                <asp:BoundField DataField="dt_emissao" HeaderText="Dt Emiss&#227;o" SortExpression="dt_emissao" />
                                                <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" SortExpression="dt_entrada" />
                                                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
                                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                                                <asp:BoundField DataField="Unitario" HeaderText="Unitario" SortExpression="Unitario" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                <asp:BoundField HeaderText="Varia&#231;&#227;o" />
                                                <asp:BoundField DataField="nr_valor_icms" HeaderText="Valor ICMS" />
                                                <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_romaneio" runat="server" Text='<%# Bind("id_romaneio") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="diferenca_pesagem" Visible="False">
                                                    <itemtemplate>
<asp:Label id="diferenca_pesagem" runat="server" Text='<%# Bind("diferenca_pesagem") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
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
