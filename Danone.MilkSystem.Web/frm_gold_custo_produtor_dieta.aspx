<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_gold_custo_produtor_dieta.aspx.vb" Inherits="frm_gold_custo_produtor_dieta" %>

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
    <title>Custo Produtor Dieta GOLD</title>
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

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Custo Produtor Dieta GOLD</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp; &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
											    <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="">
											    <TABLE id="Table6" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 18px" width="23%">
                                                            <strong>
                                                                <anthem:Label ID="lbl_titulo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                    UpdateAfterCallBack="True">Estabelecimento:</anthem:Label></strong></td>
                                                        <td style="height: 18px" width="77%">
                                                            &nbsp;<anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 18px">
                                                            <strong>
                                                                <anthem:Label ID="lbl_titulo_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                                                    UpdateAfterCallBack="True">Produtor:</anthem:Label></strong></td>
                                                        <td style="height: 18px">
                                                            &nbsp;<anthem:Label ID="lbl_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 24px">
                                                            <strong>Propriedade:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <strong>Data Validade Inicial:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_dt_referencia_inicial" runat="server" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 18%;">
                                                            <strong>Data Validade Final:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_dt_referencia_final" runat="server" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
											    </TABLE>
											    </asp:Panel>
	
											    <asp:Panel ID="Panel7" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Dados Planejados">
											    <TABLE id="Table12" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 23%;">
                                                            <strong> Volume (lts/dia):</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_nr_volume_planejado" runat="server" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 23%;">
                                                            <strong> Taxa Crescimento Ano (%):</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_nr_taxa_crescimento_ano" runat="server" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;&nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 24px; width: 23%;">
                                                            <strong> Perc. dieta com vacas em lactação (%):</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:Label ID="lbl_nr_taxa_vacas_lactacao" runat="server" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
											    </TABLE>
											    </asp:Panel>
											    
											    
											    <asp:Panel ID="Panel2" runat="server" BackColor="White" Font-Bold="False"  Width="100%" Font-Size="X-Small" CssClass="texto" GroupingText="Dieta">
											    <TABLE id="Table8" cellSpacing="0" cellPadding="2" width="100%" border="0">
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="width: 14%">
                                                <strong>Item:</strong></td>
                                            <td align="left" colspan="2">
                                                &nbsp;<anthem:TextBox ID="txt_cd_item" runat="server" AutoUpdateAfterCallBack="true"
                                                    CssClass="texto" MaxLength="16" Width="72px" AutoCallBack="True"></anthem:TextBox>&nbsp;
                                                <anthem:ImageButton ID="btn_lupa_item" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_cd_item"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Item para continuar ou selecione-o pela lupa."
                                                    Font-Bold="True" ValidationGroup="vg_adicionar_item">[!]</asp:RequiredFieldValidator>
                                                <anthem:CustomValidator ID="cv_validar_item" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_cd_item" ValidationGroup="vg_adicionar_item">[!]</anthem:CustomValidator>&nbsp;
                                                <anthem:Button ID="btn_novo_item" runat="server" Text="Adicionar" ToolTip="Adicionar novo item" CssClass="texto" ValidationGroup="vg_adicionar_item" AutoUpdateAfterCallBack="True" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

	                        <tr>
	                            <TD class="texto" align=center colspan="2"><anthem:GridView ID="gridItens" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="5" UpdateAfterCallBack="True"
                                        UseAccessibleHeader="False" Width="80%" AddCallBacks="False" ShowFooter="True">
<FooterStyle HorizontalAlign="Center" Wrap="True"></FooterStyle>

<EditRowStyle Width="100%"></EditRowStyle>
<Columns>
<asp:BoundField DataField="cd_item" HeaderText="Item" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="nm_item" HeaderText="Descri&#231;&#227;o" ReadOnly="True"></asp:BoundField>
<asp:TemplateField HeaderText="Compra Central"><EditItemTemplate>
<asp:CheckBox id="chk_compra_central" runat="server" CssClass="texto" __designer:wfdid="w9"></asp:CheckBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="chk_compra_central" runat="server" CssClass="texto" Enabled="False" __designer:wfdid="w15"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Compra Produtor"><EditItemTemplate>
<asp:CheckBox id="chk_compra_produtor" runat="server" __designer:wfdid="w52"></asp:CheckBox> 
</EditItemTemplate>
<ItemTemplate>
<asp:CheckBox id="chk_compra_produtor" runat="server" CssClass="texto" __designer:wfdid="w51" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Qtde"><EditItemTemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_quantidade" runat="server" CssClass="texto" Width="80px" MaxLength="15" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w21" DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_quantidade" runat="server" CssClass="texto" Font-Bold="True" ValidationGroup="vg_salvar_item" ErrorMessage="A quantidade deve ser informada." ControlToValidate="txt_nr_quantidade" __designer:wfdid="w22">[!]</asp:RequiredFieldValidator><asp:CompareValidator id="CompareValidator1" runat="server" CssClass="texto" ValidationGroup="vg_salvar_item" ErrorMessage="A quantidade deve ser informada." ControlToValidate="txt_nr_quantidade" __designer:wfdid="w23" ValueToCompare="0" Type="Double" Operator="GreaterThan">[!]</asp:CompareValidator> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" CssClass="texto" Text='<%# Bind("nr_quantidade") %>' __designer:wfdid="w20"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Valor Unit (R$)">
        <edititemtemplate>
&nbsp;<cc6:OnlyDecimalTextBox id="txt_nr_valor_unitario" runat="server" CssClass="texto" Width="80px" MaxLength="15" Text='<%# Bind("nr_valor_unitario") %>' __designer:wfdid="w17" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol=","></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rqf_valor_unitario" runat="server" CssClass="texto" Font-Bold="True" ValidationGroup="vg_salvar_item" ErrorMessage="O Valor Unitário deve ser informad0." ControlToValidate="txt_nr_valor_unitario" __designer:wfdid="w18">[!]</asp:RequiredFieldValidator><asp:CompareValidator id="CompareValidator2" runat="server" CssClass="texto" ValidationGroup="vg_salvar_item" ErrorMessage="O Valor Unitário deve ser mair do que zero." ControlToValidate="txt_nr_valor_unitario" __designer:wfdid="w19" Operator="GreaterThan" Type="Double" ValueToCompare="0">[!]</asp:CompareValidator> 
</edititemtemplate>
        <itemtemplate>
<asp:Label id="lbl_nr_valor_unitario" runat="server" Text='<%# Bind("nr_valor_unitario") %>' __designer:wfdid="w16"></asp:Label> 
</itemtemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Total (R$)">
        <itemtemplate>
<asp:Label id="lbl_nr_valor_total" runat="server" Text='<%# Bind("nr_valor_total") %>' __designer:wfdid="w20"></asp:Label> 
</itemtemplate>
    </asp:TemplateField>
<asp:TemplateField><EditItemTemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" CssClass="texto" ToolTip="Salvar Item de Cotação" ValidationGroup="vg_salvar_item" __designer:wfdid="w10" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Item" ImageAlign="Baseline" __designer:wfdid="w11" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_salvar_item" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w12"></asp:ValidationSummary> 
</EditItemTemplate>
<ItemTemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" CssClass="texto" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" ToolTip="Editar Item " __designer:wfdid="w8" CommandName="Edit"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Item da Dieta" ImageAlign="Baseline" __designer:wfdid="w9" CommandName="delete" CommandArgument='<%# Bind("id_gold_custo_produtor_dieta") %>' OnClientClick="if (confirm('Este item será excluído permanentemente da Base de Dados. Deseja realmente excluir?' )) return true;else return false;"></anthem:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="st_tipo_compra" Visible="False">
        <edititemtemplate>
&nbsp;
</edititemtemplate>
        <itemtemplate>
<asp:Label id="lbl_st_tipo_compra" runat="server" Text='<%# Bind("st_tipo_compra") %>' __designer:wfdid="w29"></asp:Label> 
</itemtemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="id_gold_custo_produtor_dieta" Visible="False">
        <edititemtemplate>
<asp:Label id="lbl_id_gold_custo_produtor_dieta" runat="server" Text='<%# Bind("id_gold_custo_produtor_dieta") %>' __designer:wfdid="w41"></asp:Label>&nbsp;
</edititemtemplate>
        <itemtemplate>
<asp:Label id="lbl_id_gold_custo_produtor_dieta" runat="server" Text='<%# Bind("id_gold_custo_produtor_dieta") %>' __designer:wfdid="w32"></asp:Label> 
</itemtemplate>
    </asp:TemplateField>
</Columns>
</anthem:GridView>
                                    <anthem:CustomValidator ID="cv_itens_fornecedores" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_verificacoes_finais">[!]</anthem:CustomValidator>
                                    &nbsp;
                                    &nbsp; &nbsp;&nbsp; &nbsp;
                                    <anthem:CustomValidator ID="cv_pedido_itens" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator>
                                    <anthem:CustomValidator ID="cv_pedido_aprovacao" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_pedido">[!]</anthem:CustomValidator></td>
	                        </tr>
																
                            <tr>
                                <td align="right" class="texto" style="height: 24px; width: 23%;">
                                    <strong> Custo da Dieta (R$):</strong></td>
                                <td style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_nr_custo_dieta" runat="server" CssClass="texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 24px; width: 23%;">
                                    <strong> Eficiência da Dieta (%):</strong></td>
                                <td style="height: 24px">
                                    &nbsp;<anthem:Label ID="lbl_nr_eficiencia_dieta" runat="server" CssClass="texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
											    </TABLE>
											    </asp:Panel>
											    
											    
											    

											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="img_voltarfooter" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
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
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
</form>
	</body>
</HTML>
