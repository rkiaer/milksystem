<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_cotacao_frete.aspx.vb" Inherits="lupa_cotacao_frete" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Valores de Tabela de Frete</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" />
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Seleção de Valores para Tabela Frete</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 107px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" style="height: 107px" class="TEXTO">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Estabelecimento:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Item:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px" width="20%">
                                    &nbsp;Fornecedor:</td>
                                <td style="height: 19px; width: 758px;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_fornecedor" runat="server" CssClass="texto"></anthem:Label></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">
                                    Data da Cotação:</TD>
								<TD style="HEIGHT: 3px; width: 758px;">&nbsp;
                                    <anthem:Label ID="lbl_dt_cotacao" runat="server" CssClass="texto"></anthem:Label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 19px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 19px; width: 758px;">&nbsp;
                                    <asp:Label ID="lbl_situacao" runat="server" CssClass="CaixaTexto"  Text="Ativo"></asp:Label>
                                </TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 107px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 3px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" PageSize="6">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Descri&#231;&#227;o" DataField="descricao" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Valor" DataField="nr_valor" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<asp:ImageButton id="img_selecionar" runat="server" ImageUrl="~/img/icon_ok.gif" CommandName="selecionar" __designer:wfdid="w5"></asp:ImageButton>&nbsp; 
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages></form>
	</body>
</HTML>
