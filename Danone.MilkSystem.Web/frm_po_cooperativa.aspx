<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_po_cooperativa.aspx.vb" Inherits="frm_po_cooperativa" %>

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
    <title>PO Cooperativa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>PO Cooperativa</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="height: 25px;" vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
                                    &nbsp;|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<tr>
				<td></td>
				<td>									<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="width: 23%"> Descrição</TD>
													</TR>
                    <tr>
                        <td align="right" class="texto" style="width: 23%; height: 25px">
                            <strong><span style="color: #ff0000">*</span>Estabelecimento:</strong></td>
                        <td style="height: 25px">
                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoPostBack="True"
                                CssClass="texto">
                            </anthem:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span class="obrigatorio">*</span><strong>Cooperativa:</strong></td>
                                                        <td >
                                                            &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="10" Width="64px"></anthem:TextBox>&nbsp;
                                                            <anthem:ImageButton ID="bt_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                ToolTip="Filtrar Técnicos" Width="15px" />
                                                            <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_pessoa"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cooperativa para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Cooperativa deve ser informada">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cmv_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" ErrorMessage="Cooperativa não cadastrado." Font-Bold="True" SetFocusOnError="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Cooperativa não cadastrada!" ControlToValidate="txt_cd_pessoa">[!]</anthem:CustomValidator></td>
                                                    </tr>
                    <tr>
                        <td align="right" class="texto" style="width: 23%">
                            <strong><span style="color: #ff0000">*</span>Tipo de Leite:</strong></td>
                        <td>
                            &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                CssClass="texto">
                            </anthem:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cbo_id_item"
                                CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%;">
                                                            <span class="obrigatorio">*</span><strong>Data Inicial:</strong></td>
                                                        <td >
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                                                Width="65px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_inicio"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Inicial para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Data Inicial deve ser informada.">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_dt_fim"
                                                                ControlToValidate="txt_dt_inicio" CssClass="texto" ErrorMessage="A Data Inicial deve ser menor que a Data Final."
                                                                Operator="LessThanEqual" ToolTip="Data Inicial deve ser menor que a Data Final." AutoUpdateAfterCallBack="True" Type="Date" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%;">
                                                            <span class="obrigatorio">*</span><strong>Data Final:</strong></td>
                                                        <td >
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_fim" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" DateMask="DayMonthYear" Width="65px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_dt_fim"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Final para continuar." Font-Bold="True"
                                                                ToolTip="Data Final deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%"  >
                                                        <span class="obrigatorio">*</span><strong>Nr. PO:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:TextBox ID="txt_nr_po" runat="server" CssClass="texto" MaxLength="10"
                                                                Width="72px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_nr_po"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nr. PO para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Nr. PO deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" style="width: 23%">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="width: 23%">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%" style="width: 23%;">
                                                                        <strong>Situação:</strong></td>
                                                                    <td style="height: 21px">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%" style="width: 23%">
                                                                        <strong>Modificador:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="width: 23%">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
														
													</TR>
												</TABLE>
</td>
				<td></td>
				</tr>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
														<TABLE id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a"  vAlign="middle" align="left"
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
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
