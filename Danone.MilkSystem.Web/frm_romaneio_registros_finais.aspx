<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_registros_finais.aspx.vb" Inherits="frm_romaneio_registros_finais" %>


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
    <title>Cálculo do Produtor</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" style="width: 100%" >
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG> Romaneio - Registros Finais</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp;|&nbsp;
                                    <anthem:LinkButton ID="lk_registrar_status" runat="server" OnClientClick="if (confirm('Após Registrar o Status da Exportação, os dados não poderão ser mais alterados. Deseja realmente registrar o status de exportação?' )) return true;else return false;"
                                        ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">Registrar Status Exportação</anthem:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 11px" class="texto">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
					    <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD style="width: 1px"  ></TD>
								<TD class="texto" valign="top" >
                                    <asp:Panel ID="Panel2" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Dados" HorizontalAlign="Center" Width="100%">
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Nr. Romaneio:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto" Width="100%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Situação:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto" Width="80%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Estabelecimento:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Motorista:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motorista" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>CNH:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnh" runat="server" CssClass="texto" Width="176px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Placa Principal:</strong></td>
                                                <td align="left" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_placa" runat="server" CssClass="texto" Height="16px" Width="75%"></asp:Label></td>
                                                <td align="right" style="width: 18%; height: 20px">
                                                    <strong>Tara:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_tara" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">Entrada:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Saída:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_caderneta2" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto" Width="176px"></asp:Label>
                                                </td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_labeltipoleite" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tipoleite" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_caderneta" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_caderneta" runat="server" CssClass="texto">Nr. Caderneta:</asp:Label>
                                                    </strong>
                                                </td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" EnableTheming="False"
                                                            Height="16px" Width="100%">Volume Total Caderneta:</asp:Label></strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto" Width="61%"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_transbordo" runat="server" visible="false">
                                                <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="Label1" runat="server" CssClass="texto">Volume Total Pré-Romaneios:</asp:Label>
                                                    </strong>
                                                </td>
                                                <TD style="height: 20px" align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_liquido_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px" >
                                                    <STRONG class="texto">
                                                        <asp:Label ID="Label2" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <TD align="left" >
                                                    &nbsp;<asp:Label ID="lbl_id_item" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                             
                                        </table>
                                    </asp:Panel>
                                    </td>
                                    <td></td>
                                    </tr>
						    <TR id="tr_pnl_nota_fiscal_transferencia" runat="server">
							    <TD style="height: 21px"  ></TD>
								<TD style="height: 21px" id="td2" runat="server" class="texto">
                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Nota Fiscal de Transferência" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table7" border="0" cellpadding="1" cellspacing="0" width="100%">
						                    <TR>
						                        <TD class="texto" align="right" style="height: 22px; width: 21%;" ><STRONG>Nr. Nota Fiscal:</STRONG></TD>
                                                <TD style=" height: 22px; width: 28%;" align="left" >&nbsp;<asp:Label ID="lbl_nr_nota_fiscal_transf" runat="server" CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 22px; width: 17%;" ><STRONG>Série:</STRONG></TD>
							                    <TD style="width: 32%; height: 22px;" align="left">&nbsp;<asp:Label ID="lbl_nr_serie_nota_transf" runat="server" CssClass="texto"></asp:Label></TD>
						                    </TR>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px; width: 21%;" >
                                                    <STRONG class="texto">Peso Líquido da Nota:</STRONG></TD>
							                    <TD style="height: 20px; width: 28%;" align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_nota_transf" runat="server" CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>Data de Emissão:</STRONG></TD>
							                    <TD align="left" style="width: 32%" >&nbsp;<asp:Label ID="lbl_dt_emissao_nota_transf" runat="server" CssClass="texto"></asp:Label></TD>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
                                    <tr id="tr_pnl_dados_cooperativa" runat="server">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnlCooperativa" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" Font-Size="X-Small" GroupingText="Dados da Cooperativa / Nota Fiscal"
                                        HorizontalAlign="Center" Width="100%">
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Cooperativa:</strong></td>
                                                <td align="left" colspan="3" rowspan="1" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cooperativa" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Data Entrada/Saída Nota:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_saida_nota" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong>Nr. Nota Fiscal:</strong></td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto" Width="80%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">Peso Líquido da Nota:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong>Valor da Nota:</strong></td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;<asp:Label ID="lbl_nr_valor_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">Tipo do Leite:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 17%; height: 20px">
                                                    <strong></strong>
                                                </td>
                                                <td align="left" style="width: 32%">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
						    <TR>
							    <TD style="width: 1px; height: 108px;"  ></TD>
								<TD class="texto" style="height: 108px" >
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" 
                                        Font-Bold="False" GroupingText="Dados por Placa" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" BorderStyle="None" CssClass="texto">
                                        <br />
                                        <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                            CellPadding="4" DataKeyNames="id_romaneio_placa" Font-Names="Verdana" Font-Size="XX-Small"
                                            PageSize="8" UpdateAfterCallBack="True" Width="90%">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" SortExpression="ds_placa">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Principal">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemtemplate>
<asp:CheckBox id="chk_principal" runat="server" Font-Bold="False" Enabled="False" Checked='<%# Bind("chk_principal") %>' __designer:wfdid="w130" Font-Overline="False"></asp:CheckBox>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="dt_ini_descarga" HeaderText="In&#237;cio Descarga" SortExpression="dt_ini_descarga">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_ini_cip" HeaderText="In&#237;cio CIP" SortExpression="dt_ini_cip">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_descarregado"  HeaderText="Volume Descarregado">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemstyle horizontalalign="Center" />
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w2" CommandName="edit" CommandArgument='<%# Bind("id_romaneio_placa") %>'></anthem:ImageButton>&nbsp; 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
                                    </asp:Panel>
                                    <br />
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Dados da Pesagem" HorizontalAlign="Center"
                                        Width="100%">
                                        <table id="Table8" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000"></span><strong>Data Pesagem Inicial:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_inicial" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #000000">Pesagem Inicial:</span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_pesagem_inicial" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000"></span><strong>Data Pesagem Intermediária:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_intermediaria" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #000000">Pesagem Intermediária:</span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_pesagem_intermediaria" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong><strong>Data Pesagem Final:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_pesagem_final" runat="server" CssClass="texto"></asp:Label>
                                                </td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong><span style="color: #ff0000"><strong><span style="color: #000000">Pesagem Final:</span></strong></span></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_nr_pesagem_final" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Peso Líquido Balança:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    <anthem:Label ID="lbl_nr_peso_liquido_balanca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </TD>
								<TD style="height: 108px"  ></TD>
							</TR>
                            <tr>
                                <TD style="width: 1px; height: 113px;"  >
                                </td>
                                <TD class="texto" style="height: 113px" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Resumo Final" HorizontalAlign="Center" Width="100%">
                                        <br />
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Litros Rejeitados:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_rejeitados" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Litros Ajustados:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_ajustados" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Litros Reais:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_reais" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Litros Caderneta/NF:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_caderneta_nf" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Diferença:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Diferença (%):</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca_percentual" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr id="tr_nf_transfer_2" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Diferença LitrosReais X NF Transferência:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca_nftransf" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Diferença LitrosReais X NF Transferência (%):</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca_percentual_nftransf" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:CustomValidator ID="cv_validar_lacres" runat="server" ErrorMessage="Lacres de saida devem ser preenchidos."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator>
                                    <asp:CustomValidator ID="cv_placas" runat="server" ErrorMessage="Informações das Placas devem ser preenchidas."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator>
                                    <asp:CustomValidator ID="cv_compartimentos_semresultado" runat="server" ErrorMessage="Análises obrigatórias de compartimento devem ser preenchidas."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator>
                                    <asp:CustomValidator ID="cv_uproducao_semresultado" runat="server" ErrorMessage="Análises obrigatórias de compartimento devem ser preenchidas."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator><asp:CustomValidator
                                            ID="cv_compartimentos_semregistroanalise" runat="server" ErrorMessage="Análises obrigatórias de compartimento devem ser preenchidas."
                                            ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator><asp:CustomValidator
                                                ID="cv_uproducao_semregistroanalise" runat="server" ErrorMessage="Análises obrigatórias de compartimento devem ser preenchidas."
                                                ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator></td>
                                <td style="height: 113px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="width: 1px; height: 113px;"  >
                                </td>
                                <TD class="texto" style="height: 113px" >
                                    <asp:Panel ID="Panel6" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Exportação Dados Batch Declaration" HorizontalAlign="Center" Width="100%">
                                        <br />
                                        <table id="Table9" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Exportação Arquivo:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_st_exportacao_batch" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Data Exportação Arquivo:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_dt_exportacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Registro Status Exportação:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_registro_exportacao" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                    </anthem:DropDownList>
                                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='O campo "Registro Status Exportação" deve ser informado.'
                                                        InitialValue="1" ToolTip='Informe "Liberada" ou "Não Exportar" para que o registro participe ou não do arquivo de exportação do batch.'
                                                        ValidationGroup="vg_salvar" ControlToValidate="cbo_registro_exportacao" CssClass="texto">[!]</anthem:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Data Registro Status Exportação:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_data_registro_exportacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr id="Tr1" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Usuário Registro Exportação:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_usuario_registro_exportacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong></strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Lacres de saida devem ser preenchidos."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator></td>
                                <td style="height: 113px">
                                </td>
                            </tr>
							<TR>
								<TD style="width: 1px"></TD>
								<TD>&nbsp;
								</TD>
								<TD width="1" ></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" 
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp;|&nbsp;
                                                <anthem:LinkButton ID="lk_registrar_status_footer" runat="server" OnClientClick="if (confirm('Após Registrar o Status da Exportação, os dados não poderão ser mais alterados. Deseja realmente registrar o status de exportação?' )) return true;else return false;"
                                                    ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">Registrar Status Exportação</anthem:LinkButton>
                                                </TD>
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
