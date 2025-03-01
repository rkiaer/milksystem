<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lupa_romaneio_cooperativa.aspx.vb" Inherits="lupa_romaneio_cooperativa" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head >
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Sele��o de Romaneios de Cooperativas</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
		<base target ="_self" />
		
	</head>


	<body  leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" runat="server">
			<table id="Table1"  cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><StrONG>Sele��o de Romaneios de Cooperativas</StrONG></td>
					<td style="width: 10px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 127px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server"  style="height: 127px"><br />
						<table class="borda" id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0" >
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <td id="TD1" runat="server" style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto" ValidationGroup="gv_estabel">
                                    </anthem:DropDownList>
                                    &nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!"
                                        Font-Bold="True" Operator="NotEqual" Type="Integer" ValueToCompare="0">[!]</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    C�digo:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="224px"></asp:TextBox></td>
                            </tr>
							<tr>
								<td width="20%" align="right" style="height: 20px">&nbsp;Nome:</td>
								<td style="height: 20px">&nbsp;&nbsp;<asp:textbox id="txt_nm_pessoa" runat="server" cssclass="caixaTexto"
                                        width="224px"></asp:textbox></td>
                            </tr>
                            

							<tr>
								<td style="HEIGHT: 20px" align="right">&nbsp;Situa��o:</td>
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
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;digo" SortExpression="cd_pessoa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" SortExpression="nm_pessoa" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_categoria" HeaderText="Categoria" SortExpression="st_categoria" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_grupo" HeaderText="Grupo" SortExpression="nm_grupo" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <headerstyle width="10%" />
                                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" Text="Button" CommandArgument='<%# Eval("id_pessoa") %>' __designer:wfdid="w18" CommandName="selecionar" ImageUrl="~/img/icon_ok.gif" CausesValidation="False"></asp:ImageButton> 
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
