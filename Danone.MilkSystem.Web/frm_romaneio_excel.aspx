<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_excel.aspx.vb" Inherits="frm_romaneio_excel" %>

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
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" />
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" SortExpression="nm_tecnico" >
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="EduCampo" DataField="nm_tecnico_educampo" />
                                                <asp:BoundField HeaderText="Cluster" DataField="nm_cluster" />
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod Produtor" />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop. Matriz" />
                                                <asp:BoundField DataField="ds_data_coleta" HeaderText="Data Coleta" />
                                                <asp:BoundField DataField="Litros" HeaderText="Litros" >
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Leite" DataField="ds_status_analise_uproducao" />
                                                <asp:BoundField HeaderText="Rejei&#231;&#227;o Antib." DataField="st_antibiotico" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" />
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
