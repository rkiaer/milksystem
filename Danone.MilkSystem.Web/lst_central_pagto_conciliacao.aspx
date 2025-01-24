<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_pagto_conciliacao.aspx.vb" Inherits="lst_central_pagto_conciliacao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatório de Apoio - Conciliação Pagamentos da Central de Compras</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Relatório de Apoio - Conciliação Pagamentos Central de Compras</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 26px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 26px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 30%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 25px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Referência:</td>
                                <TD style="HEIGHT: 25px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_ini" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência Inicial para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator>
                                    (mes/ano)</td>
                                <td align="left" style="height: 25px">
                                    <anthem:CheckBox ID="chk_indiretos" runat="server" Text="Pedidos Indiretos" /></td>
                                <td style="height: 25px"><anthem:CheckBox ID="chk_todas_referencias" runat="server" Text="Exibir Todas Referências Pagto Fornecedor" ToolTip="Exibir apenas a referência informada ou 12 meses." />
                                    <anthem:CheckBox ID="chk_pedidos_abertos" runat="server" Text="Pedidos Pendentes anteriores ao período selecionado" Visible="False" /></td>
                                       
                            </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 32px">
                                    </td>
								<TD align="left" colspan="2" style="height: 32px">&nbsp;
                                    </TD>
								<TD align="right" style="height: 32px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;</TD>
							</tr>
                            <tr>
                                <td align="right" colspan="1" style="height: 2px">
                                </td>
                                <td align="left" colspan="2" style="height: 2px">
                                </td>
                                <td align="right" style="height: 2px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 26px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 26px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 2px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 2px; ">
                       </td>
                    <TD style="height: 2px; width: 10px;">
                    </td>
                </tr>
				<TR  >
					<TD style="width: 9px;"></TD>
					<TD>
                            <anthem:GridView ID="gridAbertos" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Verdana"
                            Font-Size="XX-Small" PageSize="50" UpdateAfterCallBack="True" Visible="False"
                            Width="100%">
                            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade"
                                    ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cd Produtor">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Produtor">
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_tecnico" HeaderText="Tec.Danone" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_educampo" HeaderText="Tec.Educampo" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_conquali" HeaderText="Tec.ConQuali" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="Cod.SAP Parceiro">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Fornecedor" SortExpression="nm_abreviado_fornecedor">
                                    <headerstyle wrap="True" />
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_item" HeaderText="Cod.Item" />
                                <asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o" />
                                <asp:BoundField DataField="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Pedido"
                                    SortExpression="dt_pedido">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:N2}" HeaderText="Total Pedido" >
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_emissao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Emiss&#227;o" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nota Fiscal"
                                    ReadOnly="True">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" HeaderText="Valor Nota Fiscal">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" DataFormatString="{0:n0}" HeaderText="N.o Pedido">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_tipo_parcelamento" HeaderText="Tipo Pagto">
                                    <itemstyle font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_qtde_parcelas" HeaderText="Parcelas">
                                    <itemstyle font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="totalpagofornec" DataFormatString="{0:N2}" HeaderText="Total Pago Parceiro">
                                    <itemstyle horizontalalign="Right" wrap="False" backcolor="LightSkyBlue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_fornec_nota" DataFormatString="{0:N2}" HeaderText="Pagto X Nota">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>

                                <asp:BoundField DataField="totalpagoprod" DataFormatString="{0:N2}" HeaderText="Total Desc. Produtor"
                                    ReadOnly="True">
                                    <itemstyle horizontalalign="Right" wrap="False" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_saldo" DataFormatString="{0:N2}" HeaderText="Saldo">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                     </TD>
					<TD style="width: 10px;"></TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;&nbsp;
        </div>
		</form>
	</body>
</HTML>
