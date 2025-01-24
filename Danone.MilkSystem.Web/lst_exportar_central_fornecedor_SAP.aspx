<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_exportar_central_fornecedor_SAP.aspx.vb" Inherits="lst_exportar_central_fornecedor_SAP" %>

<%@ Register Assembly="RK.TextBox.OnlyDate" Namespace="RK.TextBox.OnlyDate" TagPrefix="cc3" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyDate" Namespace="RK.TextBox.AjaxOnlyDate"
    TagPrefix="cc2" %>


<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_exportar_central_fornecedor</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<script type="text/javascript"> 

	    function ShowDialogFornecedor() 
    
    {
        
        var retorno="";
   	    var szUrl;
        var hf_id_fornecedor = document.getElementById("hf_id_fornecedor");
           	     
        szUrl = 'lupa_fornecedor.aspx';
        retorno = window.showModalDialog(szUrl, "",'help:no;status:no;scroll:yes;edge:raised;dialogWidth:500px;edge:raised;dialogHeight:400px')
        if (retorno!="" && retorno!=null)
            {
                hf_id_fornecedor.value=retorno;
                //alert(retorno);
            } 
         
    }                
   </script>

		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px; height: 27px;">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif); height: 27px;"><STRONG>Exportar Pagamento ao Fornecedor SAP</STRONG></TD>
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
								<TD width="15%" style="height: 12px"></TD>
								<TD width="30%" style="height: 12px; "></TD>
								<TD style="height: 12px; "></TD>
								<TD style="height: 12px"></TD>
							</TR>
                            <tr>
                                <td align="right" style="height: 21px" width="20%">
                                    &nbsp;Estabelecimento:</td>
                                <td style="height: 21px">
                                    &nbsp;&nbsp;<asp:DropDownList ID="cbo_estabelecimento" runat="server" CssClass="caixaTexto">
                                    </asp:DropDownList>
                                    <anthem:CompareValidator ID="CompareValidator2" runat="server" AutoUpdateAfterCallBack="True"
                                        ControlToValidate="cbo_estabelecimento" Display="Dynamic" ErrorMessage="O estabelecimento deve ser informado!"
                                        Operator="NotEqual" Type="Integer" ValueToCompare="0" Visible="False">[!]</anthem:CompareValidator></td>
                                <td align="right" style="height: 21px">
                                    <anthem:Label ID="Label1" runat="server" Text="Total de linhas exportadas:" Width="160px"></anthem:Label></td>
                                <td style="height: 21px">
                                    &nbsp;<anthem:Label ID="lbl_totallinhas" runat="server" Text="0" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Mes/Ano Referência Pagto:</td>
                                <td style="height: 21px; ">&nbsp;&nbsp;<cc3:OnlyDateTextBox ID="dt_referencia" runat="server" CssClass="texto"
                                        DateMask="MonthYear" Width="76px"></cc3:OnlyDateTextBox>&nbsp;
                                </td>
 								<TD  style="height: 21px;" align="right">
                                     <anthem:CheckBox ID="ck_pagtos_exportados" runat="server" Text="Pagamentos já exportados" /></TD>
								<TD style="height: 21px">
                                    &nbsp;</TD>
                            </tr>
                            <tr>
                                <td align="right" style="height: 21px" >
                                    <strong><span style="color: #ff0000">*</span></strong>Data de Pagto:</td>
                                <td style="height: 21px; ">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_pagto" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="76px"></cc3:OnlyDateTextBox>
                                    &nbsp; &nbsp;&nbsp;
                                </td>
                                <TD  style="height: 21px;" align="right">
                                </td>
                                <TD style="height: 21px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px">
                                    Parceiro Central:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_cd_fornecedor" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                        CssClass="caixaTexto" Width="88px"></anthem:TextBox>
                                    <anthem:ImageButton ID="img_lupa_fornecedor" runat="server" AutoUpdateAfterCallBack="true"
                                        BorderStyle="None" Height="15px" ImageAlign="AbsBottom" ImageUrl="~/img/lupa.gif"
                                        ToolTip="Filtrar Técnicos" Width="15px" />
                                    <anthem:Label ID="lbl_nm_fornecedor" runat="server" AutoUpdateAfterCallBack="True"
                                        CssClass="Texto" Height="16px" UpdateAfterCallBack="True"></anthem:Label>
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
							<TR>
								<TD style="height: 12px"></TD>
								<TD style="height: 12px;"></TD>
								<TD >&nbsp;</TD>
								<TD align="right">
                                    <asp:CustomValidator ID="cv_exportar" runat="server" CssClass="texto" Font-Bold="true"
                                        ForeColor="White" Text="[!]" ToolTip="Parceiro Não Cadastrado!" ValidationGroup="vg_exportar"></asp:CustomValidator>&nbsp;<anthem:imagebutton id="btn_exportar" runat="server" imageurl="~/img/bnt_exportar.gif" ValidationGroup="vg_exportar" ></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
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
					<TD style="width: 9px">&nbsp;</TD>
					<TD>
                        &nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_exportar" />
            <anthem:HiddenField ID="hf_id_fornecedor" runat="server" AutoUpdateAfterCallBack="True" />
		</form>
	</body>
</HTML>
