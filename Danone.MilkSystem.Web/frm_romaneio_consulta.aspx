<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_consulta.aspx.vb" Inherits="frm_romaneio_consulta" %>


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
    <title>Romaneio Consulta</title>
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Consulta do Romaneio</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                    <asp:LinkButton ID="lk_Placas_Comp" runat="server" BorderStyle="None" CausesValidation="False"
                                        ToolTip="Consultar Placas/Compartimentos">Placas/Comp.</asp:LinkButton>&nbsp;&nbsp;
                                    | &nbsp;
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/icone_anexar.gif" /><asp:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio"
                                        ValidationGroup="vg_salvar">Anexar Documento</asp:LinkButton>
                                    &nbsp; &nbsp;&nbsp;</TD>
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
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Nr. Romaneio:</strong></td>
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
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto"></asp:Label></td>
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
                                                    <strong>Nova Placa:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_placa_frete" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" style="width: 19%; height: 20px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                    &nbsp;</td>
                                            </tr>
                                           <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Entrada:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Saída:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_dt_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr runat="server" id="tr_tempo_rota">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Tempo de Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tempo_rota" runat="server" CssClass="texto"></asp:Label>&nbsp;<asp:Image
                                                        ID="img_tempo_rota" runat="server" ImageUrl="~/img/icon_status_cinza.gif" />
                                                    <asp:Label ID="lbl_tempo_rota_descr" runat="server" CssClass="texto " Height="15px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>
                                                        <asp:Label ID="lbl_transit_point" runat="server" CssClass="texto" Visible="False">Nr. Transit Point:</asp:Label></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_id_transit_point" runat="server" CssClass="texto" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_caderneta2" runat="server">
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
                                            <tr id="tr_caderneta" runat="server">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_caderneta" runat="server" CssClass="texto">Nr. Caderneta:</asp:Label>
                                                    </strong>
                                                </td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto" Visible="False"></asp:Label>
                                                    <anthem:HyperLink ID="hl_nr_caderneta" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="textohlink" Target="_blank" ToolTip="Visualizar Caderneta" UpdateAfterCallBack="True" Font-Underline="True">[hl_nr_caderneta]</anthem:HyperLink></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" EnableTheming="False"
                                                            Height="16px" Width="100%">Volume Total Caderneta:</asp:Label></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_transbordo" runat="server" visible="false">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="Label1" runat="server" CssClass="texto">Volume Total Pré-Romaneios:</asp:Label>
                                                    </strong>
                                                </td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_peso_liquido_caderneta" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="Label2" runat="server" CssClass="texto">Tipo de Leite:</asp:Label></strong></td>
                                                <td align="left">
                                                    &nbsp;<asp:Label ID="lbl_id_item" runat="server" CssClass="texto"></asp:Label></td>
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
                                    <tr id="tr_pnl_dados_cooperativa" runat="server">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnlCooperativa" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" GroupingText="Dados da Cooperativa / Nota Fiscal"
                                        HorizontalAlign="Center" Width="100%">
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Cooperativa:</strong></td>
                                                <td align="left" colspan="3" rowspan="1" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cooperativa" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Data Entrada/Saída Nota:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_saida_nota" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Nr. Nota Fiscal:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto"></asp:Label>
                                                    <anthem:HyperLink ID="hl_nrnota" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Underline="True" ForeColor="Blue" Visible="False">[hl_nrnota]</anthem:HyperLink></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Peso Líquido da Nota:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Valor da Nota:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_valor_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Tipo do Leite:</strong>
                                                </td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                <strong>
                                                        <anthem:Label ID="lbl_cte" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False">Nr. Nota CTE:</anthem:Label></strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_cte" runat="server" CssClass="texto" Visible="False"></asp:Label>
                                                    <asp:HyperLink ID="hl_nrnotacte" runat="server" Font-Underline="True" ForeColor="Blue" Visible="False">[hl_nrnotacte]</asp:HyperLink></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Nr Pedido (PO):</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_po_cooperativa" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 31%">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
						    <TR>
							    <TD style="width: 1px; "  ></TD>
								<TD class="texto"  >
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados da Pesagem" HorizontalAlign="Center"
                                        Width="100%">
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
                                <td style="width: 1px; height: 113px">
                                </td>
                                <td class="texto" style="height: 113px">
                                    <asp:Panel ID="Panel6" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Exportação Dados Batch Declaration" HorizontalAlign="Center"
                                        Width="100%">
                                        <br />
                                        <table id="Table9" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Registro Status Exportação:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_registro_exportacao" runat="server" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Data Registro Status Exportação:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_data_registro_exportacao" runat="server" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr id="Tr1" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Usuário Registro Exportação:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_usuario_registro_exportacao" runat="server" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong></strong>
                                                </td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Exportação Arquivo:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_st_exportacao_batch" runat="server" CssClass="texto"
                                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Data Exportação Arquivo:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_dt_exportacao" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Lacres de saida devem ser preenchidos."
                                        ForeColor="White" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator></td>
                                <td style="height: 113px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="width: 1px; "  >
                                </td>
                                <TD class="texto"  align="center" valign="top" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Resumo Final" HorizontalAlign="Center" Width="100%">
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Litros Rejeitados:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_rejeitados" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Litros Ajustados:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_ajustados" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Litros Reais:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_reais" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Litros Caderneta/NF:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_litros_caderneta_nf" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Diferença:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Diferença (%):</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_diferenca_percentual" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                            <tr id="tr_diferenca_nf_transferencia" runat="server" >
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
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                                <td style="height: 45px">
                                </td>
                            </tr>
							
                                   <tr id="tr_transitpoint" runat="server" visible="false">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnl_transitpoint" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" GroupingText="Dados dos Pré-Romaneios do Transit Point"
                                        HorizontalAlign="Center" Width="100%">
                                        <table id="Table7" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center" class="texto" >
                                                    <br />
                                                    <anthem:GridView ID="gridTransitPoint" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                        CellPadding="4" CssClass="texto" Font-Names="Verdana"
                                                        Font-Size="XX-Small" Height="24px" PageSize="100" UpdateAfterCallBack="True"
                                                        Width="90%">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <Columns>
                                                            <asp:BoundField DataField="id_transit_point" HeaderText="Transit Point" />
                                                            <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" />
                                                            <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_litros" HeaderText="Volume" />
                                                            <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233;-Romaneio" />
                                                        </Columns>
                                                    </anthem:GridView>
                                                    </td>
                                            </tr>

                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
                                   <tr id="tr_transvase" runat="server"  visible="false">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnl_transvase" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" GroupingText="Dados dos Pré-Romaneios do Transvase"
                                        HorizontalAlign="Center" Width="100%">
                                        <table id="Table10" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center" class="texto" >
                                                    <br />
                                                    <anthem:GridView ID="gridTransvase" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                        CellPadding="4" CssClass="texto" Font-Names="Verdana"
                                                        Font-Size="XX-Small" Height="24px" PageSize="100" UpdateAfterCallBack="True"
                                                        Width="90%">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <Columns>
                                                            <asp:BoundField DataField="id_transvase" HeaderText="Transvase" />
                                                            <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" />
                                                            <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_litros" HeaderText="Volume" />
                                                            <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233;-Romaneio" />
                                                        </Columns>
                                                    </anthem:GridView>
                                                    </td>
                                            </tr>

                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD class="texto">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
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
