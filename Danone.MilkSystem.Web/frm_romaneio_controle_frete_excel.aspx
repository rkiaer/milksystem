<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_controle_frete_excel.aspx.vb" Inherits="frm_romaneio_controle_frete_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Romaneios - Controle de Frete</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
               <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                <asp:BoundField DataField="rota" HeaderText="Rota/Coop" >
                </asp:BoundField>
                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                 <asp:BoundField DataField="id_transit_point" HeaderText="Transit Point" />
                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" />
               <asp:BoundField DataField="pre_romaneio" HeaderText="Pre Romaneio" />
                <asp:BoundField DataField="dt_entrada" HeaderText="Entrada" />
                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Entrada" />
                <asp:BoundField DataField="dt_saida" HeaderText="Sa&#237;da" />
                <asp:BoundField DataField="dt_hora_saida" HeaderText="Hr Sa&#237;da" />
                <asp:BoundField DataField="nr_pesagem_ini" HeaderText="Pesagem Inicial" />
                <asp:BoundField DataField="nr_pesagem_intermediaria" HeaderText="Pesagem Intermedi&#225;ria" />
                <asp:BoundField DataField="nr_pesagem_final" HeaderText="Pesagem Final" />
                <asp:BoundField DataField="nr_peso_liquido" HeaderText="Peso L&#237;quido" />
                <asp:BoundField DataField="volume" HeaderText="Volume" />
                 <asp:BoundField DataField="nr_km_coletor" HeaderText="KM Coletor" />
                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" />
                <asp:BoundField DataField="nm_divergencia_km_frete" HeaderText="Diverg&#234;ncia Frete" />
                <asp:BoundField DataField="nm_aprovacao_km_frete" HeaderText="Aprova&#231;&#227;o Frete" />
                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d.Transportador" />
                <asp:BoundField DataField="transportador" HeaderText="Transportador" />
                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Tipo Equipamento" />

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
