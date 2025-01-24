<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_poupanca_parametro.aspx.vb" Inherits="frm_poupanca_parametro" %>

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
    <title>Poupança - Parâmetros</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Poupança Parâmetros</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                     </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%" style="height: 500px">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 10px"> Parâmetros<anthem:CustomValidator ID="cv_parametros" runat="server"
                                                                            Font-Bold="True" ForeColor="White" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Estabelecimento:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O Estabelecimento deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
													
													
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Período
                                                                de Referência Poupança:</strong></td>
                                                        <td width="77%" class="texto">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_referencia_ini" runat="server" CssClass="texto"
                                                                DateMask="MonthYear" Width="71px"></cc4:OnlyDateTextBox>
                                                            à
                                                            <cc4:OnlyDateTextBox ID="txt_referencia_fim" runat="server" CssClass="texto" DateMask="MonthYear"
                                                                Width="71px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_referencia_ini"
                                                                    CssClass="texto" ErrorMessage="Preencha o campo Período Inicial de Referência para continuar."
                                                                    Font-Bold="True" ToolTip="O campo Período Inicial de Referência deve ser informado."
                                                                    ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_referencia_fim"
                                                                        CssClass="texto" ErrorMessage="Preencha o campo Período Final de Referência para continuar."
                                                                        Font-Bold="True" ToolTip="O campo Período Final de Referência deve ser informado."
                                                                        ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação Poupança:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_nm_situacao_poupanca" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Último Cálculo Definitivo do Período:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_calculo_definitivo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Último Cálculo Mensal de Poupança:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_ultimo_calculo_poupanca" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 15px">
                                                            </td>
                                                        <td style="height: 15px">
                                                            </td>
                                                    </tr>
                                                    <TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Bônus por Adesão ao Programa</TD>
													</TR>
                                                    
                                                    <tr>
                                                        <td align="left" class="texto" colspan="2">
                                                        <table class="texto" width="100%">
                                                            <tr><td style="width: 15%"></td>
                                                            <td>
                                                                <br />
                                                            <table border="0" class="texto" style="width: 199px; border-right: scrollbar 1px solid; border-top: scrollbar 1px solid; border-left: scrollbar 1px solid; border-bottom: scrollbar 1px solid;" cellspacing="0">
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px;" class="texto">
                                                                        Ano</td>
                                                                    <td align="center" style="width: 108px; font-weight: bold; height: 22px; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                                        R$ / Litro</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; height: 22px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; border-top: #c8c8c8 1px solid;" class="texto">
                                                                        1</td>
                                                                    <td style="width: 108px; height: 22px; border-top: #c8c8c8 1px solid;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_1ano" runat="server" CssClass="texto"
                                                                            MaxLength="9" Width="65px" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_nr_bonus_1ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus por Adesão 1o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus por Adesão 1o ano' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: #c8c8c8 1px solid;" class="texto">
                                                                        2</td>
                                                                    <td style="width: 108px; border-top: #c8c8c8 1px solid; height: 22px;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_2ano" runat="server" CssClass="texto"
                                                                            MaxLength="9" Width="65px" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_nr_bonus_2ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus por Adesão 2o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus por Adesão 2o ano' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: #c8c8c8 1px solid;" class="texto">
                                                                        &gt;=3</td>
                                                                    <td style="width: 108px; border-top: #c8c8c8 1px solid; height: 22px;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_3ano" runat="server" CssClass="texto"
                                                                            MaxLength="9" Width="65px" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_nr_bonus_3ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus por Adesão 3o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus por Adesão 3o ano' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                        </td>
                                                    </tr>
                                                    <TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Bônus Adicional - Central de Compras</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 20px" valign="bottom">
                                                            <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Spend
                                                                para Período:</strong></td>
                                                        <td width="77%" class="texto" style="height: 20px" valign="bottom">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_spend_periodo" runat="server" CssClass="texto"
                                                                MaxLength="8" Width="65px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_nr_spend_periodo"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Spend para continuar." Font-Bold="True" ToolTip="O campo Spend deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="texto" colspan="2">
                                                        <table class="texto" width="100%">
                                                            <tr><td style="width: 15%"></td><td>
                                                                <br />
                                                            <table border="0" class="texto" style="width: 199px; border-right: scrollbar 1px solid; border-top: scrollbar 1px solid; border-left: scrollbar 1px solid; border-bottom: scrollbar 1px solid;" cellspacing="0">
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: scrollbar 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px;" class="texto">
                                                                        Ano</td>
                                                                    <td align="center" style="width: 108px; font-weight: bold; height: 22px; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                                        %</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; height: 22px; border-right: scrollbar 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; border-top: scrollbar 1px solid;" class="texto">
                                                                        1</td>
                                                                    <td style="width: 108px; height: 22px; border-top: scrollbar 1px solid;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_extra_1ano" runat="server" CssClass="texto"
                                                                            MaxLength="8" Width="65px"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_bonus_extra_1ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus Adicional 1o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus Adicional 1o ano' deve ser infromado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: scrollbar 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: scrollbar 1px solid;" class="texto">
                                                                        2</td>
                                                                    <td style="width: 108px; border-top: scrollbar 1px solid; height: 22px;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_extra_2ano" runat="server" CssClass="texto"
                                                                            MaxLength="8" Width="65px"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_bonus_extra_2ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus Adicional 2o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus Adicional 2o ano' deve ser infromado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="width: 91px; border-right: scrollbar 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: scrollbar 1px solid;" class="texto">
                                                                        &gt;=3</td>
                                                                    <td style="width: 108px; border-top: scrollbar 1px solid; height: 22px;" align="center">
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_bonus_extra_3ano" runat="server" CssClass="texto"
                                                                            MaxLength="8" Width="65px"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nr_bonus_extra_3ano"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo 'Bônus Adicional 3o ano' para continuar."
                                                                            Font-Bold="True" ToolTip="O campo 'Bônus Adicional 3o ano' deve ser infromado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                        </td>
                                                    </tr>
                                                    <TR id="tr_qualidade" runat="server" visible="false">
														<TD colSpan="2" class="texto">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">
                                                                        Parâmetros de Qualidade</TD>
																</TR>
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="2">
                                                                        <br />
                                                                        <table id="Table8" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                            <tr>
                                                                                <td align="right" class="texto" style="width: 24%; height: 20px" colspan="2">
                                                                                    <strong>Período Validade:</strong>
                                                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="MonthYear"
                                                                                        Width="55px"></cc4:OnlyDateTextBox>
                                                                                    à
                                                                                    <cc4:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" DateMask="MonthYear"
                                                                                        Width="55px"></cc4:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                                                            runat="server" ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="Preencha o campo Período Validade Inicial para continuar."
                                                                                            Font-Bold="False" ValidationGroup="vg_qualidade" ToolTip="O campo Período Validade Inicial deve ser informado.">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_dt_fim" CssClass="texto"
                                                                                                ErrorMessage="Preencha o campo Período Validade Final para continuar." Font-Bold="False"
                                                                                                ValidationGroup="vg_qualidade" ToolTip="O campo Período Validade Final deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                                                <td align="right" class="texto" colspan="2" style=" height: 20px; width: 22%;">
                                                                                    <strong>
                                                                                        <anthem:CheckBoxList ID="chk_antib_analises" runat="server" AutoUpdateAfterCallBack="True"
                                                                                            RepeatDirection="Horizontal" AutoCallBack="True">
                                                                                            <Items>
                                                                                                <asp:ListItem Value="RA">Rejei&#231;&#227;o Antibi&#243;tico</asp:ListItem>
                                                                                                <asp:ListItem Value="AR">An&#225;lises Romaneio</asp:ListItem>
                                                                                            </Items>
                                                                                        </anthem:CheckBoxList></strong></td>
                                                                                <td align="right" class="texto" style="width: 17%; height: 20px" colspan="2">
                                                                                    <strong>Categoria:</strong>&nbsp;<anthem:DropDownList ID="cbo_categoria_qualidade"
                                                                                        runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                                        Width="112px">
                                                                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="rfv_categoria" runat="server" ControlToValidate="cbo_categoria_qualidade"
                                                                                        CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar." Font-Bold="True" ValidationGroup="vg_qualidade" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                                                                <td align="right" class="texto" style="height: 20px" colspan="2">
                                                                                    <strong>Faixa Ref. Poupança:</strong>
                                                                                    <cc6:OnlyDecimalTextBox
                                                                                            ID="txt_faixa_inicial" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="10" MaxMantissa="4" MaxLength="15"></cc6:OnlyDecimalTextBox><anthem:CompareValidator
                                                                                                ID="cv_faixainicialfinal" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_faixa_final"
                                                                                                ControlToValidate="txt_faixa_inicial" CssClass="texto" ErrorMessage="Faixa Início não pode ser maior que Faixa Fim."
                                                                                                Font-Bold="True" Operator="LessThanEqual" Type="Double" ValidationGroup="vg_qualidade">[!]</anthem:CompareValidator><anthem:RequiredFieldValidator ID="rfv_faixainicial"
                                                                                                    runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_faixa_inicial"
                                                                                                    CssClass="texto" ErrorMessage="Preencha o campo Faixa Início para continuar."
                                                                                                    Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator>
                                                                                    à &nbsp;<cc6:OnlyDecimalTextBox ID="txt_faixa_final" runat="server" AutoUpdateAfterCallBack="True"
                                                                                        CssClass="texto" MaxCaracteristica="10" MaxMantissa="4" MaxLength="15"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator
                                                                                            ID="rfv_faixafinal" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_faixa_final"
                                                                                            CssClass="texto" ErrorMessage="Preencha o campo Faixa Fim para continuar."
                                                                                            Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator><strong></strong></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" class="texto" style="height: 20px" colspan="8">
                                                                                    &nbsp;
                                                                                    &nbsp;<strong></strong>&nbsp;<anthem:CustomValidator ID="cv_parametroqualidade" runat="server"
                                                                                        Font-Bold="True" ForeColor="White" ValidationGroup="vg_qualidade">[!]</anthem:CustomValidator>
                                                                                    <anthem:Button ID="btn_incluirqualidade" runat="server" CssClass="texto" Text="Incluir Qualidade" ValidationGroup="vg_qualidade" AutoUpdateAfterCallBack="True" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" class="texto" style="height: 16px" colspan="8">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="texto" colspan="8">
                                                                                    <anthem:GridView ID="grdQualidade" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                                                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_poupanca_parametro_qualidade"
                                                                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                                                        UseAccessibleHeader="False" Visible="False" Width="98%">
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                            ForeColor="White" HorizontalAlign="Left" />
                                                                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                            HorizontalAlign="Center" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Per&#237;odo Ini">
                                                                                                <edititemtemplate>
&nbsp; <asp:Label id="lbl_dt_referencia_ini" runat="server" Text='<%# Bind("dt_referencia_ini") %>' __designer:wfdid="w13"></asp:Label> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="lbl_dt_referencia_ini" runat="server" Text='<%# Bind("dt_referencia_ini") %>' __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Per&#237;odo Fim">
                                                                                                <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_referencia_fim_qualidade" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" ErrorMessage="Data Invalida." Width="55px" DateMask="MonthYear" MaxLength="7" Text='<%# Bind("dt_referencia_fim") %>' __designer:wfdid="w9" DateFormat="Brazil"></cc4:OnlyDateTextBox><anthem:RequiredFieldValidator id="rf_dt_referencia_fim" __designer:dtid="2251816993554552" runat="server" ValidationGroup="vg_grid" Font-Bold="True" CssClass="texto" ToolTip="O campo Período Fim deve ser informado." ErrorMessage="Preencha o campo Período Fim para continuar." ControlToValidate="txt_dt_referencia_fim_qualidade" __designer:wfdid="w10">[!]</anthem:RequiredFieldValidator> <anthem:CustomValidator id="cv_parametrogrid" __designer:dtid="9570174977966234" runat="server" ValidationGroup="vg_grid" Font-Bold="True" __designer:wfdid="w11" OnServerValidate="cv_parametrogrid_ServerValidate">[!]</anthem:CustomValidator> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="lbl_dt_referencia_fim" runat="server" Text='<%# Bind("dt_referencia_fim") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Rej. Antibi&#243;tico">
                                                                                                <edititemtemplate>
&nbsp;<anthem:Image id="img_rejeicao_antibiotico" runat="server" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" AutoUpdateAfterCallBack="True" __designer:wfdid="w12"></anthem:Image> 
</edititemtemplate>
                                                                                                <itemtemplate>
<anthem:Image id="img_rejeicao_antibiotico" runat="server" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" AutoUpdateAfterCallBack="True" __designer:wfdid="w11"></anthem:Image> 
</itemtemplate>
                                                                                                <headerstyle horizontalalign="Center" />
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="An&#225;lises Rom.">
                                                                                                <edititemtemplate>
<anthem:Image id="img_analises_romaneio" runat="server" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" AutoUpdateAfterCallBack="True" __designer:wfdid="w10"></anthem:Image>
</edititemtemplate>
                                                                                                <itemtemplate>
<anthem:Image id="img_analises_romaneio" runat="server" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" AutoUpdateAfterCallBack="True" __designer:wfdid="w9"></anthem:Image>
</itemtemplate>
                                                                                                <headerstyle horizontalalign="Center" />
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="nm_categoria" HeaderText="Categoria" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Ini Poupan&#231;a" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Fim Poupan&#231;a" ReadOnly="True" />
                                                                                            <asp:TemplateField ShowHeader="False">
                                                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w4" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w5" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" __designer:dtid="2251816993554643" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w6"></asp:ValidationSummary> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" __designer:wfdid="w2" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Parâmetro de Qualidade de Poupança" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w3" CommandName="delete" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro de parâmetro de qualidade de poupança?' )) return true;else return false;" CommandArgument='<%# Bind("id_poupanca_parametro_qualidade") %>'></anthem:ImageButton> 
</itemtemplate>
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_poupanca_parametro_qualidade" Visible="False">
                                                                                                <edititemtemplate>
<asp:Label id="lbl_id_poupanca_parametro_qualidade" runat="server" Text='<%# Bind("id_poupanca_parametro_qualidade") %>' __designer:wfdid="w49"></asp:Label>&nbsp;&nbsp; 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="lbl_id_poupanca_parametro_qualidade" runat="server" Text='<%# Bind("id_poupanca_parametro_qualidade") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="id_categoria" HeaderText="id_categoria" ReadOnly="True" Visible="False" />
                                                                                            <asp:TemplateField HeaderText="st_rejeicao_antibiotico" Visible="False">
                                                                                                <edititemtemplate>
<asp:Label id="st_rejeicao_antibiotico" runat="server" Text='<%# Bind("st_rejeicao_antibiotico") %>' __designer:wfdid="w14"></asp:Label> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="st_rejeicao_antibiotico" runat="server" Text='<%# Bind("st_rejeicao_antibiotico") %>' __designer:wfdid="w13"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="st_analises_romaneio" Visible="False">
                                                                                                <edititemtemplate>
<asp:Label id="st_analises_romaneio" runat="server" Text='<%# Bind("st_analises_romaneio") %>' __designer:wfdid="w18"></asp:Label>
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="st_analises_romaneio" runat="server" Text='<%# Bind("st_analises_romaneio") %>' __designer:wfdid="w13"></asp:Label>
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                                                    </anthem:GridView>
                                                                                    &nbsp; &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        &nbsp;&nbsp;<br />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
															</TABLE>
														</TD>
													</TR>

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
                                                                        </anthem:DropDownList></td>
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
					<TD style="width: 7px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_qualidade"></asp:ValidationSummary>
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
