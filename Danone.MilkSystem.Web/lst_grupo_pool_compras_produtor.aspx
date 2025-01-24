<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_grupo_pool_compras_produtor.aspx.vb" Inherits="lst_grupo_pool_compras_produtor" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Grupo Pool de Compras por Produtor</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><StrONG>Grupo Pool de Compras para Produtor&nbsp;</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server">
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" >
                            <tr>
                                <td align="right" style="height: 20px">
                                    Estabelecimento:</td>
                                <td id="TD1" runat="server" style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="caixaTexto" Enabled="False">
                                    </anthem:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Produtor:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:Label ID="lbl_produtor" runat="server" CssClass="CaixaTexto"></asp:Label></td>
                            </tr>
						</table></td>
					<td style="width: 10px;">&nbsp;</td>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False" PageSize="20">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_grupo_pool_compras" HeaderText="Grupo" SortExpression="cd_grupo_pool_compras" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_grupo_pool_compras" HeaderText="Nome" SortExpression="nm_grupo_pool_compras" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" SortExpression="cd_pessoa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" SortExpression="nm_pessoa" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade" />
                                                <asp:BoundField DataField="ds_telefone" HeaderText="Telefone" />
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
