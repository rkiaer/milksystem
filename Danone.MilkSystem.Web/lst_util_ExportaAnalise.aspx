<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_util_ExportaAnalise.aspx.vb" Inherits="lst_util_ExportaAnalise" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_util_ExportaAnalise</title>
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
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Conferência de Entrada de Romaneios</strong></td>
					<td width="10" style="height: 25px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px"></td>
					<td align="center">
						</td>
					<td width="10"></td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px; height: 121px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" style="height: 121px">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()"topmargin="0" >
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 23px">
                                    &nbsp;<span style="color: #ff0000">*</span>Estabelecimento:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="caixaTexto">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="Informe o Estabelecimento para continuar." Font-Bold="True" SetFocusOnError="True"
                                        ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span style="color: #ff0000">*</span>Período:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="dt_inicio" runat="server" Columns="7" CssClass="texto"
                                        DateMask="DayMonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dt_inicio"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="Informe o Período." ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator>
                                    à &nbsp;<cc2:OnlyDateTextBox ID="dt_fim" runat="server" Columns="7" CssClass="texto" DateMask="DayMonthYear"
                                        Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dt_fim"
                                        Font-Bold="True" SetFocusOnError="True" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="color: #333333">
                                <td align="right" style="height: 20px" width="20%">
                                    </td>
                                <td style="height: 20px">
                                    </td>
                            </tr>
							<TR style="color: #333333">
								<TD style="height: 25px"></TD>
								<TD align="right" style="height: 25px">
                                    &nbsp; &nbsp;
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        &nbsp;
                        <!-- <table id="table_estatisticas" class = "borda"  cellpadding="0"cellspacing="0"width="100%" border="0" > -->
                        <table id="table3" class = "borda"  cellpadding="0"cellspacing="0"width="100%" border="0" >
                        <tr runat="server" visible="false"><td style="width: 198px; height: 21px" align="left" class="texto" >
                            <bdo dir="ltr" class="texto"><strong>Total de cadernetas:</strong></bdo>
                        <anthem:Label ID="Label1" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto"></anthem:Label></td><td style="width: 225px; height: 21px" align="left" class="texto">
                            <strong>Romaneios</strong> <strong>abertos:&nbsp;
                                <anthem:Label ID="Label2" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                    Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="80px"></anthem:Label>
                            </strong></td><td style="width: 25%; height: 21px" align="left" class="texto">
                <strong class="texto">Análises OK:<anthem:Label ID="Label5" runat="server" AutoUpdateAfterCallBack="True"
                    CssClass="texto" Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="112px"></anthem:Label>
                </strong></td><td style="width: 25%; height: 21px" align="left" class="texto">
                <strong>Silos registrados:<anthem:Label ID="Label8" runat="server" AutoUpdateAfterCallBack="True"
                    CssClass="texto" Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="96px"></anthem:Label>
                </strong></td>
                        </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 198px; height: 23px;" align="left" class="texto">
                                </td>
                                <td style="width: 225px; height: 23px;" align="left" class="texto">
                                    <strong>Romaneios Fechados:&nbsp;
                                        <anthem:Label ID="Label4" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="88px"></anthem:Label></strong></td>
                                <td style="height: 23px" align="left" class="texto" >
                                    <strong class="texto">Análises</strong> <strong>iniciadas:<anthem:Label ID="Label6"
                                        runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Font-Bold="False"
                                        Height="8px" UpdateAfterCallBack="True" Width="96px"></anthem:Label></strong></td><td style="height: 23px" align="left" class="texto">
                <strong>Silos para registrar:<anthem:Label ID="Label9" runat="server" AutoUpdateAfterCallBack="True"
                    CssClass="texto" Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="80px"></anthem:Label></strong></td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="height: 24px; width: 198px;" align="left" class="texto">
                                </td>
                                <td style="height: 24px; width: 225px;" align="left" class="texto">
                                    <strong></strong></td>
                                <td style="height: 24px" align="left" class="texto">
                                    <strong>Análises NOK:<anthem:Label ID="Label7" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Bold="False" Height="8px" UpdateAfterCallBack="True" Width="104px"></anthem:Label>
                                    </strong></td><td style="height: 24px" align="left" class="texto"></td>
                            </tr>
                        </table>
                        </TD>
					<TD style="height: 121px">&nbsp;</TD>
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
					<TD style="width: 9px; height: 243px;">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="NM_LINHA" HeaderText="Rota/Coop" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="transitpoint" HeaderText="Transit Point" />
                                                <asp:BoundField DataField="DS_PLACA" HeaderText="Placa" />
                                                <asp:BoundField DataField="CADERNETA" HeaderText="Caderneta" />
                                                <asp:BoundField DataField="ROMANEIO" HeaderText="Romaneio" />
                                                <asp:BoundField DataField="STATUS" HeaderText="Status" />
                                                <asp:BoundField DataField="REG_ANALISE" HeaderText="Reg. An&#225;lise Comp." />
                                                <asp:BoundField DataField="SILO" HeaderText="Silo" />
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
                                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Tipo Ve&#237;culo" />
                                                <asp:TemplateField HeaderText="ds_tempo_rota_minutos" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_ds_tempo_rota_minutos" runat="server" Text='<%# Bind("ds_tempo_rota_minutos") %>' __designer:wfdid="w33"></asp:Label>
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
					<TD style="height: 243px">&nbsp;</TD>
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
