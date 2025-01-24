<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_central_pagto_fornecedor_conciliacao.aspx.vb" Inherits="lst_central_pagto_fornecedor_conciliacao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Conciliação Pagto Parceiro</title>
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
                        <strong>Conciliação Pagto</strong></TD>
					<TD style="height: 25px; width: 26px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 26px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 26px;">&nbsp;</TD>
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
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="Texto" Width="192px">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">
                                    Produtor:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_cd_produtor" runat="server" CssClass="caixaTexto" Width="88px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtor" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Parceiro Central:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_fornecedor" runat="server" CssClass="caixaTexto" Width="88px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_fornecedor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Técnico:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" MaxLength="10" Width="88px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />&nbsp; 
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:CustomValidator ID="cv_tecnico"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_tecnico"
                                            CssClass="texto" ErrorMessage="Técnico não cadastrado." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_tecnico"
                                        ErrorMessage="Informe o Técnico." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    &nbsp;&nbsp; &nbsp; &nbsp;
                                </td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span id="Span2" class="obrigatorio">*</span>&nbsp;Mês/Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" Columns="7" CssClass="caixaTexto"
                                        DateMask="MonthYear" Width="87px"></cc2:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        ErrorMessage="Informe o Mês/Ano de Referência." Font-Bold="True" ToolTip="Informe o Mês/Ano de Referência."
                                        ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>
                                    &nbsp;
                                    &nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="height: 181px; width: 26px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" /><anthem:HyperLink
                            ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_motorista.aspx" Target="_blank"
                            UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px; width: 26px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 26px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." />
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" Visible="False" />
                                                <asp:BoundField DataField="cd_sap_produtor" HeaderText="SAP Prod." />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Nome" />
                                                <asp:BoundField DataField="cd_parceiro" HeaderText="Parceiro" SortExpression="cd_parceiro" />
                                                <asp:BoundField DataField="cd_sap_parceiro" HeaderText="SAP Parc." />
                                                <asp:BoundField DataField="nm_parceiro" HeaderText="Nome" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="T&#233;cnico" >
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Pedido" DataField="id_central_pedido" />
                                                <asp:BoundField HeaderText="Data NF" DataField="dt_emissao_nota_fiscal" />
                                                <asp:BoundField HeaderText="N. Fiscal" DataField="nr_nota_fiscal" />
                                                <asp:BoundField HeaderText="Valor NF" DataField="nr_valor_nota_fiscal" />
                                                <asp:BoundField HeaderText="Valor Total Pago" />
                                                <asp:BoundField HeaderText="Valor Pago" DataField="nr_valor_parcela" />
                                                <asp:BoundField DataField="dt_exportacao_1vez" HeaderText="Posting Date" />
                                                <asp:BoundField HeaderText="Saldo Pagar Parc." />
                                                <asp:BoundField HeaderText="Desconto Prod." />
                                                <asp:BoundField HeaderText="Total Desconto" />
                                                <asp:BoundField DataField="nr_saldo" HeaderText="Saldo Cont&#225;bil" />
                                                <asp:TemplateField HeaderText="dt_pagto" Visible="False">
                                                    <itemtemplate>
<asp:Label id="dt_pagto" runat="server" Text='<%# Bind("dt_pagto") %>' __designer:wfdid="w1"></asp:Label>
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
					<TD style="width: 26px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 26px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="True" />
            <anthem:HiddenField ID="hf_id_produtor" runat="server" AutoUpdateAfterCallBack="True" />
            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="True" />
		</form>
	</body>
</HTML>
