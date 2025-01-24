<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_poupanca_adesao.aspx.vb" Inherits="lst_poupanca_adesao" %>

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
		<title>Poupança - Adesão</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Adesão das Propriedades à Poupança</STRONG></TD>
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
                                        ErrorMessage="Informe o Mes/Ano de Referência Poupança." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    <cc3:OnlyDateTextBox ID="dt_referencia_ini" runat="server" CssClass="texto" Visible="False"
                                        Width="76px"></cc3:OnlyDateTextBox>
                                    <cc3:OnlyDateTextBox ID="dt_referencia_fim" runat="server" CssClass="texto" Visible="False"
                                        Width="76px"></cc3:OnlyDateTextBox></td>
                                <td align="right" style="height: 20px" >
                                    </td>
                                <td style="height: 20px">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
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
                                <td align="right" style="width: 20%;">
                                    Código Propriedade:</td>
                                <td align="left" colspan="4" style="height: 22px">
                                    &nbsp;
                                    <cc5:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" CssClass="caixaTexto"
                                        Width="72px"></cc5:OnlyNumbersTextBox></td>
                            </tr>
							<tr>
			                    <td align="right" style="width: 20%; height: 25px"></td>
			                    <td align="right" style="height: 25px"></td>
								<TD style="height: 25px">&nbsp;</TD>
								<TD align="right" style="height: 25px">
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    <anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_aprovar2" runat="server" ImageUrl="~/img/salvar.gif" /><anthem:linkbutton id="lk_incluir_adesao" runat="server" AutoUpdateAfterCallBack="True" Enabled="False" ValidationGroup="vg_aderir" OnClientClick="if (confirm('Esta ação irá incluir as propriedades selecionadas ao processo de Poupança. Deseja prosseguir?' )) return true;else return false;">Incluir Adesão</anthem:linkbutton>
                        &nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="height: 19px; width: 9px;">
                    </td>
                    <TD vAlign="middle" style="height: 19px;">
                        &nbsp;</td>
                    <TD style="height: 19px;">
                    </td>
                </tr>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px;" class="texto">&nbsp;<strong><span style="color: #ff0000">*</span></strong>Data de Adesão:
                        <cc3:OnlyDateTextBox ID="txt_dt_adesao" runat="server" CssClass="texto" Width="100px"></cc3:OnlyDateTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_adesao"
                            ErrorMessage="Informe a Data de Adesão para continuar." Font-Bold="True" ToolTip="Informe a Data de Adesão"
                            ValidationGroup="vg_aderir">[!]</asp:RequiredFieldValidator></TD>
					<TD style="height: 19px;"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; ">&nbsp;</TD>
					<TD  align="center" >
									
                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="20" DataKeyNames="id_poupanca_adesao_selecao" AllowPaging="True">
                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                HorizontalAlign="Center" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <headertemplate>
&nbsp;<asp:CheckBox id="ck_header" runat="server" OnCheckedChanged="ck_header_CheckedChanged" __designer:wfdid="w16" AutoPostBack="True"></asp:CheckBox> 
</headertemplate>
                                    <itemtemplate>
&nbsp;<anthem:CheckBox id="ck_item" runat="server" AutoUpdateAfterCallBack="True" OnCheckedChanged="ck_item_CheckedChanged" __designer:wfdid="w15" AutoPostBack="True"></anthem:CheckBox> 
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Produtor" DataField="ds_produtor" ReadOnly="True" />
                                <asp:BoundField HeaderText="Propriedade" DataField="ds_propriedade" SortExpression="ds_propriedade" ReadOnly="True" />
                                <asp:BoundField DataField="nr_tempo_adesao" HeaderText="Tempo Ades&#227;o" SortExpression="nr_tempo_adesao" />
                                <asp:BoundField DataField="dt_adesao" HeaderText="Data Ades&#227;o" SortExpression="dt_adesao" />
                                <asp:TemplateField HeaderText="id_propriedade" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w3" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_propriedade" runat="server" __designer:wfdid="w2" Text='<%# Bind("id_propriedade") %>'></asp:Label> 
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
                                <asp:TemplateField HeaderText="id_poupanca_adesao_selecao" Visible="False">
                                    <edititemtemplate>
&nbsp;<asp:Label id="id_poupanca_adesao_selecao" runat="server" __designer:wfdid="w5" Text='<%# Bind("id_poupanca_adesao_selecao") %>'></asp:Label> 
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="id_poupanca_adesao_selecao" runat="server" __designer:wfdid="w4" Text='<%# Bind("id_poupanca_adesao_selecao") %>'></asp:Label> 
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="st_adesao_ok" Visible="False">
                                    <edititemtemplate>
<asp:Label id="st_adesao_ok" runat="server" Text='<%# Bind("st_adesao_ok") %>' __designer:wfdid="w29"></asp:Label>
</edititemtemplate>
                                    <itemtemplate>
<asp:Label id="st_adesao_ok" runat="server" Text='<%# Bind("st_adesao_ok") %>' __designer:wfdid="w27"></asp:Label>
</itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <itemtemplate>
<anthem:ImageButton id="img_delete" runat="server" AutoUpdateAfterCallBack="True" ImageUrl="~/img/icone_excluir.gif" UpdateAfterCallBack="True" OnClientClick="if (confirm('Deseja realmente desativar o registro de adesão?' )) return true;else return false;" __designer:wfdid="w20" CommandName="delete" CommandArgument='<%# Bind("id_poupanca_adesao") %>'></anthem:ImageButton>
</itemtemplate>
                                    <headerstyle width="5%" />
                                    <itemstyle width="5%" />
                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
                        <anthem:CustomValidator ID="cv_aderir" runat="server" CssClass="texto" ErrorMessage="Nenhum registro foi selecionado. Por favor, selecione alguma propriedade/up!"
                            ForeColor="White" ValidationGroup="vg_aderir">[!]</anthem:CustomValidator></TD>
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
