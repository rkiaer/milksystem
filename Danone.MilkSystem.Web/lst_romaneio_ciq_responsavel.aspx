<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_romaneio_ciq_responsavel.aspx.vb" Inherits="lst_romaneio_ciq_responsavel" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc4" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Controle de Incidente de Qualidade - Responsável</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	

</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");

   	     
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        //if (idcboestabel == "0")
        //{
        //   alert("O estabelecimento deve ser informado!");
        //}
        //else
        {
   	        //szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
   	        szUrl = 'lupa_produtor.aspx';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         }
    }            
</script>
<script type="text/javascript"> 

    function ShowDialogPropriedade() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
        var cd_pessoa=document.getElementById("txt_cd_pessoa").value;
   	     
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        //if (idcboestabel == "0")
        //{
        //    alert("O estabelecimento deve ser informado!");
        //}
        //else
        {
   	        
            //szUrl = 'lupa_propriedade.aspx?id_estabelecimento='+idcboestabel+'&cd_pessoa='+cd_pessoa+'';
            szUrl = 'lupa_propriedade.aspx?&cd_pessoa='+cd_pessoa+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_propriedade.value=retorno;
            } 
        }
    }            
function TABLE3_onclick() {

}

</script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 10px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Controle de Incidente de Qualidade - Responsável</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px; height: 25px;">&nbsp;</TD>
					<TD vAlign="middle" background="img/faixa_filro.gif" align="right" style="height: 25px">
                        </TD>
					<TD style="width: 10px; height: 25px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 10px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto" align="center">
					<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0"  >
							<TR>
								<TD style="height: 2px; width: 15%" ></TD>
								<TD style="height: 2px;"></TD>
								<TD style="height: 2px; width: 10%"></TD>
								<TD style="height: 2px"></TD>
                                <td style="width: 13%; height: 2px">
                                </td>
                                <td style="height: 2px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 26px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 26px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 26px">
                                    <strong><span style="color: #ff0000">*</span></strong>Período Entrada:</td>
                                <td style="height: 26px">
                                    &nbsp;&nbsp;<cc3:OnlyDateTextBox id="txt_dt_hora_entrada_ini" runat="server" CssClass="texto"
                                        DateMask="DayMonthYear" Width="80px" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox>
                                    à
                                    <cc3:OnlyDateTextBox id="txt_dt_hora_entrada_fim" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="80px" AutoUpdateAfterCallBack="True"></cc3:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="txt_dt_hora_entrada_ini" CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                        Font-Bold="False" ValidationGroup="vg_pesquisa" ToolTip="A data inicial do período deve ser informada.">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_hora_entrada_fim"
                                            CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                            ToolTip="A data final do período deve ser informada." ValidationGroup="vg_pesquisa">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_hora_entrada_fim"
                                                ControlToValidate="txt_dt_hora_entrada_ini" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                Type="Date" ValidationGroup="vg_pesquisa">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 26px">
                                    <span style="color: #ff0000">*</span>Emitente:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_emitente" runat="server" AutoCallBack="True" AutoPostBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="vg_load">
                                        <asp:ListItem Selected="True" Value="P">Produtor</asp:ListItem>
                                        <asp:ListItem Value="C">Cooperativa</asp:ListItem>
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_emitente" ErrorMessage="O emitente deve ser informado!"
                                        InitialValue="[Selecione]" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>


                                         
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px; ">
                                    Romaneio:</td>
                                <td style="height: 26px; ">
                                    &nbsp;&nbsp;<cc4:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="64px"></cc4:OnlyNumbersTextBox></td>
                                <TD align="right" style="height: 26px;">
                                    Nr. CIQ:</td>
                                <TD style="height: 26px">
                                    &nbsp;
                                    <cc4:onlynumberstextbox id="txt_nr_ciq" runat="server" cssclass="texto" width="120px" AutoUpdateAfterCallBack="True"></cc4:onlynumberstextbox></td>
                                <td align="right" style="height: 26px">
                                    Rota:</td>
                                <td style="height: 26px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_rota" runat="server" CssClass="caixaTexto" Height="22px"
                                        MaxLength="7" Width="88px" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                </td>
                            </tr>
                          
							<tr>
								<TD align="right" colspan="3" style="height: 26px">&nbsp;</TD>
								<TD align="right" colspan="3" style="height: 26px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisa" AutoUpdateAfterCallBack="True"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif" AutoUpdateAfterCallBack="True"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
</td>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px; width: 10px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 25px" vAlign="middle" background="img/faixa_filro.gif" align="right">
						&nbsp;&nbsp;&nbsp;
                        </TD>
					<TD style="HEIGHT: 25px; width: 10px;"></TD>
				</TR>
				<TR>
					<TD style="height: 5px; width: 10px;"></TD>
					<TD vAlign="middle" style="height: 5px">
                        &nbsp;&nbsp;</TD>
					<TD style="height: 5px; width: 10px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 10px" class="texto">&nbsp;</TD>
					<TD class="texto">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_compartimento" PageSize="6" CssClass="texto">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Det.">
                                    <itemtemplate>
<anthem:ImageButton id="btn_detalhe" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Coletas do Pré-Romaneio" UpdateAfterCallBack="True" ImageUrl="~/img/icon_preview.gif" CommandArgument='<%# bind("id_romaneio_compartimento") %>' __designer:wfdid="w30" CommandName="viewdetalheromaneio"></anthem:ImageButton> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Romaneio" SortExpression="id_romaneio">
                                    <itemtemplate>
<asp:Label id="lbl_id_romaneio" runat="server" Text='<%# Bind("id_romaneio") %>' __designer:wfdid="w32"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                <asp:BoundField DataField="ds_placa_romaneio" HeaderText="Placa Principal" SortExpression="ds_placa_romaneio" />
                                <asp:BoundField DataField="dt_hora_entrada" HeaderText="Entrada" SortExpression="dt_hora_entrada" />
                                <asp:BoundField HeaderText="Placa" ReadOnly="True" DataField="ds_placa_compartimento" >
                                    <itemstyle wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_compartimento" HeaderText="Comp" NullDisplayText="&quot;&quot;" />
                                <asp:BoundField DataField="id_romaneio_compartimento" HeaderText="CIQ" ReadOnly="True" />
                                <asp:BoundField DataField="nr_total_litros" HeaderText="Vol. Rejeitado" />
                                <asp:BoundField DataField="st_responsavel_ciq" HeaderText="Respons&#225;vel" ReadOnly="True" />
                                <asp:TemplateField HeaderText="nr_caderneta" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_caderneta" runat="server" Text='<%# Bind("nr_caderneta") %>' __designer:wfdid="w33"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_romaneio_transbordo" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_st_romaneio_transbordo" runat="server" Text='<%# Bind("st_romaneio_transbordo") %>' __designer:wfdid="w34"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transit_point" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_transit_point" runat="server" Text='<%# Bind("id_transit_point") %>' __designer:wfdid="w35"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_peso_liquido" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_peso_liquido" runat="server" Text='<%# Bind("nr_peso_liquido") %>' __designer:wfdid="w32"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nm_st_romaneio" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_situacao" runat="server" Text='<%# Bind("nm_st_romaneio") %>' __designer:wfdid="w36"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="transportador" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_transportador" runat="server" Text='<%# Bind("nm_abreviado_transportador") %>' __designer:wfdid="w37"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_st_romaneio" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_st_romaneio" runat="server" Text='<%# Bind("id_st_romaneio") %>' __designer:wfdid="w29"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="nr_nota_fiscal" ReadOnly="True"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="st_responsavel_ciq" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_st_responsavel_ciq" runat="server" Text='<%# Bind("st_responsavel_ciq") %>' __designer:wfdid="w38"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_cooperativa" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_cooperativa" runat="server" Text='<%# Bind("id_cooperativa") %>' __designer:wfdid="w38"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transportador" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_transportador" runat="server" Text='<%# Bind("id_transportador") %>' __designer:wfdid="w40"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_transvase" Visible="False">
                                    <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("id_transvase") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("id_transvase") %>' id="Label1"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px" class="texto">&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" >
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>
				
				<TR id="tr_detalhes" runat="server">
					<TD style="width: 10px">&nbsp;</TD>
					<TD valign="top">
					<anthem:Panel ID="pnl_romaneio" runat="server" BackColor="White" CssClass="texto" Font-Bold="True" GroupingText="Detalhes do Romaneio / Compartimento Rejeitado" HorizontalAlign="Center" Width="100%" AutoUpdateAfterCallBack="True" Visible="False">
					
                            <table width="100%" class="borda" style="border-right: 1px ridge; border-bottom: #f0f0f0 1px ridge" id="TABLE3"  cellpadding="0" cellspacing="0">
                                <tr>
                                     <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px;" align="left">
                                         &nbsp;
                                        <anthem:Label ID="lbl_romaneio" runat="server" CssClass="texto">Romaneio:</anthem:Label>&nbsp;<anthem:Label ID="lbl_id_romaneio" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_caderneta" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="left" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_nr_peso_liquido" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_situacao" runat="server" CssClass="texto"></anthem:Label></td><td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">  &nbsp;<anthem:Label
                                             ID="lbl_transbordo" runat="server" CssClass="texto">Transbordo: SIM</anthem:Label>
                                         &nbsp; &nbsp;
                                         <anthem:Label ID="lbl_transit" runat="server" CssClass="texto">Transit Point:</anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_calculado" runat="server" CssClass="texto"></anthem:Label></td>
                                                                       <td style="height: 25px;" align="right">
                                        <anthem:ImageButton ID="btn_fechar" runat="server" AutoUpdateAfterCallBack="True"
                                             ImageUrl="~/img/icone_excluir_desabilitado.gif"
                                            ToolTip="Fechar" UpdateAfterCallBack="True" />
                                    </td>

                                </tr>
                                <tr>
                                    <td align="left" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_transportador" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_nr_ciq" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_placa_compartimento" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_compartimento" runat="server" CssClass="texto"></anthem:Label></td>
                                    <td align="right" style="height: 25px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_resp" runat="server" CssClass="texto">Resp. Incidente:</anthem:Label>
                                        <anthem:DropDownList ID="cbo_responsavel" runat="server" AutoCallBack="True" AutoPostBack="True"
                                        AutoUpdateAfterCallBack="True" CssClass="texto" ValidationGroup="vg_atualizar_resp">
                                            <asp:ListItem Value="P">Produtor</asp:ListItem>
                                            <asp:ListItem Value="C">Cooperativa</asp:ListItem>
                                            <asp:ListItem Value="T">Transportador</asp:ListItem>
                                            <asp:ListItem Value="R">Recep&#231;&#227;o</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="N">Sem Respons&#225;vel</asp:ListItem>
                                        </anthem:DropDownList>
                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cbo_responsavel"
                                            CssClass="texto" ErrorMessage="Preencha o campo Resp. Incidente para continuar."
                                            Font-Bold="False" InitialValue="N" ToolTip="Informe o campo Resp. Incidente para continuar."
                                            ValidationGroup="vg_atualizar_resp">[!]</anthem:RequiredFieldValidator></td>
                                    <td align="left" colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_motivo" runat="server" CssClass="texto">Motivo Troca Resp.:</anthem:Label>
                                        <anthem:DropDownList ID="cbo_motivo" runat="server"
                                        AutoUpdateAfterCallBack="True" CssClass="texto">
                                        </anthem:DropDownList>
                                        <anthem:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cbo_motivo"
                                            CssClass="texto" ErrorMessage="Preencha o campo Motivo Troca Resp. para continuar."
                                            Font-Bold="False" InitialValue="0" ToolTip="Informe o campo Motivo Troca Resp. para continuar."
                                            ValidationGroup="vg_atualizar_resp">[!]</anthem:RequiredFieldValidator></td>
                                    <td colspan="2" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        &nbsp;<anthem:Label ID="lbl_obs" runat="server" CssClass="texto">Obs.:</anthem:Label>
                                        <anthem:TextBox ID="txt_obs_resp" runat="server" MaxLength="200" Width="89%" AutoUpdateAfterCallBack="True"></anthem:TextBox><anthem:RequiredFieldValidator
                                            ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_obs_resp" CssClass="texto"
                                            ErrorMessage="Preencha o campo Obs. para continuar." Font-Bold="False"
                                            InitialValue="0" ToolTip="Informe o campo Obs. em relação ao motivo da troca de responsável para continuar."
                                            ValidationGroup="vg_atualizar_resp">[!]</anthem:RequiredFieldValidator></td>
                                    <td align="right" style="height: 25px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="border-bottom: #f0f0f0 1px solid; height: 25px; font-weight: bold;">
                                        CIQ&nbsp;
                                        <anthem:HyperLink ID="hl_imprimir_ciq" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" ImageUrl="~/img/ic_impressao.gif" NavigateUrl="~/frm_relatorio_CIQ.aspx"
                                            Style="text-align: center" Target="_blank" ToolTip="Relatório CIQ:  Versão para Imprimir."
                                            UpdateAfterCallBack="True"></anthem:HyperLink>&nbsp;
                                        <asp:ImageButton ID="btn_email_ciq" runat="server" CommandArgument='<%# Bind("id_romaneio_compartimento") %>'
                                            CssClass="texto" ImageUrl="~/img/ico_email.gif" OnClientClick="if (confirm('O relatório CIQ será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"
                                            Style="text-align: center" ToolTip="Relatório CIQ - Enviar Email " /></td>
                                    <td align="left" style="font-weight: bold; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp; CIQT&nbsp;
                                        <anthem:HyperLink ID="hl_imprimir_ciqt" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" Enabled="False" ImageUrl="~/img/ic_impressao_desabilitado.gif"
                                            NavigateUrl="~/frm_relatorio_CIQT.aspx" Style="text-align: center" Target="_blank"
                                            ToolTip="Relatório CIQT - Incidente Qualidade Transportador:  Versão para Imprimir."
                                            UpdateAfterCallBack="True"></anthem:HyperLink>&nbsp;
                                        <asp:ImageButton ID="btn_email_ciqt" runat="server" CommandArgument='<%# Bind("id_romaneio_compartimento") %>'
                                            CssClass="texto" Enabled="False" ImageUrl="~/img/ico_email_desabilitado.gif"
                                            OnClientClick="if (confirm('O relatório CIQT será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"
                                            Style="text-align: center" ToolTip="Relatório CIQT - Incidente Qualidade Transportador - Enviar Email " /></td>
                                    <td align="left" style="font-weight: bold; border-bottom: #f0f0f0 1px solid; height: 25px">
                                        &nbsp; CIQR&nbsp;
                                        <anthem:HyperLink ID="hl_imprimir_ciqr" runat="server" AutoUpdateAfterCallBack="True"
                                            CssClass="texto" Enabled="False" ImageUrl="~/img/ic_impressao_desabilitado.gif"
                                            NavigateUrl="~/frm_relatorio_CIQR.aspx" Style="text-align: center" Target="_blank"
                                            ToolTip="Relatório CIQR - Incidente Qualidade Recepção:  Versão para Imprimir."
                                            UpdateAfterCallBack="True"></anthem:HyperLink>&nbsp;
                                        <asp:ImageButton ID="btn_email_ciqr" runat="server" CommandArgument='<%# Bind("id_romaneio_compartimento") %>'
                                            CssClass="texto" Enabled="False" ImageUrl="~/img/ico_email_desabilitado.gif"
                                            OnClientClick="if (confirm('O relatório CIQR será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"
                                            Style="text-align: center" ToolTip="Relatório CIQR - Incidente Qualidade Recepção - Enviar Email " /></td>
                                    <td align="right" colspan="3" style="border-right: #f0f0f0 1px solid; border-bottom: #f0f0f0 1px solid;
                                        height: 25px">
                                        <anthem:CustomValidator ID="cv_responsavel" runat="server" AutoUpdateAfterCallBack="True"
                                            Font-Bold="True" ForeColor="White" ValidationGroup="vg_atualizar_resp">[!]</anthem:CustomValidator>
                                         <anthem:Button ID="btn_atualizar_resp" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Text="Atualizar Responsável CIQ" ToolTip="Atualizar Responsável CIQ" ValidationGroup="vg_atualizar_resp" Visible="False" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                    <td align="right" style="height: 25px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td align="left" colspan="2" style="height: 5px">
                                    </td>
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                    <td align="right" style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                        &nbsp;<anthem:GridView ID="gridProdutor" runat="server"
                            AutoGenerateColumns="False"
                            Font-Names="Verdana" Font-Size="XX-Small" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" DataKeyNames="id_romaneio_uproducao" PageSize="20">
                            <PagerStyle Font-Names="Verdana" Font-Size="XX-Small" />
                            <HeaderStyle Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="ds_pessoa" HeaderText="Produtor" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop. UP" />
                                <asp:BoundField DataField="nm_status_analise_uproducao" HeaderText="Sit. Registro An&#225;lise" />
                                <asp:TemplateField HeaderText="CIQP">
                                    <itemtemplate>
<anthem:HyperLink style="TEXT-ALIGN: center" id="hl_imprimir_ciqp" __designer:dtid="5066575350595681" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" ToolTip="Relatório CIQP:  Versão para Imprimir." Enabled="False" UpdateAfterCallBack="True" ImageUrl="~/img/ic_impressao_desabilitado.gif" __designer:wfdid="w30" NavigateUrl="~/frm_relatorio_CIQP.aspx" Target="_blank"></anthem:HyperLink>&nbsp; <asp:ImageButton style="TEXT-ALIGN: center" id="btn_email" __designer:dtid="5066575350595684" runat="server" CssClass="texto" ToolTip="Relatório CIQP - Enviar Email " Enabled="False" ImageUrl="~/img/ico_email_desabilitado.gif" CommandName="EmailCIQP" CommandArgument='<%# Bind("id_romaneio_compartimento") %>' __designer:wfdid="w31" OnClientClick="if (confirm('O relatório CIQP será enviado à lista de emails informada nos cadastros. Deseja realmente prosseguir?' )) return true;else return false;"></asp:ImageButton>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_status_analise_uproducao" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_status_analise_uproducao" runat="server" Text='<%# Bind("id_status_analise_uproducao") %>' __designer:wfdid="w15"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_unid_producao" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_unid_producao" runat="server" Text='<%# Bind("nr_unid_producao") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_tecnico" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_tecnico" runat="server" Text='<%# Bind("id_tecnico") %>' __designer:wfdid="w32"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" />
                                        </anthem:GridView>
                        <br />
                                       
					</anthem:Panel>				
					</TD>
					<TD style="width: 10px; height: 195px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisa"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="vg_responsavel" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_atualizar_resp"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_descartar"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_receber"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
