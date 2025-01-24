<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_gold_faixa.aspx.vb" Inherits="frm_gold_faixa" %>

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
    <title>Faixas GOLD</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Faixas GOLD</STRONG></TD>
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
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
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
                                    &nbsp;&nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>&nbsp;
                                    <anthem:RequiredFieldValidator ID="rqf_estabelecimento" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <span id="Span1" class="obrigatorio">*</span><strong>V�lido a partir de:</strong></td>
                                <td width="77%">
                                    &nbsp;
                                    <cc4:OnlyDateTextBox ID="txt_dt_referencia_inicial" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="72px"></cc4:OnlyDateTextBox>&nbsp;&nbsp;<anthem:RequiredFieldValidator ID="rqf_dt_referencia_inicial"
                                            runat="server" ControlToValidate="txt_dt_referencia_inicial" CssClass="texto"
                                            ErrorMessage="Preencha o campo Data Validade Inicial para continuar." Font-Bold="True"
                                            ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                ID="cv_data_validade" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_referencia_inicial"
                                                CssClass="texto" Font-Bold="True"
                                                SetFocusOnError="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <span id="Span2" class="obrigatorio">*</span><strong>Tipo da Faixa:</strong></td>
                                <td width="77%">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo_faixa" runat="server" CssClass="texto">
                                        <asp:ListItem Value="1">Custo Efetivo</asp:ListItem>
                                        <asp:ListItem Value="2">Volume</asp:ListItem>
                                        <asp:ListItem Value="3">Crescimento</asp:ListItem>
                                        <asp:ListItem Value="4">Efici&#234;ncia Dieta</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">Selecione</asp:ListItem>
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_tipo_faixa"
                                        CssClass="texto" ErrorMessage="Preencha o campo Tipo da Faixa para continuar." Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <span id="Span3" class="obrigatorio">*</span><strong> Nome Faixa:</strong></td>
                                <td class="texto">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_faixa" runat="server" CssClass="texto" MaxLength="200"
                                        Width="350px"></anthem:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_nm_faixa"
                                        CssClass="texto" ErrorMessage="Preencha o campo Nome da Faixa para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                    &nbsp;&nbsp; &nbsp;&nbsp;</td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%"></td>
	                            <TD></td>
	                        </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados das Faixas</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
	                                <br />
	                                <anthem:GridView ID="grdFaixas" runat="server"
	                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="80%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True">
	                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
	                                    <Columns>
	                                        <asp:TemplateField HeaderText="Descri&#231;&#227;o Faixa">
	                                            <itemtemplate>
<anthem:TextBox id="txt_nm_faixa" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="208px" MaxLength="50" UpdateAfterCallBack="True" __designer:wfdid="w84"></anthem:TextBox>&nbsp;&nbsp;&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" ControlToValidate="txt_nm_faixa" ErrorMessage="Preencha o campo Placa para continuar." Font-Bold="True" ToolTip="Placa deve ser preenchida." __designer:wfdid="w92">[!]</anthem:RequiredFieldValidator> 
</itemtemplate>
	                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nr Faixa In&#237;cial">
                                                <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_faixa_inicio" runat="server" CssClass="texto" MaxLength="15" MaxCaracteristica="14" MaxMantissa="4" DecimalSymbol="," __designer:wfdid="w80"></cc6:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" ControlToValidate="txt_nr_faixa_inicio" ErrorMessage="O n�mero da faixa inicial deve ser preenchido." Font-Bold="True" __designer:wfdid="w94">[!]</asp:RequiredFieldValidator> 
</itemtemplate>
                                            </asp:TemplateField>
	                                        <asp:TemplateField HeaderText="Nr Faixa Final">
	                                            <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_faixa_fim" runat="server" CssClass="texto" MaxLength="15" MaxCaracteristica="10" MaxMantissa="4" DecimalSymbol="," __designer:wfdid="w82"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:TemplateField>
	                                            <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CommandName="delete" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" __designer:wfdid="w86"></anthem:ImageButton> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                    </Columns>
	                                </anthem:GridView><anthem:GridView ID="grdfaixaconsulta" runat="server"
	                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="80%" CellPadding="4" CssClass="texto" Height="8px" AllowSorting="True" Visible="False">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="ds_gold_faixa" HeaderText="Descri&#231;&#227;o Faixa"
                                                SortExpression="ds_gold_faixa">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nr_faixa_inicio"  HeaderText="Nr Faixa Inicial"
                                                SortExpression="nr_faixa_inicio" >
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nr_faixa_fim" HeaderText="Nr Faixa Final">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </anthem:GridView>
                                    <anthem:CustomValidator ID="cv_validar_faixas_grid" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>&nbsp;
                                    <anthem:CustomValidator ID="cv_grid" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ErrorMessage="Uma placa deve ser informada como Principal para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator><br />
                                    &nbsp;<anthem:Button ID="btn_nova_faixa" runat="server" Text="Adicionar" ToolTip="Adicionar nova escolaridade" />
	                            </td>
	                        </tr>
	                        <TR>
								<TD class="texto" align="right" style="height: 6px" colspan="2">
                                </TD>
	                        </TR>
                            <tr>
                                <td class="titmodulo" colspan="2" width="23%" style="height: 15px">
                                    Dados do Sistema</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <strong>Situa��o:</strong></td>
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
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" OnClientClick="if (confirm('Deseja realmente salvar a Faixa? Ap�s salvar, os �nicos dados que poder�o ser alterados posteriormente s�o o Nome da Faixa e a Situa��o')) return true;else return false;">Salvar</asp:LinkButton></TD>
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
