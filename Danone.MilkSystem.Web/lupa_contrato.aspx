<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_contrato.aspx.vb" Inherits="lupa_contrato" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Seleção de Contratos</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><StrONG>Seleção de Contratos</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; ">&nbsp;</td>
					<td id="td_pesquisa" runat="server" class="texto" align="center"><br />
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="98%" >
                            <tr>
                                <td align="right" style="height: 20px; width: 22%;">
                                    &nbsp;Estabelecimento:</td>
                                <td id="TD1" runat="server" style="height: 20px; width: 28%;">
                                    &nbsp;
                                    <anthem:Label ID="lbl_ds_estabelecimento" runat="server"></anthem:Label></td>
                                <td runat="server" style="height: 20px; width: 20%;" align="right">
                                    <anthem:CheckBox ID="chk_contrato_comercial" runat="server" CssClass="texto" Text="Tipo de Contrato Comercial" /></td>
                                <td runat="server" style="height: 20px; width: 30%;"><anthem:CheckBox ID="chk_contrato_mercado" runat="server" CssClass="texto" Text="Tipo de Contrato Mercado" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nome Contrato:</td>
                                <td style="height: 20px" colspan="3">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" MaxLength="50" Width="376px"></anthem:TextBox></td>
                            </tr>
							<tr>
								<td  align="right" style="height: 20px">&nbsp;Cód. Contrato:</td>
								<td style="height: 20px">&nbsp;&nbsp;<anthem:TextBox ID="txt_cd_contrato" runat="server" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="4" Width="60px"></anthem:TextBox>
                                    </td>
                                <td style="height: 20px" align="left">
                                    </td>
                                <td style="height: 20px">
                                    &nbsp;</td>
                            </tr>
							<tr>
								<td align="right" colspan="4">
                                    <asp:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif"></asp:imagebutton>
                                    &nbsp;&nbsp;<asp:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></asp:imagebutton>
                                    &nbsp;&nbsp;</td>
							</tr>
						</table></td>
					<td style="width: 10px; ">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 22px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 22px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 22px; width: 10px;">&nbsp;</td>
				</tr>
				<tr>
					<td style="height: 9px; width: 9px;"></td>
					<td vAlign="middle" style="height: 9px">&nbsp;</td>
					<td style="height: 9px; width: 10px;"></td>
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
                                                <asp:BoundField DataField="cd_contrato" HeaderText="C&#243;d.Contrato" SortExpression="cd_contrato" />
                                                <asp:BoundField DataField="nm_contrato" HeaderText="Nome Contrato" SortExpression="nm_contrato" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_contrato_comercial" HeaderText="Comercial" SortExpression="st_contrato_comercial" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_contrato_mercado" HeaderText="Mercado" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Button" CausesValidation="False" ImageUrl="~/img/icon_ok.gif" CommandName="selecionar" CommandArgument='<%# bind("id_contrato") %>' __designer:wfdid="w237"></asp:ImageButton> 
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
