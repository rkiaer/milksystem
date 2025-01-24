<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_pessoa.aspx.vb" Inherits="lst_pessoa" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_pessoa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Fornecedor&nbsp;</STRONG></TD>
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
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="width: 20%; height: 21px;">
                                    &nbsp;Estabelecimento:</td>
                                <TD style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 21px">
                                    Grupo:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_Grupo" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    Código:</td>
                                <td style="height: 21px; width: 30%;">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="90px" MaxLength="10"></anthem:TextBox></td>
                                <td style="height: 21px; width: 15%;" align="right">
                                    Código SAP:</td>
                                <td style="height: 21px;">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_codigo_SAP" runat="server" CssClass="caixaTexto" MaxLength="10"
                                        Width="90px"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD  align="right" style="height: 21px">&nbsp;Nome:</TD>
								<TD style="height: 21px">&nbsp;&nbsp;<anthem:textbox id="txt_nm_pessoa" runat="server" cssclass="caixaTexto"
                                        width="90%" MaxLength="60"></anthem:textbox></td>
                                <td style="height: 21px" align="right">
									Categoria:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_categoria" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 21px" align="right">
                                    Cód. Contrato:</TD>
								<TD style="HEIGHT: 21px" colspan="3">&nbsp;
                                    <asp:DropDownList id="cbo_contrato" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>&nbsp;
                                </TD>
							</TR>
                            <tr>
								<TD style="HEIGHT: 21px" align="right">
                                    Modelo de Relacionamento:</TD>
								<TD style="HEIGHT: 21px">&nbsp;
									<asp:DropDownList id="cbo_cluster" runat="server" CssClass="caixaTexto"></asp:DropDownList></TD>
                                <td style="height: 21px" align="right">
                                &nbsp;Situação:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<!-- <TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD> -->
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" Visible="False" /><anthem:LinkButton
                            ID="lk_novo" runat="server" Visible="False">Novo</anthem:LinkButton>
                        |
                        <anthem:Image ID="img_notificacao" runat="server" AutoUpdateAfterCallBack="True"
                            ImageUrl="~/img/ico_email.gif" Visible="False" />
                        <anthem:LinkButton ID="lk_email" runat="server" AutoUpdateAfterCallBack="True" OnClientClick="if (confirm('Uma notificação de que existem contratos para aprovação será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                            ToolTip="Notificar Aprovadores do Modelo de Contrato" ValidationGroup="vg_pesquisar"
                            Visible="False">Notificar Aprovadores</anthem:LinkButton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;digo" SortExpression="cd_pessoa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" SortExpression="nm_pessoa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" SortExpression="nm_grupo" />
                                                <asp:BoundField DataField="st_categoria" HeaderText="Categoria" SortExpression="st_categoria" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_codigo_SAP" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_SAP" ReadOnly="True" />
                                                <asp:BoundField DataField="cd_contrato" HeaderText="Contrato" SortExpression="cd_contrato" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w1" CommandName="edit" CommandArgument='<%# Bind("id_pessoa") %>'></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w14" CommandName="delete" CommandArgument='<%# Bind("id_pessoa") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
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
