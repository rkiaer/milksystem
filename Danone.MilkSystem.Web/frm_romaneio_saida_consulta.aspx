<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_consulta.aspx.vb" Inherits="frm_romaneio_saida_consulta" %>


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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG> Romaneio de Saída - Consulta</STRONG></TD>
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
                                    &nbsp;&nbsp;
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/icone_anexar.gif" Visible="False" /><asp:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio"
                                        ValidationGroup="vg_salvar" Visible="False">Anexar Documento</asp:LinkButton>
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
                                    <asp:Panel ID="Panel2" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados" HorizontalAlign="Left" Width="100%">
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Nr. Romaneio Saída:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Situação:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Estabelecimento:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Tipo de Leite:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tipoleite" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Tipo Operação:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_tipo_operacao" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Motivo Saída:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motivo_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Entrada:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Saída:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Destino:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_destino" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Destino CNPJ:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_destino_cnpj" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>Transportador CNPJ:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador_cnpj" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Motorista:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motorista" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 254px; height: 20px">
                                                    <strong>CNH:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnh" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Placa Principal:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_placa" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" style="width: 254px; height: 20px">
                                                    <strong>Tara:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_tara" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Romaneio Entrada Origem:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_romaneio_entrada" runat="server" CssClass="texto"></asp:Label>
                                                    </td>
                                                <td align="right" style="width: 254px; height: 20px">
                                                </td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </td>
                                    <td ></td>
                                    </tr>
	                                    <tr id="tr1" runat="server">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" GroupingText="Dados da Solicitação da Nota Fiscal"
                                        HorizontalAlign="Left" Width="100%">
                                        <table id="Table10" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Data Solicitação:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_solicitacao_nf" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Situação Processo NF:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nm_situacao_romaneio_saida_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Quantidade:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_quantidade" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Peso Líquido:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Preço Unitário:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_preco_unitario" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Valor Total da Nota:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_valor_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Valor Frete Combinado:</strong>
                                                </td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_valor_combinado_frete" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Resp. Solicitação:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_resp_solicitacao_nf" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
	                                    <tr id="tr_pnl_dados_cooperativa" runat="server">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnlnota" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" GroupingText="Dados da Nota Fiscal"
                                        HorizontalAlign="Left" Width="100%">
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Nr. Nota Fiscal:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto"></asp:Label>
                                                    <anthem:HyperLink ID="hl_nrnota" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Underline="True" ForeColor="Blue" Visible="False">[hl_nrnota]</anthem:HyperLink></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Data Emissão Nota:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_dt_saida_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Peso Líquido da Nota:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_peso_nf" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Valor Total da Nota:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_valor_total_nota" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Resp. Liberação NF:</strong>
                                                </td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_usuario_anexo_nf" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Data Liberação NF:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_dt_liberacao_nf" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Frete por Conta da:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_ds_frete" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Nr. Nota CTE:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_nr_cte" runat="server" CssClass="texto" Visible="False"></asp:Label>
                                                    <asp:HyperLink ID="hl_nrnotacte" runat="server" Font-Underline="True" ForeColor="Blue" Visible="False">[hl_nrnotacte]</asp:HyperLink></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Valor CTE:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_valor_cte" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Data Emissão CTE:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_dt_emissao_cte" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Resp. Liberação CTE:</strong>
                                                </td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_liberacao_cte" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Data Liberação CTE:</strong></td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;<asp:Label ID="lbl_dt_liberacao_cte" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
						    <TR>
							    <TD style="width: 1px; "  ></TD>
								<TD class="texto"  >
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados da Pesagem" HorizontalAlign="Left"
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
                    <td >
                        &nbsp;</td>
                    <td  valign="top">
                        <table id="Table4" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                            <tr style="height: 16px">
                                <td class="texto" style="height: 11px">
                                </td>
                                <td class="texto" style="font-size: 1px; height: 5px">
                                    <table border="0" cellpadding="0" cellspacing="0" class="texto" style="margin-bottom: 0px;
                                        padding-bottom: 0px; vertical-align: text-bottom; height: 8px; text-align: left">
                                        <tr>
                                            <td id="td_placa1" runat="server" align="left" class="texto" style="font-size: 1px;
                                                vertical-align: text-bottom; height: 6px">
                                                <anthem:Panel ID="pnl_placa1" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_ativa.gif"
                                                    CssClass="texto" ForeColor="#0000F5" Height="23px" HorizontalAlign="Center" Width="135px">
                                                    <anthem:LinkButton ID="btn_placa1" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" ForeColor="#0000F5"></anthem:LinkButton></anthem:Panel>
                                                &nbsp; &nbsp; &nbsp;</td>
                                            <td id="td_placa2" runat="server" align="left" style="font-size: 1px; vertical-align: text-bottom;
                                                height: 6px">
                                                <anthem:Panel ID="pnl_placa2" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                                    CssClass="texto" Height="23px" HorizontalAlign="Center" Visible="False" Width="136px">
                                                    <anthem:LinkButton ID="btn_placa2" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" ForeColor="#6767CC"></anthem:LinkButton></anthem:Panel>
                                                &nbsp; &nbsp;
                                            </td>
                                            <td id="td_placa3" runat="server" align="center" style="font-size: 1px; vertical-align: text-bottom;
                                                height: 6px">
                                                &nbsp; &nbsp; &nbsp;
                                                <anthem:Panel ID="pnl_placa3" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                                    CssClass="texto" Height="23px" Visible="False" Width="136px">
                                                    <anthem:LinkButton ID="btn_placa3" runat="server" AutoUpdateAfterCallBack="True"
                                                        ForeColor="#6767CC"></anthem:LinkButton></anthem:Panel>
                                            </td>
                                            <td id="td_placa4" runat="server" align="center" style="font-size: 1px; vertical-align: text-bottom;
                                                height: 6px">
                                                <anthem:Panel ID="pnl_placa4" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                                    CssClass="texto" Height="23px" Visible="False" Width="136px">
                                                    <anthem:LinkButton ID="btn_placa4" runat="server" AutoUpdateAfterCallBack="True"
                                                        ForeColor="#6767CC"></anthem:LinkButton></anthem:Panel>
                                                &nbsp; &nbsp; &nbsp;&nbsp;
                                            </td>
                                            <td id="td_placa5" runat="server" align="center" style="font-size: 1px; vertical-align: text-bottom;
                                                height: 6px">
                                                <anthem:Panel ID="pnl_placa5" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa.gif"
                                                    CssClass="texto" Height="23px" Visible="False" Width="136px">
                                                    <anthem:LinkButton ID="btn_placa5" runat="server" AutoUpdateAfterCallBack="True"
                                                        ForeColor="#6767CC"></anthem:LinkButton></anthem:Panel>
                                            </td>
                                            <td align="center" style="width: 135px; height: 6px">
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                        <table id="Table7" border="0" cellpadding="0" cellspacing="0" class="texto" style="border-right: #f0f0f0 1px solid;
                                            border-top: #f0f0f0 1px solid; border-left: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid"
                                            width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="height: 32px" valign="top">
                                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                        Font-Size="X-Small" GroupingText="Compartimentos" HorizontalAlign="Left" Style="color: #666666"
                                                        Width="99%">
                                                        <table id="Table9" border="0" cellpadding="2" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="center" class="texto" colspan="2" style="height: 20px">
                                                                    &nbsp;<anthem:GridView ID="gridCompartimento" runat="server" AutoGenerateColumns="False"
                                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_romaneio_saida_compartimento"
                                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                                        Width="99%">
                                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" />
                                                                            <asp:BoundField DataField="nr_volume" HeaderText="Volume M&#225;ximo" ReadOnly="True" />
                                                                            <asp:BoundField DataField="nr_total_litros" HeaderText="Volume L&#237;quido" />
                                                                            <asp:TemplateField HeaderText="Re-An&#225;lise" Visible="False">
                                                                                <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                                                <itemtemplate>
<asp:Image id="img_reanalise" runat="server" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w560" ImageAlign="Middle" AlternateText='<%# Bind("st_reanalise") %>'></asp:Image>&nbsp; 
</itemtemplate>
                                                                                <headerstyle horizontalalign="Center" />
                                                                                <itemstyle horizontalalign="Center" verticalalign="Middle" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="nm_st_analise" HeaderText="Status An&#225;lises">
                                                                                <headerstyle horizontalalign="Center" />
                                                                                <itemstyle horizontalalign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField>
                                                                                <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" ImageUrl="~/img/icone_anexar.gif" ToolTip="Documentos Anexos" __designer:wfdid="w561" ImageAlign="Baseline" CommandName="anexar" CommandArgument='<%# Bind("id_romaneio_saida") %>'></anthem:ImageButton> <anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icon_analises.gif" ToolTip="Consultar Análises" __designer:wfdid="w562" CommandName="analises" CommandArgument='<%# Bind("id_romaneio_saida_compartimento") %>'></anthem:ImageButton> 
</itemtemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="reanalise" Visible="False">
                                                                                <itemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" Text='<%# Bind("st_reanalise") %>'></asp:Label>
</itemtemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle HorizontalAlign="Left" />
                                                                    </anthem:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    
                                                </td>
                                                <td style="width: 7px; height: 32px">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td >
                                </td>
                            </tr>
 
                        </table>
                    </td>
                    <td >
                        &nbsp;</td>
                </tr>                           
                 <tr>
                                <TD style="width: 1px; "  >
                                </td>
                                <TD class="texto"  align="center" valign="top" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Documentos Anexados ao Romaneio Saída" HorizontalAlign="Left" Width="100%" Height="70px">
                                        <br />
<anthem:GridView id="gridAnexos" runat="server" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="98%" CssClass="texto" ForeColor="#333333" Font-Size="XX-Small" Font-Names="Verdana" DataKeyNames="id_anexo" CellPadding="4" AutoGenerateColumns="False">
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                        ForeColor="White" HorizontalAlign="Left"  />
                                                    <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                        HorizontalAlign="Center"  />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Origem" DataField="ds_origem" />
                                                        <asp:TemplateField HeaderText="Nome do Documento">
                                                            <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_nm_documento" runat="server" CssClass="texto" __designer:wfdid="w575" Text='<%# Bind("nm_documento") %>'></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ds_tipo_anexo" HeaderText="Tipo" >
                                                            <headerstyle horizontalalign="Center" ></headerstyle>
                                                            <itemstyle horizontalalign="Center" ></itemstyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="dt_criacao" HeaderText="Inclus&#227;o" DataFormatString="{0:dd/MM/yyyy hh:mm}" >
                                                            <headerstyle horizontalalign="Center" ></headerstyle>
                                                            <itemstyle horizontalalign="Center" ></itemstyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nm_usuario" HeaderText="Usu&#225;rio" ></asp:BoundField>
                                                        <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr.Nota" ReadOnly="True">
                                                            <headerstyle horizontalalign="Center" ></headerstyle>
                                                            <itemstyle horizontalalign="Center" ></itemstyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ds_descricao" HeaderText="Descri&#231;&#227;o" Visible="False" ></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Download">
                                                            <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" Font-Underline="True" ForeColor="Blue" __designer:wfdid="w574">Clique aqui para fazer o download</asp:HyperLink> 
</itemtemplate>
                                                            <headerstyle horizontalalign="Center" ></headerstyle>
                                                            <itemstyle horizontalalign="Center" ></itemstyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                                            <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" __designer:wfdid="w571" CommandName="Update" Text="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" __designer:wfdid="w572" CommandName="Cancel" Text="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w573"></asp:ValidationSummary> 
</edititemtemplate>
                                                            <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Visible="False" __designer:wfdid="w569" CommandName="Edit" Text="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Anexo Pedido" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w570" ImageAlign="Baseline" CommandName="delete" CommandArgument='<%# Bind("id_anexo") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                            <itemstyle horizontalalign="Center" ></itemstyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_romaneio_saida" Visible="False">
                                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                            <itemtemplate>
<asp:Label id="lbl_id_romaneio_saida" runat="server" __designer:wfdid="w553" Text='<%# Bind("id_romaneio_saida") %>'></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_tipo_anexo" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_tipo_anexo" runat="server" __designer:wfdid="w552" Text='<%# Bind("id_tipo_anexo") %>'></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id_origem" Visible="False">
                                                            <itemtemplate>
<asp:Label id="lbl_id_origem" runat="server" __designer:wfdid="w551" Text='<%# Bind("id_origem") %>'></asp:Label> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle BackColor="White" HorizontalAlign="Left"  />
                                                </anthem:GridView>
                                    </asp:Panel>
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                                <td style="height: 45px">
                                </td>
                            </tr>
                            <tr>
                                <TD style="width: 1px; height: 20px;"  >
                                </td>
                                <TD class="texto"  align="center" valign="top" style="height: 20px" >
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="width: 1px"></TD>
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
								<TD width="1" ></TD>
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
