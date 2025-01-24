<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pre_romaneio_analise_comp_veiculo.aspx.vb" Inherits="frm_pre_romaneio_analise_comp_veiculo" %>

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
    <title>Pré-Romaneio - Registrar Análise dos Compartimentos do Veículo</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width:5px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 865px;"><STRONG>Pré-Romaneio para Transit Point - Registrar Análise dos Compartimentos</STRONG></TD>
					<TD style="width: 16px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 37px" ></TD>
					<TD valign="top" align="center" background="images/faixa_filro.gif" class="texto" style="height: 37px;">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; | &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:LinkButton ID="lk_liberar" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" OnClientClick="if (confirm('Esta ação irá disponibilizar o Pré-Romaneio para o processo de Transit Point. Deseja prosseguir?' )) return true;else return false;"
                                        ValidationGroup="vg_liberar" Enabled="False" ToolTip='O "Liberar Pré-Romaneio para Transit Point" estará disponível após o registro dos compartimentos das análises.'>Liberar Pré-Romaneio para Transit Point.</anthem:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 37px; width: 16px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 134px;">&nbsp;</TD>
					<TD class="texto" style="height: 134px;">
                        <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Dados Pré-Romaneio">
						<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px"><strong>Nr. Pré-Romaneio:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_nm_linha" runat="server" CssClass="texto"></asp:Label>
                                </td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                    <strong>Situação Pré-Romaneio:</strong></td>
                                <td align="left" style="height: 20px; width: 33%;">
                                    &nbsp;<asp:Label ID="lbl_nm_st_romaneio" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr id="tr_temporota" runat="server">
                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                    <strong>Tempo de Rota:</strong></td>
                                <td align="left" colspan="3" style="height: 20px">
                                    &nbsp;<asp:Image ID="img_green" runat="server" ImageUrl="~/img/icon_status_verde.gif" />
                                    <asp:Label ID="lbl_green" runat="server" CssClass="texto " Height="15px">  Até 12:00 Horas  </asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Image ID="img_yellow" runat="server" ImageUrl="~/img/icon_status_cinza.gif" />
                                    <asp:Label ID="lbl_yellow" runat="server" CssClass="texto" Height="15px">De 12:01 a 20:00 Horas</asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Image ID="img_red" runat="server" ImageUrl="~/img/icon_status_cinza.gif" />
                                    <asp:Label ID="lbl_red" runat="server" CssClass="texto" Height="15px">Acima de 20:00 Horas</asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                    <strong>Estabelecimento:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto"></asp:Label>
                                </td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                    <strong>Tipo de Leite:</strong></td>
                                <td align="left" style="height: 20px; width: 33%;">
                                    &nbsp;<asp:Label ID="lbl_nm_item" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px">
                                    <strong>Unidade Transit Point:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<asp:Label ID="lbl_nm_transit_point_unidade" runat="server" CssClass="texto"></asp:Label>
                                </td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                </td>
                                <td align="left" style="height: 20px; width: 33%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto">
                                    <strong><span style="color: #ff0000">* <strong></strong></span>Analista:</strong></td>
                                <td align="left">
                                    &nbsp;<anthem:TextBox ID="txt_nm_analista" runat="server" CssClass="texto" MaxLength="50" Width="176px"></anthem:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_analista"
                                        CssClass="texto" ErrorMessage="O Analista deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                <td class="texto" align="right">
                                    <strong><span style="color: #ff0000">* <strong></strong></span>Início da Análise:</strong></td>
                                <td align="left" class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_analise" runat="server" CssClass="texto" MaxLength="10"
                                        Width="80px"></cc4:OnlyDateTextBox>&nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_hr_analise" runat="server" CssClass="texto" MaxLength="2"
                                        Width="20px"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_analise" runat="server" CssClass="texto" Width="20px"></cc3:OnlyNumbersTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_dt_analise"
                                        CssClass="texto" ErrorMessage="Preencha o Início da Análise para continuar."
                                        Font-Bold="False" ToolTip="Início da Análise deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_analise"
                                        CssClass="texto" ErrorMessage="Preencha as horas do Início da Análise corretamente para continuar."
                                        Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_analise" CssClass="texto"
                                            ErrorMessage="Preencha os minutos do Início da Análise corretamente para continuar."
                                            Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_analise"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Início da Análise para continuar."
                                                Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_analise"
                                                    CssClass="texto" ErrorMessage="Preencha os Minutos em Início da Análise para continuar."
                                                    Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 16px">
                                    <strong>Pré-Romaneio:</strong></td>
                                <td align="left" class="texto" style="height: 16px">
                                    &nbsp;<asp:Label ID="lbl_romaneio" runat="server" CssClass="texto">Coleta de Produtores</asp:Label></td>
                                <td align="right" class="texto" style="height: 16px" >
                                    </td>
                                <td align="left" class="texto" style="height: 16px">
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto">
                                </td>
                                <td align="left" class="texto">
                                </td>
                                <td align="left" class="texto">
                                </td>
                            </tr>
						</TABLE>
                        </asp:Panel>
					</TD>
				    <TD style="height: 134px; width: 16px;" ></TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 27px;">&nbsp;</TD>
					<TD style="height: 27px; " class="texto">
                        <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" GroupingText="Dados Compartimentos" CssClass="texto">
                            <br />
                                <anthem:GridView ID="grdCompartimentos" runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Bottom" CellPadding="2"
                                    Width="100%" Height="40px" DataKeyNames="id_romaneio_compartimento">
                                    <HeaderStyle CssClass="texto" HorizontalAlign="Left" Height="20px" />
                                    <Columns>
                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                        <asp:HyperLinkField DataTextField="ds_compartimento" HeaderText="Compartimento" Text="Compartimento" DataNavigateUrlFields="id_romaneio_compartimento" DataNavigateUrlFormatString="~/frm_romaneio_analise_compartimento_consulta.aspx?id_romaneio_compartimento={0}" NavigateUrl="~/frm_romaneio_analise_compartimento_consulta.aspx" Target="_blank" >
                                            <itemstyle font-underline="False" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="nr_total_litros" HeaderText="Litros Coletados" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
<anthem:DropDownList id="cbo_registrar_id_st_analise" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" Visible="False" __designer:wfdid="w40" OnSelectedIndexChanged="cbo_registrar_id_st_analise_SelectedIndexChanged"></anthem:DropDownList>&nbsp; <asp:Label id="lbl_st_registro" runat="server" CssClass="texto" Text='<%# bind("nm_st_analise") %>' Visible="False" __designer:wfdid="w41"></asp:Label>&nbsp; <anthem:Label id="lbl_labelmotivo" __designer:dtid="1970350606778452" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w42">Justificativa:</anthem:Label><anthem:TextBox id="txt_ds_motivo_aprovado_sob_concessao" __designer:dtid="1970350606778454" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" Width="280px" MaxLength="150" Visible="False" __designer:wfdid="w43" Rows="2"></anthem:TextBox> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CIQ" Visible="False">
                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
&nbsp;<anthem:HyperLink style="TEXT-ALIGN: center" id="hl_imprimir_ciq" __designer:dtid="5066575350595681" runat="server" ImageUrl="~/img/ic_impressao_desabilitado.gif" CssClass="texto" ToolTip="Relatório CIQ:  Versão para Imprimir." AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w125" Enabled="False" NavigateUrl="~/frm_relatorio_CIQ.aspx" Target="_blank"></anthem:HyperLink>&nbsp; <asp:ImageButton style="TEXT-ALIGN: center" id="btn_email" __designer:dtid="5066575350595684" runat="server" ImageUrl="~/img/ico_email_desabilitado.gif" CssClass="texto" ToolTip="Relatório CIQ - Enviar Email " OnClientClick="if (confirm('O relatório CIQ será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;" __designer:wfdid="w126" CommandArgument='<%# Bind("id_romaneio_compartimento") %>' Enabled="False" CommandName="EmailCIQ"></asp:ImageButton>
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="An&#225;lise Produtores">
                                            <itemtemplate>
<asp:ImageButton id="btn_registrar_analise_uproducao" runat="server" ImageUrl="~/img/icon_registrar_desabilitado.gif" ToolTip="Registrar Análise Unid. Produção / Produtor" __designer:wfdid="w127" CommandArgument='<%# Bind("id_romaneio_compartimento") %>' Enabled="False" CommandName="Registrar_Analise_UProducao"></asp:ImageButton> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_st_analise" Visible="False">
                                            <edititemtemplate>
<asp:Label id="lbl_id_st_analise" runat="server" Text='<%# Bind("id_st_analise") %>' __designer:wfdid="w46"></asp:Label> <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w47"></asp:Label> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_st_analise" runat="server" Text='<%# Bind("id_st_analise") %>' __designer:wfdid="w44"></asp:Label> <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w45"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="st_reanalise" Visible="False">
                                            <edititemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" Text='<%# Bind("st_reanalise") %>' __designer:wfdid="w21"></asp:Label> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" Text='<%# Bind("st_reanalise") %>' __designer:wfdid="w20"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="texto" HorizontalAlign="Left" />
                                </anthem:GridView>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="Red"
                                Text="ATENÇÃO: Ao registrar o resultado para o Compartimento, as análises referentes à ele não poderão mais sofrer alterações. "></asp:Label></td>
                                    <td align="right">
                                        <anthem:ImageButton ID="btn_registrar" runat="server" AutoUpdateAfterCallBack="True"
                                            CommandArgument='<%# bind("id_romaneio_compartimento") %>' CssClass="texto" ImageAlign="AbsBottom"
                                            ImageUrl="~/img/bnt_registrar2.gif" OnClick="btn_registrar_Click" ToolTip="Registrar Análise do Campartimento"
                                            ValidationGroup="vg_registrar" /></td>
                                </tr>
                            </table>
                            &nbsp;
                        </asp:Panel>
                        <br />
					</TD>
				    <TD style="height: 27px; width: 16px;" ></TD>
				</TR>				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="texto" >
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Registro das Análises">
                        <br />
						<TABLE id="Table5" cellSpacing="0" cellPadding="2" width="100%" class="texto">
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px"><strong>Código Análise:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<anthem:DropDownList ID="cbo_cd_analise" runat="server" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                    <strong>Faixa Referencial:</strong></td>
                                <td align="left" style="height: 20px; width: 33%;">
                                    <anthem:Label ID="lbl_faixa_referencial" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:DropDownList ID="cbo_sigla_analise" runat="server" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True" Visible="False">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 19px">
                                    <strong>Análise Obrigatória:</strong></td>
                                <td align="left" style="height: 19px">
                                    &nbsp;<anthem:Image ID="img_chk_obrigatorio" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/ico_chk_false.gif" /></td>
                                <td class="texto" align="right" style="height: 19px">
                                    <strong>Exibir Comentário:</strong></td>
                                <td align="left" class="texto" style="height: 19px">
                                    <anthem:CheckBox ID="chk_exibir_comentario" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" AutoCallBack="True" /></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 16px">
                                </td>
                                <td align="left" style="height: 16px">
                                </td>
                                <td align="right" class="texto" style="height: 16px">
                                </td>
                                <td align="left" class="texto" style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="texto" colspan="4">
                                    <anthem:GridView ID="grdAnalises" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="98%" Visible="False"
                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" DataKeyNames="id_analise_compartimento" CssClass="texto" UseAccessibleHeader="False" AutoUpdateAfterCallBack="True" AddCallBacks="False" UpdateAfterCallBack="True" >
                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                            HorizontalAlign="Center" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" ShowHeader="False" />
                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" ShowHeader="False" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Resultado">
                                                <edititemtemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<cc3:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" CssClass="texto" Width="56px" Text='<%# Bind("nr_valor") %>' Visible="False" __designer:wfdid="w1"></cc3:OnlyNumbersTextBox>&nbsp;<asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="False" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" ToolTip="Valor obrigatório" Visible="False" __designer:wfdid="w2">!</asp:RequiredFieldValidator><cc6:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" CssClass="texto" Width="56px" MaxLength="15" AutoUpdateAfterCallBack="True" Text='<%# Bind("nr_valor") %>' __designer:wfdid="w3" MaxMantissa="2"></cc6:OnlyDecimalTextBox>&nbsp;<asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" ValidationGroup="vg_salvar" Font-Bold="False" ErrorMessage="O valor para análise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" ToolTip="Valor obrigatório!" Visible="False" __designer:wfdid="w4">!</asp:RequiredFieldValidator><anthem:DropDownList id="cbo_nr_valor" runat="server" CssClass="texto" Visible="False" __designer:wfdid="w5"></anthem:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" ValidationGroup="vg_salvar" Font-Bold="False" ErrorMessage="O valor da análise deve ser preenchido." ControlToValidate="cbo_nr_valor" ToolTip="Valor obrigatório" Visible="False" __designer:wfdid="w6">!</asp:RequiredFieldValidator><asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' Visible="False" __designer:wfdid="w7"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Text='<%# Bind("nm_analise_logica") %>' Visible="False" __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                                <itemstyle width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Coment&#225;rio" Visible="False">
                                                <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" CssClass="texto" Width="248px" Text='<%# bind("ds_comentario") %>' Visible="False" __designer:wfdid="w62"></asp:Label>&nbsp; <anthem:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="248px" MaxLength="50" Visible="False" __designer:wfdid="w63"></anthem:TextBox>&nbsp; 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                                <edititemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w73" Text='<%# Bind("nm_st_analise") %>'></asp:Label>&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w73" Text='<%# Bind("nm_st_analise") %>'></asp:Label> 
</itemtemplate>
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False" Visible="False">
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_analise" Text="Update" __designer:wfdid="w14" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w15" CommandName="Cancel"></asp:ImageButton> 
</edititemtemplate>
                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Text="Edit" __designer:wfdid="w13" CommandName="Edit"></asp:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_romaneio_compartimento" Visible="False">
                                                <edititemtemplate>
&nbsp; <asp:Label id="lbl_id_romaneio_compartimento" runat="server" Text='<%# Bind("id_romaneio_compartimento") %>' __designer:wfdid="w17"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_romaneio_compartimento" runat="server" Text='<%# Bind("id_romaneio_compartimento") %>' __designer:wfdid="w16"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_st_original" Visible="False">
                                                <edititemtemplate>
&nbsp; <asp:Label id="lbl_id_st_original" runat="server" __designer:wfdid="w78" Text='<%# Bind("id_st_original") %>'></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_st_original" runat="server" __designer:wfdid="w77" Text='<%# Bind("id_st_original") %>'></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_st_analise_compartimento" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_id_st_analise_compartimento" runat="server" __designer:wfdid="w78" Text='<%# Bind("id_st_analise_compartimento") %>'></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_st_analise_compartimento" runat="server" __designer:wfdid="w76" Text='<%# Bind("id_st_analise_compartimento") %>'></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Left" BackColor="White" />
                                    </anthem:GridView>
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="texto" colspan="4" style="height: 16px">
                                    <anthem:Label ID="lbl_analiseinformativa" runat="server" Font-Bold="False" Font-Italic="True" ForeColor="Red"
                                        Text="* Análise Informativa" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
						</TABLE>
                        </asp:Panel>
					</TD>
				    <TD style="width: 16px" ></TD>
				</TR>
				<TR>
				    <TD  style="width: 5px"></TD>
					<TD >
					    <TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>
                                    |
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
					    </TABLE>
					</TD>
					<TD  style="width: 16px"></TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD ></TD>
					<TD style="width: 16px">&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"></cc7:AlertMessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_liberar" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_registrar" />
        </form>
	</body>
</HTML>
