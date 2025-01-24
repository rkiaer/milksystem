<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_util_ExportaVolumeRomaneio.aspx.vb" Inherits="lst_util_ExportaVolumeRomaneio" %>

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
		<title>lst_util_ExportaVolumeRomaneio</title>
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
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Volumes Técnicos</strong></TD>
					<TD width="10" style="height: 25px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center">
						</TD>
					<TD width="10"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 181px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 181px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
                                <td colspan="1" style="height: 12px">
                                </td>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="texto" Width="192px">
                                    </anthem:DropDownList></td>
                                <td style="height: 20px">
                                    <anthem:CheckBox ID="chk_preromaneio" runat="server" Text="Pré-Romaneio de Transit Point" /></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    <anthem:Label ID="lbl_obrigatorio_periodo" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Font-Bold="True" ForeColor="Red" UpdateAfterCallBack="True">*</anthem:Label>Período:</td>
                                <td style="height: 20px" colspan="2">
                                    &nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_inicio" runat="server" AutoUpdateAfterCallBack="True"
                                        Columns="10" CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc2:OnlyDateTextBox>
                                    à
                                    <cc2:OnlyDateTextBox ID="txt_dt_fim" runat="server" AutoUpdateAfterCallBack="True"
                                        Columns="10" CssClass="texto" DateMask="DayMonthYear" Width="80px"></cc2:OnlyDateTextBox>&nbsp;<anthem:RequiredFieldValidator
                                            ID="rf_dt_inicio" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_inicio"
                                            CssClass="texto" ErrorMessage="A data inicial do período deve ser informada."
                                            Font-Bold="True" ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:RequiredFieldValidator
                                                ID="rf_dt_fim" runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_fim"
                                                CssClass="texto" ErrorMessage="A data final do período deve ser informada." Font-Bold="True"
                                                ToolTip="A data final do período deve ser informada." ValidationGroup="vg_load">[!]</anthem:RequiredFieldValidator><anthem:CompareValidator
                                                    ID="rfcv_periodo" runat="server" AutoUpdateAfterCallBack="True" ControlToCompare="txt_dt_fim"
                                                    ControlToValidate="txt_dt_inicio" ErrorMessage="A data inicial do período não pode ser maior que a data final do período."
                                                    Operator="LessThanEqual" ToolTip="A data inicial do período não pode ser maior que a data final do período."
                                                    Type="Date" Font-Bold="True" ValidationGroup="vg_load">[!]</anthem:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código SAP:
                                </td>
                                <td style="height: 20px" colspan="2">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_sap" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Código EPL:</td>
                                <td style="height: 14px" colspan="2">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_cd_tecnico" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True"></anthem:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Cód. Produtor:</td>
                                <td align="left" colspan="2" style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_pessoa" runat="server" AutoCallBack="true" AutoUpdateAfterCallBack="true"
                                        CssClass="caixaTexto" MaxLength="10" Width="72px"></anthem:TextBox>
                                    <anthem:ImageButton ID="btn_lupa_produtor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_pessoa" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Cód. Propriedade:</td>
                                <td colspan="2" style="height: 20px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px" AutoCallBack="True"></cc3:OnlyNumbersTextBox>
                                    <anthem:ImageButton ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Produtores" Width="15px" />
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" Style="vertical-align: bottom" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    Romaneio:</td>
                                <td style="height: 21px">
                                    &nbsp;
                                    <cc3:OnlyNumbersTextBox ID="txt_id_romaneio" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px"></cc3:OnlyNumbersTextBox>
                                </td>
                                <td colspan="" style="height: 21px">
                                </td>
                            </tr>
							<TR>
								<TD></TD>
								<TD align="right" colspan="2">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>
                                    &nbsp;
                                    &nbsp;<anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD style="height: 181px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
                <tr>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle">&nbsp;<table class="texto" style="width: 100%">
                            <tr>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_total_litros_etq" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True">Total Litros:</anthem:Label>
                                </td>
                                <td style="width: 30%">
                                    <anthem:Label ID="lbl_total_litros" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                                <td align="right" style="width: 20%">
                                    <anthem:Label ID="lbl_total_litros_rejeitados_etq" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True">Total Litros Rejeitados por Antibiótico:</anthem:Label></td>
                                <td>
                                    <anthem:Label ID="lbl_total_litros_rejeitados" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                        </table>
                    </TD>
					<TD style="height: 19px"></TD>
                </tr>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Left" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="nm_estabelecimento" HeaderText="Estabelecimento" >
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nr_caderneta" HeaderText="Caderneta" />
                                                <asp:BoundField DataField="nm_linha" HeaderText="Rota" />
                                                <asp:BoundField DataField="nm_tecnico" HeaderText="EPL" SortExpression="nm_tecnico" >
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="EduCampo" DataField="nm_tecnico_educampo" />
                                                <asp:BoundField HeaderText="Cluster" DataField="nm_cluster" />
                                                <asp:BoundField DataField="cd_pessoa" HeaderText="Cod Produtor" />
                                                <asp:BoundField DataField="nm_pessoa" HeaderText="Produtor" />
                                                <asp:BoundField DataField="id_propriedade" HeaderText="Propriedade" />
                                                <asp:BoundField DataField="nr_unid_producao" HeaderText="UP" />
                                                <asp:BoundField DataField="ds_data_coleta" HeaderText="Data Coleta" />
                                                <asp:BoundField DataField="Litros" HeaderText="Litros" />
                                                <asp:BoundField HeaderText="Leite" DataField="ds_status_analise_uproducao" />
                                                <asp:BoundField HeaderText="Rejei&#231;&#227;o Antib." DataField="st_antibiotico" />
                                                <asp:BoundField DataField="id_romaneio" HeaderText="Romaneio" />
                                                <asp:BoundField DataField="nm_st_romaneio" HeaderText="Situa&#231;&#227;o" />
                                                <asp:BoundField DataField="cd_codigo_sap" HeaderText="C&#243;digo SAP" SortExpression="cd_codigo_sap" />
                                            </Columns>
                                            <FooterStyle Font-Names="Verdana" Font-Size="XX-Small" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <RowStyle BackColor="#EFF3FB" />
                                        </anthem:GridView>
										</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_load" />
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />


		</form>
	</body>
</HTML>
