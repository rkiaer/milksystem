<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_usuario_grupo.aspx.vb" Inherits="frm_usuario_grupo" %>

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

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Alterar Senha Usuário</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Grupos do Usuário</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; &nbsp; &nbsp;
                                </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD align="center">
                                  <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False"  Width="90%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                  <br />
 									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="90%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 10%; height: 20px">
                                                            <strong>Login:</strong></td>
                                                        <td align="left" style="width: 10%; height: 20px">
                                                            &nbsp;<asp:Label ID="lbl_login" runat="server" CssClass="texto"></asp:Label></td>
                                                        <td align="right" class="texto" style="height: 20px; width: 5%">
                                                        </td>
                                                        <td align="left" style="height: 20px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 10%; height: 20px">
                                                            <strong>Usuário:</strong></td>
                                                        <td align="left" colspan="3" rowspan="1" style="height: 20px">
                                                            &nbsp;<asp:Label ID="lbl_usuario" runat="server" CssClass="texto"></asp:Label></td>
                                                    </tr>
 									</TABLE>
                                 </asp:Panel>
                                    <br />
                                 <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="90%" Font-Size="X-Small" GroupingText="Grupos" HorizontalAlign="Center" CssClass="texto">
                                        <br/>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 20%; height: 20px">
                                                            </td>
                                                        <td  align="left" style="height: 20px; width: 25%;"><strong>Disponíveis:</strong>
                                                        <td class="texto" style="height: 20px; width: 10%;">
                                                            <strong></strong>
                                                        </td>
                                                        <td align="left" style="width: 25%"><strong>Grupos do Usuário:</strong>
                                                            </td>
                                                        <td align="left" style="width: 20%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 20%; height: 20px">
                                                            <strong class="texto"></strong></td>
                                                        <td align="left" style="height: 20px">
                                                            <anthem:ListBox ID="lst_grupo" runat="server" Height="210px" Width="100%">
                                                            </anthem:ListBox></td>
                                                        <td align="center" class="texto" style="height: 20px;">
                                                            <strong>
                                                                <anthem:Button ID="btn_adicionar" runat="server" Text=" >> " /><br />
                                                                <br />
                                                                <anthem:Button ID="btn_retirar" runat="server" Text=" << " /></strong></td>
                                                        <td align="left" style=" height: 20px">
                                                            <anthem:ListBox ID="lst_grupo_usuario" runat="server" Height="210px" Width="100%" AutoUpdateAfterCallBack="True">
                                                            </anthem:ListBox></td>
                                                        <td align="left" style="height: 20px">
                                                        </td>
                                                    </tr>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
                                        <br />
                                    </asp:Panel>
                                    <br />
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"></cc7:AlertMessages></form>
	</body>
</HTML>
