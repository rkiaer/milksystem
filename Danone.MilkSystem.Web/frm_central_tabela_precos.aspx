<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_central_tabela_precos.aspx.vb" Inherits="frm_central_tabela_precos" %>

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
    <title>frm_central_tabela_precos</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
	<script type="text/javascript"> 

    function ShowDialogFornecedor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
   	        szUrl = 'lupa_fornecedor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
    }            
    </script>
	<script type="text/javascript"> 

    function ShowDialogItem() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_item = document.getElementById("hf_id_item");
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        szUrl = 'lupa_item.aspx?id='+hf_id_pessoa+'';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_item.value=retorno;
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">

			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Tabela de Preços</STRONG></TD>
					<TD style="width: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; " ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" >
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
									colSpan="4">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%">
												<TABLE id="Table7"  cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Dados </TD>
													</TR>
                                                    
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Estabelecimento:</strong></td>
                                                        <td width="77%" style="height: 23px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" AutoCallBack="true">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
													<TR id="TrProdutor" runat="server">
														<TD class="texto" align="right" width="23%" style="height: 13px"><span id="Span3" class="obrigatorio">*</span><STRONG> Parceiro Central:</STRONG></TD>
														<TD style="height: 13px" >
    										                &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="texto" Width="64px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="14"></anthem:TextBox>
											                &nbsp;
                                                                  <anthem:ImageButton ID="btn_lupa_fornecedor" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Parceiros" Width="15px" AutoUpdateAfterCallBack="true" />
                                                                  <anthem:Label ID="lbl_nm_pessoa" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_pessoa" CssClass="texto" ErrorMessage="Preencha o campo Código do Parceiro para continuar ou selecione-o pela lupa." Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="O campo Parceiro Central deve ser informado.">[!]</asp:RequiredFieldValidator>
                                                                  <asp:CustomValidator ID="cv_fornecedor" runat="server" ErrorMessage="Parceiro não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Parceiro Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                            
                                                        </TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%" style="height: 13px">
                                                            <span id="Span4" class="obrigatorio">*</span><STRONG> Item:</strong></td>
                                                        <TD style="height: 13px" >
                                                            &nbsp;<anthem:TextBox ID="txt_cd_item" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>
                                                            &nbsp;
                                                            <anthem:ImageButton ID="btn_lupa_item" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Itens" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            <anthem:Label ID="lbl_nm_item" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_cd_pessoa"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código do Item para continuar ou selecione-o pela lupa."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" ToolTip="Ocampo Item deve ser informado.">[!]</asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cv_item" runat="server" CssClass="texto" ErrorMessage="Item não cadastrado!"
                                                                Font-Bold="true" Text="[!]" ToolTip="Item Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Unidade de Medida :</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:Label ID="lbl_unidade_medida" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">*</span><STRONG> </strong>Estado Origem:</strong></td>
                                                        <TD class="texto" style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estado_origem" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True" Enabled="False">
                                                            </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estado_origem"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estado Origem para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">*</span><STRONG> </strong>Cidade Origem:</strong></td>
                                                        <TD style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_cidade_origem" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_cidade_origem"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cidade Origem para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">*</span><STRONG> </strong>Estado Destino:</strong></td>
                                                        <TD class="texto" style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estado_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                            </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estado_destino"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estado Destino para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">*</span><STRONG> </strong>Cidade Destino:</strong></td>
                                                        <TD style="HEIGHT: 22px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_cidade_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                            </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_cidade_destino"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cidade Destino para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <!--<tr visible="false">
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Quantidade:</strong>
                                                        </td>
                                                        <td>&nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_volume_ate" runat="server" CssClass="texto"
                                                                 Width="96px" MaxCaracteristica="10" MaxLength="15" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>-->
                                                    <!--
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong>Dias de Coleta:</strong></td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_domingo" runat="server" CssClass="texto" Text="Domingo" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_segunda" runat="server" CssClass="texto" Text="Segunda-feira" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_terca" runat="server" CssClass="texto" Text="Terça-feira" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_quarta" runat="server" CssClass="texto" Text="Quarta-feira" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_quinta" runat="server" CssClass="texto" Text="Quinta-feira" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_sexta" runat="server" CssClass="texto" Text="Sexta-feira" /></td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <strong></strong>
                                                        </td>
                                                        <TD>
                                                            &nbsp;<anthem:CheckBox ID="ck_coleta_sabado" runat="server" CssClass="texto" Text="Sábado" /></td>
                                                    </tr>
                                                    -->
                                                    <!--<tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>ICMS:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_icms" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxLength="15" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>-->
 
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                                MaxLength="15" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Sacaria:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_sacaria" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxLength="15" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>
                                                                                                       <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Valor Padrão:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_valor_padrao" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                                MaxLength="15" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>

                                                    <!--<tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Nr. Parcelas:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_parcelas" runat="server" CssClass="texto"
                                                                MaxLength="14" Width="96px"></cc3:OnlyNumbersTextBox>
                                                        </td>
                                                    </tr>-->
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong><span style="color: #ff0000">*</span>Data Cotação:&nbsp; </strong>
                                                        </td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<anthem:Label ID="lbl_dt_cotacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                            <cc4:OnlyDateTextBox ID="txt_dt_cotacao" runat="server" CssClass="texto" Width="70px"></cc4:OnlyDateTextBox>
                                                            <asp:RequiredFieldValidator ID="rf_dt" runat="server" ControlToValidate="txt_dt_cotacao"
                                                                CssClass="texto" ErrorMessage="Data Cotação para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar" ToolTip="Data da Cotação deve ser informada">[!]</asp:RequiredFieldValidator>&nbsp; 
                                                            <anthem:Label ID="lbl_labelhr" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Bold="True" UpdateAfterCallBack="True">Horas/Minutos:</anthem:Label><strong>
                                                                </strong>
                                                            <cc3:OnlyNumbersTextBox ID="txt_hr_cotacao" runat="server" CssClass="texto" MaxLength="2"
                                                                Width="17px"></cc3:OnlyNumbersTextBox>
                                                            <anthem:Label ID="lbl_pontos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Bold="True" Style="text-align: center" UpdateAfterCallBack="True">:</anthem:Label>
                                                            <cc3:OnlyNumbersTextBox ID="txt_min_cotacao" runat="server" CssClass="texto" MaxLength="2"
                                                                Width="17px"></cc3:OnlyNumbersTextBox>
                                                            <asp:RangeValidator ID="rv_hr" runat="server" ControlToValidate="txt_hr_cotacao"
                                                                CssClass="texto" ErrorMessage="Preencha as horas da Data da Cotação corretamente para continuar."
                                                                Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                                    ID="rv_min" runat="server" ControlToValidate="txt_min_cotacao" CssClass="texto"
                                                                    ErrorMessage="Preencha os minutos do Data da Cotação corretamente para continuar."
                                                                    Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                        ID="rf_hr" runat="server" ControlToValidate="txt_hr_cotacao"
                                                                        CssClass="texto" ErrorMessage="Preencha o campo Horas em Data da Cotação para continuar."
                                                                        Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="rf_min" runat="server" ControlToValidate="txt_min_cotacao"
                                                                            CssClass="texto" ErrorMessage="Preencha os Minutos em Data da Cotação para continuar."
                                                                            Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 7px" width="23%">
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">Dados do Sistema</TD>
																</TR>
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
					<TD style="width: 7px">&nbsp;</TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <!-- <anthem:HiddenField ID="hf_id_linha" runat="server" AutoUpdateAfterCallBack="true" /> -->
            <anthem:HiddenField ID="hf_id_item" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_tecnico_educampo" runat="server" AutoUpdateAfterCallBack="true" />
        </div>

                </form>
	</body>
</HTML>
