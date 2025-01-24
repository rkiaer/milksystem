<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_aplicacao_bonus_excel.aspx.vb" Inherits="lst_poupanca_aplicacao_bonus_excel" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Spend Produtores Excel</title>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" DataKeyNames="id_poupanca_adesao">
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="Estabelecimento">
                    <itemtemplate>
<asp:Label id="lbl_id_estabelecimento" runat="server" __designer:wfdid="w2" Text='<%# Bind("id_estabelecimento") %>'></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor"  />
                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" />
                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade"  />
                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" />
                <asp:BoundField DataField="dt_adesao" HeaderText="Ades&#227;o" />
                <asp:BoundField DataField="nr_tempo_adesao" HeaderText="Tempo Ades&#227;o" />
                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" />
                <asp:BoundField DataField="dt_ref_ini_calc" HeaderText="Ref. In&#237;cio" />
                <asp:TemplateField HeaderText="Volume Leite"><itemtemplate>
<anthem:Label id="lbl_nr_volume" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_valor_volume_leite") %>' __designer:wfdid="w20"></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Volume Leite Transfer&#234;ncia"><itemtemplate>
<anthem:Label id="lbl_nr_valor_volume_transferencia" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_volume_transferencia") %>'></anthem:Label>
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Volume Leite Total"><itemtemplate>
<anthem:Label id="lbl_nr_volume_total" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ></anthem:Label>
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Compras Central"><itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_compras_central" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_compras_central") %>'></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Compras Central Transferencia"><itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_compras_central_transferencia" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_compras_central_transferencia") %>'></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Compras Central Total"><itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_compras_central_total" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Valor B&#244;nus"><itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus_poupanca" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w3" Text='<%# bind("nr_valor_bonus_poupanca") %>'></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Valor B&#244;nus Transfer&#234;ncia"><itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus_transf" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w4" Text='<%# bind("nr_valor_bonus_transferencia") %>'></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Valor B&#244;nus Total"><itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w5"></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Spend" ><itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_spend" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("nr_valor_spend") %>'></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="%"><itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_bonus_extra_spend" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" Text='<%# bind("nr_bonus_extra_spend") %>' __designer:wfdid="w14"></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="B&#244;nus Extra"><itemtemplate>
<asp:Label id="lbl_valor_bonus_extra" runat="server" Text='<%# bind("nr_valor_bonus_extra") %>'></asp:Label>
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="B&#244;nus Central"><itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus_central" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w6"></anthem:Label> 
</itemtemplate></asp:TemplateField>
                <asp:BoundField DataField="nm_motivo_bonus_concessao" HeaderText="Motivo Concess&#227;o B&#244;nus Extra" />
                <asp:BoundField DataField="st_bonus_poupanca_central" HeaderText="Aplica&#231;&#227;o Bonus Central" />
                <asp:BoundField DataField="st_bonus_poupanca_lancamento" HeaderText="Aplica&#231;&#227;o Bonus Lan&#231;amento" />
                <asp:TemplateField HeaderText="dt_bonus_aplicacao" Visible="False"><itemtemplate>
<asp:Label id="lbl_dt_bonus_aplicacao" runat="server" Text='<%# Bind("dt_bonus_aplicacao") %>'></asp:Label>
</itemtemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="dt_ref_ini_calc" Visible="False"><itemtemplate>
<asp:Label id="lbl_dt_ref_ini_calc" runat="server" Text='<%# Bind("dt_ref_ini_calc") %>'></asp:Label>
</itemtemplate></asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </anthem:GridView>
        &nbsp;<cc2:alertmessages id="messageControl" runat="server"></cc2:alertmessages></div>
    </form>
</body>
</html>
