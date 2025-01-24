<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_nota_fiscal_narrativa.aspx.vb" Inherits="frm_nota_fiscal_narrativa" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>Nota Fiscal Entrada</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<base target ="_self" /> 
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" class="texto">
		<form id="Form1" method="post" runat="server" style="width: 400px">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Nota Fiscal Entrada - Narrativa&nbsp;</STRONG></TD>
					<TD style="width: 9px">&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="3" style="width: 9px; height: 19px;">&nbsp;</TD>
				</TR>
					<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server">
					
					
					<BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                             <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    </td>
                                <td style="height: 20px">
                                    &nbsp; <strong>Sequência:</strong>
                                    <asp:Label ID="lbl_sequencia" runat="server" CssClass="texto" Text="Label" Width="42px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp; <strong>Item:&nbsp; </strong><asp:Label ID="lbl_item" runat="server" Text="Label" Width="202px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    &nbsp;</td>
                                <td style="height: 20px">
                                    &nbsp;</td>
                            </tr>
                           <tr>
                                <td align="right" style="height: 20px" width="20%">
                                    Narrativa:</td>
                                <td style="height: 20px">
                                    &nbsp;
                                    <anthem:TextBox ID="txt_narrativa" runat="server" CssClass="caixaTexto" Width="700px" TextMode="MultiLine" Height="215px"></anthem:TextBox></td>
                            </tr>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD style="height: 12px">&nbsp;</TD>
							</TR>
							<TR>
								<TD style="height: 12px">&nbsp;</TD>
								<TD align="center" style="height: 12px">
                                    &nbsp;
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btn_salvar" runat="server" CssClass="texto" Text="Salvar" />
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
