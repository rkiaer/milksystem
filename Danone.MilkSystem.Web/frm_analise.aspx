<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_analise.aspx.vb" Inherits="frm_analise" %>

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
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Análise</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
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
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>
													<TR id="CodigoTecnico" runat="server">
														<TD class="texto" align="right" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong><span style="color: #000000"> </span>
                                                                <strong><span style="color: #000000">Código:</span></strong></span></TD>
														<TD width="77%">&nbsp;<cc3:OnlyNumbersTextBox ID="txt_cd_analise" runat="server" CssClass="texto"
                                                                MaxLength="3" Width="48px"></cc3:OnlyNumbersTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_cd_analise"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_analise" runat="server"
                                                                CssClass="texto" Width="50%" MaxLength="50"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nm_analise"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Sigla:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_sigla" runat="server"
                                                                CssClass="texto" MaxLength="10" Width="15%"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_nm_sigla"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Estabelecimento:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" style="height: 15px" colspan="2">
                                                            Dados Análise</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 10px">
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Tipo Analise:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_analise" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_tipo_analise"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo Análise para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Formato Analise:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_formato_analise" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_formato_analise"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Formato Análise para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"></span><strong>Referência para Tipo Lógico:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_faixa_referencia_logica" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="rfv_referencialogica" runat="server" ControlToValidate="cbo_id_faixa_referencia_logica"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Referência para o tipo de análise Lógico para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" Visible="False" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <strong>Faixa Inicial:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_faixa_inicial" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4" Enabled="False" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                            <anthem:CompareValidator ID="cv_faixainicialfinal" runat="server" ControlToCompare="txt_faixa_final"
                                                                ControlToValidate="txt_faixa_inicial" CssClass="texto" ErrorMessage="Faixa Inicial não pode ser maior que Faixa Final"
                                                                Font-Bold="True" Operator="LessThanEqual" Type="Double" ValidationGroup="vg_salvar" Visible="False" AutoUpdateAfterCallBack="True">[!]</anthem:CompareValidator>
                                                            <anthem:RequiredFieldValidator ID="rfv_faixainicial" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_faixa_inicial" CssClass="texto" ErrorMessage="Preencha o campo Faixa Inicial para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" Visible="False">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <strong>Faixa Final:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_faixa_final" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4" Enabled="False" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="rfv_faixafinal" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_faixa_final" CssClass="texto" ErrorMessage="Preencha o campo Faixa Final para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" Visible="False">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong><span style="color: #ff0000">* <strong></strong></span>Tipo de Leite:</strong></td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cbo_id_item"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                                                Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Obrigatória:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_st_obrigatoria" runat="server"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value= "" Selected="True">[Selecione]</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_st_obrigatoria"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Obrigatória para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Inibidor:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_st_inibidor" runat="server"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" >
                                                            <strong>Inclusão nos Romaneios:</strong></td>
                                                        <td class="texto" style="vertical-align: text-bottom">
                                                            <br />
                                                            <anthem:CheckBoxList ID="chklst_romaneios" runat="server" CssClass="texto" Font-Bold="True"
                                                                    RepeatDirection="Horizontal" Width="50%" Height="16px">
                                                                <Items>
                                                                    <asp:ListItem Value="chk_romaneio_entrada" Selected="True">Romaneio Entrada</asp:ListItem>
                                                                    <asp:ListItem Value="chk_romaneio_saida">Romaneio Sa&#237;da</asp:ListItem>
                                                                </Items>
                                                            </anthem:CheckBoxList></td>
                                                    </tr>

                                                   <tr>
                                                        <td align="center" class="texto" colspan="2" style="height: 22px">
                                                            &nbsp;<table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="right" style="width: 10%; height: 16px" valign="top">
                                                                        <strong><span style="color: #ff0000">* &nbsp; </span></strong>
                                                                    </td>
                                                                    <td style="width: 80%; height: 16px">
                                                                        <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                                Font-Size="X-Small" GroupingText="Análise realizada em..." HorizontalAlign="Center"
                                                                Width="100%">
                                                                <br />
                                                                <strong><span style="color: #ff0000"></span></strong><anthem:CheckBoxList ID="chklist_analiserealizada" runat="server" CssClass="texto" Font-Bold="True"
                                                                    RepeatDirection="Horizontal" Width="90%" Height="16px">
                                                                    <Items>
                                                                    <asp:ListItem Value="chk_laboratorio_interno">Laborat&#243;rio Interno</asp:ListItem>
                                                                    <asp:ListItem Value="chk_laboratorio_externo">Laborat&#243;rio Externo</asp:ListItem>
                                                                    <asp:ListItem Value="chk_re_analise">Re-an&#225;lise</asp:ListItem>
                                                                        <asp:ListItem Value="chk_gera_ciq">Gera CIQ</asp:ListItem>
                                                                    </Items>
                                                                </anthem:CheckBoxList></asp:Panel>
                                                                    </td>
                                                                    <td align="left" style="width: 10%; height: 16px">
                                                                        &nbsp;
                                                                <anthem:CustomValidator ID="cv_chk_analise_realizadas" runat="server" CssClass="texto"
                                                                    ErrorMessage="Selecione uma ou mais opções para sinalizar quais as situações em que a análise poderá ser realizada."
                                                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 5px" width="23%">
                                                        </td>
                                                        <td style="height: 5px" class="texto">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server"
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
													<TR>
														<TD width="23%">&nbsp;</TD>
														<TD>&nbsp;</TD>
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
					<TD style="width: 9px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
