<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_solicitar_cotacao.aspx.vb" Inherits="frm_central_solicitar_cotacao" %>

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
    <title>Solicitar Cotação</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	<script type="text/javascript"> 

    function ShowDialogFreteValor() 
    
    {
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade").value;

   	    idcboestabel = document.getElementById("cbo_estabelecimento").value;
   	    var hf_id_item = document.getElementById("hf_sel_id_item").value;
   	    var hf_id_fornecedor = document.getElementById("hf_sel_id_fornecedor").value;
        szUrl = 'lupa_cotacao_frete.aspx?id_estabelecimento='+idcboestabel+'&id_item='+hf_id_item+'&id_fornecedor='+hf_id_fornecedor+'&id_propriedade='+hf_id_propriedade+'';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
    }            
</script>

<script type="text/javascript"> 

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
  	        
        szUrl = 'lupa_propriedade.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_produtor");
           	     
        szUrl = 'lupa_produtor.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_pessoa.value=retorno;
        } 
    }            
</script>
	<script type="text/javascript"> 

    function ShowDialogItem() 
    
    {
 
        var retorno="";
   	    var szUrl;
        var hf_id_item = document.getElementById("hf_id_item");
        
           	     
        szUrl = 'lupa_item.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_item.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>
    <script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_transportador.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_pessoa.value=retorno;
        } 
    }            
    </script>

	    <form id="Form1" method="post" runat="server">
            <br />
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Solicitar Cotação</STRONG></TD>
					<TD style="width: 12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; ">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    <anthem:Image ID="img_notificacao" runat="server" ImageUrl="~/img/ico_email.gif" Visible="False" AutoUpdateAfterCallBack="True" />
                                    &nbsp;<anthem:LinkButton ID="lk_notificar_aprovadores" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" Style="vertical-align: bottom" Visible="False">Notificar Aprovadores </anthem:LinkButton>
                                    |
                                    <anthem:LinkButton ID="lk_enviar_aprovacao" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" ValidationGroup="vg_verificacoes_finais">Enviar Aprovação</anthem:LinkButton>&nbsp;|
                                    <anthem:LinkButton ID="lk_gerar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Gerar Pedido" ValidationGroup="vg_pedido">Gerar Pedido</anthem:LinkButton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados da Cotação</TD>
							</TR>
                            <tr>
                                <TD class="texto" align="left" style="height: 22px" colspan="2">
                                    <SPAN id="Span4" class="obrigatorio"></span>&nbsp; &nbsp;
                                    <table border="0" width="100%">
                                        <tr runat="server" id="tr_header1" visible="false">
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong>Limite Disponível:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nr_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Valor Total:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_nr_valor_total_cotacao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>% Limite Disp.:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_nr_perc" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr runat="server" id="tr_header3" visible="false">
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong>Valor Mensal Estimado:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nr_valor_mensal_estimado" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>% Valor Estimado:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_nr_perc_valor_estimado" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>Pedidos Abertos:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label>
                                                <anthem:HyperLink ID="hl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="textohlink" Font-Underline="True" Target="_blank" ToolTip="Visualizar Pedidos Abertos"
                                                    UpdateAfterCallBack="True">[hl_nr_total_pedidos_abertos]</anthem:HyperLink></td>
                                        </tr>
                                        <tr runat="server" id="tr_headercontrato" visible="false">
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong>Contrato Produtor:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Início e Fim Contrato:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_dt_ini_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                à
                                                <anthem:Label ID="lbl_dt_fim_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>Rescisão Contrato:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_dt_rescisao_contrato" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr runat="server" id="tr_header2" visible="false">
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong>Nr Cotação:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_id_central_cotacao" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Dt Cotação:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_dt_cotacao" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>Situação:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_situacao_cotacao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span>Estabelecimento:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" AutoPostBack="false"></anthem:DropDownList> 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_abrir_cotacao" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Estabelecimento para continuar." ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Pedido Indireto:</strong></td>
                                            <td align="left" style="height: 19px"><anthem:DropDownList id="cbo_pedido_indireto" runat="server" CssClass="texto" AutoPostBack="false">
                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                            </anthem:DropDownList></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                            </td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span> Propriedade:</strong></td>
                                            <td align="left" colspan="1" style="height: 19px">
                                                &nbsp;<anthem:TextBox ID="txt_id_propriedade" runat="server" AutoCallBack="true"
                                                    AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                                <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_id_propriedade"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                        Font-Bold="True" ValidationGroup="vg_abrir_cotacao" ToolTip="O campo Propriedade deve ser informado.">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                                            ID="cv_propriedade" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade"
                                                            CssClass="texto" Display="Dynamic" ErrorMessage="Propriedade não cadastrado!"
                                                            Font-Bold="true" Text="[!]" ToolTip="Propriedade Não Cadastrada!" ValidationGroup="vg_abrir_cotacao"></anthem:CustomValidator></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Município:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nm_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>Estado:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_cd_uf" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span>UP:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:DropDownList id="cbo_unid_producao" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="false">
	                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_unid_producao"
                                                    CssClass="texto" ErrorMessage="Preencha o campo UP para continuar." Font-Bold="True"
                                                    ValidationGroup="vg_abrir_cotacao">[!]</asp:RequiredFieldValidator></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Acordo Insumos:&nbsp;</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_acordo_aquisicao_insumos" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                            </td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <strong>Produtor:</strong></td>
                                            <td align="left" colspan="1" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nm_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                <strong>Contato:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_ds_contato" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                <strong>Telefone:</strong></td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_ds_telefone" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 14%; height: 18px;">
                                                <strong>Cluster:</strong></td>
                                            <td align="left" colspan="1" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_cluster" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="width: 12%; height: 18px;">
                                                <strong>Email:</strong></td>
                                            <td align="left" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_ds_email" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="width: 10%; height: 18px;">
                                                <strong>Fax:</strong></td>
                                            <td align="left" style="width: 15%; height: 18px;">
                                                &nbsp;<anthem:Label ID="lbl_ds_fax" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 14%; height: 18px">
                                                <strong>Téc. Danone:</strong></td>
                                            <td align="left" colspan="1" style="height: 18px">
                                                <anthem:Label ID="lbl_nm_tecnico_danone" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="width: 12%; height: 18px">
                                                <strong>Téc. EDUCAMPO:</strong></td>
                                            <td align="left" style="height: 18px" colspan="3">
                                                <anthem:Label ID="lbl_nm_tecnico_educampo" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                    </table>
                                    <anthem:label id="lbl_informativo" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" font-italic="True" font-size="8px" forecolor="Red" updateaftercallback="True"
                                        visible="False">Informativo: O limite disponível e o valor mensal estimado foram calculados tendo como base os romaneios abertos do período.</anthem:label>
                                </td>
                            </tr>
	                        <tr id="tr_abrir_cot" runat="server" visible="false">
	                            <TD class="texto" align=right width="23%" style="height: 8px"></td>
	                            <TD style="height: 8px" align="right"><anthem:Button ID="btn_abrir_cotacao" runat="server" Text="Abrir Cotação" ToolTip="Abrir Cotação" CssClass="texto" AutoUpdateAfterCallBack="True" ValidationGroup="vg_abrir_cotacao" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
	                        </tr>
	                        </TABLE>
	                        <table runat=server id="table_body" visible="false" width="100%">
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">
                                    Itens</td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="width: 14%">
                                                <strong>Item:</strong></td>
                                            <td align="left" colspan="2">
                                                &nbsp;<anthem:TextBox ID="txt_cd_item" runat="server" AutoUpdateAfterCallBack="true"
                                                    CssClass="texto" MaxLength="16" Width="72px" AutoCallBack="True"></anthem:TextBox>&nbsp;
                                                <anthem:ImageButton ID="btn_lupa_item" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_item"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Item para continuar ou selecione-o pela lupa."
                                                    Font-Bold="True" ValidationGroup="vg_adicionar_item">[!]</asp:RequiredFieldValidator>
                                                <anthem:CustomValidator ID="cv_validar_item" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_cd_item" ValidationGroup="vg_adicionar_item">[!]</anthem:CustomValidator>&nbsp;
                                                <anthem:Button ID="btn_novo_item" runat="server" Text="Adicionar" ToolTip="Adicionar novo item" CssClass="texto" ValidationGroup="vg_adicionar_item" AutoUpdateAfterCallBack="True" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2"><anthem:GridView ID="gridItens" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="5" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="100%" AddCallBacks="False">
<FooterStyle HorizontalAlign="Center" Wrap="True"></FooterStyle>

<EditRowStyle Width="100%"></EditRowStyle>
<Columns>
<asp:TemplateField HeaderText="Det."><ItemTemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" ImageUrl="~/img/icon_preview.gif" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Cotações do Item" UpdateAfterCallBack="True" CommandName="cotacoes" __designer:wfdid="w35"></anthem:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="cd_item" HeaderText="Item" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="cd_unidade_medida" HeaderText="Un" ReadOnly="True"></asp:BoundField>
<asp:TemplateField HeaderText="Embalagem"><EditItemTemplate>
<anthem:DropDownList id="cbo_tipo_medida" __designer:dtid="562971428257867" runat="server" UpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w37" SelectedValue='<%# bind("ds_tipo_medida") %>'><asp:ListItem Value="G">Granel</asp:ListItem>
<asp:ListItem Value="S">Sacaria</asp:ListItem>
<asp:ListItem Value="O">Outros</asp:ListItem>
<asp:ListItem Selected="True" VALUE="">[Selecione]</asp:ListItem>
</anthem:DropDownList>&nbsp; <asp:RequiredFieldValidator id="rqf_tipo_medida" runat="server" ValidationGroup="vg_salvar_item" CssClass="texto" ControlToValidate="cbo_tipo_medida" ErrorMessage="O tipo de medida deve ser informado." Font-Bold="True" __designer:wfdid="w38">[!]</asp:RequiredFieldValidator> 
</EditItemTemplate>
<FooterTemplate>
&nbsp; 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="lbl_ds_tipo_medida" runat="server" CssClass="texto" Text='<%# Bind("ds_tipo_medida") %>' __designer:wfdid="w36"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Qtde"><EditItemTemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_quantidade" runat="server" CssClass="texto" Width="80px" MaxLength="15" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w40" DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_quantidade" runat="server" ValidationGroup="vg_salvar_item" CssClass="texto" ControlToValidate="txt_nr_quantidade" ErrorMessage="A quantidade deve ser informada." Font-Bold="True" __designer:wfdid="w41">[!]</asp:RequiredFieldValidator><asp:CompareValidator id="CompareValidator1" runat="server" ValidationGroup="vg_salvar_item" CssClass="texto" ControlToValidate="txt_nr_quantidade" ErrorMessage="A quantidade deve ser informada." __designer:wfdid="w42" ValueToCompare="0" Type="Double" Operator="GreaterThan">[!]</asp:CompareValidator> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" CssClass="texto" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w39"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dt Produtor"><EditItemTemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_dt_entrega" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" ErrorMessage="Data Invalida." Width="68px" Text='<%# bind("dt_entrega") %>' __designer:wfdid="w44" DateFormat="Brazil" DateMask="DayMonthYear"></cc4:OnlyDateTextBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_dt_entrega" runat="server" CssClass="texto" Text='<%# Bind("dt_entrega") %>' __designer:wfdid="w43"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Parcelar?"><EditItemTemplate>
<anthem:DropDownList id="cbo_vai_parcelar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="48px" AutoCallBack="True" __designer:wfdid="w46" OnSelectedIndexChanged="cbo_vai_parcelar_SelectedIndexChanged"><asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
<asp:ListItem Value="D">Danone</asp:ListItem>
<asp:ListItem Value="P">Parceiro</asp:ListItem>
</anthem:DropDownList>&nbsp; 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_vai_parcelar" runat="server" CssClass="texto" __designer:wfdid="w45"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Parc."><EditItemTemplate>
<cc3:OnlyNumbersTextBox id="txt_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="24px" MaxLength="2" AutoCallBack="True" Text='<%# Bind("nr_parcelas") %>' __designer:wfdid="w48"></cc3:OnlyNumbersTextBox>&nbsp;<anthem:RequiredFieldValidator id="rfv_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" Visible="False" ValidationGroup="vg_salvar_item" ToolTip="O número de parcelas deve ser informado!" ControlToValidate="txt_nr_parcelas" ErrorMessage="O número de parcelas deve ser informado!" Display="Dynamic" __designer:wfdid="w49">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator id="cv_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" Visible="False" ValidationGroup="vg_salvar_item" ToolTip="O número de parcelas deve ser maio que zero (0)!" ControlToValidate="txt_nr_parcelas" ErrorMessage="O número de parcelas deve ser maio que zero (0)!" __designer:wfdid="w50" ValueToCompare="0" Type="Integer" Operator="GreaterThan">[!]</anthem:CompareValidator><anthem:RangeValidator id="rv_parcelas" runat="server" AutoUpdateAfterCallBack="True" Visible="False" ValidationGroup="vg_salvar_item" ControlToValidate="txt_nr_parcelas" __designer:wfdid="w51" Type="Integer" MinimumValue="1" MaximumValue="3">[!]</anthem:RangeValidator> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_nr_parcelas" runat="server" Text='<%# Bind("nr_parcelas") %>' __designer:wfdid="w47"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ver Mercado"><EditItemTemplate>
<asp:CheckBox id="chk_ver_mercado" runat="server" CssClass="texto" __designer:wfdid="w53"></asp:CheckBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="chk_ver_mercado" runat="server" Enabled="False" CssClass="texto" __designer:wfdid="w52"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Prod Inf."><EditItemTemplate>
<asp:CheckBox id="chk_produtor_informado" runat="server" __designer:wfdid="w55"></asp:CheckBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="chk_produtor_informado" runat="server" Enabled="False" CssClass="texto" __designer:wfdid="w54"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Prazo Pagto Fornec">
        <edititemtemplate>
<anthem:DropDownList id="cbo_prazo_pagto" __designer:dtid="562971428257838" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w57"></anthem:DropDownList> <asp:RequiredFieldValidator id="rqf_prazo_pagto" runat="server" ValidationGroup="vg_salvar_item" ToolTip="Prazo de Pagamento deve ser informado!" CssClass="texto" ControlToValidate="cbo_prazo_pagto" ErrorMessage="O prazo de pagamento deve ser informado." Font-Bold="True" __designer:wfdid="w58">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
        <itemtemplate>
<asp:Label id="lbl_nm_prazo_pagto" runat="server" Text='<%# bind("nm_central_prazo_pagto") %>' __designer:wfdid="w56"></asp:Label> 
</itemtemplate>
    </asp:TemplateField>
<asp:BoundField DataField="nm_central_status_aprovacao" HeaderText="Sit.Item" ReadOnly="True"></asp:BoundField>
    <asp:HyperLinkField DataNavigateUrlFields="id_central_pedido" DataNavigateUrlFormatString="~/frm_central_pedido.aspx?id_central_pedido={0}&amp;tela=frm_central_solicitar_cotacao.aspx" NavigateUrl="~/frm_central_pedido.aspx" HeaderText="Pedido" DataTextField="id_central_pedido" Visible="False" />
    <asp:HyperLinkField DataNavigateUrlFields="id_central_pedido_frete" DataNavigateUrlFormatString="~/frm_central_pedido.aspx?id_central_pedido={0}&amp;tela=frm_central_solicitar_cotacao.aspx"
        DataTextField="id_central_pedido_frete" HeaderText="Pedido Frete" NavigateUrl="~/frm_central_pedido.aspx"
        Visible="False" />
<asp:TemplateField><EditItemTemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar_item" ToolTip="Salvar Item de Cotação" CssClass="texto" CommandName="Update" __designer:wfdid="w61"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Item" ImageAlign="Baseline" CommandName="Cancel" __designer:wfdid="w62"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar_item" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w63"></asp:ValidationSummary> 
</EditItemTemplate>
<ItemTemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" AutoUpdateAfterCallBack="True" ToolTip="Editar Item da Cotação" UpdateAfterCallBack="True" CssClass="texto" CommandName="Edit" __designer:wfdid="w59"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Item da Cotação" ImageAlign="Baseline" CommandName="delete" __designer:wfdid="w60" OnClientClick="if (confirm('Excluindo este item, todas as cotações associadas à ele também serão permanentemente excluídas. Deseja realmente excluir este item da cotação?' )) return true;else return false;" CommandArgument='<%# Bind("id_central_cotacao_item") %>'></anthem:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id_central_cotacao_item" Visible="False"><EditItemTemplate>
<anthem:Label id="lbl_id_central_cotacao_item" runat="server" Visible="False" Text='<%# bind("id_central_cotacao_item") %>' __designer:wfdid="w60"></anthem:Label>
</EditItemTemplate>
<ItemTemplate>
<anthem:Label id="lbl_id_central_cotacao_item" runat="server" Visible="False" Text='<%# bind("id_central_cotacao_item") %>' __designer:wfdid="w59"></anthem:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="id_item" Visible="False"><EditItemTemplate>
<asp:Label id="lbl_item" runat="server" Text='<%# Bind("id_item") %>' __designer:wfdid="w104"></asp:Label> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_item" runat="server" Text='<%# Bind("id_item") %>' __designer:wfdid="w103"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="st_produtor_informado" Visible="False"><EditItemTemplate>
<asp:Label id="st_produtor_informado" runat="server" Text='<%# Bind("st_produtor_informado") %>' __designer:wfdid="w22"></asp:Label>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="st_produtor_informado" runat="server" Text='<%# Bind("st_produtor_informado") %>' __designer:wfdid="w20"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="st_ver_mercado" Visible="False"><EditItemTemplate>
<asp:Label id="st_ver_mercado" runat="server" Text='<%# Bind("st_ver_mercado") %>' __designer:wfdid="w8"></asp:Label> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="st_ver_mercado" runat="server" Text='<%# Bind("st_ver_mercado") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="st_parcelamento" Visible="False">
        <edititemtemplate>
<asp:Label id="lbl_st_parcelamento" runat="server" Text='<%# Bind("st_parcelamento") %>' __designer:wfdid="w7"></asp:Label>
</edititemtemplate>
        <itemtemplate>
<asp:Label id="lbl_st_parcelamento" runat="server" Text='<%# Bind("st_parcelamento") %>' __designer:wfdid="w7"></asp:Label>
</itemtemplate>
    </asp:TemplateField>
</Columns>
</anthem:GridView>
                                    <anthem:CustomValidator ID="cv_itens_fornecedores" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_verificacoes_finais">[!]</anthem:CustomValidator>
                                    &nbsp;
                                    &nbsp; &nbsp;&nbsp; &nbsp;
                                    <anthem:CustomValidator ID="cv_pedido_itens" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator>
                                    <anthem:CustomValidator ID="cv_pedido_aprovacao" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator></td>
	                        </tr>
	                        <TR>
								<TD class="texto" align="right" width="23%"></TD>
	                            <TD></TD>
	                        </TR>
	                        <TR>
	                            <TD class="titmodulo" align="left" colSpan="2">
                                    Cotações para o Item
                                    <anthem:Label ID="lbl_detalhe_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" style="vertical-align: bottom; text-align: left"></anthem:Label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2px" class="texto" align=right width="23%"></TD>
								<TD style="height: 2px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 15px" align="center" colspan="2" class="texto"><anthem:GridView ID="gridCotacoes" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="100%" AddCallBacks="False">
                                        <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                        <EditRowStyle Width="100%" VerticalAlign="Top" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Parceiro ">
                                                <edititemtemplate>
<anthem:DropDownList id="cbo_parceiro_central" __designer:dtid="562971428257838" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" AutoCallBack="True" __designer:wfdid="w145" OnSelectedIndexChanged="cbo_parceiro_central_SelectedIndexChanged"></anthem:DropDownList> <asp:RequiredFieldValidator id="rqf_placa" runat="server" ValidationGroup="vg_salvar_cotacao" CssClass="texto" ControlToValidate="cbo_parceiro_central" ErrorMessage="O Parceiro da Central deve ser informado." Font-Bold="False" __designer:wfdid="w146">[!]</asp:RequiredFieldValidator><anthem:CustomValidator id="cv_parceiro" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar_cotacao" ToolTip="Este parceiro já foi incluído nesta cotação!" ControlToValidate="cbo_parceiro_central" __designer:wfdid="w147" OnServerValidate="cv_parceiro_ServerValidate">[!]</anthem:CustomValidator> 
</edititemtemplate>
                                                <footertemplate>
&nbsp; 
</footertemplate>
                                                <itemtemplate>
<asp:Label id="lbl_ds_parceiro_central" runat="server" CssClass="texto" Text='<%# Bind("nm_abreviado_fornecedor") %>' __designer:wfdid="w152"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ds_contato" HeaderText="Contato" ReadOnly="True" />
                                            <asp:BoundField DataField="ds_telefone_1" HeaderText="Telefone" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Vl Unit&#225;rio">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_valor_unitario" runat="server" AutoUpdateAfterCallBack="True" ToolTip="O preço é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o preço cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." CssClass="texto" Width="56px" MaxLength="13" __designer:wfdid="w128" DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="2"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_compartimento" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" ControlToValidate="txt_nr_valor_unitario" ErrorMessage="O valor unitário deve ser informado." Font-Bold="True" __designer:wfdid="w129">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_valor_unitario" runat="server" ToolTip="O preço é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o preço cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." CssClass="texto" Text='<%# Bind("nr_valor_unitario") %>' __designer:wfdid="w127"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sacaria">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_sacaria" runat="server" AutoUpdateAfterCallBack="True" ToolTip="O valor da Sacaria é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o valor cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." CssClass="texto" Width="56px" MaxLength="13" __designer:wfdid="w131" DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="2"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_litros" runat="server" ValidationGroup="vg_salvar_cotacao" CssClass="texto" ControlToValidate="txt_nr_sacaria" ErrorMessage="A sacaria deve ser informada." Font-Bold="True" __designer:wfdid="w132">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <footertemplate>
&nbsp; 
</footertemplate>
                                                <itemtemplate>
<asp:Label id="lbl_sacaria" runat="server" ToolTip="O valor da Sacaria é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o valor cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." CssClass="texto" Text='<%# Bind("nr_sacaria") %>' __designer:wfdid="w130"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Frete">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_frete" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="56px" MaxLength="13" AutoCallBack="True" __designer:wfdid="w141" MaxCaracteristica="10" MaxMantissa="2" __designer:errorcontrol="'2' could not be set on property 'MaxMantissa'."></cc6:OnlyDecimalTextBox>&nbsp;<anthem:ImageButton id="btn_lupa_frete_valor" __designer:dtid="281505041481785" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="true" Enabled="False" ToolTip="Filtrar Valores Frete" Width="15px" ImageAlign="AbsBottom" Height="15px" BorderStyle="None" CommandName="Lupa" __designer:wfdid="w142"></anthem:ImageButton><asp:RequiredFieldValidator id="rqf_frete" runat="server" Enabled="False" ValidationGroup="vg_salvar_cotacao" CssClass="texto" ControlToValidate="txt_nr_frete" ErrorMessage="O frete deve ser informado." Font-Bold="True" __designer:wfdid="w143">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_frete" runat="server" CssClass="texto" Text='<%# Bind("nr_frete") %>' __designer:wfdid="w140"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo">
                                                <edititemtemplate>
<anthem:DropDownList id="cbo_tipo_frete" runat="server" CssClass="texto" AutoPostBack="True" __designer:wfdid="w150" OnSelectedIndexChanged="cbo_tipo_frete_SelectedIndexChanged"><asp:ListItem Value="C">CIF</asp:ListItem>
<asp:ListItem Value="D">FOB-D</asp:ListItem>
<asp:ListItem Value="I">FOB-I</asp:ListItem>
<asp:ListItem Selected="True">[Sel.]</asp:ListItem>
</anthem:DropDownList><asp:RequiredFieldValidator id="rqf_tipo_frete" runat="server" ValidationGroup="vg_salvar_cotacao" CssClass="texto" ControlToValidate="cbo_tipo_frete" ErrorMessage="O tipo de frete deve ser informado." Font-Bold="True" __designer:wfdid="w151">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_ds_tipo_frete" runat="server" Text='<%# bind("ds_tipo_frete") %>' __designer:wfdid="w149"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transportador">
                                                <edititemtemplate>
<anthem:TextBox id="txt_cd_transportador" __designer:dtid="562984313159767" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto" Width="56px" MaxLength="14" AutoCallBack="True" Text='<%# bind("cd_transportador") %>' __designer:wfdid="w154" OnTextChanged="txt_cd_transportador_TextChanged"></anthem:TextBox>&nbsp;<anthem:Label id="lbl_nm_transportador" __designer:dtid="562984313159768" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto" Text='<%# bind("nm_abreviado_transportador") %>' __designer:wfdid="w155"></anthem:Label> <anthem:ImageButton id="btn_lupa_transportador" __designer:dtid="562984313159769" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="true" ToolTip="Filtrar Transportadores" Width="15px" ImageAlign="AbsBottom" Height="15px" BorderStyle="None" CommandName="LupaTransportador" __designer:wfdid="w156"></anthem:ImageButton><asp:CustomValidator id="cv_transportador" __designer:dtid="562984313159770" runat="server" ValidationGroup="vg_salvar_cotacao" ToolTip="Transportador Não Cadastrado!" CssClass="texto" ControlToValidate="txt_cd_transportador" ErrorMessage="Transportador não cadastrado!" Font-Bold="true" Text="[!]" __designer:wfdid="w157" OnServerValidate="cv_transportador_ServerValidate"></asp:CustomValidator><anthem:RequiredFieldValidator id="rfv_transportador" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar_cotacao" CssClass="texto" ControlToValidate="txt_cd_transportador" ErrorMessage="Preencha o campo Transportador para continuar." __designer:wfdid="w158">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_ds_transportador" runat="server" Text='<%# bind("ds_transportador") %>' __designer:wfdid="w153"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ICMS(-)">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_perc_icms" runat="server" ToolTip="O percentual ICMS é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o valor cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." CssClass="texto" Width="35px" MaxLength="5" __designer:wfdid="w95" MaxCaracteristica="3" MaxMantissa="2"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_icms" runat="server" ValidationGroup="vg_salvar_cotacao" ToolTip="O percentual icms deve ser informado." CssClass="texto" ControlToValidate="txt_nr_perc_icms" ErrorMessage="O percentual icms deve ser informado." Font-Bold="True" __designer:wfdid="w96">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_perc_icms" runat="server" ToolTip="O percentual ICMS é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o valor cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento." Text='<%# bind("nr_perc_icms") %>' __designer:wfdid="w94"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vl Total">
                                                <edititemtemplate>
<asp:Label id="lbl_nr_valor_total" runat="server" Text='<%# bind("nr_valor_total") %>' __designer:wfdid="w98"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_valor_total" runat="server" Text='<%# bind("nr_valor_total") %>' __designer:wfdid="w97"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vl Med.">
                                                <edititemtemplate>
<asp:Label id="lbl_nr_valor_medida" runat="server" __designer:wfdid="w100"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_valor_medida" runat="server" __designer:wfdid="w99"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dt Fornec">
                                                <edititemtemplate>
<cc4:OnlyDateTextBox onblur="JScript:return val_date(this);" id="txt_data_entrega" onkeypress="JScript:return DateOnKeyPress(this,event);" runat="server" CssClass="texto" ErrorMessage="Data Invalida." Width="68px" Text='<%# bind("dt_entrega") %>' __designer:wfdid="w102" DateFormat="Brazil" DateMask="DayMonthYear"></cc4:OnlyDateTextBox> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_data_entrega" runat="server" CssClass="texto" Text='<%# bind("dt_entrega") %>' __designer:wfdid="w101"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sel.">
                                                <edititemtemplate>
<asp:CheckBox id="chk_st_selecionado" runat="server" __designer:wfdid="w104"></asp:CheckBox><anthem:CustomValidator id="cv_cotacao" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar_cotacao" ToolTip="Já existe cotação selecionada!" __designer:wfdid="w105" OnServerValidate="cv_cotacao_ServerValidate">[!]</anthem:CustomValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:CheckBox id="chk_st_selecionado" runat="server" Enabled="False" __designer:wfdid="w103"></asp:CheckBox> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sit. Item" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_nm_central_status_aprovacao" runat="server" __designer:wfdid="w106"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CssClass="texto" ValidationGroup="vg_salvar_cotacao" ToolTip="Salvar Cotacao" CommandName="Update" __designer:wfdid="w14"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Coleta" ImageAlign="Baseline" CommandName="Cancel" __designer:wfdid="w15"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_salvar_cotacao" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w16"></asp:ValidationSummary> 
</edititemtemplate>
                                                <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="texto" ToolTip="Editar Coleta" CommandName="Edit" __designer:wfdid="w12"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Coleta" ImageAlign="Baseline" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir este registro de cotação?' )) return true;else return false;" CommandArgument='<%# Bind("id_central_cotacao_fornecedor") %>' __designer:wfdid="w13"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="id_central_cotacao_fornecedor" >
                                                <itemtemplate>
<anthem:Label id="lbl_id_central_cotacao_fornecedor" runat="server" Visible="False" Text='<%# bind("id_central_cotacao_fornecedor") %>' __designer:wfdid="w228"></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_central_cotacao_item" Visible="False">
                                                <edititemtemplate>
<anthem:Label id="lbl_id_central_cotacao_item" runat="server" Visible="False" Text='<%# bind("id_central_cotacao_item") %>' __designer:wfdid="w182"></anthem:Label>
</edititemtemplate>
                                                <itemtemplate>
<anthem:Label id="lbl_id_central_cotacao_item" runat="server" Visible="False" Text='<%# bind("id_central_cotacao_item") %>' __designer:wfdid="w181"></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_item" Visible="False">
                                                <itemtemplate>
<anthem:Label id="lbl_id_item" runat="server" Text='<%# bind("id_item") %>' __designer:wfdid="w174"></anthem:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="st_selecionado" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_st_selecionado" runat="server" Text='<%# Bind("st_selecionado") %>' __designer:wfdid="w14"></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_st_selecionado" runat="server" Text='<%# Bind("st_selecionado") %>' __designer:wfdid="w10"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantidade" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" Visible="true" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w109"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" Visible="true" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w108"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_transportador" SortExpression="id_transportador"
                                                Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" Text='<%# Bind("id_transportador") %>' __designer:wfdid="w121"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" Text='<%# Bind("id_transportador") %>' __designer:wfdid="w120"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                </anthem:GridView>
                                    &nbsp;
                                    <br />
                                    <anthem:Button ID="btn_adicionar_cotacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Adicionar Cotação" ToolTip="Adicionar nova cotação" Enabled="False" /></TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px"></TD>
				</TR>
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
            <asp:ValidationSummary ID="vs_abrir_cotacao" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_abrir_cotacao" /><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_adicionar_item" />
           <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_sel_id_item" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_sel_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
