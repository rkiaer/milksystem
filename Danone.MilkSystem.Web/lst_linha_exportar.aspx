<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_linha_exportar.aspx.vb" Inherits="lst_linha_exportar" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN" >
<html>
	<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</head>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 27px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><strong>Exportar Rota<br />
                    </StrONG></td>
					<td width="10" style="height: 27px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 133px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" style="height: 133px"><BR>
						<table class="borda" id="table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="20%" style="height: 12px"></td>
								<td style="height: 12px; width: 439px;"></td>
								<td style="height: 12px; "></td>
								<td style="height: 12px"></td>
							</tr>
						
                            <tr>
                                <td align="right" style="height: 23px; ">
                                    Estabelecimento:</td>
                                <td style="height: 23px; width: 439px;">
                                    &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 23px;">
                                     </td>
                                <td align="left" style="height: 23px;">
                                    </td>
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 23px; ">
                                    Status:</td>
                                <td style="height: 23px; width: 439px;">
                                    &nbsp;<asp:DropDownList ID="cbo_status" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
								<td align="right" style="height: 23px;">
                                     </td>
								<td align="left" style="height: 23px;"></td>
 							</tr>
                         
                           
							<tr>
								<td style="height: 12px"></td>
								<td style="height: 12px; width: 439px;"></td>
								<td style="width: 156px">&nbsp;</td>
								<td align="right">
                                    &nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ></anthem:imagebutton>
                                    &nbsp;</td>
							</tr>
						</table>
						<br/>
					</td>
					<td style="height: 133px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 24px; width: 9px;">&nbsp;</td>
					<td class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</td>
					<td style="HEIGHT: 24px">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;"></td>
					<td vAlign="middle" style="height: 19px">&nbsp;</td>
					<td style="height: 19px"></td>
				</tr>
				
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td>
                        &nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;">&nbsp;</td>
					<td vAlign="top" style="height: 19px">&nbsp;
					</td>
					<td style="height: 19px">&nbsp;</td>
				</tr>
			</table>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="False" />
		</form>
	</body>
</html>
