<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_import_pedido.aspx.vb" Inherits="frm_relatorio_import_pedido" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Importação Pedidos Fomento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body  >
		<form id="Form1"  runat="server">
        <div id="rel_fisico_quimico">
            <table class="texto" width="100%">
                <tr>
                    <td width="10%" rowspan="3"><img  src="img/logo.gif"/></td>
                    <td align="center" class="texto" colspan="2" style="font-weight: bold; font-size: small;
                        font-variant: small-caps">
                        RELATÓRIO DE CONSISTÊNCIAS - IMPORTAÇÃO PEDIDOS FOMENTO</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2"></td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2"></td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px">
                                                    <FooterStyle  BackColor="WhiteSmoke" HorizontalAlign="Center" Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="id_importacao" HeaderText="Nr.Import" />
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" />
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP" />
                                                <asp:BoundField DataField="cd_fornecedor" HeaderText="C&#243;d.Fornec" />
                                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor" />
                                                <asp:BoundField DataField="nr_nota" HeaderText="Nota" />
                                                <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_nota" HeaderText="Vl Nota" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_pagto_fornecedor" HeaderText="Dt Pagto Fornec" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_desconto_produtor" HeaderText="Dt Desc Prod" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_erro" HeaderText="Observa&#231;&#227;o"  />
                  </Columns>
                                                    <RowStyle BackColor="White" />
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