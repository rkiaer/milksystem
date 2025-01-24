<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_linha_pedagio.aspx.vb" Inherits="frm_linha_pedagio" %>

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
    <title>Rota - Pedágio</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Rota X Pedágio</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
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
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 10px"> Rota</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Rota:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_nm_rota" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação Rota:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_situacao_rota" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 8px" valign="bottom">
                                                            </td>
                                                        <td width="77%" class="texto" style="height: 8px" valign="bottom">
                                                            </td>
                                                    </tr>
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">
                                                                        Pedágio por Eixo</TD>
																</TR>
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="2">
                                                                        <br />
                                                                        <table id="Table8" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                            <tr>
                                                                                <td align="right" class="texto" style="width: 30%; height: 20px" >
                                                                                    <strong>Data Validade a partir de:</strong>
                                                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                                                                        Width="70px"></cc4:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                                                            runat="server" ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="Preencha o campo Período Validade Inicial para continuar."
                                                                                            Font-Bold="False" ValidationGroup="vg_pedagio" ToolTip="O campo Data Validade deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                                                <td align="right" class="texto" style="height: 20px" >
                                                                                    <strong>Valor Pedágio:</strong>
                                                                                    <cc6:OnlyDecimalTextBox
                                                                                            ID="txt_valor_pedagio" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="12" MaxMantissa="2" MaxLength="15" Width="70px"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="rfv_valor_pedagio"
                                                                                                    runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_valor_pedagio"
                                                                                                    CssClass="texto" ErrorMessage="Preencha o campo Valor Pedágio para continuar."
                                                                                                    Font-Bold="True" ValidationGroup="vg_pedagio">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                                                    &nbsp;</td>
                                                                                           <td align="left" class="texto" style="height: 20px; width: 48%;" >
                                                                                    &nbsp;
                                                                                    &nbsp;<strong></strong>&nbsp;<anthem:CustomValidator ID="cv_pedagio" runat="server"
                                                                                        Font-Bold="True" ForeColor="White" ValidationGroup="vg_pedagio">[!]</anthem:CustomValidator>
                                                                                               &nbsp; &nbsp; &nbsp; &nbsp;<anthem:Button ID="btn_incluirpedagio" runat="server" CssClass="texto" Text="Incluir Novo Pedágio" ValidationGroup="vg_pedagio" AutoUpdateAfterCallBack="True" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" class="texto" style="height: 16px" colspan="4">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" class="texto" colspan="3">
                                                                                    <anthem:GridView ID="grdPedagio" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                                                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_linha_pedagio"
                                                                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                                                        UseAccessibleHeader="False" Visible="False" Width="96%">
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                            ForeColor="White" HorizontalAlign="Left" />
                                                                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                            HorizontalAlign="Center" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="V&#225;lido a Partir de">
                                                                                                <edititemtemplate>
&nbsp; <asp:Label id="lbl_dt_validade" runat="server" Text='<%# Bind("dt_validade") %>' __designer:wfdid="w13"></asp:Label> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="lbl_dt_validade" runat="server" Text='<%# Bind("dt_validade") %>' __designer:wfdid="w44"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="nr_valor_pedagio_eixo" HeaderText="Valor Ped&#225;gio por Eixo" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="ds_login" HeaderText="Modificador" ReadOnly="True" />
                                                                                            <asp:BoundField HeaderText="Data Modifica&#231;&#227;o" DataField="dt_modificacao" />
                                                                                            <asp:TemplateField ShowHeader="False">
                                                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w47" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w48" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" __designer:dtid="2251816993554643" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w49"></asp:ValidationSummary> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" __designer:wfdid="w45" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Parâmetro de Qualidade de Poupança" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w46" CommandName="delete" CommandArgument='<%# Bind("id_linha_pedagio") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de pedágio por eixo para a rota?' )) return true;else return false;" ImageAlign="Baseline"></anthem:ImageButton> 
</itemtemplate>
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_linha_pedagio" Visible="False">
                                                                                                <edititemtemplate>
<asp:Label id="lbl_id_linha_pedagio" runat="server" Text='<%# Bind("id_linha_pedagio") %>' __designer:wfdid="w14"></asp:Label>&nbsp;&nbsp; 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:Label id="lbl_id_linha_pedagio" runat="server" Text='<%# Bind("id_linha_pedagio") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="id_linha" HeaderText="id_linha" ReadOnly="True" Visible="False" />
                                                                                        </Columns>
                                                                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                                                    </anthem:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </td>
                                                                </tr>
															

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
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
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
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_pedagio"></asp:ValidationSummary>
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
