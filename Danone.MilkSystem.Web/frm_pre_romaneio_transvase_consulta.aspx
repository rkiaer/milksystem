<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pre_romaneio_transvase_consulta.aspx.vb" Inherits="frm_pre_romaneio_transvase_consulta" %>


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
    <title>Pré-Romaneio Consulta</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function frame1_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" class="texto" width="100%" >
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif);"><STRONG>Consulta do Pré-Romaneio para Transvase</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px;" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                    <asp:LinkButton ID="lk_Placas_Comp" runat="server" BorderStyle="None" CausesValidation="False"
                                        ToolTip="Consultar Placas/Compartimentos">Placas/Comp.</asp:LinkButton>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 11px" class="texto">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top" >
					    <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0" class="texto">
						    <TR>
							    <TD style="width: 1px; "  ></TD>
								<TD class="texto" valign="top"  >
                                    <asp:Panel ID="Panel2" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados" HorizontalAlign="Center" Width="100%">
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="99%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Nr. Pré-Romaneio:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Situação:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Estabelecimento:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto"></asp:Label>
                                                </td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_labeltipoleite" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tipoleite" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Motorista:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motorista" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>CNH:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnh" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="height: 20px" colspan="2">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Placa Principal:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_placa" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" style="width: 19%; height: 20px">
                                                    <strong>Tara:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_tara" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                           <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Entrada:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Finalizado:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_dt_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr runat="server" id="tr_tempo_rota">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Tempo de Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tempo_rota" runat="server" CssClass="texto"></asp:Label>&nbsp;&nbsp;
                                                    <asp:Image
                                                        ID="img_tempo_rota" runat="server" ImageUrl="~/img/icon_status_cinza.gif" />&nbsp;
                                                    <asp:Label ID="lbl_tempo_rota_descr" runat="server" CssClass="texto " Height="15px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong></strong>
                                                </td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                </td>
                                            </tr>
                                            <tr id="tr_caderneta" runat="server">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_caderneta" runat="server" CssClass="texto">Nr. Caderneta:</asp:Label>
                                                    </strong>
                                                </td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto" Visible="False"></asp:Label>
                                                    <anthem:HyperLink ID="hl_nr_caderneta" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="textohlink" Font-Underline="True" Target="_blank" ToolTip="Visualizar Caderneta"
                                                        UpdateAfterCallBack="True">[hl_nr_caderneta]</anthem:HyperLink></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" EnableTheming="False"
                                                            Height="16px" Width="100%">Volume Total Caderneta:</asp:Label></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </td>
                                    <td ></td>
                                    </tr>
						    <TR id="tr_pnl_nota_fiscal_transferencia" runat="server">
							    <TD style="height: 21px"  ></TD>
								<TD style="height: 21px" id="td2" runat="server" class="texto">
                                    <asp:Panel ID="Panel8" runat="server" BackColor="White" Font-Bold="False" GroupingText="Nota Fiscal de Transferência" Width="100%" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table14" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
						                        <TD class="texto" align="right" style="width: 21%; height: 20px"  ><STRONG>Nr. Nota Fiscal:</STRONG></TD>
                                                <TD  align="left" >&nbsp;<asp:label ID="lbl_nr_nota_fiscal_transf" runat="server" CssClass="texto"  ></asp:label></TD>
							                    <TD class="texto" align="right" style="width: 19%; height: 20px"><STRONG>Série:</STRONG></TD>
							                    <TD  align="left" style="width: 31%; height: 20px">&nbsp;<asp:Label ID="lbl_serie_nota_fiscal_transf" runat="server" CssClass="texto" ></asp:label></TD>
						                    </TR>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">Peso Líquido da Nota:</STRONG></TD>
							                    <TD  align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota_transf" runat="server"
                                                        CssClass="texto" ></asp:Label></TD>
							                    <TD class="texto" align="right"  ><STRONG>Data de Emissão:</STRONG></TD>
							                    <TD align="left"  >&nbsp;<asp:Label ID="lbl_dt_emissao_nota" runat="server" CssClass="texto" ></asp:Label></TD>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
						    <TR>
							    <TD style="width: 1px; "  ></TD>
								<TD class="texto"  >
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados da Pesagem" HorizontalAlign="Center"
                                        Width="100%" Visible="true">
                                        <table id="Table8" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong><span style="color: #ff0000"></span><strong>Data Pesagem Inicial:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_inicial" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong><span style="color: #000000">Pesagem Inicial:</span></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_pesagem_inicial" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong><span style="color: #ff0000"></span><strong>Data Pesagem Intermediária:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_intermediaria" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong><span style="color: #000000">Pesagem Intermediária:</span></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_pesagem_intermediaria" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong><strong>Data Pesagem Final:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_final" runat="server" CssClass="texto"></asp:Label>
                                                </td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong><span style="color: #ff0000"> <strong><span style="color: #000000">Pesagem Final:</span></strong></span></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_nr_pesagem_final" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Peso Líquido Balança:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    <anthem:Label ID="lbl_nr_peso_liquido_balanca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </TD>
								<TD   ></TD>
							</TR>
						                            <tr>
                                <TD style="width: 1px; "  >
                                </td>
                                <TD class="texto"  align="center" valign="top" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Resumo Final" HorizontalAlign="Center" Width="100%">
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Litros Caderneta:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_caderneta" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Litros Rejeitados:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;
                                                    <anthem:Label ID="lbl_litros_rejeitados" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Litros Balança:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_balanca" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong></strong>
                                                </td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Diferença:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Diferença (%):</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca_percentual" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Litros Disponíveis Transvase:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_nr_volume_disponivel_tp" runat="server" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Litros Transf. Transvase:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_nr_volume_transferido_tp" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Litros Saldo:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_reais" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                                <td style="height: 45px">
                                </td>
                            </tr>
	
                            <tr  id="tr_pnl_transit_point" runat="server">
                                <TD style="width: 1px; "  >
                                </td>
                                <TD class="texto"  >
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Transvases Envolvidos" HorizontalAlign="Center"
                                        Width="100%">
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr >
                                                <td align="center" class="texto" >
                                                    <br />
                                                    
                                                        <anthem:GridView ID="gridTransitPoint" runat="server" AutoGenerateColumns="False"
                                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="100"
                                                            UpdateAfterCallBack="True" Width="90%" HorizontalAlign="Center">
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                ForeColor="White" />
                                                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField DataField="id_transvase" HeaderText="Transvase" ReadOnly="True">
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" ReadOnly="True">
                                                                    <headerstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="nr_total_litros_utilizados" HeaderText="Volume Transferido" ReadOnly="True">
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio Transvase" ReadOnly="True">
                                                                    <headerstyle horizontalalign="Center" />
                                                                    <itemstyle horizontalalign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        </anthem:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <TD   >
                                </td>
                            </tr>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD class="texto">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" vAlign="middle" align="left" 
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;</TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
