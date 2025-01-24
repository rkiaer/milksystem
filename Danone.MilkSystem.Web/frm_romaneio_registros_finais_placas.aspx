<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_registros_finais_placas.aspx.vb" Inherits="frm_romaneio_registros_finais_placas" %>

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
    <title>Romaneio Fechar Placa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Registros Finais</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 797px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 797px" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados da Placa</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 3px; width: 24%;" class="texto" align=right></TD>
								<TD style="HEIGHT: 3px"></TD>
							</TR>
                            <tr>
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <STRONG>Romaneio:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <STRONG>Placa:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lbl_placa" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <asp:CustomValidator ID="cv_lacres" runat="server" CssClass="texto" ErrorMessage="Todos os Lacres de Saída devem ser preenchidos!"
                                        Font-Bold="True" ValidationGroup="vg_salvar" Visible="False">[!]</asp:CustomValidator>
                                    <anthem:GridView ID="grdlacres" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CellPadding="4" CssClass="texto" DataKeyNames="id_romaneio_lacre" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True" Width="80%">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="nr_lacre_entrada" HeaderText="Lacre Entrada" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Lacre Sa&#237;da">
                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><cc3:OnlyNumbersTextBox id="txt_nr_lacre_saida" runat="server" CssClass="texto" MaxLength="20" Text='<%# Bind("nr_lacre_saida") %>' __designer:wfdid="w65"></cc3:OnlyNumbersTextBox>&nbsp; <asp:RequiredFieldValidator id="rfv_lacre" runat="server" ValidationGroup="vg_lacre" CssClass="texto" Font-Bold="True" ErrorMessage="Número do Lacre de Saída deve ser informado." ControlToValidate="txt_nr_lacre_saida" __designer:wfdid="w66">[!]</asp:RequiredFieldValidator> <asp:CustomValidator id="CustomValidator1" runat="server" ErrorMessage="CustomValidator" __designer:wfdid="w67" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_lacre_saida" runat="server" CssClass="texto" Text='<%# Bind("nr_lacre_saida") %>' __designer:wfdid="w64"></asp:Label>&nbsp; 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_lacre" ToolTip="Gravar Lacre" Text="Update" __designer:wfdid="w29" CommandName="Update" CommandArgument='<%# bind("id_romaneio_lacre") %>'></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" __designer:wfdid="w30" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_lacre" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w31"></asp:ValidationSummary> 
</edititemtemplate>
                                                <headerstyle width="10%" />
                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Lacre" Text="Edit" __designer:wfdid="w28" CommandName="Edit"></asp:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </anthem:GridView>
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">
                                    Dados da Descarga</td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 3px; width: 24%;" class="texto" align=right>
                                </td>
                                <TD style="HEIGHT: 3px">
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <SPAN id="Span1" class="obrigatorio">* <span style="color: #000000">Leite Descarregado</span></span><STRONG>:</strong>
                                </td>
                                <TD class="texto" style="height: 22px">
                                    &nbsp;<anthem:DropDownList ID="cbo_leite_descarregado" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Selected="True" Value="S">Sim</asp:ListItem>
                                        <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                    </anthem:DropDownList>
                                    &nbsp; &nbsp; &nbsp; &nbsp;<anthem:Label ID="lbl_motivo" runat="server" CssClass="texto"
                                        Font-Bold="True" Visible="False">Motivo:</anthem:Label>&nbsp;
                                    <anthem:DropDownList ID="cbo_motido_leite_nao_descarregado" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" Visible="False">
                                        <asp:ListItem Value="E">Empr&#233;stimo</asp:ListItem>
                                        <asp:ListItem Value="V">Venda</asp:ListItem>
                                        <asp:ListItem Selected="True">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_leite_descarregado"
                                        CssClass="texto" ErrorMessage="Preencha o Motivo do leite descarregado." Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px; width: 24%;" class="texto" align=right>
                                    <STRONG>Volume Coletado:</strong>
                                </td>
                                <TD class="texto" style="height: 20px">
                                    &nbsp;<asp:Label ID="lbl_nr_total_volume_coletado" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px; width: 24%;" class="texto" align=right>
                                    <STRONG>Volume Rejeitado:</strong>
                                </td>
                                <TD class="texto" style="height: 20px">
                                    &nbsp;<asp:Label ID="lbl_nr_total_volume_rejeitado" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr runat="server" id="tr_destino_leite_rejeitado">
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <SPAN id="Span3" class="obrigatorio"><span style="color: #000000"><span style="color: #ff0000">
                                        * </span>Destino Leite Rejeitado</span></span><STRONG>:</strong>
                                </td>
                                <TD class="texto" style="height: 22px">
                                    &nbsp;<anthem:DropDownList ID="cbo_destino_leite_rejeitado" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Value="D">Descarte</asp:ListItem>
                                        <asp:ListItem Value="V">Venda</asp:ListItem>
                                        <asp:ListItem VALUE= "" Selected="True">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList>
                                    <anthem:CustomValidator ID="cv_destino_leite_rejeitado" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_destino_leite_rejeitado" ToolTip="Destino Leite Rejeitado deve ser preenchido."
                                        ValidationGroup="vg_salvar" ValidateEmptyText="True">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px; width: 24%;" class="texto" align=right>
                                    <STRONG><span style="color: #ff0000"></span>Volume Descarregado Real:</strong>
                                </td>
                                <TD class="texto" style="height: 20px">
                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_volume_descarregado" runat="server" CssClass="texto"
                                        MaxCaracteristica="10" MaxMantissa="0" Width="100px" Visible="False" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_volume_descarregado"
                                        CssClass="texto" ErrorMessage="Preencha o campo Volume Descarregado para continuar."
                                        Font-Bold="True" ToolTip="Volume Descarregado deve ser preenchido." ValidationGroup="vg_salvar" Visible="False">[!]</asp:RequiredFieldValidator>
                                    <asp:Label ID="lbl_nr_volume_descarregado_sugerido" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Início da Descarga:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_ini_descarga" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="rv_inidescarga" runat="server" ControlToValidate="txt_dt_ini_descarga"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data de Início da Descarga para continuar."
                                        Font-Bold="True" ToolTip="Data de Início da Descarga deve ser preenchido." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Horário Início Descarga:</strong></td>
                                <TD class="texto">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini_descarga" runat="server" CssClass="texto"
                                        MaxLength="2" Width="17px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini_descarga" runat="server" CssClass="texto"
                                        MaxLength="2" Width="17px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_hr_ini_descarga"
                                        CssClass="texto" ErrorMessage="Horas do Início da Descarga inválida." Font-Bold="True"
                                        MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator>
                                        <asp:RangeValidator
                                            ID="RangeValidator4" runat="server" ControlToValidate="txt_mm_ini_descarga" CssClass="texto"
                                            ErrorMessage="Minutos do Início da Descarga Inválido." Font-Bold="True" MaximumValue="59"
                                            MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator>
                                            <anthem:RequiredFieldValidator
                                                ID="rv_hrinidescarga" runat="server" ControlToValidate="txt_hr_ini_descarga"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário Início Descarga para continuar."
                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                                <anthem:RequiredFieldValidator
                                                    ID="rv_mininidescarga" runat="server" ControlToValidate="txt_mm_ini_descarga"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Minutos em Horário Inicio Descarga para continuar."
                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <SPAN id="Span4" class="obrigatorio">* </span><STRONG>Nr Silo 1:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<asp:DropDownList ID="cbo_id_silo1" runat="server" CssClass="texto">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="cbo_id_silo1"
                                        CssClass="texto" ErrorMessage="Preencha o Silo 1 para continuar." Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align="right" style="height: 22px; width: 24%;">
									<SPAN id="Span2" class="obrigatorio">* <span style="color: #000000">Nr Silo 2</span></span><STRONG>:</strong>
                                </td>
                                <TD class="texto" style="height: 22px">
                                    &nbsp;<asp:DropDownList ID="cbo_id_silo2" runat="server" CssClass="texto">
                                    </asp:DropDownList></TD>
	                        </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Fim da Descarga:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_fim_descarga" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="rv_fimdescarga" runat="server" ControlToValidate="txt_dt_fim_descarga"
                                        CssClass="texto" ErrorMessage="Preencha o campo Fim da Descarga para continuar."
                                        Font-Bold="True" ToolTip="Data de Saída Nota Fiscal deve ser preenchido." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Horário Final Descarga:</strong></td>
                                <TD class="texto">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_fim_descarga" runat="server" CssClass="texto"
                                        MaxLength="2" Width="17px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_fim_descarga" runat="server" CssClass="texto"
                                        MaxLength="2" Width="17px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_fim_descarga"
                                        CssClass="texto" ErrorMessage="Horas do Final da Descarga inválida." Font-Bold="True"
                                        MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_fim_descarga" CssClass="texto"
                                            ErrorMessage="Minutos do Final da Descarga Inválido." Font-Bold="True" MaximumValue="59"
                                            MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><anthem:RequiredFieldValidator
                                                ID="rv_hrfimdescarga" runat="server" ControlToValidate="txt_hr_fim_descarga"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário Final Descarga para continuar."
                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                    ID="rv_minfimdescarga" runat="server" ControlToValidate="txt_mm_fim_descarga"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Minutos em Horário Final Descarga para continuar."
                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right style="width: 24%"></td>
	                            <TD></td>
	                        </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados CIP</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2" style="height: 3px">
	                                <br />
	                            </td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Início do CIP:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_ini_cip" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_ini_cip"
                                        CssClass="texto" ErrorMessage="Preencha o campo Início do CIP para continuar."
                                        Font-Bold="True" ToolTip="Data Início CIP deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Horário Início CIP:</strong></td>
                                <TD class="texto">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini_cip" runat="server" CssClass="texto"
                                        MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_ini_cip" runat="server" CssClass="texto" MaxLength="2"
                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_hr_ini_cip"
                                        CssClass="texto" ErrorMessage="Horas do Início do CIP inválida." Font-Bold="True"
                                        MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator6" runat="server" ControlToValidate="txt_mm_ini_cip" CssClass="texto"
                                            ErrorMessage="Minutos do Início do CIP Inválido." Font-Bold="True" MaximumValue="59"
                                            MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_hr_ini_cip"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário Início CIP para continuar."
                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_mm_ini_cip"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Minutos em Horário Inicio CIP para continuar."
                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 22px; width: 24%;">
                                    <STRONG>PH Solução:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_ph_solucao" runat="server" CssClass="texto"
                                        MaxCaracteristica="10" MaxMantissa="4" Width="100px"></cc6:OnlyDecimalTextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <strong></strong></span>Fim do CIP:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_fim_cip" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_dt_fim_cip"
                                        CssClass="texto" ErrorMessage="Preencha o campo Fim do CIP para continuar." Font-Bold="True"
                                        ToolTip="Data de FIM CIP deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right style="width: 24%">
                                    <STRONG><span style="color: #ff0000">* <span style="color: #000000">Horário Final CIP</span></span>:</strong></td>
                                <TD class="texto">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_fim_cip" runat="server" AutoCallBack="True"
                                        CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_fim_cip" runat="server" CssClass="texto" MaxLength="2"
                                        Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txt_hr_fim_cip"
                                        CssClass="texto" ErrorMessage="Horas do Final do CIP inválida." Font-Bold="True"
                                        MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator12" runat="server" ControlToValidate="txt_mm_fim_cip" CssClass="texto"
                                            ErrorMessage="Minutos do Final do CIP Inválido." Font-Bold="True" MaximumValue="59"
                                            MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_hr_fim_cip"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário Final CIP para continuar."
                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_mm_fim_cip"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Minutos em Horário Final CIP para continuar."
                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
	                        <TR>
								<TD class="texto" align="right" style="width: 24%"></TD>
	                            <TD></TD>
	                        </TR>
						</TABLE>
					</TD>
					<TD style="height: 797px"></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
