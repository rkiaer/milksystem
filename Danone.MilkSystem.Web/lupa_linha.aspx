<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_linha.aspx.vb" Inherits="lupa_linha" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Rotas</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><StrONG>Seleção de Rota</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 127px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server"  style="height: 127px"><br />
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" >
                            <tr>
                                <td width="20%" style="HEIGHT: 20px" align="right">
                                    &nbsp;Estabelecimento:</td>
                                <td style="HEIGHT: 20px">
                                    &nbsp;
                                    <asp:Label ID="lbl_estabelecimento" runat="server" Width="256px" CssClass="Texto"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_id_linha" runat="server" CssClass="caixaTexto" Width="224px"></asp:TextBox></td>
                            </tr>
							<tr>
								<td width="20%" align="right" style="height: 20px">&nbsp;Nome:</td>
								<td style="height: 20px">&nbsp;&nbsp;<asp:textbox id="txt_nm_linha" runat="server" cssclass="caixaTexto"
                                        width="224px"></asp:textbox></td>
                            </tr>
                            

							<tr>
								<td style="HEIGHT: 20px" align="right">&nbsp;Situação:</td>
								<td style="HEIGHT: 20px">&nbsp;
                                    <asp:Label ID="lbl_situacao" runat="server" Text="Ativo" CssClass="CaixaTexto"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td align="right">
                                    <asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></asp:imagebutton>
                                    &nbsp;</td>
							</tr>
						</table></td>
					<td style="width: 10px; height: 127px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px; width: 10px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;"></td>
					<td vAlign="middle" style="height: 19px">&nbsp;</td>
					<td style="height: 19px; width: 10px;"></td>
				</tr>
				
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" PageSize="6">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_linha" HeaderText="C&#243;digo" SortExpression="id_linha" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Nome" SortExpression="nm_linha" >
                                                    <headerstyle width="40%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Button" CommandArgument='<%# Eval("id_linha") %>' __designer:wfdid="w1" CommandName="selecionar" ImageUrl="~/img/icon_ok.gif" CausesValidation="False"></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 19px; width: 9px;">&nbsp;</td>
					<td vAlign="top" style="height: 19px">&nbsp;
					</td>
					<td style="height: 19px; width: 10px;">&nbsp;</td>
				</tr>
			</table>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</html>
