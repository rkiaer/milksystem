<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_relatorio_resumo_calculo.aspx.vb" Inherits="frm_relatorio_resumo_calculo" %>

    
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Relatório Resumo Cálculo</title>
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
                        RESUMO DO CÁLCULO</td>
                </tr>
                <tr>
                   <td align="center" class="texto" colspan="2">
                       Período:
                        <asp:Label ID="lbl_data_ini" runat="server" CssClass="texto" Font-Italic="True"  ></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="2" style="height: 14px"> </td>
                </tr>
                <tr>
                    <td align="center" class="texto" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="texto" colspan="3" style="height: 161px">
                                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px" ShowFooter="True">
                                                    <FooterStyle  BackColor="WhiteSmoke"  Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="T&#233;cnico" DataField="nm_tecnico" >
                                                            <headerstyle width="45mm" />
                                                            <itemstyle width="45mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="volumereal" HeaderText="Volume Real" >
                                                            <headerstyle width="20mm" />
                                                            <itemstyle width="20mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="negociado" HeaderText="Negociado" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="notafiscal" HeaderText="Nota Fiscal" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="incentivo" HeaderText="Incentivo" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="frete" HeaderText="Frete" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="totalqualidade" HeaderText="Qualidade" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Total" >
                                                            <headerstyle width="20mm" />
                                                            <itemstyle width="20mm" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle BackColor="White" />
                                                </anthem:GridView><anthem:GridView ID="gridCooperativa" runat="server" AutoGenerateColumns="False"  CellPadding="4" CssClass="texto" ForeColor="Black" UpdateAfterCallBack="True" UseAccessibleHeader="False" Width="100%" BackColor="White" Height="8px" ShowFooter="True" ShowHeader="False">
                                                    <FooterStyle  BackColor="WhiteSmoke"  Wrap="True" />
                                                    <PagerStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="T&#233;cnico" DataField="nm_tecnico" >
                                                            <headerstyle width="45mm" />
                                                            <itemstyle width="45mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="volumereal" HeaderText="Volume Real" >
                                                            <headerstyle width="20mm" />
                                                            <itemstyle width="20mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="negociado" HeaderText="Negociado" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="notafiscal" HeaderText="Nota Fiscal" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="incentivo" HeaderText="Incentivo" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="frete" HeaderText="Frete" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="totalqualidade" HeaderText="Qualidade" >
                                                            <headerstyle width="15mm" />
                                                            <itemstyle width="15mm" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Total" >
                                                            <headerstyle width="20mm" />
                                                            <itemstyle width="20mm" />
                                                        </asp:BoundField>
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