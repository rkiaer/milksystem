<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_saida_controle_saida.aspx.vb" Inherits="lst_romaneio_saida_controle_saida" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Romaneio Saída - Controle de Saídas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Romaneio Saída - Controle de Saídas</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD  style="height: 12px; width: 15%;"></TD>
								<TD style="height: 12px; width: 20%;"></TD>
                                <td style="height: 12px; width: 13%;">
                                </td>
                                <td style="height: 12px;">
                                </td>
                                <td style="width: 13%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" class="texto" style="height: 23px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento<strong>:</strong></td>
                                <td style="height: 23px" >
                                    &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="true"
                                        AutoPostBack="false" AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="Escolha o Estabelecimento para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                                <td style="height: 23px" align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Saída:</td>
                                <td style="height: 23px" >
                                    &nbsp;<cc2:onlydatetextbox id="txt_dt_inicio" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" datemask="DayMonthYear" width="80px"></cc2:onlydatetextbox>
                                    à
                                    <cc2:onlydatetextbox id="txt_dt_fim" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" datemask="DayMonthYear" width="80px"></cc2:onlydatetextbox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="False" ToolTip="A data inicial do período deve ser informada." ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada." ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_fim"
                                                ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date" ValidationGroup="vg_load">[!]</anthem:CompareValidator>
</td>
                                <td style="height: 23px" align="right">
                                    <span style="color: #333333">Romaneio Saída:</span></td>
                                <td style="height: 23px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_romaneio_saida" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="90px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Tipo de Operação:&nbsp;<span style="color: #ff0000"></span></td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:DropDownList ID="cbo_tipo_operacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td style="height: 20px" align="right">
                                    Motivo Saída:</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:DropDownList ID="cbo_motivo_saida" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td style="height: 20px" align="right">
                                    Romaneio Origem:</td>
                                <td style="height: 20px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_romaneio_entrada" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="90px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Tipo de Leite:&nbsp;<span style="color: #ff0000"></span></td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:DropDownList ID="cbo_item" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td style="height: 20px" align="right">
                                </td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px" align="right">
                                </td>
                                <td style="height: 20px">
                                    &nbsp;</td>
                            </tr>
							<TR>
								<TD style="height: 33px"></TD>
								<TD align="right" colspan="5" style="height: 33px" valign="bottom">
                                    &nbsp;
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px; height: 24px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 24px" valign="middle">
                        &nbsp;&nbsp;</td>
                    <td style="height: 24px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 5px; width: 9px;" class="texto"></TD>
					<TD vAlign="middle" style="height: 5px" class="texto">&nbsp;</TD>
					<TD style="height: 5px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="texto">
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="3"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_saida">
                                            <Columns>
                                                <asp:BoundField DataField="id_romaneio_saida" HeaderText="Rom.Sa&#237;da" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_romaneio_entrada" HeaderText="Rom.Origem">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" Visible="False" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_hora_saida" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Sa&#237;da">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_destino_abreviado" HeaderText="Destinat&#225;rio" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_operacao" HeaderText="Tipo Opera&#231;&#227;o" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr NF" ReadOnly="True" >
                                                   <itemstyle horizontalalign="Center" />
                                               </asp:BoundField>
                                                <asp:BoundField DataField="nr_qtde_nf_anexo" HeaderText="Qtde" DataFormatString="{0:N0}" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_nf_anexo" HeaderText="Valor NF" DataFormatString="{0:N2}" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_motivo_saida" HeaderText="Motivo Sa&#237;da">
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_transportador_abreviado" HeaderText="Transportador">
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_frete_nf" HeaderText="Frete">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_nota_fiscal_cte" HeaderText="Nr CTE">
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_nota_fiscal_cte" DataFormatString="{0:N2}" HeaderText="Valor CTE">
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="Red" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" /><PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
		</form>
	</body>
</HTML>
