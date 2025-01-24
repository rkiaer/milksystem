<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_solicitar_cotacao.aspx.vb" Inherits="lst_central_solicitar_cotacao" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_central_solicitar_cotacao</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" style="width: 100%">
	
<script type="text/javascript"> 

    function ShowDialog() 
    
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
        } 
    }            
function Table2_onclick() {

}

</script>
		<form id="form1" method="post" runat="server" >


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 98%;"><STRONG>Solicitação de Cotação&nbsp;</STRONG></TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px"></TD>
					<TD align="center">
						</TD>
					<TD style="width: 1%"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif" align="right" class="faixafiltro1a">
                        <anthem:HyperLink ID="hl_grupo_pool_compras" runat="server" AutoUpdateAfterCallBack="True"
                            Target="_blank" UpdateAfterCallBack="True" Visible="False">Grupo Produtores</anthem:HyperLink>
                    </TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0"  >
							<TR>
								<TD style="height: 12px;"></TD>
								<TD style="height: 12px;"></TD>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 12px;">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; width: 15%;" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; " colspan="2">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;
                                    </td>
                                <td style="height: 20px">
                                </td>
                                <td style="height: 20px;">
                                </td>
                            </tr>
			                <tr>
			                    <td align="right" style="height: 20px">
                                    Cód. Produtor:</td>
                                <td align="left" colspan="2" style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    &nbsp;<anthem:imagebutton ID="btn_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td align="right" style="height: 20px">
                                    Telefone:</td>
                                <td valign="bottom" style="height: 20px">
                                    <anthem:Label ID="lbl_telefone" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                </td>
                                <td style="height: 20px; ">
                                    &nbsp; Contato:
                                    <anthem:Label ID="lbl_contato" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td align="left" style="height: 20px; ">
                                    email:
                                    <anthem:Label ID="lbl_email" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False" style="vertical-align: bottom"></anthem:Label></td>
                                <td style="height: 20px; width: 10%;" align="right">
                                    Fax:</td>
                                <td style="height: 20px; width: 18%;" valign="bottom">
                                    <anthem:Label ID="lbl_fax" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
							
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Cód. Propriedade:</td>
                                <td style="height: 20px;" colspan="4">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_id_propriedade" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nr. Cotação:</td>
                                <td style="height: 20px;">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_cotacao" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" MaxLength="15" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                                <td colspan="2" style="height: 20px">
                                    Data da Cotação:&nbsp;
                                    <cc4:OnlyDateTextBox ID="txt_dt_cotacao" runat="server" CssClass="caixatexto" Width="72px"></cc4:OnlyDateTextBox></td>
                                <td colspan="1" style="height: 20px">
                                    &nbsp;</td>
                            </tr>
							<TR>
								<TD  align="right" style="height: 20px">&nbsp;Cód. Item:</td>
                                <TD style="height: 20px;" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_item" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_item" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td style="height: 20px" align="right">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação Cotação:</TD>
								<TD style="HEIGHT: 20px; ">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                                <td style="height: 20px" colspan="2">
                                    Sit. Item Cotação:
                                    <asp:DropDownList id="cbo_situacao_item" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td style="height: 20px">
                                    &nbsp;</td>
							</TR>
							<tr>
								<TD style="height: 29px" align="right">&nbsp;<anthem:CheckBox ID="chk_ver_mercado" runat="server" Text="Ver Mercado" /></TD>
								<TD align="left" colspan="2" style="height: 29px">
                                    &nbsp;&nbsp;
                                    <anthem:CheckBox ID="chk_prod_informado" runat="server" Text="Prod.Informado" />
                                    &nbsp;</TD>
                                <td align="center" colspan="2" style="height: 29px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    </td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 1%" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 5px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="width: 1%;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" SortExpression="cd_pessoa" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Nome" SortExpression="nm_abreviado_pessoa" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True"
                                    SortExpression="id_propriedade">
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" ReadOnly="True"
                                    SortExpression="nr_unid_producao">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cota&#231;&#227;o" DataField="id_central_cotacao" SortExpression="id_central_cotacao" />
                                <asp:BoundField HeaderText="Data" DataField="dt_cotacao" SortExpression="dt_cotacao" />
                                <asp:BoundField DataField="cd_item" HeaderText="Item" ReadOnly="True" SortExpression="cd_item" />
                                <asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o" ReadOnly="True" SortExpression="nm_item" />
                                <asp:BoundField HeaderText="Emb." DataField="ds_tipo_medida" SortExpression="ds_tipo_medida" />
                                <asp:BoundField HeaderText="Qtde" DataField="nr_quantidade" SortExpression="nr_quantidade" />
                                <asp:BoundField HeaderText="Valor Total" DataField="nr_valor_total" />
                                <asp:BoundField HeaderText="Entrega" SortExpression="dt_entrega" Visible="False" />
                                <asp:BoundField DataField="nm_central_status_aprovacao" HeaderText="Sit.Item" SortExpression="nm_central_status_aprovacao" />
                                <asp:BoundField HeaderText="Sit.Cota&#231;&#227;o" DataField="nm_situacao_cotacao" SortExpression="nm_situacao_cotacao" />
                                <asp:BoundField HeaderText="VM" DataField="st_ver_mercado" SortExpression="st_ver_mercado" />
                                <asp:BoundField HeaderText="PI" DataField="st_produtor_informado" SortExpression="st_produtor_informado" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_central_cotacao") %>' CommandName="edit" __designer:wfdid="w5"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" Visible="False" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandArgument='<%# Bind("id_central_cotacao") %>' CommandName="delete" __designer:wfdid="w6" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="3%" />
                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
