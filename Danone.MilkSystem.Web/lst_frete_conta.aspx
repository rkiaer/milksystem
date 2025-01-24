<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_conta.aspx.vb" Inherits="lst_frete_conta" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Contas de Frete</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 2px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Contas de Cálculo de Frete</STRONG></TD>
					<TD style="width: 2px" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 2px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 2px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_conta" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="4"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Nome:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_conta" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="30"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Natureza:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_natureza_conta" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">Custos Adicionais</asp:ListItem>
                                        <asp:ListItem Value="2">Desconto</asp:ListItem>
                                        <asp:ListItem Value="3">Outros</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px; ">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right" >
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;
                                </TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 2px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 6px; width: 2px;"></TD>
					<TD vAlign="middle" style="height: 6px" class="texto">&nbsp;</TD>
					<TD style="height: 6px; width: 2px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 2px; ">&nbsp;</TD>
					<TD align="center" >
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_frete_conta" HeaderText="C&#243;digo" SortExpression="cd_conta" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_frete_conta" HeaderText="Nome" SortExpression="nm_conta" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_natureza" HeaderText="Natureza" SortExpression="nm_natureza" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_qtd_valor" HeaderText="Valor ou Quantidade"
                                                    SortExpression="st_qtd_valor" />
                                                <asp:BoundField DataField="nr_ordem" HeaderText="Ordem " SortExpression="nr_ordem" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_frete_conta") %>' CommandName="edit" __designer:wfdid="w44"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandArgument='<%# Bind("id_frete_conta") %>' CommandName="delete" __designer:wfdid="w47" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="5%" />
                                                    <itemstyle width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 2px; " >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
