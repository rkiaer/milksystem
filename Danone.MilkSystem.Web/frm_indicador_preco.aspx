<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_indicador_preco.aspx.vb" Inherits="frm_indicador_preco" %>

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
    <title>Indicador Preço</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Indicador Preço</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="12" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 338px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:Image ID="img_notificacao" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/ico_email.gif" />
                                    <anthem:LinkButton ID="lk_email" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                                        OnClientClick="if (confirm('Uma notificação de que existem Indicadores de Preço para aprovação será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                                        ToolTip="Notificar Aprovadores de Indicador de Preço" ValidationGroup="vg_salvar">Notificar Aprovadores</anthem:LinkButton>
                                    &nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                     </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" class="texto">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%" class="texto">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 10px"> Indicador de Preço</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Tipo de Indicador de Preço:</strong></td>
                                                        <td width="77%" class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_indicador_tipo" runat="server" CssClass="texto" Enabled="False" AutoPostBack="True" AutoUpdateAfterCallBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_indicador_tipo"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo de Indicador de Preço para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O Tipo de Indicador de Preço deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
													
												
                                                   <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Referência:</strong></td>
                                                        <td class="texto">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" DateMask="MonthYear" Width="60px" Enabled="False"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar."
                                                                Font-Bold="True" ToolTip="A referência deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Valor Indicador:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="60px" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nr_valor"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Valor Indicador para continuar."
                                                                Font-Bold="True" ToolTip="O campo Valor do Indicador deve ser informado."
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação Aprovação:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_situacao_indicador_preco" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 10px" colspan="">
                                                            </td>
                                                        <td style="height: 10px" colspan="">
                                                            </td>
                                                    </tr>

													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" class="texto">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                        </anthem:DropDownList>&nbsp;</td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%" style="height: 17px">
                                                                        <strong>Modificador:</strong></TD>
																	<TD style="height: 17px">&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="height: 17px">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD style="height: 17px">&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
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
					<TD style="width: 7px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            &nbsp; &nbsp;
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
