<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_natureza_operacao.aspx.vb" Inherits="frm_natureza_operacao" %>

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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Natureza de Operação</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
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
								<TD bgColor="#d0d0d0" style="width: 1px; height: 170px;"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%" style="height: 157px">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0" style="height: 200px">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>

                                                    <tr>
                                                        <td  align="right" class="texto" style="height: 15px" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Código:</strong></td>
                                                        <td style="height: 15px" width="77%">
                                                            &nbsp;<asp:TextBox ID="txt_cd_natureza_operacao" runat="server" CssClass="texto"
                                                                MaxLength="6" Width="64px"></asp:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_natureza_operacao"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código  para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Descrição:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:TextBox ID="txt_nm_natureza_operacao" runat="server" CssClass="texto" Width="232px" MaxLength="35"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_natureza_operacao"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Descrição  para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Espécie:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_especie_nf" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_id_especie_nf"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Espécie  para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tipo de Espécie:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_ds_tipo_especie" runat="server"
                                                                CssClass="texto" MaxLength="20" Width="33%"></anthem:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Conta Transitória:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nr_conta_transitoria" runat="server" CssClass="texto"
                                                                MaxLength="17" Width="117px"></anthem:TextBox>&nbsp;
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_nr_conta_transitoria"
                                                                CssClass="texto" ErrorMessage="Formato da Conta Transitória deve ser  '99999999.99999999'. "
                                                                SetFocusOnError="True" ValidationExpression="([0-9]){8}\.([0-9]){8}"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 10px" width="23%">
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                            Dados do ICMS</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%"><strong>Alíquota ICMS:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_aliquota_icms" runat="server" CssClass="texto"
                                                                MaxCaracteristica="3" MaxLength="6" MaxMantissa="2" Width="64px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tributação ICMS:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_tributacao_icms" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 9px" width="23%">
                                                        </td>
                                                        <td style="height: 9px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                            Dados do IPI</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Alíquota IPI:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_aliquota_ipi" runat="server" CssClass="texto"
                                                                MaxCaracteristica="3" MaxLength="6" MaxMantissa="2" Width="64px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tributação IPI:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_tributacao_ipi" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 10px" width="23%">
                                                        </td>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                            Dados do PIS</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Alíquota PIS:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_aliquota_pis" runat="server" CssClass="texto"
                                                                MaxCaracteristica="3" MaxLength="6" MaxMantissa="2" Width="64px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tributação PIS:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_tributacao_pis" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 9px" width="23%">
                                                        </td>
                                                        <td style="height: 9px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" style="height: 45px">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
                                                                <tr>
                                                                    <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                                        Dados do COFINS</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Alíquota COFINS:</strong></td>
                                                                    <td>
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_aliquota_cofins" runat="server" CssClass="texto"
                                                                            MaxCaracteristica="3" MaxLength="6" MaxMantissa="2" Width="64px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Tributação COFINS:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_id_tributacao_cofins" runat="server"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 9px" width="23%">
                                                                    </td>
                                                                    <td style="height: 9px">
                                                                    </td>
                                                                </tr>
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
								<TD width="1" bgColor="#d0d0d0" style="height: 170px"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD class="texto">
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
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />

                </form>
	</body>
</HTML>
