<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_propriedade.aspx.vb" Inherits="frm_propriedade" %>

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
            alert("Para acessar a lista de produtores, o estabelecimento deve ser informado!");
        }
        else
        {
   	        szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 
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
	<script type="text/javascript"> 

    function ShowDialogTecnicoEducampo() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico_educampo = document.getElementById("hf_id_tecnico_educampo");
           	     
        szUrl = 'lupa_tecnico.aspx?categoria=E';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico_educampo.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>
    <script type="text/javascript"> 

    function ShowDialogTecnicoComquali() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico_comquali = document.getElementById("hf_id_tecnico_comquali");
           	     
        szUrl = 'lupa_tecnico.aspx?categoria=Q';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico_comquali.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="Form1" method="post" runat="server">

			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 7px">&nbsp;</TD>
					<TD class="faixafiltro1" 	style="background-image: url(img/tab_dim.gif)"><STRONG>Propriedade</STRONG></TD>
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
                                    <asp:Image ID="img_novo" runat="server" ImageUrl="img/novo.gif" /><anthem:LinkButton
                                        ID="lk_novo" runat="server">Novo</anthem:LinkButton>&nbsp; |&nbsp;
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/salvar.gif" /><asp:linkbutton id="lk_concluir" runat="server" ValidationGroup="vg_salvar">Salvar</asp:linkbutton></TD>
								<TD class="faixafiltro1a" vAlign="middle" align="right" background="img/faixa_filro.gif"
									colSpan="4">
                                    <asp:LinkButton ID="lk_unidade_producao" runat="server">Unidades de Produção</asp:LinkButton>&nbsp;|&nbsp;
                                    <asp:LinkButton ID="lk_propriedade_treinamento" runat="server">Treinamentos Realizados</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
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
														<TD class="titmodulo" width="25%" colSpan="2" style="height: 15px"> Descrição

                                                        </TD>
													</TR>
													<TR id="CodigoPropriedade" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG>
                                                            <anthem:Label ID="lbl_id_propriedade" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                UpdateAfterCallBack="True">Código:</anthem:Label></STRONG></TD>
														<TD width="77%">&nbsp;<anthem:TextBox ID="txt_id_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="11%" Enabled="False"></anthem:TextBox>
                                                            </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                        
                                                            <STRONG><anthem:Label ID="Label1" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                    UpdateAfterCallBack="True">Código SAP:</anthem:Label></strong></td>
                                                         <td>
                                                            &nbsp;<anthem:TextBox ID="txt_codigo_SAP" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False" Width="11%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <span id="Span1" class="obrigatorio">*</span><strong>Nome Propriedade:</strong></td>
                                                        <td>
                                                            &nbsp;<asp:TextBox ID="txt_nm_propriedade" runat="server" 
                                                                CssClass="texto" Width="40%" MaxLength="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nm_propriedade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Nome para continuar." Font-Bold="True" ValidationGroup="vg_salvar" Display="Dynamic">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span2" class="obrigatorio">*</span><strong>Estabelecimento:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" AutoCallBack="true">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
													<TR id="TrProdutor" runat="server">
														<TD class="texto" align="right" width="23%" style="height: 13px"><span id="Span3" class="obrigatorio">*</span><STRONG> Produtor:</STRONG></TD>
														<TD style="height: 13px" >
    										                &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="texto" Width="64px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="14"></anthem:TextBox>
                                                                  <anthem:ImageButton ID="btn_lupa_produtor" runat="server" BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Produtores" Width="15px" AutoUpdateAfterCallBack="true" />
                                                                  <anthem:Label ID="lbl_nm_pessoa" runat="server" CssClass="texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_cd_pessoa" CssClass="texto" ErrorMessage="Preencha o campo Código do Produtor para continuar ou selecione-o pela lupa." Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                                  <asp:CustomValidator ID="cv_produtor" runat="server" ErrorMessage="Produtor não cadastrado!" Text="[!]" CssClass="texto" Font-Bold="true" ToolTip="Produtor Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                            
                                                        </TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Propriedade Transferida:&nbsp; </strong>
                                                        </td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:Label ID="lbl_st_transferencia" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
													
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 5px">
                                                        </td>
                                                        <td style="height: 5px">
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" style="height: 15px" colspan="2">
                                                            Dados da Propriedade</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 6px">
                                                        </td>
                                                        <td style="height: 6px">
                                                        </td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Inscrição Estadual:</strong></TD>
														<TD>
                                                            &nbsp;<cc3:OnlyNumbersTextBox ID="txt_inscricao_estadual" runat="server" CssClass="texto"
                                                                Width="25%" MaxLength="20"></cc3:OnlyNumbersTextBox></TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Quantidade Animais:</strong>
                                                        </td>
                                                        <td>&nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_qtde_animais" runat="server" CssClass="texto" Width="88px" MaxLength="14"
                                                                ></cc3:OnlyNumbersTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Capacidade Ensacado:</strong>
                                                        </td>
                                                        <td>
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_capac_ensacado" runat="server" CssClass="texto"
                                                                MaxCaracteristica="10" MaxLength="15" MaxMantissa="4" Width="96px"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Capacidade Granel:</strong>
                                                        </td>
                                                        <td>&nbsp;<cc6:OnlyDecimalTextBox ID="txt_nr_capac_granel" runat="server" CssClass="texto"
                                                                 Width="96px" MaxCaracteristica="10" MaxLength="15" MaxMantissa="4"></cc6:OnlyDecimalTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 24px">
                                                            <strong>Volume Leite por Dia:</strong>
                                                        </td>
                                                        <td style="height: 24px">&nbsp;<cc3:OnlyNumbersTextBox ID="txt_nr_vol_leite_dia" runat="server" CssClass="texto"
                                                                MaxLength="10" Width="96px"></cc3:OnlyNumbersTextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Data Inicial:</strong></TD>
														<TD>&nbsp;<cc4:OnlyDateTextBox ID="txt_dt_inicio" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="96px"></cc4:OnlyDateTextBox></TD>
													</TR>
													<TR id="TrTecnico" runat="server">
														<TD class="texto" align="right" width="23%"><STRONG> Técnico Danone:</STRONG></TD>
														<TD >&nbsp;<anthem:TextBox ID="txt_id_tecnico" runat="server" CssClass="texto" Width="64px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="14"></anthem:TextBox>
                                                          <anthem:ImageButton ID="btn_lupa_tecnico" runat="server" BorderStyle="None" Height="15px"
                                                           ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Técnicos" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            &nbsp;<anthem:Label ID="lbl_nm_tecnico" runat="server" CssClass="texto" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label><asp:CustomValidator ID="cv_tecnico" runat="server" ControlToValidate="txt_id_tecnico"
                                                                CssClass="texto" ErrorMessage="Técnico não cadastrado!" Font-Bold="true" Text="[!]" ToolTip="Técnico Não Cadastrado!"
                                                                ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                        </TD>
													</TR>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <STRONG>Técnico EDUCAMPO:</strong></td>
                                                        <TD >
                                                            &nbsp;<anthem:TextBox ID="txt_id_tecnico_educampo" runat="server" AutoCallBack="true"
                                                                AutoUpdateAfterCallBack="true" CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>
                                                            <anthem:ImageButton ID="btn_lupa_tecnico_educampo" runat="server" BorderStyle="None" Height="15px"
                                                           ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Técnicos EDUCAMPO" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            &nbsp;<anthem:Label ID="lbl_nm_tecnico_educampo" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                            &nbsp;
                                                            <asp:CustomValidator ID="cv_tecnico_educampo" runat="server" ControlToValidate="txt_id_tecnico_educampo"
                                                                CssClass="texto" ErrorMessage="Técnico EDUCAMPO não cadastrado!" Font-Bold="true"
                                                                Text="[!]" ToolTip="Técnico EDUCAMPO Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Técnico COMQUALI:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_id_tecnico_comquali" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>&nbsp;
                                                            <anthem:ImageButton ID="btn_lupa_tecnico_comquali" runat="server" BorderStyle="None" Height="15px"
                                                           ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Técnicos EDUCAMPO" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            <anthem:Label ID="lbl_nm_tecnico_comquali" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <TD class="texto" align="right" width="23%">
                                                            <STRONG>Técnico FLORA:</strong></td>
                                                        <TD >
                                                            &nbsp;<anthem:TextBox ID="txt_tecnico_flora" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>
                                                            <anthem:ImageButton ID="btn_lupa_tecnico_flora" runat="server" BorderStyle="None" Height="15px"
                                                           ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Técnicos EDUCAMPO" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            &nbsp;<anthem:Label ID="lbl_nm_tecnico_flora" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>
                                                            &nbsp;
                                                            <asp:CustomValidator ID="cv_tecnico_flora" runat="server" ControlToValidate="txt_tecnico_flora"
                                                                CssClass="texto" ErrorMessage="Técnico FLORA não cadastrado!" Font-Bold="true"
                                                                Text="[!]" ToolTip="Técnico FLORA Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Técnico BEA:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_tecnico_bea" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                                                CssClass="texto" MaxLength="14" Width="64px"></anthem:TextBox>&nbsp;
                                                            <anthem:ImageButton ID="btn_lupa_tecnico_bea" runat="server" BorderStyle="None" Height="15px"
                                                           ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Técnicos EDUCAMPO" Width="15px" AutoUpdateAfterCallBack="true" />
                                                            <anthem:Label ID="lbl_nm_tecnico_bea" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;
                                                            <asp:CustomValidator ID="cv_tecnico_bea" runat="server" ControlToValidate="txt_tecnico_bea"
                                                                CssClass="texto" ErrorMessage="Técnico BEA não cadastrado!" Font-Bold="true"
                                                                Text="[!]" ToolTip="Técnico BEA Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Periodicidade da Coleta :</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_periodicidade_coleta" runat="server"
                                                                CssClass="texto" Width="69px" AutoPostBack="True">
                                                                <asp:ListItem Value="2" Selected="True">24 hs</asp:ListItem>
                                                                <asp:ListItem Value="4">48 hs</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tipo Coleta :</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_tipo_coleta" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="69px" Enabled="False">
                                                                <asp:ListItem Value="1" Selected="True">&#205;mpar</asp:ListItem>
                                                                <asp:ListItem Value="2">Par</asp:ListItem>
                                                            </anthem:DropDownList></td>
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
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Rota Par :&nbsp; </strong>
                                                        </td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:Label ID="lbl_rota_par" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <strong>Rota Ímpar :&nbsp; </strong>
                                                        </td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:Label ID="lbl_rota_impar" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Tipo Leite:&nbsp; </strong>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_id_item" runat="server"
                                                                CssClass="texto">
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px"></td>
                                                        <td style="height: 23px"></td>
                                                    </tr>
													<TR>
														<TD class="titmodulo" align="left" colspan="2">
                                                            &nbsp; Logradouro</TD>
													</TR>
													<TR>
														<TD class="texto" style="HEIGHT: 5px" align="right" width="23%"></TD>
														<TD style="HEIGHT: 5px">&nbsp;
															</TD>
													</TR>
                                                    <tr>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">* </span>CEP:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:TextBox ID="txt_cep" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="12%" MaxLength="9" AutoPostBack="True"></anthem:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_cep"
                                                                CssClass="texto" ErrorMessage="Preencha o campo CEP para continuar." Font-Bold="True"
                                                                ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="cv_cep" runat="server" ControlToValidate="txt_cep"
                                                                CssClass="texto" ErrorMessage="CEP não cadastrado!" Font-Bold="true" Text="[!]"
                                                                ToolTip="CEP não cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator></TD>
                                                    </tr>
                                                    <tr>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">* </span>Estado:</strong></TD>
														<TD class="texto" style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_estado" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True" Enabled="False">
                                                        </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estado"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estado para continuar."
                                                                Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
                                                    </tr>
                                                    <tr>
														<TD class="texto" style="HEIGHT: 22px" align="right" width="23%">
                                                            <strong><span style="color: #ff0000">* </span>Cidade:</strong></TD>
														<TD style="HEIGHT: 22px">&nbsp;<anthem:DropDownList ID="cbo_cidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                        </anthem:DropDownList>&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cbo_cidade"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Cidade para continuar." Font-Bold="True" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></TD>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 15px" width="23%">
                                                            <strong>Endereço:</strong></td>
                                                        <td style="height: 15px">
                                                            &nbsp;<anthem:TextBox ID="txt_endereco" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox></td>
                                                    </tr>
													<TR>
														<TD class="texto" align="right" width="23%" style="height: 15px">
                                                            <strong>Numero:</strong></TD>
														<TD style="height: 15px">&nbsp;<cc3:OnlyNumbersTextBox ID="txt_numero" runat="server" CssClass="texto" Width="8%" MaxLength="14"></cc3:OnlyNumbersTextBox>
															</TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Complemento:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_complemento" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox></TD>
													</TR>
													<TR>
														<TD class="texto" align="right" width="23%">
                                                            <strong>Bairro:</strong></TD>
														<TD>&nbsp;<anthem:TextBox ID="txt_bairro" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Width="40%" MaxLength="200"></anthem:TextBox>
															</TD>
													</TR>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Telefone:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<cc5:PhoneTextBox ID="txt_telefone1" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox>
                                                            <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_celular"
                                                                ControlToValidate="txt_telefone1" CssClass="texto" ErrorMessage="Telefone 1 não pode ser igual ao Telefone 2."
                                                                Font-Bold="True" Operator="NotEqual">[!]</anthem:CompareValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>Celular:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<cc5:PhoneTextBox ID="txt_celular" runat="server" CssClass="texto" Width="128px"></cc5:PhoneTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>e-mail:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<anthem:TextBox ID="txt_ds_email" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="50" Width="40%"></anthem:TextBox>
                                                            <anthem:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="txt_ds_email" CssClass="texto" ErrorMessage="Formato de e-mail inválido."
                                                                Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">[!]</anthem:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                            <strong>e-mail2:</strong></td>
                                                        <td style="height: 22px">
                                                            &nbsp;<anthem:TextBox ID="txt_ds_email2" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="50" Width="40%"></anthem:TextBox>
                                                            <anthem:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                ControlToValidate="txt_ds_email2" CssClass="texto" ErrorMessage="Formato de e-mail inválido."
                                                                Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">[!]</anthem:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Contato:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_ds_contato" runat="server" CssClass="texto" MaxLength="100"
                                                                Width="40%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" style="height: 22px" width="23%">
                                                        </td>
                                                        <td style="height: 22px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" valign="top">
                                                            Coordenadas Geográficas</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 5px">
                                                        </td>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Latitude:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_latitude" runat="server" CssClass="texto" MaxCaracteristica="4"
                                                                MaxLength="13" MaxMantissa="8" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Longitude:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc6:OnlyDecimalTextBox ID="txt_longitude" runat="server" CssClass="texto"
                                                                MaxCaracteristica="4" MaxLength="13" MaxMantissa="8" Width="96px"></cc6:OnlyDecimalTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%" style="height: 5px">
                                                        </td>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="titmodulo" colspan="2" >
                                                            Controle Interno</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%" style="height: 5px">
                                                        </td>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Valor Disponível:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:Label ID="txt_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Width="93px"></anthem:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Tipo Propriedade:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:Label ID="lbl_tipo_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" UpdateAfterCallBack="True" Width="93px"></anthem:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Considera Qualidadde:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_considera_qualidade" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                <asp:ListItem Value="S" Selected="True">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Contrato GOLD:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_gold" runat="server"
                                                                CssClass="texto" Enabled="False">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Programa de Incentivo Fiscal:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_incentivo_fiscal" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value="A">Incentivo 5%</asp:ListItem>
                                                                <asp:ListItem Value="B">Incentivo 10%</asp:ListItem>
                                                                <asp:ListItem Value="C">Incentivo 20%</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <asp:CustomValidator ID="cv_incentivofiscal" runat="server" ControlToValidate="cbo_incentivo_fiscal"
                                                                CssClass="texto" ErrorMessage="O Programa de Incentivo Fiscal, transferência de crédito,  incentivo 2,4% e o incentivo 2,1% não podem possuir a opção SIM simultaneamente."
                                                                Font-Bold="true" Text="[!]" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Transferência de Crédito:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_transferencia_credito" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <asp:CustomValidator ID="cv_transferencia_credito" runat="server" ControlToValidate="cbo_transferencia_credito"
                                                                CssClass="texto" ErrorMessage="O incentivo 2,4% e o incentivo 2,1% não podem possuir a opção SIM simultaneamente."
                                                                Font-Bold="true" Text="[!]" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Incentivo 2,1%:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_incentivo_21" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <asp:CustomValidator ID="cv_incentivo21" runat="server" ControlToValidate="cbo_incentivo_21"
                                                                CssClass="texto" ErrorMessage="O incentivo 2,4% e o incentivo 2,1% não podem possuir a opção SIM simultaneamente."
                                                                Font-Bold="true" Text="[!]" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Incentivo 2,4%:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_incentivo_24" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto">
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                                <asp:ListItem Value="N" Selected="True">N&#227;o</asp:ListItem>
                                                            </anthem:DropDownList>
                                                            <asp:CustomValidator ID="cv_incentivo24" runat="server" ControlToValidate="cbo_incentivo_24"
                                                                CssClass="texto" ErrorMessage="O incentivo 2,4% e o incentivo 2,1% não podem possuir a opção SIM simultaneamente."
                                                                Font-Bold="true" Text="[!]" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%" style="height: 23px">
                                                            <span id="Span4" class="obrigatorio">*</span><strong>Estabelecimento de Frete:</strong></td>
                                                        <td style="height: 23px">
                                                            &nbsp;<anthem:DropDownList ID="cbo_estabel_frete" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoPostBack="false" AutoCallBack="true">
                                                            </anthem:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_estabel_frete"
                                                                CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento de Frete para continuar."
                                                                Font-Bold="True" InitialValue="0" ValidationGroup="vg_salvar">[!]</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>Apurar Custo Financeiro:&nbsp; </strong>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;<anthem:DropDownList ID="cbo_calculo_juros" runat="server"
                                                                CssClass="texto">
                                                                <asp:ListItem Selected="True" Value="N">N&#227;o</asp:ListItem>
                                                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                                            </anthem:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto" width="23%">
                                                            <strong>CAR:</strong></td>
                                                        <td>
                                                            &nbsp;<anthem:TextBox ID="txt_ds_car" runat="server" CssClass="texto" MaxLength="50"
                                                                Width="40%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>NIRF:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:TextBox ID="txt_nirf" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="12" Width="10%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>NRP:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:TextBox ID="txt_nrp" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="11" Width="10%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>FARMS:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<anthem:TextBox ID="txt_farms" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="6" Width="10%"></anthem:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="texto"  width="23%">
                                                            <strong>Expiração DQSE:</strong></td>
                                                        <td align="left">
                                                            &nbsp;<cc4:OnlyDateTextBox ID="txt_dt_expiracao_dqse" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" MaxLength="10" Width="80px"></cc4:OnlyDateTextBox></td>
                                                    </tr>
                                                                                                        <tr>
                                                        <td align="right" class="texto" style="height: 7px" width="23%">
                                                        </td>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
													<TR id="tr_poupanca" runat="server">
														<TD colSpan="2">
															<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">Dados da Poupança Leite</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%" style="height: 21px">
                                                                        <strong>Último Período Adesão Poupança Finalizado:</strong></td>
                                                                    <td style="height: 21px">
                                                                        &nbsp;<anthem:Label ID="lbl_poupanca_ultimo_periodo" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
                                                                <tr id="Tr2" runat="server" >
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Data de Adesão Último Período:</strong></td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <anthem:Label ID="lbl_poupanca_adesao_ultimo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                                                            UpdateAfterCallBack="True"></anthem:Label></td>
                                                                </tr>
																<TR>
																	<TD class="texto" align="right" width="23%">
                                                                        <strong>Período Adesão Poupança Aberto:</strong></TD>
																	<TD>&nbsp;<anthem:Label ID="lbl_poupanca_periodo_aberto" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
																<TR>
																	<TD class="texto" align="right" style="height: 21px">
                                                                        <strong>Data de Adesão:</strong></TD>
																	<TD style="height: 21px">&nbsp;<anthem:Label ID="lbl_poupanca_adesao" runat="server" AutoUpdateAfterCallBack="True"
                                                                            CssClass="texto" UpdateAfterCallBack="True"></anthem:Label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR id="tr_dados_sitema" runat="server">
														<TD colSpan="2">
															<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD class="titmodulo" width="23%" colSpan="2" style="height: 15px">Dados do Sistema</TD>
																</TR>
                                                                <tr>
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Situação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_situacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" AutoCallBack="True">
                                                                        </anthem:DropDownList>
                                                                        <asp:CustomValidator ID="cv_situacao" runat="server" ControlToValidate="cbo_situacao"
                                                                            CssClass="texto" ErrorMessage="Propriedade não pode ser DESATIVADA pois possui volume no mes!"
                                                                            Font-Bold="true" Text="[!]" ToolTip="Técnico EDUCAMPO Não Cadastrado!" ValidationGroup="vg_salvar"></asp:CustomValidator></td>
                                                                </tr>
                                                                <tr runat="server" id="Tr3" >
                                                                    <td align="right" class="texto" width="23%">
                                                                        <strong>Motivo Inativação:</strong></td>
                                                                    <td>
                                                                        &nbsp;<anthem:DropDownList ID="cbo_id_motivo_inativacao" runat="server" AutoUpdateAfterCallBack="True"
                                                                CssClass="texto" Enabled="False">
                                                                        </anthem:DropDownList>
                                                                        <anthem:RequiredFieldValidator ID="rfv_motivoinativacao" runat="server" CssClass="texto"
                                                                            ErrorMessage="O motivo de inativação deve ser preenchido!" Font-Bold="True" Visible="False" AutoUpdateAfterCallBack="true" ControlToValidate="cbo_id_motivo_inativacao">[!]</anthem:RequiredFieldValidator></td>
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
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_tecnico_educampo" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_tecnico_comquali" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_id_tecnico_bea" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico_flora" runat="server" AutoUpdateAfterCallBack="true" />
        </div>

                </form>
	</body>
</HTML>
