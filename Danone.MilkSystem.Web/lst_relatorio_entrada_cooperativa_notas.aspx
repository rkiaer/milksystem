<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_relatorio_entrada_cooperativa_notas.aspx.vb" Inherits="lst_relatorio_entrada_cooperativa_notas" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatório de Entrada de Cooperativas e Notas Fiscais</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 2px; height: 28px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 28px;">
                        <strong>Relação de Entrada de Cooperativas e Notas Fiscais</strong></TD>
					<TD style="height: 28px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 2px;">&nbsp;</TD>
					<TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 25px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 2px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 25px">
                                    &nbsp;<span style="color: #ff0000">*</span>Estabelecimento:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="gv_estabel">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 24px" width="20%">
                                    <span style="color: #ff0000">*</span>Mês/Ano Referência:</td>
                                <td style="height: 24px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_data_ini" runat="server" Columns="10" CssClass="texto"
                                        DateMask="DayMonthYear" Width="88px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox>&nbsp; à&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_data_fim" runat="server" Columns="10" CssClass="texto"
                                        DateMask="DayMonthYear" Width="88px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data para continuar." Font-Bold="True"
                                        ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_data_fim"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data  para continuar." Font-Bold="True"
                                        ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_pesquisar"></anthem:imagebutton>&nbsp;&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="gv_pesquisar" />&nbsp;&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;
                                </TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="width: 2px" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 2px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 25px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 7px; width: 2px;"></TD>
					<TD vAlign="middle" style="height: 7px">&nbsp;</TD>
					<TD style="height: 7px; width: 2px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 2px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                                            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabel." >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d.Transportador" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_entrada_romaneio" HeaderText="Entrada" DataFormatString="{0:MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_saida_romaneio" HeaderText="Sa&#237;da" DataFormatString="{0:MM/yyyy}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_cooperativa" HeaderText="C&#243;d.Cooperativa" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_cnpj" HeaderText="CNPJ" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Item" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_peso_liquido_romaneio" HeaderText="Peso L&#237;q. Rom." DataFormatString="{0:n0}" >
                                                    <headerstyle wrap="False" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_peso_liquido_nota" HeaderText="Peso L&#237;q. NF" DataFormatString="{0:n0}" >
                                                    <headerstyle wrap="False" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="valor_nota_fiscal" HeaderText="Valor NF" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_nota_fiscal" HeaderText="Tipo NF" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_natureza_operacao" HeaderText="CFOP" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_natureza_operacao" HeaderText="Nome Natureza Opera&#231;&#227;o" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr NF" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_serie" HeaderText="Nr S&#233;rie" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_emissao_nota" HeaderText="Emiss&#227;o NF" DataFormatString="{0:MM/yyyy}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_transacao_nota" HeaderText="Transa&#231;&#227;o NF" DataFormatString="{0:MM/yyyy}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_saida_nota" HeaderText="Sa&#237;da NF" DataFormatString="{0:MM/yyyy}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_chave_nfe" HeaderText="Chave NFE" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="valor_icms" HeaderText="Valor ICMS" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_po_cooperativa" HeaderText="Nr. PO" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_frete_nf" HeaderText="Frete NF" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_cte" HeaderText="Nr CTE" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_cte" HeaderText="Valor CTE" DataFormatString="{0:n2}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_chave_cte" HeaderText="Chave CTE" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tipo_2a_nota_fiscal" HeaderText="Tipo 2a. NF" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_nota_fiscal2" HeaderText="Nr 2a. NF" DataFormatString="{0:n0}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_serie_nota_fiscal2" HeaderText="S&#233;rie 2a. NF" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_litros_nota_fiscal2" HeaderText="Litros 2a NF" DataFormatString="{0:n0}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_nota_fiscal2" HeaderText="Valor 2a. NF" DataFormatString="{0:n2}" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" /><PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_pesquisar" />
		</form>
	</body>
</HTML>
