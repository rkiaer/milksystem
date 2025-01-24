<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_batch_erro.aspx.vb" Inherits="frm_batch_erro" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Inconsistências da Exportação Batch Declaration</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" />
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server" style="width:100%">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="99%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Inconsistências Exportação Batch Declaration</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 127px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" align="center" class="texto">
                        &nbsp;<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td align="left" colspan="2" style="height: 20px">
                                    &nbsp;Nr Execução:
                                    <anthem:Label ID="lbl_execucao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="height: 20px">
                                    <br />
                                    <anthem:GridView ID="grderros" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana"
                                        Font-Size="XX-Small" ForeColor="#333333" GridLines="None" PageSize="13" UpdateAfterCallBack="True"
                                        Width="99%" Visible="False">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                            ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                            ForeColor="White" HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                            HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                            <asp:BoundField DataField="nm_erro" HeaderText="Erro" ReadOnly="True" SortExpression="nm_erro">
                                                <itemstyle wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="id_exportacao_batch_erro" HeaderText="id_exportacao_batch_erro"
                                                Visible="False" />
                                            <asp:BoundField DataField="id_exportacao_batch_itens" HeaderText="Item Exec." Visible="False" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <RowStyle BackColor="#EFF3FB" />
                                    </anthem:GridView>
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="height: 127px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages></form>
	</body>
</HTML>
