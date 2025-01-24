<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_saida_solicitar_abertura.aspx.vb" Inherits="frm_romaneio_saida_solicitar_abertura" %>

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
    <title>Solicitação/Autorização Abertura Romaneio de Saída</title>
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
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); ">Solicitação/Autorização Abertura de Romaneio de Saída</TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"  background="img/faixa_filro.gif">
                                    &nbsp;
                                    <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>&nbsp;&nbsp;
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    <asp:Image ID="img_cancelar" runat="server" ImageUrl="~/img/icone_excluir.gif" />
                                    <anthem:LinkButton ID="lk_cancelar_abertura" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Cancelar Solicitação/Autorização de Abertura do Romaneio de Saída"
                                        ValidationGroup="vg_cancelar" OnClientClick="if (confirm('Deseja realmente CANCELAR a solicitação de abertura do Romaneio de Saída?' )) return true;else return false;">Cancelar Solicitação/Autorização Abertura</anthem:LinkButton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%">
	                        
                            <tr>
                                <td align="left" class="titmodulo" colspan="2">
                                    Dados de Entrada Romaneio Saída</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" width="22%" >
                                </td>
                                <td style="height: 7px" class="texto">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="texto" colspan="2" style="height: 7px">
                                    <table width="95%">
                                        <tr runat="server" id="tr_romaneio" visible="false">
                                            <td align="right" style="width: 20%">
                                                Romaneio Saída:</td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:Label ID="lbl_romaneio_saida" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                    </td>
                                            <td align="right" style="width: 18%">
                                                Data/Hora Entrada:</td>
                                            <td align="left" style="width: 25%">
                                                &nbsp;
                                                <anthem:Label ID="lbl_dt_hora_entrada" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <span style="color: #ff0000">*</span>Estabelecimento:</td>
                                            <td align="left">
                                                &nbsp;&nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" AutoPostBack="True"></anthem:DropDownList> 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="False" ErrorMessage="Preencha o campo Estabelecimento para continuar." ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="width: 18%">
                                               <span style="color: #ff0000">*</span>Tipo de Leite:</td>
                                            <td align="left" style="width: 25%">
                                                &nbsp;&nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto">
                                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cbo_id_item"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                                    Font-Bold="False" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span><span style="color: #000000">Tipo Operação:</span></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:DropDownList ID="cbo_tipo_operacao" runat="server" AutoPostBack="false"
                                                    CssClass="texto">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_cbotiponota" runat="server" ControlToValidate="cbo_tipo_operacao"
                                                    CssClass="texto" ErrorMessage="Tipo Operação deve ser preenchida." Font-Bold="False"
                                                    ValidationGroup="vg_salvar" EnableTheming="True">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span><span style="color: #000000">Motivo da Saída:</span></td>
                                            <td align="left">
                                                &nbsp;
                                                <asp:DropDownList ID="cbo_motivo_saida" runat="server" CssClass="texto">
                                                </asp:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cbo_motivo_saida"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Natureza de Operação  para continuar."
                                                    Font-Bold="False" ToolTip="Motivo da Saída deve ser preenchida." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Data Estimada da Chegada:</td>
                                            <td align="left">
                                                &nbsp;
                                                <cc4:OnlyDateTextBox ID="txt_dt_estimada" runat="server" CssClass="texto" MaxLength="10"
                                                    Width="96px"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_estimada"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Data Estimada da Chegada do Transportador para continuar."
                                                    Font-Bold="False" ToolTip="Data Estimada de Chegada do Transportador deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Tipo de Frete:</td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:DropDownList ID="cbo_tipo_frete" runat="server"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList><anthem:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cbo_tipo_frete"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Frete  para continuar." Font-Bold="False"
                                                    ToolTip="Frete deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Transportador:</td>
                                            <td align="left" colspan="3">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>&nbsp;
                                                <anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_transportador"
                                        CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
                                        Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                        Font-Bold="False" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar"></anthem:CustomValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Destino:</td>
                                            <td align="left" colspan="3">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>&nbsp;
                                                <anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_cd_cooperativa"
                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Cooperativa para continuar ou selecione-o pela lupa."
                                        Font-Bold="False" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:CustomValidator ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa"
                                        CssClass="texto" ErrorMessage="Cooperativa não cadastrada!" Font-Bold="False"
                                        Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Volume a Carregar:</td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_peso_liquido_estimado" runat="server" CssClass="texto"
                                                    MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                            <td align="right">
                                                <span style="color: #ff0000">*</span>Preço Unitário:</td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_preco_unitario" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                    MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_preco_unitario"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Preço Unitário para continuar."
                                                        Font-Bold="False" ToolTip="Preço Unitário deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Valor do Frete:</td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_valor_frete" runat="server" CssClass="texto" MaxCaracteristica="10"
                                                    MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                            <td align="right">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Romaneio de Entrada Origem?</td>
                                            <td align="left" colspan="3">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_id_romaneio_entrada" runat="server" CssClass="texto"
                                                    MaxLength="10" Width="64px"></cc3:OnlyNumbersTextBox><anthem:CustomValidator ID="cv_romaneio_entrada"
                                                        runat="server" ControlToValidate="txt_id_romaneio_entrada"
                                                        CssClass="texto" ErrorMessage="Romaneio de Entrada não encontrado!"
                                                        Font-Bold="False" Text="[!]" ToolTip="Romaneio de Entrada não encontrado!" ValidationGroup="vg_salvar"></anthem:CustomValidator>
                                                <anthem:Label ID="lbl_romaneio_inf" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Font-Bold="True" UpdateAfterCallBack="True">SAÍDA: 22/03/2024    -    TRANSP.: VIA Lacteos Ltda bgt    -    PESO LÍQUIDO: 83.456    -    SITUAÇÃO: Fechado</anthem:Label></td>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" >
                                    <span style="color: #ff0000"></span>
                                </td>
                                <td class="texto">
                                    &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
	                        
                            <tr>
                                <TD class="titmodulo" align="left" colSpan="2">
                                    Dados do Sistema</td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 4px" class="texto" align=right >
                                </td>
                                <TD style="height: 4px; ">
                                    &nbsp;</td>
                            </tr>
							<TR>
			                    <TD class="texto" align="right" >
                                    Situação:</TD>
			                    <TD  align="left" class="texto" >
                                    &nbsp;<anthem:Label ID="lbl_situacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Font-Bold="False" Font-Italic="False"></anthem:Label></TD>
                            </tr>
                            <tr>
							    <TD class="texto" align="right" >Modificador:</TD>
							    <TD align="left" class="texto"  >
							        &nbsp;<anthem:Label ID="lbl_modificador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
						    </TR>
                            <tr>
                                <td align="right" class="texto" >
                                    <span style="color: #ff0000"> </span>Data Modificação:</td>
                                <td align="left" >
                                    &nbsp;<anthem:Label ID="lbl_dt_modificacao" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>

						</TABLE>
					</TD>
					<TD style="width: 7px"></TD>
				</TR>

				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a"  vAlign="middle" align="left" 
									background="img/faixa_filro.gif">
									&nbsp; &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
									<asp:Image ID="img_salvar_footer" runat="server" ImageUrl="~/img/salvar.gif" /><asp:LinkButton
										ID="lk_concluirFooter" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="1" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
	</body>
</HTML>
