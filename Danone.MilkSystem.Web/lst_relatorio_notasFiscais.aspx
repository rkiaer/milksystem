<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_relatorio_notasFiscais.aspx.vb" Inherits="lst_relatorio_notasFiscais" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_util_ExportaVolumeRomaneio</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Relação de Notas Fiscais</strong></TD>
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
					<TD style="width: 9px; height: 181px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 181px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código SAP:
                                </td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_sap" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span style="color: #ff0000">*</span>Mês/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" Columns="7" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="A referência deve ser informada!" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span style="color: #ff0000">*</span>Emitente:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_emitente" runat="server" CssClass="texto" Width="152px" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem>[selecione]</asp:ListItem>
                                        <asp:ListItem>Produtor</asp:ListItem>
                                        <asp:ListItem>Cooperativa</asp:ListItem>
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_emitente"
                                        ErrorMessage="O emitente deve ser informado!" Font-Bold="True" SetFocusOnError="True" ValidationGroup="vg_load" InitialValue="[selecione]">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    </td>
                                <td style="height: 20px">
                                    &nbsp;
                                    </td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="height: 181px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="Emitente" HeaderText="Emitente" SortExpression="Emitente" />
                                                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                                                <asp:BoundField DataField="cd_cpf_cnpj" HeaderText="CPF/CNPJ" />
                                                <asp:BoundField DataField="Estabelecimento" HeaderText="Estabel" SortExpression="Estabelecimento" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fabrica" HeaderText="Fabrica" SortExpression="Fabrica" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NF" HeaderText="Nota Fiscal" SortExpression="NF" />
                                                <asp:BoundField DataField="dt_emissao" HeaderText="Dt Emiss&#227;o" SortExpression="dt_emissao" />
                                                <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" SortExpression="dt_entrada" />
                                                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="Quantidade" />
                                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                                                <asp:BoundField DataField="Unitario" HeaderText="Unitario" SortExpression="Unitario" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                <asp:BoundField HeaderText="Varia&#231;&#227;o" />
                                                <asp:BoundField DataField="nr_valor_icms" HeaderText="Valor ICMS" />
                                                <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_romaneio" runat="server" Text='<%# Bind("id_romaneio") %>' __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="diferenca_pesagem" Visible="False">
                                                    <itemtemplate>
<asp:Label id="diferenca_pesagem" runat="server" Text='<%# Bind("diferenca_pesagem") %>' __designer:wfdid="w6"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
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
