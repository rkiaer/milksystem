<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_motorista.aspx.vb" Inherits="frm_motorista" %>

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

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_transportador_cooperativa.aspx';
        
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Motorista</STRONG></TD>
					<TD>&nbsp;</TD>
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
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
                                    &nbsp;|&nbsp;
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
								<TD width="1" bgColor="#d0d0d0"></TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="76%">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2"> 
                                                            Dados Pessoa Física</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%"></TD>
														<TD width="77%"></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_motorista" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="60%" MaxLength="60"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nm_motorista"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <span class="obrigatorio">*</span> <STRONG>CNH:</STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_cnh" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" MaxLength="15"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_cnh"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CNH para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <span class="obrigatorio">*</span> <STRONG>Data Validade CNH:</strong></td>
                                                        <TD width="77%">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_validade_cnh" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="10" Width="90px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_validade_cnh"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data de Validade da CNH para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">* </span>Categoria CNH:</strong></td>
                                                        <TD>
                                                            &nbsp;<anthem:DropDownList ID="cbo_categoriacnh" runat="server"
                                                                CssClass="texto" Width="104px">
                                                                <asp:ListItem Selected="True" Value="O">[Selecione]</asp:ListItem>
                                                                <asp:ListItem Value="A">A</asp:ListItem>
                                                                <asp:ListItem Value="B">B</asp:ListItem>
                                                                <asp:ListItem>C</asp:ListItem>
                                                                <asp:ListItem>D</asp:ListItem>
                                                                <asp:ListItem>E</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_categoriacnh"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Categoria da CNH para continuar."
                                                                Font-Bold="True" ToolTip="Categoria da CNH deve ser informada." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Data Nascimento:</strong></TD>
														<TD>&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_nascimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="90px" MaxLength="10"></cc4:OnlyDateTextBox></TD>
                                                    </tr>
                                                    <tr>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Sexo:</strong></TD>
														<TD>&nbsp;<anthem:DropDownList ID="cbo_sexo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="104px">
                                                            <asp:ListItem Selected="True" Value="O">[Selecione]</asp:ListItem>
                                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                            <asp:ListItem Value="F">Feminino</asp:ListItem>
                                                        </anthem:DropDownList>
															</TD>
                                                    </tr>
                                                    <tr id="tr_grau_instrucao" runat="server" visible="false">
														<TD class="texto" style="HEIGHT: 18px" align="right" width="23%">
                                                            <strong>Grau de Instrução:</strong></TD>
														<TD style="HEIGHT: 18px">&nbsp;<anthem:DropDownList ID="cbo_grau_instrucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                        </anthem:DropDownList></TD>
                                                    </tr>
                                                    <tr id="tr_nr_dependentes" runat="server" visible="false">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nr de Dependentes:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_dependentes" runat="server" CssClass="texto" MaxLength="2" Width="48px"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>RG:</strong></td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:TextBox ID="txt_rg" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Width="20%" MaxLength="15"></anthem:TextBox>
                                                            &nbsp; &nbsp; <strong>Órgão Emissor:</strong><span style="font-size: 7pt; font-family: Verdana">
                                                            &nbsp;<anthem:TextBox ID="txt_orgao_emissor" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="10%" MaxLength="5"></anthem:TextBox></span> <span class="texto"
                                                                    style="font-size: 7pt">&nbsp; &nbsp; <strong>Data Exp.:</strong> </span>
                                                            <cc4:OnlyDateTextBox ID="txt_dt_expedicao_rg" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="10" Width="90px"></cc4:OnlyDateTextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>CPF:</strong></TD>
														<TD>
                                                            &nbsp;<cc2:CPFTextBox ID="txt_cpf" runat="server" AutoUpdateAfterCallBack="True" ErrorMessage="CPF Inválido." Width="25%" CssClass="texto"></cc2:CPFTextBox>
                                                            </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Transportador:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                                                AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>
                                                            &nbsp;
                                                            <anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                ToolTip="Filtrar Transportadores" Width="15px" />
                                                            <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                            <asp:CustomValidator ID="cv_transportador" runat="server" CssClass="texto" ErrorMessage="Transportador não cadastrado!"
                                                                Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar" ControlToValidate="txt_cd_transportador"></asp:CustomValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_transportador"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Transportador para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    
												<TR id="tr_logradouro" runat="server" visible="false">
												<td colspan=2>
												<table width="100%">
													<tr>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Logradouro</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 15px" align="right" width="23%"></TD>
														<TD style="HEIGHT: 15px">&nbsp;
															</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Endereço:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_endereco" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="60%" MaxLength="60"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Numero:</strong></TD>
														<TD>&nbsp;<cc3:OnlyNumbersTextBox ID="txt_numero" runat="server" CssClass="texto" Width="8%" MaxLength="6"></cc3:OnlyNumbersTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Complemento:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_complemento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="30"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Bairro:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_bairro" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="40"></anthem:TextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                        </anthem:DropDownList></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Cidade:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>CEP:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_cep" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="9"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 1:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<cc5:PhoneTextBox ID="txt_telefone1" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox>
                                                            </TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 2:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<cc5:PhoneTextBox ID="txt_telefone2" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 3:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<cc5:PhoneTextBox ID="txt_telefone3" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>e-mail:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_email" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="50"></anthem:TextBox>
                                                            </TD>
													</TR>
													    
										        </table>
												</td>
											</TR>
                                                    													<TR id="tr_esalq" runat="server">
														<TD colSpan="2">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">
                                                                        ESALQ</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Treinamento ESALQ:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:TextBox ID="txt_treinamento_esalq" runat="server" CssClass="texto"
                                                                            MaxLength="500" Rows="7" TextMode="MultiLine" Width="75%"></anthem:TextBox></td>
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
												</TABLE>
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
