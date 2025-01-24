<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_estoque.aspx.vb" Inherits="lst_exportar_estoque" %>

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportar Estoque</STRONG></TD>
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
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="20%" style="HEIGHT: 12px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 12px;">
                                    &nbsp;&nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" Width="193px">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 12px; " align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas exportadas:"
                                         Width="160px"></anthem:Label></TD>
								<TD style="height: 12px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 19px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Período:</td>
                                <td style="height: 19px; ">&nbsp;&nbsp;&nbsp;<cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto"
                                        DateMask="DayMonthYear" Width="76px"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="76px"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                </td>
								<TD style="height: 19px; width: 156px;" align="right">
                                    </TD>
								<TD style="height: 19px">
                                    &nbsp;</TD>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px; width: 439px;"></TD>
								<TD style="width: 156px">&nbsp;</TD>
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
