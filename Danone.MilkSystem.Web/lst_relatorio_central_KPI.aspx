<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_relatorio_central_KPI.aspx.vb" Inherits="lst_relatorio_central_KPI" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>KPI Central</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	

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
        } 
    }            
              
    </script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>KPI Central</strong></TD>
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
                                    &nbsp;<span id="Span1" class="obrigatorio">*</span>Período Mês/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox
                                            ID="txt_data_inicio" runat="server" AutoUpdateAfterCallBack="True" CssClass="caixatexto"
                                            Width="87px" DateMask="MonthYear"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_data_fim"
                                            runat="server" AutoUpdateAfterCallBack="True" CssClass="caixatexto" Width="87px" DateMask="MonthYear"></cc2:OnlyDateTextBox><anthem:RequiredFieldValidator
                                                ID="rf_dt_ini" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_data_inicio"
                                                CssClass="texto" ErrorMessage="Preencha o campo Data Inicial para continuar."
                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                    ID="rf_dt_fim" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_data_fim"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Data Final para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator
                                                        ID="cv_dtini_fim" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                                                        ErrorMessage="Data de Início não pder ser menor que Data Final do período." ToolTip="Data de Início não pder ser menor que Data Final do período."
                                                        ValidationGroup="vg_load">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;Cód. Item:</td>
                                <td colspan="2" style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_item" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_item" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Categoria:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_categoria" runat="server" CssClass="Texto">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Canal:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_canal" runat="server" CssClass="Texto">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Produtor:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_cd_produtor" runat="server" CssClass="caixaTexto" Width="88px" AutoCallBack="True" AutoUpdateAfterCallBack="True" Enabled="False"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtor" Width="15px" Enabled="False" />&nbsp;
                                    <anthem:Label ID="lbl_nm_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Parceiro Central:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_fornecedor" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" Width="88px" Enabled="False"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_fornecedor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" Enabled="False" />
                                    <anthem:Label ID="lbl_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span id="Span3" class="obrigatorio">*</span>Emitir por:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_referencia" runat="server" CssClass="texto"><asp:ListItem Value="P" Selected="True">Per&#237;odo</asp:ListItem>
                                        <asp:ListItem Value="R">Refer&#234;ncia</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span id="Span2" class="obrigatorio">*</span>Exibir no KPI:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_exibir_kpi_tipo" runat="server" CssClass="texto" AutoPostBack="True">
                                        <asp:ListItem Value="I" Selected="True">Apenas Itens</asp:ListItem>
                                        <asp:ListItem Value="F">Parceiro</asp:ListItem>
                                        <asp:ListItem Value="P">Produtor</asp:ListItem>
                                    </anthem:DropDownList></td>
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
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" Visible="False" /><anthem:HyperLink
                            ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_motorista.aspx" Target="_blank"
                            UpdateAfterCallBack="True" Visible="False">Versão para Imprimir</anthem:HyperLink></TD>
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
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_produtor" HeaderText="Produtor" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Parceiro" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Categoria" DataField="nm_categoria_item" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Canal" DataField="nm_canal" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Quantidade">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" __designer:wfdid="w42"></asp:Label>
</itemtemplate>
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_unidade_medida" HeaderText="Unid.Medida" ReadOnly="True" >
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Total FOB">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_nf" runat="server" Text='<%# Bind("nr_valor_nota") %>' __designer:wfdid="w45"></asp:Label>
</itemtemplate>
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Frete">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_frete" runat="server" __designer:wfdid="w43"></asp:Label>
</itemtemplate>
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total CIF">
                                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_cif" runat="server" __designer:wfdid="w44"></asp:Label>
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_item" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_item" runat="server" Text='<%# Bind("id_item") %>' __designer:wfdid="w36"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w38"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_id_produtor" runat="server" Text='<%# Bind("id_produtor") %>' __designer:wfdid="w40"></asp:Label> 
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
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="True" />
		</form>
	</body>
</HTML>
