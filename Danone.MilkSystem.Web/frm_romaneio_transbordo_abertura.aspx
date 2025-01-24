<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_romaneio_transbordo_abertura.aspx.vb" Inherits="frm_romaneio_transbordo_abertura" %>

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
    	     
            szUrl = 'lupa_transportador.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_transportador.value=retorno;
            } 
    }            
</script>

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); "><STRONG>Abertura Romaneio para Transbordo</STRONG></TD>
					<TD style="width: 7px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; ">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" />
									<asp:LinkButton ID="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">&nbsp;&nbsp;</TD>
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
								<TD style="HEIGHT: 9px" class="texto" align=right width="23%"></TD>
								<TD style="HEIGHT: 9px; width: 749px;"></TD>
							</TR>
	                        <tr>
	                            <TD class="texto" align="right" width="24%" style="height: 22px">
									<SPAN id="Span2" class="obrigatorio">*</SPAN><STRONG>Estabelecimento:</STRONG>
								</TD>
								<TD class="texto" style="width: 749px">
									&nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" AutoPostBack="True"></anthem:DropDownList> 
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="vg_salvar" CssClass="texto" Font-Bold="True" ErrorMessage="Preencha o campo Estabelecimento para continuar." ControlToValidate="cbo_estabelecimento">[!]</asp:RequiredFieldValidator>
								</TD>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%">
	                                <SPAN id="Span3" class="obrigatorio">*</span><STRONG> Transportador:</strong></td>
	                            <TD class="texto" style="width: 749px">
	                                &nbsp;<anthem:TextBox ID="txt_cd_transportador" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
	                                    CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
	                                &nbsp;<anthem:Label ID="lbl_nm_transportador" runat="server" AutoUpdateAfterCallBack="True"
	                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
	                                <anthem:ImageButton ID="btn_lupa_transportador" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
	                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_transportador"
	                                    CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa."
	                                    Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
	                                <anthem:CustomValidator ID="cv_transportador" runat="server" CssClass="texto" ErrorMessage="Transportador não cadastrado!"
	                                    Font-Bold="true" Text="[!]" ToolTip="Transportador Não Cadastrado!" ControlToValidate="txt_cd_transportador" Display="Dynamic" AutoUpdateAfterCallBack="True" ValidationGroup="vg_salvar"></anthem:CustomValidator>&nbsp;</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align="right" width="23%" style="height: 22px">
	                                <SPAN id="Span1" class="obrigatorio">*</span><STRONG>Motorista:</strong></td>
	                            <TD class="texto" style="height: 22px; width: 749px;">
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
                                <TD style="HEIGHT: 22px" class="texto" align=right width="23%">
                                    <STRONG><span style="color: #ff0000">* </span>Rota:</strong></td>
                                <TD class="texto" style="width: 749px">
                                    &nbsp;<anthem:DropDownList id="cbo_rotas" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_rotas"
                                        CssClass="texto" ErrorMessage="Preencha o campo Rotas para continuar." Font-Bold="True"
                                        ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
	                            <TD style="HEIGHT: 22px" class="texto" align=right width="23%"><STRONG><span style="color: #ff0000">* <strong></strong></span>
	    Tipo de Leite:</STRONG></TD>
								<TD class="texto" style="width: 749px"> &nbsp;<anthem:DropDownList id="cbo_id_item" runat="server" CssClass="texto">
                                </anthem:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cbo_id_item"
                                        CssClass="texto" ErrorMessage="Preencha o campo Tipo de Leite para continuar."
                                        Font-Bold="True" ToolTip="Tipo de leite deve ser preenchido." ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 24px" class="texto" align=right width="23%">
                                    <STRONG>Cadernetas:</strong>
                                </td>
                                <TD class="texto" style="width: 749px">
                                    &nbsp;<anthem:Label ID="lbl_cadernetas" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 24px" class="texto" align=right width="23%">
                                    <STRONG>Litros Cadernetas Transbordo:</strong>
                                </td>
                                <TD class="texto" style="width: 749px">
                                    &nbsp;<anthem:Label ID="lbl_soma_nr_peso_liquido_caderneta" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=right width="23%"></td>
	                            <TD style="width: 749px"></td>
	                        </tr>
	                        <tr>
	                            <TD style="HEIGHT: 16px" class="titmodulo" align="left" colSpan="2">Dados do Veículo</td>
	                        </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2">
	                                <br />
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
	                                    </Columns>
	                                </anthem:GridView>
                                    <anthem:CustomValidator ID="cv_verificarvolume" runat="server" ErrorMessage="Litros das Cadernetas do Transbordo é maior que a soma dos compartimentos informados!"
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
	                        
	                        <TR>
								<TD style="HEIGHT: 13px" class="texto" align=right width="23%"></TD>
								<TD style="HEIGHT: 13px; width: 749px;"></TD>
							</TR>
                            <tr>
                                <TD class="titmodulo" align="left" colSpan="2">
                                    Dados Pesagem Inicial</td>
                            </tr>
                            <tr>
                                <TD style="HEIGHT: 6px" class="texto" align=right width="23%">
                                </td>
                                <TD style="height: 6px; width: 749px;">
                                    &nbsp;</td>
                            </tr>
							<TR>
			                    <TD class="texto" align="right" ><STRONG><span style="color: #ff0000">* </span><strong>Data Pesagem Inicial:</strong></STRONG></TD>
			                    <TD  align="left" class="texto" style="width: 749px" >
                                    &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_pesagem_inicial" runat="server" CssClass="texto" MaxLength="10"  ValidationGroup="vg_salvar" Width="88px"></cc4:OnlyDateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dt_pesagem_inicial"
                                        CssClass="texto" ErrorMessage="Preencha a Data da Pesagem Inicial para continuar."
                                        Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                </TD>
                            </tr>
                            <tr>
							    <TD class="texto" align="right" ><STRONG><span style="color: #ff0000">* <strong><span style="color: #000000">Horário:</span></strong></span></STRONG></TD>
							    <TD align="left" class="texto" style="width: 749px" >
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
                                <td align="right" class="texto" style="width: 23%; height: 20px">
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
                                <TD style=" height: 20px; width: 749px;" align="left" class="texto" >&nbsp;<cc6:OnlyDecimalTextBox ID="txt_pesagem_inicial" runat="server" MaxCaracteristica="10"
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
							                    <TD style="height: 20px; width: 749px;" align="left">&nbsp;</TD>
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
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;
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
