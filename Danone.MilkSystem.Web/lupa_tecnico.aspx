<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_tecnico.aspx.vb" Inherits="lupa_tecnico" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Técnicos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" />
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Técnico </STRONG>
					</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
					<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Nome:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_tecnico" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">
									Categoria:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
									<asp:DropDownList id="cbo_categoria" runat="server" CssClass="caixaTexto"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 11px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 11px">&nbsp;
                                    <asp:Label ID="lbl_situacao" runat="server" CssClass="Texto"  Text="Ativo"></asp:Label>
                                </TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></asp:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" AutoUpdateAfterCallBack="True" PageSize="6">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_tecnico" HeaderText="C&#243;digo" SortExpression="id_tecnico" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="Nome" SortExpression="nm_tecnico" >
                                                    <headerstyle width="40%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_categoria" HeaderText="Categoria" SortExpression="st_categoria" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle width="10%" />
                                                    <itemtemplate>
<asp:ImageButton id="img_selecionar" runat="server" __designer:wfdid="w16" CommandName="selecionar" CommandArgument='<%# Bind("id_tecnico") %>' ImageUrl="~/img/icon_ok.gif"></asp:ImageButton>&nbsp; 
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
		</form>
	</body>
</HTML>
