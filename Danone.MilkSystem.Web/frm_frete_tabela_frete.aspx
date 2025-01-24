<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_tabela_frete.aspx.vb" Inherits="frm_frete_tabela_frete" %>

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
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>Frete - Tabela de Frete</title>
<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");
    	     
            szUrl = 'lupa_transportador_cooperativa.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:600px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_transportador.value=retorno;
            } 
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {       
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_cooperativa.value=retorno;
        } 
    }            
</script>	
</head>
<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

<form id="Form1" method="post" runat="server">
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
	<TR>
		<TD style="width: 7px">&nbsp;</TD>
		<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Frete - Tabelas de Frete</STRONG></TD>
		<TD style="width: 7px" >&nbsp;</TD>
	</TR>
	<TR>
		<TD style="width: 7px; " ></TD>
		<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
			<TABLE id="Table2"  cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="faixafiltro1a"  vAlign="middle" align="left" background="img/faixa_filro.gif">
                        &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                        <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp;</TD>
					<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
						colSpan="4">
                        <anthem:Image ID="img_notificacao" runat="server" AutoUpdateAfterCallBack="True"
                            ImageUrl="~/img/ico_email.gif" />
                        <anthem:LinkButton ID="lk_email" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                            OnClientClick="if (confirm('Uma notificação de que existem Indicadores de Preço para aprovação será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                            ToolTip="Notificar Aprovadores de Indicador de Preço" ValidationGroup="vg_salvar">Notificar Aprovadores</anthem:LinkButton>
                        &nbsp; &nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
         </TD>
		<TD style="width: 7px" >&nbsp;</TD>
	</TR>
	<TR>
		<TD ></TD>
		<TD class="texto">
			<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
			    <TR>
				    <TD class="titmodulo"  colSpan="2" > Descrição</TD>
			    </TR>
                <tr>
                    <td align="right" class="texto" style="width:20%; ">
                        <span class="obrigatorio">*</span> <strong>Estabelecimento:</strong></td>
                    <td >
                        &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                        </anthem:DropDownList>
                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                            CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                            Font-Bold="False" ValidationGroup="vg_frete" ToolTip="O Estabelecimento deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" class="texto" ><span id="Span3" class="obrigatorio">*</span><strong> Transportador:</strong></td>
                    <td class="texto" >
                        &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="True"
                            AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                        &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                            ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                        <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_cd_transportador"
                            CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
                            Font-Bold="False" ValidationGroup="vg_frete">[!]</asp:RequiredFieldValidator>
                        <anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                            ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                            Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_frete"></anthem:CustomValidator>&nbsp;</td>
                </tr>
                <tr id="tr_cooperativa" runat="server" visible = "true">
                    <td align="right" class="texto" >
                        <span id="Span4" class="obrigatorio"><strong><span style="color: #000000"> Cooperativa:</span></strong></span></td>
                    <td class="texto" >
                        &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                            AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                        &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                            ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                        <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                        <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                        <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_cd_cooperativa"
                            CssClass="texto" ErrorMessage="Preencha o campo Código da Cooperativa para continuar ou selecione-o pela lupa."
                            Font-Bold="False" ValidationGroup="vg_frete" Visible="False">[!]</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa"
                            CssClass="texto" ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False"
                            Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_frete"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="texto"  style="height: 11px" valign="bottom">
                        </td>
                    <td  class="texto" style="height: 11px" valign="bottom">
                        </td>
                </tr>
                    <TR >
						<TD colSpan="2" class="texto">
							<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">
                                        Tabela de Frete</TD>
								</TR>
                                <tr>
                                    <td align="center" class="texto" colspan="2">
                                       
                                        <table id="Table8" cellpadding="2" cellspacing="1" class="texto" width="98%">
                                            <tr>
                                                <td align="right" class="texto" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid; width: 25%;">
                                                    <strong><span style="color: #ff0000"><anthem:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cbo_tipofrete"
                                CssClass="texto" ErrorMessage="Preencha o campo Tipo Frete para continuar."
                                Font-Bold="False" ToolTip="O TipoFrete deve ser informado." ValidationGroup="vg_frete">[!]</anthem:RequiredFieldValidator>*</span><strong> </strong>Tipo Frete:
                                                        <anthem:DropDownList ID="cbo_tipofrete" runat="server" CssClass="texto">
                                <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                <asp:ListItem Value="1">T1</asp:ListItem>
                                <asp:ListItem Value="2">T2</asp:ListItem>
                                                            <asp:ListItem Value="3">T2 TP</asp:ListItem>
                                                            <asp:ListItem Value="4">T2 TVASE</asp:ListItem>
                            </anthem:DropDownList>&nbsp; </strong></td>
                                                <td align="right" class="texto" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid;">
                                                    <strong><span style="color: #ff0000"><anthem:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                            runat="server" ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="Preencha o campo Período Validade Inicial para continuar."
                                                            Font-Bold="False" ValidationGroup="vg_frete" ToolTip="O campo Período Validade Inicial deve ser informado.">[!]</anthem:RequiredFieldValidator>*</span><strong> </strong>Válido a partir de:</strong>
                                                    <cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="MonthYear"
                                                        Width="65px" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox>&nbsp;</td>
                                                <td align="right" class="texto" style=" height: 20px; border-top: silver 1px solid; border-left: silver 1px solid;">
                                                    <strong><span style="color: #ff0000"><anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                                            ControlToValidate="cbo_tipo_equipamento" CssClass="texto" ErrorMessage="Preencha o campo Tipo Equipamento para continuar."
                                                            Font-Bold="False" ToolTip="O campo Tipo Equipamento deve ser informado." ValidationGroup="vg_frete">[!]</anthem:RequiredFieldValidator>*</span><strong> </strong>Tipo Equipamento:
                                                        <anthem:DropDownList ID="cbo_tipo_equipamento" runat="server"
                                                            CssClass="texto" AutoUpdateAfterCallBack="True">
                                                        </anthem:DropDownList>&nbsp;</strong></td>
                                                <td align="center" class="texto" style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid;" rowspan="3">
                                                    &nbsp;<anthem:CustomValidator ID="cv_tabelafrete" runat="server" Font-Bold="True"
                                                        ForeColor="White" ValidationGroup="vg_frete">[!]</anthem:CustomValidator><anthem:Button ID="btn_incluir_frete" runat="server" CssClass="texto" Text="Incluir" ValidationGroup="vg_frete" AutoUpdateAfterCallBack="True" /></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px">
                                                    <strong><anthem:RequiredFieldValidator ID="rfv_custokm" runat="server" AutoUpdateAfterCallBack="True"
                                                        ControlToValidate="txt_custokm" CssClass="texto" ErrorMessage="Preencha o campo Custo KM para continuar."
                                                        Font-Bold="False" ValidationGroup="vg_frete" Visible="False">[!]</anthem:RequiredFieldValidator>Custo KM:</strong>
                                                    <cc6:OnlyDecimalTextBox ID="txt_custokm" runat="server" CssClass="texto" MaxCaracteristica="5"
                                                        MaxLength="8" MaxMantissa="2" Width="65px" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px">
                                                    <strong><anthem:RequiredFieldValidator
                                                            ID="rfv_custofixodiaria" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_custofixodiaria"
                                                            CssClass="texto" ErrorMessage="Preencha o campo Custo Fixo Diária para continuar."
                                                            Font-Bold="False" ValidationGroup="vg_frete" Visible="False">[!]</anthem:RequiredFieldValidator>Custo Fixo Diária (por viagem):</strong>
                                                    <cc6:OnlyDecimalTextBox ID="txt_custofixodiaria" runat="server" CssClass="texto"
                                                        MaxCaracteristica="5" MaxLength="8" MaxMantissa="2" Width="65px" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                                <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px">
                                                    <strong>Custo
                                                            Fixo Mensal: </strong>
                                                    <cc6:OnlyDecimalTextBox ID="txt_nr_custo_fixo_mes" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" MaxCaracteristica="6" MaxLength="9" MaxMantissa="2" Width="65px"></cc6:OnlyDecimalTextBox><strong>&nbsp;</strong></td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid;
                                                    border-bottom: silver 1px solid; height: 20px" colspan="2">
                                                    <strong>Calcular Custo Fixo Mensal Por: </strong>
                                                    <anthem:DropDownList ID="cbo_custo_mensal_tipo" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                                        <asp:ListItem Value="1">Nr Ve&#237;culos Acordados</asp:ListItem>
                                                        <asp:ListItem Value="2">Ve&#237;culos Utilizados</asp:ListItem>
                                                        <asp:ListItem Value="3">Tipo Equipamento</asp:ListItem>
                                                    </anthem:DropDownList>
                                                    &nbsp;&nbsp; <strong>Nr. Veículos:
                                                        <cc3:OnlyNumbersTextBox ID="txt_nr_veiculos" runat="server" AutoUpdateAfterCallBack="True"
                                                            CssClass="texto" Enabled="False" MaxLength="3" Width="30px"></cc3:OnlyNumbersTextBox>&nbsp;</strong></td>
                                                <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid;
                                                    border-bottom: silver 1px solid; height: 20px">
                                                    &nbsp;<strong>% Seguro Carga: </strong>
                                                        <cc6:OnlyDecimalTextBox ID="txt_seguro_carga" runat="server" AutoCompleteType="Disabled"
                                                            AutoUpdateAfterCallBack="True" CssClass="texto" MaxCaracteristica="3" MaxLength="8"
                                                            MaxMantissa="4" ToolTip="Seguro Carga: Pagto do ercentual especificado sobre o valor da carga"
                                                            Width="65px"></cc6:OnlyDecimalTextBox>
                                                        %&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="texto" style="height: 8px" colspan="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="texto" colspan="4">
                                                    <anthem:GridView ID="grdFrete" runat="server" AutoGenerateColumns="False"
                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True" Width="100%" DataKeyNames="id_frete_tabela">
                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                            ForeColor="White" HorizontalAlign="Left" />
                                                        <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                            HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Validade">
                                                                <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_dt_referencia_ini" runat="server" Text='<%# Bind("dt_validade") %>' __designer:wfdid="w251"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Tipo" ReadOnly="True" DataField="dstipofrete" />
                                                            <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento" ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_eixo" HeaderText="Nr Eixos" ReadOnly="True" />
                                                            <asp:BoundField DataField="nr_custo_km" HeaderText="Custo KM" />
                                                            <asp:BoundField DataField="nr_custo_fixo_diaria" HeaderText="Custo Fixo Dia" />
                                                            <asp:BoundField DataField="nr_custo_fixo_mes" HeaderText="Custo Fixo M&#234;s" />
                                                            <asp:BoundField DataField="dstipocustofixomes" HeaderText="Calc. Fixo M&#234;s Por:" />
                                                            <asp:BoundField DataField="nr_custo_fixo_mes_veiculos" HeaderText="Nr. Ve&#237;culos" />
                                                            <asp:BoundField DataField="nr_perc_seguro_carga" HeaderText="% Seguro" />
                                                            <asp:TemplateField HeaderText="Situa&#231;&#227;o Aprova&#231;&#227;o" Visible="False">
                                                                <itemtemplate>
<asp:Label id="lbl_nm_situacao_aprovacao" runat="server" Text='<%# Bind("nm_situacao_aprovacao") %>' __designer:wfdid="w252"></asp:Label>
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w353" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w354" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w355"></asp:ValidationSummary> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Visible="False" Text="Edit" __designer:wfdid="w351" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Registro da Tabela de Frete" AutoUpdateAfterCallBack="True" ImageAlign="Baseline" UpdateAfterCallBack="True" __designer:wfdid="w352" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir este registro de Tabela de Frete?' )) return true;else return false;" CommandArgument='<%# bind("id_frete_tabela") %>'></anthem:ImageButton> 
</itemtemplate>
                                                                <itemstyle horizontalalign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="id_situacao_aprovacao" Visible="False">
                                                                <itemtemplate>
<asp:Label id="lbl_id_situacao_aprovacao" runat="server" Text='<%# Bind("id_situacao_aprovacao") %>' __designer:wfdid="w248"></asp:Label>
</itemtemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                                                    </anthem:GridView>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                     
                                        
                                    </td>
                                </tr>
							</TABLE>
						</TD>
					</TR>
                    <tr>
                        <TD class="titmodulo" colSpan="2" style="height: 15px">
                            Tabela de Frete por Exceção</td>
                    </tr>
                    <tr>
                        <td align="center" class="texto" colspan="2">
                            <br />
                           
                            <table id="Table10" cellpadding="2" cellspacing="1" class="texto" width="98%">
                                <tr>
                                    <td align="right" class="texto" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid;">
                                        <strong><anthem:RequiredFieldValidator ID="RequiredFieldValidator18"
                                                runat="server" ControlToValidate="txt_dt_ini_validade" CssClass="texto" ErrorMessage="Preencha o campo Período Validade Inicial para continuar."
                                                Font-Bold="False" ToolTip="O campo Período Validade Inicial deve ser informado."
                                                ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                    ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_dt_fim_validade" CssClass="texto"
                                                    ErrorMessage="Preencha o campo Período Validade Final para continuar." Font-Bold="False"
                                                    ToolTip="O campo Período Validade Final deve ser informado." ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator>Período Validade:</strong> <cc4:OnlyDateTextBox ID="txt_dt_ini_validade"
                                            runat="server" CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc4:OnlyDateTextBox><strong>
                                                à </strong>
                                        <cc4:OnlyDateTextBox ID="txt_dt_fim_validade" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                            Width="80px"></cc4:OnlyDateTextBox>&nbsp;</td>
                                    <td align="right" class="texto" style="height: 20px; border-top: silver 1px solid; border-left: silver 1px solid;">
                                        <strong><anthem:RequiredFieldValidator ID="RequiredFieldValidator5"
                                            runat="server" ControlToValidate="cbo_tipo_frete_excecao" CssClass="texto" ErrorMessage="Preencha o campo Tipo Frete para continuar."
                                            Font-Bold="False" ToolTip="O TipoFrete deve ser informado." ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator>Tipo Frete: </strong>
                                        <anthem:DropDownList ID="cbo_tipo_frete_excecao" runat="server" CssClass="texto">
                                            <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                            <asp:ListItem Value="1">T1</asp:ListItem>
                                            <asp:ListItem Value="2">T2</asp:ListItem>
                                            <asp:ListItem Value="3">T2 TP</asp:ListItem>
                                            <asp:ListItem Value="4">T2 TVASE</asp:ListItem>
                                        </anthem:DropDownList>&nbsp;</td>
                                    <td align="right" class="texto" style=" height: 20px; border-top: silver 1px solid; border-left: silver 1px solid;">
                                        <strong><anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True"
                                                ControlToValidate="cbo_tipo_equipamento_excecao" CssClass="texto" ErrorMessage="Preencha o campo Tipo Equipamento do Frete por Exceção para continuar."
                                                Font-Bold="False" ToolTip="O campo Tipo Equipamento deve ser informado." ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator>Tipo Equipamento:
                                            <anthem:DropDownList ID="cbo_tipo_equipamento_excecao" runat="server" AutoCallBack="True" CssClass="texto">
                                            </anthem:DropDownList>&nbsp;</strong></td>
                                    <td align="center" class="texto" rowspan="3" style="border-right: silver 1px solid;
                                        border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid">
                                        <anthem:CustomValidator ID="cv_freteexcecao" runat="server" Font-Bold="True" ForeColor="White"
                                            ValidationGroup="vg_excecao">[!]</anthem:CustomValidator><anthem:Button ID="btn_incluir_frete_excecao" runat="server" CssClass="texto" Text="Incluir Exceção" ValidationGroup="vg_excecao" AutoUpdateAfterCallBack="True" /></td>
                                </tr>
                                <tr>
                                    <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px">
                                        <strong><anthem:RequiredFieldValidator
                                                ID="RequiredFieldValidator16" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_custokmexcecao"
                                                CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar." Font-Bold="False"
                                                ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator>Custo KM:</strong>
                                        <cc6:OnlyDecimalTextBox ID="txt_custokmexcecao" runat="server" CssClass="texto"
                                            MaxCaracteristica="5" MaxLength="8" MaxMantissa="2" Width="65px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                    <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px; font-weight: bold;">
                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" AutoUpdateAfterCallBack="True"
                                            ControlToValidate="txt_custofixodiariaexcecao" CssClass="texto" ErrorMessage="Preencha o campo Custo Fixo Diária para continuar."
                                            Font-Bold="False" ValidationGroup="vg_excecao" Visible="False">[!]</anthem:RequiredFieldValidator>Custo
                                        Fixo Diária:
                                        <cc6:OnlyDecimalTextBox ID="txt_custofixodiariaexcecao" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxCaracteristica="5" MaxLength="8" MaxMantissa="2" Width="65px"></cc6:OnlyDecimalTextBox>&nbsp;</td>
                                    <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid; height: 20px">
                                        <strong>Custo
                                                Fixo Mensal: </strong>
                                        <cc6:OnlyDecimalTextBox ID="txt_custofixomesexcecao" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" MaxCaracteristica="6" MaxLength="9" MaxMantissa="2" Width="65px"></cc6:OnlyDecimalTextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid;
                                                    border-bottom: gray 1px solid; height: 20px" colspan="2">
                                        <strong>Calcular Custo Fixo Mensal Por: </strong>
                                        <anthem:DropDownList ID="cbo_customestipoexcecao" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                            <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                            <asp:ListItem Value="1">Nr Ve&#237;culos Acordados</asp:ListItem>
                                            <asp:ListItem Value="2">Ve&#237;culos Utilizados</asp:ListItem>
                                            <asp:ListItem Value="3">Tipo Equipamento</asp:ListItem>
                                        </anthem:DropDownList>
                                        &nbsp;&nbsp; <strong>Nr. Veículos:
                                            <cc3:OnlyNumbersTextBox ID="txt_nr_veiculos_excecao" runat="server" AutoUpdateAfterCallBack="True"
                                                CssClass="texto" Enabled="False" MaxLength="3" Width="30px"></cc3:OnlyNumbersTextBox>&nbsp;</strong></td>
                                    <td align="right" class="texto" style="border-top: silver 1px solid; border-left: silver 1px solid;
                                                    border-bottom: gray 1px solid; height: 20px; font-weight: bold;"><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_rota"
                                            CssClass="texto" ErrorMessage="Preencha o campo Rota para continuar." Font-Bold="False"
                                            ToolTip="O campo Rota deve ser informado." ValidationGroup="vg_excecao">[!]</anthem:RequiredFieldValidator>Rota: 
                                        <anthem:DropDownList ID="cbo_rota" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                        </anthem:DropDownList>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" class="texto" style="height: 6px" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="texto" colspan="4">
                                        <anthem:GridView ID="grdExcecao" runat="server" AddCallBacks="False" AutoGenerateColumns="False"
                                                        AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" UpdateAfterCallBack="True"
                                                        UseAccessibleHeader="False" Visible="False" Width="100%" DataKeyNames="id_frete_tabela_excecao">
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                            ForeColor="White" HorizontalAlign="Left" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                            HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Per&#237;odo Validade">
                                                    <edititemtemplate>
&nbsp;&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_dt_referencia_ini" runat="server" Text='<%# Bind("ds_periodo") %>' __designer:wfdid="w356"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Tipo" ReadOnly="True" DataField="dstipofrete" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" />
                                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equipamento" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_eixo" HeaderText="Nr Eixos" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_custo_km" HeaderText="Custo KM" />
                                                <asp:BoundField DataField="nr_custo_fixo_diaria" HeaderText="Custo Fixo Dia" />
                                                <asp:BoundField DataField="nr_custo_fixo_mes" HeaderText="Custo Fixo M&#234;s" />
                                                <asp:BoundField DataField="dstipocustofixomes" HeaderText="Calcular Custo M&#234;s Por:" />
                                                <asp:BoundField DataField="nr_custo_fixo_mes_veiculos" HeaderText="Nr Ve&#237;culos" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CausesValidation="True" ValidationGroup="vg_grid" Text="Update" __designer:wfdid="w359" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_voltar" runat="server" ImageUrl="~/img/icon_undo.gif" CausesValidation="False" Text="Cancel" __designer:wfdid="w360" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="validatorSummary" runat="server" ValidationGroup="vg_grid" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w361"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CausesValidation="False" Visible="False" Text="Edit" __designer:wfdid="w357" CommandName="Edit"></asp:ImageButton> <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir registro de Tabela de Frete Exceção" AutoUpdateAfterCallBack="True" ImageAlign="Baseline" UpdateAfterCallBack="True" __designer:wfdid="w358" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir este registro de Tabela de Frete Exceção ?' )) return true;else return false;" CommandArgument='<%# bind("id_frete_tabela_excecao") %>'></anthem:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="White" HorizontalAlign="Left" />
                                        </anthem:GridView>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;
                            &nbsp;
                        </td>
                    </tr>

					<TR id="tr_dados_sitema" runat="server">
						<TD colSpan="2" class="texto">
							<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD class="titmodulo"  colSpan="2" style="height: 15px">Dados do Sistema</TD>
								</TR>
                                <tr>
                                    <td align="right" class="texto" style="width:20%">
                                        <strong>Situação:</strong></td>
                                    <td>
                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                CssClass="texto" Enabled="False">
                                        </anthem:DropDownList></td>
                                </tr>
								<TR>
									<TD class="texto" align="right"  style="height: 17px">
                                        <strong>Modificador:</strong></TD>
									<TD style="height: 17px">&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
								</TR>
								<TR>
									<TD class="texto" align="right" style="height: 17px">
                                        <strong>Data Modificação:</strong></TD>
									<TD style="height: 17px">&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
					
		</TD>
		<TD   style="width: 7px"></TD>
	</TR>
	<TR>
		<TD style="width: 7px">&nbsp;</TD>
		<TD vAlign="top" class="texto">
			<TABLE id="Table3"  cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="faixafiltro1a"  vAlign="middle" align="left" 
						background="img/faixa_filro.gif">
                        &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
					<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
						>&nbsp;</TD>
				</TR>
			</TABLE>

		</TD>
		<TD style="width: 7px">&nbsp;</TD>
	</TR>
</TABLE>
<asp:ValidationSummary id="validatorSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_excecao"></asp:ValidationSummary>
<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_frete"></asp:ValidationSummary>
    <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
    UpdateAfterCallBack="True"></cc7:AlertMessages><anthem:HiddenField ID="hf_id_transportador"
        runat="server" AutoUpdateAfterCallBack="true" />
    <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
</form>
</body>
</html>
