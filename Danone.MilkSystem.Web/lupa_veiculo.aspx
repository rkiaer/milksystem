<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_veiculo.aspx.vb" Inherits="lupa_veiculo" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Veículos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" />
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Seleção de Veículos</STRONG>
					</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 127px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr id="tr_transportador" runat="server" visible="false">
                                <td align="right" style="height: 20px" width="20%">
                                    Transportador:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_veiculo" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Placa:</td>
                                <td style="height: 20px; width: 758px;">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_placa" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 19px" width="20%">
                                    &nbsp;Modelo:</td>
                                <td style="height: 19px; width: 758px;">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_modelo" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 3px" align="right">
                                    Ano Fabricação:</TD>
								<TD style="HEIGHT: 3px; width: 758px;">&nbsp;
                                    <anthem:TextBox ID="txt_ano_fabricacao" runat="server" CssClass="caixaTexto" Width="224px"></anthem:TextBox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 19px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 19px; width: 758px;">&nbsp;
                                    <asp:Label ID="lbl_situacao" runat="server" CssClass="CaixaTexto"  Text="Ativo"></asp:Label>
                                </TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD align="right" style="width: 758px">
                                    <asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></asp:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 127px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" PageSize="5">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_veiculo" HeaderText="C&#243;digo" SortExpression="id_veiculo" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_modelo" HeaderText="Modelo" SortExpression="ds_modelo" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_ano_fabricacao" HeaderText="Ano Fabrica&#231;&#227;o"
                                                    SortExpression="nr_ano_fabricacao" />
                                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<asp:ImageButton id="img_selecionar" runat="server" __designer:wfdid="w5" CommandArgument='<%# Bind("id_veiculo") %>' CommandName="selecionar" ImageUrl="~/img/icon_ok.gif"></asp:ImageButton>&nbsp; 
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
