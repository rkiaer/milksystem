<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_linha.aspx.vb" Inherits="lst_linha" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Rota&nbsp;</STRONG></TD>
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
                                    &nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 3px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_linha" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="10"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Nome:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="caixaTexto" Width="224px" MaxLength="50"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif" Visible="False"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server" Visible="False">Novo</anthem:linkbutton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_linha" HeaderText="C&#243;digo" SortExpression="id_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Nome" SortExpression="nm_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_periodicidade_coleta" HeaderText="Periodicidade Coleta" />
                                                <asp:BoundField DataField="st_rota_transbordo" HeaderText="Rota Transbordo" />
                                                <asp:BoundField DataField="st_rota_transit_point" HeaderText="Rota Transit Point"
                                                    ReadOnly="True" />
                                                <asp:BoundField DataField="st_rota_transvase" HeaderText="Rota Transvase" ReadOnly="True" />
                                                <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
&nbsp;<asp:LinkButton id="lk_detalhe" runat="server" __designer:wfdid="w25" CommandName="detalhe" CommandArgument='<%# bind("id_linha") %>'>detalhe</asp:LinkButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
&nbsp;<asp:LinkButton id="lk_atividade" runat="server" __designer:wfdid="w26" CommandName="atividade" CommandArgument='<%# bind("id_linha") %>' Text="atividades"></asp:LinkButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w20" CommandName="edit" CommandArgument='<%# Bind("id_linha") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w21" CommandName="delete" CommandArgument='<%# Bind("id_linha") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
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
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
