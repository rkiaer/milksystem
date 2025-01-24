<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_caderneta.aspx.vb" Inherits="frm_caderneta" %>

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

    <title>Caderneta Contingência</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Caderneta de Recepção do Leite</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
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
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD ></TD>
								<TD>
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
								
											<TD  >
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="titmodulo"  colSpan="4" style="height: 15px"> Descrição</TD>
													</TR>
                                                    <tr>
														<TD class="texto" align="right" width="21%" style="height: 22px" ><STRONG>Nr. Caderneta:</STRONG></TD>
														<TD style="height: 22px" >&nbsp;<asp:Label ID="lbl_nr_caderneta" runat="server"  CssClass="texto"></asp:Label></TD>
														<TD class="texto" align="right" style="height: 22px" ><STRONG><asp:Label ID="lbl_leite_desviado" runat="server"  CssClass="texto" Visible="False"><STRONG>Leite não desviado</STRONG></asp:Label></STRONG></TD>
														<TD style="height: 22px" >&nbsp;<asp:Label ID="lbl_motivo_desvio" runat="server"  CssClass="texto" Width="100%" Visible="False"></asp:Label></TD>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="21%" style="height: 22px">
                                                            <strong>Rota:</strong></TD>
														<TD width="26%" style="height: 22px" class="texto">&nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto"></asp:Label></TD>
														<TD class="texto" align="right" style="height: 22px;">
                                                            <strong>Veículo:</strong></TD>
														<TD width="38%" style="height: 22px">&nbsp;<asp:Label ID="lbl_ds_placa" runat="server"  CssClass="texto"></asp:Label></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="21%" style="height: 22px">
                                                            <strong>Motorista:</strong></td>
                                                        <TD style="height: 22px" class="texto"  >
                                                            &nbsp;<asp:Label ID="lbl_transportador" runat="server" CssClass="texto"></asp:Label><STRONG></strong>&nbsp;</td>
 														<TD class="texto" align="right" style="height: 22px;">
                                                            <strong>Total Litros:</strong></TD>
														<TD width="38%" style="height: 22px">&nbsp;<asp:Label ID="lbl_total_litros" runat="server"  CssClass="texto"></asp:Label></TD>
                                                   </tr>
													
													<TR>
														<TD colspan=2 style="height: 20px;text-align:right;"></TD>
														<TD colspan=2 style="height: 20px;text-align:left">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="titmodulo"  colSpan="4"> Coletas</TD>
													</TR>

													<TR>
														<TD style="height: 23px" colspan=4 >&nbsp;</TD>
													</TR>
													<TR>
														<TD colspan=4  >
													                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_coleta">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nr_ordem" HeaderText="Seq" SortExpression="nr_ordem" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propr." SortExpression="ds_propriedade" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_unid_producao" HeaderText="U.P."
                                                    SortExpression="ds_unid_producao" />
                                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta"  HtmlEncode="False" />
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                                <asp:BoundField DataField="ds_placa_frete" HeaderText="Placa Frete" />
                                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp.">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="Litros" />
                                                <asp:BoundField DataField="temperatura" HeaderText="Temp." />
                                                <asp:BoundField DataField="nr_alizarol" HeaderText="Aliz." />
                                                <asp:BoundField DataField="nm_motivo_nao_coleta" HeaderText="Motivo N&#227;o Coleta" >
                                                    <itemstyle wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_dist_produtores" HeaderText="Dist.Prod." NullDisplayText=" " />
                                                <asp:BoundField DataField="nr_dist_ult_produtor" HeaderText="Dist.Ult.Prod." NullDisplayText=" " />
                                                <asp:TemplateField HeaderText="N&#227;o Conf.">
                                                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w4"></asp:TextBox>
</edititemtemplate>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icon_ok.gif" CommandName="nconf" CommandArgument='<%# Bind("id_coleta") %>' ToolTip="Consultar Análises" __designer:wfdid="w2"></anthem:ImageButton> 
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
</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									
								</TD>
								<TD ></TD>
								
							<!-- Adri Rls21 Frete -->
								
							</TR>
				            <TR>
					            <TD style="width: 1px">&nbsp;</TD>
					            <TD class="texto" valign="top" align="left" style="height: 40px" >
					            <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False" GroupingText="Não Conformidades da Coleta"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                                    &nbsp;
                                    &nbsp;<anthem:GridView ID="GridNConf" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="80%" UpdateAfterCallBack="True">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <Columns>
                                            <asp:BoundField DataField="nm_nao_conformidade" HeaderText="N&#227;o Conformidades" ShowHeader="False" />
                                        </Columns>
                                    </anthem:GridView>
                                    </asp:Panel>
										            </TD>
					            <TD style="height: 40px;">&nbsp;</TD>
				            </TR>
							<!-- Rls21 Frete -->
							
							
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4" style="width: 466px">&nbsp;</TD>
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
