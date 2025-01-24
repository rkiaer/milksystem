<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_item_parceiro.aspx.vb" Inherits="frm_central_item_parceiro" %>

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
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
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
                //alert(retorno);
            } 
         
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Item x Parceiros </STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 37px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 37px" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 37px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
                                                <table id="Table9" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 1px; ">
                                                        </td>
                                                        <td align="center" class="texto" >
                                                                <table id="Table6" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="right" class="texto" style="width: 13%; height: 20px">
                                                                            <strong>Item:</strong></td>
                                                                        <td align="left" style="height: 20px" colspan="2">
                                                                            &nbsp;
                                                                            <anthem:Label ID="lbl_cd_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;-&nbsp;
                                                                            <anthem:Label ID="lbl_ds_item" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                                UpdateAfterCallBack="True"></anthem:Label>                                                                            
                                                                            </td>
                                                                        <td align="left" style="height: 20px">
                                                                            &nbsp;<strong>Unidade Medida: 
                                                                                <anthem:Label ID="lbl_unidade_medida" runat="server" AutoUpdateAfterCallBack="True"
                                                                                    CssClass="texto" Font-Bold="False" UpdateAfterCallBack="True"></anthem:Label></strong></td>
                                                                    </tr>
                                                                </table>
                                                            <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                                Font-Size="X-Small" GroupingText="Grupos" HorizontalAlign="Center" Width="99%">
                                                                <table id="Table8" border="0" cellpadding="0" cellspacing="0" width="95%" class="texto">
                                                                    <tr>
                                                                        <td  align="left" style="height: 4px" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td  align="left" colspan="2" style="height: 20px">
                                                                            Cód. Parceiro: &nbsp;
                                                                            <anthem:TextBox ID="txt_cd_fornecedor" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                                CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox>
                                                                            <anthem:ImageButton ID="btn_lupa_parceiro" runat="server" AutoUpdateAfterCallBack="true"
                                                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                                ToolTip="Filtrar Produtores" Width="15px" />
                                                                            <anthem:Label ID="lbl_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                                                                CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_fornecedor"
                                                                                CssClass="texto" ErrorMessage="Preencha o campo Código do Parceiro para continuar ou selecione-o pela lupa."
                                                                                Font-Bold="True" ToolTip="O código do Parceiro deve ser preenchido" ValidationGroup="vg_adicionar_item">[!]</asp:RequiredFieldValidator>
                                                                            <anthem:CustomValidator ID="cv_validar_item" runat="server" AutoUpdateAfterCallBack="True"
                                                                                ControlToValidate="txt_cd_fornecedor" ValidationGroup="vg_adicionar_item">[!]</anthem:CustomValidator>&nbsp;
                                                                            <anthem:Button ID="btn_novo_parceiro" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                                Text="Adicionar" ToolTip="Adicionar novo parceiro" ValidationGroup="vg_adicionar_item" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table id="Table7" border="0" cellpadding="1" cellspacing="0" width="100%" >
                                                                                <tr>
                                                                                    <td colspan="4" style="height: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="texto">
                                                                                        <strong>Parceiro Item</strong></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" valign="top" >
                                                                                        <anthem:GridView ID="gridparceiro_item" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana"
                                                                                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" UpdateAfterCallBack="True"
                                                                                            Width="100%" CssClass="texto" DataKeyNames="id_central_item_parceiro">
                                                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                                ForeColor="White" />
                                                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                                ForeColor="White" HorizontalAlign="Center" />
                                                                                            <EditRowStyle BackColor="White" CssClass="texto" VerticalAlign="Top" />
                                                                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                                HorizontalAlign="Center" />
                                                                                            <AlternatingRowStyle BackColor="White" />
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="C&#243;digo" ReadOnly="True" DataField="cd_pessoa">
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Parceiro">
                                                                                                    <itemtemplate>
<asp:Label id="lbl_nm_pessoa" runat="server" Text='<%# Bind("nm_pessoa") %>' __designer:wfdid="w84"></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Unidade Medida" SortExpression="id_unidade_medida_fornecedor">
                                                                                                    <edititemtemplate>
<anthem:DropDownList id="cbo_unidade_medida" runat="server" CssClass="texto" __designer:wfdid="w63"></anthem:DropDownList> 
</edititemtemplate>
                                                                                                    <itemtemplate>
<anthem:Label id="lbl_unidade_medidas" runat="server" Text='<%# bind("ds_unidade_medida") %>' __designer:wfdid="w62"></anthem:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Lote M&#237;nimo">
                                                                                                    <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_lote_minimo" runat="server" CssClass="texto" ValidationGroup="vgsalvar" Text='<%# bind("nr_lote_minimo") %>' __designer:wfdid="w65" DecimalSymbol="," MaxCaracteristica="14" MaxMantissa="4"></cc6:OnlyDecimalTextBox> <anthem:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" ValidationGroup="vgsalvar" ControlToValidate="txt_lote_minimo" __designer:wfdid="w66">[!]</anthem:RequiredFieldValidator>
</edititemtemplate>
                                                                                                    <itemtemplate>
<asp:Label id="lbl_lote_minimo" runat="server" Text='<%# bind("nr_lote_minimo") %>' __designer:wfdid="w64"></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Lote M&#250;tiplo">
                                                                                                    <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_lote_multiplo" runat="server" CssClass="texto" ValidationGroup="vgsalvar" Text='<%# bind("nr_lote_multiplo") %>' __designer:wfdid="w68" DecimalSymbol="," MaxCaracteristica="14" MaxMantissa="4"></cc6:OnlyDecimalTextBox> <anthem:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" ValidationGroup="vgsalvar" ControlToValidate="txt_lote_multiplo" __designer:wfdid="w69">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                                                                    <itemtemplate>
<asp:Label id="lbl_lote_multiplo" runat="server" CssClass="texto" Text='<%# bind("nr_lote_multiplo") %>' __designer:wfdid="w67"></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Fator de Convers&#227;o">
                                                                                                    <edititemtemplate>
<cc3:OnlyNumbersTextBox id="txt_fator_conversao" runat="server" CssClass="texto" Width="30px" Text='<%# bind("nr_fator_conversao") %>' __designer:wfdid="w71"></cc3:OnlyNumbersTextBox> <anthem:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" CssClass="texto" ValidationGroup="vgsalvar" ErrorMessage="O campo Fator de Conversão deve ser informado." ControlToValidate="txt_fator_conversao" __designer:wfdid="w72" Enabled="False">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                                                                    <itemtemplate>
<asp:Label id="lbl_fator_conversao" runat="server" CssClass="texto" Text='<%# bind("nr_fator_conversao") %>' __designer:wfdid="w70"></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Decimal">
                                                                                                    <edititemtemplate>
<cc3:OnlyNumbersTextBox id="txt_decimal" runat="server" CssClass="texto" Width="30px" ValidationGroup="vgsalvar" Text='<%# bind("nr_casas_decimais_conversao") %>' __designer:wfdid="w74"></cc3:OnlyNumbersTextBox> <anthem:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" CssClass="texto" ValidationGroup="vgsalvar" ErrorMessage="O campo Decimal deve ser informado." ControlToValidate="txt_decimal" __designer:wfdid="w75" Enabled="False">[!]</anthem:RequiredFieldValidator> 
</edititemtemplate>
                                                                                                    <itemtemplate>
<asp:Label id="lbl_decimal" runat="server" CssClass="texto" Text='<%# bind("nr_casas_decimais_conversao") %>' __designer:wfdid="w73"></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <edititemtemplate>
&nbsp;<anthem:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CssClass="texto" AutoUpdateAfterCallBack="True" ValidationGroup="vgsalvar" __designer:wfdid="w80" CommandName="Update"></anthem:ImageButton>&nbsp; <anthem:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" CssClass="texto" ValidationGroup="vgsalvar" __designer:wfdid="w81" CommandName="Cancel"></anthem:ImageButton> <anthem:ValidationSummary id="ValidationSummary1" runat="server" Height="16px" ValidationGroup="vgsalvar" __designer:wfdid="w82"></anthem:ValidationSummary> 
</edititemtemplate>
                                                                                                    <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CssClass="texto" __designer:wfdid="w78" CommandName="Edit"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_desativar" runat="server" ImageUrl="~/img/icone_excluir.gif" CssClass="texto" __designer:wfdid="w79" CommandName="Delete" CommandArgument='<%# Bind("id_central_item_parceiro") %>' OnClientClick="if (confirm('Deseja realmente excluir o Parceiro?' )) return true;else return false;"></asp:ImageButton> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                            <RowStyle BackColor="#EFF3FB" />
                                                                                        </anthem:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <br />
                                                        </td>
                                                        <td  width="1" >
                                                        </td>
                                                    </tr>
                                                </table>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;&nbsp;
                                            </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_adicionar_item"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="True" />
            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
