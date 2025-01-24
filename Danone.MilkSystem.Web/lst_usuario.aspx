<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_usuario.aspx.vb" Inherits="lst_usuario" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_usuario</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Usuário </STRONG>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
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
                                    Login:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_login" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="10"></anthem:TextBox></td>
                                <td  align="right" style="height: 25px">
                                    Tipo Usuário:</td>
                                <td style="height: 25px">
                                    &nbsp;<anthem:DropDownList ID="cbo_tipo_usuario" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    &nbsp;Nome:</td>
                                <td style="height: 25px" >
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_usuario" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="50"></anthem:TextBox></td>
                                <td style="height: 25px" align="right" >
                                Situação:</td>
                                <td style="height: 25px">
                                &nbsp;<asp:DropDownList id="cbo_situacao" runat="server" CssClass="Texto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    &nbsp; &nbsp;</TD>
                                <td align="right" colspan="2">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    &nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
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
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_login" HeaderText="Login" SortExpression="ds_login" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_usuario" HeaderText="Nome" SortExpression="nm_usuario" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_usuario" HeaderText="Tipo Usu&#225;rio" />
                                                <asp:BoundField DataField="ds_depto" HeaderText="Depto" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_usuario") %>' CommandName="edit" __designer:wfdid="w10"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandArgument='<%# Bind("id_usuario") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w11"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="5%" />
                                                    <itemstyle horizontalalign="Center" width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
