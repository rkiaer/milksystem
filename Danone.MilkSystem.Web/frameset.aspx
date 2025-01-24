<%@ Page Language="VB" AutoEventWireup="true" CodeFile="frameset.aspx.vb" Inherits="frameset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Milk System</title>
</head>
<form>
<div>
<frameset rows="*,24" frameborder="0" border="0" framespacing="1" bordercolor="#52647a">
    <frameset rows="80,*" frameborder="0" border="0" framespacing="1" bordercolor="#52647a">
        <frame src="header_danone.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
        <frameset cols="180,*" frameborder="0" border="0" framespacing="1" bordercolor="52647a">
		    <frame src="Menu_login.aspx" name="leftFrame" scrolling="auto" id="leftFrame" title="leftFrame" />
		    <frame src="default.aspx" name="mainFrame" scrolling="auto" id="mainFrame" title="mainFrame" />
	    </frameset>
    </frameset>
    <frame src="rodape.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" title="bottomFrame" />
</frameset>
</div>
</form>
<body>
</body>
</html>
