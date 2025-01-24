<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_central_fornecedor_item.aspx.vb" Inherits="lupa_central_fornecedor_item" %>

<%@ Register Assembly="RK.TextBox.OnlyNumbers" Namespace="RK.TextBox.OnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Fornecedores por Item</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 26px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 26px;"><StrONG>Seleção de Parceiros para Central de Compras</StrONG></td>
					<td style="width: 10px; height: 26px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server">
                        <br />
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" >
                            <tr>
                                <td align="right" style="height: 25px; width: 22%;">
                                    &nbsp;Estabelecimento:</td>
                                <td id="TD1" runat="server" style="height: 25px; width: 28%;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_ds_estabelecimento" runat="server"></anthem:Label></td>
                                <td id="Td2" runat="server" style="height: 25px; width: 20%;" align="right">
                                    </td>
                                <td id="Td3" runat="server" style="height: 25px; width: 30%;">
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nome Parceiro:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" MaxLength="100" Width="150px"></anthem:TextBox></td>
                                <td style="height: 20px" align="right">
                                    Nome Item:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:TextBox ID="txt_nome_item" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" MaxLength="100" Width="150px"></anthem:TextBox></td>
                            </tr>
							<tr>
								<td align="right" colspan="4">&nbsp;<asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></asp:imagebutton>
                                    &nbsp;</td>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" AddCallBacks="False">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Pr&#233;-Romaneio" SortExpression="id_romaneio" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" SortExpression="nr_caderneta" >
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Litros Caderneta" DataField="nr_peso_liquido_caderneta" SortExpression="nr_peso_liquido_caderneta" />
                                                <asp:BoundField DataField="nr_total_litros_tp_disponivel" HeaderText="Vol. Dispon&#237;vel"
                                                    SortExpression="nr_total_litros_tp_disponivel" />
                                                <asp:BoundField DataField="nr_total_litros_tp_transferidos" HeaderText="Vol. Transferido"
                                                    SortExpression="nr_total_litros_tp_transferidos" />
                                                <asp:BoundField DataField="nr_total_saldo" HeaderText="Vol. Saldo" SortExpression="nr_total_saldo" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Button" CausesValidation="False" ImageUrl="~/img/icon_ok.gif" CommandName="selecionar" CommandArgument='<%# bind("id_romaneio") %>'></asp:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="3%" />
                                                    <itemstyle horizontalalign="Center" />
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
