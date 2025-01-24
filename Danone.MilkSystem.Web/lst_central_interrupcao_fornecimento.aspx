<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_central_interrupcao_fornecimento.aspx.vb" Inherits="lst_central_interrupcao_fornecimento" %>

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
		<title>Desligamento Produtor/Propriedade</title>
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
            <br />


			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Desligar Produtor por Interrupção de Fornecimento de Leite</STRONG></TD>
					<TD style="width: 10px; height: 27px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 24px; " vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
                        <br />
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" >
                            <tr>
                                <TD  style="width: 20%; height: 29px;" align="right">&nbsp;<span id="Span1" class="obrigatorio">*</span>Estabelecimento:</td>
                                <TD style="HEIGHT: 29px">
                                    &nbsp;<anthem:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" ValidationGroup="gv_estabel" AutoCallBack="True" AutoUpdateAfterCallBack="True">
                                    </anthem:DropDownList>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                         Type="Integer" ValueToCompare="0" ValidationGroup="vg_pesquisar" Display="Dynamic" Font-Bold="True">[!]</asp:CompareValidator></td>
			                    <td align="right" style="height: 29px; width: 15%;">
                                    Mês/Ano Desligamento:</td>
								<td style="height: 29px">
                                    &nbsp;<cc3:OnlyDateTextBox ID="txt_MesAno" runat="server" CssClass="caixatexto" DateMask="MonthYear"
                                        Width="72px" Enabled="False"></cc3:OnlyDateTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; height: 29px;" >
                                    <span class="obrigatorio">*</span>Código Produtor:</td>
                                <td style="height: 29px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_pessoa"
                                        ErrorMessage="Informe o Código de Produtor." Font-Bold="True" ToolTip="Informe o código do produtor."
                                        ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" >
                                    </td>
                                <td style="height: 29px">
                                    &nbsp;<cc5:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto"
                                        Width="72px" Visible="False"></cc5:OnlyNumbersTextBox>&nbsp;
                                </td>
                            </tr>
							<tr>
			                    <td align="right" style="width: 20%; height: 25px"></td>
			                    <td align="right" style="height: 25px"></td>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_aprovar2" runat="server" ImageUrl="~/img/salvar.gif" Visible="False" /><anthem:linkbutton id="lk_desligar" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_desligar" OnClientClick="if (confirm('Esta ação irá interromper todos os pedidos das propriedades selecionadas. Deseja prosseguir?' )) return true;else return false;" Visible="False">Desligar</anthem:linkbutton>
                        &nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 7px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 7px;"></TD>
					<TD style="height: 7px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center"  class="texto" >
                        <anthem:GridView ID="gridPropriedades" runat="server" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" CellPadding="4" CssClass="texto" DataKeyNames="id_propriedade"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None"
                            PageSize="100" UpdateAfterCallBack="True" Width="100%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle BackColor="#2461BF" CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<anthem:ImageButton id="imgselecionar" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/ico_triangulo_cinza.gif" Text="Select" __designer:wfdid="w1" CommandName="Select" CausesValidation="False"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id_propriedade_matriz" HeaderText="Prop.Matriz">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_abreviado_pessoa" HeaderText="Produtor">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cd_uf" HeaderText="UF" ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nm_cidade" HeaderText="Cidade" ReadOnly="True" Visible="False">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Limite 150%" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_limite_mes_bruto" runat="server" __designer:wfdid="w12"></anthem:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descontos" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_desconto" runat="server" __designer:wfdid="w13"></anthem:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pedidos Abertos">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w17"></anthem:Label><anthem:HyperLink id="hl_nr_total_pedidos_abertos" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Visualizar Pedidos Abertos" CssClass="textohlink" UpdateAfterCallBack="True" __designer:wfdid="w18" Target="_blank" Font-Underline="True">[hl_nr_total_pedidos_abertos]</anthem:HyperLink> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Limite Dispon&#237;vel" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_disponivel" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w15"></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vol M&#234;s Estimado">
                                    <itemtemplate>
<anthem:Label id="lbl_nr_valor_mensal_estimado" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w58"></anthem:Label> 
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rend.L&#237;quido">
                                    <itemtemplate>
<asp:Label id="lbl_rendimento_liquido" runat="server" __designer:wfdid="w59"></asp:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ult.Pagto">
                                    <itemtemplate>
<asp:Label id="lbl_ult_pagto" runat="server" __designer:wfdid="w131"></asp:Label>
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <itemtemplate>
<anthem:ImageButton id="img_editar" runat="server" ToolTip="Visualizar Interrupção Fornecimento" ImageUrl="~/img/icone_editar.gif" __designer:wfdid="w2" CommandName="edit"></anthem:ImageButton> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w43"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_cidade" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_cidade" runat="server" Text='<%# Bind("id_cidade") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_estado" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_estado" runat="server" Text='<%# Bind("id_estado") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_cidade_matriz" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_cidade_matriz" runat="server" Text='<%# Bind("id_cidade_matriz") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_estado_matriz" Visible="False">
                                    <edititemtemplate>
&nbsp;
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_estado_matriz" runat="server" Text='<%# Bind("id_estado_matriz") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="matriz" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" Text='<%# Bind("matriz") %>' __designer:wfdid="w45"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_produtor" runat="server" Text='<%# Bind("id_pessoa") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="row_num" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_row_num" runat="server" Text='<%# Bind("row_num") %>' __designer:wfdid="w53"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="indexgridmatriz" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_indexgridmatriz" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" __designer:wfdid="w61"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="volumenomes" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_volumenomes" runat="server" Text='<%# Bind("volumenomes") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <RowStyle BackColor="#EFF3FB" />
                        </anthem:GridView>
                        <anthem:Label ID="lbl_props" runat="server" ForeColor="Red" Style="font-size: 9px" Visible="False" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True">*Pedidos abertos, aprovados ou em aprovação serão cancelados automaticamente.</anthem:Label></TD>
					<TD  >&nbsp;</TD>
				</TR>
				<TR >
					<TD style=" width: 9px; height: 102px;">&nbsp;</TD>
					<TD vAlign="bottom" style="height: 102px; font-size: xx-small;" align="center" class="texto">&nbsp;
					<table style="border-right: silver 1px solid; border-top: silver 1px solid;
                            border-left: silver 1px solid; border-bottom: silver 1px solid; border-collapse: collapse"
                            width="98%" cellspacing="1" class="texto" >
                            <tr>
                                <td align="center" style="border-right: silver 1px solid; height: 34px;">
                                    Rend.Líquido:<br />
                                    <anthem:Label ID="lbl_liquido_provisorio" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label>
                                </td>
                                <td align="center" style="border-right: silver 1px solid; height: 34px;">
                                    Total à Descontar:<br />
                                    <anthem:Label ID="lbl_total_calculo" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" style="border-right: silver 1px solid; height: 34px;">
                                    Rend.Líquido Aprox.:<br />
                                    <anthem:Label ID="lbl_liquido_aprox" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" rowspan="2" style="border-right: silver 1px solid">
                                    <anthem:ImageButton ID="btn_atualizar_totais_pedidos" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" ImageAlign="AbsBottom" ImageUrl="~/img/sincronizar.png" ToolTip="Atualizar Totalizadores" /></td>
                                <td align="center" rowspan="2">
                                    <anthem:CustomValidator ID="cv_desligar" runat="server" CssClass="texto" ErrorMessage="Nenhum registro foi selecionado. Por favor, selecione alguma propriedade/up!"
                            ForeColor="White" ValidationGroup="vg_desligar">[!]</anthem:CustomValidator><anthem:Button
                                            ID="btn_desligar" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                                            Font-Bold="True" ForeColor="#003366" Height="24px" Text="Desligar"
                                            ToolTip="Desliga a propriedade por interrupção de fornecimento de leite" ValidationGroup="vg_desligar" Enabled="False" /></td>
                            </tr>
                            <tr>
                                <td align="center" style="border-right: silver 1px solid; border-top: silver 1px solid;
                                    ">
                                    Total à Depositar:<br />
                                    <anthem:Label ID="lbl_total_deposito" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" style="border-right: silver 1px solid; border-top: silver 1px solid">
                                    Total Exportação Parceiro:<br />
                                    &nbsp; &nbsp;<anthem:Label ID="lbl_total_exportacao" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="center" style="border-right: silver 1px solid; border-top: silver 1px solid">
                                    Pagto Parceiro pelo Produtor:<br />
                                    <anthem:Label ID="lbl_pagto_forn_byprodutor" runat="server" AutoUpdateAfterCallBack="True"
                                        UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                        <anthem:Label ID="lbl_pedido_reaberto" runat="server" AutoUpdateAfterCallBack="True"
                            Font-Size="X-Small" ForeColor="Red" Style="font-size: 9px" UpdateAfterCallBack="True" Visible="False">Esta propriedade não pode ser desligada porque existem pedidos reabertos. Eles devem ser finalizados ou cancelados para dar continuidade ao processo de interrupção.</anthem:Label></TD>
					<TD style="height: 102px;">&nbsp;</TD>
				</TR>
                <tr>
                    <td style="width: 9px; height: 19px">
                    </td>
                    <td style="height: 19px" valign="top" class="texto">
                        <br />
                        <anthem:GridView ID="gridpedidos" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            CellPadding="1" CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333"
                            PageSize="100" UpdateAfterCallBack="True" Width="100%" DataKeyNames="id_central_pedido_notas">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
                                ForeColor="White" />
                            <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#2461BF" />
                            <PagerStyle CssClass="texto" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Produtor">
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_propriedade" HeaderText="Prop." ReadOnly="True">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_central_pedido" HeaderText="Pedido" >
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dt_pedido" HeaderText="Data" DataFormatString="{0:d}">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_situacao" runat="server" __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="nm_fornecedor_20" HeaderText="Fornecedor">
                                    <itemstyle horizontalalign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_nota_fiscal" HeaderText="Nr NF" ReadOnly="True" DataFormatString="{0:N0}">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nr_valor_nf" HeaderText="Valor NF" ReadOnly="True" DataFormatString="{0:N2}">
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Saldo Pagto">
                                    <itemtemplate>
<asp:Label id="lbl_saldo_pagto_fornecedor" runat="server" Text='<%# Bind("nr_valor_a_exportar_bynota", "{0:N2}") %>' __designer:wfdid="w34"></asp:Label> 
</itemtemplate>
                                    <headerstyle backcolor="PaleGreen" />
                                    <itemstyle backcolor="PaleGreen" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pagto Fornec.">
                                    <itemtemplate>
<anthem:DropDownList id="cbo_pagto" __designer:dtid="562984313159687" runat="server" AutoUpdateAfterCallBack="True" ValidationGroup="gv_estabel" CssClass="texto" __designer:wfdid="w91" OnSelectedIndexChanged="cbo_pagto_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Value="D">Danone</asp:ListItem>
<asp:ListItem Value="P">Produtor</asp:ListItem>
<asp:ListItem Value="F">Finalizado</asp:ListItem>
</anthem:DropDownList> 
</itemtemplate>
                                    <headerstyle backcolor="#C0FFC0" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Export.">
                                    <itemtemplate>
<anthem:Label id="lbl_valor_exportacao" __designer:dtid="9851654249644145" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w40"></anthem:Label>
</itemtemplate>
                                    <headerstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="pelo Prod.">
                                    <itemtemplate>
<anthem:Label id="lbl_valor_produtor" __designer:dtid="9851654249644145" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" __designer:wfdid="w90"></anthem:Label> 
</itemtemplate>
                                    <headerstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                    <itemstyle backcolor="#C0FFC0" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Saldo Desc.">
                                    <itemtemplate>
<asp:Label id="lbl_saldo_desconto_produtor" runat="server" Text='<%# Bind("nr_valor_a_descontar_bynota", "{0:N2}") %>' __designer:wfdid="w100"></asp:Label> 
</itemtemplate>
                                    <headerstyle backcolor="#FF8080" />
                                    <itemstyle backcolor="#FF8080" horizontalalign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C&#225;lculo">
                                    <itemtemplate>
<cc4:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_nr_valor_calculo" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="70px" MaxLength="10" __designer:wfdid="w23" MaxCaracteristica="6"></cc4:OnlyDecimalTextBox> 
</itemtemplate>
                                    <headerstyle backcolor="#FFC0C0" />
                                    <itemstyle backcolor="#FFC0C0" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dep&#243;sito">
                                    <itemtemplate>
<cc4:OnlyDecimalTextBox style="TEXT-ALIGN: right" id="txt_nr_valor_deposito" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="70px" MaxLength="10" __designer:wfdid="w24" MaxCaracteristica="6"></cc4:OnlyDecimalTextBox> 
</itemtemplate>
                                    <headerstyle backcolor="#FFC0C0" />
                                    <itemstyle backcolor="#FFC0C0" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Canc" Visible="False">
                                    <itemtemplate>
&nbsp;<anthem:CheckBox id="chk_cancelar" runat="server" AutoUpdateAfterCallBack="True" ToolTip="Cancelar Pedido Danone e informar parceiro " __designer:wfdid="w120"></anthem:CheckBox>
</itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                    <itemstyle horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w103"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade_matriz" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_propriedade_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w104"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_situacao_pedido" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_situacao_pedido" runat="server" Text='<%# Bind("id_situacao_pedido") %>' __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_central_pedido" Visible="False">
                                    <itemtemplate>
<anthem:Label id="lbl_id_central_pedido" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" UpdateAfterCallBack="True" Text='<%# bind("id_central_pedido") %>' __designer:wfdid="w106"></anthem:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_central_pedido_notas" Visible="False">
                                    <edititemtemplate>
&nbsp; 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="lbl_id_central_pedido_notas" runat="server" Text='<%# Bind("id_central_pedido_notas") %>' __designer:wfdid="w73"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_produtor" runat="server" Text='<%# Bind("id_produtor") %>' __designer:wfdid="w107"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_fornecedor" Visible="False">
                                    <itemtemplate>
<asp:Label id="lbl_id_fornecedor" runat="server" Text='<%# Bind("id_fornecedor") %>' __designer:wfdid="w108"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </anthem:GridView>
                    </td>
                    <td style="height: 19px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 9px; height: 19px">
                    </td>
                    <td style="height: 19px" valign="top">
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20" DataKeyNames="id_produtor,id_propriedade,id_unid_producao" Visible="False">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w5" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<asp:CheckBox id="ck_item" runat="server" __designer:wfdid="w4"></asp:CheckBox> 
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" ReadOnly="True" />
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" SortExpression="ds_propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" ReadOnly="True" />
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w6" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w5" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_produtor" runat="server" __designer:wfdid="w4" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_produtor" runat="server" __designer:wfdid="w2" Text='<%# Bind("id_produtor") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="nr_unid_producao" Visible="False">
                                    <edititemtemplate>
<asp:Label id="nr_unid_producao" runat="server" __designer:wfdid="w4" Text='<%# Bind("nr_unid_producao") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="nr_unid_producao" runat="server" __designer:wfdid="w2" Text='<%# Bind("nr_unid_producao") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_unid_producao" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_unid_producao" runat="server" __designer:wfdid="w7" Text='<%# Bind("id_unid_producao") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_unid_producao" runat="server" __designer:wfdid="w5" Text='<%# Bind("id_unid_producao") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                    </td>
                    <td style="height: 19px">
                    </td>
                </tr>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_desligar"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            &nbsp;
        </div>
		</form>
	</body>
</HTML>
