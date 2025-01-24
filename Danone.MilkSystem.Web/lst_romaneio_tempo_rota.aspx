<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_tempo_rota.aspx.vb" Inherits="lst_romaneio_tempo_rota" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Romaneio - Tempo de Rotas</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Romaneio - Tempo de Rotas</strong></td>
					<td style="width: 9px;height: 25px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px"></td>
					<td align="center">
						</td>
					<td ></td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" topmargin="0" >
							<TR>
								<TD style="width: 20%; height: 12px;" ></TD>
								<TD style="width: 30%;height: 12px" ></TD>
								<TD style="width: 20%; height: 12px;" ></TD>
								<TD style="height: 12px" ></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px;">
                                    &nbsp;<span style="color: #ff0000">*</span>Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="Informe o Estabelecimento para continuar." Font-Bold="True" SetFocusOnError="True"
                                        ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                                 <td align="right">&nbsp;<span style="color: #ff0000">*</span>Período&nbsp;
                                 <anthem:RadioButtonList ID="opt_periodo" runat="server"
                                        RepeatDirection="Horizontal" Font-Size="XX-Small" RepeatLayout="Flow">
                                        <Items>
                                            <asp:ListItem Selected="True" Value="1">Entrada</asp:ListItem>
                                            <asp:ListItem Value="2">Transmiss&#227;o</asp:ListItem>
                                        </Items>
                                    </anthem:RadioButtonList>:</td>
                                 <td>
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" Columns="7" CssClass="texto"
                                        DateMask="DayMonthYear" Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="Informe o Período." ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator>&nbsp;
                                    à &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" Columns="7" CssClass="texto" DateMask="DayMonthYear"
                                        Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_fim"
                                        Font-Bold="True" SetFocusOnError="True" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 23px;">
                                    &nbsp;Tempo de Rota:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tempo_rota" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">At&#233; 12 Horas</asp:ListItem>
                                        <asp:ListItem Value="2">De 12:01 &#224; 20:00 Horas</asp:ListItem>
                                        <asp:ListItem Value="3">Acima de 20 Horas</asp:ListItem>
                                    </anthem:DropDownList></td>
                                 <td align="right">
                                     Nome da Rota:</td>
                                 <td>
                                     &nbsp;
                                     <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                         Width="64px"></anthem:TextBox></td>
                            </tr>
                            <tr style="color: #333333">
                                <td align="right" style="height: 20px; " >
                                    Tipo Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tiporomaneio" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="N">Normal</asp:ListItem>
                                        <asp:ListItem Value="T">Transbordo</asp:ListItem>
                                        <asp:ListItem Value="TP">Transit Point</asp:ListItem>
                                        <asp:ListItem Value="PRTP">Pr&#233; Romaneio TP</asp:ListItem>
                                        <asp:ListItem Value="TV">Transvase</asp:ListItem>
                                        <asp:ListItem Value="PRTV">Pr&#233; Romaneio Transvase</asp:ListItem>
                                    </anthem:DropDownList>
                                    </td>
                                 <td align="right">
                                     Nr Romaneio / Pré Romaneio:</td>
                                <td>
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px; " >
                                    Nr Transit Point:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_transit_point" runat="server" CssClass="texto"
                                        Width="85px"></cc3:OnlyNumbersTextBox></td>
                                <td align="right">
                                    Nr Transvase:</td>
                                <td>
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_transvase" runat="server" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
							<TR style="color: #333333">
								<TD style="height: 25px; "></TD>
								<TD align="right" style="height: 25px" colspan="3">
                                    &nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        &nbsp;
                    </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR runat="server" id="tr_controle_rota" >
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px" align="center" class="texto">
                        <br />
					<anthem:Panel ID="pnl_controle_rota" runat="server" BackColor="White" CssClass="texto"
                            GroupingText="Controle Tempo de Rota" Width="80%" Font-Size="X-Small" AutoUpdateAfterCallBack="True" Visible="False" >
                        &nbsp;<table class="texto" width="90%" style="vertical-align: middle; font-size: x-small;">
                            <tr>
                                <td style="height: 20px; vertical-align: middle;" align="right" valign="middle" >
                                    <anthem:Image ID="img_green" runat="server"  ImageUrl="~/img/icon_status_verde.gif"  />&nbsp;Até
                                    12:00 Horas:</td>
                                <td style="height: 20px" valign="middle" align="left" >
                                    &nbsp;<anthem:Label ID="lbl_tempo_rota_green" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Font-Bold="True" Font-Size="X-Small">100%</anthem:Label></td>
                                <td style="height: 20px; vertical-align: middle;" align="right" valign="middle" >
                                    <anthem:Image ID="img_yellow" runat="server"  ImageUrl="~/img/icon_status_amarelo.gif" />&nbsp;
                                    De 12:01 à 20:00 Horas:</td>
                                <td style="height: 20px" valign="middle" align="left">
                                    &nbsp;<anthem:Label ID="lbl_tempo_rota_yellow" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Font-Bold="True" Font-Size="X-Small">100%</anthem:Label></td>
                                <td style="height: 20px; vertical-align: middle;" align="right" valign="middle" >
                                    <anthem:Image ID="img_red" runat="server"  ImageUrl="~/img/icon_status_vermelho.gif" />&nbsp;
                                    Acima de 20:00 Horas:</td>
                                <td style="height: 20px" valign="middle" align="left" >
                                    &nbsp;<anthem:Label ID="lbl_tempo_rota_red" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Font-Bold="True" Font-Size="X-Small">100%</anthem:Label></td>
                            </tr>
                        </table>
                        </anthem:Panel>
                        <br />
                    </TD>
					<TD style="height: 19px"></TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_tipo_romaneio" HeaderText="Tipo Romaneio" />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota/Coop" >
                                </asp:BoundField>
                                <asp:BoundField DataField="ROMANEIO" HeaderText="Romaneio" />
                                <asp:BoundField DataField="transitpoint" HeaderText="Transit Point" />
                                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" />
                                <asp:BoundField DataField="STATUS" HeaderText="Status" />
                                <asp:BoundField DataField="dt_transmissao" HeaderText="Dt Transmiss&#227;o" />
                                <asp:BoundField DataField="hr_transmissao" HeaderText="Hor&#225;rio Trans." />
                                <asp:BoundField DataField="dt_entrada" HeaderText="Dt Entrada" />
                                <asp:BoundField DataField="hr_entrada" HeaderText="Hor&#225;rio Entr." />
                                <asp:BoundField DataField="dt_saida" HeaderText="Dt Sa&#237;da" />
                                <asp:BoundField DataField="hr_saida" HeaderText="Hor&#225;rio Sa&#237;da" />
                                <asp:BoundField DataField="ds_tempo_patio" HeaderText="Tempo P&#225;tio" />
                                <asp:BoundField DataField="ds_tempo_patio_externo" HeaderText="Tempo P&#225;tio Externo" />
                                <asp:BoundField DataField="ds_tempo_rota" HeaderText="Tempo Rota" />
                                <asp:BoundField DataField="ds_transportador" HeaderText="Transportadora" />
                                <asp:TemplateField HeaderText="ds_tempo_rota_minutos" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_ds_tempo_rota_minutos" runat="server" __designer:wfdid="w11" Text='<%# Bind("ds_tempo_rota_minutos") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
										</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary
                ID="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"
                ValidationGroup="vg_load" />
		</form>
	</body>
</HTML>
