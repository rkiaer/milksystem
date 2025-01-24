<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_grupo_relacionamento.aspx.vb" Inherits="lst_poupanca_grupo_relacionamento" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc2" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc4" %>
<%@ Register Assembly="RK.TextBox.AjaxTelephone" Namespace="RK.TextBox.AjaxTelephone"
    TagPrefix="cc5" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc6" %>
<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc7" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
   <title>Poupança e Grupos de Relacionamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
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
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px; height: 29px;">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); height: 29px;"><STRONG>Poupança e Grupos de Relacionamento</STRONG></TD>
					<TD style="width: 12px; height: 29px;">&nbsp;</TD>
				</TR>
                <tr>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 20px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 20px">
                                    &nbsp;
                                    &nbsp;&nbsp;
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px">&nbsp;</TD>
                </tr>
                <tr>
                    <td style="width: 9px; height: 143px;">
                        &nbsp;</td>
                    <td id="td_pesquisa" runat="server" align="center" class="texto" style="height: 143px" valign="middle">
                        <table id="Table5" border="0" cellpadding="0" cellspacing="0" class="borda texto"
                            onclick="return Table2_onclick()" width="98%">
                            <tr>
                                <td align="right" style="width: 15%; height: 22px;" width="15%" class="texto12">
                                    &nbsp;<span id="Span2" class="obrigatorio">*</span>Estabelecimento:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Font-Bold="True"
                                        Operator="NotEqual" Type="Integer" ValidationGroup="vg_pesquisar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                                <td align="right" style="width: 16%; height: 22px;">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Referência Poupança:</td>
                                <td style="width: 25%; height: 22px;" align="left">
                                    &nbsp;<anthem:DropDownList ID="cbo_referencia_poupanca" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_referencia_poupanca"
                                        ErrorMessage="Informe o Mes/Ano de Referência Poupança." Font-Bold="True" ValidationGroup="vg_pesquisar" InitialValue="0">[!]</asp:RequiredFieldValidator>
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    Código Propriedade Titular:</td>
                                <td align="left">
                                    &nbsp;&nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_propriedade_titular" runat="server"
                                        CssClass="texto" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                                <td align="right" style="width: 16%">
                                    Código Propriedade:</td>
                                <td align="left" style="width: 25%;">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" Width="72px" CssClass="texto"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    Código Produtor:</td>
                                <td align="left">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                </td>
                                <td align="right">
                                    Participação na Poupança:</td>
                                <td align="left">
                                    &nbsp;<anthem:DropDownList ID="cbo_st_participa_poupanca" runat="server"
                                        CssClass="texto">
                                        <asp:ListItem Value="">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="G">Em Grupo</asp:ListItem>
                                        <asp:ListItem Value="I">Individual</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%; height: 32px;">
                                </td>
                                <td align="left" style="height: 32px">
                                </td>
                                <td align="right" colspan="2" style="height: 32px" valign="bottom">
                                    &nbsp;&nbsp;
                                    <anthem:ImageButton ID="btn_pesquisar" runat="server" ImageUrl="img/bnt_pesquisa.gif"
                                        ValidationGroup="vg_pesquisar" />&nbsp;
                                    <anthem:ImageButton ID="btn_limpar" runat="server" ImageUrl="img/btn_limparfiltro.gif" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td style="height: 143px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 9px; height: 24px">
                        &nbsp;</td>
                    <td background="img/faixa_filro.gif" class="faixafiltro1a" style="height: 24px" valign="middle">
                        &nbsp;&nbsp;</td>
                    <td style="height: 24px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%">
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados de Poupança</TD>
							</TR>
                            <tr>
                                <TD class="texto" align="center"  colspan="2" style="height: 16px">
                                    &nbsp;<table width="100%">
                                        <tr runat="server" id="tr_header2" visible="true">
                                            <td style="width: 14%; height: 18px;" align="right">
                                                <strong>Período de Poupança:</strong></td>
                                            <td align="left" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_referencia_poupanca" runat="server"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 14%; height: 18px;" align="right">
                                                <strong>Situação do Período Poupança:</strong></td>
                                            <td align="left" style="height: 18px">
                                                <anthem:Label ID="lbl_situacao_poupanca" runat="server" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 10%; height: 18px;" align="right">
                                                <strong></strong></td>
                                            <td style="width: 15%; height: 18px;" align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 14%; height: 18px;" align="right">
                                                <strong>Estabelecimento:</strong></td>
                                            <td align="left" style="height: 18px">
                                                &nbsp;<anthem:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 14%; height: 18px;" align="right">
                                                <strong></strong></td>
                                            <td align="left" style="height: 18px">
                                                </td>
                                            <td style="width: 10%; height: 18px;" align="right">
                                            </td>
                                            <td style="width: 15%; height: 18px;" align="left"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
	                        </TABLE>
	                        <table runat=server id="table_body" visible="true" width="100%">
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">
                                    Parametro de Poupança para Grupo de Relacionamento
                                </td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2"><anthem:GridView ID="gridGrupoTitular" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="13" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="98%" AddCallBacks="False" Visible="False" AllowPaging="True">
                                    <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditRowStyle Width="100%" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Det.">
                                            <itemtemplate>
<anthem:ImageButton id="btn_detalhe_item" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Grupo de Relacionamento" ImageUrl="~/img/icon_preview.gif" UpdateAfterCallBack="True" CommandName="gruporelacionamento" __designer:wfdid="w27"></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ds_produtor_titular" HeaderText="Produtor Titular" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Prop Titular">
                                            <edititemtemplate>
<asp:Label id="lbl_id_propriedade_titular" runat="server" __designer:wfdid="w14" Text='<%# Bind("id_propriedade_titular") %>'></asp:Label>
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade_titular" runat="server" __designer:wfdid="w13" Text='<%# Bind("id_propriedade_titular") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nr_tempo_adesao" HeaderText="Tempo Ades&#227;o" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Participa&#231;&#227;o">
                                            <edititemtemplate>
<anthem:DropDownList id="cbo_st_participa_poupanca" runat="server" AutoUpdateAfterCallBack="True" AutoCallBack="True" __designer:wfdid="w16" SelectedValue='<%# bind("st_participa_poupanca") %>' OnSelectedIndexChanged="cbo_st_participa_poupanca_SelectedIndexChanged"><asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
<asp:ListItem Value="G">Em Grupo</asp:ListItem>
<asp:ListItem Value="I">Individual</asp:ListItem>
</anthem:DropDownList> <anthem:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvartitular" ErrorMessage="O tipo de participação da poupança para o grupo de relacionamento deve ser informado!" ControlToValidate="cbo_st_participa_poupanca" ToolTip="O tipo do grupo na participação na poupança deve ser informada." __designer:wfdid="w17">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="lbl_st_participa_poupanca" runat="server" CssClass="texto" __designer:wfdid="w15" Text='<%# Bind("nm_participa_poupanca") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Resp B&#244;nus Poupan&#231;a">
                                            <edititemtemplate>
<anthem:DropDownList id="cbo_id_propriedade_responsavel_bonus" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" __designer:wfdid="w19"></anthem:DropDownList>&nbsp;<anthem:RequiredFieldValidator id="rf_propriedadebonus" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvartitular" ErrorMessage="A propriedade responsável por receber o bônus de poupança deve ser informada!" ControlToValidate="cbo_id_propriedade_responsavel_bonus" ToolTip="A propriedade responsável por receber o bônus de poupança deve ser informada!" __designer:wfdid="w20">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                            <footertemplate>
&nbsp; 
</footertemplate>
                                            <itemtemplate>
<asp:Label id="lbl_id_propriedade_responsavel_bonus" runat="server" CssClass="texto" __designer:wfdid="w18" Text='<%# Bind("id_propriedade_responsavel_bonus") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Produtor Resp.">
                                            <edititemtemplate>
&nbsp;<anthem:Label id="lbl_produtor_responsavel" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w22" Text='<%# bind("ds_produtor_responsavel") %>'></anthem:Label> 
</edititemtemplate>
                                            <itemtemplate>
&nbsp;<anthem:Label id="lbl_produtor_responsavel" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w21" Text='<%# bind("ds_produtor_responsavel") %>'></anthem:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField Visible="False" HeaderText="id_grupo_relacionamento">
                                                <edititemtemplate>
<anthem:Label id="id_grupo_relacionamento" runat="server" Visible="False" __designer:wfdid="w31" Text='<%# bind("id_grupo_relacionamento") %>'></anthem:Label>&nbsp; 
</edititemtemplate>
                                                <itemtemplate>
<anthem:Label id="id_grupo_relacionamento" runat="server" Visible="False" __designer:wfdid="w30" Text='<%# bind("id_grupo_relacionamento") %>'></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="st_participa_poupanca" Visible="False">
                                            <edititemtemplate>
<asp:Label id="st_participa_poupanca" runat="server" __designer:wfdid="w26" Text='<%# Bind("st_participa_poupanca") %>'></asp:Label>
</edititemtemplate>
                                            <itemtemplate>
<asp:Label id="st_participa_poupanca" runat="server" __designer:wfdid="w25" Text='<%# Bind("st_participa_poupanca") %>'></asp:Label> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" CssClass="texto" ValidationGroup="vg_salvartitular" ToolTip="Salvar Parâmetro de Poupança para Grupo de Relacionamento" ImageUrl="~/img/icone_gravar.gif" CommandName="Update" __designer:wfdid="w6"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ToolTip="Voltar Alteração" ImageUrl="~/img/icon_undo.gif" ImageAlign="Baseline" CommandName="Cancel" __designer:wfdid="w7"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_salvartitular" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w8"></asp:ValidationSummary> 
</edititemtemplate>
                                            <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" ToolTip="Editar Parametros de poupança para Grupo de Relacionamento." ImageUrl="~/img/icone_editar_grid.gif" UpdateAfterCallBack="True" CommandName="Edit" __designer:wfdid="w5" CommandArgument='<%# bind("id_propriedade_titular") %>'></anthem:ImageButton> 
</itemtemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                    <PagerStyle BorderColor="White" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                                        Font-Strikeout="False" Font-Underline="True" ForeColor="Navy" />
                                    </anthem:GridView>
                                    &nbsp; &nbsp; &nbsp;
                                    &nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                    <anthem:CustomValidator ID="cv_pedido" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator>
                                    </td>
	                        </tr>
	                        <TR>
	                            <TD class="titmodulo" align="left" colSpan="2">
                                    Grupo de Relacionamento da Propriedade Titular
                                    <anthem:Label ID="lbl_detalhe_titular" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" style="vertical-align: bottom; text-align: left"></anthem:Label></TD>
							</TR>
							<TR runat="server" id="tr_entregas">
								<TD style="HEIGHT: 7px; color: blue;" class="texto" align=left width="23%">
                                    </TD>
								<TD style="height: 7px">&nbsp;</TD>
							</TR>
							<TR runat="server" id="tr_entregas_grid">
								<TD style="HEIGHT: 15px" align="center" colspan="2" class="texto"><anthem:GridView ID="gridGrupo" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="20" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="98%" AddCallBacks="False" Visible="False">
                                    <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditRowStyle Width="100%" />
                                    <Columns>
                                        <asp:BoundField DataField="cd_pessoa" HeaderText="Cod. Produtor" />
                                        <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                        <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                        <asp:BoundField DataField="ds_relacionamento" HeaderText="Rela&#231;&#227;o" />
                                        <asp:BoundField DataField="ds_situacao_propriedade" HeaderText="Situa&#231;&#227;o Prop." />
                                        <asp:TemplateField HeaderText="Ades&#227;o Poupan&#231;a">
                                            <itemtemplate>
<anthem:Image id="img_adesao_poupanca" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w73"></anthem:Image> 
</itemtemplate>
                                            <itemstyle horizontalalign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="id_poupanca_adesao" Visible="False">
                                            <itemtemplate>
<asp:Label id="lbl_id_poupanca_adesao" runat="server" Text='<%# Bind("id_poupanca_adesao") %>' __designer:wfdid="w74"></asp:Label>
</itemtemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </anthem:GridView>
                                    &nbsp;&nbsp;&nbsp;
                                </TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px"></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 12px" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_pesquisar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            &nbsp;&nbsp;
           <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
        </form>
	</body>
</HTML>
