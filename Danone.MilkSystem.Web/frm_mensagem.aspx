<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_mensagem.aspx.vb" Inherits="frm_mensagem" %>

<%@ Register Assembly="RK.Ajax.AlertControl" Namespace="RK.Ajax.AlertControl" TagPrefix="cc2" %>

<%@ Register Assembly="RK.TextBox.AjaxCPF" Namespace="RK.TextBox.AjaxCPF" TagPrefix="cc1" %>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Untitled Page</title>
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <div id="corpo" style="text-align:center;vertical-align:top;">

<table>
<tr><td style="width: 783px"  >
<table width="100%" border="0" cellspacing="0" cellpadding="0" >
    <tr>
        <td style="width:1%; height: 19px;" rowspan="3" align="center" valign="top"></td>
        <td rowspan="3" align="center" valign="top" style="width: 48%; height: 19px;">
        </td>
        <td style="width:2%; height: 19px;" rowspan="3" align="center" valign="top"></td>
        <td style="width:48%; height: 19px;" align="center" valign="top">
	</td>
	<td style="width:2%; height: 19px;" rowspan="3" align="center" valign="top"></td>
  </tr>
</table><table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 128px"  >
    <tr>
        <td style="width:1%;" rowspan="3" align="center" valign="top">
        </td>
        <td class="caixatitulohome3" style="width: 776px; height: 24px;"   >
            <b></b></td>
        <td style="width:1%; " rowspan="3" align="center" valign="top">
        </td>
    </tr>
    <tr style="font-size: 12pt">
        <td align="center" class="caixaconteudohome2" style="text-align:center; width: 776px;" >
                        <table style="width:100%;text-align:center" border="0" >
				            <tr>
                                <td colspan="1" style="height: 10px">
                                </td>
					            <td colspan="4" style="height: 10px"></td>
				            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 15%; height: 105px; text-align: center">
                                </td>
                                <td style="height:105px;width:10%;text-align:center;vertical-align:middle" >
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/info.gif" />
                                </td>
                                <td style="height:105px;width:60%" align="center" valign="middle">
		                            <span class="textocaixahome2">
                                        <asp:Label ID="lbl_mensagem" runat="server"></asp:Label></span></td>
                                <td style="width:15%;text-align:center;" align="center" valign="middle" >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 15%; height: 13px; text-align: center">
                                </td>
                                <td align="center" style="vertical-align: middle; height: 13px; text-align: center"
                                    valign="middle">
                                </td>
                                <td align="center" style="width: 15%; height: 13px; text-align: center" valign="middle">
                                    <asp:ImageButton ID="btn_msgok" runat="server" ImageAlign="Middle" ImageUrl="~/img/bnt_ok.gif" /></td>
                            </tr>
                        </table>				        
        </td>
    </tr>
    <tr style="font-size: 12pt">
        <td class="caixabottomhome2" style="width:776px;height:19px;">
        </td>
    </tr>
</table>
</td>
</tr>
<tr>
<td style="width: 783px" ></td>
</tr>
    &nbsp;<tr>
<td style="width: 783px">
</td>
</tr>
</table>
            <cc2:alertmessages id="messagecontrol" runat="server" autoupdateaftercallback="True"
                updateaftercallback="True"></cc2:alertmessages>
        </div>
    </div>

    </form>
            		
</body>
</html>
