<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido.aspx.vb" Inherits="frm_central_pedido" %>

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
   <title>Pedido</title>
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
                                    <anthem:LinkButton ID="lk_atualizar_frete" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" Style="vertical-align: bottom" ToolTip="Atualização de frete"
                                        ValidationGroup="vg_atualizarfrete" Visible="False">Atualizar Frete</anthem:LinkButton>
                                    | &nbsp;
                                    <anthem:Image ID="img_notificacao" runat="server" ImageUrl="~/img/ico_email.gif" Visible="False" AutoUpdateAfterCallBack="True" CssClass="texto" />
                                    <anthem:LinkButton ID="lk_email_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" Enabled="False" ToolTip="Envio do Pedido ao Email do Produtor">Email Produtor</anthem:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;<anthem:Image ID="img_parceiro" runat="server" ImageUrl="~/img/ico_email.gif" Visible="False" AutoUpdateAfterCallBack="True" CssClass="texto" />&nbsp;
                                    <anthem:LinkButton ID="lk_email_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Envio do Pedido ao Email do Parceiro" Enabled="False">Email Parceiro</anthem:LinkButton>
                                    &nbsp;&nbsp;
                                    <anthem:Image ID="img_parceiro_frete" runat="server" ImageUrl="~/img/ico_email.gif" Visible="False" AutoUpdateAfterCallBack="True" CssClass="texto" />&nbsp;
                                    <anthem:LinkButton ID="lk_email_parceiro_frete" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Envio do Pedido ao Email do Parceiro de Frete" Enabled="False">Email Parceiro Frete</anthem:LinkButton>&nbsp;|
                                    <anthem:LinkButton ID="lk_gerar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Gerar Pedido" ValidationGroup="vg_pedido" Enabled="False">Finalizar Pedido</anthem:LinkButton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" class="texto">
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" style="font-size: x-small">
                            <tr>
                                <TD class="texto" align="center" style="height: 22px" colspan="2">
                                     <table border="0" width="100%">
  							            <tr>
								            <TD style="HEIGHT: 22px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Pedido</TD>
							            </tr>
                                      <tr runat="server" id="tr_header2" visible="true">
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
                                                Estabelecimento:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_estabelecimento" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td align="right" style="height: 21px">
                                                Total Pedido:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_total_pedido" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="height: 21px">
                                                Total Notas Incluídas:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_total_notas" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                    <anthem:CustomValidator ID="cv_parcelamento" runat="server" AutoUpdateAfterCallBack="True"
                                                        ForeColor="White" ValidationGroup="vg_atualizar_parcelamento">[!]</anthem:CustomValidator>Parcelamento:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:DropDownList ID="cbo_parcelamento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" Enabled="False" AutoCallBack="True" >
                                                        <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                        <asp:ListItem Value="D">Danone</asp:ListItem>
                                                        <asp:ListItem Value="P">Parceiro</asp:ListItem>
                                                    </anthem:DropDownList><anthem:Button ID="btn_atualizar_parcelamento" runat="server" Text="Atualizar" ToolTip="Ataualizar tipo de parcelamento para o pedido" CssClass="texto" ValidationGroup="vg_atualizar_parcelamento" AutoUpdateAfterCallBack="True" Enabled="False" Width="24px" Visible="False" />
                                                <anthem:ImageButton ID="btn_atualizarparcelamento" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png"
                                                    ToolTip="Atualizar Tipo de Parcelamento do Pedido" ValidationGroup="vg_atualizar_parcelamento" /></td>
                                            <td align="right" style="height: 21px">
                                                Nr. Parcelas:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label><cc3:OnlyNumbersTextBox
                                                        ID="txt_nrparcelas" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" MaxLength="2" Visible="False" Width="24px"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nrparcelas"
                                                            CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                            ValidationGroup="vg_atualizarparcelas">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_total_parcelas_forn"
                                                                CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                                InitialValue="0" ValidationGroup="vg_atualizarparcelas">[!]</asp:RequiredFieldValidator><anthem:ImageButton ID="btn_atualizar_parcela" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" Enabled="False" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png"
                                                    ToolTip="Atualizar Nr de Parcelas do Pedido" ValidationGroup="vg_atualizarparcelas" Visible="False" /></td>
                                            <td align="right" style="height: 21px">
                                                Tipo de Frete:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_tipo_frete" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                Evento de Compras:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:CheckBox ID="chk_compras_evento" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True"
                                                    ToolTip="Pedido realizado em EVENTO de Compras." CssClass="texto" Font-Size="X-Small" Visible="False" /><anthem:Image ID="img_compras_evento"
                                                        runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif"
                                                        ToolTip="Pedido realizado em EVENTO de Compras." /></td>
                                            <td align="right" style="height: 21px">
                                                Pedido Indireto:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<asp:Image ID="img_pedido_indireto" runat="server" ImageUrl="~/img/ico_chk_false.gif" /></td>
                                            <td align="right" style="height: 21px">
                                                Interrupção Leite:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_interrupcao" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                       <tr runat="server" id="tr_maissolidos" visible = "false">
                                            <td align="right">
                                                Prêmio Mais Sólidos:</td>
                                            <td align="left" colspan="1" style="height: 18px">
                                                <anthem:Label ID="lbl_ms_valor_premio" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" >
                                                <strong>Saldo Disp. Mais Sólidos:</strong></td>
                                            <td align="left" style="height: 18px">
                                                <anthem:Label ID="lbl_ms_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" >
                                                <strong>Prop. Titular:</strong></td>
                                            <td align="left">
                                                <anthem:Label ID="lbl_ms_propriedade_titular" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
 
   							<TR style="font-size: x-small;">
								<TD style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Produtor / Propriedade 
                                </TD>
							</TR>
                                       <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                Produtor:</td>
                                            <td align="left" colspan="1" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_nm_produtor" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                </td>
                                            <td align="left" style="height: 21px">
                                                </td>
                                            <td style=" height: 21px;" align="right">
                                                Acordo de Insumos:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_acordo_aquisicao_insumos" runat="server" CssClass="texto"
                                                    Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td align="right" style="height: 21px;">
                                                Cluster:</td>
                                            <td align="left" colspan="1" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_cluster" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style=" height: 21px;">
                                                Email:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_ds_email" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td align="right" style=" height: 21px;">
                                                Telefone:</td>
                                            <td align="left" style=" height: 21px;">
                                                &nbsp;<anthem:Label ID="lbl_ds_telefone" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                Contrato Produtor:</td>
                                            <td align="left" colspan="1" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_contrato" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="height: 21px;" align="right">
                                                Ini. e Fim Contrato:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_dt_ini_contrato" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label>
                                                à
                                                <anthem:Label ID="lbl_dt_fim_contrato" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="height: 21px;" align="right">
                                                Rescisão Contrato:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_dt_rescisao_contrato" runat="server"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td style="height: 21px;" align="right">
                                                Propriedade:</td>
                                            <td align="left" colspan="1" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_propriedade" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right">
                                                Prop.Matriz:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_propriedade_matriz" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right">
                                                UF/Cidade:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_uf_cidade" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                        <tr style="font-size: x-small;">
                                            <td style=" height: 21px;" align="right">
                                                Limite Disponível:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_limite_disponivel" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Pedidos em Aberto:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_total_pedidos_em_aberto" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label>
                                                </td>
                                            <td style=" height: 21px;" align="right">
                                            </td>
                                            <td style=" height: 21px;" align="left">
                                            </td>
                                        </tr>
   							<TR style="font-size: x-small;">
								<TD id="tr_fornec_titulo" runat="server" style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Parceiro de Insumos</TD>
							</TR>
                                       <tr style="font-size: x-small;" id="tr_fornec_dados1" runat="server">
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
                                     <tr style="font-size: x-small;" id="tr_fornec_dados2" runat="server">
                                            <td style=" height: 21px;" align="right">
                                                Exceção Prazo Pagto:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_excecao_prazo_fornecedor" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Parcelamento Parceiro:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_parcelamento_parceiro" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                </td>
                                            <td style=" height: 21px;" align="left">
                                                </td>
                                        </tr>
                                    <tr style="font-size: x-small;" id="trpedidoinsumos" runat="server" visible="false">
                                            <td style=" height: 21px;" align="right">
                                                Pedido Insumos:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_pedido_insumos" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Total Pedido Insumos:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_total_pedido_insumos" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Total Notas:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_total_notas_insumos" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
   							<TR style="font-size: x-small;" id="tr_transportador_titulo" runat="server">
								<TD style="HEIGHT: 30px; font-size: x-small;" class="titmodulo" align="left" colSpan="6">Dados do Transportador</TD>
							</TR>
                                       <tr style="font-size: x-small;" id="tr_transportador_dados" runat="server">
                                            <td style=" height: 21px;" align="right">
                                                Transportador:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_trasportador" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                CNPJ/CPF:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_cnpj_cpf_transportador" runat="server" CssClass="texto"
                                                    Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Exceção Prazo Pagto:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_excecao_prazo_transp" runat="server"
                                                    CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                     <tr style="font-size: x-small;" id="tr_transportador_pedido" runat="server">
                                            <td style=" height: 21px;" align="right">
                                                Pedido Frete:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_pedido_frete" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small"></anthem:Label>
                                                <anthem:HyperLink ID="hl_pedidofrete" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="textohlink" Font-Underline="True" Target="_blank" ToolTip="Visualizar Pedido de Frete"
                                                    UpdateAfterCallBack="True">[hl_pedidofrete]</anthem:HyperLink></td>
                                            <td style="height: 21px;" align="right" valign="middle">
                                                Total Pedido Frete:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:Label ID="lbl_valor_frete" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style=" height: 21px;" align="right">
                                                Notas Incluídas Frete:</td>
                                            <td style=" height: 21px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_total_notas_frete" runat="server" CssClass="texto" Font-Size="X-Small"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>

   							<TR style="font-size: x-small;">
								<TD style="HEIGHT: 29px; font-size: x-small;" class="titmodulo" align="left" colSpan="6"> Item</TD>
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
                                                &nbsp;<anthem:Label ID="lbl_nr_qtde" runat="server" UpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True"></anthem:Label>
                                                <cc6:OnlyDecimalTextBox ID="txt_nrqtdeitem" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13" MaxMantissa="4"
                                                    UpdateAfterCallBack="True" Visible="False" Width="65px" AutoCallBack="True"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                        ID="rf_alterar_item1" runat="server" ControlToValidate="txt_nrqtdeitem" CssClass="texto"
                                                        ErrorMessage="A quantidade do item deve ser informada." Font-Bold="False" ToolTip="A quantidade do item deve ser informada."
                                                        ValidationGroup="vg_alteraritem">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                            ID="rf_alterar_item2" runat="server" ControlToValidate="txt_nrqtdeitem" CssClass="texto"
                                                            ErrorMessage="A quantidade do item deve ser informada." Font-Bold="False" InitialValue="0"
                                                            ToolTip="A quantidade do item deve ser informada." ValidationGroup="vg_alteraritem">[!]</asp:RequiredFieldValidator><anthem:ImageButton ID="btn_atualizar_qtdeitem" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" ImageUrl="~/img/sincronizar.png"
                                                    ToolTip="Atualizar Quantidade do Pedido" ValidationGroup="vg_alteraritem" Visible="False" /></td>
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
					<TD style="width: 12px"></TD>
				</TR>
				<tr>
				    <td></td>
				    <td>
				    <table runat=server id="table_body" visible="true" width="100%" >
				    	                        <TR runat="server" id="tr_entregas">
	                            <TD class="titmodulo" align="left" style="font-size: x-small" colspan="3">
                                    Entregas do Pedido&nbsp;</TD>
							</TR>
							<TR runat="server" id="tr_entregas_grid">
								<TD style="HEIGHT: 15px" align="center" class="texto" colspan="3" >
                                    <br />
                                    <anthem:GridView ID="gridEntrega" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="X-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="98%" AddCallBacks="False">
                                    <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditRowStyle Width="100%" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Parcela" Visible="False">
                                            <edititemtemplate>
<cc3:OnlyNumbersTextBox id="txt_nr_parcela" runat="server" CssClass="texto" Width="32px" Text='<%# bind("nr_parcela") %>' MaxLength="2" __designer:wfdid="w261"></cc3:OnlyNumbersTextBox>&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_nr_parcela" runat="server" Text='<%# Bind("nr_parcela") %>' __designer:wfdid="w260"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entrega Prevista">
                                            <edititemtemplate>
&nbsp;<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_entrega_prevista" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" Width="64px" Text='<%# bind("dt_entrega_prevista") %>' ErrorMessage="Data Invalida." DateMask="DayMonthYear" DateFormat="Brazil" __designer:wfdid="w263"></cc4:OnlyDateTextBox> <asp:RequiredFieldValidator id="rqf_compartimento" runat="server" CssClass="texto" ValidationGroup="vg_salvar_entrega" Font-Bold="True" ErrorMessage="A data de entrega prevista deve ser informada." ControlToValidate="txt_dt_entrega_prevista" __designer:wfdid="w264">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_dt_entrega_prevista" runat="server" Text='<%# Bind("dt_entrega_prevista") %>' __designer:wfdid="w262"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qtde Prevista">
                                            <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_quantidade_prevista" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Width="56px" Text='<%# bind("nr_quantidade_prevista") %>' MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w266"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_litros" runat="server" CssClass="texto" ValidationGroup="vg_salvar_entrega" Font-Bold="True" ErrorMessage="A quantidade prevista deve ser informada." ControlToValidate="txt_nr_quantidade_prevista" __designer:wfdid="w267">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                            <footertemplate>
&nbsp; 
</footertemplate>
                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_nr_quantidade_prevista" runat="server" CssClass="texto" Text='<%# Bind("nr_quantidade_prevista") %>' __designer:wfdid="w265"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entrega Real">
                                            <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_entrega_real" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" Width="64px" Text='<%# bind("dt_entrega_real") %>' ErrorMessage="Data Invalida." DateMask="DayMonthYear" DateFormat="Brazil" __designer:wfdid="w129"></cc4:OnlyDateTextBox> 
</edititemtemplate>
                                            <footertemplate>
&nbsp; 
</footertemplate>
                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_dt_entrega_real" runat="server" CssClass="texto" Text='<%# Bind("dt_entrega_real") %>' __designer:wfdid="w128"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qtde Real">
                                            <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_quantidade_real" runat="server" CssClass="texto" Width="80px" Text='<%# bind("nr_quantidade_real") %>' MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w131"></cc6:OnlyDecimalTextBox> 
</edititemtemplate>
                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_nr_quantidade_real" runat="server" Text='<%# bind("nr_quantidade_real") %>' __designer:wfdid="w130"></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CssClass="texto" ToolTip="Salvar Entregas ao Produtor" ValidationGroup="vg_salvar_pagto" __designer:wfdid="w148" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Entrega" __designer:wfdid="w149" CommandName="Cancel" ImageAlign="Baseline"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_salvar_entrega" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w150"></asp:ValidationSummary> 
</edititemtemplate>
                                            <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_editar_grid.gif" CssClass="texto" ToolTip="Editar Entregas ao Produtor" __designer:wfdid="w146" CommandName="Edit"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Entregas ao Produtor" __designer:wfdid="w147" CommandName="delete" ImageAlign="Baseline" CommandArgument='<%# Bind("id_central_pedido_entrega") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de pagamnto ao fornecedor?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="id_central_pedido_entrega" >
                                            <edititemtemplate>
<anthem:Label id="lbl_id_central_pedido_entrega" runat="server" Visible="False" Text='<%# bind("id_central_pedido_entrega") %>'></anthem:Label> 
</edititemtemplate>
                                            <itemtemplate>
<anthem:Label id="lbl_id_central_pedido_entrega" runat="server" Visible="False" Text='<%# bind("id_central_pedido_entrega") %>'></anthem:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_central_pedido_item" Visible="False">
                                            <edititemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </anthem:GridView>
                                    &nbsp;&nbsp;
                                    <br />
                                    <anthem:Button ID="btn_adicionar_entrega" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Adicionar Entrega" ToolTip="Adicionar nova entrega" Enabled="False" /><br />
                                </TD>
							</TR>
 	                        <tr>
	                            <TD class="titmodulo3" align="left" style="height: 24px; width: 25%;" colspan="1">
                                    PAGAMENTOS</td>
                                 <td align="left" class="titmodulo4 faixafiltro1a" style="height: 24px; width: 25%;" colspan="1">
                                     &nbsp;<anthem:Image ID="img_pedidoeditar" runat="server" ImageUrl="~/img/icone_editar.gif" Visible="False" AutoUpdateAfterCallBack="True" CssClass="texto" /><anthem:Button ID="btn_pedidoeditar" runat="server" Text="Editar" ToolTip="Prepara pedido para atualizações" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px" Width="72px" Visible="False" />&nbsp;&nbsp;
                                     &nbsp;<anthem:Image ID="img_pedidosalvar" runat="server" ImageUrl="~/img/icone_gravar.gif" Visible="False" AutoUpdateAfterCallBack="True" CssClass="texto" />
                                     <anthem:Button ID="btn_pedidosalvar" runat="server" Text="Salvar" ToolTip="Salvar atualizações do pedido." CssClass="texto" ValidationGroup="vg_pedido" AutoUpdateAfterCallBack="True" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px" Width="72px" Visible="False" Enabled="False" />
                                     &nbsp;
                                 </td>
                                 <td align="left" class="titmodulo2 faixafiltro1a" style="height: 24px;" colspan="1">
                                     &nbsp;&nbsp;
                                 </td>
	                        </tr>

	                        <tr>
	                            <TD  style="height:5px" colspan="3">
                                   </td>
                                 <td >
                                     </td>
	                        </tr>


 	                        <tr>
	                            <TD style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="3">
                                    Notas Fiscais</td>
	                        </tr>
                               <tr id="tr_notaincluir" runat="server">
                                <TD class="texto" align=center colspan="3">
                                    <table width="100%" id="TABLE5" border="0">
                                        <tr id="tr_nota_incluir" runat="server" >
                                            <td align="right" style=" font-size: x-small; width: 7%; height: 25px;" valign="bottom" >
                                                Nr Nota:</td>
                                            <td align="left" style=" font-size: x-small; width: 10%; height: 25px;" valign="bottom">
                                                &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nf_nr_nota" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Width="72px"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_nf_nr_nota"
                                                    CssClass="texto" ErrorMessage="O número da nota fiscal deve ser informado." Font-Bold="False"
                                                    ToolTip="O número da nota fiscal para inclusão deve ser informado." ValidationGroup="vg_incluir_nota">[!]</asp:RequiredFieldValidator>
                                                 </td>
                                            <td align="right" style=" font-size: x-small; width: 5%; height: 25px;" valign="bottom">
                                               Série:</td>
                                            <td align="left" style=" font-size: x-small; width: 7%; height: 25px;" valign="bottom" >
                                                &nbsp;<anthem:TextBox ID="txt_nf_serie" runat="server" CssClass="texto" MaxLength="5" 
                                                    Width="56px" AutoUpdateAfterCallBack="True"></anthem:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_nf_serie"
                                                    CssClass="texto" ErrorMessage="A série da nota fiscal deve ser informada." Font-Bold="False"
                                                    ToolTip="A série da nota fiscal deve ser informada." ValidationGroup="vg_incluir_nota">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style=" font-size: x-small; width: 7%; height: 25px;" valign="bottom">
                                                Emissão:</td>
                                            <td align="left" style=" font-size: x-small; width: 10%; height: 25px;" valign="bottom">
                                                &nbsp;<cc4:OnlyDateTextBox ID="txt_nf_dt_emissao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" DateFormat="Brazil" DateMask="DayMonthYear" ErrorMessage="Data Invalida."
                                                    onblur="JScript:return val_date(this);" onkeypress="JScript:return DateOnKeyPress(this,event);"
                                                    Width="72px"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                        runat="server" BorderStyle="None" ControlToValidate="txt_nf_dt_emissao" CssClass="texto"
                                                        ErrorMessage="A data de Emissão da Nota a ser incluída deve ser informada."
                                                        Font-Bold="False" ToolTip="Data de emissão da nota deve ser informada." ValidationGroup="vg_incluir_nota">[!]</asp:RequiredFieldValidator><asp:CustomValidator
                                                            ID="CustomValidator1" runat="server" ControlToValidate="txt_nf_dt_emissao" ErrorMessage="A data de emissão da nota pode ser retroativa até 1 mês antes da data de pedido!"
                                                            ToolTip="A data de emissão da nota pode ser retroativa até 1 mês antes da data de pedido!"
                                                            ValidationGroup="vg_incluir_nota">[!]</asp:CustomValidator></td>
                                            <td align="right" style="font-size: x-small; width: 7%; height: 25px;" valign="bottom">
                                                Vl Nota:</td>
                                            <td align="left" style=" font-size: x-small; width: 10%; height: 25px;" valign="bottom" >
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nf_totalnota" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13" MaxMantissa="2"
                                                     UpdateAfterCallBack="True" Width="72px"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_nf_totalnota"
                                                    CssClass="texto" ErrorMessage="O valor da nota fiscal a ser inserida deve ser informado." Font-Bold="False"
                                                    ToolTip="O valor da nota fiscal deve ser informado." ValidationGroup="vg_incluir_nota">[!]</asp:RequiredFieldValidator></td>
                                            <td align="left" style="font-size: x-small; height: 25px;" valign="bottom" >
                                                &nbsp;
                                                <anthem:Button ID="btn_incluirnota" runat="server" Text="Incluir Nota Fiscal" ToolTip="Incluir Nota Fiscal ao Pedido" CssClass="texto" ValidationGroup="vg_incluir_nota" AutoUpdateAfterCallBack="True" Enabled="False" />
                                                <anthem:CustomValidator ID="cv_incluirnota" runat="server" AutoUpdateAfterCallBack="True"
                                                    ForeColor="White" ValidationGroup="vg_incluir_nota">[!]</anthem:CustomValidator></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
	                        <tr>
	                            <TD style="HEIGHT: 15px" align="center" class="texto" colspan="3" >
	                                <anthem:GridView ID="gridNotas" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="X-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="98%" AddCallBacks="False" DataKeyNames="id_central_pedido_notas">
                                    <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditRowStyle Width="100%" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Det." Visible="False">
                                            <itemtemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icon_preview.gif" ToolTip="Visualizar Cotações do Item" __designer:wfdid="w3" CommandName="cotacoes"></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nr Nota">
                                            <itemtemplate>
<anthem:HyperLink id="hl_download" runat="server" ForeColor="Blue" Text='<%# bind("nr_nota_fiscal") %>' Font-Underline="True" __designer:wfdid="w325"></anthem:HyperLink><anthem:Label id="lbl_nrnotafiscal" __designer:dtid="12103428293525722" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Font-Size="X-Small" Text='<%# bind("nr_nota_fiscal") %>' __designer:wfdid="w326"></anthem:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" ReadOnly="True" />
                                        <asp:BoundField DataField="dt_emissao" HeaderText="Emiss&#227;o" DataFormatString="{0:d}" ReadOnly="True" />
                                        <asp:BoundField DataField="nr_valor_nf" HeaderText="Total NF" DataFormatString="{0:C2}" ReadOnly="True" />
                                        <asp:BoundField DataField="dt_criacao" DataFormatString="{0:d}" HeaderText="Dt Inclus&#227;o"
                                            ReadOnly="True" />
                                        <asp:TemplateField ShowHeader="False">
                                            <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" ImageUrl="~/img/icone_anexar.gif" ToolTip="Anexar PDF Nota Fiscal" ImageAlign="Baseline" __designer:wfdid="w5" CommandArgument='<%# Bind("id_central_pedido_notas") %>' CommandName="anexar"></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Nota do Pedido" __designer:wfdid="w4" CommandArgument='<%# Bind("id_central_pedido_notas") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir a nota? Caso tenha sido importada, a nota retornará para o Gerenciamento de Notas como Pendente.' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False" HeaderText="id_central_notas_importacao">
                                                <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<anthem:Label id="lbl_id_central_notas_importacao" runat="server" Visible="False" Text='<%# bind("id_central_notas_importacao") %>' __designer:wfdid="w551"></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_central_pedido_notas" Visible="False">
                                            <edititemtemplate>
&nbsp;
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Bind("id_central_pedido_notas") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="parcela_com_exportacao_nota" Visible="False">
                                            <edititemtemplate>
</edititemtemplate>
                                            <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("parcela_com_exportacao_nota") %>' id="lbl_parcela_com_exportacao_nota"></asp:Label>
</itemtemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="parcela_com_calculo_nota" Visible="False">
                                            <edititemtemplate>
</edititemtemplate>
                                            <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("parcela_com_calculo_nota") %>' id="lbl_parcela_com_calculo_nota"></asp:Label>
</itemtemplate>
                                        </asp:TemplateField>

                                        </Columns>
                                    </anthem:GridView>
                                    <anthem:CustomValidator ID="cv_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator>
                                    </td>
	                        </tr>
	                        <TR>
								<TD class="texto" align="right" width="23%" colspan="3" style="height: 2px"></TD>
	                        </TR>

 	                        <tr >
	                            <TD style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="3">
                                    Pagamento ao Fornecedor</td>
	                        </tr>
                                <tr runat="server" id="tr_pagto_fornec_incluir">
                                <TD class="texto" align=center colspan="3">
                                    <table width="100%" id="TABLE3" border="0">
                                        <tr>
                                            <td align="right" style="width: 7%; font-size: x-small;" >
                                                Nr Nota:</td>
                                            <td align="left" style="width: 23%; font-size: x-small;">
                                                &nbsp;<anthem:DropDownList ID="cbo_nota_fiscal_forn" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Visible="False">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="rf_cbo_nota_fiscal_forn" runat="server" ControlToValidate="cbo_nota_fiscal_forn"
                                                    CssClass="texto" ErrorMessage="O número da nota fiscal deve ser informado." Font-Bold="False"
                                                    ToolTip="O número da nota fiscal deve ser informado." ValidationGroup="vg_incluir_parcelas_forn" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="width: 8%; font-size: x-small;">
                                                Total Parcelas:</td>
                                            <td align="left" style="width: 8%; font-size: x-small;">
                                                &nbsp;<cc3:OnlyNumbersTextBox ID="txt_total_parcelas_forn" runat="server" CssClass="texto"
                                                    MaxLength="2" Width="33px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator ID="rf_totalparcelas" runat="server" ControlToValidate="txt_total_parcelas_forn"
                                                    CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                    ValidationGroup="vg_incluir_parcelas_forn">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_total_parcelas_forn"
                                                        CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                        InitialValue="0" ValidationGroup="vg_incluir_parcelas_forn">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="width: 12%; font-size: x-small;">
                                                Data 1o. Pagamento:</td>
                                            <td align="left" style="font-size: x-small;" >
                                                &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_primeiro_pagto_forn" runat="server" CssClass="texto"
                                                    DateFormat="Brazil" DateMask="DayMonthYear" ErrorMessage="Data Invalida." onblur="JScript:return val_date(this);"
                                                    onkeypress="JScript:return DateOnKeyPress(this,event);" Text='<%# bind("dt_pagto") %>'
                                                    Width="68px" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="rqf_dtpagto1" runat="server"
                                                        ControlToValidate="txt_dt_primeiro_pagto_forn" CssClass="texto" ErrorMessage="A data de Primeiro pagamento do Fornecedor deve ser informada."
                                                        Font-Bold="True" ValidationGroup="vg_incluir_parcelas_forn">[!]</asp:RequiredFieldValidator><asp:CustomValidator
                                                            ID="cv_datapagtoforn" runat="server" ErrorMessage="A data de pagamento pode ser retroativa até 1 mês antes da data de pedido!"
                                                            ValidationGroup="vg_incluir_parcelas_forn">[!]</asp:CustomValidator>
                                                <anthem:Button ID="btn_incluir_parcelas_fornecedor" runat="server" Text="Incluir Parcelas" ToolTip="Incluir Parcelas de Pagamento ao Fornecedor" CssClass="texto" ValidationGroup="vg_incluir_parcelas_forn" AutoUpdateAfterCallBack="True" Enabled="False" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                                <tr>
                                    <TD style="HEIGHT: 15px" align="center" class="texto" colspan="3">
                                        <anthem:GridView ID="gridPagtoForn" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="100%">
                                            <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                            <EditRowStyle Width="100%" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Nr Nota">
                                                    <edititemtemplate>
<asp:DropDownList id="cbo_nr_nota" runat="server" Visible="False" CausesValidation="True" CssClass="texto" AutoPostBack="True" __designer:wfdid="w329" OnSelectedIndexChanged="cbo_nr_nota_SelectedIndexChanged1"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rf_cbo_nota_fiscal" runat="server" ValidationGroup="vg_salvar_pagto" ToolTip="O número da nota fiscal deve ser informado." CssClass="texto" Font-Bold="False" ErrorMessage="O número da nota fiscal deve ser informado." ControlToValidate="cbo_nr_nota" InitialValue="0" __designer:wfdid="w330">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_nota_fiscal" runat="server" Text='<%# Bind("nr_nota_fiscal") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="S&#233;rie">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_serie" runat="server" Text='<%# Bind("nr_serie_nota_fiscal") %>' __designer:wfdid="w332"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_serie" runat="server" Text='<%# Bind("nr_serie_nota_fiscal") %>' __designer:wfdid="w331"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Emiss&#227;o">
                                                    <edititemtemplate>
<asp:Label id="lbl_dt_emissao" runat="server" CssClass="texto" Text='<%# Bind("dt_emissao_nota_fiscal") %>' __designer:wfdid="w334"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_emissao" runat="server" CssClass="texto" Text='<%# Bind("dt_emissao_nota_fiscal") %>' __designer:wfdid="w333"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vl Nota">
                                                    <edititemtemplate>
<asp:Label id="lbl_nr_valor_nota_fiscal" runat="server" Text='<%# Bind("nr_valor_nota_fiscal") %>' __designer:wfdid="w336"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_nota_fiscal" runat="server" Text='<%# Bind("nr_valor_nota_fiscal") %>' __designer:wfdid="w335"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parcela">
                                                    <edititemtemplate>
<cc3:OnlyNumbersTextBox id="txt_nr_parcela" runat="server" CssClass="texto" Width="32px" Text='<%# bind("nr_parcela") %>' MaxLength="2" __designer:wfdid="w338"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator id="rqf_placa" runat="server" ValidationGroup="vg_salvar_pagto" CssClass="texto" Font-Bold="False" ErrorMessage="O número da parcela deve ser informado." ControlToValidate="txt_nr_parcela" __designer:wfdid="w339">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <footertemplate>
&nbsp; 
</footertemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_parcela") %>' __designer:wfdid="w337"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Valor">
                                                    <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_valor_parcela" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Width="56px" Text='<%# bind("nr_valor_parcela") %>' MaxLength="13" MaxMantissa="2" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w341"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_litros" runat="server" ValidationGroup="vg_salvar_pagto" CssClass="texto" Font-Bold="True" ErrorMessage="O valor da parcela deve ser informado." ControlToValidate="txt_nr_valor_parcela" __designer:wfdid="w342">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator id="rfv_vlparcela2" runat="server" ValidationGroup="vg_salvar_pagto" CssClass="texto" Font-Bold="True" ErrorMessage="O valor da parcela deve ser maior que zero." ControlToValidate="txt_nr_valor_parcela" InitialValue="0" __designer:wfdid="w343">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <footertemplate>
&nbsp; 
</footertemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_valor_parcela") %>' __designer:wfdid="w340"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Data Pagamento">
                                                    <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_pagto" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" Width="64px" Text='<%# bind("dt_pagto") %>' ErrorMessage="Data Invalida." DateMask="DayMonthYear" DateFormat="Brazil" __designer:wfdid="w345"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator id="rqf_dtpagto" runat="server" ValidationGroup="vg_salvar_pagto" CssClass="texto" Font-Bold="True" ErrorMessage="A data de pagamento deve ser informada." ControlToValidate="txt_dt_pagto" __designer:wfdid="w346">[!]</asp:RequiredFieldValidator><asp:CustomValidator id="cv_datapagto" runat="server" ValidationGroup="vg_salvar_pagto" ErrorMessage="A data de pagamento pode ser retroativa até 1 mês antes da data de pedido!" __designer:wfdid="w347" OnServerValidate="cv_datapagto_ServerValidate">[!]</asp:CustomValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_pagto" runat="server" CssClass="texto" Text='<%# Bind("dt_pagto") %>' __designer:wfdid="w344"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exporta&#231;&#227;o">
                                                    <itemtemplate>
<anthem:Image id="img_st_exportado" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" __designer:wfdid="w348"></anthem:Image> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pedido Ori." Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_pedido_origem" runat="server" __designer:wfdid="w350"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_pedido_origem" runat="server" __designer:wfdid="w349"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prop.Ori." ShowHeader="False" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_prop_origem" runat="server"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_prop_origem" runat="server"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dep&#243;sito">
                                                    <edititemtemplate>
<anthem:CheckBox id="chk_st_tipo_pagto" runat="server" AutoUpdateAfterCallBack="True" __designer:wfdid="w410"></anthem:CheckBox> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Image id="img_st_tipo_pagto" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" __designer:wfdid="w408"></anthem:Image>&nbsp;<anthem:Label id="lbl_acerto" runat="server" Visible="False" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w409"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" ImageUrl="~/img/icone_anexar.gif" ToolTip="Anexar  Pagamento ao Fornecedor" ImageAlign="Baseline" __designer:wfdid="w12" CommandArgument='<%# Bind("id_central_pedido_pagto_fornecedor") %>' CommandName="anexar"></anthem:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar_pagto" ToolTip="Salvar Pagamento ao Fornecedor" CssClass="texto" __designer:wfdid="w9" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Coleta" ImageAlign="Baseline" __designer:wfdid="w10" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar_pagto" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w11"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Pagamento ao Fornecedor" CssClass="texto" __designer:wfdid="w7" CommandName="Edit"></anthem:ImageButton>&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Pagamento ao Fornecedor" ImageAlign="Baseline" __designer:wfdid="w8" CommandArgument='<%# Bind("id_central_pedido_pagto_fornecedor") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir este registro de pagamnto ao fornecedor?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_central_pedido_pagto_fornecedor" >
                                                    <edititemtemplate>
<anthem:Label id="lbl_id_central_pedido_pagto_fornecedor" runat="server" Visible="False" Text='<%# bind("id_central_pedido_pagto_fornecedor") %>'></anthem:Label>
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_id_central_pedido_pagto_fornecedor" runat="server" Visible="False" Text='<%# bind("id_central_pedido_pagto_fornecedor") %>'></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_central_pedido_item" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_transf_volume_exportado" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_transf" runat="server" Text='<%# Bind("st_transf_volume_exportado") %>'></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_transf" runat="server" Text='<%# Bind("st_transf_volume_exportado") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_exportacao" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_exportacao" runat="server" Text='<%# Bind("st_exportacao") %>' __designer:wfdid="w59"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_exportacao" runat="server" Text='<%# Bind("st_exportacao") %>' __designer:wfdid="w58"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_central_pedido_notas" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Eval("id_central_pedido_notas") %>' __designer:wfdid="w46"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Bind("id_central_pedido_notas") %>' __designer:wfdid="w45"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_tipo_pagto" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_tipo_pagto" runat="server" Text='<%# Bind("st_tipo_pagto") %>' __designer:wfdid="w77"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_pagto" runat="server" Text='<%# Bind("st_tipo_pagto") %>' __designer:wfdid="w75"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_acerto" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_dt_acerto" runat="server" Text='<%# Eval("dt_acerto") %>' __designer:wfdid="w53"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_acerto" runat="server" Text='<%# Bind("dt_acerto") %>' __designer:wfdid="w52"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
                                        &nbsp; &nbsp;&nbsp;
                                        <br />
                                        <anthem:Button ID="btn_adicionar_pagto_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Adicionar Pagto" ToolTip="Adicionar Pagamento ao Fornecedor" Enabled="False" /><br />
                                    </td>
                                </tr>
                                <tr runat="server" id="tr_desc_produtor">
                                    <TD style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="3">
                                        Desconto ao Produtor:</td>
                                </tr>
                               <tr runat="server" id="tr_desc_produtor_incluir">
                                    <TD class="texto" align=center colspan="3">
                                        <table width="100%" id="tb_descontoprodutor" runat="server">
                                            <tr>
                                                <td align="right" style="width: 7%; font-size: x-small;">
                                                    Nr Nota:</td>
                                                <td align="left" style="width: 23%; font-size: x-small;">
                                                    &nbsp;<anthem:DropDownList ID="cbo_nota_fiscal_prod" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Visible="False">
                                                    </anthem:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rf_cbo_nota_fiscal_prod" runat="server" ControlToValidate="cbo_nota_fiscal_prod"
                                                        CssClass="texto" ErrorMessage="O número da nota fiscal deve ser informado." Font-Bold="False"
                                                        ToolTip="O número da nota fiscal deve ser informado." ValidationGroup="vg_incluir_parcelas_prod" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" style="width: 8%; font-size: x-small;">
                                                    Total Parcelas:</td>
                                                <td align="left" style="width: 8%; font-size: x-small;">
                                                    <cc3:OnlyNumbersTextBox ID="txt_total_parcelas_prod" runat="server" CssClass="texto"
                                                        MaxLength="2" Width="32px" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_total_parcelas_prod"
                                                        CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                        ValidationGroup="vg_incluir_parcelas_prod">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_total_parcelas_prod"
                                                            CssClass="texto" ErrorMessage="O total de parcelas deve ser informado." Font-Bold="False"
                                                            InitialValue="0" ValidationGroup="vg_incluir_parcelas_prod">[!]</asp:RequiredFieldValidator></td>
                                                <td align="right" style="width: 12%; font-size: x-small;">
                                                    Data 1o. Pagamento:</td>
                                                <td align="left" style="font-size: x-small" >
                                                    <cc4:OnlyDateTextBox ID="txt_dt_primeiro_pagto_prod" runat="server" CssClass="texto"
                                                        DateFormat="Brazil" DateMask="DayMonthYear" ErrorMessage="Data Invalida." onblur="JScript:return val_date(this);"
                                                        onkeypress="JScript:return DateOnKeyPress(this,event);" Text='<%# bind("dt_pagto") %>'
                                                        Width="70px" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                            runat="server" ControlToValidate="txt_dt_primeiro_pagto_prod" CssClass="texto"
                                                            ErrorMessage="A data de Primeiro desconto ao produtor deve ser informada." Font-Bold="True"
                                                            ValidationGroup="vg_incluir_parcelas_prod">[!]</asp:RequiredFieldValidator><asp:CustomValidator
                                                                ID="cv_datapagtoprod2" runat="server" ControlToValidate="txt_dt_primeiro_pagto_prod"
                                                                ErrorMessage="A data de pagamento pode ser retroativa até 1 mês antes da data de pedido!"
                                                                ValidationGroup="vg_incluir_parcelas_prod">[!]</asp:CustomValidator>&nbsp;
                                                    <anthem:CheckBox ID="chk_utilizarmaissolidos" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" Font-Bold="True" Text="Utilizar Saldo Mais Sólidos" Visible="False" />&nbsp;
                                                    <anthem:Button ID="btn_incluir_parcelas_produtor" runat="server" Text="Incluir Parcelas" ToolTip="Incluir Parcelas de Desconto ao Produtor" CssClass="texto" ValidationGroup="vg_incluir_parcelas_prod" AutoUpdateAfterCallBack="True" Enabled="False" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr_desc_produtor_grid">
                                    <TD style="HEIGHT: 15px" align="center" class="texto" colspan="3">
                                        <anthem:GridView ID="grdDescProdutor" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="100%">
                                            <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                            <EditRowStyle Width="100%" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Nr Nota">
                                                    <edititemtemplate>
<asp:DropDownList id="cbo_nr_nota" runat="server" Visible="False" CssClass="texto" AutoPostBack="True" __designer:wfdid="w362" OnSelectedIndexChanged="cbo_nr_nota_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator id="rf_cbo_nota_fiscal" runat="server" ValidationGroup="vg_salvar_desc" ToolTip="O número da nota fiscal deve ser informado." CssClass="texto" Font-Bold="False" ErrorMessage="O número da nota fiscal deve ser informado." ControlToValidate="cbo_nr_nota" InitialValue="0" __designer:wfdid="w363">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_nota_fiscal" runat="server" Text='<%# Bind("nr_nota_fiscal") %>' __designer:wfdid="w425"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vl Nota">
                                                    <edititemtemplate>
&nbsp;<asp:Label id="lbl_nr_valor_nota_fical" runat="server" Text='<%# Bind("nr_valor_nota_fiscal") %>' __designer:wfdid="w365"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_nota_fical" runat="server" Text='<%# Bind("nr_valor_nota_fiscal") %>' __designer:wfdid="w364"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parcela">
                                                    <edititemtemplate>
<cc3:OnlyNumbersTextBox id="txt_nr_parcela" runat="server" CssClass="texto" Width="32px" Text='<%# bind("nr_parcela") %>' MaxLength="2" __designer:wfdid="w367"></cc3:OnlyNumbersTextBox><asp:RequiredFieldValidator id="rqf_placa" runat="server" ValidationGroup="vg_salvar_desc" CssClass="texto" Font-Bold="False" ErrorMessage="O número da parcela deve ser informado." ControlToValidate="txt_nr_parcela" __designer:wfdid="w368">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <footertemplate>
&nbsp; 
</footertemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_parcela") %>' __designer:wfdid="w366"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Valor">
                                                    <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_valor_parcela" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Width="56px" Text='<%# bind("nr_valor_parcela") %>' MaxLength="13" MaxMantissa="2" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w370"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_litros" runat="server" ValidationGroup="vg_salvar_desc" CssClass="texto" Font-Bold="True" ErrorMessage="O valor da parcela deve ser informado." ControlToValidate="txt_nr_valor_parcela" __designer:wfdid="w371">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <footertemplate>
&nbsp; 
</footertemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_parcela" runat="server" CssClass="texto" Text='<%# Bind("nr_valor_parcela") %>' __designer:wfdid="w369"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Data Pagamento">
                                                    <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_pagto" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" Width="64px" Text='<%# bind("dt_pagto") %>' ErrorMessage="Data Invalida." DateMask="DayMonthYear" DateFormat="Brazil" __designer:wfdid="w373"></cc4:OnlyDateTextBox> <asp:RequiredFieldValidator id="rqf_dtpagto" runat="server" ValidationGroup="vg_salvar_desc" CssClass="texto" Font-Bold="True" ErrorMessage="A data de pagamento deve ser informada." ControlToValidate="txt_dt_pagto" __designer:wfdid="w374">[!]</asp:RequiredFieldValidator><asp:CustomValidator id="cv_datapagtoprod" runat="server" ValidationGroup="vg_salvar_desc" ErrorMessage="A data de pagamento pode ser retroativa até 1 mês antes da data de pedido!" __designer:wfdid="w375" OnServerValidate="cv_datapagtoprod_ServerValidate">[!]</asp:CustomValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_pagto" runat="server" CssClass="texto" Text='<%# Bind("dt_pagto") %>' __designer:wfdid="w372"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mais S&#243;lidos" Visible="False">
                                                    <edititemtemplate>
<anthem:CheckBox id="chk_mais_solidos" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Utilizar Saldo Mais Sólidos" __designer:wfdid="w26"></anthem:CheckBox> <anthem:Label id="lbl_saldo_mais_solidos" runat="server" Visible="False" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w27"></anthem:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Image id="img_st_utilizar_mais_solidos" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" __designer:wfdid="w24"></anthem:Image> <anthem:Label id="lbl_saldo_mais_solidos" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w25"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="C&#225;lculo">
                                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Image id="img_st_calculado" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" __designer:wfdid="w376"></anthem:Image> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pedido Ori." Visible="False">
                                                    <edititemtemplate>
&nbsp;<asp:Label id="lbl_pedido_ori" runat="server" __designer:wfdid="w378"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_pedido_ori" runat="server" __designer:wfdid="w377"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prop.Ori." Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_prop_ori" runat="server"></asp:Label>&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_prop_ori" runat="server"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dep&#243;sito?">
                                                    <edititemtemplate>
<anthem:CheckBox id="chk_st_tipo_desconto" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w381"></anthem:CheckBox> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Image id="img_st_tipo_desconto" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" CssClass="texto" __designer:wfdid="w379"></anthem:Image>&nbsp;<anthem:Label id="lbl_acerto" runat="server" Visible="False" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w380">Acerto em 05/05/2023</anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" ImageUrl="~/img/icone_anexar.gif" ToolTip="Anexar Comprovante Desconto ao Produtor" ImageAlign="Baseline" __designer:wfdid="w436" CommandName="anexar" CommandArgument='<%# Bind("id_central_pedido_desconto_produtor") %>'></anthem:ImageButton>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar_desc" ToolTip="Salvar Pedido" CssClass="texto" __designer:wfdid="w439" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Coleta" ImageAlign="Baseline" __designer:wfdid="w440" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar_desc" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w441"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Desconto ao Produtor" CssClass="texto" __designer:wfdid="w437" CommandName="Edit"></anthem:ImageButton>&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Desconto ao Produtor" ImageAlign="Baseline" __designer:wfdid="w438" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir este registro de desconto ao produtor?' )) return true;else return false;" CommandArgument='<%# Bind("id_central_pedido_desconto_produtor") %>'></anthem:ImageButton>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_central_pedido_pagto_fornecedor" >
                                                    <edititemtemplate>
<anthem:Label id="lbl_id_central_pedido_desconto_produtor" runat="server" Visible="False" Text='<%# bind("id_central_pedido_desconto_produtor") %>'></anthem:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_id_central_pedido_desconto_produtor" runat="server" Visible="False" Text='<%# bind("id_central_pedido_desconto_produtor") %>'></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_central_pedido_item" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_central_pedido_item" runat="server" Text='<%# bind("id_central_pedido_item") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_transf_volume_calculado" Visible="False">
                                                    <edititemtemplate>
&nbsp;<asp:Label id="lbl_st_transf" runat="server" Text='<%# Bind("st_transf_volume_calculado") %>'></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_transf" runat="server" Text='<%# Bind("st_transf_volume_calculado") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_mais_solidos" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_mais_solidos" runat="server" Text='<%# Bind("st_mais_solidos") %>'></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_mais_solidos" runat="server" Text='<%# Bind("st_mais_solidos") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="st_mais_solidos_valor_utilizado" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_mais_solidos_valor_utilizado" runat="server" Text='<%# Bind("nr_mais_solidos_valor_utilizado") %>'></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_mais_solidos_valor_utilizado" runat="server" Text='<%# Bind("nr_mais_solidos_valor_utilizado") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_central_pedido_notas" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Bind("id_central_pedido_notas") %>' __designer:wfdid="w77"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Bind("id_central_pedido_notas") %>' __designer:wfdid="w75"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_ficha_financeira_calc" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_id_ficha_financeira_calc" runat="server" Text='<%# Bind("id_ficha_financeira_calc") %>' __designer:wfdid="w80"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_ficha_financeira_calc" runat="server" Text='<%# Bind("id_ficha_financeira_calc") %>' __designer:wfdid="w78"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_tipo_desconto" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_tipo_desconto" runat="server" Text='<%# Bind("st_tipo_desconto") %>' __designer:wfdid="w81"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_desconto" runat="server" Text='<%# Bind("st_tipo_desconto") %>' __designer:wfdid="w79"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="dt_acerto" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_dt_acerto" runat="server" Text='<%# Bind("dt_acerto") %>' __designer:wfdid="w83"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_acerto" runat="server" Text='<%# Bind("dt_acerto") %>' __designer:wfdid="w82"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
                                        &nbsp; &nbsp;&nbsp;
                                        <br />
                                        <anthem:Button ID="btn_adicionar_desconto_prod" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Adicionar Desconto" ToolTip="Adicionar Desconto ao Produtor" Enabled="False" ValidationGroup="vg_adicionardescprod" />
                                        <br />
                                        </td>
                                </tr>
                                <tr>
                                    <TD class="titmodulo" align="left" style="font-size: x-small" colspan="3">
                                        Observações sobre o Pedido<br />
                                    </td>
                                </tr>
                                <tr>
                                    <TD style="HEIGHT: 7px; color: blue;" class="texto" align=left width="23%" colspan="3">
                                        </td>
                                </tr>
                                <tr>
                                    <TD style="HEIGHT: 15px" align="center" class="texto" colspan="3">
                                        <anthem:GridView ID="gridObs" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="100%">
                                            <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                            <EditRowStyle Width="100%" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Data Inclus&#227;o">
                                                    <edititemtemplate>
&nbsp;<asp:Label id="lbl_dt_criacao" runat="server" Text='<%# Bind("dt_criacao") %>' __designer:wfdid="w255"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_criacao" runat="server" Text='<%# Bind("dt_criacao") %>' __designer:wfdid="w254"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Observa&#231;&#245;es">
                                                    <edititemtemplate>
<asp:TextBox id="txt_ds_observacao" runat="server" Width="90%" Text='<%# bind("ds_observacao") %>' MaxLength="200" __designer:wfdid="w257" TextMode="MultiLine" Rows="2"></asp:TextBox><asp:RequiredFieldValidator id="rqf_obs" runat="server" CssClass="texto" ToolTip="Ocampo observação deve ser informado" ValidationGroup="vg_salvar_obs" Font-Bold="True" ErrorMessage="O campo observação deve ser informado." ControlToValidate="txt_ds_observacao" __designer:wfdid="w258">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                    <footertemplate>
&nbsp; 
</footertemplate>
                                                    <itemtemplate>
&nbsp; <asp:TextBox id="txt_ds_observacao" runat="server" Enabled="False" Width="90%" Text='<%# bind("ds_observacao") %>' MaxLength="200" __designer:wfdid="w256" TextMode="MultiLine" Rows="2"></asp:TextBox>&nbsp; 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CssClass="texto" ToolTip="Salvar Observação" ValidationGroup="vg_salvar_obs" __designer:wfdid="w99" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Entrega" __designer:wfdid="w100" CommandName="Cancel" ImageAlign="Baseline"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_salvar_obs" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w101"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_editar_grid.gif" CssClass="texto" ToolTip="Editar Entregas ao Produtor" __designer:wfdid="w97" CommandName="Edit"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Entregas ao Produtor" __designer:wfdid="w98" CommandName="delete" ImageAlign="Baseline" CommandArgument='<%# Bind("id_central_pedido_observacao") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de observação?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="8%" />
                                                    <itemstyle width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False" HeaderText="id_central_pedido_observacao" >
                                                    <edititemtemplate>
<anthem:Label id="lbl_id_central_pedido_observacao" runat="server" Visible="False" Text='<%# bind("id_central_pedido_observacao") %>'></anthem:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_id_central_pedido_observacao" runat="server" Visible="False" Text='<%# bind("id_central_pedido_observacao") %>'></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </anthem:GridView>
                                        &nbsp;&nbsp;
                                        <br />
                                        <anthem:Button ID="btn_adicionar_obs" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Adicionar Observação" ToolTip="Adicionar Observação" /></td>
                                </tr>
                                <tr>
                                    <td align="center" class="texto" style="height: 15px" colspan="3">
                                    </td>
                                </tr>
						</TABLE>

				</td>
				<td></td>
				</tr>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
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
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <asp:ValidationSummary ID="vs_incluirnota" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir_nota" /><asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir_parcelas_prod" />
            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir_parcelas_forn" /><asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_alteraritem" />
                <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_atualizar_parcelamento" /><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pedido" />
           <anthem:HiddenField ID="hf_sel_id_item" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_sel_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
