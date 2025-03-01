<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_faixa_qualidade.aspx.vb" Inherits="frm_faixa_qualidade" %>

<%@ Register Assembly="RK.TextBox.OnlyNumbers" Namespace="RK.TextBox.OnlyNumbers"
    TagPrefix="cc8" %>

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
    <title>Conta</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Faixa Qualidade</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server">Salvar</asp:linkbutton></TD>
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
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descri��o</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 20px">
                                                            &nbsp;<span id="Span4" class="obrigatorio">*<strong><span style="color: #000000">Estabelecimento:</span></strong></span></td>
                                                        <td class="texto" style="height: 20px">
                                                            &nbsp;&nbsp;
                                                            <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator>
                                                            &nbsp; &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span1" class="obrigatorio">*</span><strong>V�lido a partir de:</strong></td>
                                                        <td width="77%">
                                                            &nbsp;
                                                            <cc4:OnlyDateTextBox ID="txt_ds_validade" runat="server" CssClass="texto" DateMask="MonthYear"
                                                                Width="72px"></cc4:OnlyDateTextBox>
                                                            &nbsp;&nbsp;
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                ControlToValidate="txt_ds_validade" CssClass="texto" ErrorMessage="Preencha o campo Valido a partir de para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Categoria:</strong></td>
                                                        <td width="77%">
                                                            &nbsp;
                                                            <anthem:DropDownList ID="cbo_categoria_qualidade" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" Width="112px">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_categoria_qualidade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
													
													
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span3" class="obrigatorio">*</span><strong>Faixa Inicial (%):</strong></td>
                                                        <td width="77%">
                                                            &nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_faixa_inicio" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_faixa_inicio"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Faixa Inicial para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Faixa Final (%):</strong></td>
                                                        <td>
                                                            &nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_faixa_fim" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>&nbsp;
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_nr_faixa_inicio"
                                                                ControlToValidate="txt_nr_faixa_fim" CssClass="texto" ErrorMessage="Faixa Inicial n�o pode ser menor que Faixa Final"
                                                                Font-Bold="True" Operator="GreaterThanEqual" Type="Double">[!]</asp:CompareValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span5" class="obrigatorio">*</span><strong>B�nus / Desconto:</strong></td>
                                                        <td width="77%">
                                                            &nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_bonus_desconto" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nr_bonus_desconto"
                                                                CssClass="texto" ErrorMessage="Preencha o campo B�nus / Desconto para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span6" class="obrigatorio">*</span><strong>Unidade Medida:</strong></td>
                                                        <td width="77%">
                                                            &nbsp;
                                                            <anthem:DropDownList ID="cbo_un_medida" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="112px">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_un_medida"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Unidade Medida para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td Width="25%">
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
                                                                        <strong>Situa��o:</strong></td>
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
                                                                        <strong>Data Modifica��o:</strong></TD>
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
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server">Salvar</asp:LinkButton></TD>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
