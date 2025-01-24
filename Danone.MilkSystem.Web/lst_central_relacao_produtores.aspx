<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_central_relacao_produtores.aspx.vb" Inherits="lst_central_relacao_produtores" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Spend Produtores</title>
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
                //alert(retorno);
            } 
         
    }              
    function ShowDialogFornecedor() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_fornecedor = document.getElementById("hf_id_fornecedor");
           	     
        szUrl = 'lupa_fornecedor.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_fornecedor.value=retorno;
                //alert(retorno);
            } 
         
    }                
    </script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Spend Produtores</strong></TD>
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
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="Texto" Width="192px">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Produtor:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_cd_produtor" runat="server" CssClass="caixaTexto" Width="88px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtor" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span id="Span2" class="obrigatorio">*</span><anthem:DropDownList ID="cbo_referencia" runat="server" AutoPostBack="True" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Selected="True" Value="1">Mês/Ano Refer&#234;ncia</asp:ListItem>
                                        <asp:ListItem Value="2">Per&#237;odo M&#234;s/Ano</asp:ListItem>
                                    </anthem:DropDownList>:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" Columns="7" CssClass="caixaTexto"
                                        DateMask="MonthYear" Width="87px" AutoUpdateAfterCallBack="True"></cc2:OnlyDateTextBox><cc2:OnlyDateTextBox
                                            ID="txt_data_inicio" runat="server" AutoUpdateAfterCallBack="True" CssClass="caixatexto"
                                            Width="87px" DateMask="MonthYear" Visible="False"></cc2:OnlyDateTextBox>
                                    <anthem:Label ID="lbl_a" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False">à</anthem:Label><cc2:OnlyDateTextBox ID="txt_data_fim"
                                            runat="server" AutoUpdateAfterCallBack="True" CssClass="caixatexto" Width="87px" DateMask="MonthYear" Visible="False"></cc2:OnlyDateTextBox><anthem:RequiredFieldValidator
                                                ID="rf_dt_ini" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_data_inicio"
                                                CssClass="texto" ErrorMessage="Preencha o campo Data Inicial para continuar."
                                                Font-Bold="True" ValidationGroup="vg_load" Enabled="False">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                    ID="rf_dt_fim" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_data_fim"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Data Final para continuar." Font-Bold="True" Enabled="False" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                        ID="rf_referencia" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_referencia"
                                                        CssClass="texto" ErrorMessage="Informe o Mes/Ano de Referência." Font-Bold="True"
                                                        ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                            ID="cv_dtini_fim" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                                                            ErrorMessage="Data de Início não pder ser menor que Data Final do período." ToolTip="Data de Início não pder ser menor que Data Final do período."
                                                            ValidationGroup="vg_load">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span id="Span2" class="obrigatorio">*</span>Emitir por:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_tipo" runat="server" CssClass="texto">
                                        <asp:ListItem Value="1">Anal&#237;tico</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">Sint&#233;tico</asp:ListItem>
                                        <asp:ListItem Value="3">Sint&#233;tico Estabelecimento</asp:ListItem>
                                    </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="cbo_tipo" CssClass="texto"
                                        ErrorMessage="Preencha o campo Tipo do Relatório para continuar." Font-Bold="True"
                                        InitialValue="Tipo do Relatório deve ser informado." ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    &nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />
                                    &nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" /><anthem:HyperLink
                            ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_motorista.aspx" Target="_blank"
                            UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink></TD>
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
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Estabelecimento" >
                                                    <headerstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" SortExpression="cd_pessoa" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome " SortExpression="nm_pessoa" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="T&#233;cnico" Visible="False" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" SortExpression="dt_referencia" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Total Nota" DataField="nr_valor_total_nota" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_leite" HeaderText="Volume Leite" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_por_litros" DataFormatString="{0:n2}" HeaderText="R$/L">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_total_compras_central" HeaderText="Compras Total" ReadOnly="True" DataFormatString="{0:n2}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Spend R$/L" DataField="nr_spend" DataFormatString="{0:n4}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_perc_utilizado_faturamento" DataFormatString="{0:n2}"
                                                    HeaderText="% Utiliz. X Fat.">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="id_estabelecimento" Visible="False">
                                                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("id_estabelecimento") %>' id="Label1"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_estabelecimento" runat="server" __designer:wfdid="w42" Text='<%# Bind("id_estabelecimento") %>'></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
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
            &nbsp;
            <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="True" />
            &nbsp;
		</form>
	</body>
</HTML>
