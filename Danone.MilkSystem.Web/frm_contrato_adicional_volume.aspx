<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_contrato_adicional_volume.aspx.vb" Inherits="frm_contrato_adicional_volume" %>

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
    <title>Contrato - Adicional de Volume</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Contrato - Adicional de Volume</STRONG></TD>
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
                                                        <td align="right" class="texto" style="height: 19px">
                                                            <strong>Referência Válida a Partir:</strong></td>
                                                        <td align="left" class="texto" style="height: 19px">
                                                            <anthem:Label ID="lbl_referencia" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label></td>
                                                        <td align="right" class="texto" style="height: 19px">
                                                            <strong>Situação Contrato:</strong></td>
                                                        <td align="left" class="texto" style="height: 19px">
                                                            <anthem:Label ID="lbl_situacao_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                        <td align="left" class="texto" style="height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 8px" colspan="5" >
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="titmodulo" colSpan="5" align="left">
                                                            Adicional de Volume</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" colspan="5" >
                                                            <span id="Span6" class="obrigatorio"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="texto" style="width: 100%" colspan="5" valign="bottom" >
                                                            <table id="Table8" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                <tr runat="server" visible="false" id="tr_pesquisa">
                                                                    <td align="center" class="texto" colspan="6" valign="bottom">
                                                                        <anthem:Panel ID="Panel1" runat="server" BackColor="White" Font-Size="XX-Small" GroupingText="Filtro Adicional de Volume"
                                                                            Width="98%">
                                                                            <table id="Table5" cellpadding="0" cellspacing="0" class="texto" width="99%">
                                                                                <tr>
                                                                                    <td colspan="3" style="height: 15px">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="width: 18%;">
                                                                                        Litros/Dia:
                                                                                        <cc3:OnlyNumbersTextBox ID="OnlyNumbersTextBox1" runat="server" CssClass="texto"
                                                                                            MaxLength="6" Width="71px"></cc3:OnlyNumbersTextBox>
                                                                                    </td>
                                                                                    <td align="right" style="width: 15%;">
                                                                                        Situação:
                                                                                        <anthem:DropDownList ID="DropDownList2" runat="server" AutoCallBack="True"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto">
                                                                                            <asp:ListItem Selected="True" Value="1">Ativo</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Inativo</asp:ListItem>
                                                                                        </anthem:DropDownList>&nbsp;</td>
                                                                                    <td align="right">
                                                                                        &nbsp;<anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                                                                            ValidationGroup="vg_pesquisar" />
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                        &nbsp;&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </anthem:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr_painelincluir" runat="server" >
                                                                    <td align="center" class="texto" colspan="6" valign="bottom">
                                                                        <anthem:Panel ID="Panel2" runat="server" BackColor="White" Font-Size="XX-Small" GroupingText="Incluir Adicional de Volume"
                                                                            Width="98%">
                                                                            <table id="Table6" cellpadding="0" cellspacing="0" class="texto" width="99%">
                                                                                <tr>
                                                                                    <td colspan="5" style="height: 15px">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="texto" style="width: 22%; color: #000000; height: 20px">
                                                                                        <strong><span style="color: #ff0000">*</span>L/Dia: DE</strong>
                                                                                        <cc3:OnlyNumbersTextBox ID="txt_nr_litros_ini" runat="server" AutoUpdateAfterCallBack="True"
                                                                                            CssClass="texto" MaxLength="6" Width="42px"></cc3:OnlyNumbersTextBox>
                                                                                        ATÉ
                                                                                        <cc3:OnlyNumbersTextBox ID="txt_nr_litros_fim" runat="server" AutoUpdateAfterCallBack="True"
                                                                                            CssClass="texto" MaxLength="6" Width="42px"></cc3:OnlyNumbersTextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_nr_litros_ini"
                                                                ControlToValidate="txt_nr_litros_fim" CssClass="texto" ErrorMessage="Litros por dia (L/Dia) Inicial (DE) não pode ser menor que Litros por Dia (L/Dia) Final (ATÉ)."
                                                                Font-Bold="True" Operator="GreaterThanEqual" Type="Integer" ToolTip="L/Dia DE não pode ser menor que L/Dia ATÉ." ValidationGroup="vg_incluir">[!]</asp:CompareValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                                                    runat="server" ControlToValidate="txt_nr_litros_fim" CssClass="texto" ErrorMessage="Preencha o campo L/Dia ATÉ para continuar."
                                                                                                    Font-Bold="True" ToolTip="L/Dia ATÉ deve ser informado." ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_nr_litros_ini"
                                                                CssClass="texto" ErrorMessage="Preencha o campo L/Dia DE para continuar."
                                                                Font-Bold="True" ToolTip="L/Dia De deve ser informado." ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td align="right" class="texto" style="width: 34%; height: 20px">
                                                                                        <strong><span style="color: #ff0000">*</span>Indicador:
                                                                                            <anthem:DropDownList ID="cbo_indicador_tipo" runat="server"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto">
                                                                                            </anthem:DropDownList>&nbsp; %:
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_indicador_percentual" runat="server" CssClass="texto"
                                                                MaxCaracteristica="3" MaxMantissa="2" Width="42px" MaxLength="6"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_indicador_percentual"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Percentual CEPEA para continuar."
                                                                Font-Bold="True" ToolTip="CEPEA % deve ser informado." ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                                                            <span style="color: #ff0000">*</span>Ref.:
                                                                                            <anthem:DropDownList ID="cbo_nr_mes_indicador" runat="server"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto">
                                                                                                <asp:ListItem Selected="True" Value="0">M&#234;s Atual</asp:ListItem>
                                                                                                <asp:ListItem Value="-1">M&#234;s -1</asp:ListItem>
                                                                                                <asp:ListItem Value="-2">M&#234;s -2</asp:ListItem>
                                                                                                <asp:ListItem Value="-3">M&#234;s -3</asp:ListItem>
                                                                                                <asp:ListItem Value="-4">M&#234;s -4</asp:ListItem>
                                                                                                <asp:ListItem Value="-5">M&#234;s -5</asp:ListItem>
                                                                                            </anthem:DropDownList></strong></td>
                                                                                    <td align="right" class="texto" style="height: 20px; width: 17%;">
                                                                                        <strong><span style="color: #ff0000">*</span>Adic. 24hrs:</strong>
                                                                        <cc6:OnlyDecimalTextBox ID="txt_nr_adicional_24hrs" runat="server" CssClass="texto"
                                                                MaxCaracteristica="2" MaxMantissa="4" Width="47px" MaxLength="7"></cc6:OnlyDecimalTextBox>
                                                                                        <anthem:DropDownList ID="cbo_st_formato_24hrs" runat="server"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="V - Valor / % - Percentual">
                                                                                            <asp:ListItem Selected="True" Value="V">V</asp:ListItem>
                                                                                            <asp:ListItem Value="P">%</asp:ListItem>
                                                                                        </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nr_adicional_24hrs"
                                                                                            CssClass="texto" ErrorMessage="Preencha o campo Adic. 24hrs para continuar."
                                                                                            Font-Bold="True" ToolTip="Adic. 24hrs deve ser informado." ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td style="width: 17%" align="right">
                                                                                        <strong><span style="color: #ff0000">*</span>Adic. 48hrs:</strong>
                                                            <cc6:OnlyDecimalTextBox ID="txt_nr_adicional_48hrs" runat="server" CssClass="texto"
                                                                MaxCaracteristica="2" MaxMantissa="4" Width="47px" AutoUpdateAfterCallBack="True" MaxLength="7"></cc6:OnlyDecimalTextBox>
                                                                                        <anthem:DropDownList ID="cbo_st_formato48hrs" runat="server"
                                                                AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="V - Valor / % - Percentual">
                                                                                            <asp:ListItem Selected="True" Value="V">V</asp:ListItem>
                                                                                            <asp:ListItem Value="P">%</asp:ListItem>
                                                                                        </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nr_adicional_48hrs"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Adic. 48hrs para continuar."
                                                                Font-Bold="True" ToolTip="O campo Adic. 48hrs deve ser informado." ValidationGroup="vg_incluir">[!]</anthem:RequiredFieldValidator></td>
                                                                                    <td align="right">
                                                                                        <strong><span style="color: #ff0000">
                                                                                    <anthem:CustomValidator ID="cv_adicionalvolume" runat="server" Font-Bold="True"
                                                                            ForeColor="White" ValidationGroup="vg_incluir">[!]</anthem:CustomValidator><anthem:Button ID="btn_incluirqualidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Text="Incluir" ValidationGroup="vg_incluir" Width="59px" /></span></strong></td>
                                                                                </tr>
                                                                            </table>
                                                                        </anthem:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="6">
                                                                        <anthem:GridView ID="grdAdicionalVolume" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_contrato_adicional_volume"
                                                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                                            UseAccessibleHeader="False" Visible="False" Width="98%" PageSize="16000">
                                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                ForeColor="White" HorizontalAlign="Left" />
                                                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                HorizontalAlign="Center" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a Partir" />
                                                                                <asp:BoundField DataField="nr_litros_ini" HeaderText="De L/Dia" SortExpression="nr_litros_ini" />
                                                                                <asp:BoundField DataField="nr_litros_fim" HeaderText="At&#233; L/Dia" ReadOnly="True" SortExpression="nr_litros_fim" />
                                                                                <asp:BoundField DataField="nm_indicador_tipo" HeaderText="Indicador" />
                                                                                <asp:BoundField DataField="nr_indicador_percentual" HeaderText="%"
                                                                                    SortExpression="nr_indicador_percentual" />
                                                                                <asp:TemplateField HeaderText="Ref. Ind.">
                                                                                    <itemtemplate>
<asp:Label id="lbl_referencia_indicador" runat="server" __designer:wfdid="w79"></asp:Label>
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="nr_adicional_24hrs" HeaderText="Adicional 24hrs" SortExpression="nr_adicional_24hrs" />
                                                                                <asp:BoundField DataField="st_formato_24hrs" />
                                                                                <asp:BoundField HeaderText="Adicional 48hrs" DataField="nr_adicional_48hrs" SortExpression="nr_adicional_48hrs" />
                                                                                <asp:BoundField DataField="st_formato_48hrs" />
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w4" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w5" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" __designer:dtid="2251816993554643" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w6"></asp:ValidationSummary> 
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" CommandName="Edit" __designer:wfdid="w75"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Excluir Adicional de Volume" CommandName="delete" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro de adicional de volume?' )) return true;else return false;" CommandArgument='<%# Bind("id_contrato_adicional_volume") %>' __designer:wfdid="w76"></anthem:ImageButton> 
</itemtemplate>
                                                                                    <itemstyle horizontalalign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_contrato_adicional_volume" Visible="False">
                                                                                    <edititemtemplate>
<asp:Label id="lbl_id_contrato_adicional_volume" runat="server" Text='<%# Bind("id_contrato_adicional_volume") %>' __designer:wfdid="w49"></asp:Label>&nbsp;&nbsp; 
</edititemtemplate>
                                                                                    <itemtemplate>
<asp:Label id="lbl_id_contrato_adicional_volume" runat="server" Text='<%# Bind("id_contrato_adicional_volume") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="nr_mes_indicador" Visible="False">
                                                                                    <itemtemplate>
<asp:Label id="lbl_nr_mes_indicador" runat="server" Text='<%# Bind("nr_mes_indicador") %>' __designer:wfdid="w77"></asp:Label>
</itemtemplate>
                                                                                </asp:TemplateField>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
