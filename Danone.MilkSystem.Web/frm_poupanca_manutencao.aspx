<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_poupanca_manutencao.aspx.vb" Inherits="frm_poupanca_manutencao" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
    <title>Mais Sólidos - Manutenção do Site</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Mais Sólidos - Manutenção do Site</STRONG></TD>
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
                                    &nbsp;
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
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 10px"> Programa Mais Sólidos</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="width: 25%; height: 20px">
                                                            <span class="obrigatorio">*</span> <strong>Estabelecimento:</strong></td>
                                                        <td style="height: 20px">
                                                            <anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
													
													
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 20px">
                                                            <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Período
                                                                de Referência Poupança:</strong></td>
                                                        <td  class="texto" style="height: 20px">
                                                            <anthem:Label ID="lbl_periodo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 20px">
                                                            <strong>Situação Poupança:</strong></td>
                                                        <td style="height: 20px">
                                                            <anthem:Label ID="lbl_nm_situacao_poupanca" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 15px">
                                                            </td>
                                                        <td style="height: 15px">
                                                            </td>
                                                    </tr>
                                                    <TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Dados</TD>
													</TR>
                                                    
                                                    <tr>
                                                        <td align="left" class="texto" colspan="2">
                                                        <table class="texto" width="100%">
                                                            <tr><td style="width: 23%; height: 22px;" align="right">
                                                                <strong><span style="color: #ff0000">*</span>Data Limite Adesão ao Termo:</strong></td>
                                                            <td style="height: 22px">
                                                                <cc4:OnlyDateTextBox ID="txt_dt_adesao_limite" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                                                    Width="80px"></cc4:OnlyDateTextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_adesao_limite"
                                                                    CssClass="texto" ErrorMessage="A Dta Limite de adesão ao termo deve ser informada."
                                                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        </table>
                                                        </td>
                                                    </tr>
                                                    <TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Documento do Regulamento do Período</TD>
													</TR>
                                                    <tr>
                                                        <td align="left" class="texto" colspan="2">
                                                        <table class="texto" width="100%">
                                                            <tr>
                                                                <td align="right" style="height: 23px">
                                                                    <strong><span style="color: #ff0000">*</span>Documento:</strong></td>
                                                                <td style="height: 23px">
                                                                    <asp:FileUpload ID="ful_documento" runat="server" CssClass="texto" />
                                                                    <asp:RequiredFieldValidator ID="rqf_documento" runat="server" ControlToValidate="ful_documento"
                                                                        CssClass="texto" ErrorMessage="Escolha um Documento para Anexar" Font-Bold="True"
                                                                        ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 23%">
                                                                    <strong><span style="color: #ff0000">*</span>Nome Documento a Ser Exibido no Site:</strong></td>
                                                                <td>
                                                                    <anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" MaxLength="30" Width="250px">Regulamento_OUT2019_SET2020</anthem:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rqf_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                                                        CssClass="texto" ErrorMessage="Preencha o campo Nome do Documento para contiuar"
                                                                        Font-Bold="True" ValidationGroup="vg_anexar">[!]</asp:RequiredFieldValidator>
                                                                    <asp:CustomValidator ID="cv_nm_documento" runat="server" ControlToValidate="txt_nm_documento"
                                                                        CssClass="texto" Font-Bold="True" ValidationGroup="vg_anexar">[!]</asp:CustomValidator>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="height: 23px">
                                                                </td>
                                                                <td style="height: 23px">
                                                                    <asp:Button ID="btn_anexar" runat="server" CssClass="texto" Text="Anexar Documento"
                                                                        ValidationGroup="vg_anexar" Width="99px" /></td>
                                                            </tr>
                                                        </table>
                                                        </td>
                                                    </tr>
                                                    <TR id="tr_qualidade" runat="server" visible="false">
														<TD colSpan="2" class="texto">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">
                                                                        Documento Anexado</TD>
																</TR>
                                                                <tr>
                                                                    <td align="center" class="texto" colspan="2">
                                                                        <br />
                                                                        <table id="Table8" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                                            <tr>
                                                                                <td align="center" class="texto" colspan="8">
                                                                                    <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"
                                                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_poupanca_parametro_qualidade"
                                                                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                                                        UseAccessibleHeader="False" Visible="False" Width="90%">
                                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                            ForeColor="White" HorizontalAlign="Left" />
                                                                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                            HorizontalAlign="Center" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Nome do Documento">
                                                                                                <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                                                                <itemtemplate>
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" CssClass="texto" Text='<%# Bind("nm_documento") %>'></asp:Label>
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="nm_extensao" HeaderText="Extens&#227;o" ReadOnly="True" />
                                                                                            <asp:TemplateField HeaderText="Arquivo">
                                                                                                <itemtemplate>
&nbsp;<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Text="Clique aqui para fazer o download" Target="_blank" Font-Underline="True"></asp:HyperLink>
</itemtemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ShowHeader="False">
                                                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary> 
</edititemtemplate>
                                                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" Visible="False" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Parâmetro de Qualidade de Poupança" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# Bind("id_poupanca_parametro_anexo") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de parâmetro de qualidade de poupança?' )) return true;else return false;" ImageAlign="Baseline"></anthem:ImageButton> 
</itemtemplate>
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                                                    </anthem:GridView>
                                                                                    &nbsp; &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        &nbsp;</td>
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
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_anexar"></asp:ValidationSummary>
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
