<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_excel.aspx.vb" Inherits="frm_central_pedido_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" />
                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Nome" />
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                <asp:BoundField HeaderText="Pedido" DataField="id_central_pedido" />
                <asp:BoundField HeaderText="Pedido Origem" DataField="id_central_pedido_origem" />
                <asp:BoundField HeaderText="Prop. Origem" DataField="id_propriedade_origem" />
                <asp:BoundField DataField="cd_fornecedor" HeaderText="Parceiro"/>
                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Nome" />
                <asp:BoundField HeaderText="Data" DataField="dt_pedido" />
                <asp:BoundField HeaderText="Item" DataField="cd_item" />
                <asp:BoundField HeaderText="Descri&#231;&#227;o" DataField="nm_item" />
                <asp:BoundField HeaderText="Embalagem" DataField="ds_tipo_medida"/>
                <asp:BoundField HeaderText="Qtde" DataField="nr_quantidade" />
                <asp:BoundField HeaderText="Vl Unit." DataField="nr_valor_unitario" />
                <asp:BoundField HeaderText="Valor Total" DataField="nr_valor_total" />
                <asp:BoundField HeaderText="Parcelamento" DataField="st_parcelamento"/>
                <asp:BoundField HeaderText="Parcelas" DataField="nr_parcelas"/>
                <asp:BoundField HeaderText="Entrega" SortExpression="dt_entrega"/>
                <asp:BoundField HeaderText="Situa&#231;&#227;o" DataField="nm_situacao_pedido" />
                <asp:BoundField HeaderText="id_central_pedido_item" DataField="id_central_pedido_item" Visible="False" />
                <asp:BoundField HeaderText="nr_frete" DataField="nr_frete" Visible="False" />
                <asp:BoundField HeaderText="id_grupo" DataField="id_grupo_fornecedor" Visible="False" />
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
