<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_relatorio_entrada_cooperativa.aspx.vb" Inherits="lst_relatorio_entrada_cooperativa" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatório de Entrada de Cooperativas</title>
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
                        <strong>Relação de Entrada de Cooperativas</strong></TD>
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
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 22px">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto" ValidationGroup="gv_estabel">
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 22px">
                                    &nbsp;</td>
                                <td align="right" style="height: 22px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px" width="20%">
                                    <span style="color: #ff0000">*</span>Mês/Ano Referência:</td>
                                <td style="height: 22px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" Columns="7" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="A referência deve ser informada!" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" />
                        <anthem:HyperLink ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Enabled="False" NavigateUrl="~/frm_relatorio_entrada_cooperativa.aspx"
                            Target="_blank" UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" SortExpression="fornecedor" />
                                                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                                                <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" SortExpression="dt_entrada" />
                                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr Nota" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CFOP" HeaderText="CFOP" />
                                                <asp:BoundField DataField="qtde" HeaderText="Qtde" />
                                                <asp:BoundField DataField="vl_unit_nota" HeaderText="Vl Unit" />
                                                <asp:BoundField DataField="vl_nota" HeaderText="Vl Nota" />
                                                <asp:BoundField DataField="vl_unit_calc" HeaderText="Vl Unit Calc" />
                                                <asp:BoundField HeaderText="Vl Quinz" DataField="nr_preco_negociado" />
                                                <asp:BoundField DataField="valor_quinzena" HeaderText="Vl Quinz" />
                                                <asp:BoundField DataField="diferenca" HeaderText="Diferen&#231;a" />
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
