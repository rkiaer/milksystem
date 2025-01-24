<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_central_demonst_participacao_produtores.aspx.vb" Inherits="frm_relatorio_central_demonst_participacao_produtores" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Participação de Produtores</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="tudorel">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="2" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        Relatório Demonstrativo &nbsp;Participação Produtores</td>
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
                        &nbsp;
                        <anthem:GridView ID="gridresults" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small"
                            ForeColor="#333333" GridLines="None" PageSize="8" UpdateAfterCallBack="True"
                            Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="Silver" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="periodo" HeaderText="Per&#237;odo"  ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="Faturamento Prod." DataField="nr_faturamento_produtores" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                <asp:BoundField HeaderText="Volume Prod." DataField="nr_volume_produtores" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                <asp:BoundField HeaderText="N&#186; Prod." DataField="nr_produtores" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="N&#186; Prod. Educampo" DataField="nr_produtores_educampo" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="Prod. Central" DataField="nr_produtores_central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="Educampo Central" DataField="nr_educampo_central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="Compras Central" DataField="nr_compras_central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                <asp:BoundField HeaderText="Volume Central" DataField="nr_volume_central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
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