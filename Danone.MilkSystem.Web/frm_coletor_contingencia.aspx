<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_coletor_contingencia.aspx.vb" Inherits="frm_coletor_contingencia" %>

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
    <title>Romaneio Cooperativa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
<script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var retorno="";
   	    var szUrl;
        szUrl = 'lupa_veiculo.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
    }            
</script>
	
	    <form id="Form1" method="post" runat="server">
		    <table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 876px;"><STRONG>Contingência Coletor</STRONG></TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; width: 876px;">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" Visible="False" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar" Visible="False">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" style="width: 876px" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados do Produtor</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px" class="texto" align=right width="23%"></TD>
								<TD style="HEIGHT: 9px"></TD>
							</TR>
	                        <tr>
	                            <TD class="texto" align=right width="23%" style="height: 26px">
	                                <STRONG> Produtor:</strong></td>
	                            <TD class="texto" style="height: 26px">
	                                &nbsp; &nbsp;<anthem:Label ID="lbl_produtor" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
	                                    UpdateAfterCallBack="True" Width="500px"></anthem:Label>&nbsp;&nbsp;
                                    &nbsp;
	                            </td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%" style="height: 19px">
	                                <strong> Propriedade:</strong></td>
	                            <TD class="texto" style="height: 19px">
	                                &nbsp; &nbsp;<anthem:Label ID="lbl_propriedade" runat="server" AutoUpdateAfterCallBack="True"
	                                    CssClass="texto" UpdateAfterCallBack="True" Width="300px"></anthem:Label>&nbsp;&nbsp;
                                    &nbsp; &nbsp; <strong>U.Produção:</strong>
	                                <anthem:Label ID="lbl_unid_producao" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="117px"></anthem:Label></td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=right width="23%" style="height: 19px">
                                    <strong>Nova Placa:</strong></td>
                                <TD class="texto" style="height: 19px">
                                    &nbsp; &nbsp;<anthem:Label ID="lbl_placa_frete" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Width="300px"></anthem:Label>
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align="right" width="23%" style="height: 22px">
	                                </td>
	                            <TD class="texto" style="height: 22px">
	                                &nbsp; </td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
                                    <strong>Motivo Não Coleta:</strong></td>
	                            <TD class="texto" style="height: 19px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_motivo_nao_coleta" runat="server" CssClass="texto" AutoCallBack="True" Width="300px">
                                    </anthem:DropDownList>
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <strong>Total Litros:</strong>
                                    <anthem:Label ID="lbl_total_litros" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Width="117px"></anthem:Label></td>
	                        </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados da Coleta</td>
	                        </tr>
                            <tr>
                                <td style="height: 5px" class="texto">
                                    &nbsp;</td>
                                <td style="height: 5px" class="texto">
                                </td>
                            </tr>
	                        <tr>
	                        <td align="right">
                                <strong class="texto">Data Coleta:</strong></td>
                                <td align="left">&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_coleta" runat="server" CssClass="texto"
                                        MaxLength="10" Width="80px"></cc4:OnlyDateTextBox>&nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_hr_coleta" runat="server" CssClass="texto" MaxLength="2"
                                        Width="20px"></cc3:OnlyNumbersTextBox>
                                    :
                                    <cc3:OnlyNumbersTextBox ID="txt_mm_coleta" runat="server" CssClass="texto" Width="20px"></cc3:OnlyNumbersTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_dt_coleta"
                                        CssClass="texto" ErrorMessage="Preencha o Início da Análise para continuar."
                                        Font-Bold="False" ToolTip="Data de Coleta deve ser preenchida." ValidationGroup="vg_coleta">[!]</asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_coleta"
                                        CssClass="texto" ErrorMessage="Preencha as horas da Data de Coleta corretamente para continuar."
                                        Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_coleta">[!]</asp:RangeValidator><asp:RangeValidator
                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_coleta" CssClass="texto"
                                            ErrorMessage="Preencha os minutos da Data de Coleta corretamente para continuar."
                                            Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_coleta">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_hr_coleta"
                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Data da Coleta para continuar."
                                                Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_coleta">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mm_coleta"
                                                    CssClass="texto" ErrorMessage="Preencha os Minutos em Data de Coleta para continuar."
                                                    Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_coleta">[!]</asp:RequiredFieldValidator>
                                    <anthem:Button ID="btn_atualizar_data_coleta" runat="server" AutoUpdateAfterCallBack="True" Text="Atualizar Data de Coleta" ValidationGroup="vg_coleta" CssClass="texto" /></td>
	                        </tr>
                            <tr>
                                <td style="height: 5px" class="texto">
                                    &nbsp;</td>
                                <td style="height: 5px" class="texto">
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
                                    <anthem:GridView ID="gridColetas" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DataKeyNames="id_coleta,id_coleta_veiculo" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="5" UpdateAfterCallBack="True" UseAccessibleHeader="False"
                                        Width="80%">
                                        <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                        <EditRowStyle Width="100%" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Placa">
                                                <edititemtemplate>
<asp:DropDownList id="cbo_placa" runat="server" Width="100px" CssClass="texto" __designer:wfdid="w3" AutoPostBack="True" OnSelectedIndexChanged="cbo_placa_TextChanged"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rqf_placa" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" Font-Bold="True" ErrorMessage="A Placa deve ser informada." __designer:wfdid="w4" ControlToValidate="cbo_placa">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <footertemplate>
&nbsp; 
</footertemplate>
                                                <itemtemplate>
<asp:Label id="lbl_placa" runat="server" CssClass="texto" Text='<%# Bind("ds_placa") %>' __designer:wfdid="w5"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Compartimento">
                                                <edititemtemplate>
<anthem:DropDownList id="cbo_compartimento" runat="server" Width="100px" CssClass="texto" __designer:wfdid="w7"></anthem:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rqf_compartimento" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" Font-Bold="True" ErrorMessage="O compartimento deve ser informada." __designer:wfdid="w8" ControlToValidate="cbo_compartimento">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_compartimento" runat="server" CssClass="texto" Text='<%# Bind("nm_compartimento") %>' __designer:wfdid="w6"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Litros">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_litros" runat="server" Width="80px" CssClass="texto" __designer:wfdid="w51" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>&nbsp; <asp:RequiredFieldValidator id="rqf_litros" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" Font-Bold="True" ErrorMessage="O volume em litros deve ser informado." __designer:wfdid="w52" ControlToValidate="txt_nr_litros">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <footertemplate>
&nbsp; 
</footertemplate>
                                                <itemtemplate>
<asp:Label id="lbl_litros" runat="server" CssClass="texto" Text='<%# Bind("nr_volume") %>' __designer:wfdid="w50"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Temp.">
                                                <edititemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_temperatura" runat="server" Width="80px" CssClass="texto" __designer:wfdid="w69" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox>&nbsp;<asp:RequiredFieldValidator id="rqf_temperatura" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" Font-Bold="True" ErrorMessage="O temperatura deve ser informado." __designer:wfdid="w70" ControlToValidate="txt_nr_temperatura">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_temperatura" runat="server" CssClass="texto" Text='<%# Bind("nr_temperatura") %>' __designer:wfdid="w68"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alizarol">
                                                <edititemtemplate>
<asp:DropDownList id="cbo_alizarol" runat="server" Width="80px" CssClass="texto" __designer:wfdid="w12"><asp:ListItem Value="0">Negativo</asp:ListItem>
<asp:ListItem Value="1">Positivo</asp:ListItem>
</asp:DropDownList> <asp:RequiredFieldValidator id="rqf_alizarol" runat="server" ValidationGroup="vg_salvar_escolaridade" CssClass="texto" Font-Bold="True" ErrorMessage="O alizarol deve ser informad." __designer:wfdid="w13" ControlToValidate="cbo_alizarol">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <itemtemplate>
<asp:Label id="lbl_alizarol" runat="server" CssClass="texto" Text='<%# Bind("nm_alizarol") %>' __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar_grid" CssClass="texto" ToolTip="Salvar Coleta" __designer:wfdid="w9" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração Coleta" __designer:wfdid="w10" CommandName="Cancel" ImageAlign="Baseline"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w11"></asp:ValidationSummary> 
</edititemtemplate>
                                                <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" ToolTip="Editar Coleta" __designer:wfdid="w7" CommandName="Edit"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Coleta" __designer:wfdid="w8" CommandName="delete" ImageAlign="Baseline" CommandArgument='<%# Bind("id_compartimento") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de coleta?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <itemtemplate>
<anthem:Label id="lbl_id_compartimento" runat="server" Text='<%# bind("id_compartimento") %>' __designer:wfdid="w6" Visible="False"></anthem:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp;<br />
                                    &nbsp;<anthem:CustomValidator ID="cv_grid" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ErrorMessage="O mesmo compartimento não pode ser informado para a mesma placa."
                                        Font-Bold="True" ValidationGroup="vg_salvar_grid">[!]</anthem:CustomValidator>
                                    &nbsp;<br />
                                    &nbsp;<anthem:Button ID="btn_novo_compartimento" runat="server" Text="Adicionar" ToolTip="Adicionar nova coleta" AutoUpdateAfterCallBack="True" CssClass="texto" />
	                            </td>
	                        </tr>
                            <tr>
                                <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">
                                    Não Conformidades</td>
                            </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <anthem:GridView ID="gridNConf" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" DataKeyNames="id_coleta_nao_conformidade" Font-Names="Verdana"
                                        Font-Size="XX-Small" Height="24px" PageSize="5" UpdateAfterCallBack="True" UseAccessibleHeader="False"
                                        Width="80%">
                                        <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                        <EditRowStyle Width="100%" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="N&#227;o Conformidade">
                                                <edititemtemplate>
<asp:DropDownList id="cbo_nao_conformidade" runat="server" Width="100px" CssClass="texto" __designer:wfdid="w11" AutoPostBack="True"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rqf_nao_conformidade" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" Font-Bold="True" ErrorMessage="A Não Conformidade deve ser informada." __designer:wfdid="w12" ControlToValidate="cbo_nao_conformidade">[!]</asp:RequiredFieldValidator> 
</edititemtemplate>
                                                <footertemplate>
&nbsp; 
</footertemplate>
                                                <itemtemplate>
<asp:Label id="lbl_nao_conformidade" runat="server" CssClass="texto" Text='<%# Bind("nm_nao_conformidade") %>' __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <edititemtemplate>
<asp:ImageButton id="btn_salvar" runat="server" ImageUrl="~/img/icone_gravar.gif" ValidationGroup="vg_salvar_gridnconf" CssClass="texto" ToolTip="Salvar Não Conformidade" __designer:wfdid="w4" CommandName="Update"></asp:ImageButton>&nbsp; <asp:ImageButton id="btn_cancelar" runat="server" ImageUrl="~/img/icon_undo.gif" ToolTip="Voltar Alteração " __designer:wfdid="w5" CommandName="Cancel" ImageAlign="Baseline"></asp:ImageButton> <asp:ValidationSummary id="ValidationSummary2" runat="server" ValidationGroup="vg_salvar_grid" CssClass="texto" ShowSummary="False" ShowMessageBox="True" __designer:wfdid="w6"></asp:ValidationSummary> 
</edititemtemplate>
                                                <itemtemplate>
<anthem:ImageButton id="btn_editar" runat="server" ImageUrl="~/img/icone_editar_grid.gif" Visible="False" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" ToolTip="Editar Não Conformidade" __designer:wfdid="w2" CommandName="Edit"></anthem:ImageButton>&nbsp;&nbsp; <anthem:ImageButton id="btn_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" ToolTip="Excluir Não Conformidade" __designer:wfdid="w3" CommandName="delete" CommandArgument='<%# Bind("id_coleta_nao_conformidade") %>' OnClientClick="if (confirm('Deseja realmente excluir este registro de Não Conformidade?' )) return true;else return false;" ImageAlign="Baseline"></anthem:ImageButton> 
</itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <itemtemplate>
&nbsp;
</itemtemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp;&nbsp;&nbsp;<br />
                                    <anthem:CustomValidator ID="cv_nconf" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ErrorMessage="A  Não Conformidade já está cadastrada." Font-Bold="True"
                                        ValidationGroup="vg_salvar_gridnconf">[!]</anthem:CustomValidator>
                                    &nbsp;&nbsp;<br />
                                    &nbsp;<anthem:Button ID="btn_adicionar_nconf" runat="server" Text="Adicionar" ToolTip="Adicionar nova Não Conformidade" AutoUpdateAfterCallBack="True" CssClass="texto" />
                                </td>
                            </tr>
	                        <TR>
								<TD class="texto" align="right" width="23%"></TD>
	                            <TD></TD>
	                        </TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD style="width: 876px">
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" Visible="False" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar" Visible="False">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD ></TD>
				</TR>
			</table>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_coleta"></asp:ValidationSummary>
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
