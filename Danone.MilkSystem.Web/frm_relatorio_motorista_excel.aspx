<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_motorista_excel.aspx.vb" Inherits="frm_relatorio_motorista_excel" %>

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
            ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                                        <asp:BoundField DataField="dt_hora_entrada" HeaderText="Data/Hora Entrada" />
                                                        <asp:BoundField DataField="id_linha" HeaderText="Rota" />
                                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                        <asp:BoundField DataField="nm_motorista" HeaderText="Motorista" />
                                                        <asp:BoundField DataField="cd_cnh" HeaderText="CNH" />
                                                        <asp:BoundField DataField="st_categoria_cnh" HeaderText="Categ." />
                                                        <asp:BoundField DataField="dt_validade_cnh" HeaderText="Validade" />
                                                        <asp:BoundField DataField="dt_nascimento" HeaderText="Nascimento" />
                                                        <asp:BoundField DataField="cd_rg" HeaderText="RG" />
                                                        <asp:BoundField DataField="cd_cpf" HeaderText="CPF" />
                                                        <asp:BoundField DataField="ds_transportador" HeaderText="Transportadora" />
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
