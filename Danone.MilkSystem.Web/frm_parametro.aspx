<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_parametro.aspx.vb" Inherits="frm_parametro" %>

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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Parâmetros</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 28%" vAlign="middle" align="left"
									background="img/faixa_filro.gif">
                                    &nbsp;
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
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR id="CodigoTecnico" runat="server">
														<TD class="texto" align="right" style="width: 28%"><STRONG>Adiantamento/Limite 1.a Quinzena (%) :</STRONG></TD>
														<TD width="77%">&nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_perc_limite1q_cc" runat="server" CssClass="texto" MaxCaracteristica="12"
                                                                MaxMantissa="2" Width="80px"></cc6:OnlyDecimalTextBox>
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nr_perc_limite1q_cc"
                                                                CssClass="texto" ErrorMessage="O Adiantamento deve estar entre 0 e 100" MaximumValue="100"
                                                                MinimumValue="0" Type="Double" ValidationGroup="vg_salvar" Font-Bold="True">[!]</asp:RangeValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 28%">
                                                            <strong>Limite 2ª Quinzena (%) :</strong></td>
                                                        <td>
                                                            &nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_perc_limite2q_cc" runat="server" CssClass="texto"
                                                                MaxCaracteristica="12" MaxMantissa="2" Width="80px"></cc6:OnlyDecimalTextBox>
                                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_nr_perc_limite2q_cc"
                                                                CssClass="texto" ErrorMessage="O Limite Clube Compra 2ª Quinzena deve estar entre 0 e 100"
                                                                MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="vg_salvar" Font-Bold="True">[!]</asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" style="width: 28%">
                                                            <STRONG>Deflator para Preço Negociado (R$) :</strong></td>
                                                        <TD width="77%">
                                                            &nbsp;
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_deflator" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                                MaxMantissa="4" Width="80px"></cc6:OnlyDecimalTextBox>
                                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_nr_deflator"
                                                                CssClass="texto" ErrorMessage="O deflator deve ser informado." Font-Bold="True"
                                                                MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="vg_salvar">[!]</asp:RangeValidator></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 28%">
                                                            <strong>Política de Parcelas Central :</strong></td>
                                                        <td>
                                                            &nbsp;
                                                            <cc3:OnlyNumbersTextBox ID="txt_nr_politica_parcelas" runat="server" CssClass="texto"
                                                                MaxLength="2" Width="80px"></cc3:OnlyNumbersTextBox>
                                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_nr_politica_parcelas"
                                                                CssClass="texto" ErrorMessage="A Política de Parcelas Central deve ser informada."
                                                                Font-Bold="True" MaximumValue="99" MinimumValue="1" ToolTip="Política de Parcelas Central deve ser informada!"
                                                                Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 28%">
                                                            <strong>Política de Dias para Antecipação Cálculo :</strong></td>
                                                        <td class="texto">
                                                            &nbsp;&nbsp;
                                                            <cc3:OnlyNumbersTextBox ID="txt_nr_dias_antecipacao" runat="server" CssClass="texto"
                                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox>
                                                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_nr_dias_antecipacao"
                                                                CssClass="texto" ErrorMessage="A Política de Dias para Antecipação Cálculo deve ser informada."
                                                                Font-Bold="True" MaximumValue="31" MinimumValue="0" ToolTip="Política de Dias para Antecipação Cálculo deve ser informada!"
                                                                Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator>
                                                            Válido a partir de:
                                                            <cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CausesValidation="True"
                                                                CssClass="texto" DateMask="MonthYear" MaxLength="7" Width="60px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                                                ErrorMessage="A Referência da política de dias para antecipação de cálculo deve ser informada."
                                                                ToolTip="A Referência da política de dias para antecipação de cálculo deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cv_referencia" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px; width: 28%;">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" style="width: 28%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" style="width: 28%">
                                                                        <strong>Modificador:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="width: 28%">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="width: 28%">&nbsp;</TD>
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
                                                &nbsp;
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
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar" />
        </form>
	</body>
</HTML>
