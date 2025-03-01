<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_tabela_frete.aspx.vb" Inherits="lst_central_tabela_frete" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>


<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_central_tabela_precos</title>
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

    function ShowDialogFornecedor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
   	        szUrl = 'lupa_fornecedor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

    }            
</script>

	<script type="text/javascript"> 

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
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Tabela de Fretes&nbsp;</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 10px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()" style="vertical-align: bottom">
							<TR>
								<TD style="height: 12px;"></TD>
								<TD style="height: 12px;"></TD>
                                <td style="height: 12px"></td>
                                <td style="height: 12px;"></td>
                                <td style="height: 12px"></td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 22px; width: 20%;" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 22px; ">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;
                                    </td>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px; width: 25%;">
                                </td>
                            </tr>
			                <tr>
			                    <td align="right" style="height: 21px">C�digo Parceiro:</td>
								<td align="left" colspan="2" class="texto" style="height: 21px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>&nbsp;
                                            <anthem:imagebutton ID="img_lupa_fornecedor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Fornecedores"   AutoUpdateAfterCallBack="true" />&nbsp;
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td align="right" style="height: 21px;">
                                    Telefone:</td>
                                <td style="height: 21px" class="texto">
                                    &nbsp;<anthem:Label ID="lbl_telefone" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 21px" >
                                </td>
                                <td style="height: 21px; ">
                                    &nbsp; Contato:<anthem:Label ID="lbl_contato" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td align="left" style="height: 21px">Email:<anthem:Label ID="lbl_email" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td style="height: 21px" align="right">
                                    Fax:</td>
                                <td style="height: 21px" class="texto">
                                    &nbsp;<anthem:Label ID="lbl_fax" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
							
                            <tr>
                                <td align="right" style="height: 21px" >
                                    C�digo Item:</td>
                                <td style="height: 21px;" colspan="4" class="texto">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_item" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>&nbsp;
                                    <anthem:imagebutton ID="img_lupa_item" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Itens"   AutoUpdateAfterCallBack="true" />&nbsp;
                                    <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
							<TR>
								<td align="right" style="height: 21px">&nbsp;Per�odo:</TD>
								<td style="height: 21px;" colspan="4">&nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" Width="80px"></cc3:OnlyDateTextBox>
                                    �
                                    <cc3:OnlyDateTextBox ID="txt_dt_fim" runat="server" CssClass="texto" Width="80px"></cc3:OnlyDateTextBox></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 22px; width: 20%;" align="right">
                                    &nbsp; Destino:</td>
                                <TD style="HEIGHT: 22px; ">
                                    &nbsp;&nbsp;<anthem:DropDownList ID="cbo_estado_destino" runat="server" AutoCallBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                    </anthem:DropDownList>
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_cidade_destino" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList>&nbsp;
                                </td>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px; width: 25%;">
                                </td>
                            </tr>
							<tr>
								<TD style="height: 29px">&nbsp;</TD>
								<TD align="right" colspan="4" style="height: 29px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 2px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 2px">&nbsp;</TD>
					<TD style="height: 2px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD align=center>
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="cd_fornecedor" HeaderText="Parceiro " SortExpression="cd_fornecedor" />
                                                <asp:BoundField DataField="nm_abreviado" HeaderText="Nome" SortExpression="nm_fornecedor" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_item" HeaderText="Item" SortExpression="cd_item" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o"
                                                    SortExpression="nm_item" />
                                                <asp:BoundField DataField="cd_unidade_medida" HeaderText="Un" />
                                                <asp:BoundField DataField="cd_uf_origem" HeaderText="UF" />
                                                <asp:BoundField DataField="nm_cidade_origem" HeaderText="Cidade Ori" SortExpression="nm_cidade_origem" />
                                                <asp:BoundField DataField="cd_uf_destino" HeaderText="UF" />
                                                <asp:BoundField DataField="nm_cidade_destino" HeaderText="Cidade Dest" SortExpression="nm_cidade_destino" />
                                                <asp:BoundField DataField="dt_cotacao" HeaderText="Data/Hora" SortExpression="dt_cotacao" />
                                                <asp:BoundField DataField="nr_valor_v1" HeaderText="Truck 14T" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v2" HeaderText="Truck Rosca" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v3" HeaderText="BiTruck 18T" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v4" HeaderText="Car. Gran. 32T" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v5" HeaderText=" Car. Basc. 32T" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v6" HeaderText="BiTrem 36T" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_v7" HeaderText="Rodotrem" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ImageUrl="~/img/icone_editar.gif" CommandName="edit" CommandArgument='<%# Bind("id_central_tabela_frete") %>' __designer:wfdid="w1"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandName="delete" CommandArgument='<%# Bind("id_central_tabela_frete") %>' OnClientClick="if (confirm('Deseja realmente excluir o registro?' )) return true;else return false;" __designer:wfdid="w2"></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="4%" />
                                                    <itemstyle horizontalalign="Center" width="4%" />
                                                </asp:TemplateField>
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
