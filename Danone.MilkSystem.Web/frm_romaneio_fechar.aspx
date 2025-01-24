<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_fechar.aspx.vb" Inherits="frm_romaneio_fechar" %>


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
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" class="texto" width="100%"  >
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif);"><STRONG>Fechar Romaneio</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                        ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
                                    &nbsp;|
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ico_fechar_romaneio3.gif" /><asp:LinkButton
                                        ID="lk_fechar_romaneio" runat="server" OnClientClick="if (confirm('Após fechar o romaneio, os dados não poderão ser mais alterados. Deseja realmente fechar o romaneio?' )) return true;else return false;"
                                        ValidationGroup="vg_salvar">Fechar Romaneio</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                    <asp:LinkButton ID="lk_Placas_Comp" runat="server" BorderStyle="None" CausesValidation="False"
                                        ToolTip="Consultar Placas/Compartimentos">Placas/Comp.</asp:LinkButton><asp:LinkButton ID="lk_Uproducao" runat="server" BorderStyle="None" CausesValidation="False"
                                        ToolTip="Consultar Unidades de Produção" Visible="False">Unid. Produção</asp:LinkButton>&nbsp;&nbsp;</TD>
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
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto" Width="100%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Situação:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto" Width="80%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Estabelecimento:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Motorista:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motorista" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>CNH:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnh" runat="server" CssClass="texto" Width="176px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong>Placa Principal:</strong></td>
                                                <td align="left" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_placa" runat="server" CssClass="texto" Height="16px" Width="75%"></asp:Label></td>
                                                <td align="right" style="width: 19%; height: 20px">
                                                    <strong>Tara:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px" valign="middle">
                                                    &nbsp;<asp:Label ID="lbl_tara" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Entrada:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto" Width="176px"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong>Saída:</strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    <asp:Label ID="lbl_dt_saida" runat="server" CssClass="texto"></asp:Label></td>
                                            </tr>
                                            <tr id="tr_caderneta2" runat="server">
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong class="texto">Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto" Width="176px"></asp:Label>
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
                                                    &nbsp;<asp:Label ID="lbl_caderneta" runat="server"  CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong class="texto">
                                                        <asp:Label ID="lbl_label_peso_caderneta" runat="server" CssClass="texto" EnableTheming="False"
                                                            Height="16px" Width="100%">Volume Total Caderneta:</asp:Label></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_peso_liquido_caderneta" runat="server" CssClass="texto" Width="61%"></asp:Label></td>
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
                                                <TD class="texto" align="right" >
                                                    <STRONG class="texto">Peso Líquido da Nota:</STRONG></TD>
							                    <TD  align="left" >&nbsp;<asp:Label ID="lbl_nr_peso_liquido_nota_transf" runat="server"
                                                        CssClass="texto" ></asp:Label></TD>
							                    <TD class="texto" align="right"  ><STRONG>Data de Emissão:</STRONG></TD>
							                    <TD align="left"  >&nbsp;<asp:Label ID="lbl_dt_emissao_nota" runat="server" CssClass="texto" ></asp:Label></TD>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    
									
								</TD>
								<TD   ></TD>
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
                                                    &nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto" Width="80%"></asp:Label></td>
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
                                                    <strong class="texto">Tipo do Leite:</strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                                    <strong></strong>
                                                </td>
                                                <td align="left" style="width: 31%">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;&nbsp;
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
                            <tr>
                                <TD style="width: 1px; "  >
                                </td>
                                <TD class="texto"  >
                                    <asp:Panel ID="Panel9" runat="server" BackColor="White" CssClass="texto" Font-Bold="False" GroupingText="Dados da Pesagem" HorizontalAlign="Center"
                                        Width="100%">
                                        <table id="Table15" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 21%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Dt/Hora Pesagem Inicial:</strong></strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto"
                                                        MaxLength="10" ValidationGroup="vg_salvar" Width="72px"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                                            CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                                            Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                    <cc3:OnlyNumbersTextBox
                                                                ID="txt_hr_ini" runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox><asp:RangeValidator ID="RangeValidator1" runat="server"
                                                            ControlToValidate="txt_hr_ini" CssClass="texto" ErrorMessage="O campo horas de pesagem inicial esta inválido."
                                                            Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                                ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_ini" CssClass="texto"
                                                                ErrorMessage="O campo minutos do horário de pesagem inicial é inválido." Font-Bold="True"
                                                                MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_ini" CssClass="texto"
                                                                    ErrorMessage="Preencha o campo Horas em Horário da Pesagem Inicial para continuar."
                                                                    Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_ini" CssClass="texto"
                                                                        ErrorMessage="Preencha os Minutos do Horário da Pesagem Inicial para continuar."
                                                                        Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 16%; height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Pesagem
                                                        Inicial:</span></strong><strong><span style="color: #000000"></span></strong></span></strong></td>
                                                <td align="left" style="width: 31%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_pesagem_inicial" runat="server" CssClass="texto"
                                                        MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" ToolTip="Pesagem Inicial"
                                                        ValidationGroup="vg_salvar" Width="88px"></cc6:OnlyDecimalTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="True"
                                                        ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="A Pesagem Inicial deve ter valor maior que zero (0)."
                                                        Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Inicial maior que zero."
                                                        Type="Double" ValidationGroup="vg_salvar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Dt/Hora Pesagem Final:</strong></strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_final" runat="server" CssClass="texto"
                                                        Width="72px"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_pesagem_final"
                                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Final para continuar."
                                                        Font-Bold="True" ToolTip="Data Pesagem Final obrigatória." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                    <cc3:OnlyNumbersTextBox ID="txt_hr_fim" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_fim" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox><asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_hr_fim"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem final esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator4" runat="server" ControlToValidate="txt_mm_fim" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem final é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_hr_fim" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Final para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_hr_fim" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Final para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Pesagem
                                                        Final:</span></strong><strong><span style="color: #000000"></span></strong></span></strong></td>
                                                <td align="left" style=" height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_final" runat="server" AutoCallBack="True"
                                                        AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="10" MaxLength="15"
                                                        MaxMantissa="4" ToolTip="Pesagem Final" ValidationGroup="vg_salvar" Width="88px"></cc6:OnlyDecimalTextBox>
                                                    <asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                            CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="True"
                                                            ToolTip="Pesagem Final obrigatória." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                                ID="CompareValidator2" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                                CssClass="texto" ErrorMessage="A Pesagem Final deve ter valor maior que zero (0)."
                                                                Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Final maior que zero."
                                                                Type="Double" ValidationGroup="vg_salvar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="height: 20px">
                                                    <strong>Peso Líquido Balança:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    <anthem:Label ID="lbl_nr_peso_liquido_balanca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                <td align="right" class="texto" style="height: 20px">
                                                    </td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <TD  >
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
                                <td >
                                </td>
                            </tr>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD class="texto">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" 
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;
                                                |
                                                <asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>&nbsp;
                                                |
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/img/ico_fechar_romaneio3.gif" /><asp:LinkButton
                                                    ID="lk_fechar_romaneio_footer" runat="server" OnClientClick="if (confirm('Após fechar o romaneio, os dados não poderão ser mais alterados. Deseja realmente fechar o romaneio?' )) return true;else return false;"
                                                    ValidationGroup="vg_salvar">Fechar Romaneio</asp:LinkButton>
                                                &nbsp;</TD>
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
