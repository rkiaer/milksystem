<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_contrato.aspx.vb" Inherits="frm_contrato" %>

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
    <title>Contrato</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Contrato</STRONG></TD>
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
                                    <asp:Image ID="img_novavalidade" runat="server" ImageUrl="img/novo.gif" Visible="False" /><anthem:LinkButton
                                        ID="lk_novavalidade" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Incluir nova validade para este contrato" Visible="False">Nova Validade</anthem:LinkButton>&nbsp;
                                    <anthem:Label ID="lbl_separador" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" vAlign="bottom" Visible="False">|</anthem:Label><asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar" Enabled="False">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:LinkButton ID="lk_faixa_qualidade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ToolTip="Faixa de Qualidade para o Contrato" Enabled="False">Faixa Qualidade</anthem:LinkButton>
                                    &nbsp;| &nbsp;<anthem:LinkButton ID="lk_adicional_volume" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ToolTip="Adicional de Volume para o Contrato" Enabled="False">Adicional de Volume</anthem:LinkButton>&nbsp;&nbsp;</TD>
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
								<TD bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%" class="texto">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 10px"> Contrato<anthem:CustomValidator ID="cv_contrato" runat="server"
                                                                            Font-Bold="True" ForeColor="White" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:CustomValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Estabelecimento:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O Estabelecimento deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
													
													
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Código
                                                                do Contrato:</strong></td>
                                                        <td width="77%" class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_sigla_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" valign="bottom">C</anthem:Label>
                                                            <cc3:OnlyNumbersTextBox ID="txt_nr_contrato" runat="server" CssClass="texto" MaxLength="3"
                                                                Width="31px" Enabled="False"></cc3:OnlyNumbersTextBox>
                                                            <anthem:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_nr_contrato"
                                                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Contrato para continuar."
                                                                    Font-Bold="True" ToolTip="O campo Código do Contrato deve ser informado."
                                                                    ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Nome/Descrição do Contrato:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_descricao" runat="server" CssClass="texto" MaxLength="50"
                                                                Width="430px" Enabled="False"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_descricao"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome/Descrição do Contrato para continuar."
                                                                Font-Bold="True" ToolTip="O campo Nome/Descrição do Contrato deve ser informado."
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Contrato Padrão (default):</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_contrato_padrao" runat="server"
                                                                CssClass="texto" Enabled="False" AutoUpdateAfterCallBack="True">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Contrato Tipo Mercado:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_mercado" runat="server"
                                                                CssClass="texto" Enabled="False" AutoUpdateAfterCallBack="True">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Modelo de Relacionamento:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_cluster" runat="server" CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="rf_cluster" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="cbo_cluster" CssClass="texto" ErrorMessage="Selecione um tipo de Cluster para continuar."
                                                                Font-Bold="True" ToolTip="O campo Cluster deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Válido a Partir de:</strong></td>
                                                        <td class="texto">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" DateMask="MonthYear" Width="60px" Enabled="False"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                                                CssClass="texto" ErrorMessage="Preencha o campo 'Válido a partir de' para continuar."
                                                                Font-Bold="True" ToolTip="A validade da referência deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:Label ID="lbl_st_vigente" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Bold="False" Font-Italic="True" ForeColor="Red" UpdateAfterCallBack="True" Visible="False">(Referência Vigente Atualmente)</anthem:Label></td>
                                                    </tr>
                                                    <tr id="tr_situacaocontrato" runat="server" visible="true">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação Contrato:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_situacao_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList></td>
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
								<TD bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" Enabled="False">Salvar</asp:LinkButton></TD>
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
            &nbsp;
            <anthem:HiddenField ID="hf_dt_referencia_vigente" runat="server" AutoUpdateAfterCallBack="True" />
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
