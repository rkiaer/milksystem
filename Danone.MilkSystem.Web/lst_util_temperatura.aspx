<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lst_util_temperatura.aspx.vb" Inherits="lst_util_temperatura" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc1" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
		<title>lst_util_temperatura</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="width: 9px">&nbsp;</TD>
					<TD class="faixafiltro1" style="background-image: url(img/tab_dim.gif)"><STRONG>Utilitário - Corrigir Temperatura</STRONG></TD>
					<TD width="10">&nbsp;</TD>
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
					<TD style="width: 9px; height: 101px;">&nbsp;</TD>
					<TD id="td_pesquisa" runat="server" style="height: 101px"><BR>
						<TABLE class="borda" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
								<TD align="center" style="height: 34px" colspan="2">
                                    Ao acionar o botão 'Executar', todas as temperaturas superiores a 100 e temperaturas
                                    entre 10 e 100 das coletas realizadas serão alteradas.</TD>
                            </tr>
							<TR>
								<TD style="width: 125px">&nbsp;</TD>
								<TD align="right">
                                    &nbsp;<anthem:imagebutton id="btn_executar" runat="server" imageurl="~/img/bnt_executar.gif" OnClientClick="if (confirm('Deseja realmente corrigir as temperaturas?' )) return true;else return false;"></anthem:imagebutton>
                                    &nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
					<TD style="height: 101px">&nbsp;</TD>
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
		</form>
	</body>
</HTML>
