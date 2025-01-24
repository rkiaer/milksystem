<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_coleta_amostra_manual.aspx.vb" Inherits="frm_coleta_amostra_manual" %>

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
    <title>Coletas de Amostras Manual</title>
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
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Coleta de Amostra Manual</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="12" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                     </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD bgColor="#d0d0d0"></TD>
								<TD>

								    <TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%">
									    <TR>
										    <TD class="titmodulo" colSpan="2" > Dados<anthem:CustomValidator ID="cv_salvar" runat="server"
                                                                Font-Bold="True" ForeColor="White" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator></TD>
									    </TR>
                                        <tr>
                                            <td align="right" class="texto" width="23%" style="height: 25px">
                                                <span class="obrigatorio">*</span> <strong>Estabelecimento:</strong></td>
                                            <td style="height: 22px">
                                                &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                                </anthem:DropDownList>
                                                <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                    Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O Estabelecimento deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
    									
    									
                                        <tr>
                                            <td align="right" class="texto" width="23%">
                                                <span class="obrigatorio"></span><strong><span style="color: #ff0000">*</span>Referência:</strong></td>
                                            <td width="77%" class="texto" style="height: 22px">
                                                &nbsp;<cc4:OnlyDateTextBox ID="txt_referencia" runat="server" CssClass="texto"
                                                    DateMask="MonthYear" Width="71px"></cc4:OnlyDateTextBox>
                                                <anthem:RequiredFieldValidator
                                                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_referencia"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar."
                                                        Font-Bold="True" ToolTip="O campo Referência deve ser informado."
                                                        ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto">
                                                <strong><span style="color: #ff0000">*</span> Propriedade:</strong></td>
                                            <td style="height: 22px" >
                                                &nbsp;<anthem:TextBox ID="txt_id_propriedade" runat="server" AutoCallBack="true"
                                                    AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                                <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
                                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                <anthem:Label ID="lbl_proriedade_matriz" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_id_propriedade"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                        Font-Bold="True" ToolTip="O campo Propriedade deve ser informado." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto" >
                                                <strong><span style="color: #ff0000">*</span> UP:</strong></td>
                                            <td style="height: 22px" >
                                                &nbsp;<anthem:DropDownList ID="cbo_unid_producao" runat="server" AutoPostBack="false"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_unid_producao"
                                                    CssClass="texto" ErrorMessage="Preencha o campo UP para continuar." Font-Bold="True"
                                                    ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto" >
                                                <strong> Última Rota Carregada Coletor:</strong></td>
                                            <td style="HEIGHT: 22px">
                                                &nbsp;<anthem:Label ID="lbl_ultima_coleta" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto" >
                                                <strong><span style="color: #ff0000">*</span>Tipo da Coleta:</strong></td>
                                            <td style="height: 22px" >
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_coleta" runat="server" AutoPostBack="false"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_tipo_coleta"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Tipo da Coleta para continuar." Font-Bold="True"
                                                    ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto" >
                                                <strong><span style="color: #ff0000">*</span>Período para Coleta em dias:</strong></td>
                                            <td class="texto" style="height: 22px">
                                                &nbsp;<cc3:OnlyNumbersTextBox ID="txt_dt_ini" runat="server" CssClass="texto" MaxLength="2"
                                                                Width="30px"></cc3:OnlyNumbersTextBox>&nbsp; à&nbsp;
                                                            <cc3:OnlyNumbersTextBox ID="txt_dt_fim" runat="server" CssClass="texto"
                                                                MaxLength="2" Width="30px"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_dt_ini"
                                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Inicial do Período para Coletas' para continuar."
                                                                Font-Bold="True" ToolTip="O campo 'Dia Inicial do Período para Coletas' deve ser informado."
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_dt_fim"
                                                                CssClass="texto" ErrorMessage="Preencha o campo 'Dia Final do Período para Coletas' para continuar."
                                                                Font-Bold="True" ToolTip="O campo 'Dia Final do Período para Coletas' deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><anthem:RangeValidator
                                                                    ID="RangeValidator1" runat="server" ControlToValidate="txt_dt_ini" ErrorMessage="O Dia Inicial do Período para Coletas deve estar entre 1 e 30."
                                                                    MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial do Período para Coletas deve estar entre 1 e 30."
                                                                    Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_dt_fim"
                                                                 ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30." MaximumValue="30"
                                                                 MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                                 Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:RangeValidator><anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_dt_ini"
                                                                ControlToValidate="txt_dt_fim" ErrorMessage="O campo 'Dia Final do Período para Coletas&quot; deve ser maior ou igual ao &quot;Dia Inicial do Período para Coletas'."
                                                                Operator="GreaterThanEqual" ToolTip="O campo 'Dia Final do Período para Coletas&quot; deve ser maior ou igual ao &quot;Dia Inicial do Período para Coletas'."
                                                                Type="Integer" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="texto" style="height: 15px">
                                            </td>
                                            <td >
                                            </td>
                                        </tr>

									    <TR id="tr_dados_sitema" runat="server">
										    <TD colSpan="2" class="texto">
											    <TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
												    <TR>
													    <TD class="titmodulo" width="23%" colSpan="2" >Dados do Sistema</TD>
												    </TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação Coleta Manual:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList></td>
                                                    </tr>
												    <TR>
													    <TD class="texto" align="right">
                                                            <strong>Modificador:</strong></TD>
													    <TD style="height: 22px" >&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
												    </TR>
												    <TR>
													    <TD class="texto" align="right" >
                                                            <strong>Data Modificação:</strong></TD>
													    <TD style="height: 22px" >&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
												    </TR>
											    </TABLE>
										    </TD>
									    </TR>
								    </TABLE>

								</TD>
								<TD width="1" bgColor="#d0d0d0"></TD>
							</TR>
							<TR>
								<TD bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
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
					<TD style="width: 7px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
           <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
                <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
