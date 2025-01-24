<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_util_ExportaVolumeFicha.aspx.vb" Inherits="lst_util_ExportaVolumeFicha" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_util_ExportaVolumeFicha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Volumes Ficha Financeira</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
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
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" valign="middle">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD  style="height: 12px; width: 18%;"></TD>
								<TD style="height: 12px; width: 28%;"></TD>
                                <td style="width: 17%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px" >
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" Width="192px">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 23px">
                                    Código SAP:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_sap" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px" width="20%">
                                    <span style="color: #ff0000">*</span>Mês/Ano Referência:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="dt_referencia" runat="server" Columns="7" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dt_referencia"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="Informe o Mes/Ano de Referência." ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="height: 23px">
                                    <span style="color: #ff0000"><strong>*</strong></span>Tipo do Pagamento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_tipo_pagamento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 22px" align="right">
                                    Codigo do&nbsp;Produtor:</TD>
								<TD style="HEIGHT: 22px">&nbsp;
                                    <anthem:TextBox ID="txt_produtor" runat="server" CssClass="texto" Width="88px"></anthem:TextBox></TD>
                                <td align="right" style="height: 22px">
                                    Propriedade:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_propriedade" runat="server" CssClass="texto" Width="88px"></anthem:TextBox></td>
							</TR>
                            <tr>
								<TD style="HEIGHT: 22px" align="right">
                                    Tecnico:</TD>
								<TD style="HEIGHT: 22px">&nbsp;
                                    <anthem:TextBox ID="txt_nm_tecnico" runat="server" CssClass="texto" Width="88px"></anthem:TextBox></TD>
                                <td style="height: 22px" align="right">
                                    Tipo do Cálculo:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_calculo" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem VALUE="" Selected="True">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="P">Provis&#243;rio</asp:ListItem>
                                        <asp:ListItem Value="D">Definitivo</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD align="right" style="height: 25px" colspan="3">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        <br />
                        </TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif" Visible="False"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server" Enabled="False" Visible="False">Novo</anthem:linkbutton></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="Tecnico" SortExpression="nm_tecnico" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor" />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                                <asp:BoundField DataField="cd_conta" HeaderText="C&#243;digo" />
                                                <asp:BoundField DataField="nm_conta" HeaderText="Conta" />
                                                <asp:BoundField DataField="nm_abreviado_parceiro" HeaderText="Parceiro" />
                                                <asp:BoundField DataField="cd_transportador" HeaderText="Cod. Transp" />
                                                <asp:BoundField DataField="nm_transportador_abreviado" HeaderText="Transportador" />
                                                <asp:BoundField DataField="st_tipo_pagamento" HeaderText="Tp Pagto" />
                                                <asp:BoundField DataField="nr_valor_conta" HeaderText="Valor" />
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" />
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
                ShowSummary="False" ValidationGroup="vg_load" />
		</form>
	</body>
</HTML>
