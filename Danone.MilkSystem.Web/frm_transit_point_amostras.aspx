<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transit_point_amostras.aspx.vb" Inherits="frm_transit_point_amostras" %>

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
		<title>Transit Point - Amostras da Coleta</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">

	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 28px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 28px;"><STRONG>Transit Point - Envio de Amostras de Coletas no Transit Point para Recepção
                        Danone Poços de </STRONG></TD>
					<TD style="width: 10px; height: 28px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</TD>
					<TD style="HEIGHT: 25px; width: 10px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD id="Td1" runat="server" style="font-size: 8px">
                        <br /><TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <TD style="height: 19px; width: 9px;">
                                </td>
                                <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                                    Dados do Transit Point</td>
                                <TD style="height: 19px; width: 10px;">
                                </td>
                            </tr>
                        </table>
                        <TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="95%" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none"   >
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
                                <td align="right" style="height: 22px; width: 17%;" >
                                    Número do Transit Point:</td>
                                <td style=" width:15%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_id_transit_point" runat="server"></anthem:Label></td>
                                <td style="width:13%; height: 22px;" align="right">
                                    Unidade Transit Point:</td>
                                <td style=" width:20%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_ds_unidade_transit_point" runat="server"></anthem:Label></td>
                                <td style="width: 15%; height: 22px;" align="right">
                                    Situação Transit Point:
                                </td>
                                <td style=" width:20%; height: 22px;">
                                    &nbsp;<anthem:Label ID="lbl_nm_situacao_transit_point" runat="server" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 22px;" align="right">
                                    &nbsp;<span id="Span2" class="obrigatorio"> </span>Placa Veículo Principal:</td>
                                <TD style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_ds_placa" runat="server"></anthem:Label>
                                </td>
                                <td  align="right" style="height: 22px">
                                    Nome Rota:</td>
                                <td style="height: 22px" >
                                    &nbsp;<anthem:Label ID="lbl_nm_linha" runat="server"></anthem:Label></td>
                                <td align="right" style="height: 22px">
                                    Total Volume Transit Point:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:Label ID="lbl_nr_total_litros_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
                                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Amostras de Coletas dos Pré-Romaneios &nbsp;do Transit Point:</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
                
                <TR id="tr_detalhes" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top">
                        <br />
                            
                            <anthem:GridView ID="gridAmostras" runat="server"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_pre_romaneio_amostras" PageSize="100" CellPadding="4">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w40" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<asp:CheckBox id="ck_item" runat="server" __designer:wfdid="w52" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233; Rom." />
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop. UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop Matriz" />
                                <asp:BoundField DataField="frasco1" HeaderText="Frasco Amarelo" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="frasco2" HeaderText="Frasco Azul" ReadOnly="True" />
                                <asp:BoundField DataField="frasco3" HeaderText="Frasco Branco" ReadOnly="True" />
                                <asp:BoundField DataField="frasco4" HeaderText="Frasco Vermelho" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Col.Amostra">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_situacao_coleta_amostra" runat="server" __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_situacao_tp_amostra" HeaderText="Envio" />
                                <asp:BoundField HeaderText="Motivo Descarte no TP." DataField="nm_motivo_descarte_romaneio_amostra" />
                                <asp:TemplateField HeaderText="id_tipo_frasco1" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco1" runat="server" Text='<%# Bind("id_tipo_frasco1") %>' __designer:wfdid="w7"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco2" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco2" runat="server" Text='<%# Bind("id_tipo_frasco2") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco3" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco3" runat="server" Text='<%# Bind("id_tipo_frasco3") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco4" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco4" runat="server" Text='<%# Bind("id_tipo_frasco4") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_coleta_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_coleta_amostra" runat="server" Text='<%# Bind("id_situacao_coleta_amostra") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_tp_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_tp_amostra" runat="server" Text='<%# Bind("id_situacao_tp_amostra") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_motivo_descarte_tp_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_motivo_descarte_tp_amostra" runat="server" Text='<%# Bind("id_motivo_descarte_tp_amostra") %>' __designer:wfdid="w10"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transit_point_registro" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_transit_point_registro" runat="server" Text='<%# Bind("id_transit_point_registro") %>' __designer:wfdid="w27"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_coleta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_coleta" runat="server" Text='<%# Bind("id_coleta") %>' __designer:wfdid="w53"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        <br />
                                        
                             <table width="100%">
                                <tr>
                                     <td align="left" valign="bottom" rowspan="2">
                                         &nbsp;</td>
                                     <td align="right" rowspan="2">
                                         <asp:CustomValidator ID="cv_aguardar" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_aguardar">[!]</asp:CustomValidator>
                                         <asp:CustomValidator ID="cv_descartar" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_descartar">[!]</asp:CustomValidator><asp:CustomValidator ID="cv_enviar" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_enviar">[!]</asp:CustomValidator><anthem:Button ID="btn_enviar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Enviar Amostras" ToolTip="Receber as Amostras selecionadas" ValidationGroup="vg_enviar" Visible="False" />
                                         &nbsp;&nbsp;&nbsp; &nbsp;
                                         &nbsp;&nbsp; &nbsp;
                                         <anthem:Label ID="lbl_descarte" runat="server" CssClass="texto" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" >Motivo Descarte:</anthem:Label>&nbsp;<anthem:DropDownList id="cbo_motivo_descarte" runat="server" CssClass="caixaTexto" Width="210px" Visible="False" AutoUpdateAfterCallBack="True">
                                             <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                             <asp:ListItem Value="1">N&#227;o Entregue Transportador</asp:ListItem>
                                             <asp:ListItem Value="2">Frasco Danificado</asp:ListItem>
                                         </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                             ControlToValidate="cbo_motivo_descarte" CssClass="texto" ErrorMessage="Preencha o campo Motivo do Descarte para continuar."
                                             Font-Bold="True" InitialValue="0" ToolTip="Informe o campo Motivo Descarte para continuar."
                                             ValidationGroup="vg_descartar">[!]</anthem:RequiredFieldValidator>&nbsp;
                                     <anthem:Button ID="btn_Descartar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Descartar Amostras" ToolTip="Descartar as Amostras selecionadas" ValidationGroup="vg_descartar" Visible="False" />
                                         &nbsp;&nbsp; &nbsp;</td>
                                    <td style="width: 15%;" align="left">
                                        &nbsp;<anthem:Button ID="btn_aguardar_prox_tp" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Aguardar Próx. TP" ToolTip="Aguardar Próximo TP para envio da amostra." ValidationGroup="vg_aguardar" Visible="False" />
                                         </td>
                                </tr>
                            </table>
                                       
					</TD>
					<TD style="width: 10px; height: 195px;">&nbsp;</TD>
				</TR>


                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD style="HEIGHT: 19px" class="titmodulo" align="left" >
                        Amostras de Coletas de Pré-Romaneios não Enviadas (de Outros Transit Points)</td>
                    <TD style="height: 19px; width: 10px;">
                    </td>
                </tr>
                
                	<TR id="tr1" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top">
                       <br />
                            
                            <anthem:GridView ID="gridOutrasAmostras" runat="server"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_pre_romaneio_amostras" PageSize="100" CellPadding="4">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
<asp:CheckBox id="ck_header_oa" runat="server" __designer:wfdid="w43" OnCheckedChanged="ck_header_oa_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<asp:CheckBox id="ck_item_oa" runat="server" __designer:wfdid="w42" OnCheckedChanged="ck_item_oa_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233; Rom." />
                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                <asp:BoundField DataField="st_leite_total_rejeitado" HeaderText="Vol.Total Rejeitado" />
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop. UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop Matriz" />
                                <asp:BoundField DataField="frasco1" HeaderText="Frasco Amarelo" ReadOnly="True">
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="frasco2" HeaderText="Frasco Azul" ReadOnly="True" />
                                <asp:BoundField DataField="frasco3" HeaderText="Frasco Branco" ReadOnly="True" />
                                <asp:BoundField DataField="frasco4" HeaderText="Frasco Vermelho" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Col.Amostra">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_situacao_coleta_amostra_oa" runat="server"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_situacao_tp_amostra" HeaderText="Envio" />
                                <asp:BoundField HeaderText="Motivo Descarte no TP." DataField="nm_motivo_descarte_romaneio_amostra" />
                                <asp:TemplateField HeaderText="id_tipo_frasco1" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco1_oa" runat="server" Text='<%# Bind("id_tipo_frasco1") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco2" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco2_oa" runat="server" Text='<%# Bind("id_tipo_frasco2") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco3" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco3_oa" runat="server" Text='<%# Bind("id_tipo_frasco3") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tipo_frasco4" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_tipo_frasco4_oa" runat="server" Text='<%# Bind("id_tipo_frasco4") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_coleta_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_coleta_amostra_oa" runat="server" Text='<%# Bind("id_situacao_coleta_amostra") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_tp_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_tp_amostra_oa" runat="server" Text='<%# Bind("id_situacao_tp_amostra") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_motivo_descarte_tp_amostra" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_motivo_descarte_tp_amostra_oa" runat="server" Text='<%# Bind("id_motivo_descarte_tp_amostra") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transit_point_registro" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_transit_point_registro_oa" runat="server" Text='<%# Bind("id_transit_point_registro") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="id_coleta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_coleta_oa" runat="server" Text='<%# Bind("id_coleta") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>

                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        <br />
                                        
                             <table width="100%">
                                <tr>
                                     <td align="left" valign="bottom" rowspan="2">
                                         &nbsp;</td>
                                     <td align="right" rowspan="2">
                                         &nbsp;<asp:CustomValidator ID="cv_descartar_oa" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_descartar_oa">[!]</asp:CustomValidator><asp:CustomValidator ID="cv_enviar_oa" runat="server" CssClass="texto" ErrorMessage="CustomValidator"
                                             ForeColor="White" ValidationGroup="vg_enviar_oa">[!]</asp:CustomValidator><anthem:Button ID="btn_enviar_oa" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Enviar Amostras" ToolTip="Enviar as Amostras selecionadas" ValidationGroup="vg_enviar_oa" Visible="False" />
                                         &nbsp;&nbsp;&nbsp; &nbsp;
                                         &nbsp;&nbsp; &nbsp;
                                         <anthem:Label ID="lbl_motivo_descarte_oa" runat="server" CssClass="texto" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" >Motivo Descarte:</anthem:Label>&nbsp;
                                         <anthem:DropDownList id="cbo_motivo_descarte_oa" runat="server" CssClass="caixaTexto" Width="210px" Visible="False" AutoUpdateAfterCallBack="True">
                                             <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                             <asp:ListItem Value="1">N&#227;o Entregue Transportador</asp:ListItem>
                                             <asp:ListItem Value="2">Frasco Danificado</asp:ListItem>
                                         </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                             ControlToValidate="cbo_motivo_descarte_oa" CssClass="texto" ErrorMessage="Preencha o campo Motivo do Descarte para continuar."
                                             Font-Bold="True" InitialValue="0" ToolTip="Informe o campo Motivo Descarte para continuar."
                                             ValidationGroup="vg_descartar_oa">[!]</anthem:RequiredFieldValidator></td>
                                    <td style="width: 15%;" align="left">
                                        &nbsp;<anthem:Button ID="btn_descartar_oa" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Descartar Amostras" ToolTip="Descartar as Amostras selecionadas" ValidationGroup="vg_descartar_oa" Visible="False" /></td>
                                </tr>
                            </table>
                                       
					</TD>
					<TD style="width: 10px; height: 195px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="HEIGHT: 9px" class="texto" align=right width="23%" colspan=3>
                    </td>
                </tr>
                <tr>
                    <TD style="HEIGHT: 25px; width: 9px;">
                        &nbsp;</td>
                    <TD style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" class="faixafiltro1a">
                        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                            ID="lk_voltar_footer" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;</td>
                    <TD style="HEIGHT: 25px; width: 10px;">
                        &nbsp;</td>
                </tr>

                <tr>
                    <TD style="width: 9px">
                        &nbsp;</td>
                    <TD>
                        &nbsp;</td>
                    <TD style="width: 10px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_descartar" />
             <asp:ValidationSummary ID="validatorSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_enviar" />
            &nbsp;&nbsp;
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_aguardar" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_descartar_oa" />
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_enviar_oa" />
            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_aguardar_oa" />
            &nbsp;&nbsp;
		</form>
	</body>
</HTML>
