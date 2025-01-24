<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_calculo_resultado.aspx.vb" Inherits="lst_calculo_resultado" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_calculo_resultado</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Resultado do Cálculo&nbsp;</STRONG></TD>
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
					<TD style="width: 9px; height: 62px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 62px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="right" style="height: 20px; width: 215px; " >
                                    Mes/Ano Referência:</td>
                                <td style="width: 161px; height: 20px;" >
                                    &nbsp;<asp:Label ID="lbl_dt_referencia" runat="server" CssClass="texto" ></asp:Label></td>
                                <td align="right" style="width: 226px; height: 20px;" >
                                    Propriedade:</td>
                                <td  >
                                    &nbsp;
                                    <asp:Label ID="lbl_propriedade" runat="server" CssClass="texto" ></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 215px; height: 20px;" >
                                    &nbsp;Tipo do Pagamento:</td>
                                <td style="width: 161px; height: 20px;" >
                                    &nbsp;<asp:Label ID="lbl_tp_pagamento" runat="server" CssClass="texto" ></asp:Label></td>
                                <td align="right" style="width: 226px; height: 20px;" >
                                    Unidade Produção:</td>
                                <td >
                                    &nbsp;
                                    <asp:Label ID="lbl_unid_producao" runat="server" CssClass="texto" ></asp:Label></td>
                            </tr>
                            <tr>
                                <TD  align="right" style="width: 215px; height: 20px;">
                                    Produtor:</td>
                                <td style="width: 161px; height: 20px;" colspan="2">
                                    &nbsp;<asp:Label ID="lbl_produtor" runat="server" CssClass="texto" Width="347px" ></asp:Label></td>
                                <td >
                                    &nbsp;
                                    </td>
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
				<tr>
					<TD style="height: 19px; width: 9px;"></TD>
				    <td >
	                <table  border="0" cellpadding="0" cellspacing="0">
					    <tr>
						<td width="160"><anthem:ImageButton ID="btn_analitico" runat="server" ImageUrl="~/img/aba_calculo_ativa.gif" AutoUpdateAfterCallBack="True" /></td>
						<td width="193"><anthem:ImageButton ID="btn_sintetico" runat="server" ImageUrl="~/img/aba_demonstrativo.gif" AutoUpdateAfterCallBack="True" /></td>
						<td width="136"><anthem:ImageButton ID="btn_custos" runat="server" ImageUrl="~/img/aba_custos.gif" AutoUpdateAfterCallBack="True" /></td>
						<td ></td>
					    </tr>
				    </table>
				    </td>
					<TD style="height: 19px"></TD>
				</tr>
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
                                                <asp:BoundField DataField="cd_conta" HeaderText="Conta" SortExpression="cd_conta" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_conta" HeaderText="Descri&#231;&#227;o" SortExpression="nm_conta" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="st_qtd_valor" HeaderText="Valor/Qtde" SortExpression="st_qtd_valor" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_natureza" HeaderText="Natureza"
                                                    SortExpression="nm_natureza" />
                                                <asp:BoundField DataField="st_origem_conta" HeaderText="Origem" SortExpression="st_origem_conta" />
                                                <asp:BoundField DataField="nr_valor_conta" HeaderText="Valor" SortExpression="nr_valor_conta" />
                                                <asp:BoundField DataField="nr_ordem" HeaderText="Ordem" SortExpression="nr_ordem" />
                                                <asp:BoundField DataField="ds_transportador_abreviado" HeaderText="Transp." />
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
