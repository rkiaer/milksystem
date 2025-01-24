<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_nota_fiscal_produtor_laser.aspx.vb" Inherits="lst_exportar_nota_fiscal_produtor_laser" %>

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
		<title>lst_exportar_nota_fiscal_produtor_laser</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
	
	<script type="text/javascript"> 

    function ShowDialogPropriedade() 
    
    {
        
        var idcboestabel;
        var retorno="";
   	    var szUrl;
        var hf_id_propriedade = document.getElementById("hf_id_propriedade");
   	     
        idcboestabel = document.getElementById("cbo_estabelecimento").value;
        
        if (idcboestabel == "0")
        {
            alert("O estabelecimento deve ser informado!");
        }
        else
        {
   	        
            szUrl = 'lupa_propriedade.aspx?id_estabelecimento='+idcboestabel+'';
            
            retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
            if (retorno!="" && retorno!=null)
            {
                hf_id_propriedade.value=retorno;
            } 
        }
    }            
</script>
	<script type="text/javascript"> 
    <!--
    function showaguarde() 
    
    {
        
        document.all.lbl_aguarde.value='aguardenormal';  	     
    }            
    //-->
    </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportar Nota Fiscal Produtor Laser</STRONG></TD>
					<TD width="10" style="height: 27px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 133px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 133px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="20%" style="height: 12px"></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <TD width="20%" style="HEIGHT: 25px" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Estabelecimento:</td>
                                <TD style="HEIGHT: 25px;">
                                    &nbsp;&nbsp;<asp:DropDownList id="cbo_estabelecimento" runat="server" CssClass="caixaTexto" Width="193px">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cbo_estabelecimento"
                                        Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!" Operator="NotEqual"
                                        Type="Integer" ValueToCompare="0" AutoUpdateAfterCallBack="True" ValidationGroup="vg_exportar">[!]</anthem:CompareValidator></td>
 								<TD  style="height: 25px; " align="right">
                                     <anthem:Label ID="lbl_totallidas" runat="server" Text="Total de linhas exportadas:"
                                         Width="160px"></anthem:Label></TD>
								<TD style="height: 25px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></TD>
                           </tr>
                            <tr>
                                <td align="right" style="height: 25px" >
                                    <span style="color: #ff0000"><strong>*</strong><span style="color: #333333">Mes/Ano
                                        Referência</span></span>:</td>
                                <td style="height: 25px; ">&nbsp;
                                    <cc2:OnlyDateTextBox ID="txt_dt_referencia" runat="server" CssClass="texto" DateMask="MonthYear"
                                        Width="76px"></cc2:OnlyDateTextBox><anthem:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            runat="server" AutoUpdateAfterCallBack="True" ControlToValidate="txt_dt_referencia"
                                            CssClass="texto" ErrorMessage="O Mes/Ano de Referência deve ser informado." Font-Bold="True" ValidationGroup="vg_exportar">[!]</anthem:RequiredFieldValidator></td>
								<TD style="height: 25px;" align="left">
                                    </TD>
								<TD style="height: 25px">
                                    &nbsp;</TD>
                            </tr>
                            <tr>
                                <td align="right" style="height: 25px">
                                    Nr. Nota Fiscal
                                </td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc3:onlynumberstextbox id="txt_nr_nota_fiscal_ini" runat="server" cssclass="texto"
                                        maxlength="6" width="64px"></cc3:onlynumberstextbox>
                                    &nbsp; à&nbsp;
                                    <cc3:onlynumberstextbox id="txt_nr_nota_fiscal_fim" runat="server" cssclass="texto"
                                        maxlength="6" width="64px"></cc3:onlynumberstextbox>&nbsp;
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txt_nr_nota_fiscal_fim"
                                        ControlToValidate="txt_nr_nota_fiscal_ini" ErrorMessage="O número informado para nota fiscal inicial não deve ser maior que o número informado para a nota fiscal final."
                                        Operator="LessThanEqual" Type="Double" ValidationGroup="vg_exportar">[!]</asp:CompareValidator><asp:CustomValidator
                                            ID="cv_range_nr_nota_fiscal" runat="server" ErrorMessage="CustomValidator" ValidationGroup="vg_exportar" Visible="False">[!]</asp:CustomValidator>
                                </td>
                                <td align="right" style=" height: 25px">
                                </td>
                                <td style="height: 25px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="texto" style="height: 24px" width="20%">
                                    <span style="color: #333333">Código Propriedade</span>:</td>
                                <td class="texto" style="height: 24px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_propriedade" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Width="72px"></anthem:TextBox>
                                    <anthem:Label ID="lbl_nm_propriedade" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" UpdateAfterCallBack="True" Visible="False"></anthem:Label>&nbsp;<anthem:ImageButton
                                            ID="btn_lupa_propriedade" runat="server" AutoUpdateAfterCallBack="true" BorderStyle="None"
                                            Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif" ToolTip="Filtrar Propriedades"
                                            Width="15px" />&nbsp;</td>
                                <td style="height: 24px; ">
                                </td>
                                <td style="height: 24px">
                                </td>
                            </tr>
							<TR>
								<TD style="height: 25px"></TD>
								<TD style="height: 25px;" align="center">
                                    <anthem:Label ID="lbl_aguarde" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" CssClass="aguardenormal" Width="100%">Aguarde... Geração do arquivo em andamento...</anthem:Label></TD>
								<TD style=" height: 25px;" align="center">&nbsp;<anthem:HyperLink ID="hl_download" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="texto" Enabled="False" NavigateUrl="~/frm_download.aspx" Style="text-align: center" ToolTip="Clique aqui para download do Arquivo de Impressão"
                                        UpdateAfterCallBack="True" EnableTheming="True" Font-Overline="False" Font-Underline="True">Clique aqui para download do Arquivo de Impressão</anthem:HyperLink></TD>
								<TD align="right" style="height: 25px">
                                    &nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ValidationGroup="vg_exportar" AutoUpdateAfterCallBack="True" ></anthem:imagebutton>&nbsp;</TD>
							</TR>
                            <tr>
                                <TD width="20%" style="height: 12px">
                                </td>
                                <td colspan="2" style="height: 12px">
                                    </td>
                                <TD style="height: 12px">
                                </td>
                            </tr>
						</TABLE>
					</TD>
					<TD style="height: 133px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px">&nbsp;</TD>
					<TD style="height: 19px"></TD>
				</TR>
				
				<TR>
					<TD style="width: 9px; height: 19px;">&nbsp;</TD>
					<TD style="height: 19px">
                        &nbsp;</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;">&nbsp;</TD>
					<TD vAlign="top" style="height: 19px">&nbsp;
					</TD>
					<TD style="height: 19px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_exportar" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                
		</form>
	</body>
</HTML>
