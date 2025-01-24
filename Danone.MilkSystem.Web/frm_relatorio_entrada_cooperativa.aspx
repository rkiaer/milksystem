<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_entrada_cooperativa.aspx.vb" Inherits="frm_relatorio_entrada_cooperativa" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório de Entrada de Cooperativas</title>
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
                        RELATÓRIO ENTRADA DE COOPERATIVAS</td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2"><asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">Período:
                        <asp:Label ID="lbl_data_ini" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>
                        à <asp:Label ID="lbl_data_fim" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>
                    </td>
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
                                                        <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor"  />
                                                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                                        <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" />
                                                        <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr Nota" ></asp:BoundField>
                                                        <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" ></asp:BoundField>
                                                        <asp:BoundField DataField="CFOP" HeaderText="CFOP" />
                                                        <asp:BoundField DataField="qtde" HeaderText="Qtde" />
                                                        <asp:BoundField DataField="vl_unit_nota" HeaderText="Vl Unit" />
                                                        <asp:BoundField DataField="vl_nota" HeaderText="Vl Nota" />
                                                        <asp:BoundField DataField="vl_unit_calc" HeaderText="Vl Unit Calc" />
                                                        <asp:BoundField HeaderText="Vl Quinz" DataField="nr_preco_negociado" />
                                                        <asp:BoundField DataField="valor_quinzena" HeaderText="Vl Quinz" />
                                                        <asp:BoundField DataField="diferenca" HeaderText="Diferen&#231;a" />
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