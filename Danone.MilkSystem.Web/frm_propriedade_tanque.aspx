<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_propriedade_tanque.aspx.vb" Inherits="frm_propriedade_tanque" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Compartilhar Tanque</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	<script type="text/javascript" > 

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
           	     
        szUrl = 'lupa_propriedade.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:580px;edge:raised;dialogHeight:420px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
  
    function ShowDialogPropParc() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_prop_parc= document.getElementById("hf_id_prop_parc");
           	     
        szUrl = 'lupa_propriedade.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:580px;edge:raised;dialogHeight:420px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_prop_parc.value=retorno;
        } 
    }            
function Table2_onclick() {

}

    </script>
		<form id="Form1" method="post" runat="server">
            &nbsp;&nbsp;<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 696px;">
                        <strong>Compartilhar Tanque</strong></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>
                                    |
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
                <tr>
                    <td align="left" colspan="2" style="height: 13px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="titmodulo" colspan="2" style="height: 25px">
                        Dados Proprietário Tanque</td>
                </tr>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="TEXTO" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD style="width: 25%; height: 5px;" align="right">
                                </td>
                                <TD style="height: 5px" colspan="3">
                                </td>
                            </tr>
                            <tr>
								<TD style="width: 25%; height: 24px;" align="right">
                                    <strong><span style="color: #ff0000">*</span>Proprietário Tanque:</strong></TD>
								<TD style="height: 24px" colspan="3">&nbsp;
                                    <anthem:TextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True" ValidationGroup="vg_adicionar" Width="72px" AutoCallBack="True"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="True" style="vertical-align: bottom" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    <anthem:CustomValidator ID="cmv_propriedade" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade" ValidationGroup="vg_adicionar" CssClass="texto">[!]</anthem:CustomValidator>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_id_propriedade" CssClass="texto" ErrorMessage="Preencha o campo Propriedade Proprietária para continuar"
                                        ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator>
                                    <anthem:Label ID="lbl_ds_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 25px; text-align: right;">
                                    <strong><span style="color: #ff0000">*</span>UP:</strong></td>
                                <td align="right" style="text-align: left; height: 25px;">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_unid_producao" runat="server" AutoPostBack="false" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" AutoCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_unid_producao" CssClass="texto" ErrorMessage='Preencha o campo "Unidade de Produção" para continuar' ValidationGroup="vg_adicionar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 25px; text-align: left">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td align="left" colspan="2" style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="titmodulo" colspan="2">
                        Dados Proprietário Tanque</td>
                </tr>
				
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD rowspan="" align="left" valign="top" >
                        &nbsp;<anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False"
                                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="80%" UpdateAfterCallBack="True" PageSize="100">
                                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Propriedade">
                                                    <edititemtemplate>
<anthem:TextBox id="txt_id_prop_parc" runat="server" AutoCallBack="True" Width="70px" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" Text='<%# bind("id_propriedade_parceira") %>' OnTextChanged="txt_id_prop_parc_TextChanged" MaxLength="10" __designer:wfdid="w16"></anthem:TextBox>&nbsp;<anthem:ImageButton id="btn_lupa_parc" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="True" CssClass="texto" CommandName="Lupa" __designer:wfdid="w17"></anthem:ImageButton><anthem:CustomValidator id="cmv_propriedade_parceiro" __designer:dtid="1688862745165832" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="txt_id_prop_parc" Display="Dynamic" OnServerValidate="cmv_propriedade_parceiro_ServerValidate" __designer:wfdid="w18">[!]</anthem:CustomValidator> <anthem:RequiredFieldValidator id="RequiredFieldValidator7" __designer:dtid="562954248388628" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="txt_id_prop_parc" ErrorMessage="Preencha o campo Propriedade Parceira para continuar" __designer:wfdid="w19">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_prop_parc" runat="server" Text='<%# bind("id_propriedade_parceira") %>' __designer:wfdid="w15"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nome">
                                                    <edititemtemplate>
<asp:Label id="lbl_nm_prop_parc" runat="server" CssClass="texto" Text='<%# bind("nm_prop_parc") %>' __designer:wfdid="w8"></asp:Label> 
</edititemtemplate>
                                                    <itemtemplate>
<asp:Label id="lbl_nm_prop_parc" runat="server" CssClass="texto" Text='<%# bind("nm_prop_parc") %>' __designer:wfdid="w7"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UP">
                                                    <edititemtemplate>
<anthem:DropDownList id="cbo_up_parceiro" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w10"></anthem:DropDownList> <anthem:RequiredFieldValidator id="RequiredFieldValidator3" __designer:dtid="562954248388628" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="cbo_up_parceiro" ErrorMessage="Preencha o campo UP para continuar" __designer:wfdid="w11">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_up_parceiro" runat="server" Text='<%# bind("nr_unid_prod_parc") %>' __designer:wfdid="w9"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                                    <edititemtemplate>
<anthem:DropDownList id="cbo_situacao" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" __designer:wfdid="w13"></anthem:DropDownList> <anthem:RequiredFieldValidator id="RequiredFieldValidator4" __designer:dtid="562954248388628" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="cbo_situacao" ErrorMessage="Preencha o campo Situação para continuar" __designer:wfdid="w14">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:Label id="lbl_situacao" runat="server" Text='<%# bind("nm_situacao") %>' __designer:wfdid="w12"></anthem:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <edititemtemplate>
<anthem:ImageButton id="btn_gravar" onclick="btn_gravar_Click" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" __designer:wfdid="w17" CommandName="Update"></anthem:ImageButton>&nbsp;<anthem:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w18" CommandName="Cancel"></anthem:ImageButton> <anthem:ValidationSummary id="validatorSummary" __designer:dtid="3377708310462496" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="true" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w19"></anthem:ValidationSummary> 
</edititemtemplate>
                                                    <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar.gif" AutoUpdateAfterCallBack="True" __designer:wfdid="w15" CommandName="Edit" Visible="False"></anthem:ImageButton><anthem:ImageButton id="btn_desativar" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w16" CommandName="Delete" CommandArgument='<%# bind("id_propriedade_tanque") %>'></anthem:ImageButton> 
</itemtemplate>
                                                    <headerstyle width="8%" horizontalalign="Center" />
                                                    <itemstyle width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="id_propriedade_tanque" HeaderText="id_propriedade_tanque" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_tanque" runat="server" Text='<%# Bind("id_propriedade_tanque") %>' __designer:wfdid="w19"></asp:Label> 
</itemtemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="top" style="height: 19px;">
                        <br />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                    <anthem:Button ID="btn_adicionar" runat="server" AutoUpdateAfterCallBack="True" Text="Adicionar" ValidationGroup="vg_adicionar" /></td>
                    <TD style="height: 19px">
                    </td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        <table id="Table11" border="0" cellpadding="0" cellspacing="0" height="23" width="100%">
                            <tr>
                                <td align="left" background="img/faixa_filro.gif" class="faixafiltro1a" style="width: 265px"
                                    valign="middle" >
                                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:Image ID="Image1" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo_footer" runat="server">Novo</anthem:LinkButton></td>
                                <td align="right" background="img/faixa_filro.gif" class="faixafiltro1a" colspan="4"
                                    valign="middle">
                                    &nbsp;</td>
                            </tr>
                        </table>
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" AutoUpdateAfterCallBack="true"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_adicionar" />
            <asp:HiddenField ID="hf_id_propriedade" runat="server" /><asp:HiddenField ID="hf_id_prop_parc" runat="server" />
		</form>
	</body>
</HTML>
