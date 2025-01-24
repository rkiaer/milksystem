<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_analise_comp_veiculo.aspx.vb" Inherits="frm_romaneio_saida_analise_comp_veiculo" %>

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
    <title>Romaneio Sa�da - Registrar An�lise dos Compartimentos do Ve�culo</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width:5px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif);"><STRONG>Romaneio Sa�da - Registrar An�lise dos Compartimentos</STRONG></TD>
					<TD style="width: 16px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 37px" ></TD>
					<TD valign="top" align="center" background="images/faixa_filro.gif" class="texto" style="height: 37px;">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; | &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4"><asp:Image ID="Image4" runat="server" ImageUrl="~/img/icone_anexar.gif" /><asp:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio"
                                        ValidationGroup="vg_salvar">Anexar Documento</asp:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 37px; width: 16px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 134px;">&nbsp;</TD>
					<TD class="texto">
                        <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Dados Romaneio Sa�da">
						<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px"><strong>Nr. Romaneio Sa�da:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                    <strong>Situa��o Romaneio:</strong></td>
                                <td align="left" style="height: 20px; width: 33%;">
                                    &nbsp;<asp:Label ID="lbl_nm_st_romaneio" runat="server" CssClass="texto"></asp:Label></td>
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
                                    <strong>Transportador:</strong></td>
                                <td align="left" style="width: 30%; height: 20px">
                                    &nbsp;<asp:Label ID="lbl_transportador" runat="server" CssClass="texto"></asp:Label>
                                </td>
                                <td align="right" class="texto" style="height: 20px; width: 18%;">
                                    <strong>Destino:</strong></td>
                                <td align="left" style="height: 20px; width: 33%;">
                                    &nbsp;<asp:Label ID="lbl_destino" runat="server" CssClass="texto"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto">
                                    <strong><span style="color: #ff0000">* <strong></strong></span>Analista:</strong></td>
                                <td align="left">
                                    &nbsp;<anthem:TextBox ID="txt_nm_analista" runat="server" CssClass="texto" MaxLength="50" Width="176px"></anthem:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_analista"
                                        CssClass="texto" ErrorMessage="O Analista deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                <td class="texto" align="right">
                                    <strong><span style="color: #ff0000">* <strong></strong></span>In�cio da An�lise:</strong></td>
                                <td align="left" class="texto">
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_analise" runat="server" CssClass="texto" MaxLength="10"
                                        Width="80px"></cc4:OnlyDateTextBox>&nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_hr_analise" runat="server" CssClass="texto" MaxLength="2"
                                        Width="20px"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_analise" runat="server" CssClass="texto" Width="20px"></cc3:OnlyNumbersTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_dt_analise"
                                        CssClass="texto" ErrorMessage="Preencha o In�cio da An�lise para continuar."
                                        Font-Bold="False" ToolTip="In�cio da An�lise deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_analise"
                                        CssClass="texto" ErrorMessage="Preencha as horas do In�cio da An�lise corretamente para continuar."
                                        Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_analise" CssClass="texto"
                                            ErrorMessage="Preencha os minutos do In�cio da An�lise corretamente para continuar."
                                            Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_analise"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em In�cio da An�lise para continuar."
                                                Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_analise"
                                                    CssClass="texto" ErrorMessage="Preencha os Minutos em In�cio da An�lise para continuar."
                                                    Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
						</TABLE>
                        </asp:Panel>
					</TD>
				    <TD style="height: 134px; width: 16px;" ></TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 27px;">&nbsp;</TD>
					<TD class="texto">
                        <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" GroupingText="Dados Compartimentos" CssClass="texto">
                            <br />
                                <anthem:GridView ID="grdCompartimentos" runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Bottom" CellPadding="2"
                                    Width="100%" Height="40px" DataKeyNames="id_romaneio_saida_compartimento">
                                    <HeaderStyle CssClass="texto" HorizontalAlign="Left" Height="20px" />
                                    <Columns>
                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" >
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataTextField="ds_compartimento" HeaderText="Compartimento" Text="Compartimento" DataNavigateUrlFields="id_romaneio_saida_compartimento" DataNavigateUrlFormatString="~/frm_romaneio_saida_analise_compartimento_consulta.aspx?id_romaneio_saida_compartimento={0}" NavigateUrl="~/frm_romaneio_saida_analise_compartimento_consulta.aspx" Target="_blank" >
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle font-underline="False" horizontalalign="Center" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="nr_total_litros" HeaderText="Litros Coletados" ReadOnly="True" DataFormatString="{0:N0}" >
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Re-An&#225;lise" Visible="False">
                                            <itemtemplate>
<asp:Image id="img_reanalise" runat="server" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w109"></asp:Image> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
<anthem:DropDownList id="cbo_registrar_id_st_analise" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" Visible="False" __designer:wfdid="w110" OnSelectedIndexChanged="cbo_registrar_id_st_analise_SelectedIndexChanged"></anthem:DropDownList>&nbsp; <asp:Label id="lbl_st_registro" runat="server" CssClass="texto" Text='<%# bind("nm_st_analise") %>' Visible="False" __designer:wfdid="w111"></asp:Label>&nbsp; <anthem:Label id="lbl_labelmotivo" __designer:dtid="1970350606778452" runat="server" CssClass="texto" Font-Bold="True" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False" __designer:wfdid="w112">Justificativa:</anthem:Label><anthem:TextBox id="txt_ds_motivo_aprovado_sob_concessao" __designer:dtid="1970350606778454" runat="server" CssClass="texto" Width="280px" MaxLength="150" AutoUpdateAfterCallBack="True" Visible="False" __designer:wfdid="w113" Rows="2"></anthem:TextBox> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CIQ" Visible="False">
                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
&nbsp;<anthem:HyperLink style="TEXT-ALIGN: center" id="hl_imprimir_ciq" __designer:dtid="5066575350595681" runat="server" ImageUrl="~/img/ic_impressao_desabilitado.gif" ToolTip="Relat�rio CIQ:  Vers�o para Imprimir." CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w203" Target="_blank" NavigateUrl="~/frm_relatorio_CIQ.aspx" Enabled="False"></anthem:HyperLink>&nbsp; <asp:ImageButton style="TEXT-ALIGN: center" id="btn_email" __designer:dtid="5066575350595684" runat="server" ImageUrl="~/img/ico_email_desabilitado.gif" ToolTip="Relat�rio CIQ - Enviar Email " CssClass="texto" OnClientClick="if (confirm('O relat�rio CIQ ser� enviado � lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;" CommandArgument='<%# Bind("id_romaneio_saida_compartimento") %>' __designer:wfdid="w126" Enabled="False" CommandName="EmailCIQ"></asp:ImageButton> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="An&#225;lise Produtores" Visible="False">
                                            <itemtemplate>
<asp:ImageButton id="btn_registrar_analise_uproducao" runat="server" ImageUrl="~/img/icon_registrar_desabilitado.gif" ToolTip="Registrar An�lise Unid. Produ��o / Produtor" CommandArgument='<%# Bind("id_romaneio_saida_compartimento") %>' __designer:wfdid="w213" Enabled="False" CommandName="Registrar_Analise_UProducao"></asp:ImageButton> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_st_analise" Visible="False">
                                            <edititemtemplate>
<asp:Label id="lbl_id_st_analise" runat="server" Text='<%# Bind("id_st_analise") %>' __designer:wfdid="w208"></asp:Label> <asp:Label id="lbl_nm_st_analise" runat="server" Text='<%# Bind("nm_st_analise") %>' __designer:wfdid="w209"></asp:Label> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_st_analise" runat="server" __designer:wfdid="w128" Text='<%# Bind("id_st_analise") %>'></asp:Label> <asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w129" Text='<%# Bind("nm_st_analise") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="st_reanalise" Visible="False">
                                            <edititemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" Text='<%# Bind("st_reanalise") %>' __designer:wfdid="w211"></asp:Label> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_st_reanalise" runat="server" Text='<%# Bind("st_reanalise") %>' __designer:wfdid="w210"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="texto" HorizontalAlign="Left" />
                                </anthem:GridView>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="Red"
                                Text="ATEN��O: Ao registrar o resultado para o Compartimento, as an�lises referentes � ele n�o poder�o mais sofrer altera��es. "></asp:Label></td>
                                    <td align="right">
                                        <anthem:ImageButton ID="btn_registrar" runat="server" AutoUpdateAfterCallBack="True"
                                            CommandArgument='<%# bind("id_romaneio_saida_compartimento") %>' CssClass="texto" ImageAlign="AbsBottom"
                                            ImageUrl="~/img/bnt_registrar2.gif" OnClick="btn_registrar_Click" ToolTip="Registrar An�lise do Campartimento"
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
					<TD class="texto">
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Registro das An�lises">
                        <br />
						<TABLE id="Table5" cellSpacing="0" cellPadding="2" width="100%" class="texto">
                            <tr>
                                <td align="right" class="texto" style="width: 19%; height: 20px"><strong>C�digo An�lise:</strong></td>
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
                                    <strong>An�lise Obrigat�ria:</strong></td>
                                <td align="left" style="height: 19px">
                                    &nbsp;<anthem:Image ID="img_chk_obrigatorio" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/ico_chk_false.gif" /></td>
                                <td class="texto" align="right" style="height: 19px">
                                    <strong>Exibir Coment�rio:</strong></td>
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
                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" DataKeyNames="id_romaneio_saida_analise_compartimento" CssClass="texto" UseAccessibleHeader="False" AutoUpdateAfterCallBack="True" AddCallBacks="False" UpdateAfterCallBack="True" >
                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                            HorizontalAlign="Center" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" ShowHeader="False" >
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" ShowHeader="False" ReadOnly="True" >
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Resultado">
                                                <edititemtemplate>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<cc3:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_int_nr_valor" runat="server" CssClass="texto" Width="56px" Text='<%# Bind("nr_valor") %>' Visible="False" __designer:wfdid="w114"></cc3:OnlyNumbersTextBox>&nbsp;<asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" ValidationGroup="vg_salvar" ToolTip="Valor obrigat�rio" CssClass="texto" Font-Bold="False" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" Visible="False" __designer:wfdid="w115">!</asp:RequiredFieldValidator><cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_dec_nr_valor" runat="server" CssClass="texto" Width="56px" MaxLength="15" Text='<%# Bind("nr_valor") %>' AutoUpdateAfterCallBack="True" __designer:wfdid="w116" MaxMantissa="2"></cc6:OnlyDecimalTextBox>&nbsp;<asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" ValidationGroup="vg_salvar" ToolTip="Valor obrigat�rio!" Font-Bold="False" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" Visible="False" __designer:wfdid="w117">!</asp:RequiredFieldValidator><anthem:DropDownList id="cbo_nr_valor" runat="server" CssClass="texto" Visible="False" __designer:wfdid="w118"></anthem:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" ValidationGroup="vg_salvar" ToolTip="Valor obrigat�rio" Font-Bold="False" ErrorMessage="O valor da an�lise deve ser preenchido." ControlToValidate="cbo_nr_valor" Visible="False" __designer:wfdid="w119">!</asp:RequiredFieldValidator><asp:Label id="lbl_nr_valor" runat="server" Text='<%# Bind("nr_valor") %>' Visible="False" __designer:wfdid="w120"></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" Text='<%# Bind("nm_analise_logica") %>' Visible="False" __designer:wfdid="w121"></asp:Label> 
</itemtemplate>
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle width="20%" horizontalalign="Right" />
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
                                            <asp:TemplateField HeaderText="id_romaneio_saida_compartimento" Visible="False">
                                                <edititemtemplate>
&nbsp; <asp:Label id="lbl_id_romaneio_compartimento" runat="server" Text='<%# Bind("id_romaneio_saida_compartimento") %>' __designer:wfdid="w17"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_romaneio_compartimento" runat="server" Text='<%# Bind("id_romaneio_saida_compartimento") %>' __designer:wfdid="w16"></asp:Label> 
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
                                        Text="* An�lise Informativa" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
						</TABLE>
                            <anthem:Label ID="lbl_analise_anexo" runat="server" AutoUpdateAfterCallBack="True"
                                Font-Bold="False" Font-Italic="True" ForeColor="Red" Text="* AN�LISE OBRIGA ANEXAR DOCUMENTO COMO COMPROVANTE"
                                UpdateAfterCallBack="True" Visible="False"></anthem:Label></asp:Panel>
					</TD>
				    <TD style="width: 16px" ></TD>
				</TR>
				<TR>
				    <TD  style="width: 5px; height: 44px;"></TD>
					<TD style="height: 44px;">
					    <TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
					    </TABLE>
					</TD>
					<TD  style="width: 16px; height: 44px;"></TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD></TD>
					<TD style="width: 16px">&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"></cc7:AlertMessages></form>
	</body>
</HTML>
