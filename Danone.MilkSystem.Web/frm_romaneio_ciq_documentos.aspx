<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_ciq_documentos.aspx.vb" Inherits="frm_romaneio_ciq_documentos" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Controle de Documentos do Incidente de Qualidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Controle de Incidente de Qualidade - Anexação de Documentos</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 26px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</TD>
					<TD style="HEIGHT: 26px">&nbsp;</TD>
				</TR>
								<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td1" runat="server"  class="texto" >
                        <br />
                        <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 9px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Incidente de Qualidade</td>
                                <TD style="height: 19px; width: 10px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table5" cellSpacing="0" cellPadding="0" width="95%" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"   >
                            <TR>
                                <TD  style="height: 12px; ">
                                </td>
                                <TD style="height: 12px">
                                </td>
                                <td style="height: 12px" align="right">
                                </td>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
                                <td style=" height: 12px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px; width: 12%;" >
                                    Romaneio:</td>
                                <td style=" width:15%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_id_romaneio" runat="server"></anthem:Label></td>
                                <td style="width:13%; height: 22px;" align="right">
                                    Data Entrada:</td>
                                <td style=" width:20%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_dt_entrada" runat="server"></anthem:Label></td>
                                <td style="width: 15%; height: 22px;" align="right">
                                    <strong><span style="color: #ff0000"></span></strong>Placa Principal:
                                </td>
                                <td style=" width:25%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_placa" runat="server" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <anthem:label id="lbl_rota" runat="server" updateaftercallback="True" autoupdateaftercallback="True"></anthem:label>
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 22px;" align="right">
                                    Placa Comp.:</td>
                                <TD style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_ds_placa" runat="server"></anthem:Label>
                                </td>
                                <td  align="right" style="height: 22px">
                                    Compartimento:</td>
                                <td style="height: 22px" >
                                    &nbsp;<anthem:Label ID="lbl_compartimento" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 22px">
                                    Situação Romaneio:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:label id="lbl_situacao" runat="server"></anthem:label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    Tipo Incidente:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:label id="lbl_tipo_incidente" runat="server"></anthem:label></td>
                                <td align="right" style="height: 22px">
                                    Responsável Incidente:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:label id="lbl_responsavel" runat="server" autoupdateaftercallback="True"
                                        updateaftercallback="True"></anthem:label></td>
                                <td align="right" style="height: 22px">
                                    Transportador:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:label id="lbl_transportador" runat="server"></anthem:label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    <anthem:label id="lbl_label" runat="server" updateaftercallback="True"></anthem:label>
                                </td>
                                <td colspan="3" style="height: 22px">
                                    &nbsp;<anthem:label id="lbl_nome" runat="server" updateaftercallback="True"></anthem:label></td>
                                <td align="right" style="height: 22px">
                                </td>
                                <td style="height: 22px">
                                </td>
                            </tr>
                        </table>
					</TD>
					<TD  >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="titmodulo"  align="left">
                        Documentos Anexados:</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; " class="texto">&nbsp;</TD>
					<TD class="texto">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" class="borda">
							<TR>
								<TD   align="right" class="texto" style="width: 12%; height: 24px;">
                                    Tipo Documento:</td>
                                <TD style="height: 24px" >
                                    &nbsp;<anthem:DropDownList ID="cbo_tipo_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" AutoPostBack="True"></anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_tipo_documento" CssClass="texto" ErrorMessage="Escolha o Tipo de Documento para anexar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vganexar" ToolTip="Selecione o Tipo Documento para anexar.">[!]</anthem:RequiredFieldValidator></td>
                                <TD align="left" colspan="2" style="width: 10%; height: 24px">
                                    &nbsp;<anthem:Image ID="img_obrigatorio" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/ico_chk_false.gif" />Doc. Obrigatório</td>
                                <td align="center" style="height: 24px">
                                    &nbsp;<anthem:HyperLink ID="hl_documento" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True">[hl_documento]</anthem:HyperLink></td>
                                <td align="left" style="height: 24px">
                                    <span style="color: #ff0000"><strong>*</strong></span>Nome Documento Exibição:
                                    <anthem:TextBox ID="txt_nm_documento" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"></anthem:TextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_nm_documento" CssClass="texto" ErrorMessage="Escolha o Nome do Documento para continuar."
                                        Font-Bold="True" ValidationGroup="vganexar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <TD  style="HEIGHT: 28px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Selecione Documento:</td>
                                <td align="left" colspan="5">
                                    &nbsp;<anthem:FileUpload ID="fup_documento" runat="server" CssClass="texto" Width="70%" AutoUpdateAfterCallBack="True"  /><anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fup_documento"
                                        CssClass="texto" ErrorMessage="Escolha o arquivo para continuar." Font-Bold="True" AutoUpdateAfterCallBack="True" ValidationGroup="vganexar">[!]</anthem:RequiredFieldValidator><span style="color: #ff0000"></span></td>
                           </tr>
                            <tr>
                                <td align="center" colspan="2" valign="bottom">
                                    &nbsp;&nbsp;
                                    <anthem:Label ID="lbl_msg" runat="server" Text="Arquivo Anexado com Sucesso!" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Font-Bold="False" Font-Italic="True" ForeColor="Red"></anthem:Label>&nbsp;
                                    &nbsp;&nbsp; &nbsp;</td>
								<TD align="right">
                                    </TD>
								<TD align="right" colspan="2">
                                    &nbsp;&nbsp;&nbsp;
                                </TD>
                                <td align="right" colspan="1">
                                    &nbsp;<anthem:CustomValidator ID="cv_anexar" runat="server" ForeColor="White" ValidationGroup="vganexar">{!]</anthem:CustomValidator><anthem:Button ID="btn_anexar" runat="server" Text="Anexar Documento" ValidationGroup="vganexar" CssClass="texto" /></td>
                            </tr>
						</TABLE>
				</TD>
					<TD >&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%"  PageSize="200" AddCallBacks="False" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_ciq_documentos">
<FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"></FooterStyle>

<HeaderStyle HorizontalAlign="Left" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"></PagerStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
<Columns>
<asp:BoundField DataField="ds_tipo_incidente" HeaderText="Tipo Incidente"></asp:BoundField>
<asp:TemplateField HeaderText="Nome do Documento"><ItemTemplate>
<asp:Label id="lbl_nm_documento" runat="server" Text='<%# Bind("nm_documento") %>' __designer:wfdid="w12"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="nm_extensao" HeaderText="Extens&#227;o" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="st_obrigatorio" HeaderText="Obrigat&#243;rio" ReadOnly="True"></asp:BoundField>
<asp:TemplateField HeaderText="Arquivo"><ItemTemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Font-Underline="True" __designer:wfdid="w14">Clique aqui para fazer o download</asp:HyperLink> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Excluir Documento" OnClientClick="if (confirm('Deseja realmente excluir este documento de controle de incidente de qualidade?' )) return true;else return false;" CommandName="delete" CommandArgument='<%# bind("id_romaneio_ciq_documentos") %>' ImageAlign="Baseline" __designer:wfdid="w13"></anthem:ImageButton> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
</anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vganexar" />
		</form>
	</body>
</HTML>
