<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_notificacao.aspx.vb" Inherits="frm_notificacao" %>

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
    <title>Notificação</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="width: 100%; height: 13px;"><STRONG>Notificação</STRONG></TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; width: 100%;">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" style="width: 100%; height: 13px" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados da Notificação</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 4px" class="texto" align=right width="23%">
                                    <strong></strong>
                                </td>
                                <TD style="HEIGHT: 4px">
                                    &nbsp;</TD>
							</TR>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
	                                <SPAN id="Span3" class="obrigatorio">*</span><STRONG> Tipo da Notificação:</strong></td>
	                            <TD class="texto">
	                                &nbsp;&nbsp;<anthem:DropDownList ID="cbo_notificacao" runat="server"
                                        CssClass="texto" AutoCallBack="True">
                                    </anthem:DropDownList>
	                                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="cbo_notificacao"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Nome do Grupo para continuar."
	                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
	                                &nbsp;&nbsp; &nbsp;&nbsp;</td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=right width="23%">
                                    <STRONG> Estabelecimento:</strong></td>
                                <TD class="texto">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server"
                                        CssClass="texto">
                                    </anthem:DropDownList>
                                    &nbsp;&nbsp;
                                    <anthem:RequiredFieldValidator ID="rfv_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        ValidationGroup="vg_salvar" Visible="False">[!]</anthem:RequiredFieldValidator>
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%"></td>
	                            <TD></td>
	                        </tr>
                            <tr>
                                <TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">
                                    Dados do Email do Remetente</td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" class="texto" align=right width="23%">
                                    <strong></strong>
                                </td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right width="23%">
                                    <SPAN id="Span1" class="obrigatorio">*</span><STRONG> Email Remetente:</strong></td>
                                <TD class="texto">
                                    &nbsp; &nbsp;<anthem:TextBox ID="txt_ds_email_remetente" runat="server" CssClass="texto"
                                        MaxLength="50" UpdateAfterCallBack="True" Width="200px"></anthem:TextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_ds_email_remetente"
                                        CssClass="texto" ErrorMessage="Preencha o campo Email do Remetente Para para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_ds_email_remetente"
                                            CssClass="texto" ErrorMessage="Formato de e-mail inválido." Font-Bold="True"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vg_salvar">[!]</anthem:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <TD class="texto" align=right width="23%">
                                </td>
                                <TD>
                                </td>
                            </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados de Email&nbsp; dos Destinatários</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
	                                <br />
	                                <anthem:GridView ID="grdEmailPara" runat="server"
	                                    AutoGenerateColumns="False"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="75%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True" UseAccessibleHeader="False" AddCallBacks="False">
	                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
	                                    <Columns>
	                                        <asp:TemplateField HeaderText="Para:">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" font-bold="True" />
	                                            <itemtemplate>
<anthem:TextBox id="txt_ds_email" __designer:dtid="3096263398523087" runat="server" CssClass="texto" Width="200px" UpdateAfterCallBack="True" __designer:wfdid="w117" MaxLength="50"></anthem:TextBox>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Email Para para continuar." ControlToValidate="txt_ds_email" __designer:wfdid="w118">[!]</anthem:RequiredFieldValidator> <anthem:RegularExpressionValidator id="RegularExpressionValidator1" __designer:dtid="3096263398523088" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Formato de e-mail inválido." ControlToValidate="txt_ds_email" __designer:wfdid="w119" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">[!]</anthem:RegularExpressionValidator> 
</itemtemplate>
	                                        </asp:TemplateField><asp:TemplateField>
                                                <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w86" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" CommandName="delete"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="id_notificacao" Visible="False" />
                                        </Columns>
                                    </anthem:GridView>
                                    <anthem:CustomValidator ID="cv_validar_faixas_grid" runat="server" Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>&nbsp;
                                    <anthem:CustomValidator ID="cv_grid" runat="server"
                                        CssClass="texto" ErrorMessage="Uma placa deve ser informada como Principal para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator><br />
                                    &nbsp;<anthem:Button ID="btn_novo_email_para" runat="server" Text="Adicionar" ToolTip="Adicionar novo Email Para." />
	                            </td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <br />
                                    <anthem:GridView ID="grdEmailCopia" runat="server"
	                                    AutoGenerateColumns="False"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="75%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True" AddCallBacks="False">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="C&#243;pia:">
                                                <itemtemplate>
<anthem:TextBox id="txt_ds_email" __designer:dtid="3096263398523087" runat="server" CssClass="texto" Width="224px" MaxLength="50" __designer:wfdid="w7"></anthem:TextBox>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Email Cópia  para continuar." ControlToValidate="txt_ds_email" __designer:wfdid="w8">[!]</anthem:RequiredFieldValidator> <anthem:RegularExpressionValidator id="RegularExpressionValidator1" __designer:dtid="3096263398523088" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Formato de e-mail inválido." ControlToValidate="txt_ds_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" __designer:wfdid="w9">[!]</anthem:RegularExpressionValidator> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CommandName="delete" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" __designer:wfdid="w86"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="id_notificacao" Visible="False" />
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp; &nbsp;<br />
                                    &nbsp;<anthem:Button ID="btn_novo_email_copia" runat="server" Text="Adicionar" ToolTip="Adicionar nova escolaridade" />
                                </td>
                            </tr>
	                        <TR>
								<TD class="texto" align="right" width="23%" style="height: 6px"></TD>
	                            <TD style="height: 6px"></TD>
	                        </TR>
                            <tr>
                                <td class="titmodulo" colspan="2" width="23%">
                                    Dados do Sistema</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <strong>Situação:</strong></td>
                                <td>
                                    &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="23%">
                                    <strong></strong></td>
                                <td>
                                    &nbsp;<anthem:Label ID="lbl_modificador" runat="server"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto">
                                    </td>
                                <td>
                                    &nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            </tr>
	                        <TR>
								<TD style="HEIGHT: 13px" class="texto" align=right width="23%"></TD>
								<TD style="HEIGHT: 13px"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px"></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD style="width: 100%; height: 13px">
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
					<TD width="1" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
