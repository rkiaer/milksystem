<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_frete_flash_fechamento.aspx.vb" Inherits="lst_frete_flash_fechamento" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.OnlyNumbers" Namespace="RK.TextBox.OnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Frete - Flash Fechamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
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
function Table2_onclick() {

}

</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	

<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG> Frete - Flash Fechamento</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
                        
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()" >
                            <tr>
                                <TD style="HEIGHT: 22px; width: 18%;" align="right"><span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 22px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic">[!]</asp:CompareValidator></td>
                                <td style="height: 22px; width: 18%;" align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Referência:</td>
                                <td style="height: 22px; width: 25%;">
                                    &nbsp;<cc5:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="caixaTexto"
                                        DateMask="MonthYear" Width="80px" AutoUpdateAfterCallBack="True"></cc5:OnlyDateTextBox>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar."
                                        Font-Bold="False" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Tipo Frete:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipofrete" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">T1</asp:ListItem>
                                        <asp:ListItem Value="2">T2 COOP</asp:ListItem>
                                        <asp:ListItem Value="3">T2 TP</asp:ListItem>
                                        <asp:ListItem Value="4">T2 TVASE</asp:ListItem>
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator12"
                                        runat="server" ControlToValidate="cbo_tipofrete" CssClass="texto" ErrorMessage="Preencha o campo Tipo Frete para continuar."
                                        Font-Bold="False" ToolTip="O TipoFrete deve ser informado." ValidationGroup="vg_pesquisar" InitialValue="0">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    Visão:</td>
                                <td style="height: 20px">
                                    &nbsp;<asp:DropDownList id="cbo_visao" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Value="F">Fechamento</asp:ListItem>
                                        <asp:ListItem Value="R">Romaneio/Diverg&#234;ncia</asp:ListItem>
                                        <asp:ListItem Value="RC">Romaneio Calculado</asp:ListItem>
                                        <asp:ListItem Value="FM">Fechamento Multi</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
			                <tr>
			                    <td  align="right" style="height: 23px">
                                    Transportador:</td>
								<td style="height: 23px" colspan="3">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="6" Width="70px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><anthem:CustomValidator
                                            ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_transportador"
                                            CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                            Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_pesquisar"
                                            Visible="False"></anthem:CustomValidator></td>
							</tr>
                            <tr runat="server" id="trcooperativa" visible="false">
                                <td align="right" style="height: 23px" >
                                    Cooperativa:</td>
                                <td style="height: 23px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="6" Width="70px"></anthem:TextBox>
                                    &nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="False" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:CustomValidator ID="cv_cooperativa"
                                            runat="server" ControlToValidate="txt_cd_cooperativa" CssClass="texto" ErrorMessage="Cooperativa não cadastrada!"
                                            Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_pesquisar"
                                            Visible="False"></asp:CustomValidator></td>
                                <td style="height: 23px">
                                </td>
                                <td style="height: 23px">
                                </td>
                            </tr>
							<tr>
								<TD style="height: 28px">&nbsp;</TD>
								<TD align="left" style="height: 28px">
                                    &nbsp;&nbsp;</TD>
                                <td align="right" colspan="2" style="height: 28px">
                                    <anthem:CustomValidator ID="cv_calculo" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Bold="False" Font-Italic="False" ForeColor="White" Text="[!]"
                                        ValidationGroup="vg_pesquisar"></anthem:CustomValidator>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;&nbsp;&nbsp;<anthem:ImageButton ID="btn_exportar" runat="server"
                                        AutoUpdateAfterCallBack="True" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisar" />
                                    &nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp; &nbsp;&nbsp;
                                </td>
							</TR>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp; &nbsp;
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
                        <anthem:LinkButton ID="lk_concluir" runat="server" AutoUpdateAfterCallBack="True"
                            Enabled="False" ValidationGroup="vg_salvar">Salvar Dados Multi</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 7px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 7px" class="texto">&nbsp; &nbsp; &nbsp;&nbsp;
                        <anthem:Label ID="lbl_referencia" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Font-Italic="True" Font-Strikeout="False" ForeColor="Red" UpdateAfterCallBack="True"></anthem:Label></TD>
					<TD style="height: 7px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align="center">
									
                        <anthem:GridView ID="gridResults" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False">
                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_variavel" DataFormatString="{0:N2}" HeaderText="C.Vari&#225;vel">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_fixo" DataFormatString="{0:N2}" HeaderText="C.Fixo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_extra_lancado" DataFormatString="{0:N2}" HeaderText="C.Extra">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_desconto_lancado" DataFormatString="{0:N2}" HeaderText="Desconto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_bruto" DataFormatString="{0:N2}" HeaderText="Total Bruto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w81"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridromaneio" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />

                                <asp:BoundField DataField="nm_linha" HeaderText="Rota">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" DataFormatString="{0:N0}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="nr_preco_medio_leite" HeaderText="Pre&#231;o M&#233;dio" DataFormatString="{0:N4}" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="dsnrdivergencia" HeaderText="Tem Erros?" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="id_cd_divergencia" HeaderText="Cod." >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ds_divergencia" HeaderText="Divergencia" >
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" />
                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView><anthem:GridView ID="gridResultsT2" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_custo_variavel" DataFormatString="{0:N2}" HeaderText="C.Vari&#225;vel">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_custo_fixo" DataFormatString="{0:N2}" HeaderText="C.Fixo">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_custo_extra_lancado" DataFormatString="{0:N2}" HeaderText="C.Extra">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_desconto_lancado" DataFormatString="{0:N2}" HeaderText="Desconto">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_bruto" DataFormatString="{0:N2}" HeaderText="Total Bruto">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="seq" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w81"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                        <anthem:GridView ID="gridRomaneioT2" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tipo_equipamento" HeaderText="Equip.">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_km_frete" HeaderText="KM Frete" DataFormatString="{0:N0}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_preco_medio_leite" HeaderText="Pre&#231;o M&#233;dio" DataFormatString="{0:N4}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dsnrdivergencia" HeaderText="Tem Erros?" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_cd_divergencia" HeaderText="Cod." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_divergencia" HeaderText="Divergencia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>

                        <anthem:GridView ID="gridTotal" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False" DataKeyNames="id_calculo_frete_transportador">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" Visible="False" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_variavel" DataFormatString="{0:N2}" HeaderText="C.Vari&#225;vel">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_fixo" DataFormatString="{0:N2}" HeaderText="C.Fixo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_extra_lancado" DataFormatString="{0:N2}" HeaderText="C.Extra">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_desconto_lancado" DataFormatString="{0:N2}" HeaderText="Desconto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_bruto" DataFormatString="{0:N2}" HeaderText="Total Bruto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CTE">
                                    <itemtemplate>
<cc3:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_nr_cte_multi" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="100px" Text='<%# bind("nr_cte_multi") %>' __designer:wfdid="w243" OnTextChanged="txt_nr_cte_multi_TextChanged" AutoPostBack="True"></cc3:OnlyNumbersTextBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nr Viagem">
                                    <itemtemplate>
<cc3:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_nr_viagem_multi" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="100px" Text='<%# bind("nr_viagem_multi") %>' __designer:wfdid="w241" OnTextChanged="txt_nr_viagem_multi_TextChanged" AutoPostBack="True"></cc3:OnlyNumbersTextBox>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Anexar Docto ao Cálculo Frete Transportador" ImageUrl="~/img/icone_anexar.gif" ImageAlign="Baseline" __designer:wfdid="w244" CommandArgument='<%# Bind("id_calculo_frete_transportador") %>' CommandName="anexar"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_tipo_calculo" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_calculo" runat="server" Text='<%# Bind("st_tipo_calculo") %>' __designer:wfdid="w198"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView><anthem:GridView ID="gridTotalT2" runat="server"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="500" Visible="False" DataKeyNames="id_calculo_frete_transportador">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_referencia" HeaderText="Refer&#234;ncia" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_transportador" HeaderText="Cd.Transp" Visible="False" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_transportador" HeaderText="Transportador" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_cooperativa" HeaderText="Cooperativa">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ds_tipo_frete" HeaderText="Tipo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_variavel" DataFormatString="{0:N2}" HeaderText="C.Vari&#225;vel">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_custo_fixo" DataFormatString="{0:N2}" HeaderText="C.Fixo">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_custo_extra_lancado" DataFormatString="{0:N2}" HeaderText="C.Extra">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_desconto_lancado" DataFormatString="{0:N2}" HeaderText="Desconto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_total_bruto" DataFormatString="{0:N2}" HeaderText="Total Bruto">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="CTE">
                                    <itemtemplate>
<cc3:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_nr_cte_multit2" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="100px" Text='<%# bind("nr_cte_multi") %>' __designer:wfdid="w245" OnTextChanged="txt_nr_cte_multit2_TextChanged" AutoPostBack="True"></cc3:OnlyNumbersTextBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nr Viagem">
                                    <itemtemplate>
<cc3:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_nr_viagem_multit2" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="100px" Text='<%# bind("nr_viagem_multi") %>' __designer:wfdid="w246" OnTextChanged="txt_nr_viagem_multit2_TextChanged" AutoPostBack="True"></cc3:OnlyNumbersTextBox> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="btn_anexar" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Anexar Docto ao Cálculo Frete Transportador" ImageUrl="~/img/icone_anexar.gif" ImageAlign="Baseline" __designer:wfdid="w222" CommandArgument='<%# Bind("id_calculo_frete_transportador") %>' CommandName="anexar"></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="seq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_seq" runat="server" Text='<%# Bind("seq") %>' __designer:wfdid="w155"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_tipo_calculo" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_st_tipo_calculo" runat="server" Text='<%# Bind("st_tipo_calculo") %>' __designer:wfdid="w195"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>

										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><div visible="false">
                <anthem:HiddenField ID="hf_id_frete_periodo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
