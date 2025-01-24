<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_linha_atividade.aspx.vb" Inherits="lst_linha_atividade" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 934px;"><STRONG>Detalhes da Rota </STRONG>
					</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 934px">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 934px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 934px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
                                <td style="width: 78px; height: 12px">
                                </td>
								<TD style="height: 12px; width: 105px;"></TD>
								<TD style="height: 12px; width: 304px;"></TD>
                                <td style="width: 54px; height: 12px">
                                </td>
                                <td style="width: 392px; height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="width: 78px; height: 3px">
                                </td>
                                <TD style="HEIGHT: 3px; width: 105px;" align="left">
                                    Estabelecimento:</td>
                                <TD style="HEIGHT: 3px; width: 304px;">
                                    &nbsp;
                                    <asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" Width="274px"></asp:Label></td>
                                <td style="width: 54px; height: 3px">
                                    Rota:</td>
                                <td style="width: 392px; height: 3px">
                                    <asp:Label ID="lbl_linha" runat="server" CssClass="texto" Width="274px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 78px; height: 3px">
                                </td>
                                <td align="left" style="height: 3px; width: 105px;">
                                    </td>
                                <td style="height: 3px; width: 304px;">
                                    &nbsp;
                                    </td>
                                <td style="width: 54px; height: 3px">
                                </td>
                                <td style="width: 392px; height: 3px">
                                </td>
                            </tr>
							<TR>
                                <td style="width: 78px; height: 11px">
                                </td>
								<TD style="width: 105px; height: 11px">&nbsp;</TD>
								<TD align="right" style="width: 304px; height: 11px">
                                    &nbsp; &nbsp;</TD>
                                <td align="right" style="width: 54px; height: 11px">
                                </td>
                                <td align="right" style="width: 392px; height: 11px">
                                    <anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif" />&nbsp;</td>
							</TR>
						</TABLE>
						<BR>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 934px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_voltar" runat="server" ImageUrl="~/img/voltar.gif"></asp:Image><anthem:linkbutton
                            id="lk_voltar" runat="server">Voltar</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 934px;">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 934px">
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="atividade" HeaderText="Atividade" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sitio" HeaderText="Sitio" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="litros" HeaderText="Litros" />
                                                <asp:BoundField DataField="tecnico" HeaderText="Tecnico" />
                                                <asp:BoundField DataField="inicio" HeaderText="Inicio" />
                                                <asp:BoundField DataField="fim" HeaderText="Fim" />
                                                <asp:BoundField DataField="duracao" HeaderText="Duracao" />
                                                <asp:BoundField DataField="tempo" HeaderText="Tempo" />
                                                <asp:BoundField DataField="kmtotal" HeaderText="Km Total" />
                                                <asp:BoundField DataField="rota" HeaderText="Rota" />
                                                <asp:BoundField DataField="veiculo" HeaderText="Veiculo" />
                                                <asp:BoundField DataField="kmcumul" HeaderText="Km Cumul" />
                                                <asp:BoundField DataField="coordenaday" HeaderText="Coord.Y" />
                                                <asp:BoundField DataField="coordenadax" HeaderText="Coord.X" />
                                                <asp:BoundField DataField="descricaositio" HeaderText="Desc. Sitio" />
                                                <asp:BoundField DataField="descricaolongasitio" HeaderText="Desc. Longa Siitio" />
                                                <asp:BoundField DataField="dt_importacao" HeaderText="Dt Importa&#231;&#227;o" />
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
					<TD vAlign="top" style="height: 19px; width: 934px;">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
