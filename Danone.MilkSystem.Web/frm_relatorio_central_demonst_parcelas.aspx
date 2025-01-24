<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_central_demonst_parcelas.aspx.vb" Inherits="frm_relatorio_central_demonst_parcelas" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Motoristas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="2" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        Demonstrativo Parcelamento Central Compras</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana"
                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" PageSize="8" UpdateAfterCallBack="True"
                            Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_parceiro" HeaderText="C&#243;d Parceiro Central" SortExpression="cd_parceiro" />
                                <asp:BoundField DataField="nm_parceiro" HeaderText="Parceiro Central" />
                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor" />
                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome Produtor" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="nm_tecnico" HeaderText="Tecnico" />
                                <asp:BoundField DataField="id_central_pedido" HeaderText="N. Pedido" />
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nota Fiscal" />
                                <asp:BoundField DataField="nr_valor_nota_fiscal" HeaderText="Valor Total" />
                                <asp:BoundField DataField="dt_pagto" HeaderText="Vencimento" Visible="False" />
                                <asp:BoundField DataField="nr_parcela" HeaderText="Parcela" />
                                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parcela" />
                                <asp:BoundField DataField="nr_saldo" HeaderText="Saldo" />
                                <asp:TemplateField HeaderText="dt_pagto" Visible="False">
                                    <itemtemplate>
<asp:Label id="dt_pagto" runat="server" Text='<%# Bind("dt_pagto") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        <br />
            <!--<div id="corpo" style="text-align:center;vertical-align:top;">-->
                &nbsp;
            <cc7:AlertMessages ID="messagecontrol" runat="server"></cc7:AlertMessages></div>
     <!--</div>-->
     </form>
	</body>
</HTML>