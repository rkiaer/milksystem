<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_analise_uproducao.aspx.vb" Inherits="frm_romaneio_analise_uproducao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Romaneio - Análises da Unidade de Produção</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Registrar Análise Unidade de Produção / Produtor &nbsp;</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 5px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 5px" class="texto">
						<TABLE id="Table5" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 5px;">&nbsp;</TD>
				</TR>
			    <TR>
				    <TD style="width: 9px; height: 28px;"  ></TD>
					<TD class="texto" style="height: 28px" >
                                                <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Romaneio"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;"><STRONG>Nr. Romaneio:</STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>Situação Romaneio:</STRONG></TD>
				                    <TD align="left" style="height: 22px" class="texto" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
                                <tr>
                                    <TD class="texto" align="right" style="width:20%; height: 22px;">
                                        <STRONG>Estabelecimento:</strong></td>
                                    <TD style="width:29%; height: 22px;" align="left" class="texto" >
                                        &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto"></asp:Label></td>
                                    <TD class="texto" align="right" style="width:20%; height: 22px;" >
                                        <STRONG>Tipo de Leite:</strong></td>
                                    <TD align="left" style="height: 22px" class="texto" >
                                        &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Da Unidade de Produção"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                            <table id="Table6" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto" style="height: 56px">
                                <TR>
                                    <TD class="texto" align="right" style="width:20%; height: 21px;">
                                        <STRONG>Compartimento:</strong></td>
                                    <TD style="width:29%; height: 21px;" align="left" class="texto" >
                                        <asp:Label ID="lbl_ds_compartimento" runat="server"  CssClass="texto" Width="100%"></asp:Label></td>
                                    <TD class="texto" align="right" style="width:19%; height: 21px;" >
                                        <STRONG>Placa:</strong></td>
                                    <TD align="left" style="height: 21px" class="texto" >
                                        &nbsp;<asp:Label ID="lbl_ds_placa_compartimento" runat="server"  CssClass="texto" Width="80%"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" class="texto" style="width: 20%; height: 21px">
                                        <strong>Propriedade:</strong></td>
                                    <td align="left" class="texto" style="width: 29%; height: 21px">
                                        <asp:Label ID="lbl_ds_propriedade" runat="server"  CssClass="texto" Width="100%"></asp:Label></td>
                                    <td align="right" class="texto" style="width: 19%; height: 21px">
                                        <strong>Unidade de Produção:</strong></td>
                                    <td align="left" class="texto" style="height: 21px">
                                    &nbsp;<asp:Label ID="lbl_ds_uproducao" runat="server"  CssClass="texto" Width="80%"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" class="texto" style="width: 20%; height: 21px">
                                        <strong>Produtor:</strong></td>
                                    <td align="left" class="texto" style="width: 29%; height: 21px">
                                        <asp:Label ID="lbl_dsprodutor" runat="server"  CssClass="texto" ></asp:Label></td>
                                    <td align="right" class="texto" style="width: 19%; height: 21px">
                                        <strong>Situação:</strong></td>
                                    <td align="left" class="texto" style="height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_nm_st_uproducao" runat="server"  CssClass="texto" UpdateAfterCallBack="false"></anthem:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                            Font-Size="XX-Small" GroupingText="Análise Unidade de Produção" Height="1px"
                            Width="100%">
                            <br />
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" class="texto" style="height: 1px"
                                width="100%">
                                <tr>
                                    <td align="right" class="texto" style="width: 20%; height: 22px">
                                        <strong><span style="color: #ff0000">*</span><strong> Registrar </strong>Resultado:</strong>&nbsp;</td>
                                    <td align="left" class="texto" colspan="2" style="height: 22px; width: 43%;">
                                        <anthem:DropDownList ID="cbo_registro_analise" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" >
                                        </anthem:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_registro_analise"
                                            CssClass="texto" ErrorMessage="O resultado da Análise deve ser preenchido." Font-Bold="True"
                                            ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator><asp:CustomValidator
                                                ID="cv_st_analises" runat="server" ControlToValidate="cbo_registro_analise" CssClass="texto"
                                                ErrorMessage="CustomValidator" Font-Bold="True" ValidationGroup="vg_registrar">[!]</asp:CustomValidator><asp:CustomValidator
                                                    ID="cv_verificarrejeitadas" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                                    Font-Bold="True" ValidationGroup="vg_registrar">[!]</asp:CustomValidator></td>
                                    <td align="left" class="texto" style="width: 37%; height: 22px" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="texto" style="width: 20%; height: 21px">
                                    </td>
                                    <td align="center" class="texto" style="height: 21px">
                                    </td>
                                    <td align="right" class="texto" style="height: 21px">
                                        <asp:ImageButton ID="btn_registrar" runat="server" CssClass="texto" ImageUrl="~/img/bnt_registrar.gif"
                                            ValidationGroup="vg_registrar" OnClientClick="if (confirm('Ao registrar o resultado para o Compartimento, as análises referentes à ele não poderão mais sofrer alterações. Deseja realmente prosseguir?' )) return true;else return false;" />&nbsp; 
                                    </td>
                                    <td align="center" class="texto" colspan="1" style="height: 21px; width: 22%;">
                                        <anthem:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" AutoUpdateAfterCallBack="True" /><anthem:HyperLink
                                            ID="hl_imprimir_ciqp" runat="server" CssClass="texto"
                                            Enabled="False" NavigateUrl="~/frm_relatorio_CIQP.aspx" Style="text-align: center"
                                            Target="_blank" UpdateAfterCallBack="True" Width="120px" AutoUpdateAfterCallBack="True">Relatório CIQP      Versão para Imprimir</anthem:HyperLink></td>
                                    <td align="right" class="texto" colspan="1" style="width: 15%; height: 21px">
                                        <anthem:Image ID="img_email" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_email.gif"
                                            ToolTip="Enviar Emails" />
                                        <asp:LinkButton ID="btn_email" runat="server" CssClass="texto" Enabled="False" OnClientClick="if (confirm('O relatório CIQ será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"
                                            Style="text-align: center" Width="72px">Rel. CIQP Enviar Email</asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        
						
					</TD>
					<TD style="height: 28px"   ></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD class="texto" valign="top" >
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AddCallBacks="False" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="texto" DataKeyNames="id_analise_uproducao" Font-Names="Verdana"
                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Height="32px"
                            Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#6193E0" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Obrigat&#243;ria">
                                    <itemtemplate>
<asp:CheckBox id="chk_obrigatoria" runat="server" Font-Bold="False" Enabled="False" __designer:wfdid="w31" Font-Overline="False" Checked='<%# Bind("chk_obrigatoria") %>'></asp:CheckBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="cd_analise" HeaderText="C&#243;digo" ReadOnly="True" SortExpression="cd_analise">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla" ReadOnly="True"
                                    SortExpression="nm_sigla">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Referencial" SortExpression="ds_faixa">
                                    <edititemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w23" Visible="False" Text='<%# Bind("ds_faixa") %>'></asp:Label><asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w24" Visible="False" Text='<%# Bind("nm_faixa_referencia_logica") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w21" Visible="False" Text='<%# Bind("ds_faixa") %>'></asp:Label> <asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w22" Visible="False" Text='<%# Bind("nm_faixa_referencia_logica") %>'></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo" NullDisplayText="N&#227;o Cadastrada"
                                    ReadOnly="True" SortExpression="nm_tipo_analise" Visible="False" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Resultado">
                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Width="56px" Visible="False" __designer:wfdid="w63"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" CssClass="texto" Width="8px" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" Visible="False" ToolTip="Valor obrigatório" __designer:wfdid="w64">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Width="56px" Visible="False" MaxLength="15" MaxCaracteristica="10" MaxMantissa="4" DecimalSymbol="," __designer:wfdid="w65"></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" Visible="False" ToolTip="Valor obrigatório!" __designer:wfdid="w66">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Width="88px" Visible="False" __designer:wfdid="w67"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor da análise deve ser preenchido." ControlToValidate="cbo_nr_valor" Visible="False" ToolTip="Valor obrigatório" __designer:wfdid="w68">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_analise" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w69"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w61"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Text='<%# Bind("nm_analise_logica") %>' Visible="False" __designer:wfdid="w62"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Coment&#225;rio">
                                    <edititemtemplate>
<asp:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="200px" Text='<%# Bind("ds_comentario") %>' MaxLength="50" TextMode="MultiLine" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" Text='<%# Bind("ds_comentario") %>' __designer:wfdid="w70"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" width="200px" />
                                    <itemstyle horizontalalign="Justify" width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w73"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_analise">
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:CommandField>
                                <asp:TemplateField Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" Text='<%# Bind("nr_faixa_inicial") %>' __designer:wfdid="w75"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" Text='<%# Bind("nr_faixa_inicial") %>' __designer:wfdid="w74"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_faixa_final" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" Text='<%# Bind("nr_faixa_final") %>' __designer:wfdid="w77"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" Text='<%# Bind("nr_faixa_final") %>' __designer:wfdid="w76"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_faixa_referencia_logica" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w26" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w25" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_formato_analise" runat="server" Text='<%# Bind("id_formato_analise") %>' __designer:wfdid="w80"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_grupo_descricao" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_id_grupo_descricao" runat="server" __designer:wfdid="w33" Text='<%# Bind("id_grupo_descricao") %>'></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_grupo_descricao" runat="server" __designer:wfdid="w32" Text='<%# Bind("id_grupo_descricao") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
										</TD>
					<TD style="height: 311px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;&nbsp;
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server" UpdateAfterCallBack="false"></cc1:alertmessages></form>
	</body>
</HTML>
