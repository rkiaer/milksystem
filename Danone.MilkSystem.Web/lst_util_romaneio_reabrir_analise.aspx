<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_util_romaneio_reabrir_analise.aspx.vb" Inherits="lst_util_romaneio_reabrir_analise" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_conta_parcelada</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Reabrir Registro das Análises do Romaneio</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 1014px">
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 44px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 1014px; height: 44px;"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD style="HEIGHT: 26px; width: 25%;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Nr. Romaneio:</td>
                                <TD style="HEIGHT: 25px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_nr_romaneio" runat="server" CssClass="texto" MaxLength="10"
                                        Width="72px"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_romaneio"
                                        ErrorMessage="Informe o número do romaneio." Font-Bold="True" ValidationGroup="vg_pesquisar" SetFocusOnError="True">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                            ID="CompareValidator1" runat="server" ControlToValidate="txt_nr_romaneio" CssClass="texto"
                                            ErrorMessage="O número do romaneio deve ser maior que zero!" Operator="GreaterThan"
                                            SetFocusOnError="True" ToolTip="Número do romaneio deve ser maior que zero."
                                            ValidationGroup="vg_pesquisar" ValueToCompare="0">[!]</asp:CompareValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_nr_romaneio"
                                        CssClass="texto" ErrorMessage="Número do Romaneio deve ser informado apenas com números."
                                        SetFocusOnError="True" ValidationExpression="[0-9]*" ValidationGroup="vg_pesquisar">[!]</asp:RegularExpressionValidator></td>
                            </tr>
							<tr>
								<TD style="width: 25%; height: 26px">&nbsp;</TD>
								<TD align="right" style="height: 26px">
                                    &nbsp;<anthem:imagebutton id="btn_executar" runat="server" imageurl="~/img/bnt_executar.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD id="Td1" runat="server" style="width: 1014px">
                        <TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="center" style="height: 20px" colspan="2">
                                    Ao selecionar o botão "Executar", os registros de todas análises de compartimento
                                    serão reabertos. Todas as analises de produtor serão reinicializadas.</td>
                            </tr>
                        </table>
                    </td>
                    <TD>
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 1014px;">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
        </div>
		</form>
	</body>
</HTML>
