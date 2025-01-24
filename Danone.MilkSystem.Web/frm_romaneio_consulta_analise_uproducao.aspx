<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_consulta_analise_uproducao.aspx.vb" Inherits="frm_romaneio_consulta_analise_uproducao" %>

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
		<title>lst_calculo_acompanhamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 29px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 29px;"><STRONG>
                        <asp:Label ID="lbl_titulo" runat="server" Text="Consulta do Romaneio - Análises das Unidades de Produção/Produtores por Compartimento "></asp:Label>&nbsp;</STRONG></TD>
					<TD style="height: 29px">&nbsp;</TD>
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
									colSpan="4">
                                        <anthem:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" AutoUpdateAfterCallBack="True" Visible="False" /><anthem:HyperLink
                                            ID="hl_imprimir_ciqp" runat="server" CssClass="texto"
                                            Enabled="False" NavigateUrl="~/frm_relatorio_CIQP.aspx" Style="text-align: center"
                                            Target="_blank" UpdateAfterCallBack="True" Width="120px" AutoUpdateAfterCallBack="True" Visible="False">Relatório CIQP      Versão para Imprimir</anthem:HyperLink>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 5px;">&nbsp;</TD>
				</TR>
			    <TR>
				    <TD style="width: 9px; "  ></TD>
					<TD class="texto"  >
                                                <asp:Panel ID="pnl_romaneio" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Romaneio"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;"><STRONG>
                                        <asp:Label ID="lbl_titulo_romaneio" runat="server" CssClass="texto">Nr. Romaneio:</asp:Label></STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>
                                        <asp:Label ID="lbl_titulo_situacao" runat="server" CssClass="texto">Situação Romaneio:</asp:Label></STRONG></TD>
				                    <TD align="left" style="height: 22px; width: 31%;" class="texto" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Da Unidade de Produção"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                        <anthem:GridView ID="gridCompartimento" runat="server" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" DataKeyNames="id_romaneio_uproducao"
                            Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="5" UpdateAfterCallBack="True"
                            Width="99%" AllowPaging="True">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp." />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="ds_uproducao" HeaderText="Unid.Produ&#231;&#227;o" />
                                <asp:BoundField DataField="ds_pessoa" HeaderText="Produtor">
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_status_analise_uproducao" HeaderText="Sit.An&#225;lise" NullDisplayText="&quot;N&#227;o cadastrada&quot;" />
                                <asp:BoundField DataField="nr_litros" HeaderText="Litros" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icon_analises.gif" ToolTip="Consultar Análises" __designer:wfdid="w4" CommandArgument='<%# Bind("id_romaneio_uproducao") %>' CommandName="analises"></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                        </anthem:GridView>
                        </asp:Panel>
                        &nbsp;&nbsp;</TD>
					<TD style="height: 28px"   ></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; height: 40px;">&nbsp;</TD>
					<TD class="texto" valign="top" style="height: 40px" >
					<asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False" GroupingText="Registro das Análises"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                        &nbsp;<anthem:GridView ID="gridResults" runat="server"
                            AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="1" CssClass="texto" DataKeyNames="id_analise_uproducao" Font-Names="Verdana"
                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Height="32px"
                            Width="100%" AutoUpdateAfterCallBack="True">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" Height="20px" />
                            <EditRowStyle BackColor="#6193E0" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Obrigat&#243;ria">
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:CheckBox id="chk_obrigatoria" runat="server" Font-Bold="False" Enabled="False" Checked='<%# Bind("chk_obrigatoria") %>' Font-Overline="False" __designer:wfdid="w16"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="cd_analise" HeaderText="C&#243;digo" ReadOnly="True" SortExpression="cd_analise">
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla" ReadOnly="True"
                                    SortExpression="nm_sigla">
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Referencial" SortExpression="ds_faixa">
                                    <edititemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" Text='<%# Bind("ds_faixa") %>' Visible="False" __designer:wfdid="w59"></asp:Label><asp:Label id="lbl_faixa_referencia_logica" runat="server" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False" __designer:wfdid="w60"></asp:Label> 
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" Text='<%# Bind("ds_faixa") %>' Visible="False" __designer:wfdid="w57"></asp:Label> <asp:Label id="lbl_faixa_referencia_logica" runat="server" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False" __designer:wfdid="w58"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo" NullDisplayText="N&#227;o Cadastrada"
                                    ReadOnly="True" SortExpression="nm_tipo_analise" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Resultado">
                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Width="56px" Visible="False" __designer:wfdid="w63"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" CssClass="texto" Width="8px" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" Visible="False" ToolTip="Valor obrigatório" __designer:wfdid="w64">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Width="56px" Visible="False" MaxLength="15" MaxCaracteristica="10" MaxMantissa="4" DecimalSymbol="," __designer:wfdid="w65"></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" Visible="False" ToolTip="Valor obrigatório!" __designer:wfdid="w66">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Width="88px" Visible="False" __designer:wfdid="w67"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" Font-Bold="True" ValidationGroup="vg_analise" ErrorMessage="O valor da análise deve ser preenchido." ControlToValidate="cbo_nr_valor" Visible="False" ToolTip="Valor obrigatório" __designer:wfdid="w68">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_analise" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w69"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w61"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Text='<%# Bind("nm_analise_logica") %>' Visible="False" __designer:wfdid="w62"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Coment&#225;rio">
                                    <edititemtemplate>
<asp:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="200px" Text='<%# Bind("ds_comentario") %>' MaxLength="50" TextMode="MultiLine" __designer:wfdid="w71"></asp:TextBox> 
</edititemtemplate>
                                    <itemstyle horizontalalign="Justify" width="200px" />
                                    <headerstyle horizontalalign="Center" width="200px" />
                                    <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" Text='<%# Bind("ds_comentario") %>' __designer:wfdid="w70"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w73"></asp:Label> 
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w72"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_analise" Visible="False">
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
<asp:Label id="lbl_faixa_logica" runat="server" Text='<%# Bind("id_faixa_referencia_logica") %>' __designer:wfdid="w79"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" Text='<%# Bind("id_faixa_referencia_logica") %>' __designer:wfdid="w78"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_formato_analise" runat="server" Text='<%# Bind("id_formato_analise") %>' __designer:wfdid="w80"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        </asp:Panel>
										</TD>
					<TD style="height: 40px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;&nbsp;
                        <TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton></td>
                                <TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp;&nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server" UpdateAfterCallBack="false"></cc1:alertmessages></form>
	</body>
</HTML>
