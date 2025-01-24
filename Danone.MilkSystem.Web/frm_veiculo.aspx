<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_veiculo.aspx.vb" Inherits="frm_veiculo" %>

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
           	     
        szUrl = 'lupa_transportador.aspx';
        
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Veículos</STRONG></TD>
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
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                    <asp:LinkButton ID="lk_compartimento" runat="server">Compartimentos</asp:LinkButton>&nbsp;&nbsp;</TD>
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
													<TR id="CodigoTecnico" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG>
                                                            <anthem:Label ID="lbl_cd_veiculo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True">Código:</anthem:Label></STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_cd_veiculo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" Enabled="False"></anthem:TextBox>
                                                            </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span class="obrigatorio">*</span>&nbsp;<strong>Placa:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_placa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="25%" MaxLength="7"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_placa"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Placa para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" style="height: 15px" colspan="2">
                                                            Dados Veículo</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                        </td>
                                                        <td style="height: 23px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Marca:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_marca" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Width="39%" MaxLength="30"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Modelo:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:TextBox ID="txt_modelo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="39%" MaxLength="50"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Ano Fabricação:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ano_fabricacao" runat="server" CssClass="texto"
                                                                Width="8%" MaxLength="4"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%" style="height: 23px">
                                                            <strong>Ano Modelo:</strong></TD>
														<TD style="height: 23px">&nbsp;<cc3:OnlyNumbersTextBox ID="txt_ano_modelo" runat="server" CssClass="texto"
                                                                Width="8%" MaxLength="4"></cc3:OnlyNumbersTextBox></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Chassi:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_chassi" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="30"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Renavan:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_renavam" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="20"></anthem:TextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Tara:</strong></td>
                                                        <TD>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_tara" runat="server" CssClass="texto" Width="8%" MaxCaracteristica="10" MaxMantissa="4"></cc6:OnlyDecimalTextBox></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong>Qtde Compartimentos:</strong></td>
                                                        <TD>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_qtd_compartimentos" runat="server" CssClass="texto"
                                                                Width="8%" MaxLength="1"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                        </anthem:DropDownList>
                                                            </TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong>Cidade:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList>
                                                            </TD>
													</TR>
													<TR id="TrProdutor" runat="server">
														<TD class="texto" align="right" width="23%" >
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Transportador:</strong></TD>
														<TD >
    										                &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" CssClass="texto" Width="64px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="14"></anthem:TextBox>
											                &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" CssClass="texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                                                  <anthem:ImageButton ID="btn_lupa_transportador" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Transportadores" Width="15px" AutoUpdateAfterCallBack="true" />
                                                                  <asp:CustomValidator ID="cv_transportador" runat="server" ErrorMessage="Transportador não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_cd_transportador"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Transportador para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Proprietário do Tanque:</strong></td>
                                                        <TD class="texto" style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_proprietario_tanque" runat="server"
                                                                CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                                                <asp:ListItem Value="D">Danone</asp:ListItem>
                                                                <asp:ListItem Value="T">Transportador</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_proprietario_tanque"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Proprietário do Tanque para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</anthem:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Tipo do Caminhão:</strong></td>
                                                        <TD class="texto" style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_equipamento" runat="server"
                                                                CssClass="texto" AutoCallBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_tipo_equipamento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo de Veículo para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cv_tipo_equipamento" runat="server" CssClass="texto" ErrorMessage="O Tipo de Veículo selecionado está desativado!"
                                                                Font-Bold="true" Text="[!]" ToolTip="O Tipo de Equipamento selecionado está desativado!"
                                                                ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                            <anthem:Label ID="lbl_nm_tipo_equipamento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
													
                                                    <tr>
                                                        <td align="right" width="20%">
                                                        </td>
                                                        <td>
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
                <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
                </form>
            

	</body>
</HTML>
