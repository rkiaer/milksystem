<%@ Page Language="VB" AutoEventWireup="false" CodeFile="header.aspx.vb" Inherits="header" %>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<style type="text/css">

<!--
body {
	background-color: #63769e;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <!--<td style="width: 50%">
    <img src="img/logo.gif" width="122" height="40" /><img src="img/degrade_topo.gif" width="120" height="40" /></td> -->
                 <td style="width: 50%">
    <img src="img/logo.gif"  height="40" /><img src="img/degrade_topo.gif" width="120" height="40" /></td>
               <td style="width: 50%" >
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbl_usuario" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Font-Size="X-Small" ForeColor="White" Visible="False"></asp:Label>&nbsp&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
