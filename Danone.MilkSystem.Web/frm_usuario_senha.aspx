<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_usuario_senha.aspx.vb" Inherits="frm_usuario_senha" %>

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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Alterar Senha</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; | &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
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
								<TD>
                                   <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 30%; height: 20px">
                                                            <strong>Login:</strong></td>
                                                        <td align="left" style="width: 285px; height: 20px">
                                                            &nbsp;<asp:Label ID="lbl_login" runat="server" CssClass="texto"></asp:Label></td>
                                                        <td align="right" class="texto" style="height: 20px">
                                                        </td>
                                                        <td align="left" style="height: 20px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 21%; height: 20px">
                                                            <strong>Usuário:</strong></td>
                                                        <td align="left" colspan="3" rowspan="1" style="height: 20px">
                                                            &nbsp;<asp:Label ID="lbl_usuario" runat="server" CssClass="texto"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 21%; height: 20px">
                                                            <strong class="texto">Nova Senha:</strong></td>
                                                        <td align="left" style="width: 285px; height: 20px">
                                                            &nbsp;<anthem:TextBox ID="txt_nova_senha" runat="server" CssClass="texto" MaxLength="20"
                                                                TextMode="Password" Width="200px"></anthem:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nova_senha"
                                                                CssClass="texto" ErrorMessage="A Nova Senha deve ser informada." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                        <td align="right" class="texto" style="height: 20px">
                                                            <strong></strong>
                                                        </td>
                                                        <td align="left" style="width: 32%; height: 20px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 21%; height: 20px">
                                                            <strong class="texto">Confirmação de Senha:</strong></td>
                                                        <td align="left" style="width: 285px; height: 20px">
                                                            &nbsp;<anthem:TextBox ID="txt_confirma_senha" runat="server" CssClass="texto" MaxLength="20"
                                                                TextMode="Password" Width="200px"></anthem:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_confirma_senha"
                                                                CssClass="texto" ErrorMessage="A Confirmação da Senha deve ser informada." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            &nbsp;<asp:CustomValidator ID="cv_confirma_senha" runat="server" ControlToValidate="txt_confirma_senha"
                                                                CssClass="texto" ErrorMessage="Senha não confere!" ValidationGroup="vg_salvar">[!]</asp:CustomValidator></td>
                                                        <td align="right" class="texto" style="height: 20px">
                                                            <strong></strong>
                                                        </td>
                                                        <td align="left" style="width: 32%">
                                                            &nbsp;</td>
                                                    </tr>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
                                        <br />
                                    </asp:Panel>
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
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
