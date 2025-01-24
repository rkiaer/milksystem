<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_gold_preco_leite_aprovar_2N.aspx.vb" Inherits="lst_gold_preco_leite_aprovar_2N" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
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
		<title>Aprovação Preço Leite Produtor GOLD 2.o Nível</title>
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

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>
<script type="text/javascript"> 

</script>
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

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Preço Leite Produtor Gold 2.o Nível</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 1014px">
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 1014px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD width="15%" style="HEIGHT: 20px" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
			                    <td width="15%" align="right" style="height: 20px"></td>
								<td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
    	                        </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Data de Validade:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_inicial" runat="server" CssClass="caixatexto"
                                        DateMask="MonthYear" Width="72px"></cc3:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia_inicial"
                                        ErrorMessage="Informe a Data de Validade Inicial." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>&nbsp; à &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia_final" runat="server" CssClass="caixatexto"
                                        DateMask="MonthYear" Width="72px"></cc3:OnlyDateTextBox>
                                    &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txt_dt_referencia_final" ErrorMessage="Informe a Data de Validade final."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    &nbsp;
                                </td>
                            </tr>
							<tr>
			                    <td align="right" style="height: 20px"></td>
			                    <td align="right" style="height: 20px"></td>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_aprovar2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar 2.o Nível</anthem:linkbutton>
                        &nbsp;
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton
                            ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                            ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 1014px;">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD style="width: 1014px">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="7" DataKeyNames="id_gold_preco_leite">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged" __designer:wfdid="w5"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w34"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" SortExpression="ds_produtor" ReadOnly="True" />
                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Custo Efetivo">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_custo_operacional_efetivo" runat="server" ForeColor="Blue" __designer:wfdid="w48" Target="_blank" NavigateUrl="~/frm_gold_custo_produtor.aspx" Text='<%# Eval("nr_custo_operacional_efetivo") %>'></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="M. Coe">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_margem_custo_efetivo" runat="server" ForeColor="Blue" __designer:wfdid="w82" Target="_blank" NavigateUrl="~/frm_gold_custo.aspx" Text='<%# Eval("nr_margem_custo_efetivo") %>'></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_margem_volume" HeaderText="M. Vol" ReadOnly="True" />
                                <asp:BoundField DataField="nr_margem_crescimento" HeaderText="M. Cresc" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Custo Dieta">
                                    <itemtemplate>
<asp:HyperLink id="hl_nr_custo_dieta" runat="server" ForeColor="Blue" __designer:wfdid="w50" Target="_blank" NavigateUrl="~/frm_gold_custo_produtor_dieta.aspx" Text='<%# Eval("nr_custo_dieta") %>'></asp:HyperLink>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_eficiencia_dieta" HeaderText="Efic. Dieta" ReadOnly="True" />
                                <asp:BoundField DataField="nr_preco_leite" HeaderText="Pre&#231;o Leite" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Anota&#231;&#227;o Aprovador">
                                    <edititemtemplate>
<anthem:TextBox id="txt_ds_anotacao_aprovador" __designer:dtid="1970354901745708" runat="server" CssClass="texto" Width="350px" Text='<%# Bind("ds_anotacao_aprovador") %>' MaxLength="200" __designer:wfdid="w4"></anthem:TextBox> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_ds_anotacao_aprovador" runat="server" Text='<%# Bind("ds_anotacao_aprovador") %>' __designer:wfdid="w3"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" SortExpression="nm_aprovado" />
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_salvar" />
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_editar.gif" Text="Button" __designer:wfdid="w2" CausesValidation="False" CommandName="selecionar" CommandArgument='<%# bind("id_gold_preco_leite") %>' ToolTip="Consulta Informações Preço GOLD"></asp:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_gold_custo_produtor" Visible="False">
                                    <edititemtemplate>
&nbsp; <asp:Label id="lbl_id_gold_custo_produtor" runat="server" Text='<%# Bind("id_gold_custo_produtor") %>' __designer:wfdid="w22"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo_produtor" runat="server" Text='<%# Bind("id_gold_custo_produtor") %>' __designer:wfdid="w21"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_gold_custo" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="lbl_id_gold_custo" runat="server" Text='<%# Bind("id_gold_custo") %>' __designer:wfdid="w36"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_gold_custo" runat="server" Text='<%# Bind("id_gold_custo") %>' __designer:wfdid="w35"></asp:Label> 
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
					<TD vAlign="top" style="height: 19px; width: 1014px;">&nbsp;
					</TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
