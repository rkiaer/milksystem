<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_coleta_amostra_periodo.aspx.vb" Inherits="frm_coleta_amostra_periodo" %>

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
    <title>Períodos para Coletas das Amostras</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Período para Coleta das Amostras</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; &nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                     </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
                    <TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
					    <TR>
						    <TD class="titmodulo" colSpan="2" style="height: 10px"> Dados<anthem:CustomValidator ID="cv_salvar" runat="server"
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
                                <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Referência:</strong></td>
                            <td width="77%" class="texto">
                                &nbsp;<cc4:OnlyDateTextBox ID="txt_referencia" runat="server" CssClass="texto"
                                    DateMask="MonthYear" Width="71px"></cc4:OnlyDateTextBox>
                                <anthem:RequiredFieldValidator
                                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar."
                                        Font-Bold="True" ToolTip="O campo Referência deve ser informado."
                                        ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" class="texto" width="23%">
                                <strong> Última Rota Carregada Coletor:</strong></td>
                            <td>
                                &nbsp;<anthem:Label ID="lbl_ultima_coleta" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="texto" width="23%" style="height: 15px">
                                </td>
                            <td style="height: 15px">
                                </td>
                        </tr>
                        <TR>
						    <TD class="titmodulo"  colSpan="2" style="height: 15px"> Período para COLETAS Regulares Automáticas (em dias)</TD>
					    </TR>
                        
                        <tr>
                            <td align="left" class="texto" colspan="2">
                            <table class="texto" width="100%">
                                <tr><td style="width: 15%"></td>
                                <td>
                                    <br />
                                <table border="0" class="texto" style="border-left: scrollbar 1px solid; border-top-width: 1px; border-top-color: scrollbar; border-right-width: 1px; border-right-color: scrollbar; border-bottom-width: 1px; border-bottom-color: scrollbar;" cellspacing="0">
                                    <tr>
                                        <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: scrollbar 1px solid;" class="texto">
                                            Tipo Coleta</td>
                                        <td align="center" style="border-right: #c8c8c8 1px solid;width: 108px; font-weight: bold; height: 22px; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; border-top: scrollbar 1px solid;">
                                            Dia Inicial</td>
                                        <td align="center" style="border-right: scrollbar 1px solid; width: 108px; font-weight: bold; height: 22px; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; border-top: scrollbar 1px solid;">
                                            Dia Final</td>
                                        <td style="border: none; " ></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 91px; height: 22px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; border-top: #c8c8c8 1px solid;" class="texto">
                                            <span style="color: #ff0000">*</span>1a. Coleta</td>
                                        <td style="width: 108px; height: 22px; border-top: #c8c8c8 1px solid;border-right: #c8c8c8 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_ini_1col" runat="server" CssClass="texto" MaxLength="2"
                                                Width="30px"></cc3:OnlyNumbersTextBox></td>
                                        <td style="width: 108px; height: 22px; border-top: #c8c8c8 1px solid; border-right: scrollbar 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_fim_1col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                         <td style="border: none; " class="texto" >
                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_dia_ini_1col"
                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Inicial 1a. Coleta' para continuar."
                                                Font-Bold="True" ToolTip="O campo 'Dia Inicial da 1a Coleta' deve ser informado."
                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_dia_fim_1col"
                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Final 1a. Coleta' para continuar."
                                                Font-Bold="True" ToolTip="O campo 'Dia Final 1a. Coleta' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RangeValidator
                                                    ID="RangeValidator1" runat="server" ControlToValidate="txt_dia_ini_1col" ErrorMessage="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                                    MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                                    Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim_1col"
                                                 ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                                 MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                 Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_dia_ini_1col"
                                                ControlToValidate="txt_dia_fim_1col" ErrorMessage="O campo 'Dia Final da 1a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 1a Coleta'."
                                                Operator="GreaterThanEqual" ToolTip="O campo 'Dia Final da 1a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 1a Coleta'."
                                                Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></td>
                                   </tr>
                                    <tr>
                                        <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: #c8c8c8 1px solid;" class="texto">
                                            <span style="color: #ff0000">*</span>2a. Coleta</td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid; border-right: #c8c8c8 1px solid; height: 22px;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_ini_2col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid; height: 22px; border-right: scrollbar 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_fim_2col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                            <td style="border: none; " >
                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_dia_ini_2col"
                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Inicial 2a. Coleta' para continuar."
                                                Font-Bold="True" ToolTip="O campo 'Dia Inicial 2a. Coleta' deve ser informado."
                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dia_fim_2col"
                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Final 2a. Coleta' para continuar."
                                                Font-Bold="True" ToolTip="O campo 'Dia Final 2a. Coleta' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RangeValidator
                                                    ID="RangeValidator3" runat="server" ControlToValidate="txt_dia_ini_2col" ErrorMessage="O Dia Inicial da 2a Coleta deve estar entre 1 e 30."
                                                    MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial da 2a Coleta deve estar entre 1 e 30."
                                                    Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                        ID="RangeValidator4" runat="server" ControlToValidate="txt_dia_fim_2col" ErrorMessage="O Dia Final da 2a Coleta deve estar entre 1 e 30."
                                                        MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 2a Coleta deve estar entre 1 e 30."
                                                        Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                            ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini_2col" ControlToValidate="txt_dia_fim_2col"
                                                            ErrorMessage="O campo 'Dia Final da 2a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 2a Coleta'."
                                                            Operator="GreaterThanEqual" ToolTip="O campo 'Dia Final da 2a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 2a Coleta'."
                                                            Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></td>
                                </tr>
                                    <tr>
                                        <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: #c8c8c8 1px solid;" class="texto">
                                            3a. Coleta</td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid; border-right: #c8c8c8 1px solid; height: 22px;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_ini_3col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid; height: 22px; border-right: scrollbar 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_fim_3col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                        <td style="border: none; " >
                                            <anthem:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_dia_ini_3col"
                                                ErrorMessage="O Dia Inicial da 3a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                                MinimumValue="1" ToolTip="O Dia Inicial da 3a Coleta deve estar entre 1 e 30."
                                                Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                    ID="RangeValidator6" runat="server" ControlToValidate="txt_dia_fim_3col" ErrorMessage="O Dia Final da 3a Coleta deve estar entre 1 e 30."
                                                    MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 3a Coleta deve estar entre 1 e 30."
                                                    Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                        ID="CompareValidator3" runat="server" ControlToCompare="txt_dia_ini_3col" ControlToValidate="txt_dia_fim_3col"
                                                        ErrorMessage="O campo 'Dia Final da 3a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 3a Coleta'."
                                                        Operator="GreaterThanEqual" ToolTip="O campo 'Dia Final da 3a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 3a Coleta'."
                                                        Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator>
                                               </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="width: 91px; border-right: #c8c8c8 1px solid; font-weight: bold; font-size: 10px; font-family: Verdana, Arial, Helvetica, sans-serif; height: 22px; border-top: #c8c8c8 1px solid; border-bottom: scrollbar 1px solid;" class="texto">
                                            4a. Coleta</td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid;border-right: #c8c8c8 1px solid; height: 22px; border-bottom: scrollbar 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_ini_4col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                        <td style="width: 108px; border-top: #c8c8c8 1px solid; height: 22px; border-right: scrollbar 1px solid; border-bottom: scrollbar 1px solid;" align="center">
                                            <cc3:OnlyNumbersTextBox ID="txt_dia_fim_4col" runat="server" CssClass="texto"
                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox></td>
                                            <td style="border: none; " >
                                                <anthem:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_dia_ini_4col"
                                                    ErrorMessage="O Dia Inicial da 4a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                                    MinimumValue="1" ToolTip="O Dia Inicial da 4a Coleta deve estar entre 1 e 30."
                                                    Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                        ID="RangeValidator8" runat="server" ControlToValidate="txt_dia_fim_4col" ErrorMessage="O Dia Final da 4a Coleta deve estar entre 1 e 30."
                                                        MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 4a Coleta deve estar entre 1 e 30."
                                                        Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                            ID="CompareValidator4" runat="server" ControlToCompare="txt_dia_ini_4col" ControlToValidate="txt_dia_fim_4col"
                                                            ErrorMessage="O campo 'Dia Final da 4a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 4a Coleta'."
                                                            Operator="GreaterThanEqual" ToolTip="O campo 'Dia Final da 4a Coleta&quot; deve ser maior ou igual ao &quot;Dia Inicial da 4a Coleta'."
                                                            Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></td>
                                </tr>
                                </table>
                                </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="texto" colspan="2">
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
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
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
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            &nbsp;
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
