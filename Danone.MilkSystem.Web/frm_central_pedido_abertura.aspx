<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_pedido_abertura.aspx.vb" Inherits="frm_central_pedido_abertura" %>

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
   <title>Abertura Pedido</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" >
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
	<script type="text/javascript" > 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_produtor = document.getElementById("hf_id_produtor");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_produtor.value=retorno;
            } 

         }
    }    
</script>

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Central de Compras - Abrir Pedido</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 40px" ></TD>
					<TD vAlign="top" align="center" class="texto" style="height: 40px">
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%"  >
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"  background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"  >
                                    <anthem:Image ID="img_notificacao" runat="server" ImageUrl="~/img/ico_email.gif" Visible="False" AutoUpdateAfterCallBack="True" />
                                    &nbsp;<anthem:LinkButton ID="lk_notificar_aprovadores" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" Style="vertical-align: bottom" Visible="False" OnClick="lk_notificar_aprovadores_Click">Notificar Aprovadores </anthem:LinkButton>
                                    |
                                    <anthem:LinkButton ID="lk_enviar_aprovacao" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" ValidationGroup="vg_verificacoes_finais" Visible="False">Enviar Aprovação</anthem:LinkButton>&nbsp;
                                    <anthem:LinkButton ID="lk_gerar_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Gerar Pedido" ValidationGroup="vg_salvar" OnClick="lk_gerar_pedido_Click">Gerar Pedido</anthem:LinkButton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 40px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" style="font-size: x-small">
							<TR>
								<TD style="HEIGHT: 15px; font-size: x-small;" class="titmodulo" align="left" colSpan="2">
                                    Selecione o &nbsp;Produtor</TD>
							</TR>
                            <tr>
                                <TD class="texto" align="left" style="height: 22px" colspan="2">
                                    <SPAN id="Span4" class="obrigatorio"></span>&nbsp; &nbsp;
                                    <table border="0" width="100%" style="font-size: x-small">
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                <span style="color: #ff0000">*</span>Estabelecimento:</td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" Font-Size="X-Small" AutoUpdateAfterCallBack="True" AutoCallBack="True"></anthem:DropDownList> 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Estabelecimento para continuar." ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                </td>
                                            <td align="left" style="height: 19px">
                                                </td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                </td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 14%; height: 18px">
                                                <span style="color: #ff0000">*</span> Produtor:</td>
                                            <td align="left" colspan="3" style="height: 18px">
                                                &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                    CssClass="texto" MaxLength="10" Width="72px" Font-Size="X-Small"></anthem:TextBox>
                                                &nbsp;<anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                                    Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label>
                                                <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_pessoa"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                        Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O campo Produtor deve ser informado.">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="height: 18px">
                                                Acordo Insumos:&nbsp;</td>
                                            <td align="left" style="height: 18px">
                                                <anthem:Label ID="lbl_acordo_aquisicao_insumos" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 14%; height: 18px;">
                                                Cluster:</td>
                                            <td align="left" colspan="1" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_cluster" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td align="right" style="width: 12%; height: 18px;">
                                                Email:</td>
                                            <td align="left" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_ds_email" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td align="right" style="width: 10%; height: 18px;">
                                                Telefone:</td>
                                            <td align="left" style="width: 15%; height: 18px;">
                                                &nbsp;<anthem:Label ID="lbl_ds_telefone" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 19px;" align="right">
                                                Contrato Produtor:</td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="width: 12%; height: 19px;" align="right">
                                                Ini. e Fim Contrato:</td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_dt_ini_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label>
                                                &nbsp;à&nbsp;
                                                <anthem:Label ID="lbl_dt_fim_contrato" runat="server" CssClass="texto" UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                            <td style="width: 10%; height: 19px;" align="right">
                                                Rescisão Contrato:</td>
                                            <td style="width: 15%; height: 19px;" align="left">
                                                &nbsp;<anthem:Label ID="lbl_dt_rescisao_contrato" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True" Font-Size="X-Small"></anthem:Label></td>
                                        </tr>
                                     </table>
                                </td>
                            </tr>
	                    </TABLE>
					</TD>
					<TD></TD>
				</TR>
				<tr >
    				<td></td>
    				<td style="font-size: x-small">
    					                    <table width="100%">
                                <tr>
                                    <td align="center" colspan="2" style="height: 18px">
                                        <anthem:GridView ID="gridPropriedades" runat="server" AutoGenerateColumns="False"
                                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" PageSize="100"
                                            UpdateAfterCallBack="True" Width="95%">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                ForeColor="White" />
                                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" HorizontalAlign="Center" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<anthem:ImageButton id="imgselecionar" runat="server" ImageUrl="~/img/ico_triangulo_cinza.gif" AutoUpdateAfterCallBack="True" Text="Select" CommandName="Select" __designer:wfdid="w8" CausesValidation="False"></anthem:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Produtor" >
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
                                                <asp:TemplateField HeaderText="Limite 150%">
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_limite_mes_bruto" runat="server" __designer:wfdid="w13"></anthem:Label> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descontos">
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_desconto" runat="server" __designer:wfdid="w14"></anthem:Label> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pedidos Abertos">
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w17"></anthem:Label><anthem:HyperLink id="hl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Pedidos Abertos" CssClass="textohlink" UpdateAfterCallBack="True" __designer:wfdid="w18" Target="_blank" Font-Underline="True">[hl_nr_total_pedidos_abertos]</anthem:HyperLink> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Limite Dispon&#237;vel">
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w15"></anthem:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vol M&#234;s Estimado">
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_mensal_estimado" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Text='<%# bind("volumemes") %>' __designer:wfdid="w6"></anthem:Label> 
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
                                                <asp:TemplateField HeaderText="volumenomes" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_volumenomes" runat="server" Text='<%# Bind("volumenomes") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
                                    <anthem:label id="lbl_informativo_1" runat="server" autoupdateaftercallback="True"
                                        cssclass="texto" font-italic="True" font-size="10px" forecolor="Red" updateaftercallback="True"
                                        visible="False">*Informativo: O cálculo do limite para propriedade foi baseado na projeção do Custo Financeiro.</anthem:label>
                                        <anthem:Label ID="lbl_informativo_2" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                            Font-Italic="True" Font-Size="10px" ForeColor="Blue" UpdateAfterCallBack="True"
                                            Visible="False">**Informativo: Não existe faturamento anterior ou custo projetado para cálculo do limite. Os pedidos abertos para propriedades sem limite serão enviados para aprovação.</anthem:Label>
                                        <anthem:Label ID="lbl_informativo_4" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                            Font-Italic="True" Font-Size="10px" ForeColor="MediumSeaGreen" UpdateAfterCallBack="True"
                                            Visible="False">***Informativo: O Campo VOL MÊS ESTIMADO reflete as informações do último cálculo projetado de </anthem:Label></td>
                                </tr>
	                        <tr>
	                            <td style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colSpan="2">Dados do Parceiro de Insumos</td>
	                        </tr>
	                                                  <tr>
                                <TD class="texto" align=center colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="height: 24px; font-size: x-small; width: 13%;">
                                                <span style="color: #ff0000">*</span>Parceiro:</td>
                                            <td align="left" style="height: 24px; font-size: x-small;">
                                                &nbsp;<anthem:TextBox ID="txt_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="true"
                                                    CssClass="texto" MaxLength="100" onfocus="clearDataFornec()" Width="100px" AutoCallBack="True">[Filtre Nome]</anthem:TextBox>&nbsp;
                                                Selecione:&nbsp;<anthem:DropDownList ID="cbo_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" AutoCallBack="True">
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_fornecedor"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Parceiro para continuar." Font-Bold="True"
                                                    InitialValue="0" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="height: 24px; font-size: x-small; width: 11%;">
                                                Frete CIF Parceiro:</td>
                                            <td align="left" style="height: 24px; font-size: x-small; width: 10%;">
                                                &nbsp;<anthem:Label ID="lbl_frete_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" style="height: 24px; font-size: x-small; width: 15%;">
                                                Total Parcelas Parceiro:</td>
                                            <td align="left" style="height: 24px; font-size: x-small; width: 18%;">
                                                &nbsp;<anthem:Label ID="lbl_parcelas_parceiro" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                                          </tr>                        
                                    </table>
                                </td>
                            </tr>

	                        <tr>
	                            <td style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colSpan="2">Dados do Pedido</td>
	                        </tr>
	                                                  <tr>
                                <TD class="texto" align=center colspan="2" style="font-size: x-small">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style=" height: 24px; width: 13%;">
                                                Pedido Indireto:</td>
                                            <td align="left" style="width: 10%; height: 24px">
                                                &nbsp;<anthem:DropDownList id="cbo_pedido_indireto" runat="server" CssClass="texto" AutoPostBack="false" Font-Size="X-Small">
                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                            </anthem:DropDownList></td>
                                            <td align="center" style=" height: 24px; width: 18%;">
                                                &nbsp;Evento Compras: <anthem:CheckBox ID="chk_compras_evento" runat="server" AutoPostBack="True" AutoUpdateAfterCallBack="True"
                                                    ToolTip="Pedido realizado em EVENTO de Compras." /></td>
                                            <td align="left" style="height: 24px;" colspan="2" nowrap="noWrap">
                                                &nbsp;<span style="color: #ff0000">*</span>Parcelar?&nbsp;<anthem:DropDownList ID="cbo_vai_parcelar" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" AutoCallBack="True">
                                                    <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                    <asp:ListItem Value="D">Danone</asp:ListItem>
                                                    <asp:ListItem Value="P">Parceiro</asp:ListItem>
                                                </anthem:DropDownList>
                                                &nbsp; &nbsp;Parcelas:&nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" MaxLength="2" Text='1' UpdateAfterCallBack="True"
                                                    Width="30px" Enabled="False" style="text-align: center"></cc3:OnlyNumbersTextBox><anthem:RequiredFieldValidator ID="rfv_nr_parcelas"
                                                        runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_parcelas" ErrorMessage="O número de parcelas deve ser informado!"
                                                        ToolTip="O número de parcelas deve ser informado!" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                            ID="cv_nr_parcelas" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_parcelas" ErrorMessage="O número de parcelas deve ser maio que zero (0)!"
                                                            Operator="GreaterThan" ToolTip="O número de parcelas deve ser maio que zero (0)!"
                                                            Type="Integer" ValidationGroup="vg_salvar" ValueToCompare="0">[!]</anthem:CompareValidator><anthem:Label ID="lbl_informativo_3" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Italic="True" Font-Size="10px" ForeColor="Red" UpdateAfterCallBack="True" style="position: static"></anthem:Label></td>
                                          </tr>                        
                                        <tr>
                                            <td align="right" style="height: 24px">
                                                <span style="color: #ff0000">*</span>Tipo do Frete:</td>
                                            <td align="left" style="height: 24px" >
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_frete" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" AutoCallBack="True">
                                                    <asp:ListItem Value="C">CIF</asp:ListItem>
                                                    <asp:ListItem Value="D">FOB-D</asp:ListItem>
                                                    <asp:ListItem Value="I">FOB-I</asp:ListItem>
                                                    <asp:ListItem Value="" Selected="True">[Sel.]</asp:ListItem>
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_tipo_frete"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Tipo do Frete para continuar."
                                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="left" colspan="2" style="height: 24px;">
                                                &nbsp;Maior Tipo Caminhão Acesso à Propriedade:&nbsp;
                                                    <anthem:DropDownList ID="cbo_tipo_caminhao" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" >
                                                    </anthem:DropDownList></td>
                                            <td align="center" style="height: 24px; width: 20%;">
                                                &nbsp;
                                                <anthem:ImageButton ID="btn_atualizar_totais_pedidos" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" CommandName="atualizartotais" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png"
                                                    ToolTip="Atualizar Totalizadores" />&nbsp; Total dos Pedidos:&nbsp;
                                                <anthem:Label ID="lbl_valor_total" runat="server" AutoUpdateAfterCallBack="True"
                                                    Font-Bold="False"  UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                    </table>
 
				    </td>
				    <td></td>
				</tr>
				<tr runat="server" id="tr_itens" >
				<td style="height: 118px"></td>
				<td style="font-size: x-small; height: 118px;">                   <table width="100%">
	                        <tr>
	                            <td style="HEIGHT: 16px; font-size: x-small;" class="titmodulo" align="left" colSpan="2">Dados do Item do Pedido</td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="height: 23px; font-size: x-small; width: 13%;">
                                                Item:</td>
                                            <td align="left" style="height: 23px; font-size: x-small;" colspan="11">
                                                &nbsp;<anthem:TextBox ID="txt_nm_item" runat="server" AutoUpdateAfterCallBack="true"
                                                    CssClass="texto" MaxLength="100" onfocus="clearDataItem()" Width="100px" AutoCallBack="True">[Filtre Nome]</anthem:TextBox>&nbsp;
                                                Selecione:
                                                <anthem:DropDownList ID="cbo_item" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" AutoCallBack="True">
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_item"
                                                    CssClass="texto" ErrorMessage="Selecione o campo Código do Item para continuar."
                                                    Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator>
                                                &nbsp;&nbsp;
                                                <anthem:Label ID="lbl_nm_categoria_tit" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Bold="False" UpdateAfterCallBack="True" Visible="False">Categoria:</anthem:Label>
                                                <anthem:Label ID="lbl_nm_categoria" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                &nbsp;&nbsp;
                                                <anthem:Button ID="btn_novo_item" runat="server" Text="Adicionar" ToolTip="Adicionar novo item" CssClass="texto" ValidationGroup="vg_adicionar_item" Enabled="False" Visible="False" Width="32px" /><anthem:CustomValidator ID="cv_validar_item" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_adicionar_item" ForeColor="White">[!]</anthem:CustomValidator>
                                                &nbsp;
                                                <anthem:ImageButton ID="btn_lupa_preco" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png"
                                                    ToolTip="Atualizar Valores com Tabela de Preços" />&nbsp;
                                                <anthem:Label ID="lbl_inf_preco" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False"
                                                    Font-Italic="True" Font-Size="9px" ForeColor="Red" 
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="left" style="font-size: x-small; height: 23px">
                                            </td>
                                          </tr>                        
                                        <tr>
                                            <td align="right" style="font-size: x-small; width: 13%; height: 23px">
                                                <span style="color: #ff0000">*</span>Embalagem:</td>
                                            <td align="left" style="font-size: x-small; height: 23px; width: 10%;">
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_medida" runat="server"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True" Enabled="False" AutoCallBack="True">
                                                    <asp:ListItem Value="G">Granel</asp:ListItem>
                                                    <asp:ListItem Value="S">Sacaria</asp:ListItem>
                                                    <asp:ListItem Value="O">Outros</asp:ListItem>
                                                    <asp:ListItem value="" Selected="True">[Selecione]</asp:ListItem>
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="rqf_tipo_medida" runat="server"
                                                    ControlToValidate="cbo_tipo_medida" CssClass="texto" ErrorMessage="O tipo de medida deve ser informado."
                                                    Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="font-size: x-small; height: 23px; width: 7%;">
                                                <span style="color: #ff0000">*</span>Qtde:</td>
                                            <td align="left" style="font-size: x-small; height: 23px; width: 12%;">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_qtde" runat="server"
                                                    CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="15" MaxMantissa="4"
                                                     Width="70px" Enabled="False" AutoCallBack="True" AutoUpdateAfterCallBack="True" style="text-align: right"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                        ID="rqf_quantidade" runat="server" ControlToValidate="txt_nr_qtde" CssClass="texto"
                                                        ErrorMessage="A quantidade deve ser informada." Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:CompareValidator
                                                            ID="CompareValidator1" runat="server" ControlToValidate="txt_nr_qtde" CssClass="texto"
                                                            ErrorMessage="A quantidade deve ser informada." Operator="GreaterThan" Type="Double"
                                                            ValidationGroup="vg_salvar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                            <td align="right" style="font-size: x-small; height: 23px; width: 6%;">
                                                <span style="color: #ff0000">*</span>Vl Unit:</td>
                                            <td align="left" style="font-size: x-small; height: 23px; width: 13%;">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_unitario" runat="server"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto" DecimalSymbol="," MaxCaracteristica="10"
                                                    MaxLength="13" MaxMantissa="2" OnTextChanged="txt_nr_valor_unitario_TextChanged"
                                                     ToolTip="O preço é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o preço cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento."
                                                    UpdateAfterCallBack="True" Width="65px" Enabled="False" AutoCallBack="True" style="text-align: right"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator ID="rqf_valor_unitario"
                                                        runat="server" ControlToValidate="txt_nr_valor_unitario" CssClass="texto" ErrorMessage="O valor unitário deve ser informado."
                                                        Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="font-size: x-small; width: 9%; height: 23px">
                                                Vl Sacaria:</td>
                                            <td align="left" style="font-size: x-small; width: 12%; height: 23px">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_sacaria" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" DecimalSymbol="," MaxCaracteristica="10" MaxLength="13" MaxMantissa="2"
                                                     ToolTip="O valor da Sacaria é trazido da Tabela de Preços onde o município destino é o mesmo da propriedade. Caso não exista, será trazido o valor cadastrado para município destino Todos, sempre respeitando a data mais recente de cadastramento."
                                                    UpdateAfterCallBack="True" Width="60px" Enabled="False" AutoCallBack="True" style="text-align: right"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator
                                                        ID="rfv_sacaria" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_nr_sacaria" ErrorMessage="A sacaria deve ser informada." ToolTip="A sacaria deve ser informada."
                                                        ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right" style="font-size: x-small; height: 23px; width: 8%;">
                                                <anthem:ImageButton ID="btn_atualizar_totais" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png"
                                                    OnClick="btn_atualizar_totais_Click" ToolTip="Atualizar Totalizadores" />&nbsp;
                                                Total Item:</td>
                                            <td align="left" style="font-size: x-small; height: 23px; width: 10%;">
                                                &nbsp;<anthem:Label ID="lbl_total_item" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False"
                                                     UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                    </table>
                                <anthem:CustomValidator ID="cv_pedido_itens" runat="server" AutoUpdateAfterCallBack="True"
                                            ForeColor="White" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator><anthem:CustomValidator ID="cv_pedido_aprovacao" runat="server" AutoUpdateAfterCallBack="True"
                                            ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator></td>
                            </tr>
						</TABLE>
</td>
				<td style="height: 118px"></td>
				</tr>
				<tr runat="server" id="tr_transportador">
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
                                    CssClass="texto" Enabled="False" OnSelectedIndexChanged="cbo_transportador_SelectedIndexChanged"
                                    UpdateAfterCallBack="True" AutoCallBack="True">
                                </anthem:DropDownList><anthem:RequiredFieldValidator ID="rf_transportador" runat="server"
                                    AutoUpdateAfterCallBack="True" ControlToValidate="cbo_transportador"
                                    Enabled="False" ErrorMessage="Preencha o campo Tranportador Central para continuar."
                                    InitialValue="0" ToolTip="O transportador deve ser informado!" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                            <td align="left" style="height: 24px; font-size: x-small;">
                                <anthem:ImageButton ID="btn_lupa_frete_valor" runat="server" AutoUpdateAfterCallBack="true"
                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa_desabilitada.gif"
                                    OnClick="btn_lupa_frete_valor_Click" ToolTip="Buscar Valores Frete Transportador"
                                    Width="15px" Enabled="False" />&nbsp; Vl Frete:
                                <cc6:OnlyDecimalTextBox ID="txt_nr_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="texto" DecimalSymbol="," Enabled="False" MaxCaracteristica="10" MaxLength="13"
                                    MaxMantissa="2" OnTextChanged="txt_nr_frete_TextChanged" 
                                    UpdateAfterCallBack="True" Width="65px" AutoCallBack="True" style="text-align: right"></cc6:OnlyDecimalTextBox><anthem:RequiredFieldValidator ID="rf_frete" runat="server" AutoUpdateAfterCallBack="True"
                                    ControlToValidate="txt_nr_frete" Enabled="False" ErrorMessage="O valor de frete deve ser informado."
                                    ToolTip="O valor de frete deve ser informado!" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                <anthem:Label ID="lbl_inf_frete" runat="server" AutoUpdateAfterCallBack="True" Font-Bold="False"
                                    Font-Italic="True" Font-Size="9px" ForeColor="Red" 
                                    UpdateAfterCallBack="True"></anthem:Label></td>
                            <td align="right" style="height: 24px; font-size: x-small; width: 8%;"><anthem:ImageButton ID="btn_atualizar_totais_transporte" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png" ToolTip="Atualizar Totalizadores" />&nbsp;
                                Total Frete:</td>
                            <td align="left" style="height: 24px; font-size: x-small; width: 10%;">
                                &nbsp;<anthem:Label ID="lbl_total_frete" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                    Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                        </tr>
                        <tr class="texto">
                            <td align="center" style="height: 4px; " colspan="5">
                                &nbsp; &nbsp;
                                &nbsp; &nbsp;&nbsp;
                                </td>
                        </tr>
								<TR>
								<TD style="HEIGHT: 15px" align="center" colspan="5" class="texto">
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
				
				</td>
				<td></td>
				</tr>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
									</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <asp:ValidationSummary ID="vs_abrir_cotacao" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_abrir_cotacao" /><asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_adicionar_item" />
           <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
