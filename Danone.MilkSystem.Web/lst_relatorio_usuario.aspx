<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_relatorio_usuario.aspx.vb" Inherits="lst_relatorio_usuario" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatórios Acessos Usuários</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>Relatórios Acessos </STRONG></TD>
					<TD style="width: 10px; height: 25px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 3px;"></TD>
					<TD align="center" style="height: 3px">
						</TD>
					<TD style="width: 10px; height: 3px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD  style="height: 12px; width:15%"></TD>
								<TD style="height: 12px; width: 30%;"></TD>
								<TD style="height: 12px; width:15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    Tipo Relatório:</td>
                                <td style="height: 25px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_relatorio" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                        <asp:ListItem Selected="True" Value="U">Usu&#225;rios</asp:ListItem>
                                        <asp:ListItem Value="UG">Usu&#225;rios x Grupos</asp:ListItem>
                                        <asp:ListItem Value="UM">Usu&#225;rios x Menus</asp:ListItem>
                                        <asp:ListItem Value="GM">Grupos x Menus</asp:ListItem>
                                    </anthem:DropDownList></td>
                                <td  align="right" style="height: 25px">
                                    Situação Usuário:</td>
                                <td style="height: 25px">
                                    &nbsp;<anthem:DropDownList id="cbo_situacao" runat="server" CssClass="Texto">
                                        <asp:ListItem Selected="True" Value="1">Ativo</asp:ListItem>
                                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    &nbsp;Nome Usuário:</td>
                                <td style="height: 25px" >
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_usuario" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="50"></anthem:TextBox></td>
                                <td style="height: 25px" align="right" >
                                    Tipo Usuário:</td>
                                <td style="height: 25px">
                                    &nbsp;<anthem:DropDownList ID="cbo_tipo_usuario" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    Login:</td>
                                <td style="height: 25px" >
                                    &nbsp;
                                    <anthem:TextBox ID="txt_login" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="10"></anthem:TextBox></td>
                                <td style="height: 25px" align="right" >
                                    Grupo:</td>
                                <td style="height: 25px">
                                &nbsp;<anthem:DropDownList ID="cbo_grupo" runat="server"
                                        CssClass="texto" AutoUpdateAfterCallBack="True">
                                </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    Menu:</td>
                                <td style="height: 21px">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_menu" runat="server"
                                        CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 21px">
                                    Item Menu:</td>
                                <td style="height: 21px">
                                    &nbsp;<anthem:DropDownList ID="cbo_menu_item" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    &nbsp; &nbsp;</TD>
                                <td align="right" colspan="2">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisa" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;
                                </td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" 
                                            AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                                            
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                <asp:BoundField DataField="ds_login" HeaderText="Login" SortExpression="ds_login" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_usuario" HeaderText="Nome" SortExpression="nm_usuario" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_usuario" HeaderText="Tipo Usu&#225;rio" />
                                                <asp:BoundField DataField="ds_depto" HeaderText="Depto" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                        <anthem:GridView ID="gridUsuGrupo" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_usuario" HeaderText="Nome" SortExpression="nm_usuario" />
                                <asp:BoundField DataField="ds_login" HeaderText="Login" SortExpression="ds_login" />
                                <asp:BoundField DataField="nm_tipo_usuario" HeaderText="Tipo Usu&#225;rio" />
                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" SortExpression="nm_grupo" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridUsuMenus" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_usuario" HeaderText="Nome" SortExpression="nm_usuario" />
                                <asp:BoundField DataField="ds_login" HeaderText="Login" SortExpression="ds_login" />
                                <asp:BoundField DataField="nm_tipo_usuario" HeaderText="Tipo Usu&#225;rio" />
                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao" />
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" SortExpression="nm_grupo" />
                                <asp:BoundField DataField="nm_menu" HeaderText="Menu" />
                                <asp:BoundField DataField="nm_menu_item" HeaderText="Item de Menu" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridGrupoMenu" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" SortExpression="nm_grupo" />
                                <asp:BoundField DataField="nm_menu" HeaderText="Menu" />
                                <asp:BoundField DataField="nm_menu_item" HeaderText="Item de Menu" />
                                <asp:BoundField DataField="nm_menu_item_processo" HeaderText="Processo Espec&#237;fico" />
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             <RowStyle BackColor="#EFF3FB" />
                                       </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages></form>
	</body>
</HTML>
