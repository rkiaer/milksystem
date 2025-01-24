<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_romaneio_relatorio_variacao_volume.aspx.vb" Inherits="lst_romaneio_relatorio_variacao_volume" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Relatório Variação de Volume</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
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
<script type="text/javascript"> 

    function ShowDialogProdutor() 
    
    {
        
        // var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_pessoa = document.getElementById("hf_id_pessoa");
        //idcboestabel = document.getElementById("cbo_estabelecimento").value;
    
        //if (idcboestabel == "0")
        //{
        //    alert("O estabelecimento deve ser informado!");
        //}
        //else
        //{
   	        //szUrl = 'lupa_produtor.aspx?id='+idcboestabel+'';
            szUrl = 'lupa_produtor.aspx';
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_pessoa.value=retorno;
            } 

         //}
    }            
</script>
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 2px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Relatório Romaneio Desvio Marcação de Volume</strong></TD>
					<TD  style="height: 25px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 2px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px; width: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 2px; ">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server"  class="texto"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD  style="height: 12px; width: 18%;"></TD>
								<TD style="height: 12px"></TD>
                                <td colspan="1" style="height: 12px; width: 15%;">
                                </td>
                                <td colspan="1" style="height: 12px; width: 30%;">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 22px; ">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" >
                                    </anthem:DropDownList>
                                    <anthem:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" CssClass="texto" ErrorMessage="Escolha o Estabelecimento para continuar."
                                        Font-Bold="False" InitialValue="0" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator></td>
                                <td style="height: 22px" colspan="3" align="center">
                                    <anthem:CheckBox ID="chk_preromaneio" runat="server" Text="Pré-Romaneio de Transit Point" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px; ">
                                    <anthem:Label ID="lbl_obrigatorio_periodo" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Font-Bold="True" ForeColor="Red" UpdateAfterCallBack="True">*</anthem:Label>Período
                                    de Coleta:</td>
                                <td style="height: 22px">
                                    &nbsp;<cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" AutoUpdateAfterCallBack="True"
                                        Columns="10" CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" AutoUpdateAfterCallBack="True"
                                        Columns="10" CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc2:OnlyDateTextBox>&nbsp;<anthem:RequiredFieldValidator
                                            ID="rf_dt_inicio" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_inicio"
                                            CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                            Font-Bold="False" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                ID="rf_dt_fim" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_fim"
                                                CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="False"
                                                ToolTip="A data final do período deve ser informada." ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                    ID="rfcv_periodo" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_fim"
                                                    ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                    Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                    Type="Date" Font-Bold="False" ValidationGroup="vg_load" CssClass="texto">[!]</anthem:CompareValidator></td>
                                <td style="height: 22px" align="right">
                                    Romaneio:</td>
                                <td colspan="1" style="height: 22px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px"></cc3:OnlyNumbersTextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px; ">
                                    Código SAP:
                                </td>
                                <td style="height: 22px">
                                    &nbsp;<anthem:TextBox ID="txt_cd_sap" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                                <td align="right" style="height: 22px">
                                    Código EPL:</td>
                                <td colspan="1" style="height: 22px">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_cd_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 22px">
                                    Cód. Produtor:</td>
                                <td align="left" style="height: 22px" colspan="3">
                                    &nbsp;<anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="texto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <TD  style="height: 22px" align="right">
                                    Propriedade:</td>
                                <TD style="height: 22px" colspan="3">
                                    &nbsp;<cc3:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />&nbsp;
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right" colspan="3" valign="bottom">
                                    <anthem:CustomValidator ID="cv_desvio" runat="server" AutoUpdateAfterCallBack="True"
                                        ForeColor="White">[!]</anthem:CustomValidator>&nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>
                                    &nbsp;
                                    &nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;&nbsp;&nbsp;
                                    <anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="width: 2px" >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 2px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px; width: 2px;">&nbsp;</TD>
				</TR>
                <tr>
					<TD style="height: 5px; width: 2px;"></TD>
					<TD vAlign="middle" style="height: 5px">
                    </TD>
					<TD style="height: 5px; width: 2px;"></TD>
                </tr>
				
				<TR>
					<TD style="width: 2px">&nbsp;</TD>
					<TD class="texto">
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="15">
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EFF3FB" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabel." >
                                                    <headerstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_tecnico" HeaderText="EPL" SortExpression="nm_abreviado" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_abreviado_produtor" HeaderText="Produtor" >
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="prop" HeaderText="Propriedade" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Matriz?">
                                                    <itemtemplate>
<asp:Label id="lbl_matriz" runat="server" Text='<%# Bind("id_propriedade_matriz") %>' __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ds_dt_coleta" HeaderText="Coleta" DataFormatString="{0:dd/MM/yyyy}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="totallitrosdataanterior" DataFormatString="{0:N0}" HeaderText="LitrosUlt.Col.">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="totallitrosbyromaneio" HeaderText="LitrosRom." DataFormatString="{0:N0}" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="totallitrosbydata" DataFormatString="{0:N0}" HeaderText="LitrosDia">
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_variacao" DataFormatString="{0:N2}" HeaderText="Varia&#231;&#227;o"
                                                    ReadOnly="True" />
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" >
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Varia&#231;&#227;o" Visible="False">
                                                    <itemtemplate>
<asp:Label id="lbl_variacao" runat="server" Text='<%# Bind("nr_variacao", "{0:N2}") %>' __designer:wfdid="w23"></asp:Label>
</itemtemplate>
                                                    <headerstyle horizontalalign="Center" />
                                                    <itemstyle horizontalalign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </anthem:GridView>
										</TD>
					<TD style="width: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px; width: 2px;">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages><asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />


		</form>
	</body>
</HTML>
