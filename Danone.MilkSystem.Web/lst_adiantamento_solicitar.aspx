<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_adiantamento_solicitar.aspx.vb" Inherits="lst_adiantamento_solicitar" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

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
		<title>lst_adiantamento_solicitar</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Solicitar Adiantamento&nbsp;</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" >
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
					<TD id="td_pesquisa" runat="server" ><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <span class="obrigatorio">*</span>Mês / Ano:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td style="height: 20px"></td>
                                <td style="height: 20px"></td>                                                                       
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código Técnico:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" Visible="False" Width="190px"></anthem:Label>
                                    &nbsp;&nbsp;<anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    &nbsp;&nbsp; &nbsp;<anthem:CustomValidator ID="cv_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_tecnico" CssClass="texto" ErrorMessage="Técnico não cadastrado."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_tecnico"
                                        ErrorMessage="Informe o Técnico." Font-Bold="True" ValidationGroup="vg_pesquisar" Enabled="False" Visible="False">[!]</asp:RequiredFieldValidator></td>
                                <td style="height: 20px"></td>
                                <td style="height: 20px"></td>                                                                       
                          </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Status:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_status" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td style="height: 20px" align="right">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" AutoUpdateAfterCallBack="True"
                                        ImageUrl="~/img/bnt_exportar.gif" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
                                <td style="height: 20px"></td>                                                                        
                          </tr>
                          
                          
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image id="img_novo" runat="server" ImageUrl="~/img/ico_email.gif"></asp:Image><anthem:LinkButton ID="lk_email" runat="server" ValidationGroup="vg_pesquisar" OnClientClick="if (confirm('Uma notificação de que existem solicitações de adiantamento será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;" AutoUpdateAfterCallBack="True">Notificar Aprovadores</anthem:LinkButton>&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;
                    </TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<!-- Maracanau -->
						    <TR id="tr_panel_caderneta" runat="server" >
							    <TD style="height: 21px"  ></TD>
								<TD style="height: 21px; " id="td2" runat="server" class="texto">
                                         <table id="Table3" border="0" cellpadding="1" cellspacing="0" width="100%">
                                                 <tr>
            <td  align="right" class="texto" colspan="4" style="height: 8px">&nbsp;</td>
        </tr>
                                            <tr>
                                                <td class="texto" ><anthem:GridView ID="grdPropriedade" runat="server" AllowSorting="True"
                                                        AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="1" UpdateAfterCallBack="True"
                                                        Width="99%">
                                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                                    <EditRowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Propriedade">
                                                            <itemtemplate>
<anthem:DropDownList id="cbo_propriedade" runat="server" CssClass="texto" __designer:wfdid="w50"></anthem:DropDownList> <asp:RequiredFieldValidator id="rqf_propriedade" runat="server" CssClass="texto" ValidationGroup="vg_adicionar" Font-Bold="True" ErrorMessage="A propriedade deve ser informada" ControlToValidate="cbo_propriedade" __designer:wfdid="w51">[!]</asp:RequiredFieldValidator> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Valor Adto">
                                                            <itemtemplate>
&nbsp;<cc4:OnlyDecimalTextBox id="txt_nr_valor_adto" runat="server" Width="100px" __designer:wfdid="w52" MaxCaracteristica="14"></cc4:OnlyDecimalTextBox>&nbsp;<asp:RequiredFieldValidator id="rqf_valoraadto" runat="server" CssClass="texto" ValidationGroup="vg_adicionar" Font-Bold="True" ErrorMessage="O valor do adiantamento deve ser informado." ControlToValidate="txt_nr_valor_adto" __designer:wfdid="w53">[!]</asp:RequiredFieldValidator> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Justificativa">
                                                            <itemtemplate>
&nbsp;<anthem:DropDownList id="cbo_justificativa" runat="server" CssClass="texto" __designer:wfdid="w54"></anthem:DropDownList> <asp:RequiredFieldValidator id="rqf_justificativa" runat="server" CssClass="texto" ValidationGroup="vg_adicionar" Font-Bold="True" ErrorMessage="A justificativa deve ser informada." ControlToValidate="cbo_justificativa" __designer:wfdid="w55">[!]</asp:RequiredFieldValidator> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Portador">
                                                            <itemtemplate>
&nbsp;<anthem:DropDownList id="cbo_portador" runat="server" CssClass="texto" __designer:wfdid="w56"></anthem:DropDownList> <asp:RequiredFieldValidator id="rqf_portador" runat="server" CssClass="texto" ValidationGroup="vg_adicionar" Font-Bold="True" ErrorMessage="O portador deve ser informado." ControlToValidate="cbo_portador" __designer:wfdid="w57">[!]</asp:RequiredFieldValidator> 
</itemtemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                </anthem:GridView>
                                                </td>
                                                <td align="center" class="texto" colspan="1" valign="middle">
                                                    <anthem:Button ID="btn_adicionar_propriedade" runat="server" Text="Adicionar" CssClass="texto" ValidationGroup="vg_adicionar" AutoUpdateAfterCallBack="True" ToolTip="Adicionar Novo Adiantamento" Visible="False" /></td>
                                            </tr>
                                        </table>
 								</TD>
								<TD style="height: 21px"  ></TD>
							</TR>
				
				<!-- Maracanau -->
				
				<TR>
					<TD style="width: 9px; height: 119px;">&nbsp;</TD>
					<TD style=" height: 119px;">
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_adiantamento" AddCallBacks="False" AutoUpdateAfterCallBack="True">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" SortExpression="id_propriedade" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_mensal" HeaderText="Volume Mensal" SortExpression="nr_volume_mensal" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_mensal" HeaderText="Valor Mensal Estim." ReadOnly="True" />
                                                <asp:BoundField DataField="nr_valor_descontos_sem_adto" HeaderText="Descontos" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Valor Adto">
                                                    <edititemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_valor_adto" runat="server" Width="94px" CssClass="texto" MaxLength="15" Text='<%# bind("nr_valor_adto") %>' __designer:wfdid="w5" DecimalSymbol="," MaxMantissa="2" MaxCaracteristica="12"></cc4:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_valor_adto" runat="server" ValidationGroup="vg_salvar" Font-Bold="True" ErrorMessage="O valor do adiantamento deve ser preenchido!" ControlToValidate="txt_nr_valor_adto" __designer:wfdid="w6">!</asp:RequiredFieldValidator>&nbsp; <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w7"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_adto" runat="server" Text='<%# bind("nr_valor_adto") %>' __designer:wfdid="w16"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_valor_descontos" HeaderText="Total Desc + Adtos" ReadOnly="True" />
                                                <asp:BoundField HeaderText="% Compro-metido" ReadOnly="True" />
                                                <asp:BoundField HeaderText="Vl. Ped Abertos" DataField="nr_valor_pedidos_abertos" ReadOnly="True" />
                                                <asp:BoundField HeaderText="Total Desc + Adtos + Ped Abertos" ReadOnly="True" />
                                                <asp:BoundField HeaderText="% Compro-metido" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Justificativa">
                                                    <edititemtemplate>
&nbsp; <asp:DropDownList id="cbo_justificativa" runat="server" CssClass="texto" __designer:wfdid="w51"></asp:DropDownList>&nbsp;&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_justificativa" runat="server" __designer:wfdid="w50" Text='<%# Bind("nm_adiantamento_justificativa") %>'></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Portador">
                                                    <edititemtemplate>
<anthem:DropDownList id="cbo_portador" runat="server" CssClass="texto" __designer:wfdid="w55"></anthem:DropDownList> <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ValidationGroup="vg_salvar" Font-Bold="True" ErrorMessage="O portador  deve ser preenchido." ControlToValidate="cbo_portador" __designer:wfdid="w56">!</asp:RequiredFieldValidator> <asp:ValidationSummary id="ValidationSummary3" runat="server" ValidationGroup="vg_salvar" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w57"></asp:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_portador" runat="server" __designer:wfdid="w54" Text='<%# bind("nm_portador") %>'></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nr_valor_disponivel" HeaderText="Saldo x Pol&#237;t. Adto"
                                                    ReadOnly="True" />
                                                <asp:BoundField DataField="nm_aprovado" HeaderText="Status" ReadOnly="True" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_salvar.gif" Text="Salvar" __designer:wfdid="w19" CausesValidation="True" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" Text="Cancelar" __designer:wfdid="w20" CausesValidation="False" CommandName="Cancel"></asp:ImageButton> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" Text="Editar" __designer:wfdid="w17" CausesValidation="False" CommandName="Edit"></asp:ImageButton>&nbsp;<anthem:ImageButton id="btn_delete" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" ImageAlign="Baseline" OnClientClick="if (confirm('Deseja realmente excluir este registro de Solicitação de Adiantamento?' )) return true;else return false;" __designer:wfdid="w18" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Bind("id_adiantamento") %>'></anthem:ImageButton> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="% Adto(Editavel)" Visible="False">
                                                    <edititemtemplate>
&nbsp;&nbsp; <cc4:OnlyDecimalTextBox id="txt_nr_percentual_adto" runat="server" Width="56px" CssClass="texto" MaxLength="15" Visible="False" Text='<%# bind("nr_percentual_adto") %>' __designer:wfdid="w3" DecimalSymbol="," MaxMantissa="4" MaxCaracteristica="10"></cc4:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_txt_percentual_adto" runat="server" ValidationGroup="vg_salvar" Font-Bold="True" ErrorMessage="O percentual de adiantamento deve ser preenchido!" ControlToValidate="txt_nr_percentual_adto" ToolTip="Percentual de Adiantamento" __designer:wfdid="w4">!</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ValidationSummary id="ValidationSummary1" runat="server" ValidationGroup="vg_salvar" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w5"></asp:ValidationSummary>&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nr_percentual_adto" runat="server" Visible="False" Text='<%# Bind("nr_percentual_adto") %>' __designer:wfdid="w2"></asp:Label>&nbsp; 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_aprovado" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_aprovado" runat="server" Text='<%# Bind("st_aprovado") %>' __designer:wfdid="w46"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_aprovado" runat="server" Text='<%# Bind("st_aprovado") %>' __designer:wfdid="w44"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#78A3E2" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="height: 119px">&nbsp;</TD>
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
             <anthem:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_adicionar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
           <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
