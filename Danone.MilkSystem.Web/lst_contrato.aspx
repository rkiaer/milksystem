<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_contrato.aspx.vb" Inherits="lst_contrato" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_contrato</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Contrato</STRONG></TD>
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
                                <td align="right" style="height: 5px">
                                </td>
                                <td colspan="2" style="height: 5px">
                                </td>
                                <td align="right" class="texto" colspan="" style="height: 5px">
                                </td>
                                <td colspan="" style="height: 5px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 23px; width: 22%;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 23px; width: 28%;" colspan="2">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar">[!]</asp:CompareValidator></td>
                                <td align="right" class="texto" colspan="" style="width: 12%; height: 23px">
                                    Válido a Partir de:</td>
                                <td colspan="" style="width: 38%; height: 23px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="70px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Código do Contrato:</td>
                                <td colspan="2" style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_contrato" runat="server" CssClass="caixatexto" MaxLength="5"
                                        Width="74px"></anthem:TextBox></td>
                                <td align="right" style="height: 25px">
                                    Nome Contrato:</td>
                                <td align="left" class="texto" style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_contrato" runat="server" CssClass="caixatexto" MaxLength="50"
                                        Width="350px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Situação:</td>
                                <td style="height: 25px" colspan="2">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 25px">
                                    &nbsp;Situação Contrato:</td>
                                <td align="left" style="height: 25px" class="texto">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_situacao_contrato" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 25px" align="right">
                                    Mod. Relacionamento:&nbsp;</td>
                                <td align="left" colspan="2" style="height: 25px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_cluster" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td style="height: 25px" align="center" colspan="2">
                                    <anthem:CheckBox ID="chk_contrato_comercial" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Contrato Padrão (default)" />
                                    &nbsp; &nbsp;
                                    <anthem:CheckBox ID="chk_contrato_mercado" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Contrato Mercado" /> &nbsp; &nbsp; &nbsp; &nbsp;
                                    <anthem:CheckBox ID="chk_referenciavigente" runat="server" AutoUpdateAfterCallBack="True"
                                        Text="Referência Vigente" /></td>
							</TR>
							<TR>
                                <td align="right" colspan="5" style="height: 30px">
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
                            id="lk_novo" runat="server">Novo</anthem:linkbutton>
                        |
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ico_email.gif" /><anthem:LinkButton
                            ID="lk_email" runat="server" AutoUpdateAfterCallBack="True" OnClientClick="if (confirm('Uma notificação de que existem contratos para aprovação será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                            ValidationGroup="vg_pesquisar">Notificar Aprovadores</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_contrato_validade">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_validade" HeaderText="V&#225;lido a Partir" SortExpression="ds_validade">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_contrato" HeaderText="C&#243;digo" SortExpression="cd_contrato" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_contrato" HeaderText="Nome Contrato" SortExpression="nm_contrato" />
                                                <asp:BoundField DataField="st_contrato_comercial" HeaderText="Comercial" SortExpression="st_contrato_comercial" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_contrato_mercado" HeaderText="Mercado" SortExpression="st_contrato_mercado" />
                                                <asp:BoundField DataField="st_referencia_vigente" HeaderText="Ref. Vigente" SortExpression="st_referencia_vigente">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_situacao_contrato" HeaderText="Situa&#231;&#227;o Contrato" SortExpression="nm_situacao_contrato" />
                                                <asp:BoundField DataField="nm_situacao_contrato_validade" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao_contrato_validade" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w40" CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" __designer:wfdid="w41" CommandName="delete" OnClientClick="if (confirm('Ao desativar uma validade do contrato, caso não haja outras referências válidas, todos os produtores ligados a este contrato serão atualizados com contrato comercial. Deseja realmente excluiur o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="6%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_contrato">
                                                    <itemtemplate>
<asp:Label id="lbl_id_contrato" runat="server" Text='<%# Bind("id_contrato") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_contrato_validade" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_contrato_validade" runat="server" Text='<%# Bind("id_contrato_validade") %>' __designer:wfdid="w4"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao" runat="server" Text='<%# Bind("id_situacao") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao_contrato" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_contrato" runat="server" Text='<%# Bind("id_situacao_contrato") %>' __designer:wfdid="w7"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_situacao_contrato_validade" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_contrato_validade" runat="server" Text='<%# Bind("id_situacao_contrato_validade") %>' __designer:wfdid="w8"></asp:Label>
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
