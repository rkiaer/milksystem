<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_transferencia_volume.aspx.vb" Inherits="frm_transferencia_volume" %>

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
    <title>Solicitar Cotação</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"></link>
</head>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">

<script type="text/javascript"> 

    function ShowDialogPropriedade() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
  	        
        szUrl = 'lupa_propriedade.aspx';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade.value=retorno;
        } 
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogPropDestino() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade_destino = document.getElementById("hf_id_propriedade_destino");

        szUrl = 'lupa_propriedade.aspx?transf=S';
        
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
        {
            hf_id_propriedade_destino.value=retorno;
        } 
    }            
</script>

	    <form id="Form1" method="post" runat="server">
		    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px; height: 30px;">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif); height: 30px;"><STRONG>Transferência de Volumes</STRONG></TD>
					<TD style="width: 17px; height: 30px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px; height: 13px;" ></TD>
					<TD vAlign="top" align="center" background="images/faixa_filro.gif" style="height: 13px; " class="texto">
						<TABLE id="Table2" height="23" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 238px; height: 25px;" vAlign="middle" align="left" width="238" background="img/faixa_filro.gif">
                                    &nbsp;<asp:Image ID="img_voltar" runat="server" ImageUrl="img/voltar.gif"/><asp:linkbutton id="lk_voltar" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; |&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>
								</TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif" colSpan="4" style="height: 25px">
                                    &nbsp;
                                    <anthem:LinkButton ID="lk_transferir_volumes" runat="server" AutoUpdateAfterCallBack="True"
                                        Style="vertical-align: bottom" ToolTip="Transferir Volumes" ValidationGroup="vg_transferir" Enabled="False">Transferir Volumes</anthem:LinkButton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 17px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD vAlign="top" >
						<TABLE id="Table7" cellSpacing=0 cellPadding=2 width="100%" border=0>
							<TR>
								<TD style="HEIGHT: 15px" class="titmodulo" align="left" colSpan="2">Dados da Propriedade Origem / Destino</TD>
							</TR>
                            <tr>
                                <TD class="texto" align="center" style="height: 22px" colspan="2">
                                    <SPAN id="Span4" class="obrigatorio"></span>&nbsp; &nbsp;
                                    <table border="0" width="100%">
                                        <tr runat="server" id="tr_referencia" visible="false">
                                            <td style="width: 20%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span> Estabelecimento do Romaneio:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="false">
                                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                    Font-Bold="True" InitialValue="0" ToolTip="O campo Estabelecimento deve ser informado."
                                                    ValidationGroup="vg_buscardados">[!]</asp:RequiredFieldValidator></td>
                                            <td style="width: 17%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span> Referência:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_referencia" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" DateMask="MonthYear" MaxLength="7" Width="56px"></cc4:OnlyDateTextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_referencia"
                                                    CssClass="texto" ErrorMessage="Preencha o campo Referência para continuar." Font-Bold="True"
                                                    InitialValue="0" ToolTip="O campo Referência deve ser informado." ValidationGroup="vg_buscardados">[!]</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span> Propriedade Origem:</strong></td>
                                            <td align="left" colspan="1" style="height: 19px">
                                                &nbsp;<anthem:TextBox ID="txt_id_propriedade" runat="server" AutoCallBack="true"
                                                    AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                                <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_id_propriedade"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                        Font-Bold="True" ToolTip="O campo Propriedade deve ser informado." ValidationGroup="vg_buscardados">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                                            ID="cv_propriedade" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade"
                                                            CssClass="texto" Display="Dynamic" ErrorMessage="Propriedade não cadastrado!"
                                                            Font-Bold="true" Text="[!]" ToolTip="Propriedade Não Cadastrada!" ValidationGroup="vg_buscardados"></anthem:CustomValidator></td>
                                            <td style="width: 17%; height: 19px;" align="right">
                                                <strong>Município/Estado:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nm_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                /
                                                    &nbsp;<anthem:Label ID="lbl_cd_uf" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; height: 19px;" align="right">
                                                <strong>Produtor:</strong></td>
                                            <td align="left" colspan="1" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nm_produtor" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 17%; height: 19px;" align="right">
                                                <strong>Incrição Estadual:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_cd_ie" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; height: 19px;" align="right">
                                                <strong><span style="color: #ff0000">*</span> Propriedade Destino:</strong></td>
                                            <td align="left" colspan="1" style="height: 19px">
                                                &nbsp;<anthem:TextBox ID="txt_id_propriedade_destino" runat="server" AutoCallBack="true"
                                                    AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="6" Width="64px"></anthem:TextBox>
                                                <anthem:ImageButton ID="btn_lupa_propriedade_destino" runat="server" AutoUpdateAfterCallBack="true"
	                                    BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
	                                    ToolTip="Filtrar Produtores" Width="15px" />
                                                &nbsp;<anthem:Label ID="lbl_nm_propriedade_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label><asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_id_propriedade_destino"
                                                        CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                        Font-Bold="True" ToolTip="O campo Propriedade deve ser informado." ValidationGroup="vg_buscardados" Visible="False">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                                            ID="CustomValidator1" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade_destino"
                                                            CssClass="texto" Display="Dynamic" ErrorMessage="Propriedade não cadastrado!"
                                                            Font-Bold="true" Text="[!]" ToolTip="Propriedade Não Cadastrada!" ValidationGroup="vg_buscardados" Visible="False"></anthem:CustomValidator><asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_id_propriedade_destino"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Código da Propriedade para continuar ou selecione-o pela lupa."
                                                                Font-Bold="True" ToolTip="O campo Propriedade deve ser informado." ValidationGroup="vg_transferir">[!]</asp:RequiredFieldValidator><anthem:CustomValidator
                                                                    ID="cv_propriedade_destino" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_id_propriedade_destino"
                                                                    CssClass="texto" Display="Dynamic" ErrorMessage="Propriedade não cadastrado!"
                                                                    Font-Bold="true" Text="[!]" ToolTip="Propriedade Não Cadastrada!" ValidationGroup="vg_transferir"></anthem:CustomValidator></td>
                                            <td style="width: 17%; height: 19px;" align="right">
                                                <strong>Município/Estado:</strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_nm_cidade_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                /
                                                <anthem:Label ID="lbl_cd_uf_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; height: 19px;" align="right">
                                                <strong><span style="color: #000000">Produtor Destino:</span></strong></td>
                                            <td align="left" style="height: 19px">
                                                &nbsp;<anthem:Label ID="lbl_produtor_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td style="width: 17%; height: 19px;" align="right">
                                                <strong>Inscrição Estadual Destino:</strong></td>
                                            <td align="left" style="height: 19px">
                                                <anthem:Label ID="lbl_cd_ie_destino" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%; height: 19px">
                                                <strong><span style="color: #ff0000">*</span>UP:</strong></td>
                                            <td align="left" style="height: 19px">
                                            <anthem:DropDownList id="cbo_unid_producao_destino" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" AutoPostBack="false">
	                                </anthem:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cbo_unid_producao_destino"
                                                    CssClass="texto" ErrorMessage="Preencha o campo UP para continuar." Font-Bold="True"
                                                    ValidationGroup="vg_buscardados" Visible="False">[!]</asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_unid_producao_destino"
                                                    CssClass="texto" ErrorMessage="Preencha o campo UP para continuar." Font-Bold="True"
                                                    ValidationGroup="vg_transferir">[!]</asp:RequiredFieldValidator></td>
                                            <td align="right" style="width: 17%; height: 19px">
                                            </td>
                                            <td align="left" style="height: 19px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
	                        <tr id="tr_buscardados" runat="server" visible="false">
	                            <TD class="texto" align=right width="23%" style="height: 7px"></td>
	                            <TD style="height: 7px" align="right"><anthem:Button ID="btn_buscardados" runat="server" Text="Buscar Dados" ToolTip="Buscar Dados" CssClass="texto" AutoUpdateAfterCallBack="True" ValidationGroup="vg_buscardados" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
	                        </tr>
	                        </TABLE>
	                        <table runat=server id="table_body" visible="true" width="100%">
	                        <tr>
	                            <TD style="HEIGHT: 13px" class="titmodulo" align="left" colSpan="2">
                                    Volumes a transferir</td>
	                        </tr>
                            <tr>
                                <TD class="texto" align=center colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <strong>Volume Anual Coletado:</strong></td>
                                            <td align="left" colspan="2">
                                                &nbsp;<anthem:Label ID="lbl_nr_volume_anual_coletado" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" colspan="1">
                                                <strong>Volume Mensal:</strong></td>
                                            <td align="left" colspan="1">
                                                <anthem:Label ID="lbl_nr_volume_mensal" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label>
                                                <anthem:Label ID="lbl_soma_grid" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                    UpdateAfterCallBack="True"></anthem:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                <strong>Volume Selecionado:</strong></td>
                                            <td align="left" colspan="2">
                                                <anthem:Label ID="lbl_nr_volume_selecionado" runat="server" AutoUpdateAfterCallBack="True"
                                                    CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                            <td align="right" colspan="1">
                                            </td>
                                            <td align="left" colspan="1">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
	                        <tr>
	                            <TD class="texto" align=center colspan="2"><anthem:GridView ID="gridResults" runat="server" AutoGenerateColumns="False"
                                        AutoUpdateAfterCallBack="True" CssClass="texto"
                                        Font-Names="Verdana" Font-Size="XX-Small" Height="24px" PageSize="50" UpdateAfterCallBack="True" Width="100%" AddCallBacks="true">
                                    <FooterStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditRowStyle Width="100%" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sel.">
                                            <itemtemplate>
<anthem:CheckBox id="chk_selec" runat="server" AutoUpdateAfterCallBack="True" AutoPostBack="True" CssClass="texto" UpdateAfterCallBack="True" OnCheckedChanged="chk_selec_CheckedChanged" Checked="True" __designer:wfdid="w5"></anthem:CheckBox> 
</itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" ReadOnly="True" />
                                        <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" ReadOnly="True" />
                                        <asp:BoundField DataField="nr_litros" HeaderText="Litros" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Situa&#231;&#227;o" DataField="id_st_romaneio" />
                                        </Columns>
                                    </anthem:GridView>
                                    &nbsp; &nbsp; &nbsp;
                                    &nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp;
                                    <anthem:CustomValidator ID="cv_trasferencia_volume" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_transferir">[!]</anthem:CustomValidator>
                                    <anthem:CustomValidator ID="cv_buscardados" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White" ValidationGroup="vg_buscardados">[!]</anthem:CustomValidator></td>
	                        </tr>
						</TABLE>
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <anthem:Label ID="Label1" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Font-Bold="True" Font-Italic="True" ForeColor="Red" UpdateAfterCallBack="True">Atenção: Ao transferir o volume, todos os pedidos da Central e os lançamentos para cálculo serão transferidos para a propriedade destino.</anthem:Label></TD>
					<TD style="width: 17px"></TD>
				</TR>
				<TR>
					<TD style="width: 7px"></TD>
					<TD>
						<TABLE id="Table11" height="23" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="faixafiltro1a" style="WIDTH: 265px" vAlign="middle" align="left" width="265"
									background="img/faixa_filro.gif">
									&nbsp;<asp:image id="Image2" runat="server" ImageUrl="img/voltar.gif"></asp:image><asp:linkbutton id="lk_voltarFooter" runat="server" CausesValidation="False">voltar</asp:linkbutton>&nbsp; </TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="width: 17px" ></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="validatorSummary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vg_transferir"></asp:ValidationSummary>
            <cc7:AlertMessages ID="messageControl" runat="server" AutoUpdateAfterCallBack="True"
                UpdateAfterCallBack="True"></cc7:AlertMessages>
            <asp:ValidationSummary ID="vs_buscar_dados" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_buscardados" />
           <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_id_propriedade_destino" runat="server" AutoUpdateAfterCallBack="true" />
            &nbsp;
        </form>
	</body>
</HTML>
