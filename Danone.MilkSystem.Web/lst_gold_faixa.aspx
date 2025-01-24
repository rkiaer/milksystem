<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_gold_faixa.aspx.vb" Inherits="lst_gold_faixa" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_faixa_qualidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 1219px;"><STRONG>Faixas GOLD&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 1219px">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 1219px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 1219px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; width: 758px;"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;<span id="Span1" class="obrigatorio">*</span>Tipo da Faixa:</td>
                                <TD style="HEIGHT: 20px; width: 758px;">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_tipo_faixa" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Value="1">Custo Efetivo</asp:ListItem>
                                        <asp:ListItem Value="2">Volume</asp:ListItem>
                                        <asp:ListItem Value="3">Crescimento</asp:ListItem>
                                        <asp:ListItem Value="4">Efici&#234;ncia Dieta</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; <asp:CompareValidator
                                        ID="CompareValidator1" runat="server" ControlToValidate="cbo_tipo_faixa"
                                        Display="Dynamic" ErrorMessage="A categoria deve ser informada!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Válido a partir de:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_inicial" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="91px"></cc3:OnlyDateTextBox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px; width: 758px;">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto" Width="91px">
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="width: 758px; height: 25px;">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 1219px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 1219px;">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 1219px">
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" SortExpression="nm_estabelecimento" />
                                                <asp:BoundField DataField="nm_gold_faixa" HeaderText="Nome Faixa" SortExpression="nm_gold_faixa" />
                                                <asp:BoundField DataField="dt_referencia_inicial" HeaderText="Data Validade" SortExpression="dt_referencia_inicial" >
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("cd_gold_faixa") %>' __designer:wfdid="w1"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# Bind("cd_gold_faixa") %>' __designer:wfdid="w2" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="10%" />
                                                    <itemstyle horizontalalign="Center" />
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
					<TD vAlign="top" style="height: 19px; width: 1219px;">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>&nbsp;&nbsp;
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
		</form>
	</body>
</HTML>
