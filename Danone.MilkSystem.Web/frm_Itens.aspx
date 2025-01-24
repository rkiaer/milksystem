<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_Itens.aspx.vb" Inherits="frm_Itens" %>

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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Item</STRONG></TD>
					<TD>&nbsp;</TD>
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
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" >Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4" style="height: 25px">
                                   <asp:LinkButton ID="lk_parceiros" runat="server">Parceiros</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>								
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
                                                    <tr>
                                                        <td align="right" class="titmodulo" colspan="2" style="text-align: left" width="23%">
                                                            Descrição</td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" style="width: 23%">
                                                            </TD>
														<TD width="77%"></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 24px;">
                                                            <span class="obrigatorio">*<span style="color: #000000">Código Item</span></span><strong>:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:TextBox ID="txt_cd_item" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="130px" MaxLength="16"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_item"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 24px;">
                                                            <span class="obrigatorio"><span style="color: #000000">Código Item SAP</span></span><strong>:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<anthem:TextBox ID="txt_cd_item_sap" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="18" Width="130px"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span class="obrigatorio">*</span> <strong>Nome do Item<strong>:</strong></strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nm_item" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="300px" MaxLength="100"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_nm_item"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong><span style="color: #ff0000">* </span>Unidade de Medida:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_unidade_medida" runat="server" CssClass="texto" Width="120px">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_unidade_medida"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Unidade de Medida para continuar."
                                                                Font-Bold="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong><span style="color: #ff0000"> </span>Código do Grupo:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_cd_grupo" runat="server" CssClass="texto" Width="300px">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="rfv_cd_grupo" runat="server" ControlToValidate="cbo_cd_grupo"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código Grupo para continuar."
                                                                Font-Bold="True" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Classificação Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:TextBox ID="txt_classificacao_fiscal" runat="server" CssClass="texto" MaxLength="8" Width="120px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Depósito: </strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_deposito" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="3" Width="6%"></anthem:TextBox>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Central de Compras:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:RadioButton ID="rb_central_compras_sim" runat="server" CssClass="texto" GroupName="central"
                                                                Text="Sim" Checked="True" AutoPostBack="True" />&nbsp;<asp:RadioButton ID="rb_central_compras_nao" runat="server" CssClass="texto"
                                                                    GroupName="central" Text="Não" AutoPostBack="True" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Código Conta:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_cd_conta" runat="server" CssClass="texto" Width="300px">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="rfv_cd_conta" runat="server" ControlToValidate="cbo_cd_conta"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código Conta para continuar."
                                                                Font-Bold="True" AutoUpdateAfterCallBack="True">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Categoria:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_categoria" runat="server" CssClass="texto" Width="300px">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_categoria"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Categoria para continuar." Font-Bold="True"
                                                                ToolTip="O campo Categoria deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Canal:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_canal" runat="server" CssClass="texto" Width="300px">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="cbo_canal" CssClass="texto" ErrorMessage="Preencha o campo Canal para continuar."
                                                                Font-Bold="True" ToolTip="O campo Canal deve ser informado.">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Visualizar Item Web:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_visualizar_item_web" runat="server" CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Participa Importação Fomentos:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_importar_pedido" runat="server" CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Descrição:</strong></td>
                                                        <td style="width: 77%">
                                                            &nbsp;<asp:TextBox ID="txt_ds_descricao" runat="server" MaxLength="400" Rows="7"
                                                                TextMode="MultiLine" Width="650px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 23px; width: 23%;">
                                                        </td>
                                                        <td style="height: 23px">
                                                        </td>
                                                    </tr>
												</TABLE>
                                                <table id="Table9" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td class="titmodulo" colspan="2" width="23%">
                                                            Dados do Sistema</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação:</strong></td>
                                                        <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                        </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Modificador:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto">
                                                            <strong>Data Modificação:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
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
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" >Salvar</asp:LinkButton></TD>
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
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages></form>
	</body>
</HTML>
