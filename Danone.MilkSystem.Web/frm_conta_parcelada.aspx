<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_conta_parcelada.aspx.vb" Inherits="frm_conta_parcelada" %>

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
    <title>Conta Parcelada</title>
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Parcelamentos</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; | &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#d0d0d0" style="width: 3px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>
                                                    <tr >
                                                        <td align="right" class="texto" width="23%" style="height: 18px">
                                                            <anthem:Label ID="lbl_estabelecimento" runat="server" CssClass="textobold" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False">Estabelecimento:</anthem:Label></td>
                                                        <td style="height: 18px">
                                                            <anthem:Label ID="lbl_nm_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr >
                                                        <td align="right" class="texto" width="23%" style="height: 18px">
                                                            <anthem:Label ID="lbl_produtor" runat="server" CssClass="textobold" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Visible="False">Produtor:</anthem:Label></td>
                                                        <td style="height: 18px">
                                                            <anthem:Label ID="lbl_nm_produtor" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr >
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Propriedade:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="texto" MaxLength="7" Width="48px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                                            &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Visible="False" Width="160px" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;<anthem:ImageButton ID="btn_lupa_propriedade" runat="server" BorderStyle="None" Height="15px"
                                                                ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" Width="15px" AutoUpdateAfterCallBack="True" />
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_cd_propriedade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Propriedade para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cmv_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Propriedade não cadastrada." SetFocusOnError="True" CssClass="texto" Font-Bold="True" ToolTip="Propriedade não cadastrada!" ValidationGroup="vg_salvar" ControlToValidate="txt_cd_propriedade">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong><span style="color: #ff0000">*</span>Conta:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_conta" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_conta"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Conta para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" Display="Dynamic" ToolTip="A conta é obrigatória!">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Valor Total:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor_total" runat="server" CssClass="texto"
                                                                Width="96px" MaxCaracteristica="12" MaxMantissa="2"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Início do Desconto:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_incio_desconto" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Taxa:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_taxa" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                                MaxMantissa="4"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Quantidade de Parcelas:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_qtd_parcela" runat="server" CssClass="texto"
                                                                Width="8%" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Valor Parcela:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor_parcela" runat="server" CssClass="texto"
                                                                Width="96px" MaxCaracteristica="12" MaxMantissa="2" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px" width="20%">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
													<TR id="tr_romaneio" runat="server" visible="false">
														<TD colSpan="2">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Romaneio</TD>
																</TR>
															<tr >
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                            <strong>Romaneio:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:Label ID="lbl_romaneio" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                                <tr>
																	<TD class="texto" align="right" width="23%">
                                                                        <strong>Placa:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
                                                                </tr>
                                                                <tr>
																	<TD class="texto" align="right">
                                                                        <strong>Compartimento:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_nr_compartimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 18px" width="23%">
                                                                        <strong>Volume Coletado Compartimento:</strong></td>
                                                                    <td style="height: 18px">
                                                                        &nbsp;<anthem:Label ID="lbl_nr_litros_compartimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Volume Rejeitado Compartimento:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:Label ID="lbl_nr_litros_rejeitado" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Volume Total de Leite a Pagar:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:Label ID="nr_litros_total_a_pagar" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
															</TABLE>
														</TD>
													</TR>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%">
                                                                        <strong>Modificador:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="23%">&nbsp;</TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
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
					<TD style="width: 9px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
