<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_conciliacao_contabilidade.aspx.vb" Inherits="lst_central_conciliacao_contabilidade" %>

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
		<title>Relatório de Apoio de Contas - Contabilidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); "><STRONG>Relatório de Apoio Contas - Contabilidade</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 26px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 26px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>De:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_ini" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência Inicial para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator>
                                    (mes/ano) &nbsp; à&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_fim" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="80px"></cc3:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_referencia_fim"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência Final para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cv_periodo" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                        ValidationGroup="gv_estabel">[!] </asp:CustomValidator>
                                    (mes/ano)</td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000"></span></strong></td>
                                <td style="height: 20px">
                                    </td>
                                       
                            </tr>
 							
                            <tr >
                                <td align="right" style="height: 20px; ">
                                    </td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<anthem:RadioButtonList ID="opt_tipo_visao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" RepeatDirection="Horizontal">
                                        <Items>
                                            <asp:ListItem Selected="True" Value="A">Anal&#237;tico</asp:ListItem>
                                            <asp:ListItem Value="S">Sint&#233;tico / Agrupado</asp:ListItem>
                                        </Items>
                                    </anthem:RadioButtonList></td>
 								<TD style="HEIGHT: 20px; " align="right">
                                     </TD>
								<TD style="HEIGHT: 20px">
                                    <anthem:CheckBox ID="chk_pedidos_abertos" runat="server" Text="Pedidos Pendentes anteriores ao período selecionado" /></TD>
                           </tr>
                          
							<tr>
                                <td align="right" colspan="1" style="height: 28px">
                                    Saldo Acumulado SAP:</td>
								<TD align="left" colspan="2" style="height: 28px">&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_saldoSAP" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc3:OnlyDateTextBox>
                                    (mes/ano) &nbsp;&nbsp;<cc5:OnlyDecimalTextBox ID="txt_nr_saldoacumuladoSAP" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="10" MaxMantissa="4" Width="120px"></cc5:OnlyDecimalTextBox>&nbsp;
                                    <asp:Button ID="btn_atualizarsaldoSAP" runat="server" CssClass="texto" Text="Atualizar" /></TD>
								<TD align="right" style="height: 28px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="gv_estabel" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
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
                        <anthem:Label ID="lbl_abertos" runat="server" AutoUpdateAfterCallBack="True" BackColor="#006699"
                            Font-Bold="True" Font-Size="Small" ForeColor="White" UpdateAfterCallBack="True"
                            Visible="False" Width="100%">PEDIDOS PENDENTES COM SALDO EM ABERTO ANTERIORES AO PERÍODO SELECIONADO:</anthem:Label>
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
                                <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MMM/yyyy}" HeaderText="Maior Ref. Parcela"
                                    ReadOnly="True">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="st_parcelamento" HeaderText="Parcelamento">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="C&#243;d. SAP Parceiro">
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor Parceiro" SortExpression="nm_fornecedor">
                                    <headerstyle wrap="True" />
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" DataFormatString="{0:n0}" HeaderText="N.o Pedido">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Pedido"
                                    SortExpression="dt_pedido">
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:n0}" HeaderText="Nota Fiscal"
                                    ReadOnly="True">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" HeaderText="Valor Nota Fiscal">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_parcelas_fornecedor" HeaderText="Parcelas Pagto Fornecedor">
                                    <itemstyle font-bold="False" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valortotalcreditoforn" DataFormatString="{0:N2}" HeaderText="Total D&#233;bito">
                                    <headerstyle backcolor="CornflowerBlue" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP Produtor">
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Nome do Produtor">
                                    <itemstyle horizontalalign="Left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valortotalcreditoprod" DataFormatString="{0:N2}" HeaderText="Total Cr&#233;dito"
                                    ReadOnly="True">
                                    <headerstyle backcolor="CornflowerBlue" />
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldonota" DataFormatString="{0:N2}" HeaderText="Saldo Nota">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
                        <anthem:Label ID="lbl_pedidos" runat="server" AutoUpdateAfterCallBack="True" BackColor="#006699"
                            Font-Bold="True" Font-Size="Small" ForeColor="White" UpdateAfterCallBack="True"
                            Visible="False" Width="100%">PEDIDOS DO PERÍODO SELECIONADO:</anthem:Label>
                         <anthem:GridView
                                ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="50"
                                UpdateAfterCallBack="True" Width="100%">
                                <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                    ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                    HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MMM/yyyy}" HeaderText="Refer&#234;ncia" >
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="st_parcelamento" HeaderText="Parcelamento">
                                        <itemstyle wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cd_codigo_sap_fornecedor" HeaderText="C&#243;d. SAP Parceiro">
                                        <itemstyle backcolor="Aquamarine" horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nm_fornecedor" HeaderText="Fornecedor Parceiro" SortExpression="nm_fornecedor">
                                        <headerstyle wrap="True" />
                                        <itemstyle horizontalalign="Left" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id_central_pedido" DataFormatString="{0:n0}" HeaderText="N.o Pedido">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dt_pedido" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data Pedido"
                                        SortExpression="dt_pedido">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_nota_fiscal" DataFormatString="{0:N0}" HeaderText="Nota Fiscal"
                                        ReadOnly="True">
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="S&#233;rie" Visible="False">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_valor_nota_fiscal" DataFormatString="{0:N2}" HeaderText="Valor Nota Fiscal">
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_total_parcelas_fornecedor" HeaderText="Parcelas Pagto Fornecedor">
                                        <itemstyle font-bold="False" horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_parcela_fornecedor" HeaderText="Parcela Exportada">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dt_exportacao" HeaderText="Data Exporta&#231;&#227;o Pagto Fornecedor">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_valor_parcela_paga_fornecedor" DataFormatString="{0:N2}"
                                        HeaderText="Valor Parcela Pagamento Fornecedor">
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP Produtor">
                                        <itemstyle backcolor="Aquamarine" horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Nome do Produtor">
                                        <itemstyle horizontalalign="Left" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="st_calculo_definitivo" HeaderText="C&#225;lculo">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_nota_fiscal_ficha" DataFormatString="{0:n0}" HeaderText="Nota Fiscal Leite Milk">
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dt_desconto_produtor" HeaderText="Data Desconto Produtor">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_parcela" HeaderText="Parcela do Desconto">
                                        <itemstyle horizontalalign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_valor_parcela_paga_produtor" DataFormatString="{0:N2}"
                                        HeaderText="Valor da Parcela Descontada">
                                        <headerstyle backcolor="CornflowerBlue" />
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nr_saldo" DataFormatString="{0:N2}" HeaderText="Movimento M&#234;s">
                                        <headerstyle backcolor="CornflowerBlue" />
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="saldonota" DataFormatString="{0:N2}" HeaderText="Saldo Nota">
                                        <itemstyle horizontalalign="Right" wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                            </anthem:GridView>
                    </TD>
					<TD style="width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD vAlign="top" align="center"  >
                        <anthem:GridView ID="gridResultsSintetico" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" CellPadding="3" Font-Names="Verdana" Font-Size="XX-Small" PageSize="20"
                            UpdateAfterCallBack="True" Width="60%">
                            <FooterStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#000066"
                                HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MMM/yyyy}" HeaderText="Per&#237;odo">
                                    <itemstyle backcolor="LightBlue" horizontalalign="Center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_debito" DataFormatString="{0:c2}" HeaderText="D&#233;bito">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_credito" DataFormatString="{0:c2}" HeaderText="Cr&#233;dito">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_saldo" DataFormatString="{0:c2}" HeaderText="Saldo">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_saldoacumulado" DataFormatString="{0:c2}" HeaderText="Saldo Acumulado">
                                    <itemstyle horizontalalign="Right" wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="nr_saldoinicialconta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_saldoinicialconta" runat="server" Text='<%# Bind("nr_saldoinicialconta") %>' __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <RowStyle ForeColor="#000066" />
                        </anthem:GridView>
					</TD>
					<TD style=" width: 10px;">&nbsp;</TD>
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
