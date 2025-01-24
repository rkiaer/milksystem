<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_pesagem_final.aspx.vb" Inherits="frm_romaneio_pesagem_final" %>


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
    <title>Pesagem Final</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" width="100%" >
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Pesagem Intermediária e Final</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                        ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
                                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto" ></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Transportador:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server"  CssClass="texto" ></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong>Motorista:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_motorista" runat="server" CssClass="texto" Width="100%"></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>CNH:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_cd_cnh" runat="server" CssClass="texto" ></asp:Label></td>
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
                                                    &nbsp;<asp:Label ID="lbl_dt_entrada" runat="server"  CssClass="texto" ></asp:Label></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span>Saída:</strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_hora_saida" runat="server" CssClass="texto"
                                                        Width="64px"></cc4:OnlyDateTextBox>
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_saida" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>:<cc3:OnlyNumbersTextBox ID="txt_mm_saida"
                                                            runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_hora_saida"
                                                        CssClass="texto" ErrorMessage="Preencha Data da Saída." Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="Data de Saída obrigatória.">[!]</asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_hr_saida"
                                                        CssClass="texto" ErrorMessage="O campo horas da saída do romaneio esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator4" runat="server" ControlToValidate="txt_mm_saida" CssClass="texto"
                                                            ErrorMessage="O campo minutos da Saída do romaneio é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_hr_saida" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Saída do Romaneio para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_mm_saida" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos da Saída do Romaneio para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr id="tr_caderneta2" runat="server">
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong class="texto">Rota:</strong></td>
                                                <td align="left" style="height: 20px">
                                                    &nbsp;<asp:Label ID="lbl_linha" runat="server"  CssClass="texto" ></asp:Label>
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
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Dados da Pesagem Intermediária" HorizontalAlign="Center"
                                        Width="100%">
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança:</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca_intermediaria" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                        <asp:ListItem Value="02">Portaria 02 - Sa&#237;da</asp:ListItem>
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_balanca_intermediaria"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar."
                                                        Font-Bold="True" ValidationGroup="vg_balanca_inter">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca_intermediaria" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Ler Balança" ToolTip="Buscar peso da balança" OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Intermediária?' )) {lbl_aguarde_inter.className='aguardedestaque';return true;};else return false; " ValidationGroup="vg_balanca_inter" />
                                                    <anthem:Label ID="lbl_aguarde_inter" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                                        UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Data Pesagem Intermediária:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_intermediaria" runat="server" CssClass="texto"
                                                        Width="80px"></cc4:OnlyDateTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_dt_pesagem_intermediaria"
                                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Intermediária para continuar."
                                                        Font-Bold="True" ToolTip="Data Pesagem Intermediária obrigatória." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Horário
                                                        :</span></strong></span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_inter" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_inter" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_hr_inter"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem Intermediária esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inter">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator6" runat="server" ControlToValidate="txt_mm_inter" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem Intermediária é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inter">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_hr_inter" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Intermediária para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_mm_inter" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Intermediária para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Pesagem Intermediária:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_intermediaria" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="80px" ToolTip="Pesagem Final" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_nr_pesagem_intermediaria"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Intermediária para continuar." Font-Bold="True" ToolTip="Pesagem Intermediária obrigatória." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                            ID="CompareValidator2" runat="server" ControlToValidate="txt_nr_pesagem_intermediaria"
                                                            CssClass="texto" ErrorMessage="A Pesagem Intermediária deve ter valor maior que zero (0)."
                                                            Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Intermediária maior que zero."
                                                            ValidationGroup="vg_salvar_inter" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                                <td align="center" class="texto" style="width: 20%; height: 20px" colspan="4"><anthem:Button ID="btn_salvar_pesagem_intermediaria" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Salvar Dados Pesagem Intermediária" ToolTip="Buscar peso da balança" ValidationGroup="vg_salvar_inter" /></td>
                                            <tr>
                                            
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </TD>
								<TD style="height: 108px"  ></TD>
							</TR>
							
						    <TR>
							    <TD style="width: 1px; height: 108px;"  ></TD>
								<TD class="texto" style="height: 108px" >
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
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança:</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca_final" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                        <asp:ListItem Value="02">Portaria 02 - Sa&#237;da</asp:ListItem>
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqf_balanca" runat="server" ControlToValidate="cbo_balanca_final"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar."
                                                        Font-Bold="True" ValidationGroup="vg_balanca">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca_final" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Ler Balança" ToolTip="Buscar peso da balança" OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Final?' )) {lbl_aguarde.className='aguardedestaque';return true;};else return false; " ValidationGroup="vg_balanca" />
                                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                                        UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Data Pesagem Final:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_final" runat="server" CssClass="texto"
                                                        Width="80px"></cc4:OnlyDateTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_pesagem_final"
                                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Final para continuar."
                                                        Font-Bold="True" ToolTip="Data Pesagem Final obrigatória." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Horário
                                                        :</span></strong></span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_final" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_final" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_final"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem final esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_final" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem final é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_hr_final" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Final para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_mm_final" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Final para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Pesagem Final:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_final" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="80px" ToolTip="Pesagem Final" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="True" ToolTip="Pesagem Final obrigatória." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                            ID="CompareValidator1" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                            CssClass="texto" ErrorMessage="A Pesagem Final deve ter valor maior que zero (0)."
                                                            Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Final maior que zero."
                                                            ValidationGroup="vg_salvar" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong>Peso Líquido Balança:</strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<anthem:Label ID="lbl_nr_peso_liquido_balanca" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </TD>
								<TD style="height: 108px"  ></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
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
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar" />
            <anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_balanca_inter" />
            <anthem:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar_inter" />
            <anthem:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vg_balanca" />
        </form>
	</body>
</HTML>
