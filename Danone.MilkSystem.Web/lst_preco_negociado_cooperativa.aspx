<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_preco_negociado_cooperativa.aspx.vb" Inherits="lst_preco_negociado_cooperativa" %>

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
		<title>lst_preco_negociado_cooperativa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {       
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_cooperativa.value=retorno;
        } 
    }            
</script>	

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 5px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;"><STRONG>Preço Negociado Cooperativas&nbsp;</STRONG></TD>
					<TD style="width: 5px; height: 25px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 28px; width: 5px;">&nbsp;</TD>
					<TD style="HEIGHT: 28px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 28px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" ><BR>
						<TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="20%" style="HEIGHT: 26px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 26px;">
                                    &nbsp;<asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList><anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator><anthem:CompareValidator
                                            ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="cbo_estabelecimento"
                                            Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                            Type="Integer" ValidationGroup="vg_incluir" ValueToCompare="0">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 26px; " align="right">
                                     <strong><span style="color: #ff0000">*</span></strong>Referência:</TD>
								<TD style="height: 26px">
                                    &nbsp;<cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="75px"></cc3:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_MesAno"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="False" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno" ErrorMessage="Informe o Ano de Referência."
                                            Font-Bold="False" ValidationGroup="vg_incluir">[!]</asp:RequiredFieldValidator></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 26px">
                                    Cooperativa:</td>
                                <td colspan="3" style="height: 26px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:CustomValidator
                                                ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa" CssClass="texto"
                                                ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!"
                                                ValidationGroup="vg_pesquisar"></asp:CustomValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_cd_cooperativa"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Código da Cooperativa para continuar ou selecione-o pela lupa."
                                                    Font-Bold="False" ValidationGroup="vg_incluir">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px" >
                                    Situação Aprovação:</td>
                                <td style="height: 26px; ">
                                    &nbsp;<asp:DropDownList ID="cbo_status" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td style="height: 26px" class="texto" align="right">
                                    Período:</td>
                                <td align="left" class="texto" style="height: 26px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_periodo" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">1a.Quinz</asp:ListItem>
                                        <asp:ListItem Value="2">2a.Quinz</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 26px">
                                </td>
                                <td style="height: 26px">
                                </td>
                                <td align="right" style="height: 26px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp; 
                                </td>
                            </tr>
							<TR>
                                <td align="right" colspan="2" style="border-top: 1px ridge; height: 28px">
                                    Volume:
                                    <cc2:OnlyNumbersTextBox ID="txt_volume_incluir" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="6" Style="text-align: right" Width="72px"></cc2:OnlyNumbersTextBox>&nbsp;
                                    Preço:
                                    <cc4:OnlyDecimalTextBox ID="txt_preco_incluir" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" MaxLength="9" MaxMantissa="4" Style="text-align: right" Width="80px"></cc4:OnlyDecimalTextBox></td>
								<TD style="border-top: 1px ridge; height: 28px" align="center" valign="bottom">&nbsp;<anthem:imagebutton id="btn_incluir" runat="server" imageurl="img/bnt_incluir.gif" ValidationGroup="vg_incluir" AutoUpdateAfterCallBack="True"></anthem:imagebutton><asp:CustomValidator ID="cv_incluir" runat="server" CssClass="texto"
                                    ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False" Text="[!]" ToolTip="Cooperativa não Cadastrada!"
                                    ValidationGroup="vg_incluir"></asp:CustomValidator></TD>
								<TD align="right" style="height: 28px; border-top: 1px ridge;">
                                    &nbsp; &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 26px; width: 5px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 26px; " vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ico_email.gif" /><anthem:LinkButton
                            ID="lk_email" runat="server" CssClass="texto" OnClientClick="if (confirm('Uma notificação de que existem preços a serem aprovados será enviada aos aprovadores. Deseja realmente prosseguir?' )) return true;else return false;"
                            ValidationGroup="vg_pesquisar" AutoUpdateAfterCallBack="True" ToolTip="Notificar aprovadores 2o Nível">Notificar Aprovadores</anthem:LinkButton>&nbsp; &nbsp; |&nbsp; &nbsp; &nbsp; Total Coop. 1a.Quinz:
                        <anthem:Label ID="lbl_total_1a" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                        &nbsp;&nbsp; Total Coop. 1a.Quinz Aprovadas:
                        <anthem:Label ID="lbl_total_1a_aprovada" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label>
                        &nbsp; &nbsp; Total Coop. 2a.Quinz:
                        <anthem:Label ID="lbl_total_2a" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                        &nbsp;&nbsp; Total Coop. 2a.Quinz Aprovadas:
                        <anthem:Label ID="lbl_total_2a_aprovada" runat="server" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True"></anthem:Label></TD>
					<TD style="HEIGHT: 26px; width: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px; height: 2px;"></TD>
					<TD vAlign="middle" style="height: 2px">&nbsp;</TD>
					<TD style="width: 5px; height: 2px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD >
									
                                       <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_preco_negociado_cooperativa" AddCallBacks="False" AutoUpdateAfterCallBack="True" PageSize="30">
                                            <Columns>
                                                <asp:BoundField DataField="dt_referencia" HeaderText="Refer&#234;ncia" ReadOnly="True" DataFormatString="{0:MM/yyyy}">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ds_produtor" HeaderText="Cooperativa" SortExpression="ds_produtor" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_periodo" HeaderText="Per&#237;odo" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_volume_anterior" HeaderText="Volume M-1" ReadOnly="True" DataFormatString="{0:n0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_preco_anterior" HeaderText="Pre&#231;o M-1" ReadOnly="True" DataFormatString="{0:n4}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Volume">
                                                    <edititemtemplate>
<cc2:OnlyNumbersTextBox style="TEXT-ALIGN: right" id="txt_volume" __designer:dtid="562988608127027" runat="server" CssClass="texto" Width="72px" MaxLength="6" UpdateAfterCallBack="True" Text='<%# bind("nr_volume") %>' __designer:wfdid="w106"></cc2:OnlyNumbersTextBox><anthem:RequiredFieldValidator id="rfvolume" runat="server" CssClass="texto" ValidationGroup="vg_salvar" ErrorMessage="Volume Cooperativa deve ser informado." ControlToValidate="txt_volume" ToolTip="Volume Cooperativa deve ser informado." __designer:wfdid="w121">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator id="cpvvolume" runat="server" CssClass="texto" ValidationGroup="vg_salvar" ValueToCompare="0" Type="Integer" Operator="GreaterThan" ErrorMessage="Volume Cooperativa deve ser maior que zero." ControlToValidate="txt_volume" ToolTip="Volume Cooperativa deve ser maior que zero." __designer:wfdid="w122">[!]</anthem:CompareValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_volume" runat="server" Text='<%# Bind("nr_volume", "{0:n0}") %>' __designer:wfdid="w135"></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pre&#231;o">
                                                    <edititemtemplate>
<cc4:OnlyDecimalTextBox id="txt_nr_preco_negociado" runat="server" CssClass="texto" Width="80px" MaxLength="9" Text='<%# bind("nr_preco_negociado") %>' MaxMantissa="4" MaxCaracteristica="4" __designer:wfdid="w110" DecimalSymbol=","></cc4:OnlyDecimalTextBox><anthem:RequiredFieldValidator id="rfpreconegociado" runat="server" CssClass="texto" ValidationGroup="vg_salvar" ErrorMessage="Preço Cooperativa deve ser informado." ControlToValidate="txt_nr_preco_negociado" ToolTip="Preço Cooperativa deve ser informado." __designer:wfdid="w111">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator id="cpvpreco" runat="server" CssClass="texto" ValidationGroup="vg_salvar" ValueToCompare="0" Type="Double" Operator="GreaterThan" ErrorMessage="Preço Cooperativa deve ser maior que zero." ControlToValidate="txt_nr_preco_negociado" ToolTip="Preço Cooperativa deve ser maior que zero." __designer:wfdid="w112">[!]</anthem:CompareValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_nr_preco" runat="server" Text='<%# bind("nr_preco_negociado", "{0:n4}") %>' __designer:wfdid="w109"></anthem:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nm_aprovado" HeaderText="Situa&#231;&#227;o" ReadOnly="True" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <edititemtemplate>
<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/img/icone_salvar.gif" Text="Salvar" __designer:wfdid="w137" CausesValidation="True" CommandName="Update"></asp:ImageButton>&nbsp;<asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/img/icon_undo.gif" Text="Cancelar" __designer:wfdid="w138" CausesValidation="False" CommandName="Cancel"></asp:ImageButton>
</edititemtemplate>
                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" Text="Editar" __designer:wfdid="w136" CausesValidation="False" CommandName="Edit"></asp:ImageButton>
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" __designer:wfdid="w65" CommandName="delete" OnClientClick="if (confirm('Deseja realmente excluir o registro?' )) return true;else return false;" CommandArgument='<%# Bind("id_preco_negociado_cooperativa") %>'></anthem:ImageButton>
</itemtemplate>
                                                    <itemstyle horizontalalign="Center" width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="st_aprovado" Visible="False">
                                                    <edititemtemplate>
<asp:Label id="lbl_st_aprovado" runat="server" Text='<%# Bind("st_aprovado") %>' __designer:wfdid="w69"></asp:Label>
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_st_aprovado" runat="server" Text='<%# Bind("st_aprovado") %>' __designer:wfdid="w67"></asp:Label>
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#78A3E2" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                           <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 5px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
					</TD>
					<TD style="height: 19px; width: 5px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_incluir"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
            <anthem:ValidationSummary ID="ValidationSummary1" runat="server" AutoUpdateAfterCallBack="true"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar" />
		</form>
	</body>
</HTML>
