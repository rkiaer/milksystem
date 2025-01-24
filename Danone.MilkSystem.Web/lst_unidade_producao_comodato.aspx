<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_unidade_producao_comodato.aspx.vb" Inherits="lst_unidade_producao_comodato" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_unidade_producao_comodato</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Equipamentos da Unidade de Produção&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table4" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"	background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server">voltar</asp:linkbutton>&nbsp; 
                                </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 20px" align="right">
                                    Estabelecimento:</TD>
								<TD style="height: 20px">
								    &nbsp;
								    <asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" Height="16px"></asp:Label></TD>
							</TR>
							<TR>
								<TD width="20%" style="height: 20px" align="right">
                                    Produtor:</TD>
								<TD style="height: 20px">
								    &nbsp;
								    <asp:Label ID="lbl_produtor" runat="server" CssClass="texto" Height="16px"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD width="20%" style="height: 20px" align="right">
                                    Propriedade:</TD>
								<TD style="height: 20px">
								    &nbsp;
								    <asp:Label ID="lbl_propriedade" runat="server" CssClass="texto" Height="16px"></asp:Label>
								</TD>
							</TR>
                            <tr>
                                <TD width="20%" style="height: 20px" align="right">
                                    Unidade de Produção:</td>
                                <TD style="height: 20px">
                                    &nbsp;
                                    <asp:Label ID="lbl_unidade_producao" runat="server" CssClass="texto" Height="16px"></asp:Label>
                                </td>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_comodato" HeaderText="C&#243;digo" SortExpression="cd_comodato" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_comodato" HeaderText="Comodato" SortExpression="nm_comodato" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_proprietario" HeaderText="Propriet&#225;rio" SortExpression="nm_proprietario">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_inicio" HeaderText="In&#237;cio" SortExpression="dt_inicio" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_fim" HeaderText="T&#233;rmino" SortExpression="dt_fim" >
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle width="10%" />
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("id_unidproducaocomodato") %>' __designer:wfdid="w8"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# Bind("id_unidproducaocomodato") %>' OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w7"></anthem:ImageButton> 
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
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
		</form>
	</body>
</HTML>
