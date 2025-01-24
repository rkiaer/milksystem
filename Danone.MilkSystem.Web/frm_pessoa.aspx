<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_pessoa.aspx.vb" Inherits="frm_pessoa" %>

<%@ Register Assembly="RK.TextBox.CNPJ" Namespace="RK.TextBox.CNPJ" TagPrefix="cc8" %>

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
    <title>frm_pessoa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	<script type="text/javascript"> 

    function ShowDialogContrato() 
    
    {
        var retorno="";
   	    var szUrl;
        var hf_id_contrato = document.getElementById("hf_id_contrato");
   	    var idcboestabel
   	    idcboestabel = document.getElementById("cbo_estabelecimento").value;

        szUrl = 'lupa_contrato.aspx?id='+idcboestabel+'';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:700px;edge:raised;dialogHeight:600px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_contrato.value=retorno;
        } 
    }            

</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Fornecedor</STRONG></TD>
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
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:LinkButton ID="lk_modelo_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                        Enabled="False" Visible="False">Modelo de Contrato</anthem:LinkButton>
                                    &nbsp;
                                    | &nbsp;<asp:LinkButton ID="lk_propriedades" runat="server">Propriedades</asp:LinkButton>
                                    &nbsp;</TD>
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
														<TD class="titmodulo" width="25%" colSpan="2"> Descrição</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%"></TD>
														<TD width="77%"></TD>
													</TR>
													<TR id="trContratoRelacionado" runat="server">
														<TD class="texto" align="right" width="23%"><span class="obrigatorio">*</span>&nbsp;<STRONG>Código:</STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" MaxLength="10" Enabled="False"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_pessoa"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Código SAP:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_codigo_SAP" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="10" Width="25%"></anthem:TextBox></td>
                                                    </tr>
													<TR id="tr_contrato" runat="server" width="23%">
														<TD class="texto" style="HEIGHT: 17px" align="right" width="23%"><STRONG>Categoria:</STRONG></TD>
														<TD style="HEIGHT: 17px">&nbsp;<anthem:DropDownList ID="cbo_categoria" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True" Enabled="False">
                                                            <asp:ListItem Value="F">F&#237;sica</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="J">Juridica</asp:ListItem>
                                                            </anthem:DropDownList></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Nome:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="60%" MaxLength="60" Enabled="False"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nm_pessoa"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nome Abreviado:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_abreviado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="20" Width="25%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Estabelecimento:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Grupo:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_grupo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_grupo"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Grupo para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2">
                                                            Dados Pessoa Jurídica</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>CNPJ:</strong></TD>
														<TD>&nbsp;<cc1:CNPJTextBox ID="txt_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ErrorMessage="CNPJ Inválido." Width="25%" Enabled="False"></cc1:CNPJTextBox><anthem:RequiredFieldValidator ID="rfv_cnpj" runat="server" ControlToValidate="txt_cnpj"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CNPJ para continuar." Font-Bold="True" Enabled="False" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Empresa Nacional:</strong></TD>
														<TD>&nbsp;<anthem:DropDownList ID="cbo_empresa_nacional" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="56px" Enabled="False">
                                                            <asp:ListItem Selected="True" Value="S">Sim</asp:ListItem>
                                                            <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                                        </anthem:DropDownList></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Inscrição Estadual:</strong></TD>
														<TD>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_inscricao_estadual" runat="server" CssClass="texto"
                                                                Width="25%" MaxLength="20" Enabled="False"></cc3:OnlyNumbersTextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Inscrição Municipal:</strong></TD>
														<TD>
															<P>
																&nbsp;<cc3:OnlyNumbersTextBox ID="txt_inscricao_municipal" runat="server" CssClass="texto"
                                                                    Width="25%" MaxLength="20" Enabled="False"></cc3:OnlyNumbersTextBox></P>
														</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" style="height: 15px" colspan="2">
                                                            Dados Pessoa Física</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>RG:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_rg" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Width="25%" MaxLength="15"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Orgão Emissor:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_orgao_emissor" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="13%" MaxLength="10"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>CPF:</strong></TD>
														<TD>
                                                            &nbsp;<cc2:CPFTextBox ID="txt_cpf" runat="server" AutoUpdateAfterCallBack="True"
                                                                Enabled="False" ErrorMessage="CPF Inválido." Width="25%" CssClass="texto"></cc2:CPFTextBox>
                                                            <anthem:RequiredFieldValidator ID="rfv_cpf" runat="server" ControlToValidate="txt_cpf"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CPF para continuar." Font-Bold="True" Enabled="False" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Data Nascimento:</strong></TD>
														<TD>&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_nascimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Sexo:</strong></TD>
														<TD>&nbsp;<anthem:DropDownList ID="cbo_sexo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="104px">
                                                            <asp:ListItem Selected="True" Value="O">[Selecione]</asp:ListItem>
                                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                            <asp:ListItem Value="F">Feminino</asp:ListItem>
                                                        </anthem:DropDownList>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Nacionalidade:</strong></TD>
														<TD>&nbsp;<anthem:DropDownList ID="cbo_nacionalidades" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                        </anthem:DropDownList></TD>
													</TR>
													<TR id="tr_grau_instrucao" runat="server" visible="false">
														<TD class="texto" style="HEIGHT: 18px" align="right" width="23%">
                                                            <strong>Grau de Instrução:</strong></TD>
														<TD style="HEIGHT: 18px">&nbsp;<anthem:DropDownList ID="cbo_grau_instrucao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" Visible="false">
                                                        </anthem:DropDownList></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nr de Dependentes:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_dependentes" runat="server" CssClass="texto" MaxLength="2" Width="48px"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
													<TR>
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
                                                                CssClass="texto" Width="60%" MaxLength="60" Enabled="False"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Numero:</strong></TD>
														<TD>&nbsp;<cc3:OnlyNumbersTextBox ID="txt_numero" runat="server" CssClass="texto" Width="8%" MaxLength="6" Enabled="False"></cc3:OnlyNumbersTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Complemento:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_complemento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="30" Enabled="False"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Bairro:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_bairro" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="40" Enabled="False"></anthem:TextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True" Enabled="False">
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
                                                                CssClass="texto" Width="12%" MaxLength="9" Enabled="False"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Caixa Postal:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_caixa_postal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="15" Enabled="False"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 1:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_telefone1" runat="server" CssClass="texto" Width="128px" Enabled="False"></anthem:TextBox>
                                                            <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_telefone2"
                                                                ControlToValidate="txt_telefone1" CssClass="texto" ErrorMessage="Telefone 1 não pode ser igual ao Telefone 2."
                                                                Font-Bold="True" Operator="NotEqual" ValidationGroup="vg_salvar">[!]</anthem:CompareValidator></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Telefone 2:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_telefone2" runat="server" CssClass="texto" MaxLength="30"
                                                                Width="128px" Enabled="False"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Fax:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_fax" runat="server" CssClass="texto" MaxLength="30"
                                                                Width="128px" Enabled="False"></anthem:TextBox>
															</TD>
													</TR>
													                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Celular:</strong></td>
                                                        <TD style="HEIGHT: 22px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_celular_ddd" runat="server" CssClass="texto"
                                                                MaxLength="3" Width="25px"></cc3:OnlyNumbersTextBox>
                                                            <cc3:OnlyNumbersTextBox ID="txt_celular" runat="server" CssClass="texto" MaxLength="9"
                                                                Width="92px"></cc3:OnlyNumbersTextBox>
                                                            <anthem:Label ID="lbl_formato" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Italic="True" ForeColor="Red" UpdateAfterCallBack="True">ddd + celular (apenas números)</anthem:Label>
                                                            <anthem:CustomValidator ID="cv_celular" runat="server" CssClass="texto" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>
                                                        </td>
                                                    </tr>

													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>e-mail:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_email" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="50" Enabled="False"></anthem:TextBox>
                                                            <anthem:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="txt_email" CssClass="texto" ErrorMessage="Formato de e-mail inválido."
                                                                Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vg_salvar">[!]</anthem:RegularExpressionValidator></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>e-mail2:</strong></td>
                                                        <TD style="HEIGHT: 22px">
                                                            &nbsp;<anthem:TextBox ID="txt_ds_email2" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="50" Width="40%"></anthem:TextBox>
                                                            <anthem:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                ControlToValidate="txt_ds_email2" CssClass="texto" ErrorMessage="Formato de e-mail inválido."
                                                                Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vg_salvar">[!]</anthem:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong>Contato:</strong></td>
                                                        <TD>
                                                            &nbsp;<anthem:TextBox ID="txt_ds_contato" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="100" Width="40%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong>Distância:</strong></td>
                                                        <TD>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_distancia" runat="server" CssClass="texto"
                                                                Width="96px" MaxCaracteristica="10" MaxMantissa="3" Enabled="False" AutoUpdateAfterCallBack="True" ></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr >
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong>Valor Pedágio Eixo:</strong></td>
                                                        <TD>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_pedagio_eixo_cooperativa" runat="server" CssClass="texto"
                                                                Width="96px" MaxCaracteristica="10" MaxMantissa="2" Enabled="False" AutoUpdateAfterCallBack="True" ></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 6px" width="23%">
                                                        </td>
                                                        <td style="height: 6px">
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Dados Bancários</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Tipo Conta:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_conta" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList></td>
                                                    </tr>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Banco:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_bancos" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" vAlign="top" align="right" width="23%">
                                                            <strong>Agência:</strong></td>
                                                        <TD align="left">
                                                            &nbsp;<anthem:TextBox ID="txt_cd_agencia" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="10" Width="12%" Enabled="False"></anthem:TextBox>
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="texto" vAlign="top" align="right" width="23%">
                                                            <strong>Conta:</strong></TD>
														<TD align="left">&nbsp;<anthem:TextBox ID="txt_conta" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="10" Enabled="False"></anthem:TextBox>
															</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" valign="top" width="23%">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" valign="top" colspan="2">
                                                            Controle Interno</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>SIF:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_sif" runat="server" CssClass="texto" Width="27%" MaxLength="40"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Expiração do DQSE:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_expiracao_dqse" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                    </tr>
                                                    <tr id="tr_valor_disponivel" runat="server" visible="false">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor Disponível:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor_disponivel" runat="server" CssClass="texto"
                                                                Width="96px" MaxCaracteristica="12" MaxMantissa="2" Enabled="False" Visible="False"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Homologação:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_pessoa_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_pessoa_situacao"
                                                                CssClass="texto" ErrorMessage="Selecione uma Situação da Pessoa para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                                        <strong>Agropecuária:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_emite_nota_fiscal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                            <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                            <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                        </anthem:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Acordo para Aquisição Insumos:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_st_acordo_aquisicao_insumos" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                            <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                            <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                        </anthem:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Data de Adesão:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_adesao_acordo_insumos" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <TD class="texto" align="right" width="23%">
                                                                        <strong>Número do Contrato:</strong></td>
                                                                    <TD>
                                                                        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_contrato" runat="server" CssClass="texto" MaxLength="15" Width="17%"></cc3:OnlyNumbersTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Cluster:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_cluster" runat="server"
                                                                CssClass="texto" Enabled="False">
                                                                        </anthem:DropDownList>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <span style="color: #ff0000">
                                                                            <strong><span style="color: #000000">Contrato:</span></strong></span>&nbsp;
                                                                    </td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:TextBox ID="txt_cd_contrato" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" MaxLength="4" Width="50px" Enabled="False"></anthem:TextBox>
                                                                        <anthem:Label ID="lbl_nm_contrato" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                                        <anthem:Label ID="lbl_contrato_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Font-Italic="True" ForeColor="Red" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong><span style="color: #000000">Adicional de Volume Cálculo:</span></strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_adicional_volume" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                            <asp:ListItem Value="24">24hrs</asp:ListItem>
                                                                            <asp:ListItem Value="48">48hrs</asp:ListItem>
                                                                        </anthem:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong><span style="color: #000000">Recolhimento FUNRURAL Cálculo:</span></strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_st_funrural" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                            <asp:ListItem Value="D" Selected="True">DANONE</asp:ListItem>
                                                                            <asp:ListItem Value="P">PRODUTOR</asp:ListItem>
                                                                        </anthem:DropDownList></td>
                                                                </tr>
                                                                                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Exceção para Prazo de Pagamento:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_excecao_prazo_pagto" runat="server"
                                                                CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                            </anthem:DropDownList>
                                                        </td>
                                                    </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="titmodulo" valign="top" colspan="2">
                                                                        Controle Interno &nbsp;- &nbsp;Transportador</td>
                                                                </tr>
                                                                <tr><td align="right" class="texto" width="23%">
                                                                        <strong>Transportador Central de Compras:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_st_transportador_central" runat="server"
                                                                CssClass="texto">
                                                                            <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                            <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                        </anthem:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" width="23%">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="titmodulo" valign="top" colspan="2">
                                                                        Controle Interno&nbsp; -&nbsp; Fornecedor de Insumos</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Frete CIF Central de Compras:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_st_frete_cif" runat="server"
                                                                CssClass="texto">
                                                                            <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                            <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                        </anthem:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Número de Parcelas Central de Compras:</strong></td>
                                                                    <td align="left">
                                                                        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_fornecedor_parcelas_central" runat="server"
                                                                            CssClass="texto" MaxLength="2" Width="5%"></cc3:OnlyNumbersTextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="right" class="texto" valign="top" width="23%">
                                                                    </td>
                                                                    <td align="left">
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
            <anthem:HiddenField ID="hf_id_contrato" runat="server" AutoUpdateAfterCallBack="True" />
        </form>
	</body>
</HTML>
