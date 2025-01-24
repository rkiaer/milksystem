<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_conta_parcelada.aspx.vb" Inherits="lst_conta_parcelada" %>

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

    function ShowDialogPropriedade() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
        var cd_pessoa=document.getElementById("txt_cd_pessoa").value;
   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        
            szUrl = 'lupa_propriedade.aspx?id_estabelecimento='+idcboestabel+'&cd_pessoa='+cd_pessoa+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_propriedade.value=retorno;
            } 
        }
    }            
</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Parcelamentos</STRONG></TD>
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
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD width="30%" style="height: 12px"></TD>
								<TD width="20%" style="height: 12px"></TD>
								<TD width="30%" style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Contas Parceladas de Romaneio:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_gridromaneio" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                        <asp:ListItem Value="S">Sim</asp:ListItem>
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>

                            <tr>
                                <TD style="HEIGHT: 20px" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="gv_estabel" Display="Dynamic">[!]</asp:CompareValidator></td>
                                <td align="right" style="height: 20px" >
                                    Código Conta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_cd_conta" runat="server" CssClass="caixaTexto" Width="72px"></asp:TextBox></td>
                           </tr>
			                <tr>
			                    <td  align="right" style="height: 20px">&nbsp;Código Produtor:</td>
								<td style="height: 20px">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;
                                    <anthem:RequiredFieldValidator ID="rf_produtor" runat="server" ControlToValidate="txt_cd_pessoa"
                                        CssClass="texto" Display="Dynamic" ErrorMessage="Preencha o campo Produtor para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
								<TD align="right" style="height: 20px">&nbsp;Nome Conta:</TD>
								<TD style="height: 20px">&nbsp;&nbsp;<asp:textbox id="txt_nm_conta" runat="server" cssclass="caixaTexto"
                                        width="272px"></asp:textbox></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 20px" >&nbsp;Código Propriedade:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;
                                    <anthem:RequiredFieldValidator ID="rf_propriedade" runat="server" ControlToValidate="txt_cd_propriedade"
                                        CssClass="texto" Display="Dynamic" ErrorMessage="Preencha o campo Propriedade para continuar."
                                        Font-Bold="True" ValidationGroup="gv_estabel" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Romaneio:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <anthem:TextBox ID="txt_romaneio" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" Width="72px"></anthem:TextBox></TD>
                           </tr>
							
                            <tr>
                                <td align="right" style="height: 20px" >
                                    DataInício:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" Width="73px"></cc3:OnlyDateTextBox></td>
 								<TD style="height: 12px" align="right">
                                     &nbsp;Situação:</TD>
								<TD style="height: 12px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
                           </tr>
							<tr>
								<TD>&nbsp;</TD>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
								<TD align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="gv_estabel"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px; ">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="img/novo.gif"></asp:Image><anthem:linkbutton
                            id="lk_novo" runat="server">Novo</anthem:linkbutton></TD>
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
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="6">
                            <Columns>
                                <asp:BoundField DataField="cd_conta" HeaderText="Conta" SortExpression="cd_conta" >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_conta" HeaderText="Descri&#231;&#227;o" SortExpression="nm_conta" />
                                <asp:BoundField DataField="dt_inicio_desconto" HeaderText="Data Inicio" SortExpression="dt_inicio_desconto" />
                                <asp:BoundField DataField="nr_valor_total" HeaderText="Valor Total" SortExpression="nr_valor_total" />
                                <asp:BoundField DataField="nr_qtd_parcela" HeaderText="Qtd Parc." SortExpression="nr_qtd_parcela" />
                                <asp:BoundField DataField="nr_taxa" HeaderText="Taxa" />
                                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parc." />
                                <asp:BoundField DataField="nr_qtd_parcela_descontada" HeaderText="Qtd Parc. Desc." />
                                <asp:BoundField DataField="dt_referencia_desconto" HeaderText="&#218;ltimo Desc." />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_conta_parcelada") %>' CommandName="edit" __designer:wfdid="w10"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandArgument='<%# Bind("id_conta_parcelada") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w11"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                            <RowStyle BackColor="#EFF3FB" /><FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridContasRomaneio" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="6" Visible="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade" />
                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" SortExpression="id_romaneio" />
                                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                <asp:BoundField DataField="nr_compartimento" HeaderText="Comp." />
                                <asp:BoundField DataField="nr_total_litros" HeaderText="Litros Comp." />
                                <asp:BoundField DataField="nr_litros_rejeitados_compartimento" HeaderText="Litros Antib." />
                                <asp:BoundField DataField="nr_total_litros_a_pagar" HeaderText="Litros a Pagar" />
                                <asp:BoundField DataField="cd_conta" HeaderText="Conta" SortExpression="cd_conta" >
                                    <headerstyle width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_inicio_desconto" HeaderText="Data Inicio" SortExpression="dt_inicio_desconto" />
                                <asp:BoundField DataField="nr_valor_total" HeaderText="Valor Total" SortExpression="nr_valor_total" />
                                <asp:BoundField DataField="nr_qtd_parcela" HeaderText="Qtd Parc." SortExpression="nr_qtd_parcela" />
                                <asp:BoundField DataField="nr_valor_parcela" HeaderText="Valor Parc." />
                                <asp:BoundField DataField="nr_qtd_parcela_descontada" HeaderText="Qtd Parc. Desc." />
                                <asp:BoundField DataField="dt_referencia_desconto" HeaderText="&#218;ltimo Desc." />
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Editar" ImageUrl="~/img/icone_editar.gif" CommandArgument='<%# Bind("id_conta_parcelada") %>' CommandName="edit" __designer:wfdid="w10"></anthem:ImageButton> <anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Desativar" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" CommandArgument='<%# Bind("id_conta_parcelada") %>' CommandName="delete" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" __designer:wfdid="w11"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
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
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="gv_estabel"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
