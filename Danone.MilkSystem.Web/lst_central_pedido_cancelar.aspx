<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_pedido_cancelar.aspx.vb" Inherits="lst_central_pedido_cancelar" %>

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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); width: 98%;"><STRONG>Cancelar Pedido</STRONG></TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 2px;"></TD>
					<TD align="center" style="height: 2px; ">
						</TD>
					<TD style="width: 1%; height: 2px;"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif" align="right" class="faixafiltro1a">
                        </TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 99px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 99px; ">
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
                                    <anthem:imagebutton ID="btn_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:CustomValidator ID="cv_produtor" runat="server" ControlToValidate="txt_cd_pessoa"
                                        CssClass="texto" ErrorMessage="Cód. Produtor não existe no cadastro!" ValidationGroup="vg_pesquisar" ToolTip="Cód. Produtor não existe no cadastro!">[!]</anthem:CustomValidator></td>
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
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label>
                                    <anthem:CustomValidator ID="cv_fornecedor" runat="server" ControlToValidate="txt_cd_fornecedor"
                                        CssClass="texto" ErrorMessage="Cód. Parceiro não existe no cadastro!" ValidationGroup="vg_pesquisar" ToolTip="Cód. Parceiro não existe no cadastro!">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    Nr. Pedido:</td>
                                <td style="height: 20px;" colspan="4">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_pedido" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixatexto" MaxLength="15" Width="72px"></cc3:OnlyNumbersTextBox>
                                    <anthem:CustomValidator ID="cv_id_pedido" runat="server" ControlToValidate="txt_cd_fornecedor"
                                        CssClass="texto" ErrorMessage="O Nr. Pedido informado não está com situação 'Aberto', não podendo ser cancelado." ValidationGroup="vg_pesquisar" ToolTip="O Nr. Pedido informado não está com situação 'Aberto', não podendo ser cancelado.">[!]</anthem:CustomValidator></td>
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
							<tr>
								<TD style="height: 10px">&nbsp;</TD>
								<TD align="left" colspan="2" style="height: 10px" valign="bottom">
                                    <anthem:CheckBox ID="chk_pedidos_cancelados" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Text="Pedidos Cancelados" ToolTip="Listar os Pedidos já Cancelados" />
                                    &nbsp;&nbsp;</TD>
                                <td align="right" colspan="2" style="height: 10px" valign="bottom">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    </td>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 1%; height: 99px;" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;</TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 5px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 5px; ">&nbsp;</TD>
					<TD style="width: 1%; height: 5px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD >
                        <anthem:GridView ID="grdresults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                            DataKeyNames="id_central_pedido" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" 
                            PageSize="7" UpdateAfterCallBack="True" Width="100%">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                            <HeaderStyle BackColor="#507CD1" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left"
                                ForeColor="White"  />
                            <EditRowStyle HorizontalAlign="Left" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle HorizontalAlign="Left" BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="cd_produtor" HeaderText="Produtor" ReadOnly="True" SortExpression="cd_produtor" />
                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Nome" ReadOnly="True" SortExpression="nm_abreviado_produtor" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True" SortExpression="id_propriedade" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" ReadOnly="True" SortExpression="nr_unid_producao" />
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido" ReadOnly="True" SortExpression="id_central_pedido" />
                                <asp:BoundField DataField="id_central_pedido_origem" HeaderText="Pedido Origem" ReadOnly="True" />
                                <asp:BoundField DataField="cd_fornecedor" HeaderText="Parceiro" ReadOnly="True" SortExpression="cd_fornecedor" />
                                <asp:BoundField HeaderText="Nome" ReadOnly="True" DataField="nm_abreviado_fornecedor" SortExpression="nm_abreviado_fornecedor" />
                                <asp:BoundField HeaderText="Data" ReadOnly="True" DataField="dt_pedido" SortExpression="dt_pedido" />
                                <asp:BoundField DataField="nr_total_pedido" HeaderText="Valor Total" ReadOnly="True" />
                                <asp:BoundField DataField="nm_situacao_pedido" HeaderText="Situa&#231;&#227;o" ReadOnly="True"
                                    SortExpression="nm_situacao_pedido" />
                                <asp:TemplateField HeaderText="Motivo">
                                    <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">*<anthem:DropDownList id="cbo_pedido_cancelar_motivo" __designer:dtid="2814754062073871" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_cancelarpedido" CssClass="texto" __designer:wfdid="w20"></anthem:DropDownList></SPAN></STRONG><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_grid" CssClass="texto" ToolTip="O motivo do cancelamento do pedido deve ser informado!" ErrorMessage="O motivo do cancelamento do pedido deve ser informado!" ControlToValidate="cbo_pedido_cancelar_motivo" __designer:wfdid="w21" Font-Bold="True">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_nm_pedido_cancelar_motivo" runat="server" Text='<%# Bind("nm_pedido_cancelar_motivo") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ValidationGroup="vg_grid" ToolTip="Cancelar Pedido" ImageUrl="~/img/ico_excluir2.gif" Text="Update" __designer:wfdid="w9" CommandName="Update" OnClientClick="if (confirm('Deseja realmente cancelar o pedido?' )) return true;else return false;"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ToolTip="Voltar" ImageUrl="~/img/icon_undo.gif" Text="Cancel" __designer:wfdid="w10" CommandName="Cancel" CausesValidation="False"></asp:ImageButton> 
</edititemtemplate>
                                    <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="Informar Motivo para Cancelamento" ImageUrl="~/img/icone_editar_grid.gif" UpdateAfterCallBack="True" __designer:wfdid="w7" CommandName="Edit" CausesValidation="False" CommandArgument='<%# bind("id_central_pedido") %>'></anthem:ImageButton>&nbsp;<anthem:ImageButton id="btn_envio_email" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="Enviar Email de Cancelamento ao Parceiro" ImageUrl="~/img/ico_email.gif" UpdateAfterCallBack="True" __designer:wfdid="w8" CommandName="EnviarEmail" CommandArgument='<%# bind("id_central_pedido") %>' OnClientClick="if (confirm('Enviar email de cancelamento ao Parceiro?' )) return true;else return false;" Visible="False"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_central_pedido" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_central_pedido" runat="server" Text='<%# Bind("id_central_pedido") %>' __designer:wfdid="w100"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_central_pedido" runat="server" Text='<%# Bind("id_central_pedido") %>' __designer:wfdid="w92"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w4"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w104"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nm_estabelecimento" Visible="False">
                                    <edititemtemplate>
<asp:Label id="nm_estabelecimento" runat="server" Text='<%# Bind("nm_estabelecimento") %>' __designer:wfdid="w7"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="nm_estabelecimento" runat="server" Text='<%# Bind("nm_estabelecimento") %>' __designer:wfdid="w5"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_produtor" runat="server" Text='<%# Bind("id_pessoa") %>' __designer:wfdid="w10"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_produtor" runat="server" Text='<%# Bind("id_pessoa") %>' __designer:wfdid="w8"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w13"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w11"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_unid_producao" Visible="False">
                                    <edititemtemplate>
<asp:Label id="nr_unid_producao" runat="server" Text='<%# Bind("nr_unid_producao") %>' __designer:wfdid="w17"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="nr_unid_producao" runat="server" Text='<%# Bind("nr_unid_producao") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Left" BackColor="#EFF3FB" />
                        </anthem:GridView>
										</TD>
					<TD style="width: 1%">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px; ">&nbsp;
					</TD>
					<TD style="width: 1%;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  />
                	    <div visible="false"><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_grid"  />
                            &nbsp;<anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
