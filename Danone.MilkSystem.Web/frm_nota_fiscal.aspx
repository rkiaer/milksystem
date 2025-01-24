<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_nota_fiscal.aspx.vb" Inherits="frm_nota_fiscal" %>

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
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0" alink="#f00">

<script type="text/javascript"> 

    function ShowDialog() 
    
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
					<TD style="width: 5px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); width: 600px;"><STRONG>Nota Fiscal</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|&nbsp;
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
                                    |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <anthem:LinkButton ID="lk_rateio" runat="server" Visible="False" AutoUpdateAfterCallBack="True">Rateio NF Transf.</anthem:LinkButton>
                                    &nbsp;&nbsp;
                                    <anthem:LinkButton ID="lk_itens_nota" runat="server" AutoUpdateAfterCallBack="True"
                                        Visible="False">Itens da Nota</anthem:LinkButton>
                                    &nbsp;
                                    <anthem:LinkButton ID="lk_duplicata" runat="server" Visible="False" AutoUpdateAfterCallBack="True">Duplicatas</anthem:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
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
                                                    <tr runat="server" id="tr_id_romaneio">
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Romaneio:</strong>
                                                        </td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_id_romaneio" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                            &nbsp;
                                                            <anthem:Label ID="lbl_informativo_romaneio" runat="server" CssClass="texto" Font-Italic="True"
                                                                ForeColor="Red" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <span id="Span1" class="obrigatorio">*</span><strong>Tipo Nota Fiscal:</strong>
                                                        </td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_nota_fiscal" runat="server"
                                                                AutoPostBack="false" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_tipo_nota_fiscal"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo Nota Fiscal para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Estabelecimento:</strong>
                                                        </td>
                                                        <td class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server"
                                                                AutoPostBack="false" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                                    <td align="right" class="texto" style="width:24%;">
                                                                        <span style="color: #ff0000"><strong>*</strong></span> <strong>Emitente:</strong></td>
                                                                    <td style="height: 13px;width:76%;">
                                                                        &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoUpdateAfterCallBack="true"
                                                                            CssClass="texto" MaxLength="6" Width="64px" AutoCallBack="True" AutoPostBack="True"></anthem:TextBox>
                                                                        &nbsp;<anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                                        <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                                                            BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                                                            ToolTip="Filtrar Produtores" Width="15px" />
                                                                        <asp:CustomValidator
                                                                                ID="cv_produtor" runat="server" ControlToValidate="txt_cd_pessoa" CssClass="texto"
                                                                                ErrorMessage="Emitente não cadastrado!" Font-Bold="True" Text="[!]" ToolTip="Emitente não Cadastrado!"
                                                                                ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>CNPJ:</strong></td>
                                                        <td>
                                                            &nbsp;<cc1:CNPJTextBox ID="txt_cnpj" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" ErrorMessage="CNPJ Inválido." Width="120px" AutoCallBack="True" AutoPostBack="True"></cc1:CNPJTextBox>&nbsp;
                                                            <asp:CustomValidator ID="cv_cnpj" runat="server" ControlToValidate="txt_cnpj" CssClass="texto"
                                                                ErrorMessage="CNPJ não cadastrado para o Emitente." ToolTip="CNPJ não cadastrado para o Emitente."
                                                                ValidationGroup="vg_salvar">[!]</asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <span class="obrigatorio">*</span><strong> Natureza Operação:</strong></td>
                                                        <td style="height: 24px">
                                                            &nbsp;<asp:DropDownList ID="cbo_natureza_operacao" runat="server" CssClass="texto">
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_natureza_operacao"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Natureza de Operação  para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Nr. Nota Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_nota_fiscal" runat="server" CssClass="texto"
                                                                MaxLength="7" Width="72px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_nr_nota_fiscal"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nr. Nota Fiscal para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Série Nota Fiscal:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_nr_serie_nota_fiscal" runat="server"
                                                                CssClass="texto" MaxLength="5" Width="72px"></anthem:TextBox>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span style="color: #ff0000"><strong>*</strong></span><strong>Data Emissão Nota Fiscal:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_emissao_nota_fiscal" runat="server"
                                                                CssClass="texto" Width="112px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_emissao_nota_fiscal"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data Emissão Nota Fiscal  para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_dt_transacao"
                                                                ControlToValidate="txt_dt_emissao_nota_fiscal" CssClass="texto" ErrorMessage="Data de Emissão deve ser menor ou igual a Data da Transação."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vg_salvar">[!]</asp:CompareValidator></td>
                                                    </tr>
                                                    <tr >
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Data da Transação:</strong></td>
                                                        <td>
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_transacao" runat="server"
                                                                CssClass="texto" Width="72px"></cc4:OnlyDateTextBox>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dt_transacao"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Data da Transação para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="cv_data_transacao" runat="server" CssClass="texto" ErrorMessage="Não é permitido alteração  fora do mes corrente." ValidationGroup="vg_salvar">[!]</asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Chave Acesso NF-e:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ds_chave_nfe" runat="server" CssClass="texto"
                                                                MaxLength="44" Width="281px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                            <asp:CustomValidator ID="cv_ds_chave_nfe" runat="server" CssClass="texto" ErrorMessage="Deve ser informado exatamente 44 dígitos."
                                                                ValidationGroup="vg_salvar">[!]</asp:CustomValidator>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_ds_chave_nfe"
                                                                CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Chave Acesso NF-e  para continuar."
                                                                Font-Bold="True" ToolTip="Chave Acesso NF-e deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor ICMS:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_icms" runat="server" CssClass="texto" MaxCaracteristica="11"
                                                                MaxLength="14" Width="71px"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span style="color: #ff0000"><strong>*</strong></span> <strong>Frete:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_frete" runat="server"
                                                                CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="True">
                                                            </anthem:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cbo_id_frete"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Frete para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Número CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="14"></cc3:OnlyNumbersTextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_nr_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_nr_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Número CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Série CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_serie_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="5" Width="72px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_serie_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_serie_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Série CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Série CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_nr_valor_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_nr_valor_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Valor CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Chave CTE:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_ds_chave_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="44" Width="281px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                            <anthem:RequiredFieldValidator ID="rf_ds_chave_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_ds_chave_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Chave CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Chave CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>CST CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:DropDownList ID="cbo_CST_cte" runat="server" CssClass="texto" Enabled="False">
                                                                <asp:ListItem Value="" Selected="True">[Selecione]</asp:ListItem>
                                                                <asp:ListItem Value="00">00 - Tributada Integralmente</asp:ListItem>
                                                                <asp:ListItem Value="20">20 - Tributada com redu&#231;&#227;o de base de c&#225;lculo</asp:ListItem>
                                                                <asp:ListItem Value="30">30 - Isenta ou n&#227;o tributada e com cobran&#231;a do ICMS por substitui&#231;&#227;o tribut&#225;ria</asp:ListItem>
                                                                <asp:ListItem Value="40">40 - Isenta</asp:ListItem>
                                                                <asp:ListItem Value="41">41 - N&#227;o tributada</asp:ListItem>
                                                                <asp:ListItem Value="51">51 - Diferimento</asp:ListItem>
                                                                <asp:ListItem Value="60">60 - Cobrado anteriormente por substitui&#231;&#227;o tribut&#225;ria</asp:ListItem>
                                                                <asp:ListItem Value="70">70 - Com redu&#231;&#227;o de base de c&#225;lculo e cobran&#231;a do ICMS por substitui&#231;&#227;o tribut&#225;ria</asp:ListItem>
                                                                <asp:ListItem Value="90">90 - Outras (Regime Normal)</asp:ListItem>
                                                                <asp:ListItem Value="90_OU">90_outra_uf - Outras (ICMS devido &#224; UF de origem da presta&#231;&#227;o, quando diferente da UF do emitente)</asp:ListItem>
                                                                <asp:ListItem Value="90_SN">90_simples_nacional - Outras (regime Simples Nacional)</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <anthem:RequiredFieldValidator ID="rf_cst_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="cbo_CST_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo CST CTE  para continuar."
                                                                Font-Bold="True" ToolTip="CST CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor ICMS CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_nr_icms_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor ICMS CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Valor ICMS CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                     <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Base ICMS CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_base_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_base_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_base_icms_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo BASE ICMS CTE  para continuar."
                                                                Font-Bold="True" ToolTip="BASE ICMS CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Data Emissão CTE:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" Width="96px"></cc4:OnlyDateTextBox>
                                                            <cc3:OnlyNumbersTextBox ID="txt_hr_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="2" Width="20px"></cc3:OnlyNumbersTextBox>
                                                            :
                                                            <cc3:OnlyNumbersTextBox ID="txt_mm_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" Width="20px"></cc3:OnlyNumbersTextBox>
                                                            :
                                                            <cc3:OnlyNumbersTextBox ID="txt_ss_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" Width="20px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                            <asp:RangeValidator ID="rv_hr_cte" runat="server" ControlToValidate="txt_hr_emissao_cte"
                                                                CssClass="texto" ErrorMessage="Preencha as horas da Emissão do CTE corretamente para continuar."
                                                                Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                                    ID="rv_mm_cte" runat="server" ControlToValidate="txt_mm_emissao_cte" CssClass="texto"
                                                                    ErrorMessage="Preencha os minutos da Emissão CTE corretamente para continuar."
                                                                    Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                        ID="rf_hr_cte" runat="server" ControlToValidate="txt_hr_emissao_cte" CssClass="texto"
                                                                        ErrorMessage="Preencha o campo Horas em Emissão CTE para continuar." Font-Bold="False"
                                                                        ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="rf_mm_cte" runat="server" ControlToValidate="txt_mm_emissao_cte"
                                                                            CssClass="texto" ErrorMessage="Preencha os Minutos em Emissão CTE para continuar."
                                                                            Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RangeValidator
                                                                                ID="rv_ss_cte" runat="server" ControlToValidate="txt_ss_emissao_cte" CssClass="texto"
                                                                                ErrorMessage="Preencha os segundos da Emissão CTE corretamente para continuar."
                                                                                Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                                    ID="rf_ss_cte" runat="server" ControlToValidate="txt_ss_emissao_cte" CssClass="texto"
                                                                                    ErrorMessage="Preencha os Segundos em Emissão CTE para continuar." Font-Bold="False"
                                                                                    ToolTip="Os segundos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                                                        ID="rf_dt_emissao_cte" runat="server" ControlToValidate="txt_dt_emissao_cte"
                                                                                        CssClass="texto" ErrorMessage="Preencha o campo Data Emissão CTE para continuar."
                                                                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>UF Origem CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_uf_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="2" Width="32px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_uf_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_uf_origem_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo UF Origem CTE  para continuar."
                                                                Font-Bold="True" ToolTip="UF Origem CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>IBGE Origem CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_ibge_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="20" Width="72px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_ibge_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_ibge_origem_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo IBGE Origem CTE  para continuar."
                                                                Font-Bold="True" ToolTip="IBGE Origem CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>UF Destino CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_uf_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="2" Width="32px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_uf_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_uf_destino_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo UF Destino CTE  para continuar."
                                                                Font-Bold="True" ToolTip="UF Destino CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>IBGE Destino CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_ibge_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="20" Width="72px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_ibge_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_ibge_destino_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo IBGE Destino CTE  para continuar."
                                                                Font-Bold="True" ToolTip="IBGE Destino CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>CFOP CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_cd_cfop_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="10" Width="72px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_cfop_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_cd_cfop_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo CFOP CTE  para continuar."
                                                                Font-Bold="True" ToolTip="CFOP CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Protocolo CTE:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_protocolo_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" MaxLength="20" Width="144px"></anthem:TextBox>
                                                            <anthem:RequiredFieldValidator ID="rf_protocolo_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                                ControlToValidate="txt_protocolo_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Protocolo CTE  para continuar."
                                                                Font-Bold="True" ToolTip="Protocolo CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="height: 14px" width="20%">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_nota2" runat="server">
														<TD colSpan="2">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2">Dados da 2a Nota Fiscal</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" style="height: 22px" width="23%">
                                                                        <span id="Span3" class="obrigatorio">*</span><strong>Tipo da 2a Nota Fiscal:</strong>
                                                                    </td>
                                                                    <td class="texto">
                                                                        &nbsp;<anthem:DropDownList ID="cbo_tipo_nota2" runat="server" AutoPostBack="True"
                                                                            AutoUpdateAfterCallBack="True" CssClass="texto">
                                                                        </anthem:DropDownList>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Nr. Nota Fiscal 2:</strong></td>
                                                                    <td>
                                                                        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" MaxLength="14"></cc3:OnlyNumbersTextBox>
                                                                        <anthem:RequiredFieldValidator ID="rf_nr_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            ControlToValidate="txt_nr_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número Nota Fiscal 2 para continuar."
                                                                            Font-Bold="True" ToolTip="Número Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Série Nota Fiscal 2:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:TextBox ID="txt_serie_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" Width="96px"></anthem:TextBox>
                                                                        <anthem:RequiredFieldValidator ID="rf_serie_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            ControlToValidate="txt_serie_nota2" CssClass="texto" ErrorMessage="Preencha o campo Série Nota Fiscal 2 para continuar."
                                                                            Font-Bold="True" ToolTip="Série Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar"
                                                                            Visible="False">[!]</anthem:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Litros Nota Fiscal 2:</strong></td>
                                                                    <td>
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_litros_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="rf_nr_litros_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            ControlToValidate="txt_nr_litros_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Litros Nota Fiscal 2 para continuar."
                                                                            Font-Bold="True" ToolTip="Litros Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Valor Nota Fiscal 2:</strong></td>
                                                                    <td>
                                                                        &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                                        <anthem:RequiredFieldValidator ID="rf_valornota2" runat="server" AutoUpdateAfterCallBack="True"
                                                                            ControlToValidate="txt_nr_valor_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor Nota 2 para continuar."
                                                                            Font-Bold="True" ToolTip="Valor Nota 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                                                </tr>
															</TABLE>
														</TD>
													</TR>

                                                    <tr>
                                                        <td align="right" style="height: 14px" width="20%">
                                                        </td>
                                                        <td style="height: 14px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%">
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
																	<TD>&nbsp;<anthem:Label ID="lbl_modificador" runat="server"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right">
                                                                        <strong>Data Modificação:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
                                                                <tr id="tr_exportacao_frete" runat="server" visible="false">
                                                                    <td align="right" class="texto" style="height: 22px" width="23%">
                                                                        <strong>Exportação Frete:</strong>
                                                                    </td>
                                                                    <td class="texto">
                                                                        &nbsp;<anthem:Label ID="lbl_exportacao_frete" runat="server" CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr id="tr_exportacao_frete_dt" runat="server" visible="false">
                                                                    <td align="right" class="texto" style="height: 22px" width="23%">
                                                                        <strong>Data Exportação Frete:</strong>
                                                                    </td>
                                                                    <td class="texto">
                                                                        &nbsp;<anthem:Label ID="lbl_dt_exportacao_frete" runat="server" CssClass="texto"
                                                                            UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
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
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 5px">&nbsp;</TD>
					<TD style="width: 600px"></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />

                </form>
	</body>
</HTML>
