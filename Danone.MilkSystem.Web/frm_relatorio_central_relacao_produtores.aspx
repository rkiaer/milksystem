<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_central_relacao_produtores.aspx.vb" Inherits="frm_relatorio_central_relacao_produtores" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Spend Produtores</title>
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
                        Relatório Spend Produtores</td>
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
                                <asp:BoundField HeaderText="Estab." />
                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" />
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Nome" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." />
                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" />
                                <asp:BoundField DataField="nr_valor_total_nota" HeaderText="Total Nota" />
                                <asp:BoundField DataField="nr_volume_leite" HeaderText="Volume Leite" />
                                <asp:BoundField DataField="nr_total_compras_central" HeaderText="Compras Total" />
                                <asp:BoundField HeaderText="Spend R$/L" DataField="nr_spend" />
                                <asp:TemplateField HeaderText="lbl_id_estabelecimento" Visible="False">
                                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("id_estabelecimento") %>' id="Label1"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_estabelecimento" runat="server" Text='<%# Bind("id_estabelecimento") %>' __designer:wfdid="w43"></asp:Label>
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