<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_pre_romaneio_controle_leite.aspx.vb" Inherits="lst_pre_romaneio_controle_leite" %>

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
		<title>Pré Romaneio - Controle de Recepção de Leite</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 9px; height: 25px;">&nbsp;</td>
					<td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Pré Romaneios - Controle de Recepção de Leite</strong></td>
					<td style="width: 9px;height: 25px">&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 2px; width: 9px;">&nbsp;</td>
					<td style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></td>
					<td style="HEIGHT: 2px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 9px;">&nbsp;</td>
					<td id="td_pesquisa" runat="server" valign="middle" class="texto" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" topmargin="0" >
							<TR>
								<TD style="width: 17%; height: 12px;" ></TD>
								<TD style="width: 22%;height: 12px" ></TD>
                                <td style="width: 14%; height: 12px">
                                </td>
                                <td style="width: 13%; height: 12px">
                                </td>
								<TD style="width: 13%; height: 12px;" ></TD>
								<TD style="height: 12px" ></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 30px;">
                                    &nbsp;<span style="color: #ff0000">*<span style="color: #333333">Período&nbsp;de Entrada:</span></span></td>
                                <td style="height: 30px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" Columns="7" CssClass="texto"
                                        DateMask="DayMonthYear" Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_inicio"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="Informe o Período." ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator>&nbsp;
                                    à &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" Columns="7" CssClass="texto" DateMask="DayMonthYear"
                                        Width="85px"></cc2:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_fim"
                                        Font-Bold="True" SetFocusOnError="True" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="height: 30px">
                                    <span style="color: #333333">
                                     Nome da Rota:</span></td>
                                <td align="left" style="height: 30px">
                                    &nbsp; &nbsp;
                                     <anthem:TextBox ID="txt_nm_linha" runat="server" CssClass="Texto" MaxLength="10"
                                         Width="70px" AutoUpdateAfterCallBack="True"></anthem:TextBox><span style="color: #ff0000"></span></td>
                                 <td style="height: 30px" align="right">
                                    Nr. Pré Romaneio:</td>
                                <td style="height: 30px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" CssClass="texto" Width="85px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
							<TR style="color: #333333">
								<TD style="height: 25px; "></TD>
								<TD align="right" style="height: 25px" colspan="5">
                                    &nbsp;&nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    &nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" AutoUpdateAfterCallBack="True" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;</TD>
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
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD>
                        <br />


                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_transportador" HeaderText="C&#243;d. Transp" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_transportador" HeaderText="Transportador" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="rota" HeaderText="Rota" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Pr&#233; Romaneio" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada" HeaderText="Entrada" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Hr Entr." >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_saida" HeaderText="Sa&#237;da" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_hora_saida" HeaderText="Hr Sa&#237;da" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="peso_liquido_balanca" HeaderText="Peso Balan&#231;a" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_densidade" HeaderText="Densidade" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume" HeaderText="Volume" DataFormatString="{0:N0}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_volume_caderneta" HeaderText="Volume Caderneta" DataFormatString="{0:N0}" >
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_variacao_volume" HeaderText="Varia&#231;&#227;o Volume" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_divergencia" HeaderText="Diverg&#234;ncia" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_aprovacao" HeaderText="Aprova&#231;&#227;o" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_situacao" HeaderText="Situa&#231;&#227;o Romaneio" >
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_entrada_romaneio" HeaderText="Entrada Romaneio" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                         
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
            &nbsp;
		</form>
	</body>
</HTML>
