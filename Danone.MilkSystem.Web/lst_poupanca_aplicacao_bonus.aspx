<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_aplicacao_bonus.aspx.vb" Inherits="lst_poupanca_aplicacao_bonus" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc5" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDecimal" Namespace="RK.TextBox.AjaxOnlyDecimal"
    TagPrefix="cc4" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxCNPJ" Namespace="RK.TextBox.AjaxCNPJ" TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Poupança - Aplicação do Bônus da Poupança</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet"/>
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
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
            alert("O estabelecimento deve ser informado!");
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

</script>
	<script type="text/javascript"> 

    function ShowDialogTecnico() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_tecnico = document.getElementById("hf_id_tecnico");
           	     
        szUrl = 'lupa_tecnico.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_tecnico.value=retorno;
                //alert(retorno);
            } 
         
    }            
    </script>

		<form id="form1" method="post" runat="server">


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Aplicação do Bônus da Poupança</STRONG></TD>
					<TD style="width: 10px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD width="15%" style="width: 20%;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
			                    <td width="15%" align="right" style="height: 20px"></td>
								<td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
    	                        </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 20px;" >
                                    <span class="obrigatorio">*</span>Período Referência Poupança:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList id="cbo_referencia_poupanca" runat="server" CssClass="caixaTexto" AutoCallBack="True" AutoUpdateAfterCallBack="True" Enabled="False">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbo_referencia_poupanca"
                                        ErrorMessage="Informe o Mes/Ano de Referência Poupança." Font-Bold="True" ValidationGroup="vg_pesquisar" InitialValue="0">[!]</asp:RequiredFieldValidator></td>
                                <td align="left" style="height: 20px" colspan="2" >
                                    &nbsp; &nbsp; &nbsp;&nbsp;<anthem:CheckBox ID="chk_bonus_extra_concessao" runat="server"
                                        Text="Concessão Bônus Extra" Visible="False" />
                                    &nbsp; &nbsp; &nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;">
                                    Código Produtor:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 22px;">
                                    Código Propriedade:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;
                                    <cc5:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto"
                                        Width="72px"></cc5:OnlyNumbersTextBox>
                                    </td>
                                <td align="right" style="height: 22px">
                                    Cluster:</td>
                                <td align="left" style="height: 22px">
                                    &nbsp;
                                    <asp:DropDownList ID="cbo_cluster" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Aplicação do Bonus&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;<anthem:DropDownList id="cbo_aplicacao_bonus" runat="server" CssClass="caixaTexto">
                                        <asp:ListItem Selected="True" Value="0">[Selecione]</asp:ListItem>
                                        <asp:ListItem Value="1">B&#244;nus Aplicado na Central</asp:ListItem>
                                        <asp:ListItem Value="2">B&#244;nus Aplicado em Lan&#231;amentos</asp:ListItem>
                                        <asp:ListItem Value="3">B&#244;nus N&#227;o Aplicado</asp:ListItem>
                                    </anthem:DropDownList></td>
                                <td align="right" style="height: 20px">
                                    Código Propriedade Titular:&nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <cc5:OnlyNumbersTextBox ID="txt_propriedade_titular" runat="server" CssClass="caixaTexto"
                                        Width="72px"></cc5:OnlyNumbersTextBox></td>
                            </tr>
							<tr>
			                    <td align="right" style="width: 20%; height: 25px"></td>
			                    <td align="right" style="height: 25px"></td>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    &nbsp;
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						<table class="texto" width="100%"><tr><td align="left">&nbsp;&nbsp;<asp:Image ID="img_calcular" runat="server" ImageUrl="~/img/icone_calculadora.gif" />
                        <anthem:linkbutton id="lk_bonus_central" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_bonus_central" OnClientClick="if (confirm('Esta ação aplicará o Bônus de Poupança na Central de Compras para propriedades selecionadas. Deseja prosseguir?' )) return true;else return false;">Aplicar Bônus na Central</anthem:linkbutton>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/img/icone_calculadora.gif" /><anthem:LinkButton ID="lk_bonus_lancamento" runat="server" AutoUpdateAfterCallBack="True"
                            Enabled="False" OnClientClick="if (confirm('Esta ação aplicará o Bônus de Poupança em Lançamentos do próximo cálculo para propriedades selecionadas. Deseja prosseguir?' )) return true;else return false;"
                            ValidationGroup="vg_bonus_lancamento">Aplicar Bônus em Lançamento</anthem:LinkButton></td>
                            <td align="right">
                                Motivo Concessão Bônus Extra:
                                <anthem:DropDownList id="cbo_motivoconcessaobonus" runat="server" CssClass="caixaTexto" AutoCallBack="True" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_bonus_extra">
                                </anthem:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="cbo_motivoconcessaobonus" ErrorMessage="Informe o Mes/Ano de Referência Poupança."
                                    Font-Bold="True" InitialValue="0" ValidationGroup="vg_bonus_extra">[!]</asp:RequiredFieldValidator>
                                <anthem:CustomValidator ID="cv_concederbonus" runat="server" AutoUpdateAfterCallBack="True"
                                    ForeColor="White" ValidationGroup="vg_bonus_extra">[!]</anthem:CustomValidator>&nbsp;
                                <anthem:LinkButton ID="lk_conceder_bonus_extra" runat="server" AutoUpdateAfterCallBack="True"
                            Enabled="False" OnClientClick="if (confirm('Esta ação concederá Bônus Extra para as propriedades selecionadas que não atingiram o Spend. Deseja prosseguir?' )) return true;else return false;"
                            ValidationGroup="vg_bonus_extra">Conceder Bônus Extra</anthem:LinkButton></td>
                            </tr></table></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;" class="texto">
                        </td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				<tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;" class="texto">
                        <table class="texto" width="100%">
                            <tr>
                                <td class="texto" valign="top">
                                    Situação Poupança:
                                    <anthem:Label ID="lbl_situacao_poupanca" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td valign="top">
                                    Parametro Spend:
                                    <anthem:Label ID="lbl_parametro_spend" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                                <td valign="top">
                                    Último Cálculo Poupança Mensal:
                                    <anthem:Label ID="lbl_ultimo_calculo_poupanca" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label></td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				<tr>
                    <TD style=" width: 9px;" valign="bottom">
                    </td>
                    <TD vAlign="bottom" class="texto">
                                    <table border="0" cellpadding="0" cellspacing="0" class="texto" style="margin-bottom: 0px;
                                        padding-bottom: 0px; vertical-align: text-bottom; height: 8px; text-align: left">
                                        <tr>
                                            <td id="td_aba1" runat="server" align="left" class="texto" style="font-size: 1px;
                                                vertical-align: text-bottom; height: 6px">
                                                <anthem:Panel ID="pnl_panel1" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_ativa_media.gif"
                                                    CssClass="texto" ForeColor="#0000F5" Height="23px" HorizontalAlign="Center" Width="165px">
                                                    &nbsp; &nbsp;&nbsp;
                                                    <anthem:LinkButton ID="btn_aba_produtores" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" ForeColor="#0000F5" Width="80%">Produtores</anthem:LinkButton></anthem:Panel>
                                                &nbsp; &nbsp; &nbsp;</td>
                                            <td id="td_aba2" runat="server" align="left" style="font-size: 1px; vertical-align: text-bottom;
                                                height: 6px; width: 137px;">
                                                <anthem:Panel ID="pnl_panel2" runat="server" AutoUpdateAfterCallBack="True" BackImageUrl="~/img/aba_nao_ativa_media.gif"
                                                    CssClass="texto" Height="23px" HorizontalAlign="Center" Width="166px">
                                                    &nbsp; &nbsp; &nbsp;
                                                    <anthem:LinkButton ID="btn_aba_grupo" runat="server" AutoUpdateAfterCallBack="True"
                                                        CssClass="texto" ForeColor="#6767CC">Grupo Relacionamento</anthem:LinkButton></anthem:Panel>
                                                &nbsp; &nbsp;
                                            </td>
                                            <td align="center" style="width: 135px; height: 6px">
                                            </td>
                                        </tr>
                                    </table>
                    </td>
                    <TD valign="bottom">
                    </td>
                </tr>
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" valign="top" >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="13" DataKeyNames="id_poupanca_adesao" AllowPaging="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w88" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w1" Checked='<%# bind("st_selecao") %>' AutoPostBack="True" OnCheckedChanged="ck_item_CheckedChanged"></anthem:CheckBox> 
</itemtemplate>
                                    <headerstyle width="5%" horizontalalign="Left" />
                                    <itemstyle width="5%" horizontalalign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor_abreviado" ReadOnly="True" SortExpression="ds_produtor_abreviado" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Propriedade" DataField="id_propriedade" SortExpression="id_propriedade" ReadOnly="True" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_cluster" HeaderText="Cluster" SortExpression="nm_cluster" />
                                <asp:BoundField DataField="dt_adesao" HeaderText="Ades&#227;o" SortExpression="dt_adesao" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_tempo_adesao" HeaderText="Tempo Ades&#227;o" SortExpression="nr_tempo_adesao" >
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade_titular" HeaderText="Prop. Titular" />
                                <asp:BoundField DataField="dt_ref_ini_calc" HeaderText="Ref. In&#237;cio" SortExpression="dt_ref_ini_calc">
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Volume">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_volume" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w42" Text='<%# bind("nr_valor_volume_leite") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Compras Central">
                                    <itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_compras_central" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w43" Text='<%# bind("nr_valor_compras_central") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor B&#244;nus">
                                    <itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w44" Text='<%# bind("nr_valor_bonus_poupanca") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spend" SortExpression="nr_valor_spend">
                                    <itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_valor_spend" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w45" Text='<%# bind("nr_valor_spend") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="%">
                                    <itemtemplate>
&nbsp;<anthem:Label id="lbl_nr_bonus_extra_spend" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w4" Text='<%# bind("nr_bonus_extra_spend") %>'></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B&#244;nus Extra">
                                    <itemtemplate>
<asp:Label id="lbl_valor_bonus_extra" runat="server" __designer:wfdid="w2" Text='<%# bind("nr_valor_bonus_extra") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B&#244;nus Central">
                                    <itemtemplate>
&nbsp;<anthem:Label id="lbl_valor_bonus_central" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w4"></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_motivo_bonus_concessao" HeaderText="Motivo Concess&#227;o B&#244;nus Extra" />
                                <asp:TemplateField HeaderText="Central">
                                    <itemtemplate>
&nbsp;<anthem:Image id="img_bonus_central" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w48"></anthem:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lanc.">
                                    <itemtemplate>
<anthem:Image id="img_bonus_lancamento" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_chk_false.gif" __designer:wfdid="w3"></anthem:Image> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w58" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w57" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_produtor" runat="server" __designer:wfdid="w56" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_produtor" runat="server" __designer:wfdid="w55" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_poupanca_adesao" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_poupanca_adesao" runat="server" __designer:wfdid="w7" Text='<%# Bind("id_poupanca_adesao") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_poupanca_adesao" runat="server" __designer:wfdid="w6" Text='<%# Bind("id_poupanca_adesao") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="dt_bonus_aplicacao" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_dt_bonus_aplicacao" runat="server" __designer:wfdid="w13" Text='<%# Bind("dt_bonus_aplicacao") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_bonus_poupanca_central" Visible="False">
                                    <itemtemplate>
<asp:Label id="st_bonus_central" runat="server" __designer:wfdid="w8" Text='<%# Bind("st_bonus_poupanca_central") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_bonus_poupanca_lancamento" Visible="False">
                                    <itemtemplate>
<asp:Label id="st_bonus_lancamento" runat="server" __designer:wfdid="w10" Text='<%# Bind("st_bonus_poupanca_lancamento") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="dt_ref_ini_calc" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_dt_ref_ini_calc" runat="server" __designer:wfdid="w69" Text='<%# Bind("dt_ref_ini_calc") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="valorbonuspoupanca" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_valor_bonus_poupanca" runat="server" __designer:wfdid="w60" Text='<%# bind("nr_valor_bonus_poupanca") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="valorbonustransf" Visible="False">
                                    <edititemtemplate>
<asp:Label id="Label2" runat="server" __designer:wfdid="w63"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_valor_bonus_transf" runat="server" __designer:wfdid="w62" Text='<%# bind("nr_valor_bonus_transferencia") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="valorcentraltransf" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_compras_central_transferencia" runat="server" __designer:wfdid="w4" Text='<%# bind("nr_valor_compras_central_transferencia") %>'></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="valorvolumetransf" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_nr_valor_volume_transferencia" runat="server" __designer:wfdid="w2" Text='<%# Bind("nr_valor_volume_transferencia") %>'></asp:Label>
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
					<TD >&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px">
                        &nbsp;</td>
                    <td style="width: 840px" valign="top">
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px;">&nbsp;
                        </TD>
					<TD style="height: 19px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_bonus_extra"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_bonus_central"  AutoUpdateAfterCallBack="true" /><anthem:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_bonus_lancamento"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_dt_referencia_ini" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_dt_referencia_fim" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
