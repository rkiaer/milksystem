<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_nota_fiscal_produtor_SAP.aspx.vb" Inherits="lst_exportar_nota_fiscal_produtor_SAP" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_exportar_nota_fiscal</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportar Nota Fiscal Produtor SAP</STRONG></TD>
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
                                <TD width="20%" style="HEIGHT: 25px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 25px;">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" Width="193px">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 25px; " align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas exportadas:"
                                         Width="160px"></anthem:Label></TD>
								<TD style="height: 25px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    <span style="color: #ff0000"><strong>*</strong><span style="color: #333333">Mes/Ano
                                        Referência</span></span>:</td>
                                <td style="height: 25px; ">&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="76px"></cc2:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_referencia"
                                            CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
								<TD style="height: 25px; width: 156px;" align="left">
                                    <anthem:CheckBox ID="ck_notas_exportadas" runat="server" Text="Notas já exportadas" /></TD>
								<TD style="height: 25px">
                                    &nbsp;</TD>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD style="height: 25px; width: 439px;">
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="100%">Aguarde... Geração do arquivo em andamento...</anthem:Label></TD>
								<TD style="width: 156px; height: 25px;">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    &nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ></anthem:imagebutton>&nbsp;</TD>
							</TR>
                            <tr>
                                <TD width="20%" style="height: 12px">
                                </td>
                                <TD style="height: 12px; ">
                                </td>
                                <TD style="height: 12px; ">
                                </td>
                                <TD style="height: 12px">
                                </td>
                            </tr>
						</TABLE>
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
