<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedidos_abertos.aspx.vb" Inherits="frm_central_pedidos_abertos" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />

    <title>Pedidos Em Aberto</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Pedidos Abertos</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" Visible="False" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False" Visible="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD  ></TD>
								<TD valign="top">
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
								
											<TD  >
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="titmodulo"  colSpan="4" style="height: 15px"> Descrição</TD>
													</TR>
                                                    <tr>
														<TD class="texto" align="right" width="21%" style="height: 22px" ><STRONG>Propriedade:</STRONG></TD>
														<TD style="height: 22px" >&nbsp;<asp:Label ID="lbl_propriedade" runat="server"  CssClass="texto"></asp:Label></TD>
														<TD class="texto" align="right" style="height: 22px" ><STRONG>Produtor:</STRONG></TD>
														<TD style="height: 22px" >&nbsp;<asp:Label ID="lbl_produtor" runat="server"  CssClass="texto"></asp:Label></TD>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="21%" style="height: 22px">
                                                            <strong>Propriedade Matriz:</strong></td>
                                                        <TD width="26%" style="height: 22px" class="texto">
                                                            &nbsp;<asp:Label ID="lbl_propriedade_matriz" runat="server" CssClass="texto"></asp:Label></td>
                                                        <TD class="texto" align="right" style="height: 22px;">
                                                            <strong>Limite Disponível:</strong></td>
                                                        <TD width="38%" style="height: 22px">
                                                            &nbsp;<anthem:Label ID="lbl_nr_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                            <anthem:Label ID="lbl_informacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Italic="True" Font-Size="9px" ForeColor="Blue" UpdateAfterCallBack="True"
                                                                Visible="False">*limite em azul: apurado de cálculo projetado</anthem:Label></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="21%" style="height: 22px">
                                                            <strong>Téc. Danone:</strong></td>
                                                        <TD width="26%" style="height: 22px" class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_nm_tecnico_danone" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                        <TD class="texto" align="right" style="height: 22px;">
                                                            <strong>Téc. EDUCAMPO:</strong></td>
                                                        <TD width="38%" style="height: 22px">
                                                            <anthem:Label ID="lbl_nm_tecnico_educampo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
													
													<TR>
														<TD colspan=2 style="height: 20px;text-align:right;"></TD>
														<TD colspan=2 style="height: 20px;text-align:left">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="titmodulo"  colSpan="4"> Pedidos</TD>
													</TR>

													<TR>
														<TD style="height: 23px" colspan=4 >&nbsp;</TD>
													</TR>
													<TR>
														<TD colspan=4  >
													                                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="98%" UpdateAfterCallBack="True" DataKeyNames="id_central_pedido" HorizontalAlign="Center" PageSize="100">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="dt_pedido" HeaderText="Data Pedido" SortExpression="dt_pedido" />
                                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido" SortExpression="id_central_pedido" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_central_cotacao" HeaderText="Cota&#231;&#227;o" SortExpression="id_central_cotacao" Visible="False" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Parceiro" DataField="ds_abreviado_fornecedor" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_pedido" HeaderText="Valor Total" DataFormatString="{0:C2}" />
                                                <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Situa&#231;&#227;o" />
                                                <asp:BoundField DataField="nr_saldo_fin_parcial" DataFormatString="{0:C2}" HeaderText="Saldo Fin.Parcial" >
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
</TD>
</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									
								</TD>
								<TD  ></TD>
								
							<!-- Adri Rls21 Frete -->
								
							</TR>
							<!-- Rls21 Frete -->
							
							
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px; height: 25px;" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif" Visible="False"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4" style="width: 466px; height: 25px;">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
