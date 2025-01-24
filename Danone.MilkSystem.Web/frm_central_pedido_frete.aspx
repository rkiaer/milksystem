<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_frete.aspx.vb" Inherits="frm_central_pedido_frete" %>

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
   <title>Pedido - Atualização Frete</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" >
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px; height: 29px;">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); height: 29px; font-size: x-small;">Pedido
                        <anthem:Label AutoUpdateAfterCallBack="True" ID="lbl_titulo" runat="server" UpdateAfterCallBack="True" Visible="False">Parceiro de Frete</anthem:Label></TD>
					<TD style="width: 12px; height: 29px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    &nbsp;
                                    &nbsp;&nbsp;
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<TD vAlign="top" class="texto">
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" style="font-size: x-small">
                            <tr>
                                <TD class="texto" align="center" style="height: 22px" colspan="2">
                                     <table border="0" width="100%">
  							            <tr>
								            <TD style="HEIGHT: 22px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Pedido de Insumos</TD>
							            </tr>
                                      <tr>
                                            <td style="width: 13%; height: 21px; font-size: x-small;" align="right">
                                                Nr Pedido:</td>
                                            <td align="left" style="height: 21px; font-size: x-small; width: 20%;">
                                                &nbsp;<anthem:Label ID="lbl_id_central_pedido" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="width: 13%; height: 21px; font-size: x-small;" align="right">
                                                Dt Pedido:</td>
                                            <td align="left" style="height: 21px; font-size: x-small; width: 21%;">
                                                &nbsp;<anthem:Label ID="lbl_dt_pedido" runat="server"
                                                    UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="width: 13%; height: 21px; font-size: x-small;" align="right">
                                                Situação:</td>
                                            <td style="width: 17%; height: 21px; font-size: x-small;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_situacao_pedido" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                        <tr  style="font-size: x-small;">
                                            <td style="height: 21px; font-size: x-small;" align="right">
                                                Parcelamento:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="height: 21px">
                                                Tipo de Frete:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_frete" runat="server"
                                                    CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True" Enabled="False">
                                                    <asp:ListItem Value="C">CIF</asp:ListItem>
                                                    <asp:ListItem Value="D">FOB-D</asp:ListItem>
                                                    <asp:ListItem Value="I">FOB-I</asp:ListItem>
                                                    <asp:ListItem Selected="True">[Sel.]</asp:ListItem>
                                                </anthem:DropDownList>&nbsp;<anthem:Button ID="btn_salvar_tipo_frete" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Text="Salvar"
                                                    ValidationGroup="vg_salvar" /><anthem:CustomValidator ID="cv_salvar" runat="server"
                                                        AutoUpdateAfterCallBack="True" ForeColor="White" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></td>
                                            <td align="right" style="height: 21px">
                                                Total Pedido:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_total_pedido" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
 
   							<TR style="font-size: x-small;">
								<TD style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6" valign="bottom">Dados do Produtor / Propriedade 
                                </TD>
							</TR>
                                       <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                Produtor:</td>
                                            <td align="left" colspan="1" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_nm_produtor" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Prop.:
                                                <anthem:Label ID="lbl_propriedade" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label>
                                                </td>
                                            <td align="center" style="height: 21px">
                                                Prop.Matriz:
                                                <anthem:Label ID="lbl_propriedade_matriz" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                UF/Cidade:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_uf_cidade" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
   							<TR style="font-size: x-small;">
								<TD  style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6" valign="bottom">Dados do Parceiro de Insumos</TD>
							</TR>
                                       <tr style="font-size: x-small;" >
                                            <td style=" height: 21px;" align="right">
                                                Parceiro:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_parceiro" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                CNPJ/CPF:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_cnpj_cpf_fornecedor" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Frete CIF Parceiro:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_cif_parceiro" runat="server"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
   							<TR style="font-size: x-small;">
								<TD style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6"> Dados do Item</TD>
							</TR>
                            <tr style="font-size: x-small;">
                                            <td style=" height: 21px;" align="right">
                                                Cód. Item:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_cd_item" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Descrição:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_item_nm" runat="server" CssClass="texto"
                                                    Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Unidade:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_item_un" runat="server"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                     <tr style="font-size: x-small;" >
                                            <td style=" height: 21px;" align="right">
                                                Categoria:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_item_categoria" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Embalagem:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_tipo_embalagem" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Qtde:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_nr_qtde" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                   <tr style="font-size: x-small;" >
                                            <td style=" height: 21px;" align="right">
                                                Vl Unitário:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_vl_unitario" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Vl Sacaria:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_sacaria" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Vl Frete:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_frete" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>

                                    </table>
                                </td>
                       </tr>
	                    </TABLE>
                    </TD>
					<TD ></TD>
				</TR>
				<tr>
				    <td></td>
				    <td class="texto">
				    <table  width="100%" >
				            <TR >
	                            <TD class="titmodulo" align="left" style="font-size: x-small; height: 14px;" colspan="3">
                                    Pedidos de Frete&nbsp;</TD>
							</TR>
							<TR >
								<TD style="HEIGHT: 15px" align="center" class="texto" colspan="3" >
                                    <br />
                                    <anthem:GridView ID="gridpedidos" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CellPadding="3" CssClass="texto" Font-Names="Verdana"
                                        Font-Size="X-Small" ForeColor="#333333" PageSize="100" UpdateAfterCallBack="True"
                                        Visible="False" Width="98%" DataKeyNames="id_central_pedido">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                            ForeColor="White" />
                                        <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Center" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="dt_pedido" DataFormatString="{0:d}" HeaderText="Data"
                                                ReadOnly="True">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Pedido">
                                                <itemtemplate>
<anthem:HyperLink id="hl_id_pedido" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="textohlink" Text='<%# bind("id_central_pedido") %>' ToolTip="Visualizar Pedido" Font-Underline="True" __designer:wfdid="w61" Target="_blank"></anthem:HyperLink> 
</itemtemplate>
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ds_abreviado_fornecedor" HeaderText="Transportador">
                                                <itemstyle horizontalalign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ds_parcelas" HeaderText="Parcelado?">
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nr_frete" DataFormatString="{0:n2}" HeaderText="Valor Frete">
                                                <itemstyle horizontalalign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:n2}" HeaderText="Total Ped.Frete">
                                                <itemstyle horizontalalign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Situa&#231;&#227;o">
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Cancelar?">
                                                <itemtemplate>
<SPAN style="COLOR: #ff0000">*</SPAN><anthem:DropDownList id="cbo_pedido_cancelar_motivo" __designer:dtid="2814754062073871" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w62"></anthem:DropDownList><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" CssClass="texto" ValidationGroup="vg_grid" Font-Bold="False" ToolTip="O motivo do cancelamento do pedido deve ser informado!" InitialValue="0" ErrorMessage="O motivo do cancelamento do pedido deve ser informado!" ControlToValidate="cbo_pedido_cancelar_motivo" __designer:wfdid="w63">[!]</asp:RequiredFieldValidator>&nbsp;<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_excluir.gif" ValidationGroup="vg_grid" ToolTip="Cancelar Pedido" __designer:wfdid="w64" CommandArgument='<%# bind("id_central_pedido") %>' OnClientClick="if (confirm('Deseja realmente cancelar o pedido?' )) return true;else return false;" OnClick="btn_salvar_Click"></asp:ImageButton> 
</itemtemplate>
                                                <itemstyle horizontalalign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="E-mail">
                                                <itemtemplate>
<anthem:ImageButton id="btn_envio_email" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_email.gif" CssClass="texto" ToolTip="Enviar Email de Cancelamento ao Parceiro" __designer:wfdid="w25" CommandArgument='<%# bind("id_central_pedido") %>' OnClientClick="if (confirm('Enviar email de cancelamento ao Parceiro?' )) return true;else return false;" CommandName="EnviarEmail"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_situacao_pedido" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_id_situacao_pedido" runat="server" Text='<%# Bind("id_situacao_pedido") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_pedido_cancelar_motivo" Visible="False">
                                                <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("id_pedido_cancelar_motivo") %>' __designer:wfdid="w134"></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_pedido_cancelar_motivo" runat="server" Text='<%# Bind("id_pedido_cancelar_motivo") %>' __designer:wfdid="w133"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                                <edititemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("id_fornecedor") %>' __designer:wfdid="w164"></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w163"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="lbl_nm_pedido_cancelar_motivo" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_nm_pedido_cancelar_motivo" runat="server" Text='<%# Bind("nm_pedido_cancelar_motivo") %>' __designer:wfdid="w166"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </anthem:GridView>
                                </TD>
							</TR>
					</TABLE>
				</td>
				<td></td>
				</tr>
				
				<tr runat="server" id="tr_transportador" visible="false">
				<td></td>
				<td>
				    <table width="100%">
				        <tr>
	                        <td style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Transportador</td>
	                    </tr>
                        <tr class="texto">
                            <td align="right" style="height: 24px; font-size: x-small; width: 13%;">
                                <span style="color: #ff0000">*</span>Transportador:</td>
                            <td align="left" style="height: 24px; font-size: x-small; width: 28%;">
                                &nbsp;<anthem:DropDownList ID="cbo_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto"
                                    UpdateAfterCallBack="True">
                                </anthem:DropDownList><anthem:RequiredFieldValidator ID="rf_transportador" runat="server"
                                    AutoUpdateAfterCallBack="True" ControlToValidate="cbo_transportador"
                                    Enabled="False" ErrorMessage="Preencha o campo Tranportador Central para continuar."
                                    InitialValue="0" ToolTip="O transportador deve ser informado!" ValidationGroup="vg_pedido">[!]</anthem:RequiredFieldValidator></td>
                            <td align="left" style="height: 24px; font-size: x-small;">
                                <anthem:ImageButton ID="btn_lupa_frete_valor" runat="server" AutoUpdateAfterCallBack="true"
                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                    OnClick="btn_lupa_frete_valor_Click" ToolTip="Buscar Valores Frete Transportador"
                                    Width="15px" />&nbsp; Vl Frete:
                                <cc6:OnlyDecimalTextBox ID="txt_nr_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13"
                                    MaxMantissa="2" OnTextChanged="txt_nr_frete_TextChanged" 
                                    UpdateAfterCallBack="True" Width="65px" AutoCallBack="True" style="text-align: right"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="rf_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    ControlToValidate="txt_nr_frete" Enabled="False" ErrorMessage="O valor de frete deve ser informado."
                                    ToolTip="O valor de frete deve ser informado!" ValidationGroup="vg_pedido">[!]</anthem:RequiredFieldValidator>
                                <anthem:Label ID="lbl_inf_frete" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False"
                                    Font-Italic="True" Font-Size="9px" ForeColor="Red" 
                                    UpdateAfterCallBack="True"></anthem:Label></td>
                            <td align="right" style="height: 24px; font-size: x-small;">
                                &nbsp; Total Pedido Frete:</td>
                            <td align="left" style="height: 24px; font-size: x-small; width: 10%;">
                                &nbsp;<anthem:Label ID="lbl_total_frete" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                    Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            <td> 
                                <anthem:Button ID="btn_gerar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Text="Gerar Pedido"
                                    ValidationGroup="vg_pedido" /><anthem:CustomValidator ID="cv_pedido_itens" runat="server"
                                        AutoUpdateAfterCallBack="True" ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator></td>
                        </tr>
                        <tr class="texto">
                            <td align="right" style="height: 5px; ">
                                </td>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left" colspan="4">
                                &nbsp; &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
						<TR>
								<TD style="HEIGHT: 15px" align="center" colspan="6" class="texto">
					<anthem:Panel ID="pnl_frete" runat="server" BackColor="White"  HorizontalAlign="Center" Width="98%" AutoUpdateAfterCallBack="True" Visible="False" GroupingText="Tabela de Frete">
                                              <table width="98%">
                                <tr>
                                     <td  align="left" class="titmodulo">
                                         &nbsp;<anthem:Label ID="lbl_detalhe_item_frete" runat="server" AutoUpdateAfterCallBack="True" Style="vertical-align: bottom;
                                             text-align: left" UpdateAfterCallBack="True">Frete para o ITEM XXX - XXXXXXX</anthem:Label></td>
                                   <td  align="center">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>
                                </tr>
                            </table>

                                    <anthem:GridView ID="gridfrete" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None"
                                        PageSize="100" UpdateAfterCallBack="True" Width="97%" AutoUpdateAfterCallBack="True" DataKeyNames="id_central_tabela_frete_veiculos">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                            ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                                            ForeColor="White" Height="23px" HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="X-Small" ForeColor="White"
                                            HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="pessoa_abreviado" HeaderText="Transportador">
                                                <itemstyle horizontalalign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cd_uf_origem" HeaderText="UF">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nm_cidade_origem" HeaderText="Cidade Ori.">
                                                <itemstyle horizontalalign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nm_veiculocentralcompras" HeaderText="Ve&#237;culo">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ds_capacidade" HeaderText="Capacidade">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="cd_uf_destino" HeaderText="UF Dest.">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nm_cidade_destino" HeaderText="Cidade Dest.">
                                                <itemstyle horizontalalign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nr_valor_frete" HeaderText="Valor" DataFormatString="{0:N2}">
                                                <itemstyle horizontalalign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="dt_cotacao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Cota&#231;&#227;o">
                                                <headerstyle horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <headertemplate>
&nbsp;
</headertemplate>
                                                <itemtemplate>
<asp:ImageButton id="img_selecionar" onclick="img_selecionar_Click" runat="server" ImageUrl="~/img/icon_ok.gif" CommandName="selecionar"></asp:ImageButton>&nbsp; 
</itemtemplate>
                                                <headerstyle width="3%" horizontalalign="Center" />
                                                <itemstyle horizontalalign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <RowStyle BackColor="#EFF3FB" />
                                    </anthem:GridView>
                                    					</anthem:Panel>				

                                    </TD>
							</TR>

				    </table>
                    <br />
				
				</td>
				<td></td>
				</tr>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" vAlign="middle" align="left" background="img/faixa_filro.gif">
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>&nbsp;
            <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_grid" />
            &nbsp;&nbsp;
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pedido" />
           <anthem:HiddenField ID="hf_sel_id_item" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_sel_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
