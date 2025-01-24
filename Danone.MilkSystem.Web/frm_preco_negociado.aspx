<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_preco_negociado.aspx.vb" Inherits="frm_preco_negociado" %>

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

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Preço Negociado</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
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
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Cluster:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_cluster" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 18%;">
                                                            <span class="obrigatorio">*</span><strong>Mês /Ano:</strong></td>
                                                        <td >
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="texto" DateMask="MonthYear"
                                                                Width="65px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_MesAno"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Mês /Ano para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 18%">
                                                            <span class="obrigatorio">*</span><strong>Técnico:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="10" Width="48px"></anthem:TextBox>&nbsp;
                                                            <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Height="16px" UpdateAfterCallBack="True" Visible="False" Width="224px"></anthem:Label>
                                                            &nbsp;<anthem:ImageButton ID="bt_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                ToolTip="Filtrar Técnicos" Width="15px" />
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_tecnico"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Técnico para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cmv_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" ErrorMessage="Técnico não cadastrado." Font-Bold="True" SetFocusOnError="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Técnico não cadastrado!">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span><strong>Propriedade:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_propriedade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Propriedade para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Volume(lts):</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_volume" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Preço Base:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_preco_base" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Adicional Volume:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_adic_volume" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Adicional Região:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_adic_regiao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Adicional Mercado:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_adic_mercado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Subtotal:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_subtotal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                        <span class="obrigatorio">*</span><strong>Negociado:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor_negociado" runat="server" CssClass="texto"
                                                                Width="65px" MaxCaracteristica="10" MaxMantissa="4" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_valor_negociado"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Negociado para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Variação:</strong></td>
                                                        <td width="77%" align="left">
                                                            &nbsp;<anthem:Label ID="lbl_nr_variacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Justificativa:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_justificativa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 18px">
                                                            <anthem:Label ID="lbl_status" runat="server" AutoUpdateAfterCallBack="True" CssClass="textobold"
                                                                UpdateAfterCallBack="True" Visible="False">Status:</anthem:Label></td>
                                                        <td style="height: 18px">
                                                            <anthem:Label ID="lbl_nm_status" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True" Visible="False"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px" width="20%">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
