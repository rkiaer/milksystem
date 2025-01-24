<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_linha_exportar.aspx.vb" Inherits="frm_linha_exportar" %>

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
                    <asp:BoundField HeaderText="cod_site" DataField="cod_propriedade_up"  />
                    <asp:BoundField HeaderText="cod_categ_p"   />
                <asp:TemplateField HeaderText="cod_categ_h">
                    <ItemTemplate>
                        <asp:Label ID="lbl_horario" runat="server" Text='<%# "00:00-23:59" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="nm_pessoa" HeaderText="libelle"   />
                    <asp:BoundField HeaderText="adresse"   />
                    <asp:BoundField HeaderText="ville" DataField="nm_cidade"  />
                    <asp:BoundField HeaderText="postal"  />
                    <asp:BoundField HeaderText="pays"   />
                    <asp:BoundField HeaderText="telephone"  />
                    <asp:BoundField HeaderText="commentaire" DataField="nm_tecnico"   />
                <asp:TemplateField HeaderText="entrepot">
                    <ItemTemplate>
                        <asp:Label ID="lbl_entrepot" runat="server" Text='<%# "N" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField HeaderText="cod_loca"  />
                    <asp:BoundField HeaderText="cod_noeud" />
                    <asp:BoundField DataField="nr_longitude" HeaderText="coordY (Longitude)"  />
                    <asp:BoundField DataField="nr_latitude" HeaderText="coordx (lat)"   />
                <asp:BoundField HeaderText="transit" />
                <asp:BoundField HeaderText="cod_groupe" />
                <asp:BoundField HeaderText="zone_dtr" />
                <asp:BoundField HeaderText="codarc" />
                <asp:BoundField HeaderText="pourcent" />
                <asp:BoundField HeaderText="bascule" />
                <asp:BoundField HeaderText="cod_bascule" />

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
