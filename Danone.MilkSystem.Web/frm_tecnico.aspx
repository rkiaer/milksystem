<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_tecnico.aspx.vb" Inherits="frm_tecnico" %>

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
    <title>Untitled Page</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 3px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Técnico</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 3px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 3px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>
													<TR id="CodigoTecnico" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG>
                                                            <anthem:Label ID="lbl_cd_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True">Código:</anthem:Label></STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" Enabled="False" MaxLength="10"></anthem:TextBox>
                                                            </TD>
													</TR>
                                                    <tr>
														<TD class="texto" style="HEIGHT: 17px" align="right" width="23%"><STRONG>Categoria:</STRONG></TD>
														<TD style="HEIGHT: 17px">&nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                            <asp:ListItem Value="D">Danone</asp:ListItem>
                                                            <asp:ListItem Value="B">BEA</asp:ListItem>
                                                            <asp:ListItem Value="Q">Comquali</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="E">Educampo</asp:ListItem>
                                                            <asp:ListItem Value="F">Flora</asp:ListItem>
                                                            </anthem:DropDownList></TD>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="60"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nm_tecnico"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Nome Abreviado:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_abreviado" runat="server" CssClass="texto" MaxLength="60"
                                                                Width="40%"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_abreviado"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome Abreviado para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 5px">
                                                        </td>
                                                        <td style="height: 5px">
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" style="height: 15px" colspan="2">
                                                            Dados Pessoa Física</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                        </td>
                                                        <td style="height: 23px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>RG:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_rg" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Width="25%" MaxLength="15"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Orgão Emissor:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_orgao_emissor" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="13%" MaxLength="5"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>CPF:</strong></TD>
														<TD>
                                                            &nbsp;<cc2:CPFTextBox ID="txt_cpf" runat="server" AutoUpdateAfterCallBack="True" ErrorMessage="CPF Inválido." Width="25%" CssClass="texto"></cc2:CPFTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cpf"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CPF para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Data Nascimento:</strong></TD>
														<TD>&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_nascimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Logradouro</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 15px" align="right" width="23%"></TD>
														<TD style="HEIGHT: 15px">&nbsp;
															</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Endereço:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_endereco" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="60"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Numero:</strong></TD>
														<TD>&nbsp;<cc3:OnlyNumbersTextBox ID="txt_numero" runat="server" CssClass="texto" Width="8%" MaxLength="6"></cc3:OnlyNumbersTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Complemento:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_complemento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="30"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Bairro:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_bairro" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="40"></anthem:TextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                        </anthem:DropDownList>
                                                            </TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Cidade:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList>
                                                            </TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>CEP:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_cep" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="9"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 1:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<cc5:PhoneTextBox ID="txt_telefone1" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox>
                                                            <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_telefone2"
                                                                ControlToValidate="txt_telefone1" CssClass="texto" ErrorMessage="Telefone 1 não pode ser igual ao Telefone 2."
                                                                Font-Bold="True" Operator="NotEqual" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 2:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<cc5:PhoneTextBox ID="txt_telefone2" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>e-mail:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_email" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="50"></anthem:TextBox>
															</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                        </td>
                                                        <td style="height: 22px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" class="texto">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%">
                                                                        <strong>Modificador:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
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
					<TD style="width: 1px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
