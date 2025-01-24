<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_grupo_pool_compras_propriedade.aspx.vb" Inherits="frm_grupo_pool_compras_propriedade" %>

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

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
  	        
        szUrl = 'lupa_propriedade.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Grupo Pool de Compras x Propriedade</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
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
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" class="texto">
							<TR>
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" class="texto">
										<TR>
											<TD width="76%">
                                                <table id="Table9" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td  style="width: 1px">
                                                        </td>
                                                        <td align="center">
                                                             <table id="Table6" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td align="right" class="texto" style=" height: 20px; width: 15%;">
                                                                            <strong>Grupo Pool Compras:</strong></td>
                                                                        <td align="left" style=" height: 20px">
                                                                            &nbsp;<anthem:Label ID="lbl_cd_grupo_pool_compras" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                            &nbsp;<anthem:Label ID="lbl_ds_grupo_pool_compras" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                        <td align="right" class="texto" style="width: 1%; height: 20px">
                                                                        </td>
                                                                        <td align="left" style="height: 20px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            
                                                            <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="texto" Font-Bold="False"
                                                                Font-Size="X-Small" GroupingText="Grupos" HorizontalAlign="Center" Width="99%">
                                                                <br />
                                                                <table id="Table8" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td width="76%">
                                                                            <table id="Table7" border="0" cellpadding="1" cellspacing="0" class="texto" width="95%">
                                                                                <tr>
                                                                                    <td align="left" colspan="2" style="height: 20px">
                                                                                        Cód. Propriedade: &nbsp;
                                                                                        <anthem:TextBox ID="txt_id_propriedade" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                                            CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                                                                        <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
                                                                                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                                            ToolTip="Filtrar Produtores" Width="15px" />
                                                                                        &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                                            CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_id_propriedade"
                                                                                                CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                                                                Font-Bold="True" ToolTip="O campo Propriedade deve ser informado." ValidationGroup="vg_adicionar_item">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                                                                                    ID="cv_propriedade" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade"
                                                                                                    CssClass="texto" Display="Dynamic" ErrorMessage="Propriedade não cadastrado!"
                                                                                                    Font-Bold="true" Text="[!]" ToolTip="Propriedade Não Cadastrada!" ValidationGroup="vg_adicionar_item"></anthem:CustomValidator>&nbsp;
                                                                                        <anthem:Button ID="btn_nova_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                                            CssClass="texto" Text="Adicionar" ToolTip="Adicionar nova propriedade" ValidationGroup="vg_adicionar_item" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="height: 15px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <strong>Propriedades do Grupo</strong>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <anthem:GridView ID="gridpropriedade_grupo" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                            AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" Font-Names="Verdana"
                                                                                            Font-Size="XX-Small" ForeColor="#333333" GridLines="None" UpdateAfterCallBack="True"
                                                                                            Width="100%" CssClass="texto" PageSize="7">
                                                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                                ForeColor="White" />
                                                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                                                                                ForeColor="White" HorizontalAlign="Center" />
                                                                                            <EditRowStyle BackColor="#2461BF" />
                                                                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="White"
                                                                                                HorizontalAlign="Center" />
                                                                                            <AlternatingRowStyle BackColor="White" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="C&#243;digo" SortExpression="id_propriedade">
                                                                                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_grupo" runat="server" __designer:wfdid="w91" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="nm_propriedade" HeaderText="Propriedade" ReadOnly="True"
                                                                                                    SortExpression="nm_propriedade">
                                                                                                    <headerstyle wrap="True" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="cd_cep" HeaderText="CEP" />
                                                                                                <asp:BoundField DataField="cd_pessoa" HeaderText="C&#243;d.Produtor" SortExpression="cd_pessoa" />
                                                                                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                                                                                <asp:TemplateField>
                                                                                                    <headertemplate>
&nbsp; 
</headertemplate>
                                                                                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="btn_retirar" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" __designer:wfdid="w92" CommandName="Delete" OnClientClick="if (confirm('Deseja realmente retirar a Propriedade do Grupo?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>

                                                                                                    <headerstyle width="6%" />
                                                                                                    <itemstyle horizontalalign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField SortExpression="id_grupo_pool_compras_propriedade" Visible="False">
                                                                                                    <itemtemplate>
<asp:Label id="lbl_id_grupo_pool_compras_propriedade" runat="server" CssClass="texto" __designer:wfdid="w45" Text='<%# Bind("id_grupo_pool_compras_propriedade") %>'></asp:Label> 
</itemtemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                            <RowStyle BackColor="White"  ForeColor="Black" HorizontalAlign="Center" />
                                                                                        </anthem:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                        <td width="1">
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
                           <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
</form>
	</body>
</HTML>
