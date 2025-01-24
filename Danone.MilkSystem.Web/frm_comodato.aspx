<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_comodato.aspx.vb" Inherits="frm_comodato" %>

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

    function ShowDialogProdutor() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_produtor.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_pessoa.value=retorno;
        } 
    }            
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Equipamento</STRONG></TD>
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
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
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
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>

                                                    <tr>
                                                        <td  align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>
                                                                <anthem:Label ID="label_codigo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                    UpdateAfterCallBack="True" Visible="False">Código:</anthem:Label></strong></td>
                                                        <td style="height: 15px" width="77%">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_cd_comodato" runat="server" CssClass="texto"
                                                                Width="12%" MaxLength="10" Enabled="False" AutoUpdateAfterCallBack="True" Wrap="False" Visible="False"></cc3:OnlyNumbersTextBox>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Descrição:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:TextBox ID="txt_nm_comodato" runat="server" CssClass="texto" Width="232px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nm_comodato"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome  para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 23px" width="23%">
                                                        </td>
                                                        <td style="height: 23px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                            Dados do Equipamento</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Nome do Fabricante:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_fabricante" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="60" Width="52%"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nm_fabricante"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome do Fabricante  para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Modelo:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_modelo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="50" Width="39%"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_nm_modelo"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Modelo  para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span> <strong>Número de Série:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_serie" runat="server" CssClass="texto" MaxLength="20"></cc3:OnlyNumbersTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_nr_serie"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Número de Série para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            &nbsp;<strong>Capacidade:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_capacidade" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="72px"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Qtde Ordenhas/dia:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_qtde_ordenhas_dia" runat="server" CssClass="texto"
                                                                MaxLength="5" Width="48px"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Voltagem:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_voltagem" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 23px" width="23%">
                                                        </td>
                                                        <td style="height: 23px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                            Dados da Nota Fiscal</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nr. Nota Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_nota_fiscal" runat="server" CssClass="texto"
                                                                MaxLength="20"></cc3:OnlyNumbersTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Série Nota Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nr_serie_nota_fiscal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="20" Width="33%"></anthem:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Data Emissão Nota Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_emissao_nota_fiscal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="72px"></cc4:OnlyDateTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor Equipamento:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor" runat="server" CssClass="texto" MaxCaracteristica="12"
                                                                MaxLength="15" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr id="tr_nota_fiscal" runat="server" visible="false">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nr. Nota Fiscal de Devolução:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_nota_fiscal_devolucao" runat="server" CssClass="texto"
                                                                MaxLength="20" Width="112px"></cc3:OnlyNumbersTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="dt_nota_fiscal" runat="server" visible="false">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Data Nota Fiscal de Devolução:</strong></td>
                                                        <td>
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_nota_fiscal_devolucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="72px"></cc4:OnlyDateTextBox></td>
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
                                                                <tr>
                                                                    <td align="left" class="titmodulo" colspan="2" style="height: 15px">
                                                                        Informações Importantes</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%" style="height: 26px">
                                                                        <span class="obrigatorio">*</span> <strong>Proprietário do Equipamento:</strong></td>
                                                                    <td style="height: 26px">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_id_proprietario" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                                        </anthem:DropDownList>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="cbo_id_proprietario"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo Proprietário do Equipamento para continuar."
                                                                            Font-Bold="True" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 13px" width="23%">
                                                                        <strong>Produtor:</strong></td>
                                                                    <td style="height: 13px">
                                                                        &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                            CssClass="texto" Enabled="False" MaxLength="14" Width="64px"></anthem:TextBox>
                                                                        &nbsp;<anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                                        <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                                                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                            ToolTip="Filtrar Produtores" Width="15px" Visible="False" />
                                                                        <anthem:RequiredFieldValidator ID="rfv_produtor" runat="server" ControlToValidate="txt_cd_pessoa"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
                                                                            Font-Bold="True" ValidationGroup="vg_salvar" Visible="False" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator>
                                                                        <anthem:CustomValidator ID="cv_produtor" runat="server" CssClass="texto" ErrorMessage="Produtor não cadastrado!"
                                                                            Font-Bold="true" Text="[!]" ToolTip="Produtor Não Cadastrado!" ValidationGroup="vg_salvar"
                                                                            Visible="False" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_pessoa"></anthem:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr_nrcontrato" runat="server" visible="false">
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Nr. Contrato:</strong></td>
                                                                    <td>
                                                                        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_contrato" runat="server" CssClass="texto"
                                                                            MaxLength="20" Visible="false"></cc3:OnlyNumbersTextBox></td>
                                                                </tr>
                                                                <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Número Patrimônio:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_patrimonio" runat="server" CssClass="texto" Width="14%" MaxLength="10"></cc3:OnlyNumbersTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <span class="obrigatorio">*</span> <strong>Alocado:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_id_alocado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                            <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                            <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="[Selecione]">[Selecione]</asp:ListItem>
                                                                        </anthem:DropDownList>
                                                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cbo_id_alocado"
                                                                            CssClass="texto" ErrorMessage="Preencha o campo Alocado para continuar." Font-Bold="True"
                                                                            ValidationGroup="vg_salvar" InitialValue="[Selecione]">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="texto" align="right" width="23%">
                                                                        <STRONG></strong>
                                                                    </td>
                                                                    <TD width="77%">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
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
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
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
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />

                </form>
	</body>
</HTML>
