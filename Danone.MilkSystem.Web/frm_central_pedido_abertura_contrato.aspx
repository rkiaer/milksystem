<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_abertura_contrato.aspx.vb" Inherits="frm_central_pedido_abertura_contrato" %>

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
   <title>Abertura de Pedido por Contrato</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>

<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_produtor = document.getElementById("hf_id_produtor");
           	     
        szUrl = 'lupa_produtor.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_produtor.value=retorno;
        } 
    }            
</script>

<script type="text/javascript" language="javascript">
		function clearDataFornec()
        {
           if (document.getElementById("<%=txt_nm_fornecedor.ClientID %>").value == "[Filtre Nome]")
           {
                document.getElementById("<%=txt_nm_fornecedor.ClientID %>").value = "";
            }
		}
		
</script>

<script type="text/javascript" language="javascript">
		function clearDataItem()
        {
           if (document.getElementById("<%=txt_nm_item.ClientID %>").value == "[Filtre Nome]")
           {
                document.getElementById("<%=txt_nm_item.ClientID %>").value = "";
            }
		}
</script>
</head>
	<body leftMargin="0" topMargin="0" >

	    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td style="width: 7px">
                    &nbsp;</td>
                <td class="faixafiltro1" style="background-image: url(img/tab_dim.gif);">
                    <strong>Central de Compras - Abrir Pedido CONTRATO</strong></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td valign="top" align="center" class="texto">
                    <table id="Table2" cellspacing="0" cellpadding="1" width="100%">
                        <tr>
                            <td class="faixafiltro1a" style="height: 25px;" valign="middle" align="left" background="img/faixa_filro.gif">
                                &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                    ID="lk_voltar" runat="server" CausesValidation="False" Font-Size="XX-Small">voltar</asp:LinkButton>&nbsp;
                                |&nbsp;
                                <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                    ID="lk_novo" runat="server" Font-Size="XX-Small">Novo</anthem:LinkButton>
                                &nbsp; |&nbsp;
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:LinkButton
                                    ID="lk_concluir" runat="server" Font-Size="XX-Small" ValidationGroup="vg_salvar_inf">Salvar</anthem:LinkButton></td>
                            <td class="faixafiltro1a"  align="right" background="img/faixa_filro.gif">
                                <anthem:Image ID="img_notificacao" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" ImageUrl="~/img/ico_email.gif" Visible="False" />
                                <anthem:LinkButton ID="lk_email_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                    Enabled="False" Style="vertical-align: bottom" ToolTip="Envio do Pedido ao Email do Produtor">Email Produtor</anthem:LinkButton>
                                &nbsp; &nbsp;<anthem:Image ID="img_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" ImageUrl="~/img/ico_email.gif" Visible="False" />&nbsp;
                                <anthem:LinkButton ID="lk_email_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                    Style="vertical-align: bottom" ToolTip="Envio do Pedido ao Email do Parceiro" Enabled="False">Email Parceiro</anthem:LinkButton>&nbsp;
                                <anthem:Image ID="img_parceiro_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" ImageUrl="~/img/ico_email.gif" Visible="False" />&nbsp;
                                <anthem:LinkButton ID="lk_email_parceiro_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    Enabled="False" Style="vertical-align: bottom" ToolTip="Envio do Pedido ao Email do Parceiro de Frete">Email Parceiro Frete</anthem:LinkButton>&nbsp;
                                | &nbsp;<anthem:LinkButton ID="lk_exportar" runat="server" AutoUpdateAfterCallBack="True" Font-Size="X-Small" Style="vertical-align: bottom" ToolTip="Exportar dados do Contrato para Excel"
                                    ValidationGroup="vg_pedido" Enabled="False" Visible="False">Exportar</anthem:LinkButton>
                                &nbsp;|
                                &nbsp;
                                <anthem:LinkButton ID="lk_gerar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                    Style="vertical-align: bottom" ToolTip="Gerar Pedido e finalizar Contrato" ValidationGroup="vg_pedido"
                                    OnClick="lk_gerar_pedido_Click" Font-Size="X-Small">Finalizar Contrato e Gerar Pedido</anthem:LinkButton>
                                &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td> </td>
                <td style="font-size: x-small">
                    <table width="100%">
                        <tr>
                            <td style="height: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Dados do Pedido de Contrato</td>
                        </tr>
                        <tr>
                            <td class="texto" align="center" colspan="2" style="font-size: x-small">
                                <table width="100%">
                                    <tr>
                                        <td align="right" style="width: 10%; height: 24px; font-size: x-small;">
                                            <span style="color: #ff0000">*</span>Estabelecimento:</td>
                                        <td align="left" style="width: 13%; font-size: x-small; height: 24px;">
                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto"
                                                AutoPostBack="True" Font-Size="X-Small" AutoUpdateAfterCallBack="True">
                                            </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ValidationGroup="vg_incluircontrato" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator>&nbsp;</td>
                                        <td align="right" style="width: 5%; font-size: x-small; height: 24px;">
                                            Contrato:
                                        </td>
                                        <td align="left" style="width: 6%; height: 24px; font-size: x-small;">
                                            <anthem:Label ID="lbl_nr_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True" BorderStyle="None" Font-Size="X-Small"></anthem:Label></td>
                                        <td align="right" style="width: 6%; height: 24px; font-size: x-small;">
                                            Descrição:
                                        </td>
                                        <td align="left" style="height: 24px; width: 15%; font-size: x-small;">
                                            <anthem:TextBox ID="txt_descricao" runat="server" AutoUpdateAfterCallBack="true"
                                                CssClass="texto" Font-Size="X-Small" MaxLength="200" Width="180px"></anthem:TextBox></td>
                                        <td align="right" style="font-size: x-small; width: 5%; height: 24px">
                                            Perí&shy;odo:</td>
                                        <td align="left" style="font-size: x-small; height: 24px; width: 203px;">
                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" DateMask="MonthYear"
                                                Width="72px" CssClass="texto"></cc4:OnlyDateTextBox>&nbsp; à&nbsp;
                                            <cc4:OnlyDateTextBox ID="txt_dt_fim" runat="server" DateMask="MonthYear" Width="72px"
                                                CssClass="texto"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                                    runat="server" ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="Preencha o campo PerÃ­odo Inicial para continuar."
                                                    Font-Bold="False" ValidationGroup="vg_incluircontrato">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_dt_fim" CssClass="texto"
                                                        ErrorMessage="Preencha o campo PerÃ­odo Final para continuar." Font-Bold="False"
                                                        ValidationGroup="vg_incluircontrato">[!]</asp:RequiredFieldValidator></td>
                                        <td align="center" style="font-size: x-small; height: 24px">
                                            Qtde Prop.:
                                            <anthem:Label ID="lbl_qtde_prop" runat="server" AutoUpdateAfterCallBack="True" BorderStyle="None"
                                                CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True"></anthem:Label>
                                        </td>
                                        <td align="right" style="font-size: x-small; height: 24px">
                                            &nbsp;Situação Contrato:
                                            <anthem:Label ID="lbl_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                BorderStyle="None" CssClass="texto" Font-Size="X-Small" UpdateAfterCallBack="True">Novo</anthem:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Dados do Parceiro de Insumos</td>
                        </tr>
                        <tr>
                            <td class="texto" align="center" colspan="2" valign="middle">
                                <table width="100%" ">
                                    <tr>
                                        <td align="right" style="height: 20px; font-size: x-small; width: 10%;">
                                            <span style="color: #ff0000">*</span>Parceiro:</td>
                                        <td align="left" style="height: 20px; font-size: x-small;">
                                            &nbsp;<anthem:TextBox ID="txt_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="true"
                                                CssClass="texto" MaxLength="100" onfocus="clearDataFornec()" Width="100px" AutoPostBack="True">[Filtre Nome]</anthem:TextBox>&nbsp;<anthem:Label
                                                    ID="lbl_selecione1" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                                    Font-Size="X-Small" Height="16px" UpdateAfterCallBack="True">Selecione:</anthem:Label>
                                            <anthem:DropDownList ID="cbo_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" AutoPostBack="True">
                                            </anthem:DropDownList><anthem:Label ID="lbl_dsfornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="Texto" Font-Size="X-Small" Height="16px" UpdateAfterCallBack="True"></anthem:Label><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_fornecedor"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Parceiro para continuar." Font-Bold="True"
                                                    InitialValue="0" ValidationGroup="vg_incluircontrato">[!]</asp:RequiredFieldValidator></td>
                                        <td align="center" style="font-size: x-small; width: 12%; height: 20px">
                                            Frete CIF Parceiro:
                                            <anthem:Label ID="lbl_frete_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="Texto" UpdateAfterCallBack="True" Font-Size="X-Small">Não</anthem:Label></td>
                                        <td align="center" style="height: 20px; font-size: x-small; width: 15%;">
                                            Exceção Prazo Pagto:
                                            <anthem:Label ID="lbl_excecao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                Font-Size="X-Small" UpdateAfterCallBack="True">Sim</anthem:Label></td>
                                        <td align="right" style="height: 20px; font-size: x-small; width: 14%;">
                                            Qtde Total:
                                            <cc6:OnlyDecimalTextBox ID="txt_nr_qtde_total" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="15" MaxMantissa="4"
                                                Width="80px" Font-Size="X-Small" Style="text-align: right"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_nr_qtde_total"
                                                    CssClass="texto" ErrorMessage="A quantidade total do insumo deve ser informado."
                                                    Font-Bold="False" ToolTip="A quantidade total do insumo deve ser informada."
                                                    ValidationGroup="vg_incluircontrato">[!]</asp:RequiredFieldValidator></td>
                                        <td align="center" style="height: 20px; font-size: x-small; width: 18%;">
                                            Qtde Incluida:<anthem:Label ID="lbl_qtde_incluida" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

					</table>
                </td>
                <td>&nbsp;</td>  
            </tr>
                
			<tr>
                <td> </td>
                <td style="font-size: x-small">
                    <table width="100%">
                        <tr>
                            <td style="height: 16px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Dados do Item do Pedido</td>
                        </tr>
                        <tr>
                            <td class="texto" align="center" colspan="2">
                                <table width="100%" style="font-size: x-small; border-collapse: collapse;">
                                    <tr>
                                        <td align="right" style="font-size: x-small; width: 10%;">
                                            <span style="color: #ff0000">*</span>Item:</td>
                                        <td align="left" style="font-size: x-small;" colspan="3">
                                            &nbsp;<anthem:TextBox ID="txt_nm_item" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="true"
                                                CssClass="texto" MaxLength="100" onfocus="clearDataItem()" Width="100px">[Filtre Nome]</anthem:TextBox>&nbsp;<anthem:Label
                                                    ID="lbl_selecione2" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                                    Font-Size="X-Small" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True">Selecione:</anthem:Label>
                                            <anthem:DropDownList ID="cbo_item" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" AutoPostBack="True" Font-Size="X-Small">
                                            </anthem:DropDownList><anthem:Label ID="lbl_dsitem" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="Texto" Font-Size="X-Small" Height="16px" Style="vertical-align: bottom"
                                                UpdateAfterCallBack="True"></anthem:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    runat="server" ControlToValidate="cbo_item" CssClass="texto" ErrorMessage="Selecione o campo CÃ³digo do Item para continuar."
                                                    Font-Bold="True" ValidationGroup="vg_incluircontrato" InitialValue="0">[!]</asp:RequiredFieldValidator>
                                            &nbsp;&nbsp;
                                            <anthem:Label ID="lbl_nm_categoria_tit" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False" Font-Size="X-Small">Categoria:</anthem:Label>
                                            <anthem:Label ID="lbl_nm_categoria" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label><anthem:CustomValidator
                                                    ID="cv_validar_inclusao" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_incluircontrato">[!]</anthem:CustomValidator></td>
                                        <td align="center" style="font-size: x-small">
                                            <span style="color: #ff0000">*</span>Vl Unit:
                                            <cc6:OnlyDecimalTextBox ID="txt_nr_valor_unitario" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13" MaxMantissa="2"
                                                ToolTip="O preÃ§o Ã© trazido da Tabela de PreÃ§os onde o municÃ­pio destino Ã© o mesmo da propriedade. Caso nÃ£o exista, serÃ¡ trazido o preÃ§o cadastrado para municÃ­pio destino Todos, sempre respeitando a data mais recente de cadastramento."
                                                UpdateAfterCallBack="True" Width="65px" Style="text-align: right"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                    ID="rqf_valor_unitario" runat="server" ControlToValidate="txt_nr_valor_unitario"
                                                    CssClass="texto" ErrorMessage="O valor unitÃ¡rio deve ser informado." Font-Bold="False"
                                                    ValidationGroup="vg_incluircontrato">[!]</asp:RequiredFieldValidator>
                                            &nbsp; &nbsp;
                                        </td>
                                        <td align="left" style="font-size: x-small; width: 15%">
                                            Vl Sacaria:&nbsp;
                                            <cc6:OnlyDecimalTextBox ID="txt_nr_sacaria" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13" MaxMantissa="2"
                                                ToolTip="O valor da Sacaria Ã© trazido da Tabela de PreÃ§os onde o municÃ­pio destino Ã© o mesmo da propriedade. Caso nÃ£o exista, serÃ¡ trazido o valor cadastrado para municÃ­pio destino Todos, sempre respeitando a data mais recente de cadastramento."
                                                UpdateAfterCallBack="True" Width="60px" Style="text-align: right"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator
                                                    ID="rfv_sacaria" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_sacaria"
                                                    ErrorMessage="A sacaria deve ser informada." ToolTip="A sacaria deve ser informada."
                                                    ValidationGroup="vg_incluircontrato">[!]</anthem:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

					</table>
                </td>
                <td>&nbsp;</td>
	        </tr>
            <tr id="tr_incluir_novo_contrato" runat="server">
                <td>
                </td>
                <td align="center">
                    <anthem:Button ID="btn_abrirpedidocontrato" runat="server" AutoUpdateAfterCallBack="True"
                        CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px"
                        Text="Incluir Novo Contrato de Pedido" ToolTip="Incluir o novo contrato de pedido."
                        ValidationGroup="vg_incluircontrato" />
                </td>
                <td>
                </td>
            </tr>
            <tr id="tr_dados_produtores" runat="server" visible="false">
                <td>
                </td>
                <td style="font-size: x-small">
                    <table width="100%">
                        <tr id="tr_prod_selecao" runat="server" >
                            <td style="height: 15px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Selecione o Produtor</td>
                        </tr>
                        <tr id="tr_prod_dados" runat="server" >
                            <td class="texto" align="left" style="height: 22px" colspan="2">
                                <table width="100%" style="font-size: x-small">
                                    <tr>
                                        <td align="right" style="width: 10%; height: 18px">
                                            <span style="color: #ff0000">*</span> Produtor:</td>
                                        <td align="left" style="height: 18px">
                                            &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                CssClass="texto" MaxLength="10" Width="72px" Font-Size="X-Small"></anthem:TextBox>
                                            &nbsp;<anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                ToolTip="Filtrar Produtores" Width="15px" />
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                                Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_pessoa"
                                                CssClass="texto" ErrorMessage="Preencha o campo CÃ³digo da Propriedade para continuar ou selecione-o pela lupa."
                                                Font-Bold="True" ValidationGroup="vg_adicionarprop" ToolTip="O campo Produtor deve ser informado.">[!]</asp:RequiredFieldValidator></td>
                                        <td align="right" style="height: 18px">
                                            Telefone:</td>
                                        <td align="left" style="width: 9%; height: 18px">
                                            <anthem:Label ID="lbl_ds_telefone" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        <td align="right" style="height: 18px">
                                            Email:
                                        </td>
                                        <td align="left" style="height: 18px; width: 15%;">
                                            <anthem:Label ID="lbl_ds_email" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        <td align="center" style="width: 11%; height: 18px">
                                            Acordo Insumos:
                                            <anthem:Label ID="lbl_acordo_aquisicao_insumos" runat="server" CssClass="texto" UpdateAfterCallBack="True"
                                                Font-Size="X-Small">Não</anthem:Label></td>
                                        <td align="left" style="width: 15%; height: 18px">
                                            Cluster:
                                            <anthem:Label ID="lbl_cluster" runat="server" CssClass="texto" UpdateAfterCallBack="True"
                                                Font-Size="X-Small"></anthem:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px;" align="right">
                                            Contrato Produtor:</td>
                                        <td align="left" style="height: 18px" colspan="2">
                                            &nbsp;<anthem:Label ID="lbl_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True"
                                                Font-Size="X-Small"></anthem:Label></td>
                                        <td align="right" style="height: 18px" colspan="2">
                                            Ini. e Fim Contrato:</td>
                                        <td style="height: 18px;" align="left" colspan="2">
                                            &nbsp;<anthem:Label ID="lbl_dt_ini_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True"
                                                Font-Size="X-Small"></anthem:Label>
                                            &nbsp;&nbsp;à&nbsp;&nbsp;<anthem:Label ID="lbl_dt_fim_contrato_sel" runat="server" CssClass="texto" UpdateAfterCallBack="True"
                                                Font-Size="X-Small"></anthem:Label></td>
                                        <td align="left" style="height: 18px">
                                            Rescisão:
                                            <anthem:Label ID="lbl_dt_rescisao_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="tr_branco1" runat="server">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr id="tr_prod_grid" runat="server" >
                            <td align="center" valign="top" colspan="2">
                                <anthem:GridView ID="gridPropriedades" runat="server" AutoGenerateColumns="False"
                                    AutoUpdateAfterCallBack="True" CellPadding="3" CssClass="texto" Font-Names="Verdana"
                                    Font-Size="X-Small" ForeColor="#333333" PageSize="100" UpdateAfterCallBack="True"
                                    Width="95%">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                        ForeColor="White" />
                                    <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Center" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <itemtemplate>
<anthem:ImageButton id="imgselecionar" runat="server" ImageUrl="~/img/ico_triangulo_cinza.gif" CausesValidation="False" AutoUpdateAfterCallBack="True" Text="Select" CommandName="Select" __designer:wfdid="w55"></anthem:ImageButton> 
</itemtemplate>
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Produtor">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cd_uf" HeaderText="UF" ReadOnly="True">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_cidade" HeaderText="Cidade" ReadOnly="True">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Limite Bruto">
                                            <itemtemplate>
												<anthem:Label id="lbl_nr_limite_mes_bruto" runat="server"></anthem:Label> 
												
</itemtemplate>
                                            <itemstyle horizontalalign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descontos">
                                            <itemtemplate>
<anthem:Label id="lbl_nr_valor_desconto" runat="server"></anthem:Label> 
</itemtemplate>
                                            <itemstyle horizontalalign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pedidos Abertos">
                                            <itemtemplate>
<anthem:Label id="lbl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label><anthem:HyperLink id="hl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Pedidos Abertos" CssClass="textohlink" UpdateAfterCallBack="True" Font-Underline="True" Target="_blank">[hl_nr_total_pedidos_abertos]</anthem:HyperLink> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Limite Dispon&#237;vel">
                                            <itemtemplate>
<anthem:Label id="lbl_nr_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vol M&#234;s Estimado">
                                            <itemtemplate>
<anthem:Label id="lbl_nr_valor_mensal_estimado" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("volumemes") %>'></anthem:Label> 
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_cidade" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_cidade" runat="server" Text='<%# Bind("id_cidade") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_estado" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_estado" runat="server" Text='<%# Bind("id_estado") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_cidade_matriz" Visible="False">
                                            <edititemtemplate>
&nbsp;
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_cidade_matriz" runat="server" Text='<%# Bind("id_cidade_matriz") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_estado_matriz" Visible="False">
                                            <edititemtemplate>
&nbsp;
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_estado_matriz" runat="server" Text='<%# Bind("id_estado_matriz") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                            <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="matriz" Visible="False">
                                            <edititemtemplate>
&nbsp;
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" Text='<%# Bind("matriz") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_produtor" runat="server" Text='<%# Bind("id_pessoa") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="row_num" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_row_num" runat="server" Text='<%# Bind("row_num") %>'></asp:Label>
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="indexgridmatriz" Visible="False">
                                            <itemtemplate>
<anthem:Label id="lbl_indexgridmatriz" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </anthem:GridView>
                                <anthem:Label ID="lbl_informativo_1" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Italic="True" Font-Size="10px" ForeColor="Red" UpdateAfterCallBack="True"
                                    Visible="False">*Informativo: O cálculo do limite para propriedade foi baseado na projeção do Custo Financeiro.</anthem:Label>
                                <anthem:Label ID="lbl_informativo_2" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Italic="True" Font-Size="10px" ForeColor="Blue" UpdateAfterCallBack="True"
                                    Visible="False">**Informativo: Não existe faturamento anterior ou custo projetado para cálculo do limite. Os pedidos abertos para propriedades sem limite serão enviados para aprovação.</anthem:Label>
                            </td>
                        </tr>
                        <tr id="tr_branco2" runat="server">
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr id="tr_prod_inclusao" runat="server" >
                            <td style="height: 15px; font-size: x-small;" colspan="2" class="texto" align="center"
                                valign="bottom">
                                <table style="border-right: silver 1px solid; border-top: silver 1px solid; font-size: x-small;
                                    border-left: silver 1px solid; border-bottom: silver 1px solid; border-collapse: collapse"
                                    width="98%">
                                    <tr>
                                        <td style="border-right: silver 1px solid; height: 25px" align="center">
                                            Qtde Total Prop.:
                                            <cc6:OnlyDecimalTextBox ID="txt_ip_qtde_total_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" DecimalSymbol="," Font-Size="X-Small" MaxCaracteristica="10"
                                                MaxLength="15" MaxMantissa="4" Width="70px" style="text-align: right"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_ip_qtde_total_propriedade"
                                                    CssClass="texto" ErrorMessage="Quantidade Total para Propriedade deve ser informada."
                                                    Font-Bold="False" ValidationGroup="vg_adicionarprop" ToolTip="Qtde total do insumo deve ser informada.">[!]</asp:RequiredFieldValidator></td>
                                        <td align="center" style="border-right: silver 1px solid; height: 25px">
                                            Embalagem:
                                            <anthem:DropDownList ID="cbo_ip_tipo_medida" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True">
                                                <asp:ListItem Value="G">Granel</asp:ListItem>
                                                <asp:ListItem Value="S">Sacaria</asp:ListItem>
                                                <asp:ListItem Value="O">Outros</asp:ListItem>
                                                <asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
                                            </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                ControlToValidate="cbo_ip_tipo_medida" CssClass="texto" ErrorMessage="Tipo de Embalagem deve ser informada."
                                                Font-Bold="False" ToolTip="Tipo de embalagem deve ser informada." ValidationGroup="vg_adicionarprop">[!]</asp:RequiredFieldValidator></td>
                                        <td style="border-right: silver 1px solid; height: 25px;" align="center">
                                            Parcelar?
                                            <anthem:DropDownList ID="cbo_ip_vai_parcelar" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto">
                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                <asp:ListItem Value="D">Danone</asp:ListItem>
                                                <asp:ListItem Value="P">Parceiro</asp:ListItem>
                                            </anthem:DropDownList>
                                            Quantas?
                                            <cc3:OnlyNumbersTextBox ID="txt_ip_nr_parcelas" runat="server" AutoCallBack="True"
                                                AutoUpdateAfterCallBack="True" CssClass="texto" MaxLength="2" Text="1" UpdateAfterCallBack="True"
                                                Width="30px" style="text-align: center"></cc3:OnlyNumbersTextBox><anthem:RequiredFieldValidator ID="rfv_ip_nr_parcelas"
                                                    runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_ip_nr_parcelas"
                                                    ErrorMessage="O nÃºmero de parcelas deve ser informado!" ToolTip="O nÃºmero de parcelas deve ser informado!"
                                                    ValidationGroup="vg_adicionarprop">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                        ID="cv_ip_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_ip_nr_parcelas"
                                                        ErrorMessage="O nÃºmero de parcelas deve ser maio que zero (0)!" Operator="GreaterThan"
                                                        ToolTip="O nÃºmero de parcelas deve ser maio que zero (0)!" Type="Integer" ValidationGroup="vg_adicionarprop"
                                                        ValueToCompare="0">[!]</anthem:CompareValidator><anthem:RangeValidator ID="rv_ip_parcelas"
                                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_ip_nr_parcelas"
                                                            Enabled="False" MaximumValue="3" MinimumValue="1" Type="Integer" ValidationGroup="vg_adicionarprop">[!]</anthem:RangeValidator></td>
                                        <td style="border-right: silver 1px solid; height: 25px">
                                            <anthem:CheckBox ID="chk_ip_pedindireto" runat="server" AutoUpdateAfterCallBack="True"
                                                Text="Ped.Indireto" /></td>
                                        <td style="border-right: silver 1px solid; height: 25px;">
                                            Tipo Frete:
                                            <anthem:DropDownList ID="cbo_ip_tipofrete" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" Font-Size="X-Small">
                                                <asp:ListItem Value="" Selected="True">[Sel.]</asp:ListItem>
                                                <asp:ListItem Value="C">CIF</asp:ListItem>
                                                <asp:ListItem Value="D">FOB-D</asp:ListItem>
                                                <asp:ListItem Value="I">FOB-I</asp:ListItem>
                                            </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                ControlToValidate="cbo_ip_tipofrete" CssClass="texto" ErrorMessage="Tipo de Frete deve ser informado."
                                                Font-Bold="False" ToolTip="Tipo de frete deve ser informado." ValidationGroup="vg_adicionarprop">[!]</asp:RequiredFieldValidator></td>
                                        <td align="center" rowspan="2">
                                            <anthem:CustomValidator ID="cv_incluirpropriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                ForeColor="White" ValidationGroup="vg_adicionarprop">[!]</anthem:CustomValidator><anthem:Button ID="btn_incluirpropriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px"
                                                Text="Incluir Propriedade" ToolTip="Incluir propriedade selecionada ao contrato"
                                                ValidationGroup="vg_adicionarprop" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: silver 1px solid; height: 20px; border-top: silver 1px solid;" colspan="5">
                                        Meses de Entrega: 
                                            <anthem:CheckBox ID="chk_todas" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                Text="Todos" />&nbsp; &nbsp;&nbsp;
                                            <anthem:CheckBoxList ID="chk_meses" runat="server" CellPadding="2" CellSpacing="5"
                                                CssClass="texto" RepeatDirection="Horizontal" RepeatLayout="Flow" style="padding-right: 5px; padding-left: 5px; text-transform: uppercase" AutoUpdateAfterCallBack="True" RepeatColumns="12">
                                                <Items>
                                                    <asp:ListItem Value="1">JAN</asp:ListItem>
                                                    <asp:ListItem Value="2">FEV</asp:ListItem>
                                                    <asp:ListItem Value="3">MAR</asp:ListItem>
                                                    <asp:ListItem Value="4">ABR</asp:ListItem>
                                                    <asp:ListItem Value="5">MAI</asp:ListItem>
                                                    <asp:ListItem Value="6">JUN</asp:ListItem>
                                                    <asp:ListItem Value="7">JUL</asp:ListItem>
                                                    <asp:ListItem Value="8">AGO</asp:ListItem>
                                                    <asp:ListItem Value="9">SET</asp:ListItem>
                                                    <asp:ListItem Value="10">OUT</asp:ListItem>
                                                    <asp:ListItem Value="11">NOV</asp:ListItem>
                                                    <asp:ListItem Value="12">DEZ</asp:ListItem>
                                                </Items>
                                            </anthem:CheckBoxList>
                                            &nbsp;&nbsp;</td>
                                    </tr>
                                </table>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <anthem:Label ID="lbl_politica_parcelamento" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Italic="True" Font-Size="11px" ForeColor="Red" UpdateAfterCallBack="True">*Política de Parcelamento DANONE: máximo de 4 parcelas.</anthem:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 15px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Propriedades Adicionadas X Quantidades Mensais</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="height: 15px; font-size: x-small;" class="texto">
                                <br />
                                <table style="border-right: silver 1px solid; border-top: silver 1px solid;
                                    font-size: x-small; border-left: silver 1px solid; border-bottom: silver 1px solid;
                                    border-collapse: collapse" width="98%">
                                    <tr>
                                        <td align="center" style="border-right: silver 1px solid; height: 25px">
                                            Produtor:
                                            <anthem:DropDownList ID="cbo_produtor_filtro" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True" AutoCallBack="True">
                                            </anthem:DropDownList></td>
                                        <td align="center" style="border-right: silver 1px solid;  height: 25px">
                                            Propriedade:
                                            <anthem:DropDownList ID="cbo_propriedade_filtro" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True">
                                            </anthem:DropDownList></td>
                                        <td align="center" style="border-right: silver 1px solid; height: 25px">
                                            Mês de Entrega com Qtde:
                                            <anthem:DropDownList ID="cbo_referencia_filtro" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" UpdateAfterCallBack="True">
                                                <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="1">1</asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="2">2</asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="3">3</asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="4">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="5">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="6">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="7">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="8">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="9">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="10">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="11">
                                                </asp:ListItem>
                                                <asp:ListItem Enabled="False" Value="12">
                                                </asp:ListItem>
                                            </anthem:DropDownList></td>
                                        <td align="center">
                                            <anthem:Button ID="btn_filtrar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px" Text="Filtrar"
                                                ToolTip="Filtrar propriedades adicionadas" Enabled="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: x-small;" colspan="2">
                                <table id="Table7" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td align="center" class="texto"  >
                                            <anthem:GridView ID="gridqtdes" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                                CellPadding="2" CssClass="texto" Font-Names="Verdana" Font-Size="X-Small" Height="24px"
                                                PageSize="100" UpdateAfterCallBack="True" Width="99%" Visible="False" DataKeyNames="id_propriedade">
                                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Det.">
                                                        <itemtemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" ImageUrl="~/img/icon_preview.gif" ToolTip="Visualizar Detalhes Pedido da Propriedade" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w83" CommandName="detalhepedido"></anthem:ImageButton> 
</itemtemplate>
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Produtor">
                                                        <itemstyle horizontalalign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Prop." ReadOnly="True" DataField="id_propriedade">
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Janeiro">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes1" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," Text='<%# bind("nr_valor_01") %>' __designer:wfdid="w81"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fevereivo">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes2" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," Text='<%# bind("nr_valor_02") %>' __designer:wfdid="w80"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mar&#231;o">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes3" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," Text='<%# bind("nr_valor_03") %>' __designer:wfdid="w79"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Abril">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes4" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_04") %>' __designer:wfdid="w78"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Maio">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes5" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_05") %>' __designer:wfdid="w74"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Junho">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes6" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_06") %>' __designer:wfdid="w75"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Julho">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes7" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_07") %>' __designer:wfdid="w76"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agosto">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes8" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_08") %>'></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Setembro">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes9" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_09") %>'></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Outubro">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes10" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_10") %>'></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Novembro">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes11" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_11") %>'></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dezembro">
                                                        <itemtemplate>
<cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_mes12" runat="server" CssClass="texto" Width="50px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" Text='<%# bind("nr_valor_12") %>'></cc6:OnlyDecimalTextBox> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total">
                                                        <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                        <itemtemplate>
<anthem:Label id="lbl_total_propriedade" runat="server" Text='<%# Bind("nr_total_propriedade", "{0:N2}") %>'></anthem:Label> 
</itemtemplate>
                                                        <itemstyle horizontalalign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:N2}" HeaderText="Total Compra"
                                                        ReadOnly="True">
                                                        <itemstyle horizontalalign="Right" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/menos_red.gif" ToolTip="Excluir Propriedade do Contrato (Atenção: todas as alterações não salvas de quantidade serão perdidas.)" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w84" CommandName="delete" OnClientClick="if (confirm('ATENÇÃO: ao prosseguir com esta ação, todas as alterações em quantidade não salvas serão perdidas. Deseja realmente retirar a propriedade do contrato? ' )) return true;else return false;" CommandArgument='<%# Bind("id_propriedade") %>'></anthem:ImageButton> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_central_contrato" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_central_contrato" runat="server" Text='<%# bind("id_central_contrato") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                                        <itemtemplate>
<asp:Label id="lbl_id_propriedade_adicionada" runat="server" Text='<%# bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </anthem:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <anthem:Button ID="btn_salvar_qtde_mensal" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px"
                                    Text="Salvar Quantidades" ToolTip="Salvar alterações de quantidades mensais das propriedades."
                                    ValidationGroup="vg_salvar_qtde" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 3px" class="texto">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 15px; font-size: x-small;" class="titmodulo" align="left" colspan="2">
                                Propriedades Adicionadas X Informações Para Pedidos</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 6px">
                            </td>
                        </tr>
                        <tr>
                            <td class="texto" align="center" colspan="2">
                                <anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Black" GridLines="Vertical"
                                    ShowHeader="False" UpdateAfterCallBack="True" Width="99%" UseAccessibleHeader="False">
                                    <FooterStyle BackColor="#CCCC99" Font-Names="Verdana" Font-Size="XX-Small" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                        ForeColor="White" HorizontalAlign="Left" />
                                    <PagerStyle BackColor="#E0E0E0" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Black"
                                        HorizontalAlign="Center" VerticalAlign="Top" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <itemtemplate>
<TABLE style="BACKGROUND-IMAGE: url(img/faixa_filro.gif)" cellSpacing=0 cellPadding=0 width="100%"><TBODY><TR style="BACKGROUND-IMAGE: url(img/avisos_topo_barra3.gif); TEXT-TRANSFORM: uppercase; HEIGHT: 19px" class="faixafiltro1"><TD style="FONT-SIZE: x-small; WIDTH: 20%; HEIGHT: 20px; TEXT-ALIGN: left" class="faixafiltro1a"><anthem:Label id="lbl_dspropriedade" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="True" UpdateAfterCallBack="True" Text='<%# bind("ds_propriedade") %>'></anthem:Label></TD><TD style="FONT-SIZE: x-small; WIDTH: 9%; HEIGHT: 20px; TEXT-ALIGN: center" class="faixafiltro1a"><anthem:Label id="lbl_dsmatriz" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True" Text='<%# bind("ds_matriz") %>'></anthem:Label></TD><TD style="FONT-SIZE: x-small; WIDTH: 15%; HEIGHT: 20px; TEXT-ALIGN: left" class="faixafiltro1a"><anthem:Label id="lbl_cidade" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True" Text='<%# bind("ds_cidade") %>'></anthem:Label></TD><TD style="FONT-SIZE: x-small; WIDTH: 15%; HEIGHT: 20px; TEXT-ALIGN: center" class="faixafiltro1a"><anthem:Label id="lbl_limite" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="True" UpdateAfterCallBack="True"></anthem:Label></TD><TD style="FONT-SIZE: x-small; WIDTH: 32%; HEIGHT: 20px" class="faixafiltro1a" align=center><anthem:Label id="lbl_total_item" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True"></anthem:Label> &nbsp; &nbsp;<anthem:Label id="lbl_total_frete" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True"></anthem:Label> &nbsp;&nbsp; <anthem:Label id="lbl_valor_total" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True"></anthem:Label></TD></TR></TBODY></TABLE><TABLE style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; FONT-SIZE: x-small; BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid; BORDER-COLLAPSE: collapse" width="100%" border=1><TBODY><TR><TD style="WIDTH: 6%; HEIGHT: 19px" align=right><SPAN style="COLOR: red">*</SPAN>Embalagem:</TD><TD style="WIDTH: 8%; HEIGHT: 19px" align=left>&nbsp;<anthem:DropDownList id="cbo_tipo_medida" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" AutoCallBack="True" OnSelectedIndexChanged="cbo_tipo_medida_SelectedIndexChanged"><asp:ListItem Value="G">Granel</asp:ListItem>
<asp:ListItem Value="S">Sacaria</asp:ListItem>
<asp:ListItem Value="O">Outros</asp:ListItem>
<asp:ListItem Selected="True">[Selecione]</asp:ListItem>
</anthem:DropDownList><asp:RequiredFieldValidator id="rqf_tipo_medida" runat="server" ValidationGroup="vg_salvar_inf" CssClass="texto" ControlToValidate="cbo_tipo_medida" ErrorMessage="O tipo de medida deve ser informado." Font-Bold="False">[!]</asp:RequiredFieldValidator></TD><TD style="WIDTH: 5%; HEIGHT: 19px" align=right><SPAN style="COLOR: #ff0000">*</SPAN>Parcelar?</TD><TD style="WIDTH: 6%; HEIGHT: 19px" align=left><anthem:DropDownList id="cbo_vai_parcelar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" AutoCallBack="True" OnSelectedIndexChanged="cbo_vai_parcelar_SelectedIndexChanged"><asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
<asp:ListItem Value="D">Danone</asp:ListItem>
<asp:ListItem Value="P">Parceiro</asp:ListItem>
</anthem:DropDownList></TD><TD style="WIDTH: 9%; HEIGHT: 19px" align=center>Parcelas:<cc3:OnlyNumbersTextBox id="txt_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" Width="20px" MaxLength="2" Text='<%# bind("nr_parcelas") %>' AutoCallBack="True" OnTextChanged="txt_nr_parcelas_TextChanged"></cc3:OnlyNumbersTextBox><anthem:RequiredFieldValidator id="rfv_nr_parcelas" runat="server" ValidationGroup="vg_salvar_inf" Enabled="False" ToolTip="O nÃºmero de parcelas deve ser informado!" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_parcelas" ErrorMessage="O nÃºmero de parcelas deve ser informado!" Display="Dynamic">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator id="cv_nr_parcelas" runat="server" ValidationGroup="vg_salvar_inf" ToolTip="O nÃºmero de parcelas deve ser maio que zero (0)!" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_parcelas" ErrorMessage="O nÃºmero de parcelas deve ser maio que zero (0)!" ValueToCompare="0" Type="Integer" Operator="GreaterThan">[!]</anthem:CompareValidator><anthem:RangeValidator id="rv_parcelas" runat="server" ValidationGroup="vg_salvar_inf" Visible="False" Enabled="False" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_parcelas" Type="Integer" MinimumValue="1" MaximumValue="3">[!]</anthem:RangeValidator></TD><TD style="HEIGHT: 19px" align=center><anthem:CheckBox id="chk_st_pedido_indireto" runat="server" AutoUpdateAfterCallBack="True" Text="Ped.Indireto"></anthem:CheckBox></TD><TD style="WIDTH: 3%; HEIGHT: 19px" align=right>Frete:</TD><TD style="WIDTH: 6%; HEIGHT: 19px" align=left>&nbsp;<anthem:DropDownList id="cbo_tipo_frete" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" AutoCallBack="True" OnSelectedIndexChanged="cbo_tipo_frete_SelectedIndexChanged"><asp:ListItem Value="C">CIF</asp:ListItem>
<asp:ListItem Value="D">FOB-D</asp:ListItem>
<asp:ListItem Value="I">FOB-I</asp:ListItem>
<asp:ListItem Selected="True">[Selec.]</asp:ListItem>
</anthem:DropDownList></TD><TD style="HEIGHT: 19px" align=center>Transp.: <anthem:DropDownList id="cbo_transportador" runat="server" Enabled="False" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" AutoCallBack="True" OnSelectedIndexChanged="cbo_transportador_SelectedIndexChanged"></anthem:DropDownList><anthem:RequiredFieldValidator id="rf_transportador" runat="server" ValidationGroup="vg_salvar_inf" Enabled="False" ToolTip="O transportador deve ser informado!" AutoUpdateAfterCallBack="True" ControlToValidate="cbo_transportador" ErrorMessage="Preencha o campo Tranportador Central para continuar." InitialValue="0" Display="Dynamic">[!]</anthem:RequiredFieldValidator></TD><TD style="WIDTH: 2%; HEIGHT: 19px" align=center><anthem:ImageButton id="btn_lupa_frete_valor" onclick="btn_lupa_frete_valor_Click" runat="server" ImageUrl="~/img/lupa_desabilitada.gif" Enabled="False" ToolTip="Buscar Valores Frete Transportador" AutoUpdateAfterCallBack="true" BorderStyle="None" Width="15px" Height="15px" ImageAlign="AbsBottom" CommandName="Lupa"></anthem:ImageButton></TD><TD style="HEIGHT: 19px" align=right>Vl Frete: <cc6:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_nr_frete" runat="server" Enabled="False" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" Width="50px" MaxLength="13" MaxMantissa="2" MaxCaracteristica="10" DecimalSymbol="," Text='<%# bind("nr_valor_frete") %>' AutoCallBack="True" OnTextChanged="txt_nr_frete_TextChanged"></cc6:OnlyDecimalTextBox> <anthem:Label id="lbl_inf_frete" runat="server" Font-Size="9px" AutoUpdateAfterCallBack="True" Font-Bold="False" UpdateAfterCallBack="True" ForeColor="Red" Font-Italic="True"></anthem:Label> <anthem:RequiredFieldValidator id="rf_frete" runat="server" ValidationGroup="vg_salvar_inf" Enabled="False" ToolTip="O valor de frete deve ser informado!" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_frete" ErrorMessage="O valor de frete deve ser informado." Display="Dynamic">[!]</anthem:RequiredFieldValidator> </TD></TR></TBODY></TABLE>
</itemtemplate>
                                            <itemstyle width="100%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_central_tabela_frete_veiculos" Visible="False">
                                            <itemtemplate>
&nbsp;<asp:Label id="lbl_id_central_tabela_frete_veiculos" runat="server" Text='<%# bind("id_central_tabela_frete_veiculos") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ds_tipo_medida" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_ds_tipo_medida" runat="server" Text='<%# Bind("st_tipo_medida") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" Text='<%# Bind("id_transportador") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_cidade_destino" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_cidade_destino" runat="server" Text='<%# Bind("id_cidade_destino") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_estado_destino" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_estado_destino" runat="server" Text='<%# Bind("id_estado_destino") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade_grid" runat="server" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz_grid" runat="server" Text='<%# Bind("id_propriedade_matriz") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_produtor_grid" runat="server" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="st_parcelamento" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_st_parcelamento" runat="server" Text='<%# Bind("st_tipo_parcelamento") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="dt_fim_contrato" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_ds_tipo_frete" runat="server" Text='<%# bind("ds_tipo_frete") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="st_pedido_indireto" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_st_pedido_indireto" runat="server" Text='<%# bind("st_pedido_indireto") %>'></asp:Label>
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                </anthem:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 27px">
                                <anthem:GridView ID="gridpedidos" runat="server" AutoGenerateColumns="False"
                                    AutoUpdateAfterCallBack="True" CellPadding="3" CssClass="texto" Font-Names="Verdana"
                                    Font-Size="X-Small" ForeColor="#333333" PageSize="100" UpdateAfterCallBack="True"
                                    Width="98%" Visible="False">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                        ForeColor="White" />
                                    <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Center" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Produtor">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dt_pedido" HeaderText="Data" ReadOnly="True" DataFormatString="{0:d}">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Pedido">
                                            <itemtemplate>
<anthem:HyperLink id="hl_id_pedido" runat="server" ToolTip="Visualizar Pedido" AutoUpdateAfterCallBack="True" CssClass="textohlink" UpdateAfterCallBack="True" Text='<%# bind("id_central_pedido") %>' Target="_blank" Font-Underline="True"></anthem:HyperLink>
</itemtemplate>
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="st_pedido_indireto" HeaderText="Indireto" ReadOnly="True" />
                                        <asp:BoundField DataField="nr_quantidade" HeaderText="Qtde">
                                            <itemstyle horizontalalign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ds_parcelas" HeaderText="Parcelado?">
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nr_total_pedido" DataFormatString="{0:n2}" HeaderText="Total Pedido">
                                            <itemstyle horizontalalign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Situa&#231;&#227;o">
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ds_nmtipofrete" HeaderText="Tipo Frete">
                                            <headerstyle horizontalalign="Center" />
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador">
                                            <itemstyle horizontalalign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Ped.Frete">
                                            <itemtemplate>
<anthem:HyperLink id="hl_id_pedido_frete" runat="server" ToolTip="Visualizar Pedido de Frete" AutoUpdateAfterCallBack="True" CssClass="textohlink" UpdateAfterCallBack="True" Text='<%# bind("id_central_pedido_frete") %>' Target="_blank" Font-Underline="True"></anthem:HyperLink>
</itemtemplate>
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nr_total_pedido_frete" DataFormatString="{0:n2}" HeaderText="Total Ped.Frete">
                                            <itemstyle horizontalalign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_situacao_pedido_frete" HeaderText="Sit.Frete">
                                            <itemstyle horizontalalign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </anthem:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 27px" align="center">
                                <anthem:Button ID="btn_salvar_infpedidos" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" Font-Bold="True" Font-Size="X-Small" ForeColor="#003366" Height="24px"
                                    Text="Salvar Inf. para Pedidos" ToolTip="Salvar  as informaÃ§Ãµes  para geraÃ§Ã£o dos pedidos das propriedades."
                                    ValidationGroup="vg_salvar_inf" /></td>
                        </tr>
                        <tr>
                            <td class="texto" align="center" colspan="2">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <anthem:CustomValidator ID="cv_salvar_inf_pedidos" runat="server" AutoUpdateAfterCallBack="True"
                                    ForeColor="White" ValidationGroup="vg_salvar_inf">[!]</anthem:CustomValidator>
                                <anthem:CustomValidator ID="cv_pedido_itens" runat="server" AutoUpdateAfterCallBack="True"
                                    ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator></td>
                        </tr>
                        <tr>
                            <td style="height: 15px" align="center" colspan="2" class="texto">
                                <anthem:Panel ID="pnl_frete" runat="server" BackColor="White" HorizontalAlign="Center"
                                    Width="100%" AutoUpdateAfterCallBack="True" Visible="False" GroupingText="Tabela de Frete">
                                    <table width="98%">
                                        <tr>
                                            <td align="left" class="titmodulo">
                                                &nbsp;<anthem:Label ID="lbl_detalhe_item_frete" runat="server" AutoUpdateAfterCallBack="True"
                                                    Style="vertical-align: bottom; text-align: left" UpdateAfterCallBack="True">Frete para o ITEM XXX - XXXXXXX</anthem:Label></td>
                                            <td align="center">
                                                <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                                    ImageUrl="~/img/icone_excluir_desabilitado.gif" ToolTip="Fechar" UpdateAfterCallBack="True" />
                                            </td>
                                        </tr>
                                    </table>
                                    <anthem:GridView ID="gridfrete" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None"
                                        PageSize="100" UpdateAfterCallBack="True" Width="97%" AutoUpdateAfterCallBack="True"
                                        DataKeyNames="id_central_tabela_frete_veiculos">
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
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="font-size: x-small">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 7px; height: 47px;">
                </td>
                <td style="height: 47px">
                    <table id="Table11" height="23" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="faixafiltro1a" valign="middle" align="left" background="img/faixa_filro.gif">
                            </td>
                            <td class="faixafiltro1a" valign="middle" align="right" background="img/faixa_filro.gif"
                                colspan="4">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td style="height: 47px">
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
    </tr>   
                </table>

        <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vg_salvar_qtde"></asp:ValidationSummary>
        <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
            UpdateAfterCallBack="True"></cc7:AlertMessages><asp:ValidationSummary ID="vs_incluircontrato"
                runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_incluircontrato" />
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vg_adicionarprop" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vg_salvar_inf" />
        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vg_salvar" />
        <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vg_pedido" />
        <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="true" />
     </form>
	</body>
</HTML>
