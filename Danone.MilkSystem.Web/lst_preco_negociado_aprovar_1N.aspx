<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_preco_negociado_aprovar_1N.aspx.vb" Inherits="lst_preco_negociado_aprovar_1N" %>

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
		<title>lst_conta_parcelada</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Preço Negociado 1.o Nível</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" class="texto" >
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD width="15%" style="HEIGHT: 30px; width: 25%;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 30px; width: 40%;">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
			                    <td width="15%" align="right" style="height: 30px"></td>
								<td style="height: 30px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
    	                        </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" >
                                    <span class="obrigatorio">*</span>Mês / Ano:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="Informe o Mes/Ano de Referência." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px" >
                                    </td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;Cluster:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_cluster" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td align="right" style="height: 20px">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;</td>
                            </tr>
							<tr>
			                    <td align="right" style="height: 20px"></td>
			                    <td align="right" style="height: 20px"></td>
								<TD>&nbsp;</TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_aprovar2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar 1.o Nível</anthem:linkbutton>
                        &nbsp;
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton
                            ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"
                            ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ico_email.gif"></asp:Image><anthem:LinkButton ID="lk_email" runat="server" ValidationGroup="vg_pesquisar" OnClientClick="if (confirm('Uma notificação de que existem preços aprovados em 1.o Nivel será enviada aos aprovadores para aprovação 2.o Nível. Deseja realmente prosseguir?' )) return true;else return false;" CssClass="texto" Enabled="False" AutoUpdateAfterCallBack="True">Notificar Aprovadores</anthem:LinkButton></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; " class="texto">&nbsp;<table class="texto" style="width: 100%">
                        <tr>
                            <td align="right" style="width: 20%">
                                <anthem:Label ID="lbl_precomediototal" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Total:</anthem:Label></td>
                            <td style="width: 30%">
                                <anthem:Label ID="lbl_preco_medio_cluster_total" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            <td align="right" style="width: 20%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                <anthem:Label ID="lbl_precomedioouro" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio CPM:</anthem:Label>
                            </td>
                            <td style="width: 30%">
                                <anthem:Label ID="lbl_preco_medio_cluster_ouro" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            <td align="right" style="width: 20%">
                                <anthem:Label ID="lbl_precomedioprata" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Parceiro Longo Prazo:</anthem:Label></td>
                            <td>
                                <anthem:Label ID="lbl_preco_medio_cluster_prata" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                <anthem:Label ID="lbl_precomediobronze" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Parceiro Médio Prazo:</anthem:Label></td>
                            <td style="width: 30%">
                                <anthem:Label ID="lbl_preco_medio_cluster_bronze" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                            <td align="right" style="width: 20%">
                                <anthem:Label ID="lbl_precomediocoml" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False">Preço Médio Parceiro Curto Prazo:</anthem:Label></td>
                            <td>
                                <anthem:Label ID="lbl_preco_medio_cluster_coml" runat="server" AutoUpdateAfterCallBack="True"
                                    CssClass="Texto" Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                        </tr>
                        </table>
                    </TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_preco_negociado">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w4" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<asp:CheckBox id="ck_item" runat="server" Checked='<%# bind("st_selecao") %>' __designer:wfdid="w3"></asp:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" SortExpression="ds_produtor" ReadOnly="True" />
                                <asp:BoundField HeaderText="Propriedade" DataField="id_propriedade" SortExpression="id_propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" SortExpression="nm_cluster" />
                                <asp:BoundField HeaderText="T&#233;cnico" DataField="nm_tecnico" SortExpression="nm_tecnico" ReadOnly="True" />
                                <asp:BoundField HeaderText="Volume" DataField="nr_total_volume" SortExpression="nr_total_volume" ReadOnly="True" />
                                <asp:BoundField HeaderText="Pre&#231;o M-1" DataField="nr_preco_mes_anterior" SortExpression="nr_preco_mes_anterior" ReadOnly="True" />
                                <asp:BoundField HeaderText="Adic. Volume" SortExpression="nr_adic_volume" ReadOnly="True" Visible="False" />
                                <asp:BoundField HeaderText="Adic. Regiao" SortExpression="nr_adic_regiao" ReadOnly="True" Visible="False" />
                                <asp:BoundField HeaderText="Adic. Mercado" DataField="nr_adicional_mercado" SortExpression="nr_adicional_mercado" ReadOnly="True" />
                                <asp:BoundField HeaderText="Pre&#231;o Obj" DataField="subtotal" SortExpression="subtotal" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Negociado">
                                    <edititemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_preco_negociado" runat="server" CssClass="texto" MaxLength="15" Width="94px" __designer:wfdid="w24" Text='<%# bind("nr_preco_negociado") %>' MaxCaracteristica="10" MaxMantissa="4" DecimalSymbol=","></cc4:OnlyDecimalTextBox>
</edititemtemplate>
                                    <itemtemplate>
<anthem:Label id="lbl_preco_negociado" runat="server" CssClass="texto" __designer:wfdid="w26" Text='<%# bind("nr_preco_negociado") %>'></anthem:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Varia&#231;&#227;o" DataField="variacao" SortExpression="variacao" ReadOnly="True" />
                                <asp:BoundField HeaderText="Justificativa" DataField="nm_preco_justificativa" SortExpression="nm_preco_justificativa" ReadOnly="True" />
                                <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" SortExpression="nm_aprovado" />
                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/img/icon_undo.gif" CancelText="Cancelar"
                                    EditImageUrl="~/img/icone_editar_grid.gif" EditText="Editar" ShowEditButton="True"
                                    UpdateImageUrl="~/img/icone_salvar.gif" UpdateText="Salvar" ValidationGroup="vg_salvar" />
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
					<TD vAlign="top" style="height: 19px; ">&nbsp;
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
