<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_consulta_analise.aspx.vb" Inherits="frm_romaneio_saida_consulta_analise" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

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
		<title>Romaneio Saída - Consulta das Análises</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>
                        <asp:Label ID="lbl_titulo" runat="server" Text="Romaneio Saída - Consulta das Análises do Compartimento"></asp:Label></STRONG></TD>
					<TD style="height: 27px">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; " class="texto">
						<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 11px" class="texto">&nbsp;</TD>
				</TR>
			    <TR>
				    <TD style="width: 1px"  ></TD>
					<TD class="texto"  >
                                                <asp:Panel ID="pnl_romaneio" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Romaneio Saída"  Width="100%" Font-Size="XX-Small"  CssClass="texto">
                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;"><STRONG>
                                        <asp:Label ID="lbl_titulo_romaneio" runat="server" CssClass="texto">Nr. Romaneio Saída:</asp:Label></STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>
                                        <asp:Label ID="lbl_titulo_situacao" runat="server" CssClass="texto">Situação Romaneio Saída:</asp:Label></STRONG></TD>
				                    <TD align="left" style="height: 22px" class="texto" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
                            </table>
                        </asp:Panel>
                        &nbsp;&nbsp;<asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Compartimento" Width="100%" Font-Size="XX-Small"  CssClass="texto" >
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto" >
			                    <TR>
				                    <TD class="texto" align="right" style="height: 22px;width:20%"><STRONG>Compartimento:</STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_ds_compartimento" runat="server"  CssClass="texto" ></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>Placa:</STRONG></TD>
				                    <TD style="height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_ds_placa_compartimento" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
			                    <TR>
			                        <TD class="texto" align="right" style="height: 22px; width: 20%;" ><STRONG>Situação Análise:</STRONG></TD>
                                    <TD style=" height: 22px; width: 29%;" align="left" class="texto" >&nbsp;<anthem:Label ID="lbl_nm_st_compartimento" runat="server"  CssClass="texto"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
				                    <TD class="texto" align="right" style="height: 22px; width: 20%;" >
                                        <strong>Início da Análise:</strong></td>
                                    <TD style="height: 22px; " align="left">
                                        &nbsp;<anthem:Label ID="lbl_dt_inicio_analise" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
			                    </TR>
                                <tr>
                                    <TD class="texto" align="right" style="height: 22px;width:20%">
                                        <STRONG>Analista:</strong></td>
                                    <TD style="width:29%; height: 22px;" align="left" class="texto" >
                                        &nbsp;<anthem:Label ID="lbl_nm_analista" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                        </td>
                                    <TD class="texto" align="right" style="width:20%; height: 22px;" >
                                        <STRONG>
                                        <anthem:Label ID="lbl_labelmotivo" runat="server" CssClass="texto" Font-Bold="True" Width="72px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Justificativa:</anthem:Label></strong></td>
                                    <TD style="height: 22px;" align="left" class="texto" >
                                        &nbsp;<anthem:TextBox ID="txt_ds_motivo_aprovado_sob_concessao" runat="server" CssClass="texto"
                                            TextMode="MultiLine" Width="92%" Rows="2" MaxLength="150" Visible="False" AutoUpdateAfterCallBack="True"></anthem:TextBox></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        &nbsp;<br />
                        	</TD>
					<TD style="width: 10px; "  ></TD>
				</TR>
				<TR>
					<TD style="width: 1px; ">&nbsp;</TD>
					<TD valign="top" class="texto">
<asp:Panel ID="Panel5" runat="server" BackColor="White" Font-Bold="False" GroupingText="Registro das Análises"  Width="100%" Font-Size="XX-Small"  CssClass="texto"  HorizontalAlign="Left">
    <br />
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="1" UpdateAfterCallBack="True"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" Width="100%" DataKeyNames="id_romaneio_saida_analise_compartimento" CssClass="texto" GridLines="None" PageSize="6">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" Font-Bold="True" ForeColor="White" Height="18px" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" CssClass="texto" Height="18px" Wrap="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" Height="20px" Wrap="False" />
                                            <EditRowStyle BackColor="#6193E0" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Underline="False" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Obrigat&#243;ria">
                                                    <itemtemplate>
<asp:CheckBox id="chk_obrigatoria" runat="server" Font-Bold="False" Enabled="False" __designer:wfdid="w160" Font-Overline="False" Checked='<%# Bind("chk_obrigatoria") %>'></asp:CheckBox> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="cd_analise" HeaderText="C&#243;digo" SortExpression="cd_analise" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla An&#225;lise" SortExpression="nm_sigla" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Faixa Referencial" SortExpression="ds_faixa">
                                                    <edititemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w9" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label><asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w10" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w7" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label> <asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo"
                                                    SortExpression="nm_tipo_analise" ReadOnly="True" NullDisplayText="N&#227;o Cadastrada" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Resultado">
                                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Width="56px" Visible="False" __designer:wfdid="w163"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigatório" CssClass="texto" Width="8px" Font-Bold="True" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" Visible="False" __designer:wfdid="w164">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Width="56px" MaxLength="15" Visible="False" __designer:wfdid="w165" MaxCaracteristica="10" MaxMantissa="4" DecimalSymbol=","></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigatório!" Font-Bold="True" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" Visible="False" __designer:wfdid="w166">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Width="88px" Visible="False" __designer:wfdid="w167"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigatório" Font-Bold="True" ErrorMessage="O valor da análise deve ser preenchido." ControlToValidate="cbo_nr_valor" Visible="False" __designer:wfdid="w168">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_analise" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w169"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w161"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Visible="False" Text='<%# Bind("nm_analise_logica") %>' __designer:wfdid="w162"></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Coment&#225;rio">
                                                    <edititemtemplate>
<asp:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="200px" MaxLength="50" __designer:wfdid="w3" Text='<%# Bind("ds_comentario") %>' TextMode="MultiLine"></asp:TextBox> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" __designer:wfdid="w2" Text='<%# Bind("ds_comentario") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" width="200px" />
                                                    <itemstyle horizontalalign="Justify" width="200px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w9" Text='<%# Bind("nm_st_analise") %>'></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_st_analise") %>'></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_analise" Visible="False" >
                                                    <headerstyle horizontalalign="Center" width="10%" />
                                                    <itemstyle horizontalalign="Center" width="10%" />
                                                </asp:CommandField>
                                                <asp:TemplateField Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w2" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="nr_faixa_final" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w16" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w15" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_faixa_referencia_logica" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w13" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_formato_analise" runat="server" __designer:wfdid="w6" Text='<%# Bind("id_formato_analise") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_gera_ciq" Visible="False">
                                                    <itemtemplate>
<asp:Label id="st_gera_ciq" runat="server" __designer:wfdid="w6" Text='<%# Bind("st_gera_ciq") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_st_original" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_st_original" runat="server" Text='<%# Bind("id_st_original") %>' __designer:wfdid="w18"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="True"
        ForeColor="Red" Text="* Análise Informativa"></asp:Label></asp:Panel>
										</TD>
					<TD >&nbsp;</TD>
				</TR>
                 <tr>
                    <TD style="width: 1px; " >
                    </td>
                    <TD class="texto">
					</TD>
					<TD   ></TD>
                </tr>
				<TR>
					<TD style="height: 19px; width: 1px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; " class="texto">&nbsp;&nbsp;
                        <table id="Table11" border="0" cellpadding="0" cellspacing="0" height="23" width="100%">
                            <tr>
                                <td align="left" background="img/faixa_filro.gif" class="faixafiltro1a" style="width: 265px"
                                    valign="middle" width="265">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton></td>
                                <td align="right" background="img/faixa_filro.gif" class="faixafiltro1a" colspan="4"
                                    valign="middle">
                                    &nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server" UpdateAfterCallBack="True"></cc1:alertmessages>
            &nbsp;
        </form>
	</body>
</HTML>
