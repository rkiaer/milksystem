<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_ciq_documentos.aspx.vb" Inherits="lst_romaneio_ciq_documentos" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Gerenciamento Documentos Incidente Qualidade</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Gerenciamento Documentos Incidente Qualidade</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD  style="height: 12px; width: 15%;"></TD>
								<TD style="height: 12px; width: 20%;"></TD>
                                <td style="height: 12px; width: 13%;">
                                </td>
                                <td style="height: 12px; width: 20%;">
                                </td>
                                <td style="width: 13%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" class="texto" style="height: 23px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento<strong>:</strong></td>
                                <td style="height: 23px" >
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="true"
                                        AutoPostBack="false" AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="Escolha o Estabelecimento para continuar."
                                        Font-Bold="True" InitialValue="0" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                                <td style="height: 23px" align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Entrada:</td>
                                <td style="height: 23px" >
                                    &nbsp; <cc2:onlydatetextbox id="txt_dt_hora_entrada_ini" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" datemask="DayMonthYear" width="80px"></cc2:onlydatetextbox>
                                    à
                                    <cc2:onlydatetextbox id="txt_dt_hora_entrada_fim" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" datemask="DayMonthYear" width="80px"></cc2:onlydatetextbox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_hora_entrada_ini" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="False" ToolTip="A data inicial do período deve ser informada." ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_hora_entrada_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada." ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_hora_entrada_fim"
                                                ControlToValidate="txt_dt_hora_entrada_ini" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date" ValidationGroup="vg_pesquisa">[!]</anthem:CompareValidator>
</td>
                                <td style="height: 23px" align="right">
                                    <span style="color: #ff0000">*</span>Emitente:</td>
                                <td style="height: 23px">
                                    &nbsp;<anthem:DropDownList ID="cbo_emitente" runat="server" CssClass="texto" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load">
<asp:ListItem Selected="True" Value="P">Produtor</asp:ListItem>
<asp:ListItem Value="C">Cooperativa</asp:ListItem>
</anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_emitente" ErrorMessage="O emitente deve ser informado!"
                                        InitialValue="[Selecione]" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Tipo de Incidente:&nbsp;<span style="color: #ff0000"></span></td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_ds_tipo_incidente" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                        <asp:ListItem Value="1">CIQ</asp:ListItem>
                                        <asp:ListItem Value="2">CIQP</asp:ListItem>
                                        <asp:ListItem Value="3">CIQT</asp:ListItem>
                                        <asp:ListItem Value="4">CIQR</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </anthem:DropDownList></td>
                                <td style="height: 20px" align="right">
                                    Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:onlynumberstextbox id="txt_id_romaneio" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" width="64px"></cc3:onlynumberstextbox>
                                </td>
                                <td style="height: 20px" align="right">
                                    Nr CIQ:</td>
                                <td style="height: 20px">
                                    &nbsp;<cc3:onlynumberstextbox id="txt_nr_ciq" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" width="120px"></cc3:onlynumberstextbox></td>
                            </tr>
							<TR>
								<TD style="height: 33px"></TD>
								<TD align="right" colspan="5" style="height: 33px" valign="bottom">
                                    &nbsp;
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" AutoUpdateAfterCallBack="True" ValidationGroup="vg_load" Visible="False" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px; height: 24px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 24px" valign="middle">
                        &nbsp;&nbsp;</td>
                    <td style="height: 24px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 5px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 5px">&nbsp;</TD>
					<TD style="height: 5px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="3"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Det." ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="btn_detalhe" runat="server" ImageUrl="~/img/icon_preview.gif" Text="Select" __designer:wfdid="w17" CausesValidation="False" CommandName="Select"></asp:ImageButton>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" ReadOnly="True" />
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" ReadOnly="True" />
                                                <asp:BoundField DataField="ds_placa_compartimento" HeaderText="Placa Comp." />
                                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp." ReadOnly="True" />
                                                <asp:BoundField DataField="ds_incidente" HeaderText="Tipo" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="N&#186;">
                                                    <itemtemplate>
<asp:HyperLink id="hl_nr_incidente" runat="server" Text='<%# Eval("id_romaneio_compartimento") %>' __designer:wfdid="w16" NavigateUrl='<%# Eval("id_romaneio_compartimento", "~/frm_relatorio_ciq.aspx?id_romaneio_compartimento={0}") %>' Target="_blank"></asp:HyperLink> 
</itemtemplate>
                                                </asp:TemplateField>
                                               <asp:BoundField DataField="nr_obrigatorio" HeaderText="Doc Obrig" ReadOnly="True" >
                                                   <itemstyle horizontalalign="Center" />
                                               </asp:BoundField>
                                                <asp:BoundField DataField="nr_obrigatorioanexo" HeaderText="Doc Obrig Anexos" />
                                                <asp:BoundField DataField="totaldocanexo" HeaderText="Doc Anexos" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w402" Text CausesValidation="False" CommandName="editar"></asp:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio" runat="server" __designer:wfdid="w400" Text='<%# Bind("id_romaneio") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio_uproducao" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio_uproducao" runat="server" __designer:wfdid="w398" Text='<%# Bind("id_romaneio_uproducao") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_romaneio_compartimento" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio_compartimento" runat="server" __designer:wfdid="w395" Text='<%# Bind("id_romaneio_compartimento") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_ciq" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_ciq" runat="server" __designer:wfdid="w420" Text='<%# Bind("id_ciq") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_responsavel_ciq" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_responsavel_ciq" runat="server" __designer:wfdid="w419" Text='<%# Bind("st_responsavel_ciq") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" __designer:wfdid="w417" Text='<%# Bind("id_transportador") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="Red" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" /><PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
								<TR id="tr_detalhes" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top">
					<anthem:Panel ID="pnl_romaneio" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes do Tipo Incidente" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%" class="borda" style="border-right: 1px ridge; border-bottom: #f0f0f0 1px ridge" id="TABLE3"  cellpadding="0" cellspacing="0">
                                <tr>
                                     <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px;" align="left">
                                         &nbsp;
                                        <anthem:Label ID="lbl_romaneio" runat="server" CssClass="texto">Romaneio:</anthem:Label>&nbsp;<anthem:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_caderneta" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_rota" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_situacao" runat="server" CssClass="texto"></anthem:Label></td><td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">  &nbsp;<anthem:Label
                                             ID="lbl_transbordo" runat="server" CssClass="texto">Transbordo: SIM</anthem:Label>
                                         &nbsp; &nbsp;
                                         <anthem:Label ID="lbl_transit" runat="server" CssClass="texto">Transit Point:</anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_nr_ciq" runat="server" CssClass="texto"></anthem:Label></td>
                                                                       <td style="height: 25px;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>

                                </tr>
                                <tr>
                                    <td align="left" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_nome" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px" colspan="2">
                                        &nbsp;<anthem:Label ID="lbl_nome2" runat="server" CssClass="texto"></anthem:Label>&nbsp;</td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_resp" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="right" style="height: 25px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                    <td align="right" style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                        <anthem:GridView ID="gridDoc" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" PageSize="20" UpdateAfterCallBack="True"
                            Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_tipo_incidente" HeaderText="Tipo Incidente" />
                                <asp:BoundField HeaderText="Docto Avulso" />
                                <asp:TemplateField HeaderText="Docto Cadastro">
                                    <itemtemplate>
<asp:HyperLink id="hl_download_cadastro" runat="server" ForeColor="Blue" Text='<%# bind("nm_documento_cadastro") %>' __designer:wfdid="w21" Font-Underline="True"></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_extensao" HeaderText="Extens&#227;o" ReadOnly="True" />
                                <asp:BoundField DataField="st_obrigatorio" HeaderText="Obrigat&#243;rio" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Arquivo Anexado">
                                    <itemtemplate>
<asp:HyperLink id="hl_download" runat="server" ForeColor="Blue" Text='<%# bind("nm_documento") %>' __designer:wfdid="w14" Font-Underline="True"></asp:HyperLink> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_romaneio_ciq_documentos" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio_ciq_documentos" runat="server" Text='<%# Bind("id_romaneio_ciq_documentos") %>' __designer:wfdid="w22"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_ciq_documentos" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_ciq_documentos" runat="server" Text='<%# Bind("id_ciq_documentos") %>' __designer:wfdid="w17"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>
                                       
					</anthem:Panel>				
					</TD>
					<TD style="width: 10px; height: 195px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
		</form>
	</body>
</HTML>
