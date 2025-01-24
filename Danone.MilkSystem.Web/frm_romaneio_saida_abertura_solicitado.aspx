<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_abertura_solicitado.aspx.vb" Inherits="frm_romaneio_saida_abertura_solicitado" %>

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
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Abrir Romaneio Saída com Autorização</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

   <script type="text/javascript"> 

    function ShowDialog() 
    
    {
        var idtransportador;
        var retorno="";
   	    var szUrl;
   	    
   	    idtransportador = document.getElementById("hf_id_transportador").value;
        if (idtransportador == "0" || idtransportador == ""  )
        {
            alert("Para acessar a lista de veículos, o transportador deve ser informado!");
        }
        else
        {
            szUrl = 'lupa_veiculo.aspx?id='+idtransportador+'';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:700px;edge:raised;dialogHeight:400px')
        }  
    }          
</script>
<script type="text/javascript"> 

    function ShowDialogTransportador() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_transportador = document.getElementById("hf_id_transportador");
    	     
            szUrl = 'lupa_transportador_cooperativa.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:600px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_transportador.value=retorno;
            } 
    }            
</script>
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

	    <form id="Form1" method="post" runat="server">
		    <table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="width: 7px">&nbsp;</td>
					<td class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><strong>Abertura Romaneio Saída com Autorização de Entrada</strong></td>
					<td style="width: 7px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 7px; height: 13px;" ></td>
					<td vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<table id="Table2"  cellSpacing="0" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"  background="img/faixa_filro.gif">
                                    &nbsp;
                                    <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
								</td>
								<td class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</td>
							</tr>
						</table>
					</td>
					<td style="width: 7px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 7px">&nbsp;</td>
					<td vAlign="top" >
						<table id="Table7" cellSpacing=0 cellPadding=2 width="100%">
							<tr>
								<td style="height: 15px" class="titmodulo" align="left" colSpan="2">Dados do Romaneio Saída</td>
							</tr>
							<tr>
								<td style="height: 3px" class="texto" align="right" ></td>
								<td style="height: 3px; " class="texto"></td>
							</tr>
	                        <tr>
	                        <td align="center" class="texto" colspan="2" >
	                         <table width="98%" class="texto">
                                        <tr >
                                            <td align="right" style="width: 18%; height: 21px;">
                                                Estabelecimento:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
                                            <td align="right" style="width: 16%">
                                                Romaneio Saída:</td>
                                            <td align="left" style="width: 28%; ">
                                                &nbsp;<anthem:Label ID="lbl_romaneio_saida" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 21px">
                                                <span style="color: #ff0000">*</span><span style="color: #000000">Tipo Operação:</span></td>
                                            <td align="left">
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_operacao" runat="server" AutoPostBack="false"
                                                    CssClass="texto">
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="cbo_tipo_operacao"
                                                    CssClass="texto" ErrorMessage="Tipo Operação deve ser preenchida." Font-Bold="False"
                                                    ValidationGroup="vg_salvar" EnableTheming="True">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span><span style="color: #000000">Motivo da Saída:</span></td>
                                            <td align="left" >
                                                &nbsp;<asp:DropDownList ID="cbo_motivo_saida" runat="server" CssClass="texto">
                                                </asp:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="cbo_motivo_saida"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Natureza de Operação  para continuar."
                                                    Font-Bold="False" ToolTip="Motivo da Saída deve ser preenchida." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 21px">
                                                <span style="color: #ff0000">*</span>Tipo de Leite:</td>
                                            <td align="left">
                                                &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto">
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="cbo_id_item"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                                    Font-Bold="False" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Tipo de Frete:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<anthem:DropDownList ID="cbo_tipo_frete" runat="server" AutoPostBack="True"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="cbo_tipo_frete"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Frete  para continuar." Font-Bold="False"
                                                    ToolTip="Frete deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                 <tr>
                                            <td align="right" style="height: 21px">
                                                Destino:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                     <td align="right">
                                         CNPJ:</td>
                                     <td align="left">
                                         &nbsp;<anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True"
                                             CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                 </tr>
                                        <tr>
                                            <td align="right" style="height: 21px">
                                                Transportador:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right">
                                                CNPJ:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_cnpj_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                 <tr>
                                     <td align="right" style="height: 21px">
                                         Motorista Cadastrado:</td>
                                     <td align="left">
                                         &nbsp;<anthem:DropDownList id="cbo_motorista" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" AutoPostBack="false">
	                                </anthem:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                     </td>
                                     <td align="right">
	                                <anthem:Label ID="lbl_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
	                                    Font-Bold="False" UpdateAfterCallBack="True" Visible="False">CNH:</anthem:Label></td>
                                     <td align="left" style="height: 21px">&nbsp;<anthem:Label ID="lbl_cd_cnh" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                 </tr>
                                 <tr>
                                     <td align="right" style="height: 21px" >
                                         OU
                                         Motorista:</td>
                                     <td align="left">
                                         &nbsp;<anthem:TextBox ID="txt_nm_motorista" runat="server" AutoUpdateAfterCallBack="true"
                                             CssClass="texto" MaxLength="100" Width="80%"></anthem:TextBox>
                                     </td>
                                     <td align="right">
                                         <span style="color: #000000">CNH:</span></td>
                                     <td align="left" style="height: 21px">
                                         &nbsp;<anthem:TextBox ID="txt_cnh_motorista" runat="server" AutoUpdateAfterCallBack="true"
                                             CssClass="texto" MaxLength="30"></anthem:TextBox></td>
                                 </tr>
                                        <tr>
                                            <td align="right" style="height: 21px">
                                                Volume a Carregar:</td>
                                            <td align="left">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_peso_liquido_estimado" runat="server" CssClass="texto"
                                                    MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Preço Unitário:</td>
                                            <td align="left" style="height: 21px">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_preco_unitario" runat="server" CssClass="texto"
                                                    MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_preco_unitario"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Preço Unitário para continuar."
                                                    Font-Bold="False" ToolTip="Preço Unitário deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                 <tr>
                                     <td align="right" style="height: 21px">
                                         Valor Frete:</td>
                                     <td align="left">
                                         &nbsp;<cc6:OnlyDecimalTextBox ID="txt_valor_frete" runat="server" CssClass="texto"
                                             MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                     <td align="right">
                                     </td>
                                     <td align="left" style="height: 21px">
                                     </td>
                                 </tr>
                                    </table>

	                        </td>
	                        </tr>
	                        
	                        <tr>
	                            <td style="height: 16px" class="titmodulo" align="left" colSpan="2">Dados do Veículo</td>
	                        </tr>
	                        <tr>
	                            <td class="texto" align="center" colspan="2">
	                                <anthem:GridView ID="gridRomaneioCompartimento" runat="server"
	                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="70%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True" HorizontalAlign="Center">
	                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
	                                    <Columns>
	                                        <asp:TemplateField HeaderText="Placa">
	                                            <itemtemplate>
<anthem:TextBox id="txt_placa" runat="server" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" Width="64px" MaxLength="7" OnTextChanged="txt_placa_TextChanged" __designer:wfdid="w145"></anthem:TextBox>&nbsp; <anthem:ImageButton id="bt_lupa_veiculo" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="True" ToolTip="Filtrar Veículos" Width="15px" Height="15px" __designer:wfdid="w146" ImageAlign="AbsBottom" BorderStyle="None" CommandName="Lupa"></anthem:ImageButton>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Placa para continuar." ControlToValidate="txt_placa" ToolTip="Placa deve ser preenchida." __designer:wfdid="w147">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator id="cmv_placa" runat="server" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" ErrorMessage="Placa não cadastrada." ControlToValidate="txt_placa" ToolTip="Placa Não Cadastrada." __designer:wfdid="w148" OnServerValidate="cmv_placa_ServerValidate">[!]</anthem:CustomValidator> 
</itemtemplate>
	                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Placa Principal">
                                                <itemtemplate>
<anthem:CheckBox id="chk_st_placa_principal" runat="server" CssClass="texto" __designer:wfdid="w138"></anthem:CheckBox> 
</itemtemplate>
                                            </asp:TemplateField>
	                                        <asp:BoundField HeaderText="Volume M&#225;ximo" ReadOnly="True" />
	                                        <asp:TemplateField HeaderText="Volume L&#237;quido" Visible="False">
	                                            <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_total_litros" runat="server" CssClass="texto" Width="80px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" __designer:wfdid="w149" DecimalSymbol=","></cc6:OnlyDecimalTextBox> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:TemplateField>
	                                            <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" __designer:wfdid="w142" CommandName="delete"></anthem:ImageButton> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:BoundField ReadOnly="True" Visible="False" HeaderText="id_index" />
                                            <asp:BoundField HeaderText="id_compartimento" ReadOnly="True" Visible="False" />
                                            <asp:TemplateField HeaderText="comp_cheio" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_comp_cheio" runat="server" __designer:wfdid="w143"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
	                                    </Columns>
	                                </anthem:GridView>
                                    &nbsp;
                                    <anthem:CustomValidator ID="cv_placa_principal" runat="server" AutoUpdateAfterCallBack="True"
                                        ErrorMessage="Uma placa deve ser informada como Principal para continuar." Font-Bold="True"
                                        ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>&nbsp;
                                    <anthem:CustomValidator ID="cv_grid" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" ErrorMessage="Uma placa deve ser informada como Principal para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator><br />
                                    &nbsp;<anthem:Button ID="btn_novo_compartimento" runat="server" Text="Adicionar" ToolTip="Adicionar nova placa" AutoUpdateAfterCallBack="True" />
	                            </td>
	                        </tr>
	                        <tr>
	                            <td class="texto"  colspan="2"></td>
	                        </tr>
					
                            <tr>
                                <td class="titmodulo" align="left" colSpan="2">
                                    Dados Pesagem Inicial</td>
                            </tr>
                            <tr>
                                <td class="texto" align="right" style="width: 18%">
                                </td>
                                <td class="texto">
                                    &nbsp;</td>
                            </tr>
							<tr>
			                    <td class="texto" align="right"  ><span style="color: #ff0000">* </span>Data Pesagem Inicial:</td>
			                    <td  align="left" class="texto" style="height: 21px" >
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto" MaxLength="10"  ValidationGroup="vg_salvar" Width="88px"></cc4:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                        Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
							    <td class="texto" align="right" ><span style="color: #ff0000">*</span> Horário:</td>
							    <td align="left" class="texto" style="height: 21px"  >
							        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini" runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
							        :<cc3:OnlyNumbersTextBox ID="txt_mm_ini" runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_ini" CssClass="texto" ErrorMessage="O campo horas de pesagem inicial esta inválido."
                                                        Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_ini" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem inicial é inválido."
                                                            Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_hr_ini"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário da Pesagem Inicial para continuar."
                                                                Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_mm_ini"
                                                                    CssClass="texto" ErrorMessage="Preencha os Minutos do Horário da Pesagem Inicial para continuar."
                                                                    Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
						    </tr>
                            <tr runat="server" id="tr_balanca" visible="false">
                                <td align="right" class="texto">
                                    <span style="color: #ff0000">* </span>Informe a Balança:</td>
                                <td align="left" style="height: 21px" >
                                    &nbsp;<anthem:DropDownList ID="cbo_balanca" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False" AutoPostBack="True">
                                        <asp:ListItem Value="02">Portaria 02 - Sa&#237;da</asp:ListItem>
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="rqf_balanca" runat="server" ControlToValidate="cbo_balanca"
                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar." Font-Bold="False"
                                        ValidationGroup="vg_balanca" Visible="False">[!]</asp:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                    <anthem:Button ID="btn_balanca" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Inicial?' )) {lbl_aguarde.className='aguardedestaque';return true;};else return false; " Text="Ler Balança" ToolTip="Buscar peso da balança"
                                        ValidationGroup="vg_balanca" Enabled="False" />
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                            </tr>
						    <tr>
						        <td class="texto" align="right" ><span style="color: #ff0000">* </span>Pesagem Inicial:</td>
                                <td  align="left" class="texto" style="height: 21px" >&nbsp;<cc6:OnlyDecimalTextBox ID="txt_pesagem_inicial" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="88px" ToolTip="Pesagem Inicial" ValidationGroup="vg_salvar" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="A Pesagem Inicial deve ter valor maior que zero (0)."
                                                        Font-Bold="False" Operator="GreaterThan" ToolTip="Pesagem Inicial maior que zero."
                                                        ValidationGroup="vg_salvar" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
							                    <td class="texto" align="right"  ></td>
							                    <td  align="left">&nbsp;</td>
						                    </tr>
						</table>
						</td>
						<td style="width: 7px"></td>
				</tr>

				<tr>
					<td style="width: 7px"></td>
					<td>
						<table id="Table11"  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
									&nbsp; &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></td>
								<td class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</table>
            <anthem:ValidationSummary ID="ValidationSummary1" runat="server" EnableCallBackScript="False"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar" />
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
        </form>
					
	</body>
</html>
