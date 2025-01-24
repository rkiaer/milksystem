<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transferencia_volume_excel.aspx.vb" Inherits="frm_transferencia_volume_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Transferência de Volumesm - Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField HeaderText="Refer&#234;ncia" />
                <asp:BoundField DataField="estabelecimento_produtor" HeaderText="Estabel.Produtor" />
                <asp:BoundField DataField="Cd_Produtor" HeaderText="Cod_Produtor" SortExpression="Cd_Produtor" />
                <asp:BoundField DataField="Produtor" HeaderText="Produtor" SortExpression="Produtor" />
                <asp:BoundField DataField="id_propriedade" HeaderText="Cod_Propriedade" />
                <asp:BoundField DataField="nm_propriedade" HeaderText="Propriedade" />
                <asp:BoundField DataField="cd_inscricao_estadual" HeaderText="Inscri&#231;&#227;o Estadual" />
                <asp:BoundField DataField="nr_volume_anual_definitivo" HeaderText="Volume Anual" />
                <asp:BoundField DataField="nr_LITROS" HeaderText="Volume Aberto" />
                <asp:BoundField DataField="nr_volume_anual" HeaderText="Volume Anual Total" />
                <asp:BoundField HeaderText="C&#225;lculo Definitivo" />
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
