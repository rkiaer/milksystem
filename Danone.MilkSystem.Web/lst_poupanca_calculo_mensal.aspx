<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_calculo_mensal.aspx.vb" Inherits="lst_poupanca_calculo_mensal" %>

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
		<title>Poupança - Cálculo Mensal</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Cálculo Mensal Poupança</STRONG></TD>
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
                                        ErrorMessage="Informe o Mes/Ano de Referência Poupança." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                                <td align="right" style="height: 20px" >
                                    </td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%">
                                    <strong><span style="color: #ff0000">*</span></strong>Referência:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_dt_referencia"
                                        CssClass="caixaTexto" ErrorMessage="Preencha o campo Mes/Ano de Referência para continuar."
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</anthem:RequiredFieldValidator></td>
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
                                <td align="right" style="width: 20%;">
                                    Código Propriedade:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;
                                    <cc5:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto"
                                        Width="72px"></cc5:OnlyNumbersTextBox>
                                    <anthem:CustomValidator ID="cv_referencia" runat="server" Font-Bold="True" ForeColor="White"
                                        ValidationGroup="vg_pesquisar">[!]</anthem:CustomValidator></td>
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
						&nbsp;&nbsp;<asp:Image ID="img_calcular" runat="server" ImageUrl="~/img/icone_calculadora.gif" />
                        <anthem:linkbutton id="lk_calcular" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_calcular" OnClientClick="if (confirm('Esta ação realizará o cálculo Mensal de Poupança das propriedades selecionadas. Deseja prosseguir?' )) return true;else return false;">Calcular</anthem:linkbutton>
                        &nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;" class="texto">
                        &nbsp;Poupança Cálculo Execução:
                        <anthem:Label ID="lbl_id_poupanca_calculo_execucao" runat="server" CssClass="Texto"
                            Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="13" DataKeyNames="id_poupanca_calculo_execucao_itens" AllowPaging="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" __designer:wfdid="w85" OnCheckedChanged="ck_header_CheckedChanged" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" __designer:wfdid="w84" OnCheckedChanged="ck_item_CheckedChanged" AutoPostBack="True"></anthem:CheckBox> 
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" ReadOnly="True" SortExpression="ds_produtor" />
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" SortExpression="ds_propriedade" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Situa&#231;&#227;o">
                                    <itemtemplate>
<asp:Label id="lbl_situacao_calculo" runat="server" __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w25"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_propriedade" runat="server" Text='<%# Bind("id_propriedade") %>' __designer:wfdid="w24"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_produtor" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_produtor" runat="server" Text='<%# Bind("id_produtor") %>' __designer:wfdid="w20"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_produtor" runat="server" Text='<%# Bind("id_produtor") %>' __designer:wfdid="w19"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_poupanca_calculo_execucao_itens" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_poupanca_calculo_execucao_itens" runat="server" Text='<%# Bind("id_poupanca_calculo_execucao_itens") %>' __designer:wfdid="w31"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_poupanca_calculo_execucao_itens" runat="server" Text='<%# Bind("id_poupanca_calculo_execucao_itens") %>' __designer:wfdid="w30"></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id_selecao" Visible="False">
                                    <edititemtemplate>
<asp:Label id="id_selecao" runat="server" Text='<%# Bind("id_selecao") %>' __designer:wfdid="w11"></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_selecao" runat="server" Text='<%# Bind("id_selecao") %>' __designer:wfdid="w9"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_poupanca_calculo_execucao_itens" Visible="False">
                                    <edititemtemplate>
<asp:Label id="st_poupanca_calculo_execucao_itens" runat="server" Text='<%# Bind("st_poupanca_calculo_execucao_itens") %>' __designer:wfdid="w15"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="st_poupanca_calculo_execucao_itens" runat="server" Text='<%# Bind("st_poupanca_calculo_execucao_itens") %>' __designer:wfdid="w13"></asp:Label>
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
                	    <div visible="false"><anthem:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_aderir"  AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" /><anthem:HiddenField ID="hf_dt_referencia_ini" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_dt_referencia_fim" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
