<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_cooperativa_abertura.aspx.vb" Inherits="frm_romaneio_cooperativa_abertura" %>

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
    <title>Romaneio Cooperativa</title>
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
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Abertura Romaneio para Cooperativa</STRONG></TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; ">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style=" height: 25px;" vAlign="middle" align="left"  background="img/faixa_filro.gif">
                                    &nbsp;
                                    <asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif" /><asp:LinkButton
                                        ID="lk_voltar" runat="server" CausesValidation="False">voltar</asp:LinkButton>&nbsp;
                                    |
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/icone_anexar.gif" Visible="False" /><asp:LinkButton
                                        ID="lk_AnexarDocumento" runat="server" ToolTip="Anexar Documento ao Romaneio"
                                        ValidationGroup="vg_salvar" Visible="False">Anexar Documento</asp:LinkButton>
                                    &nbsp; &nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%">
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados do Romaneio</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px" class="texto" align=center colspan="2">
                                    <anthem:Label ID="lbl_informativo_remessa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Font-Italic="True" Font-Size="X-Small" Font-Strikeout="False"
                                        ForeColor="Red" UpdateAfterCallBack="True"></anthem:Label></TD>
							</TR>
                            <tr runat="server" id="tr_romaneio" visible="false">
                                <td align="right" class="texto" style="height: 22px">
                                    <strong>Romaneio:</strong></td>
                                <td class="texto">
                                    &nbsp;<anthem:Label ID="lbl_romaneio_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_situacao" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Font-Bold="True" Font-Italic="True">(Aberto Incompleto por Nota)</anthem:Label></td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align="right"  style="height: 22px">
									<SPAN id="Span2" class="obrigatorio">*</SPAN><STRONG>Estabelecimento:</STRONG>
								</TD>
								<TD class="texto" >
									&nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" AutoPostBack="True"></anthem:DropDownList> 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Estabelecimento para continuar." ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator>
								</TD>
	                        </tr>
                            <tr>
                                <TD class="texto" align=right >
                                    <SPAN id="Span4" class="obrigatorio">*<strong><span style="color: #000000"> Cooperativa:</span></strong></span></td>
                                <TD class="texto" >
                                    &nbsp;<anthem:TextBox ID="txt_cd_cooperativa" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                    &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_cooperativa" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Cooperativas" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_cooperativa" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                    <anthem:Label ID="lbl_nm_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNPJ:</anthem:Label>
                                    <anthem:Label ID="lbl_cd_cnpj" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_cd_cooperativa"
                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Cooperativa para continuar ou selecione-o pela lupa."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cv_cooperativa" runat="server" ControlToValidate="txt_cd_cooperativa"
                                        CssClass="texto" ErrorMessage="Cooperativa não cadastrada!" Font-Bold="true"
                                        Text="[!]" ToolTip="Cooperativa não Cadastrada!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align="right" width="20%">
	                                <SPAN id="Span3" class="obrigatorio">*</span><STRONG> Transportador:</strong></td>
	                            <TD class="texto" >
	                                &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true"
                                        AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                    &nbsp;&nbsp;<anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_transportador"
                                        CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                    <anthem:CustomValidator ID="cv_transportador" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_cd_transportador" CssClass="texto" Display="Dynamic" ErrorMessage="Transportador não cadastrado!"
                                        Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ValidationGroup="vg_salvar"></anthem:CustomValidator>&nbsp;</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align="right" width="22%" style="height: 22px">
	                                <SPAN id="Span1" class="obrigatorio">*</span><STRONG>Motorista:</strong></td>
	                            <TD class="texto" style="height: 22px; ">
	                                &nbsp;<anthem:DropDownList id="cbo_motorista" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoCallBack="True" AutoPostBack="false">
	                                </anthem:DropDownList>&nbsp;
	                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="cbo_motorista"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Motorista para continuar."
	                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
	                                &nbsp;
	                                <anthem:Label ID="lbl_cnh" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
	                                    Font-Bold="True" UpdateAfterCallBack="True" Visible="False">CNH:</anthem:Label>
	                                &nbsp;
	                                <anthem:Label ID="lbl_cd_cnh" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
								</td>
	                        </tr>
	                        <tr>
	                            <td class="texto"  ></td>
	                            <td ></td>
	                        </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados do Veículo</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
	                                <anthem:GridView ID="gridRomaneioCompartimento" runat="server"
	                                    AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
	                                    Font-Names="Verdana" Font-Size="XX-Small" PageSize="7" UpdateAfterCallBack="True"
	                                    Width="80%" CellPadding="4" CssClass="texto" Height="24px" AllowSorting="True">
	                                    <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
	                                    <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
	                                    <Columns>
	                                        <asp:TemplateField HeaderText="Placa">
	                                            <itemtemplate>
<anthem:TextBox id="txt_placa" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" Width="64px" MaxLength="7" UpdateAfterCallBack="True" __designer:wfdid="w13" OnTextChanged="txt_placa_TextChanged"></anthem:TextBox>&nbsp; <anthem:ImageButton id="bt_lupa_veiculo" runat="server" ImageUrl="~/img/lupa.gif" AutoUpdateAfterCallBack="True" Width="15px" ToolTip="Filtrar Veículos" ImageAlign="AbsBottom" Height="15px" BorderStyle="None" __designer:wfdid="w14" CommandName="Lupa"></anthem:ImageButton>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ValidationGroup="vg_salvar" CssClass="texto" ControlToValidate="txt_placa" ErrorMessage="Preencha o campo Placa para continuar." Font-Bold="True" ToolTip="Placa deve ser preenchida." __designer:wfdid="w15">[!]</anthem:RequiredFieldValidator><anthem:CustomValidator id="cmv_placa" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="txt_placa" ErrorMessage="Placa não cadastrada." Font-Bold="True" ToolTip="Placa Não Cadastrada." __designer:wfdid="w16" OnServerValidate="cmv_placa_ServerValidate">[!]</anthem:CustomValidator> 
</itemtemplate>
	                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Placa Principal">
                                                <itemtemplate>
<anthem:CheckBox id="chk_st_placa_principal" runat="server" CssClass="texto" __designer:wfdid="w17"></anthem:CheckBox> 
</itemtemplate>
                                            </asp:TemplateField>
	                                        <asp:TemplateField HeaderText="Compartimento">
	                                            <itemtemplate>
<anthem:DropDownList id="cbo_compartimento" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w18" OnSelectedIndexChanged="cbo_compartimento_SelectedIndexChanged"></anthem:DropDownList>&nbsp;<anthem:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ValidationGroup="vg_salvar" AutoUpdateAfterCallBack="True" CssClass="texto" ControlToValidate="cbo_compartimento" ErrorMessage="Preecha o compartimento para continuar." Font-Bold="True" ToolTip="Compartimento deve ser preenchido." __designer:wfdid="w19">[!]</anthem:RequiredFieldValidator>&nbsp; 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:BoundField HeaderText="Volume M&#225;ximo" ReadOnly="True" />
	                                        <asp:TemplateField HeaderText="Volume L&#237;quido" Visible="False">
	                                            <itemtemplate>
<cc6:OnlyDecimalTextBox id="txt_nr_total_litros" runat="server" CssClass="texto" Width="80px" MaxLength="15" MaxCaracteristica="10" MaxMantissa="4" __designer:wfdid="w20" DecimalSymbol=","></cc6:OnlyDecimalTextBox> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:TemplateField>
	                                            <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" ImageUrl="~/img/icone_excluir.gif" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w9" OnClientClick="if (confirm('Deseja realmente retirar o registro?' )) return true;else return false;" CommandName="delete"></anthem:ImageButton> 
</itemtemplate>
	                                        </asp:TemplateField>
	                                        <asp:BoundField ReadOnly="True" Visible="False" HeaderText="id_index" />
                                            <asp:BoundField HeaderText="id_compartimento" ReadOnly="True" Visible="False" />
                                            <asp:TemplateField HeaderText="comp_cheio" Visible="False">
                                                <itemtemplate>
<asp:Label id="lbl_comp_cheio" runat="server"></asp:Label> 
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
	                            <TD class="texto" "></td>
	                            <TD ></td>
	                        </tr>
			        
                            <tr>
                                <td align="left" class="titmodulo" colspan="2">
                                    Dados Nota Fiscal</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" >
                                </td>
                                <td style="height: 7px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="texto" colspan="2" style="height: 7px">
                                    <table width="95%">
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <strong><span style="color: #ff0000">* </span>Número Nota Fiscal :</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_nr_nota_fiscal" runat="server" CssClass="texto" MaxLength="14"></cc3:OnlyNumbersTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nr_nota_fiscal"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Número Nota Fiscal para continuar."
                                                    Font-Bold="True" ToolTip="Número Nota Fiscal deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="width: 18%">
                                                <strong><span style="color: #ff0000">* </span>Série Nota Fiscal :</strong></td>
                                            <td align="left" style="width: 25%">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_serie_nota_fiscal" runat="server" CssClass="texto" Width="96px"></anthem:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_serie_nota_fiscal"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Série Nota Fiscal para continuar."
                                                    Font-Bold="True" ToolTip="Série Nota Fiscal deve ser preenchido." ValidationGroup="vg_salvar"
                                                    Visible="False">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* </span>Data Emissão da Nota:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc4:OnlyDateTextBox ID="txt_dt_saida_nota" runat="server" CssClass="texto" MaxLength="10"
                                                    Width="96px"></cc4:OnlyDateTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_saida_nota"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Data de Saída da Nota para continuar."
                                                    Font-Bold="True" ToolTip="Data de Saída Nota Fiscal deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* </span>
	    Tipo de Leite:&nbsp; </strong>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:DropDownList ID="cbo_id_item" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cbo_id_item"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                                    Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* </span>Litros Nota Fiscal:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_peso_liquido_nota" runat="server" CssClass="texto"
                                                    MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_nr_peso_liquido_nota"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Peso Líquido Nota para continuar."
                                                    Font-Bold="True" ToolTip="Litros Nota Fiscal deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* </span>Valor Nota:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_valor_nota_fiscal" runat="server" CssClass="texto"
                                                    MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_nr_valor_nota_fiscal"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Valor Nota para continuar." Font-Bold="True"
                                                    ToolTip="Valor Nota deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #000000"><span style="color: #ff0000">* </span>Chave Acesso
                                                    NF-e:</span></strong></td>
                                            <td align="left">
                                                <strong><span style="color: #ff0000">&nbsp;<cc3:OnlyNumbersTextBox ID="txt_ds_chave_nfe"
                                                    runat="server" CssClass="texto" MaxLength="44" Width="360px"></cc3:OnlyNumbersTextBox><asp:CustomValidator ID="cv_ds_chave_nfe" runat="server" CssClass="texto" ErrorMessage="Deve ser informado exatamente 44 dígitos."
                                                        ToolTip="Chave Acesso NF-e deve ser preenchida." ValidationGroup="vg_salvar">[!]</asp:CustomValidator><anthem:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_ds_chave_nfe"
                                                        CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Chave Acesso NF-e  para continuar."
                                                        Font-Bold="True" ToolTip="Chave Acesso NF-e deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></span></strong></td>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* </span>Nr Pedido (PO):</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_nr_po" runat="server" CssClass="texto" MaxLength="10" Width="85px"></anthem:TextBox><anthem:RequiredFieldValidator
                                                    ID="RequiredFieldValidator20" runat="server" ControlToValidate="txt_nr_po" CssClass="texto"
                                                    ErrorMessage="Preencha o campo Nr. PO para continuar." Font-Bold="True" ToolTip="Nr. PO deve ser informado."
                                                    ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* <span style="color: #000000">Tipo Nota Fiscal:</span></span></strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:DropDownList ID="cbo_tipo_nota_fiscal" runat="server" AutoPostBack="false"
                                                    CssClass="texto">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_cbotiponota" runat="server" ControlToValidate="cbo_tipo_nota_fiscal"
                                                    CssClass="texto" ErrorMessage="Tipo Nota Fiscal deve ser preenchido." Font-Bold="True"
                                                    ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">*<span style="color: #000000"> Natureza Operação:</span></span></strong></td>
                                            <td align="left">
                                                &nbsp;&nbsp;<asp:DropDownList ID="cbo_natureza_operacao" runat="server" CssClass="texto">
                                                </asp:DropDownList>
                                                <anthem:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cbo_natureza_operacao"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Natureza de Operação  para continuar."
                                                    Font-Bold="True" ToolTip="Natureza de Operação deve ser preenchida." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">* <span style="color: #000000">Cod.CFOP:</span></span></strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_cd_cfop" runat="server" CssClass="texto" MaxLength="4"
                                                    Width="45px"></cc3:OnlyNumbersTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txt_cd_cfop"
                                                    CssClass="texto" ErrorMessage="Cod. CFOP deve ser preenchido." Font-Bold="True"
                                                    ValidationGroup="vg_salvar" ToolTip="Cod.CFOP deve ser informado.">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                </td>
                                            <td align="left">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">*</span>Frete:</strong></td>
                                            <td align="left">
                                                &nbsp;&nbsp;<anthem:DropDownList ID="cbo_tipo_frete" runat="server" AutoPostBack="True"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList>
                                                <anthem:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cbo_tipo_frete"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Frete  para continuar." Font-Bold="True"
                                                    ToolTip="Frete deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong></strong>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Número CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_nr_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="14"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_nr_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Número CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong>Série CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_serie_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" Width="96px"></anthem:TextBox>
                                                <anthem:RequiredFieldValidator ID="rf_serie_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_serie_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Série CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Série CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Chave CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_ds_chave_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="44" Width="360px"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_ds_chave_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_ds_chave_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Chave CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Chave CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator><strong></strong></td>
                                            <td align="right">
                                                <strong>Valor CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_valor_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_nr_valor_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_valor_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Valor CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>CST CTE:</strong>
                                            </td>
                                            <td align="left" colspan="3">
                                                &nbsp;
                                                <asp:DropDownList ID="cbo_CST_cte" runat="server" CssClass="texto" Enabled="False">
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
                                            <td align="right">
                                                <strong>Valor ICMS CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_valor_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_valor_icms_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor ICMS CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Valor ICMS CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong>Valor BASE ICMS CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_base_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_base_icms_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_base_icms_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor BASE ICMS CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Valor BASE ICMS CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Nr IBGE Origem CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_ibge_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="7" Width="96px"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_ibge_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_ibge_origem_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número IBGE Origem CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Número IBGE Origem CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong>UF Origem CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_uf_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" Width="32px"></anthem:TextBox>
                                                <anthem:RequiredFieldValidator ID="rf_uf_origem_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_uf_origem_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo UF Origem CTE  para continuar."
                                                    Font-Bold="True" ToolTip="UF Origem CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                                <strong>Nr IBGE Destino CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_ibge_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="7" Width="96px"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_ibge_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_ibge_destino_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número IBGE Destino CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Número IBGE Destino CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong>UF Origem CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_uf_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" Width="32px"></anthem:TextBox>
                                                <anthem:RequiredFieldValidator ID="rf_uf_destino_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_uf_destino_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo UF Destino CTE  para continuar."
                                                    Font-Bold="True" ToolTip="UF Destino CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Cod.CFOP CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_cd_cfop_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="4" Width="45px"></cc3:OnlyNumbersTextBox>
                                                <asp:RequiredFieldValidator ID="rf_cd_cfop_cte" runat="server" ControlToValidate="txt_cd_cfop_cte"
                                                    CssClass="texto" Enabled="False" ErrorMessage="Cod. CFOP CTE deve ser preenchido."
                                                    Font-Bold="True" ToolTip="Cod.CFOP CTE deve ser informado." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong>Nr Protocolo CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_nr_protocolo_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="20" Width="96px"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_nr_protocolo_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_protocolo_cte" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número Protocolo CTE  para continuar."
                                                    Font-Bold="True" ToolTip="Número Protocolo CTE deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Data Emissão CTE:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc4:OnlyDateTextBox ID="txt_dt_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="10" Width="96px"></cc4:OnlyDateTextBox><asp:RequiredFieldValidator
                                                        ID="rf_dt_emissao_cte" runat="server" ControlToValidate="txt_dt_emissao_cte"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Data de Emissão CTE para continuar."
                                                        Font-Bold="False" ToolTip="Data de Emissão CTE deve ser preenchido." ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RequiredFieldValidator>
                                                <cc3:OnlyNumbersTextBox ID="txt_hr_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" MaxLength="2" Width="20px"></cc3:OnlyNumbersTextBox>
                                                :
                                                <cc3:OnlyNumbersTextBox ID="txt_mm_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" Width="20px"></cc3:OnlyNumbersTextBox>
                                                :
                                                <cc3:OnlyNumbersTextBox ID="txt_ss_emissao_cte" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Enabled="False" Width="20px"></cc3:OnlyNumbersTextBox>&nbsp;
                                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_hr_emissao_cte"
                                                    CssClass="texto" ErrorMessage="Preencha as horas da Emissão do CTE corretamente para continuar."
                                                    Font-Bold="False" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RangeValidator><asp:RangeValidator
                                                        ID="RangeValidator4" runat="server" ControlToValidate="txt_mm_emissao_cte" CssClass="texto"
                                                        ErrorMessage="Preencha os minutos da Emissão CTE corretamente para continuar."
                                                        Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt_hr_emissao_cte"
                                                            CssClass="texto" ErrorMessage="Preencha o campo Horas em Emissão CTE para continuar."
                                                            Font-Bold="False" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator24" runat="server" ControlToValidate="txt_mm_emissao_cte"
                                                                CssClass="texto" ErrorMessage="Preencha os Minutos em Emissão CTE para continuar."
                                                                Font-Bold="False" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RequiredFieldValidator><asp:RangeValidator
                                                                    ID="RangeValidator5" runat="server" ControlToValidate="txt_ss_emissao_cte" CssClass="texto"
                                                                    ErrorMessage="Preencha os segundos da Emissão CTE corretamente para continuar."
                                                                    Font-Bold="False" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator22" runat="server" ControlToValidate="txt_mm_emissao_cte"
                                                                        CssClass="texto" ErrorMessage="Preencha os Segundos em Emissão CTE para continuar."
                                                                        Font-Bold="False" ToolTip="Os segundos devem ser preenchidos." ValidationGroup="vg_salvar" Enabled="False">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right">
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                   </table>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" >
                                    <strong><span style="color: #ff0000"></span></strong>
                                </td>
                                <td class="texto">
                                    &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="titmodulo" colspan="2">
                                    Dados da 2a Nota Fiscal</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" >
                                </td>
                                <td style="height: 7px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="texto" colspan="2" style="height: 7px">
                                    <table width="95%">
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <strong><span style="color: #ff0000">&nbsp;</span>Tipo da 2a &nbsp;Nota Fiscal:</strong></td>
                                            <td align="left">
                                                &nbsp;&nbsp;<anthem:DropDownList ID="cbo_tipo_nota2" runat="server" AutoPostBack="True"
                                                    AutoUpdateAfterCallBack="True" CssClass="texto">
                                                </anthem:DropDownList></td>
                                            <td align="right">
                                                <strong></strong>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <strong><span style="color: #ff0000">&nbsp;</span>Número Nota Fiscal 2:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc3:OnlyNumbersTextBox ID="txt_nr_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" MaxLength="14"></cc3:OnlyNumbersTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_nr_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Número Nota Fiscal 2 para continuar."
                                                    Font-Bold="True" ToolTip="Número Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="width: 20%">
                                                <strong><span style="color: #ff0000">&nbsp;</span>Série Nota Fiscal 2:</strong></td>
                                            <td align="left" style="width: 25%">
                                                &nbsp;
                                                <anthem:TextBox ID="txt_serie_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" Width="96px"></anthem:TextBox>
                                                <anthem:RequiredFieldValidator ID="rf_serie_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_serie_nota2" CssClass="texto" ErrorMessage="Preencha o campo Série Nota Fiscal 2 para continuar."
                                                    Font-Bold="True" ToolTip="Série Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar"
                                                    Visible="False">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Litros Nota Fiscal 2:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_litros_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_nr_litros_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_litros_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Litros Nota Fiscal 2 para continuar."
                                                    Font-Bold="True" ToolTip="Litros Nota Fiscal 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                            <td align="right">
                                                <strong><span style="color: #ff0000">&nbsp;</span>Valor Nota Fiscal 2:</strong></td>
                                            <td align="left">
                                                &nbsp;
                                                <cc6:OnlyDecimalTextBox ID="txt_nr_valor_nota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" MaxCaracteristica="12" MaxMantissa="2" Width="96px"></cc6:OnlyDecimalTextBox>
                                                <anthem:RequiredFieldValidator ID="rf_valornota2" runat="server" AutoUpdateAfterCallBack="True"
                                                    ControlToValidate="txt_nr_valor_nota2" CssClass="texto" Enabled="False" ErrorMessage="Preencha o campo Valor Nota 2 para continuar."
                                                    Font-Bold="True" ToolTip="Valor Nota 2 deve ser preenchido." ValidationGroup="vg_salvar">[!]</anthem:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
	                        
	                        <TR>
								<TD style="HEIGHT: 13px" class="texto"></TD>
								<TD style="HEIGHT: 13px; "></TD>
							</TR>
                            <tr>
                                <TD class="titmodulo" align="left" colSpan="2">
                                    Dados Pesagem Inicial</td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 6px" class="texto" align=right width="20%">
                                </td>
                                <TD style="height: 6px; ">
                                    &nbsp;</td>
                            </tr>
							<TR>
			                    <TD class="texto" align="right" ><STRONG><span style="color: #ff0000">* </span><strong>Data Pesagem Inicial:</strong></STRONG></TD>
			                    <TD  align="left" class="texto" >
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto" MaxLength="10"  ValidationGroup="vg_salvar" Width="88px"></cc4:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </TD>
                            </tr>
                            <tr>
							    <TD class="texto" align="right" ><STRONG><span style="color: #ff0000">* <strong><span style="color: #000000">Horário:</span></strong></span></STRONG></TD>
							    <TD align="left" class="texto"  >
							        &nbsp;<cc3:OnlyNumbersTextBox ID="txt_hr_ini" runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>
							        :<cc3:OnlyNumbersTextBox ID="txt_mm_ini" runat="server" CssClass="texto" MaxLength="2" Width="17px"></cc3:OnlyNumbersTextBox>&nbsp;
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_hr_ini" CssClass="texto" ErrorMessage="O campo horas de pesagem inicial esta inválido."
                                                        Font-Bold="True" MaximumValue="23" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RangeValidator
                                                            ID="RangeValidator2" runat="server" ControlToValidate="txt_mm_ini" CssClass="texto"
                                                            ErrorMessage="O campo minutos do horário de pesagem inicial é inválido."
                                                            Font-Bold="True" MaximumValue="59" MinimumValue="00" Type="Integer" ValidationGroup="vg_salvar">[!]</asp:RangeValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_hr_ini"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Horas em Horário da Pesagem Inicial para continuar."
                                                                Font-Bold="True" ToolTip="As horas devem ser preenchidas." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_mm_ini"
                                                                    CssClass="texto" ErrorMessage="Preencha os Minutos do Horário da Pesagem Inicial para continuar."
                                                                    Font-Bold="True" ToolTip="Os minutos devem ser preenchidos." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
						    </TR>
                            <tr>
                                <td align="right" class="texto" style="width: 20%; height: 20px">
                                    <strong><span style="color: #ff0000">* </span><strong>Informe a Balança:</strong></strong></td>
                                <td align="left" style="height: 20px">
                                    &nbsp;<anthem:DropDownList ID="cbo_balanca" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False" AutoPostBack="True">
                                        <asp:ListItem Value="02">Portaria 02 - Sa&#237;da</asp:ListItem>
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="rqf_balanca" runat="server" ControlToValidate="cbo_balanca"
                                        CssClass="texto" ErrorMessage="Informe a Balança para continuar." Font-Bold="True"
                                        ValidationGroup="vg_balanca">[!]</asp:RequiredFieldValidator>
                                    &nbsp; &nbsp;
                                    <anthem:Button ID="btn_balanca" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                        OnClientClick="if (confirm('Deseja realmente buscar o peso da balança e atualizá-lo  no campo Pesagem Inicial?' )) {lbl_aguarde.className='aguardedestaque';return true;};else return false; " Text="Ler Balança" ToolTip="Buscar peso da balança"
                                        ValidationGroup="vg_balanca" Enabled="False" />
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" CssClass="aguardenormal"
                                        UpdateAfterCallBack="True" Width="40%">Aguarde... Buscando peso da balança..</anthem:Label></td>
                            </tr>
						    <TR>
						        <TD class="texto" align="right" style="height: 20px" ><STRONG><span style="color: #ff0000">* </span><strong>Pesagem Inicial:</strong></STRONG></TD>
                                <TD style=" height: 20px; " align="left" class="texto" >&nbsp;<cc6:OnlyDecimalTextBox ID="txt_pesagem_inicial" runat="server" MaxCaracteristica="10"
                                                        MaxLength="15" MaxMantissa="4" Width="88px" ToolTip="Pesagem Inicial" ValidationGroup="vg_salvar" CssClass="texto" AutoCallBack="True" AutoUpdateAfterCallBack="True"></cc6:OnlyDecimalTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="Preencha a Pesagem Inicial para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_pesagem_inicial"
                                                        CssClass="texto" ErrorMessage="A Pesagem Inicial deve ter valor maior que zero (0)."
                                                        Font-Bold="True" Operator="GreaterThan" ToolTip="Pesagem Inicial maior que zero."
                                                        ValidationGroup="vg_salvar" ValueToCompare="0" Type="Double">[!]</asp:CompareValidator></TD>
                            </tr>
                            <tr>
							                    <TD class="texto" align="right" style="height: 20px" ><STRONG></STRONG></TD>
							                    <TD style="height: 20px; " align="left">&nbsp;</TD>
						                    </TR>
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
					<TD></TD>
				</TR>

			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_salvar"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
           <anthem:HiddenField ID="hf_id_transportador" runat="server" AutoUpdateAfterCallBack="true" />
           <anthem:HiddenField ID="hf_id_cooperativa" runat="server" AutoUpdateAfterCallBack="true" />
        </form>
						
					
	</body>
</html>
