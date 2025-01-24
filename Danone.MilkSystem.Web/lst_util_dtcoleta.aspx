<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_util_dtcoleta.aspx.vb" Inherits="lst_util_dtcoleta" %>

<%@ Register Assembly="RK.TextBox.AjaxOnlyNumbers" Namespace="RK.TextBox.AjaxOnlyNumbers"
    TagPrefix="cc2" %>

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
		<title>lst_conta_parcelada</title>
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
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Alterar Data de Coleta dos Cadastros</STRONG></TD>
					<TD width="10">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px"></TD>
					<TD align="center" style="width: 1014px">
						</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px; width: 9px;">&nbsp;</TD>
					<TD style="HEIGHT: 2px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif"></TD>
					<TD style="HEIGHT: 2px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="width: 9px; height: 145px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="width: 1014px; height: 145px;"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <TD style="HEIGHT: 26px; width: 25%;" align="right">
                                    &nbsp;<strong><span style="color: #ff0000">*</span></strong>Nr. Caderneta:</td>
                                <TD style="HEIGHT: 25px">
                                    &nbsp;
                                    <asp:TextBox ID="txt_nr_caderneta" runat="server" CssClass="texto" MaxLength="10"
                                        Width="72px"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nr_caderneta"
                                        ErrorMessage="Informe o número da caderneta." Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_nr_caderneta"
                                        CssClass="texto" ErrorMessage="Número da Caderneta deve ser informado apenas com números."
                                        SetFocusOnError="True" ValidationExpression="[0-9]*" ValidationGroup="vg_pesquisar" ToolTip="Número da Caderneta deve ser informado apenas com números.">[!]</asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_nr_caderneta"
                                        CssClass="texto" ErrorMessage="O número da caderneta deve ser maior que zero!"
                                        Operator="GreaterThan" SetFocusOnError="True" ToolTip="Número do caderneta deve ser maior que zero."
                                        ValidationGroup="vg_pesquisar" ValueToCompare="0">[!]</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px; width: 25%;" width="20%">
                                    <span class="obrigatorio">*</span>DE Data Coleta:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_de" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dt_coleta_de"
                                        ErrorMessage='Informe a  data de coleta a ser alterada no campo "DE Data Coleta".'
                                        Font-Bold="True" ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 26px; width: 25%;" width="20%">
                                    <span class="obrigatorio">*</span>PARA Data Coleta:</td>
                                <td style="height: 25px">
                                    &nbsp;
                                    <cc3:OnlyDateTextBox ID="txt_dt_coleta_para" runat="server" CssClass="texto" DateMask="DayMonthYear"
                                        Width="72px"></cc3:OnlyDateTextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dt_coleta_para"
                                        ErrorMessage='Informe a nova data de coleta no campo "PARA Data Coleta".' Font-Bold="True"
                                        ValidationGroup="vg_pesquisar">[!]</asp:RequiredFieldValidator></td>
                            </tr>
							<tr>
								<TD style="width: 25%; height: 26px">&nbsp;</TD>
								<TD align="right" style="height: 26px">
                                    &nbsp;<anthem:imagebutton id="btn_executar" runat="server" imageurl="~/img/bnt_executar.gif" ValidationGroup="vg_pesquisar"></anthem:imagebutton>
                                    &nbsp;</TD>
							</tr>
						</TABLE>
					</TD>
					<TD style="height: 145px">&nbsp;</TD>
				</TR>
                <tr>
                    <TD style="width: 9px; height: 64px;">
                        &nbsp;</td>
                    <TD id="Td1" runat="server" style="width: 1014px; height: 64px;">
                        <TABLE class="borda" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                            <tr>
                                <td align="center" style="height: 25px" colspan="2">
                                    Ao selecionar o botão "Executar", todas as datas de coleta da caderneta mencionada
                                    acima, que forem iguais a informada no campo "DE Data Coleta", serão substituídas
                                    para data informada na coluna "PARA Data Coleta".</td>
                            </tr>
                        </table>
                    </td>
                    <TD style="height: 64px">
                        &nbsp;</td>
                </tr>
				<TR>
					<TD style="HEIGHT: 24px; width: 9px;">&nbsp;</TD>
					<TD class="faixafiltro1a" style="HEIGHT: 24px; width: 1014px;" vAlign="middle" background="img/faixa_filro.gif">
						&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 24px;">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="height: 19px; width: 9px;"></TD>
					<TD vAlign="middle" style="height: 19px; width: 1014px;">&nbsp;</TD>
					<TD style="height: 19px;"></TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
            <anthem:ValidationSummary ID="validatorSummary" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="vg_pesquisar"  AutoUpdateAfterCallBack="true" />
                	    <div visible="false">
            <anthem:HiddenField ID="hf_id_pessoa" runat="server" AutoUpdateAfterCallBack="true" />
            <anthem:HiddenField ID="hf_id_propriedade" runat="server" AutoUpdateAfterCallBack="true" />
                            <anthem:HiddenField ID="hf_id_tecnico" runat="server" AutoUpdateAfterCallBack="true" />
        </div>
		</form>
	</body>
</HTML>
