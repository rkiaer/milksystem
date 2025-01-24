<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_mensagem.aspx.vb" Inherits="frm_romaneio_mensagem" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_faixa_qualidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 539px;"><STRONG>Mensagem&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 539px">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 539px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="height: 20px"></TD>
								<TD style="height: 20px;" colspan="2"></TD>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 20px; width: 70px;" align="right">
                                    </td>
                                <TD style="HEIGHT: 20px; width: 80%; font-weight: normal; text-justify: auto; font-size: x-small; text-align: justify;">
                                    <asp:Label ID="Label1" runat="server" Height="56px" Text="Label" Width="100%"></asp:Label></td>
                                <td style="width: 10%; height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px; width: 70px;" align="right"></TD>
								<TD style="HEIGHT: 20px; width: 1116px;" colspan="2"></TD>
							</TR>
							<TR>
								<TD style="width: 70px; height: 36px;">&nbsp;</TD>
								<TD align="center" colspan="" style="height: 36px">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="~/img/bnt_ok.gif" ImageAlign="AbsMiddle"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
                                <td align="right" colspan="" style="width: 1116px; height: 36px;">
                                </td>
							</TR>
						</TABLE>
						<BR>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 539px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 539px;">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 539px">
                        &nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; width: 539px;">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server" UpdateAfterCallBack="True"></cc1:alertmessages>&nbsp;&nbsp;
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
