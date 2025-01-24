<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_frete_kpi_densidade.aspx.vb" Inherits="lst_frete_kpi_densidade" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatório de Frete KPI Densidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 2px; height: 28px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 28px;">
                        <strong>KPI Frete - Densidade</strong></TD>
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
                        <br />
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
                                        DateMask="MonthYear" Width="88px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_data_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data para continuar." Font-Bold="True"
                                        ValidationGroup="gv_pesquisar">[!]</anthem:RequiredFieldValidator>
                                    &nbsp;<cc2:OnlyDateTextBox ID="txt_data_fim" runat="server" Columns="10" CssClass="texto"
                                        DateMask="DayMonthYear" Width="88px" AutoUpdateAfterCallBack="True" Visible="False"></cc2:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_data_fim"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data  para continuar." Font-Bold="True"
                                        ValidationGroup="gv_pesquisar" Visible="False">[!]</anthem:RequiredFieldValidator></td>
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
					<TD style="width: 2px">&nbsp;</TD>
					<TD class="texto">
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small"
                            ForeColor="#333333" GridLines="None" PageSize="15" UpdateAfterCallBack="True"
                            Visible="False" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="dt_referencia" DataFormatString="{0:MM/yyyy}" HeaderText="Refer&#234;ncia">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" Visible="False">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa2" HeaderText="2a.Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume" DataFormatString="{0:N0}" HeaderText="Volume">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" DataFormatString="{0:N0}" HeaderText="KM Frete">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="capacidadetotal" DataFormatString="{0:N0}" HeaderText="Capacidade">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_densidade" DataFormatString="{0:N0}" HeaderText="Densidade">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_taxa_ocupacao" DataFormatString="{0:N2}" HeaderText="Tx.Ocupa&#231;&#227;o %">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
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
