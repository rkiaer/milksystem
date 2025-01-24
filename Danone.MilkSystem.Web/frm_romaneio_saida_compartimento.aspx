<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_compartimento.aspx.vb" Inherits="frm_romaneio_saida_compartimento" %>

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
    <title>Romaneio Saída Compartimentos</title>
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
					<td class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><strong>Romaneio de Saída - Registrar Compartimentos</strong></td>
					<td style="width: 7px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 7px; height: 13px;" ></td>
					<td vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; ">
						<table id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"  background="img/faixa_filro.gif">
                                    &nbsp;
                                    <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Registrar</asp:LinkButton>
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
	                        <td align="center" class="texto" colspan="2" style="height: 234px" >
	                         <table width="98%">
                                        <tr >
                                            <td align="right" style="width: 18%;height: 22px;">
                                                Estabelecimento:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
                                            <td align="right" style="width: 16%">
                                                Romaneio Saída:</td>
                                            <td align="left" style="width: 28%; height: 22px;">
                                                &nbsp;<anthem:Label ID="lbl_romaneio_saida" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                 <tr>
                                     <td align="right" style="height: 22px">
                                         <span style="color: #000000">Situação:</span></td>
                                     <td align="left">
                                         &nbsp;<anthem:Label ID="lbl_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                             CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                     <td align="right">
                                         <span style="color: #000000">Data/Hora Entrada:</span></td>
                                     <td align="left" >
                                         &nbsp;<anthem:Label ID="lbl_dt_entrada" runat="server" AutoUpdateAfterCallBack="True"
                                             CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                 </tr>
                                        <tr>
                                            <td align="right" style="height: 22px">
                                                <span style="color: #000000">Tipo Operação:</span></td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_tipo_operacao" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right">
                                                <span style="color: #000000">Motivo da Saída:</span></td>
                                            <td align="left" >
                                                &nbsp;<anthem:Label ID="lbl_motivo_saida" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="height: 22px">
                                                Tipo de Leite:</td>
                                            <td align="left">
                                                &nbsp;<anthem:Label ID="lbl_tipo_leite" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right">
                                                Tipo de Frete:</td>
                                            <td align="left" style="height: 22px">
                                                &nbsp;<anthem:Label ID="lbl_tipo_frete" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                 <tr>
                                            <td align="right" style="height: 22px">
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
                                            <td align="right" style="height: 22px">
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
                                     <td align="right" style="height: 24px">
                                         Motorista:</td>
                                     <td align="left" style="height: 24px">
                                         &nbsp;<anthem:Label ID="lbl_motorista" runat="server" AutoUpdateAfterCallBack="True"
                                             CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                     <td align="right" style="height: 24px">
	                                <anthem:Label ID="lbl_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
	                                    Font-Bold="False" UpdateAfterCallBack="True">CNH:</anthem:Label></td>
                                     <td align="left" style="height: 24px">&nbsp;<anthem:Label ID="lbl_cd_cnh" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                                 </tr>
                                        <tr>
                                            <td align="right" style="height: 22px">
                                                <span style="color: #ff0000">*</span>Volume a Carregar:</td>
                                            <td align="left">
                                                &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_peso_liquido_estimado" runat="server" CssClass="texto"
                                                    MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="texto"
                                                    ValidationGroup="vg_salvar" ControlToValidate="txt_nr_peso_liquido_estimado" EnableTheming="True" ErrorMessage="'Volume a Carregar' deve ser informado para a distribuição de volume nos compartimentos.">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                Pesagem Inicial:&nbsp;</td>
                                            <td align="left" style="height: 22px">
                                                &nbsp;<anthem:Label ID="lbl_peso_inicial" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                    </table>

	                        </td>
	                        </tr>
	                        
	                        <tr>
	                            <td style="height: 16px" class="titmodulo" align="left" colSpan="2">Dados dos Compartimentos Carregados do Veículo</td>
	                        </tr>
	                        <tr>
	                            <td class="texto" align="center" colspan="2">
                                    <br />
	                                <anthem:GridView ID="gridRomaneioCompartimento" runat="server"
	                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="70%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True">
	                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
	                                    <Columns>
	                                        <asp:TemplateField HeaderText="Placa">
	                                            <itemtemplate>
<anthem:DropDownList id="cbo_placa" runat="server" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" OnSelectedIndexChanged="cbo_placa_SelectedIndexChanged" __designer:wfdid="w623"></anthem:DropDownList><anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Placa para continuar." ToolTip="Placa deve ser preenchida." ControlToValidate="cbo_placa" __designer:wfdid="w624">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator id="cmv_placa" runat="server" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" Visible="False" Font-Bold="True" ErrorMessage="Placa não cadastrada." ToolTip="Placa Não Cadastrada." ControlToValidate="txt_placa" __designer:wfdid="w625" OnServerValidate="cmv_placa_ServerValidate">[!]</anthem:CustomValidator> 
</itemtemplate>
	                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Placa Principal">
                                                <itemtemplate>
<anthem:CheckBox id="chk_st_placa_principal" runat="server" CssClass="texto" __designer:wfdid="w156"></anthem:CheckBox> 
</itemtemplate>
                                            </asp:TemplateField>
	                                        <asp:TemplateField HeaderText="Compartimento">
	                                            <itemtemplate>
<anthem:DropDownList id="cbo_compartimento" runat="server" UpdateAfterCallBack="True" CssClass="texto" AutoUpdateAfterCallBack="True" OnSelectedIndexChanged="cbo_compartimento_SelectedIndexChanged" __designer:wfdid="w626" AutoPostBack="True"></anthem:DropDownList>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ValidationGroup="vg_salvar" CssClass="texto" AutoUpdateAfterCallBack="True" Font-Bold="True" ErrorMessage="Preecha o compartimento para continuar." ToolTip="Compartimento deve ser preenchido." ControlToValidate="cbo_compartimento" __designer:wfdid="w627">[!]</anthem:RequiredFieldValidator> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:BoundField HeaderText="Volume M&#225;ximo" ReadOnly="True" />
	                                        <asp:TemplateField HeaderText="Volume L&#237;quido" Visible="False">
	                                            <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_total_litros" runat="server" CssClass="texto" Width="80px" MaxLength="15" MaxMantissa="4" MaxCaracteristica="10" DecimalSymbol="," __designer:wfdid="w204"></cc6:OnlyDecimalTextBox> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:TemplateField>
	                                            <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" AutoUpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" CommandName="delete" __designer:wfdid="w205"></anthem:ImageButton> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:BoundField ReadOnly="True" Visible="False" HeaderText="id_index" />
                                            <asp:BoundField HeaderText="id_compartimento" ReadOnly="True" Visible="False" />
                                            <asp:TemplateField HeaderText="comp_cheio" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_comp_cheio" runat="server" __designer:wfdid="w206"></asp:Label> 
</itemtemplate>
                                            </asp:TemplateField>
	                                    </Columns>
	                                </anthem:GridView>
                                    <anthem:CustomValidator ID="cv_verificarvolume" runat="server" ErrorMessage="Litros da Nota Fiscal é maior que a soma dos compartimentos informados!"
                                        Font-Bold="True" ForeColor="White" ValidationGroup="vg_salvar">[!]</anthem:CustomValidator>
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
					

						</table>
						</td>
						<td style="width: 7px"></td>
				</tr>

				<tr>
					<td style="width: 7px"></td>
					<td>
						<table id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
									&nbsp; &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Registrar</asp:LinkButton></td>
								<td class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
			</table>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
        </form>
					
	</body>
</html>
