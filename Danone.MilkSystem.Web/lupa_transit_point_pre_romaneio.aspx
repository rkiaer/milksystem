<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_transit_point_pre_romaneio.aspx.vb" Inherits="lupa_transit_point_pre_romaneio" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Pré-Romaneios para Transit Point</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><StrONG>Seleção de Pré-Romaneios Disponíveis para Transit Point</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 127px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server"  style="height: 127px"><br />
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" >
                            <tr>
                                <td align="right" style="height: 20px; width: 22%;">
                                    &nbsp;Estabelecimento:</td>
                                <td id="TD1" runat="server" style="height: 20px; width: 28%;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_ds_estabelecimento" runat="server"></anthem:Label></td>
                                <td runat="server" style="height: 20px; width: 20%;" align="right">
                                    Unidade Transit Point:</td>
                                <td runat="server" style="height: 20px; width: 30%;">
                                    &nbsp;<anthem:Label ID="lbl_ds_transit_point_unidade" runat="server"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Pré-Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyNumbersTextBox ID="txt_id_pre_romaneio" runat="server" CssClass="caixaTexto"
                                        MaxLength="15" Width="85px"></cc2:OnlyNumbersTextBox>
                                </td>
                                <td style="height: 20px" align="right">
                                    Caderneta:</td>
                                <td style="height: 20px">
                                    &nbsp;<cc2:OnlyNumbersTextBox ID="txt_nr_caderneta" runat="server" CssClass="caixaTexto"
                                        MaxLength="15" Width="85px"></cc2:OnlyNumbersTextBox></td>
                            </tr>
							<tr>
								<td  align="right" style="height: 20px">&nbsp;Placa:</td>
								<td style="height: 20px">&nbsp;&nbsp;<anthem:TextBox ID="txt_placa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="7" Width="85px"></anthem:TextBox></td>
                                <td style="height: 20px" align="right">
                                    Nome
                                    Rota:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:TextBox ID="txt_nm_linha" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" MaxLength="10" Width="70px"></anthem:TextBox></td>
                            </tr>
							<tr>
								<td align="right" colspan="4">&nbsp;<asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
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
<asp:ImageButton id="ImageButton1" runat="server" Text="Button" CausesValidation="False" ImageUrl="~/img/icon_ok.gif" CommandName="selecionar" __designer:wfdid="w2" CommandArgument='<%# bind("id_romaneio") %>'></asp:ImageButton> 
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
