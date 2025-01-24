<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_entrada_cooperativa_excel.aspx.vb" Inherits="frm_relatorio_entrada_cooperativa_excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório de Entrada de Cooperativas Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" Width="100%" ShowFooter="True" AutoGenerateColumns="False">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                    <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" SortExpression="fornecedor" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                    <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" SortExpression="dt_entrada" />
                    <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr Nota" >
                    </asp:BoundField>
                    <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" >
                    </asp:BoundField>
                    <asp:BoundField DataField="CFOP" HeaderText="CFOP" />
                    <asp:BoundField DataField="qtde" HeaderText="Qtde" />
                    <asp:BoundField DataField="vl_unit_nota" HeaderText="Vl Unit" />
                    <asp:BoundField DataField="vl_nota" HeaderText="Vl Nota" />
                    <asp:BoundField DataField="vl_unit_calc" HeaderText="Vl Unit Calc" />
                    <asp:BoundField HeaderText="Vl Quinz" DataField="nr_preco_negociado" />
                    <asp:BoundField DataField="valor_quinzena" HeaderText="Vl Quinz" />
                    <asp:BoundField DataField="diferenca" HeaderText="Diferen&#231;a" />
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
