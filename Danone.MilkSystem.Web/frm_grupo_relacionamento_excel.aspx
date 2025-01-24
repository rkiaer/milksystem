<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_grupo_relacionamento_excel.aspx.vb" Inherits="frm_grupo_relacionamento_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Grupo de Relacionamento - Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="cd_pessoa_titular" HeaderText="C&#243;d. Titular" />
                <asp:BoundField DataField="nm_pessoa_titular" HeaderText="Produtor Titular" />
                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop.Titular" />
                <asp:BoundField DataField="ds_relacionamento" HeaderText="Relacionamento" />
                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d." />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor"/>
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                <asp:BoundField DataField="st_compartilha_qualidade" HeaderText="Comp. Qualidade" />
                <asp:BoundField DataField="st_compartilha_volume" HeaderText="Comp. Volume" />
                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o"  />

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
