<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_usuario_excel.aspx.vb" Inherits="frm_usuario_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Usuários</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small"
            ForeColor="#333333" GridLines="None" PageSize="15" UpdateAfterCallBack="True"
            Width="100%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                ForeColor="White" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nm_usuario" HeaderText="Usu&#225;rio" ReadOnly="True" />
                <asp:BoundField DataField="ds_login" HeaderText="Login" />
                <asp:BoundField DataField="nm_tipo_usuario" HeaderText="Tipo" />
                <asp:BoundField DataField="dt_criacao" HeaderText="Cria&#231;&#227;o" />
                <asp:BoundField DataField="dt_modificacao" HeaderText="Modifica&#231;&#227;o">
                </asp:BoundField>
                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
            </Columns>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <RowStyle BackColor="#EFF3FB" />
        </anthem:GridView>
        &nbsp; &nbsp;<br />
        <cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages>&nbsp;
    </div>
    </form>
</body>
</html>
