<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_pedido_reabrir.aspx.vb" Inherits="lst_central_pedido_reabrir" %>

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
		<title>lst_central_pedido_reabrir</title>
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
</script>
		<form id="form1" method="post" runat="server" >


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 98%;"><STRONG>Reabertuta de Pedido</STRONG></TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 2px;"></TD>
					<TD align="center" style="height: 2px">
						</TD>
					<TD style="width: 1%; height: 2px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif" align="right" class="faixafiltro1a">
                        </TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 99px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 99px">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 2px;"></TD>
								<TD style="height: 2px;"></TD>
                                <td style="height: 2px">
                                </td>
                                <td style="height: 2px;">
                                </td>
                                <td style="height: 2px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 22px; width: 18%;" align="right">&nbsp;Estabelecimento:</td>
                                <TD style="HEIGHT: 22px; " colspan="2">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;&nbsp;
                                    </td>
                                <td style="height: 22px">
                                </td>
                                <td style="height: 22px; width: 25%;">
                                </td>
                            </tr>
			                <tr>
			                    <td align="right" style="height: 22px">
                                    Cód. Produtor:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    &nbsp;<anthem:imagebutton ID="btn_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
							</tr>
							
                            <tr>
                                <td align="right" style="height: 22px" >
                                    Cód. Parceiro:</td>
                                <td style="height: 22px;" colspan="4">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_fornecedor" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_parceiro" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nr. Pedido:</td>
                                <td style="height: 20px;" colspan="4">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_pedido" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" MaxLength="15" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nr. Cotação:</td>
                                <td style="height: 20px;" colspan="4">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_cotacao" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" MaxLength="15" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                            </tr>
                            <tr>
                                <TD  align="right" style="height: 20px">
                                    &nbsp;Data do Pedido:</td>
                                <TD style="height: 20px;" colspan="2">
                                    &nbsp;
                                    <cc4:OnlyDateTextBox ID="txt_dt_pedido" runat="server" CssClass="caixatexto" Width="72px"></cc4:OnlyDateTextBox></td>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 12px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 12px; ">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                                <td style="height: 12px">
                                    </td>
                                <td style="height: 12px" colspan="2">
                                    </td>
							</TR>
							<tr>
								<TD style="height: 10px">&nbsp;</TD>
								<TD align="right" colspan="2" style="height: 10px" valign="bottom">
                                    &nbsp;&nbsp;</TD>
                                <td align="center" colspan="2" style="height: 10px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton></td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 1%; height: 99px;" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 5px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 5px">&nbsp;</TD>
					<TD style="width: 1%; height: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_pessoa" HeaderText="Produtor" SortExpression="cd_pessoa" ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Nome" SortExpression="nm_abreviado_pessoa" >
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop."
                                    SortExpression="id_propriedade">
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Pedido" DataField="id_central_pedido" SortExpression="id_central_pedido" />
                                <asp:BoundField DataField="cd_fornecedor" HeaderText="Parceiro"
                                    SortExpression="cd_fornecedor" />
                                <asp:BoundField DataField="nm_abreviado_fornecedor" HeaderText="Nome" SortExpression="nm_abreviado_fornecedor" />
                                <asp:BoundField HeaderText="Data" DataField="dt_pedido" SortExpression="dt_pedido" />
                                <asp:BoundField HeaderText="Situa&#231;&#227;o" DataField="nm_situacao_pedido" SortExpression="nm_situacao_pedido" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w17" CommandName="edit" CommandArgument='<%# Bind("id_central_pedido") %>' Visible="False"></anthem:ImageButton><asp:LinkButton id="lk_reabrirpedido" runat="server" ToolTip="Reabrir Pedido" __designer:wfdid="w18" CommandName="Reabrir" CommandArgument='<%# bind("id_central_pedido") %>'>Reabrir</asp:LinkButton> 
</itemtemplate>
                                    <headerstyle width="3%" />
                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="id_central_pedido" Visible="False" />
                                <asp:TemplateField HeaderText="id_grupo" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_grupo" runat="server" __designer:wfdid="w19" Text='<%# Bind("id_grupo_fornecedor") %>'></asp:Label> 
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
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
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
                            &nbsp;<anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
