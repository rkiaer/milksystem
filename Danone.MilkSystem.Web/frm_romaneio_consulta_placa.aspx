<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_consulta_placa.aspx.vb" Inherits="frm_romaneio_consulta_placa" %>

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
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Romaneio Consulta Placa</title>
   
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
            <table id="Table1" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                <tr>
                    <td style="width: 9px">
                        &nbsp;</td>
                    <td class="faixafiltro1" style="background-image: url(img/tab_dim.gif); ">
                        <strong>
                            <asp:Label ID="lbl_titulo" runat="server" Text="Consulta do Romaneio - Placas/Compartimentos"></asp:Label></strong></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="texto" style="width: 9px; height: 11px">
                    </td>
                    <td align="center" background="images/faixa_filro.gif" class="texto" 
                        height: 11px" valign="top">
                        <table id="Table2" border="0" cellpadding="1" cellspacing="0" height="23" width="100%">
                            <tr>
                                <td align="left" background="img/faixa_filro.gif" class="faixafiltro1a" style="width: 238px;
                                    height: 25px" valign="middle" width="238">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                </td>
                                <td align="right" background="img/faixa_filro.gif" class="faixafiltro1a" colspan="4"
                                    style="height: 25px" valign="middle">
                                    &nbsp;&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td class="texto" style="height: 11px">
                        &nbsp;</td>
                </tr>
			    <TR>
				    <TD style="width: 9px; height: 62px;"  ></TD>
					<TD class="texto" style="height: 62px"  >
                                                <asp:Panel ID="pnl_romaneio" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Romaneio"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;"><STRONG>
                                        <asp:Label ID="lbl_titulo_romaneio" runat="server" CssClass="texto">Nr. Romaneio:</asp:Label></STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>
                                        <asp:Label ID="lbl_titulo_situacao" runat="server" CssClass="texto">Situação Romaneio:</asp:Label></STRONG></TD>
				                    <TD align="left" style="height: 22px; width: 31%;" class="texto" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
                            </table>
                        </asp:Panel>
                        &nbsp;
                        &nbsp;&nbsp;</TD>
					<TD style="height: 62px"   ></TD>
				</TR>
                
                <tr>
                    <td style="width: 9px; height: 18px;">
                        &nbsp;</td>
                    <td style="height: 18px;" class="texto">
                  </td>
                    <td style="height: 18px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 9px">
                        &nbsp;</td>
                    <td  valign="top">
                        <table id="Table6" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
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
                                        <table id="Table7" border="0" cellpadding="0" cellspacing="0" class="texto" style="border-right: #1716ff 1px solid;
                                            border-top: #1716ff 1px solid; border-left: #1716ff 1px solid; border-bottom: #1716ff 1px solid"
                                            width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="height: 32px" valign="top">
                                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                        Font-Size="X-Small" GroupingText="Compartimentos" HorizontalAlign="Center" Style="color: #666666"
                                                        Width="99%">
                                                        <table id="Table9" border="0" cellpadding="2" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="center" class="texto" colspan="2" style="height: 20px">
                                                                    &nbsp;<anthem:GridView ID="gridCompartimento" runat="server" AutoGenerateColumns="False"
                                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_romaneio_compartimento"
                                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                                        Width="99%">
                                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" />
                                                                            <asp:BoundField DataField="nr_volume" HeaderText="Volume M&#225;ximo" ReadOnly="True" />
                                                                            <asp:BoundField DataField="nr_total_litros" HeaderText="Volume L&#237;quido" />
                                                                            <asp:TemplateField HeaderText="Re-An&#225;lise">
                                                                                <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                                                <itemtemplate>
<asp:Image id="img_reanalise" runat="server" ImageUrl="~/img/ico_chk_false.gif" AlternateText='<%# Bind("st_reanalise") %>' __designer:wfdid="w109" ImageAlign="Middle"></asp:Image>&nbsp; 
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
<anthem:ImageButton id="btn_anexar" runat="server" ImageUrl="~/img/icone_anexar.gif" __designer:wfdid="w110" ImageAlign="Baseline" ToolTip="Documentos Anexos" CommandArgument='<%# Bind("id_romaneio") %>' CommandName="anexar"></anthem:ImageButton> <anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icon_analises.gif" __designer:wfdid="w111" ToolTip="Consultar Análises" CommandArgument='<%# Bind("id_romaneio_compartimento") %>' CommandName="analises"></anthem:ImageButton> 
</itemtemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="reanalise" Visible="False">
                                                                                <itemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" __designer:wfdid="w18" Text='<%# Bind("st_reanalise") %>'></asp:Label>
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
                                            <tr id="pnl_dados_lacres" runat="server">
                                                <td align="right" class="texto" style="height: 21px" valign="top">
                                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                        Font-Size="X-Small" GroupingText="Lacres" HorizontalAlign="Center" Style="color: #666666"
                                                        Width="99%">
                                                        <table id="Table10" border="0" cellpadding="2" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="center" class="texto" colspan="2" style="height: 20px">
                                                                    
                                                                    <anthem:GridView ID="grdlacres" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                                        CellPadding="4" CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" Height="8px"
                                                                        PageSize="7" UpdateAfterCallBack="True" Width="80%">
                                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="nr_lacre_entrada" HeaderText="Lacre Entrada" ReadOnly="True" />
                                                                            <asp:BoundField DataField="nr_lacre_saida" HeaderText="Lacre Sa&#237;da" ReadOnly="True" />
                                                                        </Columns>
                                                                    </anthem:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <br />
                                                </td>
                                                <td style="width: 7px; height: 21px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="height: 40px" valign="top">
                                                    <asp:Panel ID="Panel6" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                        Font-Size="X-Small" GroupingText="Dados de Descarga" HorizontalAlign="Center"
                                                        Style="color: #666666" Width="99%">
                                                        <table id="Table12" border="0" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                            <tr>
                                                                <td align="right" style="width: 21%; height: 20px">
                                                                    <strong>Volume Coletado:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_nr_total_volume_coletado" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                                <td align="right" style="width: 19%; height: 20px">
                                                                    <strong>Volume Rejeitado:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 31%; height: 5px">
                                                                    &nbsp;<anthem:Label ID="lbl_nr_total_volume_rejeitado" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                            </tr>
                                                            <tr id="tr_dados_descarga" runat="server">
                                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                                    <strong>Início da Descarga:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_dt_ini_descarga" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                                    <strong>Fim da Descarga:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 31%; height: 5px">
                                                                    &nbsp;<anthem:Label ID="lbl_dt_fim_descarga" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                            </tr>
                                                            <tr  id="tr_dados_silo" runat="server">
                                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                                    <strong>Nr Silo 1:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_id_silo1" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                                    <strong>Nr Silo 2:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 31%; height: 5px">
                                                                    &nbsp;<anthem:Label ID="lbl_id_silo2" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                            </tr>
                                                            <tr  id="tr_dados_volumedescarregadoreal" runat="server">
                                                                <td align="right" style="width: 21%; height: 20px">
                                                                    <strong>Volume Descarregado Real:</strong>
                                                                </td>
                                                                <td align="left" class="texto" colspan="3" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_nr_volume_descarregado" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <br />
                                                </td>
                                                <td style="width: 7px; height: 40px">
                                                </td>
                                            </tr>
                                            <tr id="pnl_dados_cip" runat="server">
                                                <td align="right" style="height: 25px" valign="top">
                                                    <asp:Panel ID="Panel7" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                        Font-Size="X-Small" GroupingText="Dados CIP" HorizontalAlign="Center" Width="99%">
                                                        <table id="Table13" border="0" cellpadding="2" cellspacing="0" class="texto" width="100%">
                                                            <tr>
                                                                <td align="right" style="width: 21%; height: 20px">
                                                                    <strong>Início do CIP:</strong>
                                                                </td>
                                                                <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_dt_ini_cip" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                                <td align="right" style="width: 19%; height: 20px">
                                                                    <strong>Fim do CIP:</strong></td>
                                                                <td align="left" class="texto" style="width: 31%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_dt_fim_cip" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                                    <strong>PH Solução:</strong></td>
                                                                <td align="left" class="texto" style="width: 28%; height: 20px">
                                                                    &nbsp;<anthem:Label ID="lbl_nr_ph_solucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                </td>
                                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                                </td>
                                                                <td align="left" class="texto" style="width: 31%; height: 20px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <td style="width: 7px; height: 25px">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                                <td style="height: 113px">
                                </td>
                            </tr>
                            <tr class="texto">
                                <td  style="width: 1px">
                                </td>
                                <td class="texto">
                                    
                                </td>
                                <td  width="1">
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#d0d0d0" style="width: 1px">
                                </td>
                                <td class="texto">
                                    <table id="Table11" border="0" cellpadding="0" cellspacing="0" height="23" width="100%">
                                        <tr>
                                            <td align="left" background="img/faixa_filro.gif" class="faixafiltro1a" style="width: 265px"
                                                valign="middle" width="265">
                                                &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                                    ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</td>
                                            <td align="right" background="img/faixa_filro.gif" class="faixafiltro1a" colspan="4"
                                                valign="middle">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td bgcolor="#d0d0d0" width="1">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <cc7:AlertMessages ID="messageControl" runat="server" UpdateAfterCallBack="True"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
