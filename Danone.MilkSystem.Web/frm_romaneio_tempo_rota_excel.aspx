<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_tempo_rota_excel.aspx.vb" Inherits="frm_romaneio_tempo_rota_excel" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Tempo Rota</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
               <asp:BoundField DataField="ds_tipo_romaneio" HeaderText="Tipo Romaneio" />
                <asp:BoundField DataField="NM_LINHA" HeaderText="Rota/Coop" >
                </asp:BoundField>
                <asp:BoundField DataField="ROMANEIO" HeaderText="Romaneio" />
                 <asp:BoundField DataField="transitpoint" HeaderText="Transit Point" />
                <asp:BoundField DataField="transvase" HeaderText="Transvase" />
              <asp:BoundField DataField="STATUS" HeaderText="Status" />
                <asp:BoundField DataField="dt_transmissao" HeaderText="Dt Transmiss&#227;o" />
                <asp:BoundField DataField="hr_transmissao" HeaderText="Hor&#225;rio Trans." />
                <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" />
                <asp:BoundField DataField="hr_entrada" HeaderText="Hor&#225;rio Entr." />
                <asp:BoundField DataField="dt_saida" HeaderText="Dt Sa&#237;da" />
                <asp:BoundField DataField="hr_saida" HeaderText="Hor&#225;rio Sa&#237;da" />
                <asp:BoundField DataField="ds_tempo_patio" HeaderText="Tempo P&#225;tio" />
                <asp:BoundField DataField="ds_tempo_patio_externo" HeaderText="Tempo P&#225;tio Externo" />
                <asp:BoundField DataField="ds_tempo_rota" HeaderText="Tempo Rota" />
                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transportadora" />
                <asp:BoundField DataField="nm_transportador" HeaderText="Transportadora" />
                                                <asp:TemplateField HeaderText="ds_tempo_rota_minutos" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_ds_tempo_rota_minutos" runat="server" Text='<%# Bind("ds_tempo_rota_minutos") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>

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
