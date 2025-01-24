<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_custo_financeiro_calculo.aspx.vb" Inherits="lst_custo_financeiro_calculo" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html >
<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Custo Financeiro - Cálculo</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); height: 21px;"><STRONG>Custo Financeiro - Cálculo Projetado</STRONG></TD>
					<TD width="9px" >&nbsp;</TD>
				</TR>
											<TR>
						<TD style="width: 9px" ></TD>
							<TD class="faixafiltro1a"  vAlign="middle" align="left" background="img/faixa_filro.gif">
                                    &nbsp;</TD>
                                    
								<TD >&nbsp;&nbsp;</TD>
							</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" class="texto" >
 						<TABLE class="borda" id="Table7" cellSpacing="0" cellPadding="0" width="99%" border="0">
                            <tr>
                                <TD >
                                </td>
                                <TD>
                                    &nbsp;</td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td align="right"  >
                                    <span style="color: #ff0000">*</span>Ano Referência:</td>
                                <td align="left">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ano_referencia" runat="server" CssClass="caixatexto"
                                        MaxLength="4" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ano_referencia"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar." Font-Bold="True" Display="Dynamic" ValidationGroup="vgcalculo">[!]</anthem:RequiredFieldValidator>
                                    <anthem:CustomValidator ID="cv_calculo" runat="server" ForeColor="White" ValidationGroup="vgcalculo" AutoUpdateAfterCallBack="True">[!]</anthem:CustomValidator>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ano_referencia"
                                        CssClass="caixaTexto" Display="Dynamic" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar."
                                        Font-Bold="True" ValidationGroup="vgpesquisar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                    <anthem:CustomValidator ID="cv_pesquisar" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vgpesquisar">[!]</anthem:CustomValidator></td>
                                <td  colspan="2" align="left">
                                    Último cálculo Projetado para Ano informado:
                                    <anthem:Label ID="lbl_ultimo_calculo" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							<TR>
								<TD style="height: 13px" >
                                    </TD>
								<TD style="height: 13px">&nbsp;</TD>
                                <td colspan="2" style="height: 13px">
                                    </td>
							</TR>
	                        <tr >
		                        <TD colspan=3 style="height: 20px" align="center" >
                                    <anthem:Label ID="Label2" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
		                        <TD align="right" style="height: 20px" >
                                    <anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                        ValidationGroup="vgpesquisar" Visible="False" />
                                    &nbsp;&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vgpesquisar" AutoUpdateAfterCallBack="True" />
                                    &nbsp; &nbsp;<anthem:ImageButton ID="btn_calcular" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_calcular.gif" ToolTip="Calcular Projeção" ValidationGroup="vgcalculo" />
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</TD>
	                        </tr>
                            <tr>
                                <td colspan="4" style="height: 20px" align="right">
                                    <anthem:Label ID="Label1" runat="server" CssClass="texto" ForeColor="Red">ATENÇÃO: Ao calcular a projeção do ano, todos os dados de cálculos anteriores para o ano serão recalculados.</anthem:Label></td>
                            </tr>
            </table>
</td>
					<TD >&nbsp;</TD></TR>

                            <TR>
                            <td style="height: 27px"></td>
                                <TD class="faixafiltro1a" style="HEIGHT: 27px; font-size: xx-small;" vAlign="middle" background="img/faixa_filro.gif" >
                                    &nbsp;&nbsp;Execução do Último Cálculo Projetado:
                                    <anthem:Label ID="lbl_calculoprojetado" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></TD>
                                    <td style="height: 27px"></td>
                            </TR>
                            
							<TR  >
							<td></td>
								<TD >&nbsp;&nbsp;&nbsp;
                </TD><TD> </td>
                </TR>
			</TABLE>
			
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vgcalculo"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpesquisar" />
         </form>
	</body>
</html>
