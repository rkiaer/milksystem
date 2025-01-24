<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_analise_compartimento.aspx.vb" Inherits="frm_romaneio_analise_compartimento" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>RmaneioCompartimento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 1px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 701px;"><STRONG class="texto">Registrar An�lise Compartimento &nbsp;</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 1px; height: 5px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 5px" class="texto">
						<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0" class="texto">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
                                    <asp:LinkButton ID="lk_concluir" runat="server" ToolTip="Salvar Dados Compartimento"
                                        ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 5px; width: 10px;">&nbsp;</TD>
				</TR>
			    <TR>
				    <TD style="width: 1px; height: 26px;"  ></TD>
					<TD class="texto" style="height: 26px" >
                                                <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Romaneio"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                            <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;"><STRONG>Nr. Romaneio:</STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>Situa��o Romaneio:</STRONG></TD>
				                    <TD align="left" style="height: 22px" class="texto" >&nbsp;<asp:Label ID="lbl_st_romaneio" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
                            </table>
                        </asp:Panel>
                        &nbsp;&nbsp;<asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Compartimento" Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="32px">
                            <table id="Table2" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto" style="height: 8px">
			                    <TR>
				                    <TD class="texto" align="right" style="height: 22px;width:20%"><STRONG>Compartimento:</STRONG></TD>
				                    <TD style="width:29%; height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_ds_compartimento" runat="server"  CssClass="texto" ></asp:Label></TD>
				                    <TD class="texto" align="right" style="width:20%; height: 22px;" ><STRONG>Placa:</STRONG></TD>
				                    <TD style="height: 22px;" align="left" class="texto" >&nbsp;<asp:Label ID="lbl_ds_placa_compartimento" runat="server"  CssClass="texto"></asp:Label></TD>
			                    </TR>
			                    <TR>
			                        <TD class="texto" align="right" style="height: 22px; width: 20%;" ><STRONG>Situa��o:</STRONG></TD>
                                    <TD style=" height: 22px; width: 29%;" align="left" class="texto" >&nbsp;<anthem:Label ID="lbl_nm_st_compartimento" runat="server"  CssClass="texto"  AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
				                    <TD class="texto" align="right" style="height: 22px; width: 20%;" ></td>
                                    <TD style="height: 22px; " align="left">
                                        &nbsp;</TD>
			                    </TR>
                                <tr>
                                    <TD class="texto" align="right" style="height: 22px;width:20%">
                                        <STRONG><span style="color: #ff0000">*</span><strong> </strong>Analista:</strong></td>
                                    <TD style="width:29%; height: 22px;" align="left" class="texto" >
                                        &nbsp;<asp:TextBox ID="txt_nm_analista" runat="server" CssClass="texto" Width="184px"></asp:TextBox>
                                        </td>
                                    <TD class="texto" align="right" style="width:20%; height: 22px;" >
                                        <STRONG><span style="color: #ff0000">*</span><strong> </strong>In�cio da An�lise:</strong></td>
                                    <TD style="height: 22px;" align="left" class="texto" >
                                        <cc4:OnlyDateTextBox ID="txt_dt_analise" runat="server" CssClass="texto" MaxLength="10"
                                            Width="80px"></cc4:OnlyDateTextBox>
                                        <cc2:OnlyNumbersTextBox ID="txt_hr_analise" runat="server" CssClass="texto" MaxLength="2"
                                            Width="24px"></cc2:OnlyNumbersTextBox>:<cc2:OnlyNumbersTextBox ID="txt_mm_analise"
                                                runat="server" CssClass="texto" MaxLength="2" Width="24px"></cc2:OnlyNumbersTextBox><asp:RangeValidator
                                                    ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_analise" CssClass="texto"
                                                    ErrorMessage="Preencha as horas do In�cio da An�lise corretamente para continuar."
                                                    Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                        ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_analise" CssClass="texto"
                                                        ErrorMessage="Preencha os minutos do In�cio da An�lise corretamente para continuar."
                                                        Font-Bold="True" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_analise"
                                                            CssClass="texto" ErrorMessage="Preencha o campo Horas em In�cio da An�lise para continuar."
                                                            Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_analise"
                                                                CssClass="texto" ErrorMessage="Preencha os Minutos em In�cio da An�lise para continuar."
                                                                Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_analise"
                                                                    CssClass="texto" ErrorMessage="Preencha o In�cio da An�lise para continuar."
                                                                    Font-Bold="True" ToolTip="In�cio da An�lise deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <TD class="texto" align="right" style="width:20%; height: 4px;">
                                    </td>
                                    <TD style="width:29%; height: 4px;" align="left" class="texto" >
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nm_analista"
                                            CssClass="texto" ErrorMessage="O nome do Analista que est� realizando a an�lise deve ser preenchido."
                                            Font-Bold="True" ToolTip="O analista deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nm_analista"
                                            CssClass="texto" ErrorMessage="O nome do Analista que est� realizando a an�lise deve ser preenchido."
                                            Font-Bold="True" ToolTip="O analista deve ser preenchido." ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator></td>
                                    <TD class="texto" align="right" style="width:20%; height: 4px;" >
                                    </td>
                                    <TD align="left" class="texto" style="height: 4px" >
                                        <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_dt_analise"
                                                                        CssClass="texto" ErrorMessage="Preencha o In�cio da An�lise para continuar."
                                                                        Font-Bold="True" ToolTip="In�cio da An�lise deve ser preenchido." ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator><asp:RangeValidator
                                                                            ID="RangeValidator3" runat="server" ControlToValidate="txt_hr_analise" CssClass="texto"
                                                                            ErrorMessage="Preencha as horas do In�cio da An�lise corretamente para continuar."
                                                                            Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_registrar">[!]</asp:RangeValidator><asp:RangeValidator
                                                                                ID="RangeValidator4" runat="server" ControlToValidate="txt_mm_analise" CssClass="texto"
                                                                                ErrorMessage="Preencha os minutos do In�cio da An�lise corretamente para continuar."
                                                                                Font-Bold="True" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_registrar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_hr_analise"
                                                                                    CssClass="texto" ErrorMessage="Preencha o campo Horas em In�cio da An�lise para continuar."
                                                                                    Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_mm_analise"
                                                                                        CssClass="texto" ErrorMessage="Preencha os Minutos em In�cio da An�lise para continuar."
                                                                                        Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                                                <asp:Panel ID="Panel3" runat="server" BackColor="White" Font-Bold="False" GroupingText="An�lise Compartimento"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px">
                                                    <br />
                            <table id="Table6" border="0" cellpadding="1" cellspacing="0" width="100%" class="texto" style="height: 24px">
			                    <TR>
				                    <TD class="texto" align="right" style="width:20%; height: 23px;">
                                        <strong><span style="color: #ff0000">*</span><strong> Registrar </strong>Resultado:</strong>&nbsp;</TD>
				                    <TD class="texto" align="left" style="height: 23px; width: 27%;" >
                                        <anthem:DropDownList ID="cbo_registro_analise" runat="server"
                                            CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True">
                                        </anthem:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_registro_analise"
                                            CssClass="texto" ErrorMessage="O resultado da An�lise deve ser preenchido." Font-Bold="True"
                                            ValidationGroup="vg_registrar">[!]</asp:RequiredFieldValidator><asp:CustomValidator ID="cv_st_analises" runat="server" ControlToValidate="cbo_registro_analise"
                                            CssClass="texto" ErrorMessage="CustomValidator" Font-Bold="True" ValidationGroup="vg_registrar">[!]</asp:CustomValidator><asp:CustomValidator ID="cv_verificarrejeitadas" runat="server" CssClass="texto"
                                            ErrorMessage="CustomValidator" Font-Bold="True" ValidationGroup="vg_registrar">[!]</asp:CustomValidator></TD>
                                    <td align="center" class="texto" style="width: 10%; height: 23px" colspan="2" valign="middle">
                                        <anthem:Label ID="lbl_labelmotivo" runat="server" CssClass="texto" Font-Bold="True" Width="72px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Justificativa:</anthem:Label>&nbsp;</td>
                                    <td align="left" class="texto" style="width: 43%; height: 23px" colspan="3" >
                                        <anthem:TextBox ID="txt_ds_motivo_aprovado_sob_concessao" runat="server" CssClass="texto"
                                            TextMode="MultiLine" Width="92%" Rows="2" MaxLength="150" Visible="False" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                        <anthem:RequiredFieldValidator ID="rfv_motivo" runat="server" ControlToValidate="txt_ds_motivo_aprovado_sob_concessao"
                                            CssClass="texto" ErrorMessage="A justificativa da Aprova��o Sob Concess�o deve ser preenchida." Font-Bold="True" ValidationGroup="vg_registrar" Visible="False" AutoUpdateAfterCallBack="True" ToolTip="Justificativa da Aprova��o Sob Concess�o deve ser preenchida.">[!]</anthem:RequiredFieldValidator></td>
			                    </TR>
                                <tr>
                                    <td align="right" class="texto" style="height: 22px; width: 20%;">
                                    <asp:CustomValidator
                                                ID="cv_analista_dt" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                                Font-Bold="True" ValidationGroup="vg_registrar" Visible="False">[!]</asp:CustomValidator></td>
                                    <td align="right" class="texto" style="height: 22px; width: 27%;">
                                        </td>
                                    <td align="right" class="texto" style="height: 22px; width: 1%;" colspan="">
                                    </td>
                                    <td align="center" class="texto" style="height: 22px" colspan="2">
                                        <anthem:ImageButton ID="btn_registrar" runat="server" CssClass="texto" ImageUrl="~/img/bnt_registrar.gif"
                                            ValidationGroup="vg_registrar" OnClientClick="if (confirm('Ao registrar o resultado para o Compartimento, as an�lises referentes � ele n�o poder�o mais sofrer altera��es. Deseja realmente prosseguir?' )) return true;else return false;" AutoUpdateAfterCallBack="True" /></td>
                                    <td align="right" class="texto" style="width: 22%; height: 22px">
                                        <anthem:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" AutoUpdateAfterCallBack="True" ToolTip="Imprimir Relat�rio" />
                                        <anthem:HyperLink
                                            ID="hl_imprimir_ciq" runat="server" CssClass="texto" Enabled="False" NavigateUrl="~/frm_relatorio_CIQ.aspx"
                                            Style="text-align: center" Target="_blank" Width="120px" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Relat�rio  CIQ.    Vers�o para Imprimir</anthem:HyperLink></td>
                                    <td align="right" class="texto" style="height: 22px; width: 15%;"><anthem:Image ID="img_email" runat="server" ImageUrl="~/img/ico_email.gif" AutoUpdateAfterCallBack="True" ToolTip="Enviar Emails" />
                                        <asp:LinkButton ID="btn_email" runat="server" CssClass="texto" Enabled="False" OnClientClick="if (confirm('O relat�rio CIQ ser� enviado � lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"
                                            Style="text-align: center" Width="72px">Rel. CIQ Enviar Email</asp:LinkButton>&nbsp;
                                        </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        	</TD>
					<TD style="width: 10px; height: 26px;"  ></TD>
				</TR>
				<TR>
					<TD style="height: 2px; width: 1px;"></TD>
					<TD vAlign="middle" style="height: 2px" class="texto">&nbsp;&nbsp;&nbsp;&nbsp;
                    </TD>
					<TD style="height: 2px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="width: 1px; height: 25px;">&nbsp;</TD>
					<TD style="height: 25px" valign="top" class="texto">
<asp:Panel ID="Panel5" runat="server" BackColor="White" Font-Bold="False" GroupingText="Registro das An�lises"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px" HorizontalAlign="Left">
    <br />
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="id_analise_compartimento" CssClass="texto" Height="32px">
                                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#6193E0" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Obrigat&#243;ria">
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemtemplate>
<asp:CheckBox id="chk_obrigatoria" runat="server" Font-Bold="False" Enabled="False" Checked='<%# Bind("chk_obrigatoria") %>' Font-Overline="False" __designer:wfdid="w26"></asp:CheckBox> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="cd_analise" HeaderText="C&#243;digo" SortExpression="cd_analise" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla An&#225;lise" SortExpression="nm_sigla" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Faixa Referencial" SortExpression="ds_faixa">
                                                    <edititemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w9" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label><asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w10" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</edititemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w7" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label> <asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo"
                                                    SortExpression="nm_tipo_analise" ReadOnly="True" NullDisplayText="N&#227;o Cadastrada" Visible="False" >
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Resultado">
                                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Width="56px" __designer:wfdid="w7" Visible="False"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio" CssClass="texto" Width="8px" Font-Bold="True" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" __designer:wfdid="w8" Visible="False">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Width="56px" MaxLength="15" __designer:wfdid="w9" Visible="False" DecimalSymbol="," MaxMantissa="4" MaxCaracteristica="10"></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio!" Font-Bold="True" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" __designer:wfdid="w10" Visible="False">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Width="88px" __designer:wfdid="w11" Visible="False"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio" Font-Bold="True" ErrorMessage="O valor da an�lise deve ser preenchido." ControlToValidate="cbo_nr_valor" __designer:wfdid="w12" Visible="False">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_analise" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w13"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_valor") %>'></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" __designer:wfdid="w6" Text='<%# Bind("nm_analise_logica") %>' Visible="False"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Coment&#225;rio">
                                                    <edititemtemplate>
<asp:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="200px" MaxLength="50" __designer:wfdid="w3" Text='<%# Bind("ds_comentario") %>' TextMode="MultiLine"></asp:TextBox> 
</edititemtemplate>
                                                    <itemstyle horizontalalign="Justify" width="200px" />
                                                    <headerstyle horizontalalign="Center" width="200px" />
                                                    <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" __designer:wfdid="w2" Text='<%# Bind("ds_comentario") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w9" Text='<%# Bind("nm_st_analise") %>'></asp:Label>
</edititemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_st_analise") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_analise" >
                                                    <headerstyle horizontalalign="Center" width="10%" />
                                                    <itemstyle horizontalalign="Center" width="10%" />
                                                </asp:CommandField>
                                                <asp:TemplateField Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w2" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="nr_faixa_final" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w16" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w15" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_faixa_referencia_logica" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w13" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_formato_analise" runat="server" __designer:wfdid="w6" Text='<%# Bind("id_formato_analise") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_gera_ciq" Visible="False">
                                                    <itemtemplate>
<asp:Label id="st_gera_ciq" runat="server" __designer:wfdid="w6" Text='<%# Bind("st_gera_ciq") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_st_original" Visible="False">
                                                    <itemtemplate>
<asp:Label id="id_st_original" runat="server" Text='<%# Bind("id_st_original") %>' __designer:wfdid="w18"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
    <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="True"
        ForeColor="Red" Text="* An�lise Informativa"></asp:Label></asp:Panel>
										</TD>
					<TD style="height: 25px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr id="tr_reanalise" visible="false" runat="server">
                    <TD style="width: 1px; height: 25px;">
                        &nbsp;</td>
                    <TD style="height: 25px" valign="top" class="texto">
<asp:Panel ID="Panel4" runat="server" BackColor="White" Font-Bold="False" GroupingText="Registro das Re-An�lises"  Width="100%" Font-Size="XX-Small"  CssClass="texto" Height="16px" HorizontalAlign="Left">
    <br />
                        <anthem:GridView ID="gridreanalise" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="id_analise_compartimento" CssClass="texto" Height="32px" PageSize="6">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#6193E0" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Obrigat&#243;ria">
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:CheckBox id="chk_obrigatoria" runat="server" Font-Bold="False" Enabled="False" Checked='<%# Bind("chk_obrigatoria") %>' Font-Overline="False" __designer:wfdid="w24"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="cd_analise" HeaderText="C&#243;digo" SortExpression="cd_analise" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_sigla" HeaderText="Sigla An&#225;lise" SortExpression="nm_sigla" ReadOnly="True" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Faixa Referencial" SortExpression="ds_faixa">
                                    <edititemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w9" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label><asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w10" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_faixa_referencial" runat="server" __designer:wfdid="w7" Text='<%# Bind("ds_faixa") %>' Visible="False"></asp:Label> <asp:Label id="lbl_faixa_referencia_logica" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_faixa_referencia_logica") %>' Visible="False"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_tipo_analise" HeaderText="Tipo"
                                                    SortExpression="nm_tipo_analise" ReadOnly="True" NullDisplayText="N&#227;o Cadastrada" Visible="False" >
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Resultado">
                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox id="txt_int_nr_valor" runat="server" Width="56px" __designer:wfdid="w7" Visible="False"></cc2:OnlyNumbersTextBox> <asp:RequiredFieldValidator id="rfv_txt_int_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio" CssClass="texto" Width="8px" Font-Bold="True" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_int_nr_valor" __designer:wfdid="w8" Visible="False">!</asp:RequiredFieldValidator>&nbsp; <cc3:OnlyDecimalTextBox id="txt_dec_nr_valor" runat="server" Width="56px" MaxLength="15" __designer:wfdid="w9" Visible="False" DecimalSymbol="," MaxMantissa="4" MaxCaracteristica="10"></cc3:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_dec_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio!" Font-Bold="True" ErrorMessage="O valor para an�lise deve ser preenchido!" ControlToValidate="txt_dec_nr_valor" __designer:wfdid="w10" Visible="False">!</asp:RequiredFieldValidator>&nbsp; <asp:DropDownList id="cbo_nr_valor" runat="server" Width="88px" __designer:wfdid="w11" Visible="False"></asp:DropDownList> <asp:RequiredFieldValidator id="rfv_cbo_nr_valor" runat="server" ValidationGroup="vg_analise" ToolTip="Valor obrigat�rio" Font-Bold="True" ErrorMessage="O valor da an�lise deve ser preenchido." ControlToValidate="cbo_nr_valor" __designer:wfdid="w12" Visible="False">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_analise" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w13"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor" runat="server" __designer:wfdid="w5" Text='<%# Bind("nr_valor") %>'></asp:Label> <asp:Label id="lbl_nm_valor" runat="server" __designer:wfdid="w6" Text='<%# Bind("nm_analise_logica") %>' Visible="False"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Coment&#225;rio">
                                    <edititemtemplate>
<asp:TextBox id="txt_ds_comentario" runat="server" CssClass="texto" Width="200px" MaxLength="50" __designer:wfdid="w3" Text='<%# Bind("ds_comentario") %>' TextMode="MultiLine"></asp:TextBox> 
</edititemtemplate>
                                    <itemstyle horizontalalign="Justify" width="200px" />
                                    <headerstyle horizontalalign="Center" width="200px" />
                                    <itemtemplate>
<asp:Label id="lbl_ds_comentario" runat="server" __designer:wfdid="w2" Text='<%# Bind("ds_comentario") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w9" Text='<%# Bind("nm_st_analise") %>'></asp:Label>
</edititemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                    <headerstyle horizontalalign="Center" />
                                    <itemtemplate>
<asp:Label id="lbl_nm_st_analise" runat="server" __designer:wfdid="w8" Text='<%# Bind("nm_st_analise") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_analise" >
                                    <headerstyle horizontalalign="Center" width="10%" />
                                    <itemstyle horizontalalign="Center" width="10%" />
                                </asp:CommandField>
                                <asp:TemplateField Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w3" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_inicial" runat="server" __designer:wfdid="w2" Text='<%# Bind("nr_faixa_inicial") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_faixa_final" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w16" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nr_faixa_final" runat="server" __designer:wfdid="w15" Text='<%# Bind("nr_faixa_final") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_faixa_referencia_logica" Visible="False">
                                    <edititemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_faixa_logica" runat="server" __designer:wfdid="w13" Text='<%# Bind("id_faixa_referencia_logica") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_formato_analise" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_formato_analise" runat="server" Text='<%# Bind("id_formato_analise") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_gera_ciq" Visible="False">
                                    <itemtemplate>
<asp:Label id="st_gera_ciq" runat="server" Text='<%# Bind("st_gera_ciq") %>' __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_st_original" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_st_original" runat="server" Text='<%# Bind("id_st_original") %>' __designer:wfdid="w25"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Italic="True"
        ForeColor="Red" Text="* An�lise Informativa"></asp:Label></asp:Panel>
                    </td>
                    <TD style="height: 25px; width: 10px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <TD style="width: 1px; height: 44px" >
                    </td>
                    <TD style="height: 44px" class="texto">
                        <TABLE id="Table5" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <TR>
                                <TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:image id="Image1" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp;
                                    |
                                    <asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton ID="lk_concluirBody" runat="server" ToolTip="Salvar Dados Compartimento"
                                        ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 44px; width: 10px;"  ></TD>
                </tr>
				<TR>
					<TD style="height: 19px; width: 1px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; width: 701px;">&nbsp;&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server" UpdateAfterCallBack="True"></cc1:alertmessages>
            <anthem:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="texto" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_registrar" />
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="texto" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_salvar" />
        </form>
	</body>
</HTML>
