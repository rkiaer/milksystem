<%@ Page Language="VB" AutoEventWireup="false" CodeFile="header_danone.aspx.vb" Inherits="header_danone" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Danone</title>
    <meta name="author" content="RK Automação"/>
    <link href="css/estilo.css" rel="stylesheet" type="text/css"/>

</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
    <form id="rk_dan_header" bgcolor="FF0000" runat="server">
    <div style="width: 100%">
        <table  cellspacing="0" cellpadding="0" width="100%" border="0">
	        <tr>
	            <!--<td align="left" valign="top" style="width: 138px; height: 50px"  ><img  src="img/logo_danone.gif"/></td>-->
		        <td colspan="3" align="left" valign="top" style="height: 50px; background-image:url(img/faixaback_topo.gif)"  ><img  src="img/logo_danone.gif"/><img  src="IMG/faixa_topo4.gif" id="IMG1" /><img  src="IMG/faixa_topo5.gif" id="IMG2" /></td>
	        </tr>
			<tr> 
				<td width="50%" align="left"  style="background-image: url(img/header_faixa2.gif); height: 18px;" class="texto"></td>
				<td valign="top" width="30%" align="left"  style="background-image: url(img/header_faixa2.gif); height: 18px;" class="texto"><asp:Label ID="lbl_usuario" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" CssClass="texto" ForeColor="#023391"></asp:Label></td>
				<td  width="20%" align="left"  style="background-image: url(img/header_faixa2.gif); height: 18px;" class="texto"></td>
			</tr> 
	        
        </table>

    </div>
        </form>
</body>
</html>


