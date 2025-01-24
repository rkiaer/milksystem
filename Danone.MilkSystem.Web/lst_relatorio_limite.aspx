<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_relatorio_limite.aspx.vb" Inherits="lst_relatorio_limite" %>

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
		<title>lst_relatorio_limite</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        // var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
    
        //if (idcboestabel == "0")
        //{
        //    alert("O estabelecimento deve ser informado!");
        //}
        //else
        //{
   	        //szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            szUrl = 'lupa_produtor.aspx';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         //}
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Limite</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 181px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 181px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span style="color: #ff0000">*</span>Mês/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" Columns="7" CssClass="texto"
                                        DateMask="MonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        Font-Bold="True" SetFocusOnError="True" ErrorMessage="Informe o Mes/Ano de Referência." ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span style="color: #ff0000">*</span>Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" Width="192px">
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        ErrorMessage="Informe o Estabelecimento." Font-Bold="True" SetFocusOnError="True"
                                        ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código EPL:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_cd_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Cód. Produtor:</td>
                                <td align="left" colspan="2" style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Cód. Propriedade:</td>
                                <td colspan="2" style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span style="color: #ff0000">*</span>Emitir por:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo_emissao" runat="server" CssClass="texto">
                                        <asp:ListItem Selected="True" Value="S">Sint&#233;tico</asp:ListItem>
                                        <asp:ListItem Value="A">Anal&#237;tico</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="height: 181px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResultsAnalitico" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8" Visible="False">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d.Prod." >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoareduzido" HeaderText="Produtor" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Left" wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;d. SAP" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volume" HeaderText="Vol.Mes" DataFormatString="{0:N0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Val. Mes Estim." DataField="valorestimado" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="valor_rendimento_propriedade" DataFormatString="{0:N2}"
                                                    HeaderText="Rend.M-1"> 
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Desc. M&#234;s Atual" DataField="desconto_lancamento" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Adto" DataField="desconto_adiantamento" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="desconto_contas_parceladas" DataFormatString="{0:N2}"
                                                    HeaderText="Cta Parc." ReadOnly="True">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="desconto_parcelado_danone" HeaderText="Parc.Central" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Ped Abertos">
                                                    <itemtemplate>
<asp:HyperLink id="hl_pedidosabertos" runat="server" __designer:wfdid="w2" Text='<%# Eval("desconto_aberto", "{0:N2}") %>' Target="_blank" NavigateUrl='<%# Eval("id_propriedade", "~/frm_central_pedidos_abertos.aspx?id_propriedade={0}") %>'></asp:HyperLink> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fin.Parcial">
                                                    <itemtemplate>
<asp:HyperLink id="hl_finparcial" runat="server" Text='<%# Eval("desconto_fin_parcial", "{0:N2}") %>' Target="_blank" NavigateUrl='<%# Eval("id_propriedade", "~/frm_central_pedidos_abertos.aspx?id_propriedade={0}") %>'></asp:HyperLink> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="desconto_propriedade" DataFormatString="{0:N2}" HeaderText="Desc.Prop."
                                                    ReadOnly="True">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="volumetotal" DataFormatString="{0:N0}" HeaderText="Tot Volume">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="valor_rendimento_bymatriz" DataFormatString="{0:N2}" HeaderText="Tot Rend.M-1"
                                                    ReadOnly="True">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="limitebruto_bymatriz" DataFormatString="{0:N2}" HeaderText="Tot Limite 150%">
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Tot Desc." DataField="desconto_bymatriz" DataFormatString="{0:N2}" >
                                                    <headerstyle wrap="False" horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Limite Disp." DataField="nr_limite_mes_liquido" DataFormatString="{0:N2}" >
                                                    <headerstyle horizontalalign="Center" wrap="False" />
                                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_tecnico" HeaderText="C&#243;d.EPL" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" SortExpression="nm_tecnico" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% Limite Calc" Visible="False" />
                                                <asp:BoundField HeaderText="% Vl Mensal Estim." Visible="False" />
                                            </Columns>
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                        <anthem:GridView ID="gridResultsSintetico" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8" Visible="False" HorizontalAlign="Center">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d.Prod." >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                               <asp:BoundField DataField="nm_pessoareduzido" HeaderText="Produtor" >
                                   <headerstyle horizontalalign="Center" />
                                   <itemstyle horizontalalign="Left" wrap="False" />
                               </asp:BoundField>
                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="volume" HeaderText="Vol.Mes" DataFormatString="{0:N0}" >
                                     <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Val. Mes Estim." DataField="valorestimado" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="valor_rendimento" DataFormatString="{0:N2}"
                                    HeaderText="Rend.M-1">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="limitebruto" DataFormatString="{0:N2}" HeaderText="Tot Limite 150%">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle backcolor="Aquamarine" horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Desc. M&#234;s Atual" DataField="desconto_lancamento" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Desc. Adto" DataField="desconto_adiantamento" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_contas_parceladas" DataFormatString="{0:N2}"
                                    HeaderText="Desc Cta Parc." ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_parcelado_danone" HeaderText="Parc.Central" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_aberto" HeaderText="Ped Abertos" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desconto_fin_parcial" HeaderText="Fin.Parcial">
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Desc." DataField="totaldesconto" DataFormatString="{0:N2}" >
                                    <headerstyle wrap="True" horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Limite Disp." DataField="nr_limite_mes_liquido" DataFormatString="{0:N2}" >
                                    <headerstyle horizontalalign="Center" wrap="False" />
                                    <itemstyle horizontalalign="Right" backcolor="Aquamarine" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_tecnico" HeaderText="C&#243;d.EPL" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" SortExpression="nm_tecnico" >
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />


		</form>
	</body>
</HTML>
