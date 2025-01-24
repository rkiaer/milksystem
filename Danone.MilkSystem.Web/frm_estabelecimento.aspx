<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_estabelecimento.aspx.vb" Inherits="frm_estabelecimento" %>

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
					<TD style="width: 8px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Estabelecimento</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 8px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    &nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton>
                                </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 8px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%" style="height: 5px"></TD>
														<TD width="77%" style="height: 5px"></TD>
													</TR>
													<TR id="trContratoRelacionado" runat="server">
														<TD class="texto" align="right" width="23%"><span class="obrigatorio">*</span>&nbsp;<STRONG>Código:</STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" MaxLength="50"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Código SAP:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_codigo_SAP" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="10" Width="25%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nm_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2">
                                                            Dados Pessoa Jurídica</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 5px">
                                                        </td>
                                                        <td style="height: 5px">
                                                            &nbsp;</td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <span class="obrigatorio">* </span><strong>CNPJ:</strong></TD>
														<TD>&nbsp;<cc1:CNPJTextBox ID="txt_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ErrorMessage="CNPJ Inválido." Width="25%"></cc1:CNPJTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_cnpj"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CNPJ para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Inscrição Estadual:</strong></TD>
														<TD>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_inscricao_estadual" runat="server" CssClass="texto"
                                                                Width="25%" MaxLength="20"></cc3:OnlyNumbersTextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Inscrição Municipal:</strong></TD>
														<TD>
															<P>
																&nbsp;<cc3:OnlyNumbersTextBox ID="txt_inscricao_municipal" runat="server" CssClass="texto"
                                                                    Width="25%" MaxLength="20"></cc3:OnlyNumbersTextBox></P>
														</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Categoria:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="M">Matriz</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="F">Filial</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%" style="height: 5px">
                                                        </td>
                                                        <TD width="77%" style="height: 5px">
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Logradouro</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Endereço:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_endereco" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Numero:</strong></TD>
														<TD>&nbsp;<cc3:OnlyNumbersTextBox ID="txt_numero" runat="server" CssClass="texto" Width="8%" MaxLength="8"></cc3:OnlyNumbersTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Complemento:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_complemento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Bairro:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_bairro" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <span class="obrigatorio">* </span><strong>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                        </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_estado"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estado para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <span class="texto">* </span><strong>Cidade:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_cidade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cidade para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>CEP:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_cep" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="9"></anthem:TextBox></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%" style="height: 5px">
                                                        </td>
                                                        <TD width="77%" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Mapa Leite</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Número Mapa Leite:</strong>
                                                        </td>
                                                        <td style="height: 22px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_mapa_leite" runat="server" CssClass="texto"
                                                                MaxLength="8" Width="8%"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>AIDF:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_aidf" runat="server" CssClass="texto" MaxLength="300"
                                                                TextMode="MultiLine" Width="89%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%" style="height: 5px">
                                                        </td>
                                                        <TD width="77%" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                                                                        <tr>
                                                        <TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Frete</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>KM Mínima:</strong>
                                                        </td>
                                                        <td style="height: 22px">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_km_minima" runat="server" CssClass="texto"
                                                                MaxCaracteristica="5" MaxLength="10" MaxMantissa="4" Width="70px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_km_minima"
                                                                CssClass="texto" ErrorMessage="Preencha o campo KM Mínima de frete para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            &nbsp;</td>
                                                        <td style="height: 22px">
                                                            &nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Nota Fiscal Produtores</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Série da Nota Fiscal:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_serie_nota_fiscal" runat="server" CssClass="texto" MaxLength="3" Width="56px"
                                                                ></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Número Próxima Nota Fiscal:</strong>
                                                        </td>
                                                        <td style="height: 22px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_proxima_nota_fiscal" runat="server" CssClass="texto"
                                                                MaxLength="6" Width="56px"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 22px" width="23%">
                                                                        <strong>Data Validade Formulário:</strong>
                                                                    </td>
                                                                    <td style="height: 22px">
                                                                        &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_validade_formulario" runat="server" CssClass="texto"
                                                                            MaxLength="10" Width="72px"></cc4:OnlyDateTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 15px" width="23%">
                                                                        <strong>AIDF:</strong></td>
                                                                    <td style="height: 15px">
                                                                        &nbsp;<anthem:TextBox ID="txt_aidf_nf" runat="server" CssClass="texto" MaxLength="300"
                                                                            TextMode="MultiLine" Width="89%"></anthem:TextBox></td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <TD class="texto" align="right" width="23%" style="height: 5px">
                                                                    </td>
                                                                    <TD width="77%" style="height: 5px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="titmodulo" align="left" colspan="2">
                                                                        &nbsp; Análise ESALQ</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 22px" width="23%">
                                                                        <strong>Percentual Variação Gordura (%) :</strong>
                                                                    </td>
                                                                    <td style="height: 22px">
                                                                        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_analiseesalq_percvariacaoMG" runat="server" CssClass="texto"
                                                                            MaxLength="8" Width="8%" ToolTip="Percentual utilizado para verificar Variação MG no processo de Concialiação das Análises Esalq"></cc3:OnlyNumbersTextBox>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="texto" align="right" width="23%" style="height: 5px">
                                                                    </td>
                                                                    <TD width="77%" style="height: 5px">
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
								<TD width="1" bgColor="#d0d0d0"></TD>
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
					<TD style="width: 8px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
