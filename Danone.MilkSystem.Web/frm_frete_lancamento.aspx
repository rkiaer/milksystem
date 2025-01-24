<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_frete_lancamento.aspx.vb" Inherits="frm_frete_lancamento" %>

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
    <title>Frete Lançamento</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script type="text/javascript"> 

    function ShowDialogCooperativa() 
    
    {       
        var retorno="";
   	    var szUrl;
        var hf_id_cooperativa = document.getElementById("hf_id_cooperativa");
           	     
        szUrl = 'lupa_coopertiva.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_cooperativa.value=retorno;
        } 
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");

        szUrl = 'lupa_transportador_cooperativa.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_transportador.value=retorno;
        } 
    }            
</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">


		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 3px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Lançamento para Cálculo de Frete</STRONG></TD>
					<TD style="width: 3px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 3px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
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
					<TD style="width: 3px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 3px">&nbsp;</TD>
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
													<TR>
														<TD class="texto" align="right" width="23%" style="height: 18px"><STRONG><span style="color: #ff0000">*</span><strong>Estabelecimento:</strong></STRONG></TD>
														<TD width="77%" style="height: 18px">&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server"
                                                                CssClass="texto">
                                                        </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="False" InitialValue="0" ToolTip="O Estabelecimento deve ser informado."
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong> <span style="color: #ff0000">*</span><strong> </strong>Transportador:</strong></td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                                                AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="72px"></anthem:TextBox>
                                                            &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                                                BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                ToolTip="Filtrar Produtores" Width="15px" />&nbsp;&nbsp;
                                                            <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;&nbsp;
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_cd_transportador"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Transportador para continuar."
                                                                Font-Bold="False" ToolTip="O Transportador deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                                                Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar"></anthem:CustomValidator>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 18px">
                                                            <strong><span style="color: #ff0000">*</span> Tipo de Frete:</strong></td>
                                                        <td style="height: 18px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipofrete" runat="server" CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                                                <asp:ListItem Value="1">T1</asp:ListItem>
                                                                <asp:ListItem Value="2">T2</asp:ListItem>
                                                                <asp:ListItem Value="3">T2 TP</asp:ListItem>
                                                                <asp:ListItem Value="4">T2 TVASE</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cbo_tipofrete"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo Frete para continuar." Font-Bold="False"
                                                                ToolTip="O TipoFrete deve ser informado." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 18px;">
                                                            <strong><strong>Cooperativa:</strong></strong></td>
                                                        <td style="height: 18px">
                                                            &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                                                AutoUpdateAfterCallBack="true" CssClass="texto" Enabled="False" MaxLength="6"
                                                                Width="72px"></anthem:TextBox>
                                                            &nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                                                BorderStyle="None" Enabled="False" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                                            <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                                            <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Bold="True" UpdateAfterCallBack="True">CNPJ:</anthem:Label>
                                                            <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;
                                                            <asp:RequiredFieldValidator ID="rf_cd_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa"
                                                                CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Código da Cooperativa para continuar ou selecione-o pela lupa."
                                                                Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa"
                                                                CssClass="texto" Enabled="False" ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False"
                                                                Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%; height: 24px;"><strong>Romaneio:</strong></td>
                                                        <td style="height: 24px" class="texto">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_romaneio" runat="server" CssClass="texto"
                                                                Width="72px"></cc3:OnlyNumbersTextBox>
                                                            &nbsp; ou &nbsp;
                                                            <anthem:CheckBox ID="chk_romaneio_todos" runat="server" AutoUpdateAfterCallBack="True"
                                                                Font-Bold="True" Text="Todos Romaneios?" TextAlign="Left" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <strong>Rota:</strong></td>
                                                        <td align="left" class="texto">
                                                            &nbsp;<anthem:TextBox ID="txt_rota" runat="server" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox>
                                                            &nbsp; ou &nbsp;
                                                            <anthem:CheckBox ID="chk_rotas_todas" runat="server" AutoUpdateAfterCallBack="True"
                                                                Font-Bold="True" Text="Todas Rotas?" TextAlign="Left" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Referência:</strong></td>
                                                        <td align="left" class="texto">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_ds_referencia" runat="server" CssClass="texto"
                                                                DateMask="MonthYear" Width="72px"></cc4:OnlyDateTextBox>&nbsp;
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_ds_referencia"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Referencia para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span id="Span3" class="obrigatorio">*</span><strong>Conta:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:DropDownList ID="cbo_conta" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_conta"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Conta para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="width: 23%">
                                                            <span id="Span4" class="obrigatorio">*</span><strong>Quantidade ou Valor:</strong></td>
                                                        <td width="77%" align="left" class="texto">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor" runat="server" CssClass="texto" MaxCaracteristica="12"
                                                                MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_valor"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Valor para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px; width: 23%;">
                                                        </td>
                                                        <td style="height: 14px">
                                                            <anthem:CustomValidator ID="cv_lancamento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Font-Bold="False" Font-Italic="False" Text="[!]" ValidationGroup="vg_salvar" ForeColor="White"></anthem:CustomValidator></td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2" style="height: 116px">
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
														<TD style="width: 23%">&nbsp;</TD>
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
					<TD style="width: 3px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 3px">&nbsp;</TD>
					<TD></TD>
					<TD style="width: 3px">&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_id_linha" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_id_frete_periodo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />

        </form>
	</body>
</HTML>
