<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_cep.aspx.vb" Inherits="frm_cep" %>

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
    <title>CEP</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>CEP</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="height: 25px;" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
                                    &nbsp;|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<tr>
				<td></td>
				<td>									<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="width: 23%"> Descrição</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span class="obrigatorio">*</span><strong>Estado:</strong></td>
                                                        <td >
                                                            &nbsp;<anthem:DropDownList ID="cbo_estado" runat="server"
                                                                CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estado"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estado para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Estado deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                    <tr>
                        <td align="right" class="texto" style="width: 23%">
                            <strong><span style="color: #ff0000">*</span>Cidade:</strong></td>
                        <td>
                            &nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                CssClass="texto" Enabled="False">
                            </anthem:DropDownList>
                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_cidade"
                                CssClass="texto" ErrorMessage="Preencha o campo Cidade para continuar." Font-Bold="True"
                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%"  >
                                                        <span class="obrigatorio">*</span><strong>Cod. CEP:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_cd_cep" runat="server" CssClass="texto" MaxLength="8"
                                                                Width="80px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                            <anthem:Label ID="lbl_informativo" runat="server" CssClass="texto" Font-Italic="True"
                                                                ForeColor="Red" UpdateAfterCallBack="True">apenas números</anthem:Label>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_cep"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cod. CEP para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Cod. CEP deve ser informado.">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cv_cep" runat="server" CssClass="texto" ForeColor="White"
                                                                ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" style="width: 23%">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="width: 23%">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%" style="width: 23%;">
                                                                        <strong>Situação:</strong></td>
                                                                    <td style="height: 21px">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%" style="width: 23%">
                                                                        <strong>Modificador:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="width: 23%">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
														
													</TR>
												</TABLE>
</td>
				<td></td>
				</tr>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
														<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left"
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
        </form>
	</body>
</HTML>
