<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_pesagem_balanca.aspx.vb" Inherits="frm_romaneio_pesagem_balanca" %>


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
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" >
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 840px;"><STRONG>Atualizar Pesagem Balança</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 11px;" class="texto" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 11px; width: 840px;" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 11px" class="texto">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" style="width: 840px">
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
                                                    <strong><span style="color: #ff0000"> </span></strong></td>
                                                <td align="left" style="width: 33%; height: 20px">
                                                    &nbsp; &nbsp;</td>
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
						    <TR id="tr_pnl_pesagem_inicial" runat="server">
							    <TD style="height: 21px"  ></TD>
								<TD style="height: 21px" id="td2" runat="server" class="texto">
                                    <asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Pesagem Inicial" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <table id="Table7" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança :</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca_inicial" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cbo_balanca_inicial"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar." Font-Bold="True"
                                                        ValidationGroup="vg_salvar_inicial_balanca" ToolTip="Balança da Pesagem Inicial deve ser informada.">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca_inicial" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Ler Balança" ToolTip="Buscar peso da balança" OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Inicial?' )) {lbl_aguarde_inicial.className='aguardedestaque';return true;};else return false; " ValidationGroup="vg_salvar_inicial_balanca" />
                                                    <anthem:Label ID="lbl_aguarde_inicial" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="aguardenormal" UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Data Pesagem Inicial:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto"
                                                        Width="80px"></cc4:OnlyDateTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                                        Font-Bold="True" ToolTip="Data Pesagem Inicial obrigatória." ValidationGroup="vg_salvar_inicial">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Horário
                                                        :</span></strong></span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini_pesageminicial" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini_pesageminicial" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_hr_ini_pesageminicial"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem Inicial esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inicial">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator8" runat="server" ControlToValidate="txt_mm_ini_pesageminicial" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem Inicial é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inicial">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_hr_ini_pesageminicial" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Inicial para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar_inicial">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_mm_ini_pesageminicial" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Inicial para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar_inicial">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Pesagem Inicial:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_inicial" runat="server" AutoCallBack="True"
                                                        AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" ToolTip="Pesagem Final" ValidationGroup="vg_salvar"
                                                        Width="80px"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                                                            runat="server" ControlToValidate="txt_nr_pesagem_inicial" CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar."
                                                            Font-Bold="True" ToolTip="Pesagem Final obrigatória." ValidationGroup="vg_salvar_inicial">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                                ID="CompareValidator3" runat="server" ControlToValidate="txt_nr_pesagem_inicial"
                                                                CssClass="texto" ErrorMessage="A Pesagem Inicial deve ter valor maior que zero (0)."
                                                                Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Inicial maior que zero."
                                                                Type="Double" ValidationGroup="vg_salvar_inicial" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    </td>
                                            </tr>
                                        </table><anthem:Button ID="btn_salvar_inicial" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Salvar dados da Pesagem Inicial" ToolTip="Salvar Pesagem Inicial" ValidationGroup="vg_salvar_inicial" /></asp:Panel>
                                    
									
								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
                                    <tr id="tr_pnl_pesagem_intermediaria" runat="server">
                                    <td style="width: 1px"></td>
                                    <td class="texto">
                                    <asp:Panel ID="pnlPesagemIntermediaria" runat="server" BackColor="White" CssClass="texto"
                                        Font-Bold="False" Font-Size="X-Small" GroupingText="Dados Pesagem Intermediária"
                                        HorizontalAlign="Center" Width="100%">
                                        <table id="Table5" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança :</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca_intermediaria" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_balanca_intermediaria"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar." Font-Bold="True"
                                                        ValidationGroup="vg_salvar_inter_balanca" ToolTip="Balança da Pesagem lntermediária deve ser informada.">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca_intermediaria" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Ler Balança" ToolTip="Buscar peso da balança" OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Intermediária?' )) {lbl_aguarde_intermediaria.className='aguardedestaque';return true;};else return false; " ValidationGroup="vg_salvar_inter_balanca" />
                                                    <anthem:Label ID="lbl_aguarde_intermediaria" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="aguardenormal" UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
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
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini_intermediaria" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini_intermediaria" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_hr_ini_intermediaria"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem Intermediária esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inter">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator6" runat="server" ControlToValidate="txt_mm_ini_intermediaria" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem Intermediária é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_inter">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_hr_ini_intermediaria" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Intermediária para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_mm_ini_intermediaria" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Intermediária para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Pesagem Intermediária:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_intermediaria" runat="server" AutoCallBack="True"
                                                        AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" ToolTip="Pesagem Final" ValidationGroup="vg_salvar"
                                                        Width="80px"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                            runat="server" ControlToValidate="txt_nr_pesagem_intermediaria" CssClass="texto" ErrorMessage="Preencha a Pesagem Intermediária para continuar."
                                                            Font-Bold="True" ToolTip="Pesagem Intermediária obrigatória." ValidationGroup="vg_salvar_inter">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                                ID="CompareValidator2" runat="server" ControlToValidate="txt_nr_pesagem_intermediaria"
                                                                CssClass="texto" ErrorMessage="A Pesagem Intermediária deve ter valor maior que zero (0)."
                                                                Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Intermediária maior que zero."
                                                                Type="Double" ValidationGroup="vg_salvar_inter" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    </td>
                                            </tr>
                                        </table><anthem:Button ID="btn_salvar_intermediaria" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Salvar dados da Pesagem Intermediaria" ToolTip="Salvar Pesagem Intermediaria" ValidationGroup="vg_salvar_inter" /></asp:Panel>
                                    &nbsp;
                                    
									
								</TD>
								<TD  ></TD>
							</TR>
						    <TR>
							    <TD style="width: 1px; height: 108px;"  ></TD>
								<TD class="texto" style="height: 108px" >
                                    <asp:Panel ID="Panel5" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                        Font-Size="X-Small" GroupingText="Dados da Pesagem Final" HorizontalAlign="Center"
                                        Width="100%">
                                        <table id="Table8" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="right" class="texto" style="width: 23%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança :</strong></strong></td>
                                                <td align="left" colspan="3" style="height: 20px">
                                                    &nbsp;<anthem:DropDownList ID="cbo_balanca_final" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto">
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rqf_balanca" runat="server" ControlToValidate="cbo_balanca_final"
                                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar."
                                                        Font-Bold="True" ValidationGroup="vg_salvar_final_balanca" ToolTip="Balança da Pesagem Final deve ser informada.">[!]</asp:RequiredFieldValidator>
                                                    &nbsp; &nbsp;
                                                    <anthem:Button ID="btn_balanca_final" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Ler Balança" ToolTip="Buscar peso da balança" OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Final?' )) {lbl_aguarde_final.className='aguardedestaque';return true;};else return false; " ValidationGroup="vg_salvar_final_balanca" />
                                                    <anthem:Label ID="lbl_aguarde_final" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
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
                                                        Font-Bold="True" ToolTip="Data Pesagem Final obrigatória." ValidationGroup="vg_salvar_final">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    <strong><span style="color: #ff0000">* <strong><span style="color: #000000">Horário
                                                        :</span></strong></span></strong></td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini_pesagemfinal" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>
                                                    :
                                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini_pesagemfinal" runat="server" CssClass="texto" MaxLength="2"
                                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_ini_pesagemfinal"
                                                        CssClass="texto" ErrorMessage="O campo horas de pesagem final esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_final">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_ini_pesagemfinal" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem final é inválido." Font-Bold="True"
                                                            MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar_final">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_hr_ini_pesagemfinal" CssClass="texto"
                                                                ErrorMessage="Preencha o campo Horas em Horário da Pesagem Final para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar_final">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_mm_ini_pesagemfinal" CssClass="texto"
                                                                    ErrorMessage="Preencha os Minutos do Horário da Pesagem Final para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar_final">[!]</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                                    <strong><span style="color: #ff0000">* </span><strong>Pesagem Final:</strong></strong></td>
                                                <td align="left" style="width: 28%; height: 20px">
                                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_pesagem_final" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="80px" ToolTip="Pesagem Final" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Final para continuar." Font-Bold="True" ToolTip="Pesagem Final obrigatória." ValidationGroup="vg_salvar_final">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                            ID="CompareValidator1" runat="server" ControlToValidate="txt_nr_pesagem_final"
                                                            CssClass="texto" ErrorMessage="A Pesagem Final deve ter valor maior que zero (0)."
                                                            Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Final maior que zero."
                                                            ValidationGroup="vg_salvar_final" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></td>
                                                <td align="right" class="texto" style="width: 18%; height: 20px">
                                                    </td>
                                                <td align="left" style="width: 34%; height: 20px">
                                                    </td>
                                            </tr>
                                        </table><anthem:Button ID="btn_salvar_final" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                        Text="Salvar dados da Pesagem Final" ToolTip="Salvar Pesagem Final" ValidationGroup="vg_salvar_final" /></asp:Panel>
                                    </TD>
								<TD style="height: 108px"  ></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; &nbsp;</TD>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar_inicial"></asp:ValidationSummary>
			<asp:ValidationSummary id="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar_inicial_balanca" CssClass="texto"></asp:ValidationSummary>
                <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar_inter" />
                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar_inter_balanca" />

            <br />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar_final" />
                            <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar_final_balanca" />

            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
