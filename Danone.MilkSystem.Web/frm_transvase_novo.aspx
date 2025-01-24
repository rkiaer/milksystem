<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transvase_novo.aspx.vb" Inherits="frm_transvase_novo" %>

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
    <title>Novo Transvase</title>
		<link href="css/estilo.css" type="text/css" rel="stylesheet"/>
	</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
	
	<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
           	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        if (idcboestabel == "0")
        {
            alert("Para acessar a lista de transportadores, o estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_transportador.aspx?id_estabelecimento='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
         }
    }            
    </script>
    <script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var idtransportador;
        var retorno="";
   	    var szUrl;
   	    
   	    idtransportador = document.getElementById("hf_id_pessoa").value;
        if (idtransportador == "0")
        {
            alert("Para acessar a lista de veículos, o transportador deve ser informado!");
        }
        else
        {
            szUrl = 'lupa_veiculo.aspx?id='+idtransportador+'';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        }  
    }          
</script>
	<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx?categoria=D';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">

			<table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Novo Transvase</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 44px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 44px">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px" vAlign="middle" align="left" width="238"
									background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
									|
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						</TD>
					<TD style="height: 44px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top">
						<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD bgColor="#d0d0d0" style="width: 1px"></TD>
								<TD>
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="76%">
												<TABLE id="Table7"  cellSpacing="0" cellPadding="2" width="100%" border="0">
													<TR>
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Dados do Transvase</TD>
													</TR>
													<TR >
														<TD class="texto" align="right" width="23%"><STRONG><span style="color: #ff0000">*</span><strong>Estabelecimento:</strong></STRONG></TD>
														<TD width="77%">&nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" AutoCallBack="true">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator>
                                                            </TD>
													</TR>
													<TR id="TrProdutor" runat="server">
														<TD class="texto" align="right" width="23%" style="height: 13px"><span id="Span3" class="obrigatorio">*</span><STRONG> Transportador:</STRONG></TD>
														<TD style="height: 13px" >
    										                &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="texto" Width="64px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="14"></anthem:TextBox>
											                &nbsp;<anthem:Label ID="lbl_nm_pessoa" runat="server" CssClass="texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                                                  <anthem:ImageButton ID="btn_lupa_produtor" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Produtores" Width="15px" AutoUpdateAfterCallBack="true" />
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_pessoa" CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa." Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                                  <asp:CustomValidator ID="cv_produtor" runat="server" ErrorMessage="Transportador não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                            
                                                        </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span1" class="obrigatorio">*</span><strong>Motorista:</strong></td>
                                                        <td style="height: 23px" class="texto">
                                                            &nbsp;<anthem:DropDownList ID="cbo_motorista" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" Enabled="False" AutoCallBack="True">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            <anthem:Label ID="lbl_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                Font-Bold="True" UpdateAfterCallBack="True">CNH:</anthem:Label>
                                                            <anthem:Label ID="lbl_cd_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong><span style="color: #ff0000">* </span>Rota:</strong></td>
                                                        <td class="texto" style="width: 749px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_rotas" runat="server" CssClass="texto" Enabled="False" AutoUpdateAfterCallBack="True">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="cbo_rotas"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Rotas para continuar." Font-Bold="True"
                                                                ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong><span style="color: #ff0000">* <strong></strong></span>Tipo de Leite:</strong></td>
                                                        <td class="texto" style="width: 749px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" CssClass="texto">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cbo_id_item"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                                                Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
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
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Dados do Veículo</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 5px" align="right" width="23%"></TD>
														<TD style="HEIGHT: 5px">&nbsp;
															</TD>
													</TR>
                                                    <tr>
														<TD class="texto" style="HEIGHT: 22px" align="center" colspan="2">
                                                            <anthem:GridView ID="gridTransitPointCompartimento" runat="server" AllowSorting="True"
                                                                AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto"
                                                                Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="7" UpdateAfterCallBack="True"
                                                                Width="80%">
                                                                <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                                                                <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Placa">
                                                                        <itemtemplate>
<anthem:TextBox id="txt_placa" runat="server" AutoCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" MaxLength="7" Width="64px" UpdateAfterCallBack="True" OnTextChanged="txt_placa_TextChanged" __designer:wfdid="w37"></anthem:TextBox>&nbsp; <anthem:ImageButton id="bt_lupa_veiculo" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="True" Width="15px" ToolTip="Filtrar Veículos" ImageAlign="AbsBottom" Height="15px" BorderStyle="None" __designer:wfdid="w38" CommandName="Lupa"></anthem:ImageButton>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Placa para continuar." ControlToValidate="txt_placa" ToolTip="Placa deve ser preenchida." __designer:wfdid="w39">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator id="cmv_placa" runat="server" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" ErrorMessage="Placa não cadastrada." ControlToValidate="txt_placa" ToolTip="Placa Não Cadastrada." __designer:wfdid="w40" OnServerValidate="cmv_placa_ServerValidate">[!]</anthem:CustomValidator> 
</itemtemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Placa Principal">
                                                                        <itemtemplate>
<anthem:CheckBox id="chk_st_placa_principal" runat="server" CssClass="texto" __designer:wfdid="w17"></anthem:CheckBox> 
</itemtemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compartimento">
                                                                        <itemtemplate>
<anthem:DropDownList id="cbo_compartimento" runat="server" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" __designer:wfdid="w24" OnSelectedIndexChanged="cbo_compartimento_SelectedIndexChanged"></anthem:DropDownList>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" ErrorMessage="Preecha o compartimento para continuar." ControlToValidate="cbo_compartimento" ToolTip="Compartimento deve ser preenchido." __designer:wfdid="w25">[!]</anthem:RequiredFieldValidator>&nbsp; 
</itemtemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Volume M&#225;ximo" ReadOnly="True">
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Volume L&#237;quido" Visible="False">
                                                                        <itemtemplate>
&nbsp;<cc6:OnlyDecimalTextBox id="txt_nr_total_litros" runat="server" CssClass="texto" Width="80px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w39"></cc6:OnlyDecimalTextBox>
</itemtemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w44" CommandName="delete" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;"></anthem:ImageButton> 
</itemtemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="id_index" ReadOnly="True" Visible="False" />
                                                                    <asp:BoundField HeaderText="id_compartimento" ReadOnly="True" Visible="False" />
                                                                    <asp:TemplateField HeaderText="id_veiculo" Visible="False">
                                                                        <itemtemplate>
<asp:Label id="lbl_id_veiculo" runat="server" __designer:wfdid="w43"></asp:Label> 
</itemtemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                                                        <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" __designer:wfdid="w42"></asp:Label> 
</itemtemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="comp_cheio" Visible="False">
                                                                        <itemtemplate>
<asp:Label id="lbl_comp_cheio" runat="server" __designer:wfdid="w41"></asp:Label> 
</itemtemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </anthem:GridView>
                                                            <anthem:CustomValidator ID="cv_placa_principal" runat="server" AutoUpdateAfterCallBack="True"
                                                                ErrorMessage="Uma placa deve ser informada como Principal para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</anthem:CustomValidator><anthem:CustomValidator ID="cv_grid"
                                                                    runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ErrorMessage="Uma placa deve ser informada como Principal para continuar."
                                                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>
                                                            <br />
                                                            <asp:Button ID="btn_novo_compartimento" runat="server" Text="Adicionar" /></TD>
                                                    </tr>
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
									<table id="Table3" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
												background="img/faixa_filro.gif">
                                                &nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; 
												|
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
                                                    ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
											<TD class="faixafiltro1a" valign="middle" align="right" background="img/faixa_filro.gif"
												colSpan="4">&nbsp;</TD>
										</TR>
									</table>
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
			</table>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <!-- <anthem:HiddenField ID="hf_id_linha" runat="server" AutoUpdateAfterCallBack="true" /> -->
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>

                </form>
	</body>
</html>
