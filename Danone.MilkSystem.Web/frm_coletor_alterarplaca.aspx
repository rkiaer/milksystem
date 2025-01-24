<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_coletor_alterarplaca.aspx.vb" Inherits="frm_coletor_alterarplaca" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
	
		<title>Alterar Placa</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" /> 
	
<script language="javascript" type="text/javascript">
// <!CDATA[

function Table2_onclick() {

}

// ]]>
</script>
</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" class="texto" >
		<form id="Form1" method="post" runat="server" >
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>&nbsp;Contingência para o Coletor - Alterar Placa&nbsp;</STRONG></TD>
					<TD style="width: 9px">&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="3" style="width: 9px; height: 19px;">&nbsp;</TD>
				</TR>
					<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
					
					
					<BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" onclick="return Table2_onclick()">
                             <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    </td>
                                <td style="height: 20px">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp; <strong>Nova Placa:</strong>&nbsp;&nbsp;<anthem:TextBox ID="txt_ds_placa_frete"
                                        runat="server" AutoUpdateAfterCallBack="True" CssClass="texto" Width="88px"></anthem:TextBox>
                                        <anthem:CustomValidator ID="cmv_placa_frete" runat="server" AutoUpdateAfterCallBack="True"
                                            ControlToValidate="txt_ds_placa_frete" CssClass="texto" ErrorMessage="Placa não cadastrada."
                                            Font-Bold="True" ValidationGroup="vg_salvar" ValidateEmptyText="True" ToolTip="Placa não cadastrada.">[!]</anthem:CustomValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp; <strong>Data Alteração:</strong>&nbsp;
                                        <anthem:Label ID="lbl_dt_alteracao_placa_frete" runat="server" CssClass="texto" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"></anthem:Label></td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD style="height: 12px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="left" style="height: 12px">
                                    &nbsp;
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btn_salvar" runat="server" CssClass="texto" Text="Salvar" ValidationGroup="vg_salvar" />
                                    <asp:Button ID="btn_fechar" runat="server" CssClass="texto" OnClientClick="javascript:window.close();"
                                        Text="Fechar" /></TD>
							</TR>
						</TABLE>
                                    </TD>
					<TD style="width: 9px">&nbsp;</TD>
				</TR>
			</TABLE>
            <cc1:alertmessages id="messageControl" runat="server"></cc1:alertmessages>
		</form>
	</body>
</HTML>
