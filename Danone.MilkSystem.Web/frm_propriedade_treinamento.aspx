<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_propriedade_treinamento.aspx.vb" Inherits="frm_propriedade_treinamento" %>

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
    <title>Registrar Treinamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
<script type="text/javascript"> 
    function ShowDialogTreinamento() 
    {
        var retorno="";
   	    var szUrl;
        var hf_id_treinamento = document.getElementById("hf_id_treinamento");
   	     
        szUrl = 'lupa_treinamento.aspx';
            
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_treinamento.value=retorno;
        } 
    }            
</script>
	
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Registrar Treinamentos Realizados</STRONG></TD>
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
											<TD width="76%" style="height: 334px">
												<TABLE id="Table7" cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                    <tr>
                                                        <td class="titmodulo" colspan="2" width="25%">
                                                            Descrição</td>
                                                    </tr>
													<TR id="CodigoTecnico" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG>
                                                            Estabelecimento:</STRONG></TD>
														<TD width="77%">&nbsp;
                                                            <asp:Label ID="lbl_estabelecimento" runat="server" CssClass="texto" Height="16px"></asp:Label></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Produtor:</strong></td>
                                                        <td>
                                                            &nbsp;
                                                            <asp:Label ID="lbl_produtor" runat="server" CssClass="texto" Height="16px"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Propriedade:</strong></td>
                                                        <td>
                                                            &nbsp;
                                                            <asp:Label ID="lbl_propriedade" runat="server" CssClass="texto"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <strong>Treinamento:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_cd_treinamento" runat="server" CssClass="texto" MaxLength="7" Width="50px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc3:OnlyNumbersTextBox>
                                                            <anthem:Label ID="lbl_treinamento" runat="server" CssClass="texto" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                                            <anthem:ImageButton ID="btn_lupa_treinamento" runat="server" BorderStyle="None" Height="15px"
                                                                ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" Width="15px" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_cd_treinamento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código do Treinamento para continuar." Font-Bold="True" ToolTip="O campo Código do Treinamento é obrigatório!" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cv_treinamento" runat="server"
                                                                ErrorMessage="Treinamento não cadastrado." CssClass="texto" Font-Bold="True" ControlToValidate="txt_cd_treinamento" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" SetFocusOnError="True">[!]</anthem:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Data Início:</strong></td>
                                                        <td>
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox>
                                                            </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
														</TD>
													</TR>
												</TABLE>
                                                <table id="Table9" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td class="titmodulo" colspan="2" width="23%">
                                                            Dados do Sistema</td>
                                                    </tr>
                                                </table>
                                                <table id="Table6" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Situação:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                </table>
                                                <table id="Table8" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 21px">
                                                            <strong>Modificador:</strong></td>
                                                        <td style="height: 21px">
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
								<TD bgColor="#d0d0d0" style="width: 1px; height: 24px;"></TD>
								<TD style="height: 24px">
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
								<TD width="1" bgColor="#d0d0d0" style="height: 24px"></TD>
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
        <div visible="false">
            <anthem:HiddenField ID="hf_id_treinamento" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
                
                </form>
	</body>
</HTML>
