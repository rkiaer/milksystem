<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_contrato_faixa_qualidade.aspx.vb" Inherits="frm_contrato_faixa_qualidade" %>

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
    <title>Contrato - Faixa Qualidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Contrato - Faixa Qualidade</STRONG></TD>
					<TD style="width: 9px">&nbsp;</TD>
				</TR>
				<TR>
					<TD  ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD align="center" class="texto">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="99%">
													<TR>
														<TD class="titmodulo" colSpan="5" align="left"> Descrição Contrato</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 18%; height: 19px;">
                                                            <strong>Estabelecimento:</strong></td>
                                                        <td align="left" style="height: 19px" >
                                                            <anthem:Label ID="lbl_estabelecimento" runat="server" CssClass="texto"></anthem:Label></td>
                                                        <td class="texto" align="right" style="width: 15%; height: 19px;" >
                                                            <strong>Contrato Padrão (default):</strong></td>
                                                        <td class="texto" align="left" style="width: 15%; height: 19px;" >
                                                            <anthem:Label ID="lbl_contrato_padrao" runat="server" CssClass="texto"></anthem:Label></td>
                                                        <td class="texto" align="left" style="width: 20%; height: 19px;">
                                                            <strong>Contrato Mercado:</strong>
                                                            <anthem:Label ID="lbl_contrato_mercado" runat="server" CssClass="texto">Não</anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 19px" >
                                                            <strong>Contrato:</strong></td>
                                                        <td align="left" class="texto" style="height: 19px" >
                                                            <anthem:Label ID="lbl_contrato" runat="server" CssClass="texto"></anthem:Label></td>
                                                        <td class="texto" align="right" style="height: 19px" >
                                                            <strong>Situação:</strong></td>
                                                        <td class="texto" align="left" style="height: 19px" >
                                                            <anthem:Label ID="lbl_situacao" runat="server" CssClass="texto"></anthem:Label></td>
                                                        <td class="texto" align="left" style="height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 19px" >
                                                            <strong>Referência Válida a Partir:</strong></td>
                                                        <td align="left" class="texto" style="height: 19px" >
                                                            <anthem:Label ID="lbl_referencia" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label></td>
                                                        <td class="texto" align="right" style="height: 19px" >
                                                            <strong>Situação Contrato Validade:</strong></td>
                                                        <td class="texto" align="left" style="height: 19px" >
                                                            <anthem:Label ID="lbl_situacao_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                        <td class="texto" align="left" style="height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 9px" colspan="5" >
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="titmodulo" colSpan="5" align="left">
                                                            Faixa de Qualidade</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" colspan="5" style="height: 9px" >
                                                            <span id="Span6" class="obrigatorio"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="texto" style="width: 100%" colspan="5" valign="top" >
                                                            <table id="Table8" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="6" valign="bottom">
                                                                        <anthem:Panel ID="Panel1" runat="server" BackColor="White" Font-Size="XX-Small" GroupingText="Filtro Faixa Qualçidade"
                                                                            Width="98%">
                                                                            <table id="Table5" cellpadding="0" cellspacing="0" class="texto" width="99%">
                                                                                <tr>
                                                                                    <td colspan="3" style="height: 8px">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="width: 30%; height: 20px;">
                                                                                        &nbsp;Categoria:&nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" Width="105px">
                                                                                        </anthem:DropDownList>&nbsp;
                                                                                    </td>
                                                                                    <td align="right" style="height: 20px;">
                                                                                        &nbsp;</td>
                                                                                    <td align="left" style="height: 20px">
                                                                                        &nbsp;<anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                                                                            ValidationGroup="vg_pesquisar" />
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                        &nbsp;&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </anthem:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" id="tr_painelincluir" visible="true">
                                                                    <td align="center" class="texto" colspan="6" valign="bottom">
                                                                        <anthem:Panel ID="Panel2" runat="server" BackColor="White" Font-Size="XX-Small" GroupingText="Incluir Faixa Qualçidade"
                                                                            Width="98%">
                                                                            <table id="Table6" cellpadding="0" cellspacing="0" class="texto" width="100%">
                                                                                <tr>
                                                                                    <td colspan="6" style="height: 12px">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="texto" style="width: 18%; color: #000000; height: 20px">
                                                                                        <strong><span style="color: #ff0000">*</span>Categoria:</strong>
                                                            <anthem:DropDownList ID="cbo_categoria_qualidade" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" Width="105px">
                                                            </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_categoria_qualidade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td align="right" class="texto" style="width: 16%; height: 20px">
                                                                                        <strong><span style="color: #ff0000">*</span>Faixa Ini:</strong>
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_faixa_inicio" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4" Width="75px"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_faixa_inicio"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Faixa Inicial para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td align="right" class="texto" style="height: 20px; width: 16%;">
                                                                                        <strong>Faixa Fim:</strong>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_nr_faixa_fim" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4" Width="75px"></cc6:OnlyDecimalTextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_nr_faixa_inicio"
                                                                ControlToValidate="txt_nr_faixa_fim" CssClass="texto" ErrorMessage="Faixa Inicial não pode ser menor que Faixa Final"
                                                                Font-Bold="True" Operator="GreaterThanEqual" Type="Double" ValidationGroup="vg_qualidade">[!]</asp:CompareValidator><anthem:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_faixa_fim"
                                                                    CssClass="texto" ErrorMessage="Preencha o campo Faixa Fim para continuar." Font-Bold="True"
                                                                    ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td style="width: 16%" align="right">
                                                                                        <strong><span style="color: #ff0000">*</span>Bônus/Desc.:</strong>
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_bonus_desconto" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxMantissa="4" Width="50px"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nr_bonus_desconto"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Bônus / Desconto para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td style="width: 18%" align="right">
                                                                                        <strong><span style="color: #ff0000">*</span>Unid.Medida:</strong>&nbsp;<anthem:DropDownList ID="cbo_un_medida" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="80px">
                                                            </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_un_medida"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Unidade Medida para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_qualidade">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td align="right">
                                                                                    <anthem:CustomValidator ID="cv_qualidade" runat="server" Font-Bold="True"
                                                                            ForeColor="White" ValidationGroup="vg_qualidade" CssClass="texto">[!]</anthem:CustomValidator><anthem:Button ID="btn_incluirqualidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Text="Incluir Qualidade" ValidationGroup="vg_qualidade" Width="108px" />&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="texto" style="height: 12px" >
                                                                                    </td>
                                                                                    <td align="right" class="texto" style="height: 12px" >
                                                                                    </td>
                                                                                    <td align="right" class="texto" style="height: 12px" >
                                                                                    </td>
                                                                                    <td align="right" colspan="3" style="height: 12px" >
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </anthem:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="6">
                                                                        <anthem:GridView ID="grdQualidade" runat="server" AutoGenerateColumns="False"
                                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_faixa_qualidade"
                                                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True" Visible="False" Width="98%" AllowPaging="True" AllowSorting="True">
                                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                ForeColor="White" HorizontalAlign="Left" />
                                                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                HorizontalAlign="Center" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="nm_categoria" HeaderText="Categoria" ReadOnly="True" SortExpression="nm_categoria" />
                                                                                <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a Partir" />
                                                                                <asp:BoundField DataField="nr_faixa_inicio" HeaderText="Faixa Inicial" SortExpression="nr_faixa_inicio" />
                                                                                <asp:BoundField DataField="nr_faixa_fim" HeaderText="Faixa Final" ReadOnly="True" SortExpression="nr_faixa_fim" />
                                                                                <asp:BoundField DataField="nr_bonus_desconto" HeaderText="B&#244;nus/Desconto" />
                                                                                <asp:BoundField HeaderText="Unid.Medida" DataField="un_medida" />
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w4" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w5" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" __designer:dtid="2251816993554643" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w6"></asp:ValidationSummary> 
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" CommandName="Edit" __designer:wfdid="w20"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# Bind("id_faixa_qualidade") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de faixa de qualidade?' )) return true;else return false;" ImageAlign="Baseline" ToolTip="Excluir Faixa de Qualidade" __designer:wfdid="w3"></anthem:ImageButton> 
</itemtemplate>
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_faixa_qualidade" Visible="False">
                                                                                    <edititemtemplate>
<asp:Label id="lbl_id_faixa_qualidade" runat="server" Text='<%# Bind("id_faixa_qualidade") %>' __designer:wfdid="w49"></asp:Label>&nbsp;&nbsp; 
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_faixa_qualidade" runat="server" Text='<%# Bind("id_faixa_qualidade") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="id_categoria" HeaderText="id_categoria" ReadOnly="True"
                                                                                    Visible="False" />
                                                                            </Columns>
                                                                            <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                                        </anthem:GridView>
                                                                        &nbsp; &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server" visible="false">
                                                        <td align="left" colspan="5">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" align="left">Dados do Sistema</TD>
																</TR>
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
                                                        </td>
													</TR>
												</TABLE>
								</TD>
								<TD style="width: 1px" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" ></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" 
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD  bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_qualidade"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
