<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_fisicoquimica_excel.aspx.vb" Inherits="frm_relatorio_fisicoquimica_excel" %>

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
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" DataKeyNames="id_romaneio_compartimento,id_romaneio_placa">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                                <asp:BoundField DataField="nm_analista" HeaderText="Analista" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                <asp:BoundField DataField="nm_linha_cooperativa" HeaderText="Rota/Coop." />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" ReadOnly="True" />
                                <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                <asp:BoundField DataField="nr_total_litros" HeaderText="Volume Comp." />
                                <asp:BoundField DataField="ds_dt_hora_entrada_completa" HeaderText="Cheg." />
                                <asp:BoundField HeaderText="LIT" />
                                <asp:BoundField HeaderText="LIB" />
                                <asp:BoundField HeaderText="LIM" />
                                <asp:BoundField HeaderText="CEA" />
                                <asp:BoundField DataField="dt_inicio_analise" HeaderText="An&#225;lise" />
                                <asp:BoundField HeaderText="Dens(g/l)" />
                                <asp:BoundField HeaderText="MG(%)" />
                                <asp:BoundField HeaderText="PROT(%)" />
                                <asp:BoundField HeaderText="EST(%)" />
                                <asp:BoundField HeaderText="ESD(%)" />
                                <asp:BoundField HeaderText="&#193;cido L&#225;tico" />
                                 <asp:BoundField HeaderText="N.A." ReadOnly="True" />
                               <asp:BoundField HeaderText="Temp(oC)" />
                                <asp:BoundField HeaderText="Aliz78" />
                                <asp:BoundField HeaderText="Criosc." />
                                <asp:BoundField HeaderText="Snap" />
                                <asp:BoundField HeaderText="Charm" />
                                <asp:BoundField HeaderText="Redut &gt;=90mi" />
                                <asp:BoundField HeaderText="Peroxido" />
                                <asp:BoundField HeaderText="Fosfat." />
                                <asp:BoundField HeaderText="Cloreto" ReadOnly="True" />
                <asp:BoundField HeaderText="Lacres" />
                <asp:BoundField HeaderText="pH" />
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
