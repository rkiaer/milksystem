<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_item_nota_fiscal.aspx.vb" Inherits="frm_item_nota_fiscal" %>

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
    <title>Item Nota Fiscal</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var retorno="";
   	    var szUrl;
        szUrl = 'frm_nota_fiscal_narrativa.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
    }            
</script>
	
	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Itens da Nota Fiscal</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 5px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 5px" class="texto">
						<TABLE id="Table9" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"  /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; &nbsp;</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 5px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top" >
					    <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
						    <TR>
							    <TD style="height: 39px; width: 7px;"  ></TD>
								<TD style="height: 39px" >
                                    <asp:Panel ID="Panel1" runat="server" BackColor="White" Font-Bold="False" GroupingText="Dados Nota Fiscal" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" CssClass="texto">
                                        <br />
                                        <table id="Table4" border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr runat="server" id="tr_romaneio">
                                                <TD class="texto" align="right" style="height: 20px; width: 15%;" >
                                                    <STRONG>Romaneio:</strong></td>
                                                <TD style=" height: 20px;" align="left" >
                                                    &nbsp;<asp:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px; width: 17%;" >
                                                    <STRONG></strong>
                                                </td>
                                                <TD style="height: 20px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
						                        <TD class="texto" align="right" style="height: 20px; width: 15%;" ><STRONG>Estabelecimento:</STRONG></TD>
                                                <TD style=" height: 20px;" align="left" >&nbsp;<asp:Label ID="lbl_estabelecimento" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>CNPJ:</STRONG></TD>
							                    <TD style="height: 20px" align="left">&nbsp;<asp:Label ID="lbl_cd_cnpj" runat="server"  CssClass="texto" Width="100%"></asp:Label></TD>
                                            </tr>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px;width:15%"><STRONG>Cooperativa:</STRONG></TD>
							                    <TD style="height: 20px;" align="left" colspan="3" rowspan="" >&nbsp;<asp:Label ID="lbl_cooperativa" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
                                            <tr>
						                        <TD class="texto" align="right" style="height: 20px; width: 15%;" ><STRONG>Nr. Nota Fiscal:</STRONG></TD>
                                                <TD style=" height: 20px; width: 28%;" align="left" >&nbsp;<asp:Label ID="lbl_nr_nota_fiscal" runat="server" CssClass="texto" Width="80%"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" >
                                                    <strong>Série:</strong></TD>
							                    <TD style="width: 32%;" align="left">&nbsp;<asp:Label ID="lbl_serie" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
                                            <tr>
                                                <TD class="texto" align="right" style="height: 20px; width: 15%;" >
                                                    <STRONG class="texto">Data Emissão:</STRONG></TD>
							                    <TD style="height: 20px; width: 28%;" align="left" >&nbsp;<asp:Label ID="lbl_dt_emissao" runat="server"  CssClass="texto"></asp:Label></TD>
							                    <TD class="texto" align="right" style="height: 20px; width: 17%;" ><STRONG>Data Transação:</STRONG></TD>
							                    <TD align="left" style="width: 32%" >&nbsp;<asp:Label ID="lbl_dt_transacao" runat="server"  CssClass="texto"></asp:Label></TD>
                                            </tr>
                                            <tr>
							                    <TD class="texto" align="right" style="height: 20px; width: 15%;" ><STRONG class="texto">Frete:</strong></td>
                                                <TD style="height: 20px; width: 28%;" align="left" >
                                                    &nbsp;<asp:Label ID="lbl_nm_frete" runat="server"  CssClass="texto"></asp:Label></td>
                                                <TD class="texto" align="right" style="height: 20px; width: 17%;" >
                                                    <STRONG>Natureza Operação:</strong></td>
                                                <TD align="left" style="width: 32%" >
                                                    &nbsp;<asp:Label ID="lbl_natureza_operacao" runat="server"  CssClass="texto"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                    
									
								</TD>
								<TD style="height: 39px"  ></TD>
							</TR>
						    <TR>
							    <TD style="height: 26px; width: 7px;"  ></TD>
								<TD style="height: 26px" >
                                    <asp:Panel ID="Panel3" runat="server" BackColor="White" 
                                        Font-Bold="False" GroupingText="Itens" Width="100%" Font-Size="X-Small" HorizontalAlign="Center" BorderStyle="None" CssClass="texto">
                                        <br />
                                        <table width="98%">
                                            <tr>
                                                <td align="center" class="texto" colspan="4">
                                                    <strong></strong>
                                                    <anthem:GridView ID="grditem" runat="server"
                                                        AutoGenerateColumns="False" CellPadding="4" CssClass="texto"
                                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                        Width="100%" DataKeyNames="id_item_nota">
                                                        <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                        <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sequ&#234;ncia" InsertVisible="False">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000"><asp:Label id="lbl_nr_sequencia" runat="server" CssClass="texto" Text='<%# Bind("nr_sequencia") %>' __designer:wfdid="w77"></asp:Label></SPAN></STRONG> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_sequencia" runat="server" CssClass="texto" Text='<%# Bind("nr_sequencia") %>' __designer:wfdid="w32"></asp:Label>&nbsp; 
</itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle horizontalalign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">* </SPAN></STRONG><anthem:DropDownList id="cbo_id_item" runat="server" CssClass="texto" ValidationGroup="vg_item" __designer:wfdid="w91" OnSelectedIndexChanged="cbo_id_item_SelectedIndexChanged"></anthem:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfv_placa" runat="server" CssClass="texto" Font-Bold="True" ValidationGroup="vg_item" __designer:wfdid="w92" ErrorMessage="O item deve ser informado." ControlToValidate="cbo_id_item">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nm_item" runat="server" CssClass="texto" Text='<%# Bind("nm_item") %>' __designer:wfdid="w90"></asp:Label> 
</itemtemplate>
                                                                <headerstyle horizontalalign="Center" />
                                                                <itemstyle horizontalalign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quantidade">
                                                                <edititemtemplate>
<STRONG><SPAN style="COLOR: #ff0000">&nbsp;</SPAN></STRONG><cc6:OnlyDecimalTextBox id="txt_nr_quantidade" runat="server" CssClass="texto" Width="96px" Text='<%# bind("nr_quantidade") %>' __designer:wfdid="w13" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," MaxLength="15"></cc6:OnlyDecimalTextBox>&nbsp; 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_quantidade" runat="server" Text='<%# bind("nr_quantidade") %>' __designer:wfdid="w12"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unidade">
                                                                <edititemtemplate>
<asp:Label id="lbl_cd_unidade_medida" runat="server" CssClass="texto" Text='<%# bind("cd_unidade_medida") %>' __designer:wfdid="w72"></asp:Label> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_cd_unidade_medida" runat="server" CssClass="texto" Text='<%# bind("cd_unidade_medida") %>' __designer:wfdid="w71"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pre&#231;o Unit&#225;rio">
                                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_preco_unitario" runat="server" CssClass="texto" Width="96px" Text='<%# bind("nr_preco_unitario") %>' __designer:wfdid="w16" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," MaxLength="15"></cc6:OnlyDecimalTextBox> <asp:RequiredFieldValidator id="rfv_unit" runat="server" ValidationGroup="vg_item" __designer:wfdid="w17" ErrorMessage="O preço unitário deve ser preenchido!" ControlToValidate="txt_nr_preco_unitario">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_preco_unitario" runat="server" CssClass="texto" Text='<%# bind("nr_preco_unitario") %>' __designer:wfdid="w15"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pre&#231;o Total">
                                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_preco_total" runat="server" CssClass="texto" Width="96px" Text='<%# bind("nr_preco_total") %>' __designer:wfdid="w34" DecimalSymbol="," MaxCaracteristica="12" MaxMantissa="2"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator id="rv_tot" runat="server" ValidationGroup="vg_item" __designer:wfdid="w35" ControlToValidate="txt_nr_preco_total" ErrorMessage="O Preço Total deve ser preenchido!">[!]</asp:RequiredFieldValidator><anthem:CustomValidator id="cv_nr_preco_total" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Preço Total incorreto." ValidationGroup="vg_item" __designer:wfdid="w37" ControlToValidate="txt_nr_preco_total" ErrorMessage="Preço Total incorreto." OnServerValidate="cv_nr_preco_total_ServerValidate">[!]</anthem:CustomValidator>
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_preco_total" runat="server" Text='<%# bind("nr_preco_total") %>' __designer:wfdid="w33"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Peso L&#237;quido ">
                                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_peso_liquido" runat="server" CssClass="texto" Width="96px" Text='<%# bind("nr_peso_liquido") %>' __designer:wfdid="w64" DecimalSymbol="," MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:Label id="lbl_nr_peso_liquido" runat="server" Text='<%# bind("nr_peso_liquido") %>' __designer:wfdid="w63"></asp:Label> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                            <asp:HyperLinkField DataNavigateUrlFields="id_item_nota" DataNavigateUrlFormatString="~/frm_nota_fiscal_narrativa.aspx?id_item_nota={0}"
                                                                HeaderImageUrl="~/img/icone_narrativa.gif" NavigateUrl="~/frm_nota_fiscal_narrativa.aspx"
                                                                Target="_blank" Text="Narrativa" />
                                                            <asp:TemplateField ShowHeader="False">
                                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ToolTip="Gravar Item" Text="Update" ValidationGroup="vg_item" __designer:wfdid="w83" CommandName="Update" CommandArgument='<%# bind("id_item_nota") %>'></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração" Text="Cancel" __designer:wfdid="w84" CommandName="Cancel"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" CssClass="texto" ValidationGroup="vg_item" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w85"></asp:ValidationSummary> 
</edititemtemplate>
                                                                <itemtemplate>
<asp:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" ToolTip="Editar Item" Text="Edit" __designer:wfdid="w81" CommandName="Edit"></asp:ImageButton>&nbsp;<asp:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Item" Text="Edit" __designer:wfdid="w82" CommandName="Delete" CommandArgument='<%# bind("id_item_nota") %>' OnClientClick="if (confirm('Deseja realmente excluir este item?' )) return true;else return false;"></asp:ImageButton> 
</itemtemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </anthem:GridView>
                                                    &nbsp;
                                                    <br />
                                                    <anthem:Button ID="btn_novo_lacre" runat="server"
                                                        Text="Adicionar" ToolTip="Adicionar novo lacre" AutoUpdateAfterCallBack="True" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp;
									
								</TD>
								<TD style="height: 26px"  ></TD>
							</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" style="width: 977px">
					    <TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px; height: 17px;"></TD>
								<TD style="height: 17px">
									<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                        <tr>
                                            <TD style="height: 20px"  >
                                            </td>
                                            <TD style="height: 20px" >
                                            </td>
                                            <TD style="height: 20px"  >
                                            </td>
                                        </tr>
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
											<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="1" bgColor="#d0d0d0" style="height: 17px"></TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"
                UpdateAfterCallBack="false"></cc7:AlertMessages>
        </form>
	</body>
</HTML>
