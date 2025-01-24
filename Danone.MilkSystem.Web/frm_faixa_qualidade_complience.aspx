<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_faixa_qualidade_complience.aspx.vb" Inherits="frm_faixa_qualidade_complience" %>

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
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Faixa Compliance</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Faixa Compliance</STRONG></TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; ">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar" OnClientClick="if (confirm('Após salvar os dados, os campos não poderão ser mais alterados. Deseja prosseguir?')) return true;else return false;">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados Gerais</TD>
							</TR>
                            <tr>
                                <td align="right" class="texto" style="height: 20px">
                                    &nbsp;<span id="Span4" class="obrigatorio">*<strong><span style="color: #000000">Estabelecimento:</span></strong></span></td>
                                <td class="texto" style="height: 20px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>&nbsp;
                                    <anthem:RequiredFieldValidator ID="rqf_estabelecimento" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <span id="Span1" class="obrigatorio">*</span><strong>Válido a partir de:</strong></td>
                                <td width="77%">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_validade" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="72px"></cc4:OnlyDateTextBox>&nbsp;&nbsp;<anthem:RequiredFieldValidator ID="rqf_dt_referencia_inicial"
                                            runat="server" ControlToValidate="txt_dt_validade" CssClass="texto"
                                            ErrorMessage="Preencha o campo Data Validade Inicial para continuar." Font-Bold="True"
                                            ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <span id="Span2" class="obrigatorio">*</span><strong>Categoria:</strong></td>
                                <td width="77%">
                                    &nbsp;<anthem:DropDownList
                                            ID="cbo_categoria_qualidade" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" Width="112px">
                                        </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_categoria_qualidade"
                                        CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar." Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
                                    <strong><span style="color: #ff0000">*</span> Descrição Faixa:</strong></td>
	                            <TD>
                                    &nbsp;<anthem:TextBox ID="txt_ds_faixa_qualidade_complience" runat="server" CssClass="texto"
                                        MaxLength="200" Width="350px"></anthem:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_ds_faixa_qualidade_complience"
                                        CssClass="texto" ErrorMessage="Preencha o campo Descrição da Faixa para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
	                        </tr>
                            
                            </table>
                            
                            <table id="Table10" cellspacing="0" cellpadding="2" width="100%" border="0">
						
						                 <tr>
                                                <td class="texto" align="right" style="height: 24px; width: 23%;" >
                                                    <strong class="texto">&nbsp;<span style="color: #ff0000">*</span> Operador:</strong></td>
                                                <td style="height: 24px; width: 127px;" align="left" >&nbsp;<anthem:DropDownList ID="cbo_operador" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nr_valor"
                                        CssClass="texto" ErrorMessage="Preencha o campo Operador para continuar." Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                <td class="texto" align="right" style="height: 24px; width: 42px;" >
                                                    <strong class="texto"><span style="color: #ff0000">*</span> Valor:</strong></td>
                                                <td align="left" style="height: 24px" >
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor" runat="server" CssClass="texto"
                                        DecimalSymbol="," MaxCaracteristica="14" MaxLength="15" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_valor"
                                        CssClass="texto" ErrorMessage="Preencha o campo Valor da Faixa para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                        </table>
                            
                            <TABLE id="Table3" cellSpacing=0 cellPadding=2 width="100%" border=0>
                            <tr>
                                <td class="titmodulo" colspan="2" width="23%" style="height: 15px">
                                    Dados do Sistema</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <strong>Situação:</strong></td>
                                <td>
                                    &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <strong></strong></td>
                                <td>
                                    &nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto">
                                    </td>
                                <td>
                                    &nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
	                        <TR>
								<TD style="HEIGHT: 13px" class="texto" align=right width="23%"></TD>
								<TD style="HEIGHT: 13px"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px"></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" OnClientClick="
if (confirm('Deseja realmente salvar a Faixa? Após salvar, os únicos dados que poderão ser alterados posteriormente são a Descrição da Faixa e a Situação')) return true;else return false;">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
										
					</TD>
					<TD width="1" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
