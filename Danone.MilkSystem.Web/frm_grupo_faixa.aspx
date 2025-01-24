<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_grupo_faixa.aspx.vb" Inherits="frm_grupo_faixa" %>

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
    <title>Romaneio Cooperativa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Faixa Volume</STRONG></TD>
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
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados do Grupo</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px" class="texto" align=right width="23%">
                                    <strong>
                                        <asp:Label ID="lbl_label_nm_grupo" runat="server" CssClass="texto" Text="Número do Grupo:" Visible="False"></asp:Label></strong></TD>
								<TD style="HEIGHT: 20px">
                                    &nbsp;<asp:Label ID="lbl_nr_grupo" runat="server" CssClass="texto"></asp:Label></TD>
							</TR>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
	                                <SPAN id="Span3" class="obrigatorio">*</span><STRONG> Nome Grupo:</strong></td>
	                            <TD class="texto">
	                                &nbsp;<anthem:TextBox ID="txt_nm_grupo" runat="server"
	                                    CssClass="texto" MaxLength="50" Width="232px"></anthem:TextBox>
	                                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_nm_grupo"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Nome do Grupo para continuar."
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
<cc6:OnlyDecimalTextBox id="txt_nr_faixa_inicio" runat="server" CssClass="texto" MaxLength="15" MaxCaracteristica="14" MaxMantissa="4" DecimalSymbol="," __designer:wfdid="w80"></cc6:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" ControlToValidate="txt_nr_faixa_inicio" ErrorMessage="O número da faixa inicial deve ser preenchido." Font-Bold="True" __designer:wfdid="w94">[!]</asp:RequiredFieldValidator> 
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
                                            <asp:BoundField DataField="nm_faixa_volume" HeaderText="Descri&#231;&#227;o Faixa"
                                                SortExpression="nm_faixa_volume">
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
								<TD class="texto" align="right" width="23%" style="height: 6px"></TD>
	                            <TD style="height: 6px"></TD>
	                        </TR>
                            <tr>
                                <td class="titmodulo" colspan="2" width="23%">
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
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
