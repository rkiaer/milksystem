<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_central_KPI_excel.aspx.vb" Inherits="frm_relatorio_central_KPI_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório KPI Central</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="2"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" ReadOnly="True" />
                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" ReadOnly="True" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Parceiro" ReadOnly="True" />
                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" />
                <asp:BoundField HeaderText="Categoria" DataField="nm_categoria_item" ReadOnly="True" >
                </asp:BoundField>
                <asp:BoundField HeaderText="Canal" DataField="nm_canal" ReadOnly="True" />
<asp:TemplateField HeaderText="Quantidade">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_quantidade" runat="server"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_unidade_medida" HeaderText="Unid.Medida" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Total FOB">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_nf" runat="server" Text='<%# Bind("nr_valor_nota") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Frete">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_frete" runat="server"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total CIF">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_cif" runat="server"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_item" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_item" runat="server" Text='<%# Bind("id_item") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_produtor" runat="server" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
