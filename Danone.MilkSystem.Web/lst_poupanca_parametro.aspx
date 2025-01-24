<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_parametro.aspx.vb" Inherits="lst_poupanca_parametro" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_poupanca_parametro</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Poupança Parâmetros</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 3px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 3px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Período:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="70px"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="70px"></cc2:OnlyDateTextBox>
                                    <anthem:CompareValidator ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToCompare="txt_dt_fim" ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                        Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                        Type="Date" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td align="right" style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Situação Poupança:</td>
                                <TD style="HEIGHT: 3px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao_poupanca" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
							</TR>
                            <tr>
                                <TD style="HEIGHT: 3px" align="right">
                                    &nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
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
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_poupanca_parametro">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_referencia_ini" HeaderText="Ref. Inicial" SortExpression="dt_referencia_ini">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_referencia_fim" HeaderText="Ref. Final" SortExpression="dt_referencia_fim" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_situacao_poupanca" HeaderText="Situa&#231;&#227;o Poupan&#231;a" SortExpression="nm_situacao_poupanca" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w22" CommandArgument='<%# Bind("id_poupanca_parametro") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" __designer:wfdid="w23" CommandArgument='<%# Bind("id_poupanca_parametro") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluiur o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="6%" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_poupanca" runat="server" __designer:wfdid="w24" Text='<%# Bind("id_situacao_poupanca") %>'></asp:Label>
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
