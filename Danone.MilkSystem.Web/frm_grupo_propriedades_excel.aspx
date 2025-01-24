<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_grupo_propriedades_excel.aspx.vb" Inherits="frm_grupo_propriedades_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Grupo Matriz/Filial</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
            CellPadding="4" DataKeyNames="id_grupo_propriedades" Font-Names="Verdana" Font-Size="XX-Small"
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
                <asp:BoundField DataField="cd_pessoa_matriz" HeaderText="C&#243;d. Matriz" ReadOnly="True"
                    SortExpression="cd_pessoa_matriz" />
                <asp:BoundField DataField="nm_pessoa_matriz" HeaderText="Produtor Matriz" ReadOnly="True"
                    SortExpression="nm_pessoa_matriz" />
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" ReadOnly="True"
                    SortExpression="id_propriedade_matriz" />
                <asp:BoundField DataField="ds_tipo_propriedade" HeaderText="Tipo" />
                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d." ReadOnly="True" SortExpression="cd_pessoa" />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" SortExpression="nm_pessoa">
                    <headerstyle wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" />
                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o" SortExpression="ds_situacao" />
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
