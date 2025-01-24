<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_adto.aspx.vb" Inherits="lst_exportar_adto" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>


<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportar Adiantamento</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 133px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 133px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="15%" style="height: 12px"></TD>
								<TD width="30%" style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 19px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Mes/Ano Referência::</td>
                                <td style="height: 19px; ">&nbsp;&nbsp;<cc3:OnlyDateTextBox ID="dt_referencia" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="76px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dt_referencia"
                                        CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                </td>
 								<TD  style="height: 12px;" align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas exportadas:"
                                         Width="160px"></anthem:Label></TD>
								<TD style="height: 12px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                            </tr>
                            <tr>
                                <TD width="20%" style="HEIGHT: 12px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Portador:</td>
                                <TD style="HEIGHT: 12px; ">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_portador" runat="server" CssClass="caixaTexto" Width="193px">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_portador"
                                        Display="Dynamic" ErrorMessage="O portador deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True">[!]</anthem:CompareValidator></td>
 								<TD style="height: 12px" align="right">
                                     <anthem:CheckBox ID="ck_adtos_exportados" runat="server" Text="Adiantamentos já exportados" /></TD>
								<TD style="height: 12px"></TD>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Data Processamento:</td>
                                <td style="height: 19px; ">&nbsp;&nbsp;<cc3:OnlyDateTextBox ID="dt_processamento" runat="server" CssClass="texto"
                                        Width="96px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="dt_processamento" CssClass="texto" ErrorMessage="A datia de Processamento deve ser informada."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                </td>
                                <TD  style="height: 12px; " align="right">
                                </td>
                                <TD style="height: 12px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Data Vencimento:</td>
                                <td style="height: 19px; ">&nbsp;&nbsp;<cc3:OnlyDateTextBox ID="dt_vencimento" runat="server" CssClass="texto"
                                        Width="96px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="dt_vencimento" CssClass="texto" ErrorMessage="A datia de Vencimento deve ser informada."
                                        Font-Bold="True">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                </td>
                                <TD  style="height: 12px; " align="right">
                                </td>
                                <TD style="height: 12px">
                                    &nbsp;</td>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px;"></TD>
								<TD >&nbsp;</TD>
								<TD align="right">
                                    &nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
                        &nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
		</form>
	</body>
</HTML>
