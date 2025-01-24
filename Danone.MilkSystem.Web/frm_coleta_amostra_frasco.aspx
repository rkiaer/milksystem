<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_coleta_amostra_frasco.aspx.vb" Inherits="frm_coleta_amostra_frasco" %>

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
    <title>Frascos para Análises das Amostras</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Frascos para Análises de Amostras</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; &nbsp;|&nbsp;
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
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%" style="height: 500px">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
													<TR>
														<TD class="titmodulo" colSpan="2" style="height: 10px"> Descrição<anthem:CustomValidator ID="cv_salvar" runat="server"
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
                                                            <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Válida
                                                                a partir de:</strong></td>
                                                        <td width="77%" class="texto">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_referencia" runat="server" CssClass="texto"
                                                                DateMask="MonthYear" Width="71px" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_referencia"
                                                                    CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar."
                                                                    Font-Bold="True" ToolTip="O campo Referência deve ser informado."
                                                                    ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Selecione os Frascos:</strong></td>
                                                        <td width="77%">
                                                            &nbsp;<anthem:GridView ID="gridFrascos" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                        CellPadding="4" CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" Height="24px"
                                                                        UpdateAfterCallBack="True">
                                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <itemtemplate>
<anthem:CheckBox id="chk_st_frasco" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w166"></anthem:CheckBox> 
</itemtemplate>
                                                                                <headerstyle width="90px" />
                                                                                <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Tipo Frasco">
                                                                                <itemtemplate>
<anthem:Image id="img_tipo_frasco" runat="server" ImageUrl="~/img/tampaazul.png" AutoUpdateAfterCallBack="True" Width="60px" Height="60px" __designer:wfdid="w137"></anthem:Image> <asp:Label id="lbl_nm_tipo_frasco" runat="server" __designer:wfdid="w134" Text='<%# Bind("nm_tipo_frasco") %>' valign="middle" align="center"></asp:Label> 
</itemtemplate>
                                                                                <headerstyle width="220px" />
                                                                                <itemstyle horizontalalign="Center" verticalalign="Middle" width="220px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Visualiza&#231;&#227;o Coletor">
                                                                                <itemtemplate>
<anthem:TextBox id="txt_descricao_coletor" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="136px" UpdateAfterCallBack="True" AutoCallBack="True" MaxLength="15" __designer:wfdid="w167" Text='<%# Bind("ds_descricao_frasco") %>' ></anthem:TextBox> 
</itemtemplate>
                                                                                <headerstyle width="160px" />
                                                                                <itemstyle width="160px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="id_coleta_amostra_frasco" Visible="False">
                                                                                <itemtemplate>
<asp:Label id="lbl_id_coleta_amostra_frasco" runat="server" __designer:wfdid="w165" Text='<%# Bind("id_coleta_amostra_frasco") %>'></asp:Label>
</itemtemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="id_tipo_frasco" Visible="False">
                                                                                <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco" runat="server" __designer:wfdid="w160" Text='<%# Bind("id_tipo_frasco") %>'></asp:Label>
</itemtemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="nm_imagem_frasco" Visible="False">
                                                                                <itemtemplate>
<asp:Label id="lbl_nm_imagem_frasco" runat="server" __designer:wfdid="w162" Text='<%# Bind("nm_imagem_frasco") %>'></asp:Label>
</itemtemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </anthem:GridView>
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
                                                                    <td align="right" class="texto" width="23%" style="height: 21px">
                                                                        <strong>Situação:</strong></td>
                                                                    <td style="height: 21px">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%" style="height: 21px">
                                                                        <strong>Modificador:</strong></TD>
																	<TD style="height: 21px">&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="height: 21px">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD style="height: 21px">&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
                                                                <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 21px">
                                                            <strong> Última Rota Carregada Coletor:</strong></td>
                                                        <td style="height: 21px">
                                                            &nbsp;<anthem:Label ID="lbl_ultima_coleta" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 17px">
                                                                    </td>
                                                                    <td style="height: 17px">
                                                                    </td>
                                                                </tr>
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
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
            &nbsp;
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
