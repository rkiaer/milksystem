<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_importar_pedidos_dados.aspx.vb" Inherits="lst_importar_pedidos_dados" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Pedidos Importados Fomento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
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
        } 
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Pedidos Importados Fomento</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD style="height: 12px; width: 15%" ></TD>
								<TD style="height: 12px; width: 35%"></TD>
								<TD style="height: 12px; width: 15%"></TD>
								<TD style="height: 12px"></TD>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Pagto:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_pagto_ini" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox ID="txt_dt_pagto_fim" runat="server" CssClass="texto" Width="75px"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_pagto_ini"
                                        CssClass="texto" ErrorMessage="Preencha o campo Período Pagto para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    Cód Produtor:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_produtor" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True" MaxLength="10" Height="24px"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_produtor" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    &nbsp;<anthem:CustomValidator ID="cv_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_produtor" CssClass="texto" Display="Dynamic" ErrorMessage="Produtor não cadastrado!"
                                        Font-Bold="true" Text="[!]" ToolTip="Produtor Não Cadastrado!" ValidationGroup="vg_pesquisar"></anthem:CustomValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 25px; ">
                                    Cód Parceiro:</td>
								<td style="height: 25px; ">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_fornecedor" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10" Height="24px"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_parceiro" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_parceiro" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;<anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_fornecedor" CssClass="texto" Display="Dynamic" ErrorMessage="Fornecedor não cadastrado!"
                                        Font-Bold="true" Text="[!]" ToolTip="Fornecedor Não Cadastrado!" ValidationGroup="vg_pesquisar"></anthem:CustomValidator>&nbsp; &nbsp;
    	                        </td>
								<TD align="right" style="height: 25px;">
                                    Propriedade:</TD>
								<TD style="height: 25px">&nbsp;&nbsp;<cc4:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" CssClass="caixatexto"
                                        Height="24px" Width="80px"></cc4:OnlyNumbersTextBox></td>
 							</tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Nr. Importação:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_id_importacao" runat="server" CssClass="caixatexto"
                                        Height="24px" Width="80px"></cc4:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 25px">
                                    Nr Nota:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc4:OnlyNumbersTextBox ID="txt_nr_nota" runat="server" CssClass="caixatexto"
                                        Height="24px" Width="80px"></cc4:OnlyNumbersTextBox></td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_pesquisar" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>&nbsp;&nbsp; &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px; width: 10px;"></TD>
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
                                <asp:BoundField DataField="id_importacao" HeaderText="Nr Import." />
                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Prop/UP" SortExpression="ds_propriedade" />
                                <asp:BoundField DataField="cd_fornecedor" HeaderText="Cod.Parceiro" />
                                <asp:BoundField DataField="nm_fornecedor" HeaderText="Parceiro" SortExpression="nm_fornecedor" />
                                <asp:BoundField DataField="nr_nota" HeaderText="Nr Nota" SortExpression="nr_nota" />
                                <asp:BoundField DataField="nr_serie" HeaderText="S&#233;rie" />
                                <asp:BoundField DataField="nr_valor_nota" HeaderText="Valor Nota" />
                                <asp:BoundField DataField="dt_pagto_fornecedor" HeaderText="Pagto Fornec." SortExpression="dt_pagto_fornecedor" />
                                <asp:BoundField DataField="dt_desconto_produtor" HeaderText="Desc.Produtor" SortExpression="dt_desconto_produtor" />
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Nr Pedido" SortExpression="id_central_pedido" />
                                <asp:BoundField DataField="dt_fim_execucao" HeaderText="Dt Import" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
                            &nbsp;<anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
