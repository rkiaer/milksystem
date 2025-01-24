<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_indicador_preco.aspx.vb" Inherits="lst_indicador_preco" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_indicador_preco</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Indicador Preço</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 23px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 23px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
                            <tr>
                                <td align="right" style="height: 10px">
                                </td>
                                <td style="height: 10px">
                                </td>
                                <td align="right" class="texto" colspan="" style="height: 10px">
                                </td>
                                <td colspan="" style="height: 10px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 23px; width: 22%;" align="right">
                                    Referência:&nbsp;</td>
                                <TD style="HEIGHT: 23px; width: 25%;">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="70px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox></td>
                                <td align="right" class="texto" colspan="" style="width: 12%; height: 23px">
                                    Tipo Indicador:</td>
                                <td colspan="" style="height: 23px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_indicador_tipo" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr id="tr_situacao" runat="server" visible="false">
                                <td align="right" style="height: 23px">
                                    Situação:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 23px">
                                    Situação Aprovação:&nbsp;</td>
                                <td align="left" style="height: 23px" class="texto">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_situacao_aprovacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
                                <td align="right" colspan="4" style="height: 26px">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</td>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 6px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 6px">&nbsp;</TD>
					<TD style="height: 6px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_indicador_preco">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" SortExpression="ds_referencia">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_indicador_tipo" HeaderText="Tipo Indicador" SortExpression="ds_indicador_tipo" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor" HeaderText="Valor" SortExpression="nr_valor" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao" />
                                                <asp:BoundField DataField="nm_situacao_indicador_preco" HeaderText="Situa&#231;&#227;o Aprova&#231;&#227;o"
                                                    ReadOnly="True" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# bind("id_indicador_preco") %>' __designer:wfdid="w240" CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandArgument='<%# bind("id_indicador_preco") %>' __designer:wfdid="w241" CommandName="delete" OnClientClick="if (confirm('Ao desativar uma validade do contrato, caso não haja outras referências válidas, todos os produtores ligados a este contrato serão atualizados com contrato comercial. Deseja realmente excluiur o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="6%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_indicador_preco">
                                                    <itemtemplate>
<asp:Label id="lbl_id_indicador_preco" runat="server" __designer:wfdid="w3" Text='<%# Bind("id_indicador_preco") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_indicador_tipo" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_indicador_tipo" runat="server" Text='<%# Bind("id_indicador_tipo") %>' __designer:wfdid="w4"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao" runat="server" Text='<%# Bind("id_situacao") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_referencia" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia" runat="server" Text='<%# Bind("dt_referencia") %>' __designer:wfdid="w54"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" Style="z-index: 100; left: 136px; position: absolute; top: 504px"
                ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
