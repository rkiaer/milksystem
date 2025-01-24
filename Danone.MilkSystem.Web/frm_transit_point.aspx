<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transit_point.aspx.vb" Inherits="frm_transit_point" %>

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
    <title>Transit Point</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"></>
		<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var idtransportador;
        var retorno="";
   	    var szUrl;

   	    idtransportador = document.getElementById("hf_id_transportador").value;

        szUrl = 'lupa_veiculo.aspx?id='+idtransportador+'';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
    }            
</script>

<script type="text/javascript"> 
    function ShowDialogTransportador() 
    
    {
        
       var idcboestabel;
       var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");

   	    idcboestabel = document.getElementById("cbo_estabelecimento").value;
   	    
        if (idcboestabel == "")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {

            szUrl = 'lupa_transportador.aspx?id_estabelecimento='+idcboestabel+'';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:600px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_transportador.value=retorno;
            } 
        }
    }            
</script>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Transit Point</STRONG></TD>
					<TD style="width: 12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto" colspan="">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 280px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
                                    |
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/ico_fechar_romaneio3.gif" /><asp:LinkButton
                                        ID="lk_fechar_transit_point" runat="server" OnClientClick="if (confirm('Após fechar o Transit Point, nenhuma informação poderá ser alterada e o Tranit Point ficará disponível para o processo de abertura de Romaneio. Deseja realmente finalizar o Transit Point?' )) return true;else return false;"
                                        ValidationGroup="vg_salvar">Fechar Transit Point</asp:LinkButton>&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    <anthem:LinkButton ID="lk_pre_romaneio_amostra" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Size="X-Small" ToolTip="Envio das Amostras de Coleta dos Pré-Romaneios">Envio das Amostras Pré-Romaneio</anthem:LinkButton>
                                    &nbsp; |
                                    &nbsp;&nbsp;
                                    <anthem:LinkButton ID="lk_transitpont_preromaneio" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Size="X-Small">Transit Point X Pré-Romaneios</anthem:LinkButton>&nbsp;&nbsp;</TD>
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
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados do Transit Point</TD>
							</TR>
	                        <tr>
	                            <TD class="texto" align="right" width="23%" style="height: 22px">
									<STRONG>Estabelecimento:</STRONG>
								</TD>
								<TD class="texto">
									&nbsp;<anthem:Label ID="lbl_ds_estabelecimento" runat="server"></anthem:Label></TD>
	                        </tr>
                            <tr>
                                <TD class="texto" align="right" width="23%" style="height: 22px">
                                    <STRONG>Unidade Transit Point:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<anthem:Label ID="lbl_ds_unidade_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" width="23%" style="height: 22px">
                                    <STRONG>Número Transit Point:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<anthem:Label ID="lbl_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align="right" width="23%" style="height: 22px">
                                    <STRONG>Situação Transit Point:</strong>
                                </td>
                                <TD class="texto">
                                    &nbsp;<anthem:Label ID="lbl_nm_situacao_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
	                                <SPAN id="Span3" class="obrigatorio">*</span><STRONG> Transportador:</strong></td>
	                            <TD class="texto">
	                                &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
	                                    CssClass="texto" MaxLength="6" Width="70px"></anthem:TextBox>
	                                &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
	                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
	                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_transportador"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
	                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><anthem:CustomValidator ID="cv_transportador" runat="server" CssClass="texto" ErrorMessage="Transportador não cadastrado!"
	                                    Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ControlToValidate="txt_cd_transportador" Display="Dynamic" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar"></anthem:CustomValidator>&nbsp;</td>
	                        </tr>
	                        <tr>
	                            <td class="texto" align="right" width="23%" style="height: 22px">
	                                <SPAN id="Span1" class="obrigatorio">*</span><STRONG>Motorista:</strong>
	                            </td>
	                            <TD class="texto" style="height: 22px">
	                                &nbsp;<anthem:DropDownList id="cbo_motorista" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="true" AutoPostBack="false" Enabled="False">
	                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="cbo_motorista"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Motorista para continuar."
	                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
	                                &nbsp;
	                                <anthem:Label ID="lbl_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
	                                    Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNH:</anthem:Label>
	                                &nbsp;
	                                <anthem:Label ID="lbl_cd_cnh" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
								</td>
	                        </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 22px" width="23%">
                                    <strong><span style="color: #ff0000">* </span>Rota:</strong></td>
                                <td class="texto" style="width: 749px">
                                    &nbsp;<anthem:DropDownList ID="cbo_rotas" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_rotas"
                                        CssClass="texto" ErrorMessage="Preencha o campo Rotas para continuar." Font-Bold="True"
                                        ToolTip="Rota deve ser preenchida." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 22px" width="23%">
                                    <strong><span style="color: #ff0000">* <strong></strong></span>Tipo de Leite:</strong></td>
                                <td class="texto" style="width: 749px">
                                    &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cbo_id_item"
                                        CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                        Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 22px" width="23%">
                                    <strong><span style="color: #ff0000">&nbsp;</span>Total Volume Leite:</strong></td>
                                <td class="texto" style="width: 749px">
                                    &nbsp;<anthem:Label ID="lbl_nr_total_litros_transit_point" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>&nbsp;</td>
                            </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados do Veículo</td>
	                        </tr>
                            <tr>
                                <TD class="texto" align="right" style="height: 20px" id="tr_incluir_veiculo" valign="bottom" >
                                    <STRONG></strong>&nbsp;&nbsp; Placa:
                                    <anthem:TextBox ID="txt_placa" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="7" OnTextChanged="txt_placa_TextChanged" UpdateAfterCallBack="True"
                                        Width="64px"></anthem:TextBox>&nbsp;
                                    <anthem:ImageButton ID="bt_lupa_veiculo" runat="server" AutoUpdateAfterCallBack="True"
                                        BorderStyle="None" CommandName="Lupa" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Veículos" Width="15px" /><anthem:RequiredFieldValidator ID="RequiredFieldValidator7"
                                            runat="server" ControlToValidate="txt_placa" CssClass="texto" ErrorMessage="Preencha o campo Placa para continuar."
                                            Font-Bold="True" ToolTip="Placa deve ser preenchida." ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                ID="cmv_placa" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_placa"
                                                CssClass="texto" ErrorMessage="Placa não cadastrada." Font-Bold="True" OnServerValidate="cmv_placa_ServerValidate"
                                                ToolTip="Placa Não Cadastrada." ValidationGroup="vg_adicionar">[!]</anthem:CustomValidator></td>
                                <td align="left" class="texto" style="height: 20px">
                                    &nbsp; Compartimento: &nbsp;<anthem:DropDownList ID="cbo_compartimento"
                                        runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        OnSelectedIndexChanged="cbo_compartimento_SelectedIndexChanged" UpdateAfterCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_compartimento" CssClass="texto" ErrorMessage="Preecha o compartimento para continuar."
                                        Font-Bold="True" ToolTip="Compartimento deve ser preenchido." ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator>
                                    <anthem:CustomValidator ID="cv_tpcompartimento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Bold="True" ForeColor="White" ValidationGroup="vg_adicionar">[!]</anthem:CustomValidator>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <anthem:Button ID="btn_novo_compartimento" runat="server" Text="Adicionar" ToolTip="Adicionar nova placa." AutoUpdateAfterCallBack="True" ValidationGroup="vg_adicionar" /></td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
                                    <br />
                                    <br />
                                    <anthem:GridView ID="gridTransitPointCompartimento" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CellPadding="4" CssClass="texto" DataKeyNames="id_transit_point_compartimento" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True" Width="80%">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Det.">
                                                <itemtemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" ImageUrl="~/img/icon_preview.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Visualizar Grupo de Relacionamento" CommandName="compcoletas" __designer:wfdid="w10"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Placa Principal">
                                                <edititemtemplate>
<anthem:CheckBox id="chk_st_principal" runat="server" AutoUpdateAfterCallBack="True" __designer:wfdid="w4"></anthem:CheckBox> 
</edititemtemplate>
                                                <itemtemplate>
<anthem:Image id="img_check" runat="server" ImageUrl="~/img/ico_chk_false.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w3"></anthem:Image> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ds_compartimento" HeaderText="Compartimento" ReadOnly="True" />
                                            <asp:BoundField DataField="nr_volume_maximo" HeaderText="Volume M&#225;ximo" ReadOnly="True" />
                                            <asp:BoundField DataField="nr_total_litros" HeaderText="Volume Total Comp." ReadOnly="True" />
                                            <asp:TemplateField ShowHeader="False">
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvarplaca" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvarplaca" ToolTip="Gravar Lacre" Text="Update" CommandName="Update" __designer:wfdid="w13" CommandArgument='<%# bind("id_transit_point_compartimento") %>'></asp:ImageButton> &nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" CommandName="Cancel" __designer:wfdid="w14"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvarcomp" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w15"></asp:ValidationSummary> 
</edititemtemplate>
                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Compartimento Transit Point" Text="Edit" CommandName="Edit" __designer:wfdid="w11"></asp:ImageButton> &nbsp;<asp:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" OnClientClick="if (confirm('Deseja realmente excluir este compartimento/Placa?' )) return true;else return false;" ToolTip="Excluir Placa/Compartimento" Text="Edit" CommandName="Delete" __designer:wfdid="w12"></asp:ImageButton> 
</itemtemplate>
                                                <headerstyle width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id_veiculo" HeaderText="id_veiculo" ReadOnly="True" Visible="False" />
                                            <asp:TemplateField HeaderText="id_transit_point_veiculo" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_id_transit_point_veiculo" runat="server" Text='<%# Bind("id_transit_point_veiculo") %>' __designer:wfdid="w172"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_transit_point_veiculo" runat="server" Text='<%# Bind("id_transit_point_veiculo") %>' __designer:wfdid="w171"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_transit_point_compartimento" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_id_transit_point_compartimento" runat="server" Text='<%# Bind("id_transit_point_compartimento") %>' __designer:wfdid="w170"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_transit_point_compartimento" runat="server" Text='<%# Bind("id_transit_point_compartimento") %>' __designer:wfdid="w169"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="st_principal" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_st_principal" runat="server" Text='<%# Bind("st_principal") %>' __designer:wfdid="w30"></asp:Label> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_st_principal" runat="server" Text='<%# Bind("st_principal") %>' __designer:wfdid="w38"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_transit_point" Visible="False">
                                                <edititemtemplate>
&nbsp;<asp:Label id="lbl_id_transit_point" runat="server" Text='<%# Bind("id_transit_point") %>' __designer:wfdid="w33"></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_id_transit_point" runat="server" Text='<%# Bind("id_transit_point") %>' __designer:wfdid="w31"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ds_placa" Visible="False">
                                                <edititemtemplate>
<asp:Label id="lbl_ds_placa" runat="server" Text='<%# Bind("ds_placa") %>' __designer:wfdid="w36"></asp:Label>
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_ds_placa" runat="server" Text='<%# Bind("ds_placa") %>' __designer:wfdid="w34"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle HorizontalAlign="Center" />
                                    </anthem:GridView>
                                    &nbsp;
                                    <anthem:CustomValidator ID="cv_transitpointsalvar" runat="server"
                                        Font-Bold="True" ForeColor="White" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:CustomValidator>
                                    &nbsp;
                                    <anthem:CustomValidator ID="cv_grid" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ErrorMessage="Uma placa deve ser informada como Principal para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar" Visible="False">[!]</anthem:CustomValidator><br />
                                    &nbsp;</td>
	                        </tr>
                            <tr>
                                <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">
                                    Dados das Coletas Selecionadas de Pré-Romaneios para a Placa
                                    <anthem:Label ID="lbl_detalhe_placa" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom; text-align: left" UpdateAfterCallBack="True"></anthem:Label>,
                                    Compartimento
                                    <anthem:Label ID="lbl_detalhe_compartimento" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom; text-align: left" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <br />
	                                <br />
                                    <anthem:GridView ID="grdColetas" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CellPadding="4" CssClass="texto" DataKeyNames="id_transit_point_up" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="100" UpdateAfterCallBack="True"
                                        Width="80%">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <Columns>
                                            <asp:BoundField DataField="ds_placa" HeaderText="Placa" ReadOnly="True" />
                                            <asp:BoundField DataField="nm_compartimento" HeaderText="Compartimento" ReadOnly="True" />
                                            <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" ReadOnly="True" />
                                            <asp:BoundField DataField="ds_propriedadeup" HeaderText="Prop./UP" ReadOnly="True" />
                                            <asp:BoundField DataField="nr_litros" HeaderText="Volume" />
                                            <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233;-Romaneio" />
                                            <asp:TemplateField ShowHeader="False" Visible="False">
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_lacre" ToolTip="Gravar Lacre" Text="Update" CommandName="Update" __designer:wfdid="w59" CommandArgument='<%# bind("id_transit_point_compartimento") %>'></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" CommandName="Cancel" __designer:wfdid="w106"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvarplaca" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w107"></asp:ValidationSummary> 
</edititemtemplate>
                                                <itemtemplate>
<asp:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Placa/Compartimento" Text="Edit" CommandName="Delete" CommandArgument='<%# bind("id_transit_point_up") %>' OnClientClick="if (confirm('Deseja realmente excluir este compartimento/Placa?' )) return true;else return false;" __designer:wfdid="w127"></asp:ImageButton> 
</itemtemplate>
                                                <headerstyle width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id_transit_point_up" HeaderText="id_transit_point_up"
                                                ReadOnly="True" Visible="False" />
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp; &nbsp; &nbsp;<br />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">
                                    Dados das Amostras de Pré-Romaneios Enviadas no Transit Point</td>
                            </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <br />
	                                <br />
                                    <anthem:GridView ID="gridAmostras" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CellPadding="4" CssClass="texto" DataKeyNames="id_pre_romaneio_amostras" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="100" UpdateAfterCallBack="True"
                                        Width="90%">
                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        <Columns>
                                            <asp:BoundField DataField="id_pre_romaneio" HeaderText="Pr&#233;-Romaneio" ReadOnly="True" />
                                            <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" ReadOnly="True" />
                                            <asp:BoundField DataField="st_leite_total_rejeitado" HeaderText="Vol.Total Rejeitado" />
                                            <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" ReadOnly="True" />
                                            <asp:BoundField DataField="ds_propriedade" HeaderText="Prop./UP" ReadOnly="True" />
                                            <asp:BoundField DataField="frasco1" HeaderText="Frasco Amarelo" />
                                            <asp:BoundField DataField="frasco2" HeaderText="Frasco Azul" />
                                            <asp:BoundField DataField="frasco3" HeaderText="Frasco Branco" />
                                            <asp:BoundField DataField="frasco4" HeaderText="Frasco Vermelho" />
                                            <asp:BoundField DataField="nm_situacao_tp_amostra" HeaderText="Envio Amostra" />
                                            <asp:BoundField DataField="nm_motivo_descarte_romaneio_amostra" HeaderText="Motivo Descarte" />
                                            <asp:TemplateField HeaderText="id_situacao_coleta_amostra" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_id_situacao_coleta_amostra" runat="server" Text='<%# Bind("id_situacao_coleta_amostra") %>' __designer:wfdid="w45"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_situacao_tp_amostra" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_id_situacao_tp_amostra" runat="server" Text='<%# Bind("id_situacao_tp_amostra") %>' __designer:wfdid="w48"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="id_transit_point_registro" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_id_transit_point_registro" runat="server" Text='<%# Bind("id_transit_point_registro") %>' __designer:wfdid="w50"></asp:Label>
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp; &nbsp; &nbsp;<br />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG></STRONG></TD>
							                    <TD style="height: 20px" align="left">&nbsp;</TD>
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
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_adicionar" />
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_veiculo" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
