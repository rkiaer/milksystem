<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_po_ordem_compra.aspx.vb" Inherits="lst_po_ordem_compra" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Pesquisar de Purchase Order (PO) Produtores, Cooperativas e Agropecuárias</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
   	        szUrl = 'lupa_coopertiva.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
     
   	        szUrl = 'lupa_produtor.aspx?tipo=A';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)">
                        <strong>Purchase Order (PO) Produtores, Cooperativas e Agropecuárias</strong></TD>
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
					<TD >&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" >
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
							<TR>
								<TD style="height: 12px; width:20%"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 15%; height: 12px">
                                </td>
                                <td style="width: 25%; height: 12px">
                                </td>
							</TR>
                            <tr>
								<TD style="HEIGHT: 21px" align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Tipo Fornecedor:</TD>
								<TD style="HEIGHT: 21px">&nbsp;
                                    <anthem:DropDownList id="cbo_tipo_fornecedor" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                        <asp:ListItem Value="A">Agropecu&#225;rias</asp:ListItem>
                                        <asp:ListItem Value="C">Cooperativas</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="P">Produtores</asp:ListItem>
                                    </anthem:DropDownList></TD>
                                 <td style="height: 21px">
                                </td>
                                <td style="height: 21px">
                                </td>
                           </tr>
                            <tr>
                                <td align="right" style="height: 21px">
                                    Estabelecimento:
                                </td>
                                <td colspan="" style="height: 21px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td align="right" colspan="" style="height: 21px">
                                    Nr. PO:</td>
                                <td colspan="" style="height: 21px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nr_po" runat="server" CssClass="caixatexto" Width="72px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px">
                                    <anthem:Label ID="lbl_periodo" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">Data Referência:</anthem:Label></td>
                                <td style="height: 21px" colspan="3">
                                    &nbsp;
                                    <cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" DateMask="MonthYear" Width="72px"></cc4:OnlyDateTextBox><cc4:OnlyDateTextBox
                                            ID="txt_dt_ini" runat="server" AutoUpdateAfterCallBack="True" CssClass="caixatexto"
                                            Width="72px" Visible="False"></cc4:OnlyDateTextBox>
                                    &nbsp;<anthem:Label ID="lbl_separador" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True" Visible="False">à</anthem:Label>
                                    <cc4:OnlyDateTextBox ID="txt_dt_fim" runat="server"
                                            AutoUpdateAfterCallBack="True" CssClass="caixatexto" Width="72px" Visible="False"></cc4:OnlyDateTextBox>&nbsp;
                                </td>
                            </tr>
			                <tr>
			                    <td  align="right" style="height: 21px">
                                    <anthem:Label ID="lbl_cooperativa_estado" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True">Estado:</anthem:Label></td>
								<td style="height: 21px" colspan="3">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estado" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList><anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10" Visible="False"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_cooperativa" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" ValidationGroup="vg_lupa" Visible="False" />
                                    <anthem:imagebutton ID="btn_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" ValidationGroup="vg_lupa" Visible="False" />&nbsp;
                                            <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    <asp:CustomValidator ID="cv_pessoa" runat="server" ControlToValidate="txt_cd_pessoa"
                                        CssClass="texto" ErrorMessage="Emitente não cadastrado!" Font-Bold="False"
                                        Text="[!]" ToolTip="Emitente não Cadastrado!" ValidationGroup="vg_pesquisar"></asp:CustomValidator></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    Tipo de Leite:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                                <td style="height: 21px" align="right">
                                    &nbsp;Situação:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                                                        <tr>
                                <td align="right" style="height: 21px">
                                    </td>
                                <td style="height: 21px">
                                    &nbsp;
                                    </td>
                                <td style="height: 21px">
                                </td>
                                <td style="height: 21px">
                                </td>
                            </tr>

							<tr>
								<TD>&nbsp;</TD>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo_produtor" runat="server">Novo PO Produtores</anthem:linkbutton>
                        &nbsp;|&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_novo_cooperativa" runat="server">Novo PO Cooperativa</anthem:LinkButton>
                        &nbsp;&nbsp; |
                        <asp:Image ID="Image2" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                            ID="lk_nova_agropecuaria" runat="server">Novo PO Agropecuária</anthem:LinkButton>
                        &nbsp;
                    </TD>
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
									
                        <anthem:GridView ID="gridResultscoop" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True"
                                    SortExpression="ds_estabelecimento" />
                                <asp:BoundField DataField="ds_cooperativa" HeaderText="Cooperativa" ReadOnly="True"
                                    SortExpression="ds_cooperativa" />
                                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" SortExpression="nm_item" />
                                <asp:BoundField DataField="dt_inicio" HeaderText="Data Inicial" ReadOnly="True" SortExpression="dt_inicio" />
                                <asp:BoundField DataField="dt_fim" HeaderText="Data Final" ReadOnly="True"
                                    SortExpression="dt_fim" />
                                <asp:BoundField DataField="nr_po" HeaderText="Nr. PO" ReadOnly="True" SortExpression="nr_po" />
                                <asp:BoundField DataField="id_situacao" HeaderText="Situa&#231;&#227;o"
                                    SortExpression="id_situacao" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w3" CommandArgument='<%# Bind("id_po_cooperativa") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w4" CommandArgument='<%# Bind("id_po_cooperativa") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                         <anthem:GridView ID="gridResultsProd" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                 <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True"
                                    SortExpression="ds_estabelecimento" />
                                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" SortExpression="nm_item" />
                               <asp:BoundField DataField="nm_estado" HeaderText="Estado" ReadOnly="True" SortExpression="ds_estado" />
                                <asp:BoundField DataField="dt_referencia" HeaderText="Data Refer&#234;ncia" ReadOnly="True"
                                    SortExpression="dt_referencia" />
                                <asp:BoundField DataField="nr_po" HeaderText="Nr. PO" ReadOnly="True" SortExpression="nr_po" />
                                <asp:BoundField DataField="id_situacao" HeaderText="Situa&#231;&#227;o" ReadOnly="True"
                                    SortExpression="id_situacao" />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w25" CommandArgument='<%# Bind("id_po_produtor") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w26" CommandArgument='<%# Bind("id_po_produtor") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView><anthem:GridView ID="gridResultsAgro" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_estabelecimento" HeaderText="Estabelecimento" ReadOnly="True"
                                                    SortExpression="ds_estabelecimento" />
                                                <asp:BoundField DataField="ds_agropecuaria" HeaderText="Agropecu&#225;ria" ReadOnly="True"
                                    SortExpression="ds_agropecuaria" />
                                                <asp:BoundField DataField="nm_item" HeaderText="Item" ReadOnly="True" SortExpression="nm_item" />
                                                <asp:BoundField DataField="dt_inicio" HeaderText="Data Inicial" ReadOnly="True" SortExpression="dt_inicio" />
                                                <asp:BoundField DataField="dt_fim" HeaderText="Data Final" ReadOnly="True"
                                    SortExpression="dt_fim" />
                                                <asp:BoundField DataField="nr_po" HeaderText="Nr. PO" ReadOnly="True" SortExpression="nr_po" />
                                                <asp:BoundField DataField="id_situacao" HeaderText="Situa&#231;&#227;o"
                                    SortExpression="id_situacao" />
                                                <asp:TemplateField>
                                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w1" CommandArgument='<%# Bind("id_po_agropecuaria") %>' CommandName="edit"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" __designer:wfdid="w4" CommandArgument='<%# Bind("id_po_agropecuaria") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" />
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
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
