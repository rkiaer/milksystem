<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_tabela_frete.aspx.vb" Inherits="lst_frete_tabela_frete" %>

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
		<title>lst_linha</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<script type="text/javascript"> 
    <!--
    function showaguarde() 
    
    {
        
        document.all.lbl_aguarde.value='aguardenormal';  	     
    }            
function Table2_onclick() {

}

    //-->
    </script>
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");

        szUrl = 'lupa_transportador_cooperativa.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Frete - Tabela de Frete</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 22px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="20%" style="HEIGHT: 22px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 22px;">
                                    &nbsp;<asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 22px; " align="right">
                                     </TD>
								<TD style="height: 22px" align="center">
                                    <anthem:CheckBox ID="chk_referencia_vigente" runat="server" AutoUpdateAfterCallBack="True"
                                        Checked="True" Text="Referência Vigente" Visible="False" /></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    Transportador:</td>
                                <td colspan="3" style="height: 22px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="75px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><anthem:CustomValidator
                                                ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_transportador"
                                                CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                                Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_pesquisar" Visible="False"></anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    Cooperativa:</td>
                                <td colspan="3" style="height: 22px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="75px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="False" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:CustomValidator
                                                ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa" CssClass="texto"
                                                ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!"
                                                ValidationGroup="vg_pesquisar" Visible="False"></asp:CustomValidator></td>
                            </tr>
							<TR>
								<TD style="height: 22px"></TD>
								<TD>
                                    </TD>
								<TD>&nbsp;</TD>
								<TD align="right" style="height: 22px">
                                    <anthem:ImageButton ID="btn_pesquisa" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                        ValidationGroup="vg_pesquisar" />&nbsp;<anthem:ImageButton ID="btn_limparFiltros" runat="server"
                                            ImageUrl="img/btn_limparfiltro.gif" />
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 22px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo" runat="server">Novo</anthem:LinkButton></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px;"></TD>
					<TD vAlign="middle" class="texto">&nbsp;<table id="Table3" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td valign="top">
                                    <table id="Table6" border="0" cellpadding="0" cellspacing="0" class="texto" width="100%">
                                        <tr style="height: 16px">
                                            <td class="texto" >
                                            </td>
                                            <td class="texto" style="font-size: 1px;">
                                                
                                                    <table id="Table7" cellpadding="0" cellspacing="0" class="texto"
                                                        width="100%">
                                                        <tr></tr>
                                                        <tr>
                                                            <td align="center" class="texto" style="height: 5px" valign="top">
                                                                                <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" Visible="False">
                                                                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" Height="22px" />
                                                                                    <EditRowStyle BackColor="#2461BF" />
                                                                                    <PagerStyle BackColor="#507CD1" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" Height="18px" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Det.">
                                                                                            <itemtemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Detalhes Transportador/Cooperativa" ImageUrl="~/img/icon_preview.gif" UpdateAfterCallBack="True" CommandName="detalhes" __designer:wfdid="w294"></anthem:ImageButton> 
</itemtemplate>
                                                                                            <headerstyle horizontalalign="Center" width="5%" />
                                                                                            <itemstyle horizontalalign="Center" width="5%" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" />
                                                                                        <asp:BoundField DataField="ds_transportador" HeaderText="Transportador" />
                                                                                        <asp:BoundField DataField="ds_cooperativa" HeaderText="Cooperativa" />
                                                                                        <asp:BoundField DataField="nm_situacao" HeaderText="Situa&#231;&#227;o" Visible="False" />
                                                                                        <asp:TemplateField>
                                                                                            <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" Text ImageUrl="~/img/icone_editar.gif" CommandName="selecionar" __designer:wfdid="w249" CausesValidation="False"></asp:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" Visible="False" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandName="delete" __designer:wfdid="w250" OnClientClick="if (confirm('Esta ação desativará todo conteúdo de tabela de frete para este registro, bem como qualquer cálculo de frete não exportado. Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                                                            <headerstyle width="5%" />
                                                                                            <itemstyle horizontalalign="Center" width="5%" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="id_cooperativa" Visible="False">
                                                                                            <itemtemplate>
<asp:Label id="lbl_idcooperativa" runat="server" Text='<%# Bind("id_cooperativa") %>' __designer:wfdid="w254"></asp:Label>
</itemtemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                                                                            <itemtemplate>
<asp:Label id="lbl_idtransportador" runat="server" Text='<%# Bind("id_transportador") %>' __designer:wfdid="w251"></asp:Label>
</itemtemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <RowStyle BackColor="#EFF3FB" />
                                                                                </anthem:GridView>
                                                            </td>
                                                        </tr>
                                                                &nbsp;&nbsp;
                                                    </table>
                                                
                                            </td>
                                            <td >
                                            </td>
                                        </tr>
                                    </table>
                                    					<anthem:Panel ID="pnl_detalhes" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes de" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%">
                                <tr>
                                     <td style="HEIGHT: 2px; width: 100%;" align="left">
                                         &nbsp;&nbsp;</td>
                                   <td style="HEIGHT: 2px; width: 100%;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir.gif"
                                            ToolTip="Fechar Detalhes" UpdateAfterCallBack="True" />
                                    </td>
                                </tr>
                            </table>
                            
                            <anthem:GridView ID="gridDetalhe" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_linha" PageSize="50">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                                                                        <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo Frete" />
                                                                                        <asp:BoundField DataField="dt_validade" HeaderText="V&#225;lido a Partir" />
                                                                                        <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Tipo Equipamento" />
                                                                                        <asp:BoundField DataField="nr_eixos" HeaderText="Eixos" />
                                                                                        <asp:BoundField DataField="nr_custo_km" HeaderText="Custo KM" />
                                                                                        <asp:BoundField DataField="nr_custo_fixo_diaria" HeaderText="Custo Fixo Di&#225;ria" />
                                                                                        <asp:BoundField DataField="ds_rota_transportador" HeaderText="Rota/Transp." Visible="False" />
                                             </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>

                                       
					</anthem:Panel>				

                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </TD>
					<TD style="height: 19px"></TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar" />
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
    <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />		
    </form>
	</body>
</HTML>
