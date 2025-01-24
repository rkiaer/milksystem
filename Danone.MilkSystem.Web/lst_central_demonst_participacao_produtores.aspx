<%@ Page Language="VB" AutoEventWireup="true" CodeFile="lst_central_demonst_participacao_produtores.aspx.vb" Inherits="lst_central_demonst_participacao_produtores" %>

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
		<title>lst_central_relacao_produtores</title>
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 25px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 25px;">
                        <strong>Demonstrativo Participação Produtores</strong></TD>
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
					<TD style="width: 9px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" class="texto">
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="Texto" Width="192px">
                                    </anthem:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    &nbsp;EPL:</td>
                                <td style="height: 14px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_tecnico" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" MaxLength="10" Width="88px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_tecnico" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />&nbsp; 
                                    <anthem:Label ID="lbl_nm_tecnico" runat="server" AutoUpdateAfterCallBack="True" CssClass="Texto"
                                        Height="16px" UpdateAfterCallBack="True" style="vertical-align: bottom"></anthem:Label>
                                    <anthem:CustomValidator ID="cv_tecnico"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_cd_tecnico"
                                            CssClass="texto" ErrorMessage="Técnico não cadastrado." Font-Bold="True" ValidationGroup="vg_pesquisar" ToolTip="Técnico não cadastrado.">[!]</anthem:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cd_tecnico"
                                        ErrorMessage="Informe o Técnico." Font-Bold="True" ValidationGroup="vg_pesquisar" ToolTip="Informe o Técnico.">[!]</asp:RequiredFieldValidator>
                                    &nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp;
                                </td>
                                <td align="right" style="height: 20px">
                                </td>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;<span id="Span2" class="obrigatorio">*</span> Ano Referência:</td>
                                <td style="height: 20px">
                                    &nbsp;&nbsp;<cc3:onlynumberstextbox id="txt_dt_referencia" runat="server" autocallback="True"
                                        autoupdateaftercallback="True" cssclass="caixaTexto" maxlength="4" width="87px"></cc3:onlynumberstextbox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_referencia"
                                        ErrorMessage="Informe o Ano de Referência." Font-Bold="True" ValidationGroup="vg_load">[!]</asp:RequiredFieldValidator></td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD align="right" style="height: 25px">
                                    &nbsp;<anthem:imagebutton id="btn_pesquisa" runat="server" imageurl="img/bnt_pesquisa.gif" ValidationGroup="vg_load"></anthem:imagebutton>&nbsp;
                                    <anthem:ImageButton ID="btn_exportar" runat="server" ImageUrl="~/img/bnt_exportar.gif" ValidationGroup="vg_load" />&nbsp;<anthem:imagebutton id="btn_limparFiltros" runat="server" imageurl="img/btn_limparfiltro.gif"></anthem:imagebutton>
                                    &nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
                        </TD>
					<TD >&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;<asp:Image ID="img_novo" runat="server" ImageUrl="~/img/ic_impressao.gif" /><anthem:HyperLink
                            ID="hl_imprimir" runat="server" AutoUpdateAfterCallBack="True" CssClass="texto"
                            Enabled="False" NavigateUrl="~/frm_relatorio_motorista.aspx" Target="_blank"
                            UpdateAfterCallBack="True">Versão para Imprimir</anthem:HyperLink></TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
									
                                        <anthem:GridView ID="gridResults" runat="server" AllowSorting="True"
                                            AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="XX-Small" ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True" Width="100%" UpdateAfterCallBack="True" PageSize="8">
                                            <PagerStyle BackColor="#2461BF" Font-Names="Verdana" Font-Size="XX-Small"
                                                HorizontalAlign="Center" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="periodo" HeaderText="Per&#237;odo" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Faturamento Prod." DataField="nr_faturamento_produtores"><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Volume Prod." DataField="nr_volume_produtores"><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField HeaderText="N&#186; Prod." DataField="nr_produtores"><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="N&#186; Prod. Educampo" DataField="nr_produtores_educampo" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Prod. Central" DataField="nr_produtores_central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Educampo Central" DataField="nr_educampo_central" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Compras Central" DataField="nr_compras_central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
                                                <asp:BoundField HeaderText="Volume Central" DataField="nr_volume_central" ><itemstyle horizontalalign="Right" /></asp:BoundField>
                                                <asp:BoundField HeaderText="%" ><itemstyle horizontalalign="Center" /></asp:BoundField>
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
            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="True" />
            &nbsp;&nbsp;
		</form>
	</body>
</HTML>
