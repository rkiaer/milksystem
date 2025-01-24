<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_calculo_acompanhamento.aspx.vb" Inherits="lst_calculo_acompanhamento" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_calculo_acompanhamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Acompanhamento do Cálculo&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif">
                        &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton></TD>
					<TD class="faixafiltro1a" style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colspan="4"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Mes/Ano Referência:</td>
                                <td style="height: 20px; width: 601px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_dt_referencia" runat="server" CssClass="texto" Width="23px"></asp:Label></td>
                                <TD style="HEIGHT: 20px; width: 325px;" align="right">
                                    &nbsp;Número da Execução:</td>
                                <TD style="HEIGHT: 20px; width: 758px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_nr_execucao" runat="server" CssClass="texto" Width="23px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Tipo do Pagamento:</td>
                                <td style="height: 20px; width: 601px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_tp_pagamento" runat="server" CssClass="texto" Width="222px"></asp:Label></td>
  								<TD style="HEIGHT: 20px; width: 325px;" align="right">&nbsp;Total de Propriedades:</TD>
								<TD style="HEIGHT: 20px; width: 758px;">&nbsp;
                                    <asp:Label ID="lbl_total_propriedade" runat="server" CssClass="texto" Width="23px"></asp:Label></TD>
                          </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Total Sem Volume:</td>
                                <td style="height: 20px; width: 601px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_total_sem_volume" runat="server" CssClass="texto" Width="222px"></asp:Label></td>
  								<TD style="HEIGHT: 20px; width: 325px;" align="right">&nbsp;Total Sem Preço:</TD>
								<TD style="HEIGHT: 20px; width: 758px;">&nbsp;
                                    <asp:Label ID="lbl_total_sem_preco" runat="server" CssClass="texto" Width="23px"></asp:Label></TD>
                          </tr>
						</TABLE>
						</TD>
					<TD style="height: 62px" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;Detalhes:</TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <itemtemplate>
&nbsp; <anthem:Image id="imag_ok" runat="server" __designer:wfdid="w14" ImageUrl="~/img/icon_ok.gif"></anthem:Image>
</itemtemplate>
                                                    <headerstyle width="10%" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" SortExpression="ds_propriedade" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="U.Produ&#231;&#227;o" SortExpression="nr_unid_producao" >
                                                    <headerstyle width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_calculo_execucao_itens" HeaderText="Status"
                                                    SortExpression="st_calculo_execucao_itens" />
                                                <asp:TemplateField HeaderText="Resultado">
                                                    <itemtemplate>
<anthem:ImageButton id="img_resultado" runat="server" __designer:wfdid="w11" CommandArgument='<%# bind("id_calculo_execucao_itens") %>' ImageUrl="~/img/icone_pagamento2.gif" ToolTip="Resultado do Cálculo" CommandName="resultado"></anthem:ImageButton>
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
		</form>
	</body>
</HTML>
