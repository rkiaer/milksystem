<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_importar_lancamento.aspx.vb" Inherits="lst_importar_lancamento" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Importar Pedidos Fomento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Importar Lançamentos</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 133px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 133px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="10%" style="height: 12px; width: 20%;"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="10%" style="HEIGHT: 12px" align="right"><span style="color: #ff0000"><strong>*</strong></span>Referência:</td>
                                <td style="height: 20px; ">
                                    &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_referencia" CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado."
                                        Font-Bold="True" ValidationGroup="vgpedido">[!]</anthem:RequiredFieldValidator></td>
 								<TD  style="height: 12px; width: 156px;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Nome do Arquivo:</TD>
								<TD style="height: 12px">
                                    &nbsp;<anthem:FileUpload ID="fup_nm_arquivo" runat="server" CssClass="texto" Width="405px"  /><anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fup_nm_arquivo"
                                        CssClass="texto" ErrorMessage="Escolha o arquivo para continuar." Font-Bold="True" AutoUpdateAfterCallBack="True" ValidationGroup="vgpedido">[!]</anthem:RequiredFieldValidator></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    <strong><span style="color: #ff0000"></td>
                                <td style="height: 20px;" align="right">
                                    &nbsp; &nbsp;&nbsp;<anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas lidas:"
                                         Width="160px"></anthem:Label>
                                    <anthem:Label ID="lbl_totallinhaslidas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
								<TD style="height: 20px; " align="right">
                                    </TD>
								<TD style="height: 20px">
                                    &nbsp;<anthem:Label ID="lbl_totalimportadas" runat="server" Text="Total de linhas importadas:"></anthem:Label>
                                    <anthem:Label ID="lbl_totallinhasimportadas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD >&nbsp;Nr Importação:
                                    <anthem:Label ID="lbl_nr_importacao" runat="server" AutoUpdateAfterCallBack="True" Text="0"
                                        UpdateAfterCallBack="True"></anthem:Label></TD>
								<TD align="right">
                                    &nbsp;<anthem:imagebutton id="btn_importar" runat="server" imageurl="~/img/bnt_importar.gif" ValidationGroup="vgpedido" ></anthem:imagebutton>&nbsp;&nbsp;
                                    &nbsp; &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" />
                        <anthem:HyperLink ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Enabled="False" NavigateUrl="~/frm_relatorio_import_pagto_transportador.aspx"
                            Target="_blank" UpdateAfterCallBack="True">Relatório Consistências</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="15" AddCallBacks="False" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nr_linha" HeaderText="Nr Linha" SortExpression="nr_linha" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop." />
                                                <asp:BoundField DataField="ds_conta" HeaderText="Conta" />
                                                <asp:BoundField DataField="ds_valor" HeaderText="Valor" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_erro" HeaderText="Observa&#231;&#227;o" SortExpression="nm_erro" />
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vgpedido" />
		</form>
	</body>
</HTML>
