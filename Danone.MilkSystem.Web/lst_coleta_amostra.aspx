<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_coleta_amostra.aspx.vb" Inherits="lst_coleta_amostra" %>
<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc6" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Coletas das Amostras</title>
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
</script>

		<form id="form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)" colspan="2"><STRONG> Coleta das Amostras</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px;">&nbsp;</TD>
					<TD vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
                        </TD>
					<TD style="width: 10px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" colspan="2">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" >
							<TR>
								<TD style="height: 12px; width: 13%" ></TD>
								<TD style="height: 12px; width: 30%"></TD>
								<TD style="height: 12px; width: 13%"></TD>
								<TD style="height: 12px"></TD>
                                <td style="width: 13%; height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
							</TR>

                            <tr>
                                <TD style="HEIGHT: 20px; " align="right">
                                    <strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px; ">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto">
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cbo_estabelecimento"
                                        CssClass="texto" ErrorMessage="Preencha o campo Estabelecimento para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    <strong><span style="color: #ff0000">*</span></strong>Data Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" Width="75px" DateMask="MonthYear"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="texto" ErrorMessage="Preencha o campo Data Referência para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px">
                                    Período em Dias:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc6:OnlyNumbersTextBox ID="txt_dia_ini" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px"></cc6:OnlyNumbersTextBox>
                                    à
                                    <cc6:OnlyNumbersTextBox ID="txt_dia_fim" runat="server" CssClass="texto" MaxLength="2"
                                        Width="30px"></cc6:OnlyNumbersTextBox><anthem:RangeValidator ID="RangeValidator1"
                                            runat="server" ControlToValidate="txt_dia_ini" ErrorMessage="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                            MaximumValue="30" MinimumValue="1" ToolTip="O Dia Inicial da 1a Coleta deve estar entre 1 e 30."
                                            Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:RangeValidator
                                                ID="RangeValidator2" runat="server" ControlToValidate="txt_dia_fim" ErrorMessage="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                MaximumValue="30" MinimumValue="1" ToolTip="O Dia Final da 1a Coleta deve estar entre 1 e 30."
                                                Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:RangeValidator><anthem:CompareValidator
                                                    ID="CompareValidator2" runat="server" ControlToCompare="txt_dia_ini" ControlToValidate="txt_dia_fim"
                                                    ErrorMessage="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Operator="GreaterThanEqual" ToolTip="O campo Dia Final do 'Período em Dias' deve ser maior ou igual ao Dia Inicial."
                                                    Type="Integer" ValidationGroup="vg_pesquisar">[!]</anthem:CompareValidator></td>


                                         
                            </tr>
 			                <tr>
			                    <td align="right" style="height: 20px; ">
                                    Cód. Produtor:</td>
								<td style="height: 20px; " colspan="2">
                                    &nbsp;
		                            <anthem:TextBox ID="txt_cd_pessoa" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="true" AutoUpdateAfterCallBack="true" MaxLength="10"></anthem:TextBox>
                                    <anthem:imagebutton ID="img_lupa_produtor" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Produtores"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server"  CssClass="Texto"  Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
    	                        </td>
								<TD style="height: 20px">&nbsp;&nbsp;</td>
                                 <td style="height: 20px" align="right">
                                    Tipo da Coleta:</td>
                                 <td style="height: 20px">
                                     &nbsp;
                                    <asp:DropDownList id="cbo_tipo_coleta" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
 							</tr>
 							
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Cód. Propriedade:</td>
                                <td style="height: 20px; ">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" CssClass="caixaTexto" Width="72px" AutoCallBack="True" AutoUpdateAfterCallBack="True"></anthem:TextBox>
                                    <anthem:imagebutton ID="btn_lupa_propriedade" runat="server" ImageUrl="~/img/lupa.gif" BorderStyle="None" Height="15px" Width="15px" ImageAlign="AbsBottom" ToolTip="Filtrar Propriedades"   AutoUpdateAfterCallBack="true" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" CssClass="texto" Height="16px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp;&nbsp; &nbsp;
                                    </td>
 								<TD style="HEIGHT: 3px; " align="right">
                                    Cód. Propriedade Matriz:</TD>
								<TD style="HEIGHT: 3px">&nbsp;
                                    <asp:TextBox ID="txt_id_propriedade_matriz" runat="server" CssClass="caixaTexto"
                                        MaxLength="10" Width="72px"></asp:TextBox></TD>
                                <td style="height: 3px" align="right">
                                    Rota:</td>
                                <td style="height: 3px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_nm_linha" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                           </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Caderneta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc6:OnlyNumbersTextBox ID="txt_nr_caderneta" runat="server" CssClass="texto" MaxLength="10"
                                        Width="88px"></cc6:OnlyNumbersTextBox></td>
                                <td align="right" style="height: 20px">
                                    &nbsp;Situação Coleta Amostra:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <asp:DropDownList id="cbo_situacao" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                                <td style="height: 20px" align="right">
                                    Situação Caderneta:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_situacao_caderneta" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True">
                                        <asp:ListItem Value="1">Aguardando Coleta</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">Coleta Transmitida</asp:ListItem>
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px; ">
                                    Consistências:</td>
                                <td style="height: 20px; ">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_consistencia" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Value="1">Descarte de Frascos</asp:ListItem>
                                        <asp:ListItem Value="2">Coletas Faltantes</asp:ListItem>
                                        <asp:ListItem Value="3">Amostra Manual Pendente</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; &nbsp; &nbsp;</td>
                                <TD style="HEIGHT: 3px; " align="right">
                                    Motivo não Coleta Amostra:</td>
                                <TD style="HEIGHT: 3px">
                                    &nbsp;

                                    <anthem:DropDownList id="cbo_motivo_nao_coleta" runat="server" CssClass="caixaTexto" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList></td>
                                <td style="height: 3px">
                                </td>
                                <td style="height: 3px">
                                </td>
                            </tr>
                          
							<tr>
								<TD align="left" style="height: 20px">&nbsp;</TD>
                                <td align="left" style="height: 20px">
                                    &nbsp;&nbsp;</td>
                                <td align="left" style="height: 20px">
                                </td>
								<TD align="right" colspan="3">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif"
                                        ValidationGroup="vg_pesquisar" Visible="False" />&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="width: 10px; ">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif" align="right" colspan="2">
						&nbsp;&nbsp;&nbsp;
                        </TD>
					<TD style="HEIGHT: 24px; width: 10px;"></TD>
				</TR>
                <tr>
                    <TD style="width: 9px; height: 24px;">
                        &nbsp;</td>
                    <TD colspan="2" style="height: 30px" align="center" valign="middle">
                        <anthem:Label ID="lbl_referencia" runat="server" AutoUpdateAfterCallBack="True"
                            CssClass="texto" Height="16px" UpdateAfterCallBack="True" Font-Bold="True">Referência:  Mar/2021</anthem:Label>
                        &nbsp; &nbsp; &nbsp;
                        <anthem:Label ID="lbl_periodo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Height="16px" UpdateAfterCallBack="True" Font-Bold="True">Períodos para Coleta das Amostras:</anthem:Label>
                        &nbsp;
                        <anthem:Label ID="lbl_coleta1" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Height="16px" UpdateAfterCallBack="True" Font-Bold="True">1a Coleta de 03 à 06</anthem:Label>
                        &nbsp;&nbsp;
                        <anthem:Label ID="lbl_coleta2" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Height="16px" UpdateAfterCallBack="True" Font-Bold="True">2a Coleta de 10 à 12</anthem:Label>
                        &nbsp;
                        <anthem:Label ID="lbl_coleta3" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Height="16px" UpdateAfterCallBack="True" Font-Bold="True">3a Coleta de 15 à 17</anthem:Label>
                        &nbsp;
                        <anthem:Label ID="lbl_coleta4" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" Font-Bold="True">4a Coleta de 22 à 25</anthem:Label></td>
                    <TD style="width: 10px; height: 24px;">
                        &nbsp;</td>
                </tr>

				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD colspan="2">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15" 
                            GridLines="None">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <headertemplate>
<asp:CheckBox id="ck_header" runat="server" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged" __designer:wfdid="w33"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True" __designer:wfdid="w27"></anthem:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade"/>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" SortExpression="id_propriedade_matriz" />
                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" SortExpression="nm_linha" />
                                <asp:BoundField DataField="id_currentidentity" HeaderText="Caderneta" SortExpression="id_currentidentity" />
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"
                                    SortExpression="id_tipo_coleta_analise_esalq" />
                                <asp:TemplateField HeaderText="Manual">
                                    <itemtemplate>
<anthem:Image id="img_manual" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w24"></anthem:Image>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_coleta" HeaderText="Data Coleta" SortExpression="dt_coleta" />
                                <asp:BoundField DataField="nm_situacao_coleta_amostra" HeaderText="Situa&#231;&#227;o" SortExpression="nm_situacao_coleta_amostra" />
                                <asp:BoundField DataField="nm_motivo_nao_coleta_amostra" HeaderText="Motivo N&#227;o Coleta"
                                    SortExpression="nm_motivo_nao_coleta_amostra" />
                                <asp:BoundField DataField="ds_descricao_frasco" HeaderText="Frasco" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="ds_cd_protocolo_esalq" HeaderText="Protocolo" ReadOnly="True"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="Exp.">
                                    <itemtemplate>
<anthem:Image id="img_exportacao" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w16"></anthem:Image>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_delete" runat="server" ToolTip="Desativar" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True"  OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" CommandName="delete" __designer:wfdid="w8"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_ini_amostra" HeaderText="dt_ini_amostra" ReadOnly="True"
                                    Visible="False" />
                                <asp:BoundField DataField="dt_fim_amostra" HeaderText="dt_fim_amostra" ReadOnly="True"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="st_exportacao" Visible="False">
                                    <itemtemplate>
<asp:Label id="st_exportacao" runat="server" Text='<%# Bind("st_exportacao") %>' __designer:wfdid="w28"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_coleta_amostra_manual" Visible="False">
                                    <itemtemplate>
<asp:Label id="id_coleta_amostra_manual" runat="server" Text='<%# Bind("id_coleta_amostra_manual") %>' __designer:wfdid="w30"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_coleta_amostra_periodo" HeaderText="id_coleta_amostra_periodo"
                                    NullDisplayText="0" Visible="False" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:GridView ID="gridprodutor" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15"
                             GridLines="None" Visible="False">
                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <headertemplate>
<asp:CheckBox id="ck_headerprod" runat="server" AutoPostBack="True" OnCheckedChanged="ck_header_CheckedChanged" __designer:wfdid="w33"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
<anthem:CheckBox id="ck_itemprod" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True" __designer:wfdid="w32"></anthem:CheckBox> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_abreviado" HeaderText="Produtor" SortExpression="nm_abreviado" />
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." SortExpression="id_propriedade"/>
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz" SortExpression="id_propriedade_matriz" />
                                <asp:BoundField DataField="nm_tipo_coleta_analise_esalq" HeaderText="Tipo Coleta"
                                    SortExpression="id_tipo_coleta_analise_esalq" ReadOnly="True" />
                                <asp:BoundField DataField="ds_periodo_dias" HeaderText="Per&#237;odo" SortExpression="ds_periodo_dias" />
                                <asp:TemplateField HeaderText="Manual">
                                    <itemtemplate>
<anthem:Image id="img_amostramanual" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w33"></anthem:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <itemtemplate>
&nbsp;<anthem:ImageButton id="img_deleteprod" runat="server" ToolTip="Desativar" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente desativar o registro?' )) return true;else return false;" CommandName="delete" __designer:wfdid="w34"></anthem:ImageButton> 
</itemtemplate>
                                    <headerstyle width="6%" />
                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                <asp:BoundField DataField="st_situacao_coleta_amostra" HeaderText="st_situacao_coleta_amostra" ReadOnly="True"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="st_coleta_amostra_manual" Visible="False">
                                    <itemtemplate>
<asp:Label id="st_coleta_amostra_manual" runat="server" Text='<%# Bind("st_coleta_amostra_manual") %>' __designer:wfdid="w35"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="dt_ini_amostra" HeaderText="dt_ini_amostra" ReadOnly="True"
                                    Visible="False" />
                                <asp:BoundField DataField="dt_fim_amostra" HeaderText="dt_fim_amostra" ReadOnly="True"
                                    Visible="False" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" Font-Bold="True" ForeColor="#333333" />
                                                        <RowStyle BackColor="#EFF3FB" />

                                        </anthem:GridView>
										</TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" colspan="2" >
                        </TD>
					<TD style="HEIGHT: 2px; width: 10px;">&nbsp;</TD>
				</TR>

				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px" colspan="2">&nbsp;
					</TD>
					<TD style="height: 19px; width: 10px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
            &nbsp;
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_filtros"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
