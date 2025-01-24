<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_adiantamento_aprovar_1N.aspx.vb" Inherits="lst_adiantamento_aprovar_1N" %>

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
		<title>lst_adiantamento_aprovar_1N</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aprovar Adiantamento&nbsp;1.o Nível</STRONG></TD>
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
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código Técnico:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    &nbsp;
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                         UpdateAfterCallBack="True" Visible="False" ></anthem:Label>
                                    &nbsp;&nbsp;<anthem:CustomValidator ID="cv_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_tecnico" CssClass="texto" ErrorMessage="Técnico não cadastrado."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator>
                                    </td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 20px" align="right">
                                    &nbsp;Status:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_status" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList></td>
                            </tr>
							<TR>
								<TD style="HEIGHT: 20px" align="right">&nbsp;Situação:</TD>
								<TD style="HEIGHT: 20px">&nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></TD>
							</TR>
							<tr>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
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
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
					    &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_aprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Aprovar </anthem:linkbutton>&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/img/icone_excluir.gif" /><anthem:LinkButton ID="lk_reprovar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_pesquisar">Reprovar</anthem:LinkButton>&nbsp;&nbsp;<asp:Image id="Image4" runat="server" ImageUrl="~/img/ico_email.gif"></asp:Image><anthem:LinkButton ID="lk_email" runat="server" ValidationGroup="vg_pesquisar" OnClientClick="if (confirm('Uma notificação de que existem adiantamentos aprovados em 1.o Nivel será enviada aos aprovadores para aprovação 2.o Nível. Deseja realmente prosseguir?' )) return true;else return false;" AutoUpdateAfterCallBack="True">Notificar Aprovadores</anthem:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<anthem:Label ID="lbl_total_adto" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False">Valor Total Adiantamento R$:</anthem:Label>
					    &nbsp<anthem:Label ID="lbl_valor_total_adto" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
					</TD>
					<TD style="HEIGHT: 24px; width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; ">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_adiantamento" AddCallBacks="False" AutoUpdateAfterCallBack="True" PageSize="20">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w20" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged"></asp:CheckBox> 
</headertemplate>
                                                    <itemtemplate>
<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True" Checked='<%# bind("st_selecao") %>'></anthem:CheckBox> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Produtor" SortExpression="ds_produtor" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_propriedade" HeaderText="Propriedade" SortExpression="ds_propriedade" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_mensal" HeaderText="Volume Mensal" SortExpression="nr_volume_mensal" ReadOnly="True" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_valor_mensal" HeaderText="Valor Mensal Estimado" />
                                                <asp:BoundField DataField="nr_valor_descontos_sem_adto" HeaderText="Descontos" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_valor_adto" HeaderText="Valor Adto" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_valor_descontos" HeaderText="Total Desc + Adto" />
                                                <asp:BoundField HeaderText="% Comprometido" ReadOnly="True" />
                                                <asp:BoundField DataField="nm_adiantamento_justificativa" HeaderText="Justificatica" ReadOnly="True" />
                                                <asp:BoundField DataField="nm_portador" HeaderText="Portador" ReadOnly="True" />
                                                <asp:BoundField DataField="nr_valor_disponivel" HeaderText="Saldo x Pol&#237;tica Adto"
                                                    ReadOnly="True" />
                                                <asp:TemplateField HeaderText="Status">
                                                    <edititemtemplate>
<anthem:DropDownList id="cbo_status" runat="server" CssClass="texto" __designer:wfdid="w12"></anthem:DropDownList>&nbsp;&nbsp; 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_status" runat="server" Text='<%# bind("nm_aprovado") %>' __designer:wfdid="w8"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ultrap.">
                                                    <itemtemplate>
<asp:CheckBox id="chk_ultrapassou" runat="server" CssClass="texto" Enabled="False" __designer:wfdid="w9" Checked='<%# bind("st_ultrapassou") %>'></asp:CheckBox>
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
